partial class Day12 {
	public override int Part2(in (int[,], (int, int), (int, int)) input) {
		(int[,] map, (int, int) start_pos, (int, int) end_pos) = input;
		HashSet<(int, int)> lowest_points = new();
		HashSet<(int, int)> to_measure = new();
		for (int i = 0; i < map.GetLength(0); i++) {
			for (int j = 0; j < map.GetLength(1); j++) {
				to_measure.Add((i, j));
				if (map[i, j] == 0) {
					lowest_points.Add((i, j));
				}
			}
		}
		return RunSimpleSearch(
			map, end_pos,
			measuring => measuring.Overlaps(lowest_points),
			(to, from, map) => map[from.Item1, from.Item2] - 1 <= map[to.Item1, to.Item2]
		);
	}
}