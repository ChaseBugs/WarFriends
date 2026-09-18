using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CodeStage.AntiCheat.Utils;
using Google2u;
using UnityEngine;

namespace CodeStage.AntiCheat.ObscuredTypes
{
public static class ConfigurationSaver
{
	private const string encryptionKey = "e8ah0j6qf6";

	private static string mCachedPath;

	private static readonly StringBuilder mBuffer = new StringBuilder();

	public static void DeleteOldFromPrefs(string className, IEnumerable<string> columnNames)
	{
		ObscuredPrefs.DeleteKey("config_rowIds_" + className);
		ObscuredPrefs.DeleteKey("config_sheetVersion_" + className);
		foreach (string columnName in columnNames)
		{
			ObscuredPrefs.DeleteKey("config_" + className + "_" + columnName);
		}
	}

	private static string EncryptName(string key)
	{
		key = ObscuredString.EncryptDecrypt(key, "e8ah0j6qf6");
		key = Convert.ToBase64String(Encoding.UTF8.GetBytes(key)).Replace('/', '-').Replace('+', '_');
		return key;
	}

	private static byte[] EncryptDecryptBytes(byte[] bytes, int inputLenght, int outputLenght, string key)
	{
		int length = key.Length;
		byte[] array = new byte[outputLenght];
		for (int i = 0; i < inputLenght; i++)
		{
			array[i] = (byte)(bytes[i] ^ key[i % length]);
		}
		return array;
	}

	private static string GetFilePath(string fileName)
	{
		if (mCachedPath == null)
		{
			mCachedPath = Application.persistentDataPath + "/cData/";
			if (!Directory.Exists(mCachedPath))
			{
				Directory.CreateDirectory(mCachedPath);
				SetNoBackupFlag(mCachedPath);
			}
		}
		return $"{mCachedPath}{fileName}.dat";
	}

	private static void WriteDataToFile(StreamWriter fs, string inputData, string name)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(inputData);
		int num = bytes.Length;
		byte[] array = EncryptDecryptBytes(bytes, num, num + 4, name + "e8ah0j6qf6");
		uint num2 = xxHash.CalculateHash(bytes, num);
		array[num] = (byte)(num2 & 0xFF);
		array[num + 1] = (byte)((num2 >> 8) & 0xFF);
		array[num + 2] = (byte)((num2 >> 16) & 0xFF);
		array[num + 3] = (byte)((num2 >> 24) & 0xFF);
		fs.WriteLine(Convert.ToBase64String(array));
	}

	public static void SaveSheetToFile(string className, List<string> rowIDs, string sheetVersion, Dictionary<string, bool> columnNames, List<List<string>> preparedRows)
	{
		string text = "config_data_" + className;
		string filePath = GetFilePath(EncryptName(text));
		using (StreamWriter fs = File.CreateText(filePath))
		{
			WriteDataToFile(fs, sheetVersion + ";" + columnNames.Count, text + "versions");
			mBuffer.Length = 0;
			for (int i = 0; i < rowIDs.Count; i++)
			{
				mBuffer.Append(rowIDs[i]);
				mBuffer.Append(";");
			}
			WriteDataToFile(fs, mBuffer.ToString(), text + "titles");
			int num = 0;
			foreach (KeyValuePair<string, bool> columnName in columnNames)
			{
				mBuffer.Length = 0;
				mBuffer.Append(columnName.Key);
				mBuffer.Append(";");
				for (int j = 0; j < preparedRows.Count; j++)
				{
					mBuffer.Append(preparedRows[j][num]);
					mBuffer.Append(";");
				}
				WriteDataToFile(fs, mBuffer.ToString(), text + num + "data");
				num++;
			}
		}
		SetNoBackupFlag(filePath);
	}

	private static string ReadDecryptedString(StreamReader fs, string name)
	{
		string text = fs.ReadLine();
		if (text == null)
		{
			return null;
		}
		byte[] array = Convert.FromBase64String(text);
		int num = array.Length;
		int num2 = num - 4;
		if (num < 4)
		{
			return null;
		}
		uint num3 = (uint)(array[num - 4] | (array[num - 3] << 8) | (array[num - 2] << 16) | (array[num - 1] << 24));
		byte[] array2 = EncryptDecryptBytes(array, num2, num2, name + "e8ah0j6qf6");
		uint num4 = xxHash.CalculateHash(array2, num2);
		if (num4 != num3)
		{
			Debug.LogErrorFormat("wrong hash for {0} - {1} != {2}", name, num4, num3);
			ObscuredPrefs.SavesTampered();
			return string.Empty;
		}
		return Encoding.UTF8.GetString(array2);
	}

