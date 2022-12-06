Day[] days = new Day[25];
int latest_day = -1;

int day_ref_int = 0;
while (day_ref_int <= 25) {
	Type T = Type.GetType($"Day{day_ref_int:D2}");
	if (T != null) {
		days[day_ref_int] = (Day)Activator.CreateInstance(T);
		latest_day = day_ref_int;
	}

	day_ref_int++;
}

if (latest_day < 0) {
	Console.WriteLine("Couldn't find any puzzle solutions to run.");
} else {
	Console.WriteLine($"Running most recent day (Day {latest_day:D2})...");
	days[latest_day].Run(write_sol_1: true, write_sol_2: true);
}

Console.WriteLine("Enter \"y\" to run every day's solution, or anything else to quit.");
if (Console.ReadLine() == "y") {
	for (int i = 1; i < days.Length; i++) {
		if (days[i] != null) {
			Console.WriteLine($"\nRunning Day {i:D2}...");
			days[i].Run(write_sol_1: true, write_sol_2: true);
		}
	}
}

abstract class Day {
	public int day_ref_int;
	public string day_ref_str;
	protected string input_location;

	protected string? raw_input;
	protected string? raw_input_location;

	public Day(int day_ref_int, string? input_location = null) {
		this.day_ref_int = day_ref_int;
		day_ref_str = day_ref_int.ToString("D2");
		this.input_location = input_location ?? $"../../../{day_ref_str}/input_{day_ref_str}.txt";
	}

	public void SetInputLocation(string input_location) {
		this.input_location = input_location;
	}
	public string GetInputLocation() => input_location;

	public string FetchRawInput() {
		return File.ReadAllText(input_location).TrimEnd('\n');
	}
	public void SetRawInput() {
		if (raw_input == null || raw_input_location != input_location) {
			raw_input = FetchRawInput();
			raw_input_location = input_location;
		}
	}
	public string GetRawInput(bool set_if_needed = true) {
		if (set_if_needed) {
			SetRawInput();
		}
		return raw_input;
	}
	public string GetRawInputLocation() => raw_input_location;

	public abstract void SetParsedInput(bool force = false);

	public abstract void RunPart1(bool force = true, bool force_parse_input = false, bool write_out = false);
	public abstract void RunPart2(bool force = true, bool force_parse_input = false, bool write_out = false);
	public abstract void Run(bool force_input_parse = false, bool force_part_1 = false, bool force_part_2 = false, bool write_sol_1 = false, bool write_sol_2 = false);
}

abstract class Day<InputType, Sol1Type, Sol2Type> : Day {
	private InputType? parsed_input;
	private string? parsed_input_location;

	private Sol1Type? sol_1;
	private bool has_sol_1 = false;

	private Sol2Type? sol_2;
	private bool has_sol_2 = false;

	public Day(int day_ref_int, string? input_location = null) : base(day_ref_int, input_location) { }

	public abstract InputType ParseInput(string? raw_input = null);
	public override void SetParsedInput(bool force = false) {
		GetRawInput();
		if (force || parsed_input_location != input_location) {
			parsed_input = ParseInput(raw_input);
			parsed_input_location = raw_input_location;
		}
	}
	public InputType GetParsedInput(bool set_if_needed = true) {
		if (set_if_needed) {
			SetParsedInput();
		}
		return parsed_input;
	}

	public abstract Sol1Type Part1(in InputType input);
	public override void RunPart1(bool force = true, bool force_parse_input = false, bool write_out = false) {
		if (force || !has_sol_1) {
			SetParsedInput(force_parse_input);
			sol_1= Part1(parsed_input);
			has_sol_1 = true;
		}

		if (write_out) {
			Console.WriteLine($"Day {day_ref_str} Part 1: {sol_1}");
		}
	}
	public Sol1Type GetSol1(bool set_if_needed = true) {
		if (set_if_needed) {
			RunPart1();
		}
		return sol_1;
	}

	public abstract Sol2Type Part2(in InputType input);
	public override void RunPart2(bool force = true, bool force_parse_input = false, bool write_out = false) {
		if (force || !has_sol_2) {
			SetParsedInput(force_parse_input);
			sol_2 = Part2(parsed_input);
			has_sol_2 = true;
		}

		if (write_out) {
			Console.WriteLine($"Day {day_ref_str} Part 2: {sol_2}");
		}
	}
	public Sol2Type GetSol2(bool set_if_needed = true) {
		if (set_if_needed) {
			RunPart2();
		}
		return sol_2;
	}

	public override void Run(bool force_parse_input=false, bool force_part_1 = false, bool force_part_2 = false, bool write_sol_1 = false, bool write_sol_2 = false) {
		SetParsedInput(force_parse_input);

		RunPart1(force_part_1, write_out: write_sol_1);

		RunPart2(force_part_2, write_out: write_sol_2);
	}
}