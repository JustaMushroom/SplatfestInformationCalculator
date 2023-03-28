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
		List<Match> storedMatches;
		List<SplatfestData> fests;
		HttpClient client;
		public Form1()
		{
			InitializeComponent();
			loadSplatfests();
			storedMatches = new List<Match>();
			client = new HttpClient();
			//Debug.WriteLine(HttpUtility.UrlDecode("https://stat.ink/@AbsentAria/spl3?f%5Blobby%5D=%40splatfest&f%5Brule%5D=&f%5Bmap%5D=&f%5Bweapon%5D=&f%5Bresult%5D=&f%5Bknockout%5D=&f%5Bterm%5D=term&f%5Bterm_from%5D=2023-01-07+00%3A00%3A00&f%5Bterm_to%5D=2023-01-09+00%3A00%3A00"));
			
			Debug.WriteLine(unixTimestampToDateTime(1676073600).ToString("yyyy-MM-dd HH:mm:ss"));
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
			string URL = "https://stat.ink/@" + Username + "/spl3/index.json?f[lobby]=@splatfest&f[rule]=&f[map]=&f[weapon]=&f[result]=&f[knockout]=&f[term]=term&f[term_from]=" + data.Start.ToString("yyyy-MM-dd HH:mm:ss") + "&f[term_to]=" + data.End.ToString("yyyy-MM-dd HH:mm:ss");
			string encodedURL = HttpUtility.UrlEncode(URL);

			HttpResponseMessage response = await client.GetAsync(encodedURL);

			response.EnsureSuccessStatusCode();

			string jsonStr = await response.Content.ReadAsStringAsync();

			JsonNode matchListNode = JsonNode.Parse(jsonStr)!;

			List<Match> matches = new List<Match>();
			
			foreach (JsonNode node in matchListNode!.AsArray())
			{
				if (node == null) continue;

				SplatfestMatch m;

				if (node["rule"]!["key"]!.ToString() == "tricolor")
				{
					m = new TricolorMatch(node);
				}
				else
				{
					m = new SplatfestMatch(node);
				}
				matches.Add(m);

				int idx = dataGridView1.Rows.Add();
				DataGridViewRow row = dataGridView1.Rows[idx];
				string lobby = m.Lobby.ToString();
				if (typeof(TricolorMatch).IsInstanceOfType(m))
				{
					lobby = "TRICOLOR";
				}
				float cont = 0;
				row.SetValues(new object[] { m.MatchID, m.Victory, m.Kills, m.Deaths, m.Kills / m.Deaths, cont });
			}
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