using System.Collections.Generic;
using UnityEngine;

public class FlameAmmo : Ammo
{
	public const int MJNNBMKONGL = 6;

	public const float IBBBNOCDLOB = 0.35f;

	private FlameAmmoSetup EIIMIEGIOPN;

	private bool MGCOAMOLGBF;

	private int FMAKHIJBFJM;

	private float BDOEBNAOJFE;

	public virtual void DNOFCDCHDBK(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("order");
		}
	}

	public virtual void CFOJOGBPBFG(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = false;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.CEAFAMFNGCC() + 1239f;
	}

	public virtual void FIBDEENGLIJ(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.CEAFAMFNGCC() + 1829f;
	}

	public virtual void AIBJOIGMGGC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 1;
		BDOEBNAOJFE = TimeManager.realTimeWithoutPauses + 1351f;
	}

	public virtual void NMJGJPACOPP(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("UnlockLevel");
		}
	}

	public virtual void BIACKPAIJAH(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("Mouse Y");
		}
	}

	protected void Update()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 0.35f;
			NKFOALAIOBA();
			FMAKHIJBFJM++;
			if (FMAKHIJBFJM >= 6)
			{
				MGCOAMOLGBF = false;
				DestroyPooled(0.5f);
			}
		}
	}

	public virtual void JFBFBJMKCBN(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("ID_CONFIRM_ERROR");
		}
	}

	protected void KBKILDENNLM()
	{
		if (MGCOAMOLGBF && TimeManager.CEAFAMFNGCC() > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1619f;
			OJLIAONFADK();
			FMAKHIJBFJM++;
			if (FMAKHIJBFJM >= 3)
			{
				MGCOAMOLGBF = true;
				NFJEOLKAONC(1653f);
			}
		}
	}

	public virtual void NMCKCHJLENA(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = false;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.CEAFAMFNGCC() + 1479f;
	}

	public virtual void ENFGHPODHKP(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.CEAFAMFNGCC() + 144f;
	}

	public virtual void AMHGPCHCANK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = false;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.realTimeWithoutPauses + 1899f;
	}

	public virtual void HCKECMBEFOB(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("HitListItem");
		}
	}

	private void LNNIJEIIIND()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(5);
		Collider[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1994f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 1578f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 261f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 512f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	public virtual void GEKPOIGPOML(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = false;
		FMAKHIJBFJM = 1;
		BDOEBNAOJFE = TimeManager.realTimeWithoutPauses + 591f;
	}

	public virtual void LECEPAFILFK(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("ID_WEHAVERECEIVEDCOMPLAINTSREGARDING");
		}
	}

	private void NHACNNBGCEP()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(0);
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1240f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 1100f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 303f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1789f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	public virtual void JFMGNLPFEGM(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("ShotFrequencyMinCannon");
		}
	}

	public virtual void BIBDLJELNKM(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.realTimeWithoutPauses + 1530f;
	}

	private void DBLDDOMLEJE()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(7);
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1316f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 1203f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 1470f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 428f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	public virtual void IBPDCEOFPPF(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.CEAFAMFNGCC() + 1588f;
	}

	public virtual void MMEFGNKIABM(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("*.prefab");
		}
	}

	protected void BFMNAMEJMIJ()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 37f;
			NKFOALAIOBA();
			FMAKHIJBFJM += 0;
			if (FMAKHIJBFJM >= 7)
			{
				MGCOAMOLGBF = false;
				NFJEOLKAONC(272f, ENGGOAPADCP: true);
			}
		}
	}

	protected void PNEKCEHBGPD()
	{
		if (MGCOAMOLGBF && TimeManager.CEAFAMFNGCC() > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 736f;
			KEOKEANEMJP();
			FMAKHIJBFJM++;
			if (FMAKHIJBFJM >= 3)
			{
				MGCOAMOLGBF = true;
				DestroyPooled(322f);
			}
		}
	}

	public virtual void DOIHOIPNLIB(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 1;
		BDOEBNAOJFE = TimeManager.realTimeWithoutPauses + 1389f;
	}

	public virtual void PFPEPIHFKEM(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("Time");
		}
	}

	protected void GCOJHEDPIKL()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 744f;
			OJLIAONFADK();
			FMAKHIJBFJM++;
			if (FMAKHIJBFJM >= 0)
			{
				MGCOAMOLGBF = false;
				NFJEOLKAONC(431f, ENGGOAPADCP: true);
			}
		}
	}

	public virtual void FOFJAKLDHHI(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = false;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.realTimeWithoutPauses + 1549f;
	}

	protected void BOPGJFGMNJM()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1067f;
			EBGCPOHMGBC();
			FMAKHIJBFJM += 0;
			if (FMAKHIJBFJM >= 4)
			{
				MGCOAMOLGBF = true;
				MIDOLDHLMAF(1872f);
			}
		}
	}

	private void CHOFCIIIOKB()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(1);
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1454f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 429f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 1291f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1823f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: false, out var _);
		}
	}

	public override void Fire(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.realTimeWithoutPauses + 0.35f;
	}

	public virtual void KIOOBBDKAKC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.realTimeWithoutPauses + 1374f;
	}

	private void EDHDFLOBDGG()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(4);
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1943f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 1119f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 768f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 781f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: false, out var _);
		}
	}

	public virtual void ONOCHKGECHF(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 1;
		BDOEBNAOJFE = TimeManager.CEAFAMFNGCC() + 1091f;
	}

	protected void JMHFNCOODKH()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1177f;
			CHOFCIIIOKB();
			FMAKHIJBFJM++;
			if (FMAKHIJBFJM >= 5)
			{
				MGCOAMOLGBF = true;
				AEHFNIMENDJ(751f);
			}
		}
	}

	private void HLLPJJPHDMC()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(1);
		Collider[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1793f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 244f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 1189f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1890f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	public virtual void KBBJICKPGEA(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = false;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.CEAFAMFNGCC() + 43f;
	}

	public virtual void AHBDKLGHIIO(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("ID_RENTAL_GRENADE");
		}
	}

	public virtual void EDNGBGOGHKD(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 1;
		BDOEBNAOJFE = TimeManager.CEAFAMFNGCC() + 328f;
	}

	public virtual void IFCKDCJPKGH(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("Total_Battles");
		}
	}

	public virtual void FIMDICFNOFB(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 1;
		BDOEBNAOJFE = TimeManager.realTimeWithoutPauses + 858f;
	}

	public virtual void MJDIIBBFMOF(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("COPYCAT");
		}
	}

	private void EBGCPOHMGBC()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(5);
		Collider[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1881f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 1443f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 278f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1274f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: false, out var _);
		}
	}

	protected void DEBGBGGOCEN()
	{
		if (MGCOAMOLGBF && TimeManager.CEAFAMFNGCC() > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 398f;
			BAFFHDIFOPJ();
			FMAKHIJBFJM++;
			if (FMAKHIJBFJM >= 7)
			{
				MGCOAMOLGBF = true;
				NFJEOLKAONC(1198f, ENGGOAPADCP: true);
			}
		}
	}

	public virtual void HKNOBMACJDP(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("ID_RECEIVED");
		}
	}

	public virtual void AAFEFLNFGOM(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("Card_3_Played");
		}
	}

	public override void LoadAmmoSetup(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("You probably assigned bad type of AmmoSetup to gun");
		}
	}

	public virtual void KGPPGHKFNEC(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("Days_Since_Install");
		}
	}

	private void OKCBFBJAOPL()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(7);
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1213f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 532f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 1547f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1271f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	protected void KKMHFNONAJL()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1136f;
			HLLPJJPHDMC();
			FMAKHIJBFJM += 0;
			if (FMAKHIJBFJM >= 3)
			{
				MGCOAMOLGBF = true;
				AEHFNIMENDJ(9f);
			}
		}
	}

	public virtual void NKNNIGDDODL(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("InAppHandlerIos: On restore finished");
		}
	}

	public virtual void NMHOEAHIGGM(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.CEAFAMFNGCC() + 432f;
	}

	protected void MJBACOLLOHD()
	{
		if (MGCOAMOLGBF && TimeManager.CEAFAMFNGCC() > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1169f;
			KILFPFKALCH();
			FMAKHIJBFJM++;
			if (FMAKHIJBFJM >= 2)
			{
				MGCOAMOLGBF = false;
				MIDOLDHLMAF(440f, ENGGOAPADCP: true);
			}
		}
	}

	public virtual void LFHCNKADAOE(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = false;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.CEAFAMFNGCC() + 1882f;
	}

	public virtual void NDHCLKGHOMA(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = false;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.CEAFAMFNGCC() + 640f;
	}

	public virtual void DEBCAELHHCJ(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("unit");
		}
	}

	public virtual void OMHNEEBJMII(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = false;
		FMAKHIJBFJM = 1;
		BDOEBNAOJFE = TimeManager.CEAFAMFNGCC() + 1130f;
	}

	private void KEOKEANEMJP()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(7);
		Collider[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1729f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 186f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 1221f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1612f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	public virtual void OEGKIBNPCIL(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = false;
		FMAKHIJBFJM = 1;
		BDOEBNAOJFE = TimeManager.realTimeWithoutPauses + 1089f;
	}

	public virtual void AKMBBJILJMF(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("AssignmentsIds");
		}
	}

	public virtual void LNEAACIAOBN(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("Upgrades");
		}
	}

	private void BAFFHDIFOPJ()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(7);
		Collider[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 736f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 783f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 843f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1066f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	public virtual void PAKPFIFJCOD(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("ID_YES");
		}
	}

	private void KEPPFIGPMHO()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(4);
		Collider[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 643f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 1141f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 715f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1929f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	protected void CMNIHLONIJB()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 127f;
			EBGCPOHMGBC();
			FMAKHIJBFJM++;
			if (FMAKHIJBFJM >= 5)
			{
				MGCOAMOLGBF = true;
				MIDOLDHLMAF(662f);
			}
		}
	}

	public virtual void FJKIMNBDKNC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 1;
		BDOEBNAOJFE = TimeManager.realTimeWithoutPauses + 1097f;
	}

	protected void LHJAGNOOBAF()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1895f;
			NKFOALAIOBA();
			FMAKHIJBFJM += 0;
			if (FMAKHIJBFJM >= 7)
			{
				MGCOAMOLGBF = false;
				DCFHLIDIDMN(927f, ENGGOAPADCP: true);
			}
		}
	}

	public virtual void EOBGAPOJNOO(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("InAppHandlerIos: product list fail, message = ");
		}
	}

	protected void EMFLLHFPOOB()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1014f;
			EBGCPOHMGBC();
			FMAKHIJBFJM++;
			if (FMAKHIJBFJM >= 6)
			{
				MGCOAMOLGBF = false;
				AEHFNIMENDJ(804f, ENGGOAPADCP: true);
			}
		}
	}

	public virtual void KODNJMPNEKO(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("ID_YOUNEEDMONEYTOUPGRADE");
		}
	}

	private void KILFPFKALCH()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(7);
		Collider[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 352f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 1296f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 810f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 359f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	private void CBHANIDAJKH()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(6);
		Collider[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1541f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 909f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 565f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1717f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	private void ONLKABNELNM()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(0);
		Collider[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 491f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 639f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 1471f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 740f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: false, out var _);
		}
	}

	protected void LPFGBKIINMP()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1817f;
			DBLDDOMLEJE();
			FMAKHIJBFJM += 0;
			if (FMAKHIJBFJM >= 1)
			{
				MGCOAMOLGBF = true;
				DestroyPooled(778f);
			}
		}
	}

	private void HHMAHKKHLHL()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(7);
		Collider[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1987f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 157f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 1746f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1399f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: false, out var _);
		}
	}

	public virtual void KAGPOAJNAKP(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("-{0}");
		}
	}

	protected void BPNLIABHCPN()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 173f;
			KEOKEANEMJP();
			FMAKHIJBFJM += 0;
			if (FMAKHIJBFJM >= 1)
			{
				MGCOAMOLGBF = true;
				DestroyPooled(1760f);
			}
		}
	}

	public virtual void OCEBHNAAAEI(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = true;
		FMAKHIJBFJM = 0;
		BDOEBNAOJFE = TimeManager.CEAFAMFNGCC() + 1448f;
	}

	private void PFHPBCBKAOD()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(4);
		Collider[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1334f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 1963f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 1711f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 38f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	private void NKFOALAIOBA()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(5);
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 0.3f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 0f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 0.25f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	public virtual void PMBGEMJABBF(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError(" , ");
		}
	}

	private void IFIAFNJHGBA()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(2);
		Collider[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1963f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 1757f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 1292f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1839f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	protected void CHHKMBGOMJJ()
	{
		if (MGCOAMOLGBF && TimeManager.CEAFAMFNGCC() > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1849f;
			KEOKEANEMJP();
			FMAKHIJBFJM += 0;
			if (FMAKHIJBFJM >= 1)
			{
				MGCOAMOLGBF = true;
				DCFHLIDIDMN(824f, ENGGOAPADCP: true);
			}
		}
	}

	public virtual void PDHGFNFOEKK(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("ID_FEATURE_RELOAD-DESCRIPTION");
		}
	}

	private void GGGMPCKMKAC()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(3);
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 720f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 382f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 174f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 285f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	public virtual void GECDCIHNNDB(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("ID_SILVERPACK");
		}
	}

	protected void EKPBOMOMMFB()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1647f;
			GGGMPCKMKAC();
			FMAKHIJBFJM += 0;
			if (FMAKHIJBFJM >= 6)
			{
				MGCOAMOLGBF = false;
				DCFHLIDIDMN(1707f, ENGGOAPADCP: true);
			}
		}
	}

	public virtual void BIBEAEMECIF(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("\"");
		}
	}

	protected void AAABJNBFLEG()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1438f;
			IFIAFNJHGBA();
			FMAKHIJBFJM++;
			if (FMAKHIJBFJM >= 6)
			{
				MGCOAMOLGBF = true;
				DCFHLIDIDMN(1272f, ENGGOAPADCP: true);
			}
		}
	}

	public virtual void FBNJLDNAOIO(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("damage");
		}
	}

	private void MGDJIFDHBGL()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(1);
		Collider[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 982f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 1042f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 184f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1927f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	protected void JOCHCGHAIGH()
	{
		if (MGCOAMOLGBF && TimeManager.realTimeWithoutPauses > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1802f;
			GGGMPCKMKAC();
			FMAKHIJBFJM += 0;
			if (FMAKHIJBFJM >= 5)
			{
				MGCOAMOLGBF = true;
				NFJEOLKAONC(1539f);
			}
		}
	}

	public virtual void GEODIBLMENL(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("ID_");
		}
	}

	private void OJLIAONFADK()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(4);
		Collider[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			Collider collider = array2[i];
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 541f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 884f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 991f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 426f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: false, out var _);
		}
	}

	public virtual void NCPMKDGNGMD(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("_shotgun");
		}
	}

	protected void EHLEBOMGCJN()
	{
		if (MGCOAMOLGBF && TimeManager.CEAFAMFNGCC() > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1744f;
			EDHDFLOBDGG();
			FMAKHIJBFJM += 0;
			if (FMAKHIJBFJM >= 3)
			{
				MGCOAMOLGBF = false;
				DestroyPooled(1423f);
			}
		}
	}

	public virtual void EMGHMOOIMNP(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		MGCOAMOLGBF = false;
		FMAKHIJBFJM = 1;
		BDOEBNAOJFE = TimeManager.realTimeWithoutPauses + 1266f;
	}

	private void GAGDNBPBPMG()
	{
		Vector3 position = JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		Collider[] array = Physics.OverlapSphere(position, EIIMIEGIOPN.PPNDNOHMBKH);
		List<DestroyableObject> list = new List<DestroyableObject>(7);
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			KMHCMCBGFFC kMHCMCBGFFC = component.owner;
			if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit mGECAKNCNBD = default(RaycastHit);
			if (num < 1140f)
			{
				continue;
			}
			Vector3 forward = (JMMJHCOKCGG.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (EIIMIEGIOPN.PDECAPKPLCC)
			{
				forward.y = 1189f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 113f);
			float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1916f - num / EIIMIEGIOPN.PPNDNOHMBKH;
			EIIMIEGIOPN.JGGGDHJEIKB = num3 * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Lerp(EIIMIEGIOPN.NNNCAFEGNNC, EIIMIEGIOPN.GJFCKILFOAE, num3);
			LoadAmmoSetup(EIIMIEGIOPN);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.JPPDEOKJBLO != null)
			{
				if (list.Contains(component2.JPPDEOKJBLO))
				{
					continue;
				}
				list.Add(component2.JPPDEOKJBLO);
			}
			DoDamage(collider.gameObject, mGECAKNCNBD, num3 * EIIMIEGIOPN.IHBGFNNAGPG * vector2 / num, DLKHGAHBIMB: true, out var _);
		}
	}

	public virtual void FJJDCDCJAHA(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}");
		}
	}

	protected void OOCJOBIIKAH()
	{
		if (MGCOAMOLGBF && TimeManager.CEAFAMFNGCC() > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 1337f;
			NHACNNBGCEP();
			FMAKHIJBFJM++;
			if (FMAKHIJBFJM >= 5)
			{
				MGCOAMOLGBF = true;
				NFJEOLKAONC(809f, ENGGOAPADCP: true);
			}
		}
	}

	public virtual void MMMKLBIBFAO(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		FlameAmmoSetup flameAmmoSetup = MBNLFKHLDBH as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			EIIMIEGIOPN = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("Still waiting for server\nBe patient :-)");
		}
	}

	protected void NBFMDCFFBIJ()
	{
		if (MGCOAMOLGBF && TimeManager.CEAFAMFNGCC() > BDOEBNAOJFE)
		{
			BDOEBNAOJFE += 581f;
			NHACNNBGCEP();
			FMAKHIJBFJM += 0;
			if (FMAKHIJBFJM >= 2)
			{
				MGCOAMOLGBF = false;
				DCFHLIDIDMN(1247f, ENGGOAPADCP: true);
			}
		}
	}
}
