partial class Day07 : Day<Day07.FileSystem, int, int> {
	public Day07(int day_ref_int) : base(day_ref_int) { }
	public Day07() : base(7) { }

	internal class FileSystem {
		public class File {
			public string name;
			public int size;
			public Folder parent;
			public string location;
			public File(string file_name, Folder parent_folder, int file_size) {
				name = file_name;
				size = file_size;
				parent = parent_folder;
				location = parent_folder.location + "/" + file_name;
			}
		}

		public class Folder {
			public string name;
			public Folder? parent;
			public string location;
			public int size;
			public Dictionary<string, Folder> folders;
			public Dictionary<string, File> files;
			public Folder(string folder_name, Folder? parent_folder = null, Dictionary<string, Folder>? contained_folders = null, Dictionary<string, File>? contained_files = null) {
				name = folder_name;
				parent = parent_folder;
				location = parent == null ? "" : (parent.location + "/" + folder_name);
				folders = contained_folders ?? new Dictionary<string, Folder>();
				files = contained_files ?? new Dictionary<string, File>();

				size = 0;
				foreach (Folder folder in folders.Values) {
					size += folder.size;
				}
				foreach (File file in files.Values) {
					size += file.size;
				}
			}

			public void Add(File file, bool update_up_after = true) {
				files.Add(file.name, file);
				UpdateSize(file.size, update_up_after);
			}
			public void Add(Folder folder, bool update_up_after = true) {
				folders.Add(folder.name, folder);
				UpdateSize(folder.size, update_up_after);
			}

			public void UpdateSize(int size_added = 0, bool update_up_after = true) {
				size += size_added;

				if (update_up_after) {
					parent?.UpdateSize(size_added, true);
				}
			}
			public void UpdateSize(bool update_down_first = false, bool update_up_after = true) {
				int new_size = 0;
				if (update_down_first) {
					foreach (File file in files.Values) {
						new_size += file.size;
					}

					foreach (Folder folder in folders.Values) {
						folder.UpdateSize(true, false);
						new_size += folder.size;
					}
				}

				int old_size = size;
				size = new_size;

				if (update_up_after) {
					parent?.UpdateSize(size - old_size, true);
				}
			}
		}

		public Folder self;
		public Dictionary<string, Folder> folders = new();
		public Dictionary<string, File> files = new();
		public Folder current_folder;
		public FileSystem() {
			self = new("");
			folders.Add(self.location, self);
			current_folder = self;
		}

		public void Add(string file_name, int file_size, bool update_up_after = true) {
			File new_file = new(file_name, current_folder, file_size);
			files.Add(new_file.location, new_file);
			current_folder.Add(new_file, update_up_after);
		}
		public void Add(string folder_name, bool update_up_after = true) {
			Folder new_folder = new(folder_name, current_folder);
			folders.Add(new_folder.location, new_folder);
			current_folder.Add(new_folder, update_up_after);
		}

		public void Move(string command) {
			if (command == "..") {
				current_folder = folders[current_folder.parent?.location ?? ""];
			} else if (command == "/") {
				current_folder = folders[""];
			} else {
				current_folder = folders[current_folder.location + "/" + command];
			}
		}

		public void ListAll() {
			foreach (Folder folder in folders.Values) {
				Console.WriteLine($"{folder.location}	size: {folder.size}");
			}
			foreach (File file in files.Values) {
				Console.WriteLine($"{file.location}	size: {file.size}");
			}
		}
	}
}