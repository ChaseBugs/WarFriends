using System;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class RewardDialog : GuiElementSingle<RewardDialog>, IGuiDialog
{
	[Header("Core")]
	public UISprite background;

	public UILabel title;

	public UISprite rewardBackground;

	public UISprite icon;

	public UISprite glow;

	[Header("-DogTag Part")]
	public UISprite dogtagIcon;

	[Header("-Card Part")]
	public GameObject cardHolder;

	public CardRecord cardRecord;

	[Header("-Reward Number Or Text")]
	public GameObject rewardHolder;

	public UILabel rewardValue;

	[Header("-Power Band")]
	public GameObject powerBandHolder;

	public UISprite powerBandIcon;

	public UISprite powerBandInfoBackground;

	public UISprite powerBandSmallIco;

	public UILabel powerBandValue;

	public UILabel powerBandType;

	[Header("-CardPack")]
	public UISprite cardPackIcon;

	[Header("Bottom")]
	public GameObject oneButtonBottom;

	public GameObject thanksButton;

	public GameObject collectButton;

	public GameObject twoButtonsBottom;

	public GameObject laterButton;

	public GameObject getMoreButton;

	[Header("Animation")]
	public CardMenuOwerlay cardAnimation;

	private RewardDialogType mRewardType;

	private long mAmount;

	private Card mCard;

	private PlayerVisual mPowerBand;

	private CardPack mCardPack;

	private Card[] mCards;

	private RadicalRoutine mCheckDogtags;

	private int mDailyRewardDay;

	public void ShowDialog(RewardDialogType type)
	{
		mRewardType = type;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowDialog(RewardDialogType type, long amount)
	{
		mRewardType = type;
		mAmount = amount;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowDialog(RewardDialogType type, JToken card)
	{
		mRewardType = type;
		mCard = ((card != null) ? CardManager.instance.GetCardInstance(card.ToString()) : null);
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowDialog(RewardDialogType type, PlayerVisual powerBand, long seconds)
	{
		mRewardType = type;
		mPowerBand = powerBand;
		mAmount = seconds;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowDialog(RewardDialogType type, CardPack cardPackType, Card[] cards)
	{
		mRewardType = type;
		mCardPack = cardPackType;
		mCards = cards;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowDialog(RewardDialogType type, long collectReward, int day)
	{
		mRewardType = type;
		mAmount = collectReward;
		mDailyRewardDay = day;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(thanksButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(collectButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CollectClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(laterButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener4 = UIEventListener.Get(getMoreButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(WatchAgain));
	}

	private void CollectClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
		Singleton<EventTrackingManager>.instance.Claim7DayInApp(mDailyRewardDay);
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void WatchAgain(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.ShowRewardedVideo(RewardType.Dogtag);
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		oneButtonBottom.SetActive(value: true);
		twoButtonsBottom.SetActive(value: false);
		background.transform.localScale = background.transform.localScale.ReplaceY(862f);
		Color color = ((mRewardType != RewardDialogType.Tickets && mRewardType != RewardDialogType.Scraps) ? Colours.blue : Colours.greenArena);
		glow.color = color;
		title.text = Localization.Localize((mRewardType != RewardDialogType.DailyGold) ? "ID_YOURREWARD" : "ID_DAILYGOLDBOOSTER");
		icon.gameObject.SetActive(mRewardType == RewardDialogType.Gold || mRewardType == RewardDialogType.Warbucks || mRewardType == RewardDialogType.VIP || mRewardType == RewardDialogType.DailyGold || mRewardType == RewardDialogType.Tickets || mRewardType == RewardDialogType.Scraps);
		rewardHolder.SetActive(mRewardType == RewardDialogType.Gold || mRewardType == RewardDialogType.Warbucks || mRewardType == RewardDialogType.VIP || mRewardType == RewardDialogType.PowerBand || mRewardType == RewardDialogType.DailyGold || mRewardType == RewardDialogType.Tickets || mRewardType == RewardDialogType.Scraps);
		dogtagIcon.gameObject.SetActive(mRewardType == RewardDialogType.Dogtag);
		cardHolder.SetActive(mRewardType == RewardDialogType.WarCard);
		cardPackIcon.gameObject.SetActive(mRewardType == RewardDialogType.CardPack);
		powerBandHolder.SetActive(mRewardType == RewardDialogType.PowerBand);
		if (mRewardType == RewardDialogType.Gold || mRewardType == RewardDialogType.Warbucks || mRewardType == RewardDialogType.DailyGold || mRewardType == RewardDialogType.Scraps)
		{
			SetAmountReward(mAmount);
		}
		else if (mRewardType == RewardDialogType.VIP || mRewardType == RewardDialogType.PowerBand)
		{
			SetTimeReward(mAmount);
		}
		else if (mRewardType == RewardDialogType.Tickets)
		{
			SetTextReward(Localization.LocalizeFormat("ID_XARENATICKETS", MiscTools.FormatBigNumberLong(mAmount)));
		}
		switch (mRewardType)
		{
		case RewardDialogType.Gold:
		case RewardDialogType.DailyGold:
			SetIcon("menu-gold", 1.5f, Quaternion.Euler(0f, 180f, 0f));
			break;
		case RewardDialogType.Dogtag:
			InitializeDogtagLook();
			StartCheck();
			break;
		case RewardDialogType.WarCard:
			SetCard(mCard);
			break;
		case RewardDialogType.Warbucks:
			SetIcon("menu-warbucks", 1.5f, Quaternion.Euler(0f, 0f, 0f));
			break;
		case RewardDialogType.VIP:
			SetIcon("menu-hub-multiplayer-vipico", 2f, Quaternion.Euler(0f, 0f, 0f));
			break;
		case RewardDialogType.PowerBand:
			SetPowerBand(mPowerBand);
			break;
		case RewardDialogType.CardPack:
			SetCardPack(mCardPack);
			break;
		case RewardDialogType.Tickets:
			SetIcon("menu-arena-ticket", 2.5f, Quaternion.Euler(0f, 0f, 0f));
			break;
		case RewardDialogType.Scraps:
			SetIcon("menu-arena-scrap-ico", 3f, Quaternion.Euler(0f, 0f, 0f));
			break;
		}
		thanksButton.SetActive(mRewardType != RewardDialogType.DailyGold);
		collectButton.SetActive(mRewardType == RewardDialogType.DailyGold);
		cardAnimation.ResetDraw();
	}

	private void SetIcon(string name, float scaleFactor, Quaternion rotation)
	{
		icon.spriteName = name;
		icon.MakePixelPerfect();
		icon.transform.localScale = icon.transform.localScale.MultiplyXY(scaleFactor);
		icon.transform.localRotation = rotation;
	}

	public void SetCard(Card card)
	{
		if (card == null)
		{
			Debug.LogError("null card in reward dialog");
			cardHolder.SetActive(value: false);
		}
		else
		{
			cardRecord.Initialize(card);
		}
	}

	private void SetCardPack(CardPack type)
	{
		cardPackIcon.spriteName = GameVariables.cardpackLook[type].Value2;
		cardPackIcon.MakePixelPerfect();
		cardPackIcon.transform.localScale = cardPackIcon.transform.localScale.MultiplyXY(0.9f);
	}

	private void SetTextReward(string text)
	{
		rewardValue.text = text;
		float val = 60f + rewardValue.relativeSize.x * rewardValue.transform.localScale.x;
		rewardBackground.transform.localScale = rewardBackground.transform.localScale.ReplaceX(val);
	}

	private void SetAmountReward(long amount)
	{
		rewardValue.text = MiscTools.FormatBigNumberLong(amount);
		float val = 60f + rewardValue.relativeSize.x * rewardValue.transform.localScale.x;
		rewardBackground.transform.localScale = rewardBackground.transform.localScale.ReplaceX(val);
	}

	private void SetTimeReward(long amount)
	{
		int seconds = (int)amount;
		rewardValue.text = MiscTools.PrintableTimeVipConvert(seconds);
		float val = 60f + rewardValue.relativeSize.x * rewardValue.transform.localScale.x;
		rewardBackground.transform.localScale = rewardBackground.transform.localScale.ReplaceX(val);
	}

	private void SetPowerBand(PlayerVisual powerBand)
	{
		powerBandIcon.spriteName = powerBand.icon;
		powerBandIcon.MakePixelPerfect();
		powerBandIcon.transform.localScale = powerBandIcon.transform.localScale.MultiplyXY(2f);
		powerBandSmallIco.spriteName = powerBand.decalMiniIcon;
		powerBandSmallIco.color = powerBand.decalMiniIconColor;
		powerBandValue.text = powerBand.decalValueString;
		powerBandType.text = powerBand.decalShortName;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		if (mCards != null && mCards.Length > 0)
		{
			cardAnimation.StartShowAnimation(mCards, 0.5f);
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		mCards = new Card[0];
		mAmount = 0L;
		mCard = null;
		mPowerBand = null;
		mCardPack = CardPack.None;
		StopCheck();
	}

	public void StartCheck()
	{
		StopCheck();
		mCheckDogtags = RadicalRoutine.Create(CheckDogtags());
		StartCoroutine(RadicalRoutine.Run(mCheckDogtags.enumerator));
	}

	private void StopCheck()
	{
		if (mCheckDogtags != null)
		{
			mCheckDogtags.Cancel();
			mCheckDogtags = null;
		}
	}

	private IEnumerator CheckDogtags()
	{
		while (isShowed)
		{
			if (Singleton<DogTagManager>.instance.isFull || Singleton<EventTrackingManager>.instance.IsRewardVideoPreloaded(RewardType.Dogtag))
			{
				InitializeDogtagLook();
			}
			yield return new WaitForRealSeconds(0.333f);
		}
	}

	private void InitializeDogtagLook()
	{
		bool flag = Singleton<EventTrackingManager>.instance.IsRewardVideoPreloaded(RewardType.Dogtag);
		bool isFull = Singleton<DogTagManager>.instance.isFull;
		bool flag2 = flag && !isFull;
		oneButtonBottom.SetActive(!flag2);
		twoButtonsBottom.SetActive(flag2);
		background.transform.localScale = background.transform.localScale.ReplaceY((!flag2) ? 862f : 972f);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		if (thanksButton.activeSelf)
		{
			CloseDialog(thanksButton.gameObject);
		}
		else if (collectButton.activeSelf)
		{
			CloseDialog(collectButton.gameObject);
		}
	}
}
