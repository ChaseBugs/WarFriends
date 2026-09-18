using System;
using Google2u;
using UnityEngine;

public class ArenaBox : Core_BaseScript
{
	[SerializeField]
	[Header("Win Count")]
	private UIGrid mWinCount;

	[SerializeField]
	private UILabel mCount;

	[SerializeField]
	private UILabel mWinLabel;

	[SerializeField]
	private UISprite mWinSprite;

	[SerializeField]
	[Header("Details")]
	private BoxCollider mDetails;

	[SerializeField]
	private UISprite mDetailSprite;

	[SerializeField]
	[Header("Label")]
	private UILabel mLootboxLabel;

	[Header("Hint")]
	[SerializeField]
	private BoxCollider mHintPanel;

	[SerializeField]
	private UISprite mHintBackground;

	[SerializeField]
	private UILabel mHintDetails;

	[SerializeField]
	private GameObject mHintDetailsArrows;

	[SerializeField]
	private UISprite mTopLine;

	[SerializeField]
	private UISprite mBottomLine;

	[SerializeField]
	[Header("Hint Win Count")]
	private UIGrid mWinCountHint;

	[SerializeField]
	private UILabel mCountHint;

	[SerializeField]
	private UILabel mWinLabelHint;

	[SerializeField]
	private UISprite mWinSpriteHint;

	[Header("Lootbox Part")]
	[SerializeField]
	private UITable mLootboxTable;

	[SerializeField]
	private UISprite mLootboxHintSprite;

	[SerializeField]
	private UILabel mLootboxHintLabel;

	[Header("Crown Part")]
	[SerializeField]
	private UITable mCrownTable;

	[SerializeField]
	private UISprite mCrownHintSprite;

	[SerializeField]
	private UILabel mCrownHintLabel;

	[SerializeField]
	private UILabel mCrownHintDurationLabel;

	[SerializeField]
	[Header("Others")]
	private BoxCollider mOpenBoxCollider;

	public ArenaLootBox3D arenaLootBox;

	private WarArenaConfig.LootBoxType mType;

	private WarArenaConfig.VisualType mCrownType;

	private WarArenaConfig.Node mNode;

	private bool mHintShowed;

	private float mBackgroundHeight => (mCrownType != WarArenaConfig.VisualType.None) ? 700f : 520f;

	private float mWinsPartPositionY => (mCrownType != WarArenaConfig.VisualType.None) ? 642f : 462f;

	private float mTopLinePositionY => (mCrownType != WarArenaConfig.VisualType.None) ? 600f : 420f;

	private float mLootBoxPartPositionY => (mCrownType != WarArenaConfig.VisualType.None) ? 560f : 380f;

	private float mDescriptionPositionY => (mCrownType != WarArenaConfig.VisualType.None) ? 340f : 160f;

	public bool hintShowed => mHintShowed;

