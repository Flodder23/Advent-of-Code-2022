partial class Day09 : Day<((int, int), int)[], int, int> {
	public Day09(int day_ref_int) : base(day_ref_int) { }
	public Day09() : base(9) { }

	private static int GetTailVisited(((int, int), int)[] instr, int len) {
		(int, int)[] pos = new (int, int)[len];
		HashSet<(int ,int)> already_visited = new() { (0, 0) };

		foreach (((int, int) dir, int dist) in instr) {
			for (int i = 0; i < dist; i++) {
				pos[0].Item1 += dir.Item1;
				pos[0].Item2 += dir.Item2;
				for (int j = 1; j < len; j++) {
					(int, int) new_dir = MoveTowards(pos[j], pos[j-1]);
					pos[j].Item1 += new_dir.Item1;
					pos[j].Item2 += new_dir.Item2;
				}
				already_visited.Add(pos[len - 1]);
			}
		}

		return already_visited.Count;
	}

	private static (int, int) MoveTowards((int, int) pos, (int, int) target) {
		(int, int) dir = (0, 0);

		int diff_1 = target.Item1 - pos.Item1;
		int diff_2 = target.Item2 - pos.Item2;
		if (diff_1 > 1 || diff_1 < -1 || diff_2 > 1 || diff_2 < -1) {
			if (diff_1 > 0) {
				dir.Item1 += 1;
			}
			else if (diff_1 < 0) {
				dir.Item1 -= 1;
			}

			if (diff_2 > 0) {
				dir.Item2 += 1;
			}
			else if (diff_2 < 0) {
				dir.Item2 -= 1;
			}
		}
		return dir;
	}
}