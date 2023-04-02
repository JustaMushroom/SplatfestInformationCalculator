using System;
using System.Collections.Generic;
using System.Diagnostics;
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
			CellMouseDoubleClick += CellDoubleClick;
		}

		private void CellHeaderDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			this.Sort(this.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
		}

		private void CellDoubleClick(object Sender, DataGridViewCellMouseEventArgs e)
		{
			Debug.WriteLine("Cell Double Clicked!");
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
			if (ma == null)
			{
				Debug.WriteLine("Match \"" + matchID + "\" not found");
				return;
			} ;

			match = (Match)ma;

			// TODO: Make new info dialog form for match
			MatchInformationForm infoForm = new MatchInformationForm(match);

			// TODO: Display form using ShowDialog();
			infoForm.ShowDialog();
		}
	}
}
