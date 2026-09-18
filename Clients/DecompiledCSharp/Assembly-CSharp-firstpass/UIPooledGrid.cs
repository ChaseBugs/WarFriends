using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPooledGrid : UIGrid
{
	public delegate Transform PooledTransform(int index);

	public PooledTransform getTransform;

	public Action<Transform> makeFree;

	public UIPanel parentPanel;

	public int containItems;

	private UIDraggablePanel mDragPanel;

	private List<Transform> items = new List<Transform>();

	public Transform helperMin;

	public Transform helperMax;

	public Vector2 minHelperOffset = Vector2.zero;

	public Vector2 maxHelperOffset = Vector2.zero;

	public float inLineOffset;

	public float blockAdd;

	public int blockAddEach;

	[Header("Offset of grid in Panel")]
	public Vector2 offsetGrid = Vector2.zero;

	public Transform GetItemOnIndex(int index)
	{
		if (index < 0 || index >= containItems || index >= items.Count)
		{
			return null;
		}
		return items[index];
	}

	public void init(int count, PooledTransform getter, Action<Transform> free, UIDraggablePanel dragPanel)
	{
		dragPanel.onMovePerformed = (Action)Delegate.Remove(dragPanel.onMovePerformed, new Action(PositionChanged));
		dragPanel.onMovePerformed = (Action)Delegate.Combine(dragPanel.onMovePerformed, new Action(PositionChanged));
		getTransform = getter;
		makeFree = free;
		containItems = count;
		mDragPanel = dragPanel;
		helperMin.localPosition = new Vector3((helperMin.localScale.x - cellWidth) * 0.5f - minHelperOffset.x, (cellHeight - helperMin.localScale.y) * 0.5f + minHelperOffset.y, 0f);
		int num = count - 1;
		int num2 = 0;
		if (maxPerLine > 0)
		{
			num = (count - 1) % maxPerLine;
			num2 = (count - 1) / maxPerLine;
		}
		if (arrangement == Arrangement.Vertical)
		{
			int num3 = num;
			num = num2;
			num2 = num3;
		}
		helperMax.localPosition = new Vector3((cellWidth - helperMax.localScale.x) * 0.5f + cellWidth * (float)num + maxHelperOffset.x, (helperMax.localScale.y - cellHeight) * 0.5f - cellHeight * (float)num2 - maxHelperOffset.y, 0f);
		while (items.Count < containItems)
		{
			items.Add(null);
		}
		Reposition();
	}

	public override void Reposition()
	{
		if (!mStarted)
		{
			repositionNow = true;
			return;
		}
		PositionChanged();
		if (onReposition != null)
		{
			onReposition();
		}
	}

	public void MakeEmpty()
	{
		if (makeFree != null)
		{
			for (int i = 0; i < containItems && i < items.Count; i++)
			{
				if (items[i] != null)
				{
					makeFree(items[i]);
				}
			}
		}
		items.Clear();
		if (mDragPanel != null)
		{
			UIDraggablePanel uIDraggablePanel = mDragPanel;
			uIDraggablePanel.onMovePerformed = (Action)Delegate.Remove(uIDraggablePanel.onMovePerformed, new Action(PositionChanged));
		}
		getTransform = null;
		makeFree = null;
	}

	public void SetHelpersToTheSamePosition()
	{
		helperMax.localPosition = helperMin.localPosition;
	}

	public Vector3 getPositionForIndex(int index)
	{
		int num = index;
		int num2 = 0;
		if (maxPerLine > 0)
		{
			num = index % maxPerLine;
			num2 = index / maxPerLine;
		}
		float num3 = 0f;
		if (blockAddEach > 0)
		{
			num3 = blockAdd * (float)(index / blockAddEach);
		}
		return (arrangement != Arrangement.Horizontal) ? new Vector3(cellWidth * (float)num2 + inLineOffset * (float)num + num3, (0f - cellHeight) * (float)num, 0f) : new Vector3(cellWidth * (float)num, (0f - cellHeight) * (float)num2 + inLineOffset * (float)num + num3, 0f);
	}

	public void PositionChanged()
	{
		if (makeFree == null || getTransform == null)
		{
			repositionNow = true;
			return;
		}
		Vector4 clipRange = parentPanel.clipRange;
		Vector2 vector = new Vector2(clipRange.x - clipRange.z / 2f - base.transform.localPosition.x, clipRange.y - clipRange.w / 2f - base.transform.localPosition.y);
		Vector2 vector2 = new Vector2(vector.x + clipRange.z, vector.y + clipRange.w);
		vector += offsetGrid;
		vector2 += offsetGrid;
		for (int i = 0; i < containItems && i < items.Count; i++)
		{
			if (items[i] != null)
			{
				Vector3 positionForIndex = getPositionForIndex(i);
				if (positionForIndex.x + cellWidth < vector.x || positionForIndex.x - cellWidth > vector2.x || positionForIndex.y + cellHeight < vector.y || positionForIndex.y - cellHeight > vector2.y)
				{
					makeFree(items[i]);
					items[i] = null;
				}
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
		for (int k = 0; k < containItems && k < items.Count; k++)
		{
			if (!(items[k] == null))
			{
				continue;
			}
			Vector3 positionForIndex2 = getPositionForIndex(k);
			if (positionForIndex2.x + cellWidth > vector.x && positionForIndex2.x - cellWidth < vector2.x && positionForIndex2.y + cellHeight > vector.y && positionForIndex2.y - cellHeight < vector2.y)
			{
				Transform transform = getTransform(k);
				if (transform != null)
				{
					Vector3 localScale = transform.localScale;
					transform.parent = base.transform;
					transform.localScale = localScale;
					transform.localPosition = positionForIndex2;
				}
				items[k] = transform;
			}
		}
	}
}
