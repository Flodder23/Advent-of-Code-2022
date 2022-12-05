partial class Day03 {
	public override int Part1(in char[][] input) {
		int sum = 0;
		foreach (char[] items in input) {
			HashSet<char> bag_1 = new HashSet<char>(items.Take(items.Length / 2));
			foreach (char item in items.Skip(items.Length / 2)) {
				if (bag_1.Contains(item)) {
					sum += GetPriority(item);
					break;
				}
			}
		}

		return sum;
	}
}