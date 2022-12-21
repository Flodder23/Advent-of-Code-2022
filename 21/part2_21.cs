partial class Day21 {
	public override long Part2(in Dictionary<string, Monkey> input) {
		var monkeys = CopyMonkeyDict(input);
		monkeys["root"].oper = null;
		monkeys["root"].number = 0;
		monkeys["humn"].number = null;

		if (monkeys[monkeys["root"].left].GetNumber(monkeys) is not null) {
			monkeys[monkeys["root"].right].number = monkeys[monkeys["root"].left].GetNumber(monkeys);
			monkeys[monkeys["root"].right].GetNumber(monkeys);
		} else {
			monkeys[monkeys["root"].left].number = monkeys[monkeys["root"].right].GetNumber(monkeys);
			monkeys[monkeys["root"].left].GetNumber(monkeys);
		}

		return (long)monkeys["humn"].GetNumber(monkeys);
	}
}