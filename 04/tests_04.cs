partial class Day04 {
	public override (string, int)[] Tests1() => new (string, int)[] {
		("2-4,6-8\r\n2-3,4-5\r\n5-7,7-9\r\n2-8,3-7\r\n6-6,4-6\r\n2-6,4-8", 2)
	};

	public override (string, int)[] Tests2() => new (string, int)[] {
		("2-4,6-8\r\n2-3,4-5\r\n5-7,7-9\r\n2-8,3-7\r\n6-6,4-6\r\n2-6,4-8", 4)
	};
}