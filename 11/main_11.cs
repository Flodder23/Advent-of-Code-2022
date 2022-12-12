using System.Text.RegularExpressions;

partial class Day11 : Day<Monkey[], int, long> {
	public Day11(int day_ref_int) : base(day_ref_int) { }
	public Day11() : base(11) { }
}

public class Monkey {
	public Queue<int> items;
	public (char, int) operation;
	public int test;
	public int if_true;
	public int if_false;
	public int inspections = 0;

	public Monkey(Monkey monkey) {
		items = new(monkey.items);
		operation = new(monkey.operation.Item1, monkey.operation.Item2);
		test = monkey.test;
		if_false = monkey.if_false;
		if_true = monkey.if_true;
		inspections= monkey.inspections;
	}

	public Monkey(string desc) {
		string[] desc_arr = desc.Split(Environment.NewLine);
		items = new Queue<int>(desc_arr[1][18..].Split(", ").Select(num => int.Parse(num)));
		operation = desc_arr[2][25..] == "old" ? ('^', 2) : (desc_arr[2][23], int.Parse(desc_arr[2][25..]));
		test = int.Parse(desc_arr[3][21..]);
		if_true = int.Parse(desc_arr[4][29..]);
		if_false = int.Parse(desc_arr[5][30..]);
	}

	public Queue<(int, int)> TakeTurn(bool worry_decrease = true, int modulo = int.MaxValue) {
		Queue<(int, int)> output = new();
		while (items.Count > 0) {
			inspections++;
			long item = items.Dequeue();
			switch (operation.Item1) {
				case '+':
					item += operation.Item2;
					break;
				case '*':
					item *= operation.Item2;
					break;
				default:
					item *= item;
					break;
			}
			if (worry_decrease) {
				item /= 3;
			} else {
				item %= modulo;
			}
			output.Enqueue((item % test == 0 ? if_true : if_false, (int)item));
		}
		return output;
	}
}

public class MonkeyGroup {
	public Monkey[] monkeys;
	public bool worry_decrease;
	public int global_modulo = 1;

	public MonkeyGroup(in Monkey[] monkeys, bool worry_decrease = true) {
		this.monkeys = monkeys.Select(monkey => new Monkey(monkey)).ToArray();
		this.worry_decrease = worry_decrease;

		if (!worry_decrease) {
			foreach (Monkey monkey in monkeys) {
				global_modulo = LeastCommonMultiple(global_modulo, monkey.test);
			}
		}
	}
	public void DoRound() {
		foreach(Monkey monkey in monkeys) {
			Queue<(int, int)> thrown_items = monkey.TakeTurn(worry_decrease, global_modulo);
			while (thrown_items.Count > 0) {
				(int monkey_no, int worry) = thrown_items.Dequeue();
				monkeys[monkey_no].items.Enqueue(worry);
			}
		}
	}
	public void DoRounds(int num_rounds) {
		for (int i = 0; i < num_rounds; i++) {
			DoRound();
		}
	}

	public long GetMonkeyBusinessLevel() {
		int[] max = { 0, 0 };
		foreach (Monkey monkey in monkeys) {
			if (max[0] < monkey.inspections) {
				max[0] = monkey.inspections;
				if (max[0] > max[1]) {
					(max[0], max[1]) = (max[1], max[0]);
				}
			}
		}
		return (long)max[0] * max[1];
	}

	private static int GreatestCommonFactor(int a, int b) {
		while (b != 0) {
			(a, b) = (b, a % b);
		}
		return a;
	}
	private static int LeastCommonMultiple(int a, int b) {
		return (a * b) / GreatestCommonFactor(a, b);
	}
}