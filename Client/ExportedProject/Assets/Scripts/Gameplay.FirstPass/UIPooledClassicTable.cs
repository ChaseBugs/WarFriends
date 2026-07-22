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

	public float topBreakPoint = 15f;

	public float bottomBreakPoint = 15f;

	public int containItems;

	private List<Transform> mItems = new List<Transform>();

	private List<float> mSizes = new List<float>();

	private UIDraggablePanel mDragPanel;

	private PooledTransform getTransform;

	private Action<Transform> makeFree;

	private PooledSize getSize;

	public void Initialize(int count, PooledTransform getter, Action<Transform> free, PooledSize sizeGetter, UIDraggablePanel dragPanel)
	{
		getTransform = getter;
		makeFree = free;
		getSize = sizeGetter;
		mDragPanel = dragPanel;
		mDragPanel.onMovePerformed = PositionChanged;
		containItems = count;
		for (int i = mItems.Count; i < containItems; i++)
		{
			mItems.Add(null);
			mSizes.Add(0f);
		}
		if (base.gameObject.activeInHierarchy)
		{
			PositionChanged();
		}
	}

	public void MakeEmpty()
	{
		for (int i = 0; i < containItems && i < mItems.Count; i++)
		{
			mSizes[i] = 0f;
			if (mItems[i] != null)
			{
				if (makeFree != null)
				{
					makeFree(mItems[i]);
				}
				mItems[i] = null;
			}
		}
		if (mDragPanel != null)
		{
			UIDraggablePanel uIDraggablePanel = mDragPanel;
			uIDraggablePanel.onMovePerformed = (Action)Delegate.Remove(uIDraggablePanel.onMovePerformed, new Action(PositionChanged));
		}
		getTransform = null;
		makeFree = null;
		getSize = null;
	}

	public void PositionChanged()
	{
		if (makeFree == null || getTransform == null || getSize == null)
		{
			Debug.LogError("UIPooledClassicTable - some delegates for pooling missing for: " + base.name);
			return;
		}
		if (mDragPanel == null)
		{
			Debug.LogError("UIPooledClassicTable - drag panel is null");
			return;
		}
		if (mDragPanel.panel == null)
		{
			Debug.LogError("UIPooledClassicTable - drag panel UIPanel is null");
			return;
		}
		Vector4 clipRange = mDragPanel.panel.clipRange;
		float num = clipRange.y - clipRange.w / 2f - base.transform.localPosition.y;
		float num2 = num + clipRange.w;
		num -= bottomBreakPoint;
		num2 += topBreakPoint;
		int num3 = int.MaxValue;
		int num4 = -1;
		for (int i = 0; i < containItems && i < mItems.Count; i++)
		{
			if (!(mItems[i] != null))
			{
				continue;
			}
			float num5 = mItems[i].localPosition.y - ((float)padding + mSizes[i]);
			float y = mItems[i].localPosition.y;
			if (num5 > num2 || y < num)
			{
				makeFree(mItems[i]);
				mItems[i] = null;
				continue;
			}
			num4 = i;
			if (num3 > i)
			{
				num3 = i;
			}
		}
		FreeNotUsedItems();
		if (num4 < 0)
		{
			FirstReposition(num, num2);
			return;
		}
		Vector3 localPosition = mItems[num3].localPosition;
		int num6 = num3 - 1;
		while (num6 >= 0 && localPosition.y < num2)
		{
			mItems[num6] = getTransform(num6);
			mSizes[num6] = getSize(num6);
			localPosition.y += (float)padding + mSizes[num6];
			mItems[num6].localPosition = localPosition;
			num6--;
		}
		localPosition = mItems[num4].localPosition;
		localPosition.y -= (float)padding + mSizes[num4];
		for (int j = num4 + 1; j < containItems; j++)
		{
			if (!(localPosition.y > num))
			{
				break;
			}
			mItems[j] = getTransform(j);
			mSizes[j] = getSize(j);
			mItems[j].localPosition = localPosition;
			localPosition.y -= (float)padding + mSizes[j];
		}
	}

	private void FreeNotUsedItems()
	{
		for (int i = containItems; i < mItems.Count; i++)
		{
			mSizes[i] = 0f;
			if (mItems[i] != null)
			{
				makeFree(mItems[i]);
				mItems[i] = null;
			}
		}
	}

	private void FirstReposition(float bottomLimit, float topLimit)
	{
		Vector3 zero = Vector3.zero;
		zero.y = topHelperSprite.localScale.y * 0.5f;
		topHelperSprite.localPosition = zero;
		zero = Vector3.zero;
		for (int i = 0; i < containItems; i++)
		{
			mSizes[i] = getSize(i);
			if (zero.y > bottomLimit && zero.y - ((float)padding + mSizes[i]) < topLimit)
			{
				mItems[i] = getTransform(i);
				mItems[i].localPosition = zero;
			}
			zero.y -= (float)padding + mSizes[i];
		}
		zero.y -= downHelperSprite.localScale.y * 0.5f;
		downHelperSprite.localPosition = zero;
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
		if (index < 0 || index >= containItems || index >= mItems.Count)
		{
			return null;
		}
		return mItems[index];
	}

	public Vector3 GetPositionForIndex(int index)
	{
		float num = (float)padding * (float)index;
		for (int i = 0; i < index && i < mItems.Count; i++)
		{
			num += ((!(mSizes[i] > 0f)) ? getSize(i) : mSizes[i]);
		}
		return new Vector3(0f, 0f - num, 0f);
	}
}
