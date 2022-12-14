partial class Day14 {
	public override (string, int)[] Tests1() => new (string, int)[] {
		("498,4 -> 498,6 -> 496,6\r\n503,4 -> 502,4 -> 502,9 -> 494,9", 24),  
	};

	public override (string, int)[] Tests2() => new (string, int)[] {
		("498,4 -> 498,6 -> 496,6\r\n503,4 -> 502,4 -> 502,9 -> 494,9", 93)
	};
}