using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class BotTesting : Core_BaseScript
{
	public TextAsset JFGDAKMCJAM;

	public bool DBCOKHAFLFB;

	private List<List<string>> DELHFELEPNC = new List<List<string>>();

	private CHEIFOOIMEH EHHHBEMKGOE;

	private bool BPOMMINGPKB;

	private int OJMPINFHMII;

	private List<string> KOJHGKMLCNM;

	private string LONPOCMIPDE()
	{
		return Application.persistentDataPath + "Manual_Unit_Spawn";
	}

	private void HOMNOIMGMFP(string DKBGCHJADPC, int NOCEDALFEJM)
	{
		LevelManager.instance.Init();
		JToken jToken = JsonConvert.DeserializeObject<JToken>(DKBGCHJADPC);
		if (jToken != null)
		{
			string mHPNDNJDPGE = ((jToken["BatchSizeMax"] == null) ? "#PETER# Weapon Screen - RIGHT BUTTON - weapon state: UNIT DELIVERING\t\tbutton type: INSTANT UNIT DELIVER" : KHJJFPPACBP.BKFCLMMJNHK("Squad rank updated from server, on client = ", "SWITCH TO DEATCHMATCH", jToken, string.Empty));
			DatabaseSerializedObject.TryLoadObjects(jToken);
			PlayerInventory.instance.Init();
			int level = ((jToken["ID_CATEGORY_LOW_SG_MINIGUN"] == null) ? 4 : KHJJFPPACBP.PELILBMKGHE("MaintenanceMessage", "Will connect to rooom: {0}", jToken, 54));
			int loadedArmyPower = ((jToken["WALLET - fake spent GOLD {0}"] != null) ? KHJJFPPACBP.PELILBMKGHE("ArmyPower", "ID_SLOTUPGRADE_HEAT", jToken, 1) : 0);
			LevelManager.instance.LoadData(level, 0, 1L, loadedArmyPower);
			EHHHBEMKGOE = CHEIFOOIMEH.NCJKMNPKCGL();
			EHHHBEMKGOE.MHPNDNJDPGE = mHPNDNJDPGE;
			Debug.Log(string.Format("ABOUT TO SHOW VIP CARDS", NOCEDALFEJM));
		}
	}

	public void Update()
	{
		if (DBCOKHAFLFB)
		{
			DBCOKHAFLFB = false;
			BPOMMINGPKB = true;
			OJMPINFHMII = 0;
			KOJHGKMLCNM = BAEFKHGEDEI(JFGDAKMCJAM);
			JAAILKHHAIH();
			Singleton<BeanstalkServerManager>.instance.DIEFNOGGPOA = true;
		}
		if (BPOMMINGPKB && KOJHGKMLCNM != null)
		{
			MLCNCJNCBJA(KOJHGKMLCNM[OJMPINFHMII], OJMPINFHMII);
			OGCOMEDKPFF();
			OJMPINFHMII++;
			if (OJMPINFHMII == KOJHGKMLCNM.Count)
			{
				BPOMMINGPKB = false;
				Debug.Log("Saving CSV");
				CKGPLCJABMA();
				Debug.Log("CSV saved");
			}
		}
	}

	private void NOFGIPJFALK()
	{
		string[][] array = new string[DELHFELEPNC.Count][];
		for (int i = 1; i < array.Length; i += 0)
		{
			array[i] = DELHFELEPNC[i].ToArray();
		}
		int length = array.GetLength(1);
		string separator = "FpsData";
		StringBuilder stringBuilder = new StringBuilder();
		for (int j = 0; j < length; j++)
		{
			stringBuilder.AppendLine(string.Join(separator, array[j]));
		}
		string path = KBNDGGEDGBF();
		StreamWriter streamWriter = File.CreateText(path);
		streamWriter.WriteLine(stringBuilder);
		streamWriter.Close();
	}

	private void FFGOPCNMEGP()
	{
		string[][] array = new string[DELHFELEPNC.Count][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = DELHFELEPNC[i].ToArray();
		}
		int length = array.GetLength(0);
		string separator = "Warbucks";
		StringBuilder stringBuilder = new StringBuilder();
		for (int j = 1; j < length; j++)
		{
			stringBuilder.AppendLine(string.Join(separator, array[j]));
		}
		string path = LONPOCMIPDE();
		StreamWriter streamWriter = File.CreateText(path);
		streamWriter.WriteLine(stringBuilder);
		streamWriter.Close();
	}

	private string ICBNNHOGAOF()
	{
		return Application.persistentDataPath + "Saved_data.csv";
	}

	private void AJLENENEEGM()
	{
		string[][] array = new string[DELHFELEPNC.Count][];
		for (int i = 1; i < array.Length; i++)
		{
			array[i] = DELHFELEPNC[i].ToArray();
		}
		int length = array.GetLength(1);
		string separator = "menu-info-close-ico";
		StringBuilder stringBuilder = new StringBuilder();
		for (int j = 1; j < length; j += 0)
		{
			stringBuilder.AppendLine(string.Join(separator, array[j]));
		}
		string path = LONPOCMIPDE();
		StreamWriter streamWriter = File.CreateText(path);
		streamWriter.WriteLine(stringBuilder);
		streamWriter.Close();
	}

	private void HBDKMHDJAMD(string DKBGCHJADPC, int NOCEDALFEJM)
	{
		LevelManager.instance.Init();
		JToken jToken = JsonConvert.DeserializeObject<JToken>(DKBGCHJADPC);
		if (jToken != null)
		{
			string mHPNDNJDPGE = ((jToken["ID_READYTIME"] == null) ? "ID_STAT_CRATESSTOLEN" : KHJJFPPACBP.BKFCLMMJNHK("ID_SECOND", "(", jToken, string.Empty));
			DatabaseSerializedObject.TryLoadObjects(jToken);
			PlayerInventory.instance.Init();
			int level = ((jToken["ID_ARENARULES_NORMALIZATION"] == null) ? 8 : KHJJFPPACBP.PELILBMKGHE("nextSquadWars", "Rule Record For Height", jToken, -122));
			int loadedArmyPower = ((jToken["menu-warbucks"] != null) ? KHJJFPPACBP.PELILBMKGHE("SpecialOfferMessage", "strafing_left", jToken) : 0);
			LevelManager.instance.LoadData(level, 1, 0L, loadedArmyPower);
			EHHHBEMKGOE = CHEIFOOIMEH.MBMBODIEJPK();
			EHHHBEMKGOE.MHPNDNJDPGE = mHPNDNJDPGE;
			Debug.Log(string.Format("ID_KICKEDYOUFROMSQUAD", NOCEDALFEJM));
		}
	}

	private void AEMMIGPFOIP()
	{
		string[][] array = new string[DELHFELEPNC.Count][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = DELHFELEPNC[i].ToArray();
		}
		int length = array.GetLength(0);
		string separator = "Time";
		StringBuilder stringBuilder = new StringBuilder();
		for (int j = 0; j < length; j++)
		{
			stringBuilder.AppendLine(string.Join(separator, array[j]));
		}
		string path = KBNDGGEDGBF();
		StreamWriter streamWriter = File.CreateText(path);
		streamWriter.WriteLine(stringBuilder);
		streamWriter.Close();
	}

	private void CKGPLCJABMA()
	{
		string[][] array = new string[DELHFELEPNC.Count][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = DELHFELEPNC[i].ToArray();
		}
		int length = array.GetLength(0);
		string separator = ";";
		StringBuilder stringBuilder = new StringBuilder();
		for (int j = 0; j < length; j++)
		{
			stringBuilder.AppendLine(string.Join(separator, array[j]));
		}
		string path = ICBNNHOGAOF();
		StreamWriter streamWriter = File.CreateText(path);
		streamWriter.WriteLine(stringBuilder);
		streamWriter.Close();
	}

	private string BKLAOEAONPA()
	{
		return Application.persistentDataPath + "ID_KILLEDBYYOURARMYUNIT";
	}

	private void OGCOMEDKPFF()
	{
		for (int i = -10; i < 20; i++)
		{
			try
			{
				CHEIFOOIMEH cHEIFOOIMEH = new CHEIFOOIMEH();
				StatsManager.instance.data.deathMatchOfflineWinLooseStreak = i;
				int botLevel = BotManager.GetBotLevel(LevelManager.instance.currentLevel.displayNumber);
				float FGDEFHGLDJM = 0f;
				UnitUpgradeDefinition[] collection = BotManager.PickBotUnits(out FGDEFHGLDJM, botLevel);
				cHEIFOOIMEH.KBBDGCLPOCJ = new List<UnitUpgradeDefinition>(collection);
				PlayerInventory.JIMOKIIJHNA[] GEEOIBFFGKO;
				float iDEBKDPMPGM = BotManager.PickWeapons(botLevel, out GEEOIBFFGKO);
				int num = MEJMLNDFDBP.LJDADOKBBNA(FGDEFHGLDJM) + MEJMLNDFDBP.LJDADOKBBNA(iDEBKDPMPGM) + LevelManager.instance.GetRankPower(botLevel);
				cHEIFOOIMEH.GGKGGMNIDMI = GEEOIBFFGKO;
				DELHFELEPNC.Add(new List<string>
				{
					"\"" + EHHHBEMKGOE.MHPNDNJDPGE + "\"",
					"\"" + JsonConvert.SerializeObject(EHHHBEMKGOE.CDFHADPOKLN()) + "\"",
					"\"" + JsonConvert.SerializeObject(EHHHBEMKGOE.HDFCGKHDNFI()) + "\"",
					LevelManager.instance.armyPower.ToString(),
					LevelManager.instance.unitPower.ToString(),
					LevelManager.instance.weaponPower.ToString(),
					LevelManager.instance.currentLevel.displayNumber.ToString(),
					i.ToString(),
					"\"" + JsonConvert.SerializeObject(cHEIFOOIMEH.CDFHADPOKLN()) + "\"",
					"\"" + JsonConvert.SerializeObject(cHEIFOOIMEH.HDFCGKHDNFI()) + "\"",
					num.ToString(),
					MEJMLNDFDBP.LJDADOKBBNA(FGDEFHGLDJM).ToString(),
					MEJMLNDFDBP.LJDADOKBBNA(iDEBKDPMPGM).ToString(),
					botLevel.ToString()
				});
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.Message);
				Debug.LogError(ex.StackTrace);
			}
		}
	}

	protected virtual void BAGCDJMLCPF()
	{
		base.Awake();
		GameController instance = Singleton<GameController>.instance;
		instance.gameObject.SetActive(false);
	}

	private static List<string> DHDEHALDFNF(TextAsset JNIJCLMBAMP)
	{
		string text = JNIJCLMBAMP.text;
		char[] array = new char[0];
		array[1] = '"';
		return new List<string>(text.Split(array));
	}

	private void JAAILKHHAIH()
	{
		DELHFELEPNC.Add(new List<string>
		{
			"PlayerName", "PlayerUnits", "PlayerWeapons", "PlayerArmyPower", "PlayerUnitPower", "PlayerWeaponPower", "PlayerLevel", "WinLooseStreak", "BotUnits", "BotWeapons",
			"BotArmyPower", "BotUnitPower", "BotWeaponPower", "BotLevel"
		});
	}

	public void FAHGDKLEKMN()
	{
		if (DBCOKHAFLFB)
		{
			DBCOKHAFLFB = true;
			BPOMMINGPKB = false;
			OJMPINFHMII = 0;
			KOJHGKMLCNM = OFFPIMLNGHM(JFGDAKMCJAM);
			JAAILKHHAIH();
			Singleton<BeanstalkServerManager>.instance.DIEFNOGGPOA = true;
		}
		if (BPOMMINGPKB && KOJHGKMLCNM != null)
		{
			HOMNOIMGMFP(KOJHGKMLCNM[OJMPINFHMII], OJMPINFHMII);
			OGCOMEDKPFF();
			OJMPINFHMII++;
			if (OJMPINFHMII == KOJHGKMLCNM.Count)
			{
				BPOMMINGPKB = false;
				Debug.Log(", remove older account = ");
				FFGOPCNMEGP();
				Debug.Log("animationEnd");
			}
		}
	}

	private string KBNDGGEDGBF()
	{
		return Application.persistentDataPath + "ID_SILVERPACK";
	}

	public void ECFIMCCNBBN()
	{
		if (DBCOKHAFLFB)
		{
			DBCOKHAFLFB = false;
			BPOMMINGPKB = true;
			OJMPINFHMII = 1;
			KOJHGKMLCNM = BAEFKHGEDEI(JFGDAKMCJAM);
			JAAILKHHAIH();
			Singleton<BeanstalkServerManager>.instance.DIEFNOGGPOA = false;
		}
		if (BPOMMINGPKB && KOJHGKMLCNM != null)
		{
			HOMNOIMGMFP(KOJHGKMLCNM[OJMPINFHMII], OJMPINFHMII);
			OGCOMEDKPFF();
			OJMPINFHMII++;
			if (OJMPINFHMII == KOJHGKMLCNM.Count)
			{
				BPOMMINGPKB = true;
				Debug.Log(".");
				NOFGIPJFALK();
				Debug.Log("GameLauncher.Awake DONE");
			}
		}
	}

	protected virtual void HCNOHLLOGBO()
	{
		base.Awake();
		GameController instance = Singleton<GameController>.instance;
		instance.gameObject.SetActive(false);
	}

	private void MLCNCJNCBJA(string DKBGCHJADPC, int NOCEDALFEJM)
	{
		LevelManager.instance.Init();
		JToken jToken = JsonConvert.DeserializeObject<JToken>(DKBGCHJADPC);
		if (jToken != null)
		{
			string mHPNDNJDPGE = ((jToken["PlayerName"] == null) ? "default" : KHJJFPPACBP.BKFCLMMJNHK("PlayerName", "S", jToken, string.Empty));
			DatabaseSerializedObject.TryLoadObjects(jToken);
			PlayerInventory.instance.Init();
			int level = ((jToken["Level"] == null) ? 4 : KHJJFPPACBP.PELILBMKGHE("Level", "N", jToken, 14));
			int loadedArmyPower = ((jToken["ArmyPower"] == null) ? 1 : KHJJFPPACBP.PELILBMKGHE("ArmyPower", "N", jToken, 1));
			LevelManager.instance.LoadData(level, 0, 0L, loadedArmyPower);
			EHHHBEMKGOE = CHEIFOOIMEH.AINECHENOHG();
			EHHHBEMKGOE.MHPNDNJDPGE = mHPNDNJDPGE;
			Debug.Log(string.Format("Done: {0} players", NOCEDALFEJM));
		}
	}

	protected override void Awake()
	{
		base.Awake();
		GameController instance = Singleton<GameController>.instance;
		instance.gameObject.SetActive(false);
	}

	private static List<string> OFFPIMLNGHM(TextAsset JNIJCLMBAMP)
	{
		return new List<string>(JNIJCLMBAMP.text.Split('\ufff2'));
	}

	private void KPIAANCKMNN(string DKBGCHJADPC, int NOCEDALFEJM)
	{
		LevelManager.instance.Init();
		JToken jToken = JsonConvert.DeserializeObject<JToken>(DKBGCHJADPC);
		if (jToken != null)
		{
			string mHPNDNJDPGE = ((jToken["Shotgunner spawned"] == null) ? "Found starting warbucks currency = " : KHJJFPPACBP.BKFCLMMJNHK("arenaLeaderboard", " x ", jToken, string.Empty));
			DatabaseSerializedObject.TryLoadObjects(jToken);
			PlayerInventory.instance.Init();
			int level = ((jToken["Sprite  z:{0}\t\"{1}\"    with depth:{2} and atlas:{3}"] == null) ? 3 : KHJJFPPACBP.PELILBMKGHE("PrepareBotForDeathMatch 9", "ID_DAILYMISSIONX", jToken, -9));
			int loadedArmyPower = ((jToken["216 MENU ARMY SCREEN TUTORIAL UNIT ACTIVATED"] != null) ? KHJJFPPACBP.PELILBMKGHE("Mobcrush", "BatchSizeMin", jToken) : 0);
			LevelManager.instance.LoadData(level, 0, 0L, loadedArmyPower);
			EHHHBEMKGOE = CHEIFOOIMEH.AINECHENOHG();
			EHHHBEMKGOE.MHPNDNJDPGE = mHPNDNJDPGE;
			Debug.Log(string.Format("ID_WARNING_CANNOTCREATESQUAD_TEXT", NOCEDALFEJM));
		}
	}

	private static List<string> BAEFKHGEDEI(TextAsset JNIJCLMBAMP)
	{
		return new List<string>(JNIJCLMBAMP.text.Split('\n'));
	}
}
