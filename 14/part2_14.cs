partial class Day14 {
	public override int Part2(in (Dictionary<int, (int, int)[]>, Dictionary<int, (int, int)[]>, int) input) {
		(Dictionary<int, (int, int)[]> cols, Dictionary<int, (int, int)[]> rows, int greatest_y) = input;
		rows = new(rows) { { greatest_y + 2, new (int, int)[] { (int.MinValue, int.MaxValue) } } };

		return DoSand((500, 0), cols, rows,
			(coord, sand) => sand.Contains((500, 0))
		);
	}
}