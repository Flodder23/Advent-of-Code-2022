partial class Day23 {
	public override int Part1(in HashSet<(int, int)> input) {
		HashSet<(int, int)> map = input;
		for (int i = 0; i < 10; i++) {
			DoRound(map, i, out HashSet<(int, int)> new_map);
			map = new_map;
		}

		int x_min, x_max, y_min, y_max;
		var map_enum = map.GetEnumerator();
		if (map_enum.MoveNext()) {
			(int x, int y) = map_enum.Current;
			x_min = x;
			x_max = x;
			y_min = y;
			y_max = y;

			while (map_enum.MoveNext()) {
				(x, y) = map_enum.Current;
				if (x < x_min) {
					x_min = x;
				}
				if (x_max < x) {
					x_max = x;
				}

				if (y < y_min) {
					y_min = y;
				}
				if (y_max < y) {
					y_max = y;
				}
			}
			return (x_max - x_min + 1) * (y_max - y_min + 1) - map.Count;
		}
		return -1;
	}
}