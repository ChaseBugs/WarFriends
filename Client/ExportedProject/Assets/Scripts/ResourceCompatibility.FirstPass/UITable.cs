using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UITable : MonoBehaviour
{
	public delegate void OnReposition();

	public enum Direction
	{
		Down,
		Up
	}

	public enum HorizontalDirection
	{
		Right,
		Left
	}

	public int columns;

	public HorizontalDirection horizontalDirection;

	public Direction direction;

	public Vector2 padding;

	public bool sorted;

	public bool hideInactive;

	public bool repositionNow;

	public bool keepWithinPanel;

	public OnReposition onReposition;

	private UIPanel mPanel;

	private UIDraggablePanel mDrag;

	private bool mStarted;

	private List<Transform> mChildren;

	public List<Transform> children => null;

	public static int SortByName(Transform a, Transform b)
	{
		return 0;
	}

	private void RepositionVariableSize(List<Transform> children)
	{
	}

	public void Reposition()
	{
	}

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}
}
