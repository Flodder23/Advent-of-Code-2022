partial class Day02 {
	public override int Part1(in (int, int)[] input) {
		Dictionary<(int, int), int> overall_score = PrecalcScores();

		int sum = 0;
		foreach ((int, int) choices in input) {
			sum += overall_score[choices];
		}

		return sum;
	}
}