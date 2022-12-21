partial class Day13 {
	public override int Part1(in (object[], object[])[] input) {
		int sum = 0;
		for (int i = 0; i < input.Length; i++) {
			if (Compare(input[i].Item1, input[i].Item2).Item2) {
				sum += i + 1;
			}
		}
		return sum;
	}
}