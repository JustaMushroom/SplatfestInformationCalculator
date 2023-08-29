using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SplatfestInformationCalculator.Splatfest
{
    public struct SplatfestData
    {
        public DateTime Start;
        public DateTime End;
        public string[] Options;
        public string Prompt;
        public string Halftime1st;
        public Dictionary<string, string> ThemeColors;

        public string SplatfestName
        {
            get
            {
                return String.Join(" vs. ", Options);
            }
        }
    }
}
