partial class Day06 : Day<char[], int, int> {
	public Day06(int day_ref_int) : base(day_ref_int) {}

	// Checks for duplicated in subarray starting at startpos (inclusive) and ending at endpos (exclusive)
	// Returns position of first duplicate if exists, -1 otherwise
	private int CheckDuplicates(in char[] array, int start_pos, int end_pos) {
		for (int i = start_pos;  i < end_pos; i++) {
			for (int j = i+1; j < end_pos; j++) {
				if (array[i] == array[j]) {
					return i;
				}
			}
		}

		return -1;
	}

	// Get end of the first sequence of characters of given length where no characters are repeated, or -1 if none exist
	private int GetFirstNoDuplicates(in char[] array, int length) {
		int i = 0;
		while (i < array.Length - length) {
			int dup_pos = CheckDuplicates(array, i, i + length);
			if (dup_pos == -1) {
				return i + length;
			}
			else {
				i = dup_pos + 1;
			}
		}

		return -1;
	}
}