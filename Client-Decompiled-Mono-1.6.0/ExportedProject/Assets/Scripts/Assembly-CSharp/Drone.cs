using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Drone : MechanicalUnit<DroneBehaviour>, BFOAAICAEMN
{
	public GameObject ABAADEOHHGC;

	public ParticleSystem MLJMFMAIDIB;

	public GameObject ALDCLEGMADK;

	public Material CJAGKIAIOOM;

	public Material FGKPAMLMMJJ;

	public BatchedWeapon JMMJHCOKCGG;

	private DestroyableObject FFOAABONJNO;

	private DroneSteering ILFPJEGPJJE;

	private bool PFKPCFCEDME;

	private Transform NGCDDPCAGJB;

	private GameShootableEntity MKIPAEDAADL;

	private float NBCGDEDNNGH;

	private float DFJIPNGPLON;

	private bool CAAOOEEDKBK;

	private float FJHNPLMBFAL;

	public override DestroyableObject destroyableObj
	{
		get
		{
			return FFOAABONJNO;
		}
	}

	protected Ammo.ILIOELBBLDM EGMCAGJJCAN(GameShootableEntity.ShotTarget MKIPAEDAADL)
	{
		if (MKIPAEDAADL.type == (GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out))
		{
			return (Ammo.ILIOELBBLDM)7;
		}
		return Ammo.ILIOELBBLDM.Fake;
	}

	public virtual void LLBKJDLGGBK()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.PNKKAIDEMEE().health;
		FFOAABONJNO.NGNPMPGIAGP();
		BulletSetup bulletSetup = (BulletSetup)JMMJHCOKCGG.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.LOFFMIEHPBI().damage;
		bulletSetup.JPNAINOGAMM = base.currentBeh.JOLBLHLMACM().shotSpeed;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		ILFPJEGPJJE.JPNAINOGAMM = base.currentBeh.COBLDHGLCKC().speed;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		ILFPJEGPJJE.Init();
		MLJMFMAIDIB.Stop();
		base.isAlive = true;
		ABAADEOHHGC.SetActive(base.spawnedByCard);
		ALDCLEGMADK.SetActive(!base.spawnedByCard);
		StopAllCoroutines();
		IAICPGNGCJI = ACLDFHJKBLI.totalPower;
		NBCGDEDNNGH = Time.time + 2f;
		PFKPCFCEDME = false;
		FJHNPLMBFAL = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(5f, 10f);
		SetTransparent(false);
	}

	public void CJNANILGDKI()
	{
		TweenPosition.Begin(base.gameObject, 419f, base.gameObject.transform.position - base.gameObject.transform.right * 716f + Vector3.up);
	}

	private void LOOFCCCHFJB(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if ((double)FFOAABONJNO.healthRatio < 1591.0)
		{
			MLJMFMAIDIB.Play();
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		ILFPJEGPJJE.Clear();
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	protected void AJOMLBHIFNI(bool LEJMFMGKEBA)
	{
		if (LAADDLGBFIG.isMine)
		{
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[0];
			array[0] = LEJMFMGKEBA;
			lAADDLGBFIG.RPC("AFTER CreateFromDatabase", PhotonTargets.All, array);
		}
		CAAOOEEDKBK = LEJMFMGKEBA;
		if (LEJMFMGKEBA)
		{
			CMBKCHADJPD.JLDMJDBIEJA(FGKPAMLMMJJ);
		}
		else
		{
			CMBKCHADJPD.FOHCFHAALNB(CJAGKIAIOOM);
		}
	}

	private void OnCollisionEnter(Collision AKLHJIBDAFA)
	{
		if (!base.isAlive && !PFKPCFCEDME)
		{
			JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateHeavy);
			PFKPCFCEDME = true;
			CDCOFHGPJHN(0.2f);
			Debug.Log("Drone explode");
			Singleton<HitParticleSystem>.instance.PlayParticles(NGCDDPCAGJB.position, Vector3.up, "metalExplosion", "grenadeExplosion");
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = destroyableObj.maxHealth * 0.5f;
			pKDCCCNJIEC.EPDELOGPNAC = destroyableObj.maxHealth * 0.05f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			pKDCCCNJIEC.INIBDNGHLPN = 0.7f;
			pKDCCCNJIEC.LIEABAMBOMG = 1.4f;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.KNEPFMFFOOG(nOCEDALFEJM);
		}
	}

	public virtual void MGGEGBMKEHB()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.NOKEEDNGHJC.LIAEIIFPONK;
		List<SpawnPointDrone> list = new List<SpawnPointDrone>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointDrone spawnPointDrone = (SpawnPointDrone)item;
			if (spawnPointDrone.CGAMFFPNFDM.MFHFIHIHBHA.PODMFKMOJML == null && spawnPointDrone.ABMCHNDOMGG() == fraction)
			{
				list.Add(spawnPointDrone);
			}
		}
		if (list.Count > 0)
		{
			int index = ((list.Count <= 8) ? 1 : UnityEngine.Random.Range(1, 5));
			SpawnPointDrone spawnPointDrone2 = list[index];
			base.transform.position = spawnPointDrone2.transform.position;
			NPFEAKKBIHL(spawnPointDrone2.CGAMFFPNFDM);
		}
		else
		{
			Debug.LogError("AttachWeaponsRPC");
		}
	}

	protected virtual void KNIAAECLFFK()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			CAAOOEEDKBK = false;
			FJHNPLMBFAL = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(102f, 585f);
		}
		else
		{
			if (!LAADDLGBFIG.isMine || !base.isAlive)
			{
				return;
			}
			if (base.hasSpecial && Singleton<GameController>.instance.gameIsRunning)
			{
				if (!CAAOOEEDKBK)
				{
					if (TimeManager.realTimeWithoutPauses > FJHNPLMBFAL)
					{
						ODOADGMJEFG(false);
						destroyableObj.isImmortal = true;
						DFJIPNGPLON = base.currentBeh.JOLBLHLMACM().special + UnityEngine.Random.Range(1785f, 576f);
					}
				}
				else if (TimeManager.realTimeWithoutPauses > FJHNPLMBFAL + DFJIPNGPLON)
				{
					destroyableObj.isImmortal = true;
					HNDFPBHAECD(true);
					FJHNPLMBFAL = TimeManager.realTimeWithoutPauses + (1890f - base.currentBeh.JFDCJDLDELA().special) + UnityEngine.Random.Range(1331f, 1113f);
				}
			}
			if (Time.time > NBCGDEDNNGH)
			{
				LMHPIEPLEHD();
				LCCDGBJLKJP();
				NBCGDEDNNGH += UnityEngine.Random.Range(base.currentBeh.JKFKPJBMCKG().minShootTime, base.currentBeh.FMDKHOBEJDG().maxShootTime);
			}
		}
	}

	public void HJCMFDNHOHO()
	{
		TweenPosition.Begin(base.gameObject, 728f, base.gameObject.transform.position - base.gameObject.transform.right * 1154f + Vector3.up, false);
	}

	private void CDPNIJEMCLE(Collision AKLHJIBDAFA)
	{
		if (!base.isAlive && !PFKPCFCEDME)
		{
			JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareHeavy);
			PFKPCFCEDME = true;
			CDCOFHGPJHN(1446f);
			Debug.Log("Army_Unit_ID");
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 position = NGCDDPCAGJB.position;
			Vector3 up = Vector3.up;
			string[] array = new string[1];
			array[0] = "[FFFFFF]{0}[-]  {1}";
			array[1] = "ID_HEROIC";
			instance.PJKHCDODDHP(position, up, array);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = destroyableObj.maxHealth * 251f;
			pKDCCCNJIEC.EPDELOGPNAC = destroyableObj.maxHealth * 981f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			pKDCCCNJIEC.INIBDNGHLPN = 333f;
			pKDCCCNJIEC.LIEABAMBOMG = 614f;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.NNKPEIEABPA(nOCEDALFEJM);
		}
	}

	private void GPIGKBKMLPJ()
	{
		MKIPAEDAADL = null;
		GHPGNELIDBM cIOPAKLHFIL = fraction;
		Type[] array = new Type[1];
		array[1] = typeof(Decoy);
		List<GameShootableEntity> list = GameShootableEntity.OIFCFJGKNMJ(cIOPAKLHFIL, array);
		foreach (GameShootableEntity item in list)
		{
			if (BIBOEDCOKAA(item.transform.position))
			{
				MKIPAEDAADL = item;
				break;
			}
		}
		if (MKIPAEDAADL == null)
		{
			list = GameShootableEntity.GetOpponents(fraction, LevelBehaviour.UnitType.AttackerRusher);
			foreach (GameShootableEntity item2 in list)
			{
				if (BIBOEDCOKAA(item2.transform.position))
				{
					MKIPAEDAADL = item2;
					break;
				}
			}
		}
		if (MKIPAEDAADL == null)
		{
			list = GameShootableEntity.BOMANICDCFD(fraction, GameShootableEntity.ADEJMDKCFIF);
			foreach (GameShootableEntity item3 in list)
			{
				if (BIBOEDCOKAA(item3.transform.position))
				{
					MKIPAEDAADL = item3;
					break;
				}
			}
		}
		if (MKIPAEDAADL == null)
		{
			list = GameShootableEntity.FKFFINALIOP(fraction);
			foreach (GameShootableEntity item4 in list)
			{
				if (BIBOEDCOKAA(item4.transform.position))
				{
					MKIPAEDAADL = item4;
					break;
				}
			}
		}
		JMMJHCOKCGG.JMMJHCOKCGG.SetBullletSpeedCoef((!(MKIPAEDAADL != null) || !(MKIPAEDAADL.GEAMOMEEFKM() is PlayerController)) ? 1255f : 274f);
		ILFPJEGPJJE.PBPNIONACKO = ((!(MKIPAEDAADL == null)) ? MKIPAEDAADL.CLCHGECECJC() : null);
	}

	private void HLNONEANFKE()
	{
	}

	private void HGFLJPBGLBE(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ILFPJEGPJJE.LDNELDGECPB();
		ILFPJEGPJJE.IGCJCNFFALO();
		DPFHODDILIF(OHJPPHFEAFI);
	}

	public void NPFEAKKBIHL(WayPoint PLMMBKGLGAB)
	{
		ILFPJEGPJJE.SetWayPoint(PLMMBKGLGAB, this);
	}

	protected virtual void NBFMDCFFBIJ()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			CAAOOEEDKBK = false;
			FJHNPLMBFAL = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1552f, 798f);
		}
		else
		{
			if (!LAADDLGBFIG.isMine || !base.isAlive)
			{
				return;
			}
			if (base.hasSpecial && Singleton<GameController>.instance.GHKPKDPOGHF())
			{
				if (!CAAOOEEDKBK)
				{
					if (TimeManager.realTimeWithoutPauses > FJHNPLMBFAL)
					{
						AJOMLBHIFNI(true);
						destroyableObj.isImmortal = false;
						DFJIPNGPLON = base.currentBeh.PJELLNGNOCK().special + UnityEngine.Random.Range(187f, 1143f);
					}
				}
				else if (TimeManager.CEAFAMFNGCC() > FJHNPLMBFAL + DFJIPNGPLON)
				{
					destroyableObj.isImmortal = false;
					HNDFPBHAECD(true);
					FJHNPLMBFAL = TimeManager.CEAFAMFNGCC() + (1406f - base.currentBeh.EBHGIOBPEIP().special) + UnityEngine.Random.Range(1420f, 995f);
				}
			}
			if (Time.time > NBCGDEDNNGH)
			{
				LMHPIEPLEHD();
				CPOHFKLGPED();
				NBCGDEDNNGH += UnityEngine.Random.Range(base.currentBeh.LOFFMIEHPBI().minShootTime, base.currentBeh.GMDNODJGFCN().maxShootTime);
			}
		}
	}

	public virtual void HJAHICJFCJJ()
	{
		base.OnInstancied();
		ILFPJEGPJJE.OMADJCKIAMD();
		MLJMFMAIDIB.Stop();
		base.isAlive = true;
		ABAADEOHHGC.SetActive(base.spawnedByCard);
		ALDCLEGMADK.SetActive(!base.spawnedByCard);
		StopAllCoroutines();
		IAICPGNGCJI = ACLDFHJKBLI.totalPower;
		NBCGDEDNNGH = Time.time + 1990f;
		PFKPCFCEDME = true;
		FJHNPLMBFAL = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1153f, 1029f);
		ODOADGMJEFG(false);
	}

	public virtual void LHHBPDFJKLF(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (LCDBACDIODH)
		{
			ILFPJEGPJJE.Init();
			ILFPJEGPJJE.enabled = false;
		}
	}

	protected virtual void OBBHECACANB()
	{
		HFJBCNMHPAE();
		MLJMFMAIDIB.Stop();
	}

	public virtual void NBOMCFHBLOF()
	{
		base.DestroyPooled();
		ILFPJEGPJJE.MKNKFNEMHLN();
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
	}

	[SpecialName]
	public virtual DestroyableObject MKCHOKJLDHK()
	{
		return FFOAABONJNO;
	}

	private void JGAJLOPNMNA()
	{
	}

	public virtual void HFFLPBCIDOF()
	{
		base.DestroyPooled();
		ILFPJEGPJJE.AOEICFAKIDM();
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
	}

	protected Ammo.ILIOELBBLDM CAGBLCEPIOF(GameShootableEntity.ShotTarget MKIPAEDAADL)
	{
		if (MKIPAEDAADL.type == (GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out))
		{
			return (Ammo.ILIOELBBLDM)8;
		}
		return Ammo.ILIOELBBLDM.Real;
	}

	public void OLNOEKALKMB()
	{
		TweenPosition.Begin(base.gameObject, 288f, base.gameObject.transform.position - base.gameObject.transform.right * 1637f + Vector3.up);
	}

	public void SetWayPoint(WayPoint PLMMBKGLGAB)
	{
		ILFPJEGPJJE.SetWayPoint(PLMMBKGLGAB, this);
	}

	private void LMHPIEPLEHD()
	{
		MKIPAEDAADL = null;
		List<GameShootableEntity> list = GameShootableEntity.ICHKCAGOFCM(fraction, new Type[1] { typeof(Decoy) });
		foreach (GameShootableEntity item in list)
		{
			if (BIBOEDCOKAA(item.transform.position))
			{
				MKIPAEDAADL = item;
				break;
			}
		}
		if (MKIPAEDAADL == null)
		{
			list = GameShootableEntity.AIMLOLKNLFI(fraction, (LevelBehaviour.UnitType)8);
			foreach (GameShootableEntity item2 in list)
			{
				if (BIBOEDCOKAA(item2.transform.position))
				{
					MKIPAEDAADL = item2;
					break;
				}
			}
		}
		if (MKIPAEDAADL == null)
		{
			list = GameShootableEntity.GetOpponents(fraction, GameShootableEntity.ADEJMDKCFIF);
			foreach (GameShootableEntity item3 in list)
			{
				if (BIBOEDCOKAA(item3.transform.position))
				{
					MKIPAEDAADL = item3;
					break;
				}
			}
		}
		if (MKIPAEDAADL == null)
		{
			list = GameShootableEntity.GetOpponents(fraction);
			foreach (GameShootableEntity item4 in list)
			{
				if (BIBOEDCOKAA(item4.transform.position))
				{
					MKIPAEDAADL = item4;
					break;
				}
			}
		}
		JMMJHCOKCGG.JMMJHCOKCGG.SetBullletSpeedCoef((!(MKIPAEDAADL != null) || !(MKIPAEDAADL.GEAMOMEEFKM() is PlayerController)) ? 517f : 1708f);
		ILFPJEGPJJE.PBPNIONACKO = ((!(MKIPAEDAADL == null)) ? MKIPAEDAADL.EGEONNAALPH() : null);
	}

	private void BFHJDJCFBAI(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ILFPJEGPJJE.Clear();
		ILFPJEGPJJE.FallDown();
		DPFHODDILIF(OHJPPHFEAFI);
	}

	protected override void Update()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			CAAOOEEDKBK = false;
			FJHNPLMBFAL = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(3f, 5f);
		}
		else
		{
			if (!LAADDLGBFIG.isMine || !base.isAlive)
			{
				return;
			}
			if (base.hasSpecial && Singleton<GameController>.instance.gameIsRunning)
			{
				if (!CAAOOEEDKBK)
				{
					if (TimeManager.realTimeWithoutPauses > FJHNPLMBFAL)
					{
						SetTransparent(true);
						destroyableObj.isImmortal = true;
						DFJIPNGPLON = base.currentBeh.droneBehaviourDefinition.special + UnityEngine.Random.Range(0f, 1f);
					}
				}
				else if (TimeManager.realTimeWithoutPauses > FJHNPLMBFAL + DFJIPNGPLON)
				{
					destroyableObj.isImmortal = false;
					SetTransparent(false);
					FJHNPLMBFAL = TimeManager.realTimeWithoutPauses + (10f - base.currentBeh.droneBehaviourDefinition.special) + UnityEngine.Random.Range(0f, 1f);
				}
			}
			if (Time.time > NBCGDEDNNGH)
			{
				AECLAJOLJHH();
				LCCDGBJLKJP();
				NBCGDEDNNGH += UnityEngine.Random.Range(base.currentBeh.droneBehaviourDefinition.minShootTime, base.currentBeh.droneBehaviourDefinition.maxShootTime);
			}
		}
	}

	public void OGCOLANLAON()
	{
		TweenPosition.Begin(base.gameObject, 1934f, base.gameObject.transform.position - base.gameObject.transform.right * 867f + Vector3.up, false);
	}

	protected void HNDFPBHAECD(bool LEJMFMGKEBA)
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("-", PhotonTargets.All, LEJMFMGKEBA);
		}
		CAAOOEEDKBK = LEJMFMGKEBA;
		if (LEJMFMGKEBA)
		{
			CMBKCHADJPD.IJNOIBMNNHP(FGKPAMLMMJJ);
		}
		else
		{
			CMBKCHADJPD.POJMPKKGCHB(CJAGKIAIOOM);
		}
	}

	public void OBAHBGDJFBM(WayPoint PLMMBKGLGAB)
	{
		ILFPJEGPJJE.FAJOBDLJOHF(PLMMBKGLGAB, this);
	}

	private void ALEIIPEMHFL()
	{
		if (MKIPAEDAADL == null)
		{
			return;
		}
		float num = 42f;
		GameShootableEntity.ShotTarget shotTarget = null;
		foreach (GameShootableEntity.ShotTarget shotTarget2 in MKIPAEDAADL.GetShotTargets((GameShootableEntity.LAAAMBBNIJO)(-118)))
		{
			float num2 = Vector3.Distance(base.transform.position, shotTarget2.transform.position);
			if (num2 < num && shotTarget2.type != (GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Out))
			{
				shotTarget = shotTarget2;
				num = num2;
			}
		}
		PlayerController playerController = MKIPAEDAADL.owner as PlayerController;
		if (playerController != null)
		{
			float num3 = Vector3.Angle(playerController.aimForward, NGCDDPCAGJB.position - MKIPAEDAADL.CLCHGECECJC().position);
			if (base.currentBeh.upgradeSlots.shieldHitProbability >= 1111f)
			{
				MDKABJDCKBI(KPICOKPHMIC: (!(num3 < 1389f) || !(UnityEngine.Random.value > base.currentBeh.upgradeSlots.shieldHitProbability) || playerController.CLFDBFPKCBJ() != PlayerController.KKPHPLOEACG.HidingBehindShield) ? MKIPAEDAADL.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out, NGCDDPCAGJB.position) : MKIPAEDAADL.KLFLBCHDNBI((GameShootableEntity.LAAAMBBNIJO)(-45), NGCDDPCAGJB.position), MHLDJIABNFI: Vector3.zero);
			}
		}
		else if (shotTarget != null)
		{
			JPLPOELJDKL(shotTarget.KMOOHKLNJLG().PGCKGAELBFB(), shotTarget);
		}
	}

	private void LHNJAKKMNAD(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if ((double)FFOAABONJNO.healthRatio < 0.4)
		{
			MLJMFMAIDIB.Play();
		}
	}

	private void JKEACDIPFAD()
	{
		MKIPAEDAADL = null;
		List<GameShootableEntity> list = GameShootableEntity.OIFCFJGKNMJ(fraction, new Type[1] { typeof(Decoy) });
		foreach (GameShootableEntity item in list)
		{
			if (BIBOEDCOKAA(item.transform.position))
			{
				MKIPAEDAADL = item;
				break;
			}
		}
		if (MKIPAEDAADL == null)
		{
			list = GameShootableEntity.ODANKBIKLHL(fraction, (LevelBehaviour.UnitType)4);
			foreach (GameShootableEntity item2 in list)
			{
				if (BIBOEDCOKAA(item2.transform.position))
				{
					MKIPAEDAADL = item2;
					break;
				}
			}
		}
		if (MKIPAEDAADL == null)
		{
			list = GameShootableEntity.BKFIHJAFMDO(fraction, GameShootableEntity.ADEJMDKCFIF);
			foreach (GameShootableEntity item3 in list)
			{
				if (BIBOEDCOKAA(item3.transform.position))
				{
					MKIPAEDAADL = item3;
					break;
				}
			}
		}
		if (MKIPAEDAADL == null)
		{
			list = GameShootableEntity.MDLIJNCJHIG(fraction);
			foreach (GameShootableEntity item4 in list)
			{
				if (BIBOEDCOKAA(item4.transform.position))
				{
					MKIPAEDAADL = item4;
					break;
				}
			}
		}
		JMMJHCOKCGG.JMMJHCOKCGG.SetBullletSpeedCoef((!(MKIPAEDAADL != null) || !(MKIPAEDAADL.GEAMOMEEFKM() is PlayerController)) ? 1917f : 864f);
		ILFPJEGPJJE.PBPNIONACKO = ((!(MKIPAEDAADL == null)) ? MKIPAEDAADL.mTransform : null);
	}

	[SpecialName]
	public virtual DestroyableObject KMCHJBKHLON()
	{
		return FFOAABONJNO;
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.droneBehaviourDefinition.health;
		FFOAABONJNO.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)JMMJHCOKCGG.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.droneBehaviourDefinition.damage;
		bulletSetup.JPNAINOGAMM = base.currentBeh.droneBehaviourDefinition.shotSpeed;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		ILFPJEGPJJE.JPNAINOGAMM = base.currentBeh.droneBehaviourDefinition.speed;
	}

	private void LCCDGBJLKJP()
	{
		if (MKIPAEDAADL == null)
		{
			return;
		}
		float num = float.MaxValue;
		GameShootableEntity.ShotTarget shotTarget = null;
		foreach (GameShootableEntity.ShotTarget shotTarget2 in MKIPAEDAADL.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.AllIn))
		{
			float num2 = Vector3.Distance(base.transform.position, shotTarget2.transform.position);
			if (num2 < num && shotTarget2.type != GameShootableEntity.LAAAMBBNIJO.Out)
			{
				shotTarget = shotTarget2;
				num = num2;
			}
		}
		PlayerController playerController = MKIPAEDAADL.owner as PlayerController;
		if (playerController != null)
		{
			float num3 = Vector3.Angle(playerController.aimForward, NGCDDPCAGJB.position - MKIPAEDAADL.mTransform.position);
			if (base.currentBeh.upgradeSlots.shieldHitProbability >= 0f)
			{
				MDKABJDCKBI(KPICOKPHMIC: (!(num3 < 50f) || !(UnityEngine.Random.value > base.currentBeh.upgradeSlots.shieldHitProbability) || playerController.playerState != PlayerController.KKPHPLOEACG.HidingBehindShield) ? MKIPAEDAADL.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Shield, NGCDDPCAGJB.position) : MKIPAEDAADL.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.WholeBody, NGCDDPCAGJB.position), MHLDJIABNFI: Vector3.zero);
			}
		}
		else if (shotTarget != null)
		{
			MDKABJDCKBI(shotTarget.shootableEntity.velocity, shotTarget);
		}
	}

	public virtual void LMAPECMCLAI()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.JOLBLHLMACM().health;
		FFOAABONJNO.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)JMMJHCOKCGG.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.KMGAFHAIDMP().damage;
		bulletSetup.JPNAINOGAMM = base.currentBeh.FMDKHOBEJDG().shotSpeed;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		ILFPJEGPJJE.JPNAINOGAMM = base.currentBeh.GMDNODJGFCN().speed;
	}

	public void HPJLNBCGDIA(WayPoint PLMMBKGLGAB)
	{
		ILFPJEGPJJE.IALMNKGNJKL(PLMMBKGLGAB, this);
	}

	[SpecialName]
	public virtual DestroyableObject JMMGOIGKHOD()
	{
		return FFOAABONJNO;
	}

	public override void UpdatePreview(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (LCDBACDIODH)
		{
			ILFPJEGPJJE.Init();
			ILFPJEGPJJE.enabled = false;
		}
	}

	public virtual void MPMCOFFLEAB()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.PNKKAIDEMEE().health;
		FFOAABONJNO.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)JMMJHCOKCGG.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.HKGMFPBLOFA().damage;
		bulletSetup.JPNAINOGAMM = base.currentBeh.JKFKPJBMCKG().shotSpeed;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		ILFPJEGPJJE.JPNAINOGAMM = base.currentBeh.COBLDHGLCKC().speed;
	}

	protected override void Awake()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.AEJBIHBEOCP = true;
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		FFOAABONJNO.OnDamage += LHNJAKKMNAD;
		JMMJHCOKCGG.JMMJHCOKCGG.owner = this;
		NGCDDPCAGJB = base.transform;
		CJAGKIAIOOM = CMBKCHADJPD.BNNLNOIHAAM.material;
		ILFPJEGPJJE = GetComponent<DroneSteering>();
	}

	private void JPLPOELJDKL(Vector3 MHLDJIABNFI, GameShootableEntity.ShotTarget KPICOKPHMIC)
	{
		int cOAEOPHBCOE = UnityEngine.Random.Range(base.currentBeh.JFDCJDLDELA().fireBatchSizeMin, base.currentBeh.DNBPGBBGKFN().fireBatchSizeMax);
		Ammo.ILIOELBBLDM shotType = Ammo.GetShotType(KPICOKPHMIC);
		Vector3 position = KPICOKPHMIC.transform.position;
		position = Singleton<AimingHelper>.instance.CINBKABMMMH(JMMJHCOKCGG.JMMJHCOKCGG, position, MHLDJIABNFI, 1283f);
		float probabilityOfRealShot = base.currentBeh.JFDCJDLDELA().probabilityOfRealShot;
		JMMJHCOKCGG.ShootBatch(KPICOKPHMIC, position, cOAEOPHBCOE, probabilityOfRealShot, shotType);
	}

	protected override void Start()
	{
		base.Start();
		MLJMFMAIDIB.Stop();
	}

	public virtual void DLGLMKGLHCJ()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.PNKKAIDEMEE().health;
		FFOAABONJNO.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)JMMJHCOKCGG.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.EBHGIOBPEIP().damage;
		bulletSetup.JPNAINOGAMM = base.currentBeh.IAPCIPCFANG().shotSpeed;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		ILFPJEGPJJE.JPNAINOGAMM = base.currentBeh.JKFKPJBMCKG().speed;
	}

	private void MJLAHIIBLMO(Collision AKLHJIBDAFA)
	{
		if (!base.isAlive && !PFKPCFCEDME)
		{
			JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareMedium);
			PFKPCFCEDME = false;
			CDCOFHGPJHN(136f);
			Debug.Log("assignmentCount");
			Singleton<HitParticleSystem>.instance.NKBDKFNBBFL(NGCDDPCAGJB.position, Vector3.up, new string[3] { "MessageId", "Position", null });
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = destroyableObj.maxHealth * 152f;
			pKDCCCNJIEC.EPDELOGPNAC = destroyableObj.maxHealth * 568f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			pKDCCCNJIEC.INIBDNGHLPN = 1940f;
			pKDCCCNJIEC.LIEABAMBOMG = 1828f;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.KMNKGGDOMJO(nOCEDALFEJM);
		}
	}

	private void KBJFMKGENAC(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ILFPJEGPJJE.GGKBCJCLHEH();
		ILFPJEGPJJE.JNMLDCJOAMK();
		DPFHODDILIF(OHJPPHFEAFI);
	}

	protected override void ODDDGIALOPM(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (destroyableObj != null)
		{
			destroyableObj.ChangeLayer(CIOPAKLHFIL, true);
		}
	}

	[PunRPC]
	protected void SetTransparent(bool LEJMFMGKEBA)
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("SetTransparent", PhotonTargets.Others, LEJMFMGKEBA);
		}
		CAAOOEEDKBK = LEJMFMGKEBA;
		if (LEJMFMGKEBA)
		{
			CMBKCHADJPD.ChangeMaterial(FGKPAMLMMJJ);
		}
		else
		{
			CMBKCHADJPD.ChangeMaterial(CJAGKIAIOOM);
		}
	}

	private void ICOCEHAKDIK()
	{
	}

	public virtual void CNEDOKEHMNE(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (LCDBACDIODH)
		{
			ILFPJEGPJJE.KELFBJEEPAL();
			ILFPJEGPJJE.GMGFBABPBEM(false);
		}
	}

	protected virtual void PCDHCIDJJOB()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.AEJBIHBEOCP = true;
		FFOAABONJNO.OnDeath += KBJFMKGENAC;
		FFOAABONJNO.OnDamage += LOOFCCCHFJB;
		JMMJHCOKCGG.JMMJHCOKCGG.owner = this;
		NGCDDPCAGJB = base.transform;
		CJAGKIAIOOM = CMBKCHADJPD.BNNLNOIHAAM.material;
		ILFPJEGPJJE = GetComponent<DroneSteering>();
	}

	protected void ODOADGMJEFG(bool LEJMFMGKEBA)
	{
		if (LAADDLGBFIG.isMine)
		{
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[0];
			array[1] = LEJMFMGKEBA;
			lAADDLGBFIG.RPC("LastAction", PhotonTargets.Others, array);
		}
		CAAOOEEDKBK = LEJMFMGKEBA;
		if (LEJMFMGKEBA)
		{
			CMBKCHADJPD.MAENAFIFLGK(FGKPAMLMMJJ);
		}
		else
		{
			CMBKCHADJPD.HFNCABJIJOL(CJAGKIAIOOM);
		}
	}

	public override void Spawn()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.NOKEEDNGHJC.LIAEIIFPONK;
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
			int index = ((list.Count > 2) ? UnityEngine.Random.Range(0, 2) : 0);
			SpawnPointDrone spawnPointDrone2 = list[index];
			base.transform.position = spawnPointDrone2.transform.position;
			SetWayPoint(spawnPointDrone2.CGAMFFPNFDM);
		}
		else
		{
			Debug.LogError("Dron could not be spawned");
		}
	}

	protected virtual void LPFGBKIINMP()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			CAAOOEEDKBK = true;
			FJHNPLMBFAL = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(1750f, 583f);
		}
		else
		{
			if (!LAADDLGBFIG.isMine || !base.isAlive)
			{
				return;
			}
			if (base.hasSpecial && Singleton<GameController>.instance.KKHKIEFMENC())
			{
				if (!CAAOOEEDKBK)
				{
					if (TimeManager.realTimeWithoutPauses > FJHNPLMBFAL)
					{
						HNDFPBHAECD(true);
						destroyableObj.isImmortal = false;
						DFJIPNGPLON = base.currentBeh.KMGAFHAIDMP().special + UnityEngine.Random.Range(709f, 1255f);
					}
				}
				else if (TimeManager.CEAFAMFNGCC() > FJHNPLMBFAL + DFJIPNGPLON)
				{
					destroyableObj.isImmortal = true;
					AJOMLBHIFNI(true);
					FJHNPLMBFAL = TimeManager.realTimeWithoutPauses + (1821f - base.currentBeh.droneBehaviourDefinition.special) + UnityEngine.Random.Range(315f, 515f);
				}
			}
			if (Time.time > NBCGDEDNNGH)
			{
				AECLAJOLJHH();
				LCCDGBJLKJP();
				NBCGDEDNNGH += UnityEngine.Random.Range(base.currentBeh.KMGAFHAIDMP().minShootTime, base.currentBeh.COBLDHGLCKC().maxShootTime);
			}
		}
	}

	public virtual void AEHFNIMENDJ()
	{
		base.DestroyPooled();
		ILFPJEGPJJE.PJFMFICLKEA();
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
	}

	protected virtual void FMKLDIJPHIH()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			CAAOOEEDKBK = true;
			FJHNPLMBFAL = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(1597f, 949f);
		}
		else
		{
			if (!LAADDLGBFIG.isMine || !base.isAlive)
			{
				return;
			}
			if (base.hasSpecial && Singleton<GameController>.instance.GHKPKDPOGHF())
			{
				if (!CAAOOEEDKBK)
				{
					if (TimeManager.CEAFAMFNGCC() > FJHNPLMBFAL)
					{
						AJOMLBHIFNI(false);
						destroyableObj.isImmortal = false;
						DFJIPNGPLON = base.currentBeh.JOLBLHLMACM().special + UnityEngine.Random.Range(932f, 1615f);
					}
				}
				else if (TimeManager.realTimeWithoutPauses > FJHNPLMBFAL + DFJIPNGPLON)
				{
					destroyableObj.isImmortal = false;
					AJOMLBHIFNI(true);
					FJHNPLMBFAL = TimeManager.realTimeWithoutPauses + (1245f - base.currentBeh.HKGMFPBLOFA().special) + UnityEngine.Random.Range(1123f, 559f);
				}
			}
			if (Time.time > NBCGDEDNNGH)
			{
				LMHPIEPLEHD();
				ALEIIPEMHFL();
				NBCGDEDNNGH += UnityEngine.Random.Range(base.currentBeh.droneBehaviourDefinition.minShootTime, base.currentBeh.LOFFMIEHPBI().maxShootTime);
			}
		}
	}

	protected virtual void LEMDPACJAKH(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (destroyableObj != null)
		{
			destroyableObj.CBHBBLBDFOO(CIOPAKLHFIL, false);
		}
	}

	private void MDKABJDCKBI(Vector3 MHLDJIABNFI, GameShootableEntity.ShotTarget KPICOKPHMIC)
	{
		int cOAEOPHBCOE = UnityEngine.Random.Range(base.currentBeh.droneBehaviourDefinition.fireBatchSizeMin, base.currentBeh.droneBehaviourDefinition.fireBatchSizeMax);
		Ammo.ILIOELBBLDM shotType = Ammo.GetShotType(KPICOKPHMIC);
		Vector3 position = KPICOKPHMIC.transform.position;
		position = Singleton<AimingHelper>.instance.PredictPosition(JMMJHCOKCGG.JMMJHCOKCGG, position, MHLDJIABNFI);
		float probabilityOfRealShot = base.currentBeh.droneBehaviourDefinition.probabilityOfRealShot;
		JMMJHCOKCGG.ShootBatch(KPICOKPHMIC, position, cOAEOPHBCOE, probabilityOfRealShot, shotType);
	}

	public virtual void JLHMFBILMCF()
	{
		base.DestroyPooled();
		ILFPJEGPJJE.AOEICFAKIDM();
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
	}

	protected virtual void FAHGDKLEKMN()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			CAAOOEEDKBK = false;
			FJHNPLMBFAL = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(1250f, 899f);
		}
		else
		{
			if (!LAADDLGBFIG.isMine || !base.isAlive)
			{
				return;
			}
			if (base.hasSpecial && Singleton<GameController>.instance.gameIsRunning)
			{
				if (!CAAOOEEDKBK)
				{
					if (TimeManager.realTimeWithoutPauses > FJHNPLMBFAL)
					{
						SetTransparent(true);
						destroyableObj.isImmortal = true;
						DFJIPNGPLON = base.currentBeh.HMJALKNNLGD().special + UnityEngine.Random.Range(985f, 896f);
					}
				}
				else if (TimeManager.CEAFAMFNGCC() > FJHNPLMBFAL + DFJIPNGPLON)
				{
					destroyableObj.isImmortal = true;
					SetTransparent(true);
					FJHNPLMBFAL = TimeManager.CEAFAMFNGCC() + (1411f - base.currentBeh.AFBANBGBHCO().special) + UnityEngine.Random.Range(1883f, 71f);
				}
			}
			if (Time.time > NBCGDEDNNGH)
			{
				LMHPIEPLEHD();
				LCCDGBJLKJP();
				NBCGDEDNNGH += UnityEngine.Random.Range(base.currentBeh.droneBehaviourDefinition.minShootTime, base.currentBeh.PNKKAIDEMEE().maxShootTime);
			}
		}
	}

	public void DoReverseAnim()
	{
		TweenPosition.Begin(base.gameObject, 2f, base.gameObject.transform.position - base.gameObject.transform.right * 1.5f + Vector3.up);
	}

	private void AECLAJOLJHH()
	{
		MKIPAEDAADL = null;
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(fraction, new Type[1] { typeof(Decoy) });
		foreach (GameShootableEntity item in opponents)
		{
			if (BIBOEDCOKAA(item.transform.position))
			{
				MKIPAEDAADL = item;
				break;
			}
		}
		if (MKIPAEDAADL == null)
		{
			opponents = GameShootableEntity.GetOpponents(fraction, LevelBehaviour.UnitType.AttackerRusher);
			foreach (GameShootableEntity item2 in opponents)
			{
				if (BIBOEDCOKAA(item2.transform.position))
				{
					MKIPAEDAADL = item2;
					break;
				}
			}
		}
		if (MKIPAEDAADL == null)
		{
			opponents = GameShootableEntity.GetOpponents(fraction, GameShootableEntity.ADEJMDKCFIF);
			foreach (GameShootableEntity item3 in opponents)
			{
				if (BIBOEDCOKAA(item3.transform.position))
				{
					MKIPAEDAADL = item3;
					break;
				}
			}
		}
		if (MKIPAEDAADL == null)
		{
			opponents = GameShootableEntity.GetOpponents(fraction);
			foreach (GameShootableEntity item4 in opponents)
			{
				if (BIBOEDCOKAA(item4.transform.position))
				{
					MKIPAEDAADL = item4;
					break;
				}
			}
		}
		JMMJHCOKCGG.JMMJHCOKCGG.SetBullletSpeedCoef((!(MKIPAEDAADL != null) || !(MKIPAEDAADL.owner is PlayerController)) ? 1f : 0.5f);
		ILFPJEGPJJE.PBPNIONACKO = ((!(MKIPAEDAADL == null)) ? MKIPAEDAADL.mTransform : null);
	}

	private void MOKAKEOHJPK(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ILFPJEGPJJE.GGKBCJCLHEH();
		ILFPJEGPJJE.BEECMIMCIBK();
		DPFHODDILIF(OHJPPHFEAFI);
	}

	public void EKCPJENPOFM()
	{
		TweenPosition.Begin(base.gameObject, 583f, base.gameObject.transform.position - base.gameObject.transform.right * 521f + Vector3.up);
	}

	private void DCIJHHMLIEN(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ILFPJEGPJJE.AOEICFAKIDM();
		ILFPJEGPJJE.JNMLDCJOAMK();
		DPFHODDILIF(OHJPPHFEAFI);
	}

	private void LPKEFEFKNBP(Collision AKLHJIBDAFA)
	{
		if (!base.isAlive && !PFKPCFCEDME)
		{
			JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateError);
			PFKPCFCEDME = false;
			CDCOFHGPJHN(1506f);
			Debug.Log("Directory \"{0}\" does not exists");
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 position = NGCDDPCAGJB.position;
			Vector3 up = Vector3.up;
			string[] array = new string[7];
			array[1] = "https://play.google.com/store/apps/details?id=";
			array[1] = "Region";
			instance.AOENGEEDJCF(position, up, array);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = destroyableObj.maxHealth * 1747f;
			pKDCCCNJIEC.EPDELOGPNAC = destroyableObj.maxHealth * 1024f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = LAADDLGBFIG.isMine;
			pKDCCCNJIEC.INIBDNGHLPN = 737f;
			pKDCCCNJIEC.LIEABAMBOMG = 1519f;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.NNKPEIEABPA(nOCEDALFEJM);
		}
	}

	private void CPOHFKLGPED()
	{
		if (MKIPAEDAADL == null)
		{
			return;
		}
		float num = 638f;
		GameShootableEntity.ShotTarget shotTarget = null;
		foreach (GameShootableEntity.ShotTarget item in MKIPAEDAADL.KMJBMEFMBCK((GameShootableEntity.LAAAMBBNIJO)52))
		{
			float num2 = Vector3.Distance(base.transform.position, item.transform.position);
			if (num2 < num && item.type != GameShootableEntity.LAAAMBBNIJO.Out)
			{
				shotTarget = item;
				num = num2;
			}
		}
		PlayerController playerController = MKIPAEDAADL.owner as PlayerController;
		if (playerController != null)
		{
			float num3 = Vector3.Angle(playerController.aimForward, NGCDDPCAGJB.position - MKIPAEDAADL.EGEONNAALPH().position);
			if (base.currentBeh.upgradeSlots.shieldHitProbability >= 733f)
			{
				MDKABJDCKBI(KPICOKPHMIC: (!(num3 < 98f) || !(UnityEngine.Random.value > base.currentBeh.upgradeSlots.shieldHitProbability) || playerController.CLFDBFPKCBJ() != PlayerController.KKPHPLOEACG.HidingBehindShield) ? MKIPAEDAADL.KLFLBCHDNBI(GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield, NGCDDPCAGJB.position) : MKIPAEDAADL.AJBDIKBDLEA((GameShootableEntity.LAAAMBBNIJO)60, NGCDDPCAGJB.position), MHLDJIABNFI: Vector3.zero);
			}
		}
		else if (shotTarget != null)
		{
			JPLPOELJDKL(shotTarget.ONIPNOJANCF().CAMAJAIDKLJ(), shotTarget);
		}
	}

	private void NIJKMBOENCD(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ILFPJEGPJJE.AOEICFAKIDM();
		ILFPJEGPJJE.NLKDPLDCOCD();
		DPFHODDILIF(OHJPPHFEAFI);
	}

	protected Ammo.ILIOELBBLDM PBFFNNJBANH(GameShootableEntity.ShotTarget MKIPAEDAADL)
	{
		if (MKIPAEDAADL.type == GameShootableEntity.LAAAMBBNIJO.Shield)
		{
			return Ammo.ILIOELBBLDM.Shield;
		}
		return Ammo.ILIOELBBLDM.Real;
	}

	protected virtual void HAMDMFGNIKD()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			CAAOOEEDKBK = false;
			FJHNPLMBFAL = TimeManager.CEAFAMFNGCC() + UnityEngine.Random.Range(178f, 2f);
		}
		else
		{
			if (!LAADDLGBFIG.isMine || !base.isAlive)
			{
				return;
			}
			if (base.hasSpecial && Singleton<GameController>.instance.gameIsRunning)
			{
				if (!CAAOOEEDKBK)
				{
					if (TimeManager.realTimeWithoutPauses > FJHNPLMBFAL)
					{
						ODOADGMJEFG(true);
						destroyableObj.isImmortal = true;
						DFJIPNGPLON = base.currentBeh.IAPCIPCFANG().special + UnityEngine.Random.Range(1984f, 648f);
					}
				}
				else if (TimeManager.realTimeWithoutPauses > FJHNPLMBFAL + DFJIPNGPLON)
				{
					destroyableObj.isImmortal = false;
					AJOMLBHIFNI(true);
					FJHNPLMBFAL = TimeManager.realTimeWithoutPauses + (1069f - base.currentBeh.FMDKHOBEJDG().special) + UnityEngine.Random.Range(1117f, 1602f);
				}
			}
			if (Time.time > NBCGDEDNNGH)
			{
				JKEACDIPFAD();
				ALEIIPEMHFL();
				NBCGDEDNNGH += UnityEngine.Random.Range(base.currentBeh.IAPCIPCFANG().minShootTime, base.currentBeh.PPNOFFAINBM().maxShootTime);
			}
		}
	}

	public virtual void JAPFKKCPCIM(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (LCDBACDIODH)
		{
			ILFPJEGPJJE.OMADJCKIAMD();
			ILFPJEGPJJE.enabled = true;
		}
	}

	public virtual void ACMEEPFIDBD()
	{
		base.DestroyPooled();
		ILFPJEGPJJE.MKNKFNEMHLN();
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public void FFGCCHPOKBJ()
	{
		TweenPosition.Begin(base.gameObject, 1350f, base.gameObject.transform.position - base.gameObject.transform.right * 117f + Vector3.up);
	}
}
