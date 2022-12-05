partial class Day02 {
	public override (int, int)[] GetParsedInput() {
		/*	Changing to 0, 1, 2 as we can the use maths to calculate the outcomes instead of having to list them;
			If Rock = 0, Paper = 1, Scissors = 2, then:
				- the score for each shape is one more than its value,
				- the score for each round if opponent selects x and you select y is: 3 * ((2x + y + 1) % 3)
				- if your opponent selects x and you want to y = 0(lose), 1(draw), 2(win), you should pick the shape corresponding to (2 + x + y) % 3.
			I'm not sure this makes anything quicker, if you want speed you should just hardcode it, but I liked this solution.
		*/

		string[] in_str = raw_input.Split(Environment.NewLine);

		Dictionary<char, int> ch_map = new Dictionary<char, int>() {
			['A'] = 0,
			['B'] = 1,
			['C'] = 2,
			['X'] = 0,
			['Y'] = 1,
			['Z'] = 2
		};
		(int, int)[] in_int = new (int, int)[in_str.Length];
		for (int i = 0; i < in_int.Length; i++) {
			in_int[i] = (ch_map[in_str[i][0]], ch_map[in_str[i][2]]);
		}

		return in_int;
	}
}