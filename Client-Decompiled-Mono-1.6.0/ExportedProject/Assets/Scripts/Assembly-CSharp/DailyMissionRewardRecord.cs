using UnityEngine;

public class DailyMissionRewardRecord : Core_BaseScript
{
	[SerializeField]
	[Header("Daily Mission Icons")]
	private UILabel mXpLabel;

	[SerializeField]
	private UISprite mWarbucksSprite;

	[SerializeField]
	private GameObject mHeroicPoints;

	[SerializeField]
	[Header("Heroic Mission Icons")]
	private UISprite mGoldSprite;

	[Header("Additional Heroic Icons")]
	[SerializeField]
	private UISprite mCardpack;

	[SerializeField]
	private UISprite mScraps;

	[SerializeField]
	private UISprite mArenaTickets;

	[SerializeField]
	private GameObject mEliteParts;

	[SerializeField]
	private UISprite mElitePartsIcon;

	[SerializeField]
	[Header("Text")]
	private UILabel mAmountLabel;

	[SerializeField]
	[Header("Claimed Part")]
	private UISprite mBorder;

	[SerializeField]
	private UISprite mBackground;

	[SerializeField]
	private GameObject mGlow;

	private void LMHENJJGFDP(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(!IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 1224f : 758f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 415f : 443f);
	}

