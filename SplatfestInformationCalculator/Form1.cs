using SplatfestInformationCalculator.Splatfest;
using System.Text.Json.Nodes;
using System.Diagnostics;
using SplatfestInformationCalculator.Splatfest.Generics;
using SplatfestInformationCalculator.Components;
using System.Configuration;

namespace SplatfestInformationCalculator
{
	public partial class Form1 : Form
	{
		public static List<Match> storedMatches;
		List<SplatfestData> fests;
		public static SplatfestData LoadedFest { get; private set; }
		public static readonly HttpClient client = new HttpClient();

		public static List<string> Colors = new List<string>() { // Catalog of default ink colors
			"1a1aaeff", //BlueYellow [A]
			"e38d24ff", //BlueYellow [B]
			"a0c937ff", //GreenPurple [A]
			"ba30b0ff", //GreenPurple [B]
			"de6624ff", //OrangeBlue [A]
			"343bc4ff", //OrangeBlue [B]
			"cd510aff", //OrangePurple [A]
			"6e04b6ff", //OrangePurple [B]
			"c12d74ff", //PinkGreen [A]
			"2cb721ff", //PinkGreen [B]
			"1bbeabff", //TurquoisePink [A]
			"c43a6eff", //TurquoisePink [B]
			"1ec0adff", //TurquoiseRed [A]
			"d74b31ff", //TurquoiseRed [B]
			"d0be08ff", //YellowBlue [A]
			"3a0ccdff", //YellowBlue [B]
			"ceb121ff", //YellowPurple [A]
			"9025c6ff", //YellowPurple [B]
		};


        public Form1()
		{
			InitializeComponent();
			showContributionColorsToolStripMenuItem.Checked = Properties.Settings.Default.PaintRows;
			loadSplatfests();
			storedMatches = new List<Match>();
			matchDataGridView1.PaintRowsChanged += showContributionColorsToolStripMenuItem_Changed;
			FormClosing += ExitForm;
		}
		private void ExitForm(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.ApplicationExitCall || e.CloseReason == CloseReason.UserClosing)
			{
				Properties.Settings.Default.Save();
			}
		}

		private SplatfestData? getFestFromName(string SplatfestName)
		{
			foreach (SplatfestData data in fests)
			{
				if (data.SplatfestName == SplatfestName) return data;
			}
			return null;
		}

		private async void loadSplatfests()
		{
			fests = new List<SplatfestData>();
			//string jsonData = File.ReadAllText("../../../../splatfests.json");
			string festURL = Properties.Settings.Default.FestURL; // URL to download splatfest data from

			bool error = true;
			HttpResponseMessage response;
			string jsonData = "{}";
			while (error)
			{
				try
				{
					Debug.WriteLine("Requesting Splatfest Information...");
					response = await client.GetAsync(festURL);
					response.EnsureSuccessStatusCode();
					jsonData = await response.Content.ReadAsStringAsync();
					error = false;
				}
				catch (HttpRequestException)
				{
					Debug.WriteLine("HTTP Error! Retrying...");
					await Task.Delay(2500);
				}
			}

			Debug.WriteLine("Splatfests Downloaded! Parsing Information...");
			JsonNode matchNode = JsonNode.Parse(jsonData)!;

			foreach (JsonNode node in matchNode["fests"]!.AsArray())
			{
				if (node["timing"]!["start"] == null) continue;

				string ht1 = "null";
				if (node["halftime_1st"] != null) ht1 = node["halftime_1st"].ToString();


				SplatfestData fest = node["colors"] == null ? new SplatfestData()
				{
					Start = unixTimestampToDateTime((long)node["timing"]!["start"]!),
					End = unixTimestampToDateTime((long)node["timing"]!["end"]!),
					Options = jsonArrayToStringArray(node["options"]!.AsArray()),
					Prompt = node["prompt"]!.ToString(),
					Halftime1st = ht1,
					ThemeColors = null
				} : new SplatfestData()
				{
					Start = unixTimestampToDateTime((long)node["timing"]!["start"]!),
					End = unixTimestampToDateTime((long)node["timing"]!["end"]!),
					Options = jsonArrayToStringArray(node["options"]!.AsArray()),
					Prompt = node["prompt"]!.ToString(),
					Halftime1st = ht1,
					ThemeColors = new Dictionary<string, string>()
					{
						{node["options"]![0]!.ToString(), node["colors"]![0]!.ToString() },
						{node["options"]![1]!.ToString(), node["colors"]![1]!.ToString() },
						{node["options"]![2]!.ToString(), node["colors"]![2]!.ToString() },
						{"Neutral", node["colors"]![3]!.ToString() }
					}
				};



                splatfestComboBox.Items.Add(fest.SplatfestName);
				fests.Add(fest);
			}
			Debug.WriteLine("Splatfests Loaded!");
		}

