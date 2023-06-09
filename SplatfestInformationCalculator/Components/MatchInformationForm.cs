﻿using SplatfestInformationCalculator.Splatfest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplatfestInformationCalculator.Components
{
	public partial class MatchInformationForm : Form
	{
		public MatchInformationForm(Match match)
		{
			InitializeComponent();

			matchURLBox.Text = match.OriginalData["url"]!.ToString();
			matchURLBox.LinkClicked += LinkClicked;

			Match_InfoLbl.Text = $"Result: {match.Result}\nInked: {match.MyInked}p\nKills: {match.Kills}\nAssists: {match.Assists}\nDeaths: {match.Deaths}\nKDR: {match.CalulateKD()}\nSpecials: {match.Specials}";

			if (typeof(SplatfestMatch).IsInstanceOfType(match))
			{
				SplatfestMatch splMatch = (SplatfestMatch)match;
				Splatfest_InfoLbl.Text = "Clout change: " + (splMatch.IsMirror ? "0 (Mirror Match)" : splMatch.CloutDiff);
				if (typeof(TricolorMatch).IsInstanceOfType(match))
				{
					TricolorMatch triMatch = (TricolorMatch)match;
					Splatfest_InfoLbl.Text += $"\nYour Team's signal Attempts: {triMatch.OurSignalAttempts}\nYour Signal Attempts: {triMatch.MySignalAttempts}";
				}
				else
				{
					Splatfest_InfoLbl.Text += "\nMatch Type: " + SplatfestMatch.MultiplierToString(splMatch.MatchMult);
				}
				if (splMatch.Lobby == Splatfest.Generics.SplatfestLobbyType.SPLATFEST_PRO)
				{
					Splatfest_InfoLbl.Text += "\nFest Power: " + (splMatch.FestPower != null ? splMatch.FestPower : "N/A");
				}
			}
			else
			{
				Splatfest_InfoLbl.Text = "No Splatfest Information Detected!";
			}
		}

		private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(((LinkLabel)sender).Text) { UseShellExecute = true });
		}

		private new void Show()
		{
			ShowDialog();
		}
	}
}
