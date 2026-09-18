using System;
using UnityEngine;

public class ArenaLootboxDialog : GuiElementSingle<ArenaLootboxDialog>, IGuiDialog
{
	private enum LootboxReward
	{
		Unit,
		Warbucks,
		Gold,
		Tickets,
		Scraps,
		All
	}

	[SerializeField]
	[Header("Top Part Unit")]
	private GameObject mTopUnitPart;

	[SerializeField]
	private UILabel mUnitName;

	[SerializeField]
	private UILabel mEliteLabel;

	[SerializeField]
	[Header("Center Part Unit")]
	private GameObject mCenterUnitPart;

	[SerializeField]
	private UISprite mUnitSprite;

	[SerializeField]
	private UILabel mUnitPartsGained;

	[SerializeField]
	private UILabel mUnitPartsTotal;

	[SerializeField]
	[Header("Reward Part")]
	private GameObject mScrapIcon;

	[SerializeField]
	private GameObject mGoldIcon;

	[SerializeField]
	private GameObject mTicketsIcon;

	[SerializeField]
	private GameObject mWarbucksIcon;

	[SerializeField]
	private GameObject mTexts;

	[SerializeField]
	private UILabel mRewardAmount;

	[SerializeField]
	private UILabel mRewardName;

	[SerializeField]
	[Header("Reward Part Unit")]
	private UISprite mRewardUnitSprite;

	[SerializeField]
	private UILabel mRewardUnitPartsGained;

	[Header("Center Part")]
	[SerializeField]
	private BoxCollider mTapCollider;

	[SerializeField]
	private UISprite mFlash;

	[SerializeField]
	private ParticleSystem mParticles;

	[SerializeField]
	[Header("Claim Part")]
	private GameObject mClaimPart;

	[SerializeField]
	private BoxCollider mClaimButton;

	[SerializeField]
	private UILabel mTicketsAmount;

	[SerializeField]
	private UILabel mScrapAmount;

	[SerializeField]
	private UILabel mGoldAmount;

	[SerializeField]
	private UILabel mWarbucksAmount;

	[SerializeField]
	[Header("Bottom Part")]
	private UILabel mTapLabel;

	[HideInInspector]
	public WarArenaConfig.LootBoxType type;

	private LootboxReward mRewardType;

