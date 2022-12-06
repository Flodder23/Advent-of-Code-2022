partial class Day03 {
	public override char[][] ParseInput(string? raw_input = null) {
		string[] input = (raw_input ?? GetRawInput()).Split(Environment.NewLine);
		char[][] output = new char[input.Length][];
		for (int i = 0; i < output.Length; i++) {
			output[i] = input[i].ToCharArray();
		}
		return output;
	}
}