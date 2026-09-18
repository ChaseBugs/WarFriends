using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Beebyte.Obfuscator;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

[Skip]
public class GameConfigurationManager : InGameSerializedObjectGeneric<GameConfigurationManager.ConfigurationData>
{
	[Skip]
	public class ConfigurationData
	{
		public List<string> classesNames = new List<string>();

		public string clientVersion = string.Empty;

		public DatabaseEnvironment enviroment = DatabaseEnvironment.Production;

		public string sheetConfiguration = "0";

		public Dictionary<string, string> sheetVersions;
	}

	[Serializable]
	public class SheetData
	{
		public string id;

		public string version;
	}

	private static readonly List<string> mSheetBuffer = new List<string>();

	private static string mCache;

	private readonly StringBuilder mBuffer = new StringBuilder(100);

	public string initClientVersion;

	public DatabaseEnvironment initDatabaseEnvironment;

	public string initSheetConfiguration;

	public List<SheetData> initSheetVersions;

	private Google2uComponentBase[] mAllSheets;

	private bool mConfigsRecived;

	private string mResponseString;

	private readonly string mSheetPrefix = "Google2u.";

	public Dictionary<string, Google2uComponentBase> sheetsDictionary = new Dictionary<string, Google2uComponentBase>();

	private static GameConfigurationManager mInstance;

	public Google2uComponentBase[] sheets
	{
		get
		{
			if (mAllSheets == null || mAllSheets.Length == 0)
			{
				mAllSheets = UnityEngine.Object.FindObjectsOfType<Google2uComponentBase>();
				Dictionary<Type, int> dictionary = new Dictionary<Type, int>();
				Google2uComponentBase[] array = mAllSheets;
				foreach (Google2uComponentBase google2uComponentBase in array)
				{
					Type type = google2uComponentBase.GetType();
					if (!dictionary.ContainsKey(type))
					{
						dictionary[type] = 1;
						sheetsDictionary[type.ToString()] = google2uComponentBase;
						continue;
					}
					Dictionary<Type, int> dictionary3;
					Dictionary<Type, int> dictionary2 = (dictionary3 = dictionary);
					Type key2;
					Type key = (key2 = type);
					int num = dictionary3[key2];
					dictionary2[key] = num + 1;
				}
				foreach (KeyValuePair<Type, int> item in dictionary)
				{
					if (item.Value != 1)
					{
						Debug.LogError($"Configurations error, there is {item.Value} configurations of type {item.Key}");
					}
				}
			}
			return mAllSheets;
		}
	}

	private bool isInitEnviromentSame
	{
		get
		{
			if (initDatabaseEnvironment == DatabaseEnvironment.DevelopmentSvk && Singleton<BeanstalkServerManager>.instance.environment == initDatabaseEnvironment)
			{
				return true;
			}
			if (Singleton<BeanstalkServerManager>.instance.environment == DatabaseEnvironment.DevelopmentSvk)
			{
				return false;
			}
			return true;
		}
	}

