using System.Text.RegularExpressions;

partial class Day15 {
	public override ((int, int), (int, int))[] ParseInput(string? raw_input = null) {
		return (raw_input ?? GetRawInput()).Split(Environment.NewLine)
			.Select(line => Regex.Match(line, @"Sensor at x=(-?\d+), y=(-?\d+): closest beacon is at x=(-?\d+), y=(-?\d+)"))
			.Select(line => (
				(int.Parse(line.Groups[1].Value), int.Parse(line.Groups[2].Value)),
				(int.Parse(line.Groups[3].Value), int.Parse(line.Groups[4].Value))
			)).ToArray();
	}
}