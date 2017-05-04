using System.Collections.Generic;
using Algosharp.Common.Extensions;

namespace Algosharp.Sorting.ComparisonSorts
{
	/// <summary>
	/// <para>
	/// Time complexity.
	/// Best: O(n^2)
	/// Average: O(n^2)
	/// Worst: O(n^2) 
	/// </para>
	/// 
	/// <para>
	/// Space complexity: O(1)
	/// </para>
	/// 
	/// <see href="https://en.wikipedia.org/wiki/Selection_sort"/>
	/// </summary>
	public static class SelectionSort
	{
		public static void Perform<T>(IList<T> array, Comparer<T> comparer = null)
		{
			var equalityComparer = comparer ?? Comparer<T>.Default;

			for (var i = 0; i < array.Count - 1; i++)
			{
				var min = i;
				for (var j = i + 1; j < array.Count; j++)
				{
					if (equalityComparer.Compare(array[min], array[j]) > 0)
						min = j;
				}

				if (min == i)
				{
					continue;
				}

				array.Swap(i, min);
			}
		}
	}
}
