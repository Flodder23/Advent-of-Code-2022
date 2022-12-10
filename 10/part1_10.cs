partial class Day10 {
	public override int Part1(in int?[] input) {
		int x = 1;
		int cycle_no = 0;
		int instr_no = 0;
		int instr_time = 0;
		int sum = 0;
		while (instr_no < input.Length) {
			cycle_no++;
			instr_time++;
			if (cycle_no <= 220 && (cycle_no - 20) % 40 == 0) {
				sum += cycle_no * x;
			}

			if (instr_time == (input[instr_no] == null ? 1 : 2)) {
				x += input[instr_no] ?? 0;
				instr_no++;
				instr_time = 0;
			}
		}
		return sum;
	}
}