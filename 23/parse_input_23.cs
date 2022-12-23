partial class Day23 {
	public override HashSet<(int, int)> ParseInput(string? raw_input = null) {
		string[] input = (raw_input ?? GetRawInput()).Split(Environment.NewLine);
		HashSet<(int, int)> output = new();
		for (int i = 0; i < input.Length; i++) {
			for (int j = 0; j < input[i].Length; j++) {
				if (input[i][j] == '#') {
					output.Add((i, j));
				}
			}
		}
		return output;
	}
}