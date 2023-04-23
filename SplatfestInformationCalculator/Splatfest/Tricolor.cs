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

		public int OurSignalAttempts;
		public int TheirSignalAttempts;
		public int ThirdSignalAttempts;

		public TriTeamContext TeamContext;

		public TriThemeContext ThemeContext;

		public static TricolorTeam? GetTeam(string teamKey)
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

		public TricolorTeamCtxType? GetOtherAttacker()
		{
			if (TeamContext.TheirTeam == TricolorTeam.ATTACKER)
			{
				return TricolorTeamCtxType.THEIR_TEAM;
			}
			else if (TeamContext.ThirdTeam == TricolorTeam.ATTACKER)
			{
				return TricolorTeamCtxType.THIRD_TEAM;
			}
			return null;
		}

		public float GetTeamPercent(TricolorTeamCtxType team)
		{
			switch (team)
			{
				case TricolorTeamCtxType.OUR_TEAM:
					return OurTeamPercent;
				case TricolorTeamCtxType.THEIR_TEAM:
					return TheirTeamPercent;
				case TricolorTeamCtxType.THIRD_TEAM:
					return ThirdTeamPercent;
			}
			return 0; // Why does visual studio force me to add this?
		}

        public float GetTeamSignals(TricolorTeamCtxType team)
        {
            switch (team)
            {
                case TricolorTeamCtxType.OUR_TEAM:
                    return OurSignalAttempts;
                case TricolorTeamCtxType.THEIR_TEAM:
                    return TheirSignalAttempts;
                case TricolorTeamCtxType.THIRD_TEAM:
                    return ThirdSignalAttempts;
            }
            return 0; // Why does visual studio force me to add this?
        }

        private int calculateTeamSignalAttempts(JsonNode jsonData, string keyName, TricolorTeam teamType)
		{
			int sigs = 0;

			int teamMembers = 2;

			if (teamType == TricolorTeam.DEFENDER) teamMembers = 4;

			for (int i = 0; i < teamMembers; i++)
			{
				int? signals = (int?)jsonData[keyName]![i]!["signal"]!;
				if (signals == null) continue;
				sigs += (int)signals;
			}

			return sigs;
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

			OurSignalAttempts = calculateTeamSignalAttempts(jsonData, "our_team_members", TeamContext.OurTeam);
			TheirSignalAttempts = calculateTeamSignalAttempts(jsonData, "their_team_members", TeamContext.TheirTeam);
			ThirdSignalAttempts = calculateTeamSignalAttempts(jsonData, "third_team_members", TeamContext.ThirdTeam);
		}
	}
}
