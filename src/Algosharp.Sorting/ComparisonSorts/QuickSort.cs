using System;
using System.Collections.Generic;

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
		private static readonly Random Random = new Random();

		public static void Perform<T>(T[] array, Comparer<T> comparer = null)
		{
			var equalityComparer = comparer ?? Comparer<T>.Default;

			Sort(array, equalityComparer, 0, array.Length - 1);
		}

		private static void Sort<T>(T[] array, Comparer<T> comparer, int begin, int end)
		{
			if (begin >= end)
			{
				return;
			}

			var partitionIndex = Partition(array, comparer, begin, end);

			Sort(array, comparer, begin, partitionIndex - 1);
			Sort(array, comparer, partitionIndex + 1, end);
		}

		private static int Partition<T>(T[] array, Comparer<T> comparer, int begin, int end)
		{
			var pivotIndex = Random.Next(begin, end + 1);
			var pivot = array[pivotIndex];

			Swap(ref array[pivotIndex], ref array[end]);

			var index = begin;
			for (var j = begin; j < end; j++)
			{
				if (comparer.Compare(array[j], pivot) <= 0)
				{
					Swap(ref array[index], ref array[j]);
					index++;
				}
			}

			Swap(ref array[index], ref array[end]);
			return index;
		}

		private static void Swap<T>(ref T objectFirst, ref T objectSecond)
		{
			var temp = objectFirst;
			objectFirst = objectSecond;
			objectSecond = temp;
		}
	}
}
