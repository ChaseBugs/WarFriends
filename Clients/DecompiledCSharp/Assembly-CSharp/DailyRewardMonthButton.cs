using System;
using UnityEngine;

public class DailyRewardMonthButton : PoolableObject
{
	[Header("Main content")]
	public Transform content;

	public UILabel count;

	public UISprite mainImage;

	public UISprite secondImage;

	public UISprite thirdImage;

	public UILabel secondLabel;

	public UISprite[] fromTopToBack;

	[Header("Top items")]
	public GameObject topHolder;

	public UISprite doubleIco;

	public UISprite doubleBG;

	[Header("Bottom items")]
	public UISprite checker;

	public UILabel text;

	public UISprite bg;

	[Header("Background")]
	public UISprite border;

	public GameObject actualGlow;

	public UISprite actualBorder;

	[Header("Not Available")]
	public GameObject notAvailablePart;

	[Header("Atlases")]
	public UIAtlas mainAtlas;

	public UIAtlas bigAtlas;

	public UIAtlas commonAtlas;

	public UIAtlas cardAtlas;

	public UIAtlas visualAtlas;

	private Action<int> onSelectButton;

	private int mMyIndex;

	private Vector3 mFacebookIconSize = new Vector3(34f, 34f, 1f);

	private UITweener[] mTweens = new UITweener[5];

	private static string[] cardpackNames = new string[3] { "menu-cards-bronzepack", "menu-cards-silverpack", "menu-cards-goldpack" };

