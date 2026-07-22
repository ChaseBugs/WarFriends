using System;
using System.Runtime.CompilerServices;

public class TimeManager : Core_BaseScript, IOnPhotonSerializeViewSubscriber, IPhotonEventSubscriber
{
	[Flags]
	public enum BMDADPPMCOK
	{
		None = 0,
		PausedLocaly = 1,
		LocalFocusLost = 2,
		PausedLocalyFocusLost = 3,
		PausedRemotely = 4,
		RemoteFocusLost = 8,
		PausedRemoteFocusLost = 0xC
	}

	[CompilerGenerated]
	private Action<BMDADPPMCOK> JOPMPLPPJPI;

	[CompilerGenerated]
	private Action<BMDADPPMCOK> GOALJBKALCB;

	public bool OJBLJAPPDAP;

	public bool FLLAEJLMKKN;

	private float EMMCJEEABGA;

	private float FFJGKOLGFLL;

	private float KEGBJANJDGO;

	private static DateTime OODNHMCKMNL;

	private static DateTime IOGJDEEEEBM;

	private float CJPANJALODA;

	private float HFJLPJDBLBN;

	private float PKFLCBPBNHK;

	private float IHECONJAINF;

	private float FNHAHLAIGNA;

	private float ILIJJBLGPME;

	private PhotonView IBBJLFJLAFA;

	private const float INONAEMFKGM = 5f;

	private static TimeManager DJDBDKFAKHN;

	[CompilerGenerated]
	private BMDADPPMCOK _003CFPBIIEIPBDE_003Ek__BackingField;

	public const float FKCAFJGNGIM = 10f;

	[CompilerGenerated]
	private int _003CHKIBIJPCEON_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CFHJCFFIAAOB_003Ek__BackingField;

	public float OKFNIFEBOOP;

	public float GAACADLOBAN;

	public float FDGMOOOMLNI;

	public float ELEBMOANFLN;

	public float JBNLMINMHLC;

	public float GEKHBCEJLFB;

	public float HEIMLEEGANF;

	public float LPIHNBBPBCA;

	public float LCLKHGFJHPJ;

	private TimeTweener BEGFIIPHIJP;

	[CompilerGenerated]
	private Guid? _003CMHOEGBAGFNO_003Ek__BackingField;

	public static TimeManager instance => null;

	public BMDADPPMCOK pauseStatusFlags
	{
		[CompilerGenerated]
		get
		{
			return default(BMDADPPMCOK);
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public static float pauseTimeLeft => 0f;

	public static float pauseTimeLeftRemote => 0f;

	public static float deltaTimeWithoutPauses => 0f;

	public static float realDeltaTime => 0f;

	public static float realTimeWithoutPauses => 0f;

	public bool isPaused => false;

	public bool isPausedLocaly => false;

	public bool isPausedRemotely => false;

	public static DateTime pauseStart => default(DateTime);

	public static DateTime pauseStartRemote => default(DateTime);

	public int pauseCounter
	{
		[CompilerGenerated]
		get
		{
			return 0;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public int pauseCounterRemote
	{
		[CompilerGenerated]
		get
		{
			return 0;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public Guid? PhotonSubscriberId
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public event Action<BMDADPPMCOK> GamePaused
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

	public event Action<BMDADPPMCOK> GameResumed
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

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	protected void Update()
	{
	}

	public void OnDestroy()
	{
	}

	private void FNBKIPIFMHO(bool PHDBMIIGJKC, bool EGFPCAOANDL)
	{
	}

	[PunRPC]
	private void PauseGameRPC(bool PHDBMIIGJKC, int MIFHPHNIMPF)
	{
	}

	public void ResetPauseCounters()
	{
	}

	private void EBODGNFPFFM(float HEGJEHHOGLJ, bool EGFADMKNHPA)
	{
	}

	public void ResumeGameForOpponent(float HEGJEHHOGLJ = 0f)
	{
	}

	[PunRPC]
	private void ResumeGameRPC(float HEGJEHHOGLJ)
	{
	}

	[PunRPC]
	private void ResumeGameForOpponentRPC(float HEGJEHHOGLJ)
	{
	}

	public void SetTimeScale(float HHDCBKDKICG)
	{
	}

	public void EndGame()
	{
	}

	private void NDJAHDHKCMG(UITweener GDPAJADKOPD)
	{
	}

	private void KAOCNDKBGNL(UITweener GDPAJADKOPD)
	{
	}

	public void EndMission()
	{
	}

	public void EndOfEndGame()
	{
	}

	public static TimeTweener Begin(float GHPPCNBBHDK, float EMMCJEEABGA, float FFJGKOLGFLL)
	{
		return null;
	}

	private static TimeTweener APNAJPEBBIP(float GHPPCNBBHDK, float EMMCJEEABGA, float FFJGKOLGFLL)
	{
		return null;
	}

	public static void FreezeGame()
	{
	}

	public static void Pause(bool PHDBMIIGJKC)
	{
	}

	public static void Reset()
	{
	}

	public static void Resume(float HEGJEHHOGLJ = 0f)
	{
	}

	public static void ResumeAfterReconnect()
	{
	}

	public static void UnFreezeGame(float HEGJEHHOGLJ = 0f)
	{
	}

	public static float GetTimeScaledSpeed(float ACLINDOAODK, bool AHPDFHNBCCN)
	{
		return 0f;
	}

	public static float GetTimeScaledInterval(float DPCKFGCODIL, bool AHPDFHNBCCN)
	{
		return 0f;
	}

	void IOnPhotonSerializeViewSubscriber.OnPhotonSerializeView(PhotonStream EENHMNOPHDF, PhotonMessageInfo INADGPICPMO)
	{
	}

	public void DebugTime()
	{
	}

	public void SetupPhysicsTiming(bool LPEJLMHKFLH)
	{
	}

	[CompilerGenerated]
	private void HIKGDKPPBPD(UITweener JFFJNCBEGDB)
	{
	}
}
