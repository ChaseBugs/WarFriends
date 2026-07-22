using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using WarFriends.Legacy;

public class WarArena : DatabaseSerializedObjectGeneric<WarArena.WarArenaData>
{
	[Serializable]
	public class WarArenaData
	{
		public ObscuredInt wins;

		public ObscuredInt lives = 3;

		public List<string> opponents = new List<string>();

		public string arenaId;

		public int runs;

		public string visualType;

		public int visualTimestamp;

		public int flawless;

		public int topRun;

		public int matches;

		public int shields;

		public bool played;

		public bool heartDialogShown;
	}

	private static WarArena BJHPKLAEFCI;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action MPAMONABMML;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<int> AEEJGOBGGCH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action PDHNCNPNFOD;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action MNKCLKOGMAC;

	[FormerlySerializedAs("JDJJCLHIOIK")]
	public List<WarArenaRule> GNGBLIIMJCJ = new List<WarArenaRule>();

	[FormerlySerializedAs("LNBNIBCCEFH")]
	public TextAsset HMMFCPNAFKO;

	public IKPLPPFFDNI FPLIPHCJGFO;

	public IKGCOGIODMO GCEEMAHCAJB;

	private WarArenaParameters PNEHGOINBBF;

	private List<WarArenaRule> NDIJMGCAJAO = new List<WarArenaRule>();

	private ArenaLootboxes BLLLKMIIHCM;

	private bool DFDFGFBBOEJ;

	private bool KAFGNKHAMEL = true;

	public static WarArena instance
	{
		get
		{
			BJHPKLAEFCI = BJHPKLAEFCI ?? ((WarArena)SingletonSupport.FindOrCreate(typeof(WarArena)));
			return BJHPKLAEFCI;
		}
	}

	public WarArenaParameters warArenaParameters => PNEHGOINBBF;

	public ArenaLootboxes arenaLootboxes => BLLLKMIIHCM ?? (BLLLKMIIHCM = GetComponent<ArenaLootboxes>());

	public WarArenaParameters wararenaParameters => PNEHGOINBBF ?? (PNEHGOINBBF = GetComponent<WarArenaParameters>());

	public bool isArenaTicketBought => FPLIPHCJGFO.INFLHPGMEOB == data.arenaId && (int)data.lives > 0 && (int)data.wins < FPLIPHCJGFO.FCDIFINLKIA && isOpened;

	public bool isGoodPing => CKHHAAJEBBN.DAMNJODDMNA;

	public bool isOpened
	{
		get
		{
			if (FPLIPHCJGFO == null)
			{
				return false;
			}
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			bool flag = FPLIPHCJGFO != null && data != null && FPLIPHCJGFO.JGBFNKBFCKM <= currentTimestamp && !isExpired;
			bool kAFGNKHAMEL = KAFGNKHAMEL;
			KAFGNKHAMEL = flag;
			if (!kAFGNKHAMEL && flag)
			{
				BFIJLJFOFCK();
			}
			return flag;
		}
	}

	public bool isExpired
	{
		get
		{
			if (FPLIPHCJGFO == null)
			{
				return true;
			}
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			bool flag = currentTimestamp > FPLIPHCJGFO.NGPMJNJPNMB;
			return FPLIPHCJGFO != null && data != null && flag;
		}
	}

	public bool isReminderTime
	{
		get
		{
			if (FPLIPHCJGFO == null)
			{
				return false;
			}
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num = (int)(float)wararenaParameters.GetRow(WarArenaParameters.rowIds.WarArenaReminderHours).FLOATVALUE;
			int num2 = num * 3600;
			int num3 = FPLIPHCJGFO.JGBFNKBFCKM - num2;
			return num3 <= currentTimestamp && currentTimestamp <= FPLIPHCJGFO.JGBFNKBFCKM;
		}
	}

	public int remainigTimeTillStart => Mathf.Max(0, FPLIPHCJGFO.JGBFNKBFCKM - Singleton<BeanstalkServerManager>.instance.currentTimestamp);

	public int remainigTimeTillEnd => Mathf.Max(0, FPLIPHCJGFO.NGPMJNJPNMB - Singleton<BeanstalkServerManager>.instance.currentTimestamp);

	public bool goldShieldsActive => data.shields > Singleton<BeanstalkServerManager>.instance.currentTimestamp;

