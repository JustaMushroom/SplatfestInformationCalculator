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
