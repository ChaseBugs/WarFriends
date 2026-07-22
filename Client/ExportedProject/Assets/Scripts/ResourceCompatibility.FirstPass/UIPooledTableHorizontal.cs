using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPooledTableHorizontal : MonoBehaviour
{
	public delegate float PooledSize(int index);

	public int padding;

	public Transform leftHelperSprite;

	public Transform rightHelperSprite;

	public int containItems;

	private List<Transform> mItems;

	private List<float> mSizes;

	private UIDraggablePanel mDragPanel;

	private UIPooledGrid.PooledTransform getTransform;

	private Action<Transform> makeFree;

	private PooledSize getSize;

	public void Init(int count, UIPooledGrid.PooledTransform getter, Action<Transform> free, PooledSize sizeGetter, UIDraggablePanel dragPanel)
	{
	}

	public List<T> GetShown<T>() where T : MonoBehaviour
	{
		return null;
	}

	public void MakeEmpty()
	{
	}

	public void PositionChanged()
	{
	}

	private void OnEnable()
	{
	}
}
