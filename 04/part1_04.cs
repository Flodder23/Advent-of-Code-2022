partial class Day04 {
	public override int Part1(in ((int, int), (int, int))[] input) {
		int total = 0;
		foreach (var pair in input) {
			((int a, int b), (int c, int d)) = pair;
			total += ((a <= c && b >= d) || (a >= c && b <= d)) ? 1 : 0;
		}

		return total;
	}
}