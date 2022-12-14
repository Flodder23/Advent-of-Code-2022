using System.Data;

partial class Day14 {
	public override int Part1(in (Dictionary<int, (int, int)[]>, Dictionary<int, (int, int)[]>, int) input) {
		(Dictionary<int, (int, int)[]> cols, Dictionary<int, (int, int)[]> rows, int greatest_y) = input;

		return DoSand((500, 0), cols, rows,
			(coord, sand) => coord.Item2 > greatest_y
		);
	}
}