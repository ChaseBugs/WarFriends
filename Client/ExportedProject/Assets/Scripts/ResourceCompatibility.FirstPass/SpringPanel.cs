using UnityEngine;

public class SpringPanel : IgnoreTimeScale
{
	public delegate void OnFinished();

	public delegate void OnSpecialFinished();

	public Vector3 target;

	public float strength;

	public OnFinished onFinished;

	public OnSpecialFinished onSpecialFinished;

	private UIPanel mPanel;

	private Transform mTrans;

	private float mThreshold;

	private UIDraggablePanel mDrag;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public static SpringPanel Begin(GameObject go, Vector3 pos, float strength)
	{
		return null;
	}
}
