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
bool stop = false;
while (!stop) {
	Console.WriteLine("Enter \"y\" to run and time every day's solution, a number to run and time that day's solution, or anything else to quit.");
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
				days[i].RunTimed();
			}
		}
	} else if (int.TryParse(input, out int day_to_run)) {
		Console.WriteLine($"\nRunning Day {day_to_run:D2}...");
		if (days[day_to_run].RunTests()) {
			Console.WriteLine("Tests Passed!");
		}
		else {
			continue;
		}
		days[day_to_run].RunTimed();
	} else {
		stop = true;
	}
}