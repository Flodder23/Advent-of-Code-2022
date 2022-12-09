partial class Day08 {
	public override int Part2(in sbyte[,] input) {
		int[,,] viewing_distances = new int[input.GetLength(0), input.GetLength(1), 4];

		GetViewingDistances(input, viewing_distances, true,
			0, input.GetLength(0), 1,
			0, input.GetLength(1), 1
		);
		GetViewingDistances(input, viewing_distances, true,
			0, input.GetLength(0), 1,
			input.GetLength(1), 0, -1
		);
		GetViewingDistances(input, viewing_distances, false,
			0, input.GetLength(0), 1,
			0, input.GetLength(1), 1
		);
		GetViewingDistances(input, viewing_distances, false,
			input.GetLength(0), 0, -1,
			0, input.GetLength(1), 1
		);

		int max = 0;
		for (int i = 0; i < input.GetLength(0); i++) {
			for (int j = 0; j < input.GetLength(1); j++) {
				int scenic_score = viewing_distances[i, j, 0] * viewing_distances[i, j, 1] * viewing_distances[i, j, 2] * viewing_distances[i, j, 3];
				if (scenic_score > max) {
					max = scenic_score;
				}
			}
		}

		return max;
	}

	private void GetViewingDistances(sbyte[,] forest, int[,,] viewing_distances, bool row, int r_start, int r_end, int r_dir, int c_start, int c_end, int c_dir) {
		int view_dir = row ? (c_dir > 0 ? 0 : 2) : (r_dir > 0 ? 1 : 3);

		int i_start = row ? (r_dir > 0 ? r_start : r_start - 1) : (c_dir > 0 ? c_start : c_start - 1);
		int i_end = row ? r_end : c_end;
		int i_dir = row ? r_dir : c_dir;

		int j_start = row ? (c_dir > 0 ? c_start : c_start - 1) : (r_dir > 0 ? r_start : r_start - 1);
		int j_end = row ? c_end : r_end;
		int j_dir = row ? c_dir : r_dir;

		for (int i = i_start;
			i_dir > 0 ? i < i_end : i >= i_end;
			i += i_dir
		) {
			for (int j = j_start;
				j_dir > 0 ? j < j_end : j >= j_end;
				j += j_dir
			) {
				int r = row ? i : j;
				int c = row ? j : i;

				int k = j - j_dir;
				while (j_dir > 0 ? k >= j_start : k <= j_start) {
					int new_r = row ? i : k;
					int new_c = row ? k : i;
					viewing_distances[r, c, view_dir]++;
					k -= j_dir;
					if (forest[r, c] <= forest[new_r, new_c]) {
						break;
					} else {
//						viewing_distances[r, c, view_dir] += viewing_distances[new_r, new_c, view_dir];
//						k -= j_dir * viewing_distances[new_r, new_c, view_dir];
					}
				}
			}
		}
	}
}