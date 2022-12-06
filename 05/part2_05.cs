partial class Day05 {
	public override string Part2(in (Stack<char>[], (int, int, int)[]) input) {
		Stack<char>[] stacks = Duplicate(input.Item1);
		(int, int, int)[] instrs = input.Item2;

		foreach ((int move, int from, int to) in instrs) {
			Stack<char> temp = new();
			for (int i = 0; i < move; i++) {
				temp.Push(stacks[from - 1].Pop());
			}

			for (int i = 0; i < move; i++) {
				stacks[to - 1].Push(temp.Pop());
			}
		}

		string output = "";
		foreach (var stack in stacks) {
			output += stack.Pop();
		}

		return output;
	}
}