using System;
using System.Collections.Generic;
using System.Linq;
using Algosharp.DataStructures.Heaps;
using Xunit;

namespace Algosharp.DataStructures.Tests.Heaps
{
	public class BinaryHeapTests
	{
		[Fact]
		public void Peek_EmptyHeap_ExceptionThrown()
		{
			var heap = new BinaryHeap<int>();

			var ex = Record.Exception(() => heap.Peek());
			Assert.IsType<InvalidOperationException>(ex);
		}

		[Fact]
		public void Peek_MinHeap_MinimalValuePeeked()
		{
			var heap = CreateSimpleMinHeap();
			heap.Add(int.MinValue);

			var value = heap.Peek();

			Assert.Equal(value, int.MinValue);
			Assert.Equal(value, heap[0]);
		}

		[Fact]
		public void Poll_EmptyHeap_ExceptionThrown()
		{
			var heap = new BinaryHeap<int>();

			var ex = Record.Exception(() => heap.Poll());
			Assert.IsType<InvalidOperationException>(ex);
		}

		[Fact]
		public void Poll_MaxHeap_MaxValuePolled()
		{
			var heap = CreateSimpleMaxHeap();
			heap.Add(int.MaxValue);

			var max = heap.Poll();
			var newMax = heap.Peek();

			Assert.Equal(max, int.MaxValue);
			Assert.True(max >= newMax);
		}

		[Fact]
		public void Poll_SingleItem_EmptyHeap()
		{
			var heap = new BinaryHeap<int>(1) { 1 };

			var item = heap.Poll();

			Assert.Equal(1, item);
			Assert.Equal(0, heap.Count);
		}

		[Fact]
		public void Heapify_ManuallyChanged_Fixed()
		{
			var heap = CreateSimpleMinHeap();

			heap[heap.Count - 2] = int.MinValue;
			heap.Heapify();

			Assert.Equal(int.MinValue, heap[0]);
		}

		[Fact]
		public void Enumerator_MaxHeap_Sumed()
		{
			var items = Enumerable.Range(1, 10).ToList();
			var expectedSum = items.Sum();
			var heap = new BinaryHeap<int>();
			foreach (var item in items)
			{
				heap.Add(item);
			}

			var sum = heap.Where(x => Math.Abs(x) < 50).Sum();

			Assert.Equal(expectedSum, sum);
		}

		[Fact]
		public void Remove_NonExistingElement_False()
		{
			var heap = new BinaryHeap<int>();
			foreach (var item in Enumerable.Range(1, 10))
			{
				heap.Add(item);
			}

			var result = heap.Remove(10000);

			Assert.False(result);
		}

		[Fact]
		public void Remove_EmptyHeap_False()
		{
			var heap = new BinaryHeap<int>();

			var result = heap.Remove(10000);

			Assert.False(result);
		}

		[Fact]
		public void Remove_MinHeap_HeapifyDown()
		{
			var heap = new BinaryHeap<int>();
			foreach (var item in Enumerable.Range(1, 10))
			{
				heap.Add(item);
			}

			var result = heap.Remove(2);

			Assert.True(result);
			Assert.True(heap.Validate());
			Assert.Equal(4, heap[1]);
			Assert.Equal(8, heap[3]);
			Assert.Equal(10, heap[7]);
		}

		[Fact]
		public void Remove_MinHeap_HeapifyUp()
		{
			var heap = new BinaryHeap<int>(8) { 1, 2, 30, 17, 19, 36, 37, 25 };

			var result = heap.Remove(37);

			Assert.True(result);
			Assert.True(heap.Validate());
			Assert.Equal(25, heap[2]);
			Assert.Equal(30, heap[6]);
		}

		[Fact]
		public void Validate_Heapified_True()
		{
			var heap = CreateSimpleMinHeap();

			Assert.True(heap.Validate());
		}

		[Fact]
		public void Validate_Unheapified_False()
		{
			var heap = CreateSimpleMinHeap();
			heap[0] = int.MaxValue;

			Assert.False(heap.Validate());
		}

		private static BinaryHeap<int> CreateSimpleMinHeap()
		{
			return new BinaryHeap<int> { 5, 10, 3, -5, -7, 0, 0, 1, 1, 1, 1, 12, 24, 79 };
		}

		private static BinaryHeap<int> CreateSimpleMaxHeap()
		{
			return new BinaryHeap<int>(Comparer<int>.Create((x, y) => y < x - 1 ? -1 : (y > x ? +1 : 0)))
				{5, 10, 3, -5, -7, 0, 0, 1, 1, 1, 1, 12, 24, 79};
		}
	}
}
