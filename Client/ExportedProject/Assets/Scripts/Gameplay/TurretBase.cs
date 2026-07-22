using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class TurretBase<T, U> : MechanicalUnit<T> where T : TurretBaseBehaviourG<U> where U : VehicleBehaviourDefinititon
{
	[FormerlySerializedAs("CIKNLIOKJMM")]
	public TurretWeaponBasic KAIGJFPMEKL;

	protected PhotonView FEHCCGEGPLH;

	protected DestroyableObject FFOAABONJNO;

	private TurretPosition DHDPCBHLACO;

	[FormerlySerializedAs("PEPOPLHEKBK")]
	public GameObject OFBEAKDOCIO;

	public override DestroyableObject destroyableObj => FFOAABONJNO;

	public virtual void HBFGEHIMBHD()
	{
		base.OnInstancied();
		KAIGJFPMEKL.NIGDCBDKKMJ();
		KAIGJFPMEKL.JNFKFJOECJE();
		KAIGJFPMEKL.enabled = true;
		if (OFBEAKDOCIO != null)
		{
			OFBEAKDOCIO.gameObject.SetActive(value: false);
		}
	}

	protected void PJLFPMAEIOE(int FBFMHCANCBI, int AGGJGNBOHNM)
	{
		DHDPCBHLACO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD[FBFMHCANCBI].point.IFDJIGAPAPP[AGGJGNBOHNM];
		OOCKNFJKPFD();
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		DestroyableObject fFOAABONJNO = FFOAABONJNO;
		T val = base.currentBeh;
		fFOAABONJNO.maxHealth = val.turretBehaviour.health;
		FFOAABONJNO.RefillOffline();
		AmmoSetup ammoSetup = KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		T val2 = base.currentBeh;
		ammoSetup.EPDELOGPNAC = val2.turretBehaviour.damage;
		ammoSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		ammoSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		TurretWeaponBasic kAIGJFPMEKL = KAIGJFPMEKL;
		T val3 = base.currentBeh;
		kAIGJFPMEKL.JGACHOEBKJG = val3.turretBehaviour.minShootTime;
		TurretWeaponBasic kAIGJFPMEKL2 = KAIGJFPMEKL;
		T val4 = base.currentBeh;
		kAIGJFPMEKL2.KMCFBCNNMGF = val4.turretBehaviour.maxShootTime;
		TurretWeaponBasic kAIGJFPMEKL3 = KAIGJFPMEKL;
		T val5 = base.currentBeh;
		kAIGJFPMEKL3.JMJHGHAHAOH = val5.turretBehaviour.fireBatchSizeMin;
		TurretWeaponBasic kAIGJFPMEKL4 = KAIGJFPMEKL;
		T val6 = base.currentBeh;
		kAIGJFPMEKL4.MNGCPAPDCNB = val6.turretBehaviour.fireBatchSizeMax;
		BulletSetup bulletSetup = ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			T val7 = base.currentBeh;
			bulletSetup.JPNAINOGAMM = val7.turretBehaviour.shotSpeed;
		}
		KAIGJFPMEKL.Reset();
		if (LCDBACDIODH)
		{
			KAIGJFPMEKL.enabled = false;
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public virtual void GACJFNEBJID()
	{
		base.OnInstancied();
		KAIGJFPMEKL.GGMKKIDFJOH();
		KAIGJFPMEKL.MCEPKEIINAA();
		KAIGJFPMEKL.enabled = false;
		if (OFBEAKDOCIO != null)
		{
			OFBEAKDOCIO.gameObject.SetActive(value: true);
		}
	}

	public virtual void LLBKJDLGGBK()
	{
		base.UpgradesLoaded();
		DestroyableObject fFOAABONJNO = FFOAABONJNO;
		T val = base.currentBeh;
		fFOAABONJNO.maxHealth = val.turretBehaviour.health;
		FFOAABONJNO.NGNPMPGIAGP();
		AmmoSetup ammoSetup = KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		T val2 = base.currentBeh;
		ammoSetup.EPDELOGPNAC = val2.turretBehaviour.damage;
		ammoSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		ammoSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		TurretWeaponBasic kAIGJFPMEKL = KAIGJFPMEKL;
		T val3 = base.currentBeh;
		kAIGJFPMEKL.JGACHOEBKJG = val3.turretBehaviour.minShootTime;
		TurretWeaponBasic kAIGJFPMEKL2 = KAIGJFPMEKL;
		T val4 = base.currentBeh;
		kAIGJFPMEKL2.KMCFBCNNMGF = val4.turretBehaviour.maxShootTime;
		TurretWeaponBasic kAIGJFPMEKL3 = KAIGJFPMEKL;
		T val5 = base.currentBeh;
		kAIGJFPMEKL3.JMJHGHAHAOH = val5.turretBehaviour.fireBatchSizeMin;
		TurretWeaponBasic kAIGJFPMEKL4 = KAIGJFPMEKL;
		T val6 = base.currentBeh;
		kAIGJFPMEKL4.MNGCPAPDCNB = val6.turretBehaviour.fireBatchSizeMax;
		BulletSetup bulletSetup = ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			T val7 = base.currentBeh;
			bulletSetup.JPNAINOGAMM = val7.turretBehaviour.shotSpeed;
		}
		KAIGJFPMEKL.GGMKKIDFJOH();
		if (LCDBACDIODH)
		{
			KAIGJFPMEKL.enabled = true;
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		DIPLDDHLMME = false;
		if (DHDPCBHLACO != null)
		{
			DHDPCBHLACO.OKFECLNAFBN = false;
			DHDPCBHLACO = null;
		}
	}

	protected virtual void ABMKKECEGIB()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.AEJBIHBEOCP = false;
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		KAIGJFPMEKL.IMBEHDLKAPB = base.gameObject.transform;
		DIPLDDHLMME = false;
	}

	protected void BLMDPLNHOGJ(int FBFMHCANCBI, int AGGJGNBOHNM)
	{
		DHDPCBHLACO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD[FBFMHCANCBI].point.IFDJIGAPAPP[AGGJGNBOHNM];
		OOCKNFJKPFD();
	}

	private void BMDLGLDKFGL()
	{
		NavMesh.SamplePosition(DHDPCBHLACO.transform.position, out var hit, 13f, 0);
		Vector3 position = hit.position;
		base.transform.position = position;
	}

	protected void ANCNDCABEOF(int FBFMHCANCBI, int AGGJGNBOHNM)
	{
		DHDPCBHLACO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD[FBFMHCANCBI].point.IFDJIGAPAPP[AGGJGNBOHNM];
		OOCKNFJKPFD();
	}

	public void MBPDOKPJDNN()
	{
		if (OFBEAKDOCIO != null)
		{
			OFBEAKDOCIO.gameObject.SetActive(value: true);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.AEJBIHBEOCP = true;
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		KAIGJFPMEKL.IMBEHDLKAPB = base.gameObject.transform;
		DIPLDDHLMME = false;
	}

	public override void Spawn()
	{
		base.Spawn();
		if (!LAADDLGBFIG.isMine || !DIPLDDHLMME)
		{
			return;
		}
		PlayerController player = PlayerController.GetPlayer(fraction);
		if (!(player != null))
		{
			return;
		}
		float num = float.MaxValue;
		TurretPosition turretPosition = null;
		int num2 = -1;
		int num3 = -1;
		for (int i = 0; i < Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.Count; i++)
		{
			MapDefinition.DefendPosition defendPosition = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD[i];
			if (defendPosition.fraction != fraction)
			{
				continue;
			}
			for (int j = 0; j < defendPosition.point.IFDJIGAPAPP.Count; j++)
			{
				TurretPosition turretPosition2 = defendPosition.point.IFDJIGAPAPP[j];
				if (!turretPosition2.OKFECLNAFBN)
				{
					float sqrMagnitude = (player.position - turretPosition2.transform.position).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						turretPosition = turretPosition2;
						num2 = i;
						num3 = j;
					}
				}
			}
		}
		if (turretPosition != null)
		{
			DHDPCBHLACO = turretPosition;
			DHDPCBHLACO.OKFECLNAFBN = true;
			OOCKNFJKPFD();
			FEHCCGEGPLH.RPC("SetShieldPositionRPC", PhotonTargets.Others, num2, num3);
		}
	}

	private void BFHJDJCFBAI(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		Singleton<HitParticleSystem>.instance.PlayParticles(base.transform.position, Vector3.up, "metalExplosion", "grenadeExplosion");
		DPFHODDILIF(OHJPPHFEAFI);
		CDCOFHGPJHN(0.2f);
		if (OHJPPHFEAFI.FJLBLLLEELD != DestroyableObject.MANAGOLPMLH.Explosion)
		{
			DFHALNOAGGC.JNLILPMHKCH(DFHALNOAGGC.PEBLJIFMBGC.Medium, OHJPPHFEAFI.OHNCLEOMHCF);
		}
	}

	private void OOCKNFJKPFD()
	{
		NavMesh.SamplePosition(DHDPCBHLACO.transform.position, out var hit, 10f, 1);
		Vector3 position = hit.position;
		base.transform.position = position;
	}

	public virtual void LBJDCOJJFOG()
	{
		base.OnInstancied();
		KAIGJFPMEKL.HEOPOOMLPJF();
		KAIGJFPMEKL.MCEPKEIINAA();
		KAIGJFPMEKL.enabled = false;
		if (OFBEAKDOCIO != null)
		{
			OFBEAKDOCIO.gameObject.SetActive(value: true);
		}
	}

	[PunRPC]
	protected void SetShieldPositionRPC(int FBFMHCANCBI, int AGGJGNBOHNM)
	{
		DHDPCBHLACO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD[FBFMHCANCBI].point.IFDJIGAPAPP[AGGJGNBOHNM];
		OOCKNFJKPFD();
	}

	public virtual void IKICBEFAGPE()
	{
		base.DestroyPooled();
		DIPLDDHLMME = true;
		if (DHDPCBHLACO != null)
		{
			DHDPCBHLACO.OKFECLNAFBN = false;
			DHDPCBHLACO = null;
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		KAIGJFPMEKL.Reset();
		KAIGJFPMEKL.ResetAiming();
		KAIGJFPMEKL.enabled = true;
		if (OFBEAKDOCIO != null)
		{
			OFBEAKDOCIO.gameObject.SetActive(value: true);
		}
	}

	private void NCLHELCNCFK()
	{
		NavMesh.SamplePosition(DHDPCBHLACO.transform.position, out var hit, 128f, 0);
		Vector3 position = hit.position;
		base.transform.position = position;
	}

	private void HFMEHIHJPPJ()
	{
		NavMesh.SamplePosition(DHDPCBHLACO.transform.position, out var hit, 1035f, 0);
		Vector3 position = hit.position;
		base.transform.position = position;
	}

	public void HideShadow()
	{
		if (OFBEAKDOCIO != null)
		{
			OFBEAKDOCIO.gameObject.SetActive(value: false);
		}
	}
}
