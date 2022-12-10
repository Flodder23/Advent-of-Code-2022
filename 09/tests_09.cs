partial class Day09 {
	public override (string, int)[] Tests1() => new (string, int)[] {
		("R 4\r\nU 4\r\nL 3\r\nD 1\r\nR 4\r\nD 1\r\nL 5\r\nR 2", 13)
	};

	public override (string, int)[] Tests2() => new (string, int)[] {
		("R 4\r\nU 4\r\nL 3\r\nD 1\r\nR 4\r\nD 1\r\nL 5\r\nR 2", 1),
		("R 5\r\nU 8\r\nL 8\r\nD 3\r\nR 17\r\nD 10\r\nL 25\r\nU 20", 36)
	};
}