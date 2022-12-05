partial class Day05 {
	public override string Part1(in (Stack<char>[], (int, int, int)[]) input) {
		Stack<char>[] stacks = Duplicate(input.Item1);
		(int, int, int)[] instrs = input.Item2;

		foreach ((int move, int from, int to) in instrs) {
			for (int i = 0; i < move; i++) {
				stacks[to - 1].Push(stacks[from - 1].Pop());
			}
		}

		string output = "";
		foreach (var stack in stacks) {
			output += stack.Pop();
		}

		sol_1 = output;
		return output;
	}
}