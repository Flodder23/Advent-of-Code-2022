abstract partial class Day {
	public int day_ref_int;
	public string day_ref_str;

	public Day(int day_ref_int, string? input_location = null) {
		this.day_ref_int = day_ref_int;
		day_ref_str = day_ref_int.ToString("D2");
		this.input_location = input_location ?? $"../../../{day_ref_str}/input_{day_ref_str}.txt";
	}

	public abstract void WriteSol1();
	public abstract void WriteSol2();
	public void WriteSols() {
		WriteSol1();
		WriteSol2();
	}
}