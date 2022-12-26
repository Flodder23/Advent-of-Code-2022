partial class Day25 {
	public override string Part1(in string[] input) {
		string sum = "0";
		foreach (string num in input) {
			sum = AddSNAFU(sum, num);
		}
		return sum;
	}

	private static string AddSNAFU(string a, string b) {
		string c = "";
		char carry = '0';
		for (int i = 0; carry != '0' || i < a.Length || i < b.Length; i++) {
			int val = SNAFUToDec[carry];

			if (i < a.Length) {
				val += SNAFUToDec[a[a.Length - 1 - i]];
			}
			if (i < b.Length) {
				val += SNAFUToDec[b[b.Length - 1 - i]];
			}

			string val_str = DecToSNAFU[val];
			c = val_str[1] + c;
			carry = val_str[0];
		}
		return c;
	}

	private static readonly Dictionary<char, int> SNAFUToDec = new() {
		{ '=', -2 }, { '-', -1 }, { '0', 0 }, { '1', 1 }, { '2', 2 }
	};
	private static readonly Dictionary<int, string> DecToSNAFU = new() {
		{ -5, "-0" },
		{ -4, "-1" },
		{ -3, "-2" },
		{ -2, "0=" },
		{ -1, "0-" },
		{  0, "00" },
		{  1, "01" },
		{  2, "02" },
		{  3, "1=" },
		{  4, "1-" },
		{  5, "10" }
	};
}