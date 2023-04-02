using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplatfestInformationCalculator.Components
{
	public class MatchDataGridView: DataGridView
	{
		public MatchDataGridView() : base()
		{
			ColumnHeaderMouseDoubleClick += CellHeaderDoubleClick;
			//Uncomment when CellDoubleClick is done
			//dataGridView1.CellMouseDoubleClick += CellDoubleClick;
		}

		private void CellHeaderDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			Sort(null, System.ComponentModel.ListSortDirection.Ascending);
		}

		private void CellDoubleClick(object Sender, DataGridViewCellMouseEventArgs e)
		{
			string matchID = (string)this.Rows[e.RowIndex].Cells[0].Value;

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

			// TODO: Make new info dialog form for match

			// TODO: Display form using ShowDialog();
		}
	}
}
