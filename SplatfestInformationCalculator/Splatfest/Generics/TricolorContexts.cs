using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplatfestInformationCalculator.Splatfest.Generics
{
	public struct TriTeamContext
	{
		public TricolorTeam OurTeam;
		public TricolorTeam TheirTeam;
		public TricolorTeam ThirdTeam;
	}

	public struct TriThemeContext
	{
		public string OurTeam;
		public string TheirTeam;
		public string ThirdTeam;
	}
}
