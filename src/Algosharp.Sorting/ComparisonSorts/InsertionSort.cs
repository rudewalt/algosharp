using System.Collections.Generic;

namespace Algosharp.Sorting.ComparisonSorts
{
	/// <summary>
	/// <para>
	/// Time complexity.
	/// Best: O(n)
	/// Average: O(n^2)
	/// Worst: O(n^2) 
	/// </para>
	/// 
	/// <para>
	/// Space complexity: O(1)
	/// </para>
	/// 
	/// <see href="https://en.wikipedia.org/wiki/Insertion_sort"/>
	/// </summary>
	public static class InsertionSort
	{
		public static void Perform<T>(IList<T> array, Comparer<T> comparer = null)
		{
			var equalityComparer = comparer ?? Comparer<T>.Default;
			for (var i = 1; i < array.Count; i++)
			{
				var index = i;
				var temp = array[index];
				while (index > 0 && equalityComparer.Compare(array[index - 1], temp) > 0)
				{
					array[index] = array[index - 1];
					index--;
				}

				array[index] = temp;
			}
		}
	}
}
