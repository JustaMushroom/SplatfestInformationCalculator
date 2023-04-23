﻿using SplatfestInformationCalculator.Splatfest;
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
			if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
			float cont = (float)Rows[e.RowIndex].Cells["Cont"].Value;

			// Paint the cell background
			if (cont > 0)
			{
				e.Graphics.FillRectangle(Brushes.LightGreen, e.CellBounds);
			}
			else if (cont < 0)
			{
				e.Graphics.FillRectangle(Brushes.Salmon, e.CellBounds);
			}
			else
			{
				e.PaintBackground(e.CellBounds, true);
			}

			// Paint the cell borders
			e.Paint(e.CellBounds, DataGridViewPaintParts.Border);

			// Paint the cell content
			e.PaintContent(e.CellBounds);

			// Tell Windows Forms that we've handled this cell
			e.Handled = true;


		}
	}
}
