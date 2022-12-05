partial class Day02 : Day<(int, int)[], int, int> {
	public Day02(int day_ref_int) : base(day_ref_int) { }

	private Dictionary<(int, int), int>? overall_score;
	Dictionary<(int, int), int>? to_fix;

	private void precalc_scores() {
		if (overall_score == null) {
			overall_score = new Dictionary<(int, int), int>();
			int[] chs = { 0, 1, 2 };
			foreach (int opp_ch in chs) {
				foreach (int own_ch in chs) {
					overall_score[(opp_ch, own_ch)] = 1 + own_ch + 3 * ((2 * opp_ch + own_ch + 1) % 3);
				}
			}
		}
	}

	private void precalc_fixes() {
		if (to_fix == null) {
			to_fix = new Dictionary<(int, int), int>();
			int[] chs = { 0, 1, 2 };
			foreach (int opp_ch in chs) {
				foreach (int fix_ch in chs) {
					to_fix[(opp_ch, fix_ch)] = (2 + opp_ch + fix_ch) % 3;
				}
			}
		}
	}
}