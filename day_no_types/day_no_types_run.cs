abstract partial class Day {
	public abstract void RunPart1(bool force = true, bool force_parse_input = false, bool write_out = false);
	public abstract void RunPart2(bool force = true, bool force_parse_input = false, bool write_out = false);
	public abstract void Run(bool force_input_parse = false, bool force_part_1 = false, bool force_part_2 = false, bool write_sol_1 = false, bool write_sol_2 = false);

	public abstract bool RunTests(bool skip_1 = false, bool skip_2 = false, bool write_fail_1 = true, bool write_fail_2 = true);
}