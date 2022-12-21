/*	Changing to 0, 1, 2 as we can the use maths to calculate the outcomes instead of having to list them;
	If Rock = 0, Paper = 1, Scissors = 2, then:
		- the score for each shape is one more than its value,
		- the score for each round if opponent selects x and you select y is: 3 * ((2x + y + 1) % 3)
		- if your opponent selects x and you want to y = 0(lose), 1(draw), 2(win), you should pick the shape corresponding to (2 + x + y) % 3.
	I'm not sure this makes anything quicker, if you want speed you should just hardcode it, but I liked this solution.
*/

partial class Day02 : Day<(int, int)[], int, int> {
	public Day02(int day_ref_int) : base(day_ref_int) { }
	public Day02() : base(2) { }

	private static Dictionary<(int, int), int> PrecalcScores() {
		Dictionary<(int, int), int> overall_score = new();
		int[] chs = { 0, 1, 2 };
		foreach (int opp_ch in chs) {
			foreach (int own_ch in chs) {
				overall_score[(opp_ch, own_ch)] = 1 + own_ch + 3 * ((2 * opp_ch + own_ch + 1) % 3);
			}
		}
		return overall_score;
	}
}