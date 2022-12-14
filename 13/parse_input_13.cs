partial class Day13 {
	public override (object[], object[])[] ParseInput(string? raw_input = null) {
		(string, string)[] input = (raw_input ?? GetRawInput()).Split(Environment.NewLine + Environment.NewLine)
			.Select(str => str.Split(Environment.NewLine)).Select(str_arr => (str_arr[0], str_arr[1])).ToArray();

		(object[], object[])[] output = new (object[], object[])[input.Length];

		for (int i = 0; i < output.Length; i++) {
			output[i] = (StringToArray(input[i].Item1), StringToArray(input[i].Item2));
		}

		return output;
	}

	private object[] StringToArray(in string str, int start_pos = 0, int? end_pos = null) {
		end_pos ??= str.Length;
		int i = 1;
		List<object> output = new();

		while (start_pos + i < end_pos) {
			int j = 0;
			if (str[start_pos + i] == '[') {
				int level = 1;
				j += 1;
				while (level > 0) {
					switch (str[start_pos + i + j]) {
						case '[':
							level++;
							break;
						case ']':
							level--;
							break;
					}
					j++;
				}
				output.Add(StringToArray(str, start_pos + i, start_pos + i + j));
			} else {
				while (start_pos + i + j < end_pos && str[start_pos + i + j] != ',' && str[start_pos + i + j] != ']') {
					j++;
				}
				if (j > 0) {
					output.Add(int.Parse(str.Substring(start_pos + i, j)));
				}
			}
			i += j;
			while (start_pos + i < end_pos && (str[start_pos + i] == ',' || str[start_pos + i] == ']')) {
				i++;
			}
		}
		return output.ToArray();
	}
}