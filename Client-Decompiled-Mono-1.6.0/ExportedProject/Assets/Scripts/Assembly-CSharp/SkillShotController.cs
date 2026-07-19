using UnityEngine;
using UnityEngine.Serialization;

public class SkillShotController : Core_BaseScript
{
	protected NKMKCCDCHCL GPPBACMGKFF;

	[FormerlySerializedAs("mPosition")]
	public Transform JEGEBJNNHME;

	protected PhotonView FEHCCGEGPLH;

	private bool NKMHKCKNANP;

	protected void JPDBCDENCBJ(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.MCJOOEEIIHI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.MEJCBPLAJHN(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.JDKHGMBPMOE();
			}
		}
	}

	protected void KPMJHLHEJEP(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.ALODNGEMIMO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.DBHKNGGFNPC(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.JKNIENJHNEP();
			}
		}
	}

	protected virtual void KNLKFOHBCKI()
	{
		base.Awake();
		GPPBACMGKFF = GetComponentImplementing<NKMKCCDCHCL>();
		GPPBACMGKFF.Killed += OCEAOOPIKHD;
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	protected virtual void ABMKKECEGIB()
	{
		base.Awake();
		GPPBACMGKFF = GetComponentImplementing<NKMKCCDCHCL>();
		GPPBACMGKFF.Killed += LIOHABPCFDK;
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	protected virtual void ILIBPDHNEJE(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.KLOJNPBGFIG)
		{
			return;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		if (playerController != null)
		{
			SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.HeadShot;
			float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
			if (KMJKKNFDFMM.CCFJFAMEODO)
			{
				skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
			}
			if (GPPBACMGKFF is EnemyController)
			{
				EnemyController enemyController = GPPBACMGKFF as EnemyController;
				skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
				if (enemyController.JCKHCELHDBH)
				{
					skillShotType |= SkillShot.SkillShotType.None;
				}
				if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
				{
					skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
				}
				if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame)
				{
					skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
				}
				if (enemyController.IFCAIEPFEAP())
				{
					skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
				}
				if (enemyController.isRunning)
				{
					skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner;
				}
				if (enemyController.isRevengeKill)
				{
					skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill;
				}
			}
			if (GPPBACMGKFF is Drone)
			{
				Drone drone = GPPBACMGKFF as Drone;
				skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
				skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
				if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
				{
					skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
				}
				if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal)
				{
					skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.DoubleKill;
				}
				if (drone.isRevengeKill)
				{
					skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
				}
			}
			if (GPPBACMGKFF is Tank)
			{
				Tank tank = GPPBACMGKFF as Tank;
				skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
				skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
				skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill;
				if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
				{
					skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot);
				}
				if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal)
				{
					skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
				}
				if (tank.isRevengeKill)
				{
					skillShotType |= SkillShot.SkillShotType.LongShot;
				}
			}
			if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
			{
				AIObject aIObject = GPPBACMGKFF as AIObject;
				skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
				skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered;
				if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
				{
					skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill);
				}
				if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame)
				{
					skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill;
				}
				if (aIObject.isRevengeKill)
				{
					skillShotType |= SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill;
				}
			}
			if (Time.timeScale < 1150f)
			{
				skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
			}
			if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
			{
				skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner;
			}
			NKMHKCKNANP = playerController.isCurrentPlayer;
			SkillShot skillShot = new SkillShot();
			skillShot.type = skillShotType;
			SkillShot IFDBMJEAGND = skillShot;
			Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
			if (playerController.fraction != MAIPDGCABNL.fraction)
			{
				Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
				if (NKMHKCKNANP)
				{
					HFBEKIFGIBC(IFDBMJEAGND, !KMJKKNFDFMM.NLJFIIEGHCK || playerController.fraction == GPPBACMGKFF.fraction, MAIPDGCABNL.power);
				}
				else
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[8];
					array[1] = (int)IFDBMJEAGND.type;
					array[0] = MAIPDGCABNL.power;
					array[5] = playerController.NAGAHNHAKBJ;
					fEHCCGEGPLH.RPC("ID_ARENAWINSREWARDS", PhotonTargets.All, array);
				}
			}
			if (GPPBACMGKFF is AIObject)
			{
				StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LJELEJEJIEB().MKEBHAJCGIM()
					.indexInLevelManager);
				}
				return;
			}
			NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
			if (nKMKCCDCHCL != null)
			{
				GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
				GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
				if (nKMKCCDCHCL.fraction != fraction2)
				{
					SkillShot.SkillShotType skillShotType2 = ~(SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
					if (fraction2 != fraction)
					{
						SkillShot skillShot = new SkillShot();
						skillShot.type = skillShotType2;
						SkillShot iFDBMJEAGND = skillShot;
						OHDJKOEHNPL(iFDBMJEAGND, false, GPPBACMGKFF.power);
						Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
					}
					else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
					{
						PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
						object[] array2 = new object[8];
						array2[1] = (int)skillShotType2;
						array2[1] = GPPBACMGKFF.power;
						array2[6] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
						fEHCCGEGPLH2.RPC("ID_WARNING_ACCOUNTALREADYCREATED", PhotonTargets.Others, array2);
						Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
						{
							type = skillShotType2
						}, Singleton<GameController>.instance.opponent);
					}
				}
				return;
			}
			GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
			GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
			if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion))
			{
				SkillShot.SkillShotType skillShotType3 = SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.MultiKill;
				if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
				{
					skillShotType3 |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered;
				}
				SkillShot skillShot = new SkillShot();
				skillShot.type = skillShotType3;
				SkillShot iFDBMJEAGND2 = skillShot;
				DNLPPDHGHCA(iFDBMJEAGND2, false, GPPBACMGKFF.power);
				Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
			}
		}

		protected virtual void OHHLNKPIHBH()
		{
			base.Awake();
			GPPBACMGKFF = GetComponentImplementing<NKMKCCDCHCL>();
			GPPBACMGKFF.Killed += CMGDJBHBJIB;
			FEHCCGEGPLH = GetComponent<PhotonView>();
		}

		protected void PMJDCCCADFM(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
		{
			SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
			if (skillShotDisplayer != null)
			{
				Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
				skillShotDisplayer.transform.position = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
				skillShotDisplayer.PlayDeath(APLODBKLDEG, IFDBMJEAGND);
				if (NLJFIIEGHCK)
				{
					skillShotDisplayer.PlayCritical();
				}
			}
		}

		protected override void Awake()
		{
			base.Awake();
			GPPBACMGKFF = GetComponentImplementing<NKMKCCDCHCL>();
			GPPBACMGKFF.Killed += CHBCMIDNBBM;
			FEHCCGEGPLH = GetComponent<PhotonView>();
		}

		protected void HHAEOGGEHKA(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
		{
			SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
			if (skillShotDisplayer != null)
			{
				Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
				skillShotDisplayer.transform.position = HealthBarManager.ICPEKOGEEEN().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
				skillShotDisplayer.DCDAPPKAMCO(APLODBKLDEG, IFDBMJEAGND);
				if (NLJFIIEGHCK)
				{
					skillShotDisplayer.JKNIENJHNEP();
				}
			}
		}

		protected virtual void IOAEHDJGBJC()
		{
			base.Awake();
			GPPBACMGKFF = GetComponentImplementing<NKMKCCDCHCL>();
			GPPBACMGKFF.Killed += GAPCKFFNOJE;
			FEHCCGEGPLH = GetComponent<PhotonView>();
		}

		protected void CHEFPDJMDKO(int FJLBLLLEELD, int APLODBKLDEG, int EJBEDLHIKDG)
		{
			SkillShot skillShot = new SkillShot();
			skillShot.type = (SkillShot.SkillShotType)FJLBLLLEELD;
			SkillShot iFDBMJEAGND = skillShot;
			JFMBCPCBMHJ(iFDBMJEAGND, false, APLODBKLDEG);
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.JFGDAKMCJAM[EJBEDLHIKDG]);
		}

		protected virtual void CMGDJBHBJIB(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
		{
			if (KMJKKNFDFMM.KLOJNPBGFIG)
			{
				return;
			}
			PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
			if (playerController != null)
			{
				SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.None;
				float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
				if (KMJKKNFDFMM.CCFJFAMEODO)
				{
					skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
				}
				if (GPPBACMGKFF is EnemyController)
				{
					EnemyController enemyController = GPPBACMGKFF as EnemyController;
					skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
					if (enemyController.JCKHCELHDBH)
					{
						skillShotType |= SkillShot.SkillShotType.HeadShot;
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
					{
						skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic)
					{
						skillShotType |= ~(SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
					}
					if (enemyController.KMPAPJDAPFK())
					{
						skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
					}
					if (enemyController.isRunning)
					{
						skillShotType |= SkillShot.SkillShotType.LongShot;
					}
					if (enemyController.isRevengeKill)
					{
						skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill);
					}
				}
				if (GPPBACMGKFF is Drone)
				{
					Drone drone = GPPBACMGKFF as Drone;
					skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
					skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill;
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
					{
						skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal)
					{
						skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
					}
					if (drone.isRevengeKill)
					{
						skillShotType |= SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill;
					}
				}
				if (GPPBACMGKFF is Tank)
				{
					Tank tank = GPPBACMGKFF as Tank;
					skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill;
					skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill);
					skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
					{
						skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal)
					{
						skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill);
					}
					if (tank.isRevengeKill)
					{
						skillShotType |= ~SkillShot.SkillShotType.OneHitKill;
					}
				}
				if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
				{
					AIObject aIObject = GPPBACMGKFF as AIObject;
					skillShotType |= ~(SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
					skillShotType |= ~SkillShot.SkillShotType.HeadShot;
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
					{
						skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
					{
						skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill;
					}
					if (aIObject.isRevengeKill)
					{
						skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.OneHitKill;
					}
				}
				if (Time.timeScale < 233f)
				{
					skillShotType |= ~(SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
				}
				if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
				{
					skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
				}
				NKMHKCKNANP = playerController.isCurrentPlayer;
				SkillShot skillShot = new SkillShot();
				skillShot.type = skillShotType;
				SkillShot IFDBMJEAGND = skillShot;
				Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
				if (playerController.fraction != MAIPDGCABNL.fraction)
				{
					Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
					if (NKMHKCKNANP)
					{
						FMECIHJFIJO(IFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK && playerController.fraction == GPPBACMGKFF.fraction, MAIPDGCABNL.power);
					}
					else
					{
						PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
						object[] array = new object[3];
						array[1] = (int)IFDBMJEAGND.type;
						array[1] = MAIPDGCABNL.power;
						array[1] = playerController.NAGAHNHAKBJ;
						fEHCCGEGPLH.RPC("ID_WARNING_NOTEXISTINGSQUAD", PhotonTargets.Others, array);
					}
				}
				if (GPPBACMGKFF is AIObject)
				{
					StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().currentWeapon.AHIDNLGBAJP().indexInLevelManager);
				}
				return;
			}
			NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
			if (nKMKCCDCHCL != null)
			{
				GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
				GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
				if (nKMKCCDCHCL.fraction != fraction2)
				{
					SkillShot.SkillShotType skillShotType2 = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
					if (fraction2 != fraction)
					{
						SkillShot skillShot = new SkillShot();
						skillShot.type = skillShotType2;
						SkillShot iFDBMJEAGND = skillShot;
						NPEPOIPBMJN(iFDBMJEAGND, false, GPPBACMGKFF.power);
						Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
					}
					else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
					{
						PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
						object[] array2 = new object[6];
						array2[0] = (int)skillShotType2;
						array2[1] = GPPBACMGKFF.power;
						array2[8] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
						fEHCCGEGPLH2.RPC("shotReal", PhotonTargets.All, array2);
						Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
						{
							type = skillShotType2
						}, Singleton<GameController>.instance.opponent);
					}
				}
				return;
			}
			GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
			GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
			if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot))
			{
				SkillShot.SkillShotType skillShotType3 = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
				if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
				{
					skillShotType3 |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill);
				}
				SkillShot skillShot = new SkillShot();
				skillShot.type = skillShotType3;
				SkillShot iFDBMJEAGND2 = skillShot;
				HHAEOGGEHKA(iFDBMJEAGND2, false, GPPBACMGKFF.power);
				Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
			}
		}

		protected void LLLPAMIJOBJ(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
		{
			SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
			if (skillShotDisplayer != null)
			{
				Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
				skillShotDisplayer.transform.position = HealthBarManager.ALODNGEMIMO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
				skillShotDisplayer.DKJAELPHKNJ(APLODBKLDEG, IFDBMJEAGND);
				if (NLJFIIEGHCK)
				{
					skillShotDisplayer.MDKGJKMGOJI();
				}
			}
		}

		protected virtual void IABJJOPLKFF()
		{
			base.Awake();
			GPPBACMGKFF = GetComponentImplementing<NKMKCCDCHCL>();
			GPPBACMGKFF.Killed += EAAAJPGBJOA;
			FEHCCGEGPLH = GetComponent<PhotonView>();
		}

		protected virtual void GBGDKNIMGMB()
		{
			base.Awake();
			GPPBACMGKFF = GetComponentImplementing<NKMKCCDCHCL>();
			GPPBACMGKFF.Killed += KOMCKAFKCML;
			FEHCCGEGPLH = GetComponent<PhotonView>();
		}

		protected void CHIMCDAHFAJ(int FJLBLLLEELD, int APLODBKLDEG, int EJBEDLHIKDG)
		{
			SkillShot skillShot = new SkillShot();
			skillShot.type = (SkillShot.SkillShotType)FJLBLLLEELD;
			SkillShot iFDBMJEAGND = skillShot;
			PMJDCCCADFM(iFDBMJEAGND, false, APLODBKLDEG);
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.JFGDAKMCJAM[EJBEDLHIKDG]);
		}

		protected void FMECIHJFIJO(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
		{
			SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
			if (skillShotDisplayer != null)
			{
				Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
				skillShotDisplayer.transform.position = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
				skillShotDisplayer.PlayDeath(APLODBKLDEG, IFDBMJEAGND);
				if (NLJFIIEGHCK)
				{
					skillShotDisplayer.JDKHGMBPMOE();
				}
			}
		}

		protected void HNIBEBCMOID(int FJLBLLLEELD, int APLODBKLDEG, int EJBEDLHIKDG)
		{
			SkillShot skillShot = new SkillShot();
			skillShot.type = (SkillShot.SkillShotType)FJLBLLLEELD;
			SkillShot iFDBMJEAGND = skillShot;
			DNLPPDHGHCA(iFDBMJEAGND, false, APLODBKLDEG);
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.JFGDAKMCJAM[EJBEDLHIKDG]);
		}

		protected virtual void CHBCMIDNBBM(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
		{
			if (KMJKKNFDFMM.KLOJNPBGFIG)
			{
				return;
			}
			PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
			if (playerController != null)
			{
				SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.None;
				float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
				if (KMJKKNFDFMM.CCFJFAMEODO)
				{
					skillShotType |= SkillShot.SkillShotType.OneHitKill;
				}
				if (GPPBACMGKFF is EnemyController)
				{
					EnemyController enemyController = GPPBACMGKFF as EnemyController;
					skillShotType |= SkillShot.SkillShotType.Kill;
					if (enemyController.JCKHCELHDBH)
					{
						skillShotType |= SkillShot.SkillShotType.HeadShot;
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
					{
						skillShotType |= SkillShot.SkillShotType.ExplosiveKill;
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic)
					{
						skillShotType |= SkillShot.SkillShotType.EnviromentalKill;
					}
					if (enemyController.isCovered)
					{
						skillShotType |= SkillShot.SkillShotType.Covered;
					}
					if (enemyController.isRunning)
					{
						skillShotType |= SkillShot.SkillShotType.Runner;
					}
					if (enemyController.isRevengeKill)
					{
						skillShotType |= SkillShot.SkillShotType.RevengeKill;
					}
				}
				if (GPPBACMGKFF is Drone)
				{
					Drone drone = GPPBACMGKFF as Drone;
					skillShotType |= SkillShot.SkillShotType.Kill;
					skillShotType |= SkillShot.SkillShotType.VehicleDestroyed;
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
					{
						skillShotType |= SkillShot.SkillShotType.ExplosiveKill;
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic)
					{
						skillShotType |= SkillShot.SkillShotType.EnviromentalKill;
					}
					if (drone.isRevengeKill)
					{
						skillShotType |= SkillShot.SkillShotType.RevengeKill;
					}
				}
				if (GPPBACMGKFF is Tank)
				{
					Tank tank = GPPBACMGKFF as Tank;
					skillShotType |= SkillShot.SkillShotType.Kill;
					skillShotType |= SkillShot.SkillShotType.VehicleDestroyed;
					skillShotType |= SkillShot.SkillShotType.TankDestroyed;
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
					{
						skillShotType |= SkillShot.SkillShotType.ExplosiveKill;
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic)
					{
						skillShotType |= SkillShot.SkillShotType.EnviromentalKill;
					}
					if (tank.isRevengeKill)
					{
						skillShotType |= SkillShot.SkillShotType.RevengeKill;
					}
				}
				if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
				{
					AIObject aIObject = GPPBACMGKFF as AIObject;
					skillShotType |= SkillShot.SkillShotType.Kill;
					skillShotType |= SkillShot.SkillShotType.VehicleDestroyed;
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
					{
						skillShotType |= SkillShot.SkillShotType.ExplosiveKill;
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic)
					{
						skillShotType |= SkillShot.SkillShotType.EnviromentalKill;
					}
					if (aIObject.isRevengeKill)
					{
						skillShotType |= SkillShot.SkillShotType.RevengeKill;
					}
				}
				if (Time.timeScale < 0.4f)
				{
					skillShotType |= SkillShot.SkillShotType.SlowMotionKill;
				}
				if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
				{
					skillShotType |= SkillShot.SkillShotType.LongShot;
				}
				NKMHKCKNANP = playerController.isCurrentPlayer;
				SkillShot skillShot = new SkillShot();
				skillShot.type = skillShotType;
				SkillShot IFDBMJEAGND = skillShot;
				Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
				if (playerController.fraction != MAIPDGCABNL.fraction)
				{
					Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
					if (NKMHKCKNANP)
					{
						PMJDCCCADFM(IFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK && playerController.fraction != GPPBACMGKFF.fraction, MAIPDGCABNL.power);
					}
					else
					{
						FEHCCGEGPLH.RPC("RecieveSkillshot", PhotonTargets.Others, (int)IFDBMJEAGND.type, MAIPDGCABNL.power, playerController.NAGAHNHAKBJ);
					}
				}
				if (GPPBACMGKFF is AIObject)
				{
					StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.weaponInventory.currentWeapon.weaponLevelSetup.indexInLevelManager);
				}
				return;
			}
			NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
			if (nKMKCCDCHCL != null)
			{
				GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
				GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
				if (nKMKCCDCHCL.fraction != fraction2)
				{
					SkillShot.SkillShotType skillShotType2 = SkillShot.SkillShotType.ArmyKill;
					if (fraction2 != fraction)
					{
						SkillShot skillShot = new SkillShot();
						skillShot.type = skillShotType2;
						SkillShot iFDBMJEAGND = skillShot;
						PMJDCCCADFM(iFDBMJEAGND, false, GPPBACMGKFF.power);
						Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
					}
					else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
					{
						FEHCCGEGPLH.RPC("RecieveSkillshot", PhotonTargets.Others, (int)skillShotType2, GPPBACMGKFF.power, Singleton<GameController>.instance.opponent.NAGAHNHAKBJ);
						Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
						{
							type = skillShotType2
						}, Singleton<GameController>.instance.opponent);
					}
				}
				return;
			}
			GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
			GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
			if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion))
			{
				SkillShot.SkillShotType skillShotType3 = SkillShot.SkillShotType.Kill | SkillShot.SkillShotType.EnviromentalKill;
				if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
				{
					skillShotType3 |= SkillShot.SkillShotType.ExplosiveKill;
				}
				SkillShot skillShot = new SkillShot();
				skillShot.type = skillShotType3;
				SkillShot iFDBMJEAGND2 = skillShot;
				PMJDCCCADFM(iFDBMJEAGND2, false, GPPBACMGKFF.power);
				Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
			}
		}

		protected virtual void IFJMCNPOMNL(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
		{
			if (KMJKKNFDFMM.KLOJNPBGFIG)
			{
				return;
			}
			PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
			if (playerController != null)
			{
				SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.None;
				float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
				if (KMJKKNFDFMM.CCFJFAMEODO)
				{
					skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
				}
				if (GPPBACMGKFF is EnemyController)
				{
					EnemyController enemyController = GPPBACMGKFF as EnemyController;
					skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.MultiKill);
					if (enemyController.JCKHCELHDBH)
					{
						skillShotType |= SkillShot.SkillShotType.None;
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
					{
						skillShotType |= SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill;
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver)
					{
						skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
					}
					if (enemyController.KMPAPJDAPFK())
					{
						skillShotType |= SkillShot.SkillShotType.Runner;
					}
					if (enemyController.isRunning)
					{
						skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner;
					}
					if (enemyController.isRevengeKill)
					{
						skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
					}
				}
				if (GPPBACMGKFF is Drone)
				{
					Drone drone = GPPBACMGKFF as Drone;
					skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
					skillShotType |= ~(SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
					{
						skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
					{
						skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
					}
					if (drone.isRevengeKill)
					{
						skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill);
					}
				}
				if (GPPBACMGKFF is Tank)
				{
					Tank tank = GPPBACMGKFF as Tank;
					skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
					skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
					skillShotType |= ~SkillShot.SkillShotType.LongShot;
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
					{
						skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered;
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
					{
						skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill);
					}
					if (tank.isRevengeKill)
					{
						skillShotType |= ~(SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
					}
				}
				if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
				{
					AIObject aIObject = GPPBACMGKFF as AIObject;
					skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
					skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
					{
						skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
					}
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
					{
						skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
					}
					if (aIObject.isRevengeKill)
					{
						skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
					}
				}
				if (Time.timeScale < 1987f)
				{
					skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
				}
				if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
				{
					skillShotType |= SkillShot.SkillShotType.LongShot;
				}
				NKMHKCKNANP = playerController.isCurrentPlayer;
				SkillShot skillShot = new SkillShot();
				skillShot.type = skillShotType;
				SkillShot IFDBMJEAGND = skillShot;
				Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
				if (playerController.fraction != MAIPDGCABNL.fraction)
				{
					Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
					if (NKMHKCKNANP)
					{
						PMJDCCCADFM(IFDBMJEAGND, !KMJKKNFDFMM.NLJFIIEGHCK || playerController.fraction != GPPBACMGKFF.fraction, MAIPDGCABNL.power);
					}
					else
					{
						PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
						object[] array = new object[8];
						array[1] = (int)IFDBMJEAGND.type;
						array[1] = MAIPDGCABNL.power;
						array[6] = playerController.NAGAHNHAKBJ;
						fEHCCGEGPLH.RPC("ID_USEREXISTSGOOGLEPLAYTEXT", PhotonTargets.Others, array);
					}
				}
				if (GPPBACMGKFF is AIObject)
				{
					StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().JECOEJBGKDF().AHIDNLGBAJP()
						.indexInLevelManager);
					}
					return;
				}
				NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
				if (nKMKCCDCHCL != null)
				{
					GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
					GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
					if (nKMKCCDCHCL.fraction != fraction2)
					{
						SkillShot.SkillShotType skillShotType2 = SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.DoubleKill;
						if (fraction2 != fraction)
						{
							SkillShot skillShot = new SkillShot();
							skillShot.type = skillShotType2;
							SkillShot iFDBMJEAGND = skillShot;
							CJJEHMEHDPC(iFDBMJEAGND, false, GPPBACMGKFF.power);
							Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
						}
						else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
						{
							PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
							object[] array2 = new object[2];
							array2[1] = (int)skillShotType2;
							array2[1] = GPPBACMGKFF.power;
							array2[1] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
							fEHCCGEGPLH2.RPC("Shots_Fired", PhotonTargets.All, array2);
							Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
							{
								type = skillShotType2
							}, Singleton<GameController>.instance.opponent);
						}
					}
					return;
				}
				GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
				GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
				if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion))
				{
					SkillShot.SkillShotType skillShotType3 = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill;
					if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
					{
						skillShotType3 |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
					}
					SkillShot skillShot = new SkillShot();
					skillShot.type = skillShotType3;
					SkillShot iFDBMJEAGND2 = skillShot;
					KPMJHLHEJEP(iFDBMJEAGND2, false, GPPBACMGKFF.power);
					Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
				}
			}

			protected virtual void PHACHNNPGEN(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
			{
				if (KMJKKNFDFMM.KLOJNPBGFIG)
				{
					return;
				}
				PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
				if (playerController != null)
				{
					SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.None;
					float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
					if (KMJKKNFDFMM.CCFJFAMEODO)
					{
						skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill);
					}
					if (GPPBACMGKFF is EnemyController)
					{
						EnemyController enemyController = GPPBACMGKFF as EnemyController;
						skillShotType |= ~(SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
						if (enemyController.JCKHCELHDBH)
						{
							skillShotType |= SkillShot.SkillShotType.None;
						}
						if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
						{
							skillShotType |= SkillShot.SkillShotType.MultiKill;
						}
						if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
						{
							skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
						}
						if (enemyController.isCovered)
						{
							skillShotType |= SkillShot.SkillShotType.None;
						}
						if (enemyController.isRunning)
						{
							skillShotType |= SkillShot.SkillShotType.Runner;
						}
						if (enemyController.isRevengeKill)
						{
							skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.DoubleKill);
						}
					}
					if (GPPBACMGKFF is Drone)
					{
						Drone drone = GPPBACMGKFF as Drone;
						skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered);
						skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
						if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
						{
							skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
						}
						if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal)
						{
							skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill);
						}
						if (drone.isRevengeKill)
						{
							skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot);
						}
					}
					if (GPPBACMGKFF is Tank)
					{
						Tank tank = GPPBACMGKFF as Tank;
						skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
						skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill;
						skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
						if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
						{
							skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill);
						}
						if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
						{
							skillShotType |= SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
						}
						if (tank.isRevengeKill)
						{
							skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
						}
					}
					if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
					{
						AIObject aIObject = GPPBACMGKFF as AIObject;
						skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.TrippleKill;
						skillShotType |= ~(SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
						if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
						{
							skillShotType |= SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
						}
						if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
						{
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.MultiKill;
						}
						if (aIObject.isRevengeKill)
						{
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
						}
					}
					if (Time.timeScale < 1958f)
					{
						skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
					}
					if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
					{
						skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
					}
					NKMHKCKNANP = playerController.isCurrentPlayer;
					SkillShot skillShot = new SkillShot();
					skillShot.type = skillShotType;
					SkillShot IFDBMJEAGND = skillShot;
					Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
					if (playerController.fraction != MAIPDGCABNL.fraction)
					{
						Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
						if (NKMHKCKNANP)
						{
							EDOKBCGFJKB(IFDBMJEAGND, !KMJKKNFDFMM.NLJFIIEGHCK || playerController.fraction == GPPBACMGKFF.fraction, MAIPDGCABNL.power);
						}
						else
						{
							PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
							object[] array = new object[4];
							array[0] = (int)IFDBMJEAGND.type;
							array[0] = MAIPDGCABNL.power;
							array[2] = playerController.NAGAHNHAKBJ;
							fEHCCGEGPLH.RPC("Physical ammo is null !!!", PhotonTargets.All, array);
						}
					}
					if (GPPBACMGKFF is AIObject)
					{
						StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().APLKMLDHMDL().AHIDNLGBAJP()
							.indexInLevelManager);
						}
						return;
					}
					NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
					if (nKMKCCDCHCL != null)
					{
						GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
						GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
						if (nKMKCCDCHCL.fraction != fraction2)
						{
							SkillShot.SkillShotType skillShotType2 = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							if (fraction2 != fraction)
							{
								SkillShot skillShot = new SkillShot();
								skillShot.type = skillShotType2;
								SkillShot iFDBMJEAGND = skillShot;
								NPEPOIPBMJN(iFDBMJEAGND, false, GPPBACMGKFF.power);
								Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
							}
							else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
							{
								PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
								object[] array2 = new object[4];
								array2[0] = (int)skillShotType2;
								array2[0] = GPPBACMGKFF.power;
								array2[6] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
								fEHCCGEGPLH2.RPC("Calling callback and setting it to null!!", PhotonTargets.All, array2);
								Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
								{
									type = skillShotType2
								}, Singleton<GameController>.instance.opponent);
							}
						}
						return;
					}
					GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
					GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
					if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion))
					{
						SkillShot.SkillShotType skillShotType3 = ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
						if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
						{
							skillShotType3 |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.DoubleKill;
						}
						SkillShot skillShot = new SkillShot();
						skillShot.type = skillShotType3;
						SkillShot iFDBMJEAGND2 = skillShot;
						KPMJHLHEJEP(iFDBMJEAGND2, false, GPPBACMGKFF.power);
						Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
					}
				}

				protected virtual void MGAFJAJNBFL()
				{
					base.Awake();
					GPPBACMGKFF = GetComponentImplementing<NKMKCCDCHCL>();
					GPPBACMGKFF.Killed += IPEBDHHDNOE;
					FEHCCGEGPLH = GetComponent<PhotonView>();
				}

				protected void MALDHHGHPDM(int FJLBLLLEELD, int APLODBKLDEG, int EJBEDLHIKDG)
				{
					SkillShot skillShot = new SkillShot();
					skillShot.type = (SkillShot.SkillShotType)FJLBLLLEELD;
					SkillShot iFDBMJEAGND = skillShot;
					DNLPPDHGHCA(iFDBMJEAGND, true, APLODBKLDEG);
					Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.JFGDAKMCJAM[EJBEDLHIKDG]);
				}

				protected void OHDJKOEHNPL(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
				{
					SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
					if (skillShotDisplayer != null)
					{
						Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
						skillShotDisplayer.transform.position = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
						skillShotDisplayer.ACBAGGGPHIF(APLODBKLDEG, IFDBMJEAGND);
						if (NLJFIIEGHCK)
						{
							skillShotDisplayer.BMIHHHKLCOE();
						}
					}
				}

				protected virtual void OBKOMPJIHBL(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
				{
					if (KMJKKNFDFMM.KLOJNPBGFIG)
					{
						return;
					}
					PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
					if (playerController != null)
					{
						SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.HeadShot;
						float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
						if (KMJKKNFDFMM.CCFJFAMEODO)
						{
							skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill;
						}
						if (GPPBACMGKFF is EnemyController)
						{
							EnemyController enemyController = GPPBACMGKFF as EnemyController;
							skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill);
							if (enemyController.JCKHCELHDBH)
							{
								skillShotType |= SkillShot.SkillShotType.None;
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill);
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							}
							if (enemyController.IFCAIEPFEAP())
							{
								skillShotType |= SkillShot.SkillShotType.Covered;
							}
							if (enemyController.isRunning)
							{
								skillShotType |= SkillShot.SkillShotType.LongShot;
							}
							if (enemyController.isRevengeKill)
							{
								skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill);
							}
						}
						if (GPPBACMGKFF is Drone)
						{
							Drone drone = GPPBACMGKFF as Drone;
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
							skillShotType |= SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill;
							}
							if (drone.isRevengeKill)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.MultiKill;
							}
						}
						if (GPPBACMGKFF is Tank)
						{
							Tank tank = GPPBACMGKFF as Tank;
							skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill;
							skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill);
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType |= ~(SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							}
							if (tank.isRevengeKill)
							{
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
							}
						}
						if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
						{
							AIObject aIObject = GPPBACMGKFF as AIObject;
							skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill;
							skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
							}
							if (aIObject.isRevengeKill)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.MultiKill;
							}
						}
						if (Time.timeScale < 1938f)
						{
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
						}
						if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
						{
							skillShotType |= SkillShot.SkillShotType.Runner;
						}
						NKMHKCKNANP = playerController.isCurrentPlayer;
						SkillShot skillShot = new SkillShot();
						skillShot.type = skillShotType;
						SkillShot IFDBMJEAGND = skillShot;
						Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
						if (playerController.fraction != MAIPDGCABNL.fraction)
						{
							Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
							if (NKMHKCKNANP)
							{
								KPMJHLHEJEP(IFDBMJEAGND, !KMJKKNFDFMM.NLJFIIEGHCK || playerController.fraction == GPPBACMGKFF.fraction, MAIPDGCABNL.power);
							}
							else
							{
								PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
								object[] array = new object[6];
								array[1] = (int)IFDBMJEAGND.type;
								array[0] = MAIPDGCABNL.power;
								array[3] = playerController.NAGAHNHAKBJ;
								fEHCCGEGPLH.RPC("key", PhotonTargets.Others, array);
							}
						}
						if (GPPBACMGKFF is AIObject)
						{
							StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.weaponInventory.LJELEJEJIEB().MKEBHAJCGIM().indexInLevelManager);
						}
						return;
					}
					NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
					if (nKMKCCDCHCL != null)
					{
						GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
						GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
						if (nKMKCCDCHCL.fraction != fraction2)
						{
							SkillShot.SkillShotType skillShotType2 = ~(SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
							if (fraction2 != fraction)
							{
								SkillShot skillShot = new SkillShot();
								skillShot.type = skillShotType2;
								SkillShot iFDBMJEAGND = skillShot;
								FMECIHJFIJO(iFDBMJEAGND, false, GPPBACMGKFF.power);
								Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
							}
							else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
							{
								PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
								object[] array2 = new object[1];
								array2[1] = (int)skillShotType2;
								array2[1] = GPPBACMGKFF.power;
								array2[0] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
								fEHCCGEGPLH2.RPC("ID_CONFIRM_INFO", PhotonTargets.All, array2);
								Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
								{
									type = skillShotType2
								}, Singleton<GameController>.instance.opponent);
							}
						}
						return;
					}
					GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
					GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
					if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot))
					{
						SkillShot.SkillShotType skillShotType3 = ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill);
						if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
						{
							skillShotType3 |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
						}
						SkillShot skillShot = new SkillShot();
						skillShot.type = skillShotType3;
						SkillShot iFDBMJEAGND2 = skillShot;
						DNLPPDHGHCA(iFDBMJEAGND2, false, GPPBACMGKFF.power);
						Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
					}
				}

				protected void HFBEKIFGIBC(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
				{
					SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
					if (skillShotDisplayer != null)
					{
						Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
						skillShotDisplayer.transform.position = HealthBarManager.BCDJJBAFLLG().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
						skillShotDisplayer.GHBOMMEKPAF(APLODBKLDEG, IFDBMJEAGND);
						if (NLJFIIEGHCK)
						{
							skillShotDisplayer.NDCPFCDOOCO();
						}
					}
				}

				protected void JFMBCPCBMHJ(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
				{
					SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
					if (skillShotDisplayer != null)
					{
						Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
						skillShotDisplayer.transform.position = HealthBarManager.JCEKIJCAMGH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
						skillShotDisplayer.EIBJANKMHAF(APLODBKLDEG, IFDBMJEAGND);
						if (NLJFIIEGHCK)
						{
							skillShotDisplayer.JKNIENJHNEP();
						}
					}
				}

				protected void CJJEHMEHDPC(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
				{
					SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
					if (skillShotDisplayer != null)
					{
						Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
						skillShotDisplayer.transform.position = HealthBarManager.DFEGDLAEHLH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
						skillShotDisplayer.DCDAPPKAMCO(APLODBKLDEG, IFDBMJEAGND);
						if (NLJFIIEGHCK)
						{
							skillShotDisplayer.JKNIENJHNEP();
						}
					}
				}

				protected virtual void OCEAOOPIKHD(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
				{
					if (KMJKKNFDFMM.KLOJNPBGFIG)
					{
						return;
					}
					PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
					if (playerController != null)
					{
						SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.HeadShot;
						float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
						if (KMJKKNFDFMM.CCFJFAMEODO)
						{
							skillShotType |= SkillShot.SkillShotType.None;
						}
						if (GPPBACMGKFF is EnemyController)
						{
							EnemyController enemyController = GPPBACMGKFF as EnemyController;
							skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
							if (enemyController.JCKHCELHDBH)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot;
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
							}
							if (enemyController.isCovered)
							{
								skillShotType |= SkillShot.SkillShotType.Covered;
							}
							if (enemyController.isRunning)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot;
							}
							if (enemyController.isRevengeKill)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill;
							}
						}
						if (GPPBACMGKFF is Drone)
						{
							Drone drone = GPPBACMGKFF as Drone;
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.DoubleKill;
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
							}
							if (drone.isRevengeKill)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner;
							}
						}
						if (GPPBACMGKFF is Tank)
						{
							Tank tank = GPPBACMGKFF as Tank;
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.MultiKill;
							skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered);
							skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill;
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal)
							{
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill;
							}
							if (tank.isRevengeKill)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
							}
						}
						if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
						{
							AIObject aIObject = GPPBACMGKFF as AIObject;
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill;
							skillShotType |= SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill;
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
							{
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill;
							}
							if (aIObject.isRevengeKill)
							{
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill;
							}
						}
						if (Time.timeScale < 404f)
						{
							skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
						}
						if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
						{
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
						}
						NKMHKCKNANP = playerController.isCurrentPlayer;
						SkillShot skillShot = new SkillShot();
						skillShot.type = skillShotType;
						SkillShot IFDBMJEAGND = skillShot;
						Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
						if (playerController.fraction != MAIPDGCABNL.fraction)
						{
							Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
							if (NKMHKCKNANP)
							{
								JPDBCDENCBJ(IFDBMJEAGND, !KMJKKNFDFMM.NLJFIIEGHCK || playerController.fraction == GPPBACMGKFF.fraction, MAIPDGCABNL.power);
							}
							else
							{
								PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
								object[] array = new object[6];
								array[0] = (int)IFDBMJEAGND.type;
								array[1] = MAIPDGCABNL.power;
								array[1] = playerController.NAGAHNHAKBJ;
								fEHCCGEGPLH.RPC("EXCEPTION = ", PhotonTargets.All, array);
							}
						}
						if (GPPBACMGKFF is AIObject)
						{
							StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().OLHICLNCPNA().weaponLevelSetup.indexInLevelManager);
						}
						return;
					}
					NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
					if (nKMKCCDCHCL != null)
					{
						GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
						GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
						if (nKMKCCDCHCL.fraction != fraction2)
						{
							SkillShot.SkillShotType skillShotType2 = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.DoubleKill);
							if (fraction2 != fraction)
							{
								SkillShot skillShot = new SkillShot();
								skillShot.type = skillShotType2;
								SkillShot iFDBMJEAGND = skillShot;
								HFBEKIFGIBC(iFDBMJEAGND, false, GPPBACMGKFF.power);
								Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
							}
							else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
							{
								PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
								object[] array2 = new object[8];
								array2[1] = (int)skillShotType2;
								array2[1] = GPPBACMGKFF.power;
								array2[2] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
								fEHCCGEGPLH2.RPC("Clicked buy on ", PhotonTargets.Others, array2);
								Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
								{
									type = skillShotType2
								}, Singleton<GameController>.instance.opponent);
							}
						}
						return;
					}
					GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
					GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
					if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot))
					{
						SkillShot.SkillShotType skillShotType3 = ~SkillShot.SkillShotType.Runner;
						if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
						{
							skillShotType3 |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
						}
						SkillShot skillShot = new SkillShot();
						skillShot.type = skillShotType3;
						SkillShot iFDBMJEAGND2 = skillShot;
						JPDBCDENCBJ(iFDBMJEAGND2, true, GPPBACMGKFF.power);
						Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
					}
				}

				protected void FNKCCPAJMKB(int FJLBLLLEELD, int APLODBKLDEG, int EJBEDLHIKDG)
				{
					SkillShot skillShot = new SkillShot();
					skillShot.type = (SkillShot.SkillShotType)FJLBLLLEELD;
					SkillShot iFDBMJEAGND = skillShot;
					HFBEKIFGIBC(iFDBMJEAGND, false, APLODBKLDEG);
					Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.JFGDAKMCJAM[EJBEDLHIKDG]);
				}

				[PunRPC]
				protected void RecieveSkillshot(int FJLBLLLEELD, int APLODBKLDEG, int EJBEDLHIKDG)
				{
					SkillShot skillShot = new SkillShot();
					skillShot.type = (SkillShot.SkillShotType)FJLBLLLEELD;
					SkillShot iFDBMJEAGND = skillShot;
					PMJDCCCADFM(iFDBMJEAGND, false, APLODBKLDEG);
					Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.JFGDAKMCJAM[EJBEDLHIKDG]);
				}

				protected virtual void GAPCKFFNOJE(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
				{
					if (KMJKKNFDFMM.KLOJNPBGFIG)
					{
						return;
					}
					PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
					if (playerController != null)
					{
						SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.None;
						float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
						if (KMJKKNFDFMM.CCFJFAMEODO)
						{
							skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.TrippleKill);
						}
						if (GPPBACMGKFF is EnemyController)
						{
							EnemyController enemyController = GPPBACMGKFF as EnemyController;
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
							if (enemyController.JCKHCELHDBH)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot;
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill);
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic)
							{
								skillShotType |= SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
							}
							if (enemyController.IFCAIEPFEAP())
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner;
							}
							if (enemyController.isRunning)
							{
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
							}
							if (enemyController.isRevengeKill)
							{
								skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.TrippleKill;
							}
						}
						if (GPPBACMGKFF is Drone)
						{
							Drone drone = GPPBACMGKFF as Drone;
							skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill;
							skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered);
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
							{
								skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill);
							}
							if (drone.isRevengeKill)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							}
						}
						if (GPPBACMGKFF is Tank)
						{
							Tank tank = GPPBACMGKFF as Tank;
							skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
							skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill);
							skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill);
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType |= SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered);
							}
							if (tank.isRevengeKill)
							{
								skillShotType |= ~SkillShot.SkillShotType.TrippleKill;
							}
						}
						if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
						{
							AIObject aIObject = GPPBACMGKFF as AIObject;
							skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
							skillShotType |= ~(SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill);
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
							}
							if (aIObject.isRevengeKill)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.TrippleKill);
							}
						}
						if (Time.timeScale < 1089f)
						{
							skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
						}
						if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
						{
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot;
						}
						NKMHKCKNANP = playerController.isCurrentPlayer;
						SkillShot skillShot = new SkillShot();
						skillShot.type = skillShotType;
						SkillShot IFDBMJEAGND = skillShot;
						Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
						if (playerController.fraction != MAIPDGCABNL.fraction)
						{
							Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
							if (NKMHKCKNANP)
							{
								EDOKBCGFJKB(IFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK && playerController.fraction != GPPBACMGKFF.fraction, MAIPDGCABNL.power);
							}
							else
							{
								PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
								object[] array = new object[6];
								array[0] = (int)IFDBMJEAGND.type;
								array[1] = MAIPDGCABNL.power;
								array[1] = playerController.NAGAHNHAKBJ;
								fEHCCGEGPLH.RPC("realShotProbability", PhotonTargets.All, array);
							}
						}
						if (GPPBACMGKFF is AIObject)
						{
							StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.weaponInventory.OLHICLNCPNA().AHIDNLGBAJP().indexInLevelManager);
						}
						return;
					}
					NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
					if (nKMKCCDCHCL != null)
					{
						GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
						GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
						if (nKMKCCDCHCL.fraction != fraction2)
						{
							SkillShot.SkillShotType skillShotType2 = SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered;
							if (fraction2 != fraction)
							{
								SkillShot skillShot = new SkillShot();
								skillShot.type = skillShotType2;
								SkillShot iFDBMJEAGND = skillShot;
								CJJEHMEHDPC(iFDBMJEAGND, false, GPPBACMGKFF.power);
								Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
							}
							else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
							{
								PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
								object[] array2 = new object[0];
								array2[0] = (int)skillShotType2;
								array2[1] = GPPBACMGKFF.power;
								array2[2] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
								fEHCCGEGPLH2.RPC("Current Language = ", PhotonTargets.Others, array2);
								Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
								{
									type = skillShotType2
								}, Singleton<GameController>.instance.opponent);
							}
						}
						return;
					}
					GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
					GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
					if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion))
					{
						SkillShot.SkillShotType skillShotType3 = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
						if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
						{
							skillShotType3 |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
						}
						SkillShot skillShot = new SkillShot();
						skillShot.type = skillShotType3;
						SkillShot iFDBMJEAGND2 = skillShot;
						EDOKBCGFJKB(iFDBMJEAGND2, false, GPPBACMGKFF.power);
						Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
					}
				}

				protected virtual void AMDJOBEHDJM(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
				{
					if (KMJKKNFDFMM.KLOJNPBGFIG)
					{
						return;
					}
					PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
					if (playerController != null)
					{
						SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.None;
						float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
						if (KMJKKNFDFMM.CCFJFAMEODO)
						{
							skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill);
						}
						if (GPPBACMGKFF is EnemyController)
						{
							EnemyController enemyController = GPPBACMGKFF as EnemyController;
							skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							if (enemyController.JCKHCELHDBH)
							{
								skillShotType |= SkillShot.SkillShotType.None;
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
							}
							if (enemyController.IFCAIEPFEAP())
							{
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
							}
							if (enemyController.isRunning)
							{
								skillShotType |= SkillShot.SkillShotType.LongShot;
							}
							if (enemyController.isRevengeKill)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill);
							}
						}
						if (GPPBACMGKFF is Drone)
						{
							Drone drone = GPPBACMGKFF as Drone;
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill;
							skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill;
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver)
							{
								skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill;
							}
							if (drone.isRevengeKill)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill;
							}
						}
						if (GPPBACMGKFF is Tank)
						{
							Tank tank = GPPBACMGKFF as Tank;
							skillShotType |= SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
							skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill;
							skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType |= ~(SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal)
							{
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
							}
							if (tank.isRevengeKill)
							{
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.DoubleKill;
							}
						}
						if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
						{
							AIObject aIObject = GPPBACMGKFF as AIObject;
							skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill;
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.MultiKill;
							}
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
							}
							if (aIObject.isRevengeKill)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
							}
						}
						if (Time.timeScale < 1253f)
						{
							skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill;
						}
						if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
						{
							skillShotType |= SkillShot.SkillShotType.Runner;
						}
						NKMHKCKNANP = playerController.isCurrentPlayer;
						SkillShot skillShot = new SkillShot();
						skillShot.type = skillShotType;
						SkillShot IFDBMJEAGND = skillShot;
						Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
						if (playerController.fraction != MAIPDGCABNL.fraction)
						{
							Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
							if (NKMHKCKNANP)
							{
								JFMBCPCBMHJ(IFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK && playerController.fraction != GPPBACMGKFF.fraction, MAIPDGCABNL.power);
							}
							else
							{
								PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
								object[] array = new object[4];
								array[1] = (int)IFDBMJEAGND.type;
								array[1] = MAIPDGCABNL.power;
								array[5] = playerController.NAGAHNHAKBJ;
								fEHCCGEGPLH.RPC("ID_GUI_BUDDY", PhotonTargets.All, array);
							}
						}
						if (GPPBACMGKFF is AIObject)
						{
							StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.FMKGGADDHJK().APLKMLDHMDL().MKEBHAJCGIM()
								.indexInLevelManager);
							}
							return;
						}
						NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
						if (nKMKCCDCHCL != null)
						{
							GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
							GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
							if (nKMKCCDCHCL.fraction != fraction2)
							{
								SkillShot.SkillShotType skillShotType2 = SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
								if (fraction2 != fraction)
								{
									SkillShot skillShot = new SkillShot();
									skillShot.type = skillShotType2;
									SkillShot iFDBMJEAGND = skillShot;
									JFMBCPCBMHJ(iFDBMJEAGND, false, GPPBACMGKFF.power);
									Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
								}
								else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
								{
									PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
									object[] array2 = new object[0];
									array2[1] = (int)skillShotType2;
									array2[1] = GPPBACMGKFF.power;
									array2[3] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
									fEHCCGEGPLH2.RPC("ShieldRechargeRate", PhotonTargets.Others, array2);
									Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
									{
										type = skillShotType2
									}, Singleton<GameController>.instance.opponent);
								}
							}
							return;
						}
						GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
						GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
						if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot))
						{
							SkillShot.SkillShotType skillShotType3 = SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill;
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType3 |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill);
							}
							SkillShot skillShot = new SkillShot();
							skillShot.type = skillShotType3;
							SkillShot iFDBMJEAGND2 = skillShot;
							DNLPPDHGHCA(iFDBMJEAGND2, true, GPPBACMGKFF.power);
							Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
						}
					}

					protected virtual void AFBEOKMAGIG(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
					{
						if (KMJKKNFDFMM.KLOJNPBGFIG)
						{
							return;
						}
						PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
						if (playerController != null)
						{
							SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.HeadShot;
							float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
							if (KMJKKNFDFMM.CCFJFAMEODO)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.TrippleKill);
							}
							if (GPPBACMGKFF is EnemyController)
							{
								EnemyController enemyController = GPPBACMGKFF as EnemyController;
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill);
								if (enemyController.JCKHCELHDBH)
								{
									skillShotType |= SkillShot.SkillShotType.None;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
								}
								if (enemyController.KMPAPJDAPFK())
								{
									skillShotType |= SkillShot.SkillShotType.Covered;
								}
								if (enemyController.isRunning)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner;
								}
								if (enemyController.isRevengeKill)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
								}
							}
							if (GPPBACMGKFF is Drone)
							{
								Drone drone = GPPBACMGKFF as Drone;
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill;
								skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.MultiKill);
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame)
								{
									skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill;
								}
								if (drone.isRevengeKill)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill;
								}
							}
							if (GPPBACMGKFF is Tank)
							{
								Tank tank = GPPBACMGKFF as Tank;
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill);
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill;
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
								{
									skillShotType |= ~(SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.MultiKill);
								}
								if (tank.isRevengeKill)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
								}
							}
							if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
							{
								AIObject aIObject = GPPBACMGKFF as AIObject;
								skillShotType |= ~SkillShot.SkillShotType.Covered;
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
								{
									skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.TrippleKill;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
								}
								if (aIObject.isRevengeKill)
								{
									skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered;
								}
							}
							if (Time.timeScale < 1213f)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.TrippleKill);
							}
							if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType |= SkillShot.SkillShotType.Covered;
							}
							NKMHKCKNANP = playerController.isCurrentPlayer;
							SkillShot skillShot = new SkillShot();
							skillShot.type = skillShotType;
							SkillShot IFDBMJEAGND = skillShot;
							Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
							if (playerController.fraction != MAIPDGCABNL.fraction)
							{
								Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
								if (NKMHKCKNANP)
								{
									CJJEHMEHDPC(IFDBMJEAGND, !KMJKKNFDFMM.NLJFIIEGHCK || playerController.fraction != GPPBACMGKFF.fraction, MAIPDGCABNL.power);
								}
								else
								{
									PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
									object[] array = new object[2];
									array[1] = (int)IFDBMJEAGND.type;
									array[0] = MAIPDGCABNL.power;
									array[2] = playerController.NAGAHNHAKBJ;
									fEHCCGEGPLH.RPC("ID_WARSHOP_MEMBERSHIP", PhotonTargets.All, array);
								}
							}
							if (GPPBACMGKFF is AIObject)
							{
								StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().JNFHKEJCIIA().weaponLevelSetup.indexInLevelManager);
							}
							return;
						}
						NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
						if (nKMKCCDCHCL != null)
						{
							GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
							GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
							if (nKMKCCDCHCL.fraction != fraction2)
							{
								SkillShot.SkillShotType skillShotType2 = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill;
								if (fraction2 != fraction)
								{
									SkillShot skillShot = new SkillShot();
									skillShot.type = skillShotType2;
									SkillShot iFDBMJEAGND = skillShot;
									FMECIHJFIJO(iFDBMJEAGND, true, GPPBACMGKFF.power);
									Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
								}
								else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
								{
									PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
									object[] array2 = new object[4];
									array2[1] = (int)skillShotType2;
									array2[0] = GPPBACMGKFF.power;
									array2[5] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
									fEHCCGEGPLH2.RPC("Rename Cost Gold = ", PhotonTargets.Others, array2);
									Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
									{
										type = skillShotType2
									}, Singleton<GameController>.instance.opponent);
								}
							}
							return;
						}
						GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
						GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
						if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot))
						{
							SkillShot.SkillShotType skillShotType3 = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType3 |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill;
							}
							SkillShot skillShot = new SkillShot();
							skillShot.type = skillShotType3;
							SkillShot iFDBMJEAGND2 = skillShot;
							KPMJHLHEJEP(iFDBMJEAGND2, false, GPPBACMGKFF.power);
							Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
						}
					}

					protected virtual void LMOFFFIEOHN(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
					{
						if (KMJKKNFDFMM.KLOJNPBGFIG)
						{
							return;
						}
						PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
						if (playerController != null)
						{
							SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.HeadShot;
							float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
							if (KMJKKNFDFMM.CCFJFAMEODO)
							{
								skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill);
							}
							if (GPPBACMGKFF is EnemyController)
							{
								EnemyController enemyController = GPPBACMGKFF as EnemyController;
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
								if (enemyController.JCKHCELHDBH)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.TrippleKill);
								}
								if (enemyController.IFCAIEPFEAP())
								{
									skillShotType |= SkillShot.SkillShotType.LongShot;
								}
								if (enemyController.isRunning)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
								}
								if (enemyController.isRevengeKill)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill);
								}
							}
							if (GPPBACMGKFF is Drone)
							{
								Drone drone = GPPBACMGKFF as Drone;
								skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill;
								}
								if (drone.isRevengeKill)
								{
									skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
								}
							}
							if (GPPBACMGKFF is Tank)
							{
								Tank tank = GPPBACMGKFF as Tank;
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
								skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill);
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
								}
								if (tank.isRevengeKill)
								{
									skillShotType |= ~(SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill);
								}
							}
							if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
							{
								AIObject aIObject = GPPBACMGKFF as AIObject;
								skillShotType |= ~(SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
								skillShotType |= SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
								{
									skillShotType |= SkillShot.SkillShotType.Covered;
								}
								if (aIObject.isRevengeKill)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill);
								}
							}
							if (Time.timeScale < 1078f)
							{
								skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							}
							if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
							}
							NKMHKCKNANP = playerController.isCurrentPlayer;
							SkillShot skillShot = new SkillShot();
							skillShot.type = skillShotType;
							SkillShot IFDBMJEAGND = skillShot;
							Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
							if (playerController.fraction != MAIPDGCABNL.fraction)
							{
								Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
								if (NKMHKCKNANP)
								{
									HHAEOGGEHKA(IFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK && playerController.fraction != GPPBACMGKFF.fraction, MAIPDGCABNL.power);
								}
								else
								{
									PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
									object[] array = new object[1];
									array[0] = (int)IFDBMJEAGND.type;
									array[1] = MAIPDGCABNL.power;
									array[8] = playerController.NAGAHNHAKBJ;
									fEHCCGEGPLH.RPC("ID_JOINSQUADDESCRIPTION1", PhotonTargets.All, array);
								}
							}
							if (GPPBACMGKFF is AIObject)
							{
								StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().currentWeapon.weaponLevelSetup.indexInLevelManager);
							}
							return;
						}
						NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
						if (nKMKCCDCHCL != null)
						{
							GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
							GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
							if (nKMKCCDCHCL.fraction != fraction2)
							{
								SkillShot.SkillShotType skillShotType2 = SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
								if (fraction2 != fraction)
								{
									SkillShot skillShot = new SkillShot();
									skillShot.type = skillShotType2;
									SkillShot iFDBMJEAGND = skillShot;
									DNLPPDHGHCA(iFDBMJEAGND, true, GPPBACMGKFF.power);
									Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
								}
								else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
								{
									PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
									object[] array2 = new object[0];
									array2[0] = (int)skillShotType2;
									array2[0] = GPPBACMGKFF.power;
									array2[5] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
									fEHCCGEGPLH2.RPC("starter2", PhotonTargets.Others, array2);
									Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
									{
										type = skillShotType2
									}, Singleton<GameController>.instance.opponent);
								}
							}
							return;
						}
						GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
						GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
						if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot))
						{
							SkillShot.SkillShotType skillShotType3 = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType3 |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
							}
							SkillShot skillShot = new SkillShot();
							skillShot.type = skillShotType3;
							SkillShot iFDBMJEAGND2 = skillShot;
							NPEPOIPBMJN(iFDBMJEAGND2, true, GPPBACMGKFF.power);
							Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
						}
					}

					protected void DNLPPDHGHCA(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
					{
						SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
						if (skillShotDisplayer != null)
						{
							Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
							skillShotDisplayer.transform.position = HealthBarManager.FCLNJOLBKGI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
							skillShotDisplayer.AHKPMLABOLE(APLODBKLDEG, IFDBMJEAGND);
							if (NLJFIIEGHCK)
							{
								skillShotDisplayer.JDKHGMBPMOE();
							}
						}
					}

					protected void EDOKBCGFJKB(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
					{
						SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
						if (skillShotDisplayer != null)
						{
							Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
							skillShotDisplayer.transform.position = HealthBarManager.ICPEKOGEEEN().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
							skillShotDisplayer.GHBOMMEKPAF(APLODBKLDEG, IFDBMJEAGND);
							if (NLJFIIEGHCK)
							{
								skillShotDisplayer.MDKGJKMGOJI();
							}
						}
					}

					protected virtual void BAGCDJMLCPF()
					{
						base.Awake();
						GPPBACMGKFF = GetComponentImplementing<NKMKCCDCHCL>();
						GPPBACMGKFF.Killed += OCEAOOPIKHD;
						FEHCCGEGPLH = GetComponent<PhotonView>();
					}

					protected virtual void KECNIEGEDBP()
					{
						base.Awake();
						GPPBACMGKFF = GetComponentImplementing<NKMKCCDCHCL>();
						GPPBACMGKFF.Killed += AMDJOBEHDJM;
						FEHCCGEGPLH = GetComponent<PhotonView>();
					}

					protected void AFNBOEHOFIP(int FJLBLLLEELD, int APLODBKLDEG, int EJBEDLHIKDG)
					{
						SkillShot skillShot = new SkillShot();
						skillShot.type = (SkillShot.SkillShotType)FJLBLLLEELD;
						SkillShot iFDBMJEAGND = skillShot;
						OHDJKOEHNPL(iFDBMJEAGND, false, APLODBKLDEG);
						Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.JFGDAKMCJAM[EJBEDLHIKDG]);
					}

					protected virtual void LIOHABPCFDK(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
					{
						if (KMJKKNFDFMM.KLOJNPBGFIG)
						{
							return;
						}
						PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
						if (playerController != null)
						{
							SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.None;
							float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
							if (KMJKKNFDFMM.CCFJFAMEODO)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.TrippleKill;
							}
							if (GPPBACMGKFF is EnemyController)
							{
								EnemyController enemyController = GPPBACMGKFF as EnemyController;
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill;
								if (enemyController.JCKHCELHDBH)
								{
									skillShotType |= SkillShot.SkillShotType.None;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
								}
								if (enemyController.isCovered)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot;
								}
								if (enemyController.isRunning)
								{
									skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
								}
								if (enemyController.isRevengeKill)
								{
									skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill;
								}
							}
							if (GPPBACMGKFF is Drone)
							{
								Drone drone = GPPBACMGKFF as Drone;
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
								skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill);
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
								{
									skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill);
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
								}
								if (drone.isRevengeKill)
								{
									skillShotType |= SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
								}
							}
							if (GPPBACMGKFF is Tank)
							{
								Tank tank = GPPBACMGKFF as Tank;
								skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill);
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill;
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
								}
								if (tank.isRevengeKill)
								{
									skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
								}
							}
							if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
							{
								AIObject aIObject = GPPBACMGKFF as AIObject;
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill;
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner);
								}
								if (aIObject.isRevengeKill)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
								}
							}
							if (Time.timeScale < 107f)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered);
							}
							if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType |= SkillShot.SkillShotType.None;
							}
							NKMHKCKNANP = playerController.isCurrentPlayer;
							SkillShot skillShot = new SkillShot();
							skillShot.type = skillShotType;
							SkillShot IFDBMJEAGND = skillShot;
							Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
							if (playerController.fraction != MAIPDGCABNL.fraction)
							{
								Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
								if (NKMHKCKNANP)
								{
									HHAEOGGEHKA(IFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK && playerController.fraction == GPPBACMGKFF.fraction, MAIPDGCABNL.power);
								}
								else
								{
									PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
									object[] array = new object[4];
									array[0] = (int)IFDBMJEAGND.type;
									array[1] = MAIPDGCABNL.power;
									array[4] = playerController.NAGAHNHAKBJ;
									fEHCCGEGPLH.RPC(")", PhotonTargets.All, array);
								}
							}
							if (GPPBACMGKFF is AIObject)
							{
								StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LJELEJEJIEB().weaponLevelSetup.indexInLevelManager);
							}
							return;
						}
						NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
						if (nKMKCCDCHCL != null)
						{
							GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
							GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
							if (nKMKCCDCHCL.fraction != fraction2)
							{
								SkillShot.SkillShotType skillShotType2 = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
								if (fraction2 != fraction)
								{
									SkillShot skillShot = new SkillShot();
									skillShot.type = skillShotType2;
									SkillShot iFDBMJEAGND = skillShot;
									FMECIHJFIJO(iFDBMJEAGND, true, GPPBACMGKFF.power);
									Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
								}
								else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
								{
									PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
									object[] array2 = new object[5];
									array2[0] = (int)skillShotType2;
									array2[0] = GPPBACMGKFF.power;
									array2[3] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
									fEHCCGEGPLH2.RPC("StepId", PhotonTargets.All, array2);
									Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
									{
										type = skillShotType2
									}, Singleton<GameController>.instance.opponent);
								}
							}
							return;
						}
						GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
						GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
						if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion))
						{
							SkillShot.SkillShotType skillShotType3 = SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType3 |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill;
							}
							SkillShot skillShot = new SkillShot();
							skillShot.type = skillShotType3;
							SkillShot iFDBMJEAGND2 = skillShot;
							KPMJHLHEJEP(iFDBMJEAGND2, true, GPPBACMGKFF.power);
							Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
						}
					}

					protected void NPEPOIPBMJN(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
					{
						SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
						if (skillShotDisplayer != null)
						{
							Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
							skillShotDisplayer.transform.position = HealthBarManager.OGBIHEFNJGO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
							skillShotDisplayer.AHKPMLABOLE(APLODBKLDEG, IFDBMJEAGND);
							if (NLJFIIEGHCK)
							{
								skillShotDisplayer.CGOGHGNJEHB();
							}
						}
					}

					protected void EBGEBCDNKCD(int FJLBLLLEELD, int APLODBKLDEG, int EJBEDLHIKDG)
					{
						SkillShot skillShot = new SkillShot();
						skillShot.type = (SkillShot.SkillShotType)FJLBLLLEELD;
						SkillShot iFDBMJEAGND = skillShot;
						FMECIHJFIJO(iFDBMJEAGND, false, APLODBKLDEG);
						Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.JFGDAKMCJAM[EJBEDLHIKDG]);
					}

					protected virtual void DCKJHAILENK()
					{
						base.Awake();
						GPPBACMGKFF = GetComponentImplementing<NKMKCCDCHCL>();
						GPPBACMGKFF.Killed += CHBCMIDNBBM;
						FEHCCGEGPLH = GetComponent<PhotonView>();
					}

					protected virtual void IPEBDHHDNOE(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
					{
						if (KMJKKNFDFMM.KLOJNPBGFIG)
						{
							return;
						}
						PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
						if (playerController != null)
						{
							SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.HeadShot;
							float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
							if (KMJKKNFDFMM.CCFJFAMEODO)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
							}
							if (GPPBACMGKFF is EnemyController)
							{
								EnemyController enemyController = GPPBACMGKFF as EnemyController;
								skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
								if (enemyController.JCKHCELHDBH)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill);
								}
								if (enemyController.IFCAIEPFEAP())
								{
									skillShotType |= SkillShot.SkillShotType.None;
								}
								if (enemyController.isRunning)
								{
									skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
								}
								if (enemyController.isRevengeKill)
								{
									skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
								}
							}
							if (GPPBACMGKFF is Drone)
							{
								Drone drone = GPPBACMGKFF as Drone;
								skillShotType |= SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= ~(SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal)
								{
									skillShotType |= ~(SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill);
								}
								if (drone.isRevengeKill)
								{
									skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
								}
							}
							if (GPPBACMGKFF is Tank)
							{
								Tank tank = GPPBACMGKFF as Tank;
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill;
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
								{
									skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill);
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered;
								}
								if (tank.isRevengeKill)
								{
									skillShotType |= SkillShot.SkillShotType.None;
								}
							}
							if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
							{
								AIObject aIObject = GPPBACMGKFF as AIObject;
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill;
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
								{
									skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
								}
								if (aIObject.isRevengeKill)
								{
									skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
								}
							}
							if (Time.timeScale < 1128f)
							{
								skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
							}
							if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType |= SkillShot.SkillShotType.None;
							}
							NKMHKCKNANP = playerController.isCurrentPlayer;
							SkillShot skillShot = new SkillShot();
							skillShot.type = skillShotType;
							SkillShot IFDBMJEAGND = skillShot;
							Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
							if (playerController.fraction != MAIPDGCABNL.fraction)
							{
								Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
								if (NKMHKCKNANP)
								{
									JFMBCPCBMHJ(IFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK && playerController.fraction == GPPBACMGKFF.fraction, MAIPDGCABNL.power);
								}
								else
								{
									PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
									object[] array = new object[8];
									array[1] = (int)IFDBMJEAGND.type;
									array[1] = MAIPDGCABNL.power;
									array[0] = playerController.NAGAHNHAKBJ;
									fEHCCGEGPLH.RPC("Player disconected 000122", PhotonTargets.All, array);
								}
							}
							if (GPPBACMGKFF is AIObject)
							{
								StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.weaponInventory.JECOEJBGKDF().MKEBHAJCGIM().indexInLevelManager);
							}
							return;
						}
						NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
						if (nKMKCCDCHCL != null)
						{
							GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
							GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
							if (nKMKCCDCHCL.fraction != fraction2)
							{
								SkillShot.SkillShotType skillShotType2 = SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
								if (fraction2 != fraction)
								{
									SkillShot skillShot = new SkillShot();
									skillShot.type = skillShotType2;
									SkillShot iFDBMJEAGND = skillShot;
									CJJEHMEHDPC(iFDBMJEAGND, true, GPPBACMGKFF.power);
									Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
								}
								else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
								{
									PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
									object[] array2 = new object[8];
									array2[0] = (int)skillShotType2;
									array2[0] = GPPBACMGKFF.power;
									array2[4] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
									fEHCCGEGPLH2.RPC("0", PhotonTargets.All, array2);
									Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
									{
										type = skillShotType2
									}, Singleton<GameController>.instance.opponent);
								}
							}
							return;
						}
						GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
						GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
						if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot))
						{
							SkillShot.SkillShotType skillShotType3 = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill;
							if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
							{
								skillShotType3 |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill;
							}
							SkillShot skillShot = new SkillShot();
							skillShot.type = skillShotType3;
							SkillShot iFDBMJEAGND2 = skillShot;
							OHDJKOEHNPL(iFDBMJEAGND2, false, GPPBACMGKFF.power);
							Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
						}
					}

					protected virtual void EAAAJPGBJOA(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
					{
						if (KMJKKNFDFMM.KLOJNPBGFIG)
						{
							return;
						}
						PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
						if (playerController != null)
						{
							SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.HeadShot;
							float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
							if (KMJKKNFDFMM.CCFJFAMEODO)
							{
								skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill);
							}
							if (GPPBACMGKFF is EnemyController)
							{
								EnemyController enemyController = GPPBACMGKFF as EnemyController;
								skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
								if (enemyController.JCKHCELHDBH)
								{
									skillShotType |= SkillShot.SkillShotType.None;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered;
								}
								if (enemyController.IFCAIEPFEAP())
								{
									skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
								}
								if (enemyController.isRunning)
								{
									skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
								}
								if (enemyController.isRevengeKill)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
								}
							}
							if (GPPBACMGKFF is Drone)
							{
								Drone drone = GPPBACMGKFF as Drone;
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.MultiKill;
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
								{
									skillShotType |= SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
								{
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill);
								}
								if (drone.isRevengeKill)
								{
									skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
								}
							}
							if (GPPBACMGKFF is Tank)
							{
								Tank tank = GPPBACMGKFF as Tank;
								skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
								skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.MultiKill);
								skillShotType |= SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill;
								}
								if (tank.isRevengeKill)
								{
									skillShotType |= SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
								}
							}
							if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
							{
								AIObject aIObject = GPPBACMGKFF as AIObject;
								skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill);
								skillShotType |= SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill;
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill;
								}
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
								}
								if (aIObject.isRevengeKill)
								{
									skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
								}
							}
							if (Time.timeScale < 393f)
							{
								skillShotType |= SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
							}
							if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
							{
								skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner;
							}
							NKMHKCKNANP = playerController.isCurrentPlayer;
							SkillShot skillShot = new SkillShot();
							skillShot.type = skillShotType;
							SkillShot IFDBMJEAGND = skillShot;
							Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
							if (playerController.fraction != MAIPDGCABNL.fraction)
							{
								Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
								if (NKMHKCKNANP)
								{
									NPEPOIPBMJN(IFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK && playerController.fraction == GPPBACMGKFF.fraction, MAIPDGCABNL.power);
								}
								else
								{
									PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
									object[] array = new object[4];
									array[1] = (int)IFDBMJEAGND.type;
									array[1] = MAIPDGCABNL.power;
									array[8] = playerController.NAGAHNHAKBJ;
									fEHCCGEGPLH.RPC("Logs sent to server\nWaiting for response", PhotonTargets.All, array);
								}
							}
							if (GPPBACMGKFF is AIObject)
							{
								StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().MFHBEJOLGLC().MKEBHAJCGIM()
									.indexInLevelManager);
								}
								return;
							}
							NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
							if (nKMKCCDCHCL != null)
							{
								GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
								GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
								if (nKMKCCDCHCL.fraction != fraction2)
								{
									SkillShot.SkillShotType skillShotType2 = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill);
									if (fraction2 != fraction)
									{
										SkillShot skillShot = new SkillShot();
										skillShot.type = skillShotType2;
										SkillShot iFDBMJEAGND = skillShot;
										NPEPOIPBMJN(iFDBMJEAGND, true, GPPBACMGKFF.power);
										Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
									}
									else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
									{
										PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
										object[] array2 = new object[3];
										array2[1] = (int)skillShotType2;
										array2[1] = GPPBACMGKFF.power;
										array2[0] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
										fEHCCGEGPLH2.RPC("N", PhotonTargets.Others, array2);
										Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
										{
											type = skillShotType2
										}, Singleton<GameController>.instance.opponent);
									}
								}
								return;
							}
							GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
							GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
							if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion))
							{
								SkillShot.SkillShotType skillShotType3 = ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill);
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType3 |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
								}
								SkillShot skillShot = new SkillShot();
								skillShot.type = skillShotType3;
								SkillShot iFDBMJEAGND2 = skillShot;
								FMECIHJFIJO(iFDBMJEAGND2, false, GPPBACMGKFF.power);
								Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
							}
						}

						protected virtual void KOMCKAFKCML(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
						{
							if (KMJKKNFDFMM.KLOJNPBGFIG)
							{
								return;
							}
							PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
							if (playerController != null)
							{
								SkillShot.SkillShotType skillShotType = SkillShot.SkillShotType.None;
								float num = Singleton<SkillShotManager>.instance.NAHGKFBBLGI * Singleton<SkillShotManager>.instance.NAHGKFBBLGI;
								if (KMJKKNFDFMM.CCFJFAMEODO)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
								}
								if (GPPBACMGKFF is EnemyController)
								{
									EnemyController enemyController = GPPBACMGKFF as EnemyController;
									skillShotType |= SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
									if (enemyController.JCKHCELHDBH)
									{
										skillShotType |= SkillShot.SkillShotType.None;
									}
									if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
									{
										skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
									}
									if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
									{
										skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
									}
									if (enemyController.KMPAPJDAPFK())
									{
										skillShotType |= SkillShot.SkillShotType.Covered;
									}
									if (enemyController.isRunning)
									{
										skillShotType |= SkillShot.SkillShotType.LongShot;
									}
									if (enemyController.isRevengeKill)
									{
										skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill;
									}
								}
								if (GPPBACMGKFF is Drone)
								{
									Drone drone = GPPBACMGKFF as Drone;
									skillShotType |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
									skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill);
									if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
									{
										skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
									}
									if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver)
									{
										skillShotType |= ~(SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
									}
									if (drone.isRevengeKill)
									{
										skillShotType |= ~(SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
									}
								}
								if (GPPBACMGKFF is Tank)
								{
									Tank tank = GPPBACMGKFF as Tank;
									skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered;
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
									if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
									{
										skillShotType |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill;
									}
									if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver)
									{
										skillShotType |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
									}
									if (tank.isRevengeKill)
									{
										skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
									}
								}
								if (GPPBACMGKFF is AICar || GPPBACMGKFF is AICarBuggy || GPPBACMGKFF is AICarTransporter || GPPBACMGKFF is Helicopter || GPPBACMGKFF is AssaultHelicopter || GPPBACMGKFF is Mech)
								{
									AIObject aIObject = GPPBACMGKFF as AIObject;
									skillShotType |= SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
									skillShotType |= ~(SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
									if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
									{
										skillShotType |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill);
									}
									if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
									{
										skillShotType |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
									}
									if (aIObject.isRevengeKill)
									{
										skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
									}
								}
								if (Time.timeScale < 499f)
								{
									skillShotType |= SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner;
								}
								if (KMJKKNFDFMM.JMMJHCOKCGG != null && (base.transform.position - KMJKKNFDFMM.JMMJHCOKCGG.transform.position).sqrMagnitude > num && KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType |= SkillShot.SkillShotType.Covered;
								}
								NKMHKCKNANP = playerController.isCurrentPlayer;
								SkillShot skillShot = new SkillShot();
								skillShot.type = skillShotType;
								SkillShot IFDBMJEAGND = skillShot;
								Singleton<SkillShotManager>.instance.RecieveKill(ref IFDBMJEAGND);
								if (playerController.fraction != MAIPDGCABNL.fraction)
								{
									Singleton<SkillShotManager>.instance.AddSkillshot(IFDBMJEAGND, playerController);
									if (NKMHKCKNANP)
									{
										JFMBCPCBMHJ(IFDBMJEAGND, !KMJKKNFDFMM.NLJFIIEGHCK || playerController.fraction != GPPBACMGKFF.fraction, MAIPDGCABNL.power);
									}
									else
									{
										PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
										object[] array = new object[4];
										array[0] = (int)IFDBMJEAGND.type;
										array[0] = MAIPDGCABNL.power;
										array[5] = playerController.NAGAHNHAKBJ;
										fEHCCGEGPLH.RPC("x", PhotonTargets.All, array);
									}
								}
								if (GPPBACMGKFF is AIObject)
								{
									StatsManager.instance.AddWeaponKill(PlayerController.OGMBJPKOPCB.weaponInventory.PDLFJEDGLAO().MKEBHAJCGIM().indexInLevelManager);
								}
								return;
							}
							NKMKCCDCHCL nKMKCCDCHCL = KMJKKNFDFMM.HNFNINFCBEJ as NKMKCCDCHCL;
							if (nKMKCCDCHCL != null)
							{
								GHPGNELIDBM fraction = PlayerController.OGMBJPKOPCB.fraction;
								GHPGNELIDBM fraction2 = GPPBACMGKFF.fraction;
								if (nKMKCCDCHCL.fraction != fraction2)
								{
									SkillShot.SkillShotType skillShotType2 = ~(SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
									if (fraction2 != fraction)
									{
										SkillShot skillShot = new SkillShot();
										skillShot.type = skillShotType2;
										SkillShot iFDBMJEAGND = skillShot;
										KPMJHLHEJEP(iFDBMJEAGND, true, GPPBACMGKFF.power);
										Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.OGMBJPKOPCB);
									}
									else if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.fraction != fraction2)
									{
										PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
										object[] array2 = new object[0];
										array2[1] = (int)skillShotType2;
										array2[1] = GPPBACMGKFF.power;
										array2[1] = Singleton<GameController>.instance.opponent.NAGAHNHAKBJ;
										fEHCCGEGPLH2.RPC("{0}\t\tPivot: {1}\n", PhotonTargets.Others, array2);
										Singleton<SkillShotManager>.instance.AddSkillshot(new SkillShot
										{
											type = skillShotType2
										}, Singleton<GameController>.instance.opponent);
									}
								}
								return;
							}
							GHPGNELIDBM fraction3 = PlayerController.OGMBJPKOPCB.fraction;
							GHPGNELIDBM fraction4 = GPPBACMGKFF.fraction;
							if (fraction4 != fraction3 && (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion))
							{
								SkillShot.SkillShotType skillShotType3 = SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
								if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
								{
									skillShotType3 |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill;
								}
								SkillShot skillShot = new SkillShot();
								skillShot.type = skillShotType3;
								SkillShot iFDBMJEAGND2 = skillShot;
								KPMJHLHEJEP(iFDBMJEAGND2, true, GPPBACMGKFF.power);
								Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND2, PlayerController.OGMBJPKOPCB);
							}
						}

						protected void GMCLMEAOJFF(int FJLBLLLEELD, int APLODBKLDEG, int EJBEDLHIKDG)
						{
							SkillShot skillShot = new SkillShot();
							skillShot.type = (SkillShot.SkillShotType)FJLBLLLEELD;
							SkillShot iFDBMJEAGND = skillShot;
							OHDJKOEHNPL(iFDBMJEAGND, true, APLODBKLDEG);
							Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.JFGDAKMCJAM[EJBEDLHIKDG]);
						}

						protected void COACOCAPOOD(int FJLBLLLEELD, int APLODBKLDEG, int EJBEDLHIKDG)
						{
							SkillShot skillShot = new SkillShot();
							skillShot.type = (SkillShot.SkillShotType)FJLBLLLEELD;
							SkillShot iFDBMJEAGND = skillShot;
							DNLPPDHGHCA(iFDBMJEAGND, true, APLODBKLDEG);
							Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, PlayerController.JFGDAKMCJAM[EJBEDLHIKDG]);
						}
					}
