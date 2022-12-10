abstract partial class Day<InputType, Sol1Type, Sol2Type> : Day {
	public abstract (string, Sol1Type)[] Tests1();
	public bool RunTests1(bool write_fail = true) {
		int test_no = 0;
		foreach ((string raw_input, Sol1Type sol) in Tests1()) {
			test_no++;
			Sol1Type output = Part1(ParseInput(raw_input));
			if (!Equals(output, sol)) {
				if (write_fail) {
					Console.WriteLine($"Part 1 Test {test_no} Failed; Output {output}.");
				}
				return false;
			}
		}
		return true;
	}

	public abstract (string, Sol2Type)[] Tests2();
	public bool RunTests2(bool write_fail = true) {
		int test_no = 0;
		foreach ((string raw_input, Sol2Type sol) in Tests2()) {
			test_no++;
			Sol2Type output = Part2(ParseInput(raw_input));
			if (!Equals(output, sol)) {
				if (write_fail) {
					Console.WriteLine($"Part 2 Test {test_no} Failed; Output {output}.");
				}
				return false;
			}
		}
		return true;
	}

	public override bool RunTests(bool skip_1 = false, bool skip_2 = false, bool write_fail_1 = true, bool write_fail_2 = true) {
		return (skip_1 || RunTests1(write_fail_1)) && (skip_2 || RunTests2(write_fail_2));
	}
}