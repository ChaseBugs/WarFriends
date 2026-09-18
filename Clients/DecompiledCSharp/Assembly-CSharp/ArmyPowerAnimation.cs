using UnityEngine;

public class ArmyPowerAnimation : Core_BaseScript
{
	[Header("Animation Objects")]
	public UISprite armyPowerIcon;

	public UILabel armyPowerChange;

	public UILabel armyPowerNewValue;

	[Header("Animation Settings")]
	public float dur = 0.1f;

	public float sizeOfIcon;

	public Vector3 bottomPositionOfIcon;

	public Vector3 upPositionOfIcon;

	public Vector3 endPositionOfIcon;

	public float sizeOfText;

	public Vector3 rightPositionOfChange;

	public Vector3 stopPositionOfChange;

	public Vector3 upPositionOfChange;

	public Vector3 bottomPositionOfValue;

	public float apChangeTextStartYDiff;

	private Vector3 mTextSize;

	private Vector3 mIconSize;

	public void SetUpAnimation(float heightOfIcon, float textSize, Vector3 startBottom, Vector3 startLeft, Vector3 middleUp, Vector3 middleRight, Vector3 endBottom, Vector3 endMiddle, Vector3 endUp)
	{
		sizeOfIcon = heightOfIcon;
		sizeOfText = textSize;
		bottomPositionOfIcon = startBottom;
		upPositionOfIcon = middleUp;
		endPositionOfIcon = startLeft;
		rightPositionOfChange = middleRight;
		stopPositionOfChange = endMiddle;
		upPositionOfChange = endUp;
		bottomPositionOfValue = endBottom;
	}

