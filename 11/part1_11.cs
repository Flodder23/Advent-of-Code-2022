partial class Day11 {
	public override int Part1(in Monkey[] input) {
		MonkeyGroup monkey_group = new(input);
		monkey_group.DoRounds(20);
		return (int)monkey_group.GetMonkeyBusinessLevel();
	}
}