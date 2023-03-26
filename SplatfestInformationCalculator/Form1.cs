using SplatfestInformationCalculator.Splatfest;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SplatfestInformationCalculator
{
	public partial class Form1 : Form
	{
		List<Match> storedMatches;
		public Form1()
		{
			InitializeComponent();
			testSerialization();
		}

		public void testSerialization()
		{
			string jsonData = File.ReadAllText("../../../../testMatch.json");

			JsonNode matchNode = JsonNode.Parse(jsonData)!;

			TricolorMatch match = new TricolorMatch(matchNode);

			Console.WriteLine(match);
		}
	}
}