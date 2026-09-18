using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

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

		public TranslationRecord(string idRecord, string translationRecord, int lineRecord)
		{
			id = idRecord;
			translation = translationRecord;
			line = lineRecord;
			usedInFiles = new List<string>();
		}

		public TranslationRecord(string notInDictionaryId)
		{
			id = notInDictionaryId;
			usedInFiles = new List<string>();
			line = -1;
		}

		public void IncreaseUsage(string file)
		{
			numberOfUsage++;
			usedInFiles.Add(file);
		}

		public void AddDuplicitIds(string difTranslation)
		{
			isDuplicitRecord = isDuplicitRecord || translation == difTranslation;
			if (duplicitTranslations == null)
			{
				duplicitTranslations = new List<string>();
			}
			duplicitTranslations.Add(difTranslation);
		}

		public void AddDuplicitTranslation(List<string> difIds)
		{
			duplicitIds = new List<string>();
			foreach (string difId in difIds)
			{
				duplicitIds.Add(difId);
			}
		}
	}

	[Header("References")]
	public TextAsset localizationFile;

	[Header("Settings")]
	public bool searchScripts;

	public bool searchPrefabs;

	public bool searchScenes;

	public bool searchForColours;

	[Header("Use")]
	public string localizationName;

	[Header("Choose Task:")]
	public bool startSearch;

	public bool startSearchUse;

	public bool clearDictionary;

	private Dictionary<string, TranslationRecord> mDictionary;

	private Dictionary<string, List<string>> mColoursIds;

	private string mScriptsPath = string.Empty;

	private string mPrefabsPath = string.Empty;

	private string mScenesPath = string.Empty;

	private string mDebugMessage = string.Empty;

	private string pathDel => "/";

	private void Search()
	{
		ClearDebugMessage();
		mScriptsPath = Path.GetFullPath("." + pathDel + "Assets" + pathDel + "Scripts");
		mPrefabsPath = Path.GetFullPath("." + pathDel + "Assets" + pathDel + "Prefabs");
		mScenesPath = Path.GetFullPath("." + pathDel + "Assets" + pathDel + "Scenes");
		AddToDebugMessage(string.Format("Current Full Path: \"{0}\"\n", Path.GetFullPath(".")) + $"Scripts Full Path: \"{mScriptsPath}\"\n" + $"Prefabs Full Path: \"{mPrefabsPath}\"\n" + $"Scenes Full Path: \"{mScenesPath}\"\n");
		if (localizationFile == null)
		{
			Debug.LogError("Missing reference to localization file.");
			return;
		}
		CreateDictionary();
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
		WriteDebugMessage();
		WriteConsoleNotUsedIds();
	}

	private void SearchUse()
	{
		ClearDebugMessage();
		mScriptsPath = Path.GetFullPath("." + pathDel + "Assets" + pathDel + "Scripts");
		mPrefabsPath = Path.GetFullPath("." + pathDel + "Assets" + pathDel + "Prefabs");
		mScenesPath = Path.GetFullPath("." + pathDel + "Assets" + pathDel + "Scenes");
		if (localizationFile == null)
		{
			Debug.LogError("Missing reference to localization file.");
			return;
		}
		if (string.IsNullOrEmpty(localizationName))
		{
			Debug.LogError("Null or empty localization name for search.");
			return;
		}
		CreateDictionary();
		if (searchScripts)
		{
			SearchUseScripts();
		}
		if (searchPrefabs)
		{
			SearchUsePrefabs();
		}
		if (searchScenes)
		{
			SearchUseScenes();
		}
		WriteDebugMessage();
	}

	private void CreateDictionary()
	{
		ClearDictionary();
		string[] array = localizationFile.text.Split(new string[1] { "\n" }, StringSplitOptions.None);
		int num = 0;
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		if (searchForColours)
		{
			mColoursIds = new Dictionary<string, List<string>>();
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
			if (mDictionary.ContainsKey(text2))
			{
				mDictionary[text2].AddDuplicitIds(text3);
			}
			else
			{
				mDictionary.Add(text2, new TranslationRecord(text2, text3, num));
			}
			if (dictionary.ContainsKey(text3))
			{
				dictionary[text3].Add(text2);
			}
			else
			{
				dictionary.Add(text3, new List<string> { text2 });
			}
			if (!searchForColours)
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
					if (mColoursIds.ContainsKey(key))
					{
						mColoursIds[key].Add(text2);
					}
					else
					{
						mColoursIds.Add(key, new List<string> { text2 });
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
				mDictionary[item2].AddDuplicitTranslation(item.Value);
			}
		}
		AddToDebugMessage($"Dictionary filled and contains {mDictionary.Count} ids\n");
	}

	private void ClearDictionary()
	{
		if (mDictionary == null)
		{
			mDictionary = new Dictionary<string, TranslationRecord>();
		}
		else
		{
			mDictionary.Clear();
		}
		AddToDebugMessage("Dictionary created/cleared.\n");
	}

	private void CheckDictionary(string id, string fileName)
	{
		if (!fileName.EndsWith("TranslationIdFinder.cs"))
		{
			if (!mDictionary.ContainsKey(id))
			{
				mDictionary.Add(id, new TranslationRecord(id));
			}
			mDictionary[id].IncreaseUsage(fileName);
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
		AddToDebugMessage($"Scripts to go through: {files.Length}\n");
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
						CheckDictionary(array4[k], text);
					}
				}
			}
			num++;
		}
		AddToDebugMessage("Scripts search finished.\n");
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
		AddToDebugMessage($"Prefabs to go through: {files.Length} + {files2.Length}\n");
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
					CheckDictionary(text2.Substring(text2.IndexOf(" ID_") + 1), text);
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
					CheckDictionary(text4.Substring(text4.IndexOf(" ID_") + 1), text3);
				}
			}
			num++;
		}
		AddToDebugMessage("Prefabs search finished.\n");
	}

	private void SearchScenes()
	{
		if (!Directory.Exists(mScenesPath))
		{
			Debug.LogError($"Directory \"{mScenesPath}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(mScenesPath, "MainScene.unity", SearchOption.TopDirectoryOnly);
		AddToDebugMessage($"Scenes to go through: {files.Length}\n");
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
					CheckDictionary(text2.Substring(text2.IndexOf(" ID_") + 1), text);
				}
			}
			num++;
		}
		AddToDebugMessage("Scenes search finished.\n");
	}

	private void SearchUseScripts()
	{
		if (!Directory.Exists(mScriptsPath))
		{
			Debug.LogError($"Directory \"{mScriptsPath}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(mScriptsPath, "*.cs", SearchOption.AllDirectories);
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
					if (array4[k] == localizationName)
					{
						AddToDebugMessage($"{num}:{text}\t\t{localizationName}");
					}
				}
			}
		}
	}

	private void SearchUsePrefabs()
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
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains(localizationName))
				{
					AddToDebugMessage($"{text}\t\t{localizationName}");
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
				if (text4.Contains(localizationName))
				{
					AddToDebugMessage($"{text3}\t\t{localizationName}");
				}
			}
		}
	}

	private void SearchUseScenes()
	{
		if (!Directory.Exists(mScenesPath))
		{
			Debug.LogError($"Directory \"{mScenesPath}\" does not exists");
			return;
		}
		string[] files = Directory.GetFiles(mScenesPath, "MainScene.unity", SearchOption.TopDirectoryOnly);
		string[] array = files;
		foreach (string text in array)
		{
			string[] array2 = File.ReadAllLines(text);
			string[] array3 = array2;
			foreach (string text2 in array3)
			{
				if (text2.Contains(localizationName))
				{
					AddToDebugMessage($"{text}\t\t{localizationName}");
				}
			}
		}
	}

	private void WriteConsoleNotUsedIds()
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
		foreach (KeyValuePair<string, TranslationRecord> item in mDictionary)
		{
			if (item.Value.isDuplicitRecord)
			{
				text += $"{item.Value.line}:\t{item.Value.id}\n";
				flag = true;
				continue;
			}
			if (item.Value.numberOfUsage == 0)
			{
				if (FalseNotUsedIds(item.Value.id))
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
				text8 += $"\"{usedInFile.Substring(usedInFile.LastIndexOf(pathDel) + 1)}\"\t";
			}
			if (string.IsNullOrEmpty(item.Value.translation) && item.Value.line < 1)
			{
				if (FalseNotInDictionary(item.Value.id))
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
		if (!searchForColours)
		{
			return;
		}
		string text11 = "These colours are used in IDs:\n";
		foreach (KeyValuePair<string, List<string>> mColoursId in mColoursIds)
		{
			string text12 = string.Empty;
			foreach (string item2 in mColoursId.Value)
			{
				text12 += $"\"{item2}\" ";
			}
			text11 += $"{mColoursId.Key}:\t{text12}\n";
		}
		Debug.Log(text11);
	}

	private bool FalseNotUsedIds(string id)
	{
		if ((id.StartsWith("ID_UNIT") && id.EndsWith("-ABILITY")) || (id.StartsWith("ID_UNIT") && id.EndsWith("-BUFF")) || (id.StartsWith("ID_UNIT") && id.EndsWith("-ABILITYMAXDESC")) || (id.StartsWith("ID_UNIT") && id.EndsWith("-BUFFMAXDESC")) || (id.StartsWith("ID_UNIT") && id.EndsWith("-ELITEPARTS")) || (id.StartsWith("ID_SKILL") && id.EndsWith("_DESC")) || id.StartsWith("ID_STARTERASSIGNMENT") || id.StartsWith("ID_MONTH") || id.StartsWith("ID_HINT") || id.StartsWith("ID_RATEAPPTEXT"))
		{
			return true;
		}
		return false;
	}

	private bool FalseNotInDictionary(string id)
	{
		int result = -1;
		string s = id.Substring(3);
		return int.TryParse(s, out result);
	}

	protected void Update()
	{
		if (startSearch)
		{
			startSearch = false;
			Search();
		}
		if (startSearchUse)
		{
			startSearchUse = false;
			SearchUse();
		}
		if (clearDictionary)
		{
			clearDictionary = false;
			ClearDictionary();
			DebugNumbers();
		}
	}

	private void ClearDebugMessage()
	{
		mDebugMessage = string.Empty;
	}

	private void AddToDebugMessage(string message)
	{
		mDebugMessage = mDebugMessage + message + "\n";
	}

	private void WriteDebugMessage()
	{
		Debug.Log(mDebugMessage);
	}

	private void DebugNumbers()
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
}
