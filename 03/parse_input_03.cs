partial class Day03 {
	public override char[][] ParseInput(string? raw_input = null) =>
		(raw_input ?? GetRawInput()).Split(Environment.NewLine).Select(
			s => s.ToCharArray()
		).ToArray();
}