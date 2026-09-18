using System;
using UnityEngine;

public class CraftResult : Core_BaseScript
{
	public enum State
	{
		None,
		Craft,
		Crafting,
		Ready
	}

	[Header("Core")]
	public UISprite backgroundAnimation;

	public UISprite warcardBackground;

	public UIPanel panel;

	public UISprite questionMark;

	[Header("Craft Button")]
	public GameObject craftButton;

	public UISprite craftButtonBackground;

	public UILabel craftButtonLabel;

	[Header("Progress Part")]
	public GameObject progressPart;

	public UISprite progressBar;

	public WinStreakCounter progressTime;

	[Header("Claim Button")]
	public GameObject claimButton;

	public UISprite claimButtonBackground;

	public UILabel claimButtonLabel;

	[Header("Waiting Part")]
	public GameObject waitingPart;

	private State mCurrentState;

	private State mPreviousState;

	private float mTimeLength;

	public void Initialize(State newState, bool initialization = false)
	{
		waitingPart.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		questionMark.gameObject.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
		mCurrentState = newState;
		if (initialization)
		{
			mPreviousState = mCurrentState;
		}
		progressPart.SetActive(mCurrentState == State.Crafting);
		InitializeAnimations(mPreviousState, mCurrentState);
		mPreviousState = mCurrentState;
		progressTime.StopCountingTo();
		WinStreakCounter winStreakCounter = progressTime;
		winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(EndOfTimer));
	}

	public void SetWarcardBackground(CardManager.CardType rarity)
	{
		bool flag = rarity == CardManager.CardType.Silver;
		warcardBackground.spriteName = Card.CardBackground((!flag) ? CardManager.CardType.Silver : CardManager.CardType.Gold);
	}

	public void SetCrafting(bool initialization = false)
	{
		Initialize(State.Crafting, initialization);
		mTimeLength = CardCraftingManager.instance.endCraftingTime - CardCraftingManager.instance.startCraftingTime;
		progressTime.StartCountingTo(CardCraftingManager.instance.endCraftingTime);
		WinStreakCounter winStreakCounter = progressTime;
		winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(EndOfTimer));
		WinStreakCounter winStreakCounter2 = progressTime;
		winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(EndOfTimer));
	}

	private void EndOfTimer()
	{
		GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.InitializeArrowsAnimations();
		Initialize(State.Ready);
	}

	protected void Update()
	{
		if (mCurrentState == State.Crafting)
		{
			progressBar.fillAmount = Mathf.Clamp01((float)(Singleton<BeanstalkServerManager>.instance.currentTimestamp - CardCraftingManager.instance.startCraftingTime) / mTimeLength);
		}
	}

	private void InitializeAnimations(State previousState, State currentState)
	{
		if (currentState == previousState)
		{
			StateAnimation(currentState);
		}
		else
		{
			ChangeAnimation(previousState, currentState);
		}
	}

	private void StateAnimation(State currentState)
	{
		waitingPart.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		questionMark.gameObject.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
		BackgroundAnimation();
		ClaimButtonAnimation(mCurrentState == State.Ready, 0.01f, mCurrentState);
		QuestionMarkAnimation(currentState);
		CraftButtonAnimation(mCurrentState == State.Craft, 0.01f);
		progressPart.SetActive(currentState == State.Crafting);
		if (currentState == State.None)
		{
			Debug.Log("Animation for State: None");
			if (warcardBackground.gameObject.activeSelf)
			{
				TweenAlpha.Begin(warcardBackground.gameObject, 0.01f, 0f).onFinished = delegate
				{
					warcardBackground.gameObject.SetActive(value: false);
				};
			}
		}
		if (currentState == State.Craft)
		{
			Debug.Log("Animation for State: Craft");
			warcardBackground.gameObject.SetActive(value: true);
			TweenAlpha.Begin(warcardBackground.gameObject, 0.01f, 0.75f).onFinished = null;
		}
		if (currentState == State.Crafting)
		{
			Debug.Log("Animation for State: Crafting");
			warcardBackground.gameObject.SetActive(value: true);
			TweenAlpha.Begin(warcardBackground.gameObject, 0.01f, 1f).onFinished = null;
		}
		if (currentState == State.Ready)
		{
			Debug.Log("Animation for State: Ready");
			warcardBackground.gameObject.SetActive(value: true);
			TweenAlpha.Begin(warcardBackground.gameObject, 0.01f, 1f).onFinished = null;
		}
	}

	private void BackgroundAnimation()
	{
		if (mPreviousState == State.Craft)
		{
			LoopBackgroundAnimation();
		}
		else
		{
			StopBackgroundAnimation();
		}
	}

	private void LoopBackgroundAnimation()
	{
		float duration = 1f;
		float num = 0.75f;
		float toAlpha = 0.1f;
		Vector3 vector = new Vector3(319f, 375f, 1f);
		Vector3 toScale = vector * 1.4f;
		toScale.z = 1f;
		TweenAlpha.Begin(backgroundAnimation.gameObject, duration, num, toAlpha).method = UITweener.Method.EaseOut;
		backgroundAnimation.alpha = num;
		TweenScale tweenScale = TweenScale.Begin(backgroundAnimation.gameObject, duration, vector, toScale);
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.onFinished = delegate
		{
			BackgroundAnimation();
		};
		backgroundAnimation.transform.localScale = vector;
	}

	private void StopBackgroundAnimation()
	{
		backgroundAnimation.alpha = 0f;
		TweenAlpha component = backgroundAnimation.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		backgroundAnimation.transform.localScale = new Vector3(319f, 375f, 1f);
		TweenScale component2 = backgroundAnimation.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
			component2.onFinished = null;
		}
	}

	private void QuestionMarkAnimation(State currentState)
	{
		if (questionMark.gameObject.activeSelf)
		{
			TweenPosition.Begin(questionMark.gameObject, 0.01f, new Vector3(0f, (mCurrentState != State.None) ? 23f : 0f, 0f));
			if (currentState == State.Ready)
			{
				QuestionMarkScaling();
			}
			else
			{
				StopQuestionMarkScaling();
			}
		}
	}

	private void QuestionMarkScaling()
	{
		TweenScale tweenScale = TweenScale.Begin(questionMark.gameObject, 0.4f, new Vector3(95f, 149f, 1f), new Vector3(114.00001f, 178.8f, 1f));
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.style = UITweener.Style.PingPong;
		tweenScale.NumOfRepetitions = 2;
		tweenScale.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(questionMark.gameObject, 0.4f, new Vector3(95f, 149f, 1f), new Vector3(95f, 149f, 1f));
			tweenScale2.method = UITweener.Method.Linear;
			tweenScale2.style = UITweener.Style.Once;
			tweenScale2.NumOfRepetitions = 1;
			tweenScale2.onFinished = delegate
			{
				QuestionMarkScaling();
			};
		};
	}

	private void StopQuestionMarkScaling()
	{
		TweenScale tweenScale = TweenScale.Begin(questionMark.gameObject, 0.01f, new Vector3(95f, 149f, 1f));
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
		tweenScale.onFinished = null;
	}

	private void ChangeAnimation(State previousState, State currentState)
	{
		float dur = 0.25f;
		if (previousState == State.None && currentState == State.Craft)
		{
			Debug.Log("Animation from State: None to State: Craft");
			waitingPart.SetActive(value: false);
			questionMark.gameObject.SetActive(value: true);
			warcardBackground.gameObject.SetActive(value: true);
			TweenAlpha.Begin(warcardBackground.gameObject, dur, 0f, 0.75f).onFinished = delegate
			{
				TweenPosition tweenPosition3 = TweenPosition.Begin(questionMark.gameObject, dur, new Vector3(0f, 0f, 0f), new Vector3(0f, 30f, 0f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					CraftButtonAnimation(show: true, dur);
					TweenPosition tweenPosition4 = TweenPosition.Begin(questionMark.gameObject, dur, new Vector3(0f, 23f, 0f));
					tweenPosition4.method = UITweener.Method.EaseOut;
					tweenPosition4.onFinished = delegate
					{
						StateAnimation(State.Craft);
					};
				};
			};
		}
		if (previousState == State.Craft && currentState == State.Crafting)
		{
			Debug.Log("Animation from State: Craft to State: Crafting");
			float fromAlpha = 0.75f;
			float toAlpha = 1f;
			CraftButtonAnimation(show: false, dur);
			warcardBackground.gameObject.SetActive(value: true);
			TweenAlpha.Begin(warcardBackground.gameObject, dur, fromAlpha, toAlpha).onFinished = delegate
			{
				progressPart.SetActive(value: true);
				StopBackgroundAnimation();
				FlashingBackground(2, State.Crafting);
			};
		}
		if (previousState == State.Crafting && currentState == State.Ready)
		{
			Debug.Log("Animation from State: Crafting to State: Ready");
			progressPart.SetActive(value: false);
			ClaimButtonAnimation(show: true, dur, State.Ready);
		}
		if (previousState == State.Ready && currentState == State.None)
		{
			Debug.Log("Animation from State: Ready to State: None");
			waitingPart.SetActive(value: false);
			questionMark.gameObject.SetActive(value: true);
			StopQuestionMarkScaling();
			TweenPosition tweenPosition = TweenPosition.Begin(questionMark.gameObject, dur, new Vector3(0f, 0f, 0f));
			tweenPosition.onFinished = delegate
			{
				TweenAlpha.Begin(warcardBackground.gameObject, dur, 0f).onFinished = delegate
				{
					warcardBackground.gameObject.SetActive(value: false);
					StateAnimation(State.None);
				};
			};
		}
		if (previousState != State.Craft || currentState != State.None)
		{
			return;
		}
		Debug.Log("Animation from State: Craft to State: None");
		CraftButtonAnimation(show: false, dur);
		waitingPart.SetActive(value: false);
		questionMark.gameObject.SetActive(value: true);
		TweenPosition tweenPosition2 = TweenPosition.Begin(questionMark.gameObject, dur, new Vector3(0f, 0f, 0f));
		tweenPosition2.onFinished = delegate
		{
			warcardBackground.gameObject.SetActive(value: true);
			TweenAlpha.Begin(warcardBackground.gameObject, dur, 0f).onFinished = delegate
			{
				warcardBackground.gameObject.SetActive(value: false);
				StateAnimation(State.None);
			};
		};
	}

	private void CraftButtonAnimation(bool show, float dur)
	{
		if (show)
		{
			craftButton.SetActive(value: true);
			craftButton.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
			craftButtonBackground.alpha = 0f;
			craftButtonLabel.alpha = 0f;
		}
		if (craftButton.activeSelf)
		{
			TweenScale.Begin(craftButton, dur, (!show) ? Vector3.one : new Vector3(1.2f, 1.2f, 1f), (!show) ? new Vector3(1.2f, 1.2f, 1f) : Vector3.one);
			TweenAlpha.Begin(craftButtonBackground.gameObject, dur, (!show) ? 1f : 0f, (!show) ? 0f : 1f);
			TweenAlpha.Begin(craftButtonLabel.gameObject, dur, (!show) ? 1f : 0f, (!show) ? 0f : 1f).onFinished = delegate
			{
				craftButton.SetActive(show);
			};
		}
	}

	private void ClaimButtonAnimation(bool show, float dur, State newState)
	{
		if (show)
		{
			waitingPart.SetActive(CardCraftingManager.instance.waitingForServerResponse);
			questionMark.gameObject.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
			claimButton.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
			claimButton.transform.localScale = new Vector3(1f, 1f, 1f);
			claimButtonBackground.alpha = 0f;
			claimButtonLabel.alpha = 0f;
		}
		if (!claimButton.activeSelf)
		{
			return;
		}
		TweenScale.Begin(claimButton, dur, (!show) ? Vector3.one : new Vector3(1.2f, 1.2f, 1f), (!show) ? new Vector3(1.2f, 1.2f, 1f) : Vector3.one);
		TweenAlpha.Begin(claimButtonBackground.gameObject, dur, (!show) ? 1f : 0f, (!show) ? 0f : 1f);
		TweenAlpha.Begin(claimButtonLabel.gameObject, dur, (!show) ? 1f : 0f, (!show) ? 0f : 1f).onFinished = delegate
		{
			claimButton.SetActive(show);
			if (dur > 0.1f)
			{
				StateAnimation(newState);
			}
		};
	}

	private void FlashingBackground(int count, State newState)
	{
		float dur = 0.15f;
		float minAlpha = 0.75f;
		float maxAlpha = 1f;
		if (count == 0)
		{
			StateAnimation(newState);
			return;
		}
		warcardBackground.gameObject.SetActive(value: true);
		TweenAlpha.Begin(warcardBackground.gameObject, dur, maxAlpha, minAlpha).onFinished = delegate
		{
			TweenAlpha.Begin(warcardBackground.gameObject, dur, minAlpha, maxAlpha).onFinished = delegate
			{
				FlashingBackground(count - 1, newState);
			};
		};
	}
}
