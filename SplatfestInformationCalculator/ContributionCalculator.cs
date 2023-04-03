using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplatfestInformationCalculator.Splatfest;
using SplatfestInformationCalculator.Splatfest.Generics;

namespace SplatfestInformationCalculator
{
    public abstract class ContributionCalculator
    {
        private static readonly int ESTIMATED_SIGNALS = 1;

        public static Dictionary<string, TricolorTeam> GeneratePreferredPositions(string[] options, string halftime1st)
        {
            Dictionary<string, TricolorTeam> preferredPositions = new Dictionary<string, TricolorTeam>();

            foreach (string option in options)
            {
                if (option == halftime1st)
                {
                    preferredPositions.Add(option, TricolorTeam.DEFENDER);
                }
                else
                {
                    preferredPositions.Add(option, TricolorTeam.ATTACKER);
                }
            }

            return preferredPositions;
        }

        public static float EstimateOpenContribution(SplatfestMatch match)
        {
            float clout = match.MyInked;

            if (match.IsMirror) return 0;

            if (match.Victory == true)
            {
                clout += 1000;
            }
            else if (match.Victory == false)
            {
                clout -= 1000 + (match.TheirTeamInked / 4);
            }
            else if (match.Victory == null) return 0;

            if (match.MatchMult == SplatfestMatchMultiplier.TEN_TIMES) clout *= 10;
            else if (match.MatchMult == SplatfestMatchMultiplier.ONEHUNDRED_TIMES) clout *= 100;
            else if (match.MatchMult == SplatfestMatchMultiplier.THREETHREETHREE_TIMES) clout *= 333;

            return clout;
        }

        public static float EstimateProContribution(SplatfestMatch match)
        {
            float clout = 0f;

            float matchPower = 1000f;

            if (match.FestPower != null) matchPower = (float)match.FestPower;

            if (match.Victory == true)
            {
                return match.CloutDiff;
            }
            else if (match.Victory == false)
            {
                clout -= matchPower;
            }
            else if (match.Victory == null) return 0;


            if (match.MatchMult == SplatfestMatchMultiplier.TEN_TIMES) clout *= 10;
            else if (match.MatchMult == SplatfestMatchMultiplier.ONEHUNDRED_TIMES) clout *= 100;
            else if (match.MatchMult == SplatfestMatchMultiplier.THREETHREETHREE_TIMES) clout *= 333;

            return clout;
        }

        public static float EstimateTricolorContribution(TricolorMatch match, Dictionary<string, TricolorTeam> preferredTeams)
        {
            if (match.Victory == null || match.IsMirror) return 0;
            float clout = match.CloutDiff;

            float ourMultiplier = 1f;
            if (match.TeamContext.OurTeam == preferredTeams[match.ThemeContext.OurTeam]) ourMultiplier = 1.5f;

            if (match.Victory == true) clout /= ourMultiplier;

            if (match.TeamContext.OurTeam == TricolorTeam.ATTACKER)
            {
                TricolorTeamCtxType otherAttacker = (TricolorTeamCtxType)match.GetOtherAttacker()!;

                float otherAttackerPercent = match.GetTeamPercent(otherAttacker);

                if ((bool)match.Victory)
                {
                    if (match.OurTeamPercent > otherAttackerPercent)
                    {
                        clout -= 6000;
                    }
                    else
                    {
                        clout -= 5000;
                    }
                }

                int ourSignalClaims = Convert.ToInt32(Math.Floor(clout / 2500));

                int unsuccessfulClaims = (int)(clout - (ourSignalClaims * 2500)) / 300;

                int avgAttemptsPerSuccessfulClaim = match.OurSignalAttempts - unsuccessfulClaims;

                float otherAttackerAttempts = 0f;

                if (ourSignalClaims >= 1) otherAttackerAttempts = match.GetTeamSignals(otherAttacker) - (avgAttemptsPerSuccessfulClaim * (ESTIMATED_SIGNALS - ourSignalClaims));

                float otherClout = 0;

                if ((bool)match.Victory)
                {
                    if (match.OurTeamPercent > otherAttackerPercent)
                    {
                        otherClout = 5000 + (otherAttackerAttempts * 300) + (2500 * (ESTIMATED_SIGNALS - ourSignalClaims));
                    }
                    else
                    {
                        otherClout = 6000 + (otherAttackerAttempts * 300) + (2500 * (ESTIMATED_SIGNALS - ourSignalClaims));
                    }
                }
                else
                {
                    otherClout = (otherAttackerAttempts * 300) + (2500 * (ESTIMATED_SIGNALS - ourSignalClaims));
                }

                float defenderClout = 0;

                if ((bool)match.Victory == true)
                {
                    // Apply applicable multipler to other attackers
                    if (otherAttacker == TricolorTeamCtxType.THEIR_TEAM && match.TeamContext.TheirTeam == preferredTeams[match.ThemeContext.TheirTeam]) otherClout *= 1.5f;
                    if (otherAttacker == TricolorTeamCtxType.THIRD_TEAM && match.TeamContext.ThirdTeam == preferredTeams[match.ThemeContext.ThirdTeam]) otherClout *= 1.5f;

                    // Calculate defender clout
                    if (otherAttacker == TricolorTeamCtxType.THEIR_TEAM) defenderClout = (match.ThirdTeamInked / 4);
                    if (otherAttacker == TricolorTeamCtxType.THIRD_TEAM) defenderClout = (match.TheirTeamInked / 4);
                }
                else if ((bool)match.Victory == false)
				{
                    // Calculate defender clout
                    if (otherAttacker == TricolorTeamCtxType.THEIR_TEAM) defenderClout = 9000 + (match.ThirdTeamInked / 4);
                    if (otherAttacker == TricolorTeamCtxType.THIRD_TEAM) defenderClout = 9000 + (match.TheirTeamInked / 4);

                    // Apply applicable multiplier to defenders
                    if (otherAttacker == TricolorTeamCtxType.THEIR_TEAM && match.TeamContext.ThirdTeam == preferredTeams[match.ThemeContext.ThirdTeam]) defenderClout *= 1.5f;
                    if (otherAttacker == TricolorTeamCtxType.THIRD_TEAM && match.TeamContext.TheirTeam == preferredTeams[match.ThemeContext.TheirTeam]) defenderClout *= 1.5f;
                }

                return match.CloutDiff - ((otherClout + defenderClout) / 2);
            }
            else if (match.TeamContext.OurTeam == TricolorTeam.DEFENDER)
            {
                int theirClout = (300 * (int)Math.Floor((double)7 / 2)) + 2500;
                int thirdClout = 300 * (int)Math.Floor((double)7 / 2);

                if ((bool)match.Victory)
                {
                    return match.CloutDiff - ((theirClout + thirdClout) / 2);
                }
                else
                {
                    if (match.TheirTeamPercent > match.ThirdTeamPercent)
                    {
                        theirClout += 6000;
                        thirdClout += 5000;
                    }
                    else
                    {
                        theirClout += 5000;
                        thirdClout += 6000;
                    }

                    return match.CloutDiff - ((theirClout + thirdClout) / 2);
                }
            }
            return 0;
        }
    }
}
