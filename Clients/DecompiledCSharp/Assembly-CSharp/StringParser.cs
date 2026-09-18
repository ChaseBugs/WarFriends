using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

public static class StringParser
{
	public static int ParseInt(object inputString, int defaultSafeValue = 0)
	{
		try
		{
			return Convert.ToInt32(inputString);
		}
		catch (Exception)
		{
			try
			{
				return (int)Convert.ToSingle(inputString, CultureInfo.InvariantCulture);
			}
			catch (Exception exception)
			{
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, inputString, Environment.StackTrace);
				return defaultSafeValue;
			}
		}
	}

	public static int ParseIntToken(JToken inputString, int defaultSafeValue = 0)
	{
		try
		{
			return inputString.Value<int>();
		}
		catch (Exception)
		{
			try
			{
				return (int)inputString.Value<float>();
			}
			catch (Exception exception)
			{
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, inputString, Environment.StackTrace);
				return defaultSafeValue;
			}
		}
	}

	public static float ParseFloatToken(JToken inputString, float defaultSafeValue = 0f)
	{
		try
		{
			return inputString.Value<float>();
		}
		catch (Exception exception)
		{
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, inputString, Environment.StackTrace);
			return defaultSafeValue;
		}
	}

	public static bool ParseBool(object inputString, bool defaultSafeValue = false)
	{
		try
		{
			return Convert.ToBoolean(inputString);
		}
		catch (Exception exception)
		{
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, inputString, Environment.StackTrace);
			return defaultSafeValue;
		}
	}

	public static long ParseLong(object inputString, long defaultSafeValue = 0L)
	{
		try
		{
			return Convert.ToInt64(inputString);
		}
		catch (Exception exception)
		{
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, inputString, Environment.StackTrace);
			return defaultSafeValue;
		}
	}

	public static long ParseLongToken(JToken inputString, long defaultSafeValue = 0L)
	{
		try
		{
			return inputString.Value<long>();
		}
		catch (Exception)
		{
			try
			{
				return (long)inputString.Value<float>();
			}
			catch (Exception exception)
			{
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, inputString, Environment.StackTrace);
				return defaultSafeValue;
			}
		}
	}

	public static int ParseInt(string key, string databaseType, JToken dictionary, int defaultSafeValue = 0)
	{
		try
		{
			return dictionary[key][databaseType].ToObject<int>();
		}
		catch (Exception)
		{
			try
			{
				return (int)dictionary[key][databaseType].ToObject<float>();
			}
			catch (Exception exception)
			{
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, "key= " + key + ", databaseType= " + databaseType + ", dictionary= " + dictionary, Environment.StackTrace);
				return defaultSafeValue;
			}
		}
	}

	public static string ParseString(string key, string databaseType, JToken dictionary, string defaultSafeValue = "")
	{
		try
		{
			return dictionary[key][databaseType].ToObject<string>();
		}
		catch (Exception exception)
		{
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, "key= " + key + ", databaseType= " + databaseType + ", dictionary= " + dictionary, Environment.StackTrace);
			return defaultSafeValue;
		}
	}

	public static long ParseLong(string key, string databaseType, JToken dictionary, long defaultSafeValue = 0)
	{
		try
		{
			return dictionary[key][databaseType].ToObject<long>();
		}
		catch (Exception exception)
		{
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, "key= " + key + ", databaseType= " + databaseType + ", dictionary= " + dictionary[key], Environment.StackTrace);
			return defaultSafeValue;
		}
	}

	public static string ParseString(object inputString, string defaultSafeValue = "")
	{
		try
		{
			return inputString.ToString();
		}
		catch (Exception exception)
		{
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, inputString, Environment.StackTrace);
			return defaultSafeValue;
		}
	}
}