	protected override void Awake()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(mDetails.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HintClicked));
		UIEventListener uIEventListener2 = UIEventListener.Get(mHintPanel.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HintClicked));
		UIEventListener uIEventListener3 = UIEventListener.Get(mOpenBoxCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OpenLootbox));
	}

	public void SetLabels(WarArenaConfig.Node node, int countSize)
	{
		mNode = node;
		mType = node.lootBoxType;
		mCrownType = node.visualType;
		ResetHint();
		string text = string.Empty;
		mCount.text = countSize.ToString();
		mCountHint.text = mCount.text;
		mWinLabel.color = Color.white;
		mWinLabel.text = Localization.Localize((countSize <= 1) ? "ID_ARENAWIN" : "ID_ARENAWINS");
		mWinLabelHint.color = Color.white;
		mWinLabelHint.text = Localization.Localize((countSize <= 1) ? "ID_ARENAWINREWARDS" : "ID_ARENAWINSREWARDS");
		mWinSprite.atlas = GuiScreenSingle<ArenaScreen>.instance.mainMenuAtlas;
		mWinSprite.spriteName = "menu-arena-winico";
		mWinSprite.transform.localPosition = mWinSprite.transform.localPosition.ReplaceZ(0f);
		mWinSprite.transform.localScale = mWinSprite.transform.localScale.ReplaceXY(35f, 39f);
		mWinSpriteHint.atlas = mWinSprite.atlas;
		mWinSpriteHint.spriteName = mWinSprite.spriteName;
		mWinSpriteHint.transform.localPosition = mWinSpriteHint.transform.localPosition.ReplaceZ(0f);
		mWinSpriteHint.transform.localScale = mWinSprite.transform.localScale;
		switch (mType)
		{
		case WarArenaConfig.LootBoxType.Bronze:
			text = Localization.LocalizeFormat("ID_BRONZELOOTBOXSMALL", Colours.stringBronze, Colours.stringLightGray);
			break;
		case WarArenaConfig.LootBoxType.Silver:
			text = Localization.LocalizeFormat("ID_SILVERLOOTBOXSMALL", Colours.stringSilver, Colours.stringLightGray);
			break;
		case WarArenaConfig.LootBoxType.Gold:
			text = Localization.LocalizeFormat("ID_GOLDENLOOTBOXSMALL", Colours.stringGoldHeroic, Colours.stringLightGray);
			break;
		}
		mLootboxLabel.text = text;
		SetHints();
		arenaLootBox.ShowLootBox(mType);
		arenaLootBox.ShowAnimation();
	}

	private void ResetHint()
	{
		mHintShowed = false;
		mHintPanel.gameObject.SetActive(value: false);
		mDetailSprite.spriteName = "menu-info-ico";
	}

	public void SetLabelsFlawless()
	{
		ResetHint();
		mType = WarArenaConfig.LootBoxType.None;
		mCrownType = WarArenaConfig.VisualType.None;
		mCount.text = string.Empty;
		mCountHint.text = mCount.text;
		mWinLabel.color = Colours.goldHeroic;
		mWinLabel.text = Localization.Localize("ID_ARENAFLAWLESS");
		mWinLabelHint.color = Colours.goldHeroic;
		mWinLabelHint.text = Localization.Localize("ID_ARENAFLAWLESSREWARDS");
		mWinSprite.atlas = GuiScreenSingle<ArenaScreen>.instance.commonAtlas;
		mWinSprite.spriteName = "menu-arena-flawless-ico";
		mWinSprite.transform.localPosition = mWinSprite.transform.localPosition.ReplaceZ(-1f);
		mWinSprite.transform.localScale = mWinSprite.transform.localScale.ReplaceXY(40f, 46f);
		mWinSpriteHint.atlas = mWinSprite.atlas;
		mWinSpriteHint.spriteName = mWinSprite.spriteName;
		mWinSpriteHint.transform.localPosition = mWinSpriteHint.transform.localPosition.ReplaceZ(-1f);
		mWinSpriteHint.transform.localScale = mWinSprite.transform.localScale;
		mLootboxLabel.text = Localization.LocalizeFormat("ID_GOLDENSHIELDSSMALL", Colours.stringGoldHeroic);
		SetHints();
		arenaLootBox.ShowShield();
		arenaLootBox.ShowAnimation();
	}

	private void SetHints()
	{
		string empty = string.Empty;
		mLootboxHintSprite.gameObject.SetActive(mType != WarArenaConfig.LootBoxType.None);
		switch (mType)
		{
		case WarArenaConfig.LootBoxType.Bronze:
			mLootboxHintSprite.spriteName = "menu-arena-lootbox-bronze";
			empty = Localization.LocalizeFormat("ID_BRONZELOOTBOX", Colours.stringBronze);
			break;
		case WarArenaConfig.LootBoxType.Silver:
			mLootboxHintSprite.spriteName = "menu-arena-lootbox-silver";
			empty = Localization.LocalizeFormat("ID_SILVERLOOTBOX", Colours.stringSilver);
			break;
		case WarArenaConfig.LootBoxType.Gold:
			mLootboxHintSprite.spriteName = "menu-arena-lootbox-gold";
			empty = Localization.LocalizeFormat("ID_GOLDENLOOTBOX", Colours.stringGoldHeroic);
			break;
		default:
			empty = string.Empty;
			break;
		}
		if (mType != WarArenaConfig.LootBoxType.None)
		{
			ArenaLootboxesRow lootboxRow = mNode.lootboxRow;
			mHintDetails.pivot = UIWidget.Pivot.Left;
			mHintDetails.transform.localPosition = mHintDetails.transform.localPosition.ReplaceX(-250f);
			mHintDetails.text = Localization.LocalizeFormat("ID_ARENABOXDESCRIPTION", Colours.stringGreenArena, MiscTools.FormatBigNumber(lootboxRow.ELITEPARTSMIN), MiscTools.FormatBigNumber(lootboxRow.ELITEPARTSMAX), MiscTools.FormatBigNumber(lootboxRow.TICKETSMIN), MiscTools.FormatBigNumber(lootboxRow.TICKETSMAX), MiscTools.FormatBigNumber(lootboxRow.SCRAPSMIN), MiscTools.FormatBigNumber(lootboxRow.SCRAPSMAX), MiscTools.FormatBigNumber(lootboxRow.GOLDMIN), MiscTools.FormatBigNumber(lootboxRow.GOLDMAX), MiscTools.FormatBigNumber(mNode.minWarbucks), MiscTools.FormatBigNumber(mNode.maxWarbucks));
			mHintDetailsArrows.SetActive(value: true);
		}
		else
		{
			empty = Localization.LocalizeFormat("ID_GOLDENSHIELDS", Colours.stringGoldHeroic);
			mHintDetails.pivot = UIWidget.Pivot.Center;
			mHintDetails.transform.localPosition = mHintDetails.transform.localPosition.ReplaceX(0f);
			mHintDetails.text = Localization.LocalizeFormat("ID_ARENABOXDESCRIPTIONFLAWLESS", WarArena.instance.warArenaConfig.battles, Colours.stringGreenArena, Colours.stringGoldHeroic) + "\n\n" + Localization.Localize("ID_ARENACROWN_DURATION");
			mHintDetailsArrows.SetActive(value: false);
		}
		if (mCrownType != WarArenaConfig.VisualType.None)
		{
			switch (mCrownType)
			{
			case WarArenaConfig.VisualType.Bronze:
				mCrownHintLabel.text = Localization.LocalizeFormat("ID_BRONZEARENACROWN", Colours.stringBronze);
				break;
			case WarArenaConfig.VisualType.Silver:
				mCrownHintLabel.text = Localization.LocalizeFormat("ID_SILVERARENACROWN", Colours.stringSilver);
				break;
			case WarArenaConfig.VisualType.Gold:
				mCrownHintLabel.text = Localization.LocalizeFormat("ID_GOLDENARENACROWN", Colours.stringGoldHeroic);
				break;
			}
			mCrownHintSprite.spriteName = mNode.visualReward.spriteName;
			mCrownHintSprite.MakePixelPerfect();
			mCrownHintSprite.transform.localScale = mCrownHintSprite.transform.localScale.MultiplyXY(0.3f);
		}
		mLootboxHintLabel.text = empty;
		bool flag = mType == WarArenaConfig.LootBoxType.None;
		float val = (0f - (((!flag) ? mLootboxHintSprite.transform.localScale.x : 0f) + mLootboxHintLabel.transform.localScale.x * mLootboxHintLabel.relativeSize.x)) / 2f - ((!flag) ? 15f : 30f);
		mLootboxTable.transform.localPosition = mLootboxTable.transform.localPosition.ReplaceX(val);
		float val2 = (0f - (mCrownHintSprite.transform.localScale.x + 30f + mCrownHintLabel.transform.localScale.x * mCrownHintLabel.relativeSize.x)) / 2f;
		mCrownTable.transform.localPosition = mCrownTable.transform.localPosition.ReplaceX(val2);
		mHintBackground.transform.localScale = mHintBackground.transform.localScale.ReplaceY(mBackgroundHeight);
		mWinCountHint.transform.localPosition = mWinCountHint.transform.localPosition.ReplaceY(mWinsPartPositionY);
		mTopLine.transform.localPosition = mTopLine.transform.localPosition.ReplaceY(mTopLinePositionY);
		mLootboxTable.transform.localPosition = mLootboxTable.transform.localPosition.ReplaceY(mLootBoxPartPositionY);
		mHintDetails.transform.localPosition = mHintDetails.transform.localPosition.ReplaceY(mDescriptionPositionY);
		mHintDetailsArrows.transform.localPosition = mHintDetailsArrows.transform.localPosition.ReplaceY(mDescriptionPositionY);
		mBottomLine.gameObject.SetActive(mCrownType != WarArenaConfig.VisualType.None);
		mCrownTable.gameObject.SetActive(mCrownType != WarArenaConfig.VisualType.None);
		mCrownHintDurationLabel.gameObject.SetActive(mCrownType != WarArenaConfig.VisualType.None);
		mCrownHintDurationLabel.text = Localization.Localize("ID_ARENACROWN_DURATION");
	}

	public void CenterWinCountGrid()
	{
		float num = ((!string.IsNullOrEmpty(mCount.text)) ? (mCount.transform.localScale.x * mCount.relativeSize.x) : 0f);
		float num2 = mWinLabel.transform.localScale.x * mWinLabel.relativeSize.x + 2f * mWinCount.cellWidth;
		float num3 = ((!string.IsNullOrEmpty(mCountHint.text)) ? (mCountHint.transform.localScale.x * mCountHint.relativeSize.x) : 0f);
		float num4 = mWinLabelHint.transform.localScale.x * mWinLabelHint.relativeSize.x + 2f * mWinCountHint.cellWidth;
		mWinCount.transform.localPosition = mWinCount.transform.localPosition.ReplaceX((num - num2) * 0.5f);
		mWinCountHint.transform.localPosition = mWinCountHint.transform.localPosition.ReplaceX((num3 - num4) * 0.5f);
	}

	public void SetClaimed(bool isClaimed, WarArenaConfig.LootBoxType type = WarArenaConfig.LootBoxType.None)
	{
		mOpenBoxCollider.gameObject.SetActive(value: false);
		mWinCount.gameObject.SetActive(!isClaimed);
		mDetails.gameObject.SetActive(!isClaimed);
		mLootboxLabel.gameObject.SetActive(!isClaimed);
		if (isClaimed)
		{
			arenaLootBox.ShowLootBox(type);
			arenaLootBox.ShowAnimation();
			arenaLootBox.ShowClaimed();
		}
	}

	public void SetAboutToOpen(WarArenaConfig.LootBoxType type = WarArenaConfig.LootBoxType.None)
	{
		mWinCount.gameObject.SetActive(value: false);
		mDetails.gameObject.SetActive(value: false);
		mLootboxLabel.gameObject.SetActive(value: false);
		arenaLootBox.ShowLootBox(type);
		arenaLootBox.ShowAnimation();
		mOpenBoxCollider.gameObject.SetActive(value: true);
		arenaLootBox.ShowClaimAnimation();
	}

	public void HintClicked(GameObject go)
	{
		bool flag = mHintShowed;
		GuiScreenSingle<ArenaScreen>.instance.mainContent.HideBoxesHints();
		if (flag == mHintShowed)
		{
			ShowHint();
		}
	}

	private void OpenLootbox(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		mOpenBoxCollider.gameObject.SetActive(value: false);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaLootboxDialog>.instance, 0f);
		GuiElementSingle<ArenaLootboxDialog>.instance.type = mType;
		InvokeAfter(arenaLootBox.ShowClaimed, 2f);
	}

	public void ShowHint()
	{
		float num = mHintBackground.transform.localScale.x / 2f;
		float num2 = UIRoot.list[0].activeWidth / 2f;
		float num3 = base.transform.localPosition.x + base.transform.parent.gameObject.transform.localPosition.x;
		mHintPanel.transform.localPosition = mHintPanel.transform.localPosition.ReplaceX(0f);
		if (num2 + num3 < num)
		{
			mHintPanel.transform.localPosition = mHintPanel.transform.localPosition.AddX(num - num2 - num3);
		}
		if (num3 + num + 105f > num2)
		{
			mHintPanel.transform.localPosition = mHintPanel.transform.localPosition.AddX(num2 - num3 - num - 105f);
		}
		mHintShowed = !mHintShowed;
		if (mHintShowed)
		{
			mHintPanel.gameObject.SetActive(mHintShowed);
			TweenAlpha.Begin(mHintPanel.gameObject, 0.4f, 0f, 1f);
			UIPanel[] componentsInChildren = mWinCountHint.GetComponentsInChildren<UIPanel>();
			foreach (UIPanel uIPanel in componentsInChildren)
			{
				TweenAlpha.Begin(uIPanel.gameObject, 0.4f, 0f, 1f);
			}
		}
		else
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mHintPanel.gameObject, 0.4f, 1f, 0f);
			tweenAlpha.onFinished = delegate
			{
				mHintPanel.gameObject.SetActive(mHintShowed);
			};
			UIPanel[] componentsInChildren2 = mWinCountHint.GetComponentsInChildren<UIPanel>();
			foreach (UIPanel uIPanel2 in componentsInChildren2)
			{
				TweenAlpha.Begin(uIPanel2.gameObject, 0.4f, 1f, 0f);
			}
		}
		mDetailSprite.spriteName = ((!mHintShowed) ? "menu-info-ico" : "menu-info-close-ico");
		SoundsManager.Instance.PlayButtonClickedSound();
	}
}
