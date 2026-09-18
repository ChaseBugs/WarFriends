using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteUseFinder : Core_BaseScript
{
	[Header("Settings")]
	public bool searchScripts;

	public bool searchPrefabs;

	public bool searchScenes;

	public bool searchOnlyMainScene = true;

	[Header("Atlas to search")]
	public UIAtlas searchAtlas;

	[Header("Additional Finding Sprite")]
	public bool searchSprite;

	public string spriteName;

	[Header("Start")]
	public bool startSearch;

	private string mScriptsPath = string.Empty;

	private string mPrefabsPath = string.Empty;

	private string mScenesPath = string.Empty;

	private Dictionary<string, int> mDictionary;

	private List<string> mSpriteUsage;

	private void Search()
	{
		mScriptsPath = Path.GetFullPath("./Assets/Scripts");
		mPrefabsPath = Path.GetFullPath("./Assets/Prefabs");
		mScenesPath = Path.GetFullPath("./Assets/Scenes");
		Debug.Log(string.Format("Current Full Path: \"{0}\"\n", Path.GetFullPath(".")) + $"Scripts Full Path: \"{mScriptsPath}\"\n" + $"Prefabs Full Path: \"{mPrefabsPath}\"\n" + $"Scenes Full Path: \"{mScenesPath}\"\n");
		if (searchAtlas == null)
		{
			Debug.LogError("Missing reference to atlas.");
			return;
		}
		Debug.Log($"Selected Atlas \"{searchAtlas.name}\"");
		CreateDictionary();
		AddLevels();
		AddRibbons();
		if (searchScripts)
		{
			SearchScripts();
		}
		if (searchPrefabs)
		{
			SearchPrefabs();
		}
		if (searchScenes)
		{
			SearchScenes();
		}
		WriteConsoleNotUsedSprites();
	}

	private void AddLevels()
	{
		for (int i = 1; i < 51; i++)
		{
			CheckDictionary(i.ToString(), "Levels Special Search");
		}
	}

	private void AddRibbons()
	{
		foreach (int value in Enum.GetValues(typeof(SkillShot.SkillShotType)))
		{
			CheckDictionary($"game-ribbon-{((SkillShot.SkillShotType)value).ToString().ToLower()}", "Ribbons Special Search");
			CheckDictionary($"game-ribbon-{((SkillShot.SkillShotType)value).ToString().ToLower()}-bg", "Ribbons Special Search");
		}
	}

	private void SearchPrefab(string fileName)
	{
		string[] array = File.ReadAllLines(fileName);
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Contains(" iconName:"))
			{
				CheckDictionary(text.Substring(text.IndexOf(" iconName:") + 11), fileName);
			}
			if (text.Contains(" abilityIcon:"))
			{
				CheckDictionary(text.Substring(text.IndexOf(" abilityIcon:") + 14), fileName);
			}
			if (text.Contains(" icon:"))
			{
				CheckDictionary(text.Substring(text.IndexOf(" icon:") + 7), fileName);
			}
			if (text.Contains(" bonusIcon:"))
			{
				CheckDictionary(text.Substring(text.IndexOf(" bonusIcon:") + 12), fileName);
			}
		}
	}

	private void SearchScripts()
	{
		if (!Directory.Exists(mScriptsPath))
		{
			Debug.LogError($"Directory \"{mScriptsPath}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(mScriptsPath, "*.cs", SearchOption.AllDirectories);
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
						CheckDictionary(array4[k], text);
					}
				}
			}
		}
		Debug.Log("Scripts search finished.");
	}

	private void SearchPrefabs()
	{
		if (!Directory.Exists(mScriptsPath))
		{
			Debug.LogError($"Directory \"{mScriptsPath}\" does not exists");
			return;
		}
		if (!Directory.Exists(mPrefabsPath))
		{
			Debug.LogError($"Directory \"{mPrefabsPath}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(mScriptsPath, "*.prefab", SearchOption.AllDirectories);
		string[] files2 = Directory.GetFiles(mPrefabsPath, "*.prefab", SearchOption.AllDirectories);
		Debug.Log($"Prefabs to go through: {files.Length} + {files2.Length}");
		string[] array = files;
		foreach (string text in array)
		{
			if (text.Contains("SkillShotManager.prefab") || text.Contains("Camosmanager.prefab") || text.Contains("CardManager.prefab") || text.Contains("SpawningManagerMultiplayer.prefab"))
			{
				SearchPrefab(text);
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains(" mSpriteName:"))
				{
					CheckDictionary(text2.Substring(text2.IndexOf(" mSpriteName:") + 14), text);
				}
			}
		}
		string[] array4 = files2;
		foreach (string text3 in array4)
		{
			if (text3.Contains("LevelsManager.prefab") || text3.Contains("PlayerPrefab.prefab"))
			{
				SearchPrefab(text3);
			}
			string[] array5 = File.ReadAllLines(text3);
			string[] array6 = array5;
			foreach (string text4 in array6)
			{
				if (text4.Contains(" mSpriteName:"))
				{
					CheckDictionary(text4.Substring(text4.IndexOf(" mSpriteName:") + 14), text3);
				}
			}
		}
		Debug.Log("Prefabs search finished.");
	}

	private void SearchScenes()
	{
		if (!Directory.Exists(mScenesPath))
		{
			Debug.LogError($"Directory \"{mScenesPath}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(mScenesPath, "MainScene*.unity", SearchOption.TopDirectoryOnly);
		Debug.Log($"Scenes to go through: {files.Length}");
		string[] array = files;
		foreach (string text in array)
		{
			if (searchOnlyMainScene && !text.Contains("MainScene.unity"))
			{
				continue;
			}
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains(" mSpriteName:"))
				{
					CheckDictionary(text2.Substring(text2.IndexOf(" mSpriteName:") + 14), text);
				}
				if (text2.Contains(" iconName:"))
				{
					CheckDictionary(text2.Substring(text2.IndexOf(" iconName:") + 11), text);
				}
			}
		}
		Debug.Log("Scenes search finished.");
	}

	private void CreateDictionary()
	{
		if (mDictionary == null)
		{
			mDictionary = new Dictionary<string, int>();
		}
		else
		{
			mDictionary.Clear();
		}
		if (mSpriteUsage == null)
		{
			mSpriteUsage = new List<string>();
		}
		else
		{
			mSpriteUsage.Clear();
		}
		FillDictionary();
		Debug.Log($"Dictionary filled and contains {mDictionary.Count} ids");
	}

	private void FillDictionary()
	{
		if (searchAtlas == null)
		{
			return;
		}
		foreach (UIAtlas.Sprite sprite in searchAtlas.spriteList)
		{
			mDictionary.Add(sprite.name, 0);
		}
	}

	private void CheckDictionary(string id, string fileName)
	{
		if (mDictionary.ContainsKey(id))
		{
			mDictionary[id] += 1;
		}
		if (searchSprite && spriteName == id)
		{
			mSpriteUsage.Add(fileName);
		}
	}

	private void WriteConsoleNotUsedSprites()
	{
		string text = string.Empty;
		int num = 0;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, int> item in mDictionary)
		{
			if (item.Value == 0)
			{
				list.Add(item.Key);
				num++;
			}
		}
		list.Sort((string sprite1, string sprite2) => sprite1.CompareTo(sprite2));
		foreach (string item2 in list)
		{
			text = text + item2 + "\n";
		}
		if (num > 0)
		{
			Debug.LogWarning($"Not used sprites ({num}/{mDictionary.Count}) in atlas \"{searchAtlas.name}\" :\n{text}");
		}
		else
		{
			Debug.Log($"All \"sprites\" ({mDictionary.Count}) from atlas \"{searchAtlas.name}\" are used");
		}
		if (!searchSprite)
		{
			return;
		}
		string text2 = $"Sprite \"{spriteName}\" was used in files:";
		mSpriteUsage.Sort((string sprite1, string sprite2) => sprite1.CompareTo(sprite2));
		foreach (string item3 in mSpriteUsage)
		{
			text2 += $"\n{item3}";
		}
		Debug.Log($"{text2}\n----------\n");
	}

	protected void Update()
	{
		if (startSearch)
		{
			startSearch = false;
			Search();
		}
	}
}
