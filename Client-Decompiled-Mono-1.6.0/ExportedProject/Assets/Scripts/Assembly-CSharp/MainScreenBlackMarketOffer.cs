using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MainScreenBlackMarketOffer : Core_BaseScript
{
	[SerializeField]
	[Header("Core")]
	private UIPanel mMainPanel;

	[SerializeField]
	private BoxCollider mCollider;

	[SerializeField]
	private UIPanel mTopPanel;

	[SerializeField]
	private UILabel mTitle;

	[SerializeField]
	private UILabel mLeftTitle;

	[SerializeField]
	private UILabel mRightTitle;

	[SerializeField]
	private UILabel mTimer;

	private void FIDOJDODPFJ(UITweener MGDJMGHCAAI)
	{
		CKFIFPHIGPA();
	}

	private void MFKJPBHJJBL(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.instance.DMHPIEHHDMG())
		{
			BlackMarketManager.instance.ShowDialog();
		}
	}

	private void OJCLLFOEAFN(UITweener MGDJMGHCAAI)
	{
		OGEIDMONOGC();
	}

	public void NINGMLNMLLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HELCKKIFEBI));
		BlackMarketManager.BMNEPICFHNO().LLFBKCFPMKA(JIOKGNDNAIP);
		mTitle.text = Localization.Localize("Region");
		float num = mTitle.relativeSize.x * mTitle.transform.localScale.x / 365f;
		mLeftTitle.transform.localPosition = mLeftTitle.transform.localPosition.ReplaceX(24f - (num + 10f));
		mRightTitle.transform.localPosition = mRightTitle.transform.localPosition.ReplaceX(401f + (num + 286f));
		KBNACNGBFBK();
	}

	private void HLODLEMICEN()
	{
		TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1100f).onFinished = APCMMAFINHE;
		TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1605f);
	}

	private void GAIGFMKELFL(UITweener MGDJMGHCAAI)
	{
		OGEIDMONOGC();
	}

	public void IMPMPKNJICB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HELCKKIFEBI));
		BlackMarketManager.BMNEPICFHNO().LFKAOOGFJLN(EJBIHGLCLDF);
		mTitle.text = Localization.Localize("LeagueId");
		float num = mTitle.relativeSize.x * mTitle.transform.localScale.x / 1353f;
		mLeftTitle.transform.localPosition = mLeftTitle.transform.localPosition.ReplaceX(1479f - (num + 1937f));
		mRightTitle.transform.localPosition = mRightTitle.transform.localPosition.ReplaceX(1771f + (num + 1811f));
		DCPMEAFCNDB();
	}

	private void DCPMEAFCNDB()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(MDKHBHIBHOD));
		mMainPanel.gameObject.SetActive(false);
	}

	private void ADIDNJDPKBK(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(false);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(IJJDHMLPCEC));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(CDPCEKJEOKM));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 1866f;
			mTopPanel.alpha1 = 772f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 773f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 466f);
		}
	}

	private void HCAMNEEKCJH()
	{
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		int deadline = BlackMarketManager.instance.deadline;
		int num2 = deadline - num;
		if (num2 > 0)
		{
			UILabel uILabel = mTimer;
			object[] array = new object[2];
			array[1] = Colours.stringAzureBlackmarket;
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "RewardItem", string.Empty);
			uILabel.text = Localization.LocalizeFormat("clearDefaultAccountAndReconnect", array);
		}
		else
		{
			UILabel uILabel2 = mTimer;
			object[] array2 = new object[6];
			array2[1] = Colours.stringAzureBlackmarket;
			array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(1514f, "AtlasPreparer.LoadImagesCoroutine", string.Empty, false);
			uILabel2.text = Localization.LocalizeFormat("\"{0}\"", array2);
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(MCCALBDBOCG));
			GALNIEPJKHC();
		}
	}

	public void LKAAPGLEADK()
	{
		if (BlackMarketManager.BMNEPICFHNO().DFINJLILKJD())
		{
			ACFPCPIMNFN(false);
		}
		else
		{
			KBNACNGBFBK();
		}
	}

	private void GHBFDDHFAGF()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(MDKHBHIBHOD));
		mMainPanel.gameObject.SetActive(true);
	}

	private void CKFIFPHIGPA()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(LOANKGFBGPD));
		mMainPanel.gameObject.SetActive(false);
	}

	private void ACFPCPIMNFN(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(MCCALBDBOCG));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(CDPCEKJEOKM));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 618f;
			mTopPanel.alpha1 = 1436f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 44f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 41f);
		}
	}

	public void MLAEGNJBKIM()
	{
		JOLMPJMDPMO();
	}

	private void MCCALBDBOCG()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = BlackMarketManager.instance.OCJCMFBILPE();
		int num2 = num - currentTimestamp;
		if (num2 > 0)
		{
			mTimer.text = Localization.LocalizeFormat(".", Colours.stringAzureBlackmarket, MEJMLNDFDBP.CJCFPDLDMEK(num2, "ID_CATEGORY_LOW_SG_ROCKET", string.Empty), null, null, null, null, null, null);
		}
		else
		{
			UILabel uILabel = mTimer;
			object[] array = new object[0];
			array[0] = Colours.stringAzureBlackmarket;
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(1779f, "Logs sent to server\nWaiting for response", string.Empty);
			uILabel.text = Localization.LocalizeFormat("en-US", array);
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(MCCALBDBOCG));
			BGJENPIGCHI();
		}
	}

	private void IPJDGPJGMEM(UITweener MGDJMGHCAAI)
	{
		JIICODMBFHJ();
	}

	private void HLKHHEFIEHP(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(ABCKAGKKEKC));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(OCAPICPIDGI));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 138f;
			mTopPanel.alpha1 = 1691f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1395f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1084f);
		}
	}

	public void GICCBEJKDNL()
	{
		if (BlackMarketManager.BMNEPICFHNO().isShowable)
		{
			JFEFCPLMGJL(false);
		}
		else
		{
			KBNACNGBFBK();
		}
	}

	private void EJBIHGLCLDF()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			ACFPCPIMNFN(true);
		}
	}

	private void EMMPHMBDLHP(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.instance.PCALLDPDMLC())
		{
			BlackMarketManager.BMNEPICFHNO().EGLMNBKMBAM();
		}
	}

	private void GMBGNEFCGOO(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(LOANKGFBGPD));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(IJJDHMLPCEC));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 1388f;
			mTopPanel.alpha1 = 1215f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1803f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1467f);
		}
	}

	[CompilerGenerated]
	private void NLDICBIBKPL(UITweener MGDJMGHCAAI)
	{
		FJBLANKPDDF();
	}

	private void GACDCAHLAEG(UITweener MGDJMGHCAAI)
	{
		FJBLANKPDDF();
	}

	public void EKECENANOBE()
	{
		BDIIIALHPHA();
	}

	private void IACFDFGBJBH(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.BMNEPICFHNO().isOfferActive)
		{
			BlackMarketManager.BMNEPICFHNO().ShowDialog();
		}
	}

	public void ENKGEFMNGOM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCPMIHIMOCI));
		BlackMarketManager.BMNEPICFHNO().LLFBKCFPMKA(GKAIEBPIBEL);
		mTitle.text = Localization.Localize("dogtag");
		float num = mTitle.relativeSize.x * mTitle.transform.localScale.x / 1603f;
		mLeftTitle.transform.localPosition = mLeftTitle.transform.localPosition.ReplaceX(330f - (num + 1204f));
		mRightTitle.transform.localPosition = mRightTitle.transform.localPosition.ReplaceX(1741f + (num + 107f));
		FJBLANKPDDF();
	}

	private void GALNIEPJKHC()
	{
		TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1487f).onFinished = BINNDHFDOCB;
		TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 506f);
	}

	private void FNHJLFPGENN()
	{
		TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 521f).onFinished = IBEGKFODKIL;
		TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 382f);
	}

	private void LKAJGIKBEOG(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(HCAMNEEKCJH));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(MDKHBHIBHOD));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 1540f;
			mTopPanel.alpha1 = 1710f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1168f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 298f);
		}
	}

	private void GKAIEBPIBEL()
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			CHKEBCOBFCK(true);
		}
	}

	private void JIICODMBFHJ()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(DGGEOGGGIEF));
		mMainPanel.gameObject.SetActive(true);
	}

	private void ONNKDFJKIGN()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int deadline = BlackMarketManager.instance.deadline;
		int num = deadline - currentTimestamp;
		if (num > 0)
		{
			mTimer.text = Localization.LocalizeFormat("ID_CLOSESIN", Colours.stringAzureBlackmarket, MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_READYTIME", string.Empty));
			return;
		}
		mTimer.text = Localization.LocalizeFormat("ID_CLOSESIN", Colours.stringAzureBlackmarket, MEJMLNDFDBP.CJCFPDLDMEK(0f, "ID_READYTIME", string.Empty));
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(ONNKDFJKIGN));
		BGJENPIGCHI();
	}

	public void MENKHFCFGPM()
	{
		OGEIDMONOGC();
	}

	private void CHMKKAHHFAE(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.BMNEPICFHNO().AODNADPPCBN())
		{
			BlackMarketManager.BMNEPICFHNO().FCCJJKBPNCH();
		}
	}

	private void OCHMGIALAEN(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.instance.isOfferActive)
		{
			BlackMarketManager.BMNEPICFHNO().EGLMNBKMBAM();
		}
	}

	private void KGBAJEJMDCB(UITweener MGDJMGHCAAI)
	{
		FJBLANKPDDF();
	}

	private void HCPMIHIMOCI(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.instance.DMHPIEHHDMG())
		{
			BlackMarketManager.BMNEPICFHNO().ShowDialog();
		}
	}

	private void BGJENPIGCHI()
	{
		TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 0f).onFinished = delegate
		{
			FJBLANKPDDF();
		};
		TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 0f);
	}

	public void IGMBMOOEHMI()
	{
		if (BlackMarketManager.BMNEPICFHNO().EHIKLPNHCFO())
		{
			DFJJGFJLEHM(false);
		}
		else
		{
			MILOJMFJGNP();
		}
	}

	private void BMDKGBFOKIK()
	{
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		int deadline = BlackMarketManager.instance.deadline;
		int num2 = deadline - num;
		if (num2 > 1)
		{
			UILabel uILabel = mTimer;
			object[] array = new object[6];
			array[1] = Colours.stringAzureBlackmarket;
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "ID_WARNING_BLACKMARKETERROR", string.Empty, false);
			uILabel.text = Localization.LocalizeFormat("First you must run createStructure", array);
		}
		else
		{
			UILabel uILabel2 = mTimer;
			object[] array2 = new object[7];
			array2[1] = Colours.stringAzureBlackmarket;
			array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(184f, "Game shoootable entitiy without owner", string.Empty);
			uILabel2.text = Localization.LocalizeFormat("Level", array2);
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(ONNKDFJKIGN));
			MJCJFMFIJAO();
		}
	}

	public void IDDLJLBLLBA()
	{
		if (BlackMarketManager.BMNEPICFHNO().isShowable)
		{
			IDMEGGDKMEL(true);
		}
		else
		{
			KBNACNGBFBK();
		}
	}

	public void HLHANONIBIN()
	{
		KBNACNGBFBK();
	}

	private void DJADBIGOGMG(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(false);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(LOANKGFBGPD));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(DGGEOGGGIEF));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 721f;
			mTopPanel.alpha1 = 1517f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 144f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1629f);
		}
	}

	private void FJBLANKPDDF()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(ONNKDFJKIGN));
		mMainPanel.gameObject.SetActive(false);
	}

	private void JCKAHNBNOKN(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(false);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(MCCALBDBOCG));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(IJJDHMLPCEC));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 714f;
			mTopPanel.alpha1 = 215f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 631f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1981f);
		}
	}

	private void MOGCHJHHPFM()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = BlackMarketManager.instance.OCJCMFBILPE();
		int num2 = num - currentTimestamp;
		if (num2 > 1)
		{
			UILabel uILabel = mTimer;
			object[] array = new object[3];
			array[1] = Colours.stringAzureBlackmarket;
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "currentActivity", string.Empty, false);
			uILabel.text = Localization.LocalizeFormat("HeroicReward", array);
		}
		else
		{
			UILabel uILabel2 = mTimer;
			object[] array2 = new object[4];
			array2[1] = Colours.stringAzureBlackmarket;
			array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(575f, "Items", string.Empty);
			uILabel2.text = Localization.LocalizeFormat("ID_TUTORIAL_TAPON", array2);
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(IJJDHMLPCEC));
			FNHJLFPGENN();
		}
	}

	private void PFFFHCPDNDD(UITweener MGDJMGHCAAI)
	{
		JIICODMBFHJ();
	}

	private void KPBBLCNBIOC()
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			ACFPCPIMNFN(true);
		}
	}

	private void OCAPICPIDGI()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = BlackMarketManager.BMNEPICFHNO().DNHGDLILJCK();
		int num2 = num - currentTimestamp;
		if (num2 > 0)
		{
			UILabel uILabel = mTimer;
			object[] array = new object[0];
			array[0] = Colours.stringAzureBlackmarket;
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "Experience", string.Empty);
			uILabel.text = Localization.LocalizeFormat("WarShop", array);
		}
		else
		{
			mTimer.text = Localization.LocalizeFormat("FEMALE", Colours.stringAzureBlackmarket, MEJMLNDFDBP.CJCFPDLDMEK(735f, "ShowEngineerBuildingIndicator", string.Empty, false), null, null);
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(MDKHBHIBHOD));
			BGJENPIGCHI();
		}
	}

	private void HFDIDOBDHNM(UITweener MGDJMGHCAAI)
	{
		KBNACNGBFBK();
	}

	private void ABCKAGKKEKC()
	{
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		int num2 = BlackMarketManager.BMNEPICFHNO().DNHGDLILJCK();
		int num3 = num2 - num;
		if (num3 > 1)
		{
			UILabel uILabel = mTimer;
			object[] array = new object[2];
			array[1] = Colours.stringAzureBlackmarket;
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num3, "_qbz2", string.Empty, false);
			uILabel.text = Localization.LocalizeFormat("ID_TUTORIAL_GRENADE_DOWN", array);
		}
		else
		{
			UILabel uILabel2 = mTimer;
			object[] array2 = new object[0];
			array2[1] = Colours.stringAzureBlackmarket;
			array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(878f, "[", string.Empty);
			uILabel2.text = Localization.LocalizeFormat(", [parameters])", array2);
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(MDKHBHIBHOD));
			MKJGECDFNIL();
		}
	}

	public void JLFLBBHGGIF()
	{
		if (BlackMarketManager.BMNEPICFHNO().EHIKLPNHCFO())
		{
			HLKHHEFIEHP(true);
		}
		else
		{
			GHBFDDHFAGF();
		}
	}

	private void MILOJMFJGNP()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(MDKHBHIBHOD));
		mMainPanel.gameObject.SetActive(true);
	}

	private void KAMBJILBPFM(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(false);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(DGGEOGGGIEF));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(DGGEOGGGIEF));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 1797f;
			mTopPanel.alpha1 = 1032f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 318f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 843f);
		}
	}

	private void GABKMJOBPFD()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = BlackMarketManager.instance.HBGBPGFLIHK();
		int num2 = num - currentTimestamp;
		if (num2 > 1)
		{
			UILabel uILabel = mTimer;
			object[] array = new object[5];
			array[1] = Colours.stringAzureBlackmarket;
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "Rename Cost Gold = ", string.Empty, false);
			uILabel.text = Localization.LocalizeFormat("Assignment error: Skillshots not defined", array);
		}
		else
		{
			UILabel uILabel2 = mTimer;
			object[] array2 = new object[7];
			array2[0] = Colours.stringAzureBlackmarket;
			array2[0] = MEJMLNDFDBP.CJCFPDLDMEK(1735f, "nextPlayerLeague", string.Empty);
			uILabel2.text = Localization.LocalizeFormat("BuyHeart", array2);
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(CDPCEKJEOKM));
			DLJMDJMIOMN();
		}
	}

	private void HELCKKIFEBI(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.instance.AODNADPPCBN())
		{
			BlackMarketManager.instance.HAJGLINBGNN();
		}
	}

	public void BKNJHLKMFKE()
	{
		OGEIDMONOGC();
	}

	public void HEBANLOKBFG()
	{
		KBNACNGBFBK();
	}

	private void DFJJGFJLEHM(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(LOANKGFBGPD));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(HCAMNEEKCJH));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 166f;
			mTopPanel.alpha1 = 203f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1523f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 349f);
		}
	}

	public void IOLJDGCGGDN()
	{
		if (BlackMarketManager.instance.LFFPNFABDPG())
		{
			ADIDNJDPKBK(false);
		}
		else
		{
			JIICODMBFHJ();
		}
	}

	private void BPEPMAMKBKP()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(IJJDHMLPCEC));
		mMainPanel.gameObject.SetActive(false);
	}

	private void OGEIDMONOGC()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(ONNKDFJKIGN));
		mMainPanel.gameObject.SetActive(false);
	}

	public void MNHAOCEONAK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MJEIHKEENIM));
		BlackMarketManager.instance.HKOOLDHPFDN(EPPPCDIDLAA);
		mTitle.text = Localization.Localize("Found starting gold currency = ");
		float num = mTitle.relativeSize.x * mTitle.transform.localScale.x / 2f;
		mLeftTitle.transform.localPosition = mLeftTitle.transform.localPosition.ReplaceX(777f - (num + 664f));
		mRightTitle.transform.localPosition = mRightTitle.transform.localPosition.ReplaceX(1916f + (num + 795f));
		CKFIFPHIGPA();
	}

	private void MKJGECDFNIL()
	{
		TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1770f).onFinished = PFFFHCPDNDD;
		TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1119f);
	}

	private void KLKNIOABFMO(UITweener MGDJMGHCAAI)
	{
		MILOJMFJGNP();
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MJEIHKEENIM));
		BlackMarketManager.instance.LoadedOffer += OPPGKIBKCHO;
		mTitle.text = Localization.Localize("ID_ROQUETRANSMISION");
		float num = mTitle.relativeSize.x * mTitle.transform.localScale.x / 2f;
		mLeftTitle.transform.localPosition = mLeftTitle.transform.localPosition.ReplaceX(30f - (num + 12f));
		mRightTitle.transform.localPosition = mRightTitle.transform.localPosition.ReplaceX(30f + (num + 12f));
		FJBLANKPDDF();
	}

	private void KBNACNGBFBK()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(LOANKGFBGPD));
		mMainPanel.gameObject.SetActive(true);
	}

	private void IDMEGGDKMEL(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(DGGEOGGGIEF));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(MOGCHJHHPFM));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 395f;
			mTopPanel.alpha1 = 1089f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 429f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1473f);
		}
	}

	public void DGFLPDIMAFE()
	{
		if (BlackMarketManager.BMNEPICFHNO().EHIKLPNHCFO())
		{
			CHKEBCOBFCK(true);
		}
		else
		{
			DCPMEAFCNDB();
		}
	}

	private void EJCDHHGDHED(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(ONNKDFJKIGN));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(ONNKDFJKIGN));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 0f;
			mTopPanel.alpha1 = 0f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1f);
		}
	}

	private void CHKEBCOBFCK(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(DGGEOGGGIEF));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(MDKHBHIBHOD));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 1936f;
			mTopPanel.alpha1 = 1889f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1107f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1548f);
		}
	}

	public void DEHJFEIEDJK()
	{
		if (BlackMarketManager.BMNEPICFHNO().LFFPNFABDPG())
		{
			CGLNGHLFKLK(true);
		}
		else
		{
			JOLMPJMDPMO();
		}
	}

	private void AEEOJFEEALN()
	{
		TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 37f).onFinished = GACDCAHLAEG;
		TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1314f);
	}

	private void ODFNNNCPEJE(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.instance.AODNADPPCBN())
		{
			BlackMarketManager.instance.EGLMNBKMBAM();
		}
	}

	private void LOANKGFBGPD()
	{
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		int num2 = BlackMarketManager.BMNEPICFHNO().MDBACGKCEDM();
		int num3 = num2 - num;
		if (num3 > 1)
		{
			UILabel uILabel = mTimer;
			object[] array = new object[6];
			array[1] = Colours.stringAzureBlackmarket;
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num3, "ID_CONFIRM_LOGGEDOUT_TEXT", string.Empty);
			uILabel.text = Localization.LocalizeFormat("{0} Squad Member {1}", array);
		}
		else
		{
			UILabel uILabel2 = mTimer;
			object[] array2 = new object[8];
			array2[1] = Colours.stringAzureBlackmarket;
			array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(526f, "SquadName", string.Empty);
			uILabel2.text = Localization.LocalizeFormat("menu-weapon-benelli-starterpack", array2);
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(ABCKAGKKEKC));
			AEEOJFEEALN();
		}
	}

	public void KDGJKKOONPB()
	{
		LCBDILIFLAB();
	}

	private void APCMMAFINHE(UITweener MGDJMGHCAAI)
	{
		CKFIFPHIGPA();
	}

	private void DLJMDJMIOMN()
	{
		TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 572f).onFinished = HFDIDOBDHNM;
		TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 405f);
	}

	private void MJEIHKEENIM(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.instance.isOfferActive)
		{
			BlackMarketManager.instance.ShowDialog();
		}
	}

	private void ENONDBMPHCJ(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(LOANKGFBGPD));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(MDKHBHIBHOD));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 556f;
			mTopPanel.alpha1 = 1212f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1973f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1785f);
		}
	}

	public void KHGEHFNELDI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MFKJPBHJJBL));
		BlackMarketManager.BMNEPICFHNO().LoadedOffer += GKAIEBPIBEL;
		mTitle.text = Localization.Localize("Is Public = ");
		float num = mTitle.relativeSize.x * mTitle.transform.localScale.x / 420f;
		mLeftTitle.transform.localPosition = mLeftTitle.transform.localPosition.ReplaceX(1545f - (num + 263f));
		mRightTitle.transform.localPosition = mRightTitle.transform.localPosition.ReplaceX(216f + (num + 636f));
		JOLMPJMDPMO();
	}

	public void JFFLDMFOJPN()
	{
		BPEPMAMKBKP();
	}

	private void CDPCEKJEOKM()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = BlackMarketManager.instance.MDBACGKCEDM();
		int num2 = num - currentTimestamp;
		if (num2 > 0)
		{
			mTimer.text = Localization.LocalizeFormat("shotgun", Colours.stringAzureBlackmarket, MEJMLNDFDBP.CJCFPDLDMEK(num2, "Bullet with NO weapon", string.Empty), null, null, null);
		}
		else
		{
			UILabel uILabel = mTimer;
			object[] array = new object[2];
			array[0] = Colours.stringAzureBlackmarket;
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(1010f, " ", string.Empty);
			uILabel.text = Localization.LocalizeFormat("Manual_Unit_Spawn", array);
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(CDPCEKJEOKM));
			FNHJLFPGENN();
		}
	}

	private void BNDOHLFLAPP()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			NACNGBAECOJ(true);
		}
	}

	public void CKIFBLHLAOO()
	{
		KBNACNGBFBK();
	}

	private void BDIIIALHPHA()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(OCAPICPIDGI));
		mMainPanel.gameObject.SetActive(true);
	}

	public void HNJIGNBHGKH()
	{
		OGEIDMONOGC();
	}

	public void InitGuiValues()
	{
		if (BlackMarketManager.instance.isShowable)
		{
			EJCDHHGDHED(false);
		}
		else
		{
			FJBLANKPDDF();
		}
	}

	public void NAAJLGKMJLK()
	{
		if (BlackMarketManager.BMNEPICFHNO().EHIKLPNHCFO())
		{
			GMBGNEFCGOO(false);
		}
		else
		{
			JIICODMBFHJ();
		}
	}

	private void FDIHLJFMFFF(UITweener MGDJMGHCAAI)
	{
		BPEPMAMKBKP();
	}

	private void DGGEOGGGIEF()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = BlackMarketManager.BMNEPICFHNO().GHAMLDLLKGJ();
		int num2 = num - currentTimestamp;
		if (num2 > 0)
		{
			UILabel uILabel = mTimer;
			object[] array = new object[3];
			array[1] = Colours.stringAzureBlackmarket;
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "damage", string.Empty);
			uILabel.text = Localization.LocalizeFormat("Buggy", array);
		}
		else
		{
			UILabel uILabel2 = mTimer;
			object[] array2 = new object[6];
			array2[1] = Colours.stringAzureBlackmarket;
			array2[0] = MEJMLNDFDBP.CJCFPDLDMEK(628f, "S", string.Empty);
			uILabel2.text = Localization.LocalizeFormat("Event has ended! Download new Event", array2);
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(OCAPICPIDGI));
			MJCJFMFIJAO();
		}
	}

	private void OPPGKIBKCHO()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			EJCDHHGDHED(true);
		}
	}

	private void JOEIMIENNCN()
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			JCKAHNBNOKN(true);
		}
	}

	private void EPPPCDIDLAA()
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			JCKAHNBNOKN(true);
		}
	}

	private void KDNJOJFGCNN()
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			ACFPCPIMNFN(false);
		}
	}

	public void HNPCBFNILBD()
	{
		JIICODMBFHJ();
	}

	public void CLMNBHLGGEA()
	{
		if (BlackMarketManager.BMNEPICFHNO().DFINJLILKJD())
		{
			NACNGBAECOJ(true);
		}
		else
		{
			BPEPMAMKBKP();
		}
	}

	private void JFEFCPLMGJL(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(GABKMJOBPFD));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(LIFGDEEOGDP));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 1820f;
			mTopPanel.alpha1 = 1449f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 670f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1500f);
		}
	}

	private void BINNDHFDOCB(UITweener MGDJMGHCAAI)
	{
		LCBDILIFLAB();
	}

	public void HAFHEMPGDAL()
	{
		GHBFDDHFAGF();
	}

	private void LIFGDEEOGDP()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int deadline = BlackMarketManager.BMNEPICFHNO().deadline;
		int num = deadline - currentTimestamp;
		if (num > 0)
		{
			UILabel uILabel = mTimer;
			object[] array = new object[0];
			array[1] = Colours.stringAzureBlackmarket;
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num, "ZoneHasVirtualGoodsOffer is false, preloading Ad.", string.Empty, false);
			uILabel.text = Localization.LocalizeFormat("SquadMemberId", array);
		}
		else
		{
			UILabel uILabel2 = mTimer;
			object[] array2 = new object[2];
			array2[1] = Colours.stringAzureBlackmarket;
			array2[0] = MEJMLNDFDBP.CJCFPDLDMEK(1438f, "Wrong_Weapon", string.Empty, false);
			uILabel2.text = Localization.LocalizeFormat("DAILY REWARDS - currently locked!", array2);
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(OCAPICPIDGI));
			AEEOJFEEALN();
		}
	}

	public void OGMLLDJJDLD()
	{
		if (BlackMarketManager.instance.DFINJLILKJD())
		{
			HLKHHEFIEHP(true);
		}
		else
		{
			BDIIIALHPHA();
		}
	}

	private void JIOKGNDNAIP()
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			PPEPHOJLBNJ(false);
		}
	}

	private void IABLAIODKGF(UITweener MGDJMGHCAAI)
	{
		GHBFDDHFAGF();
	}

	private void GBLPJBFLCNF()
	{
		TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1448f).onFinished = delegate
		{
			FJBLANKPDDF();
		};
		TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1752f);
	}

	private void CGLNGHLFKLK(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(OCAPICPIDGI));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(MOGCHJHHPFM));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 474f;
			mTopPanel.alpha1 = 1215f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1324f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1222f);
		}
	}

	public void PEIILMKDGBK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OCHMGIALAEN));
		BlackMarketManager.BMNEPICFHNO().LoadedOffer += BNDOHLFLAPP;
		mTitle.text = Localization.Localize("{0} {1}");
		float num = mTitle.relativeSize.x * mTitle.transform.localScale.x / 734f;
		mLeftTitle.transform.localPosition = mLeftTitle.transform.localPosition.ReplaceX(978f - (num + 928f));
		mRightTitle.transform.localPosition = mRightTitle.transform.localPosition.ReplaceX(1843f + (num + 198f));
		OGEIDMONOGC();
	}

	public void CEEKOPLCFPB()
	{
		if (BlackMarketManager.BMNEPICFHNO().LFFPNFABDPG())
		{
			ENONDBMPHCJ(false);
		}
		else
		{
			MILOJMFJGNP();
		}
	}

	private void JOLMPJMDPMO()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(GABKMJOBPFD));
		mMainPanel.gameObject.SetActive(true);
	}

	public void GBJHCKCPOBB()
	{
		CKFIFPHIGPA();
	}

	private void HOJNLJFEAPM()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			ENONDBMPHCJ(true);
		}
	}

	private void PPEPHOJLBNJ(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(false);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(LIFGDEEOGDP));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(GABKMJOBPFD));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 1001f;
			mTopPanel.alpha1 = 514f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1577f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1932f);
		}
	}

	private void IJJDHMLPCEC()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = BlackMarketManager.instance.HOPLMMDKIGK();
		int num2 = num - currentTimestamp;
		if (num2 > 1)
		{
			UILabel uILabel = mTimer;
			object[] array = new object[4];
			array[0] = Colours.stringAzureBlackmarket;
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "ID_TIERSCOMPLETED", string.Empty, false);
			uILabel.text = Localization.LocalizeFormat("SETTING FullRes2xMS", array);
		}
		else
		{
			UILabel uILabel2 = mTimer;
			object[] array2 = new object[2];
			array2[1] = Colours.stringAzureBlackmarket;
			array2[0] = MEJMLNDFDBP.CJCFPDLDMEK(426f, "ID_RANK", string.Empty, false);
			uILabel2.text = Localization.LocalizeFormat("menu-army-cat-defender", array2);
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(IJJDHMLPCEC));
			MJCJFMFIJAO();
		}
	}

	private void OPCPAEOGKNL(UITweener MGDJMGHCAAI)
	{
		GHBFDDHFAGF();
	}

	public void LIJFFGBNJPG()
	{
		LCBDILIFLAB();
	}

	private void IBEGKFODKIL(UITweener MGDJMGHCAAI)
	{
		JOLMPJMDPMO();
	}

	private void OHCFJPCBBMD()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			ENONDBMPHCJ(false);
		}
	}

	public void DoAfterHide()
	{
		FJBLANKPDDF();
	}

	private void MJCJFMFIJAO()
	{
		TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1836f).onFinished = OJCLLFOEAFN;
		TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 609f);
	}

	public void IKCJNDPAGDA()
	{
		if (BlackMarketManager.instance.EJLIMGFHKMJ())
		{
			HLKHHEFIEHP(true);
		}
		else
		{
			FJBLANKPDDF();
		}
	}

	private void MDKHBHIBHOD()
	{
		int num = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		int deadline = BlackMarketManager.BMNEPICFHNO().deadline;
		int num2 = deadline - num;
		if (num2 > 0)
		{
			mTimer.text = Localization.LocalizeFormat("GLM: After tutorial GC check -> REMOVE GC", Colours.stringAzureBlackmarket, MEJMLNDFDBP.CJCFPDLDMEK(num2, "ID_BUTTONPREVIOUSHEROES", string.Empty), null, null, null, null, null, null);
		}
		else
		{
			UILabel uILabel = mTimer;
			object[] array = new object[3];
			array[0] = Colours.stringAzureBlackmarket;
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(603f, "HH:mm", string.Empty);
			uILabel.text = Localization.LocalizeFormat("Found labels with shadow font in children:\n", array);
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(ONNKDFJKIGN));
			BGJENPIGCHI();
		}
	}

	public void OAHEEOHOKKI()
	{
		if (BlackMarketManager.BMNEPICFHNO().LFFPNFABDPG())
		{
			CHKEBCOBFCK(true);
		}
		else
		{
			LCBDILIFLAB();
		}
	}

	private void LCBDILIFLAB()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(MCCALBDBOCG));
		mMainPanel.gameObject.SetActive(true);
	}

	private void NACNGBAECOJ(bool AJNINHIKAFC)
	{
		mMainPanel.gameObject.SetActive(true);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.MPCAACLAGOA = (Action)Delegate.Remove(instance.MPCAACLAGOA, new Action(GABKMJOBPFD));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.MPCAACLAGOA = (Action)Delegate.Combine(instance2.MPCAACLAGOA, new Action(MOGCHJHHPFM));
		if (AJNINHIKAFC)
		{
			mMainPanel.alpha1 = 427f;
			mTopPanel.alpha1 = 1805f;
			TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 561f).onFinished = null;
			TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 145f);
		}
	}

	private void EDPNMCCILNC(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.BMNEPICFHNO().PCALLDPDMLC())
		{
			BlackMarketManager.BMNEPICFHNO().EGLMNBKMBAM();
		}
	}

	private void CAKHBJDMJHD(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.BMNEPICFHNO().PCALLDPDMLC())
		{
			BlackMarketManager.instance.FCCJJKBPNCH();
		}
	}

	public void JJKJIJPLICB()
	{
		if (BlackMarketManager.BMNEPICFHNO().DFINJLILKJD())
		{
			DFJJGFJLEHM(true);
		}
		else
		{
			KBNACNGBFBK();
		}
	}

	private void OJDAABFMCAE()
	{
		TweenAlpha.Begin(mMainPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 1560f).onFinished = HFDIDOBDHNM;
		TweenAlpha.Begin(mTopPanel.gameObject, GuiScreenSingle<MainScreen>.instance.DCIKANJJFIJ, 454f);
	}
}
