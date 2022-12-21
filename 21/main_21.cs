using System.Text.RegularExpressions;

partial class Day21 : Day<Dictionary<string, Day21.Monkey>, long, long> {
	public Day21(int day_ref_long) : base(day_ref_long) { }
	public Day21() : base(21) { }

	private static Dictionary<char, Func<long, long, long>> Calculate = new() {
		{ '+', (long l, long r) => l + r },
		{ '-', (long l, long r) => l - r },
		{ '*', (long l, long r) => l * r },
		{ '/', (long l, long r) => l / r }
	};
	private static Dictionary<char, Func<long, long, long>> GetLeft = new() {
		{ '+', (long r, long result) => result - r },
		{ '-', (long r, long result) => result + r },
		{ '*', (long r, long result) => result / r },
		{ '/', (long r, long result) => result * r },
		{ '=', (long r, long result) => r }
	};
	private static Dictionary<char, Func<long, long, long>> GetRight = new() {
		{ '+', (long l, long result) => result - l },
		{ '-', (long l, long result) => l - result },
		{ '*', (long l, long result) => result / l },
		{ '/', (long l, long result) => l / result },
		{ '=', (long l, long result) => l }
	};

	public class Monkey {
		public string? left, right;
		public char? oper;
		public long? number;
		public Monkey(string left, string right, char oper) {
			this.left = left;
			this.right = right;
			this.oper = oper;
		}
		public Monkey(long number) {
			this.number = number;
		}

		public long? GetNumber(in Dictionary<string, Monkey> monkeys) {
			if (oper is not null) {
				long? left = monkeys[this.left].GetNumber(monkeys);
				long? right = monkeys[this.right].GetNumber(monkeys);
				if (number is not null) {
					if (left is null && this.left is not null && right is not null) {
						monkeys[this.left].number = GetLeft[(char)oper]((long)right, (long)number);
						monkeys[this.left].GetNumber(monkeys);
					}
					else if (right is null && this.right is not null && left is not null) {
						monkeys[this.right].number = GetRight[(char)oper]((long)left, (long)number);
						monkeys[this.right].GetNumber(monkeys);
					}
				} else if (left is not null && right is not null) {
					number = Calculate[(char)oper]((long)left, (long)right);
				}
			}
			return number;
		}
	}

	Monkey CopyMonkey(in Monkey monkey) {
		if (monkey.oper is null) {
			return new Monkey((long)monkey.number);
		} else {
			return new Monkey(monkey.left, monkey.right, (char)monkey.oper);
		}
	}
	Dictionary<string, Monkey> CopyMonkeyDict(in Dictionary<string, Monkey> monkeys) {
		Dictionary<string, Monkey> new_monkeys = new();
		foreach (string name in monkeys.Keys) {
			new_monkeys.Add(name, CopyMonkey(monkeys[name]));
		}
		return new_monkeys;
	}
}