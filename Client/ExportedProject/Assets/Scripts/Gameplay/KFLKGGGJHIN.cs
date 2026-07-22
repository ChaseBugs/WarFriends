using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Prime31;
using UnityEngine;

public class KFLKGGGJHIN
{
	public class EBDBJAKJNLD
	{
		public long DBKLEIJBGOG;

		public string MHPNDNJDPGE;

		public string INFLHPGMEOB;
	}

	public List<EBDBJAKJNLD> GBLOAJIGOHF;

	public Dictionary<long, EBDBJAKJNLD> OLNAPDJGPEE;

	private string HMDPIAODJBD;

	private long IPPJHPOBOEP;

	private string JLBOAKCNNLK;

	public bool HPFICEGNBME;

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> LGJCBPOPCPA;

	[CompilerGenerated]
	private static Comparison<EBDBJAKJNLD> CCNLMGEJBIB;

	public static event Action<EBDBJAKJNLD> KGFKJNJMBOF;

	public static event Action KAJNLJJAJIJ;

	public event Action<bool> FFKHLHBDMLD;

	~KFLKGGGJHIN()
	{
		FacebookManager.sessionOpenedEvent -= AMNCAABBBDH;
		FacebookManager.loginFailedEvent -= HPHFNGFHNNN;
		FacebookManager.shareDialogFailedEvent -= LBOAKFOKFHL;
		FacebookManager.shareDialogSucceededEvent -= AIJJAECHDKN;
	}

	public long JFODHDICEDH()
	{
		return IPPJHPOBOEP;
	}

