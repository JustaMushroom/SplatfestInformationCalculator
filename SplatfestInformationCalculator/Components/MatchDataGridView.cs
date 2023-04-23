using SplatfestInformationCalculator.Splatfest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplatfestInformationCalculator.Components
{
	public class MatchDataGridView: DataGridView
	{
		int id = 0;
		public bool PaintRows = false;

		public MatchDataGridView() : base()
		{
			ColumnHeaderMouseDoubleClick += CellHeaderDoubleClick;
			CellMouseDoubleClick += CellDoubleClick;
			CellPainting += cellPainting;
		}

		private void CellHeaderDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			this.Sort(this.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
		}

		public void ClearData()
		{
			Rows.Clear();
			id = 0;
		}

		public void AddMatch(SplatfestMatch match, float contribution)
		{
			int idx = Rows.Add();
			DataGridViewRow row = Rows[idx];
			string lobby = match.Lobby.ToString();
			if (typeof(TricolorMatch).IsInstanceOfType(match))
			{
				lobby = "TRICOLOR";
			}
			decimal KD = match.CalulateKD();//Math.Round((decimal)(m.Kills / m.Deaths), 2);
			row.SetValues(new object[] { id, match.MatchID, lobby, match.Victory, match.KillsAssists.ToString() + " (" + match.Assists + ")", match.Deaths, KD, contribution });
			id++;
		}

		private void CellDoubleClick(object Sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.Columns[e.ColumnIndex].HeaderCell.RowIndex == e.RowIndex) return;
			string matchID = (string)this.Rows[e.RowIndex].Cells[1].Value;

			Match match;

			Match? ma = null;
			foreach (Match m in Form1.storedMatches)
			{
				if (m.MatchID == matchID)
				{
					ma = m;
				}
			}
			if (ma == null) return;

			match = (Match)ma;

			MatchInformationForm infoForm = new MatchInformationForm(match);

			infoForm.ShowDialog();
		}

		private void cellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (!PaintRows) return;
			if (e.RowIndex < 0) return;
			float cont = (float)Rows[e.RowIndex].Cells["Cont"].Value;

			Rectangle newRect = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4);

			using (
				Brush gridBrush = new SolidBrush(GridColor),
				backBrush = new SolidBrush(e.CellStyle.BackColor))
			{
				using (Pen gridLinePen = new Pen(gridBrush))
				{
					e.Graphics.FillRectangle(backBrush, e.CellBounds);

					e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
					e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

					if (cont > 0)
					{
						e.Graphics.DrawRectangle(Pens.LightGreen, newRect);
					}
					else if (cont < 0)
					{
						e.Graphics.DrawRectangle(Pens.Salmon, newRect);
					}
					else
					{
						e.Graphics.DrawRectangle(new Pen(backBrush), newRect);
					}

					if (e.Value != null)
					{
						e.Graphics.DrawString((string)e.Value, e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 2, StringFormat.GenericDefault);
					}
					e.Handled = true;
				}
			}

		}
	}
}
