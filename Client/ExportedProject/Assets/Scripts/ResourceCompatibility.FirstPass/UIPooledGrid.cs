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

	private List<Transform> items;

	public Transform helperMin;

	public Transform helperMax;

	public Vector2 minHelperOffset;

	public Vector2 maxHelperOffset;

	public float inLineOffset;

	public float blockAdd;

	public int blockAddEach;

	public Vector2 offsetGrid;

	public Transform GetItemOnIndex(int index)
	{
		return null;
	}

	public void init(int count, PooledTransform getter, Action<Transform> free, UIDraggablePanel dragPanel)
	{
	}

	public override void Reposition()
	{
	}

	public void MakeEmpty()
	{
	}

	public Vector3 getPositionForIndex(int index)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public void PositionChanged()
	{
	}
}