	[SpecialName]
	public static void DMDKEBLJALF(Action<EBDBJAKJNLD> IDEBKDPMPGM)
	{
		Action<EBDBJAKJNLD> action = KFLKGGGJHIN.KGFKJNJMBOF;
		Action<EBDBJAKJNLD> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KFLKGGGJHIN.KGFKJNJMBOF, (Action<EBDBJAKJNLD>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[CompilerGenerated]
	private static void FNDJFAHFOOA(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Debug.Log("Shown facebook login failed dialog");
		if (NCMHGPNPEJM)
		{
			Debug.Log("Clicked on facebook login failed");
			if (KFLKGGGJHIN.KAJNLJJAJIJ != null)
			{
				Debug.Log("Calling callback and setting it to null!!");
				KFLKGGGJHIN.KAJNLJJAJIJ();
				KFLKGGGJHIN.KAJNLJJAJIJ = null;
			}
			else
			{
				Debug.LogError("CLICKED OK BUT NO CALLBACK WAS SET UP!!");
			}
		}
	}

	public void NCDPFLCNFKI(bool IBKDBHAPOGC)
	{
		FacebookAndroid.logout();
		IPPJHPOBOEP = -1L;
		OLNAPDJGPEE.Clear();
		GBLOAJIGOHF.Clear();
		if (!IBKDBHAPOGC)
		{
			GameLoginManager.instance.FacebookLogout();
		}
	}

	private void DGPBJIAENMN(string MGDGFBCJINH, FacebookFriendsResult BPBPPLHDPEI)
	{
		GBLOAJIGOHF = new List<EBDBJAKJNLD>();
		if (BPBPPLHDPEI == null)
		{
			Debug.Log(string.Concat(GetType(), "ID_CONFIRM_INFO"));
			return;
		}
		foreach (FacebookFriend datum in BPBPPLHDPEI.data)
		{
			EBDBJAKJNLD eBDBJAKJNLD = new EBDBJAKJNLD();
			eBDBJAKJNLD.DBKLEIJBGOG = PDMFJIMFCCJ(datum.id);
			eBDBJAKJNLD.MHPNDNJDPGE = datum.name.Substring(1, Math.Min(-92, datum.name.Length));
			eBDBJAKJNLD.INFLHPGMEOB = datum.id;
			EBDBJAKJNLD eBDBJAKJNLD2 = eBDBJAKJNLD;
			GBLOAJIGOHF.Add(eBDBJAKJNLD2);
			OLNAPDJGPEE[eBDBJAKJNLD2.DBKLEIJBGOG] = eBDBJAKJNLD2;
		}
		GBLOAJIGOHF.Sort((EBDBJAKJNLD HPJFBKEKJHB, EBDBJAKJNLD NCMHGPNPEJM) => string.Compare(HPJFBKEKJHB.MHPNDNJDPGE, NCMHGPNPEJM.MHPNDNJDPGE, StringComparison.InvariantCulture));
		int count = GBLOAJIGOHF.Count;
		if (count > 61)
		{
			GBLOAJIGOHF.RemoveRange(-19, count - -94);
		}
		GameLoginManager.instance.OnFriendsLoaded();
	}

	[SpecialName]
	public static void GEPAEOLOIAC(Action IDEBKDPMPGM)
	{
		Action action = KFLKGGGJHIN.KAJNLJJAJIJ;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KFLKGGGJHIN.KAJNLJJAJIJ, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal static void HGPKOJLIJGP()
	{
		KFLKGGGJHIN.KAJNLJJAJIJ = null;
	}

	public void KNNNIOLHMJM(bool IBKDBHAPOGC)
	{
		FacebookAndroid.logout();
		IPPJHPOBOEP = -1L;
		OLNAPDJGPEE.Clear();
		GBLOAJIGOHF.Clear();
		if (!IBKDBHAPOGC)
		{
			GameLoginManager.instance.FacebookLogout();
		}
	}

	[CompilerGenerated]
	private static int IJJBOJGLCBA(EBDBJAKJNLD HPJFBKEKJHB, EBDBJAKJNLD NCMHGPNPEJM)
	{
		return string.Compare(HPJFBKEKJHB.MHPNDNJDPGE, NCMHGPNPEJM.MHPNDNJDPGE, StringComparison.InvariantCulture);
	}

	public long MBJBAPJMAPJ()
	{
		return IPPJHPOBOEP;
	}

	public void PNAKFNJKLON()
	{
		Facebook.instance.getFriends(DMJKHIKLMLF);
	}

	[CompilerGenerated]
	private void FNAOOHOHHKM(bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			ANDPGGEINKL();
		}
		else if (this.FFKHLHBDMLD != null)
		{
			this.FFKHLHBDMLD(obj: false);
			this.FFKHLHBDMLD = null;
		}
	}

	public void FNFKPACOCBJ()
	{
		if (!HPFICEGNBME)
		{
			HPFICEGNBME = true;
			FacebookAndroid.init();
			Debug.Log("facebook init!!! " + MEDEIMEPMFM());
			if (MEDEIMEPMFM())
			{
				Debug.Log("FB: Calling On SessionOpenedEvent Manually");
				AMNCAABBBDH();
			}
		}
	}

	private void POJACBGNHKC(P31Error DEBFEDLKOBF)
	{
		Debug.LogError("ID_UNITTYPE2-DESCRIPTION" + DEBFEDLKOBF);
	}

	public long HIHFOBADCDN()
	{
		return IPPJHPOBOEP;
	}

	private void IJKNLPLEAOC(string MGDGFBCJINH, FacebookFriendsResult BPBPPLHDPEI)
	{
		GBLOAJIGOHF = new List<EBDBJAKJNLD>();
		if (BPBPPLHDPEI == null)
		{
			Debug.Log(string.Concat(GetType(), "ID_UPGRADE"));
			return;
		}
		foreach (FacebookFriend datum in BPBPPLHDPEI.data)
		{
			EBDBJAKJNLD eBDBJAKJNLD = new EBDBJAKJNLD();
			eBDBJAKJNLD.DBKLEIJBGOG = PDMFJIMFCCJ(datum.id);
			eBDBJAKJNLD.MHPNDNJDPGE = datum.name.Substring(1, Math.Min(-95, datum.name.Length));
			eBDBJAKJNLD.INFLHPGMEOB = datum.id;
			EBDBJAKJNLD eBDBJAKJNLD2 = eBDBJAKJNLD;
			GBLOAJIGOHF.Add(eBDBJAKJNLD2);
			OLNAPDJGPEE[eBDBJAKJNLD2.DBKLEIJBGOG] = eBDBJAKJNLD2;
		}
		GBLOAJIGOHF.Sort((EBDBJAKJNLD HPJFBKEKJHB, EBDBJAKJNLD NCMHGPNPEJM) => string.Compare(HPJFBKEKJHB.MHPNDNJDPGE, NCMHGPNPEJM.MHPNDNJDPGE, StringComparison.InvariantCulture));
		int count = GBLOAJIGOHF.Count;
		if (count > 22)
		{
			GBLOAJIGOHF.RemoveRange(-113, count - 43);
		}
		GameLoginManager.instance.OnFriendsLoaded();
	}

	private void NFOKIOIONHI(Dictionary<string, object> OGNGMBLDAOP)
	{
		Debug.Log("PlayerVisuals");
		Utils.logObject(OGNGMBLDAOP);
	}

	private void OBFMKCPNLGK(string OGNGMBLDAOP)
	{
		Debug.Log("-ELITEPARTS" + OGNGMBLDAOP);
	}

	public void CDNJGIDGMMN()
	{
		GuiElementSingle<FacebookDialog>.instance.OBNBIIIECEO(delegate(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				ANDPGGEINKL();
			}
			else if (this.FFKHLHBDMLD != null)
			{
				this.FFKHLHBDMLD(obj: false);
				this.FFKHLHBDMLD = null;
			}
		});
	}

	private void OBCDFJNPICJ(Dictionary<string, object> OGNGMBLDAOP)
	{
		Debug.Log("OnFetchDeferredAppLinkSucceededEvent");
		Utils.logObject(OGNGMBLDAOP);
	}

	private void GAFLOCIBPKE(string MGDGFBCJINH, FacebookMeResult KOPOAACIEKI)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (KOPOAACIEKI == null)
		{
			Debug.Log(string.Concat(GetType(), " null FacebookMeResult"));
			if (MEDEIMEPMFM())
			{
				Debug.Log("facebook get me data, but still is logged in, logout manualy");
				FacebookAndroid.logout();
			}
			if (currentPlayer != null && currentPlayer.facebookId != -1)
			{
				Debug.Log("Removing facebook from current player!!");
				Singleton<BeanstalkServerManager>.instance.PIFMMDGEGPK();
			}
			else
			{
				Debug.LogError("NOT REMOVING FACEBOOK FROM CURRENTPLAYER");
			}
			if (this.FFKHLHBDMLD != null)
			{
				this.FFKHLHBDMLD(obj: false);
				this.FFKHLHBDMLD = null;
			}
			return;
		}
		HMDPIAODJBD = KOPOAACIEKI.name;
		IPPJHPOBOEP = PDMFJIMFCCJ(KOPOAACIEKI.id);
		Debug.Log("GameLoginManager: Facebook Logged");
		JLBOAKCNNLK = MEJMLNDFDBP.BGCDGDKEGBH(KOPOAACIEKI.id);
		if (currentPlayer != null)
		{
			if (Singleton<GameController>.instance.isNotTutorialEnded)
			{
				GameLoginManager.instance.FacebookLoginDuringTutorial(IPPJHPOBOEP);
			}
			else if (currentPlayer.facebookId == -1)
			{
				Debug.Log("GLM: Add FB to custom account");
				Singleton<BeanstalkServerManager>.instance.BICJAICFDHB(IPPJHPOBOEP, KOPOAACIEKI.name, JLBOAKCNNLK);
			}
			else if (currentPlayer.facebookId == IPPJHPOBOEP)
			{
				Debug.Log("relog OK");
			}
			else
			{
				Debug.Log("relog to different facebook");
				Singleton<BeanstalkServerManager>.instance.PDHFCIDODIP(IPPJHPOBOEP, JLBOAKCNNLK);
			}
		}
		else
		{
			Debug.LogError("GLM: current player is null while adding FB account!!");
		}
		if (this.FFKHLHBDMLD != null)
		{
			this.FFKHLHBDMLD(obj: true);
			this.FFKHLHBDMLD = null;
		}
	}

