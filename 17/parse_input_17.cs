﻿partial class Day17 {
	public override bool[] ParseInput(string? raw_input = null) => 
		(raw_input ?? GetRawInput()).ToCharArray().Select(ch => ch == '>').ToArray();
}