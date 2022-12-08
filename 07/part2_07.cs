partial class Day07 {
	public override int Part2(in FileSystem input) {
		int space_needed = input.self.size - 40000000; // 30000000 - (70000000 + input.self.size)
		int min_size = input.self.size;

		foreach (FileSystem.Folder folder in input.folders.Values) {
			if (folder.size > space_needed && folder.size < min_size) {
				min_size = folder.size;
			}
		}

		return min_size;
	}
}