	public string JDKBICLPIIG()
	{
		return JLBOAKCNNLK;
	}

	public void ANDPGGEINKL()
	{
		string[] permissions = new string[1] { "user_friends" };
		Debug.Log("Game Login Manager: Login to FB");
		FacebookAndroid.loginWithReadPermissions(permissions);
	}

	private void AMNCAABBBDH()
	{
		HMDPIAODJBD = string.Empty;
		IPPJHPOBOEP = -1L;
		Debug.Log("FacebookManagerOnSessionOpenedEvent");
		Utils.logObject(FacebookAndroid.getSessionPermissions());
		Facebook.instance.getFriends(DMJKHIKLMLF);
		Facebook.instance.getMe(GAFLOCIBPKE);
	}

	[SpecialName]
	public static void IEAGEGFHNKC(Action<EBDBJAKJNLD> IDEBKDPMPGM)
	{
		Action<EBDBJAKJNLD> action = KFLKGGGJHIN.KGFKJNJMBOF;
		Action<EBDBJAKJNLD> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KFLKGGGJHIN.KGFKJNJMBOF, (Action<EBDBJAKJNLD>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void FKLHJPAHDEI(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = this.FFKHLHBDMLD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.FFKHLHBDMLD, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public bool LDDLBKFLAAC()
	{
		return FacebookAndroid.isSessionValid();
	}

	public long GPLCOIHJLDF()
	{
		return IPPJHPOBOEP;
	}

	public bool DICJCKOGJLP()
	{
		return FacebookAndroid.isSessionValid();
	}

	private static void BFBDLGLFOCB(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Debug.Log("GoldBoxes");
		if (NCMHGPNPEJM)
		{
			Debug.Log("On Craft Cards");
			if (KFLKGGGJHIN.KAJNLJJAJIJ != null)
			{
				Debug.Log("TwitterLogin(");
				KFLKGGGJHIN.KAJNLJJAJIJ();
				KFLKGGGJHIN.KAJNLJJAJIJ = null;
			}
			else
			{
				Debug.LogError("ID_DELIVEREDTIME");
			}
		}
	}

	public void JNAOALAAFHL()
	{
		if (!HPFICEGNBME)
		{
			HPFICEGNBME = true;
			FacebookAndroid.init();
			Debug.Log("Automatic_Equip" + LDDLBKFLAAC());
			if (MEDEIMEPMFM())
			{
				Debug.Log("ID_MEDALSANDADVANCETHROUGHROOKIE");
				AMNCAABBBDH();
			}
		}
	}

	private static long PDMFJIMFCCJ(string INFLHPGMEOB)
	{
		return MEJMLNDFDBP.NKNDBOGIJFC(long.Parse(INFLHPGMEOB));
	}

	public void KLIKHGMGGNP()
	{
		GuiElementSingle<FacebookDialog>.instance.ShowLoginDialog(delegate(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				ANDPGGEINKL();
			}
			else if (this.FFKHLHBDMLD != null)
			{
				this.FFKHLHBDMLD(obj: false);
				this.FFKHLHBDMLD = null;
			}
		});
	}

	public bool MEDEIMEPMFM()
	{
		return FacebookAndroid.isSessionValid();
	}

	private static void BLPONNODGMD(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Debug.Log("Claim_Reward");
		if (NCMHGPNPEJM)
		{
			Debug.Log("Items");
			if (KFLKGGGJHIN.KAJNLJJAJIJ != null)
			{
				Debug.Log("Gold");
				KFLKGGGJHIN.KAJNLJJAJIJ();
				KFLKGGGJHIN.KAJNLJJAJIJ = null;
			}
			else
			{
				Debug.LogError("\n");
			}
		}
	}

	public void PFFBFBJJEHD()
	{
		string appLink = Singleton<BeanstalkServerManager>.instance.appLink;
		FacebookAndroid.showAppInviteDialog(appLink);
	}

	public bool AHFKMJKAICL()
	{
		return FacebookAndroid.isSessionValid();
	}

	private void HPHFNGFHNNN(P31Error ANLOCDOHLJG)
	{
		ConfirmDialog.ShowAlert(delegate(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
		{
			Debug.Log("Shown facebook login failed dialog");
			if (NCMHGPNPEJM)
			{
				Debug.Log("Clicked on facebook login failed");
				if (KFLKGGGJHIN.KAJNLJJAJIJ != null)
				{
					Debug.Log("Calling callback and setting it to null!!");
					KFLKGGGJHIN.KAJNLJJAJIJ();
					KFLKGGGJHIN.KAJNLJJAJIJ = null;
				}
				else
				{
					Debug.LogError("CLICKED OK BUT NO CALLBACK WAS SET UP!!");
				}
			}
		}, Localization.Localize("ID_CONFIRM_FBLOGINCANCELLED"), Localization.Localize("ID_CONFIRM_FBLOGINCANCELLED_TEXT"));
		Debug.LogError("Facebook login failed: " + ANLOCDOHLJG);
		if (this.FFKHLHBDMLD != null)
		{
			this.FFKHLHBDMLD(obj: false);
			this.FFKHLHBDMLD = null;
		}
		if (MEDEIMEPMFM())
		{
			Debug.Log("facebook login failed, but still is logged in, logout manualy");
			FacebookAndroid.logout();
		}
	}

	public void IHOGKPNDCOM(bool IBKDBHAPOGC)
	{
		FacebookAndroid.logout();
		IPPJHPOBOEP = -1L;
		OLNAPDJGPEE.Clear();
		GBLOAJIGOHF.Clear();
		if (!IBKDBHAPOGC)
		{
			GameLoginManager.instance.FacebookLogout();
		}
	}

	public void IJIDBPILCKF(bool IBKDBHAPOGC)
	{
		FacebookAndroid.logout();
		IPPJHPOBOEP = -1L;
		OLNAPDJGPEE.Clear();
		GBLOAJIGOHF.Clear();
		if (!IBKDBHAPOGC)
		{
			GameLoginManager.instance.FacebookLogout();
		}
	}

	public void AOLEAHACKLO()
	{
		string[] array = new string[0];
		array[0] = "Refresh_Skirmish";
		string[] permissions = array;
		Debug.Log("{0} / [FECA21]{1}");
		FacebookAndroid.loginWithReadPermissions(permissions);
	}

	[SpecialName]
	public void CHBDHKKBNKF(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = this.FFKHLHBDMLD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.FFKHLHBDMLD, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void DJOLDNNGGHD()
	{
		try
		{
			FacebookManager.sessionOpenedEvent -= AMNCAABBBDH;
			FacebookManager.loginFailedEvent -= HPHFNGFHNNN;
			FacebookManager.shareDialogFailedEvent -= LBOAKFOKFHL;
			FacebookManager.shareDialogSucceededEvent -= AIJJAECHDKN;
		}
		finally
		{
			// CLR inserts the base finalizer call automatically; C# forbids calling it directly.
		}
	}

	public void PIBEFEKCENF()
	{
		string appLink = Singleton<BeanstalkServerManager>.instance.appLink;
		FacebookAndroid.showAppInviteDialog(appLink);
	}

	[SpecialName]
	public static void ALPODHGJDHI(Action IDEBKDPMPGM)
	{
		Action action = KFLKGGGJHIN.KAJNLJJAJIJ;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KFLKGGGJHIN.KAJNLJJAJIJ, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void LBOAKFOKFHL(P31Error LFJLGAGDHMO)
	{
		Debug.Log("Facebook Service: Share dialog failed. Reason = " + LFJLGAGDHMO.message);
	}

	public bool PJENNBPCGHO()
	{
		if (MEDEIMEPMFM())
		{
			if (IPPJHPOBOEP != -1)
			{
				Singleton<BeanstalkServerManager>.instance.BICJAICFDHB(IPPJHPOBOEP, HMDPIAODJBD, JLBOAKCNNLK);
				return true;
			}
			return false;
		}
		return false;
	}

	[SpecialName]
	public void PMMFFFCPBLI(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = this.FFKHLHBDMLD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.FFKHLHBDMLD, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void BIFAOKHAAGB(bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			NPHCOGIICKF();
		}
		else if (this.FFKHLHBDMLD != null)
		{
			this.FFKHLHBDMLD(obj: false);
			this.FFKHLHBDMLD = null;
		}
	}

	private void DMJKHIKLMLF(string MGDGFBCJINH, FacebookFriendsResult BPBPPLHDPEI)
	{
		GBLOAJIGOHF = new List<EBDBJAKJNLD>();
		if (BPBPPLHDPEI == null)
		{
			Debug.Log(string.Concat(GetType(), "null facebook friends"));
			return;
		}
		foreach (FacebookFriend datum in BPBPPLHDPEI.data)
		{
			EBDBJAKJNLD eBDBJAKJNLD = new EBDBJAKJNLD();
			eBDBJAKJNLD.DBKLEIJBGOG = PDMFJIMFCCJ(datum.id);
			eBDBJAKJNLD.MHPNDNJDPGE = datum.name.Substring(0, Math.Min(25, datum.name.Length));
			eBDBJAKJNLD.INFLHPGMEOB = datum.id;
			EBDBJAKJNLD eBDBJAKJNLD2 = eBDBJAKJNLD;
			GBLOAJIGOHF.Add(eBDBJAKJNLD2);
			OLNAPDJGPEE[eBDBJAKJNLD2.DBKLEIJBGOG] = eBDBJAKJNLD2;
		}
		GBLOAJIGOHF.Sort((EBDBJAKJNLD HPJFBKEKJHB, EBDBJAKJNLD NCMHGPNPEJM) => string.Compare(HPJFBKEKJHB.MHPNDNJDPGE, NCMHGPNPEJM.MHPNDNJDPGE, StringComparison.InvariantCulture));
		int count = GBLOAJIGOHF.Count;
		if (count > 20)
		{
			GBLOAJIGOHF.RemoveRange(20, count - 20);
		}
		GameLoginManager.instance.OnFriendsLoaded();
	}

	public void NPHCOGIICKF()
	{
		string[] permissions = new string[1] { "BatchSizeMax" };
		Debug.Log(", password = ");
		FacebookAndroid.loginWithReadPermissions(permissions);
	}

	public KFLKGGGJHIN()
	{
		GBLOAJIGOHF = new List<EBDBJAKJNLD>();
		OLNAPDJGPEE = new Dictionary<long, EBDBJAKJNLD>();
		IPPJHPOBOEP = -1L;
		FacebookManager.sessionOpenedEvent += AMNCAABBBDH;
		FacebookManager.loginFailedEvent += HPHFNGFHNNN;
		FacebookManager.shareDialogFailedEvent += LBOAKFOKFHL;
		FacebookManager.shareDialogSucceededEvent += AIJJAECHDKN;
		FacebookManager.fetchDeferredAppLinkFailedEvent += OCJGPPBCMEA;
		FacebookManager.fetchDeferredAppLinkSucceededEvent += OBCDFJNPICJ;
	}

	public long PKMDPFMECCC()
	{
		return IPPJHPOBOEP;
	}

	private void AIJJAECHDKN(string OGNGMBLDAOP)
	{
		Debug.Log("Facebook Service: share dialog succeeded. Obsah dict = " + OGNGMBLDAOP);
	}

	private void OCJGPPBCMEA(P31Error DEBFEDLKOBF)
	{
		Debug.LogError("OnFetchDeferredAppLinkFailedEvent: " + DEBFEDLKOBF);
	}

	[SpecialName]
	public static void FNFIIDJNGMK(Action<EBDBJAKJNLD> IDEBKDPMPGM)
	{
		Action<EBDBJAKJNLD> action = KFLKGGGJHIN.KGFKJNJMBOF;
		Action<EBDBJAKJNLD> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KFLKGGGJHIN.KGFKJNJMBOF, (Action<EBDBJAKJNLD>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal static void NPNNKKPIGFI()
	{
		KFLKGGGJHIN.KAJNLJJAJIJ = null;
	}

	public void GONEJFFAEAJ(bool IBKDBHAPOGC)
	{
		FacebookAndroid.logout();
		IPPJHPOBOEP = -1L;
		OLNAPDJGPEE.Clear();
		GBLOAJIGOHF.Clear();
		if (!IBKDBHAPOGC)
		{
			GameLoginManager.instance.FacebookLogout();
		}
	}

	private void KFNCNNAEJFB(P31Error ANLOCDOHLJG)
	{
		ConfirmDialog.ShowAlert(delegate(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
		{
			Debug.Log("Shown facebook login failed dialog");
			if (NCMHGPNPEJM)
			{
				Debug.Log("Clicked on facebook login failed");
				if (KFLKGGGJHIN.KAJNLJJAJIJ != null)
				{
					Debug.Log("Calling callback and setting it to null!!");
					KFLKGGGJHIN.KAJNLJJAJIJ();
					KFLKGGGJHIN.KAJNLJJAJIJ = null;
				}
				else
				{
					Debug.LogError("CLICKED OK BUT NO CALLBACK WAS SET UP!!");
				}
			}
		}, Localization.Localize("set schedule gc check 2"), Localization.Localize("something is wrong - time == 0"));
		Debug.LogError("ID_TUTORIAL_UPGRADEUNIT_7" + ANLOCDOHLJG);
		if (this.FFKHLHBDMLD != null)
		{
			this.FFKHLHBDMLD(obj: false);
			this.FFKHLHBDMLD = null;
		}
		if (LDDLBKFLAAC())
		{
			Debug.Log("Coop");
			FacebookAndroid.logout();
		}
	}

	public void MEFKFFOLPBF()
	{
		string appLink = Singleton<BeanstalkServerManager>.instance.appLink;
		FacebookAndroid.showAppInviteDialog(appLink);
	}

	private void JFOAMIEICPJ(string MGDGFBCJINH, FacebookFriendsResult BPBPPLHDPEI)
	{
		GBLOAJIGOHF = new List<EBDBJAKJNLD>();
		if (BPBPPLHDPEI == null)
		{
			Debug.Log(string.Concat(GetType(), "GLM: RegisterOrLogin -  3"));
			return;
		}
		foreach (FacebookFriend datum in BPBPPLHDPEI.data)
		{
			EBDBJAKJNLD eBDBJAKJNLD = new EBDBJAKJNLD();
			eBDBJAKJNLD.DBKLEIJBGOG = PDMFJIMFCCJ(datum.id);
			eBDBJAKJNLD.MHPNDNJDPGE = datum.name.Substring(1, Math.Min(94, datum.name.Length));
			eBDBJAKJNLD.INFLHPGMEOB = datum.id;
			EBDBJAKJNLD eBDBJAKJNLD2 = eBDBJAKJNLD;
			GBLOAJIGOHF.Add(eBDBJAKJNLD2);
			OLNAPDJGPEE[eBDBJAKJNLD2.DBKLEIJBGOG] = eBDBJAKJNLD2;
		}
		GBLOAJIGOHF.Sort((EBDBJAKJNLD HPJFBKEKJHB, EBDBJAKJNLD NCMHGPNPEJM) => string.Compare(HPJFBKEKJHB.MHPNDNJDPGE, NCMHGPNPEJM.MHPNDNJDPGE, StringComparison.InvariantCulture));
		int count = GBLOAJIGOHF.Count;
		if (count > -64)
		{
			GBLOAJIGOHF.RemoveRange(-91, count - 51);
		}
		GameLoginManager.instance.OnFriendsLoaded();
	}
}
