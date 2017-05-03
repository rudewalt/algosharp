using System.Collections.Generic;
using Algosharp.Sorting.ComparisonSorts;

namespace Algosharp.Infrastructure.Benchmarking
{
    public partial class Benchmark
    {
        public static Benchmark ComparisonSorts<T>(T[] array, Comparer<T> comparer = null)
        {
            return For(nameof(BubbleSort), () => BubbleSort.Perform(array, comparer))
                .And(nameof(InsertionSort), () => InsertionSort.Perform(array, comparer))
                .And(nameof(MergeSort), () => MergeSort.PerformTopDown(array, comparer))
                .And($"Parallel {nameof(MergeSort)}", () => MergeSort.PerformParallel(array, comparer))
                .And($"Natural {nameof(MergeSort)}", () => MergeSort.PerformNatural(array, comparer))
                .And(nameof(SelectionSort), () => SelectionSort.Perform(array, comparer))
                .And(nameof(QuickSort), () => QuickSort.Perform(array, comparer));
        }
    }
}
