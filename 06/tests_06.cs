partial class Day06 {
	public override (string, int)[] Tests1() => new (string, int)[] {
		("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7),
		("bvwbjplbgvbhsrlpgdmjqwftvncz", 5),
		("nppdvjthqldpwncqszvftbrmjlhg", 6),
		("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10),
		("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)
	};

	public override (string, int)[] Tests2() => new (string, int)[] {
		("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19),
		("bvwbjplbgvbhsrlpgdmjqwftvncz", 23),
		("nppdvjthqldpwncqszvftbrmjlhg", 23),
		("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29),
		("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)
	};
}