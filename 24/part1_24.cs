partial class Day24 {
	public override int Part1(in int[,] input) =>
		FindPathLength((0, 1), (input.GetLength(0) - 1, input.GetLength(1) - 2), input);
}