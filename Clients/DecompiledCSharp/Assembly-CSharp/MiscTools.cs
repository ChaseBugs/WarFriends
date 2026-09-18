using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

public static class MiscTools
{
	public enum AXIS
	{
		x,
		y,
		z
	}

	public const float MEMORY_DIVIDER = 1048576f;

	public static List<List<int>> permutationsOfFOur;

	public static DateTime mZeroTIme;

	private static CultureInfo englishCulture;

	private static CultureInfo islandCulture;

	private static CultureInfo frenchCulture;

	private static int[] swArr;

	public static DateTime zeroTime => mZeroTIme;

	public static string infoButtonSprite => "menu-info-ico";

	public static string closeButtonSprite => "menu-info-close-ico";

	static MiscTools()
	{
		permutationsOfFOur = new List<List<int>>();
		mZeroTIme = new DateTime(1970, 1, 1, 0, 0, 0);
		englishCulture = new CultureInfo("en-US");
		islandCulture = new CultureInfo("is-IS");
		frenchCulture = new CultureInfo("fr-FR");
		swArr = new int[64]
		{
			17, 22, 31, 52, 35, 16, 23, 57, 3, 38,
			37, 2, 48, 0, 51, 61, 4, 7, 30, 14,
			60, 49, 13, 62, 36, 24, 44, 43, 46, 28,
			56, 1, 27, 10, 21, 25, 8, 12, 58, 39,
			53, 5, 41, 47, 33, 63, 55, 32, 50, 6,
			9, 54, 59, 15, 29, 40, 11, 26, 18, 34,
			20, 42, 45, 19
		};
		int[] values = new int[4] { 0, 1, 2, 3 };
		IEnumerable<int[]> enumerable = Permutations(values);
		foreach (int[] item in enumerable)
		{
			List<int> list = new List<int>();
			list.AddRange(item);
			permutationsOfFOur.Add(list);
		}
	}

