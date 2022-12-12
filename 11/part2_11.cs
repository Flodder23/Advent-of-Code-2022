partial class Day11 {
	public override long Part2(in Monkey[] input) {
		MonkeyGroup monkey_group = new(input, false);
		monkey_group.DoRounds(10_000);
		return monkey_group.GetMonkeyBusinessLevel();
	}
}