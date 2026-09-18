using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Grid Extended")]
public class UIGridStretchWidth : MonoBehaviour
{
	public enum Arrangement
	{
		Horizontal,
		Vertical
	}

	public delegate void OnReposition();

	public Arrangement arrangement;

	public int maxPerLine;

	public int columns = 3;

	public float cellHeight = 200f;

	public bool repositionNow;

	public bool sorted;

	public bool hideInactive = true;

	public OnReposition onReposition;

	private bool mStarted;

	private void Start()
	{
		mStarted = true;
		Reposition();
	}

	private void Update()
	{
		if (repositionNow)
		{
			repositionNow = false;
			Reposition();
		}
	}

	public static int SortByName(Transform a, Transform b)
	{
		return string.Compare(a.name, b.name);
	}

	public void Reposition()
	{
		if (!mStarted)
		{
			repositionNow = true;
			return;
		}
		UIRoot uIRoot = ((UIRoot.list != null && UIRoot.list.Count != 0) ? UIRoot.list[0] : null);
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		if (uIRoot != null)
		{
			vector *= uIRoot.GetPixelSizeAdjustment(Screen.height, Screen.width);
		}
		float x = vector.x;
		float num = x / (float)columns;
		Transform transform = base.transform;
		int num2 = 0;
		int num3 = 0;
		if (sorted)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((bool)child && (!hideInactive || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(SortByName);
			int j = 0;
			for (int count = list.Count; j < count; j++)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !hideInactive)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((arrangement != Arrangement.Horizontal) ? new Vector3(num * (float)num3, (0f - cellHeight) * (float)num2, z) : new Vector3(num * (float)num2, (0f - cellHeight) * (float)num3, z));
					if (++num2 >= maxPerLine && maxPerLine > 0)
					{
						num2 = 0;
						num3++;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < transform.childCount; k++)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !hideInactive)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((arrangement != Arrangement.Horizontal) ? new Vector3(num * (float)num3, (0f - cellHeight) * (float)num2, z2) : new Vector3(num * (float)num2, (0f - cellHeight) * (float)num3, z2));
					if (++num2 >= maxPerLine && maxPerLine > 0)
					{
						num2 = 0;
						num3++;
					}
				}
			}
		}
		if (onReposition != null)
		{
			onReposition();
		}
		UIDraggablePanel uIDraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uIDraggablePanel != null)
		{
			uIDraggablePanel.UpdateScrollbars(recalculateBounds: true);
		}
	}
}
