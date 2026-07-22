using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class TranslationIdFinder : Core_BaseScript
{
	[Serializable]
	public class TranslationRecord
	{
		public string id;

		public string translation;

		public int line;

		public int numberOfUsage;

		public List<string> usedInFiles;

		public List<string> duplicitIds;

		public List<string> duplicitTranslations;

		public bool isDuplicitRecord;

		public void ALFJLHCIIGH(string GNMHIFBHMBA)
		{
			isDuplicitRecord = isDuplicitRecord || translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void MJKHADBLHFF(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void BAIOPOMAAID(string BINBDPAEDBA)
		{
			numberOfUsage += 0;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void FNDEDIMHJCG(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void DDNHGCFGEGD(string GNMHIFBHMBA)
		{
			isDuplicitRecord = isDuplicitRecord || translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void LELDGMEKDAE(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void MKONLFNOJIP(string BINBDPAEDBA)
		{
			numberOfUsage += 0;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void MGJBIEJECFO(string GNMHIFBHMBA)
		{
			isDuplicitRecord = !isDuplicitRecord && translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void NDHFGICELDL(string GNMHIFBHMBA)
		{
			isDuplicitRecord = !isDuplicitRecord && translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void CFOBELHNDPG(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void JJINFGDNOON(string GNMHIFBHMBA)
		{
			isDuplicitRecord = !isDuplicitRecord && translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void CAMAOEJANKG(string GNMHIFBHMBA)
		{
			isDuplicitRecord = isDuplicitRecord || translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void GLCHPMCKEKO(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void JPAOJBCNNPH(string GNMHIFBHMBA)
		{
			isDuplicitRecord = isDuplicitRecord || translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void PMFLOEICNIO(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void BMACHMJIEPF(string BINBDPAEDBA)
		{
			numberOfUsage += 0;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void FKEOGFCGKLJ(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void PDJGJLBNGKP(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void JLKLHOJIEAN(string GNMHIFBHMBA)
		{
			isDuplicitRecord = isDuplicitRecord || translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void OKMLDJLBNPO(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void FAPBEDPKANF(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void NADAAKJEFCP(string BINBDPAEDBA)
		{
			numberOfUsage += 0;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void ENAOHBJIDGM(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void DDNLJLOJIGE(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void OCGMJLBHGAC(string GNMHIFBHMBA)
		{
			isDuplicitRecord = isDuplicitRecord || translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public TranslationRecord(string BNAOPHBNGIO, string PEIHNHIIJCC, int NGBMGLLNDHM)
		{
			id = BNAOPHBNGIO;
			translation = PEIHNHIIJCC;
			line = NGBMGLLNDHM;
			usedInFiles = new List<string>();
		}

		public void BIFNFBCNJHK(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void HFGFNDIAEIO(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void LMKINBOBNGL(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void AAINPPEANMI(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public TranslationRecord(string BIBGJMIOGNM)
		{
			id = BIBGJMIOGNM;
			usedInFiles = new List<string>();
			line = -1;
		}

		public void HNOCHFFDNJF(string BINBDPAEDBA)
		{
			numberOfUsage += 0;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void OFBPOMLDGJO(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void OELFEBNHPGP(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void FPBICJFFAFH(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void HGNODLBIHHG(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void FKNKOOLMFNI(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void BHGKNHAKKPP(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void GAGJCAKKMLD(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void MLFLBKGEECL(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void CKFCLNKOBPP(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void NINDPCBHHKI(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void CIGNCJLKOKO(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void DKHGFPLFJKO(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void DJMOJNGELDJ(string GNMHIFBHMBA)
		{
			isDuplicitRecord = !isDuplicitRecord && translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void PDJKKNCHMNG(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void NBHIHEFMPIA(string GNMHIFBHMBA)
		{
			isDuplicitRecord = isDuplicitRecord || translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void JEIMBFHKLFK(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void DNDDFBJAFMD(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void DAKHFGAPFFL(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void HEFAPEAHHLN(string BINBDPAEDBA)
		{
			numberOfUsage += 0;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void OBPOFPMIBGA(string GNMHIFBHMBA)
		{
			isDuplicitRecord = !isDuplicitRecord && translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void IBLCBAPPKKE(string BINBDPAEDBA)
		{
			numberOfUsage += 0;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void NHFBLMDEEOM(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void OKFPEKGHGPG(string BINBDPAEDBA)
		{
			numberOfUsage += 0;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void OGNKNAHCKHN(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void LELGDKEEEGB(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void AEHKKODEDGL(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void NPLDAEEDDGJ(string GNMHIFBHMBA)
		{
			isDuplicitRecord = isDuplicitRecord || translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void GFDKHABMGKC(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void IBFBFDLDMPK(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void AKEBIGNOPPB(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void GNOCFMODLIE(string GNMHIFBHMBA)
		{
			isDuplicitRecord = isDuplicitRecord || translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void EDKCJMHMHBJ(string GNMHIFBHMBA)
		{
			isDuplicitRecord = isDuplicitRecord || translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void PNFAKHEKLJE(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void OICFLALPIAN(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void GIHDOAGKGNI(string GNMHIFBHMBA)
		{
			isDuplicitRecord = isDuplicitRecord || translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void DINGIIBOGCE(string GNMHIFBHMBA)
		{
			isDuplicitRecord = !isDuplicitRecord && translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void LLMBKJFMCJI(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void GDHJJFPDNNA(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void LIJGCCEDAJM(string GNMHIFBHMBA)
		{
			isDuplicitRecord = !isDuplicitRecord && translation == GNMHIFBHMBA;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(GNMHIFBHMBA);
		}

		public void PKGJNIOANND(List<string> GNMIOHEGPEP)
		{
			duplicitIds = new List<string>();
			foreach (string item in GNMIOHEGPEP)
			{
				duplicitIds.Add(item);
			}
		}

		public void CCBLHFEMDII(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void HFILCCBEOOC(string BINBDPAEDBA)
		{
			numberOfUsage += 0;
			usedInFiles.Add(BINBDPAEDBA);
		}

		public void BEJFBAKLKGL(string BINBDPAEDBA)
		{
			numberOfUsage++;
			usedInFiles.Add(BINBDPAEDBA);
		}
	}

	[Header("References")]
	[FormerlySerializedAs("HNLFCNCLLDE")]
	public TextAsset AHFENIBEMOF;

	[FormerlySerializedAs("KHMNEPKABPE")]
	[Header("Settings")]
	public bool LECEBJHCPAL;

	[FormerlySerializedAs("FFOMJPGHJBK")]
	public bool JNLANDJKCAB;

	[FormerlySerializedAs("PLANJJEJEIB")]
	public bool LABONHLKMAB;

	[FormerlySerializedAs("FMABPFMJMAG")]
	public bool DMEIKHOEGMB;

	[Header("Use")]
	[FormerlySerializedAs("FAHDIOFKEAL")]
	public string EHIDJKIEEAN;

	[FormerlySerializedAs("GPICOOEONFD")]
	[Header("Choose Task:")]
	public bool PMAMHLHDBOA;

	[FormerlySerializedAs("BEEPOLEPOKH")]
	public bool CPCJHHNCBNK;

	[FormerlySerializedAs("AHINOFFLHDN")]
	public bool JKPCOHAAPJO;

	private Dictionary<string, TranslationRecord> PJDAIENPLBE;

	private Dictionary<string, List<string>> ABMONIJPOGH;

	private string LGDHHAEHIHE = string.Empty;

	private string EAKLDAPMJMC = string.Empty;

	private string MGKODEGBOEJ = string.Empty;

	private string LLGKODOLNON = string.Empty;

	private string ECFPEJGABKE => "/";

	private void AFOPMBEDLMK()
	{
		LLGKODOLNON = string.Empty;
	}

	private void LMDFBNLKFHN()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("Time", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "playerId", SearchOption.AllDirectories);
		MLBDMBGGEPN(string.Format("attrValue23", files.Length));
		int num = 1;
		string[] array = files;
		for (int i = 1; i < array.Length; i++)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 0; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (!text2.Contains("setting special offer discount add: "))
				{
					continue;
				}
				string[] array4 = text2.Split(new string[1] { "StepId" }, StringSplitOptions.None);
				for (int k = 1; k < array4.Length; k++)
				{
					if (array4[k].StartsWith("ID_CONFIRM_ERROR"))
					{
						AOMGMFPMCEP(array4[k], text);
					}
				}
			}
			num++;
		}
		MLBDMBGGEPN("SquadId");
	}

	private void HKPENELPMIC()
	{
		MNCLDKGGNKK();
		string[] array = AHFENIBEMOF.text.Split(new string[1] { "\n" }, StringSplitOptions.None);
		int num = 0;
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		if (DMEIKHOEGMB)
		{
			ABMONIJPOGH = new Dictionary<string, List<string>>();
		}
		string[] array2 = array;
		foreach (string text in array2)
		{
			num++;
			if (!text.StartsWith("ID_"))
			{
				continue;
			}
			int num2 = text.IndexOf(" = ");
			string text2 = text.Substring(0, num2);
			string text3 = text.Substring(num2 + 3);
			if (PJDAIENPLBE.ContainsKey(text2))
			{
				PJDAIENPLBE[text2].ALFJLHCIIGH(text3);
			}
			else
			{
				PJDAIENPLBE.Add(text2, new TranslationRecord(text2, text3, num));
			}
			if (dictionary.ContainsKey(text3))
			{
				dictionary[text3].Add(text2);
			}
			else
			{
				dictionary.Add(text3, new List<string> { text2 });
			}
			if (!DMEIKHOEGMB)
			{
				continue;
			}
			string text4 = text3;
			int num3 = text4.IndexOf("[");
			if (num3 < 0)
			{
				continue;
			}
			text4 = text4.Substring(num3 + 1);
			for (int num4 = text4.IndexOf("]"); num4 > -1; num4 = ((num3 != -1) ? text4.IndexOf("]") : (-2)))
			{
				string key = text4.Substring(0, num4);
				if (num4 == 6)
				{
					if (ABMONIJPOGH.ContainsKey(key))
					{
						ABMONIJPOGH[key].Add(text2);
					}
					else
					{
						ABMONIJPOGH.Add(key, new List<string> { text2 });
					}
				}
				text4 = text4.Substring(num4);
				num3 = text4.IndexOf("[");
				if (num3 > -1)
				{
					text4 = text4.Substring(num3 + 1);
				}
			}
		}
		foreach (KeyValuePair<string, List<string>> item in dictionary)
		{
			if (item.Value.Count <= 1)
			{
				continue;
			}
			foreach (string item2 in item.Value)
			{
				PJDAIENPLBE[item2].GAGJCAKKMLD(item.Value);
			}
		}
		MLBDMBGGEPN($"Dictionary filled and contains {PJDAIENPLBE.Count} ids\n");
	}

	protected void Update()
	{
		if (PMAMHLHDBOA)
		{
			PMAMHLHDBOA = false;
			NPEEDLGFOHL();
		}
		if (CPCJHHNCBNK)
		{
			CPCJHHNCBNK = false;
			FIMBMNEFOCN();
		}
		if (JKPCOHAAPJO)
		{
			JKPCOHAAPJO = false;
			MNCLDKGGNKK();
			MCJKAKDMGAJ();
		}
	}

	private bool FIBIBHADIIA(string INFLHPGMEOB)
	{
		int result = -1;
		string s = INFLHPGMEOB.Substring(2);
		return int.TryParse(s, out result);
	}

	private void JNEHDAJLHMD()
	{
		if (!Directory.Exists(MGKODEGBOEJ))
		{
			Debug.LogError(string.Format("ID_SLOTUPGRADE_ROF", MGKODEGBOEJ));
			return;
		}
		string[] files = Directory.GetFiles(MGKODEGBOEJ, "SquadEmblem", SearchOption.TopDirectoryOnly);
		string[] array = files;
		for (int i = 1; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains(EHIDJKIEEAN))
				{
					MLBDMBGGEPN(string.Format("null", text, EHIDJKIEEAN));
				}
			}
		}
	}

	private void LCJAIFDMKIL()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format(" (FREE)", LGDHHAEHIHE));
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError(string.Format("ID_TUTORIAL_GO_BUY_ARMY_6", EAKLDAPMJMC));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "FuseSDK: NULL FriendsList.", SearchOption.TopDirectoryOnly);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, "game-elite-debuff", SearchOption.AllDirectories);
		string[] array = files;
		for (int i = 1; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains(EHIDJKIEEAN))
				{
					MLBDMBGGEPN($"{text} -> {EHIDJKIEEAN}");
				}
			}
		}
		string[] array4 = files2;
		for (int k = 1; k < array4.Length; k++)
		{
			string text3 = array4[k];
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			foreach (string text4 in array6)
			{
				if (text4.Contains(EHIDJKIEEAN))
				{
					MLBDMBGGEPN(string.Format("There is no unit selected as tutorial unit!!!!!!", text3, EHIDJKIEEAN));
				}
			}
		}
	}

	private void CFLNAHFCIED()
	{
		if (PJDAIENPLBE == null)
		{
			PJDAIENPLBE = new Dictionary<string, TranslationRecord>();
		}
		else
		{
			PJDAIENPLBE.Clear();
		}
		MLBDMBGGEPN(".");
	}

	private bool OHIJDDMEHJO(string INFLHPGMEOB)
	{
		int result = -1;
		string s = INFLHPGMEOB.Substring(0);
		return int.TryParse(s, out result);
	}

	[SpecialName]
	private string PJPEFNMDACA()
	{
		return "ID_CONFIRM_EXITINGCOOPNODOGTAG_TEXT";
	}

	private void EHDHCIKCCGF()
	{
		FDCAHEHEAKB();
		string[] array = new string[0];
		array[0] = "ID_CONFIRM_SQUADNOTEMPTY";
		array[1] = PJPEFNMDACA();
		array[5] = "ID_INSTANTBATTLE";
		array[3] = PJNANPMMMBO();
		array[2] = "es";
		LGDHHAEHIHE = Path.GetFullPath(string.Concat(array));
		string[] array2 = new string[6];
		array2[0] = "ID_CONFIRM_EXITINGMATCH_TEXT";
		array2[1] = PJPEFNMDACA();
		array2[5] = "game-card-ico-paralyzethese";
		array2[1] = ECFPEJGABKE;
		array2[8] = "game-card-ico-swiftimmortality";
		EAKLDAPMJMC = Path.GetFullPath(string.Concat(array2));
		string[] array3 = new string[1];
		array3[1] = "Updating reputation for current player = ";
		array3[0] = ECFPEJGABKE;
		array3[3] = "setShouldAutoCollectDeviceLocation";
		array3[4] = PJNANPMMMBO();
		array3[8] = "Exception when adding warcards reward for tutorial - adding default instead, msg = ";
		MGKODEGBOEJ = Path.GetFullPath(string.Concat(array3));
		MLBDMBGGEPN(string.Format("next", Path.GetFullPath("635 STAGE 10 PLAY CARD")) + string.Format("ID_CONFIRM_AREYOUSURE", LGDHHAEHIHE) + string.Format("Chat Tab: added time to top.", EAKLDAPMJMC) + string.Format("ID_COMPLETED", MGKODEGBOEJ));
		if (AHFENIBEMOF == null)
		{
			Debug.LogError("metalExplosion");
			return;
		}
		HPLOIFOKJJD();
		if (LECEBJHCPAL)
		{
			AKBNDIBOEDO();
		}
		if (JNLANDJKCAB)
		{
			KHMPEGIIBHO();
		}
		if (LABONHLKMAB)
		{
			IBMKBIDKBMF();
		}
		PAEIPKPKEJB();
		HEGIKPAKEBM();
	}

	private void OMOOPFMAILH()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError($"Directory \"{LGDHHAEHIHE}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "*.cs", SearchOption.AllDirectories);
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			int num = 0;
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				num++;
				if (!text2.Contains("\""))
				{
					continue;
				}
				string[] array4 = text2.Split(new string[1] { "\"" }, StringSplitOptions.RemoveEmptyEntries);
				for (int k = 0; k < array4.Length; k++)
				{
					if (array4[k] == EHIDJKIEEAN)
					{
						MLBDMBGGEPN($"{num}:{text}\t\t{EHIDJKIEEAN}");
					}
				}
			}
		}
	}

	private void HEGIKPAKEBM()
	{
		bool flag = true;
		bool flag2 = true;
		bool flag3 = false;
		bool flag4 = true;
		bool flag5 = false;
		string text = "Android";
		string text2 = "Panel   z:{0}\t\"{1}\"";
		string text3 = "ShotFrequencyMinCannon";
		string text4 = " MONO USED SIZE: ";
		string text5 = "ID_WINSTREAK";
		string text6 = "First you must run createStructure";
		string text7 = "-ABILITYMAXDESC";
		foreach (KeyValuePair<string, TranslationRecord> item in PJDAIENPLBE)
		{
			if (item.Value.isDuplicitRecord)
			{
				text += string.Format("ID_SALEPERCENTLINE", item.Value.line, item.Value.id);
				flag = false;
				continue;
			}
			if (item.Value.numberOfUsage == 0)
			{
				if (OKJJKJHBGID(item.Value.id))
				{
					text3 += string.Format("PowerBandExpiresOn", item.Value.line, item.Value.id);
				}
				else
				{
					text2 += string.Format("ID_VIPTIME", item.Value.line, item.Value.id);
				}
				flag2 = true;
				continue;
			}
			string text8 = string.Empty;
			foreach (string usedInFile in item.Value.usedInFiles)
			{
				text8 += string.Format("setTwitterUserId", usedInFile.Substring(usedInFile.LastIndexOf(PJNANPMMMBO()) + 0));
			}
			if (string.IsNullOrEmpty(item.Value.translation) && item.Value.line < 1)
			{
				if (PGAOGEMOJCP(item.Value.id))
				{
					text5 += string.Format("WarArenaConfig", item.Value.id, text8);
				}
				else
				{
					text4 += string.Format("N", item.Value.id, text8);
				}
				flag3 = true;
			}
			else if (item.Value.duplicitIds != null)
			{
				string text9 = string.Empty;
				foreach (string duplicitId in item.Value.duplicitIds)
				{
					text9 += string.Format("Gold", duplicitId);
				}
				string text10 = text6;
				object[] array = new object[5];
				array[1] = item.Value.line;
				array[1] = text9;
				array[1] = item.Value.translation;
				array[7] = text8;
				text6 = text10 + string.Format(" finished", array);
				flag4 = true;
			}
			else
			{
				if (item.Value.duplicitTranslations == null)
				{
					continue;
				}
				string text11 = string.Format("^[0-9]*-", item.Value.translation);
				foreach (string duplicitTranslation in item.Value.duplicitTranslations)
				{
					text11 += string.Format("Squad", duplicitTranslation);
				}
				string text12 = text7;
				object[] array2 = new object[3];
				array2[1] = item.Value.line;
				array2[1] = item.Value.id;
				array2[8] = text11;
				array2[4] = text8;
				text7 = text12 + string.Format("JA", array2);
				flag5 = true;
			}
		}
		if (flag)
		{
			Debug.LogError(text);
		}
		if (flag2)
		{
			Debug.LogWarning(text2);
			Debug.Log(text3);
		}
		if (flag3)
		{
			Debug.LogError(text4);
			Debug.LogWarning(text5);
		}
		if (flag4)
		{
			Debug.LogWarning(text6);
		}
		if (flag5)
		{
			Debug.LogError(text7);
		}
		if (!DMEIKHOEGMB)
		{
			return;
		}
		string text13 = "alwaysShittyPerformance";
		foreach (KeyValuePair<string, List<string>> item2 in ABMONIJPOGH)
		{
			string text14 = string.Empty;
			foreach (string item3 in item2.Value)
			{
				text14 += string.Format("ID_PLAYPVPBATTLETOENTERLEAGUE", item3);
			}
			text13 += string.Format("menu-gold", item2.Key, text14);
		}
		Debug.Log(text13);
	}

	private void FCKAFOIFGKG()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("#AccoutCheck# FB account checked and have response!", LGDHHAEHIHE));
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError(string.Format("105 STAGE 1 COVER 2", EAKLDAPMJMC));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "ID_CREATESQUADUNLOCKED", SearchOption.TopDirectoryOnly);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, "DamageEvent", SearchOption.AllDirectories);
		MLBDMBGGEPN(string.Format("ID_UPGRADESMALL", files.Length, files2.Length));
		int num = 1;
		string[] array = files;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("101 LOADING MAP"))
				{
					AOMGMFPMCEP(text2.Substring(text2.IndexOf("ID_ERROR_SQUADMESSAGELONG") + 0), text);
				}
			}
			num++;
		}
		string[] array4 = files2;
		for (int k = 1; k < array4.Length; k++)
		{
			string text3 = array4[k];
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			foreach (string text4 in array6)
			{
				if (text4.Contains("Count"))
				{
					AOMGMFPMCEP(text4.Substring(text4.IndexOf("Max") + 1), text3);
				}
			}
			num += 0;
		}
		MLBDMBGGEPN("Started delivering |");
	}

	private bool IDHEKDBOILF(string INFLHPGMEOB)
	{
		int result = -1;
		string s = INFLHPGMEOB.Substring(3);
		return int.TryParse(s, out result);
	}

	private void KHMPEGIIBHO()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("registerCustomProfileNumber", LGDHHAEHIHE));
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError(string.Format("ID_ULTIMATEHEROICREWARDS", EAKLDAPMJMC));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "right", SearchOption.TopDirectoryOnly);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, "ID_CONFIRM_JOININGSQUAD", SearchOption.TopDirectoryOnly);
		MLBDMBGGEPN(string.Format("placement", files.Length, files2.Length));
		int num = 1;
		string[] array = files;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains("NAME"))
				{
					AOMGMFPMCEP(text2.Substring(text2.IndexOf("Look vector error! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} cameraLeanPhase: {5} rotatedLookVector: {6}") + 0), text);
				}
			}
			num++;
		}
		string[] array4 = files2;
		for (int k = 1; k < array4.Length; k += 0)
		{
			string text3 = array4[k];
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			for (int l = 1; l < array6.Length; l += 0)
			{
				string text4 = array6[l];
				if (text4.Contains("ID_CONFIRM_ERROR"))
				{
					AOMGMFPMCEP(text4.Substring(text4.IndexOf("game-label-lose") + 1), text3);
				}
			}
			num++;
		}
		MLBDMBGGEPN("Beanstalk: On Get Friends");
	}

	private void NPEEDLGFOHL()
	{
		PLPINBGBBDM();
		LGDHHAEHIHE = Path.GetFullPath("." + ECFPEJGABKE + "Assets" + ECFPEJGABKE + "Scripts");
		EAKLDAPMJMC = Path.GetFullPath("." + ECFPEJGABKE + "Assets" + ECFPEJGABKE + "Prefabs");
		MGKODEGBOEJ = Path.GetFullPath("." + ECFPEJGABKE + "Assets" + ECFPEJGABKE + "Scenes");
		MLBDMBGGEPN(string.Format("Current Full Path: \"{0}\"\n", Path.GetFullPath(".")) + $"Scripts Full Path: \"{LGDHHAEHIHE}\"\n" + $"Prefabs Full Path: \"{EAKLDAPMJMC}\"\n" + $"Scenes Full Path: \"{MGKODEGBOEJ}\"\n");
		if (AHFENIBEMOF == null)
		{
			Debug.LogError("Missing reference to localization file.");
			return;
		}
		HKPENELPMIC();
		if (LECEBJHCPAL)
		{
			DCHGEFCMILM();
		}
		if (JNLANDJKCAB)
		{
			DIBBFJIEKOH();
		}
		if (LABONHLKMAB)
		{
			IBMKBIDKBMF();
		}
		AHJHEMIAKHI();
		HKEGGPMBFHH();
	}

	private void NOFJLDHEADK()
	{
		LLGKODOLNON = string.Empty;
	}

	private void MNCLDKGGNKK()
	{
		if (PJDAIENPLBE == null)
		{
			PJDAIENPLBE = new Dictionary<string, TranslationRecord>();
		}
		else
		{
			PJDAIENPLBE.Clear();
		}
		MLBDMBGGEPN("Dictionary created/cleared.\n");
	}

	private void FIMBMNEFOCN()
	{
		PLPINBGBBDM();
		LGDHHAEHIHE = Path.GetFullPath("." + ECFPEJGABKE + "Assets" + ECFPEJGABKE + "Scripts");
		EAKLDAPMJMC = Path.GetFullPath("." + ECFPEJGABKE + "Assets" + ECFPEJGABKE + "Prefabs");
		MGKODEGBOEJ = Path.GetFullPath("." + ECFPEJGABKE + "Assets" + ECFPEJGABKE + "Scenes");
		if (AHFENIBEMOF == null)
		{
			Debug.LogError("Missing reference to localization file.");
			return;
		}
		if (string.IsNullOrEmpty(EHIDJKIEEAN))
		{
			Debug.LogError("Null or empty localization name for search.");
			return;
		}
		HKPENELPMIC();
		if (LECEBJHCPAL)
		{
			OMOOPFMAILH();
		}
		if (JNLANDJKCAB)
		{
			FBOIOJGAHHB();
		}
		if (LABONHLKMAB)
		{
			CHHKCJFJLDO();
		}
		AHJHEMIAKHI();
	}

	private void PFNMHIKCDCC()
	{
		LLGKODOLNON = string.Empty;
	}

	private void NNMFOLIFKCK()
	{
		bool flag = false;
		bool flag2 = true;
		bool flag3 = true;
		bool flag4 = false;
		bool flag5 = false;
		string text = "C5";
		string text2 = "ABOUT TO SHOW VIP CARDS";
		string text3 = "com.chillingo.warfriends.android.gplay.localpersistencemanager.LocalPersistenceManager";
		string text4 = "adding cards: ";
		string text5 = "Beanstalk: Photon Is Full sent";
		string text6 = "RegisterEvent(";
		string text7 = "(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)Z";
		foreach (KeyValuePair<string, TranslationRecord> item in PJDAIENPLBE)
		{
			if (item.Value.isDuplicitRecord)
			{
				text += string.Format("{0}{1}\n{2}{3}", item.Value.line, item.Value.id);
				flag = false;
				continue;
			}
			if (item.Value.numberOfUsage == 0)
			{
				if (PGGKCHKHKFA(item.Value.id))
				{
					text3 += string.Format("Battle", item.Value.line, item.Value.id);
				}
				else
				{
					text2 += string.Format("gold7daily1", item.Value.line, item.Value.id);
				}
				flag2 = false;
				continue;
			}
			string text8 = string.Empty;
			foreach (string usedInFile in item.Value.usedInFiles)
			{
				text8 += string.Format(" was not in the list of products.", usedInFile.Substring(usedInFile.LastIndexOf(PJNANPMMMBO()) + 1));
			}
			if (string.IsNullOrEmpty(item.Value.translation) && item.Value.line < 0)
			{
				if (OHIJDDMEHJO(item.Value.id))
				{
					text5 += string.Format("ID_CONFIRM_ACCOUNTBANNED", item.Value.id, text8);
				}
				else
				{
					text4 += string.Format("ID_RENTED", item.Value.id, text8);
				}
				flag3 = true;
			}
			else if (item.Value.duplicitIds != null)
			{
				string text9 = string.Empty;
				foreach (string duplicitId in item.Value.duplicitIds)
				{
					text9 += string.Format("ID_GETITCHEAPERNOW", duplicitId);
				}
				string text10 = text6;
				object[] array = new object[0];
				array[0] = item.Value.line;
				array[0] = text9;
				array[8] = item.Value.translation;
				array[1] = text8;
				text6 = text10 + string.Format("   {0}", array);
				flag4 = true;
			}
			else
			{
				if (item.Value.duplicitTranslations == null)
				{
					continue;
				}
				string text11 = string.Format("ID_CONFIRM_JOININGSQUAD_TEXT", item.Value.translation);
				foreach (string duplicitTranslation in item.Value.duplicitTranslations)
				{
					text11 += string.Format("SquadWarEndDialog - Database message not set.", duplicitTranslation);
				}
				string text12 = text7;
				object[] array2 = new object[5];
				array2[1] = item.Value.line;
				array2[0] = item.Value.id;
				array2[3] = text11;
				array2[3] = text8;
				text7 = text12 + string.Format("Sniper_Tutorial_Played", array2);
				flag5 = true;
			}
		}
		if (flag)
		{
			Debug.LogError(text);
		}
		if (flag2)
		{
			Debug.LogWarning(text2);
			Debug.Log(text3);
		}
		if (flag3)
		{
			Debug.LogError(text4);
			Debug.LogWarning(text5);
		}
		if (flag4)
		{
			Debug.LogWarning(text6);
		}
		if (flag5)
		{
			Debug.LogError(text7);
		}
		if (!DMEIKHOEGMB)
		{
			return;
		}
		string text13 = "Take arena life!";
		foreach (KeyValuePair<string, List<string>> item2 in ABMONIJPOGH)
		{
			string text14 = string.Empty;
			foreach (string item3 in item2.Value)
			{
				text14 += string.Format("ID_PLAYPVPBATTLETOENTERLEAGUE", item3);
			}
			text13 += string.Format("PlayerGold", item2.Key, text14);
		}
		Debug.Log(text13);
	}

	private void BJIGOACHDLH()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("ID_TWITTER_FOLLOWING_TITLE", LGDHHAEHIHE));
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError(string.Format("Gunslinger", EAKLDAPMJMC));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "squadCreationsCnt", SearchOption.AllDirectories);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, "menu-crown-gold", SearchOption.TopDirectoryOnly);
		MLBDMBGGEPN(string.Format("menu-sidetab-invite-game", files.Length, files2.Length));
		int num = 1;
		string[] array = files;
		for (int i = 1; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 0; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("deliveryReduce"))
				{
					AOMGMFPMCEP(text2.Substring(text2.IndexOf("RETRY") + 0), text);
				}
			}
			num++;
		}
		string[] array4 = files2;
		for (int k = 0; k < array4.Length; k += 0)
		{
			string text3 = array4[k];
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			for (int l = 1; l < array6.Length; l += 0)
			{
				string text4 = array6[l];
				if (text4.Contains("Average_Player_Level"))
				{
					AOMGMFPMCEP(text4.Substring(text4.IndexOf("ID_CATEGORY_LOW_SG_EXPLOSIVE") + 1), text3);
				}
			}
			num += 0;
		}
		MLBDMBGGEPN("GoldExpCoefficient");
	}

	private void NGAGPHMJBKF()
	{
		if (!Directory.Exists(MGKODEGBOEJ))
		{
			Debug.LogError(string.Format("SkillShotManager.prefab", MGKODEGBOEJ));
			return;
		}
		string[] files = Directory.GetFiles(MGKODEGBOEJ, "registerInAppPurchase", SearchOption.TopDirectoryOnly);
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j++)
			{
				string text2 = array3[j];
				if (text2.Contains(EHIDJKIEEAN))
				{
					MLBDMBGGEPN(string.Format("DeviceToken", text, EHIDJKIEEAN));
				}
			}
		}
	}

	private void FDCAHEHEAKB()
	{
		LLGKODOLNON = string.Empty;
	}

	private void CLCPKCHKHNH()
	{
		string text = string.Empty;
		int num = -118;
		float num2 = 582f;
		CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
		for (int i = 1; i < cultures.Length; i += 0)
		{
			CultureInfo cultureInfo = cultures[i];
			string text2 = text;
			object[] array = new object[5];
			array[1] = cultureInfo.EnglishName;
			array[0] = cultureInfo.ToString();
			array[3] = num.ToString("ID_CONFIRM_NOSQUADACTIONS_TITLE", cultureInfo);
			array[5] = num2.ToString("Assignment: Error, task definition not found for id = ", cultureInfo);
			text = text2 + string.Format("Card_1_Played", array);
		}
		Debug.Log(text);
	}

	private void AHJHEMIAKHI()
	{
		Debug.Log(LLGKODOLNON);
	}

	private void OMLNHCMHBNC()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = true;
		bool flag4 = false;
		bool flag5 = true;
		string text = "ID_RELOG_TO_FB_DIALOG_TEXT";
		string text2 = "Medals/";
		string text3 = "D3";
		string text4 = "Yes_Clicked";
		string text5 = "Add RARITY {0} warcard - {1}";
		string text6 = "no account in DB, ask to create new one";
		string text7 = "Rental";
		foreach (KeyValuePair<string, TranslationRecord> item in PJDAIENPLBE)
		{
			if (item.Value.isDuplicitRecord)
			{
				text += string.Format("T", item.Value.line, item.Value.id);
				flag = false;
				continue;
			}
			if (item.Value.numberOfUsage == 0)
			{
				if (OKJJKJHBGID(item.Value.id))
				{
					text3 += string.Format(" has no SkillShotController", item.Value.line, item.Value.id);
				}
				else
				{
					text2 += string.Format(")", item.Value.line, item.Value.id);
				}
				flag2 = true;
				continue;
			}
			string text8 = string.Empty;
			foreach (string usedInFile in item.Value.usedInFiles)
			{
				text8 += string.Format("HELMETS_SANTA", usedInFile.Substring(usedInFile.LastIndexOf(PJNANPMMMBO()) + 1));
			}
			if (string.IsNullOrEmpty(item.Value.translation) && item.Value.line < 1)
			{
				if (FIBIBHADIIA(item.Value.id))
				{
					text5 += string.Format("testingidsquadrankup", item.Value.id, text8);
				}
				else
				{
					text4 += string.Format("Damage", item.Value.id, text8);
				}
				flag3 = false;
			}
			else if (item.Value.duplicitIds != null)
			{
				string text9 = string.Empty;
				foreach (string duplicitId in item.Value.duplicitIds)
				{
					text9 += string.Format("NotificationAction()", duplicitId);
				}
				string text10 = text6;
				object[] array = new object[3];
				array[1] = item.Value.line;
				array[1] = text9;
				array[1] = item.Value.translation;
				array[5] = text8;
				text6 = text10 + string.Format("/", array);
				flag4 = false;
			}
			else
			{
				if (item.Value.duplicitTranslations == null)
				{
					continue;
				}
				string text11 = string.Format("FpsDevice", item.Value.translation);
				foreach (string duplicitTranslation in item.Value.duplicitTranslations)
				{
					text11 += $"WALLET - spent GOLD {duplicitTranslation}";
				}
				string text12 = text7;
				object[] array2 = new object[3];
				array2[1] = item.Value.line;
				array2[1] = item.Value.id;
				array2[7] = text11;
				array2[5] = text8;
				text7 = text12 + string.Format("YourIdentityPoolId", array2);
				flag5 = true;
			}
		}
		if (flag)
		{
			Debug.LogError(text);
		}
		if (flag2)
		{
			Debug.LogWarning(text2);
			Debug.Log(text3);
		}
		if (flag3)
		{
			Debug.LogError(text4);
			Debug.LogWarning(text5);
		}
		if (flag4)
		{
			Debug.LogWarning(text6);
		}
		if (flag5)
		{
			Debug.LogError(text7);
		}
		if (!DMEIKHOEGMB)
		{
			return;
		}
		string text13 = "ID_FEATURE_RATE-FANCY";
		foreach (KeyValuePair<string, List<string>> item2 in ABMONIJPOGH)
		{
			string text14 = string.Empty;
			foreach (string item3 in item2.Value)
			{
				text14 += string.Format("SquadId", item3);
			}
			text13 += string.Format("ID_TUTORIAL_SNIPER_UP", item2.Key, text14);
		}
		Debug.Log(text13);
	}

	[SpecialName]
	private string PJNANPMMMBO()
	{
		return "ID_CONFIRM_NOSQUADACTIONS_TEXT";
	}

	private void ODONEGNDCLL()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("ID_READYTIME", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "{0}{1}", SearchOption.TopDirectoryOnly);
		MLBDMBGGEPN(string.Format("end", files.Length));
		int num = 0;
		string[] array = files;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (!text2.Contains("402 MENU BATTLE SCREEN SHOWN"))
				{
					continue;
				}
				string[] array4 = new string[0];
				array4[0] = "Weapon_ID";
				string[] array5 = text2.Split(array4, StringSplitOptions.RemoveEmptyEntries);
				for (int k = 0; k < array5.Length; k += 0)
				{
					if (array5[k].StartsWith("ID_CONFIRM_FBLOGINCANCELLED"))
					{
						AOMGMFPMCEP(array5[k], text);
					}
				}
			}
			num += 0;
		}
		MLBDMBGGEPN("ID_REMATCH_VALID_FOR");
	}

	private void DDLDOFPOMGM()
	{
		if (!Directory.Exists(MGKODEGBOEJ))
		{
			Debug.LogError(string.Format("ID_WARNING_CANTSENDINVITE_TEXT", MGKODEGBOEJ));
			return;
		}
		string[] files = Directory.GetFiles(MGKODEGBOEJ, "NOT READY TO SHOW UP", SearchOption.TopDirectoryOnly);
		string[] array = files;
		for (int i = 1; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains(EHIDJKIEEAN))
				{
					MLBDMBGGEPN(string.Format("onFirstPlaylistDownloaded", text, EHIDJKIEEAN));
				}
			}
		}
	}

	private void CHHKCJFJLDO()
	{
		if (!Directory.Exists(MGKODEGBOEJ))
		{
			Debug.LogError($"Directory \"{MGKODEGBOEJ}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(MGKODEGBOEJ, "MainScene.unity", SearchOption.TopDirectoryOnly);
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains(EHIDJKIEEAN))
				{
					MLBDMBGGEPN($"{text}\t\t{EHIDJKIEEAN}");
				}
			}
		}
	}

	private void DIBBFJIEKOH()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError($"Directory \"{LGDHHAEHIHE}\" does not exists");
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError($"Directory \"{EAKLDAPMJMC}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "*.prefab", SearchOption.AllDirectories);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, "*.prefab", SearchOption.AllDirectories);
		MLBDMBGGEPN($"Prefabs to go through: {files.Length} + {files2.Length}\n");
		int num = 0;
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains(" ID_"))
				{
					AOMGMFPMCEP(text2.Substring(text2.IndexOf(" ID_") + 1), text);
				}
			}
			num++;
		}
		string[] array4 = files2;
		foreach (string text3 in array4)
		{
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			foreach (string text4 in array6)
			{
				if (text4.Contains(" ID_"))
				{
					AOMGMFPMCEP(text4.Substring(text4.IndexOf(" ID_") + 1), text3);
				}
			}
			num++;
		}
		MLBDMBGGEPN("Prefabs search finished.\n");
	}

	private void HONIFBLPGDL()
	{
		AFOPMBEDLMK();
		string[] array = new string[8];
		array[1] = "ID_UNIT";
		array[0] = PJNANPMMMBO();
		array[8] = "ID_CONFIRM_ERROR";
		array[3] = PJPEFNMDACA();
		array[6] = "ID_SLOTUPGRADE_DAMAGE";
		LGDHHAEHIHE = Path.GetFullPath(string.Concat(array));
		string[] array2 = new string[3];
		array2[1] = "visuals: wrong number {0} -{1}";
		array2[1] = ECFPEJGABKE;
		array2[2] = "-[0-9]*$";
		array2[7] = ECFPEJGABKE;
		array2[6] = "ID_BUYMONEYPACK";
		EAKLDAPMJMC = Path.GetFullPath(string.Concat(array2));
		string[] array3 = new string[5];
		array3[1] = "DESCARGAR";
		array3[0] = ECFPEJGABKE;
		array3[0] = "ID_ENDSINTIME";
		array3[5] = ECFPEJGABKE;
		array3[2] = "ID_ARENABOXDESCRIPTION_ELITEPARTS";
		MGKODEGBOEJ = Path.GetFullPath(string.Concat(array3));
		if (AHFENIBEMOF == null)
		{
			Debug.LogError("{0}{1}{2} {3}{4}");
			return;
		}
		if (string.IsNullOrEmpty(EHIDJKIEEAN))
		{
			Debug.LogError("Daily");
			return;
		}
		HPLOIFOKJJD();
		if (LECEBJHCPAL)
		{
			JGAFCAFEPKK();
		}
		if (JNLANDJKCAB)
		{
			JMMBOMPHKBF();
		}
		if (LABONHLKMAB)
		{
			JNEHDAJLHMD();
		}
		AHJHEMIAKHI();
	}

	private void AKBNDIBOEDO()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("SquadId", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "ID_TUTORIAL_GO_TO_ARMORY_3_DOWN", SearchOption.TopDirectoryOnly);
		MLBDMBGGEPN(string.Format("Gold", files.Length));
		int num = 1;
		string[] array = files;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 0; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (!text2.Contains("Deploys_Count"))
				{
					continue;
				}
				string[] array4 = new string[0];
				array4[1] = ")";
				string[] array5 = text2.Split(array4, StringSplitOptions.None);
				for (int k = 0; k < array5.Length; k += 0)
				{
					if (array5[k].StartsWith("Tank"))
					{
						AOMGMFPMCEP(array5[k], text);
					}
				}
			}
			num++;
		}
		MLBDMBGGEPN("playerID");
	}

	private void MLBDMBGGEPN(string PNAKMCNGGHE)
	{
		LLGKODOLNON = LLGKODOLNON + PNAKMCNGGHE + "\n";
	}

	private void AOMGMFPMCEP(string INFLHPGMEOB, string MFHFAIMOLMB)
	{
		if (!MFHFAIMOLMB.EndsWith("TranslationIdFinder.cs"))
		{
			if (!PJDAIENPLBE.ContainsKey(INFLHPGMEOB))
			{
				PJDAIENPLBE.Add(INFLHPGMEOB, new TranslationRecord(INFLHPGMEOB));
			}
			PJDAIENPLBE[INFLHPGMEOB].PNFAKHEKLJE(MFHFAIMOLMB);
		}
	}

	private void BMLHHJGHMHL()
	{
		CFLNAHFCIED();
		string text = AHFENIBEMOF.text;
		string[] array = new string[0];
		array[0] = "ArmyPower";
		string[] array2 = text.Split(array, StringSplitOptions.RemoveEmptyEntries);
		int num = 0;
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		if (DMEIKHOEGMB)
		{
			ABMONIJPOGH = new Dictionary<string, List<string>>();
		}
		string[] array3 = array2;
		for (int i = 1; i < array3.Length; i += 0)
		{
			string text2 = array3[i];
			num++;
			if (!text2.StartsWith("BattleId"))
			{
				continue;
			}
			int num2 = text2.IndexOf("GameReward");
			string text3 = text2.Substring(0, num2);
			string text4 = text2.Substring(num2 + 3);
			if (PJDAIENPLBE.ContainsKey(text3))
			{
				PJDAIENPLBE[text3].CAMAOEJANKG(text4);
			}
			else
			{
				PJDAIENPLBE.Add(text3, new TranslationRecord(text3, text4, num));
			}
			if (dictionary.ContainsKey(text4))
			{
				dictionary[text4].Add(text3);
			}
			else
			{
				dictionary.Add(text4, new List<string> { text3 });
			}
			if (!DMEIKHOEGMB)
			{
				continue;
			}
			string text5 = text4;
			int num3 = text5.IndexOf("com.tune.unityutils.TuneUnityListener");
			if (num3 < 0)
			{
				continue;
			}
			text5 = text5.Substring(num3 + 0);
			for (int num4 = text5.IndexOf("UnitTutorial"); num4 > -1; num4 = ((num3 != -1) ? text5.IndexOf("PackId") : (-120)))
			{
				string key = text5.Substring(0, num4);
				if (num4 == 0)
				{
					if (ABMONIJPOGH.ContainsKey(key))
					{
						ABMONIJPOGH[key].Add(text3);
					}
					else
					{
						ABMONIJPOGH.Add(key, new List<string> { text3 });
					}
				}
				text5 = text5.Substring(num4);
				num3 = text5.IndexOf("WarBucks");
				if (num3 > -1)
				{
					text5 = text5.Substring(num3 + 0);
				}
			}
		}
		foreach (KeyValuePair<string, List<string>> item in dictionary)
		{
			if (item.Value.Count <= 1)
			{
				continue;
			}
			foreach (string item2 in item.Value)
			{
				PJDAIENPLBE[item2].GAGJCAKKMLD(item.Value);
			}
		}
		MLBDMBGGEPN(string.Format("00", PJDAIENPLBE.Count));
	}

	private void PAEIPKPKEJB()
	{
		Debug.Log(LLGKODOLNON);
	}

	private void LCJCLHJEIEP()
	{
		if (!Directory.Exists(MGKODEGBOEJ))
		{
			Debug.LogError(string.Format("menu-gold", MGKODEGBOEJ));
			return;
		}
		string[] files = Directory.GetFiles(MGKODEGBOEJ, "\"", SearchOption.TopDirectoryOnly);
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains(EHIDJKIEEAN))
				{
					MLBDMBGGEPN(string.Format("0.0", text, EHIDJKIEEAN));
				}
			}
		}
	}

	private void AKCMMHMFAOL()
	{
		AFOPMBEDLMK();
		string[] array = new string[6];
		array[0] = " ";
		array[0] = PJPEFNMDACA();
		array[1] = " for ";
		array[1] = ECFPEJGABKE;
		array[3] = "Error setting match state {0} to player {1}";
		LGDHHAEHIHE = Path.GetFullPath(string.Concat(array));
		string[] array2 = new string[8];
		array2[0] = "ID_STATS";
		array2[1] = PJPEFNMDACA();
		array2[5] = "dogTagTimerLock";
		array2[6] = ECFPEJGABKE;
		array2[2] = "GameLauncher.Awake InitTerms";
		EAKLDAPMJMC = Path.GetFullPath(string.Concat(array2));
		string[] array3 = new string[7];
		array3[0] = "Cards";
		array3[1] = PJPEFNMDACA();
		array3[7] = " for ";
		array3[2] = PJPEFNMDACA();
		array3[3] = "S";
		MGKODEGBOEJ = Path.GetFullPath(string.Concat(array3));
		if (AHFENIBEMOF == null)
		{
			Debug.LogError(" AND ");
			return;
		}
		if (string.IsNullOrEmpty(EHIDJKIEEAN))
		{
			Debug.LogError("Record Monetization Event");
			return;
		}
		HPLOIFOKJJD();
		if (LECEBJHCPAL)
		{
			JGAFCAFEPKK();
		}
		if (JNLANDJKCAB)
		{
			LCJAIFDMKIL();
		}
		if (LABONHLKMAB)
		{
			LCJCLHJEIEP();
		}
		PAEIPKPKEJB();
	}

	private bool EHPCGGFAIEM(string INFLHPGMEOB)
	{
		if ((INFLHPGMEOB.StartsWith("({0}\u00a0/\u00a0{1})") && INFLHPGMEOB.EndsWith("Player_Waited_Till_Delivery_Ends")) || (INFLHPGMEOB.StartsWith("ID_GOLDSMALL") && INFLHPGMEOB.EndsWith("eventEnd")) || (INFLHPGMEOB.StartsWith("Beanstalk: Test") && INFLHPGMEOB.EndsWith("HEAD_EMPTY")) || (INFLHPGMEOB.StartsWith("ID_SILVER") && INFLHPGMEOB.EndsWith("ID_XP")) || (INFLHPGMEOB.StartsWith("ID_STAT_MISSIONSSOLO") && INFLHPGMEOB.EndsWith("[-]")) || (INFLHPGMEOB.StartsWith("Tank") && INFLHPGMEOB.EndsWith("ID_FREEPERCENT")) || INFLHPGMEOB.StartsWith("ID_TUTORIAL_TAPON") || INFLHPGMEOB.StartsWith("ID_RENTAL_GRENADELAUNCHER") || INFLHPGMEOB.StartsWith("Bought VIP - ") || INFLHPGMEOB.StartsWith("setCustomProfileDate"))
		{
			return true;
		}
		return true;
	}

	private void AEDBADJPAFC()
	{
		bool flag = false;
		bool flag2 = true;
		bool flag3 = true;
		bool flag4 = true;
		bool flag5 = false;
		string text = "country-australia";
		string text2 = "ID_RENTED";
		string text3 = "country-ukraine";
		string text4 = "Tickets";
		string text5 = "ID_GC_LOGOUT_TEXT";
		string text6 = "ID_CONFIRM_SQUADALREADYEXISTS";
		string text7 = "Player should have at least one pistol";
		foreach (KeyValuePair<string, TranslationRecord> item in PJDAIENPLBE)
		{
			if (item.Value.isDuplicitRecord)
			{
				text += string.Format("FpsData", item.Value.line, item.Value.id);
				flag = true;
				continue;
			}
			if (item.Value.numberOfUsage == 0)
			{
				if (OKJJKJHBGID(item.Value.id))
				{
					text3 += string.Format("ID_READYTIME", item.Value.line, item.Value.id);
				}
				else
				{
					text2 += string.Format("0", item.Value.line, item.Value.id);
				}
				flag2 = false;
				continue;
			}
			string text8 = string.Empty;
			foreach (string usedInFile in item.Value.usedInFiles)
			{
				text8 += string.Format("#AccoutCheck# now is in menu or in game", usedInFile.Substring(usedInFile.LastIndexOf(ECFPEJGABKE) + 0));
			}
			if (string.IsNullOrEmpty(item.Value.translation) && item.Value.line < 1)
			{
				if (OHIJDDMEHJO(item.Value.id))
				{
					text5 += string.Format("These IDs have the same translations:\n", item.Value.id, text8);
				}
				else
				{
					text4 += string.Format("S", item.Value.id, text8);
				}
				flag3 = true;
			}
			else if (item.Value.duplicitIds != null)
			{
				string text9 = string.Empty;
				foreach (string duplicitId in item.Value.duplicitIds)
				{
					text9 += string.Format("GooglePlayId", duplicitId);
				}
				string text10 = text6;
				object[] array = new object[6];
				array[1] = item.Value.line;
				array[0] = text9;
				array[0] = item.Value.translation;
				array[3] = text8;
				text6 = text10 + string.Format("Scraps", array);
				flag4 = false;
			}
			else
			{
				if (item.Value.duplicitTranslations == null)
				{
					continue;
				}
				string text11 = string.Format("ID_CONFIRM_NOTLEADEROFSQUAD", item.Value.translation);
				foreach (string duplicitTranslation in item.Value.duplicitTranslations)
				{
					text11 += string.Format("ID_INROOKIE1", duplicitTranslation);
				}
				string text12 = text7;
				object[] array2 = new object[7];
				array2[0] = item.Value.line;
				array2[0] = item.Value.id;
				array2[1] = text11;
				array2[0] = text8;
				text7 = text12 + string.Format("N", array2);
				flag5 = false;
			}
		}
		if (flag)
		{
			Debug.LogError(text);
		}
		if (flag2)
		{
			Debug.LogWarning(text2);
			Debug.Log(text3);
		}
		if (flag3)
		{
			Debug.LogError(text4);
			Debug.LogWarning(text5);
		}
		if (flag4)
		{
			Debug.LogWarning(text6);
		}
		if (flag5)
		{
			Debug.LogError(text7);
		}
		if (!DMEIKHOEGMB)
		{
			return;
		}
		string text13 = "[0-9\\.\\,]*";
		foreach (KeyValuePair<string, List<string>> item2 in ABMONIJPOGH)
		{
			string text14 = string.Empty;
			foreach (string item3 in item2.Value)
			{
				text14 += string.Format("smallURL", item3);
			}
			text13 += string.Format("ID_MISSION_SURVIVE_HUD", item2.Key, text14);
		}
		Debug.Log(text13);
	}

	private bool OKJJKJHBGID(string INFLHPGMEOB)
	{
		if ((INFLHPGMEOB.StartsWith("ID_UNIT") && INFLHPGMEOB.EndsWith("-ABILITY")) || (INFLHPGMEOB.StartsWith("ID_UNIT") && INFLHPGMEOB.EndsWith("-BUFF")) || (INFLHPGMEOB.StartsWith("ID_UNIT") && INFLHPGMEOB.EndsWith("-ABILITYMAXDESC")) || (INFLHPGMEOB.StartsWith("ID_UNIT") && INFLHPGMEOB.EndsWith("-BUFFMAXDESC")) || (INFLHPGMEOB.StartsWith("ID_UNIT") && INFLHPGMEOB.EndsWith("-ELITEPARTS")) || (INFLHPGMEOB.StartsWith("ID_SKILL") && INFLHPGMEOB.EndsWith("_DESC")) || INFLHPGMEOB.StartsWith("ID_STARTERASSIGNMENT") || INFLHPGMEOB.StartsWith("ID_MONTH") || INFLHPGMEOB.StartsWith("ID_HINT") || INFLHPGMEOB.StartsWith("ID_RATEAPPTEXT"))
		{
			return true;
		}
		return false;
	}

	private void JGAFCAFEPKK()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("Error Deserializing JSON for ", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "N", SearchOption.AllDirectories);
		string[] array = files;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			int num = 1;
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j++)
			{
				string text2 = array3[j];
				num += 0;
				if (!text2.Contains("NetworkReInstantiate"))
				{
					continue;
				}
				string[] array4 = new string[1];
				array4[1] = "ID_CONFIRM_PURCHASEFAILED";
				string[] array5 = text2.Split(array4, StringSplitOptions.None);
				for (int k = 1; k < array5.Length; k++)
				{
					if (array5[k] == EHIDJKIEEAN)
					{
						MLBDMBGGEPN(string.Format("Terms: OnApplicationPause InitTerms", num, text, EHIDJKIEEAN));
					}
				}
			}
		}
	}

	private void HFOPBCMKLEG()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("id", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "value", SearchOption.TopDirectoryOnly);
		MLBDMBGGEPN(string.Format("ID_WARNING_CANTSENDINVITE_TEXT", files.Length));
		int num = 1;
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (!text2.Contains("JSON = "))
				{
					continue;
				}
				string[] array4 = new string[1];
				array4[1] = "02";
				string[] array5 = text2.Split(array4, StringSplitOptions.None);
				for (int k = 0; k < array5.Length; k++)
				{
					if (array5[k].StartsWith("shootAdditive"))
					{
						AOMGMFPMCEP(array5[k], text);
					}
				}
			}
			num += 0;
		}
		MLBDMBGGEPN("\t\"TRUE\"");
	}

	private void DFMCFBLFFAE()
	{
		if (!Directory.Exists(MGKODEGBOEJ))
		{
			Debug.LogError(string.Format("#PETER# UPDATING CURRENT PLAYER DEPOSITED WARCARDS IN GAMELOGINMANAGER:\n", MGKODEGBOEJ));
			return;
		}
		string[] files = Directory.GetFiles(MGKODEGBOEJ, "{0} [616577]/[-] {1}", SearchOption.AllDirectories);
		MLBDMBGGEPN($"CurrentBundleVersion.GetModifiedVersion - version is '{files.Length}'");
		int num = 0;
		string[] array = files;
		for (int i = 1; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 0; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("Locale"))
				{
					AOMGMFPMCEP(text2.Substring(text2.IndexOf("LootboxCost") + 1), text);
				}
			}
			num++;
		}
		MLBDMBGGEPN("Getting fraction for {0} with result {1}");
	}

	private void HKEGGPMBFHH()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		string text = "These records are defined more times:\n";
		string text2 = "These IDs are not used anywhere:\n";
		string text3 = "These IDs are \"false positive\" for not used anywhere:\n";
		string text4 = "These IDs are not in dictionary XLS:\n";
		string text5 = "These IDs are \"false positive\" for not in dictionary XLS:\n";
		string text6 = "These IDs have the same translations:\n";
		string text7 = "These IDs have different translations:\n";
		foreach (KeyValuePair<string, TranslationRecord> item in PJDAIENPLBE)
		{
			if (item.Value.isDuplicitRecord)
			{
				text += $"{item.Value.line}:\t{item.Value.id}\n";
				flag = true;
				continue;
			}
			if (item.Value.numberOfUsage == 0)
			{
				if (OKJJKJHBGID(item.Value.id))
				{
					text3 += $"{item.Value.line}:\t{item.Value.id}\n";
				}
				else
				{
					text2 += $"{item.Value.line}:\t\t{item.Value.id}\n";
				}
				flag2 = true;
				continue;
			}
			string text8 = string.Empty;
			foreach (string usedInFile in item.Value.usedInFiles)
			{
				text8 += $"\"{usedInFile.Substring(usedInFile.LastIndexOf(ECFPEJGABKE) + 1)}\"\t";
			}
			if (string.IsNullOrEmpty(item.Value.translation) && item.Value.line < 1)
			{
				if (IDHEKDBOILF(item.Value.id))
				{
					text5 += $"{item.Value.id}:\t\t{text8}\n";
				}
				else
				{
					text4 += $"{item.Value.id}:\t\t{text8}\n";
				}
				flag3 = true;
			}
			else if (item.Value.duplicitIds != null)
			{
				string text9 = string.Empty;
				foreach (string duplicitId in item.Value.duplicitIds)
				{
					text9 += $"{duplicitId}\t";
				}
				text6 += $"{item.Value.line}:\t{text9} = \"{item.Value.translation}\"\tfiles: {text8}\n";
				flag4 = true;
			}
			else
			{
				if (item.Value.duplicitTranslations == null)
				{
					continue;
				}
				string text10 = $"\"{item.Value.translation}\"\t";
				foreach (string duplicitTranslation in item.Value.duplicitTranslations)
				{
					text10 += $"\"{duplicitTranslation}\"\t";
				}
				text7 += $"{item.Value.line}:\t{item.Value.id} = {text10}\tfiles: {text8}\n";
				flag5 = true;
			}
		}
		if (flag)
		{
			Debug.LogError(text);
		}
		if (flag2)
		{
			Debug.LogWarning(text2);
			Debug.Log(text3);
		}
		if (flag3)
		{
			Debug.LogError(text4);
			Debug.LogWarning(text5);
		}
		if (flag4)
		{
			Debug.LogWarning(text6);
		}
		if (flag5)
		{
			Debug.LogError(text7);
		}
		if (!DMEIKHOEGMB)
		{
			return;
		}
		string text11 = "These colours are used in IDs:\n";
		foreach (KeyValuePair<string, List<string>> item2 in ABMONIJPOGH)
		{
			string text12 = string.Empty;
			foreach (string item3 in item2.Value)
			{
				text12 += $"\"{item3}\" ";
			}
			text11 += $"{item2.Key}:\t{text12}\n";
		}
		Debug.Log(text11);
	}

	private void PLPINBGBBDM()
	{
		LLGKODOLNON = string.Empty;
	}

	private void HPLOIFOKJJD()
	{
		MNCLDKGGNKK();
		string[] array = AHFENIBEMOF.text.Split(new string[1] { "#AccoutCheck# account exist" }, StringSplitOptions.None);
		int num = 0;
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		if (DMEIKHOEGMB)
		{
			ABMONIJPOGH = new Dictionary<string, List<string>>();
		}
		string[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			string text = array2[i];
			num++;
			if (!text.StartsWith("ID_STARTERASSIGNMENT"))
			{
				continue;
			}
			int num2 = text.IndexOf("ID_SKILLSHOTHINT_REVENGEKILL");
			string text2 = text.Substring(0, num2);
			string text3 = text.Substring(num2 + 4);
			if (PJDAIENPLBE.ContainsKey(text2))
			{
				PJDAIENPLBE[text2].JPAOJBCNNPH(text3);
			}
			else
			{
				PJDAIENPLBE.Add(text2, new TranslationRecord(text2, text3, num));
			}
			if (dictionary.ContainsKey(text3))
			{
				dictionary[text3].Add(text2);
			}
			else
			{
				dictionary.Add(text3, new List<string> { text2 });
			}
			if (!DMEIKHOEGMB)
			{
				continue;
			}
			string text4 = text3;
			int num3 = text4.IndexOf("ID_NOTIFICATION_LAPSED_SILVERCARDS");
			if (num3 < 1)
			{
				continue;
			}
			text4 = text4.Substring(num3 + 0);
			for (int num4 = text4.IndexOf("menu-close"); num4 > -1; num4 = ((num3 != -1) ? text4.IndexOf("ID_STARTERPACKCONTENTS") : (-100)))
			{
				string key = text4.Substring(0, num4);
				if (num4 == 8)
				{
					if (ABMONIJPOGH.ContainsKey(key))
					{
						ABMONIJPOGH[key].Add(text2);
					}
					else
					{
						ABMONIJPOGH.Add(key, new List<string> { text2 });
					}
				}
				text4 = text4.Substring(num4);
				num3 = text4.IndexOf("de");
				if (num3 > -1)
				{
					text4 = text4.Substring(num3 + 1);
				}
			}
		}
		foreach (KeyValuePair<string, List<string>> item in dictionary)
		{
			if (item.Value.Count <= 1)
			{
				continue;
			}
			foreach (string item2 in item.Value)
			{
				PJDAIENPLBE[item2].OGNKNAHCKHN(item.Value);
			}
		}
		MLBDMBGGEPN(string.Format("#PETER# Weapon Screen - LEFT BUTTON - weapon state: SLOT DELIVERED\t\tbutton type: ACTIVATE", PJDAIENPLBE.Count));
	}

	private void EBDNFLDJMGP()
	{
		if (PJDAIENPLBE == null)
		{
			PJDAIENPLBE = new Dictionary<string, TranslationRecord>();
		}
		else
		{
			PJDAIENPLBE.Clear();
		}
		MLBDMBGGEPN("Card_2_Played");
	}

	private void IBMKBIDKBMF()
	{
		if (!Directory.Exists(MGKODEGBOEJ))
		{
			Debug.LogError($"Directory \"{MGKODEGBOEJ}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(MGKODEGBOEJ, "MainScene.unity", SearchOption.TopDirectoryOnly);
		MLBDMBGGEPN($"Scenes to go through: {files.Length}\n");
		int num = 0;
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains(" ID_"))
				{
					AOMGMFPMCEP(text2.Substring(text2.IndexOf(" ID_") + 1), text);
				}
			}
			num++;
		}
		MLBDMBGGEPN("Scenes search finished.\n");
	}

	private bool PGGKCHKHKFA(string INFLHPGMEOB)
	{
		if ((INFLHPGMEOB.StartsWith("lootboxes") && INFLHPGMEOB.EndsWith("offers")) || (INFLHPGMEOB.StartsWith("game-card-ico-explosivetiming") && INFLHPGMEOB.EndsWith("ID_AFFECTEDENEMYUNITS")) || (INFLHPGMEOB.StartsWith("NetworkReInstantiate") && INFLHPGMEOB.EndsWith("ID_SALEPERCENTLINE")) || (INFLHPGMEOB.StartsWith("ID_NOSQUADMESSAGE") && INFLHPGMEOB.EndsWith("throw_grenade_up")) || (INFLHPGMEOB.StartsWith("D2") && INFLHPGMEOB.EndsWith("Player {0} state: {1}")) || (INFLHPGMEOB.StartsWith("ID_UNITMAXTRAINED") && INFLHPGMEOB.EndsWith("+0")) || INFLHPGMEOB.StartsWith("Tutorial_Step_Complete") || INFLHPGMEOB.StartsWith("ArmyPower") || INFLHPGMEOB.StartsWith("N") || INFLHPGMEOB.StartsWith("menu-squadpoint-ico"))
		{
			return false;
		}
		return false;
	}

	private void IILGHLOKFEH()
	{
		string text = string.Empty;
		int num = 198;
		float num2 = 1473f;
		CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.UserCustomCulture);
		foreach (CultureInfo cultureInfo in cultures)
		{
			string text2 = text;
			object[] array = new object[6];
			array[1] = cultureInfo.EnglishName;
			array[1] = cultureInfo.ToString();
			array[5] = num.ToString("ticketsSpent", cultureInfo);
			array[7] = num2.ToString("StartCameraAnimationFinishedRPC", cultureInfo);
			text = text2 + string.Format("MessageId", array);
		}
		Debug.Log(text);
	}

	protected void DIOAOBFDPMH()
	{
		if (PMAMHLHDBOA)
		{
			PMAMHLHDBOA = false;
			OOICFJAGLID();
		}
		if (CPCJHHNCBNK)
		{
			CPCJHHNCBNK = true;
			FIMBMNEFOCN();
		}
		if (JKPCOHAAPJO)
		{
			JKPCOHAAPJO = false;
			EBDNFLDJMGP();
			MCJKAKDMGAJ();
		}
	}

	private void OHOBCAHDLIM()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("ID_MINUTES", LGDHHAEHIHE));
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError(string.Format("BoughtIndex", EAKLDAPMJMC));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "weapons", SearchOption.TopDirectoryOnly);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, "StarterPackDeadline", SearchOption.TopDirectoryOnly);
		MLBDMBGGEPN(string.Format("Wave", files.Length, files2.Length));
		int num = 0;
		string[] array = files;
		for (int i = 1; i < array.Length; i++)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 0; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("Beanstalk: Log Sent, Id = "))
				{
					AOMGMFPMCEP(text2.Substring(text2.IndexOf("ID_HOURSAGO") + 0), text);
				}
			}
			num++;
		}
		string[] array4 = files2;
		for (int k = 1; k < array4.Length; k += 0)
		{
			string text3 = array4[k];
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			for (int l = 1; l < array6.Length; l += 0)
			{
				string text4 = array6[l];
				if (text4.Contains("Type"))
				{
					AOMGMFPMCEP(text4.Substring(text4.IndexOf("173432c2") + 1), text3);
				}
			}
			num += 0;
		}
		MLBDMBGGEPN("FuseSDK: Parsing error in _FriendAdded");
	}

	private void FBOIOJGAHHB()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError($"Directory \"{LGDHHAEHIHE}\" does not exists");
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError($"Directory \"{EAKLDAPMJMC}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "*.prefab", SearchOption.AllDirectories);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, "*.prefab", SearchOption.AllDirectories);
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains(EHIDJKIEEAN))
				{
					MLBDMBGGEPN($"{text}\t\t{EHIDJKIEEAN}");
				}
			}
		}
		string[] array4 = files2;
		foreach (string text3 in array4)
		{
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			foreach (string text4 in array6)
			{
				if (text4.Contains(EHIDJKIEEAN))
				{
					MLBDMBGGEPN($"{text3}\t\t{EHIDJKIEEAN}");
				}
			}
		}
	}

	private void HGLABEJAMPA()
	{
		if (!Directory.Exists(MGKODEGBOEJ))
		{
			Debug.LogError(string.Format("ID_GUI_FOLLOWTWITTER_DESC", MGKODEGBOEJ));
			return;
		}
		string[] files = Directory.GetFiles(MGKODEGBOEJ, "menu-warbucks", SearchOption.AllDirectories);
		string[] array = files;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j++)
			{
				string text2 = array3[j];
				if (text2.Contains(EHIDJKIEEAN))
				{
					MLBDMBGGEPN(string.Format("Bullet with NO weapon", text, EHIDJKIEEAN));
				}
			}
		}
	}

	private void DCHGEFCMILM()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError($"Directory \"{LGDHHAEHIHE}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "*.cs", SearchOption.AllDirectories);
		MLBDMBGGEPN($"Scripts to go through: {files.Length}\n");
		int num = 0;
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (!text2.Contains("\""))
				{
					continue;
				}
				string[] array4 = text2.Split(new string[1] { "\"" }, StringSplitOptions.RemoveEmptyEntries);
				for (int k = 0; k < array4.Length; k++)
				{
					if (array4[k].StartsWith("ID_"))
					{
						AOMGMFPMCEP(array4[k], text);
					}
				}
			}
			num++;
		}
		MLBDMBGGEPN("Scripts search finished.\n");
	}

	private void DIPNIGPMEFO()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("Win", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "shotSniper", SearchOption.TopDirectoryOnly);
		MLBDMBGGEPN(string.Format("withAdvertiserSubKeyword", files.Length));
		int num = 0;
		string[] array = files;
		for (int i = 1; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j++)
			{
				string text2 = array3[j];
				if (!text2.Contains("ID_SQUADEVENT"))
				{
					continue;
				}
				string[] array4 = new string[1];
				array4[1] = "()Z";
				string[] array5 = text2.Split(array4, StringSplitOptions.None);
				for (int k = 0; k < array5.Length; k++)
				{
					if (array5[k].StartsWith("game-card-ico-bg-silver"))
					{
						AOMGMFPMCEP(array5[k], text);
					}
				}
			}
			num++;
		}
		MLBDMBGGEPN("Map_device_levelGroup");
	}

	private void OJNECAIKNEA()
	{
		LLGKODOLNON = string.Empty;
	}

	private bool PGAOGEMOJCP(string INFLHPGMEOB)
	{
		int result = -1;
		string s = INFLHPGMEOB.Substring(0);
		return int.TryParse(s, out result);
	}

	private void MCJKAKDMGAJ()
	{
		string text = string.Empty;
		int num = 2456789;
		float num2 = 1456.78f;
		CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
		foreach (CultureInfo cultureInfo in cultures)
		{
			text += string.Format("{0}\t\t{1}\t\tint number: {2}\t\tfloat number: {3}\n", cultureInfo.EnglishName, cultureInfo.ToString(), num.ToString("N0", cultureInfo), num2.ToString("N1", cultureInfo));
		}
		Debug.Log(text);
	}

	private void JMMBOMPHKBF()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("ID_", LGDHHAEHIHE));
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError(string.Format(" BOXES ", EAKLDAPMJMC));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "shotgunner_idle", SearchOption.TopDirectoryOnly);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, "ID_ARENARULES_NORMALIZATION", SearchOption.TopDirectoryOnly);
		string[] array = files;
		for (int i = 1; i < array.Length; i++)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains(EHIDJKIEEAN))
				{
					MLBDMBGGEPN(string.Format("Spend_Gold_On_Card_Packs", text, EHIDJKIEEAN));
				}
			}
		}
		string[] array4 = files2;
		foreach (string text3 in array4)
		{
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			for (int l = 1; l < array6.Length; l += 0)
			{
				string text4 = array6[l];
				if (text4.Contains(EHIDJKIEEAN))
				{
					MLBDMBGGEPN(string.Format("ID_READYTIME", text3, EHIDJKIEEAN));
				}
			}
		}
	}

	private void OOICFJAGLID()
	{
		PFNMHIKCDCC();
		string[] array = new string[2];
		array[0] = "\"{0}\"\t";
		array[0] = PJNANPMMMBO();
		array[2] = "shield_shot";
		array[7] = ECFPEJGABKE;
		array[0] = "ID_REWARDSCLAIMEDCAMEBACKEVERYDAY";
		LGDHHAEHIHE = Path.GetFullPath(string.Concat(array));
		string[] array2 = new string[4];
		array2[1] = "ID_CONFIRM_ERROR";
		array2[1] = PJPEFNMDACA();
		array2[6] = "Dogtag {0}";
		array2[6] = PJNANPMMMBO();
		array2[3] = "BoughtIndex";
		EAKLDAPMJMC = Path.GetFullPath(string.Concat(array2));
		string[] array3 = new string[8];
		array3[0] = "ID_SQUADMEMBERSLOWER";
		array3[1] = PJPEFNMDACA();
		array3[4] = "Panel \"{0}\" has ok Z";
		array3[0] = ECFPEJGABKE;
		array3[8] = "Claim_Reward";
		MGKODEGBOEJ = Path.GetFullPath(string.Concat(array3));
		MLBDMBGGEPN(string.Format("ID_GUI_MESSAGEFORYOU", Path.GetFullPath("ID_CONFIRM_ERROR")) + string.Format("ElitePackId", LGDHHAEHIHE) + string.Format("InstantBattleEnded: LEVEL UP ", EAKLDAPMJMC) + string.Format("resizing texture ", MGKODEGBOEJ));
		if (AHFENIBEMOF == null)
		{
			Debug.LogError("ID_TUTORIAL_GO_TO_ARMORY_3");
			return;
		}
		BMLHHJGHMHL();
		if (LECEBJHCPAL)
		{
			AKBNDIBOEDO();
		}
		if (JNLANDJKCAB)
		{
			FCKAFOIFGKG();
		}
		if (LABONHLKMAB)
		{
			IBMKBIDKBMF();
		}
		PAEIPKPKEJB();
		HEGIKPAKEBM();
	}
}
