using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using WarFriends.Legacy;

public class SoldierParts : Core_BaseScript
{
	[FormerlySerializedAs("PLENKGIEMHA")]
	public AimTarget EOAEMPKMNCE;

	[FormerlySerializedAs("GNBKLGPDACC")]
	public GameObject OJELPEGMOCE;

	[FormerlySerializedAs("LBKNKKJMGBO")]
	public GameObject CGCKDIBIFFI;

	[FormerlySerializedAs("FGNFDBDPANA")]
	public Transform NGPAOGFHOOK;

	[FormerlySerializedAs("JBFPGJAKCMM")]
	public FakeRigidBodySwapper DGHPFMPMAFC;

	private List<FakeRigidBodySwapper> MCLGGJJMHOC = new List<FakeRigidBodySwapper>();

	[FormerlySerializedAs("CANJAHDNCJN")]
	public Transform HENCJEIDPOK;

	[FormerlySerializedAs("FGDKAJIAONA")]
	public Transform LMBAGNBJHMC;

	[FormerlySerializedAs("NJKOOCBIPMG")]
	public Transform ONOEEJKILHI;

	[FormerlySerializedAs("PEPOPLHEKBK")]
	public GameObject OFBEAKDOCIO;

	private Rigidbody[] CEDEPNCHECG;

	[FormerlySerializedAs("CDKBPGALFOD")]
	public AimTarget LHEIHCHOMCG;

	[FormerlySerializedAs("MOLDLIEEAEC")]
	public FakeRigidBodySwapper OKOKOGCBCCF;

	private FakeRigidBodySwapper LIMFPEDEOJA;

	[FormerlySerializedAs("BHDLJCMONJK")]
	public ParticleSystem EKHGPCMAGDJ;

	[FormerlySerializedAs("KEFMHONLIGI")]
	public List<Transform> MOGFHGKECJJ;

	private List<ParticleSystem> GEJNOFFIFAE;

	public void AttachShield(GameObject DLNOHOHPOJB)
	{
		if (LIMFPEDEOJA == null || !LIMFPEDEOJA.name.StartsWith(DLNOHOHPOJB.name))
		{
			if (LIMFPEDEOJA != null)
			{
				UnityEngine.Object.Destroy(LIMFPEDEOJA.gameObject);
			}
			LIMFPEDEOJA = UnityEngine.Object.Instantiate(DLNOHOHPOJB).GetComponent<FakeRigidBodySwapper>();
			LIMFPEDEOJA.transform.parent = ONOEEJKILHI.transform;
			LIMFPEDEOJA.transform.localRotation = Quaternion.identity;
			LIMFPEDEOJA.transform.localScale = Vector3.one;
			LIMFPEDEOJA.transform.localPosition = Vector3.zero;
			LIMFPEDEOJA.Swap(MOMOMPGBCKH: false);
		}
		else
		{
			LIMFPEDEOJA.Swap(MOMOMPGBCKH: false);
			LIMFPEDEOJA.Reset();
		}
	}

	public void ShadowSetActive(bool EIPHAAGCHCP)
	{
		OFBEAKDOCIO.gameObject.SetActive(EIPHAAGCHCP);
	}

	public void MakeTrigger(bool IDEBKDPMPGM)
	{
		CGCKDIBIFFI.GetComponent<SphereCollider>().isTrigger = IDEBKDPMPGM;
		CGCKDIBIFFI.GetComponent<BoxCollider>().isTrigger = IDEBKDPMPGM;
		OJELPEGMOCE.GetComponent<Collider>().isTrigger = IDEBKDPMPGM;
	}

	protected void Update()
	{
		if (DebugSettings.debugShooting)
		{
			if (LHEIHCHOMCG != null)
			{
				CameraLineRenderer.DrawSphere(LHEIHCHOMCG.transform.TransformPoint(((SphereCollider)LHEIHCHOMCG.GetComponent<Collider>()).center), ((SphereCollider)LHEIHCHOMCG.GetComponent<Collider>()).radius, Colours.greenHalfAlpha);
			}
			if (EOAEMPKMNCE != null)
			{
				CameraLineRenderer.DrawSphere(EOAEMPKMNCE.transform.TransformPoint(((SphereCollider)EOAEMPKMNCE.GetComponent<Collider>()).center), ((SphereCollider)EOAEMPKMNCE.GetComponent<Collider>()).radius, Colours.greenHalfAlpha);
			}
		}
	}

