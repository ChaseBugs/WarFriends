using System;
using UnityEngine;

public class CardContainer : Core_BaseScript
{
	private enum DragType
	{
		None,
		Drag
	}

	[Header("Empty Part")]
	public GameObject emptyContent;

	public UISprite emptyBorder;

	public UILabel emptyLabel;

	[Header("Card Present Part")]
	public UIPanel cardContent;

	public UISprite cardBackground;

	public UISprite cardIcon;

	public UITexture cardTexture;

	public UISprite cardBonusIcon;

	public UILabel cardBonusName;

	[Header("Locked Part")]
	public GameObject lockContent;

	[Header("VIP locked Part")]
	public GameObject vipContent;

	[Header("Draggable Card")]
	public UIPanel dragPart;

	public UISprite dragIcon;

	public UITexture dragTexture;

	public UISprite dragBonusIcon;

	public UILabel dragBonusName;

	public UISprite dragBackground;

	[Header("Highlight")]
	public UISprite highlightBackground;

	[HideInInspector]
	public int index;

	private Card mCard;

	private CardContainer mContainer;

	private bool mIsDragging;

	private Vector3 mScreenScale;

	private bool mHighlighted;

	private DragType mDragType;

	private bool mWarcardsLocked;

	public bool isBuddyContainer => index == 6;

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

	public bool isAvailable => !mWarcardsLocked && !vipContent.activeSelf && !lockContent.activeSelf;

	public bool isEmpty => mCard == null;

	private bool mIsVipContainer => index == 4;

	public event Action ChangedContent;

	public void InitCardContainer(int number)
	{
		index = number;
		string currentLanguage = Localization.instance.currentLanguage;
		emptyLabel.text = Localization.Localize((!isBuddyContainer) ? "ID_GUI_DRAGCARDHERE" : "ID_BUDDYCARDHERE");
		if (!isBuddyContainer && currentLanguage == "de")
		{
			emptyLabel.transform.localScale = new Vector3(24f, 24f, 1f);
		}
		emptyLabel.color = ((!isBuddyContainer) ? Color.white : Colours.pink);
		emptyBorder.color = emptyLabel.color;
		SetEmpty();
		card = null;
		UIPanel uIPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		if (uIPanel.root != null)
		{
			vector *= uIPanel.root.GetPixelSizeAdjustment(Screen.height, Screen.width);
		}
		mScreenScale = new Vector3(vector.x / (float)Screen.width, vector.y / (float)Screen.height, 0f);
		dragPart.gameObject.SetActive(value: false);
	}

	public void SetLocked()
	{
		if (card != null)
		{
			RemoveCard();
		}
		emptyContent.SetActive(value: false);
		cardContent.gameObject.SetActive(value: false);
		lockContent.SetActive(value: true);
		vipContent.SetActive(value: false);
		HighlightAnimating(highlight: false);
		mWarcardsLocked = false;
	}

	public void SetVip()
	{
		if (card != null)
		{
			RemoveCard();
		}
		emptyContent.SetActive(value: false);
		cardContent.gameObject.SetActive(value: false);
		lockContent.SetActive(value: false);
		vipContent.SetActive(value: true);
		HighlightAnimating(highlight: false);
		mWarcardsLocked = false;
	}

	public void SetEmpty()
	{
		emptyContent.SetActive(value: true);
		emptyLabel.gameObject.SetActive(value: true);
		emptyBorder.color = ((!isBuddyContainer) ? Color.white : Colours.pink);
		cardContent.gameObject.SetActive(value: false);
		lockContent.SetActive(value: false);
		vipContent.SetActive(value: false);
		HighlightAnimating(highlight: false);
		mWarcardsLocked = false;
	}

	public void SetWarcardsLocked()
	{
		emptyContent.SetActive(value: true);
		emptyLabel.gameObject.SetActive(value: false);
		if (mIsVipContainer)
		{
			emptyBorder.color = Colours.yellowVIPBg.ReplaceA(0.2f);
		}
		else if (isBuddyContainer)
		{
			emptyBorder.color = Colours.pink.ReplaceA(0.2f);
		}
		else
		{
			emptyBorder.color = Color.white.ReplaceA(0.2f);
		}
		cardContent.gameObject.SetActive(value: false);
		lockContent.SetActive(value: false);
		vipContent.SetActive(value: false);
		HighlightAnimating(highlight: false);
		mWarcardsLocked = true;
	}

	public void CraftingLook()
	{
		emptyContent.SetActive(value: true);
		emptyLabel.gameObject.SetActive(value: false);
		cardContent.gameObject.SetActive(value: true);
		TweenAlpha component = cardContent.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		cardContent.alpha1 = 0.8f;
	}

	public void NormalLook()
	{
		TweenAlpha component = cardContent.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		cardContent.alpha1 = 1f;
		TweenScale component2 = cardContent.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		cardContent.transform.localScale = Vector3.one;
	}

