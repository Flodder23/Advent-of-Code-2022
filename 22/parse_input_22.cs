using System.Text.RegularExpressions;

partial class Day22 {
	public override ((int, int, bool[])[], (int, char)[]) ParseInput(string? raw_input = null) {
		string[] input = (raw_input ?? GetRawInput()).Split(Environment.NewLine);
		(int, int, bool[])[] output_map = new (int, int, bool[])[input.Length - 2];
		for (int i = 0; i < output_map.Length; i++) {
			output_map[i].Item3 = input[i].TrimStart().Select(ch => ch == '#').ToArray();
			output_map[i].Item1 = input[i].Length - output_map[i].Item3.Length;
			output_map[i].Item2 = input[i].Length;
		}

		List<(int, char)> output_instr = new();
		if (input[input.Length - 1][0] == 'L' || input[input.Length - 1][0] == 'R') {
			output_instr.Add((0, input[input.Length-1][0]));
		}
		foreach (Match match in Regex.Matches(input[input.Length - 1], @"(\d+)(R|L)")) {
			output_instr.Add((int.Parse(match.Groups[1].Value), match.Groups[2].Value[0]));
		}
		if (input[input.Length - 1][input[input.Length - 1].Length - 1] != 'L' && input[input.Length - 1][input[input.Length - 1].Length - 1] != 'R') {
			output_instr.Add((int.Parse(Regex.Match(input[input.Length - 1], @"(\d+)$").Groups[1].Value), 'N'));
		}

		return (output_map, output_instr.ToArray());
	}
}