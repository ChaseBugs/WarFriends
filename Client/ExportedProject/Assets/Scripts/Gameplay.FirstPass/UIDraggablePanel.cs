using System;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Draggable Panel")]
[ExecuteInEditMode]
[RequireComponent(typeof(UIPanel))]
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

	public enum Alingment
	{
		TopLeft,
		BottomRight
	}

	public bool forceDrag;

	public bool restrictWithinPanel = true;

	public bool disableDragIfFits;

	public DragEffect dragEffect = DragEffect.MomentumAndSpring;

	public bool smoothDragStart = true;

	public Vector3 scale = Vector3.one;

	public float scrollWheelFactor;

	public float momentumAmount = 35f;

	public Vector2 relativePositionOnReset = Vector2.zero;

	public bool repositionClipping;

	public bool iOSDragEmulation = true;

	public UIScrollBar horizontalScrollBar;

	public UIScrollBar verticalScrollBar;

	public ShowCondition showScrollBars = ShowCondition.OnlyIfNeeded;

	public OnDragFinished onDragFinished;

	public OnMovementFinished onMovementFinished;

	public bool alignToTopWhenDontFit = true;

	protected Transform mTrans;

	private UIPanel mPanel;

	private Vector3 mLastPos;

	private bool mPressed;

	protected Vector3 mMomentum = Vector3.zero;

	protected float mScroll;

	private Bounds mBounds;

	private bool mCalculatedBounds;

	private bool mShouldMove;

	private bool mIgnoreCallbacks;

	private int mDragID = -10;

	private Vector2 mDragStartOffset = Vector2.zero;

	private bool mDragStarted;

	public bool stretchX = true;

	public bool stretchY = true;

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
			if (mPanel == null)
			{
				Awake();
			}
			return mPanel;
		}
		set
		{
			mPanel = value;
		}
	}

	public Bounds bounds
	{
		get
		{
			if (!mCalculatedBounds)
			{
				mCalculatedBounds = true;
				mBounds = NGUIMath.CalculateRelativeWidgetBounds(mTrans, mTrans);
			}
			return mBounds;
		}
	}

	public bool shouldMoveHorizontally
	{
		get
		{
			float num = bounds.size.x;
			if (panel.clipping == UIDrawCall.Clipping.SoftClip)
			{
				num += panel.clipSoftness.x * 2f;
			}
			return num > panel.clipRange.z;
		}
	}

	public bool shouldMoveVertically
	{
		get
		{
			float num = bounds.size.y;
			if (panel.clipping == UIDrawCall.Clipping.SoftClip)
			{
				num += panel.clipSoftness.y * 2f;
			}
			return num > panel.clipRange.w;
		}
	}

	private bool shouldMove
	{
		get
		{
			if (!disableDragIfFits)
			{
				return true;
			}
			if (panel == null)
			{
				panel = GetComponent<UIPanel>();
			}
			Vector4 clipRange = panel.clipRange;
			Bounds bounds = this.bounds;
			float num = ((clipRange.z != 0f) ? (clipRange.z * 0.5f) : ((float)Screen.width));
			float num2 = ((clipRange.w != 0f) ? (clipRange.w * 0.5f) : ((float)Screen.height));
			if (!Mathf.Approximately(scale.x, 0f))
			{
				if (bounds.min.x < clipRange.x - num - 1f)
				{
					return true;
				}
				if (bounds.max.x > clipRange.x + num + 1f)
				{
					return true;
				}
			}
			if (!Mathf.Approximately(scale.y, 0f))
			{
				if (bounds.min.y < clipRange.y - num2 - 1f)
				{
					return true;
				}
				if (bounds.max.y > clipRange.y + num2 + 1f)
				{
					return true;
				}
			}
			return false;
		}
	}

	protected bool itFits
	{
		get
		{
			if (panel == null)
			{
				panel = GetComponent<UIPanel>();
			}
			Vector4 clipRange = panel.clipRange;
			Bounds bounds = this.bounds;
			float num = ((clipRange.z != 0f) ? (clipRange.z * 0.5f) : ((float)Screen.width));
			float num2 = ((clipRange.w != 0f) ? (clipRange.w * 0.5f) : ((float)Screen.height));
			if (!Mathf.Approximately(scale.x, 0f))
			{
				if (bounds.min.x < clipRange.x - num)
				{
					return true;
				}
				if (bounds.max.x > clipRange.x + num)
				{
					return true;
				}
			}
			if (!Mathf.Approximately(scale.y, 0f))
			{
				if (bounds.min.y < clipRange.y - num2)
				{
					return true;
				}
				if (bounds.max.y > clipRange.y + num2)
				{
					return true;
				}
			}
			return false;
		}
	}

	public Vector3 currentMomentum
	{
		get
		{
			return mMomentum;
		}
		set
		{
			mMomentum = value;
			mShouldMove = true;
		}
	}

	public static bool panelDisabled
	{
		get
		{
			return mDisDis;
		}
		set
		{
			mDisDis = value;
		}
	}

	public bool onePanelDisabled
	{
		get
		{
			return mOnePanelDisabled;
		}
		set
		{
			mOnePanelDisabled = value;
		}
	}

	private void Awake()
	{
		mTrans = base.transform;
		panel = GetComponent<UIPanel>();
		UIPanel uIPanel = panel;
		uIPanel.onChange = (UIPanel.OnChangeDelegate)Delegate.Combine(uIPanel.onChange, new UIPanel.OnChangeDelegate(OnPanelChange));
		if (panel.clipping == UIDrawCall.Clipping.None || panel.clipping == UIDrawCall.Clipping.AlphaClip)
		{
			Vector2 vector = new Vector2(Screen.width, Screen.height);
			if (panel.root != null)
			{
				vector *= panel.root.GetPixelSizeAdjustment(Screen.height, Screen.width);
			}
			Vector4 clipRange = panel.clipRange;
			if (stretchX)
			{
				clipRange.z = vector.x;
			}
			if (stretchY)
			{
				clipRange.w = vector.y;
			}
			panel.clipRange = clipRange;
		}
	}

	private void OnDestroy()
	{
		if (panel != null)
		{
			UIPanel uIPanel = panel;
			uIPanel.onChange = (UIPanel.OnChangeDelegate)Delegate.Remove(uIPanel.onChange, new UIPanel.OnChangeDelegate(OnPanelChange));
		}
	}

	private void OnPanelChange()
	{
		UpdateScrollbars(recalculateBounds: true);
	}

	private void Start()
	{
		UpdateScrollbars(recalculateBounds: true);
		if (horizontalScrollBar != null)
		{
			UIScrollBar uIScrollBar = horizontalScrollBar;
			uIScrollBar.onChange = (UIScrollBar.OnScrollBarChange)Delegate.Combine(uIScrollBar.onChange, new UIScrollBar.OnScrollBarChange(OnHorizontalBar));
			horizontalScrollBar.alpha = ((showScrollBars != ShowCondition.Always && !shouldMoveHorizontally) ? 0f : 1f);
		}
		if (verticalScrollBar != null)
		{
			UIScrollBar uIScrollBar2 = verticalScrollBar;
			uIScrollBar2.onChange = (UIScrollBar.OnScrollBarChange)Delegate.Combine(uIScrollBar2.onChange, new UIScrollBar.OnScrollBarChange(OnVerticalBar));
			verticalScrollBar.alpha = ((showScrollBars != ShowCondition.Always && !shouldMoveVertically) ? 0f : 1f);
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (m2DCamera == null)
		{
			m2DCamera = NGUITools.FindInParents<UICamera>(base.gameObject).GetComponent<Camera>();
		}
		mPressed = false;
	}

	public virtual bool RestrictWithinBounds(bool instant)
	{
		Vector3 vector = panel.CalculateConstrainOffset(bounds.min, bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 0.001f)
		{
			if (!instant && dragEffect == DragEffect.MomentumAndSpring)
			{
				if (shouldMoveVertically || shouldMoveHorizontally)
				{
					SpringPanel.Begin(panel.gameObject, mTrans.localPosition + vector, 13f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false);
				}
				else
				{
					SpringPanel.Begin(panel.gameObject, mTrans.localPosition + vector, 13f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 0f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !itFits)
		{
			AlignToPos(instant: false);
		}
		return false;
	}

	public void DisableSpring()
	{
		SpringPanel component = GetComponent<SpringPanel>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public void UpdateScrollbars(bool recalculateBounds)
	{
		if (panel == null)
		{
			return;
		}
		if (horizontalScrollBar != null || verticalScrollBar != null)
		{
			if (recalculateBounds)
			{
				mCalculatedBounds = false;
				mShouldMove = shouldMove;
			}
			Bounds bounds = this.bounds;
			Vector2 vector = bounds.min;
			Vector2 vector2 = bounds.max;
			if (panel.clipping == UIDrawCall.Clipping.SoftClip)
			{
				Vector2 clipSoftness = panel.clipSoftness;
				vector -= clipSoftness;
				vector2 += clipSoftness;
			}
			if (horizontalScrollBar != null && vector2.x > vector.x)
			{
				Vector4 clipRange = panel.clipRange;
				float num = clipRange.z * 0.5f;
				float num2 = clipRange.x - num - bounds.min.x;
				float num3 = bounds.max.x - num - clipRange.x;
				float num4 = vector2.x - vector.x;
				num2 = Mathf.Clamp01(num2 / num4);
				num3 = Mathf.Clamp01(num3 / num4);
				float num5 = num2 + num3;
				mIgnoreCallbacks = true;
				horizontalScrollBar.barSize = 1f - num5;
				horizontalScrollBar.scrollValue = ((!(num5 > 0.001f)) ? 0f : (num2 / num5));
				mIgnoreCallbacks = false;
			}
			if (verticalScrollBar != null && vector2.y > vector.y)
			{
				Vector4 clipRange2 = panel.clipRange;
				float num6 = clipRange2.w * 0.5f;
				float num7 = clipRange2.y - num6 - vector.y;
				float num8 = vector2.y - num6 - clipRange2.y;
				float num9 = vector2.y - vector.y;
				num7 = Mathf.Clamp01(num7 / num9);
				num8 = Mathf.Clamp01(num8 / num9);
				float num10 = num7 + num8;
				mIgnoreCallbacks = true;
				verticalScrollBar.barSize = 1f - num10;
				verticalScrollBar.scrollValue = ((!(num10 > 0.001f)) ? 0f : (1f - num7 / num10));
				mIgnoreCallbacks = false;
			}
		}
		else if (recalculateBounds)
		{
			mCalculatedBounds = false;
		}
	}

	public bool AlignToPos(bool instant, Alingment alingment = Alingment.TopLeft, bool onePanelDisabledAfterAlign = false)
	{
		if (panel == null)
		{
			return false;
		}
		mCalculatedBounds = false;
		Vector3 vector = panel.CalculateLeftTopAlignOffset(bounds.min, bounds.max);
		if (alingment == Alingment.BottomRight)
		{
			vector = panel.CalculateBottomRightAlignOffset(bounds.min, bounds.max);
		}
		vector.Scale(scale);
		if (vector.sqrMagnitude > 0.001f)
		{
			if (!instant && dragEffect == DragEffect.MomentumAndSpring)
			{
				if (!shouldMove)
				{
					onePanelDisabled = true;
				}
				SpringPanel sp = SpringPanel.Begin(panel.gameObject, mTrans.localPosition + vector, 13f);
				sp.onSpecialFinished = delegate
				{
					onePanelDisabled = !shouldMove;
					mShouldMove = shouldMove;
					sp.onSpecialFinished = null;
				};
			}
			else
			{
				onePanelDisabled = !shouldMove;
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 0f;
				SpringPanel component = GetComponent<SpringPanel>();
				if (component != null)
				{
					component.enabled = false;
				}
				mShouldMove = shouldMove;
			}
		}
		else
		{
			onePanelDisabled = !shouldMove;
			if (instant)
			{
				mMomentum = Vector3.zero;
				mScroll = 0f;
			}
			SpringPanel component2 = GetComponent<SpringPanel>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			mShouldMove = shouldMove;
		}
		return false;
	}

	public bool AlignToCenter(Vector3 vec, bool instant, Action alignedNow = null, float strength = 1.5f)
	{
		if (panel == null)
		{
			return false;
		}
		mCalculatedBounds = false;
		Vector3 vector = new Vector3(mPanel.clipRange.x - vec.x, mPanel.clipRange.y - vec.y, 0f);
		Vector3 vector2 = mPanel.CalculateLeftTopAlignOffset(bounds.min, bounds.max);
		vector2.Scale(scale);
		bool flag = mPanel.clipRange.z < bounds.max.x - bounds.min.x;
		bool flag2 = mPanel.clipRange.w < bounds.max.y - bounds.min.y;
		if (scale.y > 0f)
		{
			vector.y = ((!flag2) ? vector2.y : Mathf.Max(vector2.y, vector.y));
		}
		if (scale.x > 0f)
		{
			vector.x = ((!flag) ? vector2.x : Mathf.Min(vector2.x, vector.x));
		}
		vector2 = mPanel.CalculateBottomRightAlignOffset(bounds.min, bounds.max);
		vector2.Scale(scale);
		if (scale.y > 0f)
		{
			vector.y = ((!flag2) ? Mathf.Max(vector2.y, vector.y) : Mathf.Min(vector2.y, vector.y));
		}
		if (scale.x > 0f)
		{
			vector.x = ((!flag) ? Mathf.Min(vector2.x, vector.x) : Mathf.Max(vector2.x, vector.x));
		}
		vector.Scale(scale);
		if (vector.sqrMagnitude > 0.001f)
		{
			mScroll = 0f;
			mMomentum = Vector3.zero;
			if (!instant && dragEffect == DragEffect.MomentumAndSpring)
			{
				SpringPanel springPanel = SpringPanel.Begin(mPanel.gameObject, mTrans.localPosition + vector, (alignedNow != null) ? strength : 13f);
				springPanel.onFinished = (SpringPanel.OnFinished)Delegate.Combine(springPanel.onFinished, (SpringPanel.OnFinished)delegate
				{
					mCalculatedBounds = false;
					mShouldMove = shouldMove;
					if (alignedNow != null)
					{
						alignedNow();
					}
				});
			}
			else
			{
				MoveRelative(vector);
				lastPos = base.transform.localPosition;
				SpringPanel component = GetComponent<SpringPanel>();
				if (component != null)
				{
					component.enabled = false;
				}
				mCalculatedBounds = false;
				mShouldMove = shouldMove;
				if (alignedNow != null)
				{
					alignedNow();
				}
			}
		}
		else
		{
			if (instant)
			{
				mMomentum = Vector3.zero;
				mScroll = 0f;
			}
			SpringPanel component2 = GetComponent<SpringPanel>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			mCalculatedBounds = false;
			mShouldMove = shouldMove;
			if (alignedNow != null)
			{
				alignedNow();
			}
		}
		return false;
	}

	public void MoveToTop(float x, float y)
	{
		Bounds bounds = this.bounds;
		if (bounds.min.x != bounds.max.x && bounds.min.y != bounds.max.y)
		{
			Vector4 clipRange = panel.clipRange;
			float num = clipRange.z * 0.5f;
			float num2 = clipRange.w * 0.5f;
			float num3 = bounds.min.x + num;
			float num4 = bounds.max.x - num;
			float num5 = bounds.min.y + num2;
			float num6 = bounds.max.y - num2;
			if (panel.clipping == UIDrawCall.Clipping.SoftClip)
			{
				num3 -= panel.clipSoftness.x;
				num4 += panel.clipSoftness.x;
				num5 -= panel.clipSoftness.y;
				num6 += panel.clipSoftness.y;
			}
			float num7 = Mathf.Lerp(num3, num4, x) * scale.x;
			float num8 = Mathf.Lerp(num6, num5, y) * scale.y;
			Vector3 localPosition = mTrans.localPosition;
			if (scale.x != 0f)
			{
				localPosition.x += clipRange.x - num7;
			}
			if (scale.y != 0f)
			{
				localPosition.y += clipRange.y - num8;
			}
			SpringPanel.Begin(panel.gameObject, localPosition, 13f);
			clipRange.x = num7;
			clipRange.y = num8;
			panel.clipRange = clipRange;
		}
	}

	public void SetDragAmount(float x, float y, bool updateScrollbars)
	{
		DisableSpring();
		Bounds bounds = this.bounds;
		if (bounds.min.x == bounds.max.x || bounds.min.y == bounds.max.y)
		{
			return;
		}
		Vector4 clipRange = panel.clipRange;
		float num = clipRange.z * 0.5f;
		float num2 = clipRange.w * 0.5f;
		float num3 = bounds.min.x + num;
		float num4 = bounds.max.x - num;
		float num5 = bounds.min.y + num2;
		float num6 = bounds.max.y - num2;
		if (panel.clipping == UIDrawCall.Clipping.SoftClip)
		{
			num3 -= panel.clipSoftness.x;
			num4 += panel.clipSoftness.x;
			num5 -= panel.clipSoftness.y;
			num6 += panel.clipSoftness.y;
		}
		float num7 = Mathf.Lerp(num3, num4, x) * scale.x;
		float num8 = Mathf.Lerp(num6, num5, y) * scale.y;
		if (!updateScrollbars)
		{
			Vector3 localPosition = mTrans.localPosition;
			if (scale.x != 0f)
			{
				localPosition.x += clipRange.x - num7;
			}
			if (scale.y != 0f)
			{
				localPosition.y += clipRange.y - num8;
			}
			mTrans.localPosition = localPosition;
		}
		clipRange.x = num7;
		clipRange.y = num8;
		panel.clipRange = clipRange;
		if (updateScrollbars)
		{
			UpdateScrollbars(recalculateBounds: false);
		}
	}

	public void ResetPosition()
	{
		if (panel == null)
		{
			return;
		}
		if (panel.clipping == UIDrawCall.Clipping.None)
		{
			Vector2 vector = new Vector2(Screen.width, Screen.height);
			if (panel.root != null)
			{
				vector *= panel.root.GetPixelSizeAdjustment(Screen.height, Screen.width);
			}
			Vector4 clipRange = panel.clipRange;
			clipRange.z = vector.x;
			clipRange.w = vector.y;
			panel.clipRange = clipRange;
		}
		mCalculatedBounds = false;
		SetDragAmount(relativePositionOnReset.x, relativePositionOnReset.y, updateScrollbars: false);
		SetDragAmount(relativePositionOnReset.x, relativePositionOnReset.y, updateScrollbars: true);
	}

	private void OnHorizontalBar(UIScrollBar sb)
	{
		if (!mIgnoreCallbacks)
		{
			float x = ((!(horizontalScrollBar != null)) ? 0f : horizontalScrollBar.scrollValue);
			float y = ((!(verticalScrollBar != null)) ? 0f : verticalScrollBar.scrollValue);
			SetDragAmount(x, y, updateScrollbars: false);
		}
	}

	private void OnVerticalBar(UIScrollBar sb)
	{
		if (!mIgnoreCallbacks)
		{
			float x = ((!(horizontalScrollBar != null)) ? 0f : horizontalScrollBar.scrollValue);
			float y = ((!(verticalScrollBar != null)) ? 0f : verticalScrollBar.scrollValue);
			SetDragAmount(x, y, updateScrollbars: false);
		}
	}

	public virtual void MoveRelative(Vector3 relative)
	{
		mTrans.localPosition += relative;
		Vector4 clipRange = panel.clipRange;
		clipRange.x -= relative.x;
		clipRange.y -= relative.y;
		panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public void MoveAbsolute(Vector3 absolute)
	{
		Vector3 vector = mTrans.InverseTransformPoint(absolute);
		Vector3 vector2 = mTrans.InverseTransformPoint(Vector3.zero);
		MoveRelative(vector - vector2);
	}

	public void Press(bool pressed)
	{
		if (pressed)
		{
			mIsDragging = true;
		}
		if (smoothDragStart && pressed)
		{
			mDragStarted = false;
			mDragStartOffset = Vector2.zero;
		}
		if (!base.enabled || !NGUITools.GetActive(base.gameObject))
		{
			return;
		}
		if (!pressed && mDragID == UICamera.currentTouchID)
		{
			mDragID = -10;
		}
		mCalculatedBounds = false;
		mShouldMove = shouldMove;
		if (!mShouldMove)
		{
			return;
		}
		mPressed = pressed;
		if (pressed)
		{
			mMomentum = Vector3.zero;
			mScroll = 0f;
			DisableSpring();
			mLastPos = m2DCamera.ScreenToWorldPoint(Input.mousePosition);
			return;
		}
		if (restrictWithinPanel && dragEffect == DragEffect.MomentumAndSpring)
		{
			RestrictWithinBounds(instant: false);
		}
		if (onDragFinished != null)
		{
			onDragFinished();
		}
	}

	private bool IsTouchInside()
	{
		if ((onePanelDisabled || panelDisabled) && !forceDrag)
		{
			return false;
		}
		if (panel.clipping == UIDrawCall.Clipping.None && GetComponent<Collider>() == null)
		{
			return true;
		}
		if (panel.clipping == UIDrawCall.Clipping.None && GetComponent<Collider>() != null)
		{
			Vector3 vector = m2DCamera.ScreenToWorldPoint(Input.mousePosition);
			vector.z = base.transform.position.z;
			if (stretchX)
			{
				return GetComponent<Collider>().bounds.min.y < vector.y && GetComponent<Collider>().bounds.max.y > vector.y;
			}
			return GetComponent<Collider>().bounds.min.x < vector.x && GetComponent<Collider>().bounds.max.x > vector.x;
		}
		Vector2 vector2 = new Vector2(panel.clipRange.x - panel.clipRange.z * 0.5f, panel.clipRange.y - panel.clipRange.w * 0.5f);
		Vector2 vector3 = new Vector2(panel.clipRange.x + panel.clipRange.z * 0.5f, panel.clipRange.y + panel.clipRange.w * 0.5f);
		mPanelBounds.min = vector2;
		mPanelBounds.max = vector3;
		Vector3 point = mTrans.worldToLocalMatrix.MultiplyPoint(m2DCamera.ScreenToWorldPoint(Input.mousePosition));
		point.z = 0f;
		return mPanelBounds.Contains(point);
	}

	private void Update()
	{
		if (!mPressed && Input.GetMouseButtonDown(0) && IsTouchInside())
		{
			Press(pressed: true);
		}
		else if (mPressed && Input.GetMouseButtonUp(0))
		{
			Press(pressed: false);
		}
		else if (!mPressed && Input.GetMouseButton(0) && !IsTouchInside())
		{
		}
		if (!base.enabled || !NGUITools.GetActive(base.gameObject) || !mShouldMove || !mPressed)
		{
			return;
		}
		if (!IsTouchInside())
		{
			Press(pressed: false);
			return;
		}
		Vector3 vector = m2DCamera.ScreenToWorldPoint(Input.mousePosition);
		Vector3 vector2 = vector - mLastPos;
		vector2.z = 0f;
		mLastPos = vector;
		if (vector2.x != 0f || vector2.y != 0f)
		{
			vector2 = mTrans.InverseTransformDirection(vector2);
			vector2.Scale(scale);
			vector2 = mTrans.TransformDirection(vector2);
		}
		mMomentum = Vector3.Lerp(mMomentum, mMomentum + vector2 * (0.01f * momentumAmount), 0.67f);
		if (!iOSDragEmulation)
		{
			MoveAbsolute(vector2);
		}
		else if (panel.CalculateConstrainOffset(bounds.min, bounds.max).magnitude > 0.001f)
		{
			MoveAbsolute(vector2 * 0.5f);
			mMomentum *= 0.5f;
		}
		else
		{
			MoveAbsolute(vector2);
		}
		if (restrictWithinPanel && dragEffect != DragEffect.MomentumAndSpring)
		{
			RestrictWithinBounds(instant: true);
		}
	}

	public void Scroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && scrollWheelFactor != 0f)
		{
			DisableSpring();
			mShouldMove = shouldMove;
			if (Mathf.Sign(mScroll) != Mathf.Sign(delta))
			{
				mScroll = 0f;
			}
			mScroll += delta * scrollWheelFactor;
		}
	}

	private void LateUpdate()
	{
		if (lastPos != base.transform.localPosition && onMovePerformed != null)
		{
			onMovePerformed();
		}
		lastPos = base.transform.localPosition;
		if (repositionClipping)
		{
			repositionClipping = false;
			mCalculatedBounds = false;
			SetDragAmount(relativePositionOnReset.x, relativePositionOnReset.y, updateScrollbars: true);
		}
		if (!Application.isPlaying)
		{
			return;
		}
		float num = UpdateRealTimeDelta();
		if (showScrollBars != ShowCondition.Always)
		{
			bool flag = false;
			bool flag2 = false;
			if (showScrollBars != ShowCondition.WhenDragging || mDragID != -10 || mMomentum.magnitude > 0.01f)
			{
				flag = shouldMoveVertically;
				flag2 = shouldMoveHorizontally;
			}
			if ((bool)verticalScrollBar)
			{
				float alpha = verticalScrollBar.alpha;
				alpha += ((!flag) ? ((0f - num) * 3f) : (num * 6f));
				alpha = Mathf.Clamp01(alpha);
				if (verticalScrollBar.alpha != alpha)
				{
					verticalScrollBar.alpha = alpha;
				}
			}
			if ((bool)horizontalScrollBar)
			{
				float alpha2 = horizontalScrollBar.alpha;
				alpha2 += ((!flag2) ? ((0f - num) * 3f) : (num * 6f));
				alpha2 = Mathf.Clamp01(alpha2);
				if (horizontalScrollBar.alpha != alpha2)
				{
					horizontalScrollBar.alpha = alpha2;
				}
			}
		}
		if (!mPressed && mIsDragging && mMomentum.magnitude < 0.01f)
		{
			mIsDragging = false;
			if (onMovementFinished != null)
			{
				onMovementFinished();
			}
		}
		if (mShouldMove && !mPressed)
		{
			mMomentum -= scale * (mScroll * 0.05f);
			if (mMomentum.magnitude > 0.0001f)
			{
				mScroll = NGUIMath.SpringLerp(mScroll, 0f, 20f, num);
				Vector3 absolute = NGUIMath.SpringDampen(ref mMomentum, 9f, num);
				MoveAbsolute(absolute);
				if (restrictWithinPanel)
				{
					RestrictWithinBounds(instant: false);
				}
				if (mMomentum.magnitude < 0.0001f && onDragFinished != null)
				{
					onDragFinished();
				}
				return;
			}
			mScroll = 0f;
			mMomentum = Vector3.zero;
		}
		else
		{
			mScroll = 0f;
		}
		NGUIMath.SpringDampen(ref mMomentum, 9f, num);
	}
}
