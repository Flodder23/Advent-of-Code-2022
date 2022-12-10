partial class Day00 {
	public override (string, int)[] Tests1() => new (string, int)[] {
		("this\r\nis the\r\nfirst\r\ntest\r\nof\r\npart\r\n1", 1),
		("this\r\nis the\r\nsecond\r\ntest\r\nof\r\npart\r\n1", 1)
	};

	public override (string, int)[] Tests2() => new (string, int)[] {
		("this\r\nis the\r\nfirst\r\ntest\r\nof\r\npart\r\n2", 1),
		("this\r\nis the\r\nsecond\r\ntest\r\nof\r\npart\r\n2", 1)
	};
}