using System;
using UnityEngine;

public class CircleProgress : Core_BaseScript
{
	[Header("Circle Part")]
	public GameObject circlePartPrefab;

	[Header("Recolor Parts")]
	public bool recolor;

	public Color backColor = Colours.backCircle;

	public Color frontColor = Colours.frontCircle;

	[Header("Constants")]
	public float multiplierConstant = 1.5f;

	public int lengthOfPart = 30;

	private float mRadius = 334f;

	private UISprite[] parts = new UISprite[180];

	private float mLastProgress;

	private bool mCircleCreated;

	private bool mDeliveringAnimation;

	private float mDelTime;

	private int mLoadingDeliver;

	private bool mFirstRound;

	private bool mAfterAnimation;

	private int mAfterStep;

	public bool deliveringAnimation
	{
		get
		{
			return mDeliveringAnimation;
		}
		set
		{
			if (mDeliveringAnimation != value)
			{
				mDeliveringAnimation = value;
				if (value)
				{
					mAfterAnimation = false;
					mDelTime = 0f;
					mLoadingDeliver = 0;
					mFirstRound = true;
				}
				else
				{
					mAfterAnimation = true;
					mAfterStep = 0;
				}
			}
		}
	}

	public void CreateCircle()
	{
		if (!mCircleCreated)
		{
			backColor = Colours.backCircle;
			frontColor = Colours.frontCircle;
			for (int i = 0; i < 180; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(circlePartPrefab);
				gameObject.name = "Circle Part " + i;
				gameObject.gameObject.SetActive(value: true);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = circlePartPrefab.transform.localScale;
				gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 180 - i * 2);
				gameObject.transform.localPosition = new Vector3(mRadius * Mathf.Cos((float)(-90 - 2 * i) * ((float)Math.PI / 180f)), mRadius * Mathf.Sin((float)(-90 - 2 * i) * ((float)Math.PI / 180f)), 0f);
				parts[i] = gameObject.GetComponent<UISprite>();
				parts[i].color = backColor;
			}
			mCircleCreated = true;
		}
	}

	public void FillCircle(float progress)
	{
		if (!mCircleCreated)
		{
			CreateCircle();
		}
		mDeliveringAnimation = false;
		mLastProgress = Mathf.Clamp01(progress);
		if (mLastProgress == 0f)
		{
			mLastProgress = -0.01f;
		}
		for (int i = 0; i < 180; i++)
		{
			parts[i].color = ((!((float)i / 180f > mLastProgress)) ? frontColor : backColor);
		}
	}

	public void StartStopAnim()
	{
		deliveringAnimation = !mDeliveringAnimation;
	}

	public void PlayEndAnimation()
	{
		mDeliveringAnimation = false;
		mAfterAnimation = true;
		mAfterStep = 0;
	}

	protected void Update()
	{
		if (recolor)
		{
			FillCircle(mLastProgress);
			recolor = false;
		}
		if (mDeliveringAnimation)
		{
			DeliveringAnimation();
		}
		if (mAfterAnimation)
		{
			AfterAnimationStepper();
		}
	}

	private void DeliveringAnimation()
	{
		mDelTime += Time.deltaTime;
		if (!(mDelTime < 0f))
		{
			int num = Mathf.FloorToInt(mDelTime * 60f);
			mDelTime -= (float)num / 60f;
			mLoadingDeliver += Mathf.FloorToInt(multiplierConstant * (float)num);
			if (mLoadingDeliver > 179)
			{
				mLoadingDeliver -= 180;
				mFirstRound = false;
			}
			if (!mCircleCreated)
			{
				CreateCircle();
			}
			for (int i = 0; i < 180; i++)
			{
				int num2 = mLoadingDeliver;
				int num3 = ((mLoadingDeliver - lengthOfPart >= 0) ? (mLoadingDeliver - lengthOfPart) : ((!mFirstRound) ? (180 + (mLoadingDeliver - lengthOfPart)) : 180));
				parts[i].color = (((num2 <= i || num2 - lengthOfPart >= i) && (num3 >= i || num3 + lengthOfPart <= i)) ? backColor : frontColor);
			}
		}
	}

	private void AfterAnimationStepper()
	{
		switch (mAfterStep)
		{
		case 0:
			mAfterStep = FillCircleStep(mAfterStep);
			break;
		case 1:
			mAfterStep = WaitStep(mAfterStep);
			break;
		case 2:
			mAfterStep = EmptyCircleStep(mAfterStep);
			break;
		case 3:
			mAfterStep = WaitStep(mAfterStep);
			break;
		case 4:
			mAfterStep = FillCircleStep(mAfterStep);
			break;
		case 5:
			mAfterStep = WaitStep(mAfterStep);
			break;
		case 6:
			mAfterStep = EmptyCircleStep(mAfterStep);
			break;
		case 7:
			mAfterStep = WaitStep(mAfterStep);
			break;
		case 8:
			mAfterStep = FillCircleStep(mAfterStep);
			break;
		case 9:
			mAfterStep = WaitStep(mAfterStep);
			break;
		case 10:
			mAfterStep = EmptyCircleStep(mAfterStep);
			break;
		case 11:
			mAfterStep = WaitStep(mAfterStep);
			break;
		default:
			FillCircle(mLastProgress);
			mAfterAnimation = false;
			break;
		}
	}

	private int WaitStep(int actualStep)
	{
		mDelTime += Time.deltaTime;
		if (mDelTime > 0.07f)
		{
			return actualStep + 1;
		}
		return actualStep;
	}

	private int FillCircleStep(int actualStep)
	{
		if (!mCircleCreated)
		{
			CreateCircle();
		}
		for (int i = 0; i < 180; i++)
		{
			parts[i].color = frontColor;
		}
		mDelTime = 0f;
		return actualStep + 1;
	}

	private int EmptyCircleStep(int actualStep)
	{
		if (!mCircleCreated)
		{
			CreateCircle();
		}
		for (int i = 0; i < 180; i++)
		{
			parts[i].color = backColor;
		}
		mDelTime = 0f;
		return actualStep + 1;
	}
}