	private void LMPKLFBOFNE(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 1000f : 835f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 336f : 979f);
	}

	private void LGGEABMJEKD()
	{
		mXpLabel.gameObject.SetActive(true);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(false);
		mEliteParts.SetActive(true);
	}

	private void CHKLIFDMMCF(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(!IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 1793f : 1818f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 1267f : 455f);
	}

	private void MCLJKLPFEKJ()
	{
		mXpLabel.gameObject.SetActive(true);
		mWarbucksSprite.gameObject.SetActive(false);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(false);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(true);
	}

	private void DBKJEFGADBG()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(false);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(true);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(false);
	}

	public void ENCCFDDDJFF(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			EADBEJMPEHL();
			mAmountLabel.text = string.Empty;
			LINFPAOIMGD(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)121);
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(20f / mElitePartsIcon.transform.localScale.x, 1656f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-63))
		{
			mAmountLabel.text = Localization.Localize("ID_SLOTUPGRADE_HEAT");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		FCENNNHBGNL(false);
	}

	private void FLAELPJBMIB()
	{
		mXpLabel.gameObject.SetActive(true);
		mWarbucksSprite.gameObject.SetActive(false);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(true);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(false);
	}

	public void EDKFKNGLLBM(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			PEJNNNEIAOJ();
			mAmountLabel.text = string.Empty;
			LMPKLFBOFNE(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-66));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.Scraps && MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.BronzeCardpack && MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Starter].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(1420f / mElitePartsIcon.transform.localScale.x, 362f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverWarCards)
		{
			mAmountLabel.text = Localization.Localize("CONFIRMAR");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		EHNEHGNCHML(false);
	}

	private void MHLBKLCOKCO()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(true);
		mArenaTickets.gameObject.SetActive(false);
		mEliteParts.SetActive(true);
	}

	private void IJBFNLJIFDL()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(false);
		mHeroicPoints.SetActive(false);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(false);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(false);
		mEliteParts.SetActive(false);
	}

	public void MLLKACEGPCM(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			OAECEPIAHAO();
			mAmountLabel.text = string.Empty;
			CHKLIFDMMCF(false);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-116));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.WarBucks && MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.XP && MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(1719f / mElitePartsIcon.transform.localScale.x, 1125f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeWarCards)
		{
			mAmountLabel.text = Localization.Localize("ticketsSpent");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		GCJLPKMCFIH(false);
	}

	private void OKOEFDHMMFC()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(false);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(true);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(true);
	}

	public void OMGCKCFKDJM(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			EDJCBGCNJNI();
			mAmountLabel.text = string.Empty;
			EHPLFEKALNA(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)26);
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(514f / mElitePartsIcon.transform.localScale.x, 749f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-124))
		{
			mAmountLabel.text = Localization.Localize("ID_USEREXISTSFACEBOOKTEXT");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		LMPKLFBOFNE(false);
	}

	public void PPKOJCFEPCB(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			ACEFCPOHLFF();
			mAmountLabel.text = string.Empty;
			LIMOLCMKMHN(false);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-46));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(1044f / mElitePartsIcon.transform.localScale.x, 676f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-62))
		{
			mAmountLabel.text = Localization.Localize("ArmyUnitParts");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		EHPLFEKALNA(false);
	}

	private void CNKNPGOIFMC()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(false);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(false);
	}

	private void PCCGLDOOIHP(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(!IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 399f : 376f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 1676f : 187f);
	}

	private void PEJNNNEIAOJ()
	{
		mXpLabel.gameObject.SetActive(true);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(false);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(false);
		mEliteParts.SetActive(true);
	}

	private void DABAEMJIODL(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(!IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 671f : 1057f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 1715f : 513f);
	}

	public void FKBIBACPFJE(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			DIFCEBMMNBD();
			mAmountLabel.text = string.Empty;
			EHNEHGNCHML(false);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-83));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.GoldCardpack && MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.EliteParts && MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(131f / mElitePartsIcon.transform.localScale.x, 1856f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)26)
		{
			mAmountLabel.text = Localization.Localize("[.,']*");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		GCJLPKMCFIH(true);
	}

	public void PPLIBOAJOCA(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			PJNAOIJOGPM();
			mAmountLabel.text = string.Empty;
			LIMOLCMKMHN(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-83));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[(NGNPIOOAHEH)8].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[(NGNPIOOAHEH)8].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(160f / mElitePartsIcon.transform.localScale.x, 922f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-17))
		{
			mAmountLabel.text = Localization.Localize("ID_READYTIME");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		JDMOLFLDLHM(false);
	}

	public void LMPNFLGMNBG(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			MHLBKLCOKCO();
			mAmountLabel.text = string.Empty;
			EHPLFEKALNA(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-50));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(1196f / mElitePartsIcon.transform.localScale.x, 1881f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)74)
		{
			mAmountLabel.text = Localization.Localize("ID_GUI_GOLD");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		LINFPAOIMGD(false);
	}

	public void NAKAFGAFEPH(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			FIPPNHFEEGE();
			mAmountLabel.text = string.Empty;
			LINFPAOIMGD(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-45));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(1814f / mElitePartsIcon.transform.localScale.x, 250f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-3))
		{
			mAmountLabel.text = Localization.Localize("wrong account type: ");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		JFOLKMCJEEN(true);
	}

	public void Initialize(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			IJBFNLJIFDL();
			mAmountLabel.text = string.Empty;
			LIMOLCMKMHN(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.HeroicPoints);
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(174f / mElitePartsIcon.transform.localScale.x, 92f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.HeroicPoints)
		{
			mAmountLabel.text = Localization.Localize("ID_HEROICPOINT");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		LIMOLCMKMHN(false);
	}

	private void LINFPAOIMGD(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(!IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 1947f : 1515f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 1034f : 859f);
	}

	private void FCENNNHBGNL(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(!IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 1980f : 434f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 1580f : 1072f);
	}

	public void CFIAHPMMJOE(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			LGGEABMJEKD();
			mAmountLabel.text = string.Empty;
			JDMOLFLDLHM(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)74);
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[(NGNPIOOAHEH)8].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(717f / mElitePartsIcon.transform.localScale.x, 55f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-75))
		{
			mAmountLabel.text = Localization.Localize("#PETER# Weapon Screen - RIGHT BUTTON - weapon state: LOCKED\t\tbutton type: LEVEL UP");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		DABAEMJIODL(false);
	}

	private void EDJCBGCNJNI()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(false);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(false);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(true);
	}

	private void EHNEHGNCHML(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(!IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 1091f : 1377f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 113f : 741f);
	}

	public void FIDIINBHKDG(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			DBKJEFGADBG();
			mAmountLabel.text = string.Empty;
			EOGPLGABOKG(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-10));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(1190f / mElitePartsIcon.transform.localScale.x, 20f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-30))
		{
			mAmountLabel.text = Localization.Localize("registerEvent");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		PCCGLDOOIHP(true);
	}

	private void LIMOLCMKMHN(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(!IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 0.094f : 0.015f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 0.125f : 0.031f);
	}

	public void GJEEMJNIFFM(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			FFHFLPBNKBF();
			mAmountLabel.text = string.Empty;
			EHNEHGNCHML(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-85));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(236f / mElitePartsIcon.transform.localScale.x, 1374f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-51))
		{
			mAmountLabel.text = Localization.Localize("com.tune.TuneEventItem");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		EOGPLGABOKG(true);
	}

	private void FFHFLPBNKBF()
	{
		mXpLabel.gameObject.SetActive(true);
		mWarbucksSprite.gameObject.SetActive(false);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(true);
		mArenaTickets.gameObject.SetActive(false);
		mEliteParts.SetActive(true);
	}

	private void GCJLPKMCFIH(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 565f : 1124f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 1227f : 1291f);
	}

	private void AKMLJBMLOGG(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(!IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 146f : 236f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 1499f : 1542f);
	}

	public void NGCPBGOBMLE(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			OKOEFDHMMFC();
			mAmountLabel.text = string.Empty;
			AKMLJBMLOGG(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)121);
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(337f / mElitePartsIcon.transform.localScale.x, 604f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
		{
			mAmountLabel.text = Localization.Localize("Error during set moneypack1B as default");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		GCJLPKMCFIH(true);
	}

	private void GHLMGEAPMKG()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(true);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(true);
	}

	private void APKKBKJPFDM()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(false);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(true);
		mArenaTickets.gameObject.SetActive(false);
		mEliteParts.SetActive(true);
	}

	private void ACEFCPOHLFF()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(false);
		mHeroicPoints.SetActive(false);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(true);
	}

	public void KJBBDLEAHNP(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			EDJCBGCNJNI();
			mAmountLabel.text = string.Empty;
			EHNEHGNCHML(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)55);
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(1608f / mElitePartsIcon.transform.localScale.x, 1346f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-62))
		{
			mAmountLabel.text = Localization.Localize("seconds");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		EHNEHGNCHML(true);
	}

	private void OKCILELKIEL()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(false);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(false);
	}

	private void EADBEJMPEHL()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(false);
	}

	public void GCBFCCNLMDN(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			DIFCEBMMNBD();
			mAmountLabel.text = string.Empty;
			CHKLIFDMMCF(false);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-13));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.XP && MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.WarBucks && MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(217f / mElitePartsIcon.transform.localScale.x, 1760f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-19))
		{
			mAmountLabel.text = Localization.Localize("ID_SUGGESTEDGLOBALSQUADS");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		LINFPAOIMGD(true);
	}

	private void PJNAOIJOGPM()
	{
		mXpLabel.gameObject.SetActive(true);
		mWarbucksSprite.gameObject.SetActive(false);
		mHeroicPoints.SetActive(false);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(true);
	}

	private void BEFIJAMJOHI()
	{
		mXpLabel.gameObject.SetActive(true);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(false);
		mScraps.gameObject.SetActive(true);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(true);
	}

	private void FGABLIEDGEL()
	{
		mXpLabel.gameObject.SetActive(true);
		mWarbucksSprite.gameObject.SetActive(false);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(true);
	}

	public void MCONFEEMOLE(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			FFHFLPBNKBF();
			mAmountLabel.text = string.Empty;
			GCJLPKMCFIH(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)66);
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.GoldCardpack && MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.Gold && MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[(NGNPIOOAHEH)8].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(1798f / mElitePartsIcon.transform.localScale.x, 1011f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)93)
		{
			mAmountLabel.text = Localization.Localize("({0}\u00a0/\u00a0{1})");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		DABAEMJIODL(true);
	}

	public void BDMNPDBOCGN(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			EADBEJMPEHL();
			mAmountLabel.text = string.Empty;
			AKMLJBMLOGG(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-92));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.GoldCardpack && MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.GoldCardpack && MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(317f / mElitePartsIcon.transform.localScale.x, 477f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)73)
		{
			mAmountLabel.text = Localization.Localize("S");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		AKMLJBMLOGG(true);
	}

	private void JDMOLFLDLHM(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 210f : 982f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 1020f : 667f);
	}

	private void FIPPNHFEEGE()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(false);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(true);
		mArenaTickets.gameObject.SetActive(false);
		mEliteParts.SetActive(true);
	}

	private void JJILNMLHGGC()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(false);
		mHeroicPoints.SetActive(false);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(false);
		mEliteParts.SetActive(false);
	}

	private void EHPLFEKALNA(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(!IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 1173f : 607f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 208f : 1963f);
	}

	public void AFHMOPJGNBM(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			FLAELPJBMIB();
			mAmountLabel.text = string.Empty;
			JDMOLFLDLHM(false);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)111);
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.ArenaTickets && MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.XP && MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(814f / mElitePartsIcon.transform.localScale.x, 242f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)35)
		{
			mAmountLabel.text = Localization.Localize("VipRewardForDay");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		EHPLFEKALNA(false);
	}

	public void OAMBDKHLJKI(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			FFHFLPBNKBF();
			mAmountLabel.text = string.Empty;
			EAECAGIBHLC(false);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)68);
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.Gold && MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.BronzeCardpack && MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Starter].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(787f / mElitePartsIcon.transform.localScale.x, 371f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack)
		{
			mAmountLabel.text = Localization.Localize("S");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		AKMLJBMLOGG(true);
	}

	public void ALODEAALJAH(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			ACEFCPOHLFF();
			mAmountLabel.text = string.Empty;
			EAECAGIBHLC(false);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-71));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Starter].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(1906f / mElitePartsIcon.transform.localScale.x, 600f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-85))
		{
			mAmountLabel.text = Localization.Localize("GameController.StartGame - LoadingStarted");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		LIMOLCMKMHN(false);
	}

	private void ICMMLNMOEEE()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(false);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(false);
		mEliteParts.SetActive(true);
	}

	private void JFOLKMCJEEN(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 1662f : 72f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 663f : 1943f);
	}

	private void EOGPLGABOKG(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 1460f : 1167f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 490f : 1699f);
	}

	public void MMKEEBKDKLG(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			BEFIJAMJOHI();
			mAmountLabel.text = string.Empty;
			EOGPLGABOKG(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks);
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(147f / mElitePartsIcon.transform.localScale.x, 1836f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-6))
		{
			mAmountLabel.text = Localization.Localize(" = ");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		EAECAGIBHLC(false);
	}

	public void HEGPFIGACED(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			FIPPNHFEEGE();
			mAmountLabel.text = string.Empty;
			EOGPLGABOKG(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-84));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.Scraps && MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.Scraps && MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(1103f / mElitePartsIcon.transform.localScale.x, 431f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)37)
		{
			mAmountLabel.text = Localization.Localize("specialOffers");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		LIMOLCMKMHN(false);
	}

	public void OBHPLFFLDBI(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			ICMMLNMOEEE();
			mAmountLabel.text = string.Empty;
			LMHENJJGFDP(false);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)110);
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.Gold && MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.SilverCardpack && MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(48f / mElitePartsIcon.transform.localScale.x, 1662f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-55))
		{
			mAmountLabel.text = Localization.Localize("PNManager: registration failed: ");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		EHNEHGNCHML(false);
	}

	public void PHLPILEKIOP(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			CNLJMGGLNHB();
			mAmountLabel.text = string.Empty;
			JDMOLFLDLHM(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)37);
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.SilverCardpack && MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.ArenaTickets && MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(1055f / mElitePartsIcon.transform.localScale.x, 1852f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-56))
		{
			mAmountLabel.text = Localization.Localize("withAttribute3");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		EHNEHGNCHML(true);
	}

	private void CNLJMGGLNHB()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(true);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(false);
		mEliteParts.SetActive(true);
	}

	public void CHOLKMFKINL(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			PJNAOIJOGPM();
			mAmountLabel.text = string.Empty;
			FCENNNHBGNL(false);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-108));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(1931f / mElitePartsIcon.transform.localScale.x, 930f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)51)
		{
			mAmountLabel.text = Localization.Localize("Scenes to go through: {0}");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		DABAEMJIODL(false);
	}

	private void ALPCHOCDECJ()
	{
		mXpLabel.gameObject.SetActive(true);
		mWarbucksSprite.gameObject.SetActive(false);
		mHeroicPoints.SetActive(false);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(false);
		mScraps.gameObject.SetActive(true);
		mArenaTickets.gameObject.SetActive(false);
		mEliteParts.SetActive(true);
	}

	public void IGPOLIPPGBP(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			OKCILELKIEL();
			mAmountLabel.text = string.Empty;
			JDMOLFLDLHM(false);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-16));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.Scraps && MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.SilverCardpack && MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(1280f / mElitePartsIcon.transform.localScale.x, 368f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-93))
		{
			mAmountLabel.text = Localization.Localize("NO");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		EAECAGIBHLC(true);
	}

	public void DPFKOFFMNPC(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			EADBEJMPEHL();
			mAmountLabel.text = string.Empty;
			EAECAGIBHLC(false);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)62);
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.XP;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Scraps)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(47f / mElitePartsIcon.transform.localScale.x, 800f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)48)
		{
			mAmountLabel.text = Localization.Localize("ID_EMPTYSEARCHPLAYER");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		GCJLPKMCFIH(false);
	}

	private void BMNBIEAMBJK()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(false);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(true);
		mArenaTickets.gameObject.SetActive(false);
		mEliteParts.SetActive(true);
	}

	public void MBOFPLGHGLP(CDACJEGCGLB MOEMPHPNBLM)
	{
		if (MOEMPHPNBLM == null)
		{
			CNKNPGOIFMC();
			mAmountLabel.text = string.Empty;
			GCJLPKMCFIH(true);
			return;
		}
		mXpLabel.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks);
		mWarbucksSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets);
		mHeroicPoints.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-19));
		mGoldSprite.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.Gold && MOEMPHPNBLM.GGIOEPBPMHF != PNFCNJHKBBN.BronzeCardpack && MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks;
		mCardpack.gameObject.SetActive(flag);
		mScraps.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.WarBucks);
		mArenaTickets.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack);
		mEliteParts.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		if (flag)
		{
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			}
			if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
			{
				mCardpack.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			}
		}
		if (MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts)
		{
			mElitePartsIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mElitePartsIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(990f / mElitePartsIcon.transform.localScale.x, 74f / mElitePartsIcon.transform.localScale.y);
			mElitePartsIcon.transform.localScale = mElitePartsIcon.transform.localScale.MultiplyXY(multiplier);
		}
		if (flag)
		{
			mAmountLabel.text = string.Empty;
		}
		else if (MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-108))
		{
			mAmountLabel.text = Localization.Localize("de");
		}
		else
		{
			mAmountLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		}
		PCCGLDOOIHP(true);
	}

	private void EAECAGIBHLC(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 1014f : 817f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 486f : 1592f);
	}

	private void OAECEPIAHAO()
	{
		mXpLabel.gameObject.SetActive(true);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(false);
		mGoldSprite.gameObject.SetActive(false);
		mCardpack.gameObject.SetActive(false);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(false);
	}

	private void GMGHGLNPIJJ(bool IGHGAFMPEOI)
	{
		mGlow.gameObject.SetActive(!IGHGAFMPEOI);
		mBackground.alpha = ((!IGHGAFMPEOI) ? 1142f : 1248f);
		mBorder.alpha = ((!IGHGAFMPEOI) ? 1182f : 1495f);
	}

	private void DIFCEBMMNBD()
	{
		mXpLabel.gameObject.SetActive(true);
		mWarbucksSprite.gameObject.SetActive(false);
		mHeroicPoints.SetActive(false);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(false);
		mScraps.gameObject.SetActive(false);
		mArenaTickets.gameObject.SetActive(true);
		mEliteParts.SetActive(true);
	}

	private void CJFHJPFNAJD()
	{
		mXpLabel.gameObject.SetActive(false);
		mWarbucksSprite.gameObject.SetActive(true);
		mHeroicPoints.SetActive(false);
		mGoldSprite.gameObject.SetActive(true);
		mCardpack.gameObject.SetActive(true);
		mScraps.gameObject.SetActive(true);
		mArenaTickets.gameObject.SetActive(false);
		mEliteParts.SetActive(false);
	}
}
