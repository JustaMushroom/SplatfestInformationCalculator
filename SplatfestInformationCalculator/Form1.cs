using SplatfestInformationCalculator.Splatfest;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Net.Http;
using System.Diagnostics;
using System.Web;
using System.Runtime.CompilerServices;
using SplatfestInformationCalculator.Splatfest.Generics;

namespace SplatfestInformationCalculator
{
	public partial class Form1 : Form
	{
		public static List<Match> storedMatches;
		List<SplatfestData> fests;
		HttpClient client;
		public Form1()
		{
			InitializeComponent();
			loadSplatfests();
			storedMatches = new List<Match>();
			client = new HttpClient();
		}

		private SplatfestData? getFestFromName(string SplatfestName)
		{
			foreach (SplatfestData data in fests)
			{
				if (data.SplatfestName == SplatfestName) return data;
			}
			return null;
		}

		private void loadSplatfests()
		{
			fests = new List<SplatfestData>();
			string jsonData = File.ReadAllText("../../../../splatfests.json");

			JsonNode matchNode = JsonNode.Parse(jsonData)!;

			foreach (JsonNode node in matchNode["fests"]!.AsArray())
			{
				if (node["timing"]!["start"] == null) continue;

				string ht1 = "null";
				if (node["halftime_1st"] != null) ht1 = node["halftime_1st"].ToString();


				SplatfestData fest = new SplatfestData()
				{
					Start = unixTimestampToDateTime((long)node["timing"]!["start"]!),
					End = unixTimestampToDateTime((long)node["timing"]!["end"]!),
					Options = jsonArrayToStringArray(node["options"]!.AsArray()),
					Prompt = node["prompt"]!.ToString(),
					Halftime1st = ht1
				};


				splatfestComboBox.Items.Add(fest.SplatfestName);
				fests.Add(fest);
			}
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

		private void testSerialization()
		{
			string jsonData = File.ReadAllText("../../../../testMatch.json");

			JsonNode matchNode = JsonNode.Parse(jsonData)!;

			TricolorMatch match = new TricolorMatch(matchNode);

			Console.WriteLine(match);
		}

		private DateTime unixTimestampToDateTime(long unixTimestamp)
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
			dateTime = dateTime.AddSeconds(unixTimestamp);
			return dateTime;
		}

		private async void LoadMatches(string Username, SplatfestData data)
		{
			loadLogTextBox.Text += "Loading matches for " + Username + "..." + Environment.NewLine;
			matchDataGridView1.Rows.Clear();
			string URL = "https://stat.ink/@" + Username + "/spl3/index.json?f[lobby]=@splatfest&f[rule]=&f[map]=&f[weapon]=&f[result]=&f[knockout]=&f[term]=term&f[term_from]=" + data.Start.ToString("yyyy-MM-dd HH:mm:ss") + "&f[term_to]=" + data.End.ToString("yyyy-MM-dd HH:mm:ss");
			string encodedURL = HttpUtility.UrlEncode(URL);

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
					Thread.Sleep(2500);
				}
			}

			Dictionary<string, TricolorTeam> preferredPos = ContributionCalculator.GeneratePreferredPositions(data.Options, data.Halftime1st);

			JsonNode matchListNode = JsonNode.Parse(jsonStr)!;

			loadLogTextBox.Text += "Received " + matchListNode!.AsArray().Count + " matches from stat.ink" + Environment.NewLine;

			List<Match> matches = new List<Match>();

			loadLogTextBox.Text += "Parsing matches..." + Environment.NewLine;
			int id = 0;
			foreach (JsonNode node in matchListNode!.AsArray())
			{
				if (node == null) continue;

				if (node["our_team_percent"] == null) continue;

				SplatfestMatch m;
				float cont = 0;

				if (node["rule"]!["key"]!.ToString() == "tricolor")
				{
					m = new TricolorMatch(node);
					cont = ContributionCalculator.EstimateTricolorContribution((TricolorMatch)m, preferredPos);
				}
				else
				{
					m = new SplatfestMatch(node);
					if (m.Lobby == SplatfestLobbyType.SPLATFEST_OPEN)
					{
						cont = ContributionCalculator.EstimateOpenContribution(m);
					}
					else if (m.Lobby == SplatfestLobbyType.SPLATFEST_PRO)
					{
						cont = ContributionCalculator.EstimateProContribution(m);
					}
				}
				matches.Add(m);

				int idx = matchDataGridView1.Rows.Add();
				DataGridViewRow row = matchDataGridView1.Rows[idx];
				string lobby = m.Lobby.ToString();
				if (typeof(TricolorMatch).IsInstanceOfType(m))
				{
					lobby = "TRICOLOR";
				}
				decimal KD = m.CalulateKD();//Math.Round((decimal)(m.Kills / m.Deaths), 2);
				row.SetValues(new object[] { id, m.MatchID, lobby, m.Victory, m.Kills, m.Deaths, KD, cont });
				id++;
			}

			storedMatches = matches;
			loadLogTextBox.Text += "Matches successfully loaded!" + Environment.NewLine;
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
	}
}