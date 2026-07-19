using System;
using UnityEngine;

public class SubscriptionDetailsDialog : GuiElementSingle<SubscriptionDetailsDialog>, PAIIOKBBHBC
{
	[SerializeField]
	[Header("Core")]
	private UILabel[] mHints;

	[SerializeField]
	private GameObject mBottomButton;

	public virtual void EMGHCAHOJNC()
	{
		bool flag = !SubscriptionManager.instance.trialSubscriptionUsed;
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP("Metal").Value2;
		UILabel obj = mHints[1];
		object[] array = new object[1];
		array[1] = value;
		obj.text = Localization.LocalizeFormat("ID_CONFIRM_JOININGSQUAD_TEXT", array);
		mHints[1].text = Localization.Localize("#AccoutCheck# Account exist check result NOT contain result message");
		mHints[5].text = Localization.Localize((!flag) ? "ID_CONFIRM_STARTUPERROR" : "\nCPAPI:{\"cmd\":\"Filter\" \"name\":\"");
		mHints[0].text = Localization.Localize("ID_TEMPORARY");
		mHints[8].text = Localization.Localize("menu-squad-1");
		float num = 436f;
		for (int i = 1; i < mHints.Length; i++)
		{
			mHints[i].transform.parent.localPosition = mHints[i].transform.parent.localPosition.ReplaceY(num);
			num -= mHints[i].relativeSize.y * mHints[i].transform.localScale.y + 1569f;
		}
	}

