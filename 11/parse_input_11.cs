partial class Day11 {
	public override Monkey[] ParseInput(string? raw_input = null) =>
		(raw_input ?? GetRawInput()).Split(Environment.NewLine + Environment.NewLine)
			.Select(monk => new Monkey(monk)).ToArray();
}