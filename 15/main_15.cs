partial class Day15 : Day<((int, int), (int, int))[], int, long> {
	public Day15(int day_ref_int) : base(day_ref_int) { }
	public Day15() : base(15) { }

	private static int Manhattan((int, int) a, (int, int) b) => Math.Abs(a.Item1 - b.Item1) + Math.Abs(a.Item2 - b.Item2);

	private List<(int, int)> GetRangesForLine(((int, int), (int, int))[] beacons, int[] beacon_dists, int line_no) {
		List<(int, int)> ranges = new();

		for (int i = 0; i < beacons.Length; i++) {
			int dist = beacon_dists[i] - Math.Abs(beacons[i].Item1.Item2 - line_no);
			if (dist >= 0) {
				(int, int) new_range = (beacons[i].Item1.Item1 - dist, beacons[i].Item1.Item1 + dist + 1);
				AddRange(ranges, new_range);
			}
		}
		return ranges;
	}

	private void AddRange(List<(int, int)> ranges, (int, int) range) {
		int i = 0;
		while (i < ranges.Count && ranges[i].Item2 <= range.Item1) {
			i++;
		}
		if (i < ranges.Count) {
			if (range.Item1 < ranges[i].Item1) {
				ranges.Insert(i, range);
			}
			else {
				ranges[i] = (ranges[i].Item1, Math.Max(ranges[i].Item2, range.Item2));
			}
		}
		else {
			ranges.Add(range);
		}
		i++;
		int last_upper = range.Item2;
		while (i < ranges.Count && range.Item2 >= ranges[i].Item1) {
			last_upper = ranges[i].Item2;
			ranges.RemoveAt(i);
		}
		ranges[i - 1] = (ranges[i - 1].Item1, Math.Max(ranges[i - 1].Item2, last_upper));
	}
}