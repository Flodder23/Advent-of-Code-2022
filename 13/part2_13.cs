using System.Collections;

partial class Day13 {
	public override int Part2(in (object[], object[])[] input) {
		object[] inp = new object[input.Length * 2 + 2];
		for (int i = 0; i < input.Length; i++) {
			inp[2 * i] = input[i].Item1;
			inp[2 * i + 1] = input[i].Item2;
		}
		inp[2 * input.Length] = new object[] { new object[] { 2 } };
		inp[2 * input.Length + 1] = new object[] { new object[] { 6 } };

		Array.Sort(inp, (i1, i2) => Compare(i1, i2).Item2 ? -1 : 1);

		int? two_pos = null, six_pos = null;
		for (int i = 0; i < inp.Length; i++) {
			if (inp[i] is object[] && ((object[])inp[i]).Length == 1) {
				if (((object[])inp[i])[0] is object[] && ((object[])((object[])inp[i])[0]).Length == 1) {
					if (((object[])((object[])inp[i])[0])[0] is int) {
						if ((int)((object[])((object[])inp[i])[0])[0] == 2) {
							two_pos = i + 1;
						} else if ((int)((object[])((object[])inp[i])[0])[0] == 6) {
							six_pos = i + 1;
						}
					}
				}
			}
		}
		return (two_pos ?? 0) * (six_pos ?? 0);
	}
}