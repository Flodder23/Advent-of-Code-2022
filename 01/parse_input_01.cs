partial class Day01 {
	public override int[][] ParseInput(string? raw_input = null) {
		string[] in_str = (raw_input ?? GetRawInput()).Split(Environment.NewLine + Environment.NewLine);

		int[][] in_int = new int[in_str.Length][]; // ignoring last line as it is blank
		for (int i = 0; i < in_int.Length; i++) {
			string[] strs = in_str[i].Split(Environment.NewLine);
			in_int[i] = new int[strs.Length];
			for (int j = 0; j < strs.Length; j++) {
				in_int[i][j] = int.Parse(strs[j]);
			}
		}

		return in_int;
	}
}