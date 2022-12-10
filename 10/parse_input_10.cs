partial class Day10 {
	public override int?[] ParseInput(string? raw_input = null) {
		string[] input = (raw_input ?? GetRawInput()).Split(Environment.NewLine);
		int?[] output = new int?[input.Length];

		for (int i = 0; i < output.Length; i++) {
			if (input[i].Length > 5) {
				output[i] = int.Parse(input[i].Substring(5));
			}
		}

		return output;
	}
}