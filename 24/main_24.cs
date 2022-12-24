partial class Day24 : Day<int[,], int, int> {
	public Day24(int day_ref_int) : base(day_ref_int) { }
	public Day24() : base(24) { }

	private static int FindPathLength((int, int) start_pos, (int, int) end_pos, int[,] init, int time = 0) {
		HashSet<(int, int)> positions = new() { start_pos };
		while (!positions.Contains(end_pos)) {
			time++;
			HashSet<(int, int)>  new_positions = new();
			foreach ((int, int) pos in positions) {
				foreach ((int, int) new_pos in GetNeighbours(pos)) {
					if (PosIsClear(new_pos, init, time)) {
						new_positions.Add(new_pos);
					}
				}
			}
			positions = new_positions;
		}
		return time;
	}

	private static bool PosIsClear((int, int) pos, int[,] init, int time) =>
		0 <= pos.Item1 && pos.Item1 < init.GetLength(0) &&
		0 <= pos.Item2 && pos.Item2 < init.GetLength(1) &&
		GetAtPos(pos, init, time)[0];
	private static bool[] GetAtPos((int, int) pos, int[,] init, int time) {
		bool[] output = new bool[6];
		output[1] = init[pos.Item1, pos.Item2] == 1;
		output[2] = init[Functions.Modulo(pos.Item1 + time - 1, init.GetLength(0) - 2) + 1, pos.Item2] == 2;
		output[4] = init[Functions.Modulo(pos.Item1 - time - 1, init.GetLength(0) - 2) + 1, pos.Item2] == 4;
		output[3] = init[pos.Item1, Functions.Modulo(pos.Item2 + time - 1, init.GetLength(1) - 2) + 1] == 3;
		output[5] = init[pos.Item1, Functions.Modulo(pos.Item2 - time - 1, init.GetLength(1) - 2) + 1] == 5;
		output[0] = !(output[1] || output[2] || output[3] || output[4] || output[5]);
		return output;
	}

	private static (int, int)[] GetNeighbours((int, int) pos) =>
		new (int, int)[] {
			(pos.Item1    , pos.Item2    ),
			(pos.Item1 + 1, pos.Item2    ),
			(pos.Item1 - 1, pos.Item2    ),
			(pos.Item1    , pos.Item2 + 1),
			(pos.Item1    , pos.Item2 - 1),
		};
}