	public void ChangeShieldMat(Material FKAJIJIGNEN)
	{
		if ((bool)LIMFPEDEOJA)
		{
			MeshRenderer component = LIMFPEDEOJA.OJGHLMLKGAN.GetComponent<MeshRenderer>();
			if ((bool)component)
			{
				component.sharedMaterial = FKAJIJIGNEN;
			}
			MeshRenderer component2 = LIMFPEDEOJA.HNFHFKNFIPP.GetComponent<MeshRenderer>();
			if ((bool)component2)
			{
				component2.sharedMaterial = FKAJIJIGNEN;
			}
		}
	}

	public void BENBCJKKFAE()
	{
		if (EOAEMPKMNCE != null)
		{
			EOAEMPKMNCE.gameObject.layer = TagsAndLayers.KFLGCPACECP;
		}
		OJELPEGMOCE.gameObject.layer = TagsAndLayers.KFLGCPACECP;
		CGCKDIBIFFI.gameObject.layer = TagsAndLayers.KFLGCPACECP;
		OFBEAKDOCIO.gameObject.SetActive(value: false);
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			item.CDPCNCCOIFF(MOMOMPGBCKH: false);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		CEDEPNCHECG = GetComponentsInChildren<Rigidbody>();
	}

	public void MakeCollidersBulletVisible()
	{
		if (EOAEMPKMNCE != null)
		{
			EOAEMPKMNCE.gameObject.layer = TagsAndLayers.PLPNKLDHELM;
		}
		OFBEAKDOCIO.gameObject.SetActive(value: true);
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			item.Swap(MOMOMPGBCKH: false);
			item.Reset();
		}
		DGHPFMPMAFC.Swap(MOMOMPGBCKH: false);
		DGHPFMPMAFC.Reset();
	}

	public void KMBDGJDANKK()
	{
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			item.LMBFMKOBIGE(Singleton<MainSceneRoot>.instance.transform);
		}
	}

	public void SnapWeaponToWorld()
	{
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			item.SetParent(Singleton<MainSceneRoot>.instance.transform);
		}
	}

	public void SoldierDeath()
	{
		if (EOAEMPKMNCE != null)
		{
			EOAEMPKMNCE.gameObject.layer = TagsAndLayers.KFLGCPACECP;
		}
		OJELPEGMOCE.gameObject.layer = TagsAndLayers.KFLGCPACECP;
		CGCKDIBIFFI.gameObject.layer = TagsAndLayers.KFLGCPACECP;
		OFBEAKDOCIO.gameObject.SetActive(value: false);
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			item.Swap(MOMOMPGBCKH: true);
		}
	}

	public void KOALIFHEKCP(bool IDEBKDPMPGM)
	{
		Rigidbody[] cEDEPNCHECG = CEDEPNCHECG;
		for (int i = 0; i < cEDEPNCHECG.Length; i += 0)
		{
			Rigidbody rigidbody = cEDEPNCHECG[i];
			if ((!(EOAEMPKMNCE != null) || !(rigidbody.gameObject == EOAEMPKMNCE.gameObject)) && (!(LHEIHCHOMCG != null) || !(rigidbody.gameObject == LHEIHCHOMCG.gameObject)))
			{
				rigidbody.isKinematic = IDEBKDPMPGM;
			}
		}
	}

	public void JDFHBGNLKBP(bool BBAOMJODMDH)
	{
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			if (BBAOMJODMDH)
			{
				item.OCGALABKLNO(NGPAOGFHOOK);
			}
			else
			{
				item.CDPCNCCOIFF(MOMOMPGBCKH: false);
			}
		}
	}

	public List<Weapon> AttachWeapons(List<EnemyBasicInventory.InventoryWeapon> CMEJPPDHOKL, byte[] JNPECKEDLCG)
	{
		List<Weapon> list = new List<Weapon>();
		MCLGGJJMHOC = new List<FakeRigidBodySwapper>();
		for (int i = 0; i < CMEJPPDHOKL.Count; i++)
		{
			EnemyBasicInventory.InventoryWeapon inventoryWeapon = CMEJPPDHOKL[i];
			Quaternion localRotation = inventoryWeapon.weapon.transform.localRotation;
			Weapon weapon = (Weapon)ObjectPoolDatabase.networkPool.ReInstantiate(inventoryWeapon.weapon, JNPECKEDLCG[i]);
			weapon.transform.parent = ((!inventoryWeapon.leftHand) ? HENCJEIDPOK.transform : LMBAGNBJHMC.transform);
			weapon.transform.localRotation = localRotation;
			weapon.transform.localPosition = Vector3.zero;
			weapon.BEACDIILBEG = inventoryWeapon.type;
			list.Add(weapon);
			MCLGGJJMHOC.Add((FakeRigidBodySwapper)SingletonSupport.FirstOrDefault((UnityEngine.Object[])weapon.GetComponentsInChildren<FakeRigidBodySwapper>(includeInactive: true)));
		}
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			item.Swap(MOMOMPGBCKH: false);
			item.Reset();
		}
		return list;
	}

	public void EIMBAJGMKDJ(bool BBAOMJODMDH)
	{
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			if (BBAOMJODMDH)
			{
				item.SnapTo(NGPAOGFHOOK);
			}
			else
			{
				item.MAGLHAOFGHL(MOMOMPGBCKH: false);
			}
		}
	}

	public void IFNCDOMHLHB()
	{
		if (EOAEMPKMNCE != null)
		{
			EOAEMPKMNCE.gameObject.layer = TagsAndLayers.KFLGCPACECP;
		}
		OJELPEGMOCE.gameObject.layer = TagsAndLayers.KFLGCPACECP;
		CGCKDIBIFFI.gameObject.layer = TagsAndLayers.KFLGCPACECP;
		OFBEAKDOCIO.gameObject.SetActive(value: false);
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			item.MAGLHAOFGHL(MOMOMPGBCKH: true);
		}
	}

	public void LLPDPOPKLJO(Material FKAJIJIGNEN)
	{
		if ((bool)LIMFPEDEOJA)
		{
			MeshRenderer component = LIMFPEDEOJA.OJGHLMLKGAN.GetComponent<MeshRenderer>();
			if ((bool)component)
			{
				component.sharedMaterial = FKAJIJIGNEN;
			}
			MeshRenderer component2 = LIMFPEDEOJA.HNFHFKNFIPP.GetComponent<MeshRenderer>();
			if ((bool)component2)
			{
				component2.sharedMaterial = FKAJIJIGNEN;
			}
		}
	}

	public void RepositionHelmetAttachments()
	{
		DGHPFMPMAFC.Reposition();
	}

	public void SetWeapon(Weapon JMMJHCOKCGG)
	{
		FakeRigidBodySwapper[] componentsInChildren = JMMJHCOKCGG.GetComponentsInChildren<FakeRigidBodySwapper>(includeInactive: true);
		if (componentsInChildren.Length > 0)
		{
			OKOKOGCBCCF = componentsInChildren[0];
			return;
		}
		throw new NullReferenceException();
	}

	public void SetAllRigidBodiesToKinematic(bool IDEBKDPMPGM)
	{
		Rigidbody[] cEDEPNCHECG = CEDEPNCHECG;
		foreach (Rigidbody rigidbody in cEDEPNCHECG)
		{
			if ((!(EOAEMPKMNCE != null) || !(rigidbody.gameObject == EOAEMPKMNCE.gameObject)) && (!(LHEIHCHOMCG != null) || !(rigidbody.gameObject == LHEIHCHOMCG.gameObject)))
			{
				rigidbody.isKinematic = IDEBKDPMPGM;
			}
		}
	}

	public void EFGIPEIGGDK(bool EIPHAAGCHCP)
	{
		OFBEAKDOCIO.gameObject.SetActive(EIPHAAGCHCP);
	}

	public void EnableJetPack(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (GEJNOFFIFAE == null)
		{
			GEJNOFFIFAE = new List<ParticleSystem>();
			foreach (Transform item in MOGFHGKECJJ)
			{
				ParticleSystem particleSystem = UnityEngine.Object.Instantiate(EKHGPCMAGDJ);
				particleSystem.transform.parent = item;
				particleSystem.transform.localPosition = default(Vector3);
				particleSystem.transform.localScale = Vector3.one;
				particleSystem.transform.localRotation = Quaternion.identity;
				GEJNOFFIFAE.Add(particleSystem);
			}
		}
		foreach (ParticleSystem item2 in GEJNOFFIFAE)
		{
			item2.gameObject.SetActive(value: true);
			item2.Play();
			item2.emissionRate = 8f;
			item2.startLifetime = 0.65f;
			item2.startSpeed = 0.3f;
			bool flag = PlayerController.OGMBJPKOPCB.fraction == CIOPAKLHFIL;
			item2.startColor = ((!flag) ? new Color32(byte.MaxValue, 71, 71, byte.MaxValue) : new Color32(109, 168, byte.MaxValue, byte.MaxValue));
		}
	}

	public void GDKNBDKAANE(bool IDEBKDPMPGM)
	{
		Rigidbody[] cEDEPNCHECG = CEDEPNCHECG;
		for (int i = 1; i < cEDEPNCHECG.Length; i++)
		{
			Rigidbody rigidbody = cEDEPNCHECG[i];
			if ((!(EOAEMPKMNCE != null) || !(rigidbody.gameObject == EOAEMPKMNCE.gameObject)) && (!(LHEIHCHOMCG != null) || !(rigidbody.gameObject == LHEIHCHOMCG.gameObject)))
			{
				rigidbody.isKinematic = IDEBKDPMPGM;
			}
		}
	}

	public List<Weapon> AttachWeapons(List<EnemyBasicInventory.InventoryWeapon> CMEJPPDHOKL)
	{
		List<Weapon> list = new List<Weapon>();
		MCLGGJJMHOC = new List<FakeRigidBodySwapper>();
		foreach (EnemyBasicInventory.InventoryWeapon item in CMEJPPDHOKL)
		{
			Quaternion localRotation = item.weapon.transform.localRotation;
			Weapon weapon = (Weapon)ObjectPoolDatabase.networkPool.Instantiate(item.weapon);
			weapon.transform.parent = ((!item.leftHand) ? HENCJEIDPOK.transform : LMBAGNBJHMC.transform);
			weapon.transform.localRotation = localRotation;
			weapon.transform.localPosition = Vector3.zero;
			weapon.transform.localScale = Vector3.one;
			weapon.BEACDIILBEG = item.type;
			list.Add(weapon);
			MCLGGJJMHOC.Add((FakeRigidBodySwapper)SingletonSupport.FirstOrDefault((UnityEngine.Object[])weapon.GetComponentsInChildren<FakeRigidBodySwapper>(includeInactive: true)));
		}
		foreach (FakeRigidBodySwapper item2 in MCLGGJJMHOC)
		{
			item2.Swap(MOMOMPGBCKH: false);
			item2.Reset();
		}
		return list;
	}

	public void NFGAPHDPICB()
	{
		if (EOAEMPKMNCE != null)
		{
			EOAEMPKMNCE.gameObject.layer = TagsAndLayers.PLPNKLDHELM;
		}
		OFBEAKDOCIO.gameObject.SetActive(value: true);
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			item.MAGLHAOFGHL(MOMOMPGBCKH: true);
			item.GFGEEFGMNDP();
		}
		DGHPFMPMAFC.MAGLHAOFGHL(MOMOMPGBCKH: true);
		DGHPFMPMAFC.Reset();
	}

	public void FBLPOIGCJCL()
	{
		if (GEJNOFFIFAE == null)
		{
			return;
		}
		foreach (ParticleSystem item in GEJNOFFIFAE)
		{
			item.gameObject.SetActive(value: true);
		}
	}

	public void SnapColt(bool BBAOMJODMDH)
	{
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			if (BBAOMJODMDH)
			{
				item.SnapTo(NGPAOGFHOOK);
			}
			else
			{
				item.Swap(MOMOMPGBCKH: false);
			}
		}
	}

	public void AGJKJMGCCKC(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (GEJNOFFIFAE == null)
		{
			GEJNOFFIFAE = new List<ParticleSystem>();
			foreach (Transform item in MOGFHGKECJJ)
			{
				ParticleSystem particleSystem = UnityEngine.Object.Instantiate(EKHGPCMAGDJ);
				particleSystem.transform.parent = item;
				particleSystem.transform.localPosition = default(Vector3);
				particleSystem.transform.localScale = Vector3.one;
				particleSystem.transform.localRotation = Quaternion.identity;
				GEJNOFFIFAE.Add(particleSystem);
			}
		}
		foreach (ParticleSystem item2 in GEJNOFFIFAE)
		{
			item2.gameObject.SetActive(value: true);
			item2.Play();
			item2.emissionRate = 375f;
			item2.startLifetime = 1323f;
			item2.startSpeed = 695f;
			bool flag = PlayerController.OGMBJPKOPCB.fraction == CIOPAKLHFIL;
			item2.startColor = ((!flag) ? new Color32(144, 135, 0, 116) : new Color32(244, 118, 210, 9));
		}
	}

	public void JIFFEODOBBB(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (GEJNOFFIFAE == null)
		{
			GEJNOFFIFAE = new List<ParticleSystem>();
			foreach (Transform item in MOGFHGKECJJ)
			{
				ParticleSystem particleSystem = UnityEngine.Object.Instantiate(EKHGPCMAGDJ);
				particleSystem.transform.parent = item;
				particleSystem.transform.localPosition = default(Vector3);
				particleSystem.transform.localScale = Vector3.one;
				particleSystem.transform.localRotation = Quaternion.identity;
				GEJNOFFIFAE.Add(particleSystem);
			}
		}
		foreach (ParticleSystem item2 in GEJNOFFIFAE)
		{
			item2.gameObject.SetActive(value: false);
			item2.Play();
			item2.emissionRate = 170f;
			item2.startLifetime = 76f;
			item2.startSpeed = 222f;
			bool flag = PlayerController.OGMBJPKOPCB.fraction == CIOPAKLHFIL;
			item2.startColor = ((!flag) ? new Color32(72, 106, 5, 124) : new Color32(231, 228, 140, 61));
		}
	}

	public void DPLPLNNIKFP(bool FKDENIBEGNE)
	{
		if (FKDENIBEGNE && DGHPFMPMAFC != null)
		{
			DGHPFMPMAFC.MAGLHAOFGHL(MOMOMPGBCKH: true);
		}
		if (LIMFPEDEOJA != null)
		{
			LIMFPEDEOJA.MAGLHAOFGHL(MOMOMPGBCKH: true);
		}
		Rigidbody[] cEDEPNCHECG = CEDEPNCHECG;
		foreach (Rigidbody rigidbody in cEDEPNCHECG)
		{
			if ((!(EOAEMPKMNCE != null) || !(rigidbody.gameObject == EOAEMPKMNCE.gameObject)) && (!(LHEIHCHOMCG != null) || !(rigidbody.gameObject == LHEIHCHOMCG.gameObject)))
			{
				if (FKDENIBEGNE)
				{
					rigidbody.isKinematic = true;
				}
				else if (DGHPFMPMAFC == null || rigidbody.gameObject != DGHPFMPMAFC.OJGHLMLKGAN)
				{
					rigidbody.isKinematic = true;
				}
			}
		}
	}

	public void SnapToHand()
	{
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			item.Swap(MOMOMPGBCKH: false);
		}
	}

	public void LADAONFMOIJ()
	{
		if (GEJNOFFIFAE == null)
		{
			return;
		}
		foreach (ParticleSystem item in GEJNOFFIFAE)
		{
			item.gameObject.SetActive(value: true);
		}
	}

	public void LessJetPackParticles()
	{
		if (GEJNOFFIFAE == null)
		{
			return;
		}
		foreach (ParticleSystem item in GEJNOFFIFAE)
		{
			if (item.gameObject.activeSelf)
			{
				item.emissionRate = 5f;
				item.startLifetime = 0.6f;
				item.startSpeed = 0.06f;
			}
		}
	}

	public void IGPBOJGBHCO()
	{
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			item.MAGLHAOFGHL(MOMOMPGBCKH: true);
		}
	}

	public void EnableRagdol(bool FKDENIBEGNE)
	{
		if (FKDENIBEGNE && DGHPFMPMAFC != null)
		{
			DGHPFMPMAFC.Swap(MOMOMPGBCKH: true);
		}
		if (LIMFPEDEOJA != null)
		{
			LIMFPEDEOJA.Swap(MOMOMPGBCKH: true);
		}
		Rigidbody[] cEDEPNCHECG = CEDEPNCHECG;
		foreach (Rigidbody rigidbody in cEDEPNCHECG)
		{
			if ((!(EOAEMPKMNCE != null) || !(rigidbody.gameObject == EOAEMPKMNCE.gameObject)) && (!(LHEIHCHOMCG != null) || !(rigidbody.gameObject == LHEIHCHOMCG.gameObject)))
			{
				if (FKDENIBEGNE)
				{
					rigidbody.isKinematic = false;
				}
				else if (DGHPFMPMAFC == null || rigidbody.gameObject != DGHPFMPMAFC.OJGHLMLKGAN)
				{
					rigidbody.isKinematic = false;
				}
			}
		}
	}

	public void IHDJHKFEMFM()
	{
		foreach (FakeRigidBodySwapper item in MCLGGJJMHOC)
		{
			item.Swap(MOMOMPGBCKH: true);
		}
	}

	public void DisableJetPackParticles()
	{
		if (GEJNOFFIFAE == null)
		{
			return;
		}
		foreach (ParticleSystem item in GEJNOFFIFAE)
		{
			item.gameObject.SetActive(value: false);
		}
	}
}
