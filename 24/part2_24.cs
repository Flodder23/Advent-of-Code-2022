partial class Day24 {
	public override int Part2(in int[,] input) =>
		FindPathLength((0, 1), (input.GetLength(0) - 1, input.GetLength(1) - 2), input,
			FindPathLength((input.GetLength(0) - 1, input.GetLength(1) - 2), (0, 1), input,
				FindPathLength((0, 1), (input.GetLength(0) - 1, input.GetLength(1) - 2), input, 0)
			)
		);
}