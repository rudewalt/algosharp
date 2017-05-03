using Algosharp.Sorting.ComparisonSorts;
using Algosharp.Sorting.Tests.Helpers;
using Xunit;

namespace Algosharp.Sorting.Tests
{
    public class ComparisonSortsTests : SortTestsBase
    {
        [Theory]
        [MemberData(nameof(SortData))]
        public void TestBubbleSort(int[] input)
        {
            BubbleSort.Perform(input);

            AssertHelper.IsSorted(input);
        }

        [Theory]
        [MemberData(nameof(SortData))]
        public void TestInsertionSort(int[] input)
        {
            InsertionSort.Perform(input);

            AssertHelper.IsSorted(input);
        }

        [Theory]
        [MemberData(nameof(SortData))]
        public void TestMergeSortNatural(int[] input)
        {
            MergeSort.PerformNatural(input);

            AssertHelper.IsSorted(input);
        }

        [Theory]
        [MemberData(nameof(SortData))]
        public void TestMergeSortParallel(int[] input)
        {
            MergeSort.PerformParallel(input);

            AssertHelper.IsSorted(input);
        }

        [Theory]
        [MemberData(nameof(SortData))]
        public void TestMergeSortTopDown(int[] input)
        {
            MergeSort.PerformTopDown(input);

            AssertHelper.IsSorted(input);
        }

        [Theory]
        [MemberData(nameof(SortData))]
        public void TestSelectionSort(int[] input)
        {
            SelectionSort.Perform(input);

            AssertHelper.IsSorted(input);
        }

        [Theory]
        [MemberData(nameof(SortData))]
        public void TestQuickSort(int[] input)
        {
            QuickSort.Perform(input);

            AssertHelper.IsSorted(input);
        }
    }
}