using System;
using System.Collections.Generic;
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

		public int? FestPower;

		public SplatfestLobbyType Lobby;

		private SplatfestLobbyType mapLobbyType(string lobbyKey)
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
			FestPower = (int?)jsonData["fest_power"];
			Lobby = mapLobbyType(jsonData["lobby"]!["key"]!.ToString());
		}

	}
}
