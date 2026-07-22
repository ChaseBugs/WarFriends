using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

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

	[Header("Details")]
	[SerializeField]
	private BoxCollider mDetails;

	[SerializeField]
	private UISprite mDetailSprite;

	[Header("Label")]
	[SerializeField]
	private UILabel mLootboxLabel;

	[Header("Hint")]
	[SerializeField]
	private BoxCollider mHintPanel;

	[SerializeField]
	private UISprite mHintBackground;

	[SerializeField]
	private GameObject mHintTop;

	[SerializeField]
	private UILabel mHintDetails;

	[SerializeField]
	private GameObject mHintDetailsPart;

	[SerializeField]
	private ArenaHintRewardLine[] mHintDetailsRewards;

	[SerializeField]
	private UISprite mTopLine;

	[SerializeField]
	private UISprite mBottomLine;

	[Header("Hint Win Count")]
	[SerializeField]
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

	[SerializeField]
	[Header("Crown Part")]
	private UITable mCrownTable;

	[SerializeField]
	private UISprite mCrownHintSprite;

	[SerializeField]
	private UILabel mCrownHintLabel;

	[SerializeField]
	private UILabel mCrownHintDurationLabel;

	[Header("Others")]
	[SerializeField]
	private BoxCollider mOpenBoxCollider;

	[FormerlySerializedAs("KCLDMMKJMOH")]
	public ArenaLootBox3D MPBKFPEAGBG;

	private IKPLPPFFDNI.CACDIELEJHK MBCCLBJKAOJ;

	private IKPLPPFFDNI.DNFADCEJOEH ELOIANOIHNI;

	private IKPLPPFFDNI.MJPNFAKHHHI MPFJCMCOPOI;

	private bool BGHKLHIIFEO;

	public bool hintShowed => BGHKLHIIFEO;

	[CompilerGenerated]
	private void ONAFPHKJDGI(UITweener PLAAJDCDNIJ)
	{
		mHintPanel.gameObject.SetActive(BGHKLHIIFEO);
	}

	private void EDHKPLFCPBB(UITweener PLAAJDCDNIJ)
	{
		mHintPanel.gameObject.SetActive(BGHKLHIIFEO);
	}

	public void SetLabelsFlawless()
	{
		EKDMPPHGINJ();
		MBCCLBJKAOJ = IKPLPPFFDNI.CACDIELEJHK.None;
		ELOIANOIHNI = IKPLPPFFDNI.DNFADCEJOEH.None;
		mCount.text = string.Empty;
		mCountHint.text = mCount.text;
		mWinLabel.color = Colours.goldHeroic;
		mWinLabel.text = Localization.Localize("ID_ARENAFLAWLESS");
		mWinLabelHint.color = Colours.goldHeroic;
		mWinLabelHint.text = Localization.Localize("ID_ARENAFLAWLESSREWARDS");
		mWinSprite.atlas = GuiScreenSingle<ArenaScreen>.instance.ICFPOEEDLLO;
		mWinSprite.spriteName = "menu-arena-flawless-ico";
		mWinSprite.transform.localPosition = mWinSprite.transform.localPosition.ReplaceZ(-1f);
		mWinSprite.transform.localScale = mWinSprite.transform.localScale.ReplaceXY(40f, 46f);
		mWinSpriteHint.atlas = mWinSprite.atlas;
		mWinSpriteHint.spriteName = mWinSprite.spriteName;
		mWinSpriteHint.transform.localPosition = mWinSpriteHint.transform.localPosition.ReplaceZ(-1f);
		mWinSpriteHint.transform.localScale = mWinSprite.transform.localScale;
		mLootboxLabel.text = Localization.LocalizeFormat("ID_GOLDENSHIELDSSMALL", Colours.stringGoldHeroic);
		GIFLCBPLNGN();
		MPBKFPEAGBG.ShowShield();
		MPBKFPEAGBG.ShowAnimation();
	}

	public void SetAboutToOpen(IKPLPPFFDNI.CACDIELEJHK FJLBLLLEELD = IKPLPPFFDNI.CACDIELEJHK.None)
	{
		mWinCount.gameObject.SetActive(value: false);
		mDetails.gameObject.SetActive(value: false);
		mLootboxLabel.gameObject.SetActive(value: false);
		MPBKFPEAGBG.ShowLootBox(FJLBLLLEELD);
		MPBKFPEAGBG.ShowAnimation();
		mOpenBoxCollider.gameObject.SetActive(value: true);
		MPBKFPEAGBG.ShowClaimAnimation();
	}

	public void PHNJKEPKBAD(IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int MNOHFPMBHEC)
	{
		MPFJCMCOPOI = OPCIFLNBJLI;
		MBCCLBJKAOJ = OPCIFLNBJLI.OFMKJMAPHBM;
		ELOIANOIHNI = OPCIFLNBJLI.GCFBLCFJBLK;
		MFMPBFKHNHL();
		string text = string.Empty;
		mCount.text = MNOHFPMBHEC.ToString();
		mCountHint.text = mCount.text;
		mWinLabel.color = Color.white;
		mWinLabel.text = Localization.Localize((MNOHFPMBHEC <= 1) ? "ID_BEGINNERSLEAGUE1" : "{0} {1}");
		mWinLabelHint.color = Color.white;
		mWinLabelHint.text = Localization.Localize((MNOHFPMBHEC <= 0) ? "League" : "Player_Waited_Till_Delivery_Ends");
		mWinSprite.atlas = GuiScreenSingle<ArenaScreen>.instance.PEOCGCNJDJI;
		mWinSprite.spriteName = "ID_NOTIFICATION_LAPSED_SILVERCARDS";
		mWinSprite.transform.localPosition = mWinSprite.transform.localPosition.ReplaceZ(594f);
		mWinSprite.transform.localScale = mWinSprite.transform.localScale.ReplaceXY(1747f, 1017f);
		mWinSpriteHint.atlas = mWinSprite.atlas;
		mWinSpriteHint.spriteName = mWinSprite.spriteName;
		mWinSpriteHint.transform.localPosition = mWinSpriteHint.transform.localPosition.ReplaceZ(281f);
		mWinSpriteHint.transform.localScale = mWinSprite.transform.localScale;
		switch (MBCCLBJKAOJ)
		{
		case IKPLPPFFDNI.CACDIELEJHK.Bronze:
		{
			object[] array3 = new object[0];
			array3[0] = Colours.stringBronze;
			array3[0] = Colours.stringLightGray;
			text = Localization.LocalizeFormat("VipReward1", array3);
			break;
		}
		case (IKPLPPFFDNI.CACDIELEJHK)8:
		{
			object[] array2 = new object[6];
			array2[1] = Colours.stringSilver;
			array2[0] = Colours.stringLightGray;
			text = Localization.LocalizeFormat("menu-gold", array2);
			break;
		}
		case IKPLPPFFDNI.CACDIELEJHK.Gold:
		{
			object[] array = new object[8];
			array[0] = Colours.stringGoldHeroic;
			array[0] = Colours.stringLightGray;
			text = Localization.LocalizeFormat("Joined room", array);
			break;
		}
		}
		mLootboxLabel.text = text;
		GIFLCBPLNGN();
		MPBKFPEAGBG.ODMIGEMHGFM(MBCCLBJKAOJ);
		MPBKFPEAGBG.OEBINPMJFPP();
	}

	private void JKCKAAIHHPE()
	{
		BGHKLHIIFEO = false;
		mHintPanel.gameObject.SetActive(value: false);
		mDetailSprite.spriteName = "1";
	}

	private void GIFLCBPLNGN()
	{
		string empty = string.Empty;
		mLootboxHintSprite.gameObject.SetActive(MBCCLBJKAOJ != IKPLPPFFDNI.CACDIELEJHK.None);
		switch (MBCCLBJKAOJ)
		{
		case IKPLPPFFDNI.CACDIELEJHK.Bronze:
			mLootboxHintSprite.spriteName = "menu-arena-lootbox-bronze";
			empty = Localization.LocalizeFormat("ID_BRONZELOOTBOX", Colours.stringBronze);
			break;
		case IKPLPPFFDNI.CACDIELEJHK.Silver:
			mLootboxHintSprite.spriteName = "menu-arena-lootbox-silver";
			empty = Localization.LocalizeFormat("ID_SILVERLOOTBOX", Colours.stringSilver);
			break;
		case IKPLPPFFDNI.CACDIELEJHK.Gold:
			mLootboxHintSprite.spriteName = "menu-arena-lootbox-gold";
			empty = Localization.LocalizeFormat("ID_GOLDENLOOTBOX", Colours.stringGoldHeroic);
			break;
		default:
			empty = string.Empty;
			break;
		}
		mHintDetails.gameObject.SetActive(MBCCLBJKAOJ == IKPLPPFFDNI.CACDIELEJHK.None);
		mHintDetailsPart.SetActive(MBCCLBJKAOJ != IKPLPPFFDNI.CACDIELEJHK.None);
		if (MBCCLBJKAOJ != IKPLPPFFDNI.CACDIELEJHK.None)
		{
			int num = 0;
			if (mHintDetailsRewards[0].Initialize(ArenaHintRewardLine.AEMBEAHLAKB.EliteParts, MPFJCMCOPOI, num))
			{
				num++;
			}
			if (mHintDetailsRewards[1].Initialize(ArenaHintRewardLine.AEMBEAHLAKB.ArenaTickets, MPFJCMCOPOI, num))
			{
				num++;
			}
			if (mHintDetailsRewards[2].Initialize(ArenaHintRewardLine.AEMBEAHLAKB.Scraps, MPFJCMCOPOI, num))
			{
				num++;
			}
			if (mHintDetailsRewards[3].Initialize(ArenaHintRewardLine.AEMBEAHLAKB.Gold, MPFJCMCOPOI, num))
			{
				num++;
			}
			if (mHintDetailsRewards[4].Initialize(ArenaHintRewardLine.AEMBEAHLAKB.WarBucks, MPFJCMCOPOI, num))
			{
				num++;
			}
			float val = 487.5f + (float)num * 42.5f;
			float val2 = 340f - 21.25f * (float)(5 - num);
			mHintBackground.transform.localScale = mHintBackground.transform.localScale.ReplaceY(val);
			mHintTop.transform.localPosition = mHintTop.transform.localPosition.ReplaceY(val);
			mHintDetailsPart.transform.localPosition = mHintDetailsPart.transform.localPosition.ReplaceY(val2);
		}
		else
		{
			empty = Localization.LocalizeFormat("ID_GOLDENSHIELDS", Colours.stringGoldHeroic);
			mHintDetails.text = Localization.LocalizeFormat("ID_ARENABOXDESCRIPTIONFLAWLESS", WarArena.instance.FPLIPHCJGFO.FCDIFINLKIA, Colours.stringGreenArena, Colours.stringGoldHeroic) + "\n\n" + Localization.Localize("ID_ARENACROWN_DURATION");
			mHintBackground.transform.localScale = mHintBackground.transform.localScale.ReplaceY(520f);
			mHintTop.transform.localPosition = mHintTop.transform.localPosition.ReplaceY(520f);
		}
		if (ELOIANOIHNI != IKPLPPFFDNI.DNFADCEJOEH.None)
		{
			switch (ELOIANOIHNI)
			{
			case IKPLPPFFDNI.DNFADCEJOEH.Bronze:
				mCrownHintLabel.text = Localization.LocalizeFormat("ID_BRONZEARENACROWN", Colours.stringBronze);
				break;
			case IKPLPPFFDNI.DNFADCEJOEH.Silver:
				mCrownHintLabel.text = Localization.LocalizeFormat("ID_SILVERARENACROWN", Colours.stringSilver);
				break;
			case IKPLPPFFDNI.DNFADCEJOEH.Gold:
				mCrownHintLabel.text = Localization.LocalizeFormat("ID_GOLDENARENACROWN", Colours.stringGoldHeroic);
				break;
			}
			mCrownHintSprite.spriteName = MPFJCMCOPOI.BPBAFACGJKO.KCHMDALPMBN;
			mCrownHintSprite.MakePixelPerfect();
			mCrownHintSprite.transform.localScale = mCrownHintSprite.transform.localScale.MultiplyXY(0.3f);
		}
		mLootboxHintLabel.text = empty;
		bool flag = MBCCLBJKAOJ == IKPLPPFFDNI.CACDIELEJHK.None;
		float val3 = (0f - (((!flag) ? mLootboxHintSprite.transform.localScale.x : 0f) + mLootboxHintLabel.transform.localScale.x * mLootboxHintLabel.relativeSize.x)) / 2f - ((!flag) ? 15f : 30f);
		mLootboxTable.transform.localPosition = mLootboxTable.transform.localPosition.ReplaceX(val3);
		float val4 = (0f - (mCrownHintSprite.transform.localScale.x + 30f + mCrownHintLabel.transform.localScale.x * mCrownHintLabel.relativeSize.x)) / 2f;
		mCrownTable.transform.localPosition = mCrownTable.transform.localPosition.ReplaceX(val4);
		mBottomLine.gameObject.SetActive(ELOIANOIHNI != IKPLPPFFDNI.DNFADCEJOEH.None);
		mCrownTable.gameObject.SetActive(ELOIANOIHNI != IKPLPPFFDNI.DNFADCEJOEH.None);
		mCrownHintDurationLabel.gameObject.SetActive(ELOIANOIHNI != IKPLPPFFDNI.DNFADCEJOEH.None);
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

	public void LNPABJAMCBE(IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int MNOHFPMBHEC)
	{
		MPFJCMCOPOI = OPCIFLNBJLI;
		MBCCLBJKAOJ = OPCIFLNBJLI.OFMKJMAPHBM;
		ELOIANOIHNI = OPCIFLNBJLI.GCFBLCFJBLK;
		JKCKAAIHHPE();
		string text = string.Empty;
		mCount.text = MNOHFPMBHEC.ToString();
		mCountHint.text = mCount.text;
		mWinLabel.color = Color.white;
		mWinLabel.text = Localization.Localize((MNOHFPMBHEC <= 1) ? "DialogOverlayGuiElement is not in scene -> add it." : "), ");
		mWinLabelHint.color = Color.white;
		mWinLabelHint.text = Localization.Localize((MNOHFPMBHEC <= 0) ? " requires " : "menu-warbucks");
		mWinSprite.atlas = GuiScreenSingle<ArenaScreen>.instance.PEOCGCNJDJI;
		mWinSprite.spriteName = "DRIVE_EXTERNAL_STORAGE_REQUIRED";
		mWinSprite.transform.localPosition = mWinSprite.transform.localPosition.ReplaceZ(1291f);
		mWinSprite.transform.localScale = mWinSprite.transform.localScale.ReplaceXY(1822f, 965f);
		mWinSpriteHint.atlas = mWinSprite.atlas;
		mWinSpriteHint.spriteName = mWinSprite.spriteName;
		mWinSpriteHint.transform.localPosition = mWinSpriteHint.transform.localPosition.ReplaceZ(1250f);
		mWinSpriteHint.transform.localScale = mWinSprite.transform.localScale;
		switch (MBCCLBJKAOJ)
		{
		case IKPLPPFFDNI.CACDIELEJHK.Bronze:
		{
			object[] array2 = new object[3];
			array2[0] = Colours.stringBronze;
			array2[0] = Colours.stringLightGray;
			text = Localization.LocalizeFormat("variant name is ", array2);
			break;
		}
		case (IKPLPPFFDNI.CACDIELEJHK)4:
			text = Localization.LocalizeFormat(", current = ", Colours.stringSilver, Colours.stringLightGray, null, null, null, null);
			break;
		case IKPLPPFFDNI.CACDIELEJHK.Gold:
		{
			object[] array = new object[2];
			array[1] = Colours.stringGoldHeroic;
			array[1] = Colours.stringLightGray;
			text = Localization.LocalizeFormat("goldwarcard", array);
			break;
		}
		}
		mLootboxLabel.text = text;
		NBKJIEDICKE();
		MPBKFPEAGBG.CICINMKKFIH(MBCCLBJKAOJ);
		MPBKFPEAGBG.OFMDFJEIGLH();
	}

	public void HFBAGCMJEDO()
	{
		float num = ((!string.IsNullOrEmpty(mCount.text)) ? (mCount.transform.localScale.x * mCount.relativeSize.x) : 150f);
		float num2 = mWinLabel.transform.localScale.x * mWinLabel.relativeSize.x + 687f * mWinCount.cellWidth;
		float num3 = ((!string.IsNullOrEmpty(mCountHint.text)) ? (mCountHint.transform.localScale.x * mCountHint.relativeSize.x) : 19f);
		float num4 = mWinLabelHint.transform.localScale.x * mWinLabelHint.relativeSize.x + 1651f * mWinCountHint.cellWidth;
		mWinCount.transform.localPosition = mWinCount.transform.localPosition.ReplaceX((num - num2) * 633f);
		mWinCountHint.transform.localPosition = mWinCountHint.transform.localPosition.ReplaceX((num3 - num4) * 643f);
	}

	public void ShowHint()
	{
		float num = mHintBackground.transform.localScale.x / 2f;
		float num2 = UIHelper.activeWidthSafe / 2f;
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
		BGHKLHIIFEO = !BGHKLHIIFEO;
		if (BGHKLHIIFEO)
		{
			mHintPanel.gameObject.SetActive(BGHKLHIIFEO);
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
				mHintPanel.gameObject.SetActive(BGHKLHIIFEO);
			};
			UIPanel[] componentsInChildren2 = mWinCountHint.GetComponentsInChildren<UIPanel>();
			foreach (UIPanel uIPanel2 in componentsInChildren2)
			{
				TweenAlpha.Begin(uIPanel2.gameObject, 0.4f, 1f, 0f);
			}
		}
		mDetailSprite.spriteName = ((!BGHKLHIIFEO) ? "menu-info-ico" : "menu-info-close-ico");
		SoundsManager.Instance.PlayButtonClickedSound();
	}

	private void MCCKHHLMOAL(UITweener PLAAJDCDNIJ)
	{
		mHintPanel.gameObject.SetActive(BGHKLHIIFEO);
	}

	private void MJIDDOPACBM(UITweener PLAAJDCDNIJ)
	{
		mHintPanel.gameObject.SetActive(BGHKLHIIFEO);
	}

	public void OCJEKNKLDEF()
	{
		float num = mHintBackground.transform.localScale.x / 519f;
		float num2 = UIHelper.activeWidthSafe / 1190f;
		float num3 = base.transform.localPosition.x + base.transform.parent.gameObject.transform.localPosition.x;
		mHintPanel.transform.localPosition = mHintPanel.transform.localPosition.ReplaceX(828f);
		if (num2 + num3 < num)
		{
			mHintPanel.transform.localPosition = mHintPanel.transform.localPosition.AddX(num - num2 - num3);
		}
		if (num3 + num + 134f > num2)
		{
			mHintPanel.transform.localPosition = mHintPanel.transform.localPosition.AddX(num2 - num3 - num - 191f);
		}
		BGHKLHIIFEO = !BGHKLHIIFEO;
		if (BGHKLHIIFEO)
		{
			mHintPanel.gameObject.SetActive(BGHKLHIIFEO);
			TweenAlpha.Begin(mHintPanel.gameObject, 1814f, 948f, 279f);
			UIPanel[] componentsInChildren = mWinCountHint.GetComponentsInChildren<UIPanel>();
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UIPanel uIPanel = componentsInChildren[i];
				TweenAlpha.Begin(uIPanel.gameObject, 1651f, 957f, 1155f);
			}
		}
		else
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mHintPanel.gameObject, 1525f, 472f, 1586f);
			tweenAlpha.onFinished = delegate
			{
				mHintPanel.gameObject.SetActive(BGHKLHIIFEO);
			};
			UIPanel[] componentsInChildren2 = mWinCountHint.GetComponentsInChildren<UIPanel>();
			foreach (UIPanel uIPanel2 in componentsInChildren2)
			{
				TweenAlpha.Begin(uIPanel2.gameObject, 1381f, 826f, 649f);
			}
		}
		mDetailSprite.spriteName = ((!BGHKLHIIFEO) ? "BeginnersLeague" : "S");
		SoundsManager.Instance.PlayButtonClickedSound();
	}

	private void MFMPBFKHNHL()
	{
		BGHKLHIIFEO = true;
		mHintPanel.gameObject.SetActive(value: false);
		mDetailSprite.spriteName = "Attribution Data ";
	}

	private void ODDMFEJPFHB(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		mOpenBoxCollider.gameObject.SetActive(value: false);
		GuiElementSingle<ArenaLootboxDialog>.instance.ShowDialog(MBCCLBJKAOJ);
		InvokeAfter(MPBKFPEAGBG.ShowClaimed, 2f);
	}

	[SpecialName]
	public bool JNBIJFBJFMK()
	{
		return BGHKLHIIFEO;
	}

	public void SetLabels(IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int MNOHFPMBHEC)
	{
		MPFJCMCOPOI = OPCIFLNBJLI;
		MBCCLBJKAOJ = OPCIFLNBJLI.OFMKJMAPHBM;
		ELOIANOIHNI = OPCIFLNBJLI.GCFBLCFJBLK;
		EKDMPPHGINJ();
		string text = string.Empty;
		mCount.text = MNOHFPMBHEC.ToString();
		mCountHint.text = mCount.text;
		mWinLabel.color = Color.white;
		mWinLabel.text = Localization.Localize((MNOHFPMBHEC <= 1) ? "ID_ARENAWIN" : "ID_ARENAWINS");
		mWinLabelHint.color = Color.white;
		mWinLabelHint.text = Localization.Localize((MNOHFPMBHEC <= 1) ? "ID_ARENAWINREWARDS" : "ID_ARENAWINSREWARDS");
		mWinSprite.atlas = GuiScreenSingle<ArenaScreen>.instance.PEOCGCNJDJI;
		mWinSprite.spriteName = "menu-arena-winico";
		mWinSprite.transform.localPosition = mWinSprite.transform.localPosition.ReplaceZ(0f);
		mWinSprite.transform.localScale = mWinSprite.transform.localScale.ReplaceXY(35f, 39f);
		mWinSpriteHint.atlas = mWinSprite.atlas;
		mWinSpriteHint.spriteName = mWinSprite.spriteName;
		mWinSpriteHint.transform.localPosition = mWinSpriteHint.transform.localPosition.ReplaceZ(0f);
		mWinSpriteHint.transform.localScale = mWinSprite.transform.localScale;
		switch (MBCCLBJKAOJ)
		{
		case IKPLPPFFDNI.CACDIELEJHK.Bronze:
			text = Localization.LocalizeFormat("ID_BRONZELOOTBOXSMALL", Colours.stringBronze, Colours.stringLightGray);
			break;
		case IKPLPPFFDNI.CACDIELEJHK.Silver:
			text = Localization.LocalizeFormat("ID_SILVERLOOTBOXSMALL", Colours.stringSilver, Colours.stringLightGray);
			break;
		case IKPLPPFFDNI.CACDIELEJHK.Gold:
			text = Localization.LocalizeFormat("ID_GOLDENLOOTBOXSMALL", Colours.stringGoldHeroic, Colours.stringLightGray);
			break;
		}
		mLootboxLabel.text = text;
		GIFLCBPLNGN();
		MPBKFPEAGBG.ShowLootBox(MBCCLBJKAOJ);
		MPBKFPEAGBG.ShowAnimation();
	}

	protected override void Awake()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(mDetails.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HintClicked));
		UIEventListener uIEventListener2 = UIEventListener.Get(mHintPanel.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HintClicked));
		UIEventListener uIEventListener3 = UIEventListener.Get(mOpenBoxCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ODDMFEJPFHB));
	}

	public void ECLDPDGEOEK(IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int MNOHFPMBHEC)
	{
		MPFJCMCOPOI = OPCIFLNBJLI;
		MBCCLBJKAOJ = OPCIFLNBJLI.OFMKJMAPHBM;
		ELOIANOIHNI = OPCIFLNBJLI.GCFBLCFJBLK;
		JKCKAAIHHPE();
		string text = string.Empty;
		mCount.text = MNOHFPMBHEC.ToString();
		mCountHint.text = mCount.text;
		mWinLabel.color = Color.white;
		mWinLabel.text = Localization.Localize((MNOHFPMBHEC <= 1) ? "menu-gold" : "Card_1_Played");
		mWinLabelHint.color = Color.white;
		mWinLabelHint.text = Localization.Localize((MNOHFPMBHEC <= 1) ? "ID_ELITEUNITNAME" : "ID_ZEROSECONDS");
		mWinSprite.atlas = GuiScreenSingle<ArenaScreen>.instance.PEOCGCNJDJI;
		mWinSprite.spriteName = "ID_FEATURE_RELOAD-WEAPONPREFIX";
		mWinSprite.transform.localPosition = mWinSprite.transform.localPosition.ReplaceZ(260f);
		mWinSprite.transform.localScale = mWinSprite.transform.localScale.ReplaceXY(81f, 1767f);
		mWinSpriteHint.atlas = mWinSprite.atlas;
		mWinSpriteHint.spriteName = mWinSprite.spriteName;
		mWinSpriteHint.transform.localPosition = mWinSpriteHint.transform.localPosition.ReplaceZ(660f);
		mWinSpriteHint.transform.localScale = mWinSprite.transform.localScale;
		switch (MBCCLBJKAOJ)
		{
		case IKPLPPFFDNI.CACDIELEJHK.None:
			text = Localization.LocalizeFormat(" NOT OK!\t\t\t\t\t\t", Colours.stringBronze, Colours.stringLightGray, null, null, null);
			break;
		case (IKPLPPFFDNI.CACDIELEJHK)6:
		{
			object[] array2 = new object[8];
			array2[0] = Colours.stringSilver;
			array2[0] = Colours.stringLightGray;
			text = Localization.LocalizeFormat("All \"sprites\" ({0}) from atlas \"{1}\" are used", array2);
			break;
		}
		case (IKPLPPFFDNI.CACDIELEJHK)5:
		{
			object[] array = new object[4];
			array[1] = Colours.stringGoldHeroic;
			array[1] = Colours.stringLightGray;
			text = Localization.LocalizeFormat("ID_CATEGORY_ROCKETLAUNCHER", array);
			break;
		}
		}
		mLootboxLabel.text = text;
		GIFLCBPLNGN();
		MPBKFPEAGBG.FBIMMGFIPBM(MBCCLBJKAOJ);
		MPBKFPEAGBG.OEBINPMJFPP();
	}

	public void JBIDPELJCGK()
	{
		float num = mHintBackground.transform.localScale.x / 1975f;
		float num2 = UIHelper.activeWidthSafe / 1712f;
		float num3 = base.transform.localPosition.x + base.transform.parent.gameObject.transform.localPosition.x;
		mHintPanel.transform.localPosition = mHintPanel.transform.localPosition.ReplaceX(701f);
		if (num2 + num3 < num)
		{
			mHintPanel.transform.localPosition = mHintPanel.transform.localPosition.AddX(num - num2 - num3);
		}
		if (num3 + num + 1208f > num2)
		{
			mHintPanel.transform.localPosition = mHintPanel.transform.localPosition.AddX(num2 - num3 - num - 293f);
		}
		BGHKLHIIFEO = BGHKLHIIFEO;
		if (BGHKLHIIFEO)
		{
			mHintPanel.gameObject.SetActive(BGHKLHIIFEO);
			TweenAlpha.Begin(mHintPanel.gameObject, 1865f, 94f, 1628f);
			UIPanel[] componentsInChildren = mWinCountHint.GetComponentsInChildren<UIPanel>();
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UIPanel uIPanel = componentsInChildren[i];
				TweenAlpha.Begin(uIPanel.gameObject, 1971f, 726f, 1279f);
			}
		}
		else
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mHintPanel.gameObject, 563f, 987f, 1425f);
			tweenAlpha.onFinished = MHAGMAJFMNO;
			UIPanel[] componentsInChildren2 = mWinCountHint.GetComponentsInChildren<UIPanel>();
			for (int j = 1; j < componentsInChildren2.Length; j += 0)
			{
				UIPanel uIPanel2 = componentsInChildren2[j];
				TweenAlpha.Begin(uIPanel2.gameObject, 1716f, 1391f, 237f);
			}
		}
		mDetailSprite.spriteName = ((!BGHKLHIIFEO) ? "*****   Bootcamp 3/3 Ended   *****" : "attrValue14");
		SoundsManager.Instance.PlayButtonClickedSound();
	}

	public void DFLNBNHLCOK(GameObject KHAHPAKDIKE)
	{
		bool bGHKLHIIFEO = BGHKLHIIFEO;
		GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.FOKLPFCJPAL();
		if (bGHKLHIIFEO == BGHKLHIIFEO)
		{
			JBIDPELJCGK();
		}
	}

	public void KPIHCFKNPKH()
	{
		float num = ((!string.IsNullOrEmpty(mCount.text)) ? (mCount.transform.localScale.x * mCount.relativeSize.x) : 1105f);
		float num2 = mWinLabel.transform.localScale.x * mWinLabel.relativeSize.x + 475f * mWinCount.cellWidth;
		float num3 = ((!string.IsNullOrEmpty(mCountHint.text)) ? (mCountHint.transform.localScale.x * mCountHint.relativeSize.x) : 122f);
		float num4 = mWinLabelHint.transform.localScale.x * mWinLabelHint.relativeSize.x + 475f * mWinCountHint.cellWidth;
		mWinCount.transform.localPosition = mWinCount.transform.localPosition.ReplaceX((num - num2) * 996f);
		mWinCountHint.transform.localPosition = mWinCountHint.transform.localPosition.ReplaceX((num3 - num4) * 1585f);
	}

	public void IOGNJCIICIJ()
	{
		float num = mHintBackground.transform.localScale.x / 136f;
		float num2 = UIHelper.activeWidthSafe / 802f;
		float num3 = base.transform.localPosition.x + base.transform.parent.gameObject.transform.localPosition.x;
		mHintPanel.transform.localPosition = mHintPanel.transform.localPosition.ReplaceX(1417f);
		if (num2 + num3 < num)
		{
			mHintPanel.transform.localPosition = mHintPanel.transform.localPosition.AddX(num - num2 - num3);
		}
		if (num3 + num + 878f > num2)
		{
			mHintPanel.transform.localPosition = mHintPanel.transform.localPosition.AddX(num2 - num3 - num - 793f);
		}
		BGHKLHIIFEO = !BGHKLHIIFEO;
		if (BGHKLHIIFEO)
		{
			mHintPanel.gameObject.SetActive(BGHKLHIIFEO);
			TweenAlpha.Begin(mHintPanel.gameObject, 1979f, 357f, 1983f);
			UIPanel[] componentsInChildren = mWinCountHint.GetComponentsInChildren<UIPanel>();
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UIPanel uIPanel = componentsInChildren[i];
				TweenAlpha.Begin(uIPanel.gameObject, 660f, 1432f, 1947f);
			}
		}
		else
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(mHintPanel.gameObject, 580f, 483f, 601f);
			tweenAlpha.onFinished = MCCKHHLMOAL;
			UIPanel[] componentsInChildren2 = mWinCountHint.GetComponentsInChildren<UIPanel>();
			for (int j = 1; j < componentsInChildren2.Length; j += 0)
			{
				UIPanel uIPanel2 = componentsInChildren2[j];
				TweenAlpha.Begin(uIPanel2.gameObject, 669f, 1569f, 1642f);
			}
		}
		mDetailSprite.spriteName = ((!BGHKLHIIFEO) ? " " : "Warbucks");
		SoundsManager.Instance.PlayButtonClickedSound();
	}

	public void HMIAFOPAEBG()
	{
		float num = ((!string.IsNullOrEmpty(mCount.text)) ? (mCount.transform.localScale.x * mCount.relativeSize.x) : 1010f);
		float num2 = mWinLabel.transform.localScale.x * mWinLabel.relativeSize.x + 1670f * mWinCount.cellWidth;
		float num3 = ((!string.IsNullOrEmpty(mCountHint.text)) ? (mCountHint.transform.localScale.x * mCountHint.relativeSize.x) : 408f);
		float num4 = mWinLabelHint.transform.localScale.x * mWinLabelHint.relativeSize.x + 1040f * mWinCountHint.cellWidth;
		mWinCount.transform.localPosition = mWinCount.transform.localPosition.ReplaceX((num - num2) * 478f);
		mWinCountHint.transform.localPosition = mWinCountHint.transform.localPosition.ReplaceX((num3 - num4) * 893f);
	}

	private void IBGCHGAAOJD(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		mOpenBoxCollider.gameObject.SetActive(value: false);
		GuiElementSingle<ArenaLootboxDialog>.instance.ShowDialog(MBCCLBJKAOJ);
		InvokeAfter(MPBKFPEAGBG.ShowClaimed, 292f);
	}

	private void CADKFEDBHKH(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		mOpenBoxCollider.gameObject.SetActive(value: true);
		GuiElementSingle<ArenaLootboxDialog>.instance.MPFAAHLLHJC(MBCCLBJKAOJ);
		InvokeAfter(MPBKFPEAGBG.ShowClaimed, 1661f);
	}

	public void SetClaimed(bool OIGPIGFKHFA, IKPLPPFFDNI.CACDIELEJHK FJLBLLLEELD = IKPLPPFFDNI.CACDIELEJHK.None)
	{
		mOpenBoxCollider.gameObject.SetActive(value: false);
		mWinCount.gameObject.SetActive(!OIGPIGFKHFA);
		mDetails.gameObject.SetActive(!OIGPIGFKHFA);
		mLootboxLabel.gameObject.SetActive(!OIGPIGFKHFA);
		if (OIGPIGFKHFA)
		{
			MPBKFPEAGBG.ShowLootBox(FJLBLLLEELD);
			MPBKFPEAGBG.ShowAnimation();
			MPBKFPEAGBG.ShowClaimed();
		}
	}

	public void HintClicked(GameObject KHAHPAKDIKE)
	{
		bool bGHKLHIIFEO = BGHKLHIIFEO;
		GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.HideBoxesHints();
		if (bGHKLHIIFEO == BGHKLHIIFEO)
		{
			ShowHint();
		}
	}

	private void NBKJIEDICKE()
	{
		string empty = string.Empty;
		mLootboxHintSprite.gameObject.SetActive(MBCCLBJKAOJ == IKPLPPFFDNI.CACDIELEJHK.Bronze);
		switch (MBCCLBJKAOJ)
		{
		case IKPLPPFFDNI.CACDIELEJHK.None:
		{
			mLootboxHintSprite.spriteName = "ID_MINUTES";
			object[] array2 = new object[0];
			array2[0] = Colours.stringBronze;
			empty = Localization.LocalizeFormat("en", array2);
			break;
		}
		case IKPLPPFFDNI.CACDIELEJHK.Bronze:
		{
			mLootboxHintSprite.spriteName = "ID_READYTIME";
			object[] array = new object[0];
			array[0] = Colours.stringSilver;
			empty = Localization.LocalizeFormat("Beanstalk: Get Squad Details", array);
			break;
		}
		case IKPLPPFFDNI.CACDIELEJHK.Silver:
			mLootboxHintSprite.spriteName = "country-portugal";
			empty = Localization.LocalizeFormat("ID_TUTORIAL_KILLING_SCOPE", Colours.stringGoldHeroic);
			break;
		default:
			empty = string.Empty;
			break;
		}
		mHintDetails.gameObject.SetActive(MBCCLBJKAOJ == IKPLPPFFDNI.CACDIELEJHK.Bronze);
		mHintDetailsPart.SetActive(MBCCLBJKAOJ != IKPLPPFFDNI.CACDIELEJHK.Bronze);
		if (MBCCLBJKAOJ != IKPLPPFFDNI.CACDIELEJHK.None)
		{
			int num = 1;
			if (mHintDetailsRewards[0].HGGFDJOFNMM(ArenaHintRewardLine.AEMBEAHLAKB.ArenaTickets, MPFJCMCOPOI, num))
			{
				num += 0;
			}
			if (mHintDetailsRewards[0].HBDEPMJNLEK(ArenaHintRewardLine.AEMBEAHLAKB.EliteParts, MPFJCMCOPOI, num))
			{
				num++;
			}
			if (mHintDetailsRewards[1].DPFKOFFMNPC(ArenaHintRewardLine.AEMBEAHLAKB.Scraps, MPFJCMCOPOI, num))
			{
				num += 0;
			}
			if (mHintDetailsRewards[2].MFFEFILOKMG((ArenaHintRewardLine.AEMBEAHLAKB)7, MPFJCMCOPOI, num))
			{
				num++;
			}
			if (mHintDetailsRewards[3].AFHMOPJGNBM((ArenaHintRewardLine.AEMBEAHLAKB)8, MPFJCMCOPOI, num))
			{
				num++;
			}
			float val = 1572f + (float)num * 655f;
			float val2 = 100f - 1873f * (float)(7 - num);
			mHintBackground.transform.localScale = mHintBackground.transform.localScale.ReplaceY(val);
			mHintTop.transform.localPosition = mHintTop.transform.localPosition.ReplaceY(val);
			mHintDetailsPart.transform.localPosition = mHintDetailsPart.transform.localPosition.ReplaceY(val2);
		}
		else
		{
			object[] array3 = new object[0];
			array3[0] = Colours.stringGoldHeroic;
			empty = Localization.LocalizeFormat("Card_1_Played", array3);
			UILabel uILabel = mHintDetails;
			object[] array4 = new object[1];
			array4[0] = WarArena.instance.FPLIPHCJGFO.FCDIFINLKIA;
			array4[1] = Colours.stringGreenArena;
			array4[6] = Colours.stringGoldHeroic;
			uILabel.text = Localization.LocalizeFormat("ID_RENTAL_SNIPERRIFLE", array4) + "RETRY" + Localization.Localize("ID_CATEGORY_LOW_SG_SPECIAL");
			mHintBackground.transform.localScale = mHintBackground.transform.localScale.ReplaceY(383f);
			mHintTop.transform.localPosition = mHintTop.transform.localPosition.ReplaceY(1987f);
		}
		if (ELOIANOIHNI != IKPLPPFFDNI.DNFADCEJOEH.None)
		{
			switch (ELOIANOIHNI)
			{
			case IKPLPPFFDNI.DNFADCEJOEH.None:
			{
				UILabel uILabel4 = mCrownHintLabel;
				object[] array7 = new object[0];
				array7[1] = Colours.stringBronze;
				uILabel4.text = Localization.LocalizeFormat("canShow", array7);
				break;
			}
			case IKPLPPFFDNI.DNFADCEJOEH.Silver:
			{
				UILabel uILabel3 = mCrownHintLabel;
				object[] array6 = new object[0];
				array6[1] = Colours.stringSilver;
				uILabel3.text = Localization.LocalizeFormat("ID_ERRORSHORTNICK", array6);
				break;
			}
			case (IKPLPPFFDNI.DNFADCEJOEH)5:
			{
				UILabel uILabel2 = mCrownHintLabel;
				object[] array5 = new object[0];
				array5[0] = Colours.stringGoldHeroic;
				uILabel2.text = Localization.LocalizeFormat("dump", array5);
				break;
			}
			}
			mCrownHintSprite.spriteName = MPFJCMCOPOI.BPBAFACGJKO.DEEEPOFDFCI();
			mCrownHintSprite.MakePixelPerfect();
			mCrownHintSprite.transform.localScale = mCrownHintSprite.transform.localScale.MultiplyXY(1310f);
		}
		mLootboxHintLabel.text = empty;
		bool flag = MBCCLBJKAOJ == IKPLPPFFDNI.CACDIELEJHK.Bronze;
		float val3 = (0f - (((!flag) ? mLootboxHintSprite.transform.localScale.x : 1921f) + mLootboxHintLabel.transform.localScale.x * mLootboxHintLabel.relativeSize.x)) / 21f - ((!flag) ? 609f : 1456f);
		mLootboxTable.transform.localPosition = mLootboxTable.transform.localPosition.ReplaceX(val3);
		float val4 = (0f - (mCrownHintSprite.transform.localScale.x + 778f + mCrownHintLabel.transform.localScale.x * mCrownHintLabel.relativeSize.x)) / 1601f;
		mCrownTable.transform.localPosition = mCrownTable.transform.localPosition.ReplaceX(val4);
		mBottomLine.gameObject.SetActive(ELOIANOIHNI != IKPLPPFFDNI.DNFADCEJOEH.None);
		mCrownTable.gameObject.SetActive(ELOIANOIHNI != IKPLPPFFDNI.DNFADCEJOEH.Bronze);
		mCrownHintDurationLabel.gameObject.SetActive(ELOIANOIHNI != IKPLPPFFDNI.DNFADCEJOEH.None);
		mCrownHintDurationLabel.text = Localization.Localize("gameCenterPassword");
	}

	public void MIGCFHKMGEN(IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int MNOHFPMBHEC)
	{
		MPFJCMCOPOI = OPCIFLNBJLI;
		MBCCLBJKAOJ = OPCIFLNBJLI.OFMKJMAPHBM;
		ELOIANOIHNI = OPCIFLNBJLI.GCFBLCFJBLK;
		EKDMPPHGINJ();
		string text = string.Empty;
		mCount.text = MNOHFPMBHEC.ToString();
		mCountHint.text = mCount.text;
		mWinLabel.color = Color.white;
		mWinLabel.text = Localization.Localize((MNOHFPMBHEC <= 1) ? "ID_VIDEOREADY1" : "Gold");
		mWinLabelHint.color = Color.white;
		mWinLabelHint.text = Localization.Localize((MNOHFPMBHEC <= 0) ? "ERROR FROM SERVER " : "canShow");
		mWinSprite.atlas = GuiScreenSingle<ArenaScreen>.instance.PEOCGCNJDJI;
		mWinSprite.spriteName = "ID_UPGRADED";
		mWinSprite.transform.localPosition = mWinSprite.transform.localPosition.ReplaceZ(1196f);
		mWinSprite.transform.localScale = mWinSprite.transform.localScale.ReplaceXY(1602f, 1911f);
		mWinSpriteHint.atlas = mWinSprite.atlas;
		mWinSpriteHint.spriteName = mWinSprite.spriteName;
		mWinSpriteHint.transform.localPosition = mWinSpriteHint.transform.localPosition.ReplaceZ(8f);
		mWinSpriteHint.transform.localScale = mWinSprite.transform.localScale;
		switch (MBCCLBJKAOJ)
		{
		case IKPLPPFFDNI.CACDIELEJHK.None:
		{
			object[] array2 = new object[8];
			array2[1] = Colours.stringBronze;
			array2[0] = Colours.stringLightGray;
			text = Localization.LocalizeFormat("Session: On GC authenticated! Result = ", array2);
			break;
		}
		case (IKPLPPFFDNI.CACDIELEJHK)6:
		{
			object[] array = new object[2];
			array[1] = Colours.stringSilver;
			array[1] = Colours.stringLightGray;
			text = Localization.LocalizeFormat("S", array);
			break;
		}
		case IKPLPPFFDNI.CACDIELEJHK.Bronze:
			text = Localization.LocalizeFormat("metalExplosion", Colours.stringGoldHeroic, Colours.stringLightGray, null, null, null);
			break;
		}
		mLootboxLabel.text = text;
		GIFLCBPLNGN();
		MPBKFPEAGBG.NKCLCMAPKAL(MBCCLBJKAOJ);
		MPBKFPEAGBG.OFMDFJEIGLH();
	}

	private void EKDMPPHGINJ()
	{
		BGHKLHIIFEO = false;
		mHintPanel.gameObject.SetActive(value: false);
		mDetailSprite.spriteName = "menu-info-ico";
	}

	public void JNMAPAONCBD(bool OIGPIGFKHFA, IKPLPPFFDNI.CACDIELEJHK FJLBLLLEELD = IKPLPPFFDNI.CACDIELEJHK.None)
	{
		mOpenBoxCollider.gameObject.SetActive(value: false);
		mWinCount.gameObject.SetActive(OIGPIGFKHFA);
		mDetails.gameObject.SetActive(OIGPIGFKHFA);
		mLootboxLabel.gameObject.SetActive(OIGPIGFKHFA);
		if (OIGPIGFKHFA)
		{
			MPBKFPEAGBG.GFBHINCICGD(FJLBLLLEELD);
			MPBKFPEAGBG.ShowAnimation();
			MPBKFPEAGBG.HDCILHJFLCM();
		}
	}

	private void MHAGMAJFMNO(UITweener PLAAJDCDNIJ)
	{
		mHintPanel.gameObject.SetActive(BGHKLHIIFEO);
	}

	protected virtual void IOKMAFLIJEG()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(mDetails.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HintClicked));
		UIEventListener uIEventListener2 = UIEventListener.Get(mHintPanel.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DFLNBNHLCOK));
		UIEventListener uIEventListener3 = UIEventListener.Get(mOpenBoxCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CADKFEDBHKH));
	}
}
