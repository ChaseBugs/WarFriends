using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPooledTableSimplified : MonoBehaviour
{
	public delegate float PooledSize(int index, Transform trans);

	public int padding;

	public float defaultSize = 116f;

	public Transform topHelperSprite;

	public Transform downHelperSprite;

	public int containItems;

	private List<Transform> items = new List<Transform>();

	private List<float> sizes = new List<float>();

	private UIDraggablePanel mDragPanel;

	private UIPooledGrid.PooledTransform getTransform;

	private Action<Transform> makeFree;

	private PooledSize getSize;

	public void Init(int count, UIPooledGrid.PooledTransform getter, Action<Transform> free, PooledSize sizeGetter, UIDraggablePanel dragPanel)
	{
		getTransform = getter;
		makeFree = free;
		getSize = sizeGetter;
		mDragPanel = dragPanel;
		mDragPanel.onMovePerformed = PositionChanged;
		containItems = count;
		for (int i = items.Count; i < containItems; i++)
		{
			items.Add(null);
			sizes.Add(0f);
		}
		if (base.gameObject.activeInHierarchy)
		{
			PositionChanged();
		}
	}

	public void MakeEmpty()
	{
		for (int i = 0; i < containItems && i < items.Count; i++)
		{
			if (items[i] != null)
			{
				if (makeFree != null)
				{
					makeFree(items[i]);
				}
				items[i] = null;
			}
			sizes[i] = 0f;
		}
		if (mDragPanel != null)
		{
			UIDraggablePanel uIDraggablePanel = mDragPanel;
			uIDraggablePanel.onMovePerformed = (Action)Delegate.Remove(uIDraggablePanel.onMovePerformed, new Action(PositionChanged));
		}
		getTransform = null;
		makeFree = null;
		items.Clear();
		sizes.Clear();
	}

	private void PositionChanged()
	{
		if (makeFree == null || getTransform == null || getSize == null)
		{
			Debug.LogError("some delegates for pooling missing for: " + base.name);
			return;
		}
		Vector4 clipRange = mDragPanel.panel.clipRange;
		float num = clipRange.y - clipRange.w / 2f - base.transform.localPosition.y;
		float num2 = num + clipRange.w;
		topHelperSprite.localPosition = topHelperSprite.localPosition.ReplaceY((0f - topHelperSprite.localScale.y) * 0.5f);
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < containItems && i < items.Count; i++)
		{
			if (sizes[i] == 0f)
			{
				sizes[i] = getSize(i, items[i]);
			}
			if ((!(zero.y - sizes[i] - (float)padding <= num2 + 15f) || !(zero.y >= num - 15f)) && items[i] != null)
			{
				makeFree(items[i]);
				items[i] = null;
			}
			zero.y -= sizes[i] + (float)padding;
		}
		zero = Vector3.zero;
		for (int j = 0; j < containItems && j < items.Count; j++)
		{
			if (zero.y - sizes[j] - (float)padding <= num2 + 15f && zero.y >= num - 15f && items[j] == null)
			{
				items[j] = getTransform(j);
				items[j].localPosition = zero;
			}
			zero.y -= sizes[j] + (float)padding;
		}
		downHelperSprite.localPosition = downHelperSprite.localPosition.ReplaceY(zero.y + downHelperSprite.localScale.y * 0.5f);
	}

	private void OnEnable()
	{
		if (makeFree != null && getTransform != null && getSize != null && mDragPanel != null)
		{
			PositionChanged();
		}
	}

	public Transform GetItemOnIndex(int index)
	{
		if (index < 0 || index >= containItems || index >= items.Count)
		{
			return null;
		}
		return items[index];
	}
}
