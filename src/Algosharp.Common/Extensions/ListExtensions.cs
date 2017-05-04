using System.Collections.Generic;

namespace Algosharp.Common.Extensions
{
	public static class ListExtensions
	{
		public static void Swap<T>(this IList<T> array, int firstIndex, int secondIndex)
		{
			var temp = array[firstIndex];
			array[firstIndex] = array[secondIndex];
			array[secondIndex] = temp;
		}
	}
}
