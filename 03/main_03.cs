partial class Day03 : Day<char[][], int, int> {
	public Day03(int day_ref_int) : base(day_ref_int) { }

	private static int GetPriority(char c) => (int)c - (char.IsUpper(c) ? 38 : 96);
}