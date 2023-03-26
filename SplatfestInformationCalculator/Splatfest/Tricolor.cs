using SplatfestInformationCalculator.Splatfest.Generics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

		public TriTeamContext TeamContext;

		public TriThemeContext ThemeContext;

		public TricolorTeam? GetTeam(string teamKey)
		{
			switch (teamKey)
			{
				case "defender":
					{
						return TricolorTeam.DEFENDER;
					}
				case "attacker":
					{
						return TricolorTeam.ATTACKER;
					}
			}
			return null;
		}

		public TricolorMatch(JsonNode jsonData): base(jsonData)
		{
			ThirdTeamInked = (int)jsonData["third_team_inked"]!;
			ThirdTeamPercent = float.Parse(jsonData["third_team_percent"]!.ToString());
			MySignalAttempts = (int)jsonData["signal"]!;

			TeamContext = new TriTeamContext()
			{
				OurTeam = (TricolorTeam)GetTeam(jsonData["our_team_role"]!["key"]!.ToString())!,
				TheirTeam = (TricolorTeam)GetTeam(jsonData["their_team_role"]!["key"]!.ToString())!,
				ThirdTeam = (TricolorTeam)GetTeam(jsonData["third_team_role"]!["key"]!.ToString())!
			};

			ThemeContext = new TriThemeContext()
			{
				OurTeam = jsonData["our_team_theme"]!.ToString(),
				TheirTeam = jsonData["their_team_theme"]!.ToString(),
				ThirdTeam = jsonData["third_team_theme"]!.ToString()
			};
		}
	}
}
