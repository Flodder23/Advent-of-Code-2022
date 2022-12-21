partial class Day18 {
	public override (int, int, int)[] ParseInput(string? raw_input = null) => 
		(raw_input ?? GetRawInput()).Split(Environment.NewLine).Select(
			S => S.Split(',').Select(s => int.Parse(s)).ToArray()
		).Select(coords => (coords[0], coords[1], coords[2])).ToArray();
}