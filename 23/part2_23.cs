partial class Day23 {
	public override int Part2(in HashSet<(int, int)> input) {
		HashSet<(int, int)> map = input;
		int i = 0;
		while (DoRound(map, i, out HashSet<(int, int)> new_map)) {
			map = new_map;
			i++;
		}
		return i + 1;
	}
}