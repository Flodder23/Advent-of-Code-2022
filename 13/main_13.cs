partial class Day13 : Day<(object[], object[])[], int, int> {
	public Day13(int day_ref_int) : base(day_ref_int) { }
	public Day13() : base(13) { }

	private static (bool, bool) Compare(in object left, in object right) {
		if (left is int) {
			if (right is int) {
				return ((int)left != (int)right, (int)left < (int)right);
			}
			else {
				return Compare(new object[] { left }, right);
			}
		}
		else {
			if (right is int) {
				return Compare(left, new object[] { right });
			}
			else {
				object[] l = (object[])left;
				object[] r = (object[])right;
				int i = 0;
				bool stop = false, ordered = false;
				while (i < l.Length && i < r.Length && !stop) {
					(stop, ordered) = Compare(l[i], r[i]);
					i++;
				}
				if (stop) {
					return (true, ordered);
				}
				else {
					return (l.Length != r.Length, l.Length <= r.Length);
				}
			}
		}
	}

	private static string Write(object item) {
		if (item is int) {
			return item.ToString();
		}
		string str = "[";
		foreach (object itm in (object[])item) {
			str += Write(itm) + ",";
		}
		return str + "]";
	}
}