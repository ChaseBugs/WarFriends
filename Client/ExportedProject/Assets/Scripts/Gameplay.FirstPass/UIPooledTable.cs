using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPooledTable : MonoBehaviour
{
	public delegate float PooledSize(int index, Transform trans);

	public int padding;

	public float defaultSize = 116f;

	public bool useDefaultSize;

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

	public void IncreaseContainItems(int byNum, bool align = true)
	{
		int num = containItems - 1;
		Transform transform = null;
		if (containItems > 0)
		{
			transform = items[num];
		}
		containItems += byNum;
		for (int i = items.Count; i < containItems; i++)
		{
			items.Add(null);
			sizes.Add(0f);
		}
		if (transform != null)
		{
			Vector3 localPosition = transform.localPosition;
			for (int j = num + 1; j < containItems; j++)
			{
				if (sizes[j] == 0f)
				{
					sizes[j] = getSize(j, null);
				}
				localPosition.y += (float)padding + sizes[j];
			}
			localPosition.y += topHelperSprite.localScale.y * 0.5f;
			topHelperSprite.localPosition = localPosition;
			if (align && mDragPanel != null)
			{
				mDragPanel.AlignToPos(instant: false);
			}
		}
		if (num < 0)
		{
			PositionChanged();
			if (align && mDragPanel != null)
			{
				mDragPanel.UpdateScrollbars(recalculateBounds: true);
				mDragPanel.AlignToPos(instant: true);
			}
		}
	}

	public void MakeEmpty()
	{
		for (int i = 0; i < containItems && i < items.Count; i++)
		{
			sizes[i] = 0f;
			if (items[i] != null)
			{
				if (makeFree != null)
				{
					makeFree(items[i]);
				}
				items[i] = null;
			}
		}
		if (mDragPanel != null)
		{
			UIDraggablePanel uIDraggablePanel = mDragPanel;
			uIDraggablePanel.onMovePerformed = (Action)Delegate.Remove(uIDraggablePanel.onMovePerformed, new Action(PositionChanged));
		}
		getTransform = null;
		makeFree = null;
	}

	public void PositionChanged()
	{
		if (makeFree == null || getTransform == null || getSize == null)
		{
			Debug.LogError("some delegates for pooling missing for: " + base.name);
			return;
		}
		Vector4 clipRange = mDragPanel.panel.clipRange;
		float num = clipRange.y - clipRange.w / 2f - base.transform.localPosition.y;
		float num2 = num + clipRange.w;
		int num3 = int.MaxValue;
		int num4 = -1;
		for (int i = 0; i < containItems && i < items.Count; i++)
		{
			if (!(items[i] != null))
			{
				continue;
			}
			if (items[i].localPosition.y - sizes[i] - (float)padding > num2 + 15f || items[i].localPosition.y < num - 15f)
			{
				makeFree(items[i]);
				items[i] = null;
				continue;
			}
			num4 = i;
			if (num3 > i)
			{
				num3 = i;
			}
		}
		for (int j = containItems; j < items.Count; j++)
		{
			if (items[j] != null)
			{
				makeFree(items[j]);
				items[j] = null;
			}
		}
		if (num4 < 0)
		{
			Vector3 zero = Vector3.zero;
			zero.y = topHelperSprite.localScale.y * 0.5f;
			topHelperSprite.localPosition = zero;
			zero = Vector3.zero;
			for (int num5 = containItems - 1; num5 >= 0; num5--)
			{
				if (zero.y > num - 10f && zero.y < num2 + 10f)
				{
					items[num5] = getTransform(num5);
					if (!(items[num5] == null))
					{
						sizes[num5] = getSize(num5, items[num5]);
						items[num5].localPosition = zero;
						zero.y -= sizes[num5] + (float)padding;
					}
				}
				else
				{
					zero.y -= (float)padding + ((!useDefaultSize) ? getSize(num5, null) : defaultSize);
				}
			}
			zero.y -= downHelperSprite.localScale.y * 0.5f;
			downHelperSprite.localPosition = zero;
			return;
		}
		Vector3 localPosition = items[num3].localPosition;
		localPosition.y -= sizes[num3] + (float)padding;
		for (int num6 = num3 - 1; num6 >= 0; num6--)
		{
			if (localPosition.y > num - 10f)
			{
				items[num6] = getTransform(num6);
				if (!(items[num6] == null))
				{
					if (sizes[num6] == 0f)
					{
						sizes[num6] = getSize(num6, items[num6]);
					}
					items[num6].localPosition = localPosition;
					localPosition.y -= sizes[num6] + (float)padding;
				}
			}
			else if (sizes[num6] == 0f)
			{
				localPosition.y -= (float)padding + ((!useDefaultSize) ? getSize(num6, null) : defaultSize);
			}
			else
			{
				localPosition.y -= (float)padding + ((!useDefaultSize) ? getSize(num6, null) : defaultSize);
			}
		}
		localPosition.y -= downHelperSprite.localScale.y * 0.5f;
		downHelperSprite.localPosition = localPosition;
		localPosition = items[num4].localPosition;
		for (int k = num4 + 1; k < containItems; k++)
		{
			if (localPosition.y < num2 + 10f)
			{
				items[k] = getTransform(k);
				if (!(items[k] == null))
				{
					if (sizes[k] == 0f)
					{
						sizes[k] = getSize(k, items[k]);
					}
					localPosition.y += (float)padding + sizes[k];
					items[k].localPosition = localPosition;
				}
			}
			else
			{
				if (sizes[k] == 0f)
				{
					sizes[k] = getSize(k, null);
				}
				localPosition.y += (float)padding + sizes[k];
			}
		}
		localPosition.y += topHelperSprite.localScale.y * 0.5f;
		topHelperSprite.localPosition = localPosition;
	}

	private void OnEnable()
	{
		if (makeFree != null && getTransform != null && getSize != null && mDragPanel != null)
		{
			PositionChanged();
		}
	}
}
