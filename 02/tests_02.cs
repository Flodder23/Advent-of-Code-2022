partial class Day02 {
	public override (string, int)[] Tests1() => new (string, int)[] {
		("A Y\r\nB X\r\nC Z", 15)
	};

	public override (string, int)[] Tests2() => new (string, int)[] {
		("A Y\r\nB X\r\nC Z", 12)
	};
}