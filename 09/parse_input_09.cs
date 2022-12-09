partial class Day09 {
	public override ((int, int), int)[] ParseInput(string? raw_input = null) {
		Dictionary<char, (int, int)> get_dir = new Dictionary<char, (int, int)>(){
			{ 'U', (0, 1) },
			{ 'D', (0, -1) },
			{ 'L', (1, 0) },
			{ 'R', (-1, 0) }
		};
		string[] input = (raw_input ?? GetRawInput()).Split(Environment.NewLine);

		((int, int), int)[] output = new ((int, int), int)[input.Length];
		for (int i = 0; i < input.Length; i++) {
			output[i] = (get_dir[input[i][0]], int.Parse(input[i].Substring(2)));
		}

		return output;
	}
}