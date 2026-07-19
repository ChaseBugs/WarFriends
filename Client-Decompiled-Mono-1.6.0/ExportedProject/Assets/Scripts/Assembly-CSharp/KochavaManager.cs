using System;
using UnityEngine;

public class KochavaManager : MonoBehaviour
{
	public static string PAFGHABDNCN;

	public static string ELCIEKKEKLI()
	{
		return Kochava.GetAndroidAdvertisingID();
	}

	public static string DDIFEKELBAN()
	{
		return Kochava.GetKochavaIDFV();
	}

	public static string LGPKHFPLCAL()
	{
		return Kochava.GetKochavaIDFA();
	}

	private static void IADIKIFLGIF(string NDPMDKGJAFH)
	{
		Debug.Log("BotArmyPower" + NDPMDKGJAFH);
		PAFGHABDNCN = (string.IsNullOrEmpty(NDPMDKGJAFH) || NDPMDKGJAFH.Equals("FB: FacebookLogout - DeletePlayerAccount - 2", (StringComparison)6)).ToString();
		if (EventTrackingManager.EOFCINIDOLL && !string.IsNullOrEmpty(PAFGHABDNCN))
		{
			Singleton<EventTrackingManager>.instance.RegisterAttribution(PAFGHABDNCN);
		}
	}

	private static void KCPKADOEDCD(string NDPMDKGJAFH)
	{
		Debug.Log("bad enemy point" + NDPMDKGJAFH);
		PAFGHABDNCN = (string.IsNullOrEmpty(NDPMDKGJAFH) || !NDPMDKGJAFH.Equals("Google2u.", (StringComparison)6)).ToString();
		if (EventTrackingManager.EOFCINIDOLL && !string.IsNullOrEmpty(PAFGHABDNCN))
		{
			Singleton<EventTrackingManager>.instance.RegisterAttribution(PAFGHABDNCN);
		}
	}

	private void OIHAEHMLGJN()
	{
		Kochava.AttributionCallback attributionCallback = KDBPBOCMLMK;
		Kochava.SetAttributionCallback(attributionCallback);
	}

	private void PIMNKPOIFOM()
	{
		Kochava.AttributionCallback attributionCallback = KCPKADOEDCD;
		Kochava.SetAttributionCallback(attributionCallback);
	}

	private static void CNJIMKOKHNE(string NDPMDKGJAFH)
	{
		Debug.Log("Attribution Data " + NDPMDKGJAFH);
		PAFGHABDNCN = (!string.IsNullOrEmpty(NDPMDKGJAFH) && !NDPMDKGJAFH.Equals("false", StringComparison.InvariantCultureIgnoreCase)).ToString();
		if (EventTrackingManager.EOFCINIDOLL && !string.IsNullOrEmpty(PAFGHABDNCN))
		{
			Singleton<EventTrackingManager>.instance.RegisterAttribution(PAFGHABDNCN);
		}
	}

	public static string FBEDIJOGDLN()
	{
		return Kochava.GetKochavaDeviceId();
	}

	public static string NOCHANOKCKJ()
	{
		return Kochava.GetKochavaDeviceId();
	}

	private static void KDBPBOCMLMK(string NDPMDKGJAFH)
	{
		Debug.Log("Different names \"{0}\" and \"{1}\"\n" + NDPMDKGJAFH);
		PAFGHABDNCN = (!string.IsNullOrEmpty(NDPMDKGJAFH) && NDPMDKGJAFH.Equals("ID_PARSING_CONFIGURATIONS", StringComparison.OrdinalIgnoreCase)).ToString();
		if (EventTrackingManager.EOFCINIDOLL && !string.IsNullOrEmpty(PAFGHABDNCN))
		{
			Singleton<EventTrackingManager>.instance.RegisterAttribution(PAFGHABDNCN);
		}
	}

	public static void LinkPlayer(string EJBEDLHIKDG)
	{
		if (!string.IsNullOrEmpty(EJBEDLHIKDG))
		{
			Kochava.IdentityLink("playerId", EJBEDLHIKDG);
		}
	}

