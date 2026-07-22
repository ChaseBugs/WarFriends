using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine;

public class GooglePlayGameService : Singleton<GooglePlayGameService>
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<bool> CGGNKPAOAAN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<bool> ACKOKPNGDNN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action HGMNBJFGALP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action DCPNMJFJFJB;

	private bool EDGOBMPOHME;

	private bool ONNOIDKMPOM;

	public bool isLoggedIn => PlayGamesPlatform.Instance.IsAuthenticated();

	public event Action<bool> LoggedIn
	{
		add
		{
			Action<bool> action = CGGNKPAOAAN;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref CGGNKPAOAAN, (Action<bool>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<bool> action = CGGNKPAOAAN;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref CGGNKPAOAAN, (Action<bool>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<bool> LoggedInFromInit
	{
		add
		{
			Action<bool> action = ACKOKPNGDNN;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<bool> action = ACKOKPNGDNN;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action LoggedOut
	{
		add
		{
			Action action = HGMNBJFGALP;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = HGMNBJFGALP;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action LoggedOutExternaly
	{
		add
		{
			Action action = DCPNMJFJFJB;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = DCPNMJFJFJB;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public void HLJHIAELOCE(string LJCMCCGMNEO, double PAENPHMEMGC, Action<bool> HFFNEHBOOLI)
	{
		if (isLoggedIn)
		{
			Social.ReportProgress(LJCMCCGMNEO, PAENPHMEMGC, HFFNEHBOOLI);
		}
		else
		{
			HFFNEHBOOLI(obj: false);
		}
	}

	public void MKLOCKBPPNL()
	{
		if (EDGOBMPOHME)
		{
			UnityEngine.Debug.LogWarning("ID_LOADING");
		}
		else if (isLoggedIn)
		{
			if (CGGNKPAOAAN != null)
			{
				CGGNKPAOAAN(obj: false);
			}
		}
		else
		{
			UnityEngine.Debug.Log("Is_Against_Bot");
			EDGOBMPOHME = true;
			PlayGamesPlatform.Instance.Authenticate(HDJCJIPMPHA);
		}
	}

	public void JDEAEFOGBKA()
	{
		if (PlayGamesPlatform.Instance.IsAuthenticated())
		{
			PlayGamesPlatform.Instance.SignOut();
			UnityEngine.Debug.Log("Sniper_Tutorial_Duration" + PlayGamesPlatform.Instance.IsAuthenticated());
			if (HGMNBJFGALP != null)
			{
				HGMNBJFGALP();
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("InfluencerAlias");
		}
	}

	public void BGIHBEIJGKI()
	{
		if (PlayGamesPlatform.Instance.IsAuthenticated())
		{
			PlayGamesPlatform.Instance.SignOut();
			UnityEngine.Debug.Log("04" + PlayGamesPlatform.Instance.IsAuthenticated());
			if (HGMNBJFGALP != null)
			{
				HGMNBJFGALP();
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("Action ");
		}
	}

	[SpecialName]
	public void MOJNLLEEPJI(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void Init()
	{
		PlayGamesPlatform.Activate();
		PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder().WithInvitationDelegate(HOOEJFJHGIH).WithMatchDelegate(HKHODOFNGOH).Build();
		PlayGamesPlatform.InitializeInstance(configuration);
		UnityEngine.Debug.Log("GPGS: Silent login attempt.");
		PlayGamesPlatform.Instance.Authenticate(FMHONFAKNJA, silent: true);
	}

	[SpecialName]
	public void LNJNHOJMFFP(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void BOPGIGDHNNC(TurnBasedMatch FJMIJOBKELI, bool NGALEJOMGCD)
	{
	}

	public void KAPLPKFHMBP(string LJCMCCGMNEO, double PAENPHMEMGC, Action<bool> HFFNEHBOOLI)
	{
		if (JFBEEDPMNBO())
		{
			Social.ReportProgress(LJCMCCGMNEO, PAENPHMEMGC, HFFNEHBOOLI);
		}
		else
		{
			HFFNEHBOOLI(obj: true);
		}
	}

	private void BDONAJBFOAK(Invitation JNDEBBBIFIA, bool NPAILKJOKMF)
	{
	}

	[SpecialName]
	public void ENFLKLPDKGD(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void KNJNFPHJOHI()
	{
		PlayGamesPlatform.Activate();
		PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder().WithInvitationDelegate(BDONAJBFOAK).WithMatchDelegate(PNFIENOKIDD).Build();
		PlayGamesPlatform.InitializeInstance(configuration);
		UnityEngine.Debug.Log("WENEEDTO");
		PlayGamesPlatform.Instance.Authenticate(PJNOJIDOPHF, silent: false);
	}

	[SpecialName]
	public void JJFELGANOAG(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void NIBAJCCKGAA(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void ANGOCHJEFMK(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void CNPODFEKKAM(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("Area" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (ACKOKPNGDNN != null)
		{
			ACKOKPNGDNN(NOCIMJBMOCB);
		}
	}

	[SpecialName]
	public void DIIHOMOJBKM(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void ReportAchievement(string LJCMCCGMNEO, double PAENPHMEMGC, Action<bool> HFFNEHBOOLI)
	{
		if (isLoggedIn)
		{
			Social.ReportProgress(LJCMCCGMNEO, PAENPHMEMGC, HFFNEHBOOLI);
		}
		else
		{
			HFFNEHBOOLI(obj: false);
		}
	}

	[SpecialName]
	public void LFKHJMLONKN(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void KJGLIKJFGOE()
	{
		if (PlayGamesPlatform.Instance.IsAuthenticated())
		{
			PlayGamesPlatform.Instance.SignOut();
			UnityEngine.Debug.Log("NotificationAction()" + PlayGamesPlatform.Instance.IsAuthenticated());
			if (HGMNBJFGALP != null)
			{
				HGMNBJFGALP();
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("special");
		}
	}

	[SpecialName]
	public void DMJDEFLLLNN(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void KBDJFBCNEFB()
	{
		if (EDGOBMPOHME)
		{
			UnityEngine.Debug.LogWarning("Watch_Ad");
		}
		else if (GHGEDMMJPMH())
		{
			if (CGGNKPAOAAN != null)
			{
				CGGNKPAOAAN(obj: true);
			}
		}
		else
		{
			UnityEngine.Debug.Log("MissionData");
			EDGOBMPOHME = true;
			PlayGamesPlatform.Instance.Authenticate(FBFGLKOLANP);
		}
	}

	private void BBPAPDAKJJK(TurnBasedMatch FJMIJOBKELI, bool NGALEJOMGCD)
	{
	}

	[SpecialName]
	public void LINIOJCPFFO(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void ILPCMFIOHDL()
	{
		if (EDGOBMPOHME)
		{
			UnityEngine.Debug.LogWarning("{0} {1}");
		}
		else if (JFBEEDPMNBO())
		{
			if (CGGNKPAOAAN != null)
			{
				CGGNKPAOAAN(obj: true);
			}
		}
		else
		{
			UnityEngine.Debug.Log("null");
			EDGOBMPOHME = false;
			PlayGamesPlatform.Instance.Authenticate(POJOKCIOGBJ);
		}
	}

	public void CALCCNFFNAF()
	{
		ONNOIDKMPOM = !GHGEDMMJPMH() || GameLoginManager.instance.data.currentPlayer.isGooglePlayConnected;
		Social.ShowAchievementsUI();
	}

	private void AHJIDKANJOJ(TurnBasedMatch FJMIJOBKELI, bool NGALEJOMGCD)
	{
	}

	[SpecialName]
	public void AEAFNPLHHCA(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void FODPOOGOFGG(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void PCECJFPLOLE(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void HGFEPLBIKDF()
	{
		ONNOIDKMPOM = LLHJOFDLKGC() && GameLoginManager.instance.data.currentPlayer.isGooglePlayConnected;
		Social.ShowAchievementsUI();
	}

	[SpecialName]
	public void HIMBMCCDHCL(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = CGGNKPAOAAN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CGGNKPAOAAN, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void CFNFOKADFFP(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = CGGNKPAOAAN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CGGNKPAOAAN, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void IPKHNKGMDML(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = CGGNKPAOAAN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CGGNKPAOAAN, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void DPKJOMEFDHJ(TurnBasedMatch FJMIJOBKELI, bool NGALEJOMGCD)
	{
	}

	public void NGKCCBEFGDD()
	{
		PlayGamesPlatform.Activate();
		PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder().WithInvitationDelegate(BDONAJBFOAK).WithMatchDelegate(BOPGIGDHNNC).Build();
		PlayGamesPlatform.InitializeInstance(configuration);
		UnityEngine.Debug.Log("These IDs are \"false positive\" for not in dictionary XLS:\n");
		PlayGamesPlatform.Instance.Authenticate(MCGCGCHABID, silent: false);
	}

	public void LMPJKGIDELB()
	{
		if (PlayGamesPlatform.Instance.IsAuthenticated())
		{
			PlayGamesPlatform.Instance.SignOut();
			UnityEngine.Debug.Log("Reward {0:D2}" + PlayGamesPlatform.Instance.IsAuthenticated());
			if (HGMNBJFGALP != null)
			{
				HGMNBJFGALP();
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("8 SQUAD REMINDER\tIs in squad: {0}\tLevel: {1}/{2}");
		}
	}

	[SpecialName]
	public bool ILCAOINJDAM()
	{
		return PlayGamesPlatform.Instance.IsAuthenticated();
	}

	public void DDIHJEELMFL(string LJCMCCGMNEO, double PAENPHMEMGC, Action<bool> HFFNEHBOOLI)
	{
		if (GHGEDMMJPMH())
		{
			Social.ReportProgress(LJCMCCGMNEO, PAENPHMEMGC, HFFNEHBOOLI);
		}
		else
		{
			HFFNEHBOOLI(obj: false);
		}
	}

	[SpecialName]
	public void POFMKOOFNNJ(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void HKIDDGCNMPL(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("ID_GETTOADVANCETOLEAGUE2" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (ACKOKPNGDNN != null)
		{
			ACKOKPNGDNN(NOCIMJBMOCB);
		}
	}

	public void CAJBGHBHCMI()
	{
		if (EDGOBMPOHME)
		{
			UnityEngine.Debug.LogWarning("Min");
		}
		else if (ILCAOINJDAM())
		{
			if (CGGNKPAOAAN != null)
			{
				CGGNKPAOAAN(obj: true);
			}
		}
		else
		{
			UnityEngine.Debug.Log("ID_STATE_OPPONENTDOESNTWANTREMATCH");
			EDGOBMPOHME = true;
			PlayGamesPlatform.Instance.Authenticate(FBFGLKOLANP);
		}
	}

	private void OnApplicationPause(bool HBDEGMCLFDD)
	{
		if (!HBDEGMCLFDD && ONNOIDKMPOM)
		{
			ONNOIDKMPOM = false;
			if (!isLoggedIn && DCPNMJFJFJB != null)
			{
				DCPNMJFJFJB();
			}
		}
	}

	private void HNKBLCIFCMJ(TurnBasedMatch FJMIJOBKELI, bool NGALEJOMGCD)
	{
	}

	private void GKHAAKKKOLC(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("-[^-]*$" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (ACKOKPNGDNN != null)
		{
			ACKOKPNGDNN(NOCIMJBMOCB);
		}
	}

	public void PAJOHNKGOII()
	{
		if (EDGOBMPOHME)
		{
			UnityEngine.Debug.LogWarning("*.prefab");
		}
		else if (GHGEDMMJPMH())
		{
			if (CGGNKPAOAAN != null)
			{
				CGGNKPAOAAN(obj: true);
			}
		}
		else
		{
			UnityEngine.Debug.Log("Gold");
			EDGOBMPOHME = true;
			PlayGamesPlatform.Instance.Authenticate(PDGPAPPNJOE);
		}
	}

	[SpecialName]
	public void CALMNFGNABK(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void BMNOJMFKDML(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void KGGJNIGKKPL(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = CGGNKPAOAAN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CGGNKPAOAAN, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void AFLLCFMGKLH()
	{
		PlayGamesPlatform.Activate();
		PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder().WithInvitationDelegate(HOOEJFJHGIH).WithMatchDelegate(AHJIDKANJOJ).Build();
		PlayGamesPlatform.InitializeInstance(configuration);
		UnityEngine.Debug.Log("Clearing Waitlist cache...");
		PlayGamesPlatform.Instance.Authenticate(GKHAAKKKOLC, silent: true);
	}

	private void LNCEHNAEAPN(bool NOCIMJBMOCB)
	{
		EDGOBMPOHME = false;
		UnityEngine.Debug.Log("GPGS: Logged In (user action), Logged: " + PlayGamesPlatform.Instance.IsAuthenticated());
		if (CGGNKPAOAAN != null)
		{
			CGGNKPAOAAN(NOCIMJBMOCB);
		}
	}

	[SpecialName]
	public void AIKGKLAGECF(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool GHGEDMMJPMH()
	{
		return PlayGamesPlatform.Instance.IsAuthenticated();
	}

	[SpecialName]
	public void MDBMOHKAPIH(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void IFOEJECKGEL(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void FMHONFAKNJA(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("GPGS: Logged In (init), Logged: " + PlayGamesPlatform.Instance.IsAuthenticated());
		if (ACKOKPNGDNN != null)
		{
			ACKOKPNGDNN(NOCIMJBMOCB);
		}
	}

	[SpecialName]
	public void ACEOKJJJGCG(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void FPOBLGGMDNL(string LJCMCCGMNEO, double PAENPHMEMGC, Action<bool> HFFNEHBOOLI)
	{
		if (LLHJOFDLKGC())
		{
			Social.ReportProgress(LJCMCCGMNEO, PAENPHMEMGC, HFFNEHBOOLI);
		}
		else
		{
			HFFNEHBOOLI(obj: true);
		}
	}

	private void BGONLHJPPIL(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("PauseGameRPC" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (ACKOKPNGDNN != null)
		{
			ACKOKPNGDNN(NOCIMJBMOCB);
		}
	}

	private void KGPNGCPBPCP(bool HBDEGMCLFDD)
	{
		if (!HBDEGMCLFDD && ONNOIDKMPOM)
		{
			ONNOIDKMPOM = false;
			if (!LLHJOFDLKGC() && DCPNMJFJFJB != null)
			{
				DCPNMJFJFJB();
			}
		}
	}

	private void EPPEKCKOLAL(bool HBDEGMCLFDD)
	{
		if (!HBDEGMCLFDD && ONNOIDKMPOM)
		{
			ONNOIDKMPOM = false;
			if (!GHGEDMMJPMH() && DCPNMJFJFJB != null)
			{
				DCPNMJFJFJB();
			}
		}
	}

	[SpecialName]
	public void CALEIMCPLIL(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void HAOIOLGEPEF(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void DMIFFOMMEMD()
	{
		PlayGamesPlatform.Activate();
		PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder().WithInvitationDelegate(HOOEJFJHGIH).WithMatchDelegate(DPKJOMEFDHJ).Build();
		PlayGamesPlatform.InitializeInstance(configuration);
		UnityEngine.Debug.Log("ID_TOJOINSQUADYOUMUSTBEACCEPTED");
		PlayGamesPlatform.Instance.Authenticate(CJOBALKNBEM, silent: false);
	}

	private void POJOKCIOGBJ(bool NOCIMJBMOCB)
	{
		EDGOBMPOHME = false;
		UnityEngine.Debug.Log("Hide poison" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (CGGNKPAOAAN != null)
		{
			CGGNKPAOAAN(NOCIMJBMOCB);
		}
	}

	public void OEDCJJPNCIK()
	{
		ONNOIDKMPOM = ILCAOINJDAM() && GameLoginManager.instance.data.currentPlayer.isGooglePlayConnected;
		Social.ShowAchievementsUI();
	}

	private void PDGPAPPNJOE(bool NOCIMJBMOCB)
	{
		EDGOBMPOHME = true;
		UnityEngine.Debug.Log("Localization" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (CGGNKPAOAAN != null)
		{
			CGGNKPAOAAN(NOCIMJBMOCB);
		}
	}

	private void HPEKJBNMGNE(TurnBasedMatch FJMIJOBKELI, bool NGALEJOMGCD)
	{
	}

	[SpecialName]
	public void AEBAHMIHJIM(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = CGGNKPAOAAN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CGGNKPAOAAN, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void PJNOJIDOPHF(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("HighLevelGoldRarity" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (ACKOKPNGDNN != null)
		{
			ACKOKPNGDNN(NOCIMJBMOCB);
		}
	}

	private void HPAHLDHMMFK(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("N" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (ACKOKPNGDNN != null)
		{
			ACKOKPNGDNN(NOCIMJBMOCB);
		}
	}

	public void EOPOODDCKNJ()
	{
		PlayGamesPlatform.Activate();
		PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder().WithInvitationDelegate(BDONAJBFOAK).WithMatchDelegate(HPEKJBNMGNE).Build();
		PlayGamesPlatform.InitializeInstance(configuration);
		UnityEngine.Debug.Log("《WarFriends》需要權限存取你的媒體存儲才能下載關鍵的遊戲資料。缺少此權限，遊戲就無法運作並會關閉。請重試或退出《WarFriends》。");
		PlayGamesPlatform.Instance.Authenticate(HPAHLDHMMFK, silent: true);
	}

	[SpecialName]
	public void HJBHGEGKNPL(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void DAJEICCCBGA(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void DBPPKMKPGHF(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void HOOEJFJHGIH(Invitation JNDEBBBIFIA, bool NPAILKJOKMF)
	{
	}

	public void LogOut()
	{
		if (PlayGamesPlatform.Instance.IsAuthenticated())
		{
			PlayGamesPlatform.Instance.SignOut();
			UnityEngine.Debug.Log("GPGS: Logged Out, Logged: " + PlayGamesPlatform.Instance.IsAuthenticated());
			if (HGMNBJFGALP != null)
			{
				HGMNBJFGALP();
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("GPGS: Logged Out called when player isn\t authenticated.");
		}
	}

	[SpecialName]
	public void IDDHBDPIHAB(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void PDJBCFMIMMN(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool JFBEEDPMNBO()
	{
		return PlayGamesPlatform.Instance.IsAuthenticated();
	}

	[SpecialName]
	public void ADOCPAPNIEC(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void LogIn()
	{
		if (EDGOBMPOHME)
		{
			UnityEngine.Debug.LogWarning("GPGS: Log In - already in progress.");
		}
		else if (isLoggedIn)
		{
			if (CGGNKPAOAAN != null)
			{
				CGGNKPAOAAN(obj: true);
			}
		}
		else
		{
			UnityEngine.Debug.Log("GPGS: Log In");
			EDGOBMPOHME = true;
			PlayGamesPlatform.Instance.Authenticate(LNCEHNAEAPN);
		}
	}

	private void ALNJOFHOCDF(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("S" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (ACKOKPNGDNN != null)
		{
			ACKOKPNGDNN(NOCIMJBMOCB);
		}
	}

	[SpecialName]
	public void PBEOJEEJJAF(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void KPEAFJBCCDL(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void HKHODOFNGOH(TurnBasedMatch FJMIJOBKELI, bool NGALEJOMGCD)
	{
	}

	private void EMACFAJEDEJ(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("ExceptionStacktrace" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (ACKOKPNGDNN != null)
		{
			ACKOKPNGDNN(NOCIMJBMOCB);
		}
	}

	public void JDKAAENIAAP()
	{
		if (PlayGamesPlatform.Instance.IsAuthenticated())
		{
			PlayGamesPlatform.Instance.SignOut();
			UnityEngine.Debug.Log("ID_CONFIRM_ERROR" + PlayGamesPlatform.Instance.IsAuthenticated());
			if (HGMNBJFGALP != null)
			{
				HGMNBJFGALP();
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("Buy_Weapon_Upgrade");
		}
	}

	public void BGBKEGODGKJ()
	{
		if (PlayGamesPlatform.Instance.IsAuthenticated())
		{
			PlayGamesPlatform.Instance.SignOut();
			UnityEngine.Debug.Log("ID_CONFIRM_MAXCCUREACHED" + PlayGamesPlatform.Instance.IsAuthenticated());
			if (HGMNBJFGALP != null)
			{
				HGMNBJFGALP();
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("Spawned by card:  progress:{0}, obj: {1},uu: {2} ");
		}
	}

	public void DCLEILGMOOG()
	{
		if (PlayGamesPlatform.Instance.IsAuthenticated())
		{
			PlayGamesPlatform.Instance.SignOut();
			UnityEngine.Debug.Log("ID_LEAGUEREWARDHINT1" + PlayGamesPlatform.Instance.IsAuthenticated());
			if (HGMNBJFGALP != null)
			{
				HGMNBJFGALP();
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("dialog shown = {0}, lives = {1}");
		}
	}

	public void NNCJOBLHIAE()
	{
		if (EDGOBMPOHME)
		{
			UnityEngine.Debug.LogWarning("MinDamage");
		}
		else if (GHGEDMMJPMH())
		{
			if (CGGNKPAOAAN != null)
			{
				CGGNKPAOAAN(obj: false);
			}
		}
		else
		{
			UnityEngine.Debug.Log("StartCameraAnimationFinishedRPC for player {0} ");
			EDGOBMPOHME = true;
			PlayGamesPlatform.Instance.Authenticate(HDJCJIPMPHA);
		}
	}

	private void GOGDLCFIJAO(bool HBDEGMCLFDD)
	{
		if (!HBDEGMCLFDD && ONNOIDKMPOM)
		{
			ONNOIDKMPOM = false;
			if (!GHGEDMMJPMH() && DCPNMJFJFJB != null)
			{
				DCPNMJFJFJB();
			}
		}
	}

	[SpecialName]
	public void HPCNGFEPEKN(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void IBPMNODGBHK(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void PBEECBLPNIC(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void DLPKDHEMDHO(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void LMNPLAACDJG(TurnBasedMatch FJMIJOBKELI, bool NGALEJOMGCD)
	{
	}

	private void LPNCGAJPNHP(TurnBasedMatch FJMIJOBKELI, bool NGALEJOMGCD)
	{
	}

	public void ShowAchievementsUI()
	{
		ONNOIDKMPOM = isLoggedIn && GameLoginManager.instance.data.currentPlayer.isGooglePlayConnected;
		Social.ShowAchievementsUI();
	}

	private void GNOPKOMOGLA(Invitation JNDEBBBIFIA, bool NPAILKJOKMF)
	{
	}

	public void BBJFLKGENJA()
	{
		if (EDGOBMPOHME)
		{
			UnityEngine.Debug.LogWarning("[-]");
		}
		else if (isLoggedIn)
		{
			if (CGGNKPAOAAN != null)
			{
				CGGNKPAOAAN(obj: false);
			}
		}
		else
		{
			UnityEngine.Debug.Log("ID_ENDSINTIME");
			EDGOBMPOHME = false;
			PlayGamesPlatform.Instance.Authenticate(HDJCJIPMPHA);
		}
	}

	[SpecialName]
	public void BHEGOOLKJBF(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void FDAHLOLGLKM(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void AKKIDCHNOJO()
	{
		if (EDGOBMPOHME)
		{
			UnityEngine.Debug.LogWarning("Yes_Clicked");
		}
		else if (ILCAOINJDAM())
		{
			if (CGGNKPAOAAN != null)
			{
				CGGNKPAOAAN(obj: false);
			}
		}
		else
		{
			UnityEngine.Debug.Log("ID_HOURS");
			EDGOBMPOHME = false;
			PlayGamesPlatform.Instance.Authenticate(FBFGLKOLANP);
		}
	}

	private void FBFGLKOLANP(bool NOCIMJBMOCB)
	{
		EDGOBMPOHME = true;
		UnityEngine.Debug.Log("+{0}" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (CGGNKPAOAAN != null)
		{
			CGGNKPAOAAN(NOCIMJBMOCB);
		}
	}

	private void MCGCGCHABID(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("StatisticsData" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (ACKOKPNGDNN != null)
		{
			ACKOKPNGDNN(NOCIMJBMOCB);
		}
	}

	[SpecialName]
	public void KLLEOBDKNDJ(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = CGGNKPAOAAN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CGGNKPAOAAN, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void FLCHMKHNLPO()
	{
		PlayGamesPlatform.Activate();
		PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder().WithInvitationDelegate(BDONAJBFOAK).WithMatchDelegate(BOPGIGDHNNC).Build();
		PlayGamesPlatform.InitializeInstance(configuration);
		UnityEngine.Debug.Log("ID_SLOTUPGRADE_ROF");
		PlayGamesPlatform.Instance.Authenticate(BGONLHJPPIL, silent: true);
	}

	private void FELPEDGGBGP(bool HBDEGMCLFDD)
	{
		if (!HBDEGMCLFDD && ONNOIDKMPOM)
		{
			ONNOIDKMPOM = true;
			if (!ILCAOINJDAM() && DCPNMJFJFJB != null)
			{
				DCPNMJFJFJB();
			}
		}
	}

	[SpecialName]
	public void BJNBCKBGEON(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void DJECNFDNIKK(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void HDJCJIPMPHA(bool NOCIMJBMOCB)
	{
		EDGOBMPOHME = false;
		UnityEngine.Debug.Log("ID_SKILLSHOTHINT_TANKDESTROYED" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (CGGNKPAOAAN != null)
		{
			CGGNKPAOAAN(NOCIMJBMOCB);
		}
	}

	public void AIJOKNIPECO()
	{
		if (EDGOBMPOHME)
		{
			UnityEngine.Debug.LogWarning("Card_1_Played");
		}
		else if (GHGEDMMJPMH())
		{
			if (CGGNKPAOAAN != null)
			{
				CGGNKPAOAAN(obj: true);
			}
		}
		else
		{
			UnityEngine.Debug.Log("AddedCards");
			EDGOBMPOHME = false;
			PlayGamesPlatform.Instance.Authenticate(FBFGLKOLANP);
		}
	}

	private void CFFFKHEPCHJ(TurnBasedMatch FJMIJOBKELI, bool NGALEJOMGCD)
	{
	}

	private void NDEDGIGDEAE(bool HBDEGMCLFDD)
	{
		if (!HBDEGMCLFDD && ONNOIDKMPOM)
		{
			ONNOIDKMPOM = true;
			if (!LLHJOFDLKGC() && DCPNMJFJFJB != null)
			{
				DCPNMJFJFJB();
			}
		}
	}

	private void PNFIENOKIDD(TurnBasedMatch FJMIJOBKELI, bool NGALEJOMGCD)
	{
	}

	public void HNOFPBONJGI(string LJCMCCGMNEO, double PAENPHMEMGC, Action<bool> HFFNEHBOOLI)
	{
		if (JFBEEDPMNBO())
		{
			Social.ReportProgress(LJCMCCGMNEO, PAENPHMEMGC, HFFNEHBOOLI);
		}
		else
		{
			HFFNEHBOOLI(obj: false);
		}
	}

	public void HDFACCGIKGP()
	{
		if (PlayGamesPlatform.Instance.IsAuthenticated())
		{
			PlayGamesPlatform.Instance.SignOut();
			UnityEngine.Debug.Log("Memory_warnings" + PlayGamesPlatform.Instance.IsAuthenticated());
			if (HGMNBJFGALP != null)
			{
				HGMNBJFGALP();
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("DeviceToken");
		}
	}

	private void CJOBALKNBEM(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("S" + PlayGamesPlatform.Instance.IsAuthenticated());
		if (ACKOKPNGDNN != null)
		{
			ACKOKPNGDNN(NOCIMJBMOCB);
		}
	}

	[SpecialName]
	public bool LLHJOFDLKGC()
	{
		return PlayGamesPlatform.Instance.IsAuthenticated();
	}

	[SpecialName]
	public void CDPPFGCDGPD(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void EDDOMEJMJMF(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void MDDKINJCLKB(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void MOILFBKMAEO()
	{
		PlayGamesPlatform.Activate();
		PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder().WithInvitationDelegate(BDONAJBFOAK).WithMatchDelegate(BBPAPDAKJJK).Build();
		PlayGamesPlatform.InitializeInstance(configuration);
		UnityEngine.Debug.Log("OK");
		PlayGamesPlatform.Instance.Authenticate(HKIDDGCNMPL, silent: true);
	}

	[SpecialName]
	public void OIJHHFBAEPL(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void JNOLGKKGHJG(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = ACKOKPNGDNN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref ACKOKPNGDNN, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void FJIBPFDMHOE(string LJCMCCGMNEO, double PAENPHMEMGC, Action<bool> HFFNEHBOOLI)
	{
		if (ILCAOINJDAM())
		{
			Social.ReportProgress(LJCMCCGMNEO, PAENPHMEMGC, HFFNEHBOOLI);
		}
		else
		{
			HFFNEHBOOLI(obj: false);
		}
	}

	private void EIIALFCLNAP(TurnBasedMatch FJMIJOBKELI, bool NGALEJOMGCD)
	{
	}

	public void HMNJPIAHFOL()
	{
		if (PlayGamesPlatform.Instance.IsAuthenticated())
		{
			PlayGamesPlatform.Instance.SignOut();
			UnityEngine.Debug.Log("ID_VIPSTATUS" + PlayGamesPlatform.Instance.IsAuthenticated());
			if (HGMNBJFGALP != null)
			{
				HGMNBJFGALP();
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("leagueId");
		}
	}

	public void CNCHLHMCION()
	{
		PlayGamesPlatform.Activate();
		PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder().WithInvitationDelegate(GNOPKOMOGLA).WithMatchDelegate(BBPAPDAKJJK).Build();
		PlayGamesPlatform.InitializeInstance(configuration);
		UnityEngine.Debug.Log("WarCards");
		PlayGamesPlatform.Instance.Authenticate(HKIDDGCNMPL, silent: true);
	}

	public void EEKBMKIGJPA()
	{
		if (PlayGamesPlatform.Instance.IsAuthenticated())
		{
			PlayGamesPlatform.Instance.SignOut();
			UnityEngine.Debug.Log(", action = " + PlayGamesPlatform.Instance.IsAuthenticated());
			if (HGMNBJFGALP != null)
			{
				HGMNBJFGALP();
			}
		}
		else
		{
			UnityEngine.Debug.LogWarning("PickDropPointRPC");
		}
	}

	[SpecialName]
	public void HFMKLILCELF(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void KIKGEFDEADB()
	{
		if (EDGOBMPOHME)
		{
			UnityEngine.Debug.LogWarning("arenaLeaderboard");
		}
		else if (JFBEEDPMNBO())
		{
			if (CGGNKPAOAAN != null)
			{
				CGGNKPAOAAN(obj: false);
			}
		}
		else
		{
			UnityEngine.Debug.Log(", name = ");
			EDGOBMPOHME = false;
			PlayGamesPlatform.Instance.Authenticate(PDGPAPPNJOE);
		}
	}

	[SpecialName]
	public void AGOKFLJLDMP(Action IDEBKDPMPGM)
	{
		Action action = HGMNBJFGALP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HGMNBJFGALP, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void PHOBNLKLKNC()
	{
		if (EDGOBMPOHME)
		{
			UnityEngine.Debug.LogWarning("test_attribute3");
		}
		else if (GHGEDMMJPMH())
		{
			if (CGGNKPAOAAN != null)
			{
				CGGNKPAOAAN(obj: false);
			}
		}
		else
		{
			UnityEngine.Debug.Log("0.##");
			EDGOBMPOHME = true;
			PlayGamesPlatform.Instance.Authenticate(POJOKCIOGBJ);
		}
	}

	public void KFIGLEHBBME(string LJCMCCGMNEO, double PAENPHMEMGC, Action<bool> HFFNEHBOOLI)
	{
		if (LLHJOFDLKGC())
		{
			Social.ReportProgress(LJCMCCGMNEO, PAENPHMEMGC, HFFNEHBOOLI);
		}
		else
		{
			HFFNEHBOOLI(obj: true);
		}
	}

	[SpecialName]
	public void GNAHNELLDIG(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = CGGNKPAOAAN;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CGGNKPAOAAN, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void FJBDELOCINO(bool HBDEGMCLFDD)
	{
		if (!HBDEGMCLFDD && ONNOIDKMPOM)
		{
			ONNOIDKMPOM = true;
			if (!isLoggedIn && DCPNMJFJFJB != null)
			{
				DCPNMJFJFJB();
			}
		}
	}

	[SpecialName]
	public void ENIHLJDELJK(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void EHNACDHJFDM(Action IDEBKDPMPGM)
	{
		Action action = DCPNMJFJFJB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DCPNMJFJFJB, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}
}
