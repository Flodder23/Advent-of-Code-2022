partial class Day12 {
	public override int Part1(in (int[,], (int, int), (int, int)) input) {
		(int[,] map, (int, int) start_pos, (int, int) end_pos) = input;
		return RunSimpleSearch(
			map, start_pos,
			measuring => measuring.Contains(end_pos),
			(to, from, map) => map[from.Item1, from.Item2] + 1 >= map[to.Item1, to.Item2]
		);
	}
}