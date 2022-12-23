partial class Day22 {
	public override int Part1(in ((int, int, bool[])[], (int, char)[]) input) {
		(int, int, bool[])[] map = input.Item1;

		int dir = 0;
		(int, int) pos = (0, map[0].Item1);
		foreach ((int steps, char turn) in input.Item2) {
			for (int i = 0; i < steps; i++) {
				(int, int) new_pos = Move(pos, GetDir[dir], map);
				if (IsWall(new_pos, map)) {
					break;
				}
				pos = new_pos;
			}

			if (turn != 'N') {
				dir = ChangeDir(dir, turn == 'R');
			}
		}

		return 1_000 * (pos.Item1 + 1) + 4 * (pos.Item2 + 1) + dir;
	}

	private static readonly Dictionary<int, (int, int)> GetDir = new() {
		{ 0, (0, 1) },
		{ 1, (1, 0) },
		{ 2, (0, -1) },
		{ 3, (-1, 0) }
	};

	private static int ChangeDir(int dir, bool turn) => (dir + (turn ? 1 : 3)) % 4;
	private static bool IsWall(in (int, int) pos, in (int, int, bool[])[] map) => map[pos.Item1].Item3[pos.Item2 - map[pos.Item1].Item1];
	private static (int, int) Move((int, int) pos, (int, int) dir, in (int, int, bool[])[] map) {
		int x = pos.Item1 + dir.Item1,
			y = pos.Item2 + dir.Item2;

		if (dir.Item1 == 1) {
			if (map.Length <= x || y < map[x].Item1 || map[x].Item2 <= y) {
				x = 0;
				while (y < map[x].Item1 || map[x].Item2 <= y) {
					x++;
				}
			}
		} else if (dir.Item1 == -1) {
			if (x < 0 || y < map[x].Item1 || map[x].Item2 <= y) {
				x = map.Length - 1;
				while (y < map[x].Item1 || map[x].Item2 <= y) {
					x--;
				}
			}
		}

		if (y < map[x].Item1) {
			y = map[x].Item2 - 1;
		} else if (map[x].Item2 <= y) {
			y = map[x].Item1;
		}

		return (x, y);
	}
}