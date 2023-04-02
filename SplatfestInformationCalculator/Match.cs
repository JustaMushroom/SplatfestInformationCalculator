using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SplatfestInformationCalculator
{
	public class Match
	{
		public string MatchID;
		public string Result { get; private set; }

		public bool? Victory
		{
			get
			{
				if (Result == "draw") return null;
				return Result == "win";
			}
		}

		public int MyInked;

		public int OurTeamInked;

		public float OurTeamPercent;

		public int TheirTeamInked;

		public float TheirTeamPercent;

		public int Kills;

		public int Assists;

		public int KillsAssists
		{
			get
			{
				return Kills + Assists;
			}
		}

		public int Deaths;

		public int Specials;

		public JsonNode OriginalData { get; private set; }

		public Match(JsonNode jsonData)
		{
			// set original data
			OriginalData = jsonData;

			// Map json parameters to fields
			MatchID = jsonData["id"]!.ToString();
			Result = jsonData["result"]!.ToString();
			MyInked = (int)jsonData["inked"]!;
			OurTeamInked = (int)jsonData["our_team_inked"]!;
			OurTeamPercent = float.Parse(jsonData["our_team_percent"]!.ToString());
			TheirTeamInked = (int)jsonData["their_team_inked"]!;
			TheirTeamPercent = float.Parse(jsonData["their_team_percent"]!.ToString()); ;
			Kills = (int)jsonData["kill"]!;
			Assists = (int)jsonData["assist"]!;
			Deaths = (int)jsonData["death"]!;
			Specials = (int)jsonData["special"]!;
		}

		public decimal CalulateKD()
		{
			decimal result = 0;
			if (Deaths == 0) return 99.99m;

			result = (decimal)KillsAssists / (decimal)Deaths;

			return Math.Round(result, 2);
		}
	}
}
