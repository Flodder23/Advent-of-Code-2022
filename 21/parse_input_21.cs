using System.Text.RegularExpressions;

partial class Day21 {
	public override Dictionary<string, Monkey> ParseInput(string? raw_input = null) {
		Dictionary<string, Monkey> output = new();
		foreach (string m in (raw_input ?? GetRawInput()).Split(Environment.NewLine)) {
			Match match = Regex.Match(m, @"(\w+): (.+)");
			string name = match.Groups[1].Value;
			if (long.TryParse(match.Groups[2].Value, out long number)) {
				output.Add(name, new Monkey(number));
			}
			else {
				Match match_oper = Regex.Match(match.Groups[2].Value, @"(\w+) (\+|-|\*|/) (\w+)");
				output.Add(name, new Monkey(
					match_oper.Groups[1].Value,
					match_oper.Groups[3].Value,
					match_oper.Groups[2].Value[0]
				));
			}
		}
		return output;
	}
}