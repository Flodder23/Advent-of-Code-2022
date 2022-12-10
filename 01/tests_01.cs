partial class Day01 {
	public override (string, int)[] Tests1() => new (string, int)[] {
		("1000\r\n2000\r\n3000\r\n\r\n4000\r\n\r\n5000\r\n6000\r\n\r\n7000\r\n8000\r\n9000\r\n\r\n10000", 24000)
	};

	public override (string, int)[] Tests2() => new (string, int)[] {
		("1000\r\n2000\r\n3000\r\n\r\n4000\r\n\r\n5000\r\n6000\r\n\r\n7000\r\n8000\r\n9000\r\n\r\n10000", 45000)
	};
}