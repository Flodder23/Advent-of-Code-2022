partial class Day08 {
	public override sbyte[,] ParseInput(string? raw_input = null) {
		string[] input = (raw_input ?? GetRawInput()).Split(Environment.NewLine);
		sbyte[,] output = new sbyte[input.Length, input[0].Length];

		for (int i = 0; i < output.GetLength(0); i++) {
			for (int j = 0; j < output.GetLength(1); j++) {
				output[i, j] = sbyte.Parse(input[i][j].ToString());
			}
		}

		return output;
	}
}