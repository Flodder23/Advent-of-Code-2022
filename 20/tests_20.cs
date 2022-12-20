partial class Day20 {
	public override (string, long)[] Tests1() => new (string, long)[] {
		("1\r\n2\r\n-3\r\n3\r\n-2\r\n0\r\n4", 3)
	};

	public override (string, long)[] Tests2() => new (string, long)[] {
		("1\r\n2\r\n-3\r\n3\r\n-2\r\n0\r\n4", 1623178306)
	};
}