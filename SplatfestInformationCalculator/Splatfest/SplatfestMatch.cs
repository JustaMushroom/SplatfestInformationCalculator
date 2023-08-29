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
		private static readonly int COLOR_DIFF_THRESHOLD = 5;
		public int CloutDiff;

		public float? FestPower;

		public SplatfestLobbyType Lobby;

		public bool IsMirror;

		public SplatfestMatchMultiplier MatchMult;

		public static string MultiplierToString(SplatfestMatchMultiplier mult)
		{
			switch (mult)
			{
				case SplatfestMatchMultiplier.TEN_TIMES:
					return "10x";
				case SplatfestMatchMultiplier.ONEHUNDRED_TIMES:
					return "100x";
				case SplatfestMatchMultiplier.THREETHREETHREE_TIMES:
					return "333x";
				default:
					return "1x";
			}
		}

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

			if (jsonData["our_team_theme"] != null)
			{
				IsMirror = jsonData["our_team_theme"]!.ToString() == jsonData["their_team_theme"]!.ToString();
			}
			else
			{
				IsMirror = CalculateIsMirrorFromInkColor(jsonData["our_team_color"]!.ToString());
			}

			if (jsonData["fest_dragon"] != null) MatchMult = stringToMultiplier(jsonData["fest_dragon"]!["key"]!.ToString());
			else MatchMult = SplatfestMatchMultiplier.ONE_TIMES;

			Lobby = mapLobbyType(jsonData["lobby"]!["key"]!.ToString());
		}

		private static List<String> deconstructHexIntoBase16Pairs(string s)
		{
            return Enumerable.Range(0, (s.Length + 1) / 2)
                .Select(i =>
                    s[i * 2] +
                    ((i * 2 + 1 < s.Length) ?
                    s[i * 2 + 1].ToString() :
                    string.Empty))
                .ToList();
        }

		public static bool CalculateIsMirrorFromInkColor(string inkColor)
		{
			List<int> inkColorRGBA = deconstructHexIntoBase16Pairs(inkColor).Select<string, int>(i => Convert.ToInt32(i, 16)).ToList();
			foreach (string regColor in Form1.Colors)
			{
				List<int> regColorRGBA = deconstructHexIntoBase16Pairs(regColor).Select<string, int>(i => Convert.ToInt32(i, 16)).ToList();
                bool rDiff = Math.Abs(inkColorRGBA[0] - regColorRGBA[0]) < COLOR_DIFF_THRESHOLD;
                bool gDiff = Math.Abs(inkColorRGBA[1] - regColorRGBA[1]) < COLOR_DIFF_THRESHOLD;
                bool bDiff = Math.Abs(inkColorRGBA[2] - regColorRGBA[2]) < COLOR_DIFF_THRESHOLD;

				if (rDiff && gDiff && bDiff) return true;
            }
			return false;
		}

	}
}
