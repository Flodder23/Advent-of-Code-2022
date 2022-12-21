partial class Day21 {
	public override (string, long)[] Tests1() => new (string, long)[] {
		("root: pppw + sjmn\r\ndbpl: 5\r\ncczh: sllz + lgvd\r\nzczc: 2\r\nptdq: humn - dvpt\r\ndvpt: 3\r\nlfqf: 4\r\nhumn: 5\r\nljgn: 2\r\nsjmn: drzm * dbpl\r\nsllz: 4\r\npppw: cczh / lfqf\r\nlgvd: ljgn * ptdq\r\ndrzm: hmdt - zczc\r\nhmdt: 32", 152)
	};

	public override (string, long)[] Tests2() => new (string, long)[] {
		("root: pppw + sjmn\r\ndbpl: 5\r\ncczh: sllz + lgvd\r\nzczc: 2\r\nptdq: humn - dvpt\r\ndvpt: 3\r\nlfqf: 4\r\nhumn: 5\r\nljgn: 2\r\nsjmn: drzm * dbpl\r\nsllz: 4\r\npppw: cczh / lfqf\r\nlgvd: ljgn * ptdq\r\ndrzm: hmdt - zczc\r\nhmdt: 32", 301),
		("root: juli + josi\r\njuli: amee + alex\r\namee: buki * abby\r\nbuki: 5\r\nabby: 4\r\nalex: 4\r\njosi: benj / mark\r\nbenj: 360\r\nmark: emly - humn\r\nemly: 34\r\nhumn: 0", 19)
	};
}