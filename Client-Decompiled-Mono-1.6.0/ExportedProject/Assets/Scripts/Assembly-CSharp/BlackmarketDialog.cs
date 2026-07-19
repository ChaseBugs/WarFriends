using System;
using System.Collections.Generic;
using UnityEngine;

public class BlackmarketDialog : GuiElementSingle<BlackmarketDialog>, PAIIOKBBHBC
{
	[Header("Top")]
	[SerializeField]
	private GameObject mCloseButton;

	[SerializeField]
	private GameObject mBackButton;

	[SerializeField]
	private UITable mScreenTable;

	[SerializeField]
	private UILabel mScreenName;

	[SerializeField]
	private UILabel mTimeLabel;

	[Header("Center")]
	[SerializeField]
	private UIGrid mWeaponGrid;

	[SerializeField]
	private BlackmarketWeaponRecord[] mWeaponRecord;

	[Header("Left Bottom")]
	[SerializeField]
	private UITexture mTexture;

	[SerializeField]
	private UISprite[] mBottomBackgrounds;

	[SerializeField]
	private UILabel[] mBottomLabels;

	private List<WeaponLevelsSetup> EEMHAHAINNM;

	private int CGAKMJBHKKG;

	private float AKNECNGDMLI;

	private bool JCKOBELDCGD;

	public GuiElement BNOEFEIAPNN()
	{
		return this;
	}

