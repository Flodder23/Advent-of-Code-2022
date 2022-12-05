using System.Text.RegularExpressions;

partial class Day05 {
	public override (Stack<char>[], (int, int, int)[]) GetParsedInput() {
		string[] input = raw_input.Split(Environment.NewLine + Environment.NewLine);

		string[] raw_stacks = input[0].Split(Environment.NewLine);
		Stack<char>[] stacks = new Stack<char>[(raw_stacks[0].Length + 1) / 4];
		for (int i = 0; i < stacks.Length; i++) {
			stacks[i] = new Stack<char>();
			for (int j = raw_stacks.Length - 2; j >= 0; j--) {
				char cargo = raw_stacks[j][1 + 4 * i];
				if (cargo == ' ') {
					break;
				}
				stacks[i].Push(cargo);
			}
		}

		string[] raw_instrs = input[1].Split(Environment.NewLine);
		(int, int, int)[] instrs = new (int, int, int)[raw_instrs.Length];
		for (int i = 0; i < instrs.Length; i++) {
			var instr = Regex.Match(raw_instrs[i], @"move (\d+) from (\d+) to (\d+)").Groups;
			instrs[i] = (int.Parse(instr[1].Value), int.Parse(instr[2].Value), int.Parse(instr[3].Value));
		}

		return (stacks, instrs);
	}
}