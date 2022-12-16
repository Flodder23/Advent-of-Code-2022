partial class Day15 {
	public override int Part1(in ((int, int), (int, int))[] input) {
		int[] beacon_dists = input.Select(info => Manhattan(info.Item1, info.Item2)).ToArray();
		List<(int, int)> ranges = GetRangesForLine(input, beacon_dists, 2_000_000);
		return ranges.Select(range => range.Item2 - range.Item1).Sum() - ranges.Count;
	}
}