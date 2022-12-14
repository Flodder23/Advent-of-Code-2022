abstract partial class Day {
	protected string input_location;
	public void SetInputLocation(string input_location) {
		this.input_location = input_location;
	}
	public string GetInputLocation() => input_location;

	protected string? raw_input;
	protected string? raw_input_location;
	public string FetchRawInput() {
		return File.ReadAllText(input_location).TrimEnd();
	}
	public void SetRawInput() {
		if (raw_input == null || raw_input_location != input_location) {
			raw_input = FetchRawInput();
			raw_input_location = input_location;
		}
	}
	public string GetRawInput(bool set_if_needed = true) {
		if (set_if_needed) {
			SetRawInput();
		}
		return raw_input;
	}
	public string GetRawInputLocation() => raw_input_location;

	public abstract void SetParsedInput(bool force = false);
}