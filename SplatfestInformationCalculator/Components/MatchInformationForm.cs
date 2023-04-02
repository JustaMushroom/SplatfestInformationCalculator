﻿using System;
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
		}
		private new void Show() { }
	}
}