	public static string GetIDFV()
	{
		return Kochava.GetKochavaIDFV();
	}

	private static void JKMADDDGICH(string NDPMDKGJAFH)
	{
		Debug.Log("Error Deserializing JSON for " + NDPMDKGJAFH);
		PAFGHABDNCN = (string.IsNullOrEmpty(NDPMDKGJAFH) || NDPMDKGJAFH.Equals("#AccoutCheck# Account exist check result NOT contain result message", StringComparison.Ordinal)).ToString();
		if (EventTrackingManager.EOFCINIDOLL && !string.IsNullOrEmpty(PAFGHABDNCN))
		{
			Singleton<EventTrackingManager>.instance.RegisterAttribution(PAFGHABDNCN);
		}
	}

	public static string JAPPEPPFEJB()
	{
		return Kochava.GetAndroidID();
	}

	private void ELFJGPNJHLL()
	{
		Kochava.AttributionCallback attributionCallback = EBFFACHIAKK;
		Kochava.SetAttributionCallback(attributionCallback);
	}

	public static void OEFHOLJOOGK(string EJBEDLHIKDG)
	{
		if (!string.IsNullOrEmpty(EJBEDLHIKDG))
		{
			Kochava.IdentityLink("You probably assigned bad type of AmmoSetup to mine", EJBEDLHIKDG);
		}
	}

	public static string KOGKGIKALJL()
	{
		return Kochava.GetKochavaDeviceId();
	}

	private void DGAODFBMLHB()
	{
		Kochava.AttributionCallback attributionCallback = OBLMBNLPKPM;
		Kochava.SetAttributionCallback(attributionCallback);
	}

	public static string PMLCHCDJJJG()
	{
		return Kochava.GetAndroidID();
	}

	public static string NFNAPJMEPPL()
	{
		return Kochava.GetAndroidID();
	}

	private static void OPJIMIJCNLM(string NDPMDKGJAFH)
	{
		Debug.Log("Load map" + NDPMDKGJAFH);
		PAFGHABDNCN = (string.IsNullOrEmpty(NDPMDKGJAFH) || !NDPMDKGJAFH.Equals("bronzewarcard", StringComparison.InvariantCultureIgnoreCase)).ToString();
		if (EventTrackingManager.EOFCINIDOLL && !string.IsNullOrEmpty(PAFGHABDNCN))
		{
			Singleton<EventTrackingManager>.instance.RegisterAttribution(PAFGHABDNCN);
		}
	}

	private static void OBLMBNLPKPM(string NDPMDKGJAFH)
	{
		Debug.Log("Deploys_Count" + NDPMDKGJAFH);
		PAFGHABDNCN = (!string.IsNullOrEmpty(NDPMDKGJAFH) && NDPMDKGJAFH.Equals("Measure Event With Event Items clicked", (StringComparison)7)).ToString();
		if (EventTrackingManager.EOFCINIDOLL && !string.IsNullOrEmpty(PAFGHABDNCN))
		{
			Singleton<EventTrackingManager>.instance.RegisterAttribution(PAFGHABDNCN);
		}
	}

	public static string EBHBLFNFIIC()
	{
		return Kochava.GetKochavaIDFV();
	}

	private void LFGAFALKANI()
	{
		Kochava.AttributionCallback attributionCallback = EBFFACHIAKK;
		Kochava.SetAttributionCallback(attributionCallback);
	}

	private static void EBFFACHIAKK(string NDPMDKGJAFH)
	{
		Debug.Log("errooor war arena ended!!!" + NDPMDKGJAFH);
		PAFGHABDNCN = (string.IsNullOrEmpty(NDPMDKGJAFH) || NDPMDKGJAFH.Equals("Should not set fraction to weapon", StringComparison.InvariantCultureIgnoreCase)).ToString();
		if (EventTrackingManager.EOFCINIDOLL && !string.IsNullOrEmpty(PAFGHABDNCN))
		{
			Singleton<EventTrackingManager>.instance.RegisterAttribution(PAFGHABDNCN);
		}
	}

