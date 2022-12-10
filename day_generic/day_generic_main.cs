abstract partial class Day<InputType, Sol1Type, Sol2Type> : Day {
	private Sol1Type? sol_1;

	private Sol2Type? sol_2;

	public Day(int day_ref_int, string? input_location = null) : base(day_ref_int, input_location) { }

	public override void WriteSol1() {
		Console.WriteLine($"Day {day_ref_str} Part 1: {sol_1}");
	}
	public override void WriteSol2() {
		Console.WriteLine($"Day {day_ref_str} Part 2: {sol_2}");
	}
}