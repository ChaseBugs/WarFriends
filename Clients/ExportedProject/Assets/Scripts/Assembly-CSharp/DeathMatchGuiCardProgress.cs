using System.Collections.Generic;
using UnityEngine;

public class DeathMatchGuiCardProgress : Core_BaseScript
{
	private const float mWidth = 172f;

	private const float mDividerWidth = 2f;

	[Header("Setting")]
	public float popAmount = 1.1f;

	public float popDelay = 0.2f;

	[Header("Core")]
	public List<UISprite> bars;

	public List<UISprite> newBars;

	public List<UISprite> dividers;

	public List<UISprite> deployIcons;

	public UILabel deploy;

	public UISprite deployBackground;

	[Header("Tutorial")]
	public UISprite tutorialOverlay;

	private int mBarCount;

	private int mLastPowerLeft;

	private float mBarWidth;

	private float mBarHeight;

	private float mPopTimer;

	private bool mIsEmpty;

	public void Show(SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition)
	{
		deploy.gameObject.SetActive(value: false);
		mIsEmpty = armyUnitDefinition == null;
		mBarCount = ((armyUnitDefinition == null) ? 1 : Mathf.Min(4, armyUnitDefinition.power));
		if (!mIsEmpty && armyUnitDefinition.power > 4)
		{
			Debug.LogWarning($"Unit Power is out of range index {armyUnitDefinition.index} power {armyUnitDefinition.power}");
		}
		foreach (UISprite bar in bars)
		{
			SetBar(bar, active: false);
			bar.fillAmount = 1f;
		}
		foreach (UISprite newBar in newBars)
		{
			newBar.gameObject.SetActive(value: false);
		}
		foreach (UISprite divider in dividers)
		{
			divider.gameObject.SetActive(value: false);
		}
		for (int i = 0; i < deployIcons.Count; i++)
		{
			deployIcons[i].gameObject.SetActive(value: false);
			SetDeploy(i);
		}
		mBarWidth = (172f - 2f * (float)(mBarCount - 1 + 2)) / (float)mBarCount;
		mBarHeight = bars[0].transform.localScale.y;
		float num = -84f;
		for (int j = 0; j < mBarCount; j++)
		{
			UISprite uISprite = bars[j];
			SetBar(uISprite, active: true);
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(mBarWidth);
			uISprite.transform.localPosition = uISprite.transform.localPosition.ReplaceX(num + mBarWidth * (float)(j + 1) + 2f * (float)j);
		}
		for (int k = 0; k < mBarCount; k++)
		{
			UISprite uISprite2 = newBars[k];
			uISprite2.transform.localScale = uISprite2.transform.localScale.ReplaceX(mBarWidth);
			uISprite2.transform.localPosition = uISprite2.transform.localPosition.ReplaceX(num + mBarWidth * ((float)k + 0.5f) + 2f * (float)k);
		}
		for (int l = 0; l < mBarCount - 1; l++)
		{
			UISprite uISprite3 = dividers[l];
			uISprite3.gameObject.SetActive(value: true);
			uISprite3.transform.localPosition = uISprite3.transform.localPosition.ReplaceX(num + mBarWidth * (float)(l + 1) + 2f * ((float)l + 0.5f));
		}
		if (!mIsEmpty)
		{
			for (int m = 0; m < mBarCount; m++)
			{
				UISprite uISprite4 = deployIcons[m];
				uISprite4.gameObject.SetActive(value: true);
				TweenAlpha component = uISprite4.gameObject.GetComponent<TweenAlpha>();
				if (component != null)
				{
					component.enabled = false;
				}
				uISprite4.transform.localPosition = uISprite4.transform.localPosition.ReplaceX(num + mBarWidth * ((float)m + 0.5f) + 2f * (float)m);
			}
		}
		mLastPowerLeft = Singleton<SpawningManagerDeathMatch>.instance.powerLeft;
		mPopTimer = 0f;
		DoUpdate(forceUpdate: true);
	}