	public static bool IsFileExist(string className)
	{
		bool flag = false;
		try
		{
			string key = "config_data_" + className;
			string filePath = GetFilePath(EncryptName(key));
			return File.Exists(filePath);
		}
		catch (Exception)
		{
			Debug.LogErrorFormat("exception during deleting old config file {0}", className);
			return false;
		}
	}

	public static void DeleteFile(string className)
	{
		try
		{
			string key = "config_data_" + className;
			string filePath = GetFilePath(EncryptName(key));
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
		}
		catch (Exception)
		{
			Debug.LogErrorFormat("exception during deleting old config file {0}", className);
		}
	}

	public static bool LoadConfigFromFile(string className, Google2uComponentBase sheet, string sheetVersion)
	{
		string text = "config_data_" + className;
		string filePath = GetFilePath(EncryptName(text));
		bool result = true;
		try
		{
			using (StreamReader fs = File.OpenText(filePath))
			{
			string text2 = ReadDecryptedString(fs, text + "versions");
			if (text2 == null)
			{
				return false;
			}
			if (text2 == string.Empty)
			{
				return true;
			}
			int num = text2.LastIndexOf(';');
			if (num < 1)
			{
				return false;
			}
			string s = text2.Substring(num + 1);
			int result2 = 0;
			if (!int.TryParse(s, out result2))
			{
				return false;
			}
			text2 = text2.Substring(0, num);
			if (text2 != sheetVersion)
			{
				string message = $"Wrong data for sheet {className} saved version is {text2} and should be {sheetVersion}";
				Crittercism.LogHandledException(new Exception(message));
				Debug.LogError(message);
				return false;
			}
			string text3 = ReadDecryptedString(fs, text + "titles");
			if (text3 == null)
			{
				return false;
			}
			if (text3 == string.Empty)
			{
				return true;
			}
			List<string> list = new List<string>();
			num = 0;
			int num2 = text3.IndexOf(';', num);
			while (num2 > 0)
			{
				string item = text3.Substring(num, num2 - num);
				list.Add(item);
				num = num2 + 1;
				num2 = ((num >= text3.Length) ? (-1) : text3.IndexOf(';', num));
				if (num2 < 0 && num < text3.Length)
				{
					num2 = text3.Length;
				}
			}
			foreach (string item2 in list)
			{
				int rowIndex = sheet.GetRowIndex(item2);
				if (rowIndex < 0)
				{
					sheet.AddBlanckRowGeneric(item2);
				}
			}
			int num3 = 0;
			string text4 = null;
			while ((text4 = ReadDecryptedString(fs, text + num3 + "data")) != null)
			{
				if (text4 == null)
				{
					return false;
				}
				if (text4 == string.Empty)
				{
					return true;
				}
				num = 0;
				num2 = text4.IndexOf(';', num);
				if (num2 > 0)
				{
					string text5 = text4.Substring(num, num2 - num);
					if (sheet.HasColumn(text5))
					{
						num = num2 + 1;
						num2 = text4.IndexOf(';', num);
						int num4 = 0;
						while (num2 > 0)
						{
							if (num4 >= list.Count)
							{
								Debug.LogError($"column {text5} in sheet {className} has more saved records than IDs");
								break;
							}
							int rowIndex2 = sheet.GetRowIndex(list[num4]);
							if (rowIndex2 < 0)
							{
								Debug.LogError($"column {text5} in sheet {className} has mismach in saved data");
								break;
							}
							if (rowIndex2 < sheet.RowsGeneric.Count)
							{
								string text6 = text4.Substring(num, num2 - num);
								object value = sheet.GetValue(rowIndex2, text5);
								if (value == null || value.ToString() != text6)
								{
									sheet.SetValue(rowIndex2, text5, text6);
								}
								num4++;
								num = num2 + 1;
								num2 = ((num >= text4.Length) ? (-1) : text4.IndexOf(';', num));
								if (num2 < 0 && num < text4.Length)
								{
									num2 = text4.Length;
								}
								continue;
							}
							Debug.LogError($"column {text5} in sheet {className} has more saved records");
							break;
						}
					}
				}
				num3++;
			}
			if (result2 != num3)
			{
				Debug.LogErrorFormat("sheet {0} hawe saved wrong collumn count {1} instead {2}", className, num3, sheet.getColumnCount);
				result = false;
			}
				}
}
		catch (Exception ex)
		{
			string message2 = $"Exception - parse sheet {className}: {ex.Message}";
			Crittercism.LogHandledException(new Exception(message2));
			Debug.LogError(message2);
			Debug.LogError(ex.StackTrace);
			return false;
		}
		return result;
	}

	private static void SetNoBackupFlag(string filePath)
	{
	}
}
}
