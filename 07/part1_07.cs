partial class Day07 {
	public override int Part1(in FileSystem input) {
		int sum = 0;
		foreach(FileSystem.Folder folder in input.folders.Values) {
			if (folder.size <= 100000) {
				sum += folder.size;
			}
		}
		return sum;
	}
}