	public int phaseNumber => FPLIPHCJGFO.NBLGBIJJPNA;

	public int wararenaTicketPrize
	{
		get
		{
			if (!data.played)
			{
				return 0;
			}
			if (data.arenaId != FPLIPHCJGFO.INFLHPGMEOB)
			{
				data.runs = 0;
			}
			return FPLIPHCJGFO.ENLDFDLMLKA(data.runs);
		}
	}

	public int extraLiveCost
	{
		get
		{
			if (FPLIPHCJGFO.NFOELJINGGN.Count == 0)
			{
				return 0;
			}
			int index = Mathf.Clamp(data.wins, 0, FPLIPHCJGFO.NFOELJINGGN.Count);
			IKPLPPFFDNI.MJPNFAKHHHI mJPNFAKHHHI = FPLIPHCJGFO.NFOELJINGGN[index];
			return mJPNFAKHHHI.HPLPAKOCOHN;
		}
	}

	public List<WarArenaRule> currenArenaRules => NDIJMGCAJAO;

	public event Action WarArenaDataChanged
	{
		add
		{
			Action action = MPAMONABMML;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref MPAMONABMML, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = MPAMONABMML;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref MPAMONABMML, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<int> LivesChanged
	{
		add
		{
			Action<int> action = AEEJGOBGGCH;
			Action<int> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref AEEJGOBGGCH, (Action<int>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<int> action = AEEJGOBGGCH;
			Action<int> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref AEEJGOBGGCH, (Action<int>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action WarArenaExpired
	{
		add
		{
			Action action = PDHNCNPNFOD;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref PDHNCNPNFOD, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = PDHNCNPNFOD;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref PDHNCNPNFOD, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action WarArenaStarter
	{
		add
		{
			Action action = MNKCLKOGMAC;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref MNKCLKOGMAC, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = MNKCLKOGMAC;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref MNKCLKOGMAC, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private int JHHKFPMOOLH(out bool NGPAEAIBFDH)
	{
		NGPAEAIBFDH = true;
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int jGBFNKBFCKM = FPLIPHCJGFO.JGBFNKBFCKM;
		int nGPMJNJPNMB = FPLIPHCJGFO.NGPMJNJPNMB;
		if (nGPMJNJPNMB < currentTimestamp)
		{
			return jGBFNKBFCKM;
		}
		if (jGBFNKBFCKM < currentTimestamp)
		{
			IKPLPPFFDNI.CIFMKGIKJFM cIFMKGIKJFM = FPLIPHCJGFO.HMINOMDIBAF;
			NGPAEAIBFDH = cIFMKGIKJFM == null;
			return (!NGPAEAIBFDH) ? cIFMKGIKJFM.FMCHEIHFCFO : jGBFNKBFCKM;
		}
		return jGBFNKBFCKM;
	}

	[SpecialName]
	public int CAGNHFGDDCJ()
	{
		if (FPLIPHCJGFO.NFOELJINGGN.Count == 0)
		{
			return 1;
		}
		int index = Mathf.Clamp(data.wins, 1, FPLIPHCJGFO.NFOELJINGGN.Count);
		IKPLPPFFDNI.MJPNFAKHHHI mJPNFAKHHHI = FPLIPHCJGFO.NFOELJINGGN[index];
		return mJPNFAKHHHI.HPLPAKOCOHN;
	}

	[SpecialName]
	public void BBHMOAEIKCD(Action<int> IDEBKDPMPGM)
	{
		Action<int> action = AEEJGOBGGCH;
		Action<int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref AEEJGOBGGCH, (Action<int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public List<WarArenaRule> DeserializeRules(string NGBOOPEALCG)
	{
		List<WarArenaRule> list = new List<WarArenaRule>();
		Dictionary<string, JToken> dictionary = JsonConvert.DeserializeObject<Dictionary<string, JToken>>(NGBOOPEALCG);
		foreach (KeyValuePair<string, JToken> item in dictionary)
		{
			WarArenaRule warArenaRule = DDHPCDNCBIJ(item.Key);
			if (warArenaRule != null)
			{
				warArenaRule.AJFMLBKNLOH(item.Value);
				list.Add(warArenaRule);
			}
			else
			{
				UnityEngine.Debug.LogError($"cant deserialize rule {item.Key}");
			}
		}
		return list;
	}

	public void NKFPADOCDMA()
	{
		BJHPKLAEFCI = null;
	}

	[SpecialName]
	public bool HBIJKMFFLEB()
	{
		if (FPLIPHCJGFO == null)
		{
			return true;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = (int)(float)IBHNLKEPELC().GetRow(WarArenaParameters.rowIds.ShieldHP).FLOATVALUE;
		int num2 = num * 104;
		int num3 = FPLIPHCJGFO.JGBFNKBFCKM - num2;
		return num3 > currentTimestamp || currentTimestamp > FPLIPHCJGFO.JGBFNKBFCKM;
	}

	[SpecialName]
	public int AKMMBOOKOIA()
	{
		return FPLIPHCJGFO.IAFELDBCJDB();
	}

	[SpecialName]
	public bool CJDCEJCEHJE()
	{
		return data.shields > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	public List<WarArenaRule> LEBPNELDIEG(string NGBOOPEALCG)
	{
		List<WarArenaRule> list = new List<WarArenaRule>();
		Dictionary<string, JToken> dictionary = JsonConvert.DeserializeObject<Dictionary<string, JToken>>(NGBOOPEALCG);
		foreach (KeyValuePair<string, JToken> item in dictionary)
		{
			WarArenaRule warArenaRule = DDHPCDNCBIJ(item.Key);
			if (warArenaRule != null)
			{
				warArenaRule.MPEICOLLNAB(item.Value);
				list.Add(warArenaRule);
			}
			else
			{
				UnityEngine.Debug.LogError(string.Format("ID_SEC", item.Key));
			}
		}
		return list;
	}

	[SpecialName]
	public ArenaLootboxes HNGMEGIHAEB()
	{
		return BLLLKMIIHCM ?? (BLLLKMIIHCM = GetComponent<ArenaLootboxes>());
	}

	public void UpdateLives(int EHMEFHBAJIH)
	{
		int num = EHMEFHBAJIH - (int)data.lives;
		data.lives = EHMEFHBAJIH;
		if (AEEJGOBGGCH != null && num != 0)
		{
			AEEJGOBGGCH(num);
		}
	}

	[SpecialName]
	public void AAICGCPCPNP(Action IDEBKDPMPGM)
	{
		Action action = PDHNCNPNFOD;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PDHNCNPNFOD, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void MKHMKIKNAKP()
	{
		if (Singleton<BeanstalkServerManager>.instance.DGBOELCCINL() && BALABLIGAHK() && !DFDFGFBBOEJ)
		{
			KLACIDPAOPN();
			DFDFGFBBOEJ = false;
			if (PDHNCNPNFOD != null)
			{
				PDHNCNPNFOD();
			}
		}
	}

	public void NextPhaseArenaNotification()
	{
		if (isArenaTicketBought)
		{
			bool NGPAEAIBFDH = true;
			int phaseStartTime = JHHKFPMOOLH(out NGPAEAIBFDH);
			if (!NGPAEAIBFDH)
			{
				PushNotificationManager.instance.ScheduleLocalWarArenaStart(phaseStartTime, NGPAEAIBFDH);
			}
		}
	}

	public void GLDLLNNDIOM(JToken OGNGMBLDAOP)
	{
		FPLIPHCJGFO = new IKPLPPFFDNI(OGNGMBLDAOP);
		string nHFGEMPOHEO = FPLIPHCJGFO.NHFGEMPOHEO;
		NDIJMGCAJAO = DeserializeRules(nHFGEMPOHEO);
		PushNotificationManager.instance.ScheduleLocalWarArenaReminder(FPLIPHCJGFO.JGBFNKBFCKM);
		bool NGPAEAIBFDH = false;
		int phaseStartTime = CCKHKHCPPBH(out NGPAEAIBFDH);
		if (NGPAEAIBFDH)
		{
			PushNotificationManager.instance.ScheduleLocalWarArenaStart(phaseStartTime, NGPAEAIBFDH);
		}
		DFDFGFBBOEJ = false;
		if (MPAMONABMML != null)
		{
			MPAMONABMML();
		}
	}

	private void KLACIDPAOPN()
	{
		JOPIPCDHOLF.LOBLLDBEHCJ();
	}

	[SpecialName]
	public List<WarArenaRule> NDPAKECCAIN()
	{
		return NDIJMGCAJAO;
	}

	private int FMAKDHFBKLM(out bool NGPAEAIBFDH)
	{
		NGPAEAIBFDH = true;
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		int jGBFNKBFCKM = FPLIPHCJGFO.JGBFNKBFCKM;
		int nGPMJNJPNMB = FPLIPHCJGFO.NGPMJNJPNMB;
		if (nGPMJNJPNMB < num)
		{
			return jGBFNKBFCKM;
		}
		if (jGBFNKBFCKM < num)
		{
			IKPLPPFFDNI.CIFMKGIKJFM cIFMKGIKJFM = FPLIPHCJGFO.GIACNNJALAI();
			NGPAEAIBFDH = cIFMKGIKJFM == null;
			return (!NGPAEAIBFDH) ? cIFMKGIKJFM.BLBOJGKMODM() : jGBFNKBFCKM;
		}
		return jGBFNKBFCKM;
	}

	[SpecialName]
	public bool NHLEKBIHDAL()
	{
		if (FPLIPHCJGFO == null)
		{
			return true;
		}
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		bool flag = num > FPLIPHCJGFO.NGPMJNJPNMB;
		return FPLIPHCJGFO == null || data == null || flag;
	}

	public void EICELBFHFAB()
	{
		BJHPKLAEFCI = null;
	}

	[SpecialName]
	public List<WarArenaRule> IPLJBGDBOKC()
	{
		return NDIJMGCAJAO;
	}

	public void GJKNFBFEOBJ()
	{
		BJHPKLAEFCI = null;
	}

	[SpecialName]
	public void GPEOHBCINCB(Action IDEBKDPMPGM)
	{
		Action action = PDHNCNPNFOD;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PDHNCNPNFOD, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void FailedDownloadWarArena()
	{
		DFDFGFBBOEJ = false;
	}

	[SpecialName]
	public WarArenaParameters IBHNLKEPELC()
	{
		return PNEHGOINBBF ?? (PNEHGOINBBF = GetComponent<WarArenaParameters>());
	}

	[SpecialName]
	public bool NNGLJEPPNKM()
	{
		return data.shields > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
	}

	public void TakePlayerLive()
	{
		UpdateLives(Mathf.Clamp((int)data.lives - 1, 0, int.MaxValue));
		Singleton<BeanstalkServerManager>.instance.TakeArenaLife();
	}

	public void AGPLFGDABLN(JToken OGNGMBLDAOP)
	{
		FPLIPHCJGFO = new IKPLPPFFDNI(OGNGMBLDAOP);
		string nHFGEMPOHEO = FPLIPHCJGFO.NHFGEMPOHEO;
		NDIJMGCAJAO = LEBPNELDIEG(nHFGEMPOHEO);
		PushNotificationManager.instance.ScheduleLocalWarArenaReminder(FPLIPHCJGFO.JGBFNKBFCKM);
		bool NGPAEAIBFDH = true;
		int phaseStartTime = CCKHKHCPPBH(out NGPAEAIBFDH);
		if (NGPAEAIBFDH)
		{
			PushNotificationManager.instance.ScheduleLocalWarArenaStart(phaseStartTime, NGPAEAIBFDH);
		}
		DFDFGFBBOEJ = true;
		if (MPAMONABMML != null)
		{
			MPAMONABMML();
		}
	}

	private void NNJHBNHHGOK()
	{
		FCIGAKGDAHO.CJNEPCDLHEG();
		data.topRun = 1;
		data.flawless = 0;
		if (MNKCLKOGMAC != null)
		{
			MNKCLKOGMAC();
		}
	}

	[SpecialName]
	public bool BALABLIGAHK()
	{
		if (FPLIPHCJGFO == null)
		{
			return false;
		}
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		bool flag = num > FPLIPHCJGFO.NGPMJNJPNMB;
		return FPLIPHCJGFO == null || data == null || flag;
	}

	private void BFIJLJFOFCK()
	{
		FCIGAKGDAHO.PNHDGLHLNIE();
		data.topRun = 0;
		data.flawless = 0;
		if (MNKCLKOGMAC != null)
		{
			MNKCLKOGMAC();
		}
	}

	public void OnDestroy()
	{
		BJHPKLAEFCI = null;
	}

	private void KPPNCJBMDPE(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		if (Singleton<GameController>.instance.isWarArena)
		{
			data.opponents.Add(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ALIIBMLMNKA);
		}
	}

	[SpecialName]
	public void JMPIKJCKNIJ(Action IDEBKDPMPGM)
	{
		Action action = MPAMONABMML;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MPAMONABMML, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private WarArenaRule DDHPCDNCBIJ(string KIONJHBOLKI)
	{
		foreach (WarArenaRule item in GNGBLIIMJCJ)
		{
			if (item.GetType().ToString() == KIONJHBOLKI)
			{
				return item;
			}
		}
		return null;
	}

	[SpecialName]
	public WarArenaParameters LNDFNBFFIHA()
	{
		return PNEHGOINBBF ?? (PNEHGOINBBF = GetComponent<WarArenaParameters>());
	}

	[SpecialName]
	public bool DANDNHJBJKB()
	{
		return !(FPLIPHCJGFO.INFLHPGMEOB == data.arenaId) || (int)data.lives <= 0 || (int)data.wins >= FPLIPHCJGFO.FCDIFINLKIA || isOpened;
	}

	[SpecialName]
	public int BKCJAGBELOL()
	{
		if (FPLIPHCJGFO.NFOELJINGGN.Count == 0)
		{
			return 0;
		}
		int index = Mathf.Clamp(data.wins, 1, FPLIPHCJGFO.NFOELJINGGN.Count);
		IKPLPPFFDNI.MJPNFAKHHHI mJPNFAKHHHI = FPLIPHCJGFO.NFOELJINGGN[index];
		return mJPNFAKHHHI.HPLPAKOCOHN;
	}

	public void LoadWarArenaConfig(JToken OGNGMBLDAOP)
	{
		FPLIPHCJGFO = new IKPLPPFFDNI(OGNGMBLDAOP);
		string nHFGEMPOHEO = FPLIPHCJGFO.NHFGEMPOHEO;
		NDIJMGCAJAO = DeserializeRules(nHFGEMPOHEO);
		PushNotificationManager.instance.ScheduleLocalWarArenaReminder(FPLIPHCJGFO.JGBFNKBFCKM);
		bool NGPAEAIBFDH = true;
		int phaseStartTime = JHHKFPMOOLH(out NGPAEAIBFDH);
		if (NGPAEAIBFDH)
		{
			PushNotificationManager.instance.ScheduleLocalWarArenaStart(phaseStartTime, NGPAEAIBFDH);
		}
		DFDFGFBBOEJ = false;
		if (MPAMONABMML != null)
		{
			MPAMONABMML();
		}
	}

	public void NHPLOFAPFAN(int EHMEFHBAJIH)
	{
		int num = EHMEFHBAJIH - (int)data.lives;
		data.lives = EHMEFHBAJIH;
		if (AEEJGOBGGCH != null && num != 0)
		{
			AEEJGOBGGCH(num);
		}
	}

	private void IGHDJPBMLFI()
	{
		JOPIPCDHOLF.PNHDGLHLNIE();
	}

	[SpecialName]
	public void GFIOJGODFAK(Action<int> IDEBKDPMPGM)
	{
		Action<int> action = AEEJGOBGGCH;
		Action<int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref AEEJGOBGGCH, (Action<int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void DJBLPIOFALP(Action IDEBKDPMPGM)
	{
		Action action = PDHNCNPNFOD;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PDHNCNPNFOD, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int OOBJACGGFAB()
	{
		return Mathf.Max(0, FPLIPHCJGFO.JGBFNKBFCKM - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
	}

	[SpecialName]
	public void IIFEMPKIGJB(Action<int> IDEBKDPMPGM)
	{
		Action<int> action = AEEJGOBGGCH;
		Action<int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref AEEJGOBGGCH, (Action<int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void COLAJFAHPPO(int EHMEFHBAJIH)
	{
		int num = EHMEFHBAJIH - (int)data.lives;
		data.lives = EHMEFHBAJIH;
		if (AEEJGOBGGCH != null && num != 0)
		{
			AEEJGOBGGCH(num);
		}
	}

	[SpecialName]
	public void NCMIHGCFFOE(Action IDEBKDPMPGM)
	{
		Action action = MNKCLKOGMAC;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MNKCLKOGMAC, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected override void Load(JToken DIGPAIOFOFE)
	{
		base.Load(DIGPAIOFOFE);
		UnityEngine.Debug.LogFormat("dialog shown = {0}, lives = {1}", data.heartDialogShown, data.lives);
		if (isOpened && !data.heartDialogShown && (int)data.lives == 0)
		{
			Singleton<MessageManager>.instance.AddMessage(new NOIBBLPEDAG(instance.FPLIPHCJGFO.INFLHPGMEOB));
		}
	}

	public void ENCLOPBCLJC()
	{
		DFDFGFBBOEJ = false;
	}

	[SpecialName]
	public void PLHGIBJPPBA(Action IDEBKDPMPGM)
	{
		Action action = PDHNCNPNFOD;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PDHNCNPNFOD, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool ALHNCIONIIL()
	{
		return CKHHAAJEBBN.JCOEEPMKODO();
	}

	[SpecialName]
	public bool PBGAHILNNAH()
	{
		if (FPLIPHCJGFO == null)
		{
			return false;
		}
		int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		bool flag = FPLIPHCJGFO != null && data != null && FPLIPHCJGFO.JGBFNKBFCKM <= num && !BALABLIGAHK();
		bool kAFGNKHAMEL = KAFGNKHAMEL;
		KAFGNKHAMEL = flag;
		if (!kAFGNKHAMEL && flag)
		{
			BFIJLJFOFCK();
		}
		return flag;
	}

	public void TryGetNewArena()
	{
		if (Singleton<BeanstalkServerManager>.instance.shouldGetMessages && isExpired && !DFDFGFBBOEJ)
		{
			IGHDJPBMLFI();
			DFDFGFBBOEJ = true;
			if (PDHNCNPNFOD != null)
			{
				PDHNCNPNFOD();
			}
		}
	}

	public bool SetupRules()
	{
		Singleton<GameController>.instance.MBPKLMKBJAB.ResetRules();
		bool flag = true;
		foreach (WarArenaRule item in NDIJMGCAJAO)
		{
			bool flag2 = item.EKMMLNKADIL();
			UnityEngine.Debug.Log($"Mode with name {item.GetType()} met criteria {flag2} ");
			flag = flag && flag2;
		}
		return flag;
	}

	[SpecialName]
	public int ECNDFNDMBOD()
	{
		return Mathf.Max(0, FPLIPHCJGFO.NGPMJNJPNMB - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
	}

	public void LEGGHEEMAHI()
	{
		if (Singleton<BeanstalkServerManager>.instance.shouldGetMessages && NHLEKBIHDAL() && !DFDFGFBBOEJ)
		{
			KLACIDPAOPN();
			DFDFGFBBOEJ = true;
			if (PDHNCNPNFOD != null)
			{
				PDHNCNPNFOD();
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
		PNEHGOINBBF = GetComponent<WarArenaParameters>();
	}

	private int CCKHKHCPPBH(out bool NGPAEAIBFDH)
	{
		NGPAEAIBFDH = false;
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int jGBFNKBFCKM = FPLIPHCJGFO.JGBFNKBFCKM;
		int nGPMJNJPNMB = FPLIPHCJGFO.NGPMJNJPNMB;
		if (nGPMJNJPNMB < currentTimestamp)
		{
			return jGBFNKBFCKM;
		}
		if (jGBFNKBFCKM < currentTimestamp)
		{
			IKPLPPFFDNI.CIFMKGIKJFM cIFMKGIKJFM = FPLIPHCJGFO.HMINOMDIBAF;
			NGPAEAIBFDH = cIFMKGIKJFM == null;
			return (!NGPAEAIBFDH) ? cIFMKGIKJFM.LIPNMFAJADC() : jGBFNKBFCKM;
		}
		return jGBFNKBFCKM;
	}

	public void ApplyRules()
	{
		if (!Singleton<GameController>.instance.isWarArena)
		{
			return;
		}
		foreach (WarArenaRule item in NDIJMGCAJAO)
		{
			item.GJFHGPMMDEM();
		}
	}

	[SpecialName]
	public int BOFGAAEBONJ()
	{
		return FPLIPHCJGFO.AKMMBOOKOIA();
	}

	[SpecialName]
	public void OAGHFKOABFI(Action IDEBKDPMPGM)
	{
		Action action = MNKCLKOGMAC;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MNKCLKOGMAC, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void MNIDMKCEHGK()
	{
		BJHPKLAEFCI = null;
	}

	[SpecialName]
	public int FOCACINHHLD()
	{
		return Mathf.Max(0, FPLIPHCJGFO.JGBFNKBFCKM - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
	}
}
