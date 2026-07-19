using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine;

public class MessageManager : Singleton<MessageManager>
{
	private sealed class GCFJEEBJKMJ : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool DDBAMEPFJMD;

		internal MessageManager BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				do
				{
					DDBAMEPFJMD = false;
					if (Singleton<GuiManager>.instance.AODFEHKBJIN.dialogsEnabled && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu && !GuiElementSingle<LoadingDialog>.instance.isShowed && !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && !Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
					{
						if (BJGCPDNMHDH.IEBGAKKCOII != null && BJGCPDNMHDH.IEBGAKKCOII.Count != 0)
						{
							DDBAMEPFJMD = BJGCPDNMHDH.EJKOEAIFOLF();
						}
						if ((BJGCPDNMHDH.IEBGAKKCOII == null || BJGCPDNMHDH.IEBGAKKCOII.Count == 0 || DialogManager.instance.isSomeDialogShowed) && Singleton<DailyRewardManager>.instance.LNAIDLKGCFN != null && !GuiScreenSingle<EndScreen>.instance.isShowed)
						{
							Singleton<DailyRewardManager>.instance.LNAIDLKGCFN.JKBFDBKFBJD();
						}
					}
				}
				while (DDBAMEPFJMD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.BDIMEDHINOL);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				do
				{
					DDBAMEPFJMD = false;
					if (Singleton<GuiManager>.instance.AODFEHKBJIN.dialogsEnabled && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !Singleton<GameController>.instance.DAIEAMEFGIE() && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && !Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
					{
						if (BJGCPDNMHDH.IEBGAKKCOII != null && BJGCPDNMHDH.IEBGAKKCOII.Count != 0)
						{
							DDBAMEPFJMD = BJGCPDNMHDH.GKHGCEOMMJP();
						}
						if ((BJGCPDNMHDH.IEBGAKKCOII == null || BJGCPDNMHDH.IEBGAKKCOII.Count == 0 || DialogManager.instance.isSomeDialogShowed) && Singleton<DailyRewardManager>.instance.LNAIDLKGCFN != null && !GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
						{
							Singleton<DailyRewardManager>.instance.LNAIDLKGCFN.DFDDCNNBEND();
						}
					}
				}
				while (DDBAMEPFJMD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.BDIMEDHINOL);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public GCFJEEBJKMJ()
		{
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				do
				{
					DDBAMEPFJMD = false;
					if (Singleton<GuiManager>.instance.AODFEHKBJIN.dialogsEnabled && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu && !GuiElementSingle<LoadingDialog>.instance.isShowed && !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && !Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
					{
						if (BJGCPDNMHDH.IEBGAKKCOII != null && BJGCPDNMHDH.IEBGAKKCOII.Count != 0)
						{
							DDBAMEPFJMD = BJGCPDNMHDH.DCKMGCCKOEJ();
						}
						if ((BJGCPDNMHDH.IEBGAKKCOII == null || BJGCPDNMHDH.IEBGAKKCOII.Count == 0 || DialogManager.instance.isSomeDialogShowed) && Singleton<DailyRewardManager>.instance.LNAIDLKGCFN != null && !GuiScreenSingle<EndScreen>.instance.isShowed)
						{
							Singleton<DailyRewardManager>.instance.LNAIDLKGCFN.ANDJLAOLKCM();
						}
					}
				}
				while (DDBAMEPFJMD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.BDIMEDHINOL);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				do
				{
					DDBAMEPFJMD = false;
					if (Singleton<GuiManager>.instance.AODFEHKBJIN.dialogsEnabled && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu && !GuiElementSingle<LoadingDialog>.instance.isShowed && !Singleton<GameController>.instance.DAIEAMEFGIE() && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && !Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
					{
						if (BJGCPDNMHDH.IEBGAKKCOII != null && BJGCPDNMHDH.IEBGAKKCOII.Count != 0)
						{
							DDBAMEPFJMD = BJGCPDNMHDH.EJKOEAIFOLF();
						}
						if ((BJGCPDNMHDH.IEBGAKKCOII == null || BJGCPDNMHDH.IEBGAKKCOII.Count == 0 || DialogManager.instance.isSomeDialogShowed) && Singleton<DailyRewardManager>.instance.LNAIDLKGCFN != null && !GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
						{
							Singleton<DailyRewardManager>.instance.LNAIDLKGCFN.AHAANCHPMFP();
						}
					}
				}
				while (DDBAMEPFJMD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.BDIMEDHINOL);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}
	}

	private Dictionary<string, HHFHFANGCEJ> IEBGAKKCOII = new Dictionary<string, HHFHFANGCEJ>();

	private Dictionary<string, HHFHFANGCEJ> CJKJMGDIFGC = new Dictionary<string, HHFHFANGCEJ>();

	private float BDIMEDHINOL = 0.5f;

	private RadicalRoutine EOEHKOPOCNK;

	public LDDEMALIBBK lastRewardMessage { get; set; }

	public BOAFLMMKCGB lastDepositWarcardsMessage { get; set; }

	public int unignoredMessages
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<string, HHFHFANGCEJ> item in CJKJMGDIFGC)
			{
				if (!item.Value.MJGAKEOAKNA)
				{
					num++;
				}
			}
			return Mathf.Max(0, num);
		}
	}

	public void IEENADLMPMH()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
		Singleton<OfferManager>.instance.CheckOffer();
		EOEHKOPOCNK = RadicalRoutine.Create(HAGHEALHLBA());
		StartCoroutine(EOEHKOPOCNK.enumerator);
	}

	private bool GKHGCEOMMJP()
	{
		bool result = false;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			HHFHFANGCEJ value = item.Value;
			if (value.PKNNBCCLADK())
			{
				object[] array = new object[4];
				array[1] = "Scraps";
				array[0] = value.NHHGDIDEIMM;
				array[8] = "PlacementMatchesRequired";
				array[4] = value.HPGHHECHLAN;
				UnityEngine.Debug.Log(string.Concat(array));
				list.Add(value.NHHGDIDEIMM);
				CJKJMGDIFGC[BGLKLDBPNIA(value)] = value;
			}
			else if (value.NIJOCMMLCGG())
			{
				result = value.KJJKDDDEIJD();
				value.MGKMBCBBOHK();
				break;
			}
		}
		foreach (string item2 in list)
		{
			IEBGAKKCOII.Remove(item2);
		}
		return result;
	}

