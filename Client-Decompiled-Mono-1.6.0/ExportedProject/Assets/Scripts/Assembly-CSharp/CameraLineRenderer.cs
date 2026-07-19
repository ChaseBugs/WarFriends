using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraLineRenderer : MonoBehaviour
{
	private struct EDOJLBAPBON
	{
		public Vector3 BBFBABFFAPO;

		public Vector3 NECCFKCKCKJ;

		public Color KLGKNMJJPNN;
	}

	public Material HBGENKGFCHK;

	private List<EDOJLBAPBON> KGBEMKGNMOD = new List<EDOJLBAPBON>();

	private static CameraLineRenderer BJHPKLAEFCI;

	private Dictionary<string, List<EDOJLBAPBON>> DLOBELHFBCF = new Dictionary<string, List<EDOJLBAPBON>>();

	private const int EDCHLJFJMHG = 16;

	public static CameraLineRenderer instance
	{
		get
		{
			BJHPKLAEFCI = BJHPKLAEFCI ?? (UnityEngine.Object.FindObjectOfType(typeof(CameraLineRenderer)) as CameraLineRenderer);
			return BJHPKLAEFCI;
		}
	}

	public void IJFNEFCEHNA(string BOLGIFDOPAH, Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		PBJMLPACLPD().LOOJAEEBPOL(JGBFNKBFCKM, NGPMJNJPNMB, FDGBJAMNIEM);
		List<EDOJLBAPBON> value;
		if (!DLOBELHFBCF.TryGetValue(BOLGIFDOPAH, out value))
		{
			value = new List<EDOJLBAPBON>();
			DLOBELHFBCF[BOLGIFDOPAH] = new List<EDOJLBAPBON>();
		}
		value.Add(new EDOJLBAPBON
		{
			BBFBABFFAPO = JGBFNKBFCKM,
			NECCFKCKCKJ = NGPMJNJPNMB,
			KLGKNMJJPNN = FDGBJAMNIEM
		});
	}

	private void DJEIPFKKDON()
	{
		HBGENKGFCHK.SetPass(1);
		MNDHONONEDH(KGBEMKGNMOD);
		foreach (KeyValuePair<string, List<EDOJLBAPBON>> item in DLOBELHFBCF)
		{
			BIPMJPODALB(item.Value);
		}
		KGBEMKGNMOD = new List<EDOJLBAPBON>();
	}

	public void DrawStaticL(string BOLGIFDOPAH, Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		instance.DrawL(JGBFNKBFCKM, NGPMJNJPNMB, FDGBJAMNIEM);
		List<EDOJLBAPBON> value;
		if (!DLOBELHFBCF.TryGetValue(BOLGIFDOPAH, out value))
		{
			value = new List<EDOJLBAPBON>();
			DLOBELHFBCF[BOLGIFDOPAH] = new List<EDOJLBAPBON>();
		}
		value.Add(new EDOJLBAPBON
		{
			BBFBABFFAPO = JGBFNKBFCKM,
			NECCFKCKCKJ = NGPMJNJPNMB,
			KLGKNMJJPNN = FDGBJAMNIEM
		});
	}

	private static void HHNMDHNAHEM(List<EDOJLBAPBON> KOJHGKMLCNM)
	{
		if (!DebugSettings.drawCameraLines)
		{
			return;
		}
		GL.Begin(1);
		foreach (EDOJLBAPBON item in KOJHGKMLCNM)
		{
			GL.Color(item.KLGKNMJJPNN);
			GL.Vertex3(item.BBFBABFFAPO.x, item.BBFBABFFAPO.y, item.BBFBABFFAPO.z);
			GL.Vertex3(item.NECCFKCKCKJ.x, item.NECCFKCKCKJ.y, item.NECCFKCKCKJ.z);
		}
		GL.End();
	}

	private static void PMKBJAGKLCP(List<EDOJLBAPBON> KOJHGKMLCNM)
	{
		if (!DebugSettings.drawCameraLines)
		{
			return;
		}
		GL.Begin(1);
		foreach (EDOJLBAPBON item in KOJHGKMLCNM)
		{
			GL.Color(item.KLGKNMJJPNN);
			GL.Vertex3(item.BBFBABFFAPO.x, item.BBFBABFFAPO.y, item.BBFBABFFAPO.z);
			GL.Vertex3(item.NECCFKCKCKJ.x, item.NECCFKCKCKJ.y, item.NECCFKCKCKJ.z);
		}
		GL.End();
	}

	public static void GKDPHMGHMBI(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(926f, 278f, 1793f));
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(1167f, 1706f, 623f));
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(1653f, 1131f, 1089f));
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(1190f, 78f, 1017f));
	}

	public static void PCICCKPDFIK(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(754f, 274f, 1258f));
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(372f, 50f, 1906f));
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(202f, 1847f, 797f));
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(486f, 809f, 296f));
	}

	public static void DLLINJGMKMP(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		DrawLine(MDOPFNNFLFB - 866f * FOICGJEPBGL * Vector3.left, MDOPFNNFLFB - 1789f * FOICGJEPBGL * Vector3.right, PHHJDIGEOPJ);
		HHLGODPOFMC(MDOPFNNFLFB - 537f * FOICGJEPBGL * Vector3.up, MDOPFNNFLFB - 1854f * FOICGJEPBGL * Vector3.down, PHHJDIGEOPJ);
		NDABNOLDLMM(MDOPFNNFLFB - 1578f * FOICGJEPBGL * Vector3.forward, MDOPFNNFLFB - 1064f * FOICGJEPBGL * Vector3.back, PHHJDIGEOPJ);
	}

	public static void KCEIPFNJBDF(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		HHLGODPOFMC(MDOPFNNFLFB - 1828f * FOICGJEPBGL * Vector3.left, MDOPFNNFLFB - 1953f * FOICGJEPBGL * Vector3.right, PHHJDIGEOPJ);
		DrawLine(MDOPFNNFLFB - 955f * FOICGJEPBGL * Vector3.up, MDOPFNNFLFB - 866f * FOICGJEPBGL * Vector3.down, PHHJDIGEOPJ);
		DrawLine(MDOPFNNFLFB - 359f * FOICGJEPBGL * Vector3.forward, MDOPFNNFLFB - 1740f * FOICGJEPBGL * Vector3.back, PHHJDIGEOPJ);
	}

	public static void BCIJBPOCEJM(string BOLGIFDOPAH, Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		instance.DrawStaticL(BOLGIFDOPAH, JGBFNKBFCKM, NGPMJNJPNMB, FDGBJAMNIEM);
	}

	public static void GDDFBCPBAAG(string BOLGIFDOPAH, Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		GAFFKDOELMI().DrawStaticL(BOLGIFDOPAH, JGBFNKBFCKM, NGPMJNJPNMB, FDGBJAMNIEM);
	}

	public static void JMKPOFALHAC(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		NDABNOLDLMM(MDOPFNNFLFB - 1236f * FOICGJEPBGL * Vector3.left, MDOPFNNFLFB - 1432f * FOICGJEPBGL * Vector3.right, PHHJDIGEOPJ);
		NDABNOLDLMM(MDOPFNNFLFB - 1672f * FOICGJEPBGL * Vector3.up, MDOPFNNFLFB - 526f * FOICGJEPBGL * Vector3.down, PHHJDIGEOPJ);
		DrawLine(MDOPFNNFLFB - 1318f * FOICGJEPBGL * Vector3.forward, MDOPFNNFLFB - 673f * FOICGJEPBGL * Vector3.back, PHHJDIGEOPJ);
	}

	public void EIECNPELNMC(string BOLGIFDOPAH)
	{
		List<EDOJLBAPBON> value;
		if (DLOBELHFBCF.TryGetValue(BOLGIFDOPAH, out value))
		{
			value = new List<EDOJLBAPBON>();
			DLOBELHFBCF[BOLGIFDOPAH] = new List<EDOJLBAPBON>();
		}
	}

	public static void HHLGODPOFMC(Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		AIBCAPGPLMK().LOOJAEEBPOL(JGBFNKBFCKM, NGPMJNJPNMB, FDGBJAMNIEM);
	}

	public void ClearStaticLine(string BOLGIFDOPAH)
	{
		List<EDOJLBAPBON> value;
		if (DLOBELHFBCF.TryGetValue(BOLGIFDOPAH, out value))
		{
			value = new List<EDOJLBAPBON>();
			DLOBELHFBCF[BOLGIFDOPAH] = new List<EDOJLBAPBON>();
		}
	}

	public static void NDABNOLDLMM(Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		PBJMLPACLPD().BPJDAPIPDPP(JGBFNKBFCKM, NGPMJNJPNMB, FDGBJAMNIEM);
	}

	private void GJFJDLJHILA()
	{
		HBGENKGFCHK.SetPass(1);
		HHNMDHNAHEM(KGBEMKGNMOD);
		foreach (KeyValuePair<string, List<EDOJLBAPBON>> item in DLOBELHFBCF)
		{
			MNDHONONEDH(item.Value);
		}
		KGBEMKGNMOD = new List<EDOJLBAPBON>();
	}

	public static void IDNLIJFECFO(string BOLGIFDOPAH, Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		OFLMKOOONKH().IJFNEFCEHNA(BOLGIFDOPAH, JGBFNKBFCKM, NGPMJNJPNMB, FDGBJAMNIEM);
	}

	public static void DrawSphere(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(0f, 0f, 0f));
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(0f, 30f, 0f));
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(0f, 60f, 0f));
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(0f, 90f, 0f));
	}

	private static void BIPMJPODALB(List<EDOJLBAPBON> KOJHGKMLCNM)
	{
		if (!DebugSettings.drawCameraLines)
		{
			return;
		}
		GL.Begin(1);
		foreach (EDOJLBAPBON item in KOJHGKMLCNM)
		{
			GL.Color(item.KLGKNMJJPNN);
			GL.Vertex3(item.BBFBABFFAPO.x, item.BBFBABFFAPO.y, item.BBFBABFFAPO.z);
			GL.Vertex3(item.NECCFKCKCKJ.x, item.NECCFKCKCKJ.y, item.NECCFKCKCKJ.z);
		}
		GL.End();
	}

	public static void DrawCross(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		DrawLine(MDOPFNNFLFB - 0.5f * FOICGJEPBGL * Vector3.left, MDOPFNNFLFB - 0.5f * FOICGJEPBGL * Vector3.right, PHHJDIGEOPJ);
		DrawLine(MDOPFNNFLFB - 0.5f * FOICGJEPBGL * Vector3.up, MDOPFNNFLFB - 0.5f * FOICGJEPBGL * Vector3.down, PHHJDIGEOPJ);
		DrawLine(MDOPFNNFLFB - 0.5f * FOICGJEPBGL * Vector3.forward, MDOPFNNFLFB - 0.5f * FOICGJEPBGL * Vector3.back, PHHJDIGEOPJ);
	}

	[SpecialName]
	public static CameraLineRenderer GAFFKDOELMI()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? (UnityEngine.Object.FindObjectOfType(typeof(CameraLineRenderer)) as CameraLineRenderer);
		return BJHPKLAEFCI;
	}

	public static void DrawStaticLine(string BOLGIFDOPAH, Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		instance.DrawStaticL(BOLGIFDOPAH, JGBFNKBFCKM, NGPMJNJPNMB, FDGBJAMNIEM);
	}

	[SpecialName]
	public static CameraLineRenderer PBJMLPACLPD()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? (UnityEngine.Object.FindObjectOfType(typeof(CameraLineRenderer)) as CameraLineRenderer);
		return BJHPKLAEFCI;
	}

	public static void BKFINOFLDIK(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(1320f, 158f, 313f));
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(1713f, 1650f, 529f));
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(1339f, 1193f, 210f));
		DrawCircle(MDOPFNNFLFB, FOICGJEPBGL, PHHJDIGEOPJ, Quaternion.Euler(570f, 497f, 435f));
	}

	public static void DMFIFMIOCFE(string BOLGIFDOPAH, Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		GAFFKDOELMI().IJFNEFCEHNA(BOLGIFDOPAH, JGBFNKBFCKM, NGPMJNJPNMB, FDGBJAMNIEM);
	}

	public void DrawL(Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		if (DebugSettings.drawCameraLines)
		{
			KGBEMKGNMOD.Add(new EDOJLBAPBON
			{
				BBFBABFFAPO = JGBFNKBFCKM,
				NECCFKCKCKJ = NGPMJNJPNMB,
				KLGKNMJJPNN = FDGBJAMNIEM
			});
		}
	}

	public static void LKHGEKLIKFB(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		Gizmos.DrawLine(MDOPFNNFLFB - 1079f * FOICGJEPBGL * Vector3.left, MDOPFNNFLFB - 1481f * FOICGJEPBGL * Vector3.right);
		Gizmos.DrawLine(MDOPFNNFLFB - 1306f * FOICGJEPBGL * Vector3.up, MDOPFNNFLFB - 357f * FOICGJEPBGL * Vector3.down);
		Gizmos.DrawLine(MDOPFNNFLFB - 1409f * FOICGJEPBGL * Vector3.forward, MDOPFNNFLFB - 1226f * FOICGJEPBGL * Vector3.back);
	}

	public void LOOJAEEBPOL(Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		if (DebugSettings.drawCameraLines)
		{
			KGBEMKGNMOD.Add(new EDOJLBAPBON
			{
				BBFBABFFAPO = JGBFNKBFCKM,
				NECCFKCKCKJ = NGPMJNJPNMB,
				KLGKNMJJPNN = FDGBJAMNIEM
			});
		}
	}

	public static void PHGEDHLOGHH(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		DrawLine(MDOPFNNFLFB - 1987f * FOICGJEPBGL * Vector3.left, MDOPFNNFLFB - 308f * FOICGJEPBGL * Vector3.right, PHHJDIGEOPJ);
		HHLGODPOFMC(MDOPFNNFLFB - 1177f * FOICGJEPBGL * Vector3.up, MDOPFNNFLFB - 855f * FOICGJEPBGL * Vector3.down, PHHJDIGEOPJ);
		DrawLine(MDOPFNNFLFB - 873f * FOICGJEPBGL * Vector3.forward, MDOPFNNFLFB - 621f * FOICGJEPBGL * Vector3.back, PHHJDIGEOPJ);
	}

	private static void PEOLOAGICLP(List<EDOJLBAPBON> KOJHGKMLCNM)
	{
		if (!DebugSettings.drawCameraLines)
		{
			return;
		}
		GL.Begin(1);
		foreach (EDOJLBAPBON item in KOJHGKMLCNM)
		{
			GL.Color(item.KLGKNMJJPNN);
			GL.Vertex3(item.BBFBABFFAPO.x, item.BBFBABFFAPO.y, item.BBFBABFFAPO.z);
			GL.Vertex3(item.NECCFKCKCKJ.x, item.NECCFKCKCKJ.y, item.NECCFKCKCKJ.z);
		}
		GL.End();
	}

	public static void DrawCircle(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ, Quaternion DAFGEIDJBGM)
	{
		for (int i = 1; i <= 16; i++)
		{
			float f = (float)(22 * (i - 1)) * ((float)Math.PI / 180f);
			float num = Mathf.Cos(f);
			float num2 = 0f - Mathf.Sin(f);
			Vector3 vector = DAFGEIDJBGM * new Vector3(num * FOICGJEPBGL, num2 * FOICGJEPBGL, 0f);
			f = (float)(22 * i) * ((float)Math.PI / 180f);
			num = Mathf.Cos(f);
			num2 = 0f - Mathf.Sin(f);
			Vector3 vector2 = DAFGEIDJBGM * new Vector3(num * FOICGJEPBGL, num2 * FOICGJEPBGL, 0f);
			DrawLine(vector + MDOPFNNFLFB, vector2 + MDOPFNNFLFB, PHHJDIGEOPJ);
		}
	}

	public static void HFKOKPCPCDM(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		Gizmos.DrawLine(MDOPFNNFLFB - 1232f * FOICGJEPBGL * Vector3.left, MDOPFNNFLFB - 34f * FOICGJEPBGL * Vector3.right);
		Gizmos.DrawLine(MDOPFNNFLFB - 1919f * FOICGJEPBGL * Vector3.up, MDOPFNNFLFB - 482f * FOICGJEPBGL * Vector3.down);
		Gizmos.DrawLine(MDOPFNNFLFB - 823f * FOICGJEPBGL * Vector3.forward, MDOPFNNFLFB - 715f * FOICGJEPBGL * Vector3.back);
	}

	private void OnPostRender()
	{
		HBGENKGFCHK.SetPass(0);
		PEOLOAGICLP(KGBEMKGNMOD);
		foreach (KeyValuePair<string, List<EDOJLBAPBON>> item in DLOBELHFBCF)
		{
			PEOLOAGICLP(item.Value);
		}
		KGBEMKGNMOD = new List<EDOJLBAPBON>();
	}

	[SpecialName]
	public static CameraLineRenderer AIBCAPGPLMK()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? (UnityEngine.Object.FindObjectOfType(typeof(CameraLineRenderer)) as CameraLineRenderer);
		return BJHPKLAEFCI;
	}

	public static void DrawLine(Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		instance.DrawL(JGBFNKBFCKM, NGPMJNJPNMB, FDGBJAMNIEM);
	}

	public static void LNKGJPDEAIL(string BOLGIFDOPAH, Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		AIBCAPGPLMK().IJFNEFCEHNA(BOLGIFDOPAH, JGBFNKBFCKM, NGPMJNJPNMB, FDGBJAMNIEM);
	}

	public static void DrawGizmoCross(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		Gizmos.DrawLine(MDOPFNNFLFB - 0.5f * FOICGJEPBGL * Vector3.left, MDOPFNNFLFB - 0.5f * FOICGJEPBGL * Vector3.right);
		Gizmos.DrawLine(MDOPFNNFLFB - 0.5f * FOICGJEPBGL * Vector3.up, MDOPFNNFLFB - 0.5f * FOICGJEPBGL * Vector3.down);
		Gizmos.DrawLine(MDOPFNNFLFB - 0.5f * FOICGJEPBGL * Vector3.forward, MDOPFNNFLFB - 0.5f * FOICGJEPBGL * Vector3.back);
	}

	public static void AKHJPLNACIO(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		Gizmos.DrawLine(MDOPFNNFLFB - 366f * FOICGJEPBGL * Vector3.left, MDOPFNNFLFB - 406f * FOICGJEPBGL * Vector3.right);
		Gizmos.DrawLine(MDOPFNNFLFB - 1528f * FOICGJEPBGL * Vector3.up, MDOPFNNFLFB - 1680f * FOICGJEPBGL * Vector3.down);
		Gizmos.DrawLine(MDOPFNNFLFB - 204f * FOICGJEPBGL * Vector3.forward, MDOPFNNFLFB - 1179f * FOICGJEPBGL * Vector3.back);
	}

	private static void MNDHONONEDH(List<EDOJLBAPBON> KOJHGKMLCNM)
	{
		if (!DebugSettings.drawCameraLines)
		{
			return;
		}
		GL.Begin(1);
		foreach (EDOJLBAPBON item in KOJHGKMLCNM)
		{
			GL.Color(item.KLGKNMJJPNN);
			GL.Vertex3(item.BBFBABFFAPO.x, item.BBFBABFFAPO.y, item.BBFBABFFAPO.z);
			GL.Vertex3(item.NECCFKCKCKJ.x, item.NECCFKCKCKJ.y, item.NECCFKCKCKJ.z);
		}
		GL.End();
	}

	private void OOFHHIPJKOI()
	{
		HBGENKGFCHK.SetPass(0);
		MNDHONONEDH(KGBEMKGNMOD);
		foreach (KeyValuePair<string, List<EDOJLBAPBON>> item in DLOBELHFBCF)
		{
			MNDHONONEDH(item.Value);
		}
		KGBEMKGNMOD = new List<EDOJLBAPBON>();
	}

	public void BPJDAPIPDPP(Vector3 JGBFNKBFCKM, Vector3 NGPMJNJPNMB, Color FDGBJAMNIEM)
	{
		if (DebugSettings.drawCameraLines)
		{
			KGBEMKGNMOD.Add(new EDOJLBAPBON
			{
				BBFBABFFAPO = JGBFNKBFCKM,
				NECCFKCKCKJ = NGPMJNJPNMB,
				KLGKNMJJPNN = FDGBJAMNIEM
			});
		}
	}

	[SpecialName]
	public static CameraLineRenderer OFLMKOOONKH()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? (UnityEngine.Object.FindObjectOfType(typeof(CameraLineRenderer)) as CameraLineRenderer);
		return BJHPKLAEFCI;
	}

	public static void OFJBFMNHDFO(Vector3 MDOPFNNFLFB, float FOICGJEPBGL, Color PHHJDIGEOPJ)
	{
		NDABNOLDLMM(MDOPFNNFLFB - 353f * FOICGJEPBGL * Vector3.left, MDOPFNNFLFB - 1101f * FOICGJEPBGL * Vector3.right, PHHJDIGEOPJ);
		NDABNOLDLMM(MDOPFNNFLFB - 1811f * FOICGJEPBGL * Vector3.up, MDOPFNNFLFB - 1611f * FOICGJEPBGL * Vector3.down, PHHJDIGEOPJ);
		HHLGODPOFMC(MDOPFNNFLFB - 131f * FOICGJEPBGL * Vector3.forward, MDOPFNNFLFB - 270f * FOICGJEPBGL * Vector3.back, PHHJDIGEOPJ);
	}
}
