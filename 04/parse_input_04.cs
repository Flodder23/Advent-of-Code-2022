using System.Text.RegularExpressions;

partial class Day04 {
	public override ((int, int), (int, int))[] ParseInput(string? raw_input = null) =>
		(raw_input ?? GetRawInput()).Split(Environment.NewLine).Select( s => {
				var nums = Regex.Match(s, @"(\d+)-(\d+),(\d+)-(\d+)").Groups;
				return ((int.Parse(nums[1].Value), int.Parse(nums[2].Value)), (int.Parse(nums[3].Value), int.Parse(nums[4].Value)));
		}).ToArray();
}