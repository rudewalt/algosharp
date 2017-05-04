using System.Collections.Generic;
using Algosharp.Common.Extensions;
using Algosharp.Common.Helpers;

namespace Algosharp.Sorting.ComparisonSorts
{
	/// <summary>
	/// <para>
	/// Time complexity.
	/// Best: O(n log(n))
	/// Average: O(n log(n))
	/// Worst: O(n^2)
	/// </para>
	/// 
	/// <para>
	/// Space complexity: O(log(n)) for call stack
	/// </para>
	/// 
	/// <see href="https://en.wikipedia.org/wiki/Quicksort"/>
	/// </summary>
	public static class QuickSort
	{
		public static void Perform<T>(IList<T> array, Comparer<T> comparer = null)
		{
			var equalityComparer = comparer ?? Comparer<T>.Default;

			Sort(array, equalityComparer, 0, array.Count - 1);
		}

		private static void Sort<T>(IList<T> array, IComparer<T> comparer, int begin, int end)
		{
			if (begin >= end)
			{
				return;
			}

			var partitionIndex = Partition(array, comparer, begin, end);

			Sort(array, comparer, begin, partitionIndex - 1);
			Sort(array, comparer, partitionIndex + 1, end);
		}

		private static int Partition<T>(IList<T> array, IComparer<T> comparer, int begin, int end)
		{
			var pivotIndex = ThreadSafeRandom.Next(begin, end + 1);
			var pivot = array[pivotIndex];

			array.Swap(pivotIndex, end);

			var index = begin;
			for (var j = begin; j < end; j++)
			{
				if (comparer.Compare(array[j], pivot) <= 0)
				{
					array.Swap(index, j);
					index++;
				}
			}

			array.Swap(index, end);
			return index;
		}
	}
}
