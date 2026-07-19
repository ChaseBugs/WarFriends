using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

public static class KHJJFPPACBP
{
	public static int PELILBMKGHE(object EFHMCBKOAEO, int KGNECBICFAJ = 0)
	{
		try
		{
			return Convert.ToInt32(EFHMCBKOAEO);
		}
		catch (Exception)
		{
			try
			{
				return (int)Convert.ToSingle(EFHMCBKOAEO, CultureInfo.InvariantCulture);
			}
			catch (Exception kIJELCLONNC)
			{
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, EFHMCBKOAEO, Environment.StackTrace);
				return KGNECBICFAJ;
			}
		}
	}

	public static int HNMDPGKPLNK(JToken EFHMCBKOAEO, int KGNECBICFAJ = 0)
	{
		try
		{
			return EFHMCBKOAEO.Value<int>();
		}
		catch (Exception)
		{
			try
			{
				return (int)EFHMCBKOAEO.Value<float>();
			}
			catch (Exception kIJELCLONNC)
			{
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, EFHMCBKOAEO, Environment.StackTrace);
				return KGNECBICFAJ;
			}
		}
	}

	public static float PHNMENLEIPI(object EFHMCBKOAEO, float KGNECBICFAJ = 0f)
	{
		try
		{
			return Convert.ToSingle(EFHMCBKOAEO, CultureInfo.InvariantCulture);
		}
		catch (Exception kIJELCLONNC)
		{
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, EFHMCBKOAEO, Environment.StackTrace);
			return KGNECBICFAJ;
		}
	}

	public static float CJOBHHILPLF(JToken EFHMCBKOAEO, float KGNECBICFAJ = 0f)
	{
		try
		{
			return EFHMCBKOAEO.Value<float>();
		}
		catch (Exception kIJELCLONNC)
		{
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, EFHMCBKOAEO, Environment.StackTrace);
			return KGNECBICFAJ;
		}
	}

	public static bool FOJOKBCNBCO(object EFHMCBKOAEO, bool KGNECBICFAJ = false)
	{
		try
		{
			return Convert.ToBoolean(EFHMCBKOAEO);
		}
		catch (Exception kIJELCLONNC)
		{
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, EFHMCBKOAEO, Environment.StackTrace);
			return KGNECBICFAJ;
		}
	}

	public static long OOAIMCEBPOK(object EFHMCBKOAEO, long KGNECBICFAJ = 0L)
	{
		try
		{
			return Convert.ToInt64(EFHMCBKOAEO);
		}
		catch (Exception kIJELCLONNC)
		{
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, EFHMCBKOAEO, Environment.StackTrace);
			return KGNECBICFAJ;
		}
	}

	public static long GKKLOFAGGLI(JToken EFHMCBKOAEO, long KGNECBICFAJ = 0L)
	{
		try
		{
			return EFHMCBKOAEO.Value<long>();
		}
		catch (Exception)
		{
			try
			{
				return (long)EFHMCBKOAEO.Value<float>();
			}
			catch (Exception kIJELCLONNC)
			{
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, EFHMCBKOAEO, Environment.StackTrace);
				return KGNECBICFAJ;
			}
		}
	}

	public static int PELILBMKGHE(string IMOCKMIAJHN, string FHOBKJEHAGE, JToken DIGPAIOFOFE, int KGNECBICFAJ = 0)
	{
		try
		{
			return DIGPAIOFOFE[IMOCKMIAJHN][FHOBKJEHAGE].ToObject<int>();
		}
		catch (Exception)
		{
			try
			{
				return (int)DIGPAIOFOFE[IMOCKMIAJHN][FHOBKJEHAGE].ToObject<float>();
			}
			catch (Exception kIJELCLONNC)
			{
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, "key= " + IMOCKMIAJHN + ", databaseType= " + FHOBKJEHAGE + ", dictionary= " + DIGPAIOFOFE, Environment.StackTrace);
				return KGNECBICFAJ;
			}
		}
	}

	public static string BKFCLMMJNHK(string IMOCKMIAJHN, string FHOBKJEHAGE, JToken DIGPAIOFOFE, string KGNECBICFAJ = "")
	{
		try
		{
			return DIGPAIOFOFE[IMOCKMIAJHN][FHOBKJEHAGE].ToObject<string>();
		}
		catch (Exception kIJELCLONNC)
		{
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, "key= " + IMOCKMIAJHN + ", databaseType= " + FHOBKJEHAGE + ", dictionary= " + DIGPAIOFOFE, Environment.StackTrace);
			return KGNECBICFAJ;
		}
	}

	public static long OOAIMCEBPOK(string IMOCKMIAJHN, string FHOBKJEHAGE, JToken DIGPAIOFOFE, long KGNECBICFAJ = 0L)
	{
		try
		{
			return DIGPAIOFOFE[IMOCKMIAJHN][FHOBKJEHAGE].ToObject<long>();
		}
		catch (Exception kIJELCLONNC)
		{
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, "key= " + IMOCKMIAJHN + ", databaseType= " + FHOBKJEHAGE + ", dictionary= " + DIGPAIOFOFE[IMOCKMIAJHN], Environment.StackTrace);
			return KGNECBICFAJ;
		}
	}

	public static string BKFCLMMJNHK(object EFHMCBKOAEO, string KGNECBICFAJ = "")
	{
		try
		{
			return EFHMCBKOAEO.ToString();
		}
		catch (Exception kIJELCLONNC)
		{
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, EFHMCBKOAEO, Environment.StackTrace);
			return KGNECBICFAJ;
		}
	}
}
