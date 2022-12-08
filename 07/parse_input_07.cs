partial class Day07 {
	public override FileSystem ParseInput(string? raw_input = null) {
		string[] input = (raw_input ?? GetRawInput()).Split(Environment.NewLine);
		FileSystem filesystem = new();

		foreach (string line in input) {
			string[] parts = line.Split(' ');
			if (parts[0] == "$") {
				if (parts[1] == "cd") {
					filesystem.Move(parts[2]);
				}
			} else {
				if (parts[0] == "dir") {
					filesystem.Add(parts[1], false);
				} else {
					filesystem.Add(parts[1], int.Parse(parts[0]), false);
				}
			}
		}

		filesystem.self.UpdateSize(true, false);

		return filesystem;
	}
}