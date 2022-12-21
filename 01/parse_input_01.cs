partial class Day01 {
	public override int[][] ParseInput(string? raw_input = null) =>
		(raw_input ?? GetRawInput()).Split(Environment.NewLine + Environment.NewLine).Select(
			S => S.Split(Environment.NewLine).Select(
				s => int.Parse(s)
			).ToArray()
		).ToArray();
}