	public void ClaimAnimation()
	{
		TweenScale.Begin(cardContent.gameObject, 0.2f, Vector3.one, new Vector3(0.001f, 0.001f, 1f)).onFinished = delegate
		{
			SetEmpty();
			NormalLook();
		};
	}

	public void HookEvents()
	{
	}

	public void RemoveCard()
	{
		SetEmpty();
		if (GuiScreenSingle<CardSelectionScreen>.instance.isShowed && card != null)
		{
			GuiScreenSingle<CardSelectionScreen>.instance.UpdateAvailability(card, available: true);
		}
		else if (GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.isActive && card != null)
		{
			GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.UpdateCardRecord(card);
		}
		card = null;
		if (this.ChangedContent != null)
		{
			this.ChangedContent();
		}
	}

	public bool InsertCard(Card insertCard, bool playSound = true)
	{
		if (CheckIfVIPChanged())
		{
			return false;
		}
		card = insertCard;
		emptyContent.SetActive(value: false);
		cardContent.gameObject.SetActive(value: true);
		TweenAlpha.Begin(cardContent.gameObject, 0f, 1f);
		HighlightAnimating(highlight: false);
		card.SetUpSmallCard(cardBackground, cardIcon, cardBonusIcon, cardBonusName, cardTexture);
		card.SetUpSmallCard(dragBackground, dragIcon, dragBonusIcon, dragBonusName, dragTexture);
		NormalLook();
		if (playSound)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CardEquiped);
		}
		if (this.ChangedContent != null)
		{
			this.ChangedContent();
		}
		return true;
	}

	public bool InsertCardRecord(CardRecord cardRecord)
	{
		if (CheckIfVIPChanged())
		{
			return false;
		}
		bool flag = cardRecord.card.isBuddyCard && !isBuddyContainer;
		bool flag2 = !cardRecord.card.isBuddyCard && isBuddyContainer;
		if (!DebugSettings.debugEnabled && (flag2 || flag))
		{
			return false;
		}
		card = cardRecord.card;
		HighlightAnimating(highlight: false);
		card.SetUpSmallCard(cardBackground, cardIcon, cardBonusIcon, cardBonusName, cardTexture);
		card.SetUpSmallCard(dragBackground, dragIcon, dragBonusIcon, dragBonusName, dragTexture);
		NormalLook();
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CardEquiped);
		AnimateInsertWarcard(cardRecord.dragCardTransform.position);
		dragPart.transform.position = cardRecord.dragCardTransform.position;
		if (this.ChangedContent != null)
		{
			this.ChangedContent();
		}
		return true;
	}

	private void AnimateInsertWarcard(Vector3 positionFrom)
	{
		if (GuiScreenSingle<CardSelectionScreen>.instance.isFullyShowed || GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.isActive)
		{
			dragPart.transform.localPosition = new Vector3(0f, 0f, dragPart.transform.localPosition.z);
			dragPart.gameObject.SetActive(value: true);
			TweenAlpha.Begin(dragPart.gameObject, 0f, 1f);
			TweenPosition.Begin(dragPart.gameObject, 0.5f, positionFrom, dragPart.transform.position, useLocal: false).onFinished = delegate
			{
				AfterInsertAnimation();
			};
		}
	}

	private void AfterInsertAnimation()
	{
		if ((GuiScreenSingle<CardSelectionScreen>.instance.isFullyShowed || GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.isActive) && card != null)
		{
			emptyContent.SetActive(value: false);
			cardContent.gameObject.SetActive(value: true);
			TweenAlpha.Begin(cardContent.gameObject, 0f, 1f);
		}
		dragPart.gameObject.SetActive(value: false);
	}

	private bool CheckIfVIPChanged()
	{
		if (mIsVipContainer && !Singleton<VipManager>.instance.IsVipActive())
		{
			if (card != null)
			{
				RemoveCard();
			}
			SetVip();
			return true;
		}
		return false;
	}

	public void Highlight(bool highlight)
	{
		HighlightAnimating(highlight);
	}

	private void HighlightAnimating(bool highlight)
	{
		if (mHighlighted != highlight)
		{
			mHighlighted = highlight;
			TweenAlpha.Begin(highlightBackground.gameObject, 0.2f, (!highlight) ? 0f : 0.5f);
		}
	}

	private void ChangedContentOfContainerUpdate()
	{
		if (card == null)
		{
			emptyContent.SetActive(value: true);
			cardContent.gameObject.SetActive(value: false);
			lockContent.SetActive(value: false);
			vipContent.SetActive(value: false);
			HighlightAnimating(highlight: false);
		}
		else
		{
			emptyContent.SetActive(value: false);
			cardContent.gameObject.SetActive(value: true);
			TweenAlpha.Begin(cardContent.gameObject, 0f, 1f);
			lockContent.SetActive(value: false);
			vipContent.SetActive(value: false);
			HighlightAnimating(highlight: false);
			card.SetUpSmallCard(cardBackground, cardIcon, cardBonusIcon, cardBonusName, cardTexture);
			card.SetUpSmallCard(dragBackground, dragIcon, dragBonusIcon, dragBonusName, dragTexture);
		}
	}

	public Card ChangeCards(Card newCard)
	{
		Card result = card;
		card = newCard;
		SoundsManager.Instance.PlayButtonClickedSound();
		ChangedContentOfContainerUpdate();
		return result;
	}

	private void OnDrag(Vector2 delta)
	{
		if ((GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.isActive && !GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.canChangeContent) || !base.enabled || isEmpty || isBuddyContainer || UICamera.currentTouchID <= -2)
		{
			return;
		}
		if (mDragType == DragType.None)
		{
			mDragType = DragType.Drag;
		}
		if (!dragPart.gameObject.activeSelf)
		{
			dragPart.gameObject.SetActive(value: true);
			TweenAlpha.Begin(dragPart.gameObject, 0f, 1f);
		}
		dragPart.transform.localPosition += Vector3.Scale(mScreenScale, delta);
		RaycastHit hit = default(RaycastHit);
		Vector3 inPos = Singleton<GuiManager>.instance.guiCamera.WorldToScreenPoint(dragPart.transform.position);
		if (UICamera.Raycast(inPos, ref hit))
		{
			CardContainer cardContainer = ((!(hit.collider != null)) ? null : hit.collider.GetComponent<CardContainer>());
			if (cardContainer != mContainer)
			{
				if (mContainer != null && mContainer != this)
				{
					mContainer.Highlight(highlight: false);
				}
				mContainer = cardContainer;
				if (mContainer != null && mContainer != this)
				{
					bool highlight = mContainer.isAvailable && ((card.isBuddyCard && mContainer.isBuddyContainer) || (!card.isBuddyCard && !mContainer.isBuddyContainer));
					mContainer.Highlight(highlight);
				}
			}
		}
		else if (mContainer != null)
		{
			if (mContainer != this)
			{
				mContainer.Highlight(highlight: false);
			}
			mContainer = null;
		}
	}

	private void OnPress(bool isPressed)
	{
		if (mWarcardsLocked || (GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.isActive && !GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.canChangeContent))
		{
			return;
		}
		if (base.enabled && !isEmpty && !isBuddyContainer)
		{
			Highlight(highlight: true);
			if (isPressed)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CardReturn);
				mContainer = null;
				UIDraggablePanel.panelDisabled = true;
				dragPart.transform.position = UICamera.currentCamera.ScreenToWorldPoint(new Vector3(UICamera.currentTouch.pos.x, UICamera.currentTouch.pos.y));
				dragPart.transform.localPosition = new Vector3(dragPart.transform.localPosition.x, dragPart.transform.localPosition.y, -50f);
				mIsDragging = true;
				UICamera.stickyPress = true;
			}
			else if (mIsDragging)
			{
				UIDraggablePanel.panelDisabled = false;
				dragPart.gameObject.SetActive(value: false);
				mIsDragging = false;
				UICamera.stickyPress = false;
			}
			if (!isPressed)
			{
				Drop();
			}
			mDragType = DragType.None;
		}
		if (!isPressed && (vipContent.activeSelf || lockContent.activeSelf) && TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			DialogManager.instance.HideAllDialogs();
		}
		if (!isPressed && vipContent.activeSelf && !GuiElementSingle<BuyVIPDialog>.instance.isShowed)
		{
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		}
		if (!isPressed && lockContent.activeSelf && !GuiElementSingle<CardsAndPacksDialog>.instance.isShowed)
		{
			GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.valuePack);
		}
		if (!isPressed && isBuddyContainer)
		{
			if (!isEmpty)
			{
				RemoveCard();
			}
			else if (GuiScreenSingle<CardSelectionScreen>.instance.isShowed)
			{
				GuiScreenSingle<CardSelectionScreen>.instance.BuddyCardContainerClicked();
			}
		}
	}

	private void Drop()
	{
		if (!GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.isActive || GuiScreenSingle<CardMenuScreen>.instance.craftCardsContent.canChangeContent)
		{
			Highlight(highlight: false);
			dragPart.gameObject.SetActive(value: false);
			if ((mDragType == DragType.None || mContainer == null) && isAvailable && !isEmpty && cardContent.alpha1 == 1f)
			{
				RemoveCard();
			}
			if (mDragType != DragType.None && mContainer != null && mContainer.isAvailable && !card.isBuddyCard && !mContainer.isBuddyContainer && mContainer != this)
			{
				card = mContainer.ChangeCards(card);
				ChangedContentOfContainerUpdate();
			}
		}
	}

	protected void Update()
	{
		if (!cardTexture.gameObject.activeSelf && card != null && card.iconTexture != null)
		{
			cardIcon.gameObject.SetActive(value: false);
			cardTexture.gameObject.SetActive(value: true);
			cardTexture.mainTexture = card.iconTexture;
			dragIcon.gameObject.SetActive(value: false);
			dragTexture.gameObject.SetActive(value: true);
			dragTexture.mainTexture = card.iconTexture;
		}
	}

	public void DoAfterHide()
	{
		card = null;
	}
}
