using UnityEngine;

public class GameGuiCard : PoolableObject
{
	public UISprite highlight;

	[Header("Header")]
	public GameObject header;

	public UISprite headerBackground;

	public UILabel headerName;

	[Header("Card look")]
	public GameObject cardContent;

	public UISprite background;

	public UISprite icon;

	public UITexture texture;

	public UISprite bonusIcon;

	public UILabel bonusName;

	public UISprite backOfCard;

	[Header("Progress icon Top left")]
	public UISprite progress;

	public UISprite progressBg;

	private Vector3 mStartPositionCard;

	private float mDur = 0.2f;

	private CardsGuiElementNew mCardGui;

	private Card mCard;

	private bool mEnabled;

	public Card card
	{
		get
		{
			return mCard;
		}
		set
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

	public void InitFromCard(CardsGuiElementNew cardsGuiElementNew, Card insertCard, int number)
	{
		mEnabled = true;
		mCardGui = cardsGuiElementNew;
		card = insertCard;
		SetUpWhite();
		card.SetUpSmallCard(background, icon, bonusIcon, bonusName, texture);
		backOfCard.alpha = 0f;
		highlight.color = Colours.blue;
		headerName.text = card.cardName.ToUpper();
		headerBackground.transform.localScale = new Vector3(130f + headerName.relativeSize.x * headerName.transform.localScale.x, 74f, 1f);
		ResetTweens();
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y, number * 2);
		GetComponent<Collider>().enabled = true;
		progress.gameObject.SetActive(value: false);
		progressBg.gameObject.SetActive(value: false);
	}

	private void ResetTweens()
	{
		TweenPosition.Begin(base.gameObject, 0f, base.transform.localPosition).delay = 0f;
		TweenScale.Begin(base.gameObject, 0f, base.transform.localScale).delay = 0f;
		TweenRotation.Begin(base.gameObject, 0f, Quaternion.identity).delay = 0f;
		TweenPosition.Begin(cardContent, 0f, cardContent.transform.localPosition).delay = 0f;
		TweenScale.Begin(cardContent, 0f, Vector3.one).delay = 0f;
		TweenRotation.Begin(cardContent, 0f, Quaternion.identity).delay = 0f;
		TweenAlpha.Begin(background.gameObject, 0f, 1f).delay = 0f;
		TweenAlpha.Begin(icon.gameObject, 0f, 1f).delay = 0f;
		TweenAlpha.Begin(texture.gameObject, 0f, 1f).delay = 0f;
		TweenAlpha.Begin(bonusIcon.gameObject, 0f, 1f).delay = 0f;
		TweenAlpha.Begin(bonusName.gameObject, 0f, 1f).delay = 0f;
		TweenAlpha.Begin(highlight.gameObject, 0f, 0f).delay = 0f;
		TweenScale.Begin(highlight.gameObject, 0f, new Vector3(512f, 624f, 1f)).delay = 0f;
		TweenAlpha.Begin(headerBackground.gameObject, 0f, 0f).delay = 0f;
		TweenAlpha.Begin(headerName.gameObject, 0f, 0f).delay = 0f;
		TweenPosition.Begin(header, 0f, new Vector3(-80f, 352f, 0f)).delay = 0f;
	}

	public void SetUpWhite()
	{
		if (!(card == null))
		{
			Color color = Card.CardBackgroundColor(card.rarity, background.alpha);
			background.color = color;
			icon.color = Color.white;
			texture.color = Color.white;
			bonusIcon.color = card.bonusIconSmallCardColor;
			bonusName.color = Color.white;
		}
	}

	public void SetUpGray()
	{
		if (!(card == null))
		{
			Color color = Card.CardBackgroundColor(card.rarity, background.alpha);
			background.color = color * Color.gray;
			icon.color = Color.gray;
			texture.color = Color.gray;
			bonusIcon.color = Color.gray * card.bonusIconSmallCardColor;
		}
	}

	public void UseCard()
	{
		Debug.Log("Clicked on game CARD (bottom screen)");
		TweenPosition.Begin(base.gameObject, 0f, base.transform.localPosition);
		TweenScale.Begin(base.gameObject, 0f, base.transform.localScale);
		TweenRotation.Begin(base.gameObject, 0f, Quaternion.identity);
		CardManager.instance.UseCard(card);
		Collider component = GetComponent<Collider>();
		if (component != null)
		{
			component.enabled = false;
		}
		StartAnimationInitialization();
		TweenScaleCard();
		TweenRotationCardAndHide(mDur);
		TweenPositionCard(1.5f * mDur);
		TweenHeader();
		TweenHighlight();
	}

	private void StartAnimationInitialization()
	{
		float num = -135f;
		Vector3 vector = ((!Singleton<GameController>.instance.isCoopBot) ? new Vector3(-44f, 524f, 0f) : new Vector3(-546f, 524f, 0f));
		vector.x -= num;
		Vector3 vector2 = (vector - base.transform.localPosition) / base.transform.localScale.x;
		vector2.z = 0f;
		mStartPositionCard = cardContent.transform.localPosition;
		cardContent.transform.localPosition -= vector2;
		base.transform.localPosition = vector.ReplaceZ(-4f);
	}

