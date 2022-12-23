partial class Day23 : Day<HashSet<(int, int)>, int, int> {
	public Day23(int day_ref_int) : base(day_ref_int) { }
	public Day23() : base(23) { }

	private static bool DoRound(HashSet<(int, int)> map, int priority, out HashSet<(int, int)> new_map) {
		bool has_moved = false;
		Dictionary<(int, int), List<(int, int)>> new_map_dict = new();
		foreach ((int, int) pos in map) {
			if (SurroundsIsClear(pos, map) || !GetNewPos(pos, map, priority, out (int, int) new_pos)) {
				AddToMapDict(pos, pos, new_map_dict);
			} else {
				AddToMapDict(pos, new_pos, new_map_dict);
				has_moved = true;
			}
		}

		if (has_moved) {
			new_map = new();
			foreach ((int, int) pos in new_map_dict.Keys) {
				if (new_map_dict[pos].Count == 1) {
					new_map.Add(pos);
				} else {
					new_map.UnionWith(new_map_dict[pos]);
				}
			}
		} else {
			new_map = map;
		}
		return has_moved;
	}
	private static bool SurroundsIsClear((int, int) pos, HashSet<(int, int)> map) =>
		Array.TrueForAll(Surrounds, dir => !map.Contains((pos.Item1 + dir.Item1, pos.Item2 + dir.Item2)));
	private static bool GetNewPos((int, int) pos, HashSet<(int, int)> map, int priority, out (int, int) new_pos) {
		new_pos = pos;
		for (int i = 0; i < 4; i++) {
			int d = (priority + i) % 4;
			if (Array.TrueForAll(Sides[d], dir =>
				!map.Contains((pos.Item1 + dir.Item1, pos.Item2 + dir.Item2))
			)) {
				new_pos = (pos.Item1 + Surrounds[d].Item1, pos.Item2 + Surrounds[d].Item2);
				return true;
			}
		}
		return false;
	}

	private static void AddToMapDict((int, int) pos, (int, int) new_pos, Dictionary<(int, int), List<(int, int)>> map_dict) {
		if (map_dict.ContainsKey(new_pos)) {
			map_dict[new_pos].Add(pos);
		} else {
			map_dict[new_pos] = new() { pos };
		}
	}

	private static readonly (int, int)[] Surrounds = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1), (-1, -1), (-1, 1), (1, -1), (1, 1) };
	
	private static readonly (int, int)[][] Sides = new (int, int)[][] {
		new (int, int)[] { (-1, -1), (-1,  0), (-1,  1) },
		new (int, int)[] { ( 1, -1), ( 1,  0), ( 1,  1) },
		new (int, int)[] { (-1, -1), ( 0, -1), ( 1, -1) },
		new (int, int)[] { (-1,  1), ( 0,  1), ( 1,  1) }
	};
}