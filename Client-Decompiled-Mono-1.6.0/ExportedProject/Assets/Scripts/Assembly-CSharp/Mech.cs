using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class Mech : MechanicalUnit<MechBehaviour>
{
	private enum LLEHEFACLDA
	{
		Walk = 0,
		Strafe = 1,
		Shoot = 2,
		Idle = 3
	}

	private sealed class PBAIKHKBHBG
	{
		internal GameShootableEntity.ShotTarget GEHACOGJMHA;

		internal Vector3 MDOPFNNFLFB;

		internal Ammo.ILIOELBBLDM MGDGFBCJINH;

		internal GameShootableEntity.ShotTarget KPICOKPHMIC;

		internal Vector3 MHLDJIABNFI;

		internal Vector3 KDCJNCKOIHB;

		internal int HLAKECBLNJL;

		internal float PJPHFMECEHH;

		internal Mech BJGCPDNMHDH;

		internal void KNJBDOADLDO()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Shield)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.GLHKCPOMKHE(BJGCPDNMHDH.GGKGGMNIDMI[1].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 286f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].CHPNNNDGNIL(KPICOKPHMIC, MDOPFNNFLFB + KDCJNCKOIHB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 344.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void LHPPLGOOLEC()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Out)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.KCDPGLNJDKI(BJGCPDNMHDH.GGKGGMNIDMI[1].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 1300f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[1].MBOJADMHJMO(KPICOKPHMIC, MDOPFNNFLFB + KDCJNCKOIHB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 1748.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void CHDOECNGOPM()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.None)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.JHBMEELACLE(BJGCPDNMHDH.GGKGGMNIDMI[1].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 1805f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[1].OFPCMHCEMHA(KPICOKPHMIC, MDOPFNNFLFB + KDCJNCKOIHB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 1580.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void AMIJFGBOCLC()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Head)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.PCDBBLFKFCJ(BJGCPDNMHDH.GGKGGMNIDMI[1].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 371f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].OFPCMHCEMHA(KPICOKPHMIC, MDOPFNNFLFB + KDCJNCKOIHB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 1315.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void LJCDGJKCNEC()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Shield)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.PredictPosition(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[1].ShootBatch(KPICOKPHMIC, MDOPFNNFLFB + KDCJNCKOIHB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 0.5), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void KJIFNOJILDB()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Out)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.KCDPGLNJDKI(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 1350f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].ShootBatch(KPICOKPHMIC, MDOPFNNFLFB + KDCJNCKOIHB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 1952.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void NAJNECOMDDN()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Head)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.ABKLEHLLDBN(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 384f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].MBOJADMHJMO(KPICOKPHMIC, MDOPFNNFLFB + KDCJNCKOIHB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 1308.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void MAKLHLCDIKD()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != (GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Out))
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.KEMKJNHCEIM(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 366f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[1].OFPCMHCEMHA(KPICOKPHMIC, MDOPFNNFLFB + KDCJNCKOIHB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 1170.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void CIFEDFPPPOK()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.Head)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.CINBKABMMMH(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 819f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].OFPCMHCEMHA(KPICOKPHMIC, MDOPFNNFLFB + KDCJNCKOIHB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 1540.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void ECPMEMNKMCB()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != (GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Out))
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.PCDBBLFKFCJ(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 485f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[1].ShootBatch(KPICOKPHMIC, MDOPFNNFLFB + KDCJNCKOIHB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 221.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void MCFGAFBEJDK()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != (GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out))
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.ENKMEEDAALF(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 421f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[1].OFPCMHCEMHA(KPICOKPHMIC, MDOPFNNFLFB + KDCJNCKOIHB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 830.0), PJPHFMECEHH, MGDGFBCJINH);
		}

		internal void NDJOJHNIBFC()
		{
			MDOPFNNFLFB = GEHACOGJMHA.transform.position;
			MGDGFBCJINH = Ammo.GetShotType(GEHACOGJMHA);
			if (KPICOKPHMIC.type != GameShootableEntity.LAAAMBBNIJO.None)
			{
				MDOPFNNFLFB = Singleton<AimingHelper>.instance.KAEMPBHPOLJ(BJGCPDNMHDH.GGKGGMNIDMI[0].JMMJHCOKCGG, MDOPFNNFLFB, MHLDJIABNFI, 1079f);
			}
			BJGCPDNMHDH.GGKGGMNIDMI[0].ShootBatch(KPICOKPHMIC, MDOPFNNFLFB + KDCJNCKOIHB, HLAKECBLNJL - (int)((double)HLAKECBLNJL * 1091.0), PJPHFMECEHH, MGDGFBCJINH);
		}
	}

	[SerializeField]
	private NavigationAgent mAgent;

	[SerializeField]
	private DestroyableObjectMultipleParts mDestroyableObject;

	[SerializeField]
	private MechAnimator mMechAnimator;

	public float HHFPGODMJDJ = 0.3f;

	public List<BatchedWeapon> GGKGGMNIDMI;

	private EnemyPoint PCEHMPNPHOC;

	private bool ILPLGCOCODB;

	private LLEHEFACLDA OGGHKAKGMFE;

	private float HJEJNIJPFHF;

	private GameShootableEntity JDGADCDMFHM;

	private readonly LHMCMJDDOHI LADBLHGBOKJ = new LHMCMJDDOHI();

	public override DestroyableObject destroyableObj
	{
		get
		{
			return mDestroyableObject;
		}
	}

	private MechBehaviour NADNBCMGLBF
	{
		get
		{
			return (MechBehaviour)ACLDFHJKBLI;
		}
	}

	[CompilerGenerated]
	private int CPNFAMAILHD(EnemyPoint HPJFBKEKJHB, EnemyPoint NCMHGPNPEJM)
	{
		return Vector3.Distance(HPJFBKEKJHB.position, base.transform.position).CompareTo(Vector3.Distance(NCMHGPNPEJM.position, base.transform.position));
	}

	public virtual void KMOACOOBEJE()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.DMCDJGLDICM.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			if (AcceptSpawnPoint(item))
			{
				base.transform.position = item.transform.position;
				break;
			}
		}
	}

	public virtual void CJOEAEFIMID()
	{
		base.StartEnemyBehaviour();
		FENCJADHNLB(true);
		mMechAnimator.KLBNKCKFBEF();
		mAgent.speed = base.currentBeh.EKKFDPDMIJM().speed;
		OGGHKAKGMFE = LLEHEFACLDA.Walk;
		HJEJNIJPFHF = Time.time + 1611f;
	}

	private void MDKABJDCKBI(Vector3 MHLDJIABNFI, GameShootableEntity.ShotTarget KPICOKPHMIC, GameShootableEntity.ShotTarget GEHACOGJMHA, Vector3 JACPGMNIHEK, Vector3 KDCJNCKOIHB)
	{
		PBAIKHKBHBG pBAIKHKBHBG = new PBAIKHKBHBG();
		pBAIKHKBHBG.GEHACOGJMHA = GEHACOGJMHA;
		pBAIKHKBHBG.KPICOKPHMIC = KPICOKPHMIC;
		pBAIKHKBHBG.MHLDJIABNFI = MHLDJIABNFI;
		pBAIKHKBHBG.KDCJNCKOIHB = KDCJNCKOIHB;
		pBAIKHKBHBG.BJGCPDNMHDH = this;
		pBAIKHKBHBG.HLAKECBLNJL = UnityEngine.Random.Range(NADNBCMGLBF.mechDefinition.fireBatchSizeMin, NADNBCMGLBF.mechDefinition.fireBatchSizeMax);
		pBAIKHKBHBG.MGDGFBCJINH = Ammo.GetShotType(pBAIKHKBHBG.KPICOKPHMIC);
		pBAIKHKBHBG.MDOPFNNFLFB = pBAIKHKBHBG.KPICOKPHMIC.transform.position;
		pBAIKHKBHBG.MDOPFNNFLFB = Singleton<AimingHelper>.instance.PredictPosition(GGKGGMNIDMI[0].JMMJHCOKCGG, pBAIKHKBHBG.MDOPFNNFLFB, pBAIKHKBHBG.MHLDJIABNFI);
		pBAIKHKBHBG.PJPHFMECEHH = NADNBCMGLBF.mechDefinition.probabilityOfRealShot;
		GGKGGMNIDMI[0].ShootBatch(pBAIKHKBHBG.KPICOKPHMIC, pBAIKHKBHBG.MDOPFNNFLFB + JACPGMNIHEK, (int)((double)pBAIKHKBHBG.HLAKECBLNJL * 0.5), pBAIKHKBHBG.PJPHFMECEHH, pBAIKHKBHBG.MGDGFBCJINH);
		InvokeAfter(pBAIKHKBHBG.LJCDGJKCNEC, (float)GGKGGMNIDMI[1].JMMJHCOKCGG.JMDLKIAKOIE * 0.5f);
	}

	private void DOEFKFOGDOE()
	{
		if (JDGADCDMFHM != null && OGGHKAKGMFE == LLEHEFACLDA.Idle)
		{
			mMechAnimator.DPJBABCHFBK();
			LCCDGBJLKJP();
		}
	}

	private void LAIGPKANOPC()
	{
		if (PCEHMPNPHOC.IsEnemyPointReached(base.transform.position))
		{
			mMechAnimator.Idle();
			OGGHKAKGMFE = LLEHEFACLDA.Idle;
			InvokeAfter(ACFGMICIACP, 3f);
		}
		mMechAnimator.LookAt(JDGADCDMFHM.transform.position, true);
		if (Time.time > HJEJNIJPFHF)
		{
			LCCDGBJLKJP();
			mMechAnimator.Shoot();
			HJEJNIJPFHF = float.MaxValue;
		}
	}

	private void EMPGAHCMPHP()
	{
		if (PCEHMPNPHOC.MOKMCBFCMFJ(base.transform.position))
		{
			PickTarget(false, false);
			mMechAnimator.AOFDHIJFKIN();
			InvokeAfter(ACFGMICIACP, 1601f);
			OGGHKAKGMFE = (LLEHEFACLDA)6;
		}
		if (Time.time > HJEJNIJPFHF && base.isInField)
		{
			if (PickTarget(true, false))
			{
				OGGHKAKGMFE = (LLEHEFACLDA)6;
				mMechAnimator.FCNCECBBHMK();
				mAgent.Disable();
				InvokeAfter(OIOKDDNJFNA, 374f);
				HJEJNIJPFHF = 1162f;
			}
			else
			{
				HJEJNIJPFHF = Time.time + 1715f;
			}
		}
	}

	private void IBFEFKHAGIH()
	{
		mMechAnimator.StopShoot();
		HJEJNIJPFHF = Time.time + UnityEngine.Random.Range(NADNBCMGLBF.mechDefinition.minShootTime, NADNBCMGLBF.mechDefinition.maxShootTime);
	}

	public virtual void IEJGJBFLODO(List<AudioSource> FJGIGBNDCFE)
	{
		base.GetAudioSources(FJGIGBNDCFE);
		if (mMechAnimator != null)
		{
			FJGIGBNDCFE.Add(mMechAnimator.FDMAOLNCKIB);
		}
	}

	private void KPKKLHGBJLL()
	{
		mMechAnimator.KJCNAHNPECH();
		mMechAnimator.LookAt(base.transform.position + base.transform.forward, true);
		HJEJNIJPFHF = Time.time + UnityEngine.Random.Range(NADNBCMGLBF.PNBAIFEINJI().minShootTime, NADNBCMGLBF.MACHBLIOHKK().maxShootTime);
		mAgent.CAGPIECMNFF(PCEHMPNPHOC.PBFDGDPLFKN());
		OGGHKAKGMFE = LLEHEFACLDA.Strafe;
		JDGADCDMFHM = null;
	}

	private void AANLNCLMLGF()
	{
		if (PCEHMPNPHOC.EPDKLCKBPEK(base.transform.position))
		{
			PickTarget(true, false);
			mMechAnimator.FHBKHHCHBDA();
			InvokeAfter(ACFGMICIACP, 1356f);
			OGGHKAKGMFE = (LLEHEFACLDA)8;
		}
		if (Time.time > HJEJNIJPFHF && base.isInField)
		{
			if (PickTarget(true, true))
			{
				OGGHKAKGMFE = LLEHEFACLDA.Strafe;
				mMechAnimator.PDCMDKEDLCH();
				mAgent.Disable();
				InvokeAfter(KPKKLHGBJLL, 1000f);
				HJEJNIJPFHF = 353f;
			}
			else
			{
				HJEJNIJPFHF = Time.time + 71f;
			}
		}
	}

	private void LCCDGBJLKJP()
	{
		Vector3 jACPGMNIHEK = default(Vector3);
		Vector3 kDCJNCKOIHB = default(Vector3);
		Vector3 vector = default(Vector3);
		PlayerController playerController = JDGADCDMFHM.owner as PlayerController;
		GameShootableEntity.ShotTarget shotTarget = null;
		GameShootableEntity.ShotTarget shotTarget2 = null;
		if (playerController != null)
		{
			float num = GeometryTools.AngleSigned(playerController.aimForward, base.transform.position - JDGADCDMFHM.mTransform.position, Vector3.up);
			if (Mathf.Abs(num) < 50f && playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				if (UnityEngine.Random.value < ACLDFHJKBLI.upgradeSlots.shieldHitProbability)
				{
					List<GameShootableEntity.ShotTarget> shotTargets = JDGADCDMFHM.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Shield);
					shotTarget = shotTargets[0];
					shotTarget2 = shotTargets[0];
				}
				else
				{
					List<GameShootableEntity.ShotTarget> shotTargets2 = JDGADCDMFHM.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.WholeBody);
					shotTarget = shotTargets2[1];
					shotTarget2 = shotTargets2[0];
					if (Mathf.Abs(num) > 20f)
					{
						Vector3 lhs = shotTarget.transform.position - base.transform.position;
						lhs = lhs.ReplaceXY(0f, 0f).normalized * 0.1f;
						jACPGMNIHEK = ((!(num > 0f)) ? Vector3.zero : lhs);
						kDCJNCKOIHB = ((!(num <= 0f)) ? Vector3.zero : lhs);
					}
				}
			}
			else if (playerController.playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				shotTarget = JDGADCDMFHM.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Moving, base.transform.position);
				shotTarget2 = shotTarget;
			}
			else
			{
				shotTarget = JDGADCDMFHM.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.WholeBody, base.transform.position);
				shotTarget2 = shotTarget;
			}
			MDKABJDCKBI(playerController.FOCIOKMPCAG.velocity, shotTarget, shotTarget2, jACPGMNIHEK, kDCJNCKOIHB);
		}
		else
		{
			shotTarget = JDGADCDMFHM.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.AllIn, base.transform.position);
			MDKABJDCKBI(Vector3.zero, shotTarget, shotTarget, jACPGMNIHEK, kDCJNCKOIHB);
		}
	}

	protected virtual void IODGCIIDJEK()
	{
		base.Update();
		if (PCEHMPNPHOC != null)
		{
			switch (OGGHKAKGMFE)
			{
			case LLEHEFACLDA.Walk:
				AANLNCLMLGF();
				break;
			case LLEHEFACLDA.Strafe:
				LAIGPKANOPC();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case LLEHEFACLDA.Shoot:
			case LLEHEFACLDA.Idle:
				break;
			}
		}
		if (!LAADDLGBFIG.isMine && Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			LADBLHGBOKJ.EMPDDFBNJLP(base.transform);
		}
	}

	private void GDGAJLOAMMG()
	{
		mMechAnimator.BCGBDLJHJEE();
		HJEJNIJPFHF = Time.time + UnityEngine.Random.Range(NADNBCMGLBF.EKKFDPDMIJM().minShootTime, NADNBCMGLBF.JAOIJLBHMKK().maxShootTime);
	}

	protected virtual void NHEOMLPEBLC()
	{
		base.Update();
		if (PCEHMPNPHOC != null)
		{
			switch (OGGHKAKGMFE)
			{
			case LLEHEFACLDA.Walk:
				EMPGAHCMPHP();
				break;
			case LLEHEFACLDA.Strafe:
				LAIGPKANOPC();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case LLEHEFACLDA.Shoot:
			case LLEHEFACLDA.Idle:
				break;
			}
		}
		if (!LAADDLGBFIG.isMine && Singleton<GameController>.instance.gameIsRunning)
		{
			LADBLHGBOKJ.JAFBNNAACCL(base.transform);
		}
	}

	public override void Spawn()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.DMCDJGLDICM.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			if (AcceptSpawnPoint(item))
			{
				base.transform.position = item.transform.position;
				break;
			}
		}
	}

	protected virtual void OFNEGNKMKKG()
	{
		base.Update();
		if (PCEHMPNPHOC != null)
		{
			switch (OGGHKAKGMFE)
			{
			case LLEHEFACLDA.Walk:
				IHOMFDFENMH();
				break;
			case LLEHEFACLDA.Strafe:
				LAIGPKANOPC();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case LLEHEFACLDA.Shoot:
			case LLEHEFACLDA.Idle:
				break;
			}
		}
		if (!LAADDLGBFIG.isMine && Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			LADBLHGBOKJ.PHABEKGALCE(base.transform);
		}
	}

	private void ALFJBBCBEMH()
	{
		Vector3 jACPGMNIHEK = default(Vector3);
		Vector3 kDCJNCKOIHB = default(Vector3);
		Vector3 vector = default(Vector3);
		PlayerController playerController = JDGADCDMFHM.owner as PlayerController;
		GameShootableEntity.ShotTarget shotTarget = null;
		GameShootableEntity.ShotTarget shotTarget2 = null;
		if (playerController != null)
		{
			float num = GeometryTools.AngleSigned(playerController.aimForward, base.transform.position - JDGADCDMFHM.MEGABPHJFLL().position, Vector3.up);
			if (Mathf.Abs(num) < 1579f && playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				if (UnityEngine.Random.value < ACLDFHJKBLI.upgradeSlots.shieldHitProbability)
				{
					List<GameShootableEntity.ShotTarget> shotTargets = JDGADCDMFHM.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.None);
					shotTarget = shotTargets[1];
					shotTarget2 = shotTargets[1];
				}
				else
				{
					List<GameShootableEntity.ShotTarget> shotTargets2 = JDGADCDMFHM.GetShotTargets((GameShootableEntity.LAAAMBBNIJO)99);
					shotTarget = shotTargets2[0];
					shotTarget2 = shotTargets2[1];
					if (Mathf.Abs(num) > 1579f)
					{
						Vector3 lhs = shotTarget.transform.position - base.transform.position;
						lhs = lhs.ReplaceXY(1570f, 1657f).normalized * 1898f;
						jACPGMNIHEK = ((!(num > 441f)) ? Vector3.zero : lhs);
						kDCJNCKOIHB = ((!(num <= 25f)) ? Vector3.zero : lhs);
					}
				}
			}
			else if (playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking)
			{
				shotTarget = JDGADCDMFHM.AJBDIKBDLEA(GameShootableEntity.LAAAMBBNIJO.Shield, base.transform.position);
				shotTarget2 = shotTarget;
			}
			else
			{
				shotTarget = JDGADCDMFHM.AJBDIKBDLEA(~GameShootableEntity.LAAAMBBNIJO.Out, base.transform.position);
				shotTarget2 = shotTarget;
			}
			MDKABJDCKBI(playerController.FOCIOKMPCAG.velocity, shotTarget, shotTarget2, jACPGMNIHEK, kDCJNCKOIHB);
		}
		else
		{
			shotTarget = JDGADCDMFHM.AJBDIKBDLEA((GameShootableEntity.LAAAMBBNIJO)83, base.transform.position);
			MDKABJDCKBI(Vector3.zero, shotTarget, shotTarget, jACPGMNIHEK, kDCJNCKOIHB);
		}
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		mDestroyableObject.maxHealth = NADNBCMGLBF.mechDefinition.health;
		mDestroyableObject.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		mDestroyableObject.RefillOffline();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.JMMJHCOKCGG.ammoSetup.EPDELOGPNAC = NADNBCMGLBF.mechDefinition.damage;
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.JPNAINOGAMM = NADNBCMGLBF.mechDefinition.shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.ILOHAHFIOKM();
	}

	protected virtual void ABMKKECEGIB()
	{
		base.Awake();
		mDestroyableObject.AEJBIHBEOCP = false;
		mDestroyableObject.OnDeath += BFHJDJCFBAI;
		mDestroyableObject.OnDamage += LHNJAKKMNAD;
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.JMMJHCOKCGG.owner = this;
		}
		GGKGGMNIDMI[1].NEJBJHKMLMM(GDGAJLOAMMG);
		MechAnimator mechAnimator = mMechAnimator;
		mechAnimator.OJMHOPLCMFI = (Action)Delegate.Combine(mechAnimator.OJMHOPLCMFI, new Action(EBIINOEBJIJ));
	}

	public virtual bool EPHEOFGBDPD(SpawnPoint PLMMBKGLGAB)
	{
		return PLMMBKGLGAB.APMKFCIEBAF != SpawnPoint.PGMEFLECCPH.Normal || fraction == PLMMBKGLGAB.JCFMEBFCGJI();
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.PAJFENKBCLF(base.transform, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void LHNJAKKMNAD(DestroyableObject JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
	}

	private void IHOMFDFENMH()
	{
		if (PCEHMPNPHOC.IsEnemyPointReached(base.transform.position))
		{
			PickTarget(true, false);
			mMechAnimator.Idle();
			InvokeAfter(ACFGMICIACP, 3f);
			OGGHKAKGMFE = LLEHEFACLDA.Idle;
		}
		if (Time.time > HJEJNIJPFHF && base.isInField)
		{
			if (PickTarget(true, true))
			{
				OGGHKAKGMFE = LLEHEFACLDA.Shoot;
				mMechAnimator.Idle();
				mAgent.Disable();
				InvokeAfter(OIOKDDNJFNA, 3f);
				HJEJNIJPFHF = float.MaxValue;
			}
			else
			{
				HJEJNIJPFHF = Time.time + 2.5f;
			}
		}
	}

	public bool PickTarget(bool JJAEHBIOEHK, bool JJFKFKAEOOD)
	{
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(fraction);
		JDGADCDMFHM = randomEnemy.gameShootableEntity;
		bool flag = false;
		if (JJFKFKAEOOD)
		{
			flag = BIBOEDCOKAA(JDGADCDMFHM.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Shield, base.transform.position).transform.position);
		}
		if (JJAEHBIOEHK && flag)
		{
			mMechAnimator.LookAt(JDGADCDMFHM.transform.position, false);
		}
		return flag;
	}

	private void ADPKJNEKLPH(DestroyableObject JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
	}

	public virtual bool AcceptSpawnPoint(SpawnPoint PLMMBKGLGAB)
	{
		return PLMMBKGLGAB.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Normal && fraction == PLMMBKGLGAB.fraction;
	}

	[SpecialName]
	public virtual DestroyableObject BMCHFNKIPJD()
	{
		return mDestroyableObject;
	}

	public virtual void AEHFNIMENDJ()
	{
		base.DestroyPooled();
		mMechAnimator.JNNPIDJBJPH();
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	private void OIOKDDNJFNA()
	{
		mMechAnimator.Walk();
		mMechAnimator.LookAt(base.transform.position + base.transform.forward, false);
		HJEJNIJPFHF = Time.time + UnityEngine.Random.Range(NADNBCMGLBF.mechDefinition.minShootTime, NADNBCMGLBF.mechDefinition.maxShootTime);
		mAgent.SetDestination(PCEHMPNPHOC.position);
		OGGHKAKGMFE = LLEHEFACLDA.Walk;
		JDGADCDMFHM = null;
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		mMechAnimator.Disable();
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mDestroyableObject.AEJBIHBEOCP = true;
		mDestroyableObject.OnDeath += BFHJDJCFBAI;
		mDestroyableObject.OnDamage += LHNJAKKMNAD;
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.JMMJHCOKCGG.owner = this;
		}
		GGKGGMNIDMI[0].ShootEnded += IBFEFKHAGIH;
		MechAnimator mechAnimator = mMechAnimator;
		mechAnimator.OJMHOPLCMFI = (Action)Delegate.Combine(mechAnimator.OJMHOPLCMFI, new Action(EBIINOEBJIJ));
	}

	private void ACFGMICIACP()
	{
		FENCJADHNLB(false);
		bool hIOHPOMALHE = Vector3.Cross(JDGADCDMFHM.transform.position - base.transform.position, PCEHMPNPHOC.position - base.transform.position).y < 0f;
		mMechAnimator.Strafe(hIOHPOMALHE);
		OGGHKAKGMFE = LLEHEFACLDA.Strafe;
		mAgent.speed = HHFPGODMJDJ;
		HJEJNIJPFHF = Time.time + UnityEngine.Random.Range(NADNBCMGLBF.mechDefinition.minShootTime, NADNBCMGLBF.mechDefinition.maxShootTime);
	}

	public virtual void DNLMPCLKOBL()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.DMCDJGLDICM.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			if (EPHEOFGBDPD(item))
			{
				base.transform.position = item.transform.position;
				break;
			}
		}
	}

	private void FENCJADHNLB(bool KANKDLBGMLK)
	{
		List<EnemyPoint> points = SpawningManager.instance.GetPoints(EnemyPoint.LJGGJMAFEBN.Mech, PCEHMPNPHOC, fraction);
		if (PCEHMPNPHOC != null)
		{
			PCEHMPNPHOC.IDNNIHBIMNO = null;
		}
		EnemyPoint enemyPoint = points[UnityEngine.Random.Range(0, points.Count)];
		if (KANKDLBGMLK)
		{
			points.Sort((EnemyPoint HPJFBKEKJHB, EnemyPoint NCMHGPNPEJM) => Vector3.Distance(HPJFBKEKJHB.position, base.transform.position).CompareTo(Vector3.Distance(NCMHGPNPEJM.position, base.transform.position)));
			enemyPoint = points[0];
		}
		enemyPoint.IDNNIHBIMNO = this;
		PCEHMPNPHOC = enemyPoint;
		mAgent.SetDestination(enemyPoint.position);
	}

	protected override void Update()
	{
		base.Update();
		if (PCEHMPNPHOC != null)
		{
			switch (OGGHKAKGMFE)
			{
			case LLEHEFACLDA.Walk:
				IHOMFDFENMH();
				break;
			case LLEHEFACLDA.Strafe:
				LAIGPKANOPC();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case LLEHEFACLDA.Shoot:
			case LLEHEFACLDA.Idle:
				break;
			}
		}
		if (!LAADDLGBFIG.isMine && Singleton<GameController>.instance.gameIsRunning)
		{
			LADBLHGBOKJ.NFGMGBMCNOF(base.transform);
		}
	}

	public override void StartEnemyBehaviour()
	{
		base.StartEnemyBehaviour();
		FENCJADHNLB(true);
		mMechAnimator.Walk();
		mAgent.speed = base.currentBeh.mechDefinition.speed;
		OGGHKAKGMFE = LLEHEFACLDA.Walk;
		HJEJNIJPFHF = Time.time + 5f;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.Reset();
		}
		JDGADCDMFHM = null;
		mMechAnimator.Reset();
		mAgent.Disable();
		IAICPGNGCJI = ACLDFHJKBLI.totalPower;
		if (LCDBACDIODH)
		{
			mMechAnimator.PreviewIdle();
		}
		else
		{
			mMechAnimator.Idle();
		}
	}

	public override void MCAAIAJONDM()
	{
		base.UpgradesLoaded();
		mDestroyableObject.maxHealth = NADNBCMGLBF.APALDODNMLJ().health;
		mDestroyableObject.HHOCGCLBHKB = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-82)).FLOATVALUE;
		mDestroyableObject.RefillOffline();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.JMMJHCOKCGG.ammoSetup.EPDELOGPNAC = NADNBCMGLBF.HNPOKNFOBDO().damage;
			BulletSetup bulletSetup = (BulletSetup)item.JMMJHCOKCGG.ammoSetup;
			bulletSetup.JPNAINOGAMM = NADNBCMGLBF.EANCDAANAOD().shotSpeed;
			bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
			bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		}
	}

	public override void GetAudioSources(List<AudioSource> FJGIGBNDCFE)
	{
		base.GetAudioSources(FJGIGBNDCFE);
		if (mMechAnimator != null)
		{
			FJGIGBNDCFE.Add(mMechAnimator.FDMAOLNCKIB);
		}
	}

	private void BFHJDJCFBAI(DestroyableObject ENCEFOOPBMK, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.isAlive)
		{
			Singleton<HitParticleSystem>.instance.PlayParticles(base.transform.position + base.transform.up * 0.2f, Vector3.up, "metalExplosion", "grenadeExplosion");
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = 350f;
			pKDCCCNJIEC.EPDELOGPNAC = 40f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.GCHFGHAGJDG(nOCEDALFEJM);
			mMechAnimator.StopWalkSound();
			DPFHODDILIF(OHJPPHFEAFI);
			CDCOFHGPJHN(0.2f);
		}
	}

	public virtual void GACJFNEBJID()
	{
		base.OnInstancied();
		foreach (BatchedWeapon item in GGKGGMNIDMI)
		{
			item.LDBLCPIGLOF();
		}
		JDGADCDMFHM = null;
		mMechAnimator.PKMIJKOPPBF();
		mAgent.Disable();
		IAICPGNGCJI = ACLDFHJKBLI.totalPower;
		if (LCDBACDIODH)
		{
			mMechAnimator.EBEAIJACLGA();
		}
		else
		{
			mMechAnimator.FHBKHHCHBDA();
		}
	}

	private void EBIINOEBJIJ()
	{
		if (JDGADCDMFHM != null && OGGHKAKGMFE == LLEHEFACLDA.Shoot)
		{
			mMechAnimator.Shoot();
			LCCDGBJLKJP();
		}
	}
}
