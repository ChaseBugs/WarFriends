using UnityEngine;

[ExecuteInEditMode]
public class UIAnchor : MonoBehaviour
{
	public enum Side
	{
		BottomLeft,
		Left,
		TopLeft,
		Top,
		TopRight,
		Right,
		BottomRight,
		Bottom,
		Center
	}

	public enum SafeArea
	{
		Both,
		Width,
		Height
	}

	public Camera uiCamera;

	public UIWidget widgetContainer;

	public UIPanel panelContainer;

	public Side side;

	public bool halfPixelOffset;

	public bool runOnlyOnce;

	public Vector2 relativeOffset;

	public bool useSafeScreenArea;

	public SafeArea safeAreaType;

	private Transform mTrans;

	private Animation mAnim;

	private Rect mRect;

	private UIRoot mRoot;

	private bool mNeedsHalfPixelOffset;

	private void Awake()
	{
	}

	public void Start()
	{
	}

	private void Update()
	{
	}
}
