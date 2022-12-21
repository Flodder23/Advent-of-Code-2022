partial class Day09 {
	public override ((int, int), int)[] ParseInput(string? raw_input = null) => 
		(raw_input ?? GetRawInput()).Split(Environment.NewLine).Select(
			s => (get_dir[s[0]], int.Parse(s.Substring(2)))
		).ToArray();

	private static readonly Dictionary<char, (int, int)> get_dir = new() {
		{ 'U', (0, 1) },
		{ 'D', (0, -1) },
		{ 'L', (1, 0) },
		{ 'R', (-1, 0) }
	};
}