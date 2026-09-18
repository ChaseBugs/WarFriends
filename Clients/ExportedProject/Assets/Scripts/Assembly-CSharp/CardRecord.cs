using System;
using UnityEngine;

public class CardRecord : PoolableObject
{
	public enum Behaviour
	{
		MyWarcards,
		CraftCards,
		Lobby,
		Withdraw,
		CountDownBuddy,
		Deposit,
		Other
	}

	private enum DragType
	{
		None,
		Move,
		Scroll
	}

	[Header("Panel And Tweeners")]
	public UIPanel cardPanel;

	public TweenAlpha alphaPanel;

	public BoxCollider boxCollider;

	[Header("Back side of card")]
	public UISprite background;

	[Header("Card Look")]
	public UISprite backOfCard;

	public UISprite cardIcon;

	public UITexture cardTexture;

	public UILabel cardName;

	public UILabel cardDescription;

	[Header("Buddy Card Look")]
	public UITable cardBuddyTable;

	public UISprite cardBuddyLevelIcon;

	public UILabel cardBuddyLevelNumber;

	public UILabel cardBuddyName;

	public UILabel cardBuddyDescription;

	[Header("Right Up Corner Icon Part")]
	public GameObject bonusIconPart;

	public UISprite bonusCardBackground;

	public UISprite bonusIconBackground;

	public UISprite bonusIcon;

	public GameObject unitTypePart;

	public UISprite unitTypeIcon;

	[Header("Left Up Corner Amount Part")]
	public GameObject amountPart;

	public UILabel amountLabel;

	[Header("Highlighted Part")]
	public GameObject highlightPart;

	public UISprite highlightSprite;

	[Header("Bottom Buttons")]
	public GameObject withdrawButton;

	public UILabel withdrawLabel;

	public GameObject depositButton;

	[Header("Bottom Countdown")]
	public GameObject countdownPart;

	public UISprite countdownBackground;

	public UILabel countdownLabel;

	[Header("Draggable Card")]
	public GameObject dragPart;

	public UISprite dragIcon;

	public UISprite dragBonusIcon;

	public UITexture dragTexture;

	public UILabel dragBonusName;

	public UISprite dragIconBackground;

	[HideInInspector]
	public Card card;

	private Behaviour mBehaviour;

	private bool mDragging;

	private DragType mDragType;

	private bool mIsAvailable = true;

	private Vector3 mScreenScale;

	private CardContainer mContainer;

	private Vector3 mBigCardScale = new Vector3(402f, 490f, 0f);

	private bool mAnimating;

	private float mTimer;

	public bool isAvailable => mIsAvailable;

	public bool isAnimatingCard => mAnimating;

	public bool cardFlipped { get; private set; }

	public Transform dragCardTransform
	{
		get
		{
			dragPart.transform.localPosition = new Vector3(0f, 0f, dragPart.transform.localPosition.z);
			return dragPart.transform;
		}
	}

	public Behaviour behaviour
	{
		get
		{
			return mBehaviour;
		}
		set
		{
			mBehaviour = value;
		}
	}

	public event Action<CardRecord> OnCardClick;

	protected override void Start()
	{
		base.Start();
		UIPanel uIPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		if (uIPanel.root != null)
		{
			vector *= uIPanel.root.GetPixelSizeAdjustment(Screen.height, Screen.width);
		}
		mScreenScale = new Vector3(vector.x / (float)Screen.width, vector.y / (float)Screen.height, 0f);
	}

	public void Initialize(Card initCard, Behaviour behaviour = Behaviour.Other, bool freeOnClick = true)
	{
		card = initCard;
		mBehaviour = behaviour;
		cardPanel.isFreezed = false;
		base.transform.localScale = Vector3.one;
		InitBigCardLook();
		bool flag = card.amount > 1 && (mBehaviour == Behaviour.Lobby || mBehaviour == Behaviour.MyWarcards || mBehaviour == Behaviour.CraftCards);
		amountPart.transform.localScale = Vector3.one;
		amountPart.SetActive(flag);
		if (flag)
		{
			amountLabel.text = "x" + MiscTools.FormatBigNumber(card.amount);
		}
		bool flag2 = card.isBuddyCard && mBehaviour != Behaviour.CountDownBuddy;
		unitTypePart.SetActive(flag2);
		if (flag2)
		{
			unitTypeIcon.spriteName = card.unitTypeSpriteName;
		}
		depositButton.SetActive(mBehaviour == Behaviour.Deposit);
		withdrawButton.SetActive(mBehaviour == Behaviour.Withdraw);
		countdownPart.SetActive(mBehaviour == Behaviour.CountDownBuddy);
		SetHighlight(show: false);
		card.SetUpSmallCard(dragIconBackground, dragIcon, dragBonusIcon, dragBonusName, dragTexture);
		dragPart.SetActive(value: false);
		SetVisible();
		SetAvailable();
		if (freeOnClick)
		{
			this.OnCardClick = null;
		}
		card.ShowInMenu();
	}

