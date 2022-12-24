partial class Day24 {
	public override int[,] ParseInput(string? raw_input = null) {
		string[] input = (raw_input ?? GetRawInput()).Split(Environment.NewLine);
		int[,] output = new int[input.Length, input[0].Length];
		for (int i = 0; i < output.GetLength(0); i++) {
			for (int j = 0; j < output.GetLength(1); j++) {
				output[i, j] = Type[input[i][j]];
			}
		}
		return output;
	}

	private static readonly Dictionary<char, int> Type = new() {
		{'.', 0 }, {'#', 1 }, {'^', 2 }, {'<', 3 }, {'v', 4 }, {'>', 5 }
	};
}