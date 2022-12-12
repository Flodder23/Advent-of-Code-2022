partial class Day12 {
	public override (int[,], (int, int), (int, int)) ParseInput(string? raw_input = null) {
		char[][] input =  (raw_input ?? GetRawInput()).Split(Environment.NewLine)
			.Select(str_arr => str_arr.ToCharArray()).ToArray();
		int[,] output = new int[input.Length, input[0].Length];
		(int, int) start_pos = (0, 0), end_pos = (0, 0);
		for (int i = 0; i < output.GetLength(0); i++) {
			for (int j = 0; j < output.GetLength(1); j++) {
				char new_level = input[i][j];
				if (new_level == 'S') {
					start_pos = (i, j);
					new_level = 'a';
				} else if (new_level == 'E') {
					end_pos = (i, j);
					new_level = 'z';
				}
				output[i, j] = new_level - 97;
			}
		}
		return (output, start_pos, end_pos);
	}
}