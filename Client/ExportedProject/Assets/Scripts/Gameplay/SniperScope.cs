using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class SniperScope : Singleton<SniperScope>
{
	[Serializable]
	public class Scope
	{
		public Vector3 offset = new Vector3(30f, 30f, 0f);

		public GameObject scope;

		public Vector3 mStartScale;

		public float maxTopOffset = 30f;
	}

	[FormerlySerializedAs("INDDPOFADOG")]
	public Camera PAMJKKMGFFM;

	[FormerlySerializedAs("BGIOBKDLNLD")]
	public Vector3 MKOGHDKDFIN = new Vector3(30f, 30f, 0f);

	private Renderer NEJBJAIBKAI;

	private bool ODKHLNBKFFL;

	private Vector3 GIELOCNNOMA;

	private bool KILFMMCCCAC;

	private Scope IDMNLHEFKGH;

	[FormerlySerializedAs("NNNPOELJPBK")]
	public List<Scope> PADGDOPELEH;

	public bool showed => ODKHLNBKFFL;

	public void DFJBBKKIPAD(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 697f;
		}
		if (!FPBJEDIJNFK())
		{
			PAMJKKMGFFM.gameObject.SetActive(value: false);
			IDMNLHEFKGH.scope.transform.localScale = Vector3.zero;
			TweenScale.Begin(IDMNLHEFKGH.scope, 650f, Vector3.zero, IDMNLHEFKGH.mStartScale);
			TweenFOV.Begin(Singleton<SniperScope>.instance.PAMJKKMGFFM.gameObject, 1256f, ODENHCLHCIL);
			base.gameObject.SetActive(value: false);
			ODKHLNBKFFL = true;
		}
	}

	public Vector3 JNCDFDCDCLK(Camera PHHJDIGEOPJ, Vector3 JILEHJEHMJF, Vector3 MKOGHDKDFIN, Bounds MBJLNICGOMO)
	{
		Vector3 vector = JILEHJEHMJF + MKOGHDKDFIN;
		Vector3 result = vector;
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1682f, 1630f));
		Vector3 vector3 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(398f, 678f));
		Vector3 vector4 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(569f, 1315f));
		if (vector.y - MBJLNICGOMO.extents.y < vector2.y)
		{
			result.y = vector2.y + MBJLNICGOMO.extents.y;
		}
		if (vector.y + MBJLNICGOMO.extents.y > vector4.y)
		{
			result.y = vector4.y - MBJLNICGOMO.extents.y;
			float num = vector.y - vector4.y + MBJLNICGOMO.extents.y;
			float value = num / MBJLNICGOMO.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * 679f * 1134f);
			num = Mathf.Clamp(num, 348f, MBJLNICGOMO.extents.y + IDMNLHEFKGH.offset.x);
			num = value * IDMNLHEFKGH.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - MBJLNICGOMO.extents.x < vector2.x)
		{
			result.x = vector2.x + MBJLNICGOMO.extents.x;
		}
		if (vector.x + MBJLNICGOMO.extents.x > vector3.x)
		{
			result.x = vector3.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	public Vector3 ClampInScreenXY(Camera PHHJDIGEOPJ, Vector3 JILEHJEHMJF, Vector3 MKOGHDKDFIN, Bounds MBJLNICGOMO)
	{
		Vector3 vector = JILEHJEHMJF + MKOGHDKDFIN;
		Vector3 result = vector;
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(0f, 0f));
		Vector3 vector3 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1f, 0f));
		Vector3 vector4 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1f, 1f));
		if (vector.y - MBJLNICGOMO.extents.y < vector2.y)
		{
			result.y = vector2.y + MBJLNICGOMO.extents.y;
		}
		if (vector.y + MBJLNICGOMO.extents.y > vector4.y)
		{
			result.y = vector4.y - MBJLNICGOMO.extents.y;
			float num = vector.y - vector4.y + MBJLNICGOMO.extents.y;
			float value = num / MBJLNICGOMO.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * (float)Math.PI * 0.5f);
			num = Mathf.Clamp(num, 0f, MBJLNICGOMO.extents.y + IDMNLHEFKGH.offset.x);
			num = value * IDMNLHEFKGH.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - MBJLNICGOMO.extents.x < vector2.x)
		{
			result.x = vector2.x + MBJLNICGOMO.extents.x;
		}
		if (vector.x + MBJLNICGOMO.extents.x > vector3.x)
		{
			result.x = vector3.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	protected void OPMNIHDAHAA()
	{
		PLCKEBOHBEA();
	}

	public Vector3 KOHPABHMNFO(Camera PHHJDIGEOPJ, Vector3 JILEHJEHMJF, Vector3 MKOGHDKDFIN, Bounds MBJLNICGOMO)
	{
		Vector3 vector = JILEHJEHMJF + MKOGHDKDFIN;
		Vector3 result = vector;
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1725f, 1385f));
		Vector3 vector3 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1795f, 659f));
		Vector3 vector4 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1515f, 764f));
		if (vector.y - MBJLNICGOMO.extents.y < vector2.y)
		{
			result.y = vector2.y + MBJLNICGOMO.extents.y;
		}
		if (vector.y + MBJLNICGOMO.extents.y > vector4.y)
		{
			result.y = vector4.y - MBJLNICGOMO.extents.y;
			float num = vector.y - vector4.y + MBJLNICGOMO.extents.y;
			float value = num / MBJLNICGOMO.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * 797f * 1787f);
			num = Mathf.Clamp(num, 622f, MBJLNICGOMO.extents.y + IDMNLHEFKGH.offset.x);
			num = value * IDMNLHEFKGH.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - MBJLNICGOMO.extents.x < vector2.x)
		{
			result.x = vector2.x + MBJLNICGOMO.extents.x;
		}
		if (vector.x + MBJLNICGOMO.extents.x > vector3.x)
		{
			result.x = vector3.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	public void NLMKCDMBPPC()
	{
		if (!FPBJEDIJNFK())
		{
			IDMNLHEFKGH.scope.transform.localScale = IDMNLHEFKGH.mStartScale;
			PAMJKKMGFFM.gameObject.SetActive(value: false);
			PAMJKKMGFFM.Render();
			PLCKEBOHBEA();
			base.gameObject.SetActive(value: false);
			ODKHLNBKFFL = true;
		}
	}

	private void FBCMJAMFNCL(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.None;
		base.gameObject.SetActive(value: false);
	}

	public void ECAADOCAOHL(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 1234f;
		}
		TweenFOV.Begin(PAMJKKMGFFM.gameObject, 171f, ODENHCLHCIL);
	}

	protected virtual void MNAJGMAFJGL()
	{
		base.Awake();
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: false);
		NEJBJAIBKAI = GetComponent<Renderer>();
		Singleton<GameController>.instance.GameStarted += OJDJLDDCNPM;
		Singleton<GameController>.instance.CNPGMMPAGIE(BNEJHLHPJJO);
		GIELOCNNOMA = base.transform.localScale;
		KILFMMCCCAC = ScreenManager.isSmallScreen;
		foreach (Scope item in PADGDOPELEH)
		{
			item.mStartScale = item.scope.transform.localScale;
		}
		SetScope(1);
	}

	public void NOGIKDILBLG()
	{
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = false;
	}

	private void KIJDFAJBJGC(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		PAMJKKMGFFM.gameObject.SetActive(value: true);
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.None;
		base.gameObject.SetActive(value: false);
	}

	private void MKKLKCBMGHN(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		PAMJKKMGFFM.gameObject.SetActive(value: true);
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.Depth;
		base.gameObject.SetActive(value: false);
	}

	public void SetScope(int OPKHOMONAGG)
	{
		foreach (Scope item in PADGDOPELEH)
		{
			item.scope.SetActive(value: false);
		}
		PADGDOPELEH[OPKHOMONAGG].scope.SetActive(value: true);
		NEJBJAIBKAI = PADGDOPELEH[OPKHOMONAGG].scope.GetComponent<Renderer>();
		MKOGHDKDFIN = PADGDOPELEH[OPKHOMONAGG].offset;
		IDMNLHEFKGH = PADGDOPELEH[OPKHOMONAGG];
	}

	public Vector3 LEGMPKJFOJJ(Camera PHHJDIGEOPJ, Vector3 JILEHJEHMJF, Vector3 MKOGHDKDFIN, Bounds MBJLNICGOMO)
	{
		Vector3 vector = JILEHJEHMJF + MKOGHDKDFIN;
		Vector3 result = vector;
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(281f, 908f));
		Vector3 vector3 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1247f, 908f));
		Vector3 vector4 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1474f, 493f));
		if (vector.y - MBJLNICGOMO.extents.y < vector2.y)
		{
			result.y = vector2.y + MBJLNICGOMO.extents.y;
		}
		if (vector.y + MBJLNICGOMO.extents.y > vector4.y)
		{
			result.y = vector4.y - MBJLNICGOMO.extents.y;
			float num = vector.y - vector4.y + MBJLNICGOMO.extents.y;
			float value = num / MBJLNICGOMO.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * 1394f * 356f);
			num = Mathf.Clamp(num, 1188f, MBJLNICGOMO.extents.y + IDMNLHEFKGH.offset.x);
			num = value * IDMNLHEFKGH.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - MBJLNICGOMO.extents.x < vector2.x)
		{
			result.x = vector2.x + MBJLNICGOMO.extents.x;
		}
		if (vector.x + MBJLNICGOMO.extents.x > vector3.x)
		{
			result.x = vector3.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	protected void CLAKINKPCHA()
	{
		HNPNLJHOBID();
	}

	protected virtual void ECCECGGCMHG()
	{
		base.Awake();
		PAMJKKMGFFM.gameObject.SetActive(value: true);
		base.gameObject.SetActive(value: false);
		NEJBJAIBKAI = GetComponent<Renderer>();
		Singleton<GameController>.instance.GameStarted += LOCNFIKIHCF;
		Singleton<GameController>.instance.CNPGMMPAGIE(BNEJHLHPJJO);
		GIELOCNNOMA = base.transform.localScale;
		KILFMMCCCAC = ScreenManager.isSmallScreen;
		foreach (Scope item in PADGDOPELEH)
		{
			item.mStartScale = item.scope.transform.localScale;
		}
		KMBOLDEIBOH(0);
	}

	public void KGEEDMONDMK(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 1274f;
		}
		if (!DGFGECMICOK())
		{
			PAMJKKMGFFM.gameObject.SetActive(value: true);
			IDMNLHEFKGH.scope.transform.localScale = Vector3.zero;
			TweenScale.Begin(IDMNLHEFKGH.scope, 354f, Vector3.zero, IDMNLHEFKGH.mStartScale);
			TweenFOV.Begin(Singleton<SniperScope>.instance.PAMJKKMGFFM.gameObject, 1117f, ODENHCLHCIL);
			base.gameObject.SetActive(value: true);
			ODKHLNBKFFL = true;
		}
	}

	private void BOGCLLNHLNO()
	{
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.Depth;
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: true);
	}

	public void EKGIMBEJLFH(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 224f;
		}
		if (!FPBJEDIJNFK())
		{
			PAMJKKMGFFM.gameObject.SetActive(value: true);
			IDMNLHEFKGH.scope.transform.localScale = Vector3.zero;
			TweenScale.Begin(IDMNLHEFKGH.scope, 612f, Vector3.zero, IDMNLHEFKGH.mStartScale);
			TweenFOV.Begin(Singleton<SniperScope>.instance.PAMJKKMGFFM.gameObject, 1162f, ODENHCLHCIL);
			base.gameObject.SetActive(value: false);
			ODKHLNBKFFL = true;
		}
	}

	public void ILFJPOOMFDO()
	{
		if (!PLCILPADKCA())
		{
			IDMNLHEFKGH.scope.transform.localScale = IDMNLHEFKGH.mStartScale;
			PAMJKKMGFFM.gameObject.SetActive(value: true);
			PAMJKKMGFFM.Render();
			HNPNLJHOBID();
			base.gameObject.SetActive(value: false);
			ODKHLNBKFFL = true;
		}
	}

	public void DLCFAJEFLHO(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 422f;
		}
		if (!FPBJEDIJNFK())
		{
			PAMJKKMGFFM.gameObject.SetActive(value: false);
			IDMNLHEFKGH.scope.transform.localScale = Vector3.zero;
			TweenScale.Begin(IDMNLHEFKGH.scope, 1625f, Vector3.zero, IDMNLHEFKGH.mStartScale);
			TweenFOV.Begin(Singleton<SniperScope>.instance.PAMJKKMGFFM.gameObject, 1244f, ODENHCLHCIL);
			base.gameObject.SetActive(value: false);
			ODKHLNBKFFL = true;
		}
	}

	public Vector3 DPHCJNOPKIJ(Camera PHHJDIGEOPJ, Vector3 JILEHJEHMJF, Vector3 MKOGHDKDFIN, Bounds MBJLNICGOMO)
	{
		Vector3 vector = JILEHJEHMJF + MKOGHDKDFIN;
		Vector3 result = vector;
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(392f, 1796f));
		Vector3 vector3 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(225f, 930f));
		Vector3 vector4 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(541f, 1319f));
		if (vector.y - MBJLNICGOMO.extents.y < vector2.y)
		{
			result.y = vector2.y + MBJLNICGOMO.extents.y;
		}
		if (vector.y + MBJLNICGOMO.extents.y > vector4.y)
		{
			result.y = vector4.y - MBJLNICGOMO.extents.y;
			float num = vector.y - vector4.y + MBJLNICGOMO.extents.y;
			float value = num / MBJLNICGOMO.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * 1300f * 370f);
			num = Mathf.Clamp(num, 671f, MBJLNICGOMO.extents.y + IDMNLHEFKGH.offset.x);
			num = value * IDMNLHEFKGH.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - MBJLNICGOMO.extents.x < vector2.x)
		{
			result.x = vector2.x + MBJLNICGOMO.extents.x;
		}
		if (vector.x + MBJLNICGOMO.extents.x > vector3.x)
		{
			result.x = vector3.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	public void Hide()
	{
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = false;
	}

	protected void Update()
	{
		IGHJKFNGNGL();
	}

	public void EEOKJCKNEAL(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 682f;
		}
		if (!FPBJEDIJNFK())
		{
			PAMJKKMGFFM.gameObject.SetActive(value: false);
			IDMNLHEFKGH.scope.transform.localScale = Vector3.zero;
			TweenScale.Begin(IDMNLHEFKGH.scope, 1193f, Vector3.zero, IDMNLHEFKGH.mStartScale);
			TweenFOV.Begin(Singleton<SniperScope>.instance.PAMJKKMGFFM.gameObject, 1167f, ODENHCLHCIL);
			base.gameObject.SetActive(value: true);
			ODKHLNBKFFL = false;
		}
	}

	[SpecialName]
	public bool FPBJEDIJNFK()
	{
		return ODKHLNBKFFL;
	}

	public Vector3 NGIEFOOJFJN(Camera PHHJDIGEOPJ, Vector3 JILEHJEHMJF, Vector3 MKOGHDKDFIN, Bounds MBJLNICGOMO)
	{
		Vector3 vector = JILEHJEHMJF + MKOGHDKDFIN;
		Vector3 result = vector;
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(767f, 94f));
		Vector3 vector3 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1930f, 1954f));
		Vector3 vector4 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(817f, 564f));
		if (vector.y - MBJLNICGOMO.extents.y < vector2.y)
		{
			result.y = vector2.y + MBJLNICGOMO.extents.y;
		}
		if (vector.y + MBJLNICGOMO.extents.y > vector4.y)
		{
			result.y = vector4.y - MBJLNICGOMO.extents.y;
			float num = vector.y - vector4.y + MBJLNICGOMO.extents.y;
			float value = num / MBJLNICGOMO.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * 146f * 530f);
			num = Mathf.Clamp(num, 422f, MBJLNICGOMO.extents.y + IDMNLHEFKGH.offset.x);
			num = value * IDMNLHEFKGH.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - MBJLNICGOMO.extents.x < vector2.x)
		{
			result.x = vector2.x + MBJLNICGOMO.extents.x;
		}
		if (vector.x + MBJLNICGOMO.extents.x > vector3.x)
		{
			result.x = vector3.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	public void IAFCNNILJEJ(int OPKHOMONAGG)
	{
		foreach (Scope item in PADGDOPELEH)
		{
			item.scope.SetActive(value: false);
		}
		PADGDOPELEH[OPKHOMONAGG].scope.SetActive(value: true);
		NEJBJAIBKAI = PADGDOPELEH[OPKHOMONAGG].scope.GetComponent<Renderer>();
		MKOGHDKDFIN = PADGDOPELEH[OPKHOMONAGG].offset;
		IDMNLHEFKGH = PADGDOPELEH[OPKHOMONAGG];
	}

	public void GKAOMCGCDGE()
	{
		if (!FPBJEDIJNFK())
		{
			IDMNLHEFKGH.scope.transform.localScale = IDMNLHEFKGH.mStartScale;
			PAMJKKMGFFM.gameObject.SetActive(value: false);
			PAMJKKMGFFM.Render();
			PLCKEBOHBEA();
			base.gameObject.SetActive(value: false);
			ODKHLNBKFFL = true;
		}
	}

	private void BNEJHLHPJJO(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.None;
		base.gameObject.SetActive(value: true);
	}

	public Vector3 GCCGLOABFIA(Camera PHHJDIGEOPJ, Vector3 JILEHJEHMJF, Vector3 MKOGHDKDFIN, Bounds MBJLNICGOMO)
	{
		Vector3 vector = JILEHJEHMJF + MKOGHDKDFIN;
		Vector3 result = vector;
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(804f, 901f));
		Vector3 vector3 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1510f, 1895f));
		Vector3 vector4 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(65f, 588f));
		if (vector.y - MBJLNICGOMO.extents.y < vector2.y)
		{
			result.y = vector2.y + MBJLNICGOMO.extents.y;
		}
		if (vector.y + MBJLNICGOMO.extents.y > vector4.y)
		{
			result.y = vector4.y - MBJLNICGOMO.extents.y;
			float num = vector.y - vector4.y + MBJLNICGOMO.extents.y;
			float value = num / MBJLNICGOMO.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * 1098f * 1939f);
			num = Mathf.Clamp(num, 1982f, MBJLNICGOMO.extents.y + IDMNLHEFKGH.offset.x);
			num = value * IDMNLHEFKGH.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - MBJLNICGOMO.extents.x < vector2.x)
		{
			result.x = vector2.x + MBJLNICGOMO.extents.x;
		}
		if (vector.x + MBJLNICGOMO.extents.x > vector3.x)
		{
			result.x = vector3.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	private void PLCKEBOHBEA()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1173f));
		Vector3 normalized = ray.direction.normalized;
		PAMJKKMGFFM.transform.position = Camera.main.transform.position;
		PAMJKKMGFFM.transform.rotation = Quaternion.LookRotation(normalized);
		Vector3 vector = HealthBarManager.FCLNJOLBKGI().KPDAPFBIPAI.transform.position + new Vector3(1217f, 392f, HealthBarManager.BNDNFHKPDLM().KPDAPFBIPAI.nearClipPlane + 1053f);
		Vector3 vector2 = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(Camera.main.WorldToNormalizedViewportPoint(point));
		vector2.z = vector.z;
		Vector3 mKOGHDKDFIN = new Vector3(MKOGHDKDFIN.x * (IDMNLHEFKGH.scope.transform.localScale.x / IDMNLHEFKGH.mStartScale.x), MKOGHDKDFIN.y * (IDMNLHEFKGH.scope.transform.localScale.y / IDMNLHEFKGH.mStartScale.y), MKOGHDKDFIN.z * (IDMNLHEFKGH.scope.transform.localScale.z / IDMNLHEFKGH.mStartScale.z));
		Vector3 jILEHJEHMJF = vector2;
		jILEHJEHMJF = NPIGNFOBBNN(HealthBarManager.DFEGDLAEHLH().KPDAPFBIPAI, jILEHJEHMJF, mKOGHDKDFIN, NEJBJAIBKAI.bounds);
		base.transform.position = jILEHJEHMJF;
	}

	private void MAEFIMIEINH(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.None;
		base.gameObject.SetActive(value: false);
	}

	private void IGHJKFNGNGL()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4f));
		Vector3 normalized = ray.direction.normalized;
		PAMJKKMGFFM.transform.position = Camera.main.transform.position;
		PAMJKKMGFFM.transform.rotation = Quaternion.LookRotation(normalized);
		Vector3 vector = HealthBarManager.instance.KPDAPFBIPAI.transform.position + new Vector3(0f, 0f, HealthBarManager.instance.KPDAPFBIPAI.nearClipPlane + 3f);
		Vector3 vector2 = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(Camera.main.WorldToNormalizedViewportPoint(point));
		vector2.z = vector.z;
		Vector3 mKOGHDKDFIN = new Vector3(MKOGHDKDFIN.x * (IDMNLHEFKGH.scope.transform.localScale.x / IDMNLHEFKGH.mStartScale.x), MKOGHDKDFIN.y * (IDMNLHEFKGH.scope.transform.localScale.y / IDMNLHEFKGH.mStartScale.y), MKOGHDKDFIN.z * (IDMNLHEFKGH.scope.transform.localScale.z / IDMNLHEFKGH.mStartScale.z));
		Vector3 jILEHJEHMJF = vector2;
		jILEHJEHMJF = ClampInScreenXY(HealthBarManager.instance.KPDAPFBIPAI, jILEHJEHMJF, mKOGHDKDFIN, NEJBJAIBKAI.bounds);
		base.transform.position = jILEHJEHMJF;
	}

	protected void CDJBEAIDHKH()
	{
		HNPNLJHOBID();
	}

	public void DPDNJFAKNCM()
	{
		if (!FPBJEDIJNFK())
		{
			IDMNLHEFKGH.scope.transform.localScale = IDMNLHEFKGH.mStartScale;
			PAMJKKMGFFM.gameObject.SetActive(value: true);
			PAMJKKMGFFM.Render();
			HNPNLJHOBID();
			base.gameObject.SetActive(value: true);
			ODKHLNBKFFL = true;
		}
	}

	private void EHEKKMAKDJN(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		PAMJKKMGFFM.gameObject.SetActive(value: true);
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.None;
		base.gameObject.SetActive(value: true);
	}

	public void ADHICIANKKC(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 1590f;
		}
		TweenFOV.Begin(PAMJKKMGFFM.gameObject, 1313f, ODENHCLHCIL);
	}

	private void ACLCPJHKHLL()
	{
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.None;
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: false);
	}

	public void Show(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 0.57f;
		}
		if (!showed)
		{
			PAMJKKMGFFM.gameObject.SetActive(value: true);
			IDMNLHEFKGH.scope.transform.localScale = Vector3.zero;
			TweenScale.Begin(IDMNLHEFKGH.scope, 0.25f, Vector3.zero, IDMNLHEFKGH.mStartScale);
			TweenFOV.Begin(Singleton<SniperScope>.instance.PAMJKKMGFFM.gameObject, 0.1f, ODENHCLHCIL);
			base.gameObject.SetActive(value: true);
			ODKHLNBKFFL = true;
		}
	}

	private void LOCNFIKIHCF()
	{
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.None;
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: true);
	}

	public void DMLDBKFCACB()
	{
		if (!FPBJEDIJNFK())
		{
			IDMNLHEFKGH.scope.transform.localScale = IDMNLHEFKGH.mStartScale;
			PAMJKKMGFFM.gameObject.SetActive(value: false);
			PAMJKKMGFFM.Render();
			PLCKEBOHBEA();
			base.gameObject.SetActive(value: true);
			ODKHLNBKFFL = true;
		}
	}

	public void CALBGDIEDGA()
	{
		if (!IMDEOPABKGK())
		{
			IDMNLHEFKGH.scope.transform.localScale = IDMNLHEFKGH.mStartScale;
			PAMJKKMGFFM.gameObject.SetActive(value: true);
			PAMJKKMGFFM.Render();
			NIHDHHGAPNN();
			base.gameObject.SetActive(value: true);
			ODKHLNBKFFL = true;
		}
	}

	public void ECBMHNDPENI(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 91f;
		}
		if (!showed)
		{
			PAMJKKMGFFM.gameObject.SetActive(value: true);
			IDMNLHEFKGH.scope.transform.localScale = Vector3.zero;
			TweenScale.Begin(IDMNLHEFKGH.scope, 974f, Vector3.zero, IDMNLHEFKGH.mStartScale);
			TweenFOV.Begin(Singleton<SniperScope>.instance.PAMJKKMGFFM.gameObject, 717f, ODENHCLHCIL);
			base.gameObject.SetActive(value: true);
			ODKHLNBKFFL = false;
		}
	}

	public Vector3 ECFCKFMHKDB(Camera PHHJDIGEOPJ, Vector3 JILEHJEHMJF, Vector3 MKOGHDKDFIN, Bounds MBJLNICGOMO)
	{
		Vector3 vector = JILEHJEHMJF + MKOGHDKDFIN;
		Vector3 result = vector;
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1565f, 4f));
		Vector3 vector3 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(369f, 1073f));
		Vector3 vector4 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(579f, 448f));
		if (vector.y - MBJLNICGOMO.extents.y < vector2.y)
		{
			result.y = vector2.y + MBJLNICGOMO.extents.y;
		}
		if (vector.y + MBJLNICGOMO.extents.y > vector4.y)
		{
			result.y = vector4.y - MBJLNICGOMO.extents.y;
			float num = vector.y - vector4.y + MBJLNICGOMO.extents.y;
			float value = num / MBJLNICGOMO.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * 1737f * 833f);
			num = Mathf.Clamp(num, 700f, MBJLNICGOMO.extents.y + IDMNLHEFKGH.offset.x);
			num = value * IDMNLHEFKGH.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - MBJLNICGOMO.extents.x < vector2.x)
		{
			result.x = vector2.x + MBJLNICGOMO.extents.x;
		}
		if (vector.x + MBJLNICGOMO.extents.x > vector3.x)
		{
			result.x = vector3.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	public Vector3 EOCLIDCBMMM(Camera PHHJDIGEOPJ, Vector3 JILEHJEHMJF, Vector3 MKOGHDKDFIN, Bounds MBJLNICGOMO)
	{
		Vector3 vector = JILEHJEHMJF + MKOGHDKDFIN;
		Vector3 result = vector;
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1563f, 1680f));
		Vector3 vector3 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1408f, 1147f));
		Vector3 vector4 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1193f, 1930f));
		if (vector.y - MBJLNICGOMO.extents.y < vector2.y)
		{
			result.y = vector2.y + MBJLNICGOMO.extents.y;
		}
		if (vector.y + MBJLNICGOMO.extents.y > vector4.y)
		{
			result.y = vector4.y - MBJLNICGOMO.extents.y;
			float num = vector.y - vector4.y + MBJLNICGOMO.extents.y;
			float value = num / MBJLNICGOMO.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * 1314f * 1630f);
			num = Mathf.Clamp(num, 1106f, MBJLNICGOMO.extents.y + IDMNLHEFKGH.offset.x);
			num = value * IDMNLHEFKGH.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - MBJLNICGOMO.extents.x < vector2.x)
		{
			result.x = vector2.x + MBJLNICGOMO.extents.x;
		}
		if (vector.x + MBJLNICGOMO.extents.x > vector3.x)
		{
			result.x = vector3.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	[SpecialName]
	public bool DGFGECMICOK()
	{
		return ODKHLNBKFFL;
	}

	public void EGJBBJMJBHO()
	{
		PAMJKKMGFFM.gameObject.SetActive(value: true);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = false;
	}

	public void CMBAFEKOAPH(int OPKHOMONAGG)
	{
		foreach (Scope item in PADGDOPELEH)
		{
			item.scope.SetActive(value: false);
		}
		PADGDOPELEH[OPKHOMONAGG].scope.SetActive(value: true);
		NEJBJAIBKAI = PADGDOPELEH[OPKHOMONAGG].scope.GetComponent<Renderer>();
		MKOGHDKDFIN = PADGDOPELEH[OPKHOMONAGG].offset;
		IDMNLHEFKGH = PADGDOPELEH[OPKHOMONAGG];
	}

	public void EMHDIDDOPGE(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 703f;
		}
		TweenFOV.Begin(PAMJKKMGFFM.gameObject, 275f, ODENHCLHCIL);
	}

	public void CDNBOOFINNL(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 97f;
		}
		TweenFOV.Begin(PAMJKKMGFFM.gameObject, 1177f, ODENHCLHCIL);
	}

	protected override void Awake()
	{
		base.Awake();
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: false);
		NEJBJAIBKAI = GetComponent<Renderer>();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		Singleton<GameController>.instance.GameEnded += FBCMJAMFNCL;
		GIELOCNNOMA = base.transform.localScale;
		KILFMMCCCAC = ScreenManager.isSmallScreen;
		foreach (Scope item in PADGDOPELEH)
		{
			item.mStartScale = item.scope.transform.localScale;
		}
		SetScope(0);
	}

	public Vector3 NPIGNFOBBNN(Camera PHHJDIGEOPJ, Vector3 JILEHJEHMJF, Vector3 MKOGHDKDFIN, Bounds MBJLNICGOMO)
	{
		Vector3 vector = JILEHJEHMJF + MKOGHDKDFIN;
		Vector3 result = vector;
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(685f, 1679f));
		Vector3 vector3 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1175f, 1042f));
		Vector3 vector4 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(176f, 287f));
		if (vector.y - MBJLNICGOMO.extents.y < vector2.y)
		{
			result.y = vector2.y + MBJLNICGOMO.extents.y;
		}
		if (vector.y + MBJLNICGOMO.extents.y > vector4.y)
		{
			result.y = vector4.y - MBJLNICGOMO.extents.y;
			float num = vector.y - vector4.y + MBJLNICGOMO.extents.y;
			float value = num / MBJLNICGOMO.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * 1573f * 357f);
			num = Mathf.Clamp(num, 1968f, MBJLNICGOMO.extents.y + IDMNLHEFKGH.offset.x);
			num = value * IDMNLHEFKGH.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - MBJLNICGOMO.extents.x < vector2.x)
		{
			result.x = vector2.x + MBJLNICGOMO.extents.x;
		}
		if (vector.x + MBJLNICGOMO.extents.x > vector3.x)
		{
			result.x = vector3.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	public void GKKFPJHEEDG(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 1564f;
		}
		if (!DGFGECMICOK())
		{
			PAMJKKMGFFM.gameObject.SetActive(value: true);
			IDMNLHEFKGH.scope.transform.localScale = Vector3.zero;
			TweenScale.Begin(IDMNLHEFKGH.scope, 498f, Vector3.zero, IDMNLHEFKGH.mStartScale);
			TweenFOV.Begin(Singleton<SniperScope>.instance.PAMJKKMGFFM.gameObject, 1972f, ODENHCLHCIL);
			base.gameObject.SetActive(value: true);
			ODKHLNBKFFL = true;
		}
	}

	private void HNPNLJHOBID()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 907f));
		Vector3 normalized = ray.direction.normalized;
		PAMJKKMGFFM.transform.position = Camera.main.transform.position;
		PAMJKKMGFFM.transform.rotation = Quaternion.LookRotation(normalized);
		Vector3 vector = HealthBarManager.OFLMKOOONKH().KPDAPFBIPAI.transform.position + new Vector3(768f, 1061f, HealthBarManager.KHMBHIINOFD().KPDAPFBIPAI.nearClipPlane + 775f);
		Vector3 vector2 = HealthBarManager.ALODNGEMIMO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(Camera.main.WorldToNormalizedViewportPoint(point));
		vector2.z = vector.z;
		Vector3 mKOGHDKDFIN = new Vector3(MKOGHDKDFIN.x * (IDMNLHEFKGH.scope.transform.localScale.x / IDMNLHEFKGH.mStartScale.x), MKOGHDKDFIN.y * (IDMNLHEFKGH.scope.transform.localScale.y / IDMNLHEFKGH.mStartScale.y), MKOGHDKDFIN.z * (IDMNLHEFKGH.scope.transform.localScale.z / IDMNLHEFKGH.mStartScale.z));
		Vector3 jILEHJEHMJF = vector2;
		jILEHJEHMJF = EOCLIDCBMMM(HealthBarManager.OGBIHEFNJGO().KPDAPFBIPAI, jILEHJEHMJF, mKOGHDKDFIN, NEJBJAIBKAI.bounds);
		base.transform.position = jILEHJEHMJF;
	}

	public void NLEKBKHPEJI()
	{
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	protected virtual void ABMKKECEGIB()
	{
		base.Awake();
		PAMJKKMGFFM.gameObject.SetActive(value: true);
		base.gameObject.SetActive(value: true);
		NEJBJAIBKAI = GetComponent<Renderer>();
		Singleton<GameController>.instance.GameStarted += OJDJLDDCNPM;
		Singleton<GameController>.instance.CNPGMMPAGIE(FBCMJAMFNCL);
		GIELOCNNOMA = base.transform.localScale;
		KILFMMCCCAC = ScreenManager.isSmallScreen;
		foreach (Scope item in PADGDOPELEH)
		{
			item.mStartScale = item.scope.transform.localScale;
		}
		LAPHAJIOIAE(0);
	}

	private void BMKKOEJJCGM()
	{
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.Depth;
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: false);
	}

	public void DIBLFOPCCPL()
	{
		if (!showed)
		{
			IDMNLHEFKGH.scope.transform.localScale = IDMNLHEFKGH.mStartScale;
			PAMJKKMGFFM.gameObject.SetActive(value: false);
			PAMJKKMGFFM.Render();
			HNPNLJHOBID();
			base.gameObject.SetActive(value: false);
			ODKHLNBKFFL = true;
		}
	}

	public void LAPHAJIOIAE(int OPKHOMONAGG)
	{
		foreach (Scope item in PADGDOPELEH)
		{
			item.scope.SetActive(value: true);
		}
		PADGDOPELEH[OPKHOMONAGG].scope.SetActive(value: true);
		NEJBJAIBKAI = PADGDOPELEH[OPKHOMONAGG].scope.GetComponent<Renderer>();
		MKOGHDKDFIN = PADGDOPELEH[OPKHOMONAGG].offset;
		IDMNLHEFKGH = PADGDOPELEH[OPKHOMONAGG];
	}

	public void MICFIMBLPEL(int OPKHOMONAGG)
	{
		foreach (Scope item in PADGDOPELEH)
		{
			item.scope.SetActive(value: false);
		}
		PADGDOPELEH[OPKHOMONAGG].scope.SetActive(value: false);
		NEJBJAIBKAI = PADGDOPELEH[OPKHOMONAGG].scope.GetComponent<Renderer>();
		MKOGHDKDFIN = PADGDOPELEH[OPKHOMONAGG].offset;
		IDMNLHEFKGH = PADGDOPELEH[OPKHOMONAGG];
	}

	public void DFHDHPGPLBP(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 950f;
		}
		TweenFOV.Begin(PAMJKKMGFFM.gameObject, 1490f, ODENHCLHCIL);
	}

	protected virtual void AKKKDIBLICM()
	{
		base.Awake();
		PAMJKKMGFFM.gameObject.SetActive(value: true);
		base.gameObject.SetActive(value: false);
		NEJBJAIBKAI = GetComponent<Renderer>();
		Singleton<GameController>.instance.GameStarted += LOCNFIKIHCF;
		Singleton<GameController>.instance.CNPGMMPAGIE(GAPAJLFMPBP);
		GIELOCNNOMA = base.transform.localScale;
		KILFMMCCCAC = ScreenManager.isSmallScreen;
		foreach (Scope item in PADGDOPELEH)
		{
			item.mStartScale = item.scope.transform.localScale;
		}
		SetScope(1);
	}

	private void OJDJLDDCNPM()
	{
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.None;
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: false);
	}

	[SpecialName]
	public bool PLCILPADKCA()
	{
		return ODKHLNBKFFL;
	}

	public Vector3 OLGOEBGBEJE(Camera PHHJDIGEOPJ, Vector3 JILEHJEHMJF, Vector3 MKOGHDKDFIN, Bounds MBJLNICGOMO)
	{
		Vector3 vector = JILEHJEHMJF + MKOGHDKDFIN;
		Vector3 result = vector;
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(338f, 24f));
		Vector3 vector3 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(807f, 967f));
		Vector3 vector4 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(358f, 1601f));
		if (vector.y - MBJLNICGOMO.extents.y < vector2.y)
		{
			result.y = vector2.y + MBJLNICGOMO.extents.y;
		}
		if (vector.y + MBJLNICGOMO.extents.y > vector4.y)
		{
			result.y = vector4.y - MBJLNICGOMO.extents.y;
			float num = vector.y - vector4.y + MBJLNICGOMO.extents.y;
			float value = num / MBJLNICGOMO.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * 1146f * 1448f);
			num = Mathf.Clamp(num, 1394f, MBJLNICGOMO.extents.y + IDMNLHEFKGH.offset.x);
			num = value * IDMNLHEFKGH.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - MBJLNICGOMO.extents.x < vector2.x)
		{
			result.x = vector2.x + MBJLNICGOMO.extents.x;
		}
		if (vector.x + MBJLNICGOMO.extents.x > vector3.x)
		{
			result.x = vector3.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		PAMJKKMGFFM.gameObject.SetActive(value: true);
		base.gameObject.SetActive(value: true);
		NEJBJAIBKAI = GetComponent<Renderer>();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		Singleton<GameController>.instance.CNPGMMPAGIE(KIJDFAJBJGC);
		GIELOCNNOMA = base.transform.localScale;
		KILFMMCCCAC = ScreenManager.isSmallScreen;
		foreach (Scope item in PADGDOPELEH)
		{
			item.mStartScale = item.scope.transform.localScale;
		}
		SetScope(1);
	}

	public void Show()
	{
		if (!showed)
		{
			IDMNLHEFKGH.scope.transform.localScale = IDMNLHEFKGH.mStartScale;
			PAMJKKMGFFM.gameObject.SetActive(value: true);
			PAMJKKMGFFM.Render();
			IGHJKFNGNGL();
			base.gameObject.SetActive(value: true);
			ODKHLNBKFFL = true;
		}
	}

	protected void LMNEMMGCEFP()
	{
		PLCKEBOHBEA();
	}

	protected void JNDLGOABMKC()
	{
		HNPNLJHOBID();
	}

	public void BLFNIFFFAIJ()
	{
		if (!FPBJEDIJNFK())
		{
			IDMNLHEFKGH.scope.transform.localScale = IDMNLHEFKGH.mStartScale;
			PAMJKKMGFFM.gameObject.SetActive(value: true);
			PAMJKKMGFFM.Render();
			PLCKEBOHBEA();
			base.gameObject.SetActive(value: false);
			ODKHLNBKFFL = false;
		}
	}

	protected virtual void FNJKFDOMGOO()
	{
		base.Awake();
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: true);
		NEJBJAIBKAI = GetComponent<Renderer>();
		Singleton<GameController>.instance.GameStarted += LOCNFIKIHCF;
		Singleton<GameController>.instance.CNPGMMPAGIE(GAPAJLFMPBP);
		GIELOCNNOMA = base.transform.localScale;
		KILFMMCCCAC = ScreenManager.isSmallScreen;
		foreach (Scope item in PADGDOPELEH)
		{
			item.mStartScale = item.scope.transform.localScale;
		}
		LAPHAJIOIAE(1);
	}

	public void AnimFov(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 0.57f;
		}
		TweenFOV.Begin(PAMJKKMGFFM.gameObject, 0.5f, ODENHCLHCIL);
	}

	protected void OFDJHFMAJBI()
	{
		PLCKEBOHBEA();
	}

	protected void IDPOHKDKDNL()
	{
		PLCKEBOHBEA();
	}

	public void PHEFLAHPMDH(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 50f;
		}
		if (!DGFGECMICOK())
		{
			PAMJKKMGFFM.gameObject.SetActive(value: false);
			IDMNLHEFKGH.scope.transform.localScale = Vector3.zero;
			TweenScale.Begin(IDMNLHEFKGH.scope, 1707f, Vector3.zero, IDMNLHEFKGH.mStartScale);
			TweenFOV.Begin(Singleton<SniperScope>.instance.PAMJKKMGFFM.gameObject, 174f, ODENHCLHCIL);
			base.gameObject.SetActive(value: false);
			ODKHLNBKFFL = true;
		}
	}

	public void ONCKKJFAMKF(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 1182f;
		}
		if (!PLCILPADKCA())
		{
			PAMJKKMGFFM.gameObject.SetActive(value: false);
			IDMNLHEFKGH.scope.transform.localScale = Vector3.zero;
			TweenScale.Begin(IDMNLHEFKGH.scope, 1661f, Vector3.zero, IDMNLHEFKGH.mStartScale);
			TweenFOV.Begin(Singleton<SniperScope>.instance.PAMJKKMGFFM.gameObject, 1813f, ODENHCLHCIL);
			base.gameObject.SetActive(value: true);
			ODKHLNBKFFL = true;
		}
	}

	private void NCGGIEJPFJL(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		PAMJKKMGFFM.gameObject.SetActive(value: true);
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.Depth;
		base.gameObject.SetActive(value: true);
	}

	public void DCIPJFNIMNH(int OPKHOMONAGG)
	{
		foreach (Scope item in PADGDOPELEH)
		{
			item.scope.SetActive(value: true);
		}
		PADGDOPELEH[OPKHOMONAGG].scope.SetActive(value: true);
		NEJBJAIBKAI = PADGDOPELEH[OPKHOMONAGG].scope.GetComponent<Renderer>();
		MKOGHDKDFIN = PADGDOPELEH[OPKHOMONAGG].offset;
		IDMNLHEFKGH = PADGDOPELEH[OPKHOMONAGG];
	}

	public void NNJDPMOGPLK(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 1896f;
		}
		TweenFOV.Begin(PAMJKKMGFFM.gameObject, 239f, ODENHCLHCIL);
	}

	public void IFGMJHLIPJL()
	{
		PAMJKKMGFFM.gameObject.SetActive(value: true);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	[SpecialName]
	public bool IMDEOPABKGK()
	{
		return ODKHLNBKFFL;
	}

	public void OFPAGLLFPPK(float ODENHCLHCIL)
	{
		if (KILFMMCCCAC)
		{
			ODENHCLHCIL *= 128f;
		}
		if (!IMDEOPABKGK())
		{
			PAMJKKMGFFM.gameObject.SetActive(value: true);
			IDMNLHEFKGH.scope.transform.localScale = Vector3.zero;
			TweenScale.Begin(IDMNLHEFKGH.scope, 10f, Vector3.zero, IDMNLHEFKGH.mStartScale);
			TweenFOV.Begin(Singleton<SniperScope>.instance.PAMJKKMGFFM.gameObject, 543f, ODENHCLHCIL);
			base.gameObject.SetActive(value: false);
			ODKHLNBKFFL = true;
		}
	}

	private void NIHDHHGAPNN()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 83f));
		Vector3 normalized = ray.direction.normalized;
		PAMJKKMGFFM.transform.position = Camera.main.transform.position;
		PAMJKKMGFFM.transform.rotation = Quaternion.LookRotation(normalized);
		Vector3 vector = HealthBarManager.BMNEPICFHNO().KPDAPFBIPAI.transform.position + new Vector3(1642f, 310f, HealthBarManager.instance.KPDAPFBIPAI.nearClipPlane + 1222f);
		Vector3 vector2 = HealthBarManager.MCJOOEEIIHI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(Camera.main.WorldToNormalizedViewportPoint(point));
		vector2.z = vector.z;
		Vector3 mKOGHDKDFIN = new Vector3(MKOGHDKDFIN.x * (IDMNLHEFKGH.scope.transform.localScale.x / IDMNLHEFKGH.mStartScale.x), MKOGHDKDFIN.y * (IDMNLHEFKGH.scope.transform.localScale.y / IDMNLHEFKGH.mStartScale.y), MKOGHDKDFIN.z * (IDMNLHEFKGH.scope.transform.localScale.z / IDMNLHEFKGH.mStartScale.z));
		Vector3 jILEHJEHMJF = vector2;
		jILEHJEHMJF = EOCLIDCBMMM(HealthBarManager.MCJOOEEIIHI().KPDAPFBIPAI, jILEHJEHMJF, mKOGHDKDFIN, NEJBJAIBKAI.bounds);
		base.transform.position = jILEHJEHMJF;
	}

	private void GAPAJLFMPBP(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.None;
		base.gameObject.SetActive(value: true);
	}

	private void CIAAMDIEFPK(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		PAMJKKMGFFM.gameObject.SetActive(value: true);
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.None;
		base.gameObject.SetActive(value: false);
	}

	public void KMBOLDEIBOH(int OPKHOMONAGG)
	{
		foreach (Scope item in PADGDOPELEH)
		{
			item.scope.SetActive(value: false);
		}
		PADGDOPELEH[OPKHOMONAGG].scope.SetActive(value: true);
		NEJBJAIBKAI = PADGDOPELEH[OPKHOMONAGG].scope.GetComponent<Renderer>();
		MKOGHDKDFIN = PADGDOPELEH[OPKHOMONAGG].offset;
		IDMNLHEFKGH = PADGDOPELEH[OPKHOMONAGG];
	}

	private void MLBGDCLNGLL(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.Depth;
		base.gameObject.SetActive(value: false);
	}

	private void DNKOACLLOAC(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.None;
		base.gameObject.SetActive(value: true);
	}

	public Vector3 MFKJOGCLGJM(Camera PHHJDIGEOPJ, Vector3 JILEHJEHMJF, Vector3 MKOGHDKDFIN, Bounds MBJLNICGOMO)
	{
		Vector3 vector = JILEHJEHMJF + MKOGHDKDFIN;
		Vector3 result = vector;
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(128f, 736f));
		Vector3 vector3 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(916f, 1967f));
		Vector3 vector4 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(405f, 48f));
		if (vector.y - MBJLNICGOMO.extents.y < vector2.y)
		{
			result.y = vector2.y + MBJLNICGOMO.extents.y;
		}
		if (vector.y + MBJLNICGOMO.extents.y > vector4.y)
		{
			result.y = vector4.y - MBJLNICGOMO.extents.y;
			float num = vector.y - vector4.y + MBJLNICGOMO.extents.y;
			float value = num / MBJLNICGOMO.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * 958f * 1290f);
			num = Mathf.Clamp(num, 1865f, MBJLNICGOMO.extents.y + IDMNLHEFKGH.offset.x);
			num = value * IDMNLHEFKGH.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - MBJLNICGOMO.extents.x < vector2.x)
		{
			result.x = vector2.x + MBJLNICGOMO.extents.x;
		}
		if (vector.x + MBJLNICGOMO.extents.x > vector3.x)
		{
			result.x = vector3.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	public Vector3 JFJGAEAPFKP(Camera PHHJDIGEOPJ, Vector3 JILEHJEHMJF, Vector3 MKOGHDKDFIN, Bounds MBJLNICGOMO)
	{
		Vector3 vector = JILEHJEHMJF + MKOGHDKDFIN;
		Vector3 result = vector;
		Vector3 vector2 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(440f, 1344f));
		Vector3 vector3 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(364f, 89f));
		Vector3 vector4 = PHHJDIGEOPJ.ViewportToWorldPoint(new Vector2(1666f, 521f));
		if (vector.y - MBJLNICGOMO.extents.y < vector2.y)
		{
			result.y = vector2.y + MBJLNICGOMO.extents.y;
		}
		if (vector.y + MBJLNICGOMO.extents.y > vector4.y)
		{
			result.y = vector4.y - MBJLNICGOMO.extents.y;
			float num = vector.y - vector4.y + MBJLNICGOMO.extents.y;
			float value = num / MBJLNICGOMO.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * 1469f * 367f);
			num = Mathf.Clamp(num, 384f, MBJLNICGOMO.extents.y + IDMNLHEFKGH.offset.x);
			num = value * IDMNLHEFKGH.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - MBJLNICGOMO.extents.x < vector2.x)
		{
			result.x = vector2.x + MBJLNICGOMO.extents.x;
		}
		if (vector.x + MBJLNICGOMO.extents.x > vector3.x)
		{
			result.x = vector3.x - MBJLNICGOMO.extents.x;
		}
		return result;
	}

	private void ALGPECFCGNK(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		PAMJKKMGFFM.depthTextureMode = DepthTextureMode.Depth;
		base.gameObject.SetActive(value: false);
	}

	protected virtual void HCNOHLLOGBO()
	{
		base.Awake();
		PAMJKKMGFFM.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: true);
		NEJBJAIBKAI = GetComponent<Renderer>();
		Singleton<GameController>.instance.GameStarted += BOGCLLNHLNO;
		Singleton<GameController>.instance.GameEnded += KIJDFAJBJGC;
		GIELOCNNOMA = base.transform.localScale;
		KILFMMCCCAC = ScreenManager.isSmallScreen;
		foreach (Scope item in PADGDOPELEH)
		{
			item.mStartScale = item.scope.transform.localScale;
		}
		SetScope(0);
	}

	protected void JOCHCGHAIGH()
	{
		NIHDHHGAPNN();
	}
}
