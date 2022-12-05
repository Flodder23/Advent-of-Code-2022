partial class Day03 {
	public override int Part2(in char[][] input) {
		int group_size = 3;
		int sum = 0;

		for (int i = 0; i < input.Length; i += group_size) {
			HashSet<char> items = new(input[i]);
			for (int j = 1; j < group_size; j++) {
				items.IntersectWith(input[i + j]);
			}

			foreach (char item in items) { // there should only be one left now
				sum += GetPriority(item);
			}
		}

		return sum;
	}
}