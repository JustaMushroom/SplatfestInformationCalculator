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
		public MatchDataGridView() : base()
		{
			ColumnHeaderMouseDoubleClick += CellHeaderDoubleClick;
			CellMouseDoubleClick += CellDoubleClick;
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
	}
}
