using UnityEngine;

[ExecuteInEditMode]
public class UIGrid : MonoBehaviour
{
	public delegate void OnReposition();

	public enum Arrangement
	{
		Horizontal,
		Vertical
	}

	public Arrangement arrangement;

	public int maxPerLine;

	public float cellWidth;

	public float cellHeight;

	public bool repositionNow;

	public bool sorted;

	public bool hideInactive;

	public OnReposition onReposition;

	protected bool mStarted;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public static int SortByName(Transform a, Transform b)
	{
		return 0;
	}

	public virtual void Reposition()
	{
	}
}