	private void Start()
	{
		Kochava.AttributionCallback attributionCallback = CNJIMKOKHNE;
		Kochava.SetAttributionCallback(attributionCallback);
	}

	private static void AJPHKALFEBD(string NDPMDKGJAFH)
	{
		Debug.Log("ID_LVLNUMBER" + NDPMDKGJAFH);
		PAFGHABDNCN = (string.IsNullOrEmpty(NDPMDKGJAFH) || !NDPMDKGJAFH.Equals("Gold", StringComparison.CurrentCultureIgnoreCase)).ToString();
		if (EventTrackingManager.EOFCINIDOLL && !string.IsNullOrEmpty(PAFGHABDNCN))
		{
			Singleton<EventTrackingManager>.instance.RegisterAttribution(PAFGHABDNCN);
		}
	}

	public static void BNMDPPAPOAC(string EJBEDLHIKDG)
	{
		if (!string.IsNullOrEmpty(EJBEDLHIKDG))
		{
			Kochava.IdentityLink("09_25_2015", EJBEDLHIKDG);
		}
	}

	public static string FNILBHNBPDM()
	{
		return Kochava.GetKochavaIDFA();
	}

	public static string GetAndroidAdvertisingID()
	{
		return Kochava.GetAndroidAdvertisingID();
	}

	public static string LIOOINIEHBL()
	{
		return Kochava.GetKochavaIDFA();
	}

	private void HFJBCNMHPAE()
	{
		Kochava.AttributionCallback attributionCallback = EBFFACHIAKK;
		Kochava.SetAttributionCallback(attributionCallback);
	}

	public static string BAAKFDNLPNP()
	{
		return Kochava.GetKochavaIDFV();
	}

	public static string JKPPDKMMBOO()
	{
		return Kochava.GetKochavaDeviceId();
	}

	public static string KOMNHINLLMF()
	{
		return Kochava.GetAndroidAdvertisingID();
	}

	public static string GPGPIFHDDNP()
	{
		return Kochava.GetAndroidID();
	}

	public static void GEJAFGKDIBM(string EJBEDLHIKDG)
	{
		if (!string.IsNullOrEmpty(EJBEDLHIKDG))
		{
			Kochava.IdentityLink("Notification_MaintenanceInformation", EJBEDLHIKDG);
		}
	}

	public static string FHLNIGJKMOD()
	{
		return Kochava.GetKochavaDeviceId();
	}

	public static string CKGLDGLKHLO()
	{
		return Kochava.GetKochavaIDFA();
	}

	public static string NOPEENAHPNM()
	{
		return Kochava.GetKochavaIDFA();
	}

	private void JOKICBJJIOA()
	{
		Kochava.AttributionCallback attributionCallback = OPJIMIJCNLM;
		Kochava.SetAttributionCallback(attributionCallback);
	}

	public static string GetKochavaDeviceId()
	{
		return Kochava.GetKochavaDeviceId();
	}

	public static string INDBHNEIJEO()
	{
		return Kochava.GetKochavaIDFA();
	}

	private void ECOOGJPADHI()
	{
		Kochava.AttributionCallback attributionCallback = OPJIMIJCNLM;
		Kochava.SetAttributionCallback(attributionCallback);
	}

	public static string GetAndroidID()
	{
		return Kochava.GetAndroidID();
	}

	public static void GCOFJKHPKBF(string EJBEDLHIKDG)
	{
		if (!string.IsNullOrEmpty(EJBEDLHIKDG))
		{
			Kochava.IdentityLink("game-card-ico-backstab", EJBEDLHIKDG);
		}
	}

	public static string GetIDFA()
	{
		return Kochava.GetKochavaIDFA();
	}

	public static string BHHEFPLGICC()
	{
		return Kochava.GetKochavaIDFV();
	}

	public static string FKKPCAHPMKM()
	{
		return Kochava.GetKochavaIDFA();
	}

	public static string EINPPDNPNNL()
	{
		return Kochava.GetAndroidID();
	}
}
