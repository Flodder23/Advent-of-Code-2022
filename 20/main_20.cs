partial class Day20 : Day<List<int>, long, long> {
	public Day20(int day_ref_long) : base(day_ref_long) { }
	public Day20() : base(20) { }

	private static long GetGrooveCoords(List<int> file, int iters = 1, long key =1) {
		List<int> positions = new();
		for (int i = 0; i < file.Count; i++) {
			positions.Add(i);
		}

		for (int i = 0; i < iters; i++) {
			for (int j = 0; j < positions.Count; j++) {
				int pos = positions.IndexOf(j);
				int diff = (int)((key * file[j]) % (positions.Count - 1));
				int new_pos = (pos + diff) % positions.Count;
				if (diff > 0) {
					new_pos++;
				} else if (new_pos < 0) {
					new_pos += positions.Count;
				}

				if (pos < new_pos) {
					positions.Insert(new_pos, j);
					positions.RemoveAt(pos);
				} else {
					positions.RemoveAt(pos);
					positions.Insert(new_pos, j);
				}
			}
		}

		int zero_pos = positions.IndexOf(file.IndexOf(0));
		return key * (file[positions[(zero_pos + 1_000) % positions.Count]] + file[positions[(zero_pos + 2_000) % positions.Count]] + file[positions[(zero_pos + 3_000) % positions.Count]]);
	}
}