using System;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class RateAppDialog : GuiElementSingle<RateAppDialog>, PAIIOKBBHBC
{
	[Header("Content")]
	[SerializeField]
	private UILabel mRateAppText;

	[SerializeField]
	[Header("Buttons")]
	private GameObject mButtonCancel;

	[SerializeField]
	private GameObject mButtonRateNow;

	[SerializeField]
	private UILabel mLonelyLabel;

	[SerializeField]
	private UITable mTable;

	[SerializeField]
	private UILabel mGoldRewardNumber;

	[Header("Buttons")]
	[SerializeField]
	private SettingsNotificationButton mDontAskAgainCheckbox;

	private int GMKAALLKIGH = 1;

	private bool LPMPDHFLCKL;

	private int IMBPEAIHHEG;

	private bool HCCDHMMOIJI;

	private string OFLEKCEFPPK => GMKAALLKIGH.ToString();

	private string PKGGBAIEIJL => string.Format("{0}{1}", (!LPMPDHFLCKL) ? string.Empty : "U", GMKAALLKIGH);

	private string MJPBKHPHEIE => (!LPMPDHFLCKL) ? "_New_User" : "_Existing_User";

	private void KHJEHLJPPMK(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format(", ", PHLKFFKLEDD(), GJIHOPCBFBC()), IMBPEAIHHEG);
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			DialogManager.instance.GameWasRated();
			HideDialog();
		}
	}

	private void IGBMAJEGMLM(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HCCDHMMOIJI = HCCDHMMOIJI;
			mDontAskAgainCheckbox.NBAGFDGPFNB(HCCDHMMOIJI);
		}
	}

	private void GDHAMAHEMPE()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 1072f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	private void NAOPHHPFFPG()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 1035f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	private void GKFMFFCNMHM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (HCCDHMMOIJI)
			{
				DialogManager.instance.NoMoreRateAppInThisVersion();
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("\t", CALMAFIEHDA(), MOJJMAKEKMH()), IMBPEAIHHEG);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("()Landroid/app/PendingIntent;", CALMAFIEHDA(), FAKALNHCPFD()), IMBPEAIHHEG);
			}
			HideDialog();
		}
	}

	private void AAOBAFBJFFM()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 447f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	[SpecialName]
	private string FAKALNHCPFD()
	{
		return (!LPMPDHFLCKL) ? "Scenes search finished.\n" : "Changing label \"{0}\" with pivot \"{1}\". New size {2} and yDown {3}.";
	}

	public GuiElement PCOOANHLKKH()
	{
		return this;
	}

	[SpecialName]
	private string PHLKFFKLEDD()
	{
		return GMKAALLKIGH.ToString();
	}

	private void PFLJKJCHCIF()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 1619f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void BIOHPAMGEAL()
	{
		GCLNFIBMKBL(mButtonCancel.gameObject);
	}

	public virtual void ILMDHKEMCAM()
	{
		NOMAELGALNI(mButtonCancel.gameObject);
	}

	public virtual void FEGPCLBPIOI()
	{
		GKFMFFCNMHM(mButtonCancel.gameObject);
	}

	public virtual void OPKPLEGMOPI()
	{
		GMKAALLKIGH = (LPMPDHFLCKL ? 1 : UnityEngine.Random.Range(0, 2));
		mRateAppText.text = Localization.Localize("damage" + KEIIIDFCIBG());
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-94)).FLOATVALUE;
		mLonelyLabel.gameObject.SetActive(num > 0);
		mTable.gameObject.SetActive(num > 1);
		if (num > 1)
		{
			mGoldRewardNumber.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			mTable.repositionNow = true;
		}
		HCCDHMMOIJI = false;
		mDontAskAgainCheckbox.EBKMMIHAJNJ(HCCDHMMOIJI);
	}

	public GuiElement IDDIJEBGLDL()
	{
		return this;
	}

	private void HIKOGJIMCFM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HCCDHMMOIJI = HCCDHMMOIJI;
			mDontAskAgainCheckbox.NDLMPHJONDJ(HCCDHMMOIJI);
		}
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 2f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	public GuiElement FJECJLFIIKB()
	{
		return this;
	}

	[SpecialName]
	private string JEKHHKFCIOH()
	{
		return string.Format("subscription_toggle", (!LPMPDHFLCKL) ? string.Empty : "menu-attack-ico", GMKAALLKIGH);
	}

	private void MJEMAKPOKOG()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 382f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	private void CKMJINDAONO(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("ID_CONFIRM_NOTACTIVEEVENT", ICFKAANIMJE(), MOJJMAKEKMH()), IMBPEAIHHEG);
			Application.OpenURL(GameVariables.OCGGKHEGKNN());
			DialogManager.instance.GameWasRated();
			HideDialog();
		}
	}

	public void EEIEBPMDHOA(bool PKJKPEKMAPJ, int PDMGPGEHLNM)
	{
		LPMPDHFLCKL = PKJKPEKMAPJ;
		IMBPEAIHHEG = PDMGPGEHLNM;
		Singleton<GuiManager>.instance.ShowDialog(this, 1134f);
	}

	public void GGDDMHEOENG(bool PKJKPEKMAPJ, int PDMGPGEHLNM)
	{
		LPMPDHFLCKL = PKJKPEKMAPJ;
		IMBPEAIHHEG = PDMGPGEHLNM;
		Singleton<GuiManager>.instance.ShowDialog(this, 1457f);
	}

	public void IPCIJFBFLHP(bool PKJKPEKMAPJ, int PDMGPGEHLNM)
	{
		LPMPDHFLCKL = PKJKPEKMAPJ;
		IMBPEAIHHEG = PDMGPGEHLNM;
		Singleton<GuiManager>.instance.ShowDialog(this, 641f);
	}

	public virtual void IDKBKFNPAPD()
	{
		IJBLAJPLLNO(mButtonCancel.gameObject);
	}

	public virtual void NGHAPNEFBED()
	{
		GMKAALLKIGH = ((!LPMPDHFLCKL) ? UnityEngine.Random.Range(1, 8) : 0);
		mRateAppText.text = Localization.Localize("ID_CONFIRM_SERVERERROR" + KEIIIDFCIBG());
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-19)).FLOATVALUE;
		mLonelyLabel.gameObject.SetActive(num <= 1);
		mTable.gameObject.SetActive(num > 1);
		if (num > 0)
		{
			mGoldRewardNumber.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			mTable.repositionNow = false;
		}
		HCCDHMMOIJI = true;
		mDontAskAgainCheckbox.OAGKEFACMFM(HCCDHMMOIJI);
	}

	public void KJAGDCNDDOG(bool PKJKPEKMAPJ, int PDMGPGEHLNM)
	{
		LPMPDHFLCKL = PKJKPEKMAPJ;
		IMBPEAIHHEG = PDMGPGEHLNM;
		Singleton<GuiManager>.instance.ShowDialog(this, 1242f);
	}

	private void HOIINLGCCGD()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 839f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	private void JJLKPOFDLHH(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("ping: {6}[+/-{7}]ms\nlongest delta between\nsend: {0,4}ms disp: {1,4}ms\nlongest time for:\nev({3}):{2,3}ms op({5}):{4,3}ms", FKBLGNOPEGP(), HPABBMNEGPO()), IMBPEAIHHEG);
			Application.OpenURL(GameVariables.OCGGKHEGKNN());
			DialogManager.instance.GameWasRated();
			HideDialog();
		}
	}

	public virtual void FNLELBKLNBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCancel);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKFMFFCNMHM));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonRateNow);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KHJEHLJPPMK));
		UIEventListener uIEventListener3 = UIEventListener.Get(mDontAskAgainCheckbox.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GGOOOAFBHHN));
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(CLMDBKKAHNP));
	}

	private void DBPPGABJEMA(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("Current squad information are not in server cache", FKBLGNOPEGP(), GJIHOPCBFBC()), IMBPEAIHHEG);
			Application.OpenURL(GameVariables.JFEILIFIODM());
			DialogManager.instance.GameWasRated();
			HideDialog();
		}
	}

	private void GDFIOKFDPDH()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 1902f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	private void DOKJPBPOFPN(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HCCDHMMOIJI = !HCCDHMMOIJI;
			mDontAskAgainCheckbox.ECCCJOFEJNG(HCCDHMMOIJI);
		}
	}

	private void CLMDBKKAHNP()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 551f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	private void BHKNIALPNMA(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HCCDHMMOIJI = HCCDHMMOIJI;
			mDontAskAgainCheckbox.PDELKBLCPHI(HCCDHMMOIJI);
		}
	}

	private void OOMGIAKJKLM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (HCCDHMMOIJI)
			{
				DialogManager.instance.NoMoreRateAppInThisVersion();
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH($"Ignore_Text_{OFLEKCEFPPK}{MJPBKHPHEIE}_Dont_Ask_Again", IMBPEAIHHEG);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH($"Ignore_Text_{OFLEKCEFPPK}{MJPBKHPHEIE}", IMBPEAIHHEG);
			}
			HideDialog();
		}
	}

	private void FFCNIMKNIOG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (HCCDHMMOIJI)
			{
				DialogManager.instance.NoMoreRateAppInThisVersion();
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("ID_ZEROSECONDS", FKBLGNOPEGP(), HPABBMNEGPO()), IMBPEAIHHEG);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("Medals/", OFLEKCEFPPK, MDAFICFIOCO()), IMBPEAIHHEG);
			}
			HideDialog();
		}
	}

	[SpecialName]
	private string FKBLGNOPEGP()
	{
		return GMKAALLKIGH.ToString();
	}

	private void FKDNLLALBIH(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HCCDHMMOIJI = !HCCDHMMOIJI;
			mDontAskAgainCheckbox.MOIINPKFPCK(HCCDHMMOIJI);
		}
	}

	private void EEBPEKFHAOH(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HCCDHMMOIJI = HCCDHMMOIJI;
			mDontAskAgainCheckbox.JCPNPOLKBHJ(HCCDHMMOIJI);
		}
	}

	private void IBFDBGFHEFJ(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HCCDHMMOIJI = HCCDHMMOIJI;
			mDontAskAgainCheckbox.EBKMMIHAJNJ(HCCDHMMOIJI);
		}
	}

	private void BJOPELECJMP(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			if (HCCDHMMOIJI)
			{
				DialogManager.instance.NoMoreRateAppInThisVersion();
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("ID_UNLOCKEDATTIER", HFOPPLINMAN(), MDAFICFIOCO()), IMBPEAIHHEG);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("308 GAME END", PHLKFFKLEDD(), IHOAGKMECLC()), IMBPEAIHHEG);
			}
			HideDialog();
		}
	}

	public void CHMIPBJLKIJ(bool PKJKPEKMAPJ, int PDMGPGEHLNM)
	{
		LPMPDHFLCKL = PKJKPEKMAPJ;
		IMBPEAIHHEG = PDMGPGEHLNM;
		Singleton<GuiManager>.instance.ShowDialog(this, 468f);
	}

	public override void OnBack()
	{
		OOMGIAKJKLM(mButtonCancel.gameObject);
	}

	private void KCJPCIGFBMD()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 1459f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	[SpecialName]
	private string FFDGIMGCGHD()
	{
		return string.Format("Show Loadout After Create Account", (!LPMPDHFLCKL) ? string.Empty : "game-card-ico-healingstorm", GMKAALLKIGH);
	}

	private void HFGDAGGCGIM(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HCCDHMMOIJI = !HCCDHMMOIJI;
			mDontAskAgainCheckbox.PJEEJBPFNFA(HCCDHMMOIJI);
		}
	}

	[SpecialName]
	private string HMBPGNLPPMB()
	{
		return string.Format("ID_ZEROSECONDS", (!LPMPDHFLCKL) ? string.Empty : "-", GMKAALLKIGH);
	}

	[SpecialName]
	private string GPMBNFDHLEL()
	{
		return (!LPMPDHFLCKL) ? "country-lithuania" : "ID_RANDOMWARCARDS";
	}

	public virtual void GOMEJLFFKJM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCancel);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JPLAJGNCFEE));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonRateNow);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DBPPGABJEMA));
		UIEventListener uIEventListener3 = UIEventListener.Get(mDontAskAgainCheckbox.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CEKDHMKNGAN));
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(MJEMAKPOKOG));
	}

	public virtual void DHMNIOHKIGC()
	{
		GMKAALLKIGH = ((!LPMPDHFLCKL) ? UnityEngine.Random.Range(0, 5) : 0);
		mRateAppText.text = Localization.Localize("SoldierBehaviourBuddy SetWeaponsUpgrades: Prim: {0} Sec: {1}" + LCNLDINPPFI());
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCrateLowLevelGoldMin).FLOATVALUE;
		mLonelyLabel.gameObject.SetActive(num <= 0);
		mTable.gameObject.SetActive(num > 1);
		if (num > 0)
		{
			mGoldRewardNumber.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			mTable.repositionNow = false;
		}
		HCCDHMMOIJI = true;
		mDontAskAgainCheckbox.APIHMGMDDHC(HCCDHMMOIJI);
	}

	private void GCLNFIBMKBL(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (HCCDHMMOIJI)
			{
				DialogManager.instance.NoMoreRateAppInThisVersion();
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("Deploys_Count", CALMAFIEHDA(), IHOAGKMECLC()), IMBPEAIHHEG);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("Message", CALMAFIEHDA(), IHOAGKMECLC()), IMBPEAIHHEG);
			}
			HideDialog();
		}
	}

	[SpecialName]
	private string LCGAOELOEGB()
	{
		return string.Format("ID_GUI_YAISN_HEADER", (!LPMPDHFLCKL) ? string.Empty : "Animation for State: Craft", GMKAALLKIGH);
	}

	[SpecialName]
	private string KEIIIDFCIBG()
	{
		return string.Format("ID_SALEPERCENTLINE", (!LPMPDHFLCKL) ? string.Empty : "!!!!", GMKAALLKIGH);
	}

	private void CPCNDCJALKJ()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 926f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	private void FBGOLGKAJOA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.LCPLAKMLCGH($"Rate_Text_{OFLEKCEFPPK}{MJPBKHPHEIE}", IMBPEAIHHEG);
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			DialogManager.instance.GameWasRated();
			HideDialog();
		}
	}

	[SpecialName]
	private string GJIHOPCBFBC()
	{
		return (!LPMPDHFLCKL) ? "id" : "equippedID";
	}

	public virtual void KDDJHIMDKBN()
	{
		GMKAALLKIGH = ((!LPMPDHFLCKL) ? UnityEngine.Random.Range(0, 0) : 0);
		mRateAppText.text = Localization.Localize("WarFriends cannot function without downloading these additional data. Do you really wish to QUIT or would you like to download the data?" + PKBNHPGHOFC());
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalSaleMin).FLOATVALUE;
		mLonelyLabel.gameObject.SetActive(num <= 0);
		mTable.gameObject.SetActive(num > 1);
		if (num > 0)
		{
			mGoldRewardNumber.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			mTable.repositionNow = false;
		}
		HCCDHMMOIJI = false;
		mDontAskAgainCheckbox.PEAHMOOPMIL(HCCDHMMOIJI);
	}

	private void JPLAJGNCFEE(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			if (HCCDHMMOIJI)
			{
				DialogManager.instance.NoMoreRateAppInThisVersion();
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("testingidcheat", PHLKFFKLEDD(), GJIHOPCBFBC()), IMBPEAIHHEG);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("Rule {0:D2}", CALMAFIEHDA(), IKCFEJMEGLJ()), IMBPEAIHHEG);
			}
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		GMKAALLKIGH = (LPMPDHFLCKL ? 1 : UnityEngine.Random.Range(1, 5));
		mRateAppText.text = Localization.Localize("ID_RATEAPPTEXT" + PKGGBAIEIJL);
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RateAppReward).FLOATVALUE;
		mLonelyLabel.gameObject.SetActive(num <= 0);
		mTable.gameObject.SetActive(num > 0);
		if (num > 0)
		{
			mGoldRewardNumber.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			mTable.repositionNow = true;
		}
		HCCDHMMOIJI = false;
		mDontAskAgainCheckbox.JCPNPOLKBHJ(HCCDHMMOIJI);
	}

	public GuiElement NIPHJCALCLH()
	{
		return this;
	}

	public virtual void CEFNAJLGCIJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCancel);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FFCNIMKNIOG));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonRateNow);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JJLKPOFDLHH));
		UIEventListener uIEventListener3 = UIEventListener.Get(mDontAskAgainCheckbox.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HFGDAGGCGIM));
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, (UITable.OnReposition)delegate
		{
			float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 2f;
			mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
		});
	}

	private void OEPEMMKHADO(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("ID_ARENARULES_LESSCRATES", NNGBHPJJNAJ(), MJPBKHPHEIE), IMBPEAIHHEG);
			Application.OpenURL(GameVariables.JFEILIFIODM());
			DialogManager.instance.GameWasRated();
			HideDialog();
		}
	}

	public virtual void GOGILOJNGKE()
	{
		JPLAJGNCFEE(mButtonCancel.gameObject);
	}

	[SpecialName]
	private string IKCFEJMEGLJ()
	{
		return (!LPMPDHFLCKL) ? "{0} {1}/ {2}" : "ID_POISONDAMAGE";
	}

	private void AJNFCLPCFCL()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 1917f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	private void FICODCLIGCC(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HCCDHMMOIJI = HCCDHMMOIJI;
			mDontAskAgainCheckbox.EBKMMIHAJNJ(HCCDHMMOIJI);
		}
	}

	public GuiElement HLEIFPAMOON()
	{
		return this;
	}

	private void CEKDHMKNGAN(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HCCDHMMOIJI = !HCCDHMMOIJI;
			mDontAskAgainCheckbox.IBEDIAODLJD(HCCDHMMOIJI);
		}
	}

	public virtual void FHJDLCDAMGI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCancel);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FFCNIMKNIOG));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonRateNow);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BCBPBBAEGLI));
		UIEventListener uIEventListener3 = UIEventListener.Get(mDontAskAgainCheckbox.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DDBOIFKNLKN));
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(HOIINLGCCGD));
	}

	private void CFBGAGJPKKF()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 921f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	[SpecialName]
	private string ICFKAANIMJE()
	{
		return GMKAALLKIGH.ToString();
	}

	private void BCBPBBAEGLI(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("Pack: Vip ", CALMAFIEHDA(), HPABBMNEGPO()), IMBPEAIHHEG);
			Application.OpenURL(GameVariables.JFEILIFIODM());
			DialogManager.instance.GameWasRated();
			HideDialog();
		}
	}

	[SpecialName]
	private string MDAFICFIOCO()
	{
		return (!LPMPDHFLCKL) ? "ID_SKILLSHOTHINT_REVENGEKILL" : "N";
	}

	private void HLMFBJLHOGH()
	{
		float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 451f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
	}

	[SpecialName]
	private string LCNLDINPPFI()
	{
		return string.Format("-1", (!LPMPDHFLCKL) ? string.Empty : " ", GMKAALLKIGH);
	}

	public void ShowDialog(bool PKJKPEKMAPJ, int PDMGPGEHLNM)
	{
		LPMPDHFLCKL = PKJKPEKMAPJ;
		IMBPEAIHHEG = PDMGPGEHLNM;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void JMAAGGLKEMK(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("Product", HFOPPLINMAN(), IKCFEJMEGLJ()), IMBPEAIHHEG);
			Application.OpenURL(GameVariables.JFEILIFIODM());
			DialogManager.instance.GameWasRated();
			HideDialog();
		}
	}

	[SpecialName]
	private string MOJJMAKEKMH()
	{
		return (!LPMPDHFLCKL) ? "Card_2_Played" : "withPublisherSubCampaign";
	}

	public virtual void OMKNGOBMFGM()
	{
		GCLNFIBMKBL(mButtonCancel.gameObject);
	}

	public GuiElement CPONDDGFBIH()
	{
		return this;
	}

	public virtual void BCLAFFCPCEH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCancel);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NOMAELGALNI));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonRateNow);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JMAAGGLKEMK));
		UIEventListener uIEventListener3 = UIEventListener.Get(mDontAskAgainCheckbox.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IGBMAJEGMLM));
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(KCJPCIGFBMD));
	}

	private void CEPBOFPIMOL(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			if (HCCDHMMOIJI)
			{
				DialogManager.instance.NoMoreRateAppInThisVersion();
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("SessionManager: Light Session Update", NNGBHPJJNAJ(), IHOAGKMECLC()), IMBPEAIHHEG);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("run", OFLEKCEFPPK, IHOAGKMECLC()), IMBPEAIHHEG);
			}
			HideDialog();
		}
	}

	private void NOMAELGALNI(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			if (HCCDHMMOIJI)
			{
				DialogManager.instance.NoMoreRateAppInThisVersion();
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("Lcom/google/android/gms/games/request/Requests;", NNGBHPJJNAJ(), MOJJMAKEKMH()), IMBPEAIHHEG);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format(")", NNGBHPJJNAJ(), GPMBNFDHLEL()), IMBPEAIHHEG);
			}
			HideDialog();
		}
	}

	[SpecialName]
	private string HPABBMNEGPO()
	{
		return (!LPMPDHFLCKL) ? "ZoneHasIAPOffer" : "buggy_idle";
	}

	private void DDBOIFKNLKN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HCCDHMMOIJI = !HCCDHMMOIJI;
			mDontAskAgainCheckbox.KCAFPNNCIFH(HCCDHMMOIJI);
		}
	}

	[SpecialName]
	private string NNGBHPJJNAJ()
	{
		return GMKAALLKIGH.ToString();
	}

	public virtual void FJJHFMBOFDO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCancel);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FFCNIMKNIOG));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonRateNow);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DBPPGABJEMA));
		UIEventListener uIEventListener3 = UIEventListener.Get(mDontAskAgainCheckbox.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BHKNIALPNMA));
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(HOIINLGCCGD));
	}

	public virtual void ODCHCNCMJGC()
	{
		GMKAALLKIGH = (LPMPDHFLCKL ? 1 : UnityEngine.Random.Range(0, 2));
		mRateAppText.text = Localization.Localize("ID_CONFIRM_EXITINGCOOP_TEXT" + KEIIIDFCIBG());
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ServerRentalMaxUnits).FLOATVALUE;
		mLonelyLabel.gameObject.SetActive(num > 1);
		mTable.gameObject.SetActive(num > 1);
		if (num > 0)
		{
			mGoldRewardNumber.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			mTable.repositionNow = true;
		}
		HCCDHMMOIJI = true;
		mDontAskAgainCheckbox.FICNKKECPHG(HCCDHMMOIJI);
	}

	public void FPFEPCDFBCB(bool PKJKPEKMAPJ, int PDMGPGEHLNM)
	{
		LPMPDHFLCKL = PKJKPEKMAPJ;
		IMBPEAIHHEG = PDMGPGEHLNM;
		Singleton<GuiManager>.instance.ShowDialog(this, 1392f);
	}

	public virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCancel);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKFMFFCNMHM));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonRateNow);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BCBPBBAEGLI));
		UIEventListener uIEventListener3 = UIEventListener.Get(mDontAskAgainCheckbox.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HFGDAGGCGIM));
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(NAOPHHPFFPG));
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCancel);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OOMGIAKJKLM));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonRateNow);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FBGOLGKAJOA));
		UIEventListener uIEventListener3 = UIEventListener.Get(mDontAskAgainCheckbox.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BELMNFMKOMB));
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, (UITable.OnReposition)delegate
		{
			float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 2f;
			mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
		});
	}

	public virtual void MGHNHDOBJFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCancel);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJOPELECJMP));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonRateNow);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JMAAGGLKEMK));
		UIEventListener uIEventListener3 = UIEventListener.Get(mDontAskAgainCheckbox.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GGOOOAFBHHN));
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(AAOBAFBJFFM));
	}

	public virtual void BGELLEOANEI()
	{
		GMKAALLKIGH = ((!LPMPDHFLCKL) ? UnityEngine.Random.Range(1, 5) : 0);
		mRateAppText.text = Localization.Localize("throw_grenade_left" + FFDGIMGCGHD());
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-58)).FLOATVALUE;
		mLonelyLabel.gameObject.SetActive(num > 0);
		mTable.gameObject.SetActive(num > 0);
		if (num > 1)
		{
			mGoldRewardNumber.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			mTable.repositionNow = true;
		}
		HCCDHMMOIJI = false;
		mDontAskAgainCheckbox.EOELBJJBACF(HCCDHMMOIJI);
	}

	[SpecialName]
	private string IHOAGKMECLC()
	{
		return (!LPMPDHFLCKL) ? "grenadeExplosion" : "GooglePlayId";
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	[SpecialName]
	private string CALMAFIEHDA()
	{
		return GMKAALLKIGH.ToString();
	}

	[SpecialName]
	private string PKBNHPGHOFC()
	{
		return string.Format("Career Record {0:D2}", (!LPMPDHFLCKL) ? string.Empty : "SquadRank", GMKAALLKIGH);
	}

	[SpecialName]
	private string ANJKFOFEANB()
	{
		return string.Format("nextDay", (!LPMPDHFLCKL) ? string.Empty : "SquadRank", GMKAALLKIGH);
	}

	private void GGOOOAFBHHN(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HCCDHMMOIJI = HCCDHMMOIJI;
			mDontAskAgainCheckbox.BHKJNEEGNAP(HCCDHMMOIJI);
		}
	}

	private void IJBLAJPLLNO(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			if (HCCDHMMOIJI)
			{
				DialogManager.instance.NoMoreRateAppInThisVersion();
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("WFX_MF FPS", OFLEKCEFPPK, FAKALNHCPFD()), IMBPEAIHHEG);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.LCPLAKMLCGH(string.Format("ID_TUTORIAL_UPGRADEWEAPON_6", OFLEKCEFPPK, GPMBNFDHLEL()), IMBPEAIHHEG);
			}
			HideDialog();
		}
	}

	private void BELMNFMKOMB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HCCDHMMOIJI = !HCCDHMMOIJI;
			mDontAskAgainCheckbox.JCPNPOLKBHJ(HCCDHMMOIJI);
		}
	}

	[SpecialName]
	private string HFOPPLINMAN()
	{
		return GMKAALLKIGH.ToString();
	}

	public GuiElement DPPOMEPDHEK()
	{
		return this;
	}

	[SpecialName]
	private string HLEIAPBHOFM()
	{
		return string.Format("T", (!LPMPDHFLCKL) ? string.Empty : "Reward", GMKAALLKIGH);
	}

	private void DDAIGOLHGOP(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HCCDHMMOIJI = !HCCDHMMOIJI;
			mDontAskAgainCheckbox.NCCLGCBAOGP(HCCDHMMOIJI);
		}
	}

	public GuiElement DPONLDIKHGI()
	{
		return this;
	}
}