	public void SetAmount(int count)
	{
		amountPart.SetActive(count > 1);
		amountLabel.text = "x" + MiscTools.FormatBigNumber(count);
	}

	public void UnhookAndStopAllTweens()
	{
		TweenRotation.Begin(base.gameObject, 0f, Quaternion.identity);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].onBegin = null;
			componentsInChildren[i].onFinished = null;
			componentsInChildren[i].delay = 0f;
			componentsInChildren[i].duration = 0f;
			componentsInChildren[i].enabled = false;
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		boxCollider.enabled = true;
	}

	public override void DestroyPooled()
	{
		UnhookAndStopAllTweens();
		boxCollider.enabled = true;
		if (card != null)
		{
			card.HideInMenu();
		}
		this.OnCardClick = null;
		base.DestroyPooled();
	}

	public void InitBigCardLook()
	{
		TweenAlpha.Begin(base.gameObject, 0f, 1f, 1f);
		backOfCard.alpha = 0f;
		background.spriteName = Card.CardBigBackground(card.rarity);
		background.color = Card.CardBackgroundColor(card.rarity);
		if (card.iconName == string.Empty)
		{
			cardIcon.gameObject.SetActive(value: false);
			bonusIconPart.SetActive(value: false);
			Debug.LogError("Card " + card.cardName.ToUpper() + " does not have defined look!!!!!!");
		}
		else
		{
			cardIcon.gameObject.SetActive(!card.isBuddyCard);
			cardTexture.gameObject.SetActive(value: false);
			if (cardIcon.gameObject.activeSelf)
			{
				cardIcon.spriteName = card.iconName;
				cardIcon.MakePixelPerfect();
				cardIcon.alpha = 1f;
			}
			cardIcon.transform.localPosition = card.bigCardPosition;
			if (card.bonusIcon == string.Empty)
			{
				bonusIconPart.SetActive(value: false);
			}
			else
			{
				bonusIconPart.SetActive(value: true);
				bonusCardBackground.spriteName = Card.CardSmallIconBackground(card.rarity);
				bonusIconBackground.color = card.bonusIconBackgroundColor;
				bonusIcon.spriteName = card.bonusIcon;
				bonusIcon.MakePixelPerfect();
				bonusIcon.color = card.bonusIconColor;
			}
		}
		cardName.gameObject.SetActive(!card.isBuddyCard);
		cardDescription.gameObject.SetActive(!card.isBuddyCard);
		cardBuddyTable.gameObject.SetActive(card.isBuddyCard);
		cardBuddyDescription.gameObject.SetActive(card.isBuddyCard);
		if (card.isBuddyCard)
		{
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition((card as CardBuddy).buddyCardData.level);
			cardBuddyLevelIcon.spriteName = levelDefinition.iconName;
			cardBuddyLevelNumber.text = levelDefinition.displayString;
			cardBuddyName.text = card.cardName;
			MiscTools.SetUILabelRescale(cardBuddyName, 37f, 12f, 298);
			cardBuddyDescription.text = ((mBehaviour != Behaviour.CountDownBuddy) ? card.description : (card as CardBuddy).createDescription);
			cardBuddyTable.repositionNow = true;
		}
		else
		{
			TweenAlpha.Begin(cardName.gameObject, 0f, 1f);
			TweenAlpha.Begin(cardDescription.gameObject, 0f, 1f);
			cardName.text = card.cardName.ToUpper();
			MiscTools.SetUILabelRescale(cardName, 37f, 12f, 365);
			cardDescription.text = ((mBehaviour != Behaviour.CountDownBuddy) ? card.description : (card as CardBuddy).createDescription);
		}
	}

	protected void Update()
	{
		if (card.iconTexture != null && !cardTexture.gameObject.activeSelf)
		{
			cardIcon.gameObject.SetActive(value: false);
			cardTexture.gameObject.SetActive(value: true);
			cardTexture.mainTexture = card.iconTexture;
			dragIcon.gameObject.SetActive(value: false);
			dragTexture.gameObject.SetActive(value: true);
			dragTexture.mainTexture = card.iconTexture;
		}
		if (mBehaviour == Behaviour.CountDownBuddy)
		{
			mTimer += Time.deltaTime;
			if (mTimer >= 0.333f)
			{
				mTimer -= 0.333f;
				UpdateTexts();
			}
		}
	}

	private void UpdateTexts()
	{
		int num = CardManager.instance.nextBuddyDeposit - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (num < 0)
		{
			Initialize(card, Behaviour.Deposit, freeOnClick: false);
		}
		else
		{
			countdownLabel.text = string.Format("{0} {1}{2}", Localization.Localize("ID_DEPOSITAVAILABLEIN"), Colours.stringPink, MiscTools.PrintableTime(num, "ID_READYTIME", string.Empty));
		}
	}

	private void OnDrag(Vector2 delta)
	{
		if (mBehaviour == Behaviour.Other || !base.enabled || UICamera.currentTouchID <= -2)
		{
			return;
		}
		switch (mDragType)
		{
		case DragType.None:
		{
			float num = Math.Abs(delta.y) / Math.Max(0.0001f, Math.Abs(delta.x));
			if (num < 0.5f || !mIsAvailable)
			{
				mDragType = DragType.Scroll;
				UIDraggablePanel.panelDisabled = false;
			}
			else
			{
				bool flag = mBehaviour == Behaviour.Lobby || (mBehaviour == Behaviour.CraftCards && GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.canChangeContent);
				mDragType = (flag ? DragType.Move : DragType.Scroll);
			}
			break;
		}
		case DragType.Move:
		{
			if (!dragPart.activeSelf)
			{
				dragPart.SetActive(value: true);
				TweenAlpha.Begin(dragPart, 0f, 1f);
				TweenScale tweenScale = TweenScale.Begin(dragPart, 0.3f, new Vector3(0.1f, 0.1f, 0.1f), new Vector3(1.2f, 1.2f, 1.2f));
				tweenScale.method = UITweener.Method.EaseIn;
				tweenScale.onFinished = delegate
				{
					TweenScale tweenScale2 = TweenScale.Begin(dragPart, 0.2f, new Vector3(1f, 1f, 1f));
					tweenScale2.method = UITweener.Method.EaseOut;
				};
			}
			dragPart.transform.localPosition += Vector3.Scale(mScreenScale, delta);
			UIDraggablePanel.panelDisabled = true;
			RaycastHit hit = default(RaycastHit);
			Vector3 inPos = Singleton<GuiManager>.instance.guiCamera.WorldToScreenPoint(dragPart.transform.position);
			if (UICamera.Raycast(inPos, ref hit))
			{
				CardContainer cardContainer = ((!(hit.collider != null)) ? null : hit.collider.GetComponent<CardContainer>());
				if (cardContainer != mContainer)
				{
					if (mContainer != null)
					{
						mContainer.Highlight(highlight: false);
					}
					mContainer = cardContainer;
				}
				if (mContainer != null)
				{
					bool highlight = mContainer.isAvailable && ((card.isBuddyCard && mContainer.isBuddyContainer) || (!card.isBuddyCard && !mContainer.isBuddyContainer));
					mContainer.Highlight(highlight);
				}
			}
			else if (mContainer != null)
			{
				mContainer.Highlight(highlight: false);
				mContainer = null;
			}
			break;
		}
		case DragType.Scroll:
			break;
		}
	}

	private void OnPress(bool isPressed)
	{
		if (mBehaviour != Behaviour.Other && base.enabled)
		{
			if (isPressed)
			{
				mContainer = null;
				dragPart.transform.position = UICamera.currentCamera.ScreenToWorldPoint(new Vector3(UICamera.currentTouch.pos.x, UICamera.currentTouch.pos.y));
				dragPart.transform.localPosition = new Vector3(dragPart.transform.localPosition.x, dragPart.transform.localPosition.y, -50f);
				mDragging = true;
				UICamera.stickyPress = true;
			}
			else if (mDragging)
			{
				UIDraggablePanel.panelDisabled = false;
				dragPart.SetActive(value: false);
				mDragging = false;
				UICamera.stickyPress = false;
			}
			Collider component = GetComponent<Collider>();
			if (component != null)
			{
				component.enabled = !isPressed;
			}
			if (!isPressed)
			{
				Drop();
			}
			mDragType = DragType.None;
		}
	}

	private void Drop()
	{
		if (mBehaviour == Behaviour.Lobby || mBehaviour == Behaviour.CraftCards)
		{
			bool flag = mBehaviour == Behaviour.CraftCards;
			if (flag && !GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.canChangeContent)
			{
				return;
			}
			if (mContainer != null)
			{
				if (!mContainer.isAvailable || (card.isBuddyCard && !mContainer.isBuddyContainer) || (!card.isBuddyCard && mContainer.isBuddyContainer))
				{
					return;
				}
				if (!mContainer.isEmpty)
				{
					mContainer.RemoveCard();
				}
				if (mContainer.InsertCard(card))
				{
					if (flag)
					{
						SelectForCraftingAnimation();
						GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.UpdateCardRecord(card);
					}
					else
					{
						SetUnAvailable();
					}
				}
			}
			if (mDragType != DragType.None)
			{
				return;
			}
			if (mIsAvailable)
			{
				if (flag)
				{
					if (GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.TryToPutCardIntoEmptyContainer(this))
					{
						SelectForCraftingAnimation();
					}
				}
				else if (GuiScreenSingle<CardSelectionScreen>.instance.TryToPutCardIntoEmptyContainer(this))
				{
					SetUnAvailable();
				}
			}
			else if (flag)
			{
				GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.TryToRemoveCardFromAnyContainer(this);
			}
			else
			{
				GuiScreenSingle<CardSelectionScreen>.instance.TryToRemoveCardFromAnyContainer(this);
			}
		}
		else if (mDragType == DragType.None && (mBehaviour == Behaviour.Deposit || mBehaviour == Behaviour.Withdraw) && this.OnCardClick != null)
		{
			this.OnCardClick(this);
		}
	}

	public void EndScreenAnimation(bool isTutorial)
	{
		cardFlipped = false;
		mAnimating = true;
		SetInvisible();
		Vector3 toScale = mBigCardScale * 1.2f;
		toScale.z = 1f;
		base.transform.localScale = Vector3.one;
		base.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		backOfCard.cachedTransform.localScale = Vector3.one;
		backOfCard.cachedTransform.localPosition = Vector3.zero;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(backOfCard.gameObject, 0.4f, 0f, 1f);
		tweenAlpha.from = 0f;
		tweenAlpha.delay = 0f;
		TweenPosition tweenPosition = TweenPosition.Begin(backOfCard.gameObject, 0.2f, Vector3.zero, new Vector3(0f, 20f, 0f));
		tweenPosition.delay = 0.2f;
		tweenPosition.NumOfRepetitions = 2;
		tweenPosition.style = UITweener.Style.PingPong;
		TweenScale tweenScale = TweenScale.Begin(backOfCard.gameObject, 0.4f, Vector3.one, toScale);
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.delay = 0f;
		tweenScale.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(backOfCard.gameObject, 0.2f, mBigCardScale);
			tweenScale2.method = UITweener.Method.EaseOut;
			tweenScale2.onFinished = delegate
			{
				FlipBuyAnimation(0);
				TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, 0.4f, Vector3.zero, new Vector3(0f, 20f, 0f));
				tweenPosition2.NumOfRepetitions = 2;
				tweenPosition2.delay = 0f;
				tweenPosition2.style = UITweener.Style.PingPong;
				tweenPosition2.onFinished = delegate
				{
					TweenPosition tweenPosition3 = ((!isTutorial) ? TweenPosition.Begin(base.gameObject, 0.01f, Vector3.zero, Vector3.zero) : TweenPosition.Begin(base.gameObject, 1f, Vector3.zero, new Vector3(0f, 20f, 0f)));
					tweenPosition3.delay = 0f;
					tweenPosition3.NumOfRepetitions = ((!isTutorial) ? 1 : 2);
					tweenPosition3.style = (isTutorial ? UITweener.Style.PingPong : UITweener.Style.Once);
					tweenPosition3.onFinished = delegate
					{
						if (!BreakAnimation())
						{
							HideCardInEndScreen();
						}
					};
				};
			};
		};
	}

	public void HideCardInEndScreen()
	{
		TweenScale tweenScale = TweenScale.Begin(base.gameObject, 0.2f, new Vector3(0.28f, 0.28f, 1f));
		tweenScale.delay = 0f;
		tweenScale.onFinished = null;
		TweenPosition.Begin(base.gameObject, 0.2f, GuiScreenSingle<EndScreen>.instance.placeForCardAnimation.transform.position, useLocal: false).onFinished = delegate
		{
			if (!BreakAnimation())
			{
				TweenScale tweenScale2 = TweenScale.Begin(base.gameObject, 0.2f, new Vector3(0.05f, 0.05f, 1f));
				tweenScale2.delay = 0.1f;
				tweenScale2.onFinished = delegate
				{
					if (!BreakAnimation())
					{
						SetInvisible();
						TweenScale tweenScale3 = TweenScale.Begin(base.gameObject, 0.05f, new Vector3(1f, 1f, 1f));
						tweenScale3.delay = 0f;
						tweenScale3.onFinished = delegate
						{
							if (!BreakAnimation())
							{
								TweenPosition.Begin(base.gameObject, 0.05f, Vector3.zero).onFinished = delegate
								{
									mAnimating = false;
									if (!BreakAnimation())
									{
									}
								};
							}
						};
					}
				};
			}
		};
	}

	private bool BreakAnimation()
	{
		if (mBehaviour != Behaviour.Other)
		{
			Debug.Log("Gained Card Animation INTERUPTED - reseting card");
			TweenScale.Begin(base.gameObject, 0.05f, new Vector3(1f, 1f, 1f)).onFinished = null;
			SetVisible();
			mAnimating = false;
			return true;
		}
		return false;
	}

	public void SetInvisible()
	{
		backOfCard.transform.localScale = Vector3.one;
		backOfCard.alpha = 0f;
		background.alpha = 0f;
		cardName.alpha = 0f;
		cardDescription.alpha = 0f;
		if (cardIcon.gameObject.activeSelf)
		{
			cardIcon.alpha = 0f;
		}
		if (cardTexture.gameObject.activeSelf)
		{
			cardTexture.alpha = 0f;
		}
		if (bonusIcon.gameObject.activeSelf)
		{
			bonusIcon.alpha = 0f;
			bonusIconBackground.alpha = 0f;
			bonusCardBackground.alpha = 0f;
		}
		unitTypePart.SetActive(value: false);
		amountPart.SetActive(value: false);
		SetHighlight(show: false);
	}

	private void SetVisible()
	{
		background.alpha = 1f;
		cardName.alpha = 1f;
		cardDescription.alpha = 1f;
		if (cardIcon.gameObject.activeSelf)
		{
			cardIcon.alpha = 1f;
		}
		if (cardTexture.gameObject.activeSelf)
		{
			cardTexture.alpha = 1f;
		}
		if (bonusIcon.gameObject.activeSelf)
		{
			bonusIcon.alpha = 1f;
			bonusIconBackground.alpha = 1f;
			bonusCardBackground.alpha = 1f;
		}
		cardPanel.alpha1 = 1f;
		alphaPanel.enabled = false;
	}

	public void PrepareBuyAnimation()
	{
		SetInvisible();
		base.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		backOfCard.alpha = 0f;
		backOfCard.MakePixelPerfect();
		backOfCard.cachedTransform.localScale = backOfCard.cachedTransform.localScale.MultiplyXY(0.5f);
	}

	public void FlipBuyAnimation(int index)
	{
		TweenRotation tweenRotation = TweenRotation.Begin(base.gameObject, 0.2f, Quaternion.Euler(0f, 90f, 0f));
		tweenRotation.delay = (float)index * 0.35f;
		tweenRotation.onBegin = delegate
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CardFlip);
		};
		tweenRotation.onFinished = delegate
		{
			SetVisible();
			backOfCard.alpha = 0f;
			TweenAlpha.Begin(backOfCard.gameObject, 0.05f, 0f, 0f);
			TweenRotation tweenRotation2 = TweenRotation.Begin(base.gameObject, 0.2f, Quaternion.Euler(0f, 0f, 0f));
			tweenRotation2.delay = 0f;
			tweenRotation2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation2.onFinished, (UITweener.OnFinished)delegate
			{
				cardFlipped = true;
			});
		};
	}

	public void SelectForCraftingAnimation()
	{
		SetHighlight(show: true);
		highlightSprite.alpha = 0f;
		amountPart.transform.localScale = Vector3.one;
		float dur = 0.15f;
		TweenScale tweenScale = TweenScale.Begin(amountPart, dur, Vector3.one, new Vector3(1.3f, 1.3f, 1f));
		tweenScale.method = UITweener.Method.EaseIn;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(highlightSprite.gameObject, dur, 0f, 1f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(amountPart, dur, Vector3.one);
			tweenScale2.method = UITweener.Method.EaseOut;
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(highlightSprite.gameObject, dur, 0.4f);
			tweenAlpha2.method = UITweener.Method.EaseOut;
			tweenAlpha2.onFinished = null;
		};
	}

	public void SetHighlight(bool show)
	{
		highlightPart.SetActive(show);
		bool flag = mBehaviour == Behaviour.Deposit;
		highlightSprite.color = ((!flag) ? Colours.blue : Colours.pink);
	}

	public void SetUnAvailable()
	{
		UIWidget[] componentsInChildren = GetComponentsInChildren<UIWidget>(includeInactive: true);
		UIWidget[] array = componentsInChildren;
		foreach (UIWidget uIWidget in array)
		{
			float alpha = uIWidget.alpha;
			uIWidget.color = Color.grey;
			uIWidget.alpha = alpha;
		}
		background.color = (Card.CardBackgroundColor(card.rarity) * Color.grey).ReplaceA(background.alpha);
		bonusIconBackground.color = (card.bonusIconBackgroundColor * Color.grey).ReplaceA(bonusIconBackground.alpha);
		bonusIcon.color = (card.bonusIconColor * Color.grey).ReplaceA(bonusIcon.alpha);
		dragIconBackground.color = (Card.CardBackgroundColor(card.rarity) * Color.grey).ReplaceA(dragIconBackground.alpha);
		dragBonusIcon.color = (card.bonusIconSmallCardColor * Color.grey).ReplaceA(dragBonusIcon.alpha);
		amountLabel.color = Color.black.ReplaceA(amountLabel.alpha);
		SetHighlight(show: true);
		if (mBehaviour == Behaviour.Deposit)
		{
			depositButton.SetActive(value: false);
		}
		if (mBehaviour == Behaviour.CountDownBuddy)
		{
			TweenAlpha component = countdownPart.GetComponent<TweenAlpha>();
			if (component != null)
			{
				if (component.enabled)
				{
					component.to = 1f;
				}
				else
				{
					UIPanel component2 = countdownPart.GetComponent<UIPanel>();
					if (component2 != null)
					{
						component2.alpha1 = 1f;
					}
				}
			}
		}
		withdrawLabel.color = Color.black.ReplaceA(withdrawLabel.alpha);
		countdownBackground.color = Colours.blackDeposit.ReplaceA(countdownBackground.alpha);
		countdownLabel.color = Color.white.ReplaceA(countdownLabel.alpha);
		mIsAvailable = false;
	}

	internal void SetAvailable()
	{
		UIWidget[] componentsInChildren = GetComponentsInChildren<UIWidget>(includeInactive: true);
		UIWidget[] array = componentsInChildren;
		foreach (UIWidget uIWidget in array)
		{
			float alpha = uIWidget.alpha;
			uIWidget.color = Color.white;
			uIWidget.alpha = alpha;
		}
		background.color = Card.CardBackgroundColor(card.rarity).ReplaceA(background.alpha);
		bonusIconBackground.color = card.bonusIconBackgroundColor.ReplaceA(bonusIconBackground.alpha);
		bonusIcon.color = card.bonusIconColor.ReplaceA(bonusIcon.alpha);
		dragIconBackground.color = Card.CardBackgroundColor(card.rarity).ReplaceA(dragIconBackground.alpha);
		dragBonusIcon.color = card.bonusIconSmallCardColor.ReplaceA(dragBonusIcon.alpha);
		amountLabel.color = Color.black.ReplaceA(amountLabel.alpha);
		SetHighlight(show: false);
		if (mBehaviour == Behaviour.Deposit)
		{
			depositButton.SetActive(value: true);
		}
		if (mBehaviour == Behaviour.CountDownBuddy)
		{
			TweenAlpha component = countdownPart.GetComponent<TweenAlpha>();
			if (component != null)
			{
				if (component.enabled)
				{
					component.to = 1f;
				}
				else
				{
					UIPanel component2 = countdownPart.GetComponent<UIPanel>();
					if (component2 != null)
					{
						component2.alpha1 = 1f;
					}
				}
			}
		}
		withdrawLabel.color = Color.black.ReplaceA(withdrawLabel.alpha);
		countdownBackground.color = Colours.blackDeposit.ReplaceA(countdownBackground.alpha);
		countdownLabel.color = Color.white.ReplaceA(countdownLabel.alpha);
		mIsAvailable = true;
	}
}
