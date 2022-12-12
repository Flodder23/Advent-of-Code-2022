using System.Drawing;

partial class Day12 : Day<(int[,], (int, int), (int, int)), int, int> {
	public Day12(int day_ref_int) : base(day_ref_int) { }
	public Day12() : base(12) { }

	private int RunSimpleSearch(
		in int[,] map, in (int, int) start_pos,
		Func<HashSet<(int, int)>, bool> stop_criteria,
		Func<(int, int), (int, int), int[,], bool> add_criteria
	) {
		HashSet<(int, int)> to_measure = new();
		for (int i = 0; i < map.GetLength(0); i++) {
			for (int j = 0; j < map.GetLength(1); j++) {
				to_measure.Add((i, j));
			}
		}

		HashSet<(int, int)> measuring = new() { start_pos };
		to_measure.Remove(start_pos);

		int distance = 0;
		while (!stop_criteria(measuring)) {
			distance++;
			HashSet<(int, int)> measure_next = new();
			foreach ((int x, int y) in measuring) {
				(int, int)[] neighbours = { (x + 1, y), (x - 1, y), (x, y + 1), (x, y - 1) };
				foreach ((int, int) point in neighbours) {
					AddPoint(point, (x, y), map, measure_next, to_measure, add_criteria);
				}
			}
			measuring = measure_next;
		}

		return distance;
	}

	private static void AddPoint(
		(int, int) point, (int, int) from, int[,] map,
		HashSet<(int, int)> measure_next,
		in HashSet<(int, int)> to_measure,
		Func<(int, int), (int, int), int[,], bool> add_criteria
	) {
		if (point.Item1 >= 0 && point.Item1 < map.GetLength(0) && point.Item2 >= 0 && point.Item2 < map.GetLength(1) &&
			add_criteria(point, from, map) && to_measure.Remove(point)) {
			measure_next.Add(point);
		}
	}
}