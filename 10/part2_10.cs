using System.Globalization;

partial class Day10 {
	public override string Part2(in int?[] input) {
		bool[,] screen = new bool[6, 40];
		int x = 1;
		int cycle_no = 0;
		int instr_no = 0;
		int instr_time = 0;
		while (instr_no < input.Length) {
			screen[(cycle_no / 40) % 6, cycle_no % 40] = ((cycle_no % 40) - x <= 1 && (cycle_no % 40) - x >= -1);

			cycle_no++;
			instr_time++;

			if (instr_time == (input[instr_no] == null ? 1 : 2)) {
				x += input[instr_no] ?? 0;
				instr_no++;
				instr_time = 0;
			}
		}

		string output = "";
		for (int i = 0; i < screen.GetLength(0); i++) {
			output += Environment.NewLine;
			for (int j = 0; j < screen.GetLength(1); j++) {
				output += screen[i, j] ? '#' : '.';
			}
		}

		return output;
	}
}