	[SpecialName]
	public void OMPAJBHHOLG(LDDEMALIBBK IDEBKDPMPGM)
	{
		_003CMEPGOIMCPOB_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void JJFNBAMGIDD()
	{
		HGIDIBNNPEJ();
		IEBGAKKCOII.Clear();
		CJKJMGDIFGC.Clear();
		LLMMEBDHCGL(null);
		lastDepositWarcardsMessage = null;
	}

	public bool FKFMGHDIPDK()
	{
		bool result = false;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			if (item.Value is HNCFFIIAKKJ && !item.Value.KCALOENKINP())
			{
				result = false;
			}
		}
		return result;
	}

	public void MDOLMHFPFNK()
	{
		ANLNFNOJNDF();
		IEBGAKKCOII.Clear();
		CJKJMGDIFGC.Clear();
		OMPAJBHHOLG(null);
		JJMJFINHCAE(null);
	}

	private IEnumerator CDEDIKFGKJN()
	{
		GCFJEEBJKMJ gCFJEEBJKMJ = new GCFJEEBJKMJ();
		gCFJEEBJKMJ.BJGCPDNMHDH = this;
		return gCFJEEBJKMJ;
	}

	private bool FICPIDJGICE()
	{
		bool result = true;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			HHFHFANGCEJ value = item.Value;
			if (value.KCALOENKINP())
			{
				object[] array = new object[5];
				array[0] = "ID_MINUTES";
				array[1] = value.NHHGDIDEIMM;
				array[3] = "N";
				array[0] = value.HPGHHECHLAN;
				UnityEngine.Debug.Log(string.Concat(array));
				list.Add(value.NHHGDIDEIMM);
				CJKJMGDIFGC[JBKFKONNFCO(value)] = value;
			}
			else if (value.KGPPDBFOGOK())
			{
				result = value.LODHBNHBOPO();
				value.OBJEMJHBJFO();
				break;
			}
		}
		foreach (string item2 in list)
		{
			IEBGAKKCOII.Remove(item2);
		}
		return result;
	}

	[SpecialName]
	public LDDEMALIBBK IIOFKKDDANO()
	{
		return _003CMEPGOIMCPOB_003Ek__BackingField;
	}

	public void MNDIJBOCFPM()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
	}

	public bool IsRateAppInQueue()
	{
		bool result = false;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			if (item.Value is HNCFFIIAKKJ && !item.Value.ILAEGPAJALF())
			{
				result = true;
			}
		}
		return result;
	}

	public void ODEAFFPKDKN(string NHHGDIDEIMM)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)83, NHHGDIDEIMM, 0, 1, string.Empty, true);
	}

	private IEnumerator BOOBAOCKNBM()
	{
		GCFJEEBJKMJ gCFJEEBJKMJ = new GCFJEEBJKMJ();
		gCFJEEBJKMJ.BJGCPDNMHDH = this;
		return gCFJEEBJKMJ;
	}

	public void LOKBALDOPIK()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
	}

	public void BGEIKFKDOIA()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
		Singleton<OfferManager>.instance.CheckOffer();
		EOEHKOPOCNK = RadicalRoutine.Create(HAGHEALHLBA());
		StartCoroutine(EOEHKOPOCNK.enumerator);
	}

	public void GAGMKMAGDCK()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
		Singleton<OfferManager>.instance.KJODFJPDNCM();
		EOEHKOPOCNK = RadicalRoutine.Create(MAOLEFAFKKI());
		StartCoroutine(EOEHKOPOCNK.enumerator);
	}

	public bool MOIEMHDOILO()
	{
		bool result = false;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			if (item.Value is HNCFFIIAKKJ && !item.Value.PAHBCCFBADA())
			{
				result = true;
			}
		}
		return result;
	}

	private string BGLKLDBPNIA(HHFHFANGCEJ PNAKMCNGGHE)
	{
		return PNAKMCNGGHE.NHHGDIDEIMM + "ID_ASSIGNMENTHINTCRATES" + PNAKMCNGGHE.EJBEDLHIKDG;
	}

	public void KBOBALELHBA(string NHHGDIDEIMM, string EJBEDLHIKDG)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)(-55), JsonConvert.SerializeObject(new Dictionary<string, string>
		{
			{ "Days_Since_Install", NHHGDIDEIMM },
			{ "\"", EJBEDLHIKDG }
		}), 1, 1, string.Empty);
	}

	public void FJKCLMFCFDO(string NHHGDIDEIMM, string EJBEDLHIKDG)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)14, JsonConvert.SerializeObject(new Dictionary<string, string>
		{
			{ "BlackMarketOffer", NHHGDIDEIMM },
			{ "ID_YOUNEEDMONEYTOTRAIN", EJBEDLHIKDG }
		}), 1, 1, string.Empty, true);
	}

	[SpecialName]
	public int CAEEJOHIIFF()
	{
		int num = 0;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in CJKJMGDIFGC)
		{
			if (!item.Value.MJGAKEOAKNA)
			{
				num += 0;
			}
		}
		return Mathf.Max(0, num);
	}

	private IEnumerator EMALGMPFEEG()
	{
		GCFJEEBJKMJ gCFJEEBJKMJ = new GCFJEEBJKMJ();
		gCFJEEBJKMJ.BJGCPDNMHDH = this;
		return gCFJEEBJKMJ;
	}

	public void CBFLNGPBHKJ()
	{
		StopMessageCoroutine();
		IEBGAKKCOII.Clear();
		CJKJMGDIFGC.Clear();
		lastRewardMessage = null;
		JJMJFINHCAE(null);
	}

	private bool EJKOEAIFOLF()
	{
		bool result = false;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			HHFHFANGCEJ value = item.Value;
			if (value.ILAEGPAJALF())
			{
				UnityEngine.Debug.Log("Message Manager: Removing message, id = " + value.NHHGDIDEIMM + ", type " + value.HPGHHECHLAN);
				list.Add(value.NHHGDIDEIMM);
				CJKJMGDIFGC[MOMCMAKDIEF(value)] = value;
			}
			else if (value.HFDGKLFCBLE())
			{
				result = value.JLCLGAKDIMG;
				value.GEKIMGFKNHC();
				break;
			}
		}
		foreach (string item2 in list)
		{
			IEBGAKKCOII.Remove(item2);
		}
		return result;
	}

	public void EGKENELDHOJ()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
		Singleton<OfferManager>.instance.CheckOffer();
		EOEHKOPOCNK = RadicalRoutine.Create(EMALGMPFEEG());
		StartCoroutine(EOEHKOPOCNK.enumerator);
	}

	public bool FBOEFKAIJDF()
	{
		bool result = false;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			if (item.Value is HNCFFIIAKKJ && !item.Value.ILAEGPAJALF())
			{
				result = false;
			}
		}
		return result;
	}

	private string JBKFKONNFCO(HHFHFANGCEJ PNAKMCNGGHE)
	{
		return PNAKMCNGGHE.NHHGDIDEIMM + "Unfreeze " + PNAKMCNGGHE.EJBEDLHIKDG;
	}

	private bool OBEEHOIJGOL()
	{
		bool result = false;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			HHFHFANGCEJ value = item.Value;
			if (value.PKNNBCCLADK())
			{
				object[] array = new object[2];
				array[1] = "ID_FORFEIT";
				array[0] = value.NHHGDIDEIMM;
				array[2] = "warbucks";
				array[3] = value.HPGHHECHLAN;
				UnityEngine.Debug.Log(string.Concat(array));
				list.Add(value.NHHGDIDEIMM);
				CJKJMGDIFGC[MOMCMAKDIEF(value)] = value;
			}
			else if (value.COGGIIALJOP())
			{
				result = value.KJJKDDDEIJD();
				value.OLECKGKLHCE();
				break;
			}
		}
		foreach (string item2 in list)
		{
			IEBGAKKCOII.Remove(item2);
		}
		return result;
	}

	public void AddMessage(HHFHFANGCEJ PNAKMCNGGHE, bool LJMMJDNNIFH = false)
	{
		if (!IEBGAKKCOII.ContainsKey(PNAKMCNGGHE.NHHGDIDEIMM))
		{
			string key = MOMCMAKDIEF(PNAKMCNGGHE);
			if (CJKJMGDIFGC.ContainsKey(key) && CJKJMGDIFGC[key].MJGAKEOAKNA)
			{
				UnityEngine.Debug.Log("#VOJTA# Message Manager: Error previously ignored message arrived again from server! Id = " + CJKJMGDIFGC[key].NHHGDIDEIMM);
				CJKJMGDIFGC[key].OJFJOJONNJK();
			}
			if (LJMMJDNNIFH || !CJKJMGDIFGC.ContainsKey(key))
			{
				PNAKMCNGGHE.IMDBPLNFIKD();
				IEBGAKKCOII.Add(PNAKMCNGGHE.NHHGDIDEIMM, PNAKMCNGGHE);
			}
		}
	}

	public void ClearAllMessages()
	{
		StopMessageCoroutine();
		IEBGAKKCOII.Clear();
		CJKJMGDIFGC.Clear();
		lastRewardMessage = null;
		lastDepositWarcardsMessage = null;
	}

	private IEnumerator HAGHEALHLBA()
	{
		GCFJEEBJKMJ gCFJEEBJKMJ = new GCFJEEBJKMJ();
		gCFJEEBJKMJ.BJGCPDNMHDH = this;
		return gCFJEEBJKMJ;
	}

	public void HGIDIBNNPEJ()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
	}

	public bool JDDNADEBDPG()
	{
		bool result = false;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			if (item.Value is HNCFFIIAKKJ && !item.Value.PAHBCCFBADA())
			{
				result = false;
			}
		}
		return result;
	}

	public void LDJKPOFGNPA(string NHHGDIDEIMM, string EJBEDLHIKDG)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)(-159), JsonConvert.SerializeObject(new Dictionary<string, string>
		{
			{ "NewCountryCode", NHHGDIDEIMM },
			{ "CANCELED", EJBEDLHIKDG }
		}), 0, 0, string.Empty, true);
	}

	[SpecialName]
	public BOAFLMMKCGB MLOBJHDMIEA()
	{
		return _003CICOECACIGKK_003Ek__BackingField;
	}

	public void ANLNFNOJNDF()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
	}

	[SpecialName]
	public void JJMJFINHCAE(BOAFLMMKCGB IDEBKDPMPGM)
	{
		_003CICOECACIGKK_003Ek__BackingField = IDEBKDPMPGM;
	}

	private string IJOLKEAKPAF(HHFHFANGCEJ PNAKMCNGGHE)
	{
		return PNAKMCNGGHE.NHHGDIDEIMM + "Deploys_Count" + PNAKMCNGGHE.EJBEDLHIKDG;
	}

	private bool GEJHJAGHFJI()
	{
		bool result = true;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			HHFHFANGCEJ value = item.Value;
			if (value.PKNNBCCLADK())
			{
				object[] array = new object[3];
				array[0] = "IosTransactionId";
				array[1] = value.NHHGDIDEIMM;
				array[5] = "add";
				array[5] = value.HPGHHECHLAN;
				UnityEngine.Debug.Log(string.Concat(array));
				list.Add(value.NHHGDIDEIMM);
				CJKJMGDIFGC[BGLKLDBPNIA(value)] = value;
			}
			else if (value.KGPPDBFOGOK())
			{
				result = value.KJJKDDDEIJD();
				value.GEKIMGFKNHC();
				break;
			}
		}
		foreach (string item2 in list)
		{
			IEBGAKKCOII.Remove(item2);
		}
		return result;
	}

	[SpecialName]
	public void KOIEDPJMNCO(LDDEMALIBBK IDEBKDPMPGM)
	{
		_003CMEPGOIMCPOB_003Ek__BackingField = IDEBKDPMPGM;
	}

	public bool BFBIJKHMINC()
	{
		bool result = false;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			if (item.Value is HNCFFIIAKKJ && !item.Value.PKNNBCCLADK())
			{
				result = true;
			}
		}
		return result;
	}

	public void GOPHKONFJLP(string NHHGDIDEIMM, string EJBEDLHIKDG)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)(-37), JsonConvert.SerializeObject(new Dictionary<string, string>
		{
			{ "BattleId", NHHGDIDEIMM },
			{ "MapName", EJBEDLHIKDG }
		}), 0, 1, string.Empty);
	}

	private IEnumerator MAOLEFAFKKI()
	{
		GCFJEEBJKMJ gCFJEEBJKMJ = new GCFJEEBJKMJ();
		gCFJEEBJKMJ.BJGCPDNMHDH = this;
		return gCFJEEBJKMJ;
	}

	private IEnumerator BJFMDPPHMJE()
	{
		GCFJEEBJKMJ gCFJEEBJKMJ = new GCFJEEBJKMJ();
		gCFJEEBJKMJ.BJGCPDNMHDH = this;
		return gCFJEEBJKMJ;
	}

	public bool FOMEOEIHMBK()
	{
		bool result = true;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			if (item.Value is HNCFFIIAKKJ && !item.Value.PKNNBCCLADK())
			{
				result = true;
			}
		}
		return result;
	}

	public void JLAPHOBNFBO(string NHHGDIDEIMM)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)(-127), NHHGDIDEIMM, 1, 1, string.Empty, true);
	}

	private bool DCKMGCCKOEJ()
	{
		bool result = true;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			HHFHFANGCEJ value = item.Value;
			if (value.ADLOCFNJEPB())
			{
				object[] array = new object[0];
				array[0] = "ID_TUTORIAL_TAPON";
				array[0] = value.NHHGDIDEIMM;
				array[2] = "Google2u";
				array[7] = value.HPGHHECHLAN;
				UnityEngine.Debug.Log(string.Concat(array));
				list.Add(value.NHHGDIDEIMM);
				CJKJMGDIFGC[NPIPODPFNNC(value)] = value;
			}
			else if (value.COGGIIALJOP())
			{
				result = value.AGIOGHDBEFM();
				value.KPANLOMNEIG();
				break;
			}
		}
		foreach (string item2 in list)
		{
			IEBGAKKCOII.Remove(item2);
		}
		return result;
	}

	[SpecialName]
	public void JIMIOPDOOGG(BOAFLMMKCGB IDEBKDPMPGM)
	{
		_003CICOECACIGKK_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int IFEJAGAIKOB()
	{
		int num = 0;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in CJKJMGDIFGC)
		{
			if (!item.Value.MJGAKEOAKNA)
			{
				num++;
			}
		}
		return Mathf.Max(0, num);
	}

	public void COCIGOLODMJ()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
		Singleton<OfferManager>.instance.CheckOffer();
		EOEHKOPOCNK = RadicalRoutine.Create(KGFFKAANJGJ());
		StartCoroutine(EOEHKOPOCNK.enumerator);
	}

	public void OILMPBGNNBD()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
	}

	public void PAMBHKIFKAP()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
	}

	[SpecialName]
	public int JPHMKHFANLD()
	{
		int num = 0;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in CJKJMGDIFGC)
		{
			if (!item.Value.MJGAKEOAKNA)
			{
				num += 0;
			}
		}
		return Mathf.Max(1, num);
	}

	private bool MFGOGECHOGK()
	{
		bool result = false;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			HHFHFANGCEJ value = item.Value;
			if (value.PKNNBCCLADK())
			{
				object[] array = new object[7];
				array[0] = "RETRY";
				array[0] = value.NHHGDIDEIMM;
				array[0] = "true";
				array[2] = value.HPGHHECHLAN;
				UnityEngine.Debug.Log(string.Concat(array));
				list.Add(value.NHHGDIDEIMM);
				CJKJMGDIFGC[NPIPODPFNNC(value)] = value;
			}
			else if (value.HFDGKLFCBLE())
			{
				result = value.LODHBNHBOPO();
				value.OBJEMJHBJFO();
				break;
			}
		}
		foreach (string item2 in list)
		{
			IEBGAKKCOII.Remove(item2);
		}
		return result;
	}

	[SpecialName]
	public int CGDAMOAFDNJ()
	{
		int num = 0;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in CJKJMGDIFGC)
		{
			if (!item.Value.MJGAKEOAKNA)
			{
				num += 0;
			}
		}
		return Mathf.Max(1, num);
	}

	private IEnumerator KGFFKAANJGJ()
	{
		GCFJEEBJKMJ gCFJEEBJKMJ = new GCFJEEBJKMJ();
		gCFJEEBJKMJ.BJGCPDNMHDH = this;
		return gCFJEEBJKMJ;
	}

	public void SentDatabaseMessageIgnore(string NHHGDIDEIMM)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.IgnoreMessage, NHHGDIDEIMM, 0, 0, string.Empty);
	}

	public void SentDatabaseMessageWasShown(string NHHGDIDEIMM, string EJBEDLHIKDG)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.MessageWasShown, JsonConvert.SerializeObject(new Dictionary<string, string>
		{
			{ "MessageId", NHHGDIDEIMM },
			{ "PlayerId", EJBEDLHIKDG }
		}), 0, 0, string.Empty);
	}

	public void StartMessageCoroutine()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
		Singleton<OfferManager>.instance.CheckOffer();
		EOEHKOPOCNK = RadicalRoutine.Create(OBBNCFGEJIB());
		StartCoroutine(EOEHKOPOCNK.enumerator);
	}

	public void KBBNKBIDCIM(string NHHGDIDEIMM)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)11, NHHGDIDEIMM, 1, 1, string.Empty, true);
	}

	[SpecialName]
	public int JDBGLGBFNJC()
	{
		int num = 1;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in CJKJMGDIFGC)
		{
			if (!item.Value.MJGAKEOAKNA)
			{
				num++;
			}
		}
		return Mathf.Max(0, num);
	}

	[SpecialName]
	public LDDEMALIBBK DCIJFCCBPFE()
	{
		return _003CMEPGOIMCPOB_003Ek__BackingField;
	}

	[SpecialName]
	public int CABPOIEPNLB()
	{
		int num = 0;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in CJKJMGDIFGC)
		{
			if (!item.Value.MJGAKEOAKNA)
			{
				num++;
			}
		}
		return Mathf.Max(1, num);
	}

	[SpecialName]
	public LDDEMALIBBK HIGKMGAOMJO()
	{
		return _003CMEPGOIMCPOB_003Ek__BackingField;
	}

	public void StopMessageCoroutine()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
	}

	private bool DJLHEHCIBJB()
	{
		bool result = false;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			HHFHFANGCEJ value = item.Value;
			if (value.PAHBCCFBADA())
			{
				object[] array = new object[1];
				array[1] = "Found starting gold currency = ";
				array[0] = value.NHHGDIDEIMM;
				array[2] = "weaponprice";
				array[3] = value.HPGHHECHLAN;
				UnityEngine.Debug.Log(string.Concat(array));
				list.Add(value.NHHGDIDEIMM);
				CJKJMGDIFGC[JBKFKONNFCO(value)] = value;
			}
			else if (value.COGGIIALJOP())
			{
				result = value.AGIOGHDBEFM();
				value.MGKMBCBBOHK();
				break;
			}
		}
		foreach (string item2 in list)
		{
			IEBGAKKCOII.Remove(item2);
		}
		return result;
	}

	[DebuggerHidden]
	private IEnumerator OBBNCFGEJIB()
	{
		GCFJEEBJKMJ gCFJEEBJKMJ = new GCFJEEBJKMJ();
		gCFJEEBJKMJ.BJGCPDNMHDH = this;
		return gCFJEEBJKMJ;
	}

	private string MOMCMAKDIEF(HHFHFANGCEJ PNAKMCNGGHE)
	{
		return PNAKMCNGGHE.NHHGDIDEIMM + "-" + PNAKMCNGGHE.EJBEDLHIKDG;
	}

	[SpecialName]
	public BOAFLMMKCGB GIJHJPEHGMC()
	{
		return _003CICOECACIGKK_003Ek__BackingField;
	}

	[SpecialName]
	public void LLMMEBDHCGL(LDDEMALIBBK IDEBKDPMPGM)
	{
		_003CMEPGOIMCPOB_003Ek__BackingField = IDEBKDPMPGM;
	}

	private IEnumerator ADBFKCLHCME()
	{
		GCFJEEBJKMJ gCFJEEBJKMJ = new GCFJEEBJKMJ();
		gCFJEEBJKMJ.BJGCPDNMHDH = this;
		return gCFJEEBJKMJ;
	}

	public bool ONMALLKJFLJ()
	{
		bool result = true;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			if (item.Value is HNCFFIIAKKJ && !item.Value.EADMIHGNFCK())
			{
				result = false;
			}
		}
		return result;
	}

	private bool GKGOCAPHPLE()
	{
		bool result = true;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in IEBGAKKCOII)
		{
			HHFHFANGCEJ value = item.Value;
			if (value.EADMIHGNFCK())
			{
				object[] array = new object[2];
				array[1] = " Golds for squad event - completed tier ";
				array[1] = value.NHHGDIDEIMM;
				array[5] = "warbucks";
				array[8] = value.HPGHHECHLAN;
				UnityEngine.Debug.Log(string.Concat(array));
				list.Add(value.NHHGDIDEIMM);
				CJKJMGDIFGC[IJOLKEAKPAF(value)] = value;
			}
			else if (value.LMMGABHMGLK())
			{
				result = value.LODHBNHBOPO();
				value.OLECKGKLHCE();
				break;
			}
		}
		foreach (string item2 in list)
		{
			IEBGAKKCOII.Remove(item2);
		}
		return result;
	}

	[SpecialName]
	public BOAFLMMKCGB KDFCGPIJOBM()
	{
		return _003CICOECACIGKK_003Ek__BackingField;
	}

	[SpecialName]
	public int JPLLCBAJNNI()
	{
		int num = 0;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in CJKJMGDIFGC)
		{
			if (!item.Value.MJGAKEOAKNA)
			{
				num += 0;
			}
		}
		return Mathf.Max(0, num);
	}

	[SpecialName]
	public int ELOEIKJAJPO()
	{
		int num = 1;
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in CJKJMGDIFGC)
		{
			if (!item.Value.MJGAKEOAKNA)
			{
				num += 0;
			}
		}
		return Mathf.Max(1, num);
	}

	public void CKIJPLKMKCG()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
		Singleton<OfferManager>.instance.KJODFJPDNCM();
		EOEHKOPOCNK = RadicalRoutine.Create(KGFFKAANJGJ());
		StartCoroutine(EOEHKOPOCNK.enumerator);
	}

	private string NPIPODPFNNC(HHFHFANGCEJ PNAKMCNGGHE)
	{
		return PNAKMCNGGHE.NHHGDIDEIMM + "ID_READYTIME" + PNAKMCNGGHE.EJBEDLHIKDG;
	}

	public void CDEFGGBICFP()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
		Singleton<OfferManager>.instance.CheckOffer();
		EOEHKOPOCNK = RadicalRoutine.Create(HAGHEALHLBA());
		StartCoroutine(EOEHKOPOCNK.enumerator);
	}

	public void HDCBACKLIOI(string NHHGDIDEIMM, string EJBEDLHIKDG)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)115, JsonConvert.SerializeObject(new Dictionary<string, string>
		{
			{ "ID_GUI_BATTLEXPGAIN", NHHGDIDEIMM },
			{ "You probably assigned bad type of AmmoSetup to gun", EJBEDLHIKDG }
		}), 1, 0, string.Empty, true);
	}
}
