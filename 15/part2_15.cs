partial class Day15 {
	public override long Part2(in ((int, int), (int, int))[] input) {
		int min_x = 0, max_x = 4_000_001, min_y = 0, max_y = 4_000_001;
		((int, int), int)[] sensors = input.Select(info => (info.Item1, Manhattan(info.Item1, info.Item2))).ToArray();
		int[] beacon_dists = input.Select(info => Manhattan(info.Item1, info.Item2)).ToArray();
		for (int i = min_y; i < max_y; i++) {
			List<(int, int)> ranges = GetRangesForLine(input, beacon_dists, i);
			if (ranges[0].Item1 == min_x + 1) {
				return TuningFreq(min_x, i);
			}
			for (int j = 1; j < ranges.Count; j++) {
				if (0 <= ranges[j - 1].Item2 && ranges[j].Item1 <= max_x) {
					return TuningFreq(ranges[j - 1].Item2, i);
				}
			}
			if (ranges[ranges.Count-1].Item2 == max_x) {
				return TuningFreq(max_x - 1, i);
			}
		}

		//		This solution (inspired by
		//		https://www.reddit.com/r/adventofcode/comments/zmw9d8/2022_day_15_part_2_speed_up_your_solution_60000x/
		//		) actually runs slower but if I can search through fewer
		//		points by eg. finding intersections then it will become much quicker
		//		than the "brute-force-all-4_000_000-lines" method so I'll leave
		//		this here in case I get around to implementing that at some point

		/*		foreach (((int, int), int) sensor in sensors) {
					int x = sensor.Item1.Item1, y = sensor.Item1.Item2;
					int len = sensor.Item2 + 1;
					for (int i = 0; i <= len; i++) {
						foreach ((int x_diff, int y_diff) in new (int, int)[] {
							(i, len - i), (len - i, i), (-i, len + i), (len + i, -i) }
						) {
							int new_x = x + x_diff, new_y = y + y_diff;
							if (min_x <= new_x && new_x < max_x &&
								min_y <= new_y && new_y < max_y &&
								!IsInSensorRange((x + x_diff, y + y_diff), sensors)
							) {
								return (long)(x + x_diff) * 4_000_000 + (y + y_diff);
							}
						}
					}
				}
		*/
		return 2;
	}

/*	private bool IsInSensorRange((int, int) point, ((int, int), int)[] sensors) {
		foreach (((int, int), int) sensor in sensors) {
			if (Manhattan(sensor.Item1, point) <= sensor.Item2) {
				return true;
			}
		}
		return false;
	}
*/
	private long TuningFreq(long x, long y) => x * 4_000_000 + y;
}