partial class Day05 : Day<(Stack<char>[], (int, int, int)[]), string, string> {
	public Day05(int day_ref_int) : base(day_ref_int) { }
	public Day05() : base(5) { }

	private static Stack<char>[] Duplicate(in Stack<char>[] to_duplicate) {
//		return to_duplicate.Select(ch_st => new Stack<char>(ch_st)).ToArray();
		var duplicate = new Stack<char>[to_duplicate.Length];

		for (int i = 0; i < duplicate.Length; i++) {
			duplicate[i] = new Stack<char>(new Stack<char>(to_duplicate[i]));
		}

		return duplicate;
	}
}