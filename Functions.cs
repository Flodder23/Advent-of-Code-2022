using System.Diagnostics;

class Functions {
	public static int GreatestCommonFactor(int a, int b) {
		while (b != 0) {
			(a, b) = (b, a % b);
		}
		return a;
	}
	public static int LeastCommonMultiple(int a, int b) {
		return (a * b) / GreatestCommonFactor(a, b);
	}
	public static float TimeFunctionMicro(Action function, bool skip_first = false, int times_to_run = 120, int trim_outliers = 10) {
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

	public static int Modulo(int a, int b) {
		int r = a % b;
		return r + (r < 0 ? b : 0);
	}
}