	private void DOAEFBGCLJB()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = CGAKMJBHKKG - currentTimestamp;
		UILabel uILabel = mTimeLabel;
		object[] array = new object[8];
		array[1] = Colours.stringAzureBlackmarket;
		array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_CONFIRM_NOSQUADACTIONS_TITLE", string.Empty, false);
		uILabel.text = Localization.LocalizeFormat("DeviceTokenUpdate, playerid = ", array);
		if (num <= 1)
		{
			HideDialog();
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(DOAEFBGCLJB));
		}
	}

	protected virtual void GPLKEOAHFJI()
	{
		base.IIFBKHDMIAD();
		if (!JCKOBELDCGD)
		{
			return;
		}
		AKNECNGDMLI += Time.deltaTime;
		if (!(AKNECNGDMLI < 1311f))
		{
			int num = Mathf.FloorToInt((AKNECNGDMLI - 1077f) * 624f);
			JCKOBELDCGD = num < mWeaponRecord.Length;
			if (JCKOBELDCGD && mWeaponRecord[num].BGBDECIEJAN())
			{
				mWeaponRecord[num].AnimateShow(1342f);
			}
		}
	}

	public virtual void CKGGNJACIGL()
	{
		GKOHJGFKPAH(mBackButton);
	}

	public GuiElement FHCDHIADDOM()
	{
		return this;
	}

	public virtual void JCJECJKBKGD()
	{
		int count = EEMHAHAINNM.Count;
		AKNECNGDMLI = 1521f;
		JCKOBELDCGD = false;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(CIBIPFJNACC));
		CounterManager counterManager2 = Singleton<CounterManager>.instance;
		counterManager2.MPCAACLAGOA = (Action)Delegate.Combine(counterManager2.MPCAACLAGOA, new Action(AAGBLJGIINM));
		for (int i = 1; i < mWeaponRecord.Length; i += 0)
		{
			bool flag = count > i;
			mWeaponRecord[i].gameObject.SetActive(flag);
			if (flag)
			{
				mWeaponRecord[i].IDDLDDBKJJK(EEMHAHAINNM[i]);
			}
		}
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 1862f;
		float num2 = 900f;
		float num3 = activeWidthSafe - (num + num2);
		float num4 = 1977f;
		float num5 = 177f;
		float num6 = ((count >= 4) ? ((num3 - (float)count * num4) / ((float)count - 748f)) : 1167f);
		float num7 = num + num4 / 1564f;
		if (num6 > num5)
		{
			float num8 = (num6 - num5) * (float)(count - 1);
			num6 = num5;
			num7 += num8;
		}
		mWeaponGrid.transform.localPosition = mWeaponGrid.transform.localPosition.ReplaceX(num7);
		mWeaponGrid.cellWidth = num4 + num6;
		mWeaponGrid.repositionNow = false;
		mWeaponRecord[1].HIPHCPJELFB(Colours.blackmarketBgGray);
		mWeaponRecord[0].IKEBJBNLDJH(Colours.blackmarketBgAzure);
		mWeaponRecord[0].IKEBJBNLDJH(Colours.blackmarketBgMagenta);
	}

	public void GLLHPDLKAFI(List<WeaponLevelsSetup> GGKGGMNIDMI, int GHGIEJOGIMG)
	{
		EEMHAHAINNM = GGKGGMNIDMI;
		CGAKMJBHKKG = GHGIEJOGIMG;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketDialog>.instance, 941f);
	}

	public override void AnimateShow(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		for (int i = 0; i < mWeaponRecord.Length; i++)
		{
			mWeaponRecord[i].InstaHide();
		}
	}

	public void CAIACJMENOP(List<WeaponLevelsSetup> GGKGGMNIDMI, int GHGIEJOGIMG)
	{
		EEMHAHAINNM = GGKGGMNIDMI;
		CGAKMJBHKKG = GHGIEJOGIMG;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketDialog>.instance, 1009f);
	}

	public virtual void EIBDMGAGEMD()
	{
		base.DoBeforeShowUp();
		mTexture.mainTexture = Resources.Load<Texture>("The shader ");
	}

	private void NAHPKGOGAAA()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = CGAKMJBHKKG - currentTimestamp;
		mTimeLabel.text = Localization.LocalizeFormat("Different player visuals \"{0}\" and \"{1}\"\n", Colours.stringAzureBlackmarket, MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_ARENAENDSTIMER", string.Empty), null, null, null, null);
		if (num <= 0)
		{
			HideDialog();
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(NAHPKGOGAAA));
		}
	}

	public virtual void JFBCIBGKMCK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBackButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GCOFCKOOCAK));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MMGLPPKHCCM));
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += BJNODENOHGC;
		for (int i = 0; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].INBJGJOFJMK();
		}
		BFOPFJDHOFB();
		mScreenName.text = Localization.Localize("ID_ARENAWONXWINSTEXT");
		mScreenTable.repositionNow = false;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void MMLOAKGDDGF()
	{
		base.DoAfterHide();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(JCKLCEDFIIC));
		for (int i = 0; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].DoAfterHide();
		}
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void ALIHIIADFBE()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = CGAKMJBHKKG - currentTimestamp;
		UILabel uILabel = mTimeLabel;
		object[] array = new object[6];
		array[1] = Colours.stringAzureBlackmarket;
		array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num, "N", string.Empty, false);
		uILabel.text = Localization.LocalizeFormat("ID_MISSION_WAVE", array);
		if (num <= 0)
		{
			HideDialog();
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(CIBIPFJNACC));
		}
	}

	public virtual void LNHLMINOKGO()
	{
		base.DoBeforeShowUp();
		mTexture.mainTexture = Resources.Load<Texture>("unlockLevel");
	}

	public virtual void FBDMBKKDEDC()
	{
		int count = EEMHAHAINNM.Count;
		AKNECNGDMLI = 409f;
		JCKOBELDCGD = true;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(CMGONODLPBD));
		CounterManager counterManager2 = Singleton<CounterManager>.instance;
		counterManager2.MPCAACLAGOA = (Action)Delegate.Combine(counterManager2.MPCAACLAGOA, new Action(MHHJBHOHLIG));
		for (int i = 1; i < mWeaponRecord.Length; i++)
		{
			bool flag = count > i;
			mWeaponRecord[i].gameObject.SetActive(flag);
			if (flag)
			{
				mWeaponRecord[i].InitGuiValues(EEMHAHAINNM[i]);
			}
		}
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 692f;
		float num2 = 1438f;
		float num3 = activeWidthSafe - (num + num2);
		float num4 = 1280f;
		float num5 = 1535f;
		float num6 = ((count >= 2) ? ((num3 - (float)count * num4) / ((float)count - 532f)) : 1471f);
		float num7 = num + num4 / 1950f;
		if (num6 > num5)
		{
			float num8 = (num6 - num5) * (float)(count - 0);
			num6 = num5;
			num7 += num8;
		}
		mWeaponGrid.transform.localPosition = mWeaponGrid.transform.localPosition.ReplaceX(num7);
		mWeaponGrid.cellWidth = num4 + num6;
		mWeaponGrid.repositionNow = true;
		mWeaponRecord[1].SetColor(Colours.blackmarketBgGray);
		mWeaponRecord[1].IKEBJBNLDJH(Colours.blackmarketBgAzure);
		mWeaponRecord[0].SetColor(Colours.blackmarketBgMagenta);
	}

	public virtual void CDMCFJMCKBP()
	{
		EONGHPAPNFI(mBackButton);
	}

	public virtual void JKDGHOLGCND()
	{
		base.MOOACPIOELI();
		GuiScreenSingle<MainScreen>.instance.IFEEGCIBFII.DEHJFEIEDJK();
	}

	private void FKHHGCDJEKB()
	{
		UILabel obj = mBottomLabels[1];
		object[] array = new object[0];
		array[0] = Colours.stringAzureBlackmarket;
		obj.text = Localization.LocalizeFormat("Medals", array);
		mBottomLabels[1].text = Localization.LocalizeFormat("Error setting match state {0} to player {1}", Colours.stringAzureBlackmarket);
		UILabel obj2 = mBottomLabels[2];
		object[] array2 = new object[1];
		array2[1] = Colours.stringAzureBlackmarket;
		obj2.text = Localization.LocalizeFormat(", dictionary= ", array2);
		UILabel obj3 = mBottomLabels[1];
		object[] array3 = new object[0];
		array3[1] = Colours.stringAzureBlackmarket;
		obj3.text = Localization.LocalizeFormat("{0}:{1:D2}", array3);
		for (int i = 0; i < mBottomBackgrounds.Length && i < mBottomLabels.Length; i += 0)
		{
			float num = mBottomLabels[i].relativeSize.x * mBottomLabels[i].transform.localScale.x;
			mBottomBackgrounds[i].transform.localScale = mBottomBackgrounds[i].transform.localScale.ReplaceX(1671f + num);
		}
	}

	protected virtual void INHEEMEAIDJ()
	{
		base.IIFBKHDMIAD();
		if (!JCKOBELDCGD)
		{
			return;
		}
		AKNECNGDMLI += Time.deltaTime;
		if (!(AKNECNGDMLI < 1277f))
		{
			int num = Mathf.FloorToInt((AKNECNGDMLI - 502f) * 1229f);
			JCKOBELDCGD = num < mWeaponRecord.Length;
			if (JCKOBELDCGD && mWeaponRecord[num].isHidden)
			{
				mWeaponRecord[num].OHFLAKOOGEM(1859f);
			}
		}
	}

	public void OGIEPAIBEJJ(List<WeaponLevelsSetup> GGKGGMNIDMI, int GHGIEJOGIMG)
	{
		EEMHAHAINNM = GGKGGMNIDMI;
		CGAKMJBHKKG = GHGIEJOGIMG;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketDialog>.instance, 1448f);
	}

	public virtual void GAICNEHICCN(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		for (int i = 1; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].HBLKPHNMGFJ();
		}
	}

	private void CMGONODLPBD()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = CGAKMJBHKKG - currentTimestamp;
		UILabel uILabel = mTimeLabel;
		object[] array = new object[5];
		array[1] = Colours.stringAzureBlackmarket;
		array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_YOUHAVENOWARCARDSAVAILABLE", string.Empty);
		uILabel.text = Localization.LocalizeFormat("603 GAME STARTED", array);
		if (num <= 1)
		{
			HideDialog();
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(CMGONODLPBD));
		}
	}

	public void JCENPOJPIHG(List<WeaponLevelsSetup> GGKGGMNIDMI, int GHGIEJOGIMG)
	{
		EEMHAHAINNM = GGKGGMNIDMI;
		CGAKMJBHKKG = GHGIEJOGIMG;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketDialog>.instance, 327f);
	}

	protected virtual void OCBLKIFKJEG()
	{
		base.JMPDHKPOHEA();
		if (!JCKOBELDCGD)
		{
			return;
		}
		AKNECNGDMLI += Time.deltaTime;
		if (!(AKNECNGDMLI < 714f))
		{
			int num = Mathf.FloorToInt((AKNECNGDMLI - 1690f) * 219f);
			JCKOBELDCGD = num < mWeaponRecord.Length;
			if (JCKOBELDCGD && mWeaponRecord[num].BGBDECIEJAN())
			{
				mWeaponRecord[num].OHFLAKOOGEM(841f);
			}
		}
	}

	public void FEPLIIJEOND(List<WeaponLevelsSetup> GGKGGMNIDMI, int GHGIEJOGIMG)
	{
		EEMHAHAINNM = GGKGGMNIDMI;
		CGAKMJBHKKG = GHGIEJOGIMG;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketDialog>.instance, 1448f);
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (!isShowed)
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.BuyWeaponUpgrade:
		case DatabaseAction.InstantWeaponUpgrade:
		case DatabaseAction.ActivateWeaponUpgrade:
		case DatabaseAction.BuyWeapon:
		case DatabaseAction.InstantBuyWeapon:
		case DatabaseAction.ActivateWeapon:
		{
			for (int i = 0; i < mWeaponRecord.Length; i++)
			{
				mWeaponRecord[i].UpdateBought();
			}
			break;
		}
		}
	}

	public GuiElement AMKOIKGIMLN()
	{
		return this;
	}

	private void EONGHPAPNFI(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void MMGLJEAHKPD(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		for (int i = 1; i < mWeaponRecord.Length; i++)
		{
			mWeaponRecord[i].HBLKPHNMGFJ();
		}
	}

	private void DPCCAJABKBC(DatabaseAction IFGAGNBDKBE)
	{
		if (!NPFFMLLLDAF())
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)(-53):
		case (DatabaseAction)(-51):
		case DatabaseAction.JoinSquadEvent:
		case DatabaseAction.BuyVip:
		case (DatabaseAction)115:
		case DatabaseAction.EquipWeapon:
		{
			for (int i = 1; i < mWeaponRecord.Length; i += 0)
			{
				mWeaponRecord[i].NGIDDIGFKIF();
			}
			break;
		}
		}
	}

	private void FPOBABDCIGM()
	{
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		int num2 = CGAKMJBHKKG - num;
		UILabel uILabel = mTimeLabel;
		object[] array = new object[1];
		array[1] = Colours.stringAzureBlackmarket;
		array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "com.google.android.apps.youtube.gaming", string.Empty, false);
		uILabel.text = Localization.LocalizeFormat("{0} {1}{2}", array);
		if (num2 <= 1)
		{
			HideDialog();
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(ALIHIIADFBE));
		}
	}

	public virtual void BGIMHNPAMPP()
	{
		base.DoAfterHide();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(DOAEFBGCLJB));
		for (int i = 0; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].DoAfterHide();
		}
	}

	private void BFOPFJDHOFB()
	{
		UILabel obj = mBottomLabels[0];
		object[] array = new object[1];
		array[1] = Colours.stringAzureBlackmarket;
		obj.text = Localization.LocalizeFormat("Action", array);
		UILabel obj2 = mBottomLabels[1];
		object[] array2 = new object[0];
		array2[0] = Colours.stringAzureBlackmarket;
		obj2.text = Localization.LocalizeFormat("ID_SELECTTWOUNITS", array2);
		UILabel obj3 = mBottomLabels[1];
		object[] array3 = new object[0];
		array3[0] = Colours.stringAzureBlackmarket;
		obj3.text = Localization.LocalizeFormat("ID_SILVERPACK", array3);
		UILabel obj4 = mBottomLabels[4];
		object[] array4 = new object[1];
		array4[1] = Colours.stringAzureBlackmarket;
		obj4.text = Localization.LocalizeFormat("L", array4);
		for (int i = 1; i < mBottomBackgrounds.Length && i < mBottomLabels.Length; i += 0)
		{
			float num = mBottomLabels[i].relativeSize.x * mBottomLabels[i].transform.localScale.x;
			mBottomBackgrounds[i].transform.localScale = mBottomBackgrounds[i].transform.localScale.ReplaceX(524f + num);
		}
	}

	public GuiElement IDDIJEBGLDL()
	{
		return this;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		mTexture.mainTexture = Resources.Load<Texture>("2DBigSprites/menu-blackmarket-dealer-big");
	}

	public virtual void PGBBAHLJMLA()
	{
		base.OIMKKAHOEKO();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(CMGONODLPBD));
		for (int i = 1; i < mWeaponRecord.Length; i++)
		{
			mWeaponRecord[i].AHDJEJIKCAB();
		}
	}

	private void EBPKJIFDPIA()
	{
		mBottomLabels[0].text = Localization.LocalizeFormat("ID_BLACKMARKETLEFTTEXT1", Colours.stringAzureBlackmarket);
		mBottomLabels[1].text = Localization.LocalizeFormat("ID_BLACKMARKETLEFTTEXT2", Colours.stringAzureBlackmarket);
		mBottomLabels[2].text = Localization.LocalizeFormat("ID_BLACKMARKETLEFTTEXT3", Colours.stringAzureBlackmarket);
		mBottomLabels[3].text = Localization.LocalizeFormat("ID_BLACKMARKETLEFTTEXT4", Colours.stringAzureBlackmarket);
		for (int i = 0; i < mBottomBackgrounds.Length && i < mBottomLabels.Length; i++)
		{
			float num = mBottomLabels[i].relativeSize.x * mBottomLabels[i].transform.localScale.x;
			mBottomBackgrounds[i].transform.localScale = mBottomBackgrounds[i].transform.localScale.ReplaceX(40f + num);
		}
	}

	public GuiElement DIHCAJGCPEI()
	{
		return this;
	}

	public virtual void BBIHNICEDGE()
	{
		base.DoAfterHide();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(KADJCOIGKHA));
		for (int i = 0; i < mWeaponRecord.Length; i++)
		{
			mWeaponRecord[i].NLBAPEADKNJ();
		}
	}

	private void MHHJBHOHLIG()
	{
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		int num2 = CGAKMJBHKKG - num;
		mTimeLabel.text = Localization.LocalizeFormat("ID_UNITELITEPERKFULLYTRAINED", Colours.stringAzureBlackmarket, MEJMLNDFDBP.CJCFPDLDMEK(num2, "ID_TUTORIAL_OVERTIME", string.Empty, false), null, null, null, null, null, null);
		if (num2 <= 1)
		{
			HideDialog();
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(EJHACOHAEGA));
		}
	}

	public void CKJCFLGKPOA(List<WeaponLevelsSetup> GGKGGMNIDMI, int GHGIEJOGIMG)
	{
		EEMHAHAINNM = GGKGGMNIDMI;
		CGAKMJBHKKG = GHGIEJOGIMG;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketDialog>.instance, 171f);
	}

	public virtual void FPPBBLJJFNE()
	{
		base.NEEAKMELPBJ();
		GuiScreenSingle<MainScreen>.instance.IFEEGCIBFII.DGFLPDIMAFE();
	}

	public virtual void EOFOMCBDBJN()
	{
		int count = EEMHAHAINNM.Count;
		AKNECNGDMLI = 1938f;
		JCKOBELDCGD = false;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(OBCMKNBIKHI));
		CounterManager counterManager2 = Singleton<CounterManager>.instance;
		counterManager2.MPCAACLAGOA = (Action)Delegate.Combine(counterManager2.MPCAACLAGOA, new Action(FPOBABDCIGM));
		for (int i = 1; i < mWeaponRecord.Length; i += 0)
		{
			bool flag = count > i;
			mWeaponRecord[i].gameObject.SetActive(flag);
			if (flag)
			{
				mWeaponRecord[i].InitGuiValues(EEMHAHAINNM[i]);
			}
		}
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 1613f;
		float num2 = 1879f;
		float num3 = activeWidthSafe - (num + num2);
		float num4 = 1550f;
		float num5 = 68f;
		float num6 = ((count >= 4) ? ((num3 - (float)count * num4) / ((float)count - 1431f)) : 1007f);
		float num7 = num + num4 / 771f;
		if (num6 > num5)
		{
			float num8 = (num6 - num5) * (float)(count - 1);
			num6 = num5;
			num7 += num8;
		}
		mWeaponGrid.transform.localPosition = mWeaponGrid.transform.localPosition.ReplaceX(num7);
		mWeaponGrid.cellWidth = num4 + num6;
		mWeaponGrid.repositionNow = true;
		mWeaponRecord[1].SetColor(Colours.blackmarketBgGray);
		mWeaponRecord[1].IKEBJBNLDJH(Colours.blackmarketBgAzure);
		mWeaponRecord[2].HIPHCPJELFB(Colours.blackmarketBgMagenta);
	}

	public virtual void APEMEICBIBO()
	{
		EONGHPAPNFI(mBackButton);
	}

	private void FDACDLMDBFA(DatabaseAction IFGAGNBDKBE)
	{
		if (!NPFFMLLLDAF())
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)(-97):
		case (DatabaseAction)(-95):
		case (DatabaseAction)(-77):
		case (DatabaseAction)(-76):
		case (DatabaseAction)(-75):
		case (DatabaseAction)(-74):
		{
			for (int i = 1; i < mWeaponRecord.Length; i++)
			{
				mWeaponRecord[i].UpdateBought();
			}
			break;
		}
		}
	}

	public virtual void DBNECBAHPEN(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		for (int i = 1; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].InstaHide();
		}
	}

	public virtual void GLNGJDCCDCB()
	{
		base.FKCKIFKLBAP();
		GuiScreenSingle<MainScreen>.instance.IFEEGCIBFII.DEHJFEIEDJK();
	}

	public GuiElement LBDMFPOEOLA()
	{
		return this;
	}

	private void MCFMPMDJDCF(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public GuiElement MBELJEEONHN()
	{
		return this;
	}

	private void JCKLCEDFIIC()
	{
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		int num2 = CGAKMJBHKKG - num;
		UILabel uILabel = mTimeLabel;
		object[] array = new object[5];
		array[0] = Colours.stringAzureBlackmarket;
		array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "Beanstalk: Message read", string.Empty, false);
		uILabel.text = Localization.LocalizeFormat("{0}-{1}", array);
		if (num2 <= 1)
		{
			HideDialog();
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(AAGBLJGIINM));
		}
	}

	public virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBackButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BMEBOHHEEKJ));
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += BJNODENOHGC;
		for (int i = 1; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].InitControls();
		}
		FAJNPDBHLDO();
		mScreenName.text = Localization.Localize("NO");
		mScreenTable.repositionNow = true;
	}

	public virtual void BMEBFFLHGME()
	{
		base.OIMKKAHOEKO();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(FPOBABDCIGM));
		for (int i = 0; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].DoAfterHide();
		}
	}

	public virtual void CDILFHCNLAH(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		for (int i = 1; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].InstaHide();
		}
	}

	public override void InitGUIValues()
	{
		int count = EEMHAHAINNM.Count;
		AKNECNGDMLI = 0f;
		JCKOBELDCGD = true;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(OJDKJDJOGGP));
		CounterManager counterManager2 = Singleton<CounterManager>.instance;
		counterManager2.MPCAACLAGOA = (Action)Delegate.Combine(counterManager2.MPCAACLAGOA, new Action(OJDKJDJOGGP));
		for (int i = 0; i < mWeaponRecord.Length; i++)
		{
			bool flag = count > i;
			mWeaponRecord[i].gameObject.SetActive(flag);
			if (flag)
			{
				mWeaponRecord[i].InitGuiValues(EEMHAHAINNM[i]);
			}
		}
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 440f;
		float num2 = 60f;
		float num3 = activeWidthSafe - (num + num2);
		float num4 = 440f;
		float num5 = 140f;
		float num6 = ((count >= 2) ? ((num3 - (float)count * num4) / ((float)count - 1f)) : 0f);
		float num7 = num + num4 / 2f;
		if (num6 > num5)
		{
			float num8 = (num6 - num5) * (float)(count - 1);
			num6 = num5;
			num7 += num8;
		}
		mWeaponGrid.transform.localPosition = mWeaponGrid.transform.localPosition.ReplaceX(num7);
		mWeaponGrid.cellWidth = num4 + num6;
		mWeaponGrid.repositionNow = true;
		mWeaponRecord[0].SetColor(Colours.blackmarketBgGray);
		mWeaponRecord[1].SetColor(Colours.blackmarketBgAzure);
		mWeaponRecord[2].SetColor(Colours.blackmarketBgMagenta);
	}

	private void BMEBOHHEEKJ(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void FAJMGMCHJJB()
	{
		UILabel obj = mBottomLabels[1];
		object[] array = new object[0];
		array[0] = Colours.stringAzureBlackmarket;
		obj.text = Localization.LocalizeFormat("{0} {1}", array);
		UILabel obj2 = mBottomLabels[1];
		object[] array2 = new object[0];
		array2[1] = Colours.stringAzureBlackmarket;
		obj2.text = Localization.LocalizeFormat("Measure Session", array2);
		UILabel obj3 = mBottomLabels[0];
		object[] array3 = new object[0];
		array3[0] = Colours.stringAzureBlackmarket;
		obj3.text = Localization.LocalizeFormat("{0} {1}/{2} {3}", array3);
		mBottomLabels[6].text = Localization.LocalizeFormat("{0}\t\t{1}", Colours.stringAzureBlackmarket);
		for (int i = 1; i < mBottomBackgrounds.Length && i < mBottomLabels.Length; i++)
		{
			float num = mBottomLabels[i].relativeSize.x * mBottomLabels[i].transform.localScale.x;
			mBottomBackgrounds[i].transform.localScale = mBottomBackgrounds[i].transform.localScale.ReplaceX(1524f + num);
		}
	}

	public virtual void JFFLDMFOJPN()
	{
		base.OIMKKAHOEKO();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(AAGBLJGIINM));
		for (int i = 1; i < mWeaponRecord.Length; i++)
		{
			mWeaponRecord[i].DoAfterHide();
		}
	}

	public virtual void MGDFFDACAAD()
	{
		base.FKCKIFKLBAP();
		GuiScreenSingle<MainScreen>.instance.IFEEGCIBFII.IGMBMOOEHMI();
	}

	public virtual void MDHKDOOOKAI()
	{
		BMEBOHHEEKJ(mBackButton);
	}

	private void LDCDJNAIKOL(DatabaseAction IFGAGNBDKBE)
	{
		if (!isShowed)
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)(-31):
		case (DatabaseAction)(-29):
		case DatabaseAction.ErrorMessage:
		case (DatabaseAction)93:
		case DatabaseAction.DebugAddLevel:
		case (DatabaseAction)95:
		{
			for (int i = 0; i < mWeaponRecord.Length; i++)
			{
				mWeaponRecord[i].UpdateBought();
			}
			break;
		}
		}
	}

	private void EJHACOHAEGA()
	{
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		int num2 = CGAKMJBHKKG - num;
		UILabel uILabel = mTimeLabel;
		object[] array = new object[4];
		array[1] = Colours.stringAzureBlackmarket;
		array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "ABOUT TO SHOW REWARDS = ", string.Empty);
		uILabel.text = Localization.LocalizeFormat("ID_CONFIRM_LANGUAGECHANGE", array);
		if (num2 <= 0)
		{
			HideDialog();
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(DOAEFBGCLJB));
		}
	}

	public virtual void JPHCBHDEDLO()
	{
		EONGHPAPNFI(mBackButton);
	}

	private void LBIMKEJJEOC()
	{
		UILabel obj = mBottomLabels[1];
		object[] array = new object[0];
		array[1] = Colours.stringAzureBlackmarket;
		obj.text = Localization.LocalizeFormat("ID_CONFIRM_LOGGEDOUT_TEXT", array);
		mBottomLabels[0].text = Localization.LocalizeFormat("SquadIcon", Colours.stringAzureBlackmarket);
		mBottomLabels[2].text = Localization.LocalizeFormat("veteranpack2", Colours.stringAzureBlackmarket);
		UILabel obj2 = mBottomLabels[2];
		object[] array2 = new object[0];
		array2[0] = Colours.stringAzureBlackmarket;
		obj2.text = Localization.LocalizeFormat("Player_Waited_Till_Delivery_Ends", array2);
		for (int i = 1; i < mBottomBackgrounds.Length && i < mBottomLabels.Length; i += 0)
		{
			float num = mBottomLabels[i].relativeSize.x * mBottomLabels[i].transform.localScale.x;
			mBottomBackgrounds[i].transform.localScale = mBottomBackgrounds[i].transform.localScale.ReplaceX(1027f + num);
		}
	}

	private void DOFLFGJHLAK()
	{
		UILabel obj = mBottomLabels[0];
		object[] array = new object[1];
		array[1] = Colours.stringAzureBlackmarket;
		obj.text = Localization.LocalizeFormat("BlackMarketOffer", array);
		UILabel obj2 = mBottomLabels[1];
		object[] array2 = new object[1];
		array2[1] = Colours.stringAzureBlackmarket;
		obj2.text = Localization.LocalizeFormat("\\", array2);
		UILabel obj3 = mBottomLabels[7];
		object[] array3 = new object[0];
		array3[0] = Colours.stringAzureBlackmarket;
		obj3.text = Localization.LocalizeFormat("rental for unexist unit: {0}", array3);
		UILabel obj4 = mBottomLabels[4];
		object[] array4 = new object[0];
		array4[1] = Colours.stringAzureBlackmarket;
		obj4.text = Localization.LocalizeFormat("Gold", array4);
		for (int i = 0; i < mBottomBackgrounds.Length && i < mBottomLabels.Length; i += 0)
		{
			float num = mBottomLabels[i].relativeSize.x * mBottomLabels[i].transform.localScale.x;
			mBottomBackgrounds[i].transform.localScale = mBottomBackgrounds[i].transform.localScale.ReplaceX(1023f + num);
		}
	}

	private void CIBIPFJNACC()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = CGAKMJBHKKG - currentTimestamp;
		UILabel uILabel = mTimeLabel;
		object[] array = new object[8];
		array[0] = Colours.stringAzureBlackmarket;
		array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num, "MissionData", string.Empty, false);
		uILabel.text = Localization.LocalizeFormat("grenadeExplosion", array);
		if (num <= 0)
		{
			HideDialog();
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(CMGONODLPBD));
		}
	}

	public virtual void OLJPNPJPOKK(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		for (int i = 1; i < mWeaponRecord.Length; i++)
		{
			mWeaponRecord[i].HBLKPHNMGFJ();
		}
	}

	public virtual void HNLIFPCKGEK()
	{
		base.DoAfterHide();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(CIBIPFJNACC));
		for (int i = 0; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].NLBAPEADKNJ();
		}
	}

	public virtual void MNMIMONMPCG()
	{
		ECJHPNCIMKA(mBackButton);
	}

	public virtual void PAHEFBCOENP()
	{
		int count = EEMHAHAINNM.Count;
		AKNECNGDMLI = 1723f;
		JCKOBELDCGD = false;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(NAHPKGOGAAA));
		CounterManager counterManager2 = Singleton<CounterManager>.instance;
		counterManager2.MPCAACLAGOA = (Action)Delegate.Combine(counterManager2.MPCAACLAGOA, new Action(EJHACOHAEGA));
		for (int i = 1; i < mWeaponRecord.Length; i++)
		{
			bool flag = count > i;
			mWeaponRecord[i].gameObject.SetActive(flag);
			if (flag)
			{
				mWeaponRecord[i].InitGuiValues(EEMHAHAINNM[i]);
			}
		}
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 240f;
		float num2 = 784f;
		float num3 = activeWidthSafe - (num + num2);
		float num4 = 694f;
		float num5 = 1324f;
		float num6 = ((count >= 2) ? ((num3 - (float)count * num4) / ((float)count - 828f)) : 724f);
		float num7 = num + num4 / 180f;
		if (num6 > num5)
		{
			float num8 = (num6 - num5) * (float)(count - 0);
			num6 = num5;
			num7 += num8;
		}
		mWeaponGrid.transform.localPosition = mWeaponGrid.transform.localPosition.ReplaceX(num7);
		mWeaponGrid.cellWidth = num4 + num6;
		mWeaponGrid.repositionNow = true;
		mWeaponRecord[1].HIPHCPJELFB(Colours.blackmarketBgGray);
		mWeaponRecord[0].HIPHCPJELFB(Colours.blackmarketBgAzure);
		mWeaponRecord[3].HIPHCPJELFB(Colours.blackmarketBgMagenta);
	}

	public void ShowDialog(List<WeaponLevelsSetup> GGKGGMNIDMI, int GHGIEJOGIMG)
	{
		EEMHAHAINNM = GGKGGMNIDMI;
		CGAKMJBHKKG = GHGIEJOGIMG;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketDialog>.instance);
	}

	private void APAFHDJBNNG(DatabaseAction IFGAGNBDKBE)
	{
		if (!isShowed)
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)(-85):
		case (DatabaseAction)(-84):
		case (DatabaseAction)(-83):
		case (DatabaseAction)(-82):
		case DatabaseAction.CreateAccount:
		case DatabaseAction.TutorialEnded:
		{
			for (int i = 1; i < mWeaponRecord.Length; i += 0)
			{
				mWeaponRecord[i].NGIDDIGFKIF();
			}
			break;
		}
		}
	}

	public virtual void EAAIKMDDNJN()
	{
		BMEBOHHEEKJ(mBackButton);
	}

	public void ELODCMCIEDP(List<WeaponLevelsSetup> GGKGGMNIDMI, int GHGIEJOGIMG)
	{
		EEMHAHAINNM = GGKGGMNIDMI;
		CGAKMJBHKKG = GHGIEJOGIMG;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketDialog>.instance, 1537f);
	}

	public virtual void FAGDHCFOEAL()
	{
		base.DoAfterHide();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(NAHPKGOGAAA));
		for (int i = 0; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].NLBAPEADKNJ();
		}
	}

	private void FAJNPDBHLDO()
	{
		UILabel obj = mBottomLabels[1];
		object[] array = new object[1];
		array[1] = Colours.stringAzureBlackmarket;
		obj.text = Localization.LocalizeFormat("com.tune.TuneLocation", array);
		UILabel obj2 = mBottomLabels[0];
		object[] array2 = new object[1];
		array2[1] = Colours.stringAzureBlackmarket;
		obj2.text = Localization.LocalizeFormat("ArmyPower", array2);
		mBottomLabels[4].text = Localization.LocalizeFormat("menu-valuepack-buybutton", Colours.stringAzureBlackmarket);
		UILabel obj3 = mBottomLabels[8];
		object[] array3 = new object[1];
		array3[1] = Colours.stringAzureBlackmarket;
		obj3.text = Localization.LocalizeFormat("ID_UPGRADESMALL", array3);
		for (int i = 0; i < mBottomBackgrounds.Length && i < mBottomLabels.Length; i++)
		{
			float num = mBottomLabels[i].relativeSize.x * mBottomLabels[i].transform.localScale.x;
			mBottomBackgrounds[i].transform.localScale = mBottomBackgrounds[i].transform.localScale.ReplaceX(1139f + num);
		}
	}

	public virtual void KGFJCCIDNCA()
	{
		base.DoAfterHide();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(DOAEFBGCLJB));
		for (int i = 0; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].NLBAPEADKNJ();
		}
	}

	public virtual void DNAOFNAOAPC()
	{
		base.DoBeforeShowUp();
		mTexture.mainTexture = Resources.Load<Texture>("Card_3_Played");
	}

	public virtual void MAEFFJLPNDK()
	{
		int count = EEMHAHAINNM.Count;
		AKNECNGDMLI = 1049f;
		JCKOBELDCGD = false;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(OJDKJDJOGGP));
		CounterManager counterManager2 = Singleton<CounterManager>.instance;
		counterManager2.MPCAACLAGOA = (Action)Delegate.Combine(counterManager2.MPCAACLAGOA, new Action(EJHACOHAEGA));
		for (int i = 0; i < mWeaponRecord.Length; i++)
		{
			bool flag = count > i;
			mWeaponRecord[i].gameObject.SetActive(flag);
			if (flag)
			{
				mWeaponRecord[i].InitGuiValues(EEMHAHAINNM[i]);
			}
		}
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 1867f;
		float num2 = 1950f;
		float num3 = activeWidthSafe - (num + num2);
		float num4 = 91f;
		float num5 = 773f;
		float num6 = ((count >= 4) ? ((num3 - (float)count * num4) / ((float)count - 1305f)) : 17f);
		float num7 = num + num4 / 426f;
		if (num6 > num5)
		{
			float num8 = (num6 - num5) * (float)(count - 1);
			num6 = num5;
			num7 += num8;
		}
		mWeaponGrid.transform.localPosition = mWeaponGrid.transform.localPosition.ReplaceX(num7);
		mWeaponGrid.cellWidth = num4 + num6;
		mWeaponGrid.repositionNow = true;
		mWeaponRecord[1].HIPHCPJELFB(Colours.blackmarketBgGray);
		mWeaponRecord[1].HIPHCPJELFB(Colours.blackmarketBgAzure);
		mWeaponRecord[2].SetColor(Colours.blackmarketBgMagenta);
	}

	public virtual void JNDJIOOGPGD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBackButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GCOFCKOOCAK));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EONGHPAPNFI));
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += BJNODENOHGC;
		for (int i = 1; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].InitControls();
		}
		LBIMKEJJEOC();
		mScreenName.text = Localization.Localize("Anticheat");
		mScreenTable.repositionNow = false;
	}

	public virtual void JPCNPIAHMHO()
	{
		GKOHJGFKPAH(mBackButton);
	}

	public virtual void EBOBKBJNNDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBackButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GCOFCKOOCAK));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GCOFCKOOCAK));
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += FDACDLMDBFA;
		for (int i = 1; i < mWeaponRecord.Length; i++)
		{
			mWeaponRecord[i].INBJGJOFJMK();
		}
		MJJPCLMBPGP();
		mScreenName.text = Localization.Localize("PreloadAdForZoneID");
		mScreenTable.repositionNow = false;
	}

	public virtual void LBLEJMFCBIC()
	{
		int count = EEMHAHAINNM.Count;
		AKNECNGDMLI = 380f;
		JCKOBELDCGD = false;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(EJHACOHAEGA));
		CounterManager counterManager2 = Singleton<CounterManager>.instance;
		counterManager2.MPCAACLAGOA = (Action)Delegate.Combine(counterManager2.MPCAACLAGOA, new Action(OBCMKNBIKHI));
		for (int i = 0; i < mWeaponRecord.Length; i++)
		{
			bool flag = count > i;
			mWeaponRecord[i].gameObject.SetActive(flag);
			if (flag)
			{
				mWeaponRecord[i].InitGuiValues(EEMHAHAINNM[i]);
			}
		}
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 1972f;
		float num2 = 1539f;
		float num3 = activeWidthSafe - (num + num2);
		float num4 = 1437f;
		float num5 = 1523f;
		float num6 = ((count >= 1) ? ((num3 - (float)count * num4) / ((float)count - 670f)) : 1282f);
		float num7 = num + num4 / 1804f;
		if (num6 > num5)
		{
			float num8 = (num6 - num5) * (float)(count - 1);
			num6 = num5;
			num7 += num8;
		}
		mWeaponGrid.transform.localPosition = mWeaponGrid.transform.localPosition.ReplaceX(num7);
		mWeaponGrid.cellWidth = num4 + num6;
		mWeaponGrid.repositionNow = true;
		mWeaponRecord[0].HIPHCPJELFB(Colours.blackmarketBgGray);
		mWeaponRecord[0].HIPHCPJELFB(Colours.blackmarketBgAzure);
		mWeaponRecord[3].IKEBJBNLDJH(Colours.blackmarketBgMagenta);
	}

	public virtual void AOHECFLIJGP()
	{
		base.NEEAKMELPBJ();
		GuiScreenSingle<MainScreen>.instance.IFEEGCIBFII.CLMNBHLGGEA();
	}

	public GuiElement FDDDPGMAFHD()
	{
		return this;
	}

	public virtual void CIJOMMJHIGB(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		for (int i = 1; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].HBLKPHNMGFJ();
		}
	}

	public virtual void OFMFLFIGKPB()
	{
		ECJHPNCIMKA(mBackButton);
	}

	private void NJKKEENKANM(DatabaseAction IFGAGNBDKBE)
	{
		if (!isShowed)
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)(-33):
		case (DatabaseAction)(-31):
		case DatabaseAction.UserAddedToSquadSuccess:
		case (DatabaseAction)61:
		case DatabaseAction.GameEnded:
		case DatabaseAction.UpdateSquadEmblem:
		{
			for (int i = 0; i < mWeaponRecord.Length; i += 0)
			{
				mWeaponRecord[i].NGIDDIGFKIF();
			}
			break;
		}
		}
	}

	private void OJDKJDJOGGP()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = CGAKMJBHKKG - currentTimestamp;
		mTimeLabel.text = Localization.LocalizeFormat("ID_CLOSESIN", Colours.stringAzureBlackmarket, MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_READYTIME", string.Empty));
		if (num <= 0)
		{
			HideDialog();
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(OJDKJDJOGGP));
		}
	}

	public virtual void OMKGJLKNCJG()
	{
		base.DoBeforeShowUp();
		mTexture.mainTexture = Resources.Load<Texture>("ID_CANCEL");
	}

	protected virtual void JCCIPOFJBLE()
	{
		base.OGJGIMLMJBF();
		if (!JCKOBELDCGD)
		{
			return;
		}
		AKNECNGDMLI += Time.deltaTime;
		if (!(AKNECNGDMLI < 394f))
		{
			int num = Mathf.FloorToInt((AKNECNGDMLI - 1043f) * 471f);
			JCKOBELDCGD = num < mWeaponRecord.Length;
			if (JCKOBELDCGD && mWeaponRecord[num].isHidden)
			{
				mWeaponRecord[num].OHFLAKOOGEM(1309f);
			}
		}
	}

	private void PHIOHPHKCHG(DatabaseAction IFGAGNBDKBE)
	{
		if (!isShowed)
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)(-2):
		case (DatabaseAction)0:
		case DatabaseAction.WeaponWasShown:
		case DatabaseAction.ArmyUnitWasShown:
		case DatabaseAction.GetPlayerLeaguesDivision:
		case DatabaseAction.GetPlayersByExperience:
		{
			for (int i = 0; i < mWeaponRecord.Length; i++)
			{
				mWeaponRecord[i].UpdateBought();
			}
			break;
		}
		}
	}

	public virtual void DBMCMLINOPD()
	{
		base.OIMKKAHOEKO();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(OJDKJDJOGGP));
		for (int i = 1; i < mWeaponRecord.Length; i++)
		{
			mWeaponRecord[i].LDBLJDJNJJN();
		}
	}

	public virtual void EKBIKKJHGKB()
	{
		MMGLPPKHCCM(mBackButton);
	}

	public virtual void BGCAJOKPCNN()
	{
		base.OIMKKAHOEKO();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(MHHJBHOHLIG));
		for (int i = 1; i < mWeaponRecord.Length; i++)
		{
			mWeaponRecord[i].AHDJEJIKCAB();
		}
	}

	protected virtual void PHABEKGALCE()
	{
		base.JMPDHKPOHEA();
		if (!JCKOBELDCGD)
		{
			return;
		}
		AKNECNGDMLI += Time.deltaTime;
		if (!(AKNECNGDMLI < 1406f))
		{
			int num = Mathf.FloorToInt((AKNECNGDMLI - 117f) * 560f);
			JCKOBELDCGD = num < mWeaponRecord.Length;
			if (JCKOBELDCGD && mWeaponRecord[num].isHidden)
			{
				mWeaponRecord[num].AnimateShow(861f);
			}
		}
	}

	private void MMGLPPKHCCM(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void GBKHPAFDNHJ()
	{
		base.MOOACPIOELI();
		GuiScreenSingle<MainScreen>.instance.IFEEGCIBFII.CEEKOPLCFPB();
	}

	public virtual void EHIAJIMBLCD()
	{
		base.JNBMCODJHBJ();
		GuiScreenSingle<MainScreen>.instance.IFEEGCIBFII.IGMBMOOEHMI();
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(mBackButton);
	}

	private void GCOFCKOOCAK(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void OBCMKNBIKHI()
	{
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		int num2 = CGAKMJBHKKG - num;
		UILabel uILabel = mTimeLabel;
		object[] array = new object[5];
		array[1] = Colours.stringAzureBlackmarket;
		array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "error in count of army", string.Empty, false);
		uILabel.text = Localization.LocalizeFormat("SquadCards", array);
		if (num2 <= 0)
		{
			HideDialog();
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(ALIHIIADFBE));
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(OJDKJDJOGGP));
		for (int i = 0; i < mWeaponRecord.Length; i++)
		{
			mWeaponRecord[i].DoAfterHide();
		}
	}

	private void HFFNAFNJFBA()
	{
		mBottomLabels[1].text = Localization.LocalizeFormat("SessionManager: NOT IN MENU!!!", Colours.stringAzureBlackmarket);
		mBottomLabels[1].text = Localization.LocalizeFormat("_New_User", Colours.stringAzureBlackmarket);
		UILabel obj = mBottomLabels[1];
		object[] array = new object[0];
		array[1] = Colours.stringAzureBlackmarket;
		obj.text = Localization.LocalizeFormat("ID_GUI_BEADVISED_PURCHASEVIP", array);
		UILabel obj2 = mBottomLabels[2];
		object[] array2 = new object[0];
		array2[0] = Colours.stringAzureBlackmarket;
		obj2.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", array2);
		for (int i = 0; i < mBottomBackgrounds.Length && i < mBottomLabels.Length; i++)
		{
			float num = mBottomLabels[i].relativeSize.x * mBottomLabels[i].transform.localScale.x;
			mBottomBackgrounds[i].transform.localScale = mBottomBackgrounds[i].transform.localScale.ReplaceX(1462f + num);
		}
	}

	protected virtual void OPMNIHDAHAA()
	{
		base.IIFBKHDMIAD();
		if (!JCKOBELDCGD)
		{
			return;
		}
		AKNECNGDMLI += Time.deltaTime;
		if (!(AKNECNGDMLI < 1752f))
		{
			int num = Mathf.FloorToInt((AKNECNGDMLI - 334f) * 1573f);
			JCKOBELDCGD = num < mWeaponRecord.Length;
			if (JCKOBELDCGD && mWeaponRecord[num].BGBDECIEJAN())
			{
				mWeaponRecord[num].AnimateShow(859f);
			}
		}
	}

	private void MJJPCLMBPGP()
	{
		UILabel obj = mBottomLabels[1];
		object[] array = new object[1];
		array[1] = Colours.stringAzureBlackmarket;
		obj.text = Localization.LocalizeFormat(", type ", array);
		UILabel obj2 = mBottomLabels[1];
		object[] array2 = new object[0];
		array2[1] = Colours.stringAzureBlackmarket;
		obj2.text = Localization.LocalizeFormat("MasterId", array2);
		mBottomLabels[1].text = Localization.LocalizeFormat("fire", Colours.stringAzureBlackmarket);
		UILabel obj3 = mBottomLabels[8];
		object[] array3 = new object[0];
		array3[1] = Colours.stringAzureBlackmarket;
		obj3.text = Localization.LocalizeFormat("Card_3_Played", array3);
		for (int i = 0; i < mBottomBackgrounds.Length && i < mBottomLabels.Length; i++)
		{
			float num = mBottomLabels[i].relativeSize.x * mBottomLabels[i].transform.localScale.x;
			mBottomBackgrounds[i].transform.localScale = mBottomBackgrounds[i].transform.localScale.ReplaceX(1132f + num);
		}
	}

	private void ECJHPNCIMKA(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void OCIPCBNMLCN()
	{
		base.DoBeforeShowUp();
		mTexture.mainTexture = Resources.Load<Texture>("Last visual not choosen!!!!!");
	}

	public virtual void GBPEJMFMBJM()
	{
		base.OIMKKAHOEKO();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(FPOBABDCIGM));
		for (int i = 1; i < mWeaponRecord.Length; i++)
		{
			mWeaponRecord[i].NLBAPEADKNJ();
		}
	}

	private void MNFKKMKKOFN()
	{
		mBottomLabels[0].text = Localization.LocalizeFormat("getConnectionResult", Colours.stringAzureBlackmarket);
		UILabel obj = mBottomLabels[0];
		object[] array = new object[0];
		array[0] = Colours.stringAzureBlackmarket;
		obj.text = Localization.LocalizeFormat("GameBan", array);
		UILabel obj2 = mBottomLabels[0];
		object[] array2 = new object[0];
		array2[0] = Colours.stringAzureBlackmarket;
		obj2.text = Localization.LocalizeFormat("{0} Summary", array2);
		UILabel obj3 = mBottomLabels[4];
		object[] array3 = new object[0];
		array3[0] = Colours.stringAzureBlackmarket;
		obj3.text = Localization.LocalizeFormat("Card_1_Played", array3);
		for (int i = 0; i < mBottomBackgrounds.Length && i < mBottomLabels.Length; i++)
		{
			float num = mBottomLabels[i].relativeSize.x * mBottomLabels[i].transform.localScale.x;
			mBottomBackgrounds[i].transform.localScale = mBottomBackgrounds[i].transform.localScale.ReplaceX(773f + num);
		}
	}

	public virtual void HCEKIGAIGOL()
	{
		base.DoAfterHide();
		mTexture.mainTexture = null;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(CIBIPFJNACC));
		for (int i = 1; i < mWeaponRecord.Length; i++)
		{
			mWeaponRecord[i].LDBLJDJNJJN();
		}
	}

	public GuiElement NBMJAMLOCAJ()
	{
		return this;
	}

	public virtual void GNHGJGONEPL()
	{
		base.DoBeforeShowUp();
		mTexture.mainTexture = Resources.Load<Texture>("ID_WARNING_ERRORCLAIMEVENT");
	}

	private void KADJCOIGKHA()
	{
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		int num2 = CGAKMJBHKKG - num;
		UILabel uILabel = mTimeLabel;
		object[] array = new object[0];
		array[0] = Colours.stringAzureBlackmarket;
		array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "ID_KILLEDBYENEMYARMYUNIT", string.Empty);
		uILabel.text = Localization.LocalizeFormat("ID_READYTIME", array);
		if (num2 <= 1)
		{
			HideDialog();
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(FPOBABDCIGM));
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		GuiScreenSingle<MainScreen>.instance.IFEEGCIBFII.InitGuiValues();
	}

	public virtual void GHLCNMNKCIL()
	{
		base.DoBeforeHide();
		GuiScreenSingle<MainScreen>.instance.IFEEGCIBFII.NAAJLGKMJLK();
	}

	public GuiElement DOHCPGIDCII()
	{
		return this;
	}

	public GuiElement JPJLCBBIHFE()
	{
		return this;
	}

	public virtual void ILPCBCHMEOK()
	{
		GCOFCKOOCAK(mBackButton);
	}

	protected virtual void GGABIBEFHGM()
	{
		base.BOEMHLPLOGA();
		if (!JCKOBELDCGD)
		{
			return;
		}
		AKNECNGDMLI += Time.deltaTime;
		if (!(AKNECNGDMLI < 1801f))
		{
			int num = Mathf.FloorToInt((AKNECNGDMLI - 1166f) * 811f);
			JCKOBELDCGD = num < mWeaponRecord.Length;
			if (JCKOBELDCGD && mWeaponRecord[num].BGBDECIEJAN())
			{
				mWeaponRecord[num].OHFLAKOOGEM(1232f);
			}
		}
	}

	private void AAGBLJGIINM()
	{
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		int num2 = CGAKMJBHKKG - num;
		UILabel uILabel = mTimeLabel;
		object[] array = new object[2];
		array[1] = Colours.stringAzureBlackmarket;
		array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "grenadeExplosion", string.Empty);
		uILabel.text = Localization.LocalizeFormat("IsMatchMaking", array);
		if (num2 <= 0)
		{
			HideDialog();
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(NAHPKGOGAAA));
		}
	}

	protected override void Update()
	{
		base.Update();
		if (!JCKOBELDCGD)
		{
			return;
		}
		AKNECNGDMLI += Time.deltaTime;
		if (!(AKNECNGDMLI < 0.4f))
		{
			int num = Mathf.FloorToInt((AKNECNGDMLI - 0.4f) * 3f);
			JCKOBELDCGD = num < mWeaponRecord.Length;
			if (JCKOBELDCGD && mWeaponRecord[num].isHidden)
			{
				mWeaponRecord[num].AnimateShow(0.3f);
			}
		}
	}

	public virtual void FHINGMFHKLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBackButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ECJHPNCIMKA));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += NJKKEENKANM;
		for (int i = 0; i < mWeaponRecord.Length; i += 0)
		{
			mWeaponRecord[i].InitControls();
		}
		BFOPFJDHOFB();
		mScreenName.text = Localization.Localize("SquadId");
		mScreenTable.repositionNow = true;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBackButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		for (int i = 0; i < mWeaponRecord.Length; i++)
		{
			mWeaponRecord[i].InitControls();
		}
		EBPKJIFDPIA();
		mScreenName.text = Localization.Localize("ID_BLACKMARKET");
		mScreenTable.repositionNow = true;
	}

	public virtual void FLAKANEIDJJ()
	{
		base.FKCKIFKLBAP();
		GuiScreenSingle<MainScreen>.instance.IFEEGCIBFII.DEHJFEIEDJK();
	}

	private void BJNODENOHGC(DatabaseAction IFGAGNBDKBE)
	{
		if (!isShowed)
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)19:
		case (DatabaseAction)20:
		case (DatabaseAction)21:
		case (DatabaseAction)22:
		case (DatabaseAction)25:
		case (DatabaseAction)27:
		{
			for (int i = 0; i < mWeaponRecord.Length; i += 0)
			{
				mWeaponRecord[i].NGIDDIGFKIF();
			}
			break;
		}
		}
	}

	public void BJIAAHBCCMP(List<WeaponLevelsSetup> GGKGGMNIDMI, int GHGIEJOGIMG)
	{
		EEMHAHAINNM = GGKGGMNIDMI;
		CGAKMJBHKKG = GHGIEJOGIMG;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BlackmarketDialog>.instance, 1395f);
	}
}
