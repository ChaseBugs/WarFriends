using UnityEngine;

public class CardpoolDialogCardRecord : Core_BaseScript
{
	public bool isBuddy = true;

	[Header("Core")]
	public BoxCollider boxCollider;

	[Header("Empty Part")]
	public GameObject emptyPart;

	public UISprite border;

	[Header("Card Part")]
	public GameObject cardPart;

	public UISprite cardBackground;

	public UISprite cardIcon;

	public UITexture cardTexture;

	public UISprite cardBonusIcon;

	public UILabel cardBonusLabel;

	public GameObject closeIcon;

	private Card mCard;

	public bool isAvailable => emptyPart.activeSelf || cardPart.activeSelf;

	public bool isEmpty => emptyPart.activeSelf && mCard == null;

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

	public void InitializeNoCard()
	{
		card = null;
		boxCollider.enabled = false;
		emptyPart.SetActive(value: false);
		cardPart.SetActive(value: false);
		StopTweens();
	}

	public void InitializeEmpty()
	{
		card = null;
		boxCollider.enabled = false;
		emptyPart.SetActive(value: true);
		cardPart.SetActive(value: false);
		StopTweens();
		border.color = ((!isBuddy) ? Colours.grayBorder : Colours.pink);
	}

	public void InitializeCard(Card insertCard, bool showEmpty = false, bool enableClose = true)
	{
		card = insertCard;
		boxCollider.enabled = true;
		emptyPart.SetActive(showEmpty);
		cardPart.SetActive(value: true);
		StopTweens();
		card.SetUpSmallCard(cardBackground, cardIcon, cardBonusIcon, cardBonusLabel, cardTexture);
		closeIcon.SetActive(enableClose && !isBuddy);
	}

	public void AnimateCard(CardRecord cardRecord)
	{
		InitializeCard(cardRecord.card, showEmpty: true, enableClose: false);
		cardPart.transform.position = cardRecord.transform.position;
		cardPart.transform.localPosition = new Vector3(cardPart.transform.localPosition.x, cardPart.transform.localPosition.y, -1f);
		TweenPosition.Begin(cardPart, 0.4f, new Vector3(0f, 0f, -1f)).onFinished = delegate
		{
			emptyPart.SetActive(value: false);
			closeIcon.SetActive(!isBuddy);
		};
	}

	public void OnClick()
	{
		if (this.card != null && !isBuddy)
		{
			Card card = this.card;
			InitializeEmpty();
			GuiElementSingle<CardpoolDialog>.instance.RemoveCard(card);
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CardReturn);
		}
	}

	private void StopTweens()
	{
		TweenPosition component = cardPart.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		cardPart.transform.localPosition = new Vector3(0f, 0f, -1f);
	}

	protected void Update()
	{
		if (!cardTexture.gameObject.activeSelf && card != null && card.iconTexture != null)
		{
			cardIcon.gameObject.SetActive(value: false);
			cardTexture.gameObject.SetActive(value: true);
			cardTexture.mainTexture = card.iconTexture;
		}
	}
}
