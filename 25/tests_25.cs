partial class Day25 {
	public override (string, string)[] Tests1() => new (string, string)[] {
		("1=-0-2\r\n12111\r\n2=0=\r\n21\r\n2=01\r\n111\r\n20012\r\n112\r\n1=-1=\r\n1-12\r\n12\r\n1=\r\n122", "2=-1=0"),
	};

	public override (string, int)[] Tests2() => new (string, int)[] {
		("1=-0-2\r\n12111\r\n2=0=\r\n21\r\n2=01\r\n111\r\n20012\r\n112\r\n1=-1=\r\n1-12\r\n12\r\n1=\r\n122", 2),
	};
}