	public static int ConvertTimeIntoGold(int seconds)
	{
		if (seconds <= 0)
		{
			return 0;
		}
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCoefficient).FLOATVALUE;
		ObscuredFloat fLOATVALUE2 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldExpCoefficient).FLOATVALUE;
		float num = (float)seconds / 60f;
		return Convert.ToInt32(Math.Ceiling((double)(float)fLOATVALUE * Math.Pow(num, (float)fLOATVALUE2) * (double)num));
	}

	public static int ConvertTicketsIntoGold(long tickets)
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TicketsToGold).FLOATVALUE;
		return (int)(float)fLOATVALUE * (int)tickets;
	}

	public static DateTime GetDateTime(int timeSpan)
	{
		return zeroTime + new TimeSpan(0, 0, timeSpan);
	}

	public static int GetTimeInt(DateTime time)
	{
		return (int)(time - zeroTime).TotalSeconds;
	}

	public static GameObject InstantiateAsChild(GameObject o, GameObject parent)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(o, Vector3.zero, Quaternion.identity);
		Vector3 localScale = gameObject.transform.localScale;
		gameObject.transform.parent = parent.transform;
		gameObject.transform.localScale = localScale;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.rotation = o.transform.rotation;
		return gameObject;
	}

	public static Vector3 MultiplyVectors(Vector3 vct1, Vector3 vct2)
	{
		return new Vector3(vct1.x * vct2.x, vct1.y * vct2.y, vct1.z * vct2.z);
	}

	public static T GetLastElementOfList<T>(List<T> list)
	{
		return list[list.Count - 1];
	}

	public static T GetFirstElementOfList<T>(List<T> list)
	{
		return list[0];
	}

	public static List<T> AddElementsToEndOfList<T>(List<T> destination, List<T> source)
	{
		foreach (T item in source)
		{
			destination.Add(item);
		}
		return destination;
	}

	public static void PrintArray<T>(IEnumerable<T> list, string name)
	{
		string text = name + " ";
		int num = 0;
		foreach (T item in list)
		{
			string text2 = text;
			text = string.Concat(text2, "[", num, "]=", item, ",  ");
			num++;
		}
		Debug.Log(text);
	}

	public static void FreezeRigidbody(Rigidbody rigidbody)
	{
		rigidbody.constraints = RigidbodyConstraints.FreezeAll;
	}

	public static void UnfreezeRigidbody(Rigidbody rigidbody)
	{
		rigidbody.constraints = (RigidbodyConstraints)56;
	}

	public static bool IsRigidbodyFreezed(Rigidbody rigidbody)
	{
		return rigidbody.constraints == RigidbodyConstraints.FreezeAll;
	}

	public static void ShootOff(GameObject go, Vector3 direction, float strength)
	{
		Rigidbody component = go.GetComponent<Rigidbody>();
		UnfreezeRigidbody(component);
		component.velocity = new Vector3(0f, 0f, 0f);
		component.AddForce(Vector3.Normalize(direction) * strength);
		component.useGravity = true;
	}

	public static void ShootOffRelativeToMass(GameObject go, Vector3 direction, float strength)
	{
		Rigidbody component = go.GetComponent<Rigidbody>();
		UnfreezeRigidbody(component);
		component.velocity = new Vector3(0f, 0f, 0f);
		component.AddForce(Vector3.Normalize(direction) * strength * component.mass);
		component.useGravity = true;
	}

	public static void BroadcastAll(string fun, object msg)
	{
		GameObject[] array = (GameObject[])UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if ((bool)gameObject && gameObject.transform.parent == null)
			{
				gameObject.gameObject.BroadcastMessage(fun, msg, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public static void InvokeAfter(MonoBehaviour o, Action a, float seconds)
	{
		o.StartCoroutine(WaitAndCall(a, seconds));
	}

	private static IEnumerator WaitAndCall(Action a, float seconds)
	{
		yield return new WaitForSeconds(seconds);
		a();
	}

	public static bool IsPowerOfTwo(int x)
	{
		return (x & (x - 1)) == 0;
	}

	public static int GetNearestUpperPowerOfTwo(int n)
	{
		int num = (int)Math.Log(n, 2.0);
		double num2 = Math.Pow(2.0, num);
		double num3 = Math.Pow(2.0, num + 1);
		return (!(num2 >= (double)n)) ? ((int)num3) : ((int)num2);
	}

	public static float GetRadianAngleBetweenPoints(Vector3 pt1, Vector3 pt2)
	{
		return Mathf.Atan2(pt2.y - pt1.y, pt2.x - pt1.x);
	}

	public static float GetDegreeAngleBetweenPoints(Vector3 pt1, Vector3 pt2)
	{
		return GetRadianAngleBetweenPoints(pt1, pt2) * 57.29578f;
	}

	public static Vector3 GetRelativePoint(Vector3 src, float distance, float angle)
	{
		return new Vector3(src.x + Mathf.Cos(angle) * distance, src.y + Mathf.Sin(angle) * distance, src.z);
	}

	public static SortedList<GameObject, double> GetOrderedBy(MonoBehaviour[] gameObjects, AXIS axis)
	{
		List<GameObject> list = new List<GameObject>();
		foreach (MonoBehaviour monoBehaviour in gameObjects)
		{
			list.Add(monoBehaviour.gameObject);
		}
		return GetOrderedBy(list.ToArray(), axis);
	}

	public static SortedList<GameObject, double> GetOrderedBy(GameObject[] gameObjects, AXIS axis)
	{
		SortedList<GameObject, double> sortedList = new SortedList<GameObject, double>();
		foreach (GameObject gameObject in gameObjects)
		{
			switch (axis)
			{
			case AXIS.x:
				sortedList.Add(gameObject, gameObject.transform.position.x);
				break;
			case AXIS.y:
				sortedList.Add(gameObject, gameObject.transform.position.y);
				break;
			case AXIS.z:
				sortedList.Add(gameObject, gameObject.transform.position.z);
				break;
			}
		}
		return sortedList;
	}

	public static Texture2D resizeTexturecustomFilter(Texture2D texture, int width, int height)
	{
		texture.filterMode = FilterMode.Bilinear;
		Texture2D texture2D = new Texture2D(width, height, TextureFormat.ARGB32, mipmap: true);
		texture2D.filterMode = FilterMode.Bilinear;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				Color pixel = texture.GetPixel(i * 2, j * 2);
				Color pixel2 = texture.GetPixel(i * 2 + 1, j * 2);
				Color pixel3 = texture.GetPixel(i * 2, j * 2 + 1);
				Color pixel4 = texture.GetPixel(i * 2 + 1, j * 2 + 1);
				texture2D.SetPixel(i, j, Average(pixel, pixel2, pixel3, pixel4));
			}
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogWarning("resizing texture " + texture.name + "to " + width + " x " + height);
		}
		texture2D.Apply(updateMipmaps: true);
		return texture2D;
	}

	public static Color[] resizeHalfTexturecustomFilter(Texture2D texture)
	{
		int width = texture.width;
		int height = texture.height;
		Color[] array = new Color[width / 2 * (height / 2)];
		for (int i = 0; i < width / 2; i++)
		{
			for (int j = 0; j < height / 2; j++)
			{
				Color pixel = texture.GetPixel(i * 2, j * 2);
				Color pixel2 = texture.GetPixel(i * 2 + 1, j * 2);
				Color pixel3 = texture.GetPixel(i * 2, j * 2 + 1);
				Color pixel4 = texture.GetPixel(i * 2 + 1, j * 2 + 1);
				ref Color reference = ref array[flatten(i, j, width / 2)];
				reference = Average(pixel, pixel2, pixel3, pixel4);
			}
		}
		if (Debug.isDebugBuild)
		{
			Debug.LogWarning("resizing texture " + texture.name + "to " + width + " x " + height);
		}
		return array;
	}

	public static Color[] resizeHalfTexturecustomFilter(ref Color[] colors, int width, int height)
	{
		Color[] array = new Color[width / 2 * (height / 2)];
		for (int i = 0; i < width / 2; i++)
		{
			for (int j = 0; j < height / 2; j++)
			{
				Color c = colors[flatten(i * 2, j * 2, width)];
				Color c2 = colors[flatten(i * 2 + 1, j * 2, width)];
				Color c3 = colors[flatten(i * 2, j * 2 + 1, width)];
				Color c4 = colors[flatten(i * 2 + 1, j * 2 + 1, width)];
				ref Color reference = ref array[flatten(i, j, width / 2)];
				reference = Average(c, c2, c3, c4);
			}
		}
		return array;
	}

	private static int flatten(int x, int y, int width)
	{
		return y * width + x;
	}

	public static Color Average(Color c1, Color c2, Color c3, Color c4)
	{
		float r = (c1.r + c2.r + c3.r + c4.r) * 0.25f;
		float g = (c1.g + c2.g + c3.g + c4.g) * 0.25f;
		float b = (c1.b + c2.b + c3.b + c4.b) * 0.25f;
		float a = (c1.a + c2.a + c3.a + c4.a) * 0.25f;
		return new Color(r, g, b, a);
	}

	public static Texture2D resizeTexture(Texture2D texture, int width, int height)
	{
		Color[] pixels = texture.GetPixels(1);
		texture.Resize(width, height);
		texture.SetPixels(pixels);
		texture.Apply();
		if (Debug.isDebugBuild)
		{
			Debug.LogWarning("resizing texture " + texture.name + "to " + width + " x " + height);
		}
		GC.WaitForPendingFinalizers();
		Array.Clear(pixels, 0, pixels.Length);
		pixels = null;
		GC.Collect();
		return texture;
	}

	public static string FormatBigNumber(int num)
	{
		return num.ToString("N0", englishCulture);
	}

	public static string FormatBigNumberLong(long number)
	{
		return number.ToString("N0", englishCulture);
	}

	public static string FormatBigNumber(long num)
	{
		return num.ToString("N0", englishCulture);
	}

	public static string FormatAssignmentNumber(int num)
	{
		return num.ToString("N0", frenchCulture);
	}

	public static string FormatFloatNumber(float value)
	{
		return (!(value > 1f) && !(value < -1f)) ? value.ToString("G1", englishCulture) : value.ToString("N0", englishCulture);
	}

	public static string FormatFloatNumberSigned(float value, float hideDecimalPointFrom = 10f)
	{
		if (value < 0f)
		{
			return value.ToString((!(value < 0f - hideDecimalPointFrom)) ? "0.#" : "N0", englishCulture);
		}
		return "+" + value.ToString((!(value > hideDecimalPointFrom)) ? "0.#" : "N0", englishCulture);
	}

	public static string FormatFloatNumberRoundOne(float num)
	{
		return num.ToString("N1", englishCulture);
	}

	public static string FormatFloatNumberRoundZeroOrOne(float num)
	{
		return num.ToString("#,0.#", englishCulture);
	}

	public static string FormatNumberToOrdinal(int num)
	{
		if (Localization.isEnglish)
		{
			int num2 = num % 100;
			if (num2 == 11 || num2 == 12 || num2 == 13)
			{
				return $"{FormatBigNumber(num)}th";
			}
			string text = FormatBigNumber(num);
			return (num % 10) switch
			{
				1 => text + "st", 
				2 => text + "nd", 
				3 => text + "rd", 
				_ => text + "th", 
			};
		}
		return FormatNumberToOrdinalPoint(num);
	}

	public static string FormatNumberToOrdinalPoint(int num)
	{
		return $"{FormatBigNumber(num)}.";
	}

	public static string FormatMedalsDifference(int num)
	{
		return ((num <= 0) ? string.Empty : "+") + num.ToString("N0", englishCulture);
	}

	public static string FormatNumberAsSeconds(int num)
	{
		return string.Format("{0}{1}", FormatBigNumber(num), Localization.Localize("ID_SEC"));
	}

	public static string FormatNumberAsSeconds(float value)
	{
		return string.Format("{0}{1}", FormatFloatNumberRoundZeroOrOne(value), Localization.Localize("ID_SEC"));
	}

	public static string FormatNumberPerMinute(float value)
	{
		return string.Format("{0}/{1}", FormatFloatNumberRoundZeroOrOne(value), Localization.Localize("ID_MIN"));
	}

	public static string FormatFloatNumberAsPercent(float value)
	{
		return $"{FormatFloatNumberRoundZeroOrOne(value * 100f)}%";
	}

	public static string FormatFloatNumberAsPlusPercent(float value)
	{
		return $"+{FormatFloatNumberRoundZeroOrOne(value * 100f)}%";
	}

	public static string FormatFloatNumberAsPercentWithoutCharacter(float value)
	{
		return $"{FormatFloatNumberRoundZeroOrOne(value * 100f)}";
	}

	public static string FormatFloatNumberAsPercentSigned(float value)
	{
		return string.Format((!(value < 0f)) ? "+{0}%" : "{0}%", FormatFloatNumberRoundZeroOrOne(value * 100f));
	}

	public static string FormatNumberAsPercent(int num)
	{
		return $"{num}%";
	}

	public static Color CompareStats(float shownStat, float equippedStat, bool inverted = false)
	{
		if (Mathf.Approximately(shownStat, equippedStat))
		{
			return Color.white;
		}
		if (shownStat > equippedStat)
		{
			return (!inverted) ? Colours.greenWeaponStats : Colours.redWeaponStats;
		}
		return (!inverted) ? Colours.redWeaponStats : Colours.greenWeaponStats;
	}

	public static string RemoveDiacritics(string s)
	{
		s = s.Normalize(NormalizationForm.FormD);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < s.Length; i++)
		{
			if (CharUnicodeInfo.GetUnicodeCategory(s[i]) != UnicodeCategory.NonSpacingMark)
			{
				stringBuilder.Append(s[i]);
			}
		}
		return stringBuilder.ToString();
	}

	public static Vector3 ClosestPointOnLine(Vector3 a, Vector3 b, Vector3 Point)
	{
		Vector3 rhs = Point - a;
		Vector3 normalized = (b - a).normalized;
		float magnitude = (b - a).magnitude;
		float num = Vector3.Dot(normalized, rhs);
		if (num < 0f)
		{
			return a;
		}
		if (num > magnitude)
		{
			return b;
		}
		normalized *= num;
		return a + normalized;
	}

	public static long BitSwitch(long input, int first, int second)
	{
		long num = 1L << first;
		long num2 = 1L << second;
		long num3 = (input >> first) & 1;
		long num4 = (input >> second) & 1;
		return (((input & ~num) | (num4 << first)) & ~num2) | (num3 << second);
	}

	public static long SimpleHash(long input)
	{
		input += 4584757287377321145L;
		for (int i = 0; i < 64; i += 2)
		{
			input = BitSwitch(input, swArr[i], swArr[i + 1]);
		}
		return input ^ 0x5A2C6D853BAC35A8L;
	}

	public static string Md5(string pass)
	{
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		byte[] bytes = uTF8Encoding.GetBytes(pass);
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
		return BitConverter.ToString(array).ToLower().Replace("-", string.Empty);
	}

	public static string PrintableTime(float seconds, string readyString = "ID_READYTIME", string prefixTimeString = "", bool localizeReadyString = true)
	{
		if (seconds <= 0.5f)
		{
			return (!localizeReadyString) ? readyString : Localization.Localize(readyString);
		}
		if (prefixTimeString != string.Empty)
		{
			prefixTimeString = ((!prefixTimeString.StartsWith("ID")) ? prefixTimeString : Localization.Localize(prefixTimeString)) + " ";
		}
		TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
		if (timeSpan.Days > 0)
		{
			return string.Format("{0}{1}{2} {3}{4}", prefixTimeString, timeSpan.Days, Localization.Localize("ID_DAY"), timeSpan.Hours, Localization.Localize("ID_HOU"));
		}
		if (timeSpan.Hours > 0)
		{
			return string.Format("{0}{1}{2} {3}{4}", prefixTimeString, timeSpan.Hours, Localization.Localize("ID_HOU"), timeSpan.Minutes, Localization.Localize("ID_MIN"));
		}
		return string.Format("{0}{1}{2} {3}{4}", prefixTimeString, timeSpan.Minutes, Localization.Localize("ID_MIN"), timeSpan.Seconds, Localization.Localize("ID_SEC"));
	}

	public static string PrintableDetailedTime(float seconds, string readyString = "ID_READYTIME", string prefixTimeString = "", bool localizeReadyString = true)
	{
		if (seconds <= 0.5f)
		{
			return (!localizeReadyString) ? readyString : Localization.Localize(readyString);
		}
		if (prefixTimeString != string.Empty)
		{
			prefixTimeString = ((!prefixTimeString.StartsWith("ID")) ? prefixTimeString : Localization.Localize(prefixTimeString)) + " ";
		}
		TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
		if (timeSpan.Days > 0)
		{
			return string.Format("{0}{1}{2} {3}{4} {5}{6} {7}{8}", prefixTimeString, timeSpan.Days, Localization.Localize("ID_DAY"), timeSpan.Hours, Localization.Localize("ID_HOU"), timeSpan.Minutes, Localization.Localize("ID_MIN"), timeSpan.Seconds, Localization.Localize("ID_SEC"));
		}
		if (timeSpan.Hours > 0)
		{
			return string.Format("{0}{1}{2} {3}{4} {5}{6}", prefixTimeString, timeSpan.Hours, Localization.Localize("ID_HOU"), timeSpan.Minutes, Localization.Localize("ID_MIN"), timeSpan.Seconds, Localization.Localize("ID_SEC"));
		}
		return string.Format("{0}{1}{2} {3}{4}", prefixTimeString, timeSpan.Minutes, Localization.Localize("ID_MIN"), timeSpan.Seconds, Localization.Localize("ID_SEC"));
	}

	public static string PrintableTimeTwoDigits(float seconds)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
		return $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
	}

	public static string PrintableTimeDigits(float seconds)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
		return $"{timeSpan.Minutes}:{timeSpan.Seconds:D2}";
	}

	public static void PrintableTimeTwoDigits(ref StringBuilder b, float seconds)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
		b.AppendFormat("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
	}

	public static string PrintableTimeDescription(float seconds, string readyString = "ID_ZEROSECONDS")
	{
		if (seconds <= 0.5f)
		{
			return Localization.Localize(readyString);
		}
		if (seconds > 3599f)
		{
			return Localization.Localize("ID_HOURANDMORE");
		}
		TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
		string text = ((timeSpan.Minutes != 1) ? Localization.Localize("ID_MINUTES") : Localization.Localize("ID_MINUTE"));
		string text2 = ((timeSpan.Seconds != 1) ? Localization.Localize("ID_SECONDS") : Localization.Localize("ID_SECOND"));
		if (timeSpan.Minutes == 0)
		{
			return $"{timeSpan.Seconds}\u00a0{text2}";
		}
		if (timeSpan.Seconds == 0)
		{
			return $"{timeSpan.Minutes}\u00a0{text}";
		}
		return Localization.LocalizeFormat("ID_TIMEANDTIME", timeSpan.Minutes, text, timeSpan.Seconds, text2);
	}

	public static string PrintableTimeMessageCenter(float seconds)
	{
		if (seconds < 60f)
		{
			return Localization.Localize("ID_LESSTHANMINUTE");
		}
		TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
		if (timeSpan.Days > 1)
		{
			return Localization.LocalizeFormat("ID_DAYSAGO", timeSpan.Days);
		}
		if (timeSpan.Days == 1)
		{
			return Localization.Localize("ID_DAYAGO");
		}
		if (timeSpan.Hours > 1)
		{
			return Localization.LocalizeFormat("ID_HOURSAGO", timeSpan.Hours);
		}
		if (timeSpan.Hours == 1)
		{
			return Localization.Localize("ID_HOURAGO");
		}
		return Localization.LocalizeFormat("ID_MINAGO", timeSpan.Minutes);
	}

	public static string PrintableTimeVipConvert(int seconds)
	{
		int num = seconds % 86400;
		int num2 = seconds / 86400;
		if (num == 0 && num2 > 1)
		{
			return string.Format("{0}\u00a0{1}", num2, Localization.Localize("ID_DAYS"));
		}
		num = seconds % 3600;
		num2 = seconds / 3600;
		if (num == 0 && num2 > 1)
		{
			return string.Format("{0}\u00a0{1}", num2, Localization.Localize("ID_HOURS"));
		}
		num = seconds % 60;
		num2 = seconds / 60;
		if (num == 0 && num2 > 1)
		{
			return string.Format("{0}\u00a0{1}", num2, Localization.Localize("ID_MINUTES").ToUpper());
		}
		if (seconds > 1)
		{
			return string.Format("{0}\u00a0{1}", seconds, Localization.Localize("ID_SECONDS").ToUpper());
		}
		return "1\u00a0" + Localization.Localize("ID_SECOND").ToUpper();
	}

	public static string PrintableTimeVipConvertSmall(int seconds)
	{
		int num = seconds % 86400;
		int num2 = seconds / 86400;
		if (num == 0 && num2 > 1)
		{
			return string.Format("{0}\u00a0{1}", num2, Localization.Localize("ID_DAYS").ToLower());
		}
		num = seconds % 3600;
		num2 = seconds / 3600;
		if (num == 0 && num2 > 1)
		{
			return string.Format("{0}\u00a0{1}", num2, Localization.Localize("ID_HOURS").ToLower());
		}
		if (num == 0 && num2 == 1)
		{
			return Localization.Localize("ID_HOUR_SMALL");
		}
		num = seconds % 60;
		num2 = seconds / 60;
		if (num == 0 && num2 > 1)
		{
			return string.Format("{0}\u00a0{1}", num2, Localization.Localize("ID_MINUTES"));
		}
		if (seconds > 1)
		{
			return string.Format("{0}\u00a0{1}", seconds, Localization.Localize("ID_SECONDS"));
		}
		return string.Format("1\u00a0{0}", Localization.Localize("ID_SECOND"));
	}

	public static string PrintableTimeLongForm(float seconds, bool showSeconds = true)
	{
		if (seconds <= 0.5f)
		{
			return "0\u00a0" + Localization.Localize((!showSeconds) ? "ID_MINUTES" : "ID_SECONDS");
		}
		TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
		string text = string.Empty;
		int num = 0;
		if (timeSpan.Days > 1)
		{
			text += string.Format(" {0}\u00a0{1}", timeSpan.Days, Localization.Localize("ID_DAYS").ToLower());
			num++;
		}
		else if (timeSpan.Days == 1)
		{
			text += Localization.Localize("ID_DAY_SMALL");
			num++;
		}
		if (timeSpan.Hours > 1)
		{
			text += string.Format(" {0}\u00a0{1}", timeSpan.Hours, Localization.Localize("ID_HOURS").ToLower());
			num++;
		}
		else if (timeSpan.Hours == 1)
		{
			text = text + " " + Localization.Localize("ID_HOUR_SMALL");
			num++;
		}
		if (num == 2)
		{
			return text.Trim();
		}
		if (timeSpan.Minutes > 1)
		{
			text += string.Format(" {0}\u00a0{1}", timeSpan.Minutes, Localization.Localize("ID_MINUTES"));
			num++;
		}
		else if (timeSpan.Minutes == 1)
		{
			text += string.Format(" 1\u00a0{0}", Localization.Localize("ID_MINUTE"));
			num++;
		}
		if (num == 2)
		{
			return text.Trim();
		}
		if (showSeconds)
		{
			text = ((timeSpan.Seconds > 1) ? (text + string.Format(" {0}\u00a0{1}", timeSpan.Seconds, Localization.Localize("ID_SECONDS"))) : ((timeSpan.Seconds != 1) ? (text + string.Format(" {0}\u00a0{1}", timeSpan.Seconds, Localization.Localize("ID_SECONDS"))) : (text + string.Format(" 1\u00a0{0}", Localization.Localize("ID_SECOND")))));
		}
		return text.Trim();
	}

	public static string PrintableWholeTimeLongForm(float seconds, bool showSeconds = true)
	{
		if (seconds <= 0.5f)
		{
			return "0\u00a0" + Localization.Localize((!showSeconds) ? "ID_MINUTES" : "ID_SECONDS");
		}
		TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
		string text = string.Empty;
		if (timeSpan.Days > 1)
		{
			text += string.Format(" {0}\u00a0{1}", timeSpan.Days, Localization.Localize("ID_DAYS").ToLower());
		}
		else if (timeSpan.Days == 1)
		{
			text += Localization.Localize("ID_DAY_SMALL");
		}
		if (timeSpan.Hours > 1)
		{
			text += string.Format(" {0}\u00a0{1}", timeSpan.Hours, Localization.Localize("ID_HOURS").ToLower());
		}
		else if (timeSpan.Hours == 1)
		{
			text = text + " " + Localization.Localize("ID_HOUR_SMALL");
		}
		if (timeSpan.Minutes > 1)
		{
			text += string.Format(" {0}\u00a0{1}", timeSpan.Minutes, Localization.Localize("ID_MINUTES"));
		}
		else if (timeSpan.Minutes == 1)
		{
			text += string.Format(" 1\u00a0{0}", Localization.Localize("ID_MINUTE"));
		}
		if (showSeconds)
		{
			text = ((timeSpan.Seconds > 1) ? (text + string.Format(" {0}\u00a0{1}", timeSpan.Seconds, Localization.Localize("ID_SECONDS"))) : ((timeSpan.Seconds != 1) ? (text + string.Format(" {0}\u00a0{1}", timeSpan.Seconds, Localization.Localize("ID_SECONDS"))) : (text + string.Format(" 1\u00a0{0}", Localization.Localize("ID_SECOND")))));
		}
		return text.Trim();
	}

	public static string PrintableWholeTime(float seconds, bool showSeconds = true)
	{
		if (seconds <= 0.5f)
		{
			return "0" + Localization.Localize((!showSeconds) ? "ID_MIN" : "ID_SEC");
		}
		TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
		string text = string.Empty;
		if (timeSpan.Days > 0)
		{
			text += string.Format(" {0}{1}", timeSpan.Days, Localization.Localize("ID_DAY"));
		}
		if (timeSpan.Hours > 0)
		{
			text += string.Format(" {0}{1}", timeSpan.Hours, Localization.Localize("ID_HOU"));
		}
		if (timeSpan.Minutes > 0 || !showSeconds)
		{
			text += string.Format(" {0}{1}", timeSpan.Minutes, Localization.Localize("ID_MIN"));
		}
		return (text + ((timeSpan.Seconds <= 0 || !showSeconds) ? string.Empty : string.Format(" {0}{1}", timeSpan.Seconds, Localization.Localize("ID_SEC")))).Trim();
	}

	public static void PrintMemoryInfo()
	{
		string text = "MONO HEAP SIZE: " + (float)Profiler.GetMonoHeapSize() / 1048576f;
		text = text + " MONO USED SIZE: " + (float)Profiler.GetMonoUsedSize() / 1048576f;
		text = text + " TOTAL ALLOCATED: " + (float)Profiler.GetTotalAllocatedMemory() / 1048576f;
		text = text + " TOTAL RESERVED: " + (float)Profiler.GetTotalReservedMemory() / 1048576f;
		text = text + " TOTAL UNSUED RESERVED: " + (float)Profiler.GetTotalUnusedReservedMemory() / 1048576f;
		text = text + " TOTAL MEMORY (GC): " + (float)GC.GetTotalMemory(forceFullCollection: false) / 1048576f;
		Debug.Log(text);
	}

	public static void PrintRuntimeSize(string o)
	{
	}

	public static float GetSize(string o)
	{
		return (float)Encoding.Unicode.GetByteCount(o) / 1048576f;
	}

	public static string GetPath(UnityEngine.Object @object)
	{
		return string.Empty;
	}

	public static void SetUILabelRescale(UILabel label, float defaultHeight, float minHeight, int width = 0)
	{
		float y = label.transform.localScale.y;
		SetUILabelLocalScale(label, defaultHeight, minHeight, width);
		if (label.font.isDynamic)
		{
			SetUILabelNewLocalPosition(label, y);
			SetUILabelDynamicSize(label);
		}
	}

	public static void SetUILabelLocalScale(UILabel label, float defaultHeight, float minHeight, int width = 0)
	{
		if (minHeight > defaultHeight)
		{
			float num = minHeight;
			minHeight = defaultHeight;
			defaultHeight = num;
		}
		if (width == 0)
		{
			width = label.lineWidth;
		}
		float num2 = defaultHeight;
		if (width > 0)
		{
			int num3 = label.maxLineCount;
			if (num3 == 0)
			{
				num3 = 1;
			}
			float num4 = Mathf.Max(label.getSizeForString(label.text.Replace("\n", " ")).x, 1f);
			float num5 = num3 * width;
			num2 = Mathf.Clamp(Mathf.Floor(num5 / num4), minHeight, defaultHeight);
		}
		label.transform.localScale = new Vector3(num2, num2, 1f);
	}

	public static void SetUILabelNewLocalPosition(UILabel label, float previousHeight)
	{
		if (!label.font.isDynamic)
		{
			return;
		}
		float y = label.transform.localScale.y;
		if (previousHeight != y)
		{
			float num = 0f;
			UIWidget.Pivot pivot = label.pivot;
			if (pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.Center || pivot == UIWidget.Pivot.Right)
			{
				num = 0.091f;
			}
			if (pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.Top || pivot == UIWidget.Pivot.TopRight)
			{
				num = 0.182f;
			}
			if (pivot == UIWidget.Pivot.BottomLeft || pivot == UIWidget.Pivot.Bottom || pivot == UIWidget.Pivot.BottomRight)
			{
				num = ((!(label.relativeSize.y > 1f)) ? 0f : 0.139f);
			}
			float num2 = 0f - Mathf.Round(Mathf.Round(previousHeight / 0.826f) * num);
			float num3 = 0f - Mathf.Round(Mathf.Round(y / 0.826f) * num);
			float num4 = 0f - num2 + num3;
			if ((-315f <= label.transform.localRotation.eulerAngles.z && label.transform.localRotation.eulerAngles.z <= -225f) || (45f <= label.transform.localRotation.eulerAngles.z && label.transform.localRotation.eulerAngles.z <= 135f))
			{
				label.transform.localPosition = label.transform.localPosition.ReplaceX(label.transform.localPosition.x + num4);
			}
			else if ((-135f <= label.transform.localRotation.eulerAngles.z && label.transform.localRotation.eulerAngles.z <= -45f) || (225f <= label.transform.localRotation.eulerAngles.z && label.transform.localRotation.eulerAngles.z <= 315f))
			{
				label.transform.localPosition = label.transform.localPosition.ReplaceX(label.transform.localPosition.x - num4);
			}
			else
			{
				label.transform.localPosition = label.transform.localPosition.ReplaceY(label.transform.localPosition.y + num4);
			}
		}
	}

	public static void SetUILabelDynamicSize(UILabel label)
	{
		if (label.font.isDynamic)
		{
			int dynamicFontSize = label.dynamicFontSize;
			int num = ((label.transform.localScale.y >= 50f) ? 80 : 0);
			if (dynamicFontSize != num)
			{
				label.dynamicFontSize = num;
				label.text = label.text;
			}
		}
	}

	public static int CompareSquadRanks(SquadRank squadRank1, SquadRank squadRank2)
	{
		if (squadRank1 == squadRank2)
		{
			return 0;
		}
		if (squadRank1 == SquadRank.Coleader)
		{
			return (squadRank2 != SquadRank.Leader) ? 1 : (-1);
		}
		if (squadRank2 == SquadRank.Coleader)
		{
			return (squadRank1 == SquadRank.Leader) ? 1 : (-1);
		}
		return (int)Mathf.Sign(squadRank1 - squadRank2);
	}

	public static string DifferenceString(int previousValue, int newValue)
	{
		if (previousValue > newValue)
		{
			return $"was:{previousValue} is:{newValue} removed:{previousValue - newValue}";
		}
		return $"was:{previousValue} is:{newValue} added:{newValue - previousValue}";
	}

	public static string DifferenceString(long previousValue, long newValue)
	{
		if (previousValue > newValue)
		{
			return $"was:{previousValue} is:{newValue} removed:{previousValue - newValue}";
		}
		return $"was:{previousValue} is:{newValue} added:{newValue - previousValue}";
	}

	public static int Sign(int number)
	{
		return (number > 0) ? 1 : ((number < 0) ? (-1) : 0);
	}

	public static IEnumerable<T[]> Permutations<T>(T[] values, int fromInd = 0)
	{
		if (fromInd + 1 == values.Length)
		{
			yield return values;
			yield break;
		}
		foreach (T[] item in Permutations(values, fromInd + 1))
		{
			yield return item;
		}
		for (int i = fromInd + 1; i < values.Length; i++)
		{
			SwapValues(values, fromInd, i);
			foreach (T[] item2 in Permutations(values, fromInd + 1))
			{
				yield return item2;
			}
			SwapValues(values, fromInd, i);
		}
	}

	private static void SwapValues<T>(T[] values, int pos1, int pos2)
	{
		if (pos1 != pos2)
		{
			T val = values[pos1];
			values[pos1] = values[pos2];
			values[pos2] = val;
		}
	}

	public static int SquadWarTier(int position, int count)
	{
		if (position < 1)
		{
			return 0;
		}
		if (count <= (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowerSquadLimit).FLOATVALUE)
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier2Reward).FLOATVALUE;
			if (position < num)
			{
				return 1;
			}
			int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier3Reward).FLOATVALUE;
			if (position < num2)
			{
				return 2;
			}
			int num3 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier4Reward).FLOATVALUE;
			if (position < num3)
			{
				return 3;
			}
			int num4 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsTier5Reward).FLOATVALUE;
			if (position < num4)
			{
				return 4;
			}
			int num5 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowSquadsNoReward).FLOATVALUE;
			if (position < num5)
			{
				return 5;
			}
			return 0;
		}
		int num6 = 1;
		if (position == num6)
		{
			return 1;
		}
		int num7 = Mathf.CeilToInt((float)count * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsTier3Percentage).FLOATVALUE);
		if (position - 1 < num7)
		{
			return 2;
		}
		int num8 = Mathf.CeilToInt((float)count * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsTier4Percentage).FLOATVALUE);
		if (position - 1 < num8)
		{
			return 3;
		}
		int num9 = Mathf.CeilToInt((float)count * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsTier5Percentage).FLOATVALUE);
		if (position - 1 < num9)
		{
			return 4;
		}
		int num10 = Mathf.CeilToInt((float)count * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsNoRewardPercentage).FLOATVALUE);
		if (position - 1 < num10)
		{
			return 5;
		}
		return 0;
	}

	public static int SquadWarPositionPromote(int count, int division)
	{
		float num = Singleton<GameVariables>.instance.SquadWarPromoteConstant(division);
		return Mathf.CeilToInt((float)count * num);
	}

	public static int SquadWarPositionDemote(int count, int division)
	{
		float num = Singleton<GameVariables>.instance.SquadWarDemoteConstant(division);
		return Mathf.FloorToInt((float)count * (1f - num));
	}

	public static string GetPrintableDate(DateTime date)
	{
		return date.ToString("dd/M/yyyy");
	}

	public static WeaponCategory ParseCategory(string data)
	{
		data = data.ToLower();
		if (int.TryParse(data, out var result))
		{
			return (WeaponCategory)result;
		}
		switch (data)
		{
		case "assault":
		case "assaultrifle":
			return WeaponCategory.AssaultRifle;
		case "smg":
			return WeaponCategory.SMG;
		case "lmg":
			return WeaponCategory.LMG;
		case "primary":
			return WeaponCategory.Primary;
		case "minigun":
			return WeaponCategory.Minigun;
		case "sniper":
		case "sniperrifle":
			return WeaponCategory.SniperRifle;
		case "shotgun":
			return WeaponCategory.Shotgun;
		case "special":
			return WeaponCategory.Special;
		case "grenade":
			return WeaponCategory.Grenade;
		case "bazooka":
		case "rocket":
		case "rocketlauncher":
			return WeaponCategory.RocketLauncher;
		case "grenadelauncher":
			return WeaponCategory.GrenadeLauncher;
		case "explosive":
			return WeaponCategory.Explosive;
		case "pistol":
			return WeaponCategory.Pistol;
		default:
			return WeaponCategory.None;
		}
	}

	public static T GetCopyOf<T>(this Component comp, T other) where T : Component
	{
		Type type = comp.GetType();
		if (type != other.GetType())
		{
			return (T)null;
		}
		BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
		while (type.BaseType != typeof(Component))
		{
			PropertyInfo[] properties = type.GetProperties(bindingAttr);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				if (propertyInfo.CanWrite)
				{
					try
					{
						propertyInfo.SetValue(comp, propertyInfo.GetValue(other, null), null);
					}
					catch
					{
					}
				}
			}
			FieldInfo[] fields = type.GetFields(bindingAttr);
			FieldInfo[] array2 = fields;
			foreach (FieldInfo fieldInfo in array2)
			{
				fieldInfo.SetValue(comp, fieldInfo.GetValue(other));
			}
			type = type.BaseType;
		}
		return comp as T;
	}

	public static T AddComponent<T>(this GameObject go, T toAdd) where T : Component
	{
		Type typeFromHandle = typeof(T);
		Type type = toAdd.GetType();
		Component component = go.AddComponent(toAdd.GetType());
		component.GetCopyOf(toAdd);
		return (T)component;
	}

	public static T CopyComponent<T>(this GameObject go, T toAdd) where T : Component
	{
		Type typeFromHandle = typeof(T);
		Type type = toAdd.GetType();
		Component component = go.GetComponent(toAdd.GetType());
		if (component == null)
		{
			component = go.AddComponent(toAdd.GetType());
		}
		component.GetCopyOf(toAdd);
		return (T)component;
	}

	public static int RoundToInt(float value)
	{
		return Mathf.FloorToInt(value + 0.5f);
	}

	public static bool IsChildOf(this GameObject gameObject, GameObject obj)
	{
		GameObject gameObject2 = gameObject;
		while (gameObject2.transform.parent != null)
		{
			gameObject2 = gameObject2.transform.parent.gameObject;
			if (gameObject2 == obj)
			{
				return true;
			}
		}
		return false;
	}
}
