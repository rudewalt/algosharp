using System.Collections.Generic;
using System.Threading.Tasks;

namespace Algosharp.Sorting.ComparisonSorts
{
	/// <summary>
	/// <para>
	/// Time complexity.
	/// Best: O(n log(n)) typical, O(n) natural variant
	/// Average: O(n log(n))
	/// Worst: O(n log(n)) 
	/// </para>
	/// 
	/// <para>
	/// Space complexity: O(n)
	/// </para>
	/// 
	/// <see href="https://en.wikipedia.org/wiki/Merge_sort"/>
	/// </summary>
	public static class MergeSort
	{
		/// <summary>
		/// <para>
		/// Best time complexity: O(n) 
		/// </para>
		/// 
		/// <see cref="MergeSort"/>
		/// </summary>
		public static void PerformNatural<T>(IList<T> array, Comparer<T> comparer = null)
		{
			var equalityComparer = comparer ?? Comparer<T>.Default;
			var temp = new T[array.Count];

			var end = array.Count - 1;
			bool sorted;

			do
			{
				sorted = true;
				var begin = 0;

				while (begin < end)
				{
					var left = begin;
					while (left < end && equalityComparer.Compare(array[left], array[left + 1]) <= 0)
					{
						left++;
					}

					var right = left + 1;
					while (right == end - 1 || right < end && equalityComparer.Compare(array[right], array[right + 1]) <= 0)
					{
						right++;
					}

					if (right <= end)
					{
						Merge(array, begin, left, right, equalityComparer, temp);
						sorted = false;
					}

					begin = right + 1;
				}

			} while (!sorted);
		}

		/// <summary> 
		/// <para>
		/// Best time complexity: O(n log(n)) 
		/// </para>
		/// 
		/// <see cref="MergeSort"/>
		/// </summary>
		public static void PerformParallel<T>(IList<T> array, Comparer<T> comparer = null)
		{
			var equalityComparer = comparer ?? Comparer<T>.Default;
			SplitParallel(array, 0, array.Count - 1, equalityComparer, new T[array.Count]);
		}

		/// <summary>
		/// <para>
		/// Best time complexity: O(n log(n)) 
		/// </para>
		/// 
		/// <see cref="MergeSort"/>
		/// </summary>
		public static void PerformTopDown<T>(IList<T> array, Comparer<T> comparer = null)
		{
			var equalityComparer = comparer ?? Comparer<T>.Default;
			Split(array, 0, array.Count - 1, equalityComparer, new T[array.Count]);
		}

		private static void Split<T>(IList<T> array, int begin, int end, IComparer<T> comparer, IList<T> temp)
		{
			if (end - begin < 1)
			{
				return;
			}

			var middle = (begin + end) / 2;
			Split(array, begin, middle, comparer, temp);
			Split(array, middle + 1, end, comparer, temp);

			Merge(array, begin, middle, end, comparer, temp);
		}

		private static void SplitParallel<T>(IList<T> array, int begin, int end, IComparer<T> comparer, IList<T> temp)
		{
			if (end - begin < 1)
			{
				return;
			}

			var middle = (begin + end) / 2;
			Parallel.Invoke(
				() => Split(array, begin, middle, comparer, temp),
				() => Split(array, middle + 1, end, comparer, temp));

			Merge(array, begin, middle, end, comparer, temp);
		}

		private static void Merge<T>(IList<T> array, int begin, int middle, int end, IComparer<T> comparer, IList<T> temp)
		{
			var leftHead = begin;
			var rightHead = middle + 1;

			for (var i = begin; i <= end; i++)
			{
				if (leftHead <= middle && (rightHead > end || comparer.Compare(array[leftHead], array[rightHead]) <= 0))
				{
					temp[i] = array[leftHead];
					leftHead++;
				}
				else
				{
					temp[i] = array[rightHead];
					rightHead++;
				}
			}

			for (var i = begin; i <= end; i++)
			{
				array[i] = temp[i];
			}
		}
	}
}
