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
		}

		private void CellHeaderDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			Sort(null, System.ComponentModel.ListSortDirection.Ascending);
		}
	}
}
