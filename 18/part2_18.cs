partial class Day18 {
	public override int Part2(in (int, int, int)[] input) {
		int x_min = input[0].Item1, x_max = input[0].Item1,
			y_min = input[0].Item2, y_max = input[0].Item2,
			z_min = input[0].Item3, z_max = input[0].Item3;
		for (int i = 1; i < input.Count(); i++) {
			if (input[i].Item1 < x_min) {
				x_min = input[i].Item1;
			} else if (x_max < input[i].Item1) {
				x_max = input[i].Item1;
			}
			if (input[i].Item2 < y_min) {
				y_min = input[i].Item2;
			}
			else if (y_max < input[i].Item2) {
				y_max = input[i].Item2;
			}
			if (input[i].Item3 < z_min) {
				z_min = input[i].Item3;
			}
			else if (z_max < input[i].Item3) {
				z_max = input[i].Item3;
			}
		}
		(int, int, int) min = (x_min - 1, y_min - 1, z_min - 1);
		(int, int, int) max = (x_max + 1, y_max + 1, z_max + 1);
		HashSet<(int, int, int, int)> exposed_sides = GetExposedSides(input);

		HashSet<(int, int, int)> checked_coords = new(input) { min };
		HashSet<(int, int, int, int)> out_sides = new();
		HashSet<(int, int, int)> to_check = new() { min };
		while (to_check.Count > 0) {
			HashSet<(int, int, int)> to_check_next = new();
			foreach ((int, int, int) coord in to_check) {
				foreach ((int x_diff, int y_diff, int z_diff) in new (int, int, int)[] {
					( 1, 0, 0), (0,  1, 0), (0, 0,  1),
					(-1, 0, 0), (0, -1, 0), (0, 0, -1)
				}) {
					(int, int, int) new_coord = (
						coord.Item1 + x_diff,
						coord.Item2 + y_diff,
						coord.Item3 + z_diff
					);
					if (min.Item1 <= new_coord.Item1 && new_coord.Item1 <= max.Item1 &&
						min.Item2 <= new_coord.Item2 && new_coord.Item2 <= max.Item2 &&
						min.Item3 <= new_coord.Item3 && new_coord.Item3 <= max.Item3 &&
						checked_coords.Add(new_coord)
					) {
						to_check_next.Add(new_coord);
						foreach ((int, int, int, int) side in GetSides(new_coord)) {
							if (exposed_sides.Contains(side)) {
								out_sides.Add(side);
							}
						}
					}
				}
			}
			to_check = to_check_next;
		}
		return out_sides.Count;
	}
}