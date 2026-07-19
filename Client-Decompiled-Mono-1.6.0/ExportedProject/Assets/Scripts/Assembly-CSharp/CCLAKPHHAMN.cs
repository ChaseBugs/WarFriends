using System;
using CodeStage.AntiCheat.ObscuredTypes;
using Newtonsoft.Json;
using UnityEngine;

public static class CCLAKPHHAMN
{
	public static void LLEEMOLNPMI(string MHPNDNJDPGE, Type POENMJMDGBJ, object MMMKOMPFLGG)
	{
		try
		{
			ObscuredPrefs.SetString(MHPNDNJDPGE, JEONPNGFNMM(MMMKOMPFLGG, POENMJMDGBJ));
		}
		catch (Exception ex)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogError(ex.ToString());
			}
		}
	}

	public static void PDAPDJPGKEK(string MHPNDNJDPGE)
	{
		ObscuredPrefs.DeleteAll();
	}

	private static string JEONPNGFNMM(object KMHEPACAPBH, Type FJLBLLLEELD)
	{
		return JsonConvert.SerializeObject(KMHEPACAPBH);
	}
}
