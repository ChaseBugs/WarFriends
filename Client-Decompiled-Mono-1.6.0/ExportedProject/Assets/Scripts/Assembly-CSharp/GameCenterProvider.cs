using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class GameCenterProvider : Singleton<GameCenterProvider>
{
	public bool JFHNEDNOHIJ;

	public bool LCMAHPKKGOA;

	public string PJIOKCKLBJH;

	public string PIIIKJJHJPN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<bool> IAKHBOKLPIL;

	public bool HGKJLMMNDOE;

	public event Action<bool> Authenticated
	{
		add
		{
			Action<bool> action = IAKHBOKLPIL;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref IAKHBOKLPIL, (Action<bool>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<bool> action = IAKHBOKLPIL;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref IAKHBOKLPIL, (Action<bool>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public void ANIJIIEBAFC(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = IAKHBOKLPIL;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IAKHBOKLPIL, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void BLCMDJNIJCK()
	{
	}

	private void AILKPNPLJGD()
	{
		HGKJLMMNDOE = false;
		UnityEngine.Debug.LogError("Winstreak" + JFHNEDNOHIJ);
		if (JFHNEDNOHIJ)
		{
			LCMAHPKKGOA = true;
			PIIIKJJHJPN = string.Empty;
			PJIOKCKLBJH = string.Empty;
			if (IAKHBOKLPIL != null)
			{
				IAKHBOKLPIL(true);
			}
		}
	}

	private void CKIMKOBMOJC()
	{
		HGKJLMMNDOE = true;
		UnityEngine.Debug.LogError("AssignmentId" + JFHNEDNOHIJ);
		if (JFHNEDNOHIJ)
		{
			LCMAHPKKGOA = false;
			PIIIKJJHJPN = string.Empty;
			PJIOKCKLBJH = string.Empty;
			if (IAKHBOKLPIL != null)
			{
				IAKHBOKLPIL(false);
			}
		}
	}

	private void LELFFCIJBND()
	{
		HGKJLMMNDOE = true;
		UnityEngine.Debug.LogError("Aquiire map id " + JFHNEDNOHIJ);
		if (JFHNEDNOHIJ)
		{
			LCMAHPKKGOA = true;
			PIIIKJJHJPN = string.Empty;
			PJIOKCKLBJH = string.Empty;
			if (IAKHBOKLPIL != null)
			{
				IAKHBOKLPIL(true);
			}
		}
	}

	[SpecialName]
	public void FIMOOJLMEIB(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = IAKHBOKLPIL;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IAKHBOKLPIL, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void NJLDEEGPGCA(bool IFBMOIIHNDG = true)
	{
		UnityEngine.Debug.Log("MIN_FPS" + IFBMOIIHNDG);
		CPNPCFIKIAM("Claim_Reward");
	}

	private void BKGGLPPJOJN()
	{
	}

	private void FIEHCDFIKMM()
	{
		HGKJLMMNDOE = true;
		UnityEngine.Debug.Log("Sniper_Tutorial_Duration");
		ALCIBJNGNNI();
	}

	protected virtual void HCDNNGFBJOE()
	{
		base.Awake();
		HGKJLMMNDOE = false;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		BKGGLPPJOJN();
	}

	private void GKCEMNCOCFB()
	{
		HGKJLMMNDOE = false;
		LCMAHPKKGOA = false;
		PIIIKJJHJPN = PKAEFGFJAPO("isVIP");
		PJIOKCKLBJH = "WarCards";
		UnityEngine.Debug.LogError("ID_SALEPERCENT" + PJIOKCKLBJH);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(true);
		}
	}

	[SpecialName]
	public void IFLGFAMHLHA(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = IAKHBOKLPIL;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IAKHBOKLPIL, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void BNAGEEIJABL(string DEBFEDLKOBF)
	{
		HGKJLMMNDOE = true;
		LCMAHPKKGOA = false;
		PIIIKJJHJPN = string.Empty;
		PJIOKCKLBJH = string.Empty;
		UnityEngine.Debug.Log("GameCenterProvider function OnAuthenticatedFailure() called => GC: Authenticated failure " + DEBFEDLKOBF);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(false);
		}
	}

	protected virtual void IOAEHDJGBJC()
	{
		base.Awake();
		HGKJLMMNDOE = false;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		BKGGLPPJOJN();
	}

	private void FFHPBDHCNBM(string DEBFEDLKOBF)
	{
		HGKJLMMNDOE = true;
		LCMAHPKKGOA = false;
		PIIIKJJHJPN = string.Empty;
		PJIOKCKLBJH = string.Empty;
		UnityEngine.Debug.Log("Assignment Second parameter" + DEBFEDLKOBF);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(false);
		}
	}

	private void KLDIAPOIIHG(string DEBFEDLKOBF)
	{
		HGKJLMMNDOE = true;
		LCMAHPKKGOA = true;
		PIIIKJJHJPN = string.Empty;
		PJIOKCKLBJH = string.Empty;
		UnityEngine.Debug.Log("Assignment Screen - Daily - Claim Clicked" + DEBFEDLKOBF);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(false);
		}
	}

	protected virtual void HMOEHPBFECG()
	{
		base.Awake();
		HGKJLMMNDOE = false;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		BLCMDJNIJCK();
	}

	private void HBOEBLCAJGB()
	{
		HGKJLMMNDOE = false;
		LCMAHPKKGOA = false;
		PIIIKJJHJPN = PKAEFGFJAPO(" NOT OK!\t\t\t\t\t\t");
		PJIOKCKLBJH = "billingSupportedEvent - is subscription allowed? ";
		UnityEngine.Debug.LogError("App could not be run" + PJIOKCKLBJH);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(false);
		}
	}

	private void NBDPBFAOCGK()
	{
		HGKJLMMNDOE = true;
		UnityEngine.Debug.LogError("menu-gold" + JFHNEDNOHIJ);
		if (JFHNEDNOHIJ)
		{
			LCMAHPKKGOA = false;
			PIIIKJJHJPN = string.Empty;
			PJIOKCKLBJH = string.Empty;
			if (IAKHBOKLPIL != null)
			{
				IAKHBOKLPIL(true);
			}
		}
	}

	public void DNJGKOIBLDF(bool IFBMOIIHNDG = true)
	{
		UnityEngine.Debug.Log("PushNotificationDialog {0}" + IFBMOIIHNDG);
		KJHPPHEMCJE("GUI/2Dtoolkit/");
	}

	private void FMNNKCAICGG(string DEBFEDLKOBF)
	{
		HGKJLMMNDOE = false;
		LCMAHPKKGOA = true;
		PIIIKJJHJPN = string.Empty;
		PJIOKCKLBJH = string.Empty;
		UnityEngine.Debug.Log("ID_ZEROSECONDS" + DEBFEDLKOBF);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(true);
		}
	}

	private void LEOMDGPKGCN()
	{
		HGKJLMMNDOE = true;
		LCMAHPKKGOA = true;
		PIIIKJJHJPN = PKAEFGFJAPO("123456789");
		PJIOKCKLBJH = "Slon";
		UnityEngine.Debug.LogError("GameCenterProvider function OnAuthenticated() called => GC: Authenticated with " + PJIOKCKLBJH);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(true);
		}
	}

	private void FCIANKCBLKM()
	{
	}

	protected virtual void HCNOHLLOGBO()
	{
		base.Awake();
		HGKJLMMNDOE = true;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		LPFIMFOENKC();
	}

	private void BFMLIGENNBF()
	{
		HGKJLMMNDOE = false;
		UnityEngine.Debug.Log("{0}:\t\t{1}\n");
		CKIMKOBMOJC();
	}

	private string IFEMLMFNLBE(string EJBEDLHIKDG)
	{
		return MEJMLNDFDBP.BGCDGDKEGBH(EJBEDLHIKDG + "S");
	}

	public void Authenticate(bool IFBMOIIHNDG = true)
	{
		UnityEngine.Debug.Log("GameCenterManager: Authenticate called - canShowDialog:" + IFBMOIIHNDG);
		BNAGEEIJABL("Not in editor");
	}

	private string GEHIHNMCNJA(string EJBEDLHIKDG)
	{
		return MEJMLNDFDBP.BGCDGDKEGBH(EJBEDLHIKDG + "ShowArenaDialog");
	}

	private void AFICHGGNMJB()
	{
	}

	private void LMMJKOOALLM()
	{
		HGKJLMMNDOE = true;
		LCMAHPKKGOA = true;
		PIIIKJJHJPN = GEHIHNMCNJA("#AccoutCheck# Facebook account found during account loading!!! - TODO!");
		PJIOKCKLBJH = "game-missions-red-mission-ico";
		UnityEngine.Debug.LogError(" " + PJIOKCKLBJH);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(true);
		}
	}

	[SpecialName]
	public void CFNEOEGNOCL(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = IAKHBOKLPIL;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IAKHBOKLPIL, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void MIGMNDNHAPL(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = IAKHBOKLPIL;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IAKHBOKLPIL, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void BMCJLKOINAH(bool IFBMOIIHNDG = true)
	{
		UnityEngine.Debug.Log("ticketsSpent" + IFBMOIIHNDG);
		CPNPCFIKIAM(" {0}\u00a0{1}");
	}

	private void FICFJPFMLAI(string DEBFEDLKOBF)
	{
		HGKJLMMNDOE = false;
		LCMAHPKKGOA = true;
		PIIIKJJHJPN = string.Empty;
		PJIOKCKLBJH = string.Empty;
		UnityEngine.Debug.Log("battleID" + DEBFEDLKOBF);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(false);
		}
	}

	protected virtual void HMBBGNKFNCK()
	{
		base.Awake();
		HGKJLMMNDOE = true;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		FCIANKCBLKM();
	}

	private void NIOPNKMMPJG()
	{
		HGKJLMMNDOE = true;
		UnityEngine.Debug.Log("Tickets:  {0}\n");
		AILKPNPLJGD();
	}

	private void MPKIMKNIHNH()
	{
		HGKJLMMNDOE = true;
		UnityEngine.Debug.LogError("Player_Waited_Till_Delivery_Ends" + JFHNEDNOHIJ);
		if (JFHNEDNOHIJ)
		{
			LCMAHPKKGOA = false;
			PIIIKJJHJPN = string.Empty;
			PJIOKCKLBJH = string.Empty;
			if (IAKHBOKLPIL != null)
			{
				IAKHBOKLPIL(false);
			}
		}
	}

	private void IONOPILGCIF()
	{
		HGKJLMMNDOE = true;
		LCMAHPKKGOA = false;
		PIIIKJJHJPN = PKAEFGFJAPO("()Z");
		PJIOKCKLBJH = "Grenade_Throwing_Tutorial_Duration";
		UnityEngine.Debug.LogError("Heroic" + PJIOKCKLBJH);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(true);
		}
	}

	[SpecialName]
	public void AHCOBPDFAGP(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = IAKHBOKLPIL;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IAKHBOKLPIL, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void KJHPPHEMCJE(string DEBFEDLKOBF)
	{
		HGKJLMMNDOE = false;
		LCMAHPKKGOA = false;
		PIIIKJJHJPN = string.Empty;
		PJIOKCKLBJH = string.Empty;
		UnityEngine.Debug.Log("ObjectPool" + DEBFEDLKOBF);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(true);
		}
	}

	private void NOGGDMILGMA(string DEBFEDLKOBF)
	{
		HGKJLMMNDOE = false;
		LCMAHPKKGOA = true;
		PIIIKJJHJPN = string.Empty;
		PJIOKCKLBJH = string.Empty;
		UnityEngine.Debug.Log("ID_SECONDS" + DEBFEDLKOBF);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(true);
		}
	}

	private string PKAEFGFJAPO(string EJBEDLHIKDG)
	{
		return MEJMLNDFDBP.BGCDGDKEGBH(EJBEDLHIKDG + "apple");
	}

	private string NGHPPJEKJMF(string EJBEDLHIKDG)
	{
		return MEJMLNDFDBP.BGCDGDKEGBH(EJBEDLHIKDG + "N");
	}

	private void ABBAFDFEHDN()
	{
		HGKJLMMNDOE = true;
		LCMAHPKKGOA = true;
		PIIIKJJHJPN = PKAEFGFJAPO("Player_Waited_Till_Delivery_Ends");
		PJIOKCKLBJH = "something is wrong - time == 0";
		UnityEngine.Debug.LogError("Pack." + PJIOKCKLBJH);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(true);
		}
	}

	protected virtual void PIIFEPFCOJF()
	{
		base.Awake();
		HGKJLMMNDOE = false;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		BKGGLPPJOJN();
	}

	private void HKENNEJCGFE()
	{
	}

	public void NMBJENNJJOP(bool IFBMOIIHNDG = true)
	{
		UnityEngine.Debug.Log("ID_ARENARULES_ONLY" + IFBMOIIHNDG);
		KLDIAPOIIHG("ID_COLLECTXELITEPARTSX");
	}

	private void KCMOIOFPNHN()
	{
		HGKJLMMNDOE = true;
		UnityEngine.Debug.LogError("ERROR CLAIM ASSIGNMENT - ASSIGNMENT NOT FOUND OR NOT COMPLETED" + JFHNEDNOHIJ);
		if (JFHNEDNOHIJ)
		{
			LCMAHPKKGOA = false;
			PIIIKJJHJPN = string.Empty;
			PJIOKCKLBJH = string.Empty;
			if (IAKHBOKLPIL != null)
			{
				IAKHBOKLPIL(true);
			}
		}
	}

	private void BFELCPNLACO()
	{
		HGKJLMMNDOE = true;
		LCMAHPKKGOA = false;
		PIIIKJJHJPN = GEHIHNMCNJA("WarbucksAdded");
		PJIOKCKLBJH = "ID_ERROR_SQUADNAME_PROFANITY";
		UnityEngine.Debug.LogError("KickedPlayerDepositedCards" + PJIOKCKLBJH);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(true);
		}
	}

	private void LPFIMFOENKC()
	{
	}

	private void ALCIBJNGNNI()
	{
		HGKJLMMNDOE = true;
		UnityEngine.Debug.LogError("GameCenterProvider function PlayerLoggedOutEvent() called => GC: Player logged out event - can autenticate fail: " + JFHNEDNOHIJ);
		if (JFHNEDNOHIJ)
		{
			LCMAHPKKGOA = false;
			PIIIKJJHJPN = string.Empty;
			PJIOKCKLBJH = string.Empty;
			if (IAKHBOKLPIL != null)
			{
				IAKHBOKLPIL(false);
			}
		}
	}

	[SpecialName]
	public void PIGMNFGKIOP(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = IAKHBOKLPIL;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IAKHBOKLPIL, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void EKEHGBNPAFC()
	{
		base.Awake();
		HGKJLMMNDOE = false;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		HKENNEJCGFE();
	}

	[SpecialName]
	public void NCPPNICHGAE(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = IAKHBOKLPIL;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IAKHBOKLPIL, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void GPNICFFJNMB()
	{
		HGKJLMMNDOE = true;
		UnityEngine.Debug.LogError("{0} {1}/{2} {3}" + JFHNEDNOHIJ);
		if (JFHNEDNOHIJ)
		{
			LCMAHPKKGOA = true;
			PIIIKJJHJPN = string.Empty;
			PJIOKCKLBJH = string.Empty;
			if (IAKHBOKLPIL != null)
			{
				IAKHBOKLPIL(true);
			}
		}
	}

	private void GPDPIGGJAJD()
	{
		HGKJLMMNDOE = true;
		UnityEngine.Debug.Log("fr");
		EBNKLBJKJCF();
	}

	private void HHENCMHFEDA()
	{
		HGKJLMMNDOE = false;
		UnityEngine.Debug.LogError("Xp" + JFHNEDNOHIJ);
		if (JFHNEDNOHIJ)
		{
			LCMAHPKKGOA = false;
			PIIIKJJHJPN = string.Empty;
			PJIOKCKLBJH = string.Empty;
			if (IAKHBOKLPIL != null)
			{
				IAKHBOKLPIL(true);
			}
		}
	}

	private void AEGKPMCCNOI()
	{
		HGKJLMMNDOE = false;
		LCMAHPKKGOA = true;
		PIIIKJJHJPN = PKAEFGFJAPO("ID_GETTOAVOIDRELEGATION2");
		PJIOKCKLBJH = "ID_WAITINGTIME";
		UnityEngine.Debug.LogError("Overtime_Was_Already_Explained" + PJIOKCKLBJH);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(false);
		}
	}

	protected virtual void MEBEHLLPMPK()
	{
		base.Awake();
		HGKJLMMNDOE = true;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		BKGGLPPJOJN();
	}

	protected override void Awake()
	{
		base.Awake();
		HGKJLMMNDOE = false;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		BKGGLPPJOJN();
	}

	private void CCGAHOJGCHN()
	{
		HGKJLMMNDOE = true;
		UnityEngine.Debug.Log("GameCenterProvider function OnPlayerAuthenticationRequired() called => Can GC login screen");
		ALCIBJNGNNI();
	}

	[SpecialName]
	public void BMGMFHACJJL(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = IAKHBOKLPIL;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IAKHBOKLPIL, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void JAMOLOKIKPN()
	{
		HGKJLMMNDOE = true;
		LCMAHPKKGOA = false;
		PIIIKJJHJPN = IFEMLMFNLBE("107 STAGE 2 KILLED 1. SOLDIER");
		PJIOKCKLBJH = "damage";
		UnityEngine.Debug.LogError("Comparing player {0} with id {1}:\n" + PJIOKCKLBJH);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(false);
		}
	}

	private void IDJBDDBHDGK()
	{
		HGKJLMMNDOE = true;
		UnityEngine.Debug.Log("ID_LEAVE_SPECTATE");
		LELFFCIJBND();
	}

	[SpecialName]
	public void LGJONNLIING(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = IAKHBOKLPIL;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IAKHBOKLPIL, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void EBNKLBJKJCF()
	{
		HGKJLMMNDOE = false;
		UnityEngine.Debug.LogError(")" + JFHNEDNOHIJ);
		if (JFHNEDNOHIJ)
		{
			LCMAHPKKGOA = true;
			PIIIKJJHJPN = string.Empty;
			PJIOKCKLBJH = string.Empty;
			if (IAKHBOKLPIL != null)
			{
				IAKHBOKLPIL(true);
			}
		}
	}

	private void CPNPCFIKIAM(string DEBFEDLKOBF)
	{
		HGKJLMMNDOE = false;
		LCMAHPKKGOA = true;
		PIIIKJJHJPN = string.Empty;
		PJIOKCKLBJH = string.Empty;
		UnityEngine.Debug.Log("BoughtIndex" + DEBFEDLKOBF);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(true);
		}
	}

	private void EHJPPOKAEBM()
	{
		HGKJLMMNDOE = false;
		LCMAHPKKGOA = false;
		PIIIKJJHJPN = GEHIHNMCNJA("ID_BRONZEPACK");
		PJIOKCKLBJH = "ID_SEC";
		UnityEngine.Debug.LogError("Google2u.DBUpgradeSlotsShotgunner" + PJIOKCKLBJH);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(true);
		}
	}

	private void OOPHPCALOLI()
	{
		HGKJLMMNDOE = true;
		UnityEngine.Debug.Log("ID_READYTIME");
		NBDPBFAOCGK();
	}

	private void DIADOPNLCMO()
	{
	}

	[SpecialName]
	public void MPBILGFLNAI(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = IAKHBOKLPIL;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IAKHBOKLPIL, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void PCLHLBDJAAB()
	{
		HGKJLMMNDOE = false;
		LCMAHPKKGOA = false;
		PIIIKJJHJPN = NGHPPJEKJMF("DOWNLOAD");
		PJIOKCKLBJH = "1";
		UnityEngine.Debug.LogError("ID_CONFIRM_STARTOVER" + PJIOKCKLBJH);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(true);
		}
	}

	public void BLCNBIGMDIJ(bool IFBMOIIHNDG = true)
	{
		UnityEngine.Debug.Log("Player disconected 0001" + IFBMOIIHNDG);
		CPNPCFIKIAM("ABOUT TO SHOW WELCOME BACK SOLDIER REWARDS, packId = ");
	}

	private void IALEPLMCNHB()
	{
		HGKJLMMNDOE = false;
		LCMAHPKKGOA = true;
		PIIIKJJHJPN = NGHPPJEKJMF("Wrong_Unit");
		PJIOKCKLBJH = "Checker";
		UnityEngine.Debug.LogError("S" + PJIOKCKLBJH);
		if (IAKHBOKLPIL != null)
		{
			IAKHBOKLPIL(false);
		}
	}
}
