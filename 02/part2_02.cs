partial class Day02 {
	public override int Part2(in (int, int)[] input) {
		precalc_scores();
		precalc_fixes();

		int sum = 0;
		foreach ((int opp_ch, int own_ch) in input) {
			sum += overall_score[(opp_ch, to_fix[(opp_ch, own_ch)])];
		}

		return sum;
	}
}