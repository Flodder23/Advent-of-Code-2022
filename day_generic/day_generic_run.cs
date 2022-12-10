abstract partial class Day<InputType, Sol1Type, Sol2Type> : Day {
	private bool has_sol_1 = false;
	public abstract Sol1Type Part1(in InputType input);
	public override void RunPart1(bool force = true, bool force_parse_input = false, bool write_out = false) {
		if (force || !has_sol_1) {
			SetParsedInput(force_parse_input);
			sol_1 = Part1(parsed_input);
			has_sol_1 = true;
		}

		if (write_out) {
			WriteSol1();
		}
	}
	public Sol1Type GetSol1(bool set_if_needed = true) {
		if (set_if_needed) {
			RunPart1();
		}
		return sol_1;
	}

	private bool has_sol_2 = false;
	public abstract Sol2Type Part2(in InputType input);
	public override void RunPart2(bool force = true, bool force_parse_input = false, bool write_out = false) {
		if (force || !has_sol_2) {
			SetParsedInput(force_parse_input);
			sol_2 = Part2(parsed_input);
			has_sol_2 = true;
		}

		if (write_out) {
			WriteSol2();
		}
	}
	public Sol2Type GetSol2(bool set_if_needed = true) {
		if (set_if_needed) {
			RunPart2();
		}
		return sol_2;
	}

	public override void Run(bool force_parse_input = false, bool force_part_1 = false, bool force_part_2 = false, bool write_sol_1 = false, bool write_sol_2 = false) {
		SetParsedInput(force_parse_input);

		RunPart1(force_part_1, write_out: write_sol_1);

		RunPart2(force_part_2, write_out: write_sol_2);
	}
}