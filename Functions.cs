class Functions {
	public static int GreatestCommonFactor(int a, int b) {
		while (b != 0) {
			(a, b) = (b, a % b);
		}
		return a;
	}
	public static int LeastCommonMultiple(int a, int b) {
		return (a * b) / GreatestCommonFactor(a, b);
	}
}