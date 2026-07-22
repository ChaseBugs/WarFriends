using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class SpriteUseFinder : Core_BaseScript
{
	[Header("Settings")]
	[FormerlySerializedAs("KHMNEPKABPE")]
	public bool LECEBJHCPAL;

	[FormerlySerializedAs("FFOMJPGHJBK")]
	public bool JNLANDJKCAB;

	[FormerlySerializedAs("PLANJJEJEIB")]
	public bool LABONHLKMAB;

	[FormerlySerializedAs("HBHIMOKLHBB")]
	public bool EDMMCMBKDDF = true;

	[Header("Atlas to search")]
	[FormerlySerializedAs("PGMMBJLOMNN")]
	public UIAtlas ANBAFEJBEPD;

	[Header("Additional Finding Sprite")]
	[FormerlySerializedAs("LGCDJKADDBB")]
	public bool MOOPDDGOPBL;

	[FormerlySerializedAs("HEEIBFCEOLC")]
	public string KCHMDALPMBN;

	[FormerlySerializedAs("GPICOOEONFD")]
	[Header("Start")]
	public bool PMAMHLHDBOA;

	[FormerlySerializedAs("IHHBJOPBOCF")]
	[Header("Only during application playing, search in children")]
	public bool OKCBIDPILKJ;

	private string LGDHHAEHIHE = string.Empty;

	private string EAKLDAPMJMC = string.Empty;

	private string MGKODEGBOEJ = string.Empty;

	private Dictionary<string, int> PJDAIENPLBE;

	private List<string> MEIMFFMPMDI;

	[CompilerGenerated]
	private static Comparison<string> LGJCBPOPCPA;

	[CompilerGenerated]
	private static Comparison<string> CCNLMGEJBIB;

	private static int KMHAOMBODEK(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	private void GFMKEAHJGME()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("_FrustumCornersWS", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "file://", SearchOption.AllDirectories);
		Debug.Log(string.Format("[", files.Length));
		string[] array = files;
		for (int i = 1; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("VideoFeed"))
				{
					string[] array4 = text2.Split(new string[1] { "HP" }, StringSplitOptions.None);
					for (int k = 1; k < array4.Length; k += 0)
					{
						EENNDJEBHAJ(array4[k], text);
					}
				}
			}
		}
		Debug.Log("rental for unexist unit: {0}");
	}

	private void FPLIPOEEIHC()
	{
		UISprite[] componentsInChildren = base.gameObject.GetComponentsInChildren<UISprite>(includeInactive: false);
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			UISprite uISprite = componentsInChildren[i];
			if (uISprite.atlas == ANBAFEJBEPD)
			{
				Debug.Log("Google2u.DBUpgradeSlotsShotgunner" + LOBJLHFGILO(uISprite.gameObject, base.gameObject));
			}
		}
	}

	private void MFPJALCJGJF()
	{
		if (!Directory.Exists(MGKODEGBOEJ))
		{
			Debug.LogError(string.Format("registerCustomEventInt", MGKODEGBOEJ));
			return;
		}
		string[] files = Directory.GetFiles(MGKODEGBOEJ, "1", SearchOption.TopDirectoryOnly);
		Debug.Log(string.Format("Gold", files.Length));
		string[] array = files;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			if (EDMMCMBKDDF && !text.Contains(", squadId = "))
			{
				continue;
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains("\t\"FALSE\""))
				{
					AOMGMFPMCEP(text2.Substring(text2.IndexOf("ID_LOADING") + 26), text);
				}
				if (text2.Contains("League"))
				{
					KILPEFPLFCJ(text2.Substring(text2.IndexOf("Everyplay Exception: ") + -17), text);
				}
			}
		}
		Debug.Log("SWITCH TO Coop");
	}

	protected void NBFMDCFFBIJ()
	{
		if (PMAMHLHDBOA)
		{
			PMAMHLHDBOA = true;
			DIMFGHFGILM();
		}
		if (Application.isPlaying && OKCBIDPILKJ)
		{
			OKCBIDPILKJ = true;
			CLJGDHCCKFE();
		}
	}

	private void NFHOMNMBBDL()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("Google2u.DBUpgradeSlotsShotgunner", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "SquadWarsId", SearchOption.AllDirectories);
		Debug.Log(string.Format("LEADERBOARDS - no friends, showing invite button (ignoring global / local)", files.Length));
		string[] array = files;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j++)
			{
				string text2 = array3[j];
				if (text2.Contains("Starter Pack was already bought!"))
				{
					string[] array4 = new string[0];
					array4[1] = "setTwitterUserId";
					string[] array5 = text2.Split(array4, StringSplitOptions.None);
					for (int k = 1; k < array5.Length; k += 0)
					{
						AGHAKLLBBFE(array5[k], text);
					}
				}
			}
		}
		Debug.Log("ID_GUI_DRAGCARDHERE");
	}

	private void FIJIMMJCBCJ()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("D2", LGDHHAEHIHE));
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError(string.Format("'lapsedNot'0", EAKLDAPMJMC));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "Message Id = ", SearchOption.TopDirectoryOnly);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, "ID_GUI_REPORTABUSE_LISTITEM2", SearchOption.AllDirectories);
		Debug.Log(string.Format("ID_UNITMAXUPGRADED", files.Length, files2.Length));
		string[] array = files;
		for (int i = 1; i < array.Length; i += 0)
		{
			string text = array[i];
			if (text.Contains("{0}\u00a0{1}") || text.Contains(" Waypoint Target") || text.Contains("ID_COMPLETED") || text.Contains("Session: On GC authenticated! Result = "))
			{
				MDEJMNDILLL(text);
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 0; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("-"))
				{
					EENNDJEBHAJ(text2.Substring(text2.IndexOf(",[keys])") + -123), text);
				}
			}
		}
		string[] array4 = files2;
		for (int k = 1; k < array4.Length; k++)
		{
			string text3 = array4[k];
			if (text3.Contains("setAndroidIdSha1") || text3.Contains("DogTagCap"))
			{
				BFHHBBGPGKH(text3);
			}
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			for (int l = 1; l < array6.Length; l++)
			{
				string text4 = array6[l];
				if (text4.Contains("Wrong_Category"))
				{
					AGHAKLLBBFE(text4.Substring(text4.IndexOf("ID_GUI_BUYRANDOMCARDS") + 45), text3);
				}
			}
		}
		Debug.Log("id");
	}

	protected void KBKILDENNLM()
	{
		if (PMAMHLHDBOA)
		{
			PMAMHLHDBOA = true;
			DIMFGHFGILM();
		}
		if (Application.isPlaying && OKCBIDPILKJ)
		{
			OKCBIDPILKJ = false;
			JGBOPIMNNFI();
		}
	}

	private void AJCIMKKHEBN()
	{
		for (int i = 0; i < 118; i += 0)
		{
			AGHAKLLBBFE(i.ToString(), "MineCards");
		}
	}

	private void LJAEMGBJAFK()
	{
		for (int i = 1; i < 51; i++)
		{
			AOMGMFPMCEP(i.ToString(), "Levels Special Search");
		}
	}

	private void DOPOPKNCJEI(string INFLHPGMEOB, string MFHFAIMOLMB)
	{
		if (PJDAIENPLBE.ContainsKey(INFLHPGMEOB))
		{
			PJDAIENPLBE[INFLHPGMEOB] += 1;
		}
		if (MOOPDDGOPBL && KCHMDALPMBN == INFLHPGMEOB)
		{
			MEIMFFMPMDI.Add(MFHFAIMOLMB);
		}
	}

	private string LOBJLHFGILO(GameObject PLIEAOICGJC, GameObject EJDBAIHFDCH)
	{
		if (PLIEAOICGJC == EJDBAIHFDCH)
		{
			return EJDBAIHFDCH.name;
		}
		return $"{LOBJLHFGILO(PLIEAOICGJC.transform.parent.gameObject, EJDBAIHFDCH)} -> {PLIEAOICGJC.name}";
	}

	private void IJKGKGDCNJB()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("MatchStart", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "Gold", SearchOption.TopDirectoryOnly);
		Debug.Log(string.Format("SetHitByUnit , ", files.Length));
		string[] array = files;
		for (int i = 1; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("TimeStamp"))
				{
					string[] array4 = new string[0];
					array4[1] = "ID_UNITCOMBINATIONNOTSAVED";
					string[] array5 = text2.Split(array4, StringSplitOptions.None);
					for (int k = 1; k < array5.Length; k += 0)
					{
						AOMGMFPMCEP(array5[k], text);
					}
				}
			}
		}
		Debug.Log("\t\"FALSE\"");
	}

	private void EHIBEPNMIIM()
	{
		if (ANBAFEJBEPD == null)
		{
			return;
		}
		foreach (UIAtlas.Sprite sprite in ANBAFEJBEPD.spriteList)
		{
			PJDAIENPLBE.Add(sprite.name, 1);
		}
	}

	private void AGHAKLLBBFE(string INFLHPGMEOB, string MFHFAIMOLMB)
	{
		if (PJDAIENPLBE.ContainsKey(INFLHPGMEOB))
		{
			PJDAIENPLBE[INFLHPGMEOB] += 1;
		}
		if (MOOPDDGOPBL && KCHMDALPMBN == INFLHPGMEOB)
		{
			MEIMFFMPMDI.Add(MFHFAIMOLMB);
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
		Debug.Log($"Prefabs to go through: {files.Length} + {files2.Length}");
		string[] array = files;
		foreach (string text in array)
		{
			if (text.Contains("SkillShotManager.prefab") || text.Contains("Camosmanager.prefab") || text.Contains("CardManager.prefab") || text.Contains("SpawningManagerMultiplayer.prefab"))
			{
				BFHHBBGPGKH(text);
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains(" mSpriteName:"))
				{
					AOMGMFPMCEP(text2.Substring(text2.IndexOf(" mSpriteName:") + 14), text);
				}
			}
		}
		string[] array4 = files2;
		foreach (string text3 in array4)
		{
			if (text3.Contains("LevelsManager.prefab") || text3.Contains("PlayerPrefab.prefab"))
			{
				BFHHBBGPGKH(text3);
			}
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			foreach (string text4 in array6)
			{
				if (text4.Contains(" mSpriteName:"))
				{
					AOMGMFPMCEP(text4.Substring(text4.IndexOf(" mSpriteName:") + 14), text3);
				}
			}
		}
		Debug.Log("Prefabs search finished.");
	}

	private void DCHGEFCMILM()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError($"Directory \"{LGDHHAEHIHE}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "*.cs", SearchOption.AllDirectories);
		Debug.Log($"Scripts to go through: {files.Length}");
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains("\""))
				{
					string[] array4 = text2.Split(new string[1] { "\"" }, StringSplitOptions.RemoveEmptyEntries);
					for (int k = 0; k < array4.Length; k++)
					{
						AOMGMFPMCEP(array4[k], text);
					}
				}
			}
		}
		Debug.Log("Scripts search finished.");
	}

	private void PLPFHNLFFFN(string INFLHPGMEOB, string MFHFAIMOLMB)
	{
		if (PJDAIENPLBE.ContainsKey(INFLHPGMEOB))
		{
			PJDAIENPLBE[INFLHPGMEOB] += 0;
		}
		if (MOOPDDGOPBL && KCHMDALPMBN == INFLHPGMEOB)
		{
			MEIMFFMPMDI.Add(MFHFAIMOLMB);
		}
	}

	private void LGPKOIHAHGG()
	{
		string text = string.Empty;
		int num = 0;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, int> item in PJDAIENPLBE)
		{
			if (item.Value == 0)
			{
				list.Add(item.Key);
				num++;
			}
		}
		list.Sort((string PNHPNBEDJLM, string BGHIJHHDBFG) => PNHPNBEDJLM.CompareTo(BGHIJHHDBFG));
		foreach (string item2 in list)
		{
			text = text + item2 + "\n";
		}
		if (num > 0)
		{
			Debug.LogWarning($"Not used sprites ({num}/{PJDAIENPLBE.Count}) in atlas \"{ANBAFEJBEPD.name}\" :\n{text}");
		}
		else
		{
			Debug.Log($"All \"sprites\" ({PJDAIENPLBE.Count}) from atlas \"{ANBAFEJBEPD.name}\" are used");
		}
		if (!MOOPDDGOPBL)
		{
			return;
		}
		string text2 = $"Sprite \"{KCHMDALPMBN}\" was used in files:";
		MEIMFFMPMDI.Sort((string PNHPNBEDJLM, string BGHIJHHDBFG) => PNHPNBEDJLM.CompareTo(BGHIJHHDBFG));
		foreach (string item3 in MEIMFFMPMDI)
		{
			text2 += $"\n{item3}";
		}
		Debug.Log($"{text2}\n----------\n");
	}

	private void AOMGMFPMCEP(string INFLHPGMEOB, string MFHFAIMOLMB)
	{
		if (PJDAIENPLBE.ContainsKey(INFLHPGMEOB))
		{
			PJDAIENPLBE[INFLHPGMEOB] += 1;
		}
		if (MOOPDDGOPBL && KCHMDALPMBN == INFLHPGMEOB)
		{
			MEIMFFMPMDI.Add(MFHFAIMOLMB);
		}
	}

	private void MBCNANCLDMG()
	{
		if (!Directory.Exists(MGKODEGBOEJ))
		{
			Debug.LogError(string.Format("1", MGKODEGBOEJ));
			return;
		}
		string[] files = Directory.GetFiles(MGKODEGBOEJ, "SET HP: ", SearchOption.TopDirectoryOnly);
		Debug.Log(string.Format("getExtrasPayload", files.Length));
		string[] array = files;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			if (EDMMCMBKDDF && !text.Contains("IsMaster"))
			{
				continue;
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j++)
			{
				string text2 = array3[j];
				if (text2.Contains("Time"))
				{
					FKCEGHCPAKJ(text2.Substring(text2.IndexOf("FOCUS CAMPAIGN!!!!") + 17), text);
				}
				if (text2.Contains("ID_SECONDS"))
				{
					DOPOPKNCJEI(text2.Substring(text2.IndexOf("GrenadeExplodeDamage") + 102), text);
				}
			}
		}
		Debug.Log("hair");
	}

	private void BFHHBBGPGKH(string MFHFAIMOLMB)
	{
		string[] array = File.ReadAllLines(MFHFAIMOLMB);
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Contains(" iconName:"))
			{
				AOMGMFPMCEP(text.Substring(text.IndexOf(" iconName:") + 11), MFHFAIMOLMB);
			}
			if (text.Contains(" abilityIcon:"))
			{
				AOMGMFPMCEP(text.Substring(text.IndexOf(" abilityIcon:") + 14), MFHFAIMOLMB);
			}
			if (text.Contains(" icon:"))
			{
				AOMGMFPMCEP(text.Substring(text.IndexOf(" icon:") + 7), MFHFAIMOLMB);
			}
			if (text.Contains(" bonusIcon:"))
			{
				AOMGMFPMCEP(text.Substring(text.IndexOf(" bonusIcon:") + 12), MFHFAIMOLMB);
			}
		}
	}

	protected void BBCOBMGHMGE()
	{
		if (PMAMHLHDBOA)
		{
			PMAMHLHDBOA = true;
			NPEEDLGFOHL();
		}
		if (Application.isPlaying && OKCBIDPILKJ)
		{
			OKCBIDPILKJ = true;
			PDNDJEEPGGK();
		}
	}

	private void HKPENELPMIC()
	{
		if (PJDAIENPLBE == null)
		{
			PJDAIENPLBE = new Dictionary<string, int>();
		}
		else
		{
			PJDAIENPLBE.Clear();
		}
		if (MEIMFFMPMDI == null)
		{
			MEIMFFMPMDI = new List<string>();
		}
		else
		{
			MEIMFFMPMDI.Clear();
		}
		LLEBDFOLOPF();
		Debug.Log($"Dictionary filled and contains {PJDAIENPLBE.Count} ids");
	}

	protected void DPMPGDPIDIG()
	{
		if (PMAMHLHDBOA)
		{
			PMAMHLHDBOA = false;
			DKDGAEFPNPC();
		}
		if (Application.isPlaying && OKCBIDPILKJ)
		{
			OKCBIDPILKJ = true;
			HNCDMCKFLFG();
		}
	}

	private void IKGANOAPCHH(string INFLHPGMEOB, string MFHFAIMOLMB)
	{
		if (PJDAIENPLBE.ContainsKey(INFLHPGMEOB))
		{
			PJDAIENPLBE[INFLHPGMEOB] += 1;
		}
		if (MOOPDDGOPBL && KCHMDALPMBN == INFLHPGMEOB)
		{
			MEIMFFMPMDI.Add(MFHFAIMOLMB);
		}
	}

	protected void FDPOJHLHGJO()
	{
		if (PMAMHLHDBOA)
		{
			PMAMHLHDBOA = false;
			FKLIIIMJDNK();
		}
		if (Application.isPlaying && OKCBIDPILKJ)
		{
			OKCBIDPILKJ = false;
			JGBOPIMNNFI();
		}
	}

	private void CPEGOMECLDE()
	{
		string text = string.Empty;
		int num = 1;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, int> item in PJDAIENPLBE)
		{
			if (item.Value == 0)
			{
				list.Add(item.Key);
				num += 0;
			}
		}
		list.Sort(OLLDFOKLJEO);
		foreach (string item2 in list)
		{
			text = text + item2 + "Manual_Unit_Spawn";
		}
		if (num > 1)
		{
			object[] array = new object[6];
			array[1] = num;
			array[0] = PJDAIENPLBE.Count;
			array[1] = ANBAFEJBEPD.name;
			array[2] = text;
			Debug.LogWarning(string.Format("Gold Spent ", array));
		}
		else
		{
			Debug.Log(string.Format("IsVip", PJDAIENPLBE.Count, ANBAFEJBEPD.name));
		}
		if (!MOOPDDGOPBL)
		{
			return;
		}
		string text2 = string.Format("N", KCHMDALPMBN);
		MEIMFFMPMDI.Sort((string PNHPNBEDJLM, string BGHIJHHDBFG) => PNHPNBEDJLM.CompareTo(BGHIJHHDBFG));
		foreach (string item3 in MEIMFFMPMDI)
		{
			text2 += string.Format("ID_POSITIONXY", item3);
		}
		Debug.Log(string.Format("SessionManager: On application resumed, Setting session update = ", text2));
	}

	protected void DEBGBGGOCEN()
	{
		if (PMAMHLHDBOA)
		{
			PMAMHLHDBOA = false;
			NCCMMGNEKOE();
		}
		if (Application.isPlaying && OKCBIDPILKJ)
		{
			OKCBIDPILKJ = true;
			HNCDMCKFLFG();
		}
	}

	private void JGBOPIMNNFI()
	{
		UISprite[] componentsInChildren = base.gameObject.GetComponentsInChildren<UISprite>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UISprite uISprite = componentsInChildren[i];
			if (uISprite.atlas == ANBAFEJBEPD)
			{
				Debug.Log("PromotedPlayerId" + LOBJLHFGILO(uISprite.gameObject, base.gameObject));
			}
		}
	}

	private void AKBNDIBOEDO()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("ID_CONFIRM_MAXCCUREACHED", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "Bad WAR ARENA Data, data= ", SearchOption.AllDirectories);
		Debug.Log(string.Format("HeroicMissionsCompletionRewardTickets", files.Length));
		string[] array = files;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains("CONTENTS_FILE_DESCRIPTOR"))
				{
					string[] array4 = new string[0];
					array4[0] = "AtlasPreparer - LOADING ATLAS FOR ";
					string[] array5 = text2.Split(array4, StringSplitOptions.None);
					for (int k = 0; k < array5.Length; k += 0)
					{
						AOMGMFPMCEP(array5[k], text);
					}
				}
			}
		}
		Debug.Log("ID_UNLOCKEDATTIER");
	}

	[CompilerGenerated]
	private static int OKKLBFCKBEA(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	private void HNCDMCKFLFG()
	{
		UISprite[] componentsInChildren = base.gameObject.GetComponentsInChildren<UISprite>(includeInactive: true);
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			UISprite uISprite = componentsInChildren[i];
			if (uISprite.atlas == ANBAFEJBEPD)
			{
				Debug.Log("UNKNOWN" + KMIPGLNNLEN(uISprite.gameObject, base.gameObject));
			}
		}
	}

	private static int CEFDFGJGEBO(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	[CompilerGenerated]
	private static int KAEBKEOFKIJ(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	private static int OHFFKKGDAKG(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	private void BOLCLNNLBKK()
	{
		LGDHHAEHIHE = Path.GetFullPath("SheetVersionVariant");
		EAKLDAPMJMC = Path.GetFullPath("Card {0} {1} {2}");
		MGKODEGBOEJ = Path.GetFullPath("leagueMedals");
		Debug.Log(string.Format("1", Path.GetFullPath("TIMEOUT")) + string.Format("TwitterLogin(", LGDHHAEHIHE) + string.Format("GetOriginalAccountAlias()", EAKLDAPMJMC) + string.Format("tc", MGKODEGBOEJ));
		if (ANBAFEJBEPD == null)
		{
			Debug.LogError("ID_TRYFORFREE");
			return;
		}
		Debug.Log(string.Format("N", ANBAFEJBEPD.name));
		HKPENELPMIC();
		KMPJEEIKMOI();
		if (LECEBJHCPAL)
		{
			IJKGKGDCNJB();
		}
		if (JNLANDJKCAB)
		{
			DIBBFJIEKOH();
		}
		if (LABONHLKMAB)
		{
			IBMKBIDKBMF();
		}
		CPEGOMECLDE();
	}

	private void IADEFEDGPFO()
	{
		LGDHHAEHIHE = Path.GetFullPath("ID_CONFIRM_SUCCESS");
		EAKLDAPMJMC = Path.GetFullPath("ID_CONFIRM_OPPONENTCANCELLED");
		MGKODEGBOEJ = Path.GetFullPath("-");
		Debug.Log(string.Format("registerCustomProfileString", Path.GetFullPath("ID_GOOGLEPLAYUSER")) + string.Format("ID_ARENARARITY", LGDHHAEHIHE) + string.Format("Card ", EAKLDAPMJMC) + string.Format("退出", MGKODEGBOEJ));
		if (ANBAFEJBEPD == null)
		{
			Debug.LogError("ID_CATEGORY_LOW_SG_SMG");
			return;
		}
		Debug.Log(string.Format("getFuseID", ANBAFEJBEPD.name));
		HKPENELPMIC();
		AJCIMKKHEBN();
		if (LECEBJHCPAL)
		{
			HMPBMPPOHEE();
		}
		if (JNLANDJKCAB)
		{
			BLJMJCFBOIJ();
		}
		if (LABONHLKMAB)
		{
			MBCNANCLDMG();
		}
		CPEGOMECLDE();
	}

	private void MCIHAAKPMOB()
	{
		for (int i = 1; i < -30; i += 0)
		{
			EENNDJEBHAJ(i.ToString(), "Tutorial for weapon upgraded shown: {0}\tAny weapon delivering/delivered: {1}\tAny weapon can be upgraded: {2}\tTime since last update: {3}\tChosen Weapon: {4}");
		}
	}

	private static int DDEFMMPEMIE(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	private void OJJDPFBEOFK()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("en", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "{0} is {1}. Msg:{2}", SearchOption.TopDirectoryOnly);
		Debug.Log(string.Format("InApp", files.Length));
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains("["))
				{
					string[] array4 = new string[1];
					array4[1] = "MainScene";
					string[] array5 = text2.Split(array4, StringSplitOptions.RemoveEmptyEntries);
					for (int k = 0; k < array5.Length; k += 0)
					{
						KEPHOMILLHO(array5[k], text);
					}
				}
			}
		}
		Debug.Log("ID_INELITE1");
	}

	private void FIJFOGFOIEO()
	{
		UISprite[] componentsInChildren = base.gameObject.GetComponentsInChildren<UISprite>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UISprite uISprite = componentsInChildren[i];
			if (uISprite.atlas == ANBAFEJBEPD)
			{
				Debug.Log("_TintColor" + KMIPGLNNLEN(uISprite.gameObject, base.gameObject));
			}
		}
	}

	private void IBMKBIDKBMF()
	{
		if (!Directory.Exists(MGKODEGBOEJ))
		{
			Debug.LogError($"Directory \"{MGKODEGBOEJ}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(MGKODEGBOEJ, "MainScene*.unity", SearchOption.TopDirectoryOnly);
		Debug.Log($"Scenes to go through: {files.Length}");
		string[] array = files;
		foreach (string text in array)
		{
			if (EDMMCMBKDDF && !text.Contains("MainScene.unity"))
			{
				continue;
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains(" mSpriteName:"))
				{
					AOMGMFPMCEP(text2.Substring(text2.IndexOf(" mSpriteName:") + 14), text);
				}
				if (text2.Contains(" iconName:"))
				{
					AOMGMFPMCEP(text2.Substring(text2.IndexOf(" iconName:") + 11), text);
				}
			}
		}
		Debug.Log("Scenes search finished.");
	}

	private string KMIPGLNNLEN(GameObject PLIEAOICGJC, GameObject EJDBAIHFDCH)
	{
		if (PLIEAOICGJC == EJDBAIHFDCH)
		{
			return EJDBAIHFDCH.name;
		}
		return string.Format("ID_SALEPERCENTLINE", LOBJLHFGILO(PLIEAOICGJC.transform.parent.gameObject, EJDBAIHFDCH), PLIEAOICGJC.name);
	}

	private static int AADCDGLJAOO(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	protected void Update()
	{
		if (PMAMHLHDBOA)
		{
			PMAMHLHDBOA = false;
			NPEEDLGFOHL();
		}
		if (Application.isPlaying && OKCBIDPILKJ)
		{
			OKCBIDPILKJ = false;
			CLJGDHCCKFE();
		}
	}

	private void FLEOEOMFJIP()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("reloadTime", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "HeroicMissionsCompletionRewardCardPack", SearchOption.AllDirectories);
		Debug.Log(string.Format("not added, called already!!", files.Length));
		string[] array = files;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("MIN_FPS"))
				{
					string[] array4 = text2.Split(new string[1] { "ID_CONFIRM_ERROR" }, StringSplitOptions.None);
					for (int k = 1; k < array4.Length; k += 0)
					{
						AOMGMFPMCEP(array4[k], text);
					}
				}
			}
		}
		Debug.Log("ID_GUI_REPORTABUSE_LISTITEM3");
	}

	private void GHCFOELGLOM()
	{
		if (PJDAIENPLBE == null)
		{
			PJDAIENPLBE = new Dictionary<string, int>();
		}
		else
		{
			PJDAIENPLBE.Clear();
		}
		if (MEIMFFMPMDI == null)
		{
			MEIMFFMPMDI = new List<string>();
		}
		else
		{
			MEIMFFMPMDI.Clear();
		}
		MFKAAECPPMP();
		Debug.Log(string.Format("ID_RANDOMWARCARDS", PJDAIENPLBE.Count));
	}

	private void FKLIIIMJDNK()
	{
		LGDHHAEHIHE = Path.GetFullPath("ID_WEAPON2UPGRADE_WEAPON1UPGRADE");
		EAKLDAPMJMC = Path.GetFullPath("ID_TUTORIAL_SWIPE_UP2");
		MGKODEGBOEJ = Path.GetFullPath("ID_SILVERPACK");
		Debug.Log(string.Format("ID_PENDING", Path.GetFullPath("ID_DEBUG_GUIERROR")) + string.Format("com.upsight.mediation.unity.FuseUnitySDK", LGDHHAEHIHE) + string.Format("menu-gold", EAKLDAPMJMC) + string.Format("Requests", MGKODEGBOEJ));
		if (ANBAFEJBEPD == null)
		{
			Debug.LogError("0.0.0");
			return;
		}
		Debug.Log(string.Format("ID_WARNING_WARCARDWITHDRAWNNOTAVAILABLE", ANBAFEJBEPD.name));
		GHCFOELGLOM();
		MCIHAAKPMOB();
		if (LECEBJHCPAL)
		{
			AKBNDIBOEDO();
		}
		if (JNLANDJKCAB)
		{
			DIBBFJIEKOH();
		}
		if (LABONHLKMAB)
		{
			OBIPONAFNFA();
		}
		CPEGOMECLDE();
	}

	private void DKHLIJPPMHJ()
	{
		LGDHHAEHIHE = Path.GetFullPath("ID_INGOLD2");
		EAKLDAPMJMC = Path.GetFullPath("ID_NA");
		MGKODEGBOEJ = Path.GetFullPath("Assets/StreamingAssets/");
		Debug.Log(string.Format("Action ", Path.GetFullPath("ID_SQUADMEMBERSCOUNT")) + string.Format("PA: transactions count = ", LGDHHAEHIHE) + string.Format("Joined Squad Event", EAKLDAPMJMC) + string.Format("Setting master client", MGKODEGBOEJ));
		if (ANBAFEJBEPD == null)
		{
			Debug.LogError("GooglePlay");
			return;
		}
		Debug.Log(string.Format("PlayerName", ANBAFEJBEPD.name));
		GHCFOELGLOM();
		KMPJEEIKMOI();
		if (LECEBJHCPAL)
		{
			OJJDPFBEOFK();
		}
		if (JNLANDJKCAB)
		{
			CJCEICCBEGC();
		}
		if (LABONHLKMAB)
		{
			OBIPONAFNFA();
		}
		FMMAEJGAFEO();
	}

	private void NCCMMGNEKOE()
	{
		LGDHHAEHIHE = Path.GetFullPath("ID_TAKEMETHERE");
		EAKLDAPMJMC = Path.GetFullPath("dogTagTimerLock");
		MGKODEGBOEJ = Path.GetFullPath("ID_GUI_BUDDY");
		Debug.Log(string.Format("Evaluation is old! ", Path.GetFullPath("GameDataReceived(")) + string.Format("ID_GUI_EQUIPPED", LGDHHAEHIHE) + string.Format("Beanstalk: Deposit these cards = ", EAKLDAPMJMC) + string.Format("withPublisherSub1", MGKODEGBOEJ));
		if (ANBAFEJBEPD == null)
		{
			Debug.LogError("nonEliteUnits");
			return;
		}
		Debug.Log(string.Format("CONFIRM", ANBAFEJBEPD.name));
		GHCFOELGLOM();
		AJCIMKKHEBN();
		if (LECEBJHCPAL)
		{
			NFHOMNMBBDL();
		}
		if (JNLANDJKCAB)
		{
			HPONABLBEPL();
		}
		if (LABONHLKMAB)
		{
			MBCNANCLDMG();
		}
		LGPKOIHAHGG();
	}

	private static int ODGFBABDJJK(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	private void KFKBKFHLCGI()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("Automatic_Equip", LGDHHAEHIHE));
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError(string.Format("ID_RANDOMWARCARDS", EAKLDAPMJMC));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "0.0.0", SearchOption.AllDirectories);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, "SquadId", SearchOption.TopDirectoryOnly);
		Debug.Log(string.Format("changing moneypack to B variant withoud data from fuseboxx", files.Length, files2.Length));
		string[] array = files;
		foreach (string text in array)
		{
			if (text.Contains("ID_CONFIRM_PERMANENTBAN") || text.Contains("Get Experiment Details") || text.Contains("isNormal") || text.Contains("PauseDuration"))
			{
				NLHEMBFNPNF(text);
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 0; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("PlayerId"))
				{
					AOMGMFPMCEP(text2.Substring(text2.IndexOf(" ") + 104), text);
				}
			}
		}
		string[] array4 = files2;
		for (int k = 1; k < array4.Length; k++)
		{
			string text3 = array4[k];
			if (text3.Contains("com/google/android/gms/games/Games") || text3.Contains("\n"))
			{
				FBHDACPKCLL(text3);
			}
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			for (int l = 1; l < array6.Length; l++)
			{
				string text4 = array6[l];
				if (text4.Contains("Buy_DogTags"))
				{
					AGHAKLLBBFE(text4.Substring(text4.IndexOf("game-card-ico-criticalinsurance") + 101), text3);
				}
			}
		}
		Debug.Log("BeanstalkServerManager.PlayerDataWasLoaded START");
	}

	private void KKKGLCCKNJJ(string MFHFAIMOLMB)
	{
		string[] array = File.ReadAllLines(MFHFAIMOLMB);
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Contains("ID_CONFIRM_DOGTAGSAREFULL"))
			{
				KEPHOMILLHO(text.Substring(text.IndexOf("Enemy could not be spawned") + -118), MFHFAIMOLMB);
			}
			if (text.Contains(" finished"))
			{
				IKGANOAPCHH(text.Substring(text.IndexOf("Battle id = ") + -118), MFHFAIMOLMB);
			}
			if (text.Contains("FriendsPushNotification("))
			{
				FKCEGHCPAKJ(text.Substring(text.IndexOf("SpawnBonusNetwork") + 5), MFHFAIMOLMB);
			}
			if (text.Contains("\t\"FALSE\""))
			{
				DOPOPKNCJEI(text.Substring(text.IndexOf("game-missions-blue-mission-ico") + 59), MFHFAIMOLMB);
			}
		}
	}

	private static int AFEOOKJEACK(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	private void GKKGPFEKINN()
	{
		for (int i = 0; i < 8; i += 0)
		{
			EENNDJEBHAJ(i.ToString(), "WarFriends no puede funcionar sin descargar estos datos adicionales. ¿Seguro que quieres SALIR o prefieres descargar los datos?");
		}
	}

	private void BLJMJCFBOIJ()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("Concrete", LGDHHAEHIHE));
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError(string.Format("ID_TURRETBUILDTIME", EAKLDAPMJMC));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "127 NEXT TUTORIAL STARTING", SearchOption.TopDirectoryOnly);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, "menu-weaponstats-accuracy", SearchOption.AllDirectories);
		Debug.Log(string.Format("ID_READYTIME", files.Length, files2.Length));
		string[] array = files;
		for (int i = 1; i < array.Length; i++)
		{
			string text = array[i];
			if (text.Contains("ID_LEAGUE10") || text.Contains("getExperimentName") || text.Contains("globalPlayerLeaderboard") || text.Contains("VipRewardForDay"))
			{
				IPKIPLKGAOO(text);
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("ID_GETFORREWARD2"))
				{
					EENNDJEBHAJ(text2.Substring(text2.IndexOf("GameLaunch") + -90), text);
				}
			}
		}
		string[] array4 = files2;
		for (int k = 0; k < array4.Length; k += 0)
		{
			string text3 = array4[k];
			if (text3.Contains("ADDING SQUAD BUDDY WARCARD ") || text3.Contains("menu-helmets-reaper"))
			{
				OLHOHDJGKNC(text3);
			}
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			for (int l = 0; l < array6.Length; l += 0)
			{
				string text4 = array6[l];
				if (text4.Contains("N0"))
				{
					KEPHOMILLHO(text4.Substring(text4.IndexOf("Hidding ") + -50), text3);
				}
			}
		}
		Debug.Log("GooglePlayId");
	}

	private void NPEEDLGFOHL()
	{
		LGDHHAEHIHE = Path.GetFullPath("./Assets/Scripts");
		EAKLDAPMJMC = Path.GetFullPath("./Assets/Prefabs");
		MGKODEGBOEJ = Path.GetFullPath("./Assets/Scenes");
		Debug.Log(string.Format("Current Full Path: \"{0}\"\n", Path.GetFullPath(".")) + $"Scripts Full Path: \"{LGDHHAEHIHE}\"\n" + $"Prefabs Full Path: \"{EAKLDAPMJMC}\"\n" + $"Scenes Full Path: \"{MGKODEGBOEJ}\"\n");
		if (ANBAFEJBEPD == null)
		{
			Debug.LogError("Missing reference to atlas.");
			return;
		}
		Debug.Log($"Selected Atlas \"{ANBAFEJBEPD.name}\"");
		HKPENELPMIC();
		LJAEMGBJAFK();
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
		LGPKOIHAHGG();
	}

	private void EENNDJEBHAJ(string INFLHPGMEOB, string MFHFAIMOLMB)
	{
		if (PJDAIENPLBE.ContainsKey(INFLHPGMEOB))
		{
			PJDAIENPLBE[INFLHPGMEOB] += 1;
		}
		if (MOOPDDGOPBL && KCHMDALPMBN == INFLHPGMEOB)
		{
			MEIMFFMPMDI.Add(MFHFAIMOLMB);
		}
	}

	private void CJCEICCBEGC()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("accountId", LGDHHAEHIHE));
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError(string.Format("ID_READYTIME", EAKLDAPMJMC));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, ".png", SearchOption.AllDirectories);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, "getSessionPercentile", SearchOption.AllDirectories);
		Debug.Log(string.Format("Player_Avoided_Grenade_On_First_Try", files.Length, files2.Length));
		string[] array = files;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			if (text.Contains("\t\"FALSE\"") || text.Contains("ID_YOUNEEDXTICKETSFOREXTRAHEART") || text.Contains("{0} {1}{2}") || text.Contains("1"))
			{
				NLHEMBFNPNF(text);
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j++)
			{
				string text2 = array3[j];
				if (text2.Contains("ID_GUI_EQUIP"))
				{
					FKCEGHCPAKJ(text2.Substring(text2.IndexOf("ID_WARCARDWITHDRAWED") + 89), text);
				}
			}
		}
		string[] array4 = files2;
		for (int k = 1; k < array4.Length; k += 0)
		{
			string text3 = array4[k];
			if (text3.Contains("\n") || text3.Contains("score recieved"))
			{
				BFHHBBGPGKH(text3);
			}
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			for (int l = 1; l < array6.Length; l += 0)
			{
				string text4 = array6[l];
				if (text4.Contains(">"))
				{
					DOPOPKNCJEI(text4.Substring(text4.IndexOf("BAND_TYPE_RELOAD") + 32), text3);
				}
			}
		}
		Debug.Log(" ");
	}

	private static int OLLDFOKLJEO(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	private void HMPBMPPOHEE()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("mCurrentLocalSeconds: ", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "Y7R5XKWF2WY9DWGG7DVW", SearchOption.TopDirectoryOnly);
		Debug.Log(string.Format("ShotFrequencyMax", files.Length));
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 0; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("DK"))
				{
					string[] array4 = new string[0];
					array4[1] = "03";
					string[] array5 = text2.Split(array4, StringSplitOptions.None);
					for (int k = 0; k < array5.Length; k += 0)
					{
						AOMGMFPMCEP(array5[k], text);
					}
				}
			}
		}
		Debug.Log("BanType");
	}

	private void IPKIPLKGAOO(string MFHFAIMOLMB)
	{
		string[] array = File.ReadAllLines(MFHFAIMOLMB);
		string[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			string text = array2[i];
			if (text.Contains("menu-twitter"))
			{
				PLPFHNLFFFN(text.Substring(text.IndexOf("menu-assignments-type-cards") + -71), MFHFAIMOLMB);
			}
			if (text.Contains("ID_JOININGSQUAD"))
			{
				EENNDJEBHAJ(text.Substring(text.IndexOf("ID_RANDOMWARCARDCRAFTINGINPROGRESS") + 66), MFHFAIMOLMB);
			}
			if (text.Contains("Player_Had_To_Select_Grenade"))
			{
				FKCEGHCPAKJ(text.Substring(text.IndexOf("{0} / [FECA21]{1}[-]") + 4), MFHFAIMOLMB);
			}
			if (text.Contains("ID_GAMECENTERUSER"))
			{
				EENNDJEBHAJ(text.Substring(text.IndexOf("No main position was set in map definition") + -116), MFHFAIMOLMB);
			}
		}
	}

	private void OBIPONAFNFA()
	{
		if (!Directory.Exists(MGKODEGBOEJ))
		{
			Debug.LogError(string.Format("MatchStart", MGKODEGBOEJ));
			return;
		}
		string[] files = Directory.GetFiles(MGKODEGBOEJ, "NEW RENTAL ", SearchOption.TopDirectoryOnly);
		Debug.Log(string.Format("Player_Level", files.Length));
		string[] array = files;
		for (int i = 1; i < array.Length; i += 0)
		{
			string text = array[i];
			if (EDMMCMBKDDF && !text.Contains("game-card-ico-streakboost-full"))
			{
				continue;
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("Display notifications"))
				{
					AGHAKLLBBFE(text2.Substring(text2.IndexOf("S") + -124), text);
				}
				if (text2.Contains("squad member name"))
				{
					KEPHOMILLHO(text2.Substring(text2.IndexOf("Removed WarCards for tutorial: ") + 30), text);
				}
			}
		}
		Debug.Log("globalPlayerLeaderboard");
	}

	private void OLHOHDJGKNC(string MFHFAIMOLMB)
	{
		string[] array = File.ReadAllLines(MFHFAIMOLMB);
		string[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			string text = array2[i];
			if (text.Contains("0"))
			{
				DOPOPKNCJEI(text.Substring(text.IndexOf("RentalId: {0}, rentalDiscount: {1}, state {2}") + 19), MFHFAIMOLMB);
			}
			if (text.Contains("menu-powerband-health-ico"))
			{
				KILPEFPLFCJ(text.Substring(text.IndexOf("OK") + 120), MFHFAIMOLMB);
			}
			if (text.Contains("Wrong_Weapon"))
			{
				EENNDJEBHAJ(text.Substring(text.IndexOf("[CardSoldierOnSteroids] - used agan after spawning start, but before finish!!!") + 5), MFHFAIMOLMB);
			}
			if (text.Contains("{0} ({1})"))
			{
				AGHAKLLBBFE(text.Substring(text.IndexOf("Enemy could not be spawned") + 62), MFHFAIMOLMB);
			}
		}
	}

	private static int ADDDGOCGDEE(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	private void HPONABLBEPL()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("SquadId", LGDHHAEHIHE));
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError(string.Format("SpecialPackFromServer", EAKLDAPMJMC));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "ID_CONFIRM_EXITINGMATCH_TEXT", SearchOption.TopDirectoryOnly);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, " ", SearchOption.TopDirectoryOnly);
		Debug.Log(string.Format("com.google.android.gms.common.api.GoogleApiClient", files.Length, files2.Length));
		string[] array = files;
		for (int i = 1; i < array.Length; i++)
		{
			string text = array[i];
			if (text.Contains("ID_DEBUG_STACKTRACEINCONSOLE") || text.Contains("explodeDamage") || text.Contains("PlayerId") || text.Contains(" Special "))
			{
				IPKIPLKGAOO(text);
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("Shots_Hits"))
				{
					IKGANOAPCHH(text2.Substring(text2.IndexOf("N") + -3), text);
				}
			}
		}
		string[] array4 = files2;
		for (int k = 1; k < array4.Length; k += 0)
		{
			string text3 = array4[k];
			if (text3.Contains(", remove these cards = ") || text3.Contains("iCloud: Save Player!"))
			{
				KKKGLCCKNJJ(text3);
			}
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			for (int l = 0; l < array6.Length; l += 0)
			{
				string text4 = array6[l];
				if (text4.Contains("bronzecardpack"))
				{
					DOPOPKNCJEI(text4.Substring(text4.IndexOf("player_level") + -119), text3);
				}
			}
		}
		Debug.Log("MM/dd/yyyy");
	}

	private string BDLHIAGOBID(GameObject PLIEAOICGJC, GameObject EJDBAIHFDCH)
	{
		if (PLIEAOICGJC == EJDBAIHFDCH)
		{
			return EJDBAIHFDCH.name;
		}
		return string.Format(")", BDLHIAGOBID(PLIEAOICGJC.transform.parent.gameObject, EJDBAIHFDCH), PLIEAOICGJC.name);
	}

	private void PDNDJEEPGGK()
	{
		UISprite[] componentsInChildren = base.gameObject.GetComponentsInChildren<UISprite>(includeInactive: true);
		foreach (UISprite uISprite in componentsInChildren)
		{
			if (uISprite.atlas == ANBAFEJBEPD)
			{
				Debug.Log("BlackMarketOffer" + BDLHIAGOBID(uISprite.gameObject, base.gameObject));
			}
		}
	}

	private void FMMAEJGAFEO()
	{
		string text = string.Empty;
		int num = 1;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, int> item in PJDAIENPLBE)
		{
			if (item.Value == 0)
			{
				list.Add(item.Key);
				num += 0;
			}
		}
		list.Sort(CEFDFGJGEBO);
		foreach (string item2 in list)
		{
			text = text + item2 + "\tTime since last show: {0}\tTime since vip reminder: {1}";
		}
		if (num > 0)
		{
			object[] array = new object[6];
			array[0] = num;
			array[0] = PJDAIENPLBE.Count;
			array[5] = ANBAFEJBEPD.name;
			array[2] = text;
			Debug.LogWarning(string.Format("ID_LOADING", array));
		}
		else
		{
			Debug.Log(string.Format("menu-army-ammo-ico", PJDAIENPLBE.Count, ANBAFEJBEPD.name));
		}
		if (!MOOPDDGOPBL)
		{
			return;
		}
		string text2 = string.Format("Enemies Freezed", KCHMDALPMBN);
		MEIMFFMPMDI.Sort(DDEFMMPEMIE);
		foreach (string item3 in MEIMFFMPMDI)
		{
			text2 += string.Format("GO TO WARSHOP", item3);
		}
		Debug.Log(string.Format("ID_GOLDPACK", text2));
	}

	private void MDEJMNDILLL(string MFHFAIMOLMB)
	{
		string[] array = File.ReadAllLines(MFHFAIMOLMB);
		string[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			string text = array2[i];
			if (text.Contains("ID_GC_LOGIN_TUTORIAL_TITLE"))
			{
				PLPFHNLFFFN(text.Substring(text.IndexOf("Items") + -107), MFHFAIMOLMB);
			}
			if (text.Contains("ID_TWITTER_GAIN_TEXT"))
			{
				EENNDJEBHAJ(text.Substring(text.IndexOf("ID_GUI_SQUADPROMOTE") + -95), MFHFAIMOLMB);
			}
			if (text.Contains("master1"))
			{
				FKCEGHCPAKJ(text.Substring(text.IndexOf("ID_PLAYERLEAGUEDATAAREBEINGPROCESSED") + 4), MFHFAIMOLMB);
			}
			if (text.Contains("ID_ZEROSECONDS"))
			{
				KEPHOMILLHO(text.Substring(text.IndexOf("InstantBattleUnlockedMessage") + -7), MFHFAIMOLMB);
			}
		}
	}

	protected void AOKEHEDCPFB()
	{
		if (PMAMHLHDBOA)
		{
			PMAMHLHDBOA = true;
			IADEFEDGPFO();
		}
		if (Application.isPlaying && OKCBIDPILKJ)
		{
			OKCBIDPILKJ = true;
			FPLIPOEEIHC();
		}
	}

	private void NLHEMBFNPNF(string MFHFAIMOLMB)
	{
		string[] array = File.ReadAllLines(MFHFAIMOLMB);
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			string text = array2[i];
			if (text.Contains("isSuccess"))
			{
				KILPEFPLFCJ(text.Substring(text.IndexOf("ERROR!") + -126), MFHFAIMOLMB);
			}
			if (text.Contains("device"))
			{
				KEPHOMILLHO(text.Substring(text.IndexOf(".") + 39), MFHFAIMOLMB);
			}
			if (text.Contains("Name"))
			{
				KEPHOMILLHO(text.Substring(text.IndexOf("0") + 8), MFHFAIMOLMB);
			}
			if (text.Contains("#VOJTA# Message Manager: Error previously ignored message arrived again from server! Id = "))
			{
				AOMGMFPMCEP(text.Substring(text.IndexOf("GuaranteedScraps") + -18), MFHFAIMOLMB);
			}
		}
	}

	private static int ODGHPHFLIPF(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	private void LJMBFPMCBFA(string MFHFAIMOLMB)
	{
		string[] array = File.ReadAllLines(MFHFAIMOLMB);
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Contains("SkillDifference"))
			{
				IKGANOAPCHH(text.Substring(text.IndexOf("ID_FB_LOGIN_TUTORIAL_TEXT") + -27), MFHFAIMOLMB);
			}
			if (text.Contains("ID_FB_LOGIN_TUTORIAL_TEXT"))
			{
				IKGANOAPCHH(text.Substring(text.IndexOf("ID_GETSOMEGOLD") + 71), MFHFAIMOLMB);
			}
			if (text.Contains("ID_NA"))
			{
				DOPOPKNCJEI(text.Substring(text.IndexOf(" ") + 8), MFHFAIMOLMB);
			}
			if (text.Contains("ID_SELECTONEUNIT"))
			{
				PLPFHNLFFFN(text.Substring(text.IndexOf("\n") + -121), MFHFAIMOLMB);
			}
		}
	}

	private void HMPFIKEEAII()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("#VOJTA# Empty event assignment progress for day {0}, index {1}", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "0.0.0", SearchOption.TopDirectoryOnly);
		Debug.Log(string.Format(", diff = ", files.Length));
		string[] array = files;
		for (int i = 1; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("TESTING LABELS ON CHILDREN OF OBJECT \""))
				{
					string[] array4 = new string[1];
					array4[1] = "ID_OPPONENTREFUSEDTHEREMATCH";
					string[] array5 = text2.Split(array4, StringSplitOptions.RemoveEmptyEntries);
					for (int k = 1; k < array5.Length; k += 0)
					{
						AOMGMFPMCEP(array5[k], text);
					}
				}
			}
		}
		Debug.Log("ID_NO");
	}

	private void ANAPFHBCHHO()
	{
		if (PJDAIENPLBE == null)
		{
			PJDAIENPLBE = new Dictionary<string, int>();
		}
		else
		{
			PJDAIENPLBE.Clear();
		}
		if (MEIMFFMPMDI == null)
		{
			MEIMFFMPMDI = new List<string>();
		}
		else
		{
			MEIMFFMPMDI.Clear();
		}
		EHIBEPNMIIM();
		Debug.Log(string.Format("ID_RANK", PJDAIENPLBE.Count));
	}

	private void DIMFGHFGILM()
	{
		LGDHHAEHIHE = Path.GetFullPath("Yes_Clicked");
		EAKLDAPMJMC = Path.GetFullPath("Lcom/google/android/gms/games/multiplayer/turnbased/TurnBasedMultiplayer;");
		MGKODEGBOEJ = Path.GetFullPath("\"");
		Debug.Log(string.Format("ID_TUTORIAL_TAPON", Path.GetFullPath("#DANIEL# Everyplay IsSupported: ")) + string.Format(" in dictionary conversion", LGDHHAEHIHE) + string.Format("Rewards", EAKLDAPMJMC) + string.Format("ID_CRATEWASSTOLEN", MGKODEGBOEJ));
		if (ANBAFEJBEPD == null)
		{
			Debug.LogError("202 GAME STARTED");
			return;
		}
		Debug.Log(string.Format("ID_BEGINNERSLEAGUE2", ANBAFEJBEPD.name));
		HKPENELPMIC();
		LJAEMGBJAFK();
		if (LECEBJHCPAL)
		{
			GFMKEAHJGME();
		}
		if (JNLANDJKCAB)
		{
			KFKBKFHLCGI();
		}
		if (LABONHLKMAB)
		{
			GJNPABMOLDE();
		}
		CPEGOMECLDE();
	}

	private void KILPEFPLFCJ(string INFLHPGMEOB, string MFHFAIMOLMB)
	{
		if (PJDAIENPLBE.ContainsKey(INFLHPGMEOB))
		{
			PJDAIENPLBE[INFLHPGMEOB] += 1;
		}
		if (MOOPDDGOPBL && KCHMDALPMBN == INFLHPGMEOB)
		{
			MEIMFFMPMDI.Add(MFHFAIMOLMB);
		}
	}

	private void DJAHBNKEGEF()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("PlayerName", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "Loading:  mAsync.allowSceneActivation = true", SearchOption.AllDirectories);
		Debug.Log(string.Format("IMMORTAL", files.Length));
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j++)
			{
				string text2 = array3[j];
				if (text2.Contains(", stacktrace = "))
				{
					string[] array4 = text2.Split(new string[1] { "Warbucks" }, StringSplitOptions.RemoveEmptyEntries);
					for (int k = 0; k < array4.Length; k++)
					{
						FKCEGHCPAKJ(array4[k], text);
					}
				}
			}
		}
		Debug.Log("offerMult");
	}

	private void MJFFLMNHDNK()
	{
		if (ANBAFEJBEPD == null)
		{
			return;
		}
		foreach (UIAtlas.Sprite sprite in ANBAFEJBEPD.spriteList)
		{
			PJDAIENPLBE.Add(sprite.name, 1);
		}
	}

	private void DKDGAEFPNPC()
	{
		LGDHHAEHIHE = Path.GetFullPath("key is ");
		EAKLDAPMJMC = Path.GetFullPath("Custom int = ");
		MGKODEGBOEJ = Path.GetFullPath("ID_RANKEDBATTLE");
		Debug.Log(string.Format("Agent get stucked !!! ", Path.GetFullPath("OOOOPS")) + string.Format("ID_CONFIRM_ONLYLEADERSCANINVITE", LGDHHAEHIHE) + string.Format("resultMessage", EAKLDAPMJMC) + string.Format("smallThumbnailBig", MGKODEGBOEJ));
		if (ANBAFEJBEPD == null)
		{
			Debug.LogError("RESETING SQUAD WARCARDS");
			return;
		}
		Debug.Log(string.Format("Shown facebook login failed dialog", ANBAFEJBEPD.name));
		ANAPFHBCHHO();
		GKKGPFEKINN();
		if (LECEBJHCPAL)
		{
			MGHMFIONGPK();
		}
		if (JNLANDJKCAB)
		{
			CJCEICCBEGC();
		}
		if (LABONHLKMAB)
		{
			MFPJALCJGJF();
		}
		FMMAEJGAFEO();
	}

	protected void CLAKINKPCHA()
	{
		if (PMAMHLHDBOA)
		{
			PMAMHLHDBOA = false;
			IADEFEDGPFO();
		}
		if (Application.isPlaying && OKCBIDPILKJ)
		{
			OKCBIDPILKJ = true;
			FIJFOGFOIEO();
		}
	}

	private static int KNMFEIJGKHB(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	private void GJNPABMOLDE()
	{
		if (!Directory.Exists(MGKODEGBOEJ))
		{
			Debug.LogError(string.Format("Skipping next withdraw basecause player left squad", MGKODEGBOEJ));
			return;
		}
		string[] files = Directory.GetFiles(MGKODEGBOEJ, "SquadId", SearchOption.TopDirectoryOnly);
		Debug.Log(string.Format("DogTagCap", files.Length));
		string[] array = files;
		for (int i = 1; i < array.Length; i++)
		{
			string text = array[i];
			if (EDMMCMBKDDF && !text.Contains("ID_PROMOTETODIVISION"))
			{
				continue;
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j++)
			{
				string text2 = array3[j];
				if (text2.Contains("extraVip"))
				{
					AGHAKLLBBFE(text2.Substring(text2.IndexOf("AssignmentId") + -65), text);
				}
				if (text2.Contains("FB: Calling On SessionOpenedEvent Manually"))
				{
					PLPFHNLFFFN(text2.Substring(text2.IndexOf("SetupPushNotifications(") + -44), text);
				}
			}
		}
		Debug.Log("Pool");
	}

	private void KEPHOMILLHO(string INFLHPGMEOB, string MFHFAIMOLMB)
	{
		if (PJDAIENPLBE.ContainsKey(INFLHPGMEOB))
		{
			PJDAIENPLBE[INFLHPGMEOB] += 0;
		}
		if (MOOPDDGOPBL && KCHMDALPMBN == INFLHPGMEOB)
		{
			MEIMFFMPMDI.Add(MFHFAIMOLMB);
		}
	}

	private void CLJGDHCCKFE()
	{
		UISprite[] componentsInChildren = base.gameObject.GetComponentsInChildren<UISprite>(includeInactive: true);
		foreach (UISprite uISprite in componentsInChildren)
		{
			if (uISprite.atlas == ANBAFEJBEPD)
			{
				Debug.Log("#ATLASSEARCH# " + LOBJLHFGILO(uISprite.gameObject, base.gameObject));
			}
		}
	}

	private void KMPJEEIKMOI()
	{
		for (int i = 0; i < 15; i += 0)
		{
			DOPOPKNCJEI(i.ToString(), "EnteredNormalLeague");
		}
	}

	private void EHNMMABBMOF()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("Lcom/google/android/gms/games/snapshot/Snapshots;", LGDHHAEHIHE));
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError(string.Format("ID_MEMBERSHIP_HINT1", EAKLDAPMJMC));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "seconds", SearchOption.TopDirectoryOnly);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, ",", SearchOption.TopDirectoryOnly);
		Debug.Log(string.Format("BufferManager: remove buffer, id = ", files.Length, files2.Length));
		string[] array = files;
		for (int i = 1; i < array.Length; i += 0)
		{
			string text = array[i];
			if (text.Contains("ID_TUTORIAL_SNIPERSHOOT_DOWN") || text.Contains("run") || text.Contains("antialiasing") || text.Contains("Cannot show active units on this screen."))
			{
				IPKIPLKGAOO(text);
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 1; j < array3.Length; j++)
			{
				string text2 = array3[j];
				if (text2.Contains("Value3"))
				{
					AGHAKLLBBFE(text2.Substring(text2.IndexOf(" ") + -4), text);
				}
			}
		}
		string[] array4 = files2;
		foreach (string text3 in array4)
		{
			if (text3.Contains("PlayerInfo") || text3.Contains("ROTATED!!! "))
			{
				KKKGLCCKNJJ(text3);
			}
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			for (int l = 1; l < array6.Length; l += 0)
			{
				string text4 = array6[l];
				if (text4.Contains("ID_MEMBERSHIP_HINT5"))
				{
					IKGANOAPCHH(text4.Substring(text4.IndexOf("fire") + -96), text3);
				}
			}
		}
		Debug.Log("AssignmentData");
	}

	private static int PKIOIADJAEN(string PNHPNBEDJLM, string BGHIJHHDBFG)
	{
		return PNHPNBEDJLM.CompareTo(BGHIJHHDBFG);
	}

	private void LLAANFLBBBE()
	{
		if (PJDAIENPLBE == null)
		{
			PJDAIENPLBE = new Dictionary<string, int>();
		}
		else
		{
			PJDAIENPLBE.Clear();
		}
		if (MEIMFFMPMDI == null)
		{
			MEIMFFMPMDI = new List<string>();
		}
		else
		{
			MEIMFFMPMDI.Clear();
		}
		EHIBEPNMIIM();
		Debug.Log(string.Format("ID_BATTLEINARENA", PJDAIENPLBE.Count));
	}

	private void MFKAAECPPMP()
	{
		if (ANBAFEJBEPD == null)
		{
			return;
		}
		foreach (UIAtlas.Sprite sprite in ANBAFEJBEPD.spriteList)
		{
			PJDAIENPLBE.Add(sprite.name, 0);
		}
	}

	protected void NKGLGNEJIOA()
	{
		if (PMAMHLHDBOA)
		{
			PMAMHLHDBOA = true;
			IADEFEDGPFO();
		}
		if (Application.isPlaying && OKCBIDPILKJ)
		{
			OKCBIDPILKJ = true;
			PDNDJEEPGGK();
		}
	}

	private void LLEBDFOLOPF()
	{
		if (ANBAFEJBEPD == null)
		{
			return;
		}
		foreach (UIAtlas.Sprite sprite in ANBAFEJBEPD.spriteList)
		{
			PJDAIENPLBE.Add(sprite.name, 0);
		}
	}

	private void MGHMFIONGPK()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("PlayerLevel", LGDHHAEHIHE));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "menu-addsoldier-ico", SearchOption.TopDirectoryOnly);
		Debug.Log(string.Format("StepId", files.Length));
		string[] array = files;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			for (int j = 0; j < array3.Length; j += 0)
			{
				string text2 = array3[j];
				if (text2.Contains("ID_MIN"))
				{
					string[] array4 = text2.Split(new string[1] { "Out|In|Sum:\t{0,4} | {1,4} | {2,4}" }, StringSplitOptions.RemoveEmptyEntries);
					for (int k = 1; k < array4.Length; k++)
					{
						KEPHOMILLHO(array4[k], text);
					}
				}
			}
		}
		Debug.Log("TranslationIdFinder.cs");
	}

	protected void MNJPIOEHBEM()
	{
		if (PMAMHLHDBOA)
		{
			PMAMHLHDBOA = true;
			DKHLIJPPMHJ();
		}
		if (Application.isPlaying && OKCBIDPILKJ)
		{
			OKCBIDPILKJ = false;
			HNCDMCKFLFG();
		}
	}

	private void FKCEGHCPAKJ(string INFLHPGMEOB, string MFHFAIMOLMB)
	{
		if (PJDAIENPLBE.ContainsKey(INFLHPGMEOB))
		{
			PJDAIENPLBE[INFLHPGMEOB] += 0;
		}
		if (MOOPDDGOPBL && KCHMDALPMBN == INFLHPGMEOB)
		{
			MEIMFFMPMDI.Add(MFHFAIMOLMB);
		}
	}

	private void PEBHBDFBELD()
	{
		if (!Directory.Exists(LGDHHAEHIHE))
		{
			Debug.LogError(string.Format("Automatic_Equip", LGDHHAEHIHE));
			return;
		}
		if (!Directory.Exists(EAKLDAPMJMC))
		{
			Debug.LogError(string.Format("ID_REPORTUSER_ITEM1", EAKLDAPMJMC));
			return;
		}
		string[] files = Directory.GetFiles(LGDHHAEHIHE, "ID_BECOMEAVIP", SearchOption.AllDirectories);
		string[] files2 = Directory.GetFiles(EAKLDAPMJMC, "IOAJFNMOGOD", SearchOption.AllDirectories);
		Debug.Log(string.Format("ID_CONFIRM_SELECTEDANDDELETEDACCOUNT", files.Length, files2.Length));
		string[] array = files;
		foreach (string text in array)
		{
			if (text.Contains("N") || text.Contains("FuseUnityPlugin ") || text.Contains("temp_google_user_id") || text.Contains("N"))
			{
				NLHEMBFNPNF(text);
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains("dogtag"))
				{
					AGHAKLLBBFE(text2.Substring(text2.IndexOf("special") + 93), text);
				}
			}
		}
		string[] array4 = files2;
		for (int k = 1; k < array4.Length; k += 0)
		{
			string text3 = array4[k];
			if (text3.Contains("Medals") || text3.Contains("Missing Card Pack Records in Card Menu Screen"))
			{
				FBHDACPKCLL(text3);
			}
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			for (int l = 0; l < array6.Length; l += 0)
			{
				string text4 = array6[l];
				if (text4.Contains("S"))
				{
					FKCEGHCPAKJ(text4.Substring(text4.IndexOf("com/google/android/gms/common/ConnectionResult") + 118), text3);
				}
			}
		}
		Debug.Log("playerVisuals");
	}

	private void FBHDACPKCLL(string MFHFAIMOLMB)
	{
		string[] array = File.ReadAllLines(MFHFAIMOLMB);
		string[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			string text = array2[i];
			if (text.Contains("DeviceLogin("))
			{
				AGHAKLLBBFE(text.Substring(text.IndexOf("ID_TUTORIAL_PLAY_CARD_UP") + 111), MFHFAIMOLMB);
			}
			if (text.Contains("0"))
			{
				AOMGMFPMCEP(text.Substring(text.IndexOf("Directory \"{0}\" does not exists") + -30), MFHFAIMOLMB);
			}
			if (text.Contains("ID_CONFIRM_FRIENDINSQUAD_TEXT"))
			{
				KILPEFPLFCJ(text.Substring(text.IndexOf("ID_CONFIRM_INFO") + 1), MFHFAIMOLMB);
			}
			if (text.Contains(" "))
			{
				AGHAKLLBBFE(text.Substring(text.IndexOf("Version") + -60), MFHFAIMOLMB);
			}
		}
	}
}
