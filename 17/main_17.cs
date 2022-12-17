partial class Day17 : Day<bool[], int, long> {
	public Day17(int day_ref_int) : base(day_ref_int) { }
	public Day17() : base(17) { }

	private static long DoRocks(long n, bool[] input) {
		int rocks_to_remember = 100; // this should to be as small as reasonable while being big enough to catch all cycles
		Dictionary<string, (int, int)> last_seen = new();
		Queue<(int, int)> last_rocks = new();
		int cycle_length = 0;
		long cycles_skipped = 0;
		long rocks_skipped = 0;
		int cycle_height = 0;

		int highest_point = 0;
		Dictionary<int, bool[]> rows = new() { { 0, new bool[] { true, true, true, true, true, true, true } } };
		int jet_no = input.Length - 1;
		for (int i = 0; i < (n - rocks_skipped); i++) {
			(int, int) pos = (2, highest_point + 4);
			int shape = i % 5;
			do {
				jet_no++;
				if (jet_no == input.Length) {
					jet_no = 0;
				}
				MoveAcross(shape, input[jet_no], ref pos, rows);
			} while (MoveDown(shape, ref pos, rows));
			AddShape(shape, pos, rows);
			highest_point = Math.Max(highest_point, GetHighestY[shape](pos));

			if (cycle_length == 0) {
				last_rocks.Enqueue((shape, jet_no));
				if (last_rocks.Count > rocks_to_remember) {
					last_rocks.Dequeue();
					// This hash works because we have 5 shapes and ~10_000 jet_nos giving a total of ~50_000 combinations
					// which we can uniquely assign to a UTF-16 character, then turn that char[] into a string for hashing
					string hash = new string(last_rocks.Select(r => (char)(r.Item1 + 5 * r.Item2)).ToArray());
					if (last_seen.TryGetValue(hash, out (int, int) info)) {
						cycle_length = i - info.Item1;
						cycles_skipped = (n - i) / cycle_length;
						rocks_skipped = cycles_skipped * cycle_length;
						cycle_height = highest_point - info.Item2;
					}
					else {
						last_seen.Add(hash, (i, highest_point));
					}
				}
			}
		}
		return (cycles_skipped * cycle_height) + highest_point;
	}

	private static bool MoveAcross(int shape, bool dir, ref (int, int) pos, Dictionary<int, bool[]> rows) {
		return Move(shape, ref pos, (pos.Item1 + (dir ? 1 : -1), pos.Item2), rows);
	}
	private static bool MoveDown(int shape, ref (int, int) pos, Dictionary<int, bool[]> rows) {
		return Move(shape, ref pos, (pos.Item1, pos.Item2 - 1), rows);
	}
	private static bool Move(int shape, ref (int, int) pos, (int, int) new_pos, Dictionary<int, bool[]> rows) {
		if (CheckCollision(shape, new_pos, rows)) {
			return false;
		}
		else {
			pos = new_pos;
			return true;
		}
	}

	private static bool CheckCollision(int shape, (int, int) pos, Dictionary<int, bool[]> rows) =>
		!Array.TrueForAll(GetCollisionPoints[shape](pos), p => !IsAnythingAt(p, rows));
	private static bool IsAnythingAt((int, int) pos, Dictionary<int, bool[]> rows) =>
		(pos.Item1 < 0 || 6 < pos.Item1) ? true : (rows.TryGetValue(pos.Item2, out bool[] row) ? row[pos.Item1] : false);

	private static void AddRock((int, int) pos, Dictionary<int, bool[]> rows) {
		if (rows.TryGetValue(pos.Item2, out bool[] row)) {
			row[pos.Item1] = true;
		} else {
			rows.Add(pos.Item2, new bool[] { false, false, false, false, false, false, false });
			rows[pos.Item2][pos.Item1] = true;
		}
	}
	private static void AddShape(int shape, (int, int) pos, Dictionary<int, bool[]> rows) {
		foreach ((int, int) p in GetCollisionPoints[shape](pos)) {
			AddRock(p, rows);
		}
	}


	private static readonly Dictionary<int, Func<(int, int), (int, int)[]>> GetCollisionPoints = new() {
		{ 0, point => new (int, int)[] {
			(point.Item1,     point.Item2    ),
			(point.Item1 + 1, point.Item2    ),
			(point.Item1 + 2, point.Item2    ),
			(point.Item1 + 3, point.Item2    )
		} }, { 1, point => new (int, int)[] {
			(point.Item1 + 1, point.Item2    ),
			(point.Item1,     point.Item2 + 1),
			(point.Item1 + 1, point.Item2 + 1),
			(point.Item1 + 2, point.Item2 + 1),
			(point.Item1 + 1, point.Item2 + 2)
		} }, { 2, point => new (int, int)[] {
			(point.Item1    , point.Item2    ),
			(point.Item1 + 1, point.Item2    ),
			(point.Item1 + 2, point.Item2    ),
			(point.Item1 + 2, point.Item2 + 1),
			(point.Item1 + 2, point.Item2 + 2)
		} }, { 3, point => new (int, int)[] {
			(point.Item1,     point.Item2    ),
			(point.Item1,     point.Item2 + 1),
			(point.Item1,     point.Item2 + 2),
			(point.Item1,     point.Item2 + 3)
		} }, { 4, point => new (int, int)[] {
			(point.Item1,     point.Item2    ),
			(point.Item1 + 1, point.Item2    ),
			(point.Item1    , point.Item2 + 1),
			(point.Item1 + 1, point.Item2 + 1)
		} }
	};
	private static readonly Dictionary<int, Func<(int, int), int>> GetHighestY = new() {
		{ 0, point => point.Item2     },
		{ 1, point => point.Item2 + 2 },
		{ 2, point => point.Item2 + 2 },
		{ 3, point => point.Item2 + 3 },
		{ 4, point => point.Item2 + 1 }
	};

}