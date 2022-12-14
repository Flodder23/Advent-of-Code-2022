abstract partial class Day {
	public abstract void RunPart1(bool force = true, bool force_parse_input = false, bool write_out = false);
	public abstract void RunPart2(bool force = true, bool force_parse_input = false, bool write_out = false);
	public abstract void Run(bool force_input_parse = false, bool force_part_1 = false, bool force_part_2 = false, bool write_sol_1 = false, bool write_sol_2 = false);

	public abstract bool RunTests(bool skip_1 = false, bool skip_2 = false, bool write_fail_1 = true, bool write_fail_2 = true);

	public float RunTimed(bool write_results = true) {
		Run(true, true, write_results); // run once to avoid one-time performance hits and to write input values
		WriteSols();
		float parse_input_ms = Functions.TimeFunctionMicro(() => SetParsedInput(true));
		float parse_part_1_ms = Functions.TimeFunctionMicro(() => RunPart1(true));
		float parse_part_2_ms = Functions.TimeFunctionMicro(() => RunPart2(true));
		if (write_results) {
			Console.WriteLine(
				$" input: {parse_input_ms:N3}µs\n" +
				$"part 1: {parse_part_1_ms:N3}µs\n" +
				$"part 2: {parse_part_2_ms:N3}µs\n" +
				$" total: {(parse_input_ms + parse_part_1_ms + parse_part_2_ms):N3}µs"
			);
		}
		return parse_input_ms + parse_part_1_ms + parse_part_2_ms;
	}
}