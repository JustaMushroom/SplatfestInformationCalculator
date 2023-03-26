using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SplatfestInformationCalculator.Splatfest
{
	public class TricolorMatch: SplatfestMatch
	{
		public int ThirdTeamInked;

		public float ThirdTeamPercent;

		public int MySignalAttempts;

		public TricolorMatch(JsonNode jsonData): base(jsonData)
		{
			ThirdTeamInked = (int)jsonData["third_team_inked"]!;
			ThirdTeamPercent = float.Parse(jsonData["third_team_percent"]!.ToString());
			MySignalAttempts = (int)jsonData["signal"]!;
		}
	}
}
