using System;
using UnityEngine;

public class SpecialPackRecord : PoolableObject
{
	[Header("Core")]
	public BoxCollider boxCollider;

	public UIPanel[] otherPanels;

	[Header("-Background")]
	public UISprite background;

	public UISprite backgroundTop;

	public UISprite backgroundBottom;

	public UISprite backgroundLeft;

	public UISprite backgroundRight;

	[Header("-Header")]
	public GameObject headerPart;

	public UILabel packNameLabel;

	public UISprite packLeftWing;

	public UISprite packRightWing;

	[Header("-Offer Active")]
	public GameObject offerActive;

	public UILabel offerActiveTime;

	[Header("-Sale")]
	public GameObject salePart;

	public UILabel salePercent;

	[Header("-Starter Pack Content")]
	public GameObject starterPackPart;

	[Header("-Value Pack Content")]
	public GameObject valuePackPart;

	[Header("-Boxes")]
	public SpecialPackBoxItem[] boxes;

	[Header("-Bottom Button")]
	public UILabel packPrize;

	public StrikethroughPrize packPrizeStrikeThroughSetter;

	public UILabel packRealPrize;

	[Header("-Purchased")]
	public GameObject packPurchased;

	private SpecialPackContent mPackToShow;

	private int mEndTime;

	public void InitializeStarterPack()
	{
		mPackToShow = Singleton<GameVariables>.instance.starterPack;
		UIEventListener uIEventListener = UIEventListener.Get(boxCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BuyPack));
		UIEventListener uIEventListener2 = UIEventListener.Get(boxCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BuyPack));
		starterPackPart.SetActive(value: true);
		valuePackPart.SetActive(value: false);
		packNameLabel.text = Localization.Localize("ID_STARTERPACK");
		MiscTools.SetUILabelRescale(packNameLabel, 62f, 31f, 450);
		float num = packNameLabel.relativeSize.x * packNameLabel.transform.localScale.x / 2f + 34f;
		packLeftWing.transform.localPosition = packLeftWing.transform.localPosition.ReplaceX(0f - num);
		packRightWing.transform.localPosition = packRightWing.transform.localPosition.ReplaceX(num);
		mEndTime = PlayerAnalytics.instance.data.starterPackDeadline;
		bool active = mEndTime != 0;
		offerActive.SetActive(active);
		UpdateOfferTime();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterBySecond = (Action)Delegate.Remove(instance.updateCounterBySecond, new Action(UpdateOfferTime));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.updateCounterBySecond = (Action)Delegate.Combine(instance2.updateCounterBySecond, new Action(UpdateOfferTime));
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(CardPack.Starter);
		bool flag = num2 > 0f;
		salePart.SetActive(flag);
		if (flag)
		{
			salePercent.text = Localization.LocalizeFormat("ID_SALEPERCENT", MiscTools.RoundToInt(num2 * 100f));
			MiscTools.SetUILabelRescale(salePercent, 52f, 26f, 290);
		}
		headerPart.transform.localPosition = new Vector3((!flag) ? 0f : (-40f), headerPart.transform.localPosition.y, headerPart.transform.localPosition.z);
		HideAllBoxes();
		boxes[0].Initialize(2, 5, mPackToShow.contentOfPack[0]);
		boxes[0].freeSticker.SetActive(mPackToShow.contentOfPack[0].type != SpecialPackContent.ContentType.Customization);
		boxes[0].gameObject.SetActive(value: true);
		boxes[1].Initialize(3, 5, mPackToShow.contentOfPack[1]);
		boxes[1].freeSticker.SetActive(mPackToShow.contentOfPack[1].type != SpecialPackContent.ContentType.Customization);
		boxes[1].gameObject.SetActive(value: true);
		boxes[2].Initialize(4, 5, mPackToShow.contentOfPack[2]);
		boxes[2].freeSticker.SetActive(mPackToShow.contentOfPack[2].type != SpecialPackContent.ContentType.Customization);
		boxes[2].gameObject.SetActive(value: true);
		boxes[3].Initialize(5, 5, mPackToShow.contentOfPack[3]);
		boxes[3].freeSticker.SetActive(mPackToShow.contentOfPack[3].type != SpecialPackContent.ContentType.Customization);
		boxes[3].gameObject.SetActive(value: true);
		string value = Singleton<GameVariables>.instance.PriceOfPack(CardPack.Starter).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(CardPack.Starter).Value2;
		SetBottomButton(flag, value, value2);
		bool purchased = PlayerAnalytics.instance.data.IsPackBought(CardPack.Starter);
		SetPurchased(purchased);
	}

	public void InitializeValuePack()
	{
		mPackToShow = Singleton<GameVariables>.instance.valuePack;
		UIEventListener uIEventListener = UIEventListener.Get(boxCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BuyPack));
		UIEventListener uIEventListener2 = UIEventListener.Get(boxCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BuyPack));
		starterPackPart.SetActive(value: false);
		valuePackPart.SetActive(value: true);
		packNameLabel.text = Localization.Localize("ID_VALUEPACK");
		MiscTools.SetUILabelRescale(packNameLabel, 62f, 31f, 450);
		float num = packNameLabel.relativeSize.x * packNameLabel.transform.localScale.x / 2f + 34f;
		packLeftWing.transform.localPosition = packLeftWing.transform.localPosition.ReplaceX(0f - num);
		packRightWing.transform.localPosition = packRightWing.transform.localPosition.ReplaceX(num);
		mEndTime = 0;
		offerActive.SetActive(value: false);
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(CardPack.Value);
		bool flag = num2 > 0f;
		salePart.SetActive(flag);
		if (flag)
		{
			salePercent.text = Localization.LocalizeFormat("ID_SALEPERCENT", MiscTools.RoundToInt(num2 * 100f));
			MiscTools.SetUILabelRescale(salePercent, 52f, 26f, 290);
		}
		headerPart.transform.localPosition = new Vector3((!flag) ? 0f : (-40f), headerPart.transform.localPosition.y, headerPart.transform.localPosition.z);
		HideAllBoxes();
		boxes[0].Initialize(2, 5, mPackToShow.contentOfPack[0]);
		boxes[0].freeSticker.SetActive(mPackToShow.contentOfPack[0].type != SpecialPackContent.ContentType.Customization);
		boxes[0].gameObject.SetActive(value: true);
		if (mPackToShow.contentOfPack[0].type == SpecialPackContent.ContentType.Customization && mPackToShow.contentOfPack[0].visual.owner.categoryNumber != 0)
		{
			boxes[0].AlterShownCustomization(2, 5);
		}
		boxes[1].Initialize(3, 5, mPackToShow.contentOfPack[1]);
		boxes[1].freeSticker.SetActive(mPackToShow.contentOfPack[1].type != SpecialPackContent.ContentType.Customization);
		boxes[1].gameObject.SetActive(value: true);
		if (mPackToShow.contentOfPack[1].type == SpecialPackContent.ContentType.Customization && mPackToShow.contentOfPack[1].visual.owner.categoryNumber != 0)
		{
			boxes[1].AlterShownCustomization(3, 5);
		}
		boxes[2].Initialize(4, 5, mPackToShow.contentOfPack[2]);
		boxes[2].freeSticker.SetActive(mPackToShow.contentOfPack[2].type != SpecialPackContent.ContentType.Customization);
		boxes[2].gameObject.SetActive(value: true);
		if (mPackToShow.contentOfPack[2].type == SpecialPackContent.ContentType.Customization && mPackToShow.contentOfPack[2].visual.owner.categoryNumber != 0)
		{
			boxes[2].AlterShownCustomization(4, 5);
		}
		boxes[3].Initialize(5, 5, mPackToShow.contentOfPack[3]);
		boxes[3].freeSticker.SetActive(mPackToShow.contentOfPack[3].type != SpecialPackContent.ContentType.Customization);
		boxes[3].gameObject.SetActive(value: true);
		if (mPackToShow.contentOfPack[3].type == SpecialPackContent.ContentType.Customization && mPackToShow.contentOfPack[3].visual.owner.categoryNumber != 0)
		{
			boxes[3].AlterShownCustomization(5, 5);
		}
		string value = Singleton<GameVariables>.instance.PriceOfPack(CardPack.Value).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(CardPack.Value).Value2;
		SetBottomButton(flag, value, value2);
		bool purchased = PlayerAnalytics.instance.data.IsPackBought(CardPack.Value);
		SetPurchased(purchased);
	}

	public void InitializeMoneyPack()
	{
		mPackToShow = Singleton<GameVariables>.instance.moneyPack;
		UIEventListener uIEventListener = UIEventListener.Get(boxCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BuyPack));
		UIEventListener uIEventListener2 = UIEventListener.Get(boxCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BuyPack));
		starterPackPart.SetActive(value: false);
		valuePackPart.SetActive(value: false);
		packNameLabel.text = Localization.Localize("ID_MONEYPACK");
		MiscTools.SetUILabelRescale(packNameLabel, 62f, 31f, 450);
		float num = packNameLabel.relativeSize.x * packNameLabel.transform.localScale.x / 2f + 34f;
		packLeftWing.transform.localPosition = packLeftWing.transform.localPosition.ReplaceX(0f - num);
		packRightWing.transform.localPosition = packRightWing.transform.localPosition.ReplaceX(num);
		mEndTime = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = mEndTime != 0;
		offerActive.SetActive(active);
		UpdateOfferTime();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterBySecond = (Action)Delegate.Remove(instance.updateCounterBySecond, new Action(UpdateOfferTime));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.updateCounterBySecond = (Action)Delegate.Combine(instance2.updateCounterBySecond, new Action(UpdateOfferTime));
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(CardPack.Money);
		bool flag = num2 > 0f;
		salePart.SetActive(flag);
		if (flag)
		{
			salePercent.text = Localization.LocalizeFormat("ID_SALEPERCENT", MiscTools.RoundToInt(num2 * 100f));
			MiscTools.SetUILabelRescale(salePercent, 52f, 26f, 290);
		}
		headerPart.transform.localPosition = new Vector3((!flag) ? 0f : (-40f), headerPart.transform.localPosition.y, headerPart.transform.localPosition.z);
		HideAllBoxes();
		boxes[0].Initialize(1, 3, mPackToShow.contentOfPack[0]);
		boxes[0].freeSticker.SetActive(value: false);
		boxes[0].gameObject.SetActive(value: true);
		boxes[1].Initialize(2, 3, mPackToShow.contentOfPack[1]);
		boxes[1].freeSticker.SetActive(value: false);
		boxes[1].gameObject.SetActive(value: true);
		boxes[2].Initialize(3, 3, mPackToShow.contentOfPack[2]);
		boxes[2].freeSticker.SetActive(value: false);
		boxes[2].gameObject.SetActive(value: true);
		string value = Singleton<GameVariables>.instance.PriceOfPack(CardPack.Money).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(CardPack.Money).Value2;
		SetBottomButton(flag, value, value2);
		bool purchased = PlayerAnalytics.instance.data.IsPackBought(CardPack.Money);
		SetPurchased(purchased);
	}

	public void Initialize(SpecialPackContent packToShow)
	{
		if (!EnoughtBoxes())
		{
			Debug.LogError("Missing references in Special Pack Record: " + base.gameObject.name);
			return;
		}
		mPackToShow = packToShow;
		UIEventListener uIEventListener = UIEventListener.Get(boxCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BuyPack));
		UIEventListener uIEventListener2 = UIEventListener.Get(boxCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BuyPack));
		starterPackPart.SetActive(value: false);
		valuePackPart.SetActive(value: false);
		packNameLabel.text = packToShow.name;
		MiscTools.SetUILabelRescale(packNameLabel, 62f, 31f, 450);
		float num = packNameLabel.relativeSize.x * packNameLabel.transform.localScale.x / 2f + 34f;
		packLeftWing.transform.localPosition = packLeftWing.transform.localPosition.ReplaceX(0f - num);
		packRightWing.transform.localPosition = packRightWing.transform.localPosition.ReplaceX(num);
		mEndTime = packToShow.finishAt;
		bool active = mEndTime != 0;
		offerActive.SetActive(active);
		UpdateOfferTime();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterBySecond = (Action)Delegate.Remove(instance.updateCounterBySecond, new Action(UpdateOfferTime));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.updateCounterBySecond = (Action)Delegate.Combine(instance2.updateCounterBySecond, new Action(UpdateOfferTime));
		bool flag = packToShow.sale > 0f;
		salePart.SetActive(flag);
		if (flag)
		{
			salePercent.text = Localization.LocalizeFormat("ID_SALEPERCENT", MiscTools.RoundToInt(packToShow.sale * 100f));
			MiscTools.SetUILabelRescale(salePercent, 52f, 26f, 290);
		}
		headerPart.transform.localPosition = new Vector3((!flag) ? 0f : (-40f), headerPart.transform.localPosition.y, headerPart.transform.localPosition.z);
		HideAllBoxes();
		int num2 = packToShow.contentOfPack.Length;
		if (num2 < 2)
		{
			if (num2 == 1)
			{
				boxes[0].Initialize(1, 2, packToShow.contentOfPack[0]);
				boxes[0].gameObject.SetActive(value: true);
			}
		}
		else
		{
			for (int i = 1; i <= num2 && i <= 6; i++)
			{
				SpecialPackContent.Content content = packToShow.contentOfPack[i - 1];
				boxes[i - 1].Initialize(i, num2, content);
				boxes[i - 1].gameObject.SetActive(value: true);
				if (packToShow.packId.StartsWith("elitepack") && (content.type == SpecialPackContent.ContentType.Gold || content.type == SpecialPackContent.ContentType.Gold))
				{
					boxes[i - 1].freeSticker.SetActive(value: true);
				}
			}
		}
		SetBottomButton(flag, packToShow.currentPrize, packToShow.realPrize);
		bool purchased = PlayerAnalytics.instance.IsPackBought(packToShow.packId);
		SetPurchased(purchased);
	}

	public void AnimatePanels(bool instant, bool show)
	{
		float duration = ((!instant) ? (GuiElementSingle<InappScreen>.instance.dur * 2f) : 0.01f);
		float num = ((!show) ? 0f : 1f);
		if (otherPanels != null)
		{
			for (int i = 0; i < otherPanels.Length; i++)
			{
				if (!(otherPanels[i] == null) && otherPanels[i].gameObject.activeSelf)
				{
					TweenAlpha.Begin(otherPanels[i].gameObject, duration, num);
				}
			}
		}
		for (int j = 0; j < boxes.Length; j++)
		{
			boxes[j].OverrideTweenPanels(duration, num);
		}
	}

	private void SetPurchased(bool purchased)
	{
		packPurchased.SetActive(purchased);
		boxCollider.enabled = !purchased;
		if (purchased)
		{
			TweenAlpha.Begin(packPurchased, 0f, 1f);
		}
	}

	private void BuyPack(GameObject go)
	{
		if (!packPurchased.activeSelf)
		{
			Debug.Log("Clicked buy on " + mPackToShow.packId);
			SoundsManager.Instance.PlayButtonClickedSound();
			Singleton<BeanstalkServerManager>.instance.BuyPack(mPackToShow.packId, "WarShop");
		}
	}

	private void SetBottomButton(bool isSale, string prizeOfPack, string fullPrize)
	{
		packPrize.text = prizeOfPack;
		MiscTools.SetUILabelRescale(packPrize, 42f, 22f, 230);
		packRealPrize.transform.localPosition = packRealPrize.transform.localPosition.ReplaceY(packPrize.transform.localPosition.y);
		packRealPrize.transform.localScale = packPrize.transform.localScale;
		packRealPrize.text = ((!isSale) ? string.Empty : fullPrize);
		packPrizeStrikeThroughSetter.gameObject.SetActive(isSale);
		if (isSale)
		{
			packPrizeStrikeThroughSetter.SetUpStrikeThrought();
		}
	}

	private void UpdateOfferTime()
	{
		if (mEndTime > 0)
		{
			int num = mEndTime - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			offerActiveTime.text = string.Format("{0} {1}", Localization.Localize("ID_OFFERACTIVE"), MiscTools.PrintableTime(num, "-", string.Empty, localizeReadyString: false));
			MiscTools.SetUILabelRescale(offerActiveTime, 33f, 20f, 360);
		}
	}

	private void HideAllBoxes()
	{
		SpecialPackBoxItem[] array = boxes;
		foreach (SpecialPackBoxItem specialPackBoxItem in array)
		{
			specialPackBoxItem.gameObject.SetActive(value: false);
		}
	}

	private bool EnoughtBoxes()
	{
		return boxes.Length >= 6;
	}

	public override void DestroyPooled()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterBySecond = (Action)Delegate.Remove(instance.updateCounterBySecond, new Action(UpdateOfferTime));
		UIEventListener uIEventListener = UIEventListener.Get(boxCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BuyPack));
		base.DestroyPooled();
	}
}
