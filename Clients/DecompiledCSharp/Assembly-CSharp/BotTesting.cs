using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class BotTesting : Core_BaseScript
{
	public TextAsset players;

	public bool compute;

	private List<List<string>> rowData = new List<List<string>>();

	private PlayerProperties playerProperties;

	private bool mComputing;

	private int mI;

	private List<string> lines;

	protected override void Awake()
	{
		base.Awake();
		GameController instance = Singleton<GameController>.instance;
		instance.gameObject.SetActive(value: false);
	}

	public void Update()
	{
		if (compute)
		{
			compute = false;
			mComputing = true;
			mI = 0;
			lines = TextAssetToList(players);
			InitCsv();
			Singleton<BeanstalkServerManager>.instance.disableErrorrs = true;
		}
		if (mComputing && lines != null)
		{
			LoadPlayer(lines[mI], mI);
			TestBotsForPlayer();
			mI++;
			if (mI == lines.Count)
			{
				mComputing = false;
				Debug.Log("Saving CSV");
				SaveCsv();
				Debug.Log("CSV saved");
			}
		}
	}

	private static List<string> TextAssetToList(TextAsset ta)
	{
		return new List<string>(ta.text.Split('\n'));
	}

	private void TestBotsForPlayer()
	{
		for (int i = -10; i < 20; i++)
		{
			try
			{
				PlayerProperties playerProperties = new PlayerProperties();
				StatsManager.instance.data.deathMatchOfflineWinLooseStreak = i;
				int botLevel = BotManager.GetBotLevel(LevelManager.instance.currentLevel.displayNumber);
				float botUnitPower = 0f;
				UnitUpgradeDefinition[] collection = BotManager.PickBotUnits(out botUnitPower, botLevel);
				playerProperties.upgrades = new List<UnitUpgradeDefinition>(collection);
				PlayerInventory.EquippedWeapon[] equippedWeapons;
				float value = BotManager.PickWeapons(botLevel, out equippedWeapons);
				int num = MiscTools.RoundToInt(botUnitPower) + MiscTools.RoundToInt(value) + LevelManager.instance.GetRankPower(botLevel);
				playerProperties.weapons = equippedWeapons;
				rowData.Add(new List<string>
				{
					"\"" + this.playerProperties.name + "\"",
					"\"" + JsonConvert.SerializeObject(this.playerProperties.GetArmyForStats()) + "\"",
					"\"" + JsonConvert.SerializeObject(this.playerProperties.GetWeaponsForStats()) + "\"",
					LevelManager.instance.armyPower.ToString(),
					LevelManager.instance.unitPower.ToString(),
					LevelManager.instance.weaponPower.ToString(),
					LevelManager.instance.currentLevel.displayNumber.ToString(),
					i.ToString(),
					"\"" + JsonConvert.SerializeObject(playerProperties.GetArmyForStats()) + "\"",
					"\"" + JsonConvert.SerializeObject(playerProperties.GetWeaponsForStats()) + "\"",
					num.ToString(),
					MiscTools.RoundToInt(botUnitPower).ToString(),
					MiscTools.RoundToInt(value).ToString(),
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

	private void InitCsv()
	{
		rowData.Add(new List<string>
		{
			"PlayerName", "PlayerUnits", "PlayerWeapons", "PlayerArmyPower", "PlayerUnitPower", "PlayerWeaponPower", "PlayerLevel", "WinLooseStreak", "BotUnits", "BotWeapons",
			"BotArmyPower", "BotUnitPower", "BotWeaponPower", "BotLevel"
		});
	}

	private void LoadPlayer(string line, int i)
	{
		LevelManager.instance.Init();
		JToken jToken = JsonConvert.DeserializeObject<JToken>(line);
		if (jToken != null)
		{
			string text = ((jToken["PlayerName"] == null) ? "default" : StringParser.ParseString("PlayerName", "S", jToken, string.Empty));
			DatabaseSerializedObject.TryLoadObjects(jToken);
			PlayerInventory.instance.Init();
			int level = ((jToken["Level"] == null) ? 4 : StringParser.ParseInt("Level", "N", jToken, 14));
			int loadedArmyPower = ((jToken["ArmyPower"] == null) ? 1 : StringParser.ParseInt("ArmyPower", "N", jToken, 1));
			LevelManager.instance.LoadData(level, 0, 0L, loadedArmyPower);
			playerProperties = PlayerProperties.CreateForLocalPlayerLight();
			playerProperties.name = text;
			Debug.Log($"Done: {i} players");
		}
	}

	private void SaveCsv()
	{
		string[][] array = new string[rowData.Count][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = rowData[i].ToArray();
		}
		int length = array.GetLength(0);
		string separator = ";";
		StringBuilder stringBuilder = new StringBuilder();
		for (int j = 0; j < length; j++)
		{
			stringBuilder.AppendLine(string.Join(separator, array[j]));
		}
		string path = getPath();
		StreamWriter streamWriter = File.CreateText(path);
		streamWriter.WriteLine(stringBuilder);
		streamWriter.Close();
	}

	private string getPath()
	{
		return Application.persistentDataPath + "Saved_data.csv";
	}
}
