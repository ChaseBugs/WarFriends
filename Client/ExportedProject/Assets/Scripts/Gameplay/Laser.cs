using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Laser : Ammo
{
	private WSP_LaserBeamWS JJPJDEOIJDG;

	private Vector3 AKPHKLGJBBB;

	[CompilerGenerated]
	private static Comparison<RaycastHit> LGJCBPOPCPA;

	private static int EODOLFALLMG(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	protected virtual void HMBBGNKFNCK()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	private void GIMOMGKLJEE(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, bool KKKEAMCNDHH)
	{
		JJPJDEOIJDG.LaserFireEmitPointTrans.position = OEIICEJPGKI;
		JJPJDEOIJDG.TargetHitTransform.position = IIMDKHJAJGO;
		JJPJDEOIJDG.CurrentTarget.position = IIMDKHJAJGO;
		JJPJDEOIJDG.FireLaser();
		AEHFNIMENDJ(1601f, ENGGOAPADCP: true);
	}

	protected virtual void MEBEHLLPMPK()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	private static int KPMLLDECEDI(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	private static int MBGKKJCPJFD(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	protected virtual void FGOGGLDAKHL()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	public virtual void JODNLNFFAEK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 81f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 1628f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		Ray ray = new Ray(OEIICEJPGKI + normalized * 1216f, normalized);
		int layerMask = Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		RaycastHit[] array = Physics.RaycastAll(ray, 1821f, layerMask);
		Array.Sort(array, KPMLLDECEDI);
		bool flag = false;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit raycastHit = array2[i];
			if (TagsAndLayers.KHKNLLDEBMA(raycastHit.transform.gameObject))
			{
				GIMOMGKLJEE(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: false);
				flag = false;
				break;
			}
			DestroyableObject component = raycastHit.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.JPBFBBMCFPI(PMCGFJLLCHJ, raycastHit.point, Vector3.zero, JMMJHCOKCGG, base.owner, CAKABHIPCDF, NLJFIIEGHCK: true);
				if (component.AEJBIHBEOCP)
				{
					AHMOBKLCAHL(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: false);
					flag = false;
					break;
				}
			}
		}
		if (!flag)
		{
			NIAGPEADKIN(OEIICEJPGKI, IIMDKHJAJGO, KKKEAMCNDHH: true);
		}
	}

	public virtual void FFDPHJCJFFI(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 114f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 1733f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		Ray ray = new Ray(OEIICEJPGKI + normalized * 563f, normalized);
		int layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		RaycastHit[] array = Physics.RaycastAll(ray, 1311f, layerMask);
		Array.Sort(array, EMFKJOBPLEN);
		bool flag = false;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			RaycastHit raycastHit = array2[i];
			if (TagsAndLayers.LKIJKDCGCMI(raycastHit.transform.gameObject))
			{
				GIMOMGKLJEE(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: false);
				flag = false;
				break;
			}
			DestroyableObject component = raycastHit.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.Shoot(PMCGFJLLCHJ, raycastHit.point, Vector3.zero, JMMJHCOKCGG, base.owner, CAKABHIPCDF, NLJFIIEGHCK: false);
				if (component.AEJBIHBEOCP)
				{
					ABIEEPEGOGO(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: true);
					flag = false;
					break;
				}
			}
		}
		if (!flag)
		{
			HIGDEKMELIM(OEIICEJPGKI, IIMDKHJAJGO, KKKEAMCNDHH: true);
		}
	}

	[CompilerGenerated]
	private static int IJEKEKIMPPM(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	private static int GGPPDOKIFEE(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	private void ABIEEPEGOGO(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, bool KKKEAMCNDHH)
	{
		JJPJDEOIJDG.LaserFireEmitPointTrans.position = OEIICEJPGKI;
		JJPJDEOIJDG.TargetHitTransform.position = IIMDKHJAJGO;
		JJPJDEOIJDG.CurrentTarget.position = IIMDKHJAJGO;
		JJPJDEOIJDG.FireLaser();
		NFJEOLKAONC(1619f);
	}

	protected virtual void MLBAFICPECE()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	protected virtual void BKNKFFEHJOA()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	protected virtual void OLBEOPKDEBJ()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	private static int MLBCFBOCMHE(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	protected virtual void EJNJCILPBEC()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	protected override void Awake()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	public virtual void CJCOJIFHHMN(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 165f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 438f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		Ray ray = new Ray(OEIICEJPGKI + normalized * 514f, normalized);
		int layerMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		RaycastHit[] array = Physics.RaycastAll(ray, 217f, layerMask);
		Array.Sort(array, MLBCFBOCMHE);
		bool flag = false;
		RaycastHit[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			RaycastHit raycastHit = array2[i];
			if (TagsAndLayers.LKIJKDCGCMI(raycastHit.transform.gameObject))
			{
				HILMBFDOJCK(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: false);
				flag = true;
				break;
			}
			DestroyableObject component = raycastHit.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.JPBFBBMCFPI(PMCGFJLLCHJ, raycastHit.point, Vector3.zero, JMMJHCOKCGG, base.owner, CAKABHIPCDF, NLJFIIEGHCK: false);
				if (component.AEJBIHBEOCP)
				{
					AHMOBKLCAHL(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: true);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			AHMOBKLCAHL(OEIICEJPGKI, IIMDKHJAJGO, KKKEAMCNDHH: true);
		}
	}

	private static int PCPBINKMGII(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	protected virtual void BACJPKBJNIB()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	public virtual void ABHDBNJGONF(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 1967f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 140f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		Ray ray = new Ray(OEIICEJPGKI + normalized * 1663f, normalized);
		int layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		RaycastHit[] array = Physics.RaycastAll(ray, 1932f, layerMask);
		Array.Sort(array, EODOLFALLMG);
		bool flag = false;
		RaycastHit[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			RaycastHit raycastHit = array2[i];
			if (TagsAndLayers.KHKNLLDEBMA(raycastHit.transform.gameObject))
			{
				NIAGPEADKIN(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: false);
				flag = false;
				break;
			}
			DestroyableObject component = raycastHit.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.Shoot(PMCGFJLLCHJ, raycastHit.point, Vector3.zero, JMMJHCOKCGG, base.owner, CAKABHIPCDF, NLJFIIEGHCK: false);
				if (component.AEJBIHBEOCP)
				{
					HILMBFDOJCK(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: true);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			HIGDEKMELIM(OEIICEJPGKI, IIMDKHJAJGO, KKKEAMCNDHH: true);
		}
	}

	private static int IBGDBNLDFGM(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	public virtual void HFONHKMACOG(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 37f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 1554f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		Ray ray = new Ray(OEIICEJPGKI + normalized * 1324f, normalized);
		int layerMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		RaycastHit[] array = Physics.RaycastAll(ray, 1487f, layerMask);
		Array.Sort(array, PCJMPOJBECD);
		bool flag = false;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit raycastHit = array2[i];
			if (TagsAndLayers.IsStatic(raycastHit.transform.gameObject))
			{
				HIGDEKMELIM(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: false);
				flag = true;
				break;
			}
			DestroyableObject component = raycastHit.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.JPBFBBMCFPI(PMCGFJLLCHJ, raycastHit.point, Vector3.zero, JMMJHCOKCGG, base.owner, CAKABHIPCDF, NLJFIIEGHCK: false);
				if (component.AEJBIHBEOCP)
				{
					NIAGPEADKIN(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: true);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			GIMOMGKLJEE(OEIICEJPGKI, IIMDKHJAJGO, KKKEAMCNDHH: false);
		}
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	private void HILMBFDOJCK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, bool KKKEAMCNDHH)
	{
		JJPJDEOIJDG.LaserFireEmitPointTrans.position = OEIICEJPGKI;
		JJPJDEOIJDG.TargetHitTransform.position = IIMDKHJAJGO;
		JJPJDEOIJDG.CurrentTarget.position = IIMDKHJAJGO;
		JJPJDEOIJDG.FireLaser();
		DestroyPooled(1176f);
	}

	public virtual void LPLLKPCGHJH(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 1619f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 1557f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		Ray ray = new Ray(OEIICEJPGKI + normalized * 1201f, normalized);
		int layerMask = Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		RaycastHit[] array = Physics.RaycastAll(ray, 416f, layerMask);
		Array.Sort(array, IDGCLGDALIP);
		bool flag = false;
		RaycastHit[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			RaycastHit raycastHit = array2[i];
			if (TagsAndLayers.KHKNLLDEBMA(raycastHit.transform.gameObject))
			{
				ABIEEPEGOGO(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: false);
				flag = true;
				break;
			}
			DestroyableObject component = raycastHit.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.JPBFBBMCFPI(PMCGFJLLCHJ, raycastHit.point, Vector3.zero, JMMJHCOKCGG, base.owner, CAKABHIPCDF, NLJFIIEGHCK: false);
				if (component.AEJBIHBEOCP)
				{
					ABIEEPEGOGO(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: true);
					flag = false;
					break;
				}
			}
		}
		if (!flag)
		{
			HILMBFDOJCK(OEIICEJPGKI, IIMDKHJAJGO, KKKEAMCNDHH: false);
		}
	}

	private static int IDGCLGDALIP(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	public virtual void DPMDEEGOOHI(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 657f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 1618f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		Ray ray = new Ray(OEIICEJPGKI + normalized * 1013f, normalized);
		int layerMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		RaycastHit[] array = Physics.RaycastAll(ray, 1423f, layerMask);
		Array.Sort(array, PCPBINKMGII);
		bool flag = true;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			RaycastHit raycastHit = array2[i];
			if (TagsAndLayers.KHKNLLDEBMA(raycastHit.transform.gameObject))
			{
				ABIEEPEGOGO(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: false);
				flag = true;
				break;
			}
			DestroyableObject component = raycastHit.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.Shoot(PMCGFJLLCHJ, raycastHit.point, Vector3.zero, JMMJHCOKCGG, base.owner, CAKABHIPCDF, NLJFIIEGHCK: true);
				if (component.AEJBIHBEOCP)
				{
					AHMOBKLCAHL(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: false);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			NIAGPEADKIN(OEIICEJPGKI, IIMDKHJAJGO, KKKEAMCNDHH: false);
		}
	}

	protected virtual void HEJKGFPPIDC()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	protected virtual void HCNOHLLOGBO()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	private void HIGDEKMELIM(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, bool KKKEAMCNDHH)
	{
		JJPJDEOIJDG.LaserFireEmitPointTrans.position = OEIICEJPGKI;
		JJPJDEOIJDG.TargetHitTransform.position = IIMDKHJAJGO;
		JJPJDEOIJDG.CurrentTarget.position = IIMDKHJAJGO;
		JJPJDEOIJDG.FireLaser();
		DCFHLIDIDMN(1913f, ENGGOAPADCP: true);
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	public override void Fire(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 50f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 50f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		Ray ray = new Ray(OEIICEJPGKI + normalized * 0.1f, normalized);
		int layerMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity, layerMask);
		Array.Sort(array, (RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM) => HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance));
		bool flag = false;
		RaycastHit[] array2 = array;
		for (int num = 0; num < array2.Length; num++)
		{
			RaycastHit raycastHit = array2[num];
			if (TagsAndLayers.IsStatic(raycastHit.transform.gameObject))
			{
				AHMOBKLCAHL(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: false);
				flag = true;
				break;
			}
			DestroyableObject component = raycastHit.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.Shoot(PMCGFJLLCHJ, raycastHit.point, Vector3.zero, JMMJHCOKCGG, base.owner, CAKABHIPCDF, NLJFIIEGHCK: false);
				if (component.AEJBIHBEOCP)
				{
					AHMOBKLCAHL(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: false);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			AHMOBKLCAHL(OEIICEJPGKI, IIMDKHJAJGO, KKKEAMCNDHH: false);
		}
	}

	protected virtual void FFBBKELEEIF()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	private static int EMFKJOBPLEN(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	private void NIAGPEADKIN(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, bool KKKEAMCNDHH)
	{
		JJPJDEOIJDG.LaserFireEmitPointTrans.position = OEIICEJPGKI;
		JJPJDEOIJDG.TargetHitTransform.position = IIMDKHJAJGO;
		JJPJDEOIJDG.CurrentTarget.position = IIMDKHJAJGO;
		JJPJDEOIJDG.FireLaser();
		AEHFNIMENDJ(1870f);
	}

	public virtual void IIONGNALLPB(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 428f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 1336f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		Ray ray = new Ray(OEIICEJPGKI + normalized * 1080f, normalized);
		int layerMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		RaycastHit[] array = Physics.RaycastAll(ray, 1261f, layerMask);
		Array.Sort(array, (RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM) => HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance));
		bool flag = false;
		RaycastHit[] array2 = array;
		for (int num = 1; num < array2.Length; num++)
		{
			RaycastHit raycastHit = array2[num];
			if (TagsAndLayers.IsStatic(raycastHit.transform.gameObject))
			{
				AHMOBKLCAHL(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: true);
				flag = false;
				break;
			}
			DestroyableObject component = raycastHit.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.JPBFBBMCFPI(PMCGFJLLCHJ, raycastHit.point, Vector3.zero, JMMJHCOKCGG, base.owner, CAKABHIPCDF, NLJFIIEGHCK: false);
				if (component.AEJBIHBEOCP)
				{
					AHMOBKLCAHL(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: true);
					flag = false;
					break;
				}
			}
		}
		if (!flag)
		{
			NIAGPEADKIN(OEIICEJPGKI, IIMDKHJAJGO, KKKEAMCNDHH: false);
		}
	}

	private void AHMOBKLCAHL(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, bool KKKEAMCNDHH)
	{
		JJPJDEOIJDG.LaserFireEmitPointTrans.position = OEIICEJPGKI;
		JJPJDEOIJDG.TargetHitTransform.position = IIMDKHJAJGO;
		JJPJDEOIJDG.CurrentTarget.position = IIMDKHJAJGO;
		JJPJDEOIJDG.FireLaser();
		DestroyPooled(3f);
	}

	private static int JGOCHADPJEH(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	private static int PCJMPOJBECD(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	private static int JKFFCAMPIJE(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	protected virtual void AKKKDIBLICM()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}

	public virtual void PHIOGPAMKJK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 95f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 1862f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		Ray ray = new Ray(OEIICEJPGKI + normalized * 38f, normalized);
		int layerMask = Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		RaycastHit[] array = Physics.RaycastAll(ray, 217f, layerMask);
		Array.Sort(array, EODOLFALLMG);
		bool flag = true;
		RaycastHit[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			RaycastHit raycastHit = array2[i];
			if (TagsAndLayers.KHKNLLDEBMA(raycastHit.transform.gameObject))
			{
				HIGDEKMELIM(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: false);
				flag = true;
				break;
			}
			DestroyableObject component = raycastHit.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.Shoot(PMCGFJLLCHJ, raycastHit.point, Vector3.zero, JMMJHCOKCGG, base.owner, CAKABHIPCDF, NLJFIIEGHCK: false);
				if (component.AEJBIHBEOCP)
				{
					NIAGPEADKIN(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: false);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			GIMOMGKLJEE(OEIICEJPGKI, IIMDKHJAJGO, KKKEAMCNDHH: false);
		}
	}

	private static int EMOIMPBBGIN(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	private static int KPMBIKJADIF(RaycastHit HPJFBKEKJHB, RaycastHit NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.distance.CompareTo(NCMHGPNPEJM.distance);
	}

	public virtual void AKBHIINCJFM(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 1139f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 981f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		Ray ray = new Ray(OEIICEJPGKI + normalized * 302f, normalized);
		int layerMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		RaycastHit[] array = Physics.RaycastAll(ray, 1825f, layerMask);
		Array.Sort(array, PCPBINKMGII);
		bool flag = true;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i += 0)
		{
			RaycastHit raycastHit = array2[i];
			if (TagsAndLayers.JEIDEFIFCLE(raycastHit.transform.gameObject))
			{
				AHMOBKLCAHL(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: true);
				flag = false;
				break;
			}
			DestroyableObject component = raycastHit.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.Shoot(PMCGFJLLCHJ, raycastHit.point, Vector3.zero, JMMJHCOKCGG, base.owner, CAKABHIPCDF, NLJFIIEGHCK: false);
				if (component.AEJBIHBEOCP)
				{
					HILMBFDOJCK(OEIICEJPGKI, raycastHit.point, KKKEAMCNDHH: true);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			AHMOBKLCAHL(OEIICEJPGKI, IIMDKHJAJGO, KKKEAMCNDHH: false);
		}
	}

	protected virtual void PBIJLBHDFOK()
	{
		base.Awake();
		JJPJDEOIJDG = GetComponent<WSP_LaserBeamWS>();
	}
}
