partial class Day10 {
	public override int?[] ParseInput(string? raw_input = null) =>
		(raw_input ?? GetRawInput()).Split(Environment.NewLine).Select(s =>
			(int?)(s.Length > 5 ? int.Parse(s.Substring(5)) : null)
		).ToArray();
}