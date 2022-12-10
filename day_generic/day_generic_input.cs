abstract partial class Day<InputType, Sol1Type, Sol2Type> : Day {
	private InputType? parsed_input;
	private string? parsed_input_location;

	public abstract InputType ParseInput(string? raw_input = null);
	public override void SetParsedInput(bool force = false) {
		GetRawInput();
		if (force || parsed_input_location != input_location) {
			parsed_input = ParseInput(raw_input);
			parsed_input_location = raw_input_location;
		}
	}
	public InputType GetParsedInput(bool set_if_needed = true) {
		if (set_if_needed) {
			SetParsedInput();
		}
		return parsed_input;
	}
}