		private string[] jsonArrayToStringArray(JsonArray array)
		{
			List<string> outputList = new List<string>();

			foreach (JsonNode node in array)
			{
				outputList.Add(node!.ToString());
			}
			return outputList.ToArray();
		}

		private DateTime unixTimestampToDateTime(long unixTimestamp)
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
			dateTime = dateTime.AddSeconds(unixTimestamp);
			return dateTime;
		}

		private async void LoadMatches(string Username, SplatfestData data)
		{
			if (Username.StartsWith("@")) Username = Username.Substring(1);
			loadLogTextBox.Text += "Loading matches for " + Username + "..." + Environment.NewLine;
			matchDataGridView1.ClearData();
			string URL = "https://stat.ink/@" + Username + "/spl3/index.json?f[lobby]=@splatfest&f[rule]=&f[map]=&f[weapon]=&f[result]=&f[knockout]=&f[term]=term&f[term_from]=" + data.Start.ToString("yyyy-MM-dd HH:mm:ss") + "&f[term_to]=" + data.End.ToString("yyyy-MM-dd HH:mm:ss");

			bool error = true;
			HttpResponseMessage response;
			string jsonStr = "{}";
			while (error)
			{
				try
				{
					loadLogTextBox.Text += "Requesting matches from stat.ink" + Environment.NewLine;
					response = await client.GetAsync(URL);
					response.EnsureSuccessStatusCode();
					jsonStr = await response.Content.ReadAsStringAsync();
					error = false;
				}
				catch (HttpRequestException)
				{
					loadLogTextBox.Text += "HTTP request error! Retrying..." + Environment.NewLine;
					await Task.Delay(2500);
				}
			}
			LoadedFest = data;
			Dictionary<string, TricolorTeam> preferredPos = ContributionCalculator.GeneratePreferredPositions(data.Options, data.Halftime1st);

			JsonNode matchListNode = JsonNode.Parse(jsonStr)!;

			loadLogTextBox.Text += "Received " + matchListNode!.AsArray().Count + " matches from stat.ink" + Environment.NewLine;

			List<Match> matches = new List<Match>();

			loadLogTextBox.Text += "Parsing matches..." + Environment.NewLine;
			int skippedMatches = 0;
			foreach (JsonNode node in matchListNode!.AsArray())
			{
				if (node == null) continue;

				if (node["our_team_percent"] == null) continue;

				SplatfestMatch m;
				float cont = 0;

				if (node["rule"]!["key"]!.ToString() == "tricolor")
				{
					if (Properties.Settings.Default.ProcessTricolor == false || (node["our_team_theme"] == null && data.ThemeColors == null))
					{
						skippedMatches++;
						continue;
					}
					m = new TricolorMatch(node);
					cont = ContributionCalculator.EstimateTricolorContribution((TricolorMatch)m, preferredPos);
				}
				else
				{
					m = new SplatfestMatch(node);
					if (m.Lobby == SplatfestLobbyType.SPLATFEST_OPEN)
                    {
                        if (Properties.Settings.Default.ProcessOpen == false)
                        {
                            skippedMatches++;
                            continue;
                        }
                        cont = ContributionCalculator.EstimateOpenContribution(m);
					}
					else if (m.Lobby == SplatfestLobbyType.SPLATFEST_PRO)
                    {
                        if (Properties.Settings.Default.ProcessPro == false)
                        {
                            skippedMatches++;
                            continue;
                        }
                        cont = ContributionCalculator.EstimateProContribution(m);
					}
				}
				matches.Add(m);

				matchDataGridView1.AddMatch(m, cont);
			}

			storedMatches = matches;
			loadLogTextBox.Text += "Matches successfully loaded!" + Environment.NewLine;
			if (skippedMatches > 0) loadLogTextBox.Text += $"{skippedMatches} Matches were not able to be processed!" + Environment.NewLine;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string username = usernameTextBox.Text;
			if (username == "")
			{
				MessageBox.Show("Invalid Username!");
				return;
			}

			SplatfestData? fest = getFestFromName(splatfestComboBox.Text);

			if (fest == null)
			{
				MessageBox.Show("Invalid Splatfest");
				return;
			}

			LoadMatches(username, (SplatfestData)fest);
		}

		private void showContributionColorsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			matchDataGridView1.PaintRows = !matchDataGridView1.PaintRows;
			//((ToolStripMenuItem)sender).Checked = matchDataGridView1.PaintRows;
		}

		private void showContributionColorsToolStripMenuItem_Changed(object sender, EventArgs e)
		{
			MatchDataGridView view = (MatchDataGridView)sender;
			showContributionColorsToolStripMenuItem.Checked = view.PaintRows;
			Properties.Settings.Default.PaintRows = view.PaintRows;
		}
	}
}