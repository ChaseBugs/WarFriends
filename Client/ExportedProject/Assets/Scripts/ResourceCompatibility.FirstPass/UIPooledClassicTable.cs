using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPooledClassicTable : MonoBehaviour
{
	public delegate Transform PooledTransform(int index);

	public delegate float PooledSize(int index);

	public int padding;

	public Transform topHelperSprite;

	public Transform downHelperSprite;

	public float topBreakPoint;

	public float bottomBreakPoint;

	public int containItems;

	private List<Transform> mItems;

	private List<float> mSizes;

	private UIDraggablePanel mDragPanel;

	private PooledTransform getTransform;

	private Action<Transform> makeFree;

	private PooledSize getSize;

	public void Initialize(int count, PooledTransform getter, Action<Transform> free, PooledSize sizeGetter, UIDraggablePanel dragPanel)
	{
	}

	public void MakeEmpty()
	{
	}

	public void PositionChanged()
	{
	}

	private void FreeNotUsedItems()
	{
	}

	private void FirstReposition(float bottomLimit, float topLimit)
	{
	}

	private void OnEnable()
	{
	}

	public Transform GetItemOnIndex(int index)
	{
		return null;
	}

	public Vector3 GetPositionForIndex(int index)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}
}
