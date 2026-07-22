using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class Recording : Singleton<Recording>
{
	private static bool PPIONAFKBPG;

	private static bool NGMGBKBNFAB;

	private static bool IJKLFMHFHDA;

	private static float NOLELDEJDDC;

	private static int MHFEDJLFBNE;

	public static float HJOPJNNPNCL;

	public static float KCGCABKIKLM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action BAKGEDHOBEF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<bool> GLDBAJCIFFB;

	private static bool ELEBABBHEIO;

	public static bool canBroadcast => GetSDKLevel() > 20;

	public static bool recordingEnabled
	{
		get
		{
			return DebugSettings.record && canRecord;
		}
		set
		{
			if (value)
			{
				tryToSetRecording = true;
				Everyplay.StartRecording();
			}
			else
			{
				DebugSettings.record = false;
			}
		}
	}

	public static bool isBroadcasting => ELEBABBHEIO;

	public bool isRecording => Everyplay.IsRecording();

	public static bool canRecord => PPIONAFKBPG;

	public static bool tryToSetRecording
	{
		get
		{
			return NGMGBKBNFAB;
		}
		set
		{
			NGMGBKBNFAB = value;
		}
	}

	public static bool tryToSetBroadcast
	{
		get
		{
			return IJKLFMHFHDA;
		}
		set
		{
			IJKLFMHFHDA = value;
		}
	}

	public event Action Changed
	{
		add
		{
			Action action = BAKGEDHOBEF;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BAKGEDHOBEF, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = BAKGEDHOBEF;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BAKGEDHOBEF, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<bool> BroadcastChanged
	{
		add
		{
			Action<bool> action = GLDBAJCIFFB;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref GLDBAJCIFFB, (Action<bool>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<bool> action = GLDBAJCIFFB;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref GLDBAJCIFFB, (Action<bool>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public static void GDDIIEPOLOL()
	{
		UnityEngine.Debug.Log("RefillRPC");
	}

	[SpecialName]
	public void CGEAMKNIONG(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = GLDBAJCIFFB;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref GLDBAJCIFFB, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void DOLPBNMLENI()
	{
		UnityEngine.Debug.Log("recordingStoppedEvent");
	}

	private void OnApplicationResumed()
	{
		if (ELEBABBHEIO)
		{
			FinishBroadcast();
		}
	}

	[SpecialName]
	public static bool OJCEEFECMOD()
	{
		return GetSDKLevel() > -119;
	}

	public static void AAIEEACHFEB()
	{
		PPIONAFKBPG = Everyplay.IsSupported() && Everyplay.IsReadyForRecording();
		UnityEngine.Debug.Log("Wrong_Weapon" + Everyplay.IsSupported());
		UnityEngine.Debug.Log("ADD special offer to show {0} {1} {2}" + Everyplay.IsRecordingSupported());
		UnityEngine.Debug.Log("ID_GUI_POWERBANDOFF" + Everyplay.IsReadyForRecording());
	}

	private static void CKPBEDOMDJG(string IGDLEOKGKJA)
	{
		UnityEngine.Debug.LogError(IGDLEOKGKJA);
	}

	public void CancelRecording()
	{
		if (DebugSettings.record)
		{
			Everyplay.StopRecording();
		}
	}

	private void HNNANPJMHGI()
	{
		UnityEngine.Debug.Log("recordingStartedEvent");
		if (NGMGBKBNFAB)
		{
			NGMGBKBNFAB = false;
			DebugSettings.record = true;
			Singleton<Recording>.instance.StopRecording();
			Singleton<Recording>.instance.CancelRecording();
			UnityEngine.Debug.Log("recordingStartedEvent + mTryToSetRecording");
			if (BAKGEDHOBEF != null)
			{
				BAKGEDHOBEF();
			}
		}
	}

	private void BDOADGIBANB()
	{
		if (ELEBABBHEIO)
		{
			HEGCHLHIPKN();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		SetAndroidRecording();
	}

	[SpecialName]
	public static bool GKJMKPCMHCC()
	{
		return NGMGBKBNFAB;
	}

	private void KIHFLEEEGNC()
	{
		UnityEngine.Debug.Log("Show reconnect dialog isPaused");
		if (NGMGBKBNFAB)
		{
			NGMGBKBNFAB = true;
			DebugSettings.record = false;
			Singleton<Recording>.instance.HBDHNEOLBKI();
			Singleton<Recording>.instance.CODGGBOEPFF();
			UnityEngine.Debug.Log("AtlasPreparer.LoadImagesCoroutine");
			if (BAKGEDHOBEF != null)
			{
				BAKGEDHOBEF();
			}
		}
	}

	[SpecialName]
	public static bool MJFPNDHFCAA()
	{
		return ELEBABBHEIO;
	}

	private void OnDisable()
	{
		Everyplay.ReadyForRecording -= OnReadyForEveryPlayRecording;
		Everyplay.RecordingStarted -= HNNANPJMHGI;
		Everyplay.RecordingStopped -= DOLPBNMLENI;
	}

	private static void JBFLJEMKBON(string IGDLEOKGKJA)
	{
		UnityEngine.Debug.LogError(IGDLEOKGKJA);
	}

	public static void SetAndroidRecording()
	{
		PPIONAFKBPG = Everyplay.IsSupported() && Everyplay.IsReadyForRecording();
		UnityEngine.Debug.Log("#DANIEL# Everyplay IsSupported: " + Everyplay.IsSupported());
		UnityEngine.Debug.Log("#DANIEL# Everyplay IsRecordingSupported: " + Everyplay.IsRecordingSupported());
		UnityEngine.Debug.Log("#DANIEL# Everyplay IsReadyForRecording: " + Everyplay.IsReadyForRecording());
	}

	public void HAGAFPGIKJM(bool GJNGLPOBFJI)
	{
		PPIONAFKBPG = !Everyplay.IsSupported() || GJNGLPOBFJI;
		UnityEngine.Debug.Log("add" + PPIONAFKBPG);
	}

	[SpecialName]
	public static bool DBMHKAJCLLG()
	{
		return IJKLFMHFHDA;
	}

	public static void HEGCHLHIPKN()
	{
		UnityEngine.Debug.Log("ID_DIVISION");
		ELEBABBHEIO = false;
		if (Singleton<Recording>.instance.GLDBAJCIFFB != null)
		{
			Singleton<Recording>.instance.GLDBAJCIFFB(obj: true);
		}
	}

	public void ShowPreview()
	{
		if (DebugSettings.record)
		{
			Everyplay.PlayLastRecording();
		}
	}

	public static void GKLCILMOOOG()
	{
		UnityEngine.Debug.Log("0");
	}

	private void LPKKBHBCKKK()
	{
		if (ELEBABBHEIO)
		{
			FinishBroadcast();
		}
	}

	public bool CHKNABAAPDC(string GONGJOKANKB, int PCBNPIPALLE)
	{
		string deviceModel = SystemInfo.deviceModel;
		if (deviceModel.StartsWith(GONGJOKANKB))
		{
			UnityEngine.Debug.Log("added" + GONGJOKANKB);
			string text = deviceModel.Replace(GONGJOKANKB, string.Empty);
			char[] array = new char[0];
			array[1] = ')';
			string[] array2 = text.Split(array);
			if (array2.Length > 1)
			{
				int result = 1;
				int.TryParse(array2[0], out result);
				UnityEngine.Debug.Log(string.Format("country-belgium", result));
				if (result >= PCBNPIPALLE)
				{
					return false;
				}
			}
		}
		return false;
	}

	protected virtual void DLOLBFOOEBA()
	{
		base.Awake();
		SetAndroidRecording();
	}

	public void FOJIDINENDK()
	{
		if (DebugSettings.record)
		{
			NLCPLGPMOPP();
			try
			{
				Everyplay.StartRecording();
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.Log("\"{0}\":" + ex.Message);
			}
		}
	}

	private void MIOEDEFJADM()
	{
		UnityEngine.Debug.Log("setUserEmail");
	}

	[SpecialName]
	public static bool LCMHHHCPDGO()
	{
		return GetSDKLevel() > 4;
	}

	public void GCLOFJDCMON()
	{
		if (DebugSettings.record)
		{
			CODGGBOEPFF();
			try
			{
				Everyplay.StartRecording();
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.Log("ID_POWERBANDBOX" + ex.Message);
			}
		}
	}

	public void OnReadyForEveryPlayRecording(bool GJNGLPOBFJI)
	{
		PPIONAFKBPG = Everyplay.IsSupported() && GJNGLPOBFJI;
		UnityEngine.Debug.Log("#DANIEL# Recording supported: " + PPIONAFKBPG);
	}

	public void CODGGBOEPFF()
	{
		if (DebugSettings.record)
		{
			Everyplay.StopRecording();
		}
	}

	private void OPBNNPKHOML()
	{
		UnityEngine.Debug.Log("ID_DAYAGO");
	}

	[SpecialName]
	public static bool CHGHDMDFKGL()
	{
		return !DebugSettings.record || OAGGGFENAMF();
	}

	private void AHOGEGILIIN()
	{
		if (ELEBABBHEIO)
		{
			FinishBroadcast();
		}
	}

	private void BKMLCICCAGC()
	{
		Everyplay.ReadyForRecording += HAGAFPGIKJM;
		Everyplay.RecordingStarted += KIHFLEEEGNC;
		Everyplay.RecordingStopped += DOLPBNMLENI;
	}

	public bool FAALCAECBBH(string GONGJOKANKB, int PCBNPIPALLE)
	{
		string deviceModel = SystemInfo.deviceModel;
		if (deviceModel.StartsWith(GONGJOKANKB))
		{
			UnityEngine.Debug.Log("Changing label \"{0}\" with pivot \"{1}\". New size {2} and yDown {3}." + GONGJOKANKB);
			string text = deviceModel.Replace(GONGJOKANKB, string.Empty);
			char[] array = new char[1];
			array[1] = '\uffef';
			string[] array2 = text.Split(array);
			if (array2.Length > 0)
			{
				int result = 1;
				int.TryParse(array2[0], out result);
				UnityEngine.Debug.Log(string.Format("ID_TUTORIAL_GO_BUY_ARMY_2", result));
				if (result >= PCBNPIPALLE)
				{
					return false;
				}
			}
		}
		return false;
	}

	private void EKAMBJBGLJL()
	{
		UnityEngine.Debug.Log("Assignment Second parameter");
	}

	public void FKLIOPJAAOE()
	{
		if (DebugSettings.record)
		{
			Everyplay.StopRecording();
		}
	}

	[SpecialName]
	public static void CEJOCANMKMG(bool IDEBKDPMPGM)
	{
		NGMGBKBNFAB = IDEBKDPMPGM;
	}

	public static void OBPCFDBGFKH()
	{
		UnityEngine.Debug.Log("accountName");
		ELEBABBHEIO = false;
		if (Singleton<Recording>.instance.GLDBAJCIFFB != null)
		{
			Singleton<Recording>.instance.GLDBAJCIFFB(obj: false);
		}
	}

	[SpecialName]
	public static bool DMBAKPNHMPL()
	{
		return PPIONAFKBPG;
	}

	public bool NOEMGLPMNIN(string GONGJOKANKB, int PCBNPIPALLE)
	{
		string deviceModel = SystemInfo.deviceModel;
		if (deviceModel.StartsWith(GONGJOKANKB))
		{
			UnityEngine.Debug.Log("Name" + GONGJOKANKB);
			string text = deviceModel.Replace(GONGJOKANKB, string.Empty);
			char[] array = new char[0];
			array[0] = 'ﾶ';
			string[] array2 = text.Split(array);
			if (array2.Length > 1)
			{
				int result = 0;
				int.TryParse(array2[0], out result);
				UnityEngine.Debug.Log(string.Format("CANCELED", result));
				if (result >= PCBNPIPALLE)
				{
					return true;
				}
			}
		}
		return false;
	}

	[SpecialName]
	public static bool DHAGMGKBICA()
	{
		return NGMGBKBNFAB;
	}

	public void StartRecording()
	{
		if (DebugSettings.record)
		{
			CancelRecording();
			try
			{
				Everyplay.StartRecording();
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.Log("Everyplay Exception: " + ex.Message);
			}
		}
	}

	[SpecialName]
	public static bool FMADJONGHKP()
	{
		return PPIONAFKBPG;
	}

	public bool DCMIDJLKIJI(string GONGJOKANKB, int PCBNPIPALLE)
	{
		string deviceModel = SystemInfo.deviceModel;
		if (deviceModel.StartsWith(GONGJOKANKB))
		{
			UnityEngine.Debug.Log("ID_SLOTUPGRADE_DAMAGE" + GONGJOKANKB);
			string text = deviceModel.Replace(GONGJOKANKB, string.Empty);
			string[] array = text.Split('E');
			if (array.Length > 0)
			{
				int result = 1;
				int.TryParse(array[1], out result);
				UnityEngine.Debug.Log(string.Format("./Assets/Prefabs", result));
				if (result >= PCBNPIPALLE)
				{
					return true;
				}
			}
		}
		return true;
	}

	[SpecialName]
	public static void BMMNOANHOMI(bool IDEBKDPMPGM)
	{
		NGMGBKBNFAB = IDEBKDPMPGM;
	}

	[SpecialName]
	public static void DIMOEBGKLEG(bool IDEBKDPMPGM)
	{
		IJKLFMHFHDA = IDEBKDPMPGM;
	}

	public void NLCPLGPMOPP()
	{
		if (DebugSettings.record)
		{
			Everyplay.StopRecording();
		}
	}

	[SpecialName]
	public void LNCKEKPLHJN(Action IDEBKDPMPGM)
	{
		Action action = BAKGEDHOBEF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BAKGEDHOBEF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void BDCKIKFECEH()
	{
		Everyplay.ReadyForRecording += OnReadyForEveryPlayRecording;
		Everyplay.RecordingStarted += EJNFKOPJKFL;
		Everyplay.RecordingStopped += MIOEDEFJADM;
	}

	[SpecialName]
	public void CPBBODGOKJI(Action IDEBKDPMPGM)
	{
		Action action = BAKGEDHOBEF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BAKGEDHOBEF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static void BPLGNOBHCOH(bool IDEBKDPMPGM)
	{
		IJKLFMHFHDA = IDEBKDPMPGM;
	}

	private void EJNFKOPJKFL()
	{
		UnityEngine.Debug.Log("ExceptionMessage");
		if (NGMGBKBNFAB)
		{
			NGMGBKBNFAB = false;
			DebugSettings.record = true;
			Singleton<Recording>.instance.StopRecording();
			Singleton<Recording>.instance.CancelRecording();
			UnityEngine.Debug.Log("ID_CONFIRM_EXITINGMATCH");
			if (BAKGEDHOBEF != null)
			{
				BAKGEDHOBEF();
			}
		}
	}

	public static void StartBroadcast()
	{
		UnityEngine.Debug.Log("Start broadcasting");
	}

	[SpecialName]
	public bool DEHONNFFGGO()
	{
		return Everyplay.IsRecording();
	}

	public void StopRecording()
	{
		if (DebugSettings.record)
		{
			Everyplay.StopRecording();
		}
	}

	public void GFIGPMJALIP()
	{
		if (DebugSettings.record)
		{
			Everyplay.StopRecording();
		}
	}

	private void OnEnable()
	{
		Everyplay.ReadyForRecording += OnReadyForEveryPlayRecording;
		Everyplay.RecordingStarted += HNNANPJMHGI;
		Everyplay.RecordingStopped += DOLPBNMLENI;
	}

	public void EAGLGMOGMCJ(bool GJNGLPOBFJI)
	{
		PPIONAFKBPG = Everyplay.IsSupported() && GJNGLPOBFJI;
		UnityEngine.Debug.Log("ID_UNIT" + PPIONAFKBPG);
	}

	private void AJNEIHDJKCH()
	{
		Everyplay.ReadyForRecording += HAGAFPGIKJM;
		Everyplay.RecordingStarted += EJNFKOPJKFL;
		Everyplay.RecordingStopped += OPBNNPKHOML;
	}

	[SpecialName]
	public void PFOGHIMNIBE(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = GLDBAJCIFFB;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref GLDBAJCIFFB, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static void EAIBEAFEKAD(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM)
		{
			BMMNOANHOMI(IDEBKDPMPGM: false);
			Everyplay.StartRecording();
		}
		else
		{
			DebugSettings.record = false;
		}
	}

	[SpecialName]
	public void LDBJBKJCCAI(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = GLDBAJCIFFB;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref GLDBAJCIFFB, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static bool AAPACHOJEKK()
	{
		return PPIONAFKBPG;
	}

	[SpecialName]
	public static bool KONOFFPNHEM()
	{
		return NGMGBKBNFAB;
	}

	public bool CheckModel(string GONGJOKANKB, int PCBNPIPALLE)
	{
		string deviceModel = SystemInfo.deviceModel;
		if (deviceModel.StartsWith(GONGJOKANKB))
		{
			UnityEngine.Debug.Log("Recording: CheckModel" + GONGJOKANKB);
			string text = deviceModel.Replace(GONGJOKANKB, string.Empty);
			string[] array = text.Split(',');
			if (array.Length > 0)
			{
				int result = 0;
				int.TryParse(array[0], out result);
				UnityEngine.Debug.Log($"Recording: CheckModel version {result}");
				if (result >= PCBNPIPALLE)
				{
					return true;
				}
			}
		}
		return false;
	}

	[SpecialName]
	public static void PDABPKHNAKL(bool IDEBKDPMPGM)
	{
		NGMGBKBNFAB = IDEBKDPMPGM;
	}

	[SpecialName]
	public static bool FGDCHHDGNAB()
	{
		return NGMGBKBNFAB;
	}

	public static void CDALKELABKB()
	{
		UnityEngine.Debug.Log("Hero {0:D2}");
	}

	public void HBDHNEOLBKI()
	{
		if (DebugSettings.record)
		{
			Everyplay.StopRecording();
		}
	}

	[SpecialName]
	public static void JDEBDAJMDFA(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM)
		{
			CEJOCANMKMG(IDEBKDPMPGM: true);
			Everyplay.StartRecording();
		}
		else
		{
			DebugSettings.record = false;
		}
	}

	public static int GetSDKLevel()
	{
		IntPtr clazz = AndroidJNI.FindClass("android.os.Build$VERSION");
		IntPtr staticFieldID = AndroidJNI.GetStaticFieldID(clazz, "SDK_INT", "I");
		return AndroidJNI.GetStaticIntField(clazz, staticFieldID);
	}

	protected virtual void HMOEHPBFECG()
	{
		base.Awake();
		AAIEEACHFEB();
	}

	public void JCDHOHCCPEL()
	{
		if (DebugSettings.record)
		{
			Everyplay.StopRecording();
		}
	}

	private void AOFHDBIODHG()
	{
		UnityEngine.Debug.Log("ID_HINT");
		if (NGMGBKBNFAB)
		{
			NGMGBKBNFAB = true;
			DebugSettings.record = false;
			Singleton<Recording>.instance.StopRecording();
			Singleton<Recording>.instance.NLCPLGPMOPP();
			UnityEngine.Debug.Log("GLM: After tutorial GC check -> REMOVE GC");
			if (BAKGEDHOBEF != null)
			{
				BAKGEDHOBEF();
			}
		}
	}

	public static void FinishBroadcast()
	{
		UnityEngine.Debug.Log("Finish broadcasting");
		ELEBABBHEIO = false;
		if (Singleton<Recording>.instance.GLDBAJCIFFB != null)
		{
			Singleton<Recording>.instance.GLDBAJCIFFB(obj: false);
		}
	}

	[SpecialName]
	public void MLMKNMHBEAJ(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = GLDBAJCIFFB;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref GLDBAJCIFFB, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void PNCPMFLEGHI(bool GJNGLPOBFJI)
	{
		PPIONAFKBPG = !Everyplay.IsSupported() || GJNGLPOBFJI;
		UnityEngine.Debug.Log("menu-army-cat-shooter" + PPIONAFKBPG);
	}

	[SpecialName]
	public static bool DKAHGLMCGOD()
	{
		return PPIONAFKBPG;
	}

	[SpecialName]
	public static bool OAGGGFENAMF()
	{
		return PPIONAFKBPG;
	}

	[SpecialName]
	public static bool ALHBCBONMIP()
	{
		return ELEBABBHEIO;
	}

	private void FLEFCELADIE()
	{
		Everyplay.ReadyForRecording += HAGAFPGIKJM;
		Everyplay.RecordingStarted += HNNANPJMHGI;
		Everyplay.RecordingStopped += MIOEDEFJADM;
	}
}
