using System;
using System.Collections;
using System.Collections.Generic;
using Algosharp.Common.Extensions;

namespace Algosharp.DataStructures.Heaps
{
	/// <summary>
	/// <para>A binary heap is a complete binary tree which satisfies the heap ordering property. The ordering can be one of two types:</para>
	/// <para>- the min-heap property: the value of each node is greater than or equal to the value of its parent, with the minimum-value element at the root.</para>
	/// <para>- the max-heap property: the value of each node is less than or equal to the value of its parent, with the maximum-value element at the root.</para>
	///  </summary>
	/// <typeparam name="T">The type of elements in the heap</typeparam>
	public class BinaryHeap<T> : IEnumerable<T>
	{
		private readonly List<T> _items;
		private readonly IComparer<T> _comparer;

		/// <summary>
		/// Gets the total number of elements the internal data structure can hold without resizing
		/// </summary>
		public int Capacity => _items.Capacity;

		/// <summary>
		/// Gets the number of elements contained
		/// </summary>
		public int Count => _items.Count;

		/// <summary>
		/// <para>
		/// Gets or sets the element at the specified index
		/// </para>
		/// <para>
		/// This method doesn't maintain the heap constraints
		/// </para>
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set</param>
		/// <returns></returns>
		public T this[int index]
		{
			get { return _items[index]; }
			set { _items[index] = value; }
		}

		/// <summary>
		/// <para>Initializes a new instance of the binary heap that is empty and has the default initial capacity</para>
		/// <para>By default it is a min-heap. To make it a max-heap invert the comparer logic</para>
		/// </summary>
		/// <param name="comparer">Comparer used to compare elements</param>
		public BinaryHeap(Comparer<T> comparer = null)
		{
			_items = new List<T>();
			_comparer = comparer ?? Comparer<T>.Default;
		}

		/// <summary>
		/// <para>Initializes a new instance of the binary heap that is empty and has the specified initial capacity</para>
		/// <para>By default it is a min-heap. To make it a max-heap invert the comparer logic</para>
		/// </summary>
		/// <param name="capacity">The number of elements that the new heap can initially store</param>
		/// <param name="comparer">Comparer used to compare elements</param>
		public BinaryHeap(int capacity, Comparer<T> comparer = null)
		{
			_items = new List<T>(capacity);
			_comparer = comparer ?? Comparer<T>.Default;
		}

		/// <summary>
		/// <para>Adds an object to the heap</para>
		/// <para>Time complexity: O(log (n))</para> 
		/// </summary>
		/// <param name="item">The object to be added to the heap. The value can be null for reference types.</param>
		public void Add(T item)
		{
			var index = _items.Count;
			_items.Add(item);
			HeapifyUp(index);
		}

		/// <summary>
		/// <para>Peeks an object on top of the heap</para>
		/// <para>Time complexity: O(1)</para>
		/// </summary>
		/// <returns>The minimal object for the min-heap (The maximum object for the max-heap)</returns>
		public T Peek()
		{
			if (_items.Count < 1) throw new InvalidOperationException("No items in the heap");

			return _items[0];
		}

		/// <summary>
		/// <para>Removes the object on top of the heap and maintains the heap constraints</para>
		/// <para>Time complaxity: Θ(log(n))</para>
		/// </summary>
		/// <returns>The minimal object for the min-heap (The maximum object for the max-heap)</returns>
		public T Poll()
		{
			if (_items.Count < 1) throw new InvalidOperationException("No items in the heap");

			var result = _items[0];
			if (_items.Count == 1)
			{
				_items.RemoveAt(0);
			}
			else
			{
				var last = _items.Count - 1;
				_items[0] = _items[last];
				_items.RemoveAt(last);
				HeapifyDown(0);
			}

			return result;
		}

		/// <summary>
		/// <para>Removes specified object from the heap and maintains the heap constraints</para>
		/// <para>Time complexity: Θ(log(n))</para>
		/// </summary>
		/// <param name="item">The object to remove from the heap</param>
		/// <returns>true if operation was successful, otherwise false</returns>
		public bool Remove(T item)
		{
			var i = _items.IndexOf(item);
			if (i < 0)
			{
				return false;
			}

			var last = _items.Count - 1;
			_items[i] = _items[last];
			_items.RemoveAt(last);

			var parent = _items[GetParentIndex(i)];
			if (_comparer.Compare(parent, _items[i]) > 0)
			{
				HeapifyUp(i);
			}
			else
			{
				HeapifyDown(i);
			}

			return true;
		}

		/// <summary>
		/// <para>Maintains the heap constraints</para>
		/// <para>Time complexity: Θ(n)</para> 
		/// </summary>
		public void Heapify()
		{
			for (var i = _items.Count - 1; i > 0; i--)
			{
				var parentPosition = GetParentIndex(i);
				if (_comparer.Compare(_items[parentPosition], _items[i]) > 0)
				{
					_items.Swap(i, parentPosition);
				}
			}
		}

		/// <summary>
		/// <para>Validates the heap</para>
		/// <para>Time complexity: Θ(n)</para> 
		/// </summary>
		/// <returns></returns>
		public bool Validate()
		{
			for (var i = _items.Count - 1; i > 0; i--)
			{
				var parentPosition = GetParentIndex(i);
				if (_comparer.Compare(_items[parentPosition], _items[i]) > 0)
				{
					return false;
				}
			}

			return true;
		}

		private static int GetParentIndex(int index) => (index - 1) / 2;
		private static int GetLeftChildIndex(int index) => 2 * index + 1;
		private static int GetRightChildIndex(int index) => 2 * index + 2;

		private void HeapifyUp(int index)
		{
			while (true)
			{
				var parentIndex = GetParentIndex(index);
				if (parentIndex < 0 || _comparer.Compare(_items[parentIndex], _items[index]) <= 0)
				{
					break;
				}

				_items.Swap(index, parentIndex);
				index = parentIndex;
			}
		}

		private void HeapifyDown(int index)
		{
			while (true)
			{
				var smallest = index;

				var left = GetLeftChildIndex(index);
				var right = GetRightChildIndex(index);

				if (left < _items.Count && _comparer.Compare(_items[left], _items[index]) < 0)
				{
					smallest = left;
				}

				if (right < _items.Count && _comparer.Compare(_items[right], _items[smallest]) < 0)
				{
					smallest = right;
				}

				if (smallest == index)
				{
					break;
				}

				_items.Swap(index, smallest);
				index = smallest;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
