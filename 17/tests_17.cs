partial class Day17 {
	public override (string, int)[] Tests1() => new (string, int)[] {
		(">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>", 3068)
	};

	public override (string, long)[] Tests2() => new (string, long)[] {
		(">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>", 1514285714288)
	};
}