	protected override void Awake()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(base.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(Select));
	}

	private void Select(GameObject go)
	{
		if (onSelectButton != null)
		{
			onSelectButton(mMyIndex);
		}
	}

	private void SetSprite(UISprite sprite, string spriteName, UIAtlas atlas, float scale, Vector3 localPosition)
	{
		localPosition = localPosition.ReplaceY(localPosition.y + 20f);
		sprite.cachedTransform.localPosition = localPosition;
		sprite.atlas = atlas;
		sprite.spriteName = spriteName;
		sprite.MakePixelPerfect();
		sprite.cachedTransform.localScale = new Vector3(sprite.cachedTransform.localScale.x * scale, sprite.cachedTransform.localScale.y * scale, 1f);
		sprite.enabled = true;
	}

	private void SetTextPosition(Vector3 localPosition)
	{
		localPosition = new Vector3(localPosition.x, localPosition.y - 34f, -2f);
		count.cachedTransform.localPosition = localPosition;
	}

	public void SetForData(int index, DailyRewardMonthScreen.DailyRewardDataForDay myData, int actual, bool canClaim, Action<int> selectButton, int lastClaimableIndex)
	{
		for (int i = 0; i < mTweens.Length; i++)
		{
			if (mTweens[i] != null)
			{
				mTweens[i].enabled = false;
				if (i == 4)
				{
					mTweens[i].Sample(0f, isFinished: true);
				}
			}
		}
		mMyIndex = index;
		onSelectButton = selectButton;
		SetTextPosition(new Vector3(0f, 0f, 0f));
		for (int j = 0; j < fromTopToBack.Length; j++)
		{
			fromTopToBack[j].gameObject.SetActive(value: false);
			fromTopToBack[j].cachedTransform.localRotation = Quaternion.identity;
			fromTopToBack[j].color = Color.white;
		}
		secondLabel.gameObject.SetActive(value: false);
		content.localScale = Vector3.one;
		content.localPosition = Vector3.zero;
		switch (myData.rewardType)
		{
		case DailyReward.Warbucks:
			WarbucksLook(myData.count);
			break;
		case DailyReward.Gold:
			GoldLook(myData.count);
			break;
		case DailyReward.BronzeCardpack:
		case DailyReward.SilverCardpack:
		case DailyReward.GoldCardpack:
			CardpackLook(myData.rewardType, (int)myData.count);
			break;
		case DailyReward.Vip:
			VipLook((int)myData.count);
			break;
		case DailyReward.PowerBand:
			PowerBandLook(myData.parameters, (int)myData.count);
			break;
		case DailyReward.ParticularCards:
			CustomWarCardsLook(myData.parameters, (int)myData.count);
			break;
		case DailyReward.BronzeCards:
		case DailyReward.SilverCards:
		case DailyReward.GoldCards:
			RandomWarCardsLook(myData.rewardType, (int)myData.count);
			break;
		case DailyReward.Customization:
			CustomizationLook(myData.parameters);
			break;
		case DailyReward.ArenaTickets:
			TicketsLook(myData.count);
			break;
		default:
			Debug.LogErrorFormat("Unimplemented daily reward visual for {1}:\n {0}", myData, base.name);
			break;
		}
		topHolder.SetActive(myData.doubleFor != DailyRewardDouble.None);
		if (myData.doubleFor == DailyRewardDouble.Facebook)
		{
			doubleIco.spriteName = "menu-tilegfx-facebook";
			doubleIco.cachedTransform.localScale = mFacebookIconSize;
		}
		else if (myData.doubleFor == DailyRewardDouble.VIP)
		{
			doubleIco.spriteName = "menu-dailyrewards-vip-ico";
			doubleIco.MakePixelPerfect();
		}
		if (index > lastClaimableIndex)
		{
			SetRedNotAvailableBackground();
		}
		else if (index < actual || (index == actual && !canClaim))
		{
			SetBlueClaimedBackground();
		}
		else if (index == actual && canClaim)
		{
			SetBlueClaimBackground();
		}
		else if (index - actual == 1)
		{
			SetYellowTomorrowBackground();
		}
		else
		{
			SetWhiteLoginBackground(index);
		}
	}

	private void TicketsLook(long amount)
	{
		SetSprite(mainImage, "menu-arena-ticket", mainAtlas, 1f, Vector3.zero);
		SetTextPosition(new Vector3(40f, -25f, 0f));
		count.enabled = true;
		count.text = $"x{MiscTools.FormatBigNumberLong(amount)}";
	}

	private void WarbucksLook(long amount)
	{
		SetSprite(mainImage, "menu-warbucks", mainAtlas, 1f, Vector3.zero);
		count.enabled = true;
		count.text = MiscTools.FormatBigNumberLong(amount);
	}

	private void GoldLook(long amount)
	{
		SetSprite(mainImage, "menu-gold", mainAtlas, 0.5f, Vector3.zero);
		count.enabled = true;
		count.text = MiscTools.FormatBigNumberLong(amount);
	}

	private void CardpackLook(DailyReward rewardType, int amount)
	{
		SetSprite(mainImage, cardpackNames[(int)(rewardType - 11)], bigAtlas, 0.3f, new Vector3(0f, 0f, -1f));
		if (amount > 1)
		{
			SetTextPosition(new Vector3(40f, -20f, 0f));
			count.enabled = true;
			count.text = amount.ToString("'x'0");
		}
		else
		{
			count.enabled = false;
		}
	}

	private void VipLook(int seconds)
	{
		SetSprite(mainImage, "menu-hub-multiplayer-vipico", mainAtlas, 0.666f, new Vector3(0f, 25f, 0f));
		SetTextPosition(new Vector3(0f, -15f, 0f));
		count.enabled = true;
		count.text = MiscTools.PrintableTimeVipConvertSmall(seconds * 3600);
	}

	private void PowerBandLook(string powerBandId, int seconds)
	{
		PlayerVisual powerBand = CamosManager.instance.GetPowerBand(powerBandId);
		SetSprite(mainImage, powerBand.icon, commonAtlas, 0.5f, new Vector3(-15f, 20f, -1f));
		SetSprite(secondImage, powerBand.decalMiniIcon, commonAtlas, 1f, new Vector3(35f, -15f, -1f));
		secondImage.color = powerBand.decalMiniIconColor;
		secondImage.gameObject.SetActive(value: true);
		secondLabel.text = powerBand.decalValueString;
		secondLabel.pivot = UIWidget.Pivot.Center;
		secondLabel.cachedTransform.localPosition = new Vector3(40f, 51f, -2f);
		secondLabel.gameObject.SetActive(value: true);
		SetTextPosition(new Vector3(0f, -25f, 0f));
		count.enabled = true;
		count.text = MiscTools.PrintableTimeVipConvertSmall(seconds * 3600);
	}

	private void CustomWarCardsLook(string warCardsIds, int amount)
	{
		string cardId = warCardsIds;
		int num = warCardsIds.IndexOf(';');
		if (num > 0)
		{
			cardId = warCardsIds.Substring(0, num);
		}
		bool flag = num > 0 && num + 1 < warCardsIds.Length;
		Card cardInstance = CardManager.instance.GetCardInstance(cardId);
		fromTopToBack[2].atlas = cardAtlas;
		fromTopToBack[1].atlas = cardAtlas;
		fromTopToBack[0].atlas = commonAtlas;
		mainImage.enabled = false;
		fromTopToBack[2].cachedTransform.localPosition = new Vector3(0f, 0f, 2f);
		secondLabel.pivot = UIWidget.Pivot.Right;
		secondLabel.cachedTransform.localPosition = new Vector3(-4f, 72f, -2f);
		secondLabel.gameObject.SetActive(value: true);
		cardInstance.SetUpSmallCard(fromTopToBack[2], fromTopToBack[1], fromTopToBack[0], secondLabel);
		fromTopToBack[2].MakePixelPerfect();
		fromTopToBack[2].gameObject.SetActive(value: true);
		Vector3 localPosition = fromTopToBack[1].cachedTransform.localPosition;
		localPosition.z = 2f;
		fromTopToBack[1].cachedTransform.localPosition = localPosition;
		localPosition = fromTopToBack[0].cachedTransform.localPosition;
		localPosition.z = -1f;
		fromTopToBack[0].cachedTransform.localPosition = localPosition;
		content.localScale = new Vector3(0.65f, 0.65f, 1f);
		int num2 = 0;
		if (flag)
		{
			int num3 = num;
			num = warCardsIds.IndexOf(';', num + 1);
			while (fromTopToBack.Length > 3 + num2 && num > 0)
			{
				Card cardInstance2 = CardManager.instance.GetCardInstance(warCardsIds.Substring(num3 + 1, num - num3 - 1));
				if (cardInstance2 != null)
				{
					UISprite uISprite = fromTopToBack[3 + num2];
					num2++;
					SetSprite(uISprite, Card.CardBackground(cardInstance2.rarity), cardAtlas, 1f, new Vector3(-15f * (float)num2, -20f, 1f));
					uISprite.MakePixelPerfect();
					uISprite.cachedTransform.localRotation = Quaternion.Euler(0f, 0f, 2f * (float)num2);
					uISprite.gameObject.SetActive(value: true);
				}
				num3 = num;
				num = warCardsIds.IndexOf(';', num + 1);
			}
			if (fromTopToBack.Length > 3 + num2 && num3 < warCardsIds.Length - 1)
			{
				Card cardInstance3 = CardManager.instance.GetCardInstance(warCardsIds.Substring(num3 + 1, warCardsIds.Length - num3 - 1));
				if (cardInstance3 != null)
				{
					UISprite uISprite2 = fromTopToBack[3 + num2];
					num2++;
					SetSprite(uISprite2, Card.CardBackground(cardInstance3.rarity), cardAtlas, 1f, new Vector3(-15f * (float)num2, -20f, 1f));
					uISprite2.MakePixelPerfect();
					uISprite2.cachedTransform.localRotation = Quaternion.Euler(0f, 0f, 2f * (float)num2);
					uISprite2.gameObject.SetActive(value: true);
				}
			}
		}
		content.localPosition = new Vector3((float)num2 * 4f, 20f, 0f);
		if (amount > 1)
		{
			SetTextPosition(new Vector3(40f + (float)num2 * 4f, -25f, 0f));
			count.enabled = true;
			count.text = amount.ToString("'x'0");
		}
		else
		{
			count.enabled = false;
		}
	}

	private void RandomWarCardsLook(DailyReward randomWarCards, int amount)
	{
		SetSprite(mainImage, "menu-randomcard-ico", mainAtlas, 1f, new Vector3(0f, -20f, -1f));
		mainImage.cachedTransform.localPosition = Vector3.zero;
		int num = 0;
		for (int i = 0; i < amount && i < fromTopToBack.Length; i++)
		{
			CardManager.CardType cardRarity = (CardManager.CardType)(1 + (randomWarCards - 2));
			SetSprite(fromTopToBack[i], Card.CardBackground(cardRarity), cardAtlas, 1f, new Vector3(-15f * (float)i, -20f, 1f));
			fromTopToBack[i].MakePixelPerfect();
			fromTopToBack[i].cachedTransform.localRotation = Quaternion.Euler(0f, 0f, 2f * (float)i);
			fromTopToBack[i].gameObject.SetActive(value: true);
			num++;
		}
		secondLabel.gameObject.SetActive(value: false);
		content.localScale = new Vector3(0.65f, 0.65f, 1f);
		content.localPosition = new Vector3((float)num * 4f, 20f, 0f);
		count.enabled = false;
	}

	private void CustomizationLook(string customizationId)
	{
		PlayerVisual visual = CamosManager.instance.GetVisual(customizationId);
		SetSprite(mainImage, visual.icon, visualAtlas, 0.75f, new Vector3(0f, -20f, -1f));
		count.enabled = false;
	}

	private void SetBlueClaimedBackground()
	{
		bg.enabled = true;
		bg.color = Colours.blueHover.ReplaceA(0.31f);
		border.color = Colours.blueHover.ReplaceA(0.31f);
		actualGlow.SetActive(value: false);
		notAvailablePart.SetActive(value: false);
		checker.gameObject.SetActive(value: true);
		checker.MakePixelPerfect();
		text.enabled = false;
	}

	private void SetBlueClaimBackground()
	{
		bg.enabled = true;
		bg.color = Colours.blueHover.ReplaceA(0.9f);
		border.color = Colours.blueHover.ReplaceA(0.7f);
		actualGlow.SetActive(value: true);
		actualBorder.MakePixelPerfect();
		notAvailablePart.SetActive(value: false);
		checker.gameObject.SetActive(value: false);
		text.text = Localization.Localize("ID_CLAIMTODAY");
		text.color = Color.black;
		text.enabled = true;
	}

	private void SetYellowTomorrowBackground()
	{
		bg.enabled = true;
		bg.color = Colours.yellowDailyTomorrow.ReplaceA(0.31f);
		border.color = Colours.yellowDailyTomorrow.ReplaceA(0.31f);
		actualGlow.SetActive(value: false);
		notAvailablePart.SetActive(value: false);
		checker.gameObject.SetActive(value: false);
		text.text = Localization.Localize("ID_TOMORROW");
		text.color = Colours.yellowDailyTomorrow;
		text.enabled = true;
	}

	private void SetWhiteLoginBackground(int index)
	{
		bg.enabled = false;
		border.color = Colours.grayLight.ReplaceA(0.15f);
		actualGlow.SetActive(value: false);
		notAvailablePart.SetActive(value: false);
		checker.gameObject.SetActive(value: false);
		text.text = Localization.LocalizeFormat("ID_DAYNUMBER", index);
		text.color = Colours.grayLight.ReplaceA(0.4f);
		text.enabled = true;
	}

	private void SetRedNotAvailableBackground()
	{
		bg.enabled = false;
		border.alpha = 0f;
		actualGlow.SetActive(value: false);
		notAvailablePart.SetActive(value: true);
		checker.gameObject.SetActive(value: false);
		text.enabled = false;
	}

	public void AnimateClaim()
	{
		mTweens[0] = TweenAlpha.Begin(text.gameObject, 0.2f, 0f);
		mTweens[1] = TweenAlpha.Begin(bg.gameObject, 0.2f, 0.31f);
		mTweens[2] = TweenAlpha.Begin(border.gameObject, 0.1f, 0.31f);
		UITweener obj = mTweens[2];
		obj.onFinished = (UITweener.OnFinished)Delegate.Combine(obj.onFinished, (UITweener.OnFinished)delegate
		{
			checker.gameObject.SetActive(value: true);
			checker.MakePixelPerfect();
			Vector3 localScale2 = checker.cachedTransform.localScale;
			checker.cachedTransform.localScale = localScale2 * 12f;
			mTweens[3] = TweenScale.Begin(checker.gameObject, 0.2f, localScale2);
		});
		Vector3 localScale = actualBorder.cachedTransform.localScale;
		localScale.Scale(new Vector3(3f, 3f, 1f));
		mTweens[4] = TweenScale.Begin(actualBorder.gameObject, 0.2f, localScale);
		UITweener obj2 = mTweens[4];
		obj2.onFinished = (UITweener.OnFinished)Delegate.Combine(obj2.onFinished, (UITweener.OnFinished)delegate
		{
			actualGlow.SetActive(value: false);
		});
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		onSelectButton = null;
	}
}