	private WararenaLootboxReward mRewards;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mTapCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnTap));
		UIEventListener uIEventListener2 = UIEventListener.Get(mClaimButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		Singleton<LootBoxCameraArena>.instance.LootBoxShowedUp += ShowRewards;
	}

	private void CloseDialog(GameObject go)
	{
		if (isShowed)
		{
			TweenAlpha.Begin(mFlash.gameObject, 0.05f, 0f, 1f).onFinished = delegate
			{
				HideLabelsAndSprites();
				HideDialog();
			};
		}
	}

	private void OnTap(GameObject go)
	{
		switch (mRewardType)
		{
		case LootboxReward.Unit:
			FlashScreen(delegate
			{
				HideLabelsAndSprites();
				mTapCollider.gameObject.SetActive(value: true);
				mTopUnitPart.SetActive(value: true);
				mCenterUnitPart.SetActive(value: true);
				mTapLabel.gameObject.SetActive(value: true);
				ShowUnit();
			});
			break;
		case LootboxReward.Gold:
			FlashScreen(delegate
			{
				HideLabelsAndSprites();
				mGoldIcon.SetActive(value: true);
				mTexts.SetActive(value: true);
				mTapLabel.gameObject.SetActive(value: true);
				ShowOtherReward(mRewards.gold, Localization.Localize("ID_ARENALOOTBOXGOLD"), mGoldAmount, LootboxReward.Scraps);
			});
			break;
		case LootboxReward.Scraps:
			FlashScreen(delegate
			{
				HideLabelsAndSprites();
				mScrapIcon.SetActive(value: true);
				mTexts.SetActive(value: true);
				mTapLabel.gameObject.SetActive(value: true);
				ShowOtherReward(mRewards.scraps, Localization.Localize("ID_ARENALOOTBOXSCRAPS"), mScrapAmount, LootboxReward.Tickets);
			});
			break;
		case LootboxReward.Tickets:
			FlashScreen(delegate
			{
				HideLabelsAndSprites();
				mTicketsIcon.SetActive(value: true);
				mTexts.SetActive(value: true);
				mTapLabel.gameObject.SetActive(value: true);
				ShowOtherReward(mRewards.tickets, Localization.Localize("ID_ARENALOOTBOXTICKETS"), mTicketsAmount, LootboxReward.Warbucks);
			});
			break;
		case LootboxReward.Warbucks:
			FlashScreen(delegate
			{
				HideLabelsAndSprites();
				mWarbucksIcon.SetActive(value: true);
				mTexts.SetActive(value: true);
				mTapLabel.gameObject.SetActive(value: true);
				mTexts.transform.localPosition = mTexts.transform.localPosition.ReplaceX(-160f);
				ShowOtherReward(mRewards.warbucks, Localization.Localize("ID_ARENALOOTBOXWARBUCKS"), mWarbucksAmount, LootboxReward.All);
			});
			break;
		case LootboxReward.All:
			FlashScreen(delegate
			{
				HideLabelsAndSprites();
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Fight);
				mTapCollider.gameObject.SetActive(value: false);
				mParticles.gameObject.SetActive(value: true);
				mParticles.Play();
				MiscTools.SetUILabelRescale(mWarbucksAmount, 90f, 50f, 300);
				mClaimPart.SetActive(value: true);
			});
			break;
		default:
			HideDialog();
			break;
		}
	}

	private void HideLabelsAndSprites()
	{
		Singleton<LootBoxCameraArena>.instance.HideModel();
		mParticles.Stop();
		mParticles.gameObject.SetActive(value: false);
		mTopUnitPart.SetActive(value: false);
		mCenterUnitPart.SetActive(value: false);
		mTapLabel.gameObject.SetActive(value: false);
		mScrapIcon.SetActive(value: false);
		mGoldIcon.SetActive(value: false);
		mTicketsIcon.SetActive(value: false);
		mWarbucksIcon.SetActive(value: false);
		mTexts.SetActive(value: false);
		mClaimPart.SetActive(value: false);
		mTexts.transform.localPosition = mTexts.transform.localPosition.ReplaceX(0f);
	}

	private void ShowUnit()
	{
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.OpenLootboxCompleted);
		mUnitName.text = Localization.LocalizeFormat("ID_ELITEUNITNAME", mRewards.unit.unitName.ToUpper());
		mEliteLabel.text = mRewards.unit.unitElitePartsName.ToUpper();
		mUnitPartsGained.text = "+" + MiscTools.FormatBigNumber(mRewards.eliteParts);
		mRewardUnitPartsGained.text = mUnitPartsGained.text;
		string text = MiscTools.FormatBigNumber(mRewards.unit.upgradeSlots.upgradeSlotElite.currentParts);
		string text2 = MiscTools.FormatBigNumber(mRewards.unit.upgradeSlots.upgradeSlotElite.upgradePriceParts);
		if (mRewards.unit.upgradeSlots.upgradeSlotElite.isMaxUpgraded)
		{
			mUnitPartsTotal.text = $"{Colours.stringGreenArena}{text}[-]";
		}
		else
		{
			mUnitPartsTotal.text = $"{Colours.stringGreenArena}{text}[-] {Colours.stringGrayLight}/[-] {text2}";
		}
		SetUnitSprite(mRewards.unit);
		Singleton<LootBoxCameraArena>.instance.DisplayModel(mRewards.unit, isLootboxReward: true);
		mRewardType = LootboxReward.Gold;
		mParticles.gameObject.SetActive(value: true);
		mParticles.Play();
	}

	private void ShowOtherReward(int amount, string newRewardName, UILabel endLabel, LootboxReward nextReward)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.OpenLootboxCompleted);
		mRewardAmount.text = MiscTools.FormatBigNumber(amount);
		endLabel.text = mRewardAmount.text;
		mRewardName.text = newRewardName;
		mRewardType = nextReward;
		mParticles.gameObject.SetActive(value: true);
		mParticles.Play();
	}

	private void ShowRewards()
	{
		if (mRewards == null)
		{
			HideDialog();
			return;
		}
		WarArena.instance.lastLootboxReward.AddToClient();
		mRewardType = LootboxReward.Unit;
		OnTap(base.gameObject);
	}

	private void SetUnitSprite(LevelBehaviour unit)
	{
		mUnitSprite.spriteName = unit.upgradeSlots.iconNameElite;
		mUnitSprite.MakePixelPerfect();
		mRewardUnitSprite.spriteName = unit.upgradeSlots.iconNameElite;
		mRewardUnitSprite.MakePixelPerfect();
		if (unit.isSoldier)
		{
			float multiplier = 110f / mUnitSprite.transform.localScale.y;
			mUnitSprite.pivot = UIWidget.Pivot.Bottom;
			mUnitSprite.transform.localPosition = mUnitSprite.transform.localPosition.ReplaceY(-62f);
			mUnitSprite.transform.localScale = mUnitSprite.transform.localScale.MultiplyXY(multiplier);
			mRewardUnitSprite.pivot = UIWidget.Pivot.Bottom;
			mRewardUnitSprite.transform.localPosition = mRewardUnitSprite.transform.localPosition.ReplaceY(-62f);
			mRewardUnitSprite.transform.localScale = mRewardUnitSprite.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			float multiplier2 = Mathf.Min(110f / mUnitSprite.transform.localScale.x, 110f / mUnitSprite.transform.localScale.y);
			mUnitSprite.pivot = UIWidget.Pivot.Center;
			mUnitSprite.transform.localPosition = mUnitSprite.transform.localPosition.ReplaceY(0f);
			mUnitSprite.transform.localScale = mUnitSprite.transform.localScale.MultiplyXY(multiplier2);
			mRewardUnitSprite.pivot = UIWidget.Pivot.Center;
			mRewardUnitSprite.transform.localPosition = mRewardUnitSprite.transform.localPosition.ReplaceY(0f);
			mRewardUnitSprite.transform.localScale = mRewardUnitSprite.transform.localScale.MultiplyXY(multiplier2);
		}
	}

	public override void InitGUIValues()
	{
		Singleton<LootBoxCameraArena>.instance.StopAllCoroutines();
		mTapCollider.gameObject.SetActive(value: false);
		mRewards = WarArena.instance.lastLootboxReward;
		HideLabelsAndSprites();
	}

	private void FlashScreen(Action Action)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mFlash.gameObject, 0.05f, 0f, 1f);
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha.Begin(mFlash.gameObject, 1f, 1f, 0f).onFinished = null;
			if (Action != null)
			{
				Action();
			}
		};
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		Singleton<LootBoxCamera>.instance.dialogCamera.gameObject.SetActive(value: true);
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		Singleton<LootBoxCameraArena>.instance.ShowUpLootBox(type);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		Singleton<LootBoxCameraArena>.instance.Hide();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		TweenAlpha.Begin(mFlash.gameObject, 0f, 1f, 0f);
		Singleton<LootBoxCamera>.instance.dialogCamera.gameObject.SetActive(value: false);
		GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}
}
