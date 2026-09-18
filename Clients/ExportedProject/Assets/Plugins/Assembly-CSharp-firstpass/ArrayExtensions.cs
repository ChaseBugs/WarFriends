using System;
using System.Collections.Generic;

public static class ArrayExtensions
{
	private sealed class StabilizingComparer<T> : IComparer<KeyValuePair<int, T>>
	{
		private readonly Comparison<T> _comparison;

		public StabilizingComparer(Comparison<T> comparison)
		{
			_comparison = comparison;
		}

		public int Compare(KeyValuePair<int, T> x, KeyValuePair<int, T> y)
		{
			int num = _comparison(x.Value, y.Value);
			return (num == 0) ? x.Key.CompareTo(y.Key) : num;
		}
	}

	public static void StableSort<T>(this T[] values, Comparison<T> comparison)
	{
		KeyValuePair<int, T>[] array = new KeyValuePair<int, T>[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			ref KeyValuePair<int, T> reference = ref array[i];
			reference = new KeyValuePair<int, T>(i, values[i]);
		}
		Array.Sort(array, values, new StabilizingComparer<T>(comparison));
	}

	public static void StableSort<T>(this List<T> values, Comparison<T> comparison)
	{
		KeyValuePair<int, T>[] array = new KeyValuePair<int, T>[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			ref KeyValuePair<int, T> reference = ref array[i];
			reference = new KeyValuePair<int, T>(i, values[i]);
		}
		T[] array2 = values.ToArray();
		Array.Sort(array, array2, new StabilizingComparer<T>(comparison));
		values.Clear();
		values.AddRange(array2);
	}
}
