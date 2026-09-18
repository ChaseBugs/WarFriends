using System.Collections;
using UnityEngine;

public class CardsGuiElement : GuiElement
{
	public UISprite highlight;

	[Header("Header")]
	public GameObject header;

	public UISprite headerBackground;

	public UILabel headerName;

	[Header("Card")]
	public GameObject cardContent;

	public UISprite cardIcon;

	public UITexture cardTexture;

	public UISprite cardBackground;

	public UISprite cardBonusIcon;

	public UILabel cardBonusName;

	public UISprite backOfCard;

	[Header("set in EDITOR - coop friend true, enemy false")]
	public bool displayFriends;

	[HideInInspector]
	public bool isPlaying;

	private Vector3 mStartPosition;

	private Vector3 mStartPositionCard;

	private float mDur = 0.2f;

	private Card mCard;

	private UIPanel mPanel;

	public Card card
	{
		get
		{
			return mCard;
		}
		private set
		{
			if (value == null && mCard != null)
			{
				mCard.HideInMenu();
			}
			mCard = value;
			if (mCard != null)
			{
				mCard.ShowInMenu();
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		CardManager.instance.CardUsed += InstanceOnCardUse;
		Singleton<GameController>.instance.BeforeGameStarted += InstanceOnBeforeGameStarted;
		Singleton<GameController>.instance.GameEnded += delegate
		{
			if (card != null)
			{
				card = null;
			}
		};
		isPlaying = false;
		mPanel = GetComponent<UIPanel>();
	}

	public override void InitControls()
	{
		base.transform.localPosition = ((!displayFriends) ? new Vector3(0f, -493f, 0f) : new Vector3(546f, 524f, 0f));
		mStartPosition = base.transform.localPosition;
		mStartPositionCard = cardContent.transform.localPosition;
		highlight.color = ((!displayFriends) ? Colours.redCardHeader : Colours.blue);
		headerBackground.color = ((!displayFriends) ? Colours.redCardHeader : Colours.blue);
	}

	private void InstanceOnBeforeGameStarted()
	{
		StopAllCoroutines();
		if (mPanel != null)
		{
			TweenAlpha.Begin(mPanel.gameObject, 0f, 0f);
		}
		ResetAnimation();
		base.gameObject.SetActive(value: false);
	}

	public override void InitGUIValues()
	{
		if (!displayFriends)
		{
			if (Singleton<GameController>.instance.isMission)
			{
				base.transform.localPosition = mStartPosition - new Vector3(0f, 116f, 0f);
			}
			else
			{
				base.transform.localPosition = mStartPosition - new Vector3(0f, 0f, 0f);
			}
		}
	}

	protected override void Update()
	{
		if (DebugSettings.debugEnabled)
		{
			if (Input.GetKeyDown(KeyCode.K))
			{
				InstanceOnCardUse(CardManager.instance.GetCardInstance("AMMOBOX"), Fractions.Enemies, isMine: false);
			}
			if (Input.GetKeyDown(KeyCode.P))
			{
				InstanceOnCardUse(CardManager.instance.GetCardInstance("AMMOBOX"), Fractions.Allies, isMine: false);
			}
		}
		if (isPlaying && mPanel != null)
		{
			mPanel.alpha1 = ((!Singleton<SniperScope>.instance.showed) ? 1f : 0.3f);
		}
		if (!cardTexture.gameObject.activeSelf && card != null && card.iconTexture != null)
		{
			cardIcon.gameObject.SetActive(value: false);
			cardTexture.gameObject.SetActive(value: true);
			cardTexture.mainTexture = card.iconTexture;
		}
	}

	private void ResetAnimation()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(highlight.gameObject, 0f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha = TweenAlpha.Begin(headerName.gameObject, 0f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha = TweenAlpha.Begin(headerBackground.gameObject, 0f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha = TweenAlpha.Begin(cardIcon.gameObject, 0f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha = TweenAlpha.Begin(cardTexture.gameObject, 0f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha = TweenAlpha.Begin(cardBackground.gameObject, 0f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha = TweenAlpha.Begin(cardBonusIcon.gameObject, 0f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha = TweenAlpha.Begin(cardBonusName.gameObject, 0f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha = TweenAlpha.Begin(backOfCard.gameObject, 0f, 0f);
		tweenAlpha.delay = 0f;
		TweenRotation.Begin(cardContent, 0f, Quaternion.identity);
		TweenScale.Begin(cardContent, 0f, Vector3.one);
		TweenPosition.Begin(cardContent, 0f, mStartPositionCard - new Vector3(0f, 50f, 0f));
		TweenAlpha.Begin(highlight.gameObject, 0f, 0f);
	}

	private void InstanceOnCardUse(Card usedCard, Fractions fraction, bool isMine)
	{
		Fractions fraction2 = PlayerController.currentPlayer.fraction;
		bool flag = fraction == fraction2 == displayFriends;
		if (!isMine && flag && usedCard.showInGame)
		{
			ResetAnimation();
			base.gameObject.SetActive(value: true);
			PlayCard(usedCard);
			PauseOtherAnimations();
		}
	}

	private void PauseOtherAnimations()
	{
		GuiElementSingle<KillStreakGuiElement>.instance.Stop();
		GuiElementSingle<RibbonGuiElement>.instance.Stop();
		GuiScreenSingle<HudScreen>.instance.StopHitArrow();
		isPlaying = true;
	}

	private void ResumeOtherAnimations()
	{
		GuiElementSingle<RibbonGuiElement>.instance.Resume();
		GuiElementSingle<KillStreakGuiElement>.instance.Resume();
		GuiScreenSingle<HudScreen>.instance.ResumeHitArrow();
		isPlaying = false;
	}

	private void PlayCard(Card playCard)
	{
		if (!(playCard == null))
		{
			card = playCard;
			card.SetUpSmallCard(cardBackground, cardIcon, cardBonusIcon, cardBonusName, cardTexture);
			headerName.text = card.cardName.ToUpper();
			headerBackground.transform.localScale = new Vector3(130f + headerName.relativeSize.x * headerName.transform.localScale.x, 74f, 1f);
			StartCoroutine(ShowCard());
		}
	}

	private IEnumerator ShowCard()
	{
		TweenShowCard();
		yield return new WaitForSeconds(mDur);
		TweenScaleCard();
		TweenHeader();
		TweenHighlight();
		yield return new WaitForSeconds(mDur);
		TweenRotationCard();
		yield return new WaitForSeconds(0.5f * mDur);
		TweenPositionCard();
		yield return new WaitForSeconds(5.5f * mDur);
		TweenHideCard();
		yield return null;
		card = null;
	}

	private void TweenRotationCard()
	{
		TweenRotation tweenRotation = TweenRotation.Begin(cardContent, 1f * mDur, Quaternion.Euler(0f, 0f, 0f), Quaternion.Euler(0f, 0f, -15f));
		tweenRotation.method = UITweener.Method.Linear;
		tweenRotation.onFinished = delegate
		{
			TweenRotation tweenRotation2 = TweenRotation.Begin(cardContent, 0.75f * mDur, Quaternion.Euler(0f, 90f, -7.5f));
			tweenRotation2.onFinished = delegate
			{
				cardBackground.alpha = 0f;
				cardIcon.alpha = 0f;
				cardTexture.alpha = 0f;
				cardBonusIcon.alpha = 0f;
				cardBonusName.alpha = 0f;
				backOfCard.alpha = 1f;
				TweenRotation tweenRotation3 = TweenRotation.Begin(cardContent, 0.75f * mDur, Quaternion.Euler(0f, 180f, 0f));
				tweenRotation3.onFinished = delegate
				{
					TweenRotation tweenRotation4 = TweenRotation.Begin(cardContent, 0.75f * mDur, Quaternion.Euler(0f, 270f, 0f));
					tweenRotation4.onFinished = delegate
					{
						cardBackground.alpha = 1f;
						cardIcon.alpha = 1f;
						cardTexture.alpha = 1f;
						cardBonusIcon.alpha = 1f;
						cardBonusName.alpha = 1f;
						backOfCard.alpha = 0f;
						TweenRotation.Begin(cardContent, 0.75f * mDur, Quaternion.Euler(0f, 360f, 0f));
					};
				};
			};
		};
	}

	private void TweenScaleCard()
	{
		TweenScale tweenScale = TweenScale.Begin(cardContent, 3f * mDur, new Vector3(1f, 1f, 1f), new Vector3(1.33f, 1.33f, 1f));
		tweenScale.delay = 0f;
		tweenScale.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(cardContent, 1f * mDur, new Vector3(1.33f, 1.33f, 1f), new Vector3(1.28f, 1.28f, 1f));
			tweenScale2.delay = 2f * mDur;
			tweenScale2.onFinished = delegate
			{
				TweenScale tweenScale3 = TweenScale.Begin(cardContent, 1f * mDur, new Vector3(1.28f, 1.28f, 1f), new Vector3(1.33f, 1.33f, 1f));
				tweenScale3.delay = 0f;
				tweenScale3.onFinished = delegate
				{
					TweenScale.Begin(cardContent, 4f * mDur, new Vector3(1.33f, 1.33f, 1f), new Vector3(1.9f, 1.9f, 1f));
				};
			};
		};
	}

	private void TweenPositionCard()
	{
		TweenPosition.Begin(cardContent, 4f * mDur, mStartPositionCard);
	}

	private void TweenShowCard()
	{
		TweenAlpha.Begin(cardBackground.gameObject, mDur, 1f);
		TweenAlpha.Begin(cardIcon.gameObject, mDur, 1f);
		TweenAlpha.Begin(cardTexture.gameObject, mDur, 1f);
		TweenAlpha.Begin(cardBonusIcon.gameObject, mDur, 1f);
		TweenAlpha.Begin(cardBonusName.gameObject, mDur, 1f);
	}

	private void TweenHideCard()
	{
		TweenAlpha.Begin(cardBackground.gameObject, 4f * mDur, 1f, 0f);
		TweenAlpha.Begin(cardIcon.gameObject, 4f * mDur, 1f, 0f);
		TweenAlpha.Begin(cardTexture.gameObject, 4f * mDur, 1f, 0f);
		TweenAlpha.Begin(cardBonusIcon.gameObject, 4f * mDur, 1f, 0f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(cardBonusName.gameObject, 4f * mDur, 1f, 0f);
		tweenAlpha.onFinished = delegate
		{
			ResumeOtherAnimations();
			base.gameObject.SetActive(value: false);
		};
	}

	private void TweenHeader()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(headerBackground.gameObject, mDur, 0f, 1f);
		tweenAlpha.delay = 1.75f * mDur;
		TweenAlpha tweenAlpha2 = TweenAlpha.Begin(headerName.gameObject, mDur, 0f, 1f);
		tweenAlpha2.delay = 1.75f * mDur;
		TweenPosition tweenPosition = TweenPosition.Begin(header, mDur, new Vector3(-80f, 352f, 0f), new Vector3(0f, 352f, 0f));
		tweenPosition.delay = 1.75f * mDur;
		tweenPosition.onFinished = delegate
		{
			TweenAlpha tweenAlpha3 = TweenAlpha.Begin(headerBackground.gameObject, mDur, 0f);
			tweenAlpha3.delay = 3.75f * mDur;
			TweenAlpha tweenAlpha4 = TweenAlpha.Begin(headerName.gameObject, mDur, 0f);
			tweenAlpha4.delay = 3.75f * mDur;
			TweenPosition tweenPosition2 = TweenPosition.Begin(header, mDur, new Vector3(80f, 352f, 0f));
			tweenPosition2.delay = 3.75f * mDur;
		};
	}

	private void TweenHighlight()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(highlight.gameObject, 2f * mDur, 0f, 1f);
		tweenAlpha.method = UITweener.Method.EaseOut;
		tweenAlpha.delay = 4f * mDur;
		TweenScale tweenScale = TweenScale.Begin(highlight.gameObject, 2.5f * mDur, new Vector3(512f, 624f, 1f), new Vector3(284f, 346f, 1f));
		tweenScale.delay = 4f * mDur;
		tweenScale.onFinished = delegate
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(highlight.gameObject, 3f * mDur, 0f);
			tweenAlpha2.method = UITweener.Method.EaseIn;
			tweenAlpha2.delay = 1.5f * mDur;
			TweenScale tweenScale2 = TweenScale.Begin(highlight.gameObject, 4.5f * mDur, new Vector3(698f, 850f, 1f));
			tweenScale2.delay = 0f;
		};
	}
}
