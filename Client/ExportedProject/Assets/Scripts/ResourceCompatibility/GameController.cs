using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameController : Singleton<GameController>
{
	public enum ALOAMODMHMO
	{
		None = 0,
		Killed = 1,
		Win = 2,
		WinByForfeit = 3,
		Forfeit = 5,
		Kia = 8,
		MissionFailed = 9,
		MissionSuccess = 10
	}

	[Flags]
	public enum IMOMKGNHGNN
	{
		Campaign = 2,
		Coop = 4,
		DeathMatch = 8,
		DeathMatchOffline = 0x10,
		WarArena = 0x20
	}

	public enum HIGIKGPGJLM
	{
		Menu,
		WaitingForResponse,
		Loading,
		Playing
	}

	public delegate void BOKPJIIKPEN();

	public enum FNFKGOFDAGO
	{
		None,
		Error,
		Success
	}

	private sealed class BCOPIAFDCOF : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameController HNNCIECPFEJ;

		public string MHHPANHFGJC;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public BCOPIAFDCOF(int HEIHBBOBLGF)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class FNCDFMBGJKL : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameController HNNCIECPFEJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public FNCDFMBGJKL(int HEIHBBOBLGF)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class IFIBNONEIBK
	{
		public string JFAOHOOMBLA;

		public DatabasePlayer GDMBMAPOKCL;
	}

	private sealed class BHFCAEPOCEG
	{
		public Action KEGGJAPKDIO;

		public Action EADPONCMEFJ;

		public IFIBNONEIBK PAIPGOJKHMM;

		internal void BEHAIPHBGFG()
		{
		}

		internal void ODADFDKDIJF()
		{
		}
	}

	private sealed class OJJDPHJECPP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameController HNNCIECPFEJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public OJJDPHJECPP(int HEIHBBOBLGF)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class BOJGPJLFGGA : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameController HNNCIECPFEJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public BOJGPJLFGGA(int HEIHBBOBLGF)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private sealed class ENHHHDEDOGF : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameController HNNCIECPFEJ;

		public bool PNEECMFHMHE;

		public bool FKIOECHJOOO;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public ENHHHDEDOGF(int HEIHBBOBLGF)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private HIGIKGPGJLM _003CPGJDDFICEBE_003Ek__BackingField;

	public GameControllerCampaign BBKLJKAKJME;

	public GameControllerCoop MGIJOKDKDJJ;

	public GameControllerDeathMatch HIAHKAEFHOC;

	public GameControllerDeathMatchOffline KMFDOMOJAEJ;

	public GameControllerTutorial KCEOMJEOJFA;

	public GameControllerWarArena DDEJOBGOOBF;

	public GameControllerInvasion DILDMMLEOOK;

	public ALOAMODMHMO DFEHIADKKNO;

	public AudioClip MMDBHABIMBG;

	private bool? MOJFHNIOFKL;

	private bool LMCCLMBJHIA;

	private bool JGPPKKDJNMK;

	private bool OPECMFFMLEN;

	private bool FEMKPKOCOFH;

	private bool KEACLPPMKLL;

	private ECFKBOAEIAC LDAPODNKEGA;

	private IGameController MMIDNIIHFCD;

	private PlayerController CLIIKILEGOE;

	public PlayerController PBBDJAODLIJ;

	public string MHHPANHFGJC;

	public AudioClip NAGCCPFHPOB;

	[CompilerGenerated]
	private Action<ALOAMODMHMO> LDOBIMHMAAP;

	[CompilerGenerated]
	private BOKPJIIKPEN KJDMCHAPPAE;

	[CompilerGenerated]
	private BOKPJIIKPEN PLIGLOFIGNH;

	[CompilerGenerated]
	private BOKPJIIKPEN KHMGCIKLDDM;

	[CompilerGenerated]
	private Action AENFPIDNHMF;

	private string FENEKHIGHJA;

	private bool DKHBNNGGIBK;

	public PlayerController ELIALMPMEGM;

	private string JBHPHPBNBNP;

	[CompilerGenerated]
	private FNFKGOFDAGO _003CIEFCJALHGLI_003Ek__BackingField;

	[CompilerGenerated]
	private LHDJHNFCLMD _003CDKMNFEEDLJL_003Ek__BackingField;

	public HIGIKGPGJLM gameState
	{
		[CompilerGenerated]
		get
		{
			return default(HIGIKGPGJLM);
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public IGameController mainController
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float time => 0f;

	public bool wonLastGame => false;

	public bool gameIsRunning
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public IMOMKGNHGNN gameType => default(IMOMKGNHGNN);

	public bool isMission => false;

	public bool isCampaign => false;

	public bool isCoop => false;

	public bool isInvasion => false;

	public bool isGameRunning => false;

	public bool isBattle => false;

	public bool isPVP => false;

	public bool isDeathMatch => false;

	public bool isDeathMatchOffline => false;

	public bool isWarArena => false;

	public bool isTutorial => false;

	public bool isTutorialInProgressOrPlaned => false;

	public bool isNotTutorialEnded => false;

	public bool isTutorialStage1 => false;

	public bool isTutorialStage2 => false;

	public bool isTutorialStage3 => false;

	public bool isFirstLoadingOfWarfriends => false;

	public string battleId
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool isRandomMatchMaking => false;

	public bool isChallenge => false;

	public bool isInMenuOrWait => false;

	public bool isLoadingOrPlaying => false;

	public FNFKGOFDAGO gameEndServerResponse
	{
		[CompilerGenerated]
		get
		{
			return default(FNFKGOFDAGO);
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public LHDJHNFCLMD errorReason
	{
		[CompilerGenerated]
		get
		{
			return default(LHDJHNFCLMD);
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public PlayerController opponent
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public event Action<ALOAMODMHMO> GameEnded
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event BOKPJIIKPEN BeforeGameStarted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event BOKPJIIKPEN GameStarted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event BOKPJIIKPEN AfterGameStarted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action SceneFreed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void CAMLAFCPKHN(Component LFJKBCPLEPD, IGameController DPBGFJFBPKO)
	{
	}

	public void StopAllTutorials()
	{
	}

	protected override void Awake()
	{
	}

	private void MIHHLNMIBON(DatabaseAction JMAECKMPPBI)
	{
	}

	public void InstanceOnAfterPlayerDataLoaded()
	{
	}

	private void FOJIOAFBPEP(bool EGMJAECMHBP)
	{
	}

	public void SwitchToSinglePlayer()
	{
	}

	public void SwitchToInvasion()
	{
	}

	public void SwitchToCoop()
	{
	}

	public void SwitchToTutorial()
	{
	}

	public void SwitchToDeathMatch()
	{
	}

	public void SwitchToWarArena()
	{
	}

	public void SwitchToDeatchMatchOffline()
	{
	}

	private void HGBHCNCAEMB()
	{
	}

	protected override void Start()
	{
	}

	public void StartGame(string FJIJLGOOHOC = "ModernTown")
	{
	}

	private IEnumerator NDIPKEIGHJA(string MHHPANHFGJC)
	{
		return null;
	}

	public IEnumerator WaitForServerResponse()
	{
		return null;
	}

	public void Rematch()
	{
	}

	public void StartHostMultiplayer()
	{
	}

	public bool SetChallenge(GIFNNKNKCMA NNCFCHPCADD)
	{
		return false;
	}

	public void StartMultiplayerGame(DatabasePlayer GDMBMAPOKCL)
	{
	}

	public void TryStopLoading()
	{
	}

	public void OnGameResumed(TimeManager.BMDADPPMCOK CACDIABJCML)
	{
	}

	public void OnGamePaused(TimeManager.BMDADPPMCOK CACDIABJCML)
	{
	}

	protected void OnApplicationPause(bool JAOPIKCFOEA)
	{
	}

	protected void OnApplicationResumed()
	{
	}

	public void InteruptStartingTutorial()
	{
	}

	public void ContinueOrStartTutorial()
	{
	}

	public void ContinueTutorialImmediately()
	{
	}

	public void TestDisconnect()
	{
	}

	private void JICCPBNEALN(string EGEKCMKCGKH = "")
	{
	}

	public void FinishGame()
	{
	}

	public IEnumerator RestartTutorial()
	{
		return null;
	}

	private IEnumerator LBFCCABAMCO()
	{
		return null;
	}

	private void FEMCBDKPMMN(DatabaseAction LGIKFLFEBHP, int AKBOMMEMLHM, AIIHHIPDAJA OJLKLBKCMIH)
	{
	}

	public void ChangeAccountDuringTutorial()
	{
	}

	public void ChangeAccountDuringTutorialTransition()
	{
	}

	public void StopGame(bool FKIOECHJOOO)
	{
	}

	private void PIIPHBPAOLF(bool FKIOECHJOOO, bool PNEECMFHMHE = false)
	{
	}

	private IEnumerator KDOMPFLMOJA(bool FKIOECHJOOO, bool PNEECMFHMHE)
	{
		return null;
	}

	public void Quit()
	{
	}

	[CompilerGenerated]
	private void NAJEAKGANOE()
	{
	}

	[CompilerGenerated]
	private void FEHAPPHHNOB()
	{
	}

	[CompilerGenerated]
	private void HPJDKGNEBHL()
	{
	}
}