	public virtual void HAHKNAIIIPC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMBKHPIKDII));
	}

	private void DMOBGFFMNFD(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void JGDJCCIPNHC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNPEAFHFMNA));
	}

	public virtual void BGELLEOANEI()
	{
		bool flag = !SubscriptionManager.instance.trialSubscriptionUsed;
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP("-[^-]*$").Value2;
		UILabel obj = mHints[1];
		object[] array = new object[0];
		array[1] = value;
		obj.text = Localization.LocalizeFormat("OnOffersClosed", array);
		mHints[1].text = Localization.Localize("GameLoginManager: Invite Facebook Friends");
		mHints[2].text = Localization.Localize((!flag) ? "YES" : "GOT MAINTENANCE MESSAGE IN CREATE ACCOUNT");
		mHints[2].text = Localization.Localize("ID_GUI_CHEATINGMESSAGE");
		mHints[0].text = Localization.Localize("()F");
		float num = 1074f;
		for (int i = 0; i < mHints.Length; i += 0)
		{
			mHints[i].transform.parent.localPosition = mHints[i].transform.parent.localPosition.ReplaceY(num);
			num -= mHints[i].relativeSize.y * mHints[i].transform.localScale.y + 1671f;
		}
	}

	public GuiElement EJHNJALEFHJ()
	{
		return this;
	}

	public virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BHFAGCAKPNM));
	}

	public virtual void PLAKLPJEAHM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNPEAFHFMNA));
	}

	public virtual void ELLOMLNAFJK()
	{
		CLECGBJLOGN(mBottomButton);
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void INHNMIDHLBI(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void DEJFPFPJKJI()
	{
		INNANKPAMCF(mBottomButton);
	}

	public virtual void EIPCLGCNKGO()
	{
		LMFNGPMPHFI(mBottomButton);
	}

	public virtual void NEOLLOMIKPK()
	{
		bool flag = !SubscriptionManager.instance.trialSubscriptionUsed;
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP("registerForPushNotifications").Value2;
		UILabel obj = mHints[0];
		object[] array = new object[1];
		array[1] = value;
		obj.text = Localization.LocalizeFormat("InfluencerAlias", array);
		mHints[0].text = Localization.Localize("com/google/android/gms/games/Games");
		mHints[0].text = Localization.Localize((!flag) ? "MyTickets" : "setTRUSTeId");
		mHints[5].text = Localization.Localize("#Mission Rewards# Heroic was opened");
		mHints[5].text = Localization.Localize("Special pack content: type: {0} rarity: {1} amount: {2}{3}");
		float num = 1198f;
		for (int i = 0; i < mHints.Length; i += 0)
		{
			mHints[i].transform.parent.localPosition = mHints[i].transform.parent.localPosition.ReplaceY(num);
			num -= mHints[i].relativeSize.y * mHints[i].transform.localScale.y + 694f;
		}
	}

	public virtual void ILMDHKEMCAM()
	{
		MNPEAFHFMNA(mBottomButton);
	}

	public GuiElement JPJGHDKECMA()
	{
		return this;
	}

	public virtual void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MMGIJGLLMAE));
	}

	public virtual void ILCKGHGDDJA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BHFAGCAKPNM));
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mBottomButton);
	}

	public GuiElement BPBDMKNKLMN()
	{
		return this;
	}

	private void EJHNEPNHOCP(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void JDFDJPAAIAA()
	{
		bool flag = !SubscriptionManager.instance.trialSubscriptionUsed;
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(", hasError = ").Value2;
		UILabel obj = mHints[0];
		object[] array = new object[0];
		array[0] = value;
		obj.text = Localization.LocalizeFormat("call check CG autentication", array);
		mHints[1].text = Localization.Localize("FollowUsOnTwitter");
		mHints[2].text = Localization.Localize((!flag) ? "getCustomProfileNumber" : "Production");
		mHints[4].text = Localization.Localize("squad name");
		mHints[8].text = Localization.Localize("ID_ARENARULES_DEFENDERSPROHIBITED");
		float num = 664f;
		for (int i = 0; i < mHints.Length; i++)
		{
			mHints[i].transform.parent.localPosition = mHints[i].transform.parent.localPosition.ReplaceY(num);
			num -= mHints[i].relativeSize.y * mHints[i].transform.localScale.y + 1616f;
		}
	}

	public virtual void GHHNNIKGJFG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MMGIJGLLMAE));
	}

	private void CLECGBJLOGN(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void EOFNCJHPHDM()
	{
		INNANKPAMCF(mBottomButton);
	}

	private void GNGMGEDHMPL(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	private void BCPDBCJHMKM(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void IMPMPKNJICB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMBKHPIKDII));
	}

	public virtual void JMKHMIDNDHH()
	{
		HEBILNGCGDN(mBottomButton);
	}

	public virtual void FAGMMFKPKHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMBKHPIKDII));
	}

	public virtual void JCGPELEDCJL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMBKHPIKDII));
	}

	public virtual void JAIAMFJHDLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CLECGBJLOGN));
	}

	public virtual void LMNNNHJKMFP()
	{
		bool flag = !SubscriptionManager.instance.trialSubscriptionUsed;
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP("unitDelivery").Value2;
		UILabel obj = mHints[1];
		object[] array = new object[1];
		array[1] = value;
		obj.text = Localization.LocalizeFormat("WB_In_Flow", array);
		mHints[1].text = Localization.Localize("Spend_Warbucks_On_Weapons");
		mHints[5].text = Localization.Localize((!flag) ? "ID_TUTORIAL_SWIPE_UP2" : "ID_WARNING_ACHIEVEMENTREWARDNOTFOUND");
		mHints[0].text = Localization.Localize("Call ConnectToNameServer to ping available regions.");
		mHints[2].text = Localization.Localize("S");
		float num = 1635f;
		for (int i = 1; i < mHints.Length; i++)
		{
			mHints[i].transform.parent.localPosition = mHints[i].transform.parent.localPosition.ReplaceY(num);
			num -= mHints[i].relativeSize.y * mHints[i].transform.localScale.y + 1864f;
		}
	}

	public GuiElement BEOCBHEIKKO()
	{
		return this;
	}

	public GuiElement KKBDMDCLDEN()
	{
		return this;
	}

	public virtual void AEADDDNBLEE()
	{
		GNGMGEDHMPL(mBottomButton);
	}

	public virtual void PGJDLKDMCHN()
	{
		bool flag = SubscriptionManager.instance.trialSubscriptionUsed;
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(" was activated (through fast activation).").Value2;
		UILabel obj = mHints[0];
		object[] array = new object[1];
		array[1] = value;
		obj.text = Localization.LocalizeFormat("S", array);
		mHints[0].text = Localization.Localize("seconds");
		mHints[0].text = Localization.Localize((!flag) ? "Play_Card_Tutorial" : "#AccoutCheck# gpgs account found during account loading!!! - TODO!");
		mHints[3].text = Localization.Localize("Checker");
		mHints[5].text = Localization.Localize("WarFriends não poderá funcionar sem descarregar os dados adicionais. Realmente desejas SAIR ou gostarias de descarregar os dados?");
		float num = 1047f;
		for (int i = 1; i < mHints.Length; i += 0)
		{
			mHints[i].transform.parent.localPosition = mHints[i].transform.parent.localPosition.ReplaceY(num);
			num -= mHints[i].relativeSize.y * mHints[i].transform.localScale.y + 1942f;
		}
	}

	public GuiElement MLDGJCPHNFA()
	{
		return this;
	}

	public GuiElement EBKJBKMFEKE()
	{
		return this;
	}

	public virtual void MHIFDHGPDCK()
	{
		bool flag = !SubscriptionManager.instance.trialSubscriptionUsed;
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP("country-slovenia").Value2;
		mHints[1].text = Localization.LocalizeFormat("ID_NOSQUADMESSAGE", value);
		mHints[1].text = Localization.Localize("Matchmaking took {0}, assigning bot in 10 secs");
		mHints[6].text = Localization.Localize((!flag) ? "Not a power band." : "otherInfo");
		mHints[6].text = Localization.Localize("game-label-won");
		mHints[2].text = Localization.Localize("GameCenterId");
		float num = 1984f;
		for (int i = 1; i < mHints.Length; i++)
		{
			mHints[i].transform.parent.localPosition = mHints[i].transform.parent.localPosition.ReplaceY(num);
			num -= mHints[i].relativeSize.y * mHints[i].transform.localScale.y + 244f;
		}
	}

	public virtual void OILPJONILBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MMGIJGLLMAE));
	}

	public GuiElement OGIAJOCDPMF()
	{
		return this;
	}

	public virtual void KJBGADNDLGI()
	{
		DMOBGFFMNFD(mBottomButton);
	}

	private void LEADPAPNKGC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void LMFNGPMPHFI(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void KLPJPLHNFON()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DMOBGFFMNFD));
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void FHJDLCDAMGI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GNGMGEDHMPL));
	}

	public virtual void CBOBIADFILJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GNGMGEDHMPL));
	}

	public virtual void OPKPLEGMOPI()
	{
		bool flag = SubscriptionManager.instance.trialSubscriptionUsed;
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP("ID_STATE_CONNECTINGTOSERVER").Value2;
		UILabel obj = mHints[0];
		object[] array = new object[0];
		array[0] = value;
		obj.text = Localization.LocalizeFormat("114 STAGE 4 SPAWN 2 DONE", array);
		mHints[1].text = Localization.Localize("0.0.0");
		mHints[8].text = Localization.Localize((!flag) ? "DemotedPlayerId" : "x0");
		mHints[5].text = Localization.Localize("Player_Avoided_Grenade_On_First_Try");
		mHints[7].text = Localization.Localize("Squad icon: {0} already displayed");
		float num = 946f;
		for (int i = 0; i < mHints.Length; i++)
		{
			mHints[i].transform.parent.localPosition = mHints[i].transform.parent.localPosition.ReplaceY(num);
			num -= mHints[i].relativeSize.y * mHints[i].transform.localScale.y + 94f;
		}
	}

	private void BHFAGCAKPNM(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void MNPEAFHFMNA(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void NEBDMLHMLBC()
	{
		BCPDBCJHMKM(mBottomButton);
	}

	public virtual void KHDFKEINFCJ()
	{
		BCPDBCJHMKM(mBottomButton);
	}

	public virtual void LFBAOBONBKH()
	{
		INHNMIDHLBI(mBottomButton);
	}

	public virtual void DNFPEBEDLIG()
	{
		bool flag = !SubscriptionManager.instance.trialSubscriptionUsed;
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP("HighLevel").Value2;
		UILabel obj = mHints[1];
		object[] array = new object[1];
		array[1] = value;
		obj.text = Localization.LocalizeFormat("ID_CONFIRM_DOGTAGSAREFULL", array);
		mHints[0].text = Localization.Localize("ID_GUI_EQUIPPED");
		mHints[8].text = Localization.Localize((!flag) ? "Enemies Freezed" : "HeroicReward");
		mHints[3].text = Localization.Localize("damage");
		mHints[4].text = Localization.Localize("LevelManager: Awake");
		float num = 350f;
		for (int i = 1; i < mHints.Length; i++)
		{
			mHints[i].transform.parent.localPosition = mHints[i].transform.parent.localPosition.ReplaceY(num);
			num -= mHints[i].relativeSize.y * mHints[i].transform.localScale.y + 1640f;
		}
	}

	public override void InitGUIValues()
	{
		bool flag = !SubscriptionManager.instance.trialSubscriptionUsed;
		string value = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP("subscription1").Value2;
		mHints[0].text = Localization.LocalizeFormat("ID_SUBSCRIPTIODETAILS_HINT1", value);
		mHints[1].text = Localization.Localize("ID_SUBSCRIPTIODETAILS_HINT2");
		mHints[2].text = Localization.Localize((!flag) ? "ID_SUBSCRIPTIODETAILS_HINT3GOOGLE" : "ID_SUBSCRIPTIODETAILS_HINT3TRAILGOOGLE");
		mHints[3].text = Localization.Localize("ID_SUBSCRIPTIODETAILS_HINT4");
		mHints[4].text = Localization.Localize("ID_SUBSCRIPTIODETAILS_HINT5");
		float num = 0f;
		for (int i = 0; i < mHints.Length; i++)
		{
			mHints[i].transform.parent.localPosition = mHints[i].transform.parent.localPosition.ReplaceY(num);
			num -= mHints[i].relativeSize.y * mHints[i].transform.localScale.y + 30f;
		}
	}

	public virtual void INMFKHJDBIP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BCPDBCJHMKM));
	}

	public virtual void LPFPAKGNNIO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MMGIJGLLMAE));
	}

	private void MMGIJGLLMAE(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void IINOAOIFBFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EJHNEPNHOCP));
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public GuiElement DDIIHKEFFNA()
	{
		return this;
	}

	public virtual void HCGDNLHIOBL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EJHNEPNHOCP));
	}

	private void HMBKHPIKDII(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public GuiElement LFCHFGHMIGD()
	{
		return this;
	}

	public GuiElement DGJNMDEGIPD()
	{
		return this;
	}

	private void INNANKPAMCF(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public GuiElement IBINMECCCLH()
	{
		return this;
	}

	public virtual void PANHEDPIJHD()
	{
		MMGIJGLLMAE(mBottomButton);
	}

	public GuiElement PCOOANHLKKH()
	{
		return this;
	}
}
