partial class Day02 {
	public override (int, int)[] ParseInput(string? raw_input = null) =>
		(raw_input ?? GetRawInput()).Split(Environment.NewLine).Select(
			s => (ch_map[s[0]], ch_map[s[2]])
		).ToArray();

	private static readonly Dictionary<char, int> ch_map = new() {
		['A'] = 0,
		['B'] = 1,
		['C'] = 2,
		['X'] = 0,
		['Y'] = 1,
		['Z'] = 2
	};
}