using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplatfestInformationCalculator.Splatfest.Generics
{
	public enum SplatfestLobbyType
	{
		INVALID,
		SPLATFEST_OPEN,
		SPLATFEST_PRO
	}
	public enum TricolorTeam
	{
		ATTACKER,
		DEFENDER
	}

	public enum SplatfestMatchMultiplier
	{
		ONE_TIMES,
		TEN_TIMES,
		ONEHUNDRED_TIMES,
		THREETHREETHREE_TIMES
	}

	public enum TricolorTeamCtxType
	{
		OUR_TEAM,
		THEIR_TEAM,
		THIRD_TEAM
	}
}
