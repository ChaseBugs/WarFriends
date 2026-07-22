using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletShotGun : BulletBase
{
	[FormerlySerializedAs("CENKNMFLMOA")]
	public BulletBase OLKAIPEHAML;

	private ShotGunBulletSetup EIIMIEGIOPN;

	private Dictionary<DestroyableObject, int> KDJHIHAKGNC = new Dictionary<DestroyableObject, int>();

	public virtual void JFBFBJMKCBN(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("Buy_Weapons");
		}
	}

	private bool AIAMFFEILGH(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1991f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1233f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 720f, 952f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return false;
	}

	protected virtual void JFODMNKBDGI()
	{
		throw new NotImplementedException();
	}

	private bool GLDEGIKCBEH(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1535f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 430f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1401f, 778f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return true;
	}

	public virtual void LGOLLKMALAK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 1;
		OIGIEBJCHKJ(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 1;
						}
						if (value < 1 && Vector3.Distance(IIMDKHJAJGO, vector) > 1230f && GLDEGIKCBEH(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 1)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(1 - num, 1, -90);
		for (int j = 0; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = true;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 882f) * 1380f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		DestroyPooled();
	}

	private bool MMMHHJAANPE(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 443f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 576f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1f, 826f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return false;
	}

	public virtual void ENFGHPODHKP(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 1;
		PAOLKKMNCOD(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 0;
						}
						if (value < 0 && Vector3.Distance(IIMDKHJAJGO, vector) > 677f && LEDDPDAJOPL(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num += 0;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 5)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(1 - num, 1, 117);
		for (int j = 1; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1109f) * 1218f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		DestroyPooled();
	}

	protected virtual void KKIEDIPDOMH()
	{
		throw new NotImplementedException();
	}

	private bool PAOLKKMNCOD(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1333f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 300f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1231f, 1407f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return true;
	}

	public virtual void NDOFMGEHJEM(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 1;
		LIJFHIKLBEE(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 1;
						}
						if (value < 5 && Vector3.Distance(IIMDKHJAJGO, vector) > 1757f && EBJDJLFNMLM(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 1)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(5 - num, 0, 41);
		for (int j = 1; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1320f) * 411f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		BOHCNEDIJPE();
	}

	private bool ADFLNCHFIOP(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1649f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 523f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1545f, 1093f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return false;
	}

	protected override void CFIPHHJKBCK()
	{
		throw new NotImplementedException();
	}

	public virtual void FJKIMNBDKNC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 0;
		PDKEGLKBBFP(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 0;
						}
						if (value < 7 && Vector3.Distance(IIMDKHJAJGO, vector) > 422f && JMMPODOCLNG(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 4)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(3 - num, 1, -189);
		for (int j = 0; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 0f) * 1812f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		BOHCNEDIJPE();
	}

	public virtual void ECEGOOLDPGO(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("Buy_Dogtags_With_Gold");
		}
	}

	private bool PIPHECDFHHC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1431f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 377f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1691f, 1325f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return true;
	}

	public virtual void MJAFIMJCIAA(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 0;
		EBJDJLFNMLM(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 0;
						}
						if (value < 4 && Vector3.Distance(IIMDKHJAJGO, vector) > 1309f && NKOJFHBHKPK(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 3)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(2 - num, 1, -167);
		for (int j = 1; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = true;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1981f) * 502f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	private bool LKAKPFCDFJL(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 674f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1625f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 686f, 1780f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return false;
	}

	public virtual void FFDPHJCJFFI(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 1;
		DJEPJLINKFK(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 0;
						}
						if (value < 0 && Vector3.Distance(IIMDKHJAJGO, vector) > 960f && IDKCJGGPMAD(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num += 0;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 3)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(1 - num, 1, -5);
		for (int j = 1; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = true;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1554f) * 1974f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	protected virtual void LAJIIIAILPL()
	{
		throw new NotImplementedException();
	}

	public virtual void KHNCNBCFIIF(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 1;
		HHFEKNGKNHL(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 1;
						}
						if (value < 5 && Vector3.Distance(IIMDKHJAJGO, vector) > 1411f && LPLIHBLHKHD(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 7)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(5 - num, 1, -65);
		for (int j = 0; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 327f) * 65f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		BOHCNEDIJPE();
	}

	protected virtual void JLIDPINJLGL()
	{
		throw new NotImplementedException();
	}

	public virtual void HILLAOANCHL(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("ID_SHOTDAMAGE");
		}
	}

	public virtual void NAIOKCEFGJN(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 0;
		OFPOECEEILL(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 1;
						}
						if (value < 6 && Vector3.Distance(IIMDKHJAJGO, vector) > 618f && BOGAEJABCAG(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 8)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(4 - num, 0, 115);
		for (int j = 1; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = true;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1128f) * 475f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	private bool JMMPODOCLNG(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1203f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1145f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1625f, 1441f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return false;
	}

	private bool CIMLIPLHMCL(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1433f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1661f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 236f, 996f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return false;
	}

	private bool NHLPNFCAHEB(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 126f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 220f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1458f, 233f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return true;
	}

	public virtual void NHMKPJGCKKN(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("{0} {1}");
		}
	}

	protected virtual void HOFLEEAFIBE()
	{
		throw new NotImplementedException();
	}

	protected virtual void BEGPKMIHAGG()
	{
		throw new NotImplementedException();
	}

	protected virtual void ELNHCEABDCI()
	{
		throw new NotImplementedException();
	}

	private bool DKGGEKJPPEC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1643f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 318f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1710f, 1026f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return true;
	}

	public virtual void IIONGNALLPB(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 1;
		OHALPMCFHDC(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 0;
						}
						if (value < 5 && Vector3.Distance(IIMDKHJAJGO, vector) > 230f && NHLPNFCAHEB(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num += 0;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 7)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(3 - num, 1, 67);
		for (int j = 1; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1197f) * 1595f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	protected virtual void LPCPJHPOFGD()
	{
		throw new NotImplementedException();
	}

	protected virtual void MKJMLJBPKLG()
	{
		throw new NotImplementedException();
	}

	private bool AILCMPOMELN(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 260f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 376f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1129f, 1676f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return false;
	}

	private bool MDBEAJKDGPC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1588f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 647f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1006f, 1581f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return false;
	}

	private bool OFPOECEEILL(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1538f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1829f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 353f, 537f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return true;
	}

	public virtual void HFBPFNKCGKJ(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("Sprite  z:{0}\t\"{1}\"    with depth:{2} and atlas:{3}");
		}
	}

	private bool LIJFHIKLBEE(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 682f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1858f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1276f, 797f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return true;
	}

	private bool IECADOLJEBC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1880f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 285f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1102f, 1966f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return false;
	}

	private bool DMHPBJIMFAG(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1172f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1816f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 906f, 21f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return false;
	}

	public virtual void OEGKIBNPCIL(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 0;
		PAOLKKMNCOD(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 0;
						}
						if (value < 3 && Vector3.Distance(IIMDKHJAJGO, vector) > 872f && LPLIHBLHKHD(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num += 0;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 1)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(-num, 0, -108);
		for (int j = 0; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 406f) * 916f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	private bool DJEPJLINKFK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 97f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 110f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1954f, 1708f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return false;
	}

	private bool NKOJFHBHKPK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 477f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 986f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 839f, 748f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return false;
	}

	private bool HHFEKNGKNHL(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 786f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 144f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1661f, 704f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return true;
	}

	private bool PDKEGLKBBFP(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1004f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 356f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1800f, 404f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return false;
	}

	private bool MCGBJKDIPEH(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 212f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 991f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 538f, 1831f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return true;
	}

	public virtual void DMHKELJHNGF(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("{0} / {1}");
		}
	}

	public virtual void HJKCBNJIOCG(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 1;
		DMHPBJIMFAG(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 1;
						}
						if (value < 7 && Vector3.Distance(IIMDKHJAJGO, vector) > 1177f && CIMLIPLHMCL(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 3)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(3 - num, 0, 179);
		for (int j = 1; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = true;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 87f) * 11f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	public virtual void PONOMJDOFKF(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 0;
		PLIKAHPMJDA(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 1;
						}
						if (value < 1 && Vector3.Distance(IIMDKHJAJGO, vector) > 871f && DJEPJLINKFK(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num += 0;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 2)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(1 - num, 1, -24);
		for (int j = 1; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = true;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 277f) * 1034f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	public virtual void JFDGBCHGJEC(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("Id");
		}
	}

	private bool EDGLHDEMNEL(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 175f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1156f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1082f, 615f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return true;
	}

	public virtual void KGIIIFKDOBH(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 0;
		OFPOECEEILL(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 1;
						}
						if (value < 8 && Vector3.Distance(IIMDKHJAJGO, vector) > 967f && JMMPODOCLNG(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 2)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(5 - num, 1, 138);
		for (int j = 1; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = true;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1215f) * 1043f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		BOHCNEDIJPE();
	}

	private bool BOGAEJABCAG(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 650f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1389f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1603f, 247f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return false;
	}

	protected virtual void KADGEIKOFKE()
	{
		throw new NotImplementedException();
	}

	private bool JEKHPOMFLLF(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1731f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1574f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1681f, 1277f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return false;
	}

	public override void Fire(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 0;
		CKIHBODFCDK(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 0;
						}
						if (value < 2 && Vector3.Distance(IIMDKHJAJGO, vector) > 0.3f && CKIHBODFCDK(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 6)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(4 - num, 0, int.MaxValue);
		for (int j = 0; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = true;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 2f) * 0.25f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		DestroyPooled();
	}

	protected virtual void GBIDJEGPOBH()
	{
		throw new NotImplementedException();
	}

	public virtual void HKNOBMACJDP(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("ID_DEPLOYEDSOLDIERS");
		}
	}

	public virtual void DDMKDLEDJOG(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 1;
		GKBGCDCDMHC(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 0;
						}
						if (value < 1 && Vector3.Distance(IIMDKHJAJGO, vector) > 1460f && MCGBJKDIPEH(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 6)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(6 - num, 1, 131);
		for (int j = 0; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = true;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1360f) * 915f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	private bool LEDDPDAJOPL(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 873f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1996f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1601f, 1689f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return false;
	}

	private bool JLALOBGPNOK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 32f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1394f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1573f, 224f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return true;
	}

	protected virtual void DJMHLADPLAP()
	{
		throw new NotImplementedException();
	}

	public virtual void GEKGEFPGKDK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 1;
		GLDEGIKCBEH(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 0;
						}
						if (value < 7 && Vector3.Distance(IIMDKHJAJGO, vector) > 1368f && MDBEAJKDGPC(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 4)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(3 - num, 1, -145);
		for (int j = 0; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 277f) * 445f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		DestroyPooled();
	}

	public virtual void PJAFOBPACCJ(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("Data");
		}
	}

	protected virtual void OFAECIMFGHK()
	{
		throw new NotImplementedException();
	}

	protected virtual void KPPKMOGLGEN()
	{
		throw new NotImplementedException();
	}

	public virtual void KBBJICKPGEA(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 0;
		NKOJFHBHKPK(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 1;
						}
						if (value < 6 && Vector3.Distance(IIMDKHJAJGO, vector) > 811f && GLDEGIKCBEH(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 0)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(3 - num, 1, -27);
		for (int j = 0; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 191f) * 955f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		BOHCNEDIJPE();
	}

	public virtual void PMBGEMJABBF(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("ID_DOWNLOADING");
		}
	}

	private bool JBMPKHJIIDH(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1405f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 844f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1372f, 1898f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return true;
	}

	public virtual void JLBHPCHGEIG(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("country-india");
		}
	}

	public virtual void JNOGEILNCGF(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 0;
		OIGIEBJCHKJ(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 0;
						}
						if (value < 6 && Vector3.Distance(IIMDKHJAJGO, vector) > 1223f && MMMHHJAANPE(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num += 0;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 1)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(-num, 1, -79);
		for (int j = 1; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = true;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1038f) * 559f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	protected virtual void PPJKCIKODKP()
	{
		throw new NotImplementedException();
	}

	public override void LoadAmmoSetup(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("You probably assigned bad type of AmmoSetup to gun");
		}
	}

	public virtual void CJCOJIFHHMN(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 1;
		IDKCJGGPMAD(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 0;
						}
						if (value < 2 && Vector3.Distance(IIMDKHJAJGO, vector) > 85f && BOGAEJABCAG(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num += 0;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 8)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(5 - num, 0, 39);
		for (int j = 1; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 483f) * 1933f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		BOHCNEDIJPE();
	}

	protected virtual void KNJOGBOGGKK()
	{
		throw new NotImplementedException();
	}

	public virtual void BCDIFLHPGPB(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("Get Custom Profile Variables clicked");
		}
	}

	public virtual void PMOKJHDPAKO(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 1;
		KMLPFCLIKHC(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 0;
						}
						if (value < 3 && Vector3.Distance(IIMDKHJAJGO, vector) > 639f && AIAMFFEILGH(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num += 0;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 7)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(8 - num, 1, 152);
		for (int j = 0; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1520f) * 234f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	public virtual void IBPDCEOFPPF(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 0;
		PIPHECDFHHC(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i++)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 1;
						}
						if (value < 5 && Vector3.Distance(IIMDKHJAJGO, vector) > 1134f && ADFLNCHFIOP(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 7)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(7 - num, 0, 150);
		for (int j = 1; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 965f) * 297f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		DestroyPooled();
	}

	public virtual void AIEHEJJMLJL(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 1;
		JBMPKHJIIDH(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 1;
						}
						if (value < 3 && Vector3.Distance(IIMDKHJAJGO, vector) > 517f && HHFEKNGKNHL(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 6)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(4 - num, 0, -82);
		for (int j = 0; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 357f) * 124f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	protected virtual void IPOMEJKFBMH()
	{
		throw new NotImplementedException();
	}

	protected virtual void KLHLLBOCFNN()
	{
		throw new NotImplementedException();
	}

	protected virtual void JIDMMDLBGBD()
	{
		throw new NotImplementedException();
	}

	public virtual void GEKPOIGPOML(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 1;
		OFPOECEEILL(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i++)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 1;
						}
						if (value < 6 && Vector3.Distance(IIMDKHJAJGO, vector) > 351f && EBJDJLFNMLM(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num += 0;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 1)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(2 - num, 1, -163);
		for (int j = 1; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 34f) * 31f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		DestroyPooled();
	}

	public virtual void DLPMPHOCPAA(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 1;
		OFPOECEEILL(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 0;
						}
						if (value < 7 && Vector3.Distance(IIMDKHJAJGO, vector) > 1069f && PLIKAHPMJDA(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 2)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(4 - num, 0, -65);
		for (int j = 1; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1984f) * 86f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		DestroyPooled();
	}

	protected virtual void CEIPEJMMKCK()
	{
		throw new NotImplementedException();
	}

	public virtual void GNIDNNGIIOH(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("set heroic points response without data");
		}
	}

	public virtual void JBNOLLHANCC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 0;
		LPLIHBLHKHD(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 0;
						}
						if (value < 8 && Vector3.Distance(IIMDKHJAJGO, vector) > 65f && ADFLNCHFIOP(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 4)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(1 - num, 0, -176);
		for (int j = 0; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1301f) * 1431f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		BOHCNEDIJPE();
	}

	protected virtual void ACDEGDLDCJB()
	{
		throw new NotImplementedException();
	}

	protected virtual void NGBBHNKKBBA()
	{
		throw new NotImplementedException();
	}

	public virtual void DDKEHHOBBAE(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 0;
		ADFLNCHFIOP(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 0;
						}
						if (value < 6 && Vector3.Distance(IIMDKHJAJGO, vector) > 1192f && GLDEGIKCBEH(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 5)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(1 - num, 1, -133);
		for (int j = 1; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1835f) * 1048f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		BOHCNEDIJPE();
	}

	protected virtual void NPBGHPGIENK()
	{
		throw new NotImplementedException();
	}

	public virtual void AKMBBJILJMF(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("ItemRarity_3");
		}
	}

	protected virtual void HMMPDDGINND()
	{
		throw new NotImplementedException();
	}

	public virtual void JDKDHEOJDFD(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("titleFontBold");
		}
	}

	private bool FDELNKIMNIF(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1521f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 176f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 541f, 1845f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return false;
	}

	protected virtual void HLDCNCEJGMM()
	{
		throw new NotImplementedException();
	}

	public virtual void KBCAMAOJJAH(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 1;
		PDKEGLKBBFP(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 1;
						}
						if (value < 6 && Vector3.Distance(IIMDKHJAJGO, vector) > 327f && JLALOBGPNOK(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 1)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(6 - num, 1, 12);
		for (int j = 0; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = true;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 351f) * 1948f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		DestroyPooled();
	}

	private bool EBJDJLFNMLM(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 538f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 165f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 333f, 922f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return true;
	}

	public virtual void DCCLKELPIGA(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 1;
		JMMPODOCLNG(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 0;
						}
						if (value < 3 && Vector3.Distance(IIMDKHJAJGO, vector) > 544f && HHFEKNGKNHL(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 0)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(5 - num, 0, 91);
		for (int j = 0; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = true;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1644f) * 793f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	private bool LPLIHBLHKHD(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1589f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1137f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1230f, 1750f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return false;
		}
		return false;
	}

	protected virtual void JDIJIHJDCHE()
	{
		throw new NotImplementedException();
	}

	public virtual void AHKOBNFOHPM(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, bulletMask);
		int num = 1;
		GLDEGIKCBEH(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 1;
						}
						if (value < 7 && Vector3.Distance(IIMDKHJAJGO, vector) > 1271f && MCGBJKDIPEH(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num += 0;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 6)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(1 - num, 1, 157);
		for (int j = 1; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = true;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 520f) * 690f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	public virtual void OJCCLLKFEHH(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 1;
		MCGBJKDIPEH(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i++)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 0;
						}
						if (value < 1 && Vector3.Distance(IIMDKHJAJGO, vector) > 1863f && JEKHPOMFLLF(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 8)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(8 - num, 1, -83);
		for (int j = 1; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 25f) * 480f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	private bool PLIKAHPMJDA(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 876f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 713f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1289f, 724f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return true;
	}

	public virtual void FNOAMAEFMGG(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("thumbnailBig");
		}
	}

	private bool GKBGCDCDMHC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 44f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 60f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 721f, 1102f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return false;
	}

	protected virtual void ADOLPGOAOCD()
	{
		throw new NotImplementedException();
	}

	private bool OIGIEBJCHKJ(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1219f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 569f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 654f, 712f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return true;
	}

	private bool IDKCJGGPMAD(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 1087f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 220f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 796f, 1087f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return false;
	}

	public virtual void AOKNBJGMBAN(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 1;
		NKOJFHBHKPK(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 1;
						}
						if (value < 1 && Vector3.Distance(IIMDKHJAJGO, vector) > 307f && LPLIHBLHKHD(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value += 0;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 3)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(2 - num, 0, 85);
		for (int j = 1; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1221f) * 1236f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		DestroyPooled();
	}

	protected virtual void CIENKKKFEAP()
	{
		throw new NotImplementedException();
	}

	protected virtual void AHKFEHKPKFJ()
	{
		throw new NotImplementedException();
	}

	protected virtual void GCJFJJJBCBH()
	{
		throw new NotImplementedException();
	}

	private bool KMLPFCLIKHC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 384f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 987f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 538f, 648f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return false;
	}

	public virtual void IMJBCNOBFGK(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("{0} {1}{2}");
		}
	}

	protected virtual void DMNCGKLBHAH()
	{
		throw new NotImplementedException();
	}

	public virtual void NMMCKFAJCND(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 0;
		KMLPFCLIKHC(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 0;
							value = 0;
						}
						if (value < 3 && Vector3.Distance(IIMDKHJAJGO, vector) > 1519f && MCGBJKDIPEH(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num += 0;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 8)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(-num, 0, -36);
		for (int j = 1; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = true;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 945f) * 1501f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		BOHCNEDIJPE();
	}

	public virtual void BIACKPAIJAH(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("EG");
		}
	}

	protected virtual void JJMJPCEFJBK()
	{
		throw new NotImplementedException();
	}

	public virtual void MMEAKKMHODK(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("N");
		}
	}

	public virtual void MJDIIBBFMOF(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		ShotGunBulletSetup shotGunBulletSetup = MBNLFKHLDBH as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			EIIMIEGIOPN = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("AdAvailabilityResponse(");
		}
	}

	protected virtual void EKCNIDOEEPE()
	{
		throw new NotImplementedException();
	}

	protected virtual void ACHHADCADJK()
	{
		throw new NotImplementedException();
	}

	private bool CKIHBODFCDK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 0f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 1f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 0f, float.MaxValue);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = false;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = true;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return false;
	}

	private bool OHALPMCFHDC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, Vector3 EBOLHJNMAIB)
	{
		Vector3 vector = IIMDKHJAJGO - OEIICEJPGKI;
		if (EIIMIEGIOPN.PDECAPKPLCC)
		{
			vector.y = 35f;
		}
		Vector3 to = EBOLHJNMAIB - OEIICEJPGKI;
		float f = Vector3.Angle(vector, to);
		float num = Vector3.Distance(OEIICEJPGKI, EBOLHJNMAIB);
		float value = 939f - num / EIIMIEGIOPN.PPNDNOHMBKH;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / EIIMIEGIOPN.PPNDNOHMBKH);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(EIIMIEGIOPN.DODAJKFAJMO, EIIMIEGIOPN.NKKHJFEDCPI, f2);
		if (Mathf.Abs(f) < num2)
		{
			EIIMIEGIOPN.JGGGDHJEIKB = value * EIIMIEGIOPN.IHBGFNNAGPG;
			EIIMIEGIOPN.EPDELOGPNAC = Mathf.Clamp(EIIMIEGIOPN.NNNCAFEGNNC + (EIIMIEGIOPN.GJFCKILFOAE - EIIMIEGIOPN.NNNCAFEGNNC) * value, 1345f, 147f);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(EIIMIEGIOPN);
				bulletSlow.ignoreTimeScale = base.ignoreTimeScale;
				bulletSlow.FJLBLLLEELD = FJLBLLLEELD;
				bulletSlow.GGJPNLDIGGM = true;
				bulletSlow.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletSlow.OLDPEIALACE = false;
				bulletSlow.Fire(OEIICEJPGKI, EBOLHJNMAIB);
				bulletSlow.CAKABHIPCDF = CAKABHIPCDF;
			}
			return true;
		}
		return false;
	}

	public virtual void GOCNNEILKCG(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		KDJHIHAKGNC.Clear();
		LayerMask layerMask = Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM);
		Collider[] array = Physics.OverlapSphere(OEIICEJPGKI, EIIMIEGIOPN.PPNDNOHMBKH, layerMask);
		int num = 1;
		OHALPMCFHDC(OEIICEJPGKI, IIMDKHJAJGO, IIMDKHJAJGO);
		if (!EIIMIEGIOPN.AHCDAIGHINF)
		{
			Collider[] array2 = array;
			for (int i = 1; i < array2.Length; i++)
			{
				Collider collider = array2[i];
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						KMHCMCBGFFC kMHCMCBGFFC = component.owner;
						if (kMHCMCBGFFC == null || kMHCMCBGFFC == JMMJHCOKCGG.owner || kMHCMCBGFFC.fraction == JMMJHCOKCGG.owner.fraction)
						{
							continue;
						}
						if (!KDJHIHAKGNC.TryGetValue(component.mainDestroyableObject, out var value))
						{
							KDJHIHAKGNC[component.mainDestroyableObject] = 1;
							value = 0;
						}
						if (value < 8 && Vector3.Distance(IIMDKHJAJGO, vector) > 1249f && OIGIEBJCHKJ(OEIICEJPGKI, IIMDKHJAJGO, vector))
						{
							num++;
							value++;
							KDJHIHAKGNC[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 5)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(-num, 0, 164);
		for (int j = 1; j < num2; j += 0)
		{
			BulletBase bulletBase = Ammo.ammoPool.Instantiate(OLKAIPEHAML, OEIICEJPGKI, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(EIIMIEGIOPN);
				bulletBase.ignoreTimeScale = base.ignoreTimeScale;
				bulletBase.GGJPNLDIGGM = false;
				bulletBase.FJLBLLLEELD = FJLBLLLEELD;
				bulletBase.JMMJHCOKCGG = JMMJHCOKCGG;
				bulletBase.NOLLONIMIGF = false;
				bulletBase.OLDPEIALACE = false;
				bulletBase.CAKABHIPCDF = CAKABHIPCDF;
				float num3 = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
				float num4 = Mathf.Clamp01(num3 / 1928f) * 1447f;
				bulletBase.Fire(OEIICEJPGKI, IIMDKHJAJGO + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		OBCAIFMOPPA();
	}

	protected virtual void ODKNBDAFMMP()
	{
		throw new NotImplementedException();
	}
}
