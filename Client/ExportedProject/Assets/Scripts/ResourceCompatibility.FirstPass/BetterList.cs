using System;
using System.Collections.Generic;

public class BetterList<T>
{
	public T[] buffer;

	public int size;

	public T Item
	{
		get
		{
			return default(T);
		}
		set
		{
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		return null;
	}

	private void AllocateMore()
	{
	}

	public void Trim()
	{
	}

	public void TrimTo128()
	{
	}

	public void Clear()
	{
	}

	public void Release()
	{
	}

	public void Add(T item)
	{
	}

	public void Insert(int index, T item)
	{
	}

	public bool Contains(T item)
	{
		return false;
	}

	public bool Remove(T item)
	{
		return false;
	}

	public void RemoveAt(int index)
	{
	}

	public T Pop()
	{
		return default(T);
	}

	public T[] ToArray()
	{
		return null;
	}

	public void Sort(Comparison<T> comparer)
	{
	}
}