	public void StartAnimation(int changeNumber, int valueEnd, float speed = 0f)
	{
		if (speed >= 0f)
		{
			dur = speed;
		}
		StopAllAnimations();
		if (changeNumber == 0)
		{
			return;
		}
		armyPowerChange.text = MiscTools.FormatMedalsDifference(changeNumber);
		armyPowerChange.color = ((changeNumber >= 0) ? Color.white : Colours.redMedals);
		armyPowerNewValue.text = MiscTools.FormatBigNumber(valueEnd);
		TweenAlpha.Begin(armyPowerIcon.gameObject, dur * 3f, 0f, 1f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(armyPowerIcon.gameObject, dur * 3f, bottomPositionOfIcon, upPositionOfIcon);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(armyPowerIcon.gameObject, dur * 2f, endPositionOfIcon);
			tweenPosition2.method = UITweener.Method.EaseOut;
		};
		TweenAlpha.Begin(armyPowerChange.gameObject, dur * 1f, 0f, 1f).onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(armyPowerChange.gameObject, dur * 3f, new Vector3(endPositionOfIcon.x, endPositionOfIcon.y - apChangeTextStartYDiff, rightPositionOfChange.z), rightPositionOfChange);
			tweenPosition2.method = UITweener.Method.EaseIn;
			tweenPosition2.onFinished = delegate
			{
				TweenPosition tweenPosition3 = TweenPosition.Begin(armyPowerChange.gameObject, dur * 2f, stopPositionOfChange);
				tweenPosition3.method = UITweener.Method.EaseOut;
				tweenPosition3.onFinished = delegate
				{
					TweenAlpha.Begin(armyPowerIcon.gameObject, dur * 3f, 1f, 1f).onFinished = delegate
					{
						DisplayEnd();
					};
				};
			};
		};
	}

	private void SpecialAnimation(int valueEnd)
	{
		armyPowerNewValue.text = MiscTools.FormatBigNumber(valueEnd);
		TweenAlpha.Begin(armyPowerIcon.gameObject, dur * 3f, 0f, 1f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(armyPowerIcon.gameObject, dur * 3f, bottomPositionOfIcon, upPositionOfIcon);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(armyPowerIcon.gameObject, dur * 2f, endPositionOfIcon);
			tweenPosition2.method = UITweener.Method.EaseOut;
			TweenAlpha.Begin(armyPowerNewValue.gameObject, dur * 2f, 0f, 1f).onFinished = null;
			TweenPosition tweenPosition3 = TweenPosition.Begin(armyPowerNewValue.gameObject, dur * 2f, bottomPositionOfValue, stopPositionOfChange);
			tweenPosition3.onFinished = delegate
			{
				TweenAlpha.Begin(armyPowerIcon.gameObject, dur * 3f, 1f).onFinished = delegate
				{
					TweenAlpha.Begin(armyPowerIcon.gameObject, dur * 3f, 1f, 0f).onFinished = null;
					TweenAlpha.Begin(armyPowerNewValue.gameObject, dur * 3f, 1f, 0f).onFinished = null;
					Vector3 toScale = mIconSize * 2f;
					toScale.z = 1f;
					Vector3 toScale2 = new Vector3(sizeOfText * 2f, sizeOfText * 2f, 1f);
					TweenScale.Begin(armyPowerIcon.gameObject, dur * 3f, mIconSize, toScale);
					TweenScale.Begin(armyPowerNewValue.gameObject, dur * 3f, mTextSize, toScale2);
				};
			};
		};
	}

	private void DisplayEnd()
	{
		TweenAlpha.Begin(armyPowerChange.gameObject, dur * 2f, 1f, 0f).onFinished = null;
		TweenPosition.Begin(armyPowerChange.gameObject, dur * 2f, stopPositionOfChange, upPositionOfChange).onFinished = null;
		TweenAlpha.Begin(armyPowerNewValue.gameObject, dur * 2f, 0f, 1f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(armyPowerNewValue.gameObject, dur * 2f, bottomPositionOfValue, stopPositionOfChange);
		tweenPosition.onFinished = delegate
		{
			TweenAlpha.Begin(armyPowerIcon.gameObject, dur * 3f, 1f).onFinished = delegate
			{
				TweenAlpha.Begin(armyPowerIcon.gameObject, dur * 3f, 1f, 0f).onFinished = null;
				TweenAlpha.Begin(armyPowerNewValue.gameObject, dur * 3f, 1f, 0f).onFinished = null;
				Vector3 toScale = mIconSize * 2f;
				toScale.z = 1f;
				Vector3 toScale2 = new Vector3(sizeOfText * 2f, sizeOfText * 2f, 1f);
				TweenScale.Begin(armyPowerIcon.gameObject, dur * 3f, mIconSize, toScale);
				TweenScale.Begin(armyPowerNewValue.gameObject, dur * 3f, mTextSize, toScale2);
			};
		};
	}

	public void StopAllAnimations()
	{
		InitializeAlphaZero();
		TweenPosition.Begin(armyPowerIcon.gameObject, 0f, bottomPositionOfIcon).onFinished = null;
		TweenPosition.Begin(armyPowerChange.gameObject, 0f, endPositionOfIcon).onFinished = null;
		TweenPosition.Begin(armyPowerNewValue.gameObject, 0f, bottomPositionOfValue).onFinished = null;
		SetStartSizeArmyPowerIcon();
		SetStartSizeText();
	}

	public void InitializeAlphaZero()
	{
		TweenAlpha.Begin(armyPowerIcon.gameObject, 0f, 0f).onFinished = null;
		TweenAlpha.Begin(armyPowerChange.gameObject, 0f, 0f).onFinished = null;
		TweenAlpha.Begin(armyPowerNewValue.gameObject, 0f, 0f).onFinished = null;
	}

	private void SetStartSizeArmyPowerIcon()
	{
		mIconSize = new Vector3(sizeOfIcon, sizeOfIcon * 61f / 49f, 1f);
		armyPowerIcon.transform.localScale = mIconSize;
		TweenScale.Begin(armyPowerIcon.gameObject, 0f, mIconSize);
	}

	private void SetStartSizeText()
	{
		mTextSize = new Vector3(sizeOfText, sizeOfText, 1f);
		armyPowerChange.transform.localScale = mTextSize;
		armyPowerNewValue.transform.localScale = mTextSize;
		TweenScale.Begin(armyPowerNewValue.gameObject, 0f, mTextSize);
	}
}
