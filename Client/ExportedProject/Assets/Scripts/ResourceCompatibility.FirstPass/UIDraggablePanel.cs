using System;
using UnityEngine;

[ExecuteInEditMode]
public class UIDraggablePanel : IgnoreTimeScale
{
	public enum DragEffect
	{
		None,
		Momentum,
		MomentumAndSpring
	}

	public enum ShowCondition
	{
		Always,
		OnlyIfNeeded,
		WhenDragging
	}

	public delegate void OnDragFinished();

	public delegate void OnMovementFinished();

	public delegate void OnPressed();

	public delegate void OnRelease();

	public enum Alingment
	{
		TopLeft,
		BottomRight
	}

	public bool forceDrag;

	public bool restrictWithinPanel;

	public bool disableDragIfFits;

	public DragEffect dragEffect;

	public bool smoothDragStart;

	public Vector3 scale;

	public float scrollWheelFactor;

	public float momentumAmount;

	public Vector2 relativePositionOnReset;

	public bool repositionClipping;

	public bool iOSDragEmulation;

	public UIScrollBar horizontalScrollBar;

	public UIScrollBar verticalScrollBar;

	public ShowCondition showScrollBars;

	public OnDragFinished onDragFinished;

	public OnMovementFinished onMovementFinished;

	public OnPressed onPressed;

	public OnRelease onRelease;

	public bool alignToTopWhenDontFit;

	protected Transform mTrans;

	private UIPanel mPanel;

	private Vector3 mLastPos;

	private bool mPressed;

	protected Vector3 mMomentum;

	protected float mScroll;

	private Bounds mBounds;

	private bool mCalculatedBounds;

	private bool mShouldMove;

	private bool mIgnoreCallbacks;

	private int mDragID;

	private Vector2 mDragStartOffset;

	private bool mDragStarted;

	public bool stretchX;

	public bool stretchY;

	private Vector2 defaultClipRangeCenter;

	private Camera m2DCamera;

	private Bounds mPanelBounds;

	private static bool mDisDis;

	private bool mOnePanelDisabled;

	private bool mIsDragging;

	private Vector3 lastPos;

	public Action onMovePerformed;

	public UIPanel panel
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Bounds bounds => default(Bounds);

	public bool shouldMoveHorizontally => false;

	public bool shouldMoveVertically => false;

	private bool shouldMove => false;

	protected bool itFits => false;

	public Vector3 currentMomentum
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector3);
		}
		set
		{
		}
	}

	public static bool panelDisabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool onePanelDisabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnPanelChange()
	{
	}

	private void Start()
	{
	}

	protected override void OnEnable()
	{
	}

	public virtual bool RestrictWithinBounds(bool instant)
	{
		return false;
	}

	public void DisableSpring()
	{
	}

	public void UpdateScrollbars(bool recalculateBounds)
	{
	}

	public bool AlignToPos(bool instant, Alingment alingment = Alingment.TopLeft, bool onePanelDisabledAfterAlign = false)
	{
		return false;
	}

	public bool AlignToCenter(Vector3 vec, bool instant, Action alignedNow = null, float strength = 1.5f)
	{
		return false;
	}

	public void MoveToTop(float x, float y)
	{
	}

	public void SetDragAmount(float x, float y, bool updateScrollbars)
	{
	}

	public void ResetPosition()
	{
	}

	private void OnHorizontalBar(UIScrollBar sb)
	{
	}

	private void OnVerticalBar(UIScrollBar sb)
	{
	}

	public virtual void MoveRelative(Vector3 relative)
	{
	}

	public void MoveAbsolute(Vector3 absolute)
	{
	}

	public void Press(bool pressed)
	{
	}

	private bool IsTouchInside()
	{
		return false;
	}

	private void Update()
	{
	}

	public void Scroll(float delta)
	{
	}

	private void LateUpdate()
	{
	}
}
