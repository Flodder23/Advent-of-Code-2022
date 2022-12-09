partial class Day09 {
	public override int Part2(in ((int, int), int)[] input) {
		return GetTailVisited(input, 10);
	}
}