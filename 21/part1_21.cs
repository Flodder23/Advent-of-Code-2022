partial class Day21 {
	public override long Part1(in Dictionary<string, Monkey> input) {
		var monkeys = CopyMonkeyDict(input);
		return (long)monkeys["root"].GetNumber(monkeys);
	}
}