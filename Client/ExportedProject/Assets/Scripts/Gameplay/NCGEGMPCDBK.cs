using System;
using System.Reflection;
using UnityEngine;

public static class NCGEGMPCDBK
{
	private static bool OBDMAMHCBLE;

	private static MethodInfo OEGDCFDNGPJ;

	private static bool NBABKNIIKOF;

	private static Type LBGIBFLGNOO;

	private static MethodInfo OGJGOAAMDGB
	{
		get
		{
			if (OEGDCFDNGPJ == null || !OBDMAMHCBLE)
			{
				OBDMAMHCBLE = true;
				if (COEEGMJJBIP == null)
				{
					return null;
				}
				OEGDCFDNGPJ = COEEGMJJBIP.GetMethod("ClearEntries", BindingFlags.Static | BindingFlags.Public);
			}
			return OEGDCFDNGPJ;
		}
	}

	private static Type COEEGMJJBIP
	{
		get
		{
			if (LBGIBFLGNOO == null || !NBABKNIIKOF)
			{
				NBABKNIIKOF = true;
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				for (int i = 0; i < assemblies.Length; i++)
				{
					Type[] types = assemblies[i].GetTypes();
					for (int j = 0; j < types.Length; j++)
					{
						if (types[j].Name == "ConsolePro3Window")
						{
							LBGIBFLGNOO = types[j];
						}
					}
				}
			}
			return LBGIBFLGNOO;
		}
	}

	public static void JJKDKMGEHHL()
	{
		if (OGJGOAAMDGB != null)
		{
			OGJGOAAMDGB.Invoke(null, null);
		}
	}

	public static void LJKBMHLCLMC(string GOPPBOOPHJN, string HEJLAHBEABB)
	{
		Debug.Log(GOPPBOOPHJN + "\nCPAPI:{\"cmd\":\"Filter\" \"name\":\"" + HEJLAHBEABB + "\"}");
	}

	public static void HMDCJHFFBFN(string PNFAFHHJJKI, string MHEKHINPHBP)
	{
		Debug.Log(PNFAFHHJJKI + " : " + MHEKHINPHBP + "\nCPAPI:{\"cmd\":\"Watch\" \"name\":\"" + PNFAFHHJJKI + "\"}");
	}
}
