using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class AssaultHelicopter : Vehicle<AssaultHelicopterBehaviour>
{
	private sealed class PBAIKHKBHBG
	{
		internal GameShootableEntity.ShotTarget GEHACOGJMHA;

		internal Vector3 MDOPFNNFLFB;

		internal Ammo.ILIOELBBLDM MGDGFBCJINH;

		internal GameShootableEntity.ShotTarget KPICOKPHMIC;

		internal Vector3 MHLDJIABNFI;

		internal int HLAKECBLNJL;

		internal float PJPHFMECEHH;

		internal AssaultHelicopter BJGCPDNMHDH;

		internal void NDJOJHNIBFC()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != (GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out))
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.OAOOGPJEDBL(BJGCPDNMHDH.GGKGGMNIDMI[1].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 876f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[1].MBOJADMHJMO(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 1376.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void EMKPBGFBPFI()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != (GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield))
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.PNBAFAAGNMC(BJGCPDNMHDH.GGKGGMNIDMI[1].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 463f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].ShootBatch(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 711.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void MCFGAFBEJDK()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Shield)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.HHJLJCLJNED(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 1932f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].OFPCMHCEMHA(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 585.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void AMIJFGBOCLC()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.None)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.EGLIJJGEINK(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 1010f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[1].MBOJADMHJMO(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 351.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void BMCMDMKGHHO()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Shield)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.EGLIJJGEINK(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 1999f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].MBOJADMHJMO(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 1756.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void AGFEDJAKLAC()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Out)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.ENKMEEDAALF(BJGCPDNMHDH.GGKGGMNIDMI[1].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 64f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[1].MBOJADMHJMO(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 419.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void MFCNOIDCJME()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != (GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out))
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.CINBKABMMMH(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 1097f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].MBOJADMHJMO(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 486.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void ECPMEMNKMCB()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != (GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out))
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.KEMKJNHCEIM(BJGCPDNMHDH.GGKGGMNIDMI[1].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 1489f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].MBOJADMHJMO(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 659.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void MAKLHLCDIKD()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.None)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.ILFJCEAPCFF(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 1587f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].CHPNNNDGNIL(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 803.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void LJCDGJKCNEC()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Shield)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.PredictPosition(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[1].ShootBatch(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 0.5), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void OKNCFDMEFGJ()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Shield)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.PHHCNIABKLA(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 388f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[1].CHPNNNDGNIL(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 857.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void MMEEJDGGAID()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Head)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.FHIELLINPIH(BJGCPDNMHDH.GGKGGMNIDMI[1].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 662f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].MBOJADMHJMO(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 698.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void ILNPANOCHIH()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Out)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.ABKLEHLLDBN(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 1605f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].MBOJADMHJMO(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 1597.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void PHGDBIEENCB()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Head)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.BBAAMJMGEJB(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 1035f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].OFPCMHCEMHA(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 1148.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void FHDOHCJJEMM()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Body)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.KAEMPBHPOLJ(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 35f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[1].MBOJADMHJMO(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 1032.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void CIFEDFPPPOK()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Head)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.HHJLJCLJNED(BJGCPDNMHDH.GGKGGMNIDMI[1].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 1532f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].MBOJADMHJMO(KPICOKPHMIC, MDOPFNNFLFB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 797.0), PJPHFMECEHH, MGDGFBCJINH);
		}
	}

	private readonly LHMCMJDDOHI LADBLHGBOKJ = new LHMCMJDDOHI();

	private float NDOILFHEJHE;

	[FormerlySerializedAs("BGGEDFNMGIE")]
	public GameObject KEGHKGBEIHD;

	[FormerlySerializedAs("AIBBNKAHIIA")]
	public GameObject HPOGALNAEFO;

	[FormerlySerializedAs("AJNMLEGNFMJ")]
	public EnemyPointVehicle NLGBGOGCNKP;

	[FormerlySerializedAs("KPGABKOOCAO")]
	public ParticleSystem MLJMFMAIDIB;

	public float JEMGOPDEBLL = 100f;

	[FormerlySerializedAs("IKANKLBKCEA")]
	public List<Glass> MBILJNBILGN;

	[FormerlySerializedAs("DAFACJHHOMH")]
	public DestroyableObject JNHMOOKDCOO;

	private DestroyableObjectMultipleParts FFOAABONJNO;

	private bool PFKPCFCEDME;

	private float NBCGDEDNNGH;

	private float MNGLGGJJFOO;

	private Rigidbody KJPFENINCHJ;

	private float PFOIBOPIJLP;

	private Transform NGCDDPCAGJB;

	private int NLMFOLMAEDA;

	private GameShootableEntity MKIPAEDAADL;

	[FormerlySerializedAs("FJJILDEABAH")]
	public List<BatchedWeapon> GGKGGMNIDMI;

	public float DAGMBMDCIIC = 1f;

	public WayPointPath MFHFIHIHBHA;

	public float JPNAINOGAMM = 0.8f;

	public float DFGAOECAOBD = 1f;

	public float IJPFEKLCIDG = 0.4f;

	public bool IFBJNODDLJC = true;

	public bool LJMIDMAELAP;

	public float ECNBEOHNHCB = 0.1f;

	private int INDBNCLMMNC;

	private int ILEKLILGKAK;

	private Vector3 GPIIEAHGHEO;

	private float MMFCDIKPEHF;

	private Vector3 IMGHHHHHPKF;

	private bool KPBAJMBFKLF;

	private Vector3 DHFAONHFMCF;

	private Quaternion LONCMJPAIJB = Quaternion.identity;

	private AssaultHelicopterBehaviour GBEGGHECHNN => (AssaultHelicopterBehaviour)ACLDFHJKBLI;

	public override DestroyableObject destroyableObj => FFOAABONJNO;

	private void BPKHCMAFKOM()
	{
		if (!LCDBACDIODH && !base.isAlive && Singleton<GameController>.instance.KKHKIEFMENC())
		{
			Vector3 vector = Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG.position - base.transform.position;
			vector.Normalize();
			KJPFENINCHJ.AddForce(Vector3.up * 843f + vector * 1513f, ForceMode.Force);
			KJPFENINCHJ.AddTorque(NGCDDPCAGJB.up * 1035f, ForceMode.Impulse);
		}
	}

	public virtual void IPOEGNPNGGJ()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.NELLCLDMJNE.LIAEIIFPONK;
		List<SpawnPointDrone> list = new List<SpawnPointDrone>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointDrone spawnPointDrone = (SpawnPointDrone)item;
			if (spawnPointDrone.CGAMFFPNFDM.MFHFIHIHBHA.PODMFKMOJML == null && spawnPointDrone.JLLFKJHLLHM() == fraction)
			{
				list.Add(spawnPointDrone);
			}
		}
		if (list.Count > 0)
		{
			int index = UnityEngine.Random.Range(1, list.Count);
			SpawnPointDrone spawnPointDrone2 = list[index];
			base.transform.position = spawnPointDrone2.transform.position;
			Vector3 forward = spawnPointDrone2.CGAMFFPNFDM.transform.position - spawnPointDrone2.transform.position;
			forward.y = 1083f;
			LONCMJPAIJB = Quaternion.LookRotation(forward);
			LMFPIBIPALI(spawnPointDrone2.CGAMFFPNFDM);
		}
		else
		{
			Debug.LogError("ID_WATCHVIDEO");
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + DHFAONHFMCF * JEMGOPDEBLL);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(base.transform.position, base.transform.position + GPIIEAHGHEO * JEMGOPDEBLL);
	}

	public void HFMDLCOGGJJ(WayPoint PLMMBKGLGAB)
	{
		ILEKLILGKAK = PLMMBKGLGAB.MFHFIHIHBHA.wayPoints.Count;
		INDBNCLMMNC = PLMMBKGLGAB.DFHAAIFFLOE;
		IMGHHHHHPKF = PLMMBKGLGAB.transform.position;
		KPBAJMBFKLF = false;
		MFHFIHIHBHA = PLMMBKGLGAB.MFHFIHIHBHA;
		PLMMBKGLGAB.MFHFIHIHBHA.PODMFKMOJML = this;
	}

	public virtual void GCKFKPAJLOK()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = KEEFBLEKBCM().assaultHelicopterBehaviour.health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FriendDamageCoeficient).FLOATVALUE;
		FFOAABONJNO.NGNPMPGIAGP();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.JMMJHCOKCGG.ammoSetup.EPDELOGPNAC = KEEFBLEKBCM().BLOJCMEKNFO().damage;
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.JPNAINOGAMM = KEEFBLEKBCM().PBHCJOLNDHK().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		PFOIBOPIJLP = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(293f, 763f);
		JNHMOOKDCOO.maxHealth = (float)KEEFBLEKBCM().KDEMLILDPGB().glassHealth * PFGLIAHPMCK.scaleHp;
		JNHMOOKDCOO.GGMFIDCAFGM(this);
		JNHMOOKDCOO.NGNPMPGIAGP();
		foreach (Glass item2 in MBILJNBILGN)
		{
			item2.IHLHPGLAEIB();
		}
		JPNAINOGAMM = Mathf.Clamp(KEEFBLEKBCM().PGKKDHPOCCJ().speed, 1057f, 105f);
		IJPFEKLCIDG = JPNAINOGAMM;
	}

	public virtual void KPOELIFMEFO()
	{
		GHPGNELIDBM cIOPAKLHFIL = fraction;
		Type[] array = new Type[1];
		array[1] = typeof(Decoy);
		List<GameShootableEntity> list = GameShootableEntity.ICHKCAGOFCM(cIOPAKLHFIL, array);
		if (list.Count > 0)
		{
			MKIPAEDAADL = list[UnityEngine.Random.Range(0, list.Count)];
			return;
		}
		PlayerController playerController = PlayerController.BAEIKGKJOIN(fraction);
		MKIPAEDAADL = playerController.IJPPJNNDFIB();
	}

	private void NDGLPMLNFHJ(Vector3 MHLDJIABNFI, GameShootableEntity.ShotTarget KPICOKPHMIC, GameShootableEntity.ShotTarget GEHACOGJMHA)
	{
		PBAIKHKBHBG pBAIKHKBHBG = new PBAIKHKBHBG();
		pBAIKHKBHBG.GEHACOGJMHA = GEHACOGJMHA;
		pBAIKHKBHBG.KPICOKPHMIC = KPICOKPHMIC;
		pBAIKHKBHBG.MHLDJIABNFI = MHLDJIABNFI;
		pBAIKHKBHBG.BJGCPDNMHDH = this;
		pBAIKHKBHBG.HLAKECBLNJL = UnityEngine.Random.Range(MKIENKGOFPJ().GEBDFOAAPFL().fireBatchSizeMin, KEEFBLEKBCM().FHDIDGEKCGE().fireBatchSizeMax);
		pBAIKHKBHBG.MGDGFBCJINH = Ammo.GetShotType(pBAIKHKBHBG.KPICOKPHMIC);
		pBAIKHKBHBG.MDOPFNNFLFB = pBAIKHKBHBG.KPICOKPHMIC.transform.position;
		pBAIKHKBHBG.MDOPFNNFLFB = Singleton<AimingHelper>.instance.JHBMEELACLE(GGKGGMNIDMI[0].JMMJHCOKCGG, pBAIKHKBHBG.MDOPFNNFLFB, pBAIKHKBHBG.MHLDJIABNFI, 529f);
		pBAIKHKBHBG.PJPHFMECEHH = MKIENKGOFPJ().MBLNPCAFJFF().probabilityOfRealShot;
		GGKGGMNIDMI[0].OFPCMHCEMHA(pBAIKHKBHBG.KPICOKPHMIC, pBAIKHKBHBG.MDOPFNNFLFB, (int)((double)pBAIKHKBHBG.HLAKECBLNJL * 187.0), pBAIKHKBHBG.PJPHFMECEHH, pBAIKHKBHBG.MGDGFBCJINH);
		InvokeAfter(pBAIKHKBHBG.MFCNOIDCJME, (float)GGKGGMNIDMI[1].JMMJHCOKCGG.JMDLKIAKOIE * 1051f);
	}

	public override void DoReverseAnim()
	{
		base.DoReverseAnim();
		TweenPosition.Begin(base.gameObject, 2f, base.gameObject.transform.position + Vector3.up * 1.5f);
	}

	[SpecialName]
	private AssaultHelicopterBehaviour MKIENKGOFPJ()
	{
		return (AssaultHelicopterBehaviour)ACLDFHJKBLI;
	}

	public virtual void MMJBLFBLKHI()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = MKIENKGOFPJ().ILPKGIBOFLE().health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-79)).FLOATVALUE;
		FFOAABONJNO.NGNPMPGIAGP();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.JMMJHCOKCGG.ammoSetup.EPDELOGPNAC = MKIENKGOFPJ().PCCPMIHMMAE().damage;
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.JPNAINOGAMM = GBEGGHECHNN.FHDIDGEKCGE().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		PFOIBOPIJLP = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(219f, 432f);
		JNHMOOKDCOO.maxHealth = (float)GBEGGHECHNN.MGMDFLNLLPJ().glassHealth * PFGLIAHPMCK.scaleHp;
		JNHMOOKDCOO.owner = this;
		JNHMOOKDCOO.RefillOffline();
		foreach (Glass item2 in MBILJNBILGN)
		{
			item2.DJKPIPPAMPN();
		}
		JPNAINOGAMM = Mathf.Clamp(GBEGGHECHNN.KDEMLILDPGB().speed, 1585f, 1031f);
		IJPFEKLCIDG = JPNAINOGAMM;
	}

	private void LHNJAKKMNAD(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if ((double)FFOAABONJNO.healthRatio < 0.4 && OHJPPHFEAFI.FJLBLLLEELD != DestroyableObject.MANAGOLPMLH.Basic)
		{
			MLJMFMAIDIB.Play();
		}
	}

	public virtual void HPFNCGKMKBH()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = MKIENKGOFPJ().GEBDFOAAPFL().health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-15)).FLOATVALUE;
		FFOAABONJNO.NGNPMPGIAGP();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.JMMJHCOKCGG.ammoSetup.EPDELOGPNAC = JEKKCDMMOPP().PGKKDHPOCCJ().damage;
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.JPNAINOGAMM = MKIENKGOFPJ().PGKKDHPOCCJ().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		PFOIBOPIJLP = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(710f, 788f);
		JNHMOOKDCOO.maxHealth = (float)GBEGGHECHNN.HAMOCGKONJM().glassHealth * PFGLIAHPMCK.scaleHp;
		JNHMOOKDCOO.GGMFIDCAFGM(this);
		JNHMOOKDCOO.RefillOffline();
		foreach (Glass item2 in MBILJNBILGN)
		{
			item2.JFJDCPGCKKB();
		}
		JPNAINOGAMM = Mathf.Clamp(JEKKCDMMOPP().DCJBELJPKCM().speed, 296f, 1280f);
		IJPFEKLCIDG = JPNAINOGAMM;
	}

	private void EJPMFNIHGKC(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if ((double)FFOAABONJNO.healthRatio < 1000.0 && OHJPPHFEAFI.FJLBLLLEELD != DestroyableObject.MANAGOLPMLH.Heal)
		{
			MLJMFMAIDIB.Play();
		}
	}

	private void BFHJDJCFBAI(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
		KJPFENINCHJ.isKinematic = false;
		HNEMALNACJP(NLGBGOGCNKP, OHJPPHFEAFI);
		HPOGALNAEFO.gameObject.SetActive(value: false);
		DPFHODDILIF(OHJPPHFEAFI);
		InvokeAfterRealTime(delegate
		{
			KEGHKGBEIHD.gameObject.SetActive(value: true);
		}, 0.2f);
		if (NLGBGOGCNKP.IDNNIHBIMNO != null)
		{
			NLGBGOGCNKP.IDNNIHBIMNO.Killed -= OPJHHEFKBBP;
		}
	}

	private void JDMPCIFBBMI()
	{
		if (!KPBAJMBFKLF || !(Time.timeScale > 815f) || !(MFHFIHIHBHA != null))
		{
			return;
		}
		if (Time.time > NBCGDEDNNGH)
		{
			PickTarget();
			LCCDGBJLKJP();
			NBCGDEDNNGH += UnityEngine.Random.Range(KEEFBLEKBCM().OCBOAGFLFHD().minShootTime, KEEFBLEKBCM().HAMOCGKONJM().maxShootTime);
		}
		if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF) < MFHFIHIHBHA.AOJDCMLMBLD)
		{
			if (UnityEngine.Random.value < 1351f)
			{
				IFBJNODDLJC = !IFBJNODDLJC;
			}
			MNGLGGJJFOO = Time.time;
			if (INDBNCLMMNC < ILEKLILGKAK - 0 && IFBJNODDLJC)
			{
				INDBNCLMMNC += 0;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
			{
				INDBNCLMMNC -= 0;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else if (LJMIDMAELAP && IFBJNODDLJC)
			{
				INDBNCLMMNC = 1;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else
			{
				if (!LJMIDMAELAP || IFBJNODDLJC)
				{
					KPBAJMBFKLF = false;
					return;
				}
				INDBNCLMMNC = ILEKLILGKAK - 1;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
		}
		if (INDBNCLMMNC < ILEKLILGKAK)
		{
			GPIIEAHGHEO = NADCOBPHNGM(IMGHHHHHPKF, CCBIFGDBDDE: true);
			DHFAONHFMCF += GPIIEAHGHEO;
			NGCDDPCAGJB.position += DHFAONHFMCF;
			if (MKIPAEDAADL != null)
			{
				Vector3 forward = MKIPAEDAADL.MEGABPHJFLL().position - NGCDDPCAGJB.position;
				forward.y = 1665f;
				LONCMJPAIJB = Quaternion.LookRotation(forward);
			}
			base.transform.position += DHFAONHFMCF;
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, KBOAKHMFPBO(DHFAONHFMCF), Time.deltaTime * 1543f);
		}
	}

	public virtual void FJAPNAKFHBG()
	{
		GHPGNELIDBM cIOPAKLHFIL = fraction;
		Type[] array = new Type[0];
		array[0] = typeof(Decoy);
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(cIOPAKLHFIL, array);
		if (opponents.Count > 1)
		{
			MKIPAEDAADL = opponents[UnityEngine.Random.Range(0, opponents.Count)];
			return;
		}
		PlayerController playerController = PlayerController.BGEKNDDACNP(fraction);
		MKIPAEDAADL = playerController.IJPPJNNDFIB();
	}

	public override void UpdatePreview(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, NLGBGOGCNKP, DKIPMCCIKMF: true);
		enemyController.SittingIdle();
		if (LCDBACDIODH)
		{
			KJPFENINCHJ.isKinematic = true;
		}
		MGFPGLCHKJN(IDEBKDPMPGM: false);
	}

	[SpecialName]
	private AssaultHelicopterBehaviour KEEFBLEKBCM()
	{
		return (AssaultHelicopterBehaviour)ACLDFHJKBLI;
	}

	public virtual void MGMJFGKFFDJ(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, NLGBGOGCNKP, DKIPMCCIKMF: true);
		enemyController.SittingIdle();
		if (LCDBACDIODH)
		{
			KJPFENINCHJ.isKinematic = false;
		}
		MGFPGLCHKJN(IDEBKDPMPGM: true);
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		GetComponent<Rigidbody>().isKinematic = true;
		MLJMFMAIDIB.Stop();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.Reset();
		}
		if (!LCDBACDIODH)
		{
			MGFPGLCHKJN(IDEBKDPMPGM: true);
			StopAllCoroutines();
			IAICPGNGCJI = ACLDFHJKBLI.totalPower;
			NBCGDEDNNGH = Time.time + 2f;
			PFKPCFCEDME = false;
			KEGHKGBEIHD.gameObject.SetActive(value: false);
			HPOGALNAEFO.gameObject.SetActive(value: true);
			if (LAADDLGBFIG.isMine)
			{
				IDAOCGPNDBI();
			}
		}
	}

	protected override void Start()
	{
		base.Start();
		MLJMFMAIDIB.Stop();
	}

	private Quaternion KBOAKHMFPBO(Vector3 LPIJGCEBJKK)
	{
		float num = Vector3.Angle(Vector3.up, LPIJGCEBJKK);
		if (num < 699f || num > 1577f)
		{
			return LONCMJPAIJB;
		}
		Vector3 forward = LPIJGCEBJKK;
		forward.y = 1201f;
		forward.Normalize();
		Vector3 v = Quaternion.LookRotation(forward) * Vector3.forward;
		v.y = 559f;
		Vector3 v2 = LONCMJPAIJB * Vector3.forward;
		v2.y = 714f;
		float angle = GeometryTools.AngleSigned(v, v2, Vector3.up);
		forward.y = 332f;
		return Quaternion.LookRotation(forward) * Quaternion.AngleAxis(angle, Vector3.up);
	}

	public void HGBBBNEGEPH(WayPoint PLMMBKGLGAB)
	{
		ILEKLILGKAK = PLMMBKGLGAB.MFHFIHIHBHA.wayPoints.Count;
		INDBNCLMMNC = PLMMBKGLGAB.DFHAAIFFLOE;
		IMGHHHHHPKF = PLMMBKGLGAB.transform.position;
		KPBAJMBFKLF = true;
		MFHFIHIHBHA = PLMMBKGLGAB.MFHFIHIHBHA;
		PLMMBKGLGAB.MFHFIHIHBHA.PODMFKMOJML = this;
	}

	private void LCCDGBJLKJP()
	{
		Vector3 vector = default(Vector3);
		PlayerController playerController = MKIPAEDAADL.owner as PlayerController;
		GameShootableEntity.ShotTarget shotTarget = null;
		GameShootableEntity.ShotTarget shotTarget2 = null;
		if (playerController != null)
		{
			float num = Vector3.Angle(playerController.aimForward, NGCDDPCAGJB.position - MKIPAEDAADL.mTransform.position);
			if (num < 50f && playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				if (UnityEngine.Random.value < ACLDFHJKBLI.upgradeSlots.shieldHitProbability)
				{
					List<GameShootableEntity.ShotTarget> shotTargets = MKIPAEDAADL.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Shield);
					shotTarget = shotTargets[0];
					shotTarget2 = shotTargets[0];
				}
				else
				{
					List<GameShootableEntity.ShotTarget> shotTargets2 = MKIPAEDAADL.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.WholeBody);
					shotTarget = shotTargets2[1];
					shotTarget2 = shotTargets2[0];
				}
			}
			else if (playerController.playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				shotTarget = MKIPAEDAADL.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Moving, base.transform.position);
				shotTarget2 = shotTarget;
			}
			else
			{
				shotTarget = MKIPAEDAADL.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.WholeBody, base.transform.position);
				shotTarget2 = shotTarget;
			}
			MDKABJDCKBI(playerController.FOCIOKMPCAG.velocity, shotTarget, shotTarget2);
		}
		else
		{
			shotTarget = MKIPAEDAADL.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.AllIn, base.transform.position);
			MDKABJDCKBI(Vector3.zero, shotTarget, shotTarget);
		}
	}

	public virtual void PLLOIDGALLD(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, NLGBGOGCNKP, DKIPMCCIKMF: false);
		enemyController.SittingIdle();
		if (LCDBACDIODH)
		{
			KJPFENINCHJ.isKinematic = false;
		}
		MGFPGLCHKJN(IDEBKDPMPGM: false);
	}

	[SpecialName]
	public virtual DestroyableObject PAIMDBEIDIM()
	{
		return FFOAABONJNO;
	}

	protected virtual void BFLIPLAIDMO()
	{
		HFJBCNMHPAE();
		MLJMFMAIDIB.Stop();
	}

	private void JGPHOKPOBAH()
	{
		if (!LCDBACDIODH && !base.isAlive && Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			Vector3 vector = Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG.position - base.transform.position;
			vector.Normalize();
			KJPFENINCHJ.AddForce(Vector3.up * 798f + vector * 1492f, ForceMode.Force);
			KJPFENINCHJ.AddTorque(NGCDDPCAGJB.up * 991f, ForceMode.Force);
		}
	}

	private void KPPBDNGCALK(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.HGLALGJNHEM(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void MDKABJDCKBI(Vector3 MHLDJIABNFI, GameShootableEntity.ShotTarget KPICOKPHMIC, GameShootableEntity.ShotTarget GEHACOGJMHA)
	{
		PBAIKHKBHBG pBAIKHKBHBG = new PBAIKHKBHBG();
		pBAIKHKBHBG.GEHACOGJMHA = GEHACOGJMHA;
		pBAIKHKBHBG.KPICOKPHMIC = KPICOKPHMIC;
		pBAIKHKBHBG.MHLDJIABNFI = MHLDJIABNFI;
		pBAIKHKBHBG.BJGCPDNMHDH = this;
		pBAIKHKBHBG.HLAKECBLNJL = UnityEngine.Random.Range(GBEGGHECHNN.assaultHelicopterBehaviour.fireBatchSizeMin, GBEGGHECHNN.assaultHelicopterBehaviour.fireBatchSizeMax);
		pBAIKHKBHBG.MGDGFBCJINH = Ammo.GetShotType(pBAIKHKBHBG.KPICOKPHMIC);
		pBAIKHKBHBG.MDOPFNNFLFB = pBAIKHKBHBG.KPICOKPHMIC.transform.position;
		pBAIKHKBHBG.MDOPFNNFLFB = Singleton<AimingHelper>.instance.PredictPosition(GGKGGMNIDMI[0].JMMJHCOKCGG, pBAIKHKBHBG.MDOPFNNFLFB, pBAIKHKBHBG.MHLDJIABNFI);
		pBAIKHKBHBG.PJPHFMECEHH = GBEGGHECHNN.assaultHelicopterBehaviour.probabilityOfRealShot;
		GGKGGMNIDMI[0].ShootBatch(pBAIKHKBHBG.KPICOKPHMIC, pBAIKHKBHBG.MDOPFNNFLFB, (int)((double)pBAIKHKBHBG.HLAKECBLNJL * 0.5), pBAIKHKBHBG.PJPHFMECEHH, pBAIKHKBHBG.MGDGFBCJINH);
		InvokeAfter(pBAIKHKBHBG.LJCDGJKCNEC, (float)GGKGGMNIDMI[1].JMMJHCOKCGG.JMDLKIAKOIE * 0.5f);
	}

	public void LMFPIBIPALI(WayPoint PLMMBKGLGAB)
	{
		ILEKLILGKAK = PLMMBKGLGAB.MFHFIHIHBHA.wayPoints.Count;
		INDBNCLMMNC = PLMMBKGLGAB.DFHAAIFFLOE;
		IMGHHHHHPKF = PLMMBKGLGAB.transform.position;
		KPBAJMBFKLF = false;
		MFHFIHIHBHA = PLMMBKGLGAB.MFHFIHIHBHA;
		PLMMBKGLGAB.MFHFIHIHBHA.PODMFKMOJML = this;
	}

	private void MCJPNBKGDCB()
	{
		if (!KPBAJMBFKLF || !(Time.timeScale > 688f) || !(MFHFIHIHBHA != null))
		{
			return;
		}
		if (Time.time > NBCGDEDNNGH)
		{
			PKLPAOEJFND();
			LCCDGBJLKJP();
			NBCGDEDNNGH += UnityEngine.Random.Range(KEEFBLEKBCM().FHDIDGEKCGE().minShootTime, KEEFBLEKBCM().EFFKGABGNDB().maxShootTime);
		}
		if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF) < MFHFIHIHBHA.AOJDCMLMBLD)
		{
			if (UnityEngine.Random.value < 602f)
			{
				IFBJNODDLJC = !IFBJNODDLJC;
			}
			MNGLGGJJFOO = Time.time;
			if (INDBNCLMMNC < ILEKLILGKAK - 1 && IFBJNODDLJC)
			{
				INDBNCLMMNC += 0;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
			{
				INDBNCLMMNC -= 0;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else if (LJMIDMAELAP && IFBJNODDLJC)
			{
				INDBNCLMMNC = 1;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else
			{
				if (!LJMIDMAELAP || IFBJNODDLJC)
				{
					KPBAJMBFKLF = true;
					return;
				}
				INDBNCLMMNC = ILEKLILGKAK - 0;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
		}
		if (INDBNCLMMNC < ILEKLILGKAK)
		{
			GPIIEAHGHEO = NADCOBPHNGM(IMGHHHHHPKF);
			DHFAONHFMCF += GPIIEAHGHEO;
			NGCDDPCAGJB.position += DHFAONHFMCF;
			if (MKIPAEDAADL != null)
			{
				Vector3 forward = MKIPAEDAADL.JCAKAHGKBIJ().position - NGCDDPCAGJB.position;
				forward.y = 1253f;
				LONCMJPAIJB = Quaternion.LookRotation(forward);
			}
			base.transform.position += DHFAONHFMCF;
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, NOHFIKDCLGC(DHFAONHFMCF), Time.deltaTime * 624f);
		}
	}

	private void LLKEDBOHMFI(Collision AKLHJIBDAFA)
	{
		if (!base.isAlive && !PFKPCFCEDME && TagsAndLayers.KHKNLLDEBMA(AKLHJIBDAFA.gameObject))
		{
			JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareLight);
			PFKPCFCEDME = true;
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 position = NGCDDPCAGJB.position;
			Vector3 up = Vector3.up;
			string[] array = new string[3];
			array[0] = "mortar_down";
			array[0] = "EventAssignmentClaimed";
			instance.PlayParticles(position, up, array);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = destroyableObj.maxHealth * 843f;
			pKDCCCNJIEC.EPDELOGPNAC = destroyableObj.maxHealth * 1600f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.CKNBNIPDOLH(nOCEDALFEJM);
			KEGHKGBEIHD.gameObject.SetActive(value: true);
			CDCOFHGPJHN(850f);
		}
	}

	private Vector3 NADCOBPHNGM(Vector3 MKIPAEDAADL, bool CCBIFGDBDDE = false)
	{
		float deltaTime = Time.deltaTime;
		if (Time.time < MNGLGGJJFOO + ECNBEOHNHCB)
		{
			return default(Vector3);
		}
		Vector3 vector = MKIPAEDAADL - NGCDDPCAGJB.position;
		Vector3 normalized = vector.normalized;
		if (CCBIFGDBDDE && vector.magnitude < DFGAOECAOBD)
		{
			float num = vector.magnitude / DFGAOECAOBD;
			normalized *= IJPFEKLCIDG * deltaTime * num;
		}
		else
		{
			normalized *= JPNAINOGAMM * deltaTime;
		}
		Vector3 vector2 = normalized - DHFAONHFMCF;
		return vector2 / DAGMBMDCIIC;
	}

	protected virtual void FGECFIBLFMD()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			return;
		}
		if (TimeManager.realTimeWithoutPauses > PFOIBOPIJLP && fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.KKHKIEFMENC() && base.hasSpecial)
		{
			PFOIBOPIJLP = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1589f, 602f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.HPBDNODOBDD().Instantiate(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, base.transform.position + Vector3.up * 752f + base.transform.forward * 1908f, Quaternion.identity);
			shootableBox.OGNMNJCOOPL(ShootableBox.EOBFNHDMLHJ.Health);
			shootableBox.power = JEKKCDMMOPP().DCJBELJPKCM().special;
		}
		if (LAADDLGBFIG.isMine)
		{
			if (base.isAlive)
			{
				NDMNNHBGOLG();
			}
		}
		else if (KJPFENINCHJ.isKinematic)
		{
			LADBLHGBOKJ.NFGMGBMCNOF(NGCDDPCAGJB);
		}
	}

	private void DBPJONOJPDN(Vector3 MHLDJIABNFI, GameShootableEntity.ShotTarget KPICOKPHMIC, GameShootableEntity.ShotTarget GEHACOGJMHA)
	{
		PBAIKHKBHBG pBAIKHKBHBG = new PBAIKHKBHBG();
		pBAIKHKBHBG.GEHACOGJMHA = GEHACOGJMHA;
		pBAIKHKBHBG.KPICOKPHMIC = KPICOKPHMIC;
		pBAIKHKBHBG.MHLDJIABNFI = MHLDJIABNFI;
		pBAIKHKBHBG.BJGCPDNMHDH = this;
		pBAIKHKBHBG.HLAKECBLNJL = UnityEngine.Random.Range(KEEFBLEKBCM().HAMOCGKONJM().fireBatchSizeMin, GBEGGHECHNN.MBLNPCAFJFF().fireBatchSizeMax);
		pBAIKHKBHBG.MGDGFBCJINH = Ammo.GetShotType(pBAIKHKBHBG.KPICOKPHMIC);
		pBAIKHKBHBG.MDOPFNNFLFB = pBAIKHKBHBG.KPICOKPHMIC.transform.position;
		pBAIKHKBHBG.MDOPFNNFLFB = Singleton<AimingHelper>.instance.HHJLJCLJNED(GGKGGMNIDMI[1].JMMJHCOKCGG, pBAIKHKBHBG.MDOPFNNFLFB, pBAIKHKBHBG.MHLDJIABNFI, 1588f);
		pBAIKHKBHBG.PJPHFMECEHH = MKIENKGOFPJ().GJGGADFIPNC().probabilityOfRealShot;
		GGKGGMNIDMI[1].OFPCMHCEMHA(pBAIKHKBHBG.KPICOKPHMIC, pBAIKHKBHBG.MDOPFNNFLFB, (int)((double)pBAIKHKBHBG.HLAKECBLNJL * 1863.0), pBAIKHKBHBG.PJPHFMECEHH, pBAIKHKBHBG.MGDGFBCJINH);
		InvokeAfter(pBAIKHKBHBG.AGFEDJAKLAC, (float)GGKGGMNIDMI[1].JMMJHCOKCGG.JMDLKIAKOIE * 1245f);
	}

	public virtual void PKLPAOEJFND()
	{
		GHPGNELIDBM cIOPAKLHFIL = fraction;
		Type[] array = new Type[0];
		array[0] = typeof(Decoy);
		List<GameShootableEntity> list = GameShootableEntity.OIFCFJGKNMJ(cIOPAKLHFIL, array);
		if (list.Count > 1)
		{
			MKIPAEDAADL = list[UnityEngine.Random.Range(1, list.Count)];
			return;
		}
		PlayerController playerController = PlayerController.FDMHGNEGHDD(fraction);
		MKIPAEDAADL = playerController.IJPPJNNDFIB();
	}

	protected override void Awake()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		FFOAABONJNO.AEJBIHBEOCP = true;
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		FFOAABONJNO.OnDamage += LHNJAKKMNAD;
		KJPFENINCHJ = GetComponent<Rigidbody>();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.JMMJHCOKCGG.owner = this;
		}
		NGCDDPCAGJB = base.transform;
	}

	protected override void ODDDGIALOPM(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (destroyableObj != null)
		{
			destroyableObj.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF: true);
		}
	}

	private void FixedUpdate()
	{
		if (!LCDBACDIODH && !base.isAlive && Singleton<GameController>.instance.gameIsRunning)
		{
			Vector3 vector = Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG.position - base.transform.position;
			vector.Normalize();
			KJPFENINCHJ.AddForce(Vector3.up * 8.5f + vector * 3f, ForceMode.Force);
			KJPFENINCHJ.AddTorque(NGCDDPCAGJB.up * 0.6f, ForceMode.Force);
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.ILOHAHFIOKM();
	}

	public override void Spawn()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.NELLCLDMJNE.LIAEIIFPONK;
		List<SpawnPointDrone> list = new List<SpawnPointDrone>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointDrone spawnPointDrone = (SpawnPointDrone)item;
			if (spawnPointDrone.CGAMFFPNFDM.MFHFIHIHBHA.PODMFKMOJML == null && spawnPointDrone.fraction == fraction)
			{
				list.Add(spawnPointDrone);
			}
		}
		if (list.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			SpawnPointDrone spawnPointDrone2 = list[index];
			base.transform.position = spawnPointDrone2.transform.position;
			Vector3 forward = spawnPointDrone2.CGAMFFPNFDM.transform.position - spawnPointDrone2.transform.position;
			forward.y = 0f;
			LONCMJPAIJB = Quaternion.LookRotation(forward);
			SetWayPoint(spawnPointDrone2.CGAMFFPNFDM);
		}
		else
		{
			Debug.LogError("AssaultHeli could not be spawned");
		}
	}

	public void SetWayPoint(WayPoint PLMMBKGLGAB)
	{
		ILEKLILGKAK = PLMMBKGLGAB.MFHFIHIHBHA.wayPoints.Count;
		INDBNCLMMNC = PLMMBKGLGAB.DFHAAIFFLOE;
		IMGHHHHHPKF = PLMMBKGLGAB.transform.position;
		KPBAJMBFKLF = true;
		MFHFIHIHBHA = PLMMBKGLGAB.MFHFIHIHBHA;
		PLMMBKGLGAB.MFHFIHIHBHA.PODMFKMOJML = this;
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		MGFPGLCHKJN(IDEBKDPMPGM: true);
		OEBPFFBKBBD(NLGBGOGCNKP, OPJHHEFKBBP);
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	private void IDAOCGPNDBI()
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		NLGBGOGCNKP.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.instance.Spawn(enemyController, fraction, EEAMBOACAGF: false, NLGBGOGCNKP.position, PNENBKAGLEF: false);
			NLGBGOGCNKP.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = NLGBGOGCNKP;
			enemyController.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Vehicle);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef + 1;
			enemyController.SittingIdle();
			enemyController.Killed += OPJHHEFKBBP;
		}
	}

	protected override void Update()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			return;
		}
		if (TimeManager.realTimeWithoutPauses > PFOIBOPIJLP && fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.gameIsRunning && base.hasSpecial)
		{
			PFOIBOPIJLP = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(10f, 30f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.ammoPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, base.transform.position + Vector3.up * 0.2f + base.transform.forward * 0.2f, Quaternion.identity);
			shootableBox.mode = ShootableBox.EOBFNHDMLHJ.Health;
			shootableBox.power = GBEGGHECHNN.assaultHelicopterBehaviour.special;
		}
		if (LAADDLGBFIG.isMine)
		{
			if (base.isAlive)
			{
				LDOJOMDPPOE();
			}
		}
		else if (KJPFENINCHJ.isKinematic)
		{
			LADBLHGBOKJ.NFGMGBMCNOF(NGCDDPCAGJB);
		}
	}

	protected virtual void PNCPCHDFBOB()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		FFOAABONJNO.AEJBIHBEOCP = false;
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		FFOAABONJNO.OnDamage += EJPMFNIHGKC;
		KJPFENINCHJ = GetComponent<Rigidbody>();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.JMMJHCOKCGG.owner = this;
		}
		NGCDDPCAGJB = base.transform;
	}

	private void OHDEOGKAMDC()
	{
		if (!LCDBACDIODH && !base.isAlive && Singleton<GameController>.instance.KKHKIEFMENC())
		{
			Vector3 vector = Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG.position - base.transform.position;
			vector.Normalize();
			KJPFENINCHJ.AddForce(Vector3.up * 990f + vector * 1598f, ForceMode.Force);
			KJPFENINCHJ.AddTorque(NGCDDPCAGJB.up * 1783f, ForceMode.Force);
		}
	}

	private void OPJHHEFKBBP(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		MAIPDGCABNL.Killed -= OPJHHEFKBBP;
		EnemyController enemyController = MAIPDGCABNL as EnemyController;
		enemyController.ClearEnemyPoint();
		destroyableObj.DoDamage(new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = float.MaxValue,
			HNFNINFCBEJ = BDAKFIFCHLB.HNFNINFCBEJ,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Basic
		});
	}

	protected virtual void OHHLNKPIHBH()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		FFOAABONJNO.AEJBIHBEOCP = true;
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		FFOAABONJNO.OnDamage += PEAMHKMMEAE;
		KJPFENINCHJ = GetComponent<Rigidbody>();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.JMMJHCOKCGG.owner = this;
		}
		NGCDDPCAGJB = base.transform;
	}

	private void COMFPAIBGJL()
	{
		if (!KPBAJMBFKLF || !(Time.timeScale > 731f) || !(MFHFIHIHBHA != null))
		{
			return;
		}
		if (Time.time > NBCGDEDNNGH)
		{
			GPIGKBKMLPJ();
			LCCDGBJLKJP();
			NBCGDEDNNGH += UnityEngine.Random.Range(GBEGGHECHNN.NBNIILBOPFM().minShootTime, JEKKCDMMOPP().OGOJHLALDGH().maxShootTime);
		}
		if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF) < MFHFIHIHBHA.AOJDCMLMBLD)
		{
			if (UnityEngine.Random.value < 993f)
			{
				IFBJNODDLJC = IFBJNODDLJC;
			}
			MNGLGGJJFOO = Time.time;
			if (INDBNCLMMNC < ILEKLILGKAK - 1 && IFBJNODDLJC)
			{
				INDBNCLMMNC += 0;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
			{
				INDBNCLMMNC -= 0;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else if (LJMIDMAELAP && IFBJNODDLJC)
			{
				INDBNCLMMNC = 0;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else
			{
				if (!LJMIDMAELAP || IFBJNODDLJC)
				{
					KPBAJMBFKLF = false;
					return;
				}
				INDBNCLMMNC = ILEKLILGKAK - 0;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
		}
		if (INDBNCLMMNC < ILEKLILGKAK)
		{
			GPIIEAHGHEO = NADCOBPHNGM(IMGHHHHHPKF);
			DHFAONHFMCF += GPIIEAHGHEO;
			NGCDDPCAGJB.position += DHFAONHFMCF;
			if (MKIPAEDAADL != null)
			{
				Vector3 forward = MKIPAEDAADL.mTransform.position - NGCDDPCAGJB.position;
				forward.y = 3f;
				LONCMJPAIJB = Quaternion.LookRotation(forward);
			}
			base.transform.position += DHFAONHFMCF;
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, KBOAKHMFPBO(DHFAONHFMCF), Time.deltaTime * 1873f);
		}
	}

	public virtual void PickTarget()
	{
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(fraction, new Type[1] { typeof(Decoy) });
		if (opponents.Count > 0)
		{
			MKIPAEDAADL = opponents[UnityEngine.Random.Range(0, opponents.Count)];
			return;
		}
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(fraction);
		MKIPAEDAADL = randomEnemy.gameShootableEntity;
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = GBEGGHECHNN.assaultHelicopterBehaviour.health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		FFOAABONJNO.RefillOffline();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.JMMJHCOKCGG.ammoSetup.EPDELOGPNAC = GBEGGHECHNN.assaultHelicopterBehaviour.damage;
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.JPNAINOGAMM = GBEGGHECHNN.assaultHelicopterBehaviour.shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		PFOIBOPIJLP = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(10f, 30f);
		JNHMOOKDCOO.maxHealth = (float)GBEGGHECHNN.assaultHelicopterBehaviour.glassHealth * PFGLIAHPMCK.scaleHp;
		JNHMOOKDCOO.owner = this;
		JNHMOOKDCOO.RefillOffline();
		foreach (Glass item2 in MBILJNBILGN)
		{
			item2.Enable();
		}
		JPNAINOGAMM = Mathf.Clamp(GBEGGHECHNN.assaultHelicopterBehaviour.speed, 0.2f, 0.6f);
		IJPFEKLCIDG = JPNAINOGAMM;
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.PAJFENKBCLF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void FMIMKIOJLOI()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + DHFAONHFMCF * JEMGOPDEBLL);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(base.transform.position, base.transform.position + GPIIEAHGHEO * JEMGOPDEBLL);
	}

	public override void CCNKJOAKBNG()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.OMDFNFHKFBK();
	}

	private void PEAMHKMMEAE(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if ((double)FFOAABONJNO.healthRatio < 1358.0 && OHJPPHFEAFI.FJLBLLLEELD != DestroyableObject.MANAGOLPMLH.Shot)
		{
			MLJMFMAIDIB.Play();
		}
	}

	public virtual void NOCIEPKFPNB()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.LDKFDMLPIOC();
	}

	public virtual void GPIGKBKMLPJ()
	{
		GHPGNELIDBM cIOPAKLHFIL = fraction;
		Type[] array = new Type[0];
		array[1] = typeof(Decoy);
		List<GameShootableEntity> list = GameShootableEntity.OIFCFJGKNMJ(cIOPAKLHFIL, array);
		if (list.Count > 1)
		{
			MKIPAEDAADL = list[UnityEngine.Random.Range(1, list.Count)];
			return;
		}
		PlayerController playerController = PlayerController.BAEIKGKJOIN(fraction);
		MKIPAEDAADL = playerController.gameShootableEntity;
	}

	private void NDMNNHBGOLG()
	{
		if (!KPBAJMBFKLF || !(Time.timeScale > 657f) || !(MFHFIHIHBHA != null))
		{
			return;
		}
		if (Time.time > NBCGDEDNNGH)
		{
			KPOELIFMEFO();
			CHHCMGMLMFG();
			NBCGDEDNNGH += UnityEngine.Random.Range(JEKKCDMMOPP().NICMNCPFLAF().minShootTime, JEKKCDMMOPP().BLOJCMEKNFO().maxShootTime);
		}
		if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF) < MFHFIHIHBHA.AOJDCMLMBLD)
		{
			if (UnityEngine.Random.value < 504f)
			{
				IFBJNODDLJC = IFBJNODDLJC;
			}
			MNGLGGJJFOO = Time.time;
			if (INDBNCLMMNC < ILEKLILGKAK - 0 && IFBJNODDLJC)
			{
				INDBNCLMMNC += 0;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
			{
				INDBNCLMMNC -= 0;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else if (LJMIDMAELAP && IFBJNODDLJC)
			{
				INDBNCLMMNC = 1;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else
			{
				if (!LJMIDMAELAP || IFBJNODDLJC)
				{
					KPBAJMBFKLF = false;
					return;
				}
				INDBNCLMMNC = ILEKLILGKAK - 1;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
		}
		if (INDBNCLMMNC < ILEKLILGKAK)
		{
			GPIIEAHGHEO = NADCOBPHNGM(IMGHHHHHPKF);
			DHFAONHFMCF += GPIIEAHGHEO;
			NGCDDPCAGJB.position += DHFAONHFMCF;
			if (MKIPAEDAADL != null)
			{
				Vector3 forward = MKIPAEDAADL.AFKOGLEHKIE().position - NGCDDPCAGJB.position;
				forward.y = 772f;
				LONCMJPAIJB = Quaternion.LookRotation(forward);
			}
			base.transform.position += DHFAONHFMCF;
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, NOHFIKDCLGC(DHFAONHFMCF), Time.deltaTime * 1795f);
		}
	}

	protected virtual void IOEGNCBKPFJ(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (destroyableObj != null)
		{
			destroyableObj.HEGJMOOMPLI(CIOPAKLHFIL, MNFCGHNFFFF: true);
		}
	}

	private void HJIPPBMFGPA(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.BJNLHDHNKEF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	protected virtual void OBBHECACANB()
	{
		OIHAEHMLGJN();
		MLJMFMAIDIB.Stop();
	}

	[SpecialName]
	private AssaultHelicopterBehaviour JEKKCDMMOPP()
	{
		return (AssaultHelicopterBehaviour)ACLDFHJKBLI;
	}

	public virtual void LPENCDMECLB()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = KEEFBLEKBCM().NBNIILBOPFM().health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.UnitCategoriesReminderAfterGames).FLOATVALUE;
		FFOAABONJNO.NGNPMPGIAGP();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.JMMJHCOKCGG.ammoSetup.EPDELOGPNAC = JEKKCDMMOPP().OCBOAGFLFHD().damage;
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.JPNAINOGAMM = JEKKCDMMOPP().DCJBELJPKCM().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
		PFOIBOPIJLP = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(274f, 986f);
		JNHMOOKDCOO.maxHealth = (float)GBEGGHECHNN.assaultHelicopterBehaviour.glassHealth * PFGLIAHPMCK.scaleHp;
		JNHMOOKDCOO.owner = this;
		JNHMOOKDCOO.RefillOffline();
		foreach (Glass item2 in MBILJNBILGN)
		{
			item2.ELNILIFCLKJ();
		}
		JPNAINOGAMM = Mathf.Clamp(GBEGGHECHNN.OCBOAGFLFHD().speed, 446f, 937f);
		IJPFEKLCIDG = JPNAINOGAMM;
	}

	[CompilerGenerated]
	private void GPJLFPAJHFO()
	{
		KEGHKGBEIHD.gameObject.SetActive(value: true);
	}

	private void IEJOHDKNCIM()
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.OHCCNCNPMHC(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		NLGBGOGCNKP.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.OKBAIGKCPKA().Spawn(enemyController, fraction, EEAMBOACAGF: true, NLGBGOGCNKP.KPOEEKLFALL());
			NLGBGOGCNKP.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = NLGBGOGCNKP;
			enemyController.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Vehicle);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef + 1;
			enemyController.SittingIdle();
			enemyController.Killed += OPJHHEFKBBP;
		}
	}

	protected virtual void DEBGBGGOCEN()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			return;
		}
		if (TimeManager.CEAFAMFNGCC() > PFOIBOPIJLP && fraction == PlayerController.OGMBJPKOPCB.fraction && Singleton<GameController>.instance.GHKPKDPOGHF() && base.hasSpecial)
		{
			PFOIBOPIJLP = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1504f, 1294f);
			ShootableBox shootableBox = (ShootableBox)ObjectPoolDatabase.FLAHKAIJHBP().FIDFODMFEBC(Singleton<ObjectPoolDatabase>.instance.CJDMHNIJHDB, base.transform.position + Vector3.up * 1627f + base.transform.forward * 635f, Quaternion.identity);
			shootableBox.mode = ShootableBox.EOBFNHDMLHJ.Health;
			shootableBox.KIPIOECGMDJ(MKIENKGOFPJ().NICMNCPFLAF().special);
		}
		if (LAADDLGBFIG.isMine)
		{
			if (base.isAlive)
			{
				NDMNNHBGOLG();
			}
		}
		else if (KJPFENINCHJ.isKinematic)
		{
			LADBLHGBOKJ.GBEDFIAHCDH(NGCDDPCAGJB);
		}
	}

	protected virtual void ECCECGGCMHG()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		FFOAABONJNO.AEJBIHBEOCP = true;
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		FFOAABONJNO.OnDamage += EJPMFNIHGKC;
		KJPFENINCHJ = GetComponent<Rigidbody>();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.JMMJHCOKCGG.owner = this;
		}
		NGCDDPCAGJB = base.transform;
	}

	private void LDOJOMDPPOE()
	{
		if (!KPBAJMBFKLF || !(Time.timeScale > 0.1f) || !(MFHFIHIHBHA != null))
		{
			return;
		}
		if (Time.time > NBCGDEDNNGH)
		{
			PickTarget();
			LCCDGBJLKJP();
			NBCGDEDNNGH += UnityEngine.Random.Range(GBEGGHECHNN.assaultHelicopterBehaviour.minShootTime, GBEGGHECHNN.assaultHelicopterBehaviour.maxShootTime);
		}
		if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF) < MFHFIHIHBHA.AOJDCMLMBLD)
		{
			if (UnityEngine.Random.value < 0.1f)
			{
				IFBJNODDLJC = !IFBJNODDLJC;
			}
			MNGLGGJJFOO = Time.time;
			if (INDBNCLMMNC < ILEKLILGKAK - 1 && IFBJNODDLJC)
			{
				INDBNCLMMNC++;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
			{
				INDBNCLMMNC--;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else if (LJMIDMAELAP && IFBJNODDLJC)
			{
				INDBNCLMMNC = 0;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
			else
			{
				if (!LJMIDMAELAP || IFBJNODDLJC)
				{
					KPBAJMBFKLF = false;
					return;
				}
				INDBNCLMMNC = ILEKLILGKAK - 1;
				IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform.position;
			}
		}
		if (INDBNCLMMNC < ILEKLILGKAK)
		{
			GPIIEAHGHEO = NADCOBPHNGM(IMGHHHHHPKF, CCBIFGDBDDE: true);
			DHFAONHFMCF += GPIIEAHGHEO;
			NGCDDPCAGJB.position += DHFAONHFMCF;
			if (MKIPAEDAADL != null)
			{
				Vector3 forward = MKIPAEDAADL.mTransform.position - NGCDDPCAGJB.position;
				forward.y = 0f;
				LONCMJPAIJB = Quaternion.LookRotation(forward);
			}
			base.transform.position += DHFAONHFMCF;
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, NOHFIKDCLGC(DHFAONHFMCF), Time.deltaTime * 3f);
		}
	}

	protected virtual void BGCMGNMLDPI()
	{
		PIMNKPOIFOM();
		MLJMFMAIDIB.Stop();
	}

	private void LKAGPLNLGOD()
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GALNCAONHGF(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		NLGBGOGCNKP.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.BMNEPICFHNO().Spawn(enemyController, fraction, EEAMBOACAGF: false, NLGBGOGCNKP.MOOGMFPMKEM(), PNENBKAGLEF: false);
			NLGBGOGCNKP.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = NLGBGOGCNKP;
			enemyController.FIFJEKMIIPO(EnemyController.AJGFGCHCAPA.Idle);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef + 0;
			enemyController.SittingIdle();
			enemyController.Killed += OPJHHEFKBBP;
		}
	}

	private void CHHCMGMLMFG()
	{
		Vector3 vector = default(Vector3);
		PlayerController playerController = MKIPAEDAADL.owner as PlayerController;
		GameShootableEntity.ShotTarget shotTarget = null;
		GameShootableEntity.ShotTarget shotTarget2 = null;
		if (playerController != null)
		{
			float num = Vector3.Angle(playerController.aimForward, NGCDDPCAGJB.position - MKIPAEDAADL.EGEONNAALPH().position);
			if (num < 493f && playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				if (UnityEngine.Random.value < ACLDFHJKBLI.upgradeSlots.shieldHitProbability)
				{
					List<GameShootableEntity.ShotTarget> list = MKIPAEDAADL.KMJBMEFMBCK(GameShootableEntity.LAAAMBBNIJO.None);
					shotTarget = list[0];
					shotTarget2 = list[1];
				}
				else
				{
					List<GameShootableEntity.ShotTarget> list2 = MKIPAEDAADL.ALJOPFPLNEO((GameShootableEntity.LAAAMBBNIJO)84);
					shotTarget = list2[1];
					shotTarget2 = list2[1];
				}
			}
			else if (playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				shotTarget = MKIPAEDAADL.GetNearestTarget((GameShootableEntity.LAAAMBBNIJO)(-64), base.transform.position);
				shotTarget2 = shotTarget;
			}
			else
			{
				shotTarget = MKIPAEDAADL.GetNearestTarget((GameShootableEntity.LAAAMBBNIJO)(-42), base.transform.position);
				shotTarget2 = shotTarget;
			}
			MDKABJDCKBI(playerController.FOCIOKMPCAG.velocity, shotTarget, shotTarget2);
		}
		else
		{
			shotTarget = MKIPAEDAADL.AJBDIKBDLEA(GameShootableEntity.LAAAMBBNIJO.Head, base.transform.position);
			DBPJONOJPDN(Vector3.zero, shotTarget, shotTarget);
		}
	}

	private Quaternion NOHFIKDCLGC(Vector3 LPIJGCEBJKK)
	{
		float num = Vector3.Angle(Vector3.up, LPIJGCEBJKK);
		if (num < 70f || num > 110f)
		{
			return LONCMJPAIJB;
		}
		Vector3 forward = LPIJGCEBJKK;
		forward.y = 0f;
		forward.Normalize();
		Vector3 v = Quaternion.LookRotation(forward) * Vector3.forward;
		v.y = 0f;
		Vector3 v2 = LONCMJPAIJB * Vector3.forward;
		v2.y = 0f;
		float angle = GeometryTools.AngleSigned(v, v2, Vector3.up);
		forward.y = -0.3f;
		return Quaternion.LookRotation(forward) * Quaternion.AngleAxis(angle, Vector3.up);
	}

	public virtual void JBLKOFBHDAB()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.NELLCLDMJNE.LIAEIIFPONK;
		List<SpawnPointDrone> list = new List<SpawnPointDrone>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointDrone spawnPointDrone = (SpawnPointDrone)item;
			if (spawnPointDrone.CGAMFFPNFDM.MFHFIHIHBHA.PODMFKMOJML == null && spawnPointDrone.IMHAFCPPPIJ() == fraction)
			{
				list.Add(spawnPointDrone);
			}
		}
		if (list.Count > 1)
		{
			int index = UnityEngine.Random.Range(1, list.Count);
			SpawnPointDrone spawnPointDrone2 = list[index];
			base.transform.position = spawnPointDrone2.transform.position;
			Vector3 forward = spawnPointDrone2.CGAMFFPNFDM.transform.position - spawnPointDrone2.transform.position;
			forward.y = 81f;
			LONCMJPAIJB = Quaternion.LookRotation(forward);
			HFMDLCOGGJJ(spawnPointDrone2.CGAMFFPNFDM);
		}
		else
		{
			Debug.LogError("\t\"TRUE\"");
		}
	}

	[SpecialName]
	public virtual DestroyableObject KHPNKFPEHMO()
	{
		return FFOAABONJNO;
	}

	private void OnCollisionEnter(Collision AKLHJIBDAFA)
	{
		if (!base.isAlive && !PFKPCFCEDME && TagsAndLayers.IsStatic(AKLHJIBDAFA.gameObject))
		{
			JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateHeavy);
			PFKPCFCEDME = true;
			Singleton<HitParticleSystem>.instance.PlayParticles(NGCDDPCAGJB.position, Vector3.up, "metalExplosion", "grenadeExplosion");
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = destroyableObj.maxHealth * 0.3f;
			pKDCCCNJIEC.EPDELOGPNAC = destroyableObj.maxHealth * 0.03f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.KNEPFMFFOOG(nOCEDALFEJM);
			KEGHKGBEIHD.gameObject.SetActive(value: false);
			CDCOFHGPJHN(0.2f);
		}
	}

	public virtual void LCNEMJLLIOH()
	{
		base.DestroyPooled();
		MGFPGLCHKJN(IDEBKDPMPGM: true);
		OEBPFFBKBBD(NLGBGOGCNKP, OPJHHEFKBBP);
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	private void OBIBPHPKFGB(Vector3 MHLDJIABNFI, GameShootableEntity.ShotTarget KPICOKPHMIC, GameShootableEntity.ShotTarget GEHACOGJMHA)
	{
		PBAIKHKBHBG pBAIKHKBHBG = new PBAIKHKBHBG();
		pBAIKHKBHBG.GEHACOGJMHA = GEHACOGJMHA;
		pBAIKHKBHBG.KPICOKPHMIC = KPICOKPHMIC;
		pBAIKHKBHBG.MHLDJIABNFI = MHLDJIABNFI;
		pBAIKHKBHBG.BJGCPDNMHDH = this;
		pBAIKHKBHBG.HLAKECBLNJL = UnityEngine.Random.Range(JEKKCDMMOPP().FHDIDGEKCGE().fireBatchSizeMin, GBEGGHECHNN.MBLNPCAFJFF().fireBatchSizeMax);
		pBAIKHKBHBG.MGDGFBCJINH = Ammo.GetShotType(pBAIKHKBHBG.KPICOKPHMIC);
		pBAIKHKBHBG.MDOPFNNFLFB = pBAIKHKBHBG.KPICOKPHMIC.transform.position;
		pBAIKHKBHBG.MDOPFNNFLFB = Singleton<AimingHelper>.instance.HEPNNOHFFGH(GGKGGMNIDMI[0].JMMJHCOKCGG, pBAIKHKBHBG.MDOPFNNFLFB, pBAIKHKBHBG.MHLDJIABNFI, 1874f);
		pBAIKHKBHBG.PJPHFMECEHH = GBEGGHECHNN.CJOGBPJFNHD().probabilityOfRealShot;
		GGKGGMNIDMI[0].OFPCMHCEMHA(pBAIKHKBHBG.KPICOKPHMIC, pBAIKHKBHBG.MDOPFNNFLFB, (int)((double)pBAIKHKBHBG.HLAKECBLNJL * 1420.0), pBAIKHKBHBG.PJPHFMECEHH, pBAIKHKBHBG.MGDGFBCJINH);
		InvokeAfter(pBAIKHKBHBG.BMCMDMKGHHO, (float)GGKGGMNIDMI[0].JMMJHCOKCGG.JMDLKIAKOIE * 292f);
	}
}