	public static GameConfigurationManager instance
	{
		get
		{
			mInstance = mInstance ?? ((GameConfigurationManager)UnityEngine.Object.FindObjectsOfType(typeof(GameConfigurationManager))[0]);
			return mInstance;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Google2uComponentBase[] array = sheets;
		foreach (Google2uComponentBase google2uComponentBase in array)
		{
			string className = google2uComponentBase.GetType().ToString();
			ConfigurationSaver.DeleteOldFromPrefs(className, google2uComponentBase.columnNames);
		}
		if (data != null && data.classesNames != null && data.classesNames.Count > 0)
		{
			for (int num = data.classesNames.Count - 1; num >= 0; num--)
			{
				string className2 = data.classesNames[num];
				if (!ConfigurationSaver.IsFileExist(className2))
				{
					data.sheetVersions = null;
					break;
				}
			}
		}
		if (data.sheetVersions != null && data.enviroment != Singleton<BeanstalkServerManager>.instance.environment)
		{
			Debug.Log($"Configarations enviromend changed, saved: {data.enviroment}, current {Singleton<BeanstalkServerManager>.instance.environment}");
			InitSheetVersions(forceDownload: true);
		}
		if (data.sheetVersions != null)
		{
			CheckNewConfigsInClient();
		}
		else
		{
			InitSheetVersions();
			Save();
		}
		Google2uComponentBase[] array2 = sheets;
	}

	private void CheckNewConfigsInClient()
	{
		Google2uComponentBase[] array = sheets;
		foreach (Google2uComponentBase google2uComponentBase in array)
		{
			string text = StripGoogleFu(google2uComponentBase.GetType().ToString());
			if (!data.sheetVersions.ContainsKey(text))
			{
				data.sheetVersions[text] = ((!isInitEnviromentSame) ? "-1" : GetInitSheetVersion(text).ToString());
				Debug.Log($"Client has new config for: {text} with version {data.sheetVersions[text]}");
			}
		}
		if (!isInitEnviromentSame)
		{
			return;
		}
		bool flag = false;
		if (Singleton<CurrentBundleVersion>.instance.shortVersion == initClientVersion)
		{
			if (data.clientVersion != initClientVersion)
			{
				Debug.Log($"Client is newer, configs stored for: {data.clientVersion} and new version is {initClientVersion} init sheet config {initSheetConfiguration}, current bundle version {Singleton<CurrentBundleVersion>.instance.shortVersion}");
				data.clientVersion = initClientVersion;
				data.sheetConfiguration = initSheetConfiguration;
				flag = true;
			}
		}
		else if (data.clientVersion != Singleton<CurrentBundleVersion>.instance.shortVersion)
		{
			Debug.Log($"Client has no suitable init configs, RESETING, configs stored for: {data.clientVersion} and new version is {initClientVersion} init sheet config {initSheetConfiguration}, curent bundle version {Singleton<CurrentBundleVersion>.instance.shortVersion}");
			flag = true;
			data.clientVersion = Singleton<CurrentBundleVersion>.instance.shortVersion;
			data.sheetConfiguration = "0";
		}
		List<string> list = new List<string>(data.sheetVersions.Keys);
		foreach (string item in list)
		{
			int num = int.Parse(data.sheetVersions[item]);
			int initSheetVersion = GetInitSheetVersion(item);
			if (initSheetVersion >= num)
			{
				if (initSheetVersion > num)
				{
					Debug.Log($"Client has newer config for: {item} Saved version {num} Client version {initSheetVersion}");
				}
				data.sheetVersions[item] = initSheetVersion.ToString();
			}
			if (flag)
			{
				ConfigurationSaver.DeleteFile(GetClassName(item));
			}
		}
		Save();
	}

	private int GetInitSheetVersion(string sheetName)
	{
		if (initSheetVersions != null)
		{
			foreach (SheetData initSheetVersion in initSheetVersions)
			{
				if (initSheetVersion.id == sheetName)
				{
					return int.Parse(initSheetVersion.version);
				}
			}
		}
		return -1;
	}

	private void InitSheetVersions(bool forceDownload = false)
	{
		data.sheetVersions = new Dictionary<string, string>();
		data.enviroment = Singleton<BeanstalkServerManager>.instance.environment;
		data.sheetConfiguration = ((!forceDownload && isInitEnviromentSame) ? initSheetConfiguration : "0");
		data.clientVersion = Singleton<CurrentBundleVersion>.instance.shortVersion;
		data.classesNames = new List<string>();
		Google2uComponentBase[] array = sheets;
		foreach (Google2uComponentBase google2uComponentBase in array)
		{
			string text = StripGoogleFu(google2uComponentBase.GetType().ToString());
			data.sheetVersions[text] = "-1";
			if (!forceDownload && isInitEnviromentSame)
			{
				data.sheetVersions[text] = GetInitSheetVersion(text).ToString();
			}
		}
		Save();
	}

	internal void UpdateConfigurationsNew(string response)
	{
		mResponseString = response;
		mConfigsRecived = true;
	}

	private string StripGoogleFu(string input)
	{
		return (!input.StartsWith(mSheetPrefix)) ? input : input.Substring(mSheetPrefix.Length);
	}

	private void OnPlayerPrefsHack()
	{
		Debug.LogError("Configurations hacked");
		ReDownload(forceDownloadAll: true);
	}

	public IEnumerator PrepareConfigurations()
	{
		ObscuredPrefs.onAlterationDetected += OnPlayerPrefsHack;
		while (!mConfigsRecived)
		{
			yield return null;
		}
		mConfigsRecived = false;
		Dictionary<string, bool> recievedSheets = new Dictionary<string, bool>();
		if (mResponseString != null)
		{
			StringBuilder responseBuffer = new StringBuilder();
			JToken newConfigurationVersions = new JObject();
			int cnt = 0;
			string configurationVersion = "0";
			for (int index = 0; index < mResponseString.Length; index++)
			{
				char character = mResponseString[index];
				if (character == ';' || index == mResponseString.Length - 1)
				{
					cnt++;
					if (index == mResponseString.Length - 1 && character != ';')
					{
						responseBuffer.Append(character);
					}
					if (cnt == 1)
					{
						Debug.Log("Checking success string: " + responseBuffer);
						if (!"success".Equals(responseBuffer.ToString()))
						{
							Debug.LogError("Error while parsing response from GetConfigurations, will try again next run");
							break;
						}
					}
					else
					{
						switch (cnt)
						{
						case 2:
							configurationVersion = responseBuffer.ToString();
							data.sheetConfiguration = configurationVersion;
							Debug.LogWarningFormat("Recieved from server CONFIGURATIONS: {0}-{1}", Singleton<CurrentBundleVersion>.instance.shortVersion, data.sheetConfiguration);
							break;
						case 3:
							newConfigurationVersions = JsonConvert.DeserializeObject<JToken>(responseBuffer.ToString());
							break;
						default:
						{
							if (cnt == 3)
							{
								LoadingDialog.ShowLoading(Localization.Localize("ID_PARSING_CONFIGURATIONS"));
							}
							JToken item = JsonConvert.DeserializeObject<JToken>(responseBuffer.ToString());
							if (item is JObject && item["Localization"] != null)
							{
								Singleton<OfferManager>.instance.SetPacknames(item["Localization"]);
								responseBuffer.Length = 0;
								continue;
							}
							if (item is JArray || item["Id"]["S"] == null || item["Data"] == null || item["Data"]["L"] == null)
							{
								responseBuffer.Length = 0;
								continue;
							}
							string sheetId = (string)item["Id"]["S"];
							sheetId = sheetId.Replace("Client_", string.Empty);
							string sheetVersion = string.Empty;
							if (newConfigurationVersions[sheetId] != null)
							{
								JToken tmp = newConfigurationVersions[sheetId];
								if (tmp["N"] != null)
								{
									sheetVersion = tmp["N"].ToString();
									data.sheetVersions[sheetId] = sheetVersion;
								}
							}
							JToken configData = item["Data"]["L"];
							List<string> rowIds = null;
							if (item["RowIDs"] != null && item["RowIDs"]["L"] != null)
							{
								rowIds = new List<string>();
								JToken rowData = item["RowIDs"]["L"];
								foreach (JToken obj in rowData.Children())
								{
									rowIds.Add((string)obj["S"]);
								}
							}
							foreach (JToken obj2 in configData.Children())
							{
								mSheetBuffer.Add((string)obj2["S"]);
							}
							string className = GetClassName(sheetId);
							recievedSheets[className] = true;
							if (item["ColumnNames"] != null)
							{
								UpdateSheetInGame(className, mSheetBuffer, (string)item["ColumnNames"]["S"], rowIds, sheetVersion, configurationVersion);
							}
							else
							{
								Debug.LogError("Configuration Error: sheet " + className + " error (no ColumnNames)");
							}
							mSheetBuffer.Clear();
							yield return new WaitForEndOfFrame();
							yield return new WaitForEndOfFrame();
							break;
						}
						}
					}
					responseBuffer.Length = 0;
				}
				else
				{
					responseBuffer.Append(character);
				}
			}
			try
			{
				string str = "============SHEETS RECIEVED===========\n";
				foreach (KeyValuePair<string, bool> recievedSheet in recievedSheets)
				{
					string text = str;
					str = text + recievedSheet.Key + ";" + data.sheetVersions[StripGoogleFu(recievedSheet.Key)] + "\n";
				}
				Debug.Log(str);
			}
			catch (Exception ex)
			{
				Exception exception = ex;
				Debug.LogError("Exception while processing received sheets: " + exception.Message);
			}
		}
		mResponseString = null;
		Save();
		string dbgStr = string.Empty;
		Debug.Log("NEW CONFIG WILL BE LOADED FROM PREFS:");
		for (int i = 0; i < data.classesNames.Count; i++)
		{
			string className2 = data.classesNames[i];
			if (recievedSheets.ContainsKey(className2))
			{
				continue;
			}
			Google2uComponentBase[] array = sheets;
			foreach (Google2uComponentBase sheet in array)
			{
				string sheetName = sheet.GetType().ToString();
				if (sheetName == className2)
				{
					dbgStr = dbgStr + className2 + "\n";
					string sheetVersion2 = string.Empty;
					string strippedName = StripGoogleFu(sheetName);
					data.sheetVersions.TryGetValue(strippedName, out sheetVersion2);
					if (!ConfigurationSaver.LoadConfigFromFile(className2, sheet, sheetVersion2))
					{
						instance.ReDownload(forceDownloadAll: false);
					}
					break;
				}
			}
			mCache = new string(new char[0]);
			yield return new WaitForEndOfFrame();
		}
		Debug.Log("Loaded from prefs: " + dbgStr);
		ObscuredPrefs.onAlterationDetected -= OnPlayerPrefsHack;
	}

	private void ReDownload(bool forceDownloadAll)
	{
		mResponseString = null;
		ObscuredPrefs.onAlterationDetected -= OnPlayerPrefsHack;
		InitSheetVersions(forceDownloadAll);
		StopAllCoroutines();
		Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
		GameLoginManager.Relog();
	}

	private Dictionary<string, bool> ParseSheetColumnNames(string columnString)
	{
		Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < columnString.Length; i++)
		{
			char c = columnString[i];
			if (c == '/' || i == columnString.Length - 1)
			{
				if (i == columnString.Length - 1 && c != '/')
				{
					stringBuilder.Append(c);
				}
				dictionary[stringBuilder.ToString()] = true;
				stringBuilder.Length = 0;
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return dictionary;
	}

	private List<string> ParseRowValues(string rowString)
	{
		List<string> list = new List<string>();
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < rowString.Length; i++)
		{
			char c = rowString[i];
			if (c == '/' || i == rowString.Length - 1)
			{
				if (i == rowString.Length - 1 && c != '/')
				{
					stringBuilder.Append(c);
				}
				list.Add(stringBuilder.ToString());
				stringBuilder.Length = 0;
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		if (rowString[rowString.Length - 1] == '/')
		{
			list.Add(string.Empty);
		}
		return list;
	}

	private Google2uComponentBase GetSheet(string className)
	{
		Google2uComponentBase[] array = sheets;
		foreach (Google2uComponentBase google2uComponentBase in array)
		{
			string text = google2uComponentBase.GetType().ToString();
			if (text == className)
			{
				return google2uComponentBase;
			}
		}
		return null;
	}

	private void UpdateSheetInGame(string className, List<string> rows, string columnNamesString, List<string> rowIDs, string sheetVersion, string configurationsVersion)
	{
		Dictionary<string, bool> dictionary = ParseSheetColumnNames(columnNamesString);
		className = className.Replace("Client_", string.Empty);
		Google2uComponentBase sheet = GetSheet(className);
		List<List<string>> list = new List<List<string>>();
		if (sheet != null && sheet.haveDictionary)
		{
			if (rowIDs == null)
			{
				Debug.LogError("No row IDs gained from server for new item config download: " + className);
				return;
			}
			if (rows.Count != rowIDs.Count)
			{
				Debug.LogError("No row IDs count not match with row count for: " + className);
				return;
			}
			for (int i = 0; i < rows.Count; i++)
			{
				List<string> list2 = ParseRowValues(rows[i]);
				list.Add(list2);
				int rowIndex = sheet.GetRowIndex(rowIDs[i]);
				if (list2.Count == dictionary.Count)
				{
					if (rowIndex < 0)
					{
						List<string> list3 = new List<string>();
						list3.Add(rowIDs[i]);
						for (int j = 0; j < list2.Count; j++)
						{
							list3.Add(list2[j]);
						}
						int num = sheet.AddRowGenericRealyAdd(list3);
						if (num < 0)
						{
							Debug.LogError("error in creating new row in: " + className + " with error code: " + num);
							break;
						}
						continue;
					}
					int num2 = 0;
					foreach (KeyValuePair<string, bool> item in dictionary)
					{
						string text = list2[num2++];
						if (sheet.HasColumn(item.Key))
						{
							object value = sheet.GetValue(rowIndex, item.Key);
							if (value == null || value.ToString() != text)
							{
								sheet.SetValue(rowIndex, item.Key, text);
							}
						}
						else
						{
							Debug.LogWarning($"Error - sheet {className} doesnt have column {item.Key}");
						}
					}
				}
				else
				{
					Debug.LogError($"Error - wrong column names and values count ({dictionary.Count} != {list2.Count}) for sheet {className}");
					Debug.LogError(columnNamesString);
					Debug.LogError(rows[i]);
				}
			}
		}
		SaveSheetToPrefs(className, rowIDs, sheetVersion, dictionary, list);
	}

	private void SaveSheetToPrefs(string className, List<string> rowIDs, string sheetVersion, Dictionary<string, bool> columnNames, List<List<string>> preparedRows)
	{
		ConfigurationSaver.SaveSheetToFile(className, rowIDs, sheetVersion, columnNames, preparedRows);
		if (!data.classesNames.Contains(className))
		{
			data.classesNames.Add(className);
		}
	}

	public void UpdateSheet(string className, List<Dictionary<string, string>> rows, bool save = false)
	{
		Google2uComponentBase[] array = sheets;
		foreach (Google2uComponentBase google2uComponentBase in array)
		{
			string text = google2uComponentBase.GetType().ToString();
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
			if (!(text == className))
			{
				continue;
			}
			for (int j = 0; j < rows.Count; j++)
			{
				if (j < google2uComponentBase.RowsGeneric.Count)
				{
					Dictionary<string, string> dictionary2 = rows[j];
					foreach (KeyValuePair<string, string> item in dictionary2)
					{
						if (google2uComponentBase.HasColumn(item.Key))
						{
							string text2 = google2uComponentBase.GetValue(j, item.Key).ToString();
							if (text2 != item.Value)
							{
								google2uComponentBase.SetValue(j, item.Key, item.Value);
							}
						}
						if (!google2uComponentBase.HasColumn(item.Key))
						{
							Debug.LogError($"Error - sheet {text} doesnt have column {item.Key}");
						}
						dictionary[item.Key] = true;
					}
					continue;
				}
				Debug.LogError(string.Concat("Error in loading configuration for ", google2uComponentBase.GetType(), ", there is more records on server than on client (records missing = ", rows.Count - j, ")"));
				break;
			}
		}
	}

	private string GetClassName(string sheetId)
	{
		return mSheetPrefix + sheetId;
	}

	internal void GetConfigurations(string configVariant)
	{
		LoadingDialog.ShowLoading(Localization.Localize("ID_DOWNLOADING_CONFIGURATIONS"));
		Singleton<BeanstalkServerManager>.instance.GetConfigurations(data.sheetConfiguration, configVariant);
	}

	public static string GetAllConfigsJson()
	{
		Google2uComponentBase[] array = UnityEngine.Object.FindObjectsOfType<Google2uComponentBase>();
		List<string> list = new List<string>();
		if (array != null)
		{
			Google2uComponentBase[] array2 = array;
			foreach (Google2uComponentBase google2uComponentBase in array2)
			{
				list.Add(google2uComponentBase.GetType().ToString());
			}
		}
		return JsonConvert.SerializeObject(list);
	}

	public void OnDestroy()
	{
		mInstance = null;
	}
}
