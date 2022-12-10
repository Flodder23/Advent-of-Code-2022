using System.Diagnostics;

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
	if (days[latest_day].RunTests()) {
		Console.WriteLine("Tests Passed!");
		days[latest_day].Run(write_sol_1: true, write_sol_2: true);
	}
}

Console.WriteLine("Enter \"y\" to run and time every day's solution, a number to run that day's solution, or anything else to quit.");
string input = Console.ReadLine();
if (input == "y") {
	for (int i = 1; i < days.Length; i++) {
		if (days[i] != null) {
			Console.WriteLine($"\nRunning Day {i:D2}...");
			if (days[i].RunTests()) {
				Console.WriteLine("Tests Passed!");
			}
			else {
				continue;
			}
			days[i].Run(true, true, true); // run once to avoid one-time performance hits and to write input values
			days[i].WriteSols();
			float parse_input_ms = TimeFunctionMicro(() => days[i].SetParsedInput(true));
			float parse_part_1_ms = TimeFunctionMicro(() => days[i].RunPart1(true));
			float parse_part_2_ms = TimeFunctionMicro(() => days[i].RunPart2(true));
			Console.WriteLine(
				$" input: {parse_input_ms:N3}µs\n" +
				$"part 1: {parse_part_1_ms:N3}µs\n" +
				$"part 2: {parse_part_2_ms:N3}µs\n" +
				$" total: {(parse_input_ms + parse_part_1_ms + parse_part_2_ms):N3}µs"
			);
		}
	}
} else if (int.TryParse(input, out int day_to_run)) {
	days[day_to_run].Run(write_sol_1: true, write_sol_2: true);
}

float TimeFunctionMicro(Action function, bool skip_first = false, int times_to_run = 120, int trim_outliers = 10) {
	if (skip_first) {
		function(); // run once to avoid one-time performance hits and to write input values
	}

	Stopwatch sw = new Stopwatch();
	List<long> ticks = new();
	for (int i = 0; i < times_to_run; i++) {
		sw.Reset();
		sw.Start();
		function();
		sw.Stop();
		ticks.Add(sw.ElapsedTicks);
	}

	ticks.Sort();
	return (ticks.Skip(trim_outliers).SkipLast(trim_outliers).Sum() * (1000L * 1000L)) / (float)((times_to_run - 2 * trim_outliers) * Stopwatch.Frequency);
}