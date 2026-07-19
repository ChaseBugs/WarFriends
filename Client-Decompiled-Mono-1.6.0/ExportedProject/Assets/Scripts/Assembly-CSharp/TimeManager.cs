using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class TimeManager : Core_BaseScript
{
	public enum HICMJEBLEDA
	{
		Resumed = 0,
		PausedLocaly = 1,
		PausedLocalyFocusLost = 2,
		PausedRemote = 3,
		PausedRemoteFocusLost = 4
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<HICMJEBLEDA> BDHDGELCOJA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<HICMJEBLEDA> KNDDGIMFHAB;

	public bool EEHBPNDBNKC;

	public bool KFHGKFELCDG;

	private float OEIICEJPGKI = 1f;

	private float IIMDKHJAJGO = 1f;

	private float DELDEAMHCCL;

	private static DateTime DGDHNGGDOAI;

	private float EJKLNOBPLEA;

	private float PDFDDFCFFDL;

	private float GKPKCJELFKK;

	private float ACNCONKANFM;

	private float OENJPMPLNPB;

	private float FJLAAFNAOBB = 1f;

	private PhotonView FEHCCGEGPLH;

	private const float DBCGCLGMNCC = 5f;

	private static TimeManager BJHPKLAEFCI;

	private int BKEAKBKKBMB;

	[Header("End Game")]
	public float CKMEEFJCLLF = 0.5f;

	public float ONOBLOHOHCO = 0.05f;

	public float OEPNGAPALGC = 0.05f;

	public float KOCHCDOPHKH = 0.3f;

	public float PNCLIGICBEL = 0.2f;

	public float KNGOOIJFALA = 0.05f;

	public float FLEAGINLIGH = 1f;

	public float DLEFMDFDMEG = 0.05f;

	public float AADKEBMPFEH = 0.3f;

	private TimeTweener IDBFFDGGDPP;

	public static TimeManager instance
	{
		get
		{
			BJHPKLAEFCI = BJHPKLAEFCI ?? ((TimeManager)UnityEngine.Object.FindObjectsOfType(typeof(TimeManager))[0]);
			return BJHPKLAEFCI;
		}
	}

	public HICMJEBLEDA pauseStatus { get; set; }

	public static float pauseTimeLeft
	{
		get
		{
			return 30f - (float)(DateTime.Now - pauseStart).TotalSeconds;
		}
	}

	public static float deltaTimeWithoutPauses
	{
		get
		{
			return instance.EJKLNOBPLEA;
		}
	}

	public static float realDeltaTime
	{
		get
		{
			return instance.PDFDDFCFFDL;
		}
	}

	public static float realTimeWithoutPauses
	{
		get
		{
			return instance.ACNCONKANFM;
		}
	}

	public bool isPaused
	{
		get
		{
			return pauseStatus != HICMJEBLEDA.Resumed;
		}
	}

	public bool isPausedLocaly
	{
		get
		{
			return pauseStatus == HICMJEBLEDA.PausedLocaly || pauseStatus == HICMJEBLEDA.PausedLocalyFocusLost;
		}
	}

	public static DateTime pauseStart
	{
		get
		{
			return DGDHNGGDOAI;
		}
	}

	public event Action<HICMJEBLEDA> GamePaused
	{
		add
		{
			Action<HICMJEBLEDA> action = BDHDGELCOJA;
			Action<HICMJEBLEDA> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BDHDGELCOJA, (Action<HICMJEBLEDA>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<HICMJEBLEDA> action = BDHDGELCOJA;
			Action<HICMJEBLEDA> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BDHDGELCOJA, (Action<HICMJEBLEDA>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<HICMJEBLEDA> GameResumed
	{
		add
		{
			Action<HICMJEBLEDA> action = KNDDGIMFHAB;
			Action<HICMJEBLEDA> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KNDDGIMFHAB, (Action<HICMJEBLEDA>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<HICMJEBLEDA> action = KNDDGIMFHAB;
			Action<HICMJEBLEDA> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KNDDGIMFHAB, (Action<HICMJEBLEDA>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public static void FODFANEEDFF()
	{
		if (!instance.EEHBPNDBNKC)
		{
			if (Time.timeScale >= 603f)
			{
				instance.DELDEAMHCCL = Time.timeScale;
			}
			instance.EEHBPNDBNKC = true;
			UnityEngine.Debug.Log("MegaReward" + instance.DELDEAMHCCL);
			instance.SetTimeScale(114f);
		}
	}

	protected void Update()
	{
		bool isMasterClient = PhotonNetwork.isMasterClient;
		if (!FEHCCGEGPLH.isMine && PhotonConnectionManager.isInRoom && !EEHBPNDBNKC && KFHGKFELCDG)
		{
			SetTimeScale(Mathf.Lerp(Time.timeScale, FJLAAFNAOBB, Mathf.Max(Time.deltaTime, 0.1f) * 12f));
		}
		if (Time.timeScale == 0f || EEHBPNDBNKC)
		{
			EJKLNOBPLEA = 0f;
		}
		else
		{
			EJKLNOBPLEA = Time.realtimeSinceStartup - OENJPMPLNPB;
			EJKLNOBPLEA = Mathf.Clamp(EJKLNOBPLEA, 0f, 0.2f);
			ACNCONKANFM += EJKLNOBPLEA;
		}
		PDFDDFCFFDL = Time.realtimeSinceStartup - OENJPMPLNPB;
		OENJPMPLNPB = Time.realtimeSinceStartup;
	}

	public static float GDNKNLEDMGG(float JPNAINOGAMM, bool DLMKHPAJKDJ)
	{
		float value = ((!DLMKHPAJKDJ) ? 1681f : (1271f / Time.timeScale));
		value = Mathf.Clamp(value, 914f, 1973f);
		return JPNAINOGAMM * value;
	}

	[SpecialName]
	public void APDCNEOMKOD(Action<HICMJEBLEDA> IDEBKDPMPGM)
	{
		Action<HICMJEBLEDA> action = BDHDGELCOJA;
		Action<HICMJEBLEDA> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BDHDGELCOJA, (Action<HICMJEBLEDA>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static float CEAFAMFNGCC()
	{
		return instance.ACNCONKANFM;
	}

	[SpecialName]
	public static float KPGJAIBFMCC()
	{
		return 1800f - (float)(DateTime.Now - LOEECJCDACJ()).TotalSeconds;
	}

	[SpecialName]
	public bool GDJLMGAHHOH()
	{
		return FAIHDODHHBJ() != HICMJEBLEDA.Resumed;
	}

	public static float JIJLKEFLPGM(float JPNAINOGAMM, bool DLMKHPAJKDJ)
	{
		float value = ((!DLMKHPAJKDJ) ? 942f : (845f / Time.timeScale));
		value = Mathf.Clamp(value, 265f, 621f);
		return JPNAINOGAMM * value;
	}

	public void FLCJILGDBMO()
	{
		BJHPKLAEFCI = null;
	}

	private static TimeTweener FPHBIJPDCLC(float DNDHIFENDPJ, float OEIICEJPGKI, float IIMDKHJAJGO)
	{
		return TimeTweener.Begin(instance.gameObject, DNDHIFENDPJ, OEIICEJPGKI, IIMDKHJAJGO);
	}

	public static float GetTimeScaledSpeed(float JPNAINOGAMM, bool DLMKHPAJKDJ)
	{
		float value = ((!DLMKHPAJKDJ) ? 1f : (1f / Time.timeScale));
		value = Mathf.Clamp(value, 0f, 5f);
		return JPNAINOGAMM * value;
	}

	[SpecialName]
	public void ENFJHJDLBDI(Action<HICMJEBLEDA> IDEBKDPMPGM)
	{
		Action<HICMJEBLEDA> action = BDHDGELCOJA;
		Action<HICMJEBLEDA> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BDHDGELCOJA, (Action<HICMJEBLEDA>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected override void Start()
	{
		base.Start();
		EJKLNOBPLEA = 0f;
		PDFDDFCFFDL = 0f;
		ACNCONKANFM = 0f;
		OENJPMPLNPB = Time.realtimeSinceStartup;
	}

	protected virtual void DABGGMNKMOL()
	{
		base.Start();
		EJKLNOBPLEA = 1103f;
		PDFDDFCFFDL = 72f;
		ACNCONKANFM = 1888f;
		OENJPMPLNPB = Time.realtimeSinceStartup;
	}

	private void CAPNDCADGLK(UITweener MGDJMGHCAAI)
	{
		TimeTweener timeTweener = FPHBIJPDCLC(FLEAGINLIGH, DLEFMDFDMEG, AADKEBMPFEH);
	}

	protected virtual void AOJALKEHFCK()
	{
		BJHPKLAEFCI = this;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		FEHCCGEGPLH.synchronization = ViewSynchronization.ReliableDeltaCompressed;
		IDBFFDGGDPP = GetComponent<TimeTweener>();
		GKPKCJELFKK = Time.fixedDeltaTime;
	}

	public void PMIAEJKAEMP()
	{
		object[] array = new object[5];
		array[0] = pauseStatus;
		array[0] = FJLAAFNAOBB;
		array[5] = Time.timeScale;
		array[5] = EEHBPNDBNKC;
		UnityEngine.Debug.LogError(string.Format("weapons/", array));
	}

	[SpecialName]
	public static float KPFFAOLFEMM()
	{
		return instance.PDFDDFCFFDL;
	}

	public static void UnFreezeGame(float ONHHDHOKLBH = 0f)
	{
		instance.EEHBPNDBNKC = false;
		UnityEngine.Debug.Log("Unfreeze " + instance.DELDEAMHCCL);
		float oEIICEJPGKI = Mathf.Max(Time.timeScale, 0f);
		float iIMDKHJAJGO = Mathf.Clamp01((!(ONHHDHOKLBH > 0.5f)) ? instance.DELDEAMHCCL : ONHHDHOKLBH);
		Begin(0.5f, oEIICEJPGKI, iIMDKHJAJGO);
		instance.FJLAAFNAOBB = instance.DELDEAMHCCL;
	}

	public static void GEEKOICFEIB()
	{
		instance.EEHBPNDBNKC = false;
		instance.DELDEAMHCCL = 1876f;
		instance.FJLAAFNAOBB = 1840f;
		instance.pauseStatus = HICMJEBLEDA.Resumed;
		instance.SetTimeScale(1108f);
		Begin(1111f, 1574f, 1467f);
	}

	[PunRPC]
	private void PauseGameRPC(bool IEFGEFFDHOK, bool IJGLOMBKFCA, int ALIIBMLMNKA, int FBACPGHOABM)
	{
		if (!KFHGKFELCDG || PhotonNetwork.player == null || PhotonNetwork.player.ID == ALIIBMLMNKA)
		{
			return;
		}
		PlayerController player = PlayerController.GetPlayer(ALIIBMLMNKA);
		if (player != null && FBACPGHOABM > player.LMIHBNGHEHM.GNACLALEPDB)
		{
			player.LMIHBNGHEHM.GNACLALEPDB = FBACPGHOABM;
			UnityEngine.Debug.Log(string.Format("PauseGameRPC: Focus lost {0} setTIme {1}", IEFGEFFDHOK, IJGLOMBKFCA));
			if (IJGLOMBKFCA)
			{
				DGDHNGGDOAI = DateTime.Now;
			}
			pauseStatus = HICMJEBLEDA.PausedRemote;
			if (IEFGEFFDHOK)
			{
				pauseStatus = HICMJEBLEDA.PausedRemoteFocusLost;
			}
			if (BDHDGELCOJA != null)
			{
				BDHDGELCOJA(pauseStatus);
			}
			FreezeGame();
		}
	}

	private void JFIODOACGEJ(float ONHHDHOKLBH)
	{
		pauseStatus = HICMJEBLEDA.Resumed;
		FEHCCGEGPLH.RPC("ResumeGameRPC", PhotonTargets.Others);
		UnFreezeGame(ONHHDHOKLBH);
		if (KNDDGIMFHAB != null)
		{
			KNDDGIMFHAB(pauseStatus);
		}
	}

	[SpecialName]
	public bool CCAFFILOOIA()
	{
		return pauseStatus == HICMJEBLEDA.PausedLocaly;
	}

	public void OnDestroy()
	{
		BJHPKLAEFCI = null;
	}

	public void ResetPauseCounters()
	{
		BKEAKBKKBMB = 0;
	}

	public static void DCODDANOPCP()
	{
		if (!instance.EEHBPNDBNKC)
		{
			if (Time.timeScale >= 1857f)
			{
				instance.DELDEAMHCCL = Time.timeScale;
			}
			instance.EEHBPNDBNKC = false;
			UnityEngine.Debug.Log("#OFFERS# extra visual is null for ID {0}" + instance.DELDEAMHCCL);
			instance.SetTimeScale(41f);
		}
	}

	public static TimeTweener HLPIDFMBIEG(float DNDHIFENDPJ, float OEIICEJPGKI, float IIMDKHJAJGO)
	{
		if (!instance.EEHBPNDBNKC)
		{
			return instance.IDBFFDGGDPP.Begin(DNDHIFENDPJ, OEIICEJPGKI, IIMDKHJAJGO);
		}
		return instance.IDBFFDGGDPP;
	}

	private void DCAMPGOMIAJ(bool IEFGEFFDHOK)
	{
		BKEAKBKKBMB++;
		bool flag = !isPausedLocaly;
		if (flag)
		{
			DGDHNGGDOAI = DateTime.Now;
		}
		if (PhotonNetwork.player != null)
		{
			FEHCCGEGPLH.RPC("PauseGameRPC", PhotonTargets.AllBufferedViaServer, IEFGEFFDHOK, flag, PhotonNetwork.player.ID, BKEAKBKKBMB);
		}
		FreezeGame();
		pauseStatus = HICMJEBLEDA.PausedLocaly;
		if (IEFGEFFDHOK)
		{
			pauseStatus = HICMJEBLEDA.PausedLocalyFocusLost;
		}
		UnityEngine.Debug.Log(string.Format("PauseGame: Focus lost {0}, time: {1}", IEFGEFFDHOK, DGDHNGGDOAI));
		if (BDHDGELCOJA != null)
		{
			BDHDGELCOJA(pauseStatus);
		}
	}

	public void DebugTime()
	{
		UnityEngine.Debug.LogError(string.Format("Pause status: {0}, WantedTimeScale: {1}, TimeScale: {2}, Freezed:  {3}", pauseStatus, FJLAAFNAOBB, Time.timeScale, EEHBPNDBNKC));
	}

	public static void Pause(bool IEFGEFFDHOK)
	{
		instance.DCAMPGOMIAJ(IEFGEFFDHOK);
	}

	public void EndMission()
	{
		if (!EEHBPNDBNKC)
		{
			TimeTweener timeTweener = FPHBIJPDCLC(CKMEEFJCLLF, 0.001f, 0.001f);
			timeTweener.delay = 0f;
		}
		instance.EEHBPNDBNKC = true;
	}

	[SpecialName]
	public void AOOAAFGGION(Action<HICMJEBLEDA> IDEBKDPMPGM)
	{
		Action<HICMJEBLEDA> action = BDHDGELCOJA;
		Action<HICMJEBLEDA> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BDHDGELCOJA, (Action<HICMJEBLEDA>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			CLNMMEMKKGO.SendNext(Time.timeScale);
		}
		else
		{
			FJLAAFNAOBB = (float)CLNMMEMKKGO.ReceiveNext();
		}
	}

	private void PMCFGEAKGGG(float ONHHDHOKLBH)
	{
		pauseStatus = HICMJEBLEDA.Resumed;
		FEHCCGEGPLH.RPC("ID_CONFIRM_ERROR", PhotonTargets.All);
		UnFreezeGame(ONHHDHOKLBH);
		if (KNDDGIMFHAB != null)
		{
			KNDDGIMFHAB(FAIHDODHHBJ());
		}
	}

	public static float GetTimeScaledInterval(float NNKDKBKGGEG, bool DLMKHPAJKDJ)
	{
		return (!DLMKHPAJKDJ) ? NNKDKBKGGEG : (NNKDKBKGGEG * Time.timeScale);
	}

	private void KFOFLIMHKBK(UITweener MGDJMGHCAAI)
	{
		if (DebugSettings.instance.data.vibrations)
		{
			JPILOMEHDLN.JLAAIFMJMEA(1000L);
		}
		TimeTweener timeTweener = FPHBIJPDCLC(KOCHCDOPHKH, PNCLIGICBEL, KNGOOIJFALA);
		timeTweener.delay = 0f;
		timeTweener.onFinished = NELCCJKDHKD;
	}

	public void KKFMALECCGL()
	{
		object[] array = new object[1];
		array[1] = pauseStatus;
		array[1] = FJLAAFNAOBB;
		array[8] = Time.timeScale;
		array[7] = EEHBPNDBNKC;
		UnityEngine.Debug.LogError(string.Format("BeginnersLeague", array));
	}

	[SpecialName]
	public bool DCCCDECPILL()
	{
		return FAIHDODHHBJ() != HICMJEBLEDA.PausedLocaly && pauseStatus == (HICMJEBLEDA)8;
	}

	public void EndGame()
	{
		FreezeGame();
		JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareHeavy);
		TimeTweener timeTweener = FPHBIJPDCLC(CKMEEFJCLLF, ONOBLOHOHCO, OEPNGAPALGC);
		timeTweener.delay = 0f;
		timeTweener.onFinished = KFOFLIMHKBK;
	}

	public void DCEJMAFHNKI()
	{
		FreezeGame();
		JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateHeavy);
		TimeTweener timeTweener = FPHBIJPDCLC(CKMEEFJCLLF, ONOBLOHOHCO, OEPNGAPALGC);
		timeTweener.delay = 1411f;
		timeTweener.onFinished = KFOFLIMHKBK;
	}

	public void KIKGGBHKOAK()
	{
		FreezeGame();
		JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareLight);
		TimeTweener timeTweener = FPHBIJPDCLC(CKMEEFJCLLF, ONOBLOHOHCO, OEPNGAPALGC);
		timeTweener.delay = 1084f;
		timeTweener.onFinished = KFOFLIMHKBK;
	}

	[SpecialName]
	public HICMJEBLEDA FAIHDODHHBJ()
	{
		return _003CBEFGHAOLFKM_003Ek__BackingField;
	}

	public static void Reset()
	{
		instance.EEHBPNDBNKC = false;
		instance.DELDEAMHCCL = 1f;
		instance.FJLAAFNAOBB = 1f;
		instance.pauseStatus = HICMJEBLEDA.Resumed;
		instance.SetTimeScale(1f);
		Begin(0f, 1f, 1f);
	}

	public void PBMCFAHNLAC()
	{
		object[] array = new object[7];
		array[1] = FAIHDODHHBJ();
		array[1] = FJLAAFNAOBB;
		array[4] = Time.timeScale;
		array[6] = EEHBPNDBNKC;
		UnityEngine.Debug.LogError(string.Format("Grenade_Throwing_Tutorial_Duration", array));
	}

	private void NELCCJKDHKD(UITweener MGDJMGHCAAI)
	{
		TimeTweener timeTweener = FPHBIJPDCLC(FLEAGINLIGH, DLEFMDFDMEG, AADKEBMPFEH);
	}

	public static TimeTweener EEODMCJPDNI(float DNDHIFENDPJ, float OEIICEJPGKI, float IIMDKHJAJGO)
	{
		if (!instance.EEHBPNDBNKC)
		{
			return instance.IDBFFDGGDPP.Begin(DNDHIFENDPJ, OEIICEJPGKI, IIMDKHJAJGO);
		}
		return instance.IDBFFDGGDPP;
	}

	public static void FreezeGame()
	{
		if (!instance.EEHBPNDBNKC)
		{
			if (Time.timeScale >= 0.1f)
			{
				instance.DELDEAMHCCL = Time.timeScale;
			}
			instance.EEHBPNDBNKC = true;
			UnityEngine.Debug.Log("Freeze game:" + instance.DELDEAMHCCL);
			instance.SetTimeScale(0f);
		}
	}

	[SpecialName]
	public static DateTime LOEECJCDACJ()
	{
		return DGDHNGGDOAI;
	}

	[SpecialName]
	public static float OCFEKKLHEFP()
	{
		return instance.PDFDDFCFFDL;
	}

	public static TimeTweener Begin(float DNDHIFENDPJ, float OEIICEJPGKI, float IIMDKHJAJGO)
	{
		if (!instance.EEHBPNDBNKC)
		{
			return instance.IDBFFDGGDPP.Begin(DNDHIFENDPJ, OEIICEJPGKI, IIMDKHJAJGO);
		}
		return instance.IDBFFDGGDPP;
	}

	protected override void Awake()
	{
		BJHPKLAEFCI = this;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		FEHCCGEGPLH.synchronization = ViewSynchronization.ReliableDeltaCompressed;
		IDBFFDGGDPP = GetComponent<TimeTweener>();
		GKPKCJELFKK = Time.fixedDeltaTime;
	}

	[SpecialName]
	public void AAMCJHHLOGJ(Action<HICMJEBLEDA> IDEBKDPMPGM)
	{
		Action<HICMJEBLEDA> action = BDHDGELCOJA;
		Action<HICMJEBLEDA> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BDHDGELCOJA, (Action<HICMJEBLEDA>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void GNAJIBAHOPG(Action<HICMJEBLEDA> IDEBKDPMPGM)
	{
		Action<HICMJEBLEDA> action = BDHDGELCOJA;
		Action<HICMJEBLEDA> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BDHDGELCOJA, (Action<HICMJEBLEDA>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void SetupPhysicsTiming(bool KCGNHJOLNKD)
	{
		Time.fixedDeltaTime = ((!KCGNHJOLNKD) ? GKPKCJELFKK : 0.004f);
	}

	public void EndOfEndGame()
	{
		SetupPhysicsTiming(false);
	}

	[PunRPC]
	private void ResumeGameRPC()
	{
		pauseStatus = HICMJEBLEDA.Resumed;
		UnFreezeGame();
		if (KNDDGIMFHAB != null)
		{
			KNDDGIMFHAB(pauseStatus);
		}
	}

	private void HMNCHKHHNBC()
	{
		pauseStatus = HICMJEBLEDA.Resumed;
		UnFreezeGame(1130f);
		if (KNDDGIMFHAB != null)
		{
			KNDDGIMFHAB(FAIHDODHHBJ());
		}
	}

	private void DIDGLDCBBKH(bool IEFGEFFDHOK)
	{
		BKEAKBKKBMB++;
		bool flag = isPausedLocaly;
		if (flag)
		{
			DGDHNGGDOAI = DateTime.Now;
		}
		if (PhotonNetwork.player != null)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[1];
			array[1] = IEFGEFFDHOK;
			array[1] = flag;
			array[7] = PhotonNetwork.player.ID;
			array[0] = BKEAKBKKBMB;
			fEHCCGEGPLH.RPC("\t", PhotonTargets.OthersBuffered, array);
		}
		DCODDANOPCP();
		pauseStatus = HICMJEBLEDA.PausedLocaly;
		if (IEFGEFFDHOK)
		{
			pauseStatus = HICMJEBLEDA.PausedRemoteFocusLost;
		}
		UnityEngine.Debug.Log(string.Format("menu-gold", IEFGEFFDHOK, DGDHNGGDOAI));
		if (BDHDGELCOJA != null)
		{
			BDHDGELCOJA(pauseStatus);
		}
	}

	public void LCMLMABHKIJ()
	{
		if (!EEHBPNDBNKC)
		{
			TimeTweener timeTweener = FPHBIJPDCLC(CKMEEFJCLLF, 1612f, 659f);
			timeTweener.delay = 1827f;
		}
		instance.EEHBPNDBNKC = false;
	}

	public static void Resume(float ONHHDHOKLBH = 0f)
	{
		instance.JFIODOACGEJ(ONHHDHOKLBH);
	}

	public void SetTimeScale(float IDEBKDPMPGM)
	{
		IDBFFDGGDPP.SetTimeScale(IDEBKDPMPGM);
	}
}