	public void StartTutorialAnimation(int index)
	{
		tutorialOverlay.gameObject.SetActive(value: true);
		float num = ((index % 2 != 0) ? 0.1f : 0.5f);
		float toAlpha = ((index % 2 != 0) ? 0.5f : 0.1f);
		tutorialOverlay.alpha = num;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(tutorialOverlay.gameObject, 0.8f, num, toAlpha);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.style = UITweener.Style.PingPong;
		Vector3 fromScale = ((index % 2 != 0) ? new Vector3(150f, 36f, 1f) : new Vector3(180f, 53f, 1f));
		Vector3 toScale = ((index % 2 != 0) ? new Vector3(180f, 53f, 1f) : new Vector3(150f, 36f, 1f));
		TweenScale tweenScale = TweenScale.Begin(tutorialOverlay.gameObject, 0.8f, fromScale, toScale);
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = UITweener.Style.PingPong;
	}

	public void StopTutorialAnimation()
	{
		tutorialOverlay.gameObject.SetActive(value: false);
	}

	public void DoUpdate(bool forceUpdate = false)
	{
		mPopTimer -= TimeManager.deltaTimeWithoutPauses;
		if (mLastPowerLeft == (int)Singleton<SpawningManagerDeathMatch>.instance.powerLeft && !forceUpdate)
		{
			return;
		}
		if (mLastPowerLeft > (int)Singleton<SpawningManagerDeathMatch>.instance.powerLeft || forceUpdate || mIsEmpty)
		{
			mLastPowerLeft = Singleton<SpawningManagerDeathMatch>.instance.powerLeft;
			for (int i = 0; i < mBarCount; i++)
			{
				UISprite bar = bars[i];
				bool flag = !mIsEmpty && i < mLastPowerLeft;
				SetBar(bar, !flag);
				SetDeploy(i);
			}
			if (mLastPowerLeft >= mBarCount && !mIsEmpty)
			{
				ShowDeploy(animate: false);
			}
			else
			{
				HideDeploy();
			}
		}
		else if (mPopTimer <= 0f)
		{
			ShowNewBar(mLastPowerLeft);
			mLastPowerLeft++;
			mPopTimer = popDelay;
		}
	}

	private void ShowNewBar(int index)
	{
		if (index < 0 || index >= mBarCount)
		{
			return;
		}
		UISprite bar = bars[index];
		UISprite newBar = newBars[index];
		newBar.gameObject.SetActive(value: true);
		TweenAlpha.Begin(newBar.gameObject, 0.2f, 0f, 1f);
		TweenScale tweenScale = TweenScale.Begin(newBar.gameObject, 0.2f, Vector3.zero, new Vector3(popAmount * mBarWidth, popAmount * mBarHeight, 1f));
		tweenScale.method = UITweener.Method.EaseOut;
		tweenScale.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(newBar.gameObject, 0.2f, new Vector3(popAmount * mBarWidth, popAmount * mBarHeight, 1f), new Vector3(mBarWidth, mBarHeight, 1f));
			tweenScale2.method = UITweener.Method.EaseIn;
			tweenScale2.onFinished = delegate
			{
				newBar.gameObject.SetActive(value: false);
				bool flag = index < mLastPowerLeft;
				SetBar(bar, !flag);
				SetDeploy(index);
			};
			if (index == mBarCount - 1)
			{
				ShowDeploy(animate: true);
			}
		};
	}

	private void ShowDeploy(bool animate)
	{
		deployBackground.gameObject.SetActive(value: true);
		TweenAlpha.Begin(deployBackground.gameObject, 0.1f, 1f);
	}

	private void HideDeploy()
	{
		TweenAlpha.Begin(deployBackground.gameObject, 0f, 1f);
		deployBackground.gameObject.SetActive(value: false);
		if (!mIsEmpty)
		{
			for (int i = 0; i < mBarCount; i++)
			{
				UISprite uISprite = deployIcons[i];
				uISprite.gameObject.SetActive(value: true);
				SetDeploy(i);
			}
		}
	}

	private void SetBar(UISprite bar, bool active)
	{
		bar.alpha = ((!active) ? 0f : 0.7f);
	}

	private void SetDeploy(int index)
	{
		UISprite uISprite = deployIcons[index];
		bool flag = index < mLastPowerLeft;
		TweenAlpha component = uISprite.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		if (flag)
		{
			uISprite.color = Color.white;
		}
		else
		{
			uISprite.color = Colours.blue.ReplaceA(0.6f);
		}
	}
}
