partial class Day02 {
	public override int Part2(in (int, int)[] input) {
		Dictionary<(int, int), int> overall_score = PrecalcScores();
		Dictionary<(int, int), int> to_fix = PrecalcFixes();

		int sum = 0;
		foreach ((int opp_ch, int own_ch) in input) {
			sum += overall_score[(opp_ch, to_fix[(opp_ch, own_ch)])];
		}

		return sum;
	}
	private static Dictionary<(int, int), int> PrecalcFixes() {
		Dictionary<(int, int), int>  to_fix = new();
		int[] chs = { 0, 1, 2 };
		foreach (int opp_ch in chs) {
			foreach (int fix_ch in chs) {
				to_fix[(opp_ch, fix_ch)] = (2 + opp_ch + fix_ch) % 3;
			}
		}
		return to_fix;
	}
}