	public void PlayProgress()
	{
		progress.gameObject.SetActive(value: true);
		progressBg.gameObject.SetActive(value: true);
		bonusName.color = Color.gray;
		SetUpGray();
	}

	protected void Update()
	{
		if (progressBg.gameObject.activeSelf)
		{
			progress.fillAmount = 1f - CardManager.instance.Progress;
			if (CardManager.instance.Progress == 0f)
			{
				progress.gameObject.SetActive(value: false);
				progressBg.gameObject.SetActive(value: false);
				SetUpWhite();
			}
		}
		if (!texture.gameObject.activeSelf && card != null && card.iconTexture != null)
		{
			icon.gameObject.SetActive(value: false);
			texture.gameObject.SetActive(value: true);
			texture.mainTexture = card.iconTexture;
		}
	}

	private void OnClick()
	{
		if (PlayerController.currentPlayer.canSendCards && mEnabled)
		{
			mCardGui.OnCardClick(this);
		}
	}

	private void TweenRotationCardAndHide(float delay)
	{
		TweenRotation tw = TweenRotation.Begin(cardContent, 1f * mDur, Quaternion.Euler(0f, 0f, 0f), Quaternion.Euler(0f, 0f, -15f));
		tw.method = UITweener.Method.Linear;
		tw.delay = delay;
		tw.onFinished = delegate
		{
			tw.delay = 0f;
			TweenRotation.Begin(cardContent, 0.75f * mDur, Quaternion.Euler(0f, 90f, -7.5f)).onFinished = delegate
			{
				TweenAlpha.Begin(background.gameObject, 0f, 0f);
				TweenAlpha.Begin(icon.gameObject, 0f, 0f);
				TweenAlpha.Begin(texture.gameObject, 0f, 0f);
				TweenAlpha.Begin(bonusIcon.gameObject, 0f, 0f);
				TweenAlpha.Begin(bonusName.gameObject, 0f, 0f);
				TweenAlpha.Begin(backOfCard.gameObject, 0f, 1f);
				TweenRotation.Begin(cardContent, 0.75f * mDur, Quaternion.Euler(0f, 180f, 0f)).onFinished = delegate
				{
					TweenRotation.Begin(cardContent, 0.75f * mDur, Quaternion.Euler(0f, 270f, 0f)).onFinished = delegate
					{
						TweenAlpha.Begin(background.gameObject, 0f, 1f);
						TweenAlpha.Begin(icon.gameObject, 0f, 1f);
						TweenAlpha.Begin(texture.gameObject, 0f, 1f);
						TweenAlpha.Begin(bonusIcon.gameObject, 0f, 1f);
						TweenAlpha.Begin(bonusName.gameObject, 0f, 1f);
						TweenAlpha.Begin(backOfCard.gameObject, 0f, 0f);
						TweenRotation.Begin(cardContent, 0.75f * mDur, Quaternion.Euler(0f, 360f, 0f)).onFinished = delegate
						{
							TweenAlpha delayTween = TweenAlpha.Begin(background.gameObject, 0.0001f, 1f);
							delayTween.delay = 2f * mDur;
							delayTween.onFinished = delegate
							{
								delayTween.delay = 0f;
								TweenAlpha tweenAlpha = TweenAlpha.Begin(background.gameObject, 4f * mDur, 1f, 0f);
								TweenAlpha.Begin(icon.gameObject, 4f * mDur, 1f, 0f);
								TweenAlpha.Begin(texture.gameObject, 4f * mDur, 1f, 0f);
								TweenAlpha.Begin(bonusIcon.gameObject, 4f * mDur, 1f, 0f);
								TweenAlpha.Begin(bonusName.gameObject, 4f * mDur, 1f, 0f);
								tweenAlpha.onFinished = delegate
								{
									DestroyPooled();
								};
							};
						};
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

	private void TweenPositionCard(float delay)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(cardContent, 4f * mDur, mStartPositionCard);
		tweenPosition.delay = delay;
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
		TweenAlpha tw = TweenAlpha.Begin(highlight.gameObject, 2f * mDur, 0f, 1f);
		tw.method = UITweener.Method.EaseOut;
		tw.delay = 4f * mDur;
		TweenScale tweenScale = TweenScale.Begin(highlight.gameObject, 2.5f * mDur, new Vector3(512f, 624f, 1f), new Vector3(284f, 346f, 1f));
		tweenScale.delay = 4f * mDur;
		tweenScale.onFinished = delegate
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(highlight.gameObject, 3f * mDur, 0f);
			tw.method = UITweener.Method.EaseIn;
			tweenAlpha.delay = 1.5f * mDur;
			TweenScale tweenScale2 = TweenScale.Begin(highlight.gameObject, 4.5f * mDur, new Vector3(698f, 850f, 1f));
			tweenScale2.delay = 0f;
		};
	}

	public override void DestroyPooled()
	{
		if (base.isInstantiated)
		{
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: true);
			UITweener[] array = componentsInChildren;
			foreach (UITweener uITweener in array)
			{
				uITweener.enabled = false;
			}
		}
		if (card != null)
		{
			card = null;
		}
		base.DestroyPooled();
	}

	public void Disable()
	{
		mEnabled = false;
	}

	public void Enable()
	{
		mEnabled = true;
	}
}
