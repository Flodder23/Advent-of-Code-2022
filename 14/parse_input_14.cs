partial class Day14 {
	public override (Dictionary<int, (int, int)[]>, Dictionary<int, (int, int)[]>, int) ParseInput(string? raw_input = null) {
		Dictionary<int, List<(int, int)>> cols = new();
		Dictionary<int, List<(int, int)>> rows = new();
		int greatest_y = 0;
		foreach (string path in (raw_input ?? GetRawInput()).Split(Environment.NewLine)) {
			(int, int) last_coord = (500, 0);
			foreach(string c0 in path.Split(" -> ")) {
				string[] c1 = c0.Split(",");
				(int, int) coord = (int.Parse(c1[0]), int.Parse(c1[1]));

				if (coord.Item2 > greatest_y) {
					greatest_y = coord.Item2;
				}

				if (last_coord == (500, 0)) {
					last_coord = coord;
				} else {
					if (last_coord.Item1 == coord.Item1) {
						AddToDictList(cols, coord.Item1, coord.Item2 < last_coord.Item2 ? (coord.Item2, last_coord.Item2) : (last_coord.Item2, coord.Item2));
					} else if (last_coord.Item2 == coord.Item2) {
						AddToDictList(rows, coord.Item2, coord.Item1 < last_coord.Item1 ? (coord.Item1, last_coord.Item1) : (last_coord.Item1, coord.Item1));
					}
				}
				last_coord = coord;
			}
		}

		Dictionary<int, (int, int)[]> cols_arr = new();
		foreach ((int key, List<(int, int)> val) in cols) {
			cols_arr.Add(key, val.ToArray());
		}
		Dictionary<int, (int, int)[]> rows_arr = new();
		foreach ((int key, List<(int, int)> val) in rows) {
			rows_arr.Add(key, val.ToArray());
		}

		return (cols_arr, rows_arr, greatest_y);
	}

	private void AddToDictList(Dictionary<int, List<(int, int)>> dict, int key, (int, int) item) {
		if (dict.ContainsKey(key)) {
			dict[key].Add(item);
		} else {
			dict.Add(key, new List<(int, int)> { item });
		}
	}
}