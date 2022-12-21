partial class Day14 : Day<(Dictionary<int, (int, int)[]>, Dictionary<int, (int, int)[]>, int), int, int> {
	public Day14(int day_ref_int) : base(day_ref_int) { }
	public Day14() : base(14) { }

	public static int DoSand((int, int) spawn,
		Dictionary<int, (int, int)[]> cols,
		Dictionary<int, (int, int)[]> rows,
		Func<(int, int), HashSet<(int, int)>, bool> stop
	) {
		HashSet<(int, int)> sand = new();
		(int x, int y) = spawn;
		Stack<(int, int)> path = new();
		while (!stop((x, y), sand)) {
			path.Push((x, y));
			y += 1;
			if (CheckCoord((x, y), cols, rows) || sand.Contains((x, y))) {
				if (CheckCoord((x - 1, y), cols, rows) || sand.Contains((x - 1, y))) {
					if (CheckCoord((x + 1, y), cols, rows) || sand.Contains((x + 1, y))) {
						sand.Add(path.Pop());
						if (path.Count > 0) {
							(x, y) = path.Pop();
						}
					}
					else {
						x += 1;
					}
				}
				else {
					x -= 1;
				}
			}
		}

		return sand.Count();
	}

	public static bool CheckCoord((int, int) coord, Dictionary<int, (int, int)[]> cols, Dictionary<int, (int, int)[]> rows) {
		(int, int)[] ranges;
		if (cols.TryGetValue(coord.Item1, out ranges)) {
			foreach ((int r1, int r2) in ranges) {
				if (r1 <= coord.Item2 && coord.Item2 <= r2) {
					return true;
				}
			}
		}
		if (rows.TryGetValue(coord.Item2, out ranges)) {
			foreach ((int r1, int r2) in ranges) {
				if (r1 <= coord.Item1 && coord.Item1 <= r2) {
					return true;
				}
			}
		}
		return false;
	}
}