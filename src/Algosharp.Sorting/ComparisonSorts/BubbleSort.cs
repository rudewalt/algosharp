using System.Collections.Generic;
using Algosharp.Common.Extensions;

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
	/// <see href="https://en.wikipedia.org/wiki/Bubble_sort"/>
	/// </summary>
	public static class BubbleSort
	{
		public static void Perform<T>(IList<T> array, Comparer<T> comparer = null)
		{
			var equalityComparer = comparer ?? Comparer<T>.Default;

			var n = array.Count - 1;
			int lastSwap;
			do
			{
				lastSwap = 0;
				for (var j = 0; j < n; j++)
				{
					if (equalityComparer.Compare(array[j], array[j + 1]) <= 0)
					{
						continue;
					}

					array.Swap(j, j + 1);

					lastSwap = j;
				}

				n = lastSwap;
			} while (lastSwap != 0);
		}
	}
}
