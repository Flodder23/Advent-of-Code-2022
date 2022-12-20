partial class Day20 {
	public override List<int> ParseInput(string? raw_input = null) {
		return new List<int>((raw_input ?? GetRawInput()).Split(Environment.NewLine).Select(s => int.Parse(s)));
	}
}