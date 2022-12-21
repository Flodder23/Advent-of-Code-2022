partial class Day03 : Day<char[][], int, int> {
	public Day03(int day_ref_int) : base(day_ref_int) { }
	public Day03() : base(3) { }

	private static int GetPriority(char c) => c - (char.IsUpper(c) ? 38 : 96);
}