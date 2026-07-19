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

		public bool swiping
		{
			get
			{
				return mFingerId.HasValue;
			}
		}

		public bool swipeStarted
		{
			get
			{
				return mSwipeStarted;
			}
		}

		public bool swipeDone
		{
			get
			{
				return mSwipeDone;
			}
		}

		public Vector2 swipeStart
		{
			get
			{
				return mSwipeStart;
			}
		}

		public Vector2 swipeEnd
		{
			get
			{
				return mSwipeEnd;
			}
		}

		public Vector2 swipePosition
		{
			get
			{
				return (!mSwipePosition.HasValue) ? Vector2.zero : mSwipePosition.Value;
			}
		}

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

	public bool isTapping
	{
		get
		{
			return mIsTapping;
		}
	}

	public bool isTappingStarted
	{
		get
		{
			return mIsTapStarted;
		}
	}

	public RawSwipeInputController rawSwipeInput
	{
		get
		{
			return mRawSwipeInput;
		}
	}

	public bool isSwipe
	{
		get
		{
			return mIsSwipe;
		}
	}

	public bool swipeEnded
	{
		get
		{
			return mSwipeEnded;
		}
	}

	public Vector3 pressPosition
	{
		get
		{
			return mPressPos;
		}
	}

	public Vector3 touchPosition
	{
		get
		{
			return Input.mousePosition;
		}
	}

	public Vector3 swipePosition
	{
		get
		{
			return mSwipePosition;
		}
	}

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
