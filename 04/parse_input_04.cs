using System.Text.RegularExpressions;

partial class Day04 {
	public override ((int, int), (int, int))[] ParseInput(string? raw_input = null) {
		string[] input = (raw_input ?? GetRawInput()).Split(Environment.NewLine);

		var output = new ((int, int), (int, int))[input.Length];
		for (int i = 0; i < output.Length; i++) {
			var nums = Regex.Match(input[i], @"(\d+)-(\d+),(\d+)-(\d+)").Groups;
			output[i] = ((int.Parse(nums[1].Value), int.Parse(nums[2].Value)), (int.Parse(nums[3].Value), int.Parse(nums[4].Value)));
		}

		return output;
	}

}