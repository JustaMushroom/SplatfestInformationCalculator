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
		public string result;

		public bool? Victory
		{
			get
			{
				if (result == "draw") return null;
				return result == "win";
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
			result = jsonData["result"]!.ToString();
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
	}
}
