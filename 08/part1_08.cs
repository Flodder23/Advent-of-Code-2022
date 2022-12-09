using System.Globalization;

partial class Day08 {
	public override int Part1(in sbyte[,] input) {
		int count = 0;
		bool[,] visible = new bool[input.GetLength(0), input.GetLength(1)];

		count += CountNewVisible(input, visible, true,
			0, input.GetLength(0), 1,
			0, input.GetLength(1), 1
		);
		count += CountNewVisible(input, visible, true,
			0, input.GetLength(0), 1,
			input.GetLength(1), 0, -1
		);
		count += CountNewVisible(input, visible, false,
			0, input.GetLength(0), 1,
			0, input.GetLength(1), 1
		);
		count += CountNewVisible(input, visible, false,
			input.GetLength(0), 0, -1,
			0, input.GetLength(1), 1
		);

		return count;
	}

	private int CountNewVisible(sbyte[,] forest, bool[,] visible, bool row, int r_start, int r_end, int r_dir, int c_start, int c_end, int c_dir) {
		int i_start = row ? (r_dir > 0 ? r_start : r_start-1) : (c_dir > 0 ? c_start : c_start - 1);
		int i_end = row ? r_end : c_end;
		int i_dir = row ? r_dir : c_dir;

		int j_start = row ? (c_dir > 0 ? c_start : c_start - 1) : (r_dir > 0 ? r_start : r_start - 1);
		int j_end = row ? c_end : r_end;
		int j_dir = row ? c_dir : r_dir;

		int count = 0;
		for (int i = i_start;
			i_dir > 0 ? i < i_end : i >= i_end;
			i += i_dir
		) {
			sbyte max = -1;
			for (int j = j_start;
				j_dir > 0 ? j < j_end : j >= j_end;
				j += j_dir
			) {
				int r = row ? i : j;
				int c = row ? j : i;

				if (forest[r, c] > max) {
					max = forest[r, c];
					if (!visible[r, c]) {
						visible[r, c] = true;
						count++;
					}
					if (max == 9) {
						break;
					}
				}
			}
		}

		return count;
	}
}