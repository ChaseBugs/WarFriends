using System;
using UnityEngine;

public class InputController : Singleton<InputController>
{
	public class RawSwipeInputController
	{
		private int? mFingerId;

		private Vector2? mSwipePosition;

		private Vector2 mSwipeStart;

		private Vector2 mSwipeEnd;

		private bool mSwipeDone;

		private bool mSwipeStarted;

		public bool swiping => mFingerId.HasValue;

		public bool swipeStarted => mSwipeStarted;

		public bool swipeDone => mSwipeDone;

		public Vector2 swipeStart => mSwipeStart;

		public Vector2 swipeEnd => mSwipeEnd;

		public Vector2 swipePosition => (!mSwipePosition.HasValue) ? Vector2.zero : mSwipePosition.Value;

		public void Update()
		{
			mSwipeDone = false;
			mSwipeStarted = false;
			if (!mFingerId.HasValue && Input.GetMouseButton(0))
			{
				mFingerId = 0;
				mSwipeStarted = true;
				mSwipeStart = Input.mousePosition;
			}
			if (mFingerId.HasValue)
			{
				if (Input.GetMouseButtonUp(0))
				{
					mSwipeDone = true;
					mSwipeEnd = Input.mousePosition;
				}
				mSwipePosition = Input.mousePosition;
				if (!mSwipePosition.HasValue || mSwipeDone)
				{
					mFingerId = null;
				}
			}
		}
	}

	public float timeToDetectTap = 0.1f;

	public float swipeMinLength = 0.05f;

	private float diagonal;

	private Vector3 mPressPos;

	private bool mIsTapping;

	private bool mIsTapStarted;

	private bool mIsSwipe;

	private bool mSwipeEnded;

	private Vector3 mSwipePosition;

	private bool mClickProcessed;

	private float mAccumTime;

	private RawSwipeInputController mRawSwipeInput;

	public bool isTapping => mIsTapping;

	public bool isTappingStarted => mIsTapStarted;

	public RawSwipeInputController rawSwipeInput => mRawSwipeInput;

	public bool isSwipe => mIsSwipe;

	public bool swipeEnded => mSwipeEnded;

	public Vector3 pressPosition => mPressPos;

	public Vector3 touchPosition => Input.mousePosition;

	public Vector3 swipePosition => mSwipePosition;

	protected override void Awake()
	{
		base.Awake();
		mRawSwipeInput = new RawSwipeInputController();
		diagonal = (float)Math.Sqrt(Screen.width * Screen.width + Screen.height * Screen.height);
	}

	protected override void Start()
	{
		base.Start();
		Debug.LogWarningFormat("InputController - Start");
	}

	protected void Update()
	{
		mRawSwipeInput.Update();
		mIsTapStarted = false;
		mSwipeEnded = false;
		if (!Input.GetMouseButton(0) && mClickProcessed)
		{
			mIsTapping = false;
		}
		if (Input.GetMouseButtonUp(0))
		{
			if (!mClickProcessed)
			{
				mClickProcessed = true;
				if (Vector3.Distance(Input.mousePosition, pressPosition) > swipeMinLength * diagonal)
				{
					mIsSwipe = true;
					mIsTapping = false;
				}
				else
				{
					mIsSwipe = false;
					mIsTapping = true;
					mIsTapStarted = true;
				}
			}
			if (mIsSwipe)
			{
				mSwipePosition = Input.mousePosition;
				mSwipeEnded = true;
			}
		}
		if (Input.GetMouseButtonDown(0))
		{
			mPressPos = Input.mousePosition;
			mClickProcessed = false;
			mIsTapStarted = false;
			mAccumTime = 0f - Time.unscaledDeltaTime;
		}
		if (!Input.GetMouseButton(0))
		{
			return;
		}
		mAccumTime += Time.unscaledDeltaTime;
		if (mAccumTime > timeToDetectTap && !mClickProcessed)
		{
			mClickProcessed = true;
			if (Vector3.Distance(Input.mousePosition, pressPosition) > swipeMinLength * diagonal)
			{
				mIsSwipe = true;
				mIsTapping = false;
			}
			else
			{
				mIsSwipe = false;
				mIsTapping = true;
				mIsTapStarted = true;
			}
		}
	}

	public void CancelClick()
	{
		mClickProcessed = true;
	}
}
