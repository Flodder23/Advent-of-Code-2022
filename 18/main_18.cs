partial class Day18 : Day<(int, int, int)[], int, int> {
	public Day18(int day_ref_int) : base(day_ref_int) { }
	public Day18() : base(18) { }

	public static (int, int, int, int) ToCanon ((int, int, int, int) side) => (
		side.Item1 + (side.Item4 == 3 ? 1 : 0),
		side.Item2 + (side.Item4 == 4 ? 1 : 0),
		side.Item3 + (side.Item4 == 5 ? 1 : 0),
		side.Item4 - (side.Item4 < 3 ? 0 : 3)
	);

	private static HashSet<(int, int, int, int)> GetExposedSides((int, int, int)[] coords) {
		HashSet<(int, int, int, int)> exposed_sides = new();
		foreach ((int, int, int) coord in coords) {
			foreach ((int, int, int, int) side in GetSides(coord)) {
				if (!exposed_sides.Add(side)) {
					exposed_sides.Remove(side);
				}
			}
		}

		return exposed_sides;
	}
	private static IEnumerable<(int, int, int, int)> GetSides((int, int, int) coord) {
		for (int side_no = 0; side_no < 6; side_no++) {
			yield return ToCanon((coord.Item1, coord.Item2, coord.Item3, side_no));
		}
	}
}