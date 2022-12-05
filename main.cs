Day[] days = new Day[25];
int latest_day = -1;

int day_ref_int = 0;
while (day_ref_int <= 25) {
	Type T = Type.GetType($"Day{day_ref_int:D2}");
	if (T != null) {
		days[day_ref_int] = (Day)Activator.CreateInstance(T, day_ref_int);
		latest_day = day_ref_int;
	}

	day_ref_int++;
}

if (latest_day < 0) {
	Console.WriteLine("Couldn't find any puzzle solutions to run.");
} else {
	Console.WriteLine($"Running most recent day (Day {latest_day:D2})...");
	days[latest_day].Run();
}

Console.WriteLine("Enter \"y\" to run every day's solution, or anything else to quit.");
if (Console.ReadLine() == "y") {
	for (int i = 1; i < days.Length; i++) {
		if (days[i] != null) {
			Console.WriteLine($"\nRunning Day {i:D2}...");
			days[i].Run();
		}
	}
}

public abstract class Day {
	public abstract void Run(bool output_1 = true, bool output_2 = true);
}

abstract class Day<InputType, Sol1Type, Sol2Type> : Day {
	public int day_ref_int;
	public string day_ref_str;
	public string input_location;

	public string? raw_input;
	private bool has_raw_input = false;

	public InputType? parsed_input;
	private bool has_parsed_input = false;

	public Sol1Type? sol_1;
	public Sol2Type? sol_2;

	public Day(int day_ref_int) {
		this.day_ref_int = day_ref_int;
		day_ref_str = day_ref_int.ToString("D2");
		input_location = $"../../../{day_ref_str}/input_{day_ref_str}.txt";
	}

	public void GetRawInput(bool force = false) {
		if (force || !has_raw_input) {
			raw_input = System.IO.File.ReadAllText(input_location).TrimEnd('\n');
			has_raw_input = true;
		}
	}

	public abstract InputType GetParsedInput();

	public void ParseInput(bool force = false) {
		if (force || !has_parsed_input) {
			if (!has_raw_input) {
				GetRawInput();
			}
			parsed_input = GetParsedInput();
			has_parsed_input = true;
		}
	}

	public abstract Sol1Type Part1(in InputType input);
	public void RunPart1(bool force = true, bool write_out = false) {
		if (force || sol_1 == null)
		{
			sol_1 = Part1(parsed_input);
		}
		if (write_out) {
			Console.WriteLine($"Day {day_ref_str} Part 1: " + (sol_1 == null ? "FAILED" : sol_1));
		}
	}

	public abstract Sol2Type Part2(in InputType input);
	public void RunPart2(bool force = true, bool write_out = false) {
		if (force || sol_2 == null) {
			sol_2 = Part2(parsed_input);
		}
		if (write_out) {
			Console.WriteLine($"Day {day_ref_str} Part 2: " + (sol_2 == null ? "FAILED" : sol_2));
		}
	}

	public override void Run(bool write_sol_1 = true, bool write_sol_2 = true) {
		ParseInput();

		RunPart1(write_out: write_sol_1);

		RunPart2(write_out: write_sol_2);
	}
}