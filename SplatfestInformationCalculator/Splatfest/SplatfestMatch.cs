using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SplatfestInformationCalculator.Splatfest.Generics;

namespace SplatfestInformationCalculator.Splatfest
{
	public class SplatfestMatch: Match
	{
		public int CloutDiff;

		public float? FestPower;

		public SplatfestLobbyType Lobby;

		public bool IsMirror;

		public SplatfestMatchMultiplier MatchMult;

		private static SplatfestMatchMultiplier stringToMultiplier(string key)
		{
			switch (key)
			{
				case "10x":
					{
						return SplatfestMatchMultiplier.TEN_TIMES;
					}
				case "100x":
					{
						return SplatfestMatchMultiplier.ONEHUNDRED_TIMES;
					}
				case "333x":
					{
						return SplatfestMatchMultiplier.THREETHREETHREE_TIMES;
					}
				default:
					{
						return SplatfestMatchMultiplier.ONE_TIMES;
					}
			}
		}


		private static SplatfestLobbyType mapLobbyType(string lobbyKey)
		{
			switch (lobbyKey)
			{
				case "splatfest_open":
					{
						return SplatfestLobbyType.SPLATFEST_OPEN;
					}
				case "splatfest_challenge":
					{
						return SplatfestLobbyType.SPLATFEST_PRO;
					}
				default:
					{
						return SplatfestLobbyType.INVALID;
					}
			}
		}

		public SplatfestMatch(JsonNode jsonData) : base(jsonData)
		{
			CloutDiff = (int)jsonData["clout_change"]!;
			FestPower = (float?)jsonData["fest_power"];

			IsMirror = jsonData["our_team_theme"]!.ToString() == jsonData["their_team_theme"]!.ToString();

			if (jsonData["fest_dragon"] != null) MatchMult = stringToMultiplier(jsonData["fest_dragon"]!["key"]!.ToString());
			else MatchMult = SplatfestMatchMultiplier.ONE_TIMES;

			Lobby = mapLobbyType(jsonData["lobby"]!["key"]!.ToString());
		}

	}
}
