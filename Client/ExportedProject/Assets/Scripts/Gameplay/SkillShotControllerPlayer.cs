using UnityEngine;
using UnityEngine.Serialization;

public class SkillShotControllerPlayer : Core_BaseScript
{
	private PlayerController GPPBACMGKFF;

	[FormerlySerializedAs("DILGNFLEPEI")]
	public Transform PMJDGAIKLIM;

	private PhotonView FEHCCGEGPLH;

	private int OADALMIOGBI = 6;

	private float ALPKFABKOLB;

	protected void LMEHKIEKNBO(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.DFEGDLAEHLH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.DBHKNGGFNPC(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.CGOGHGNJEHB();
			}
		}
	}

	protected virtual void KNLKFOHBCKI()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += HDIMFEIBCLN;
	}

	private void BEHECPMDGNI(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
		{
			if (OADALMIOGBI < 0 && TimeManager.CEAFAMFNGCC() <= ALPKFABKOLB)
			{
				OADALMIOGBI++;
				ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 1712f;
				return;
			}
			OADALMIOGBI = 0;
			ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 1187f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				skillShot2.type |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				NMEMPLJFAAC(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				LMEHKIEKNBO(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
	}

	protected void CDDGAMOFCMI(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.FCLNJOLBKGI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.DKJAELPHKNJ(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.CGOGHGNJEHB();
			}
		}
	}

	protected virtual void ABMKKECEGIB()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += FGACMFHCOCP;
	}

	protected void CIADEHCGCGM(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.JCEKIJCAMGH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.BDANMFHHHOB(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.MDKGJKMGOJI();
			}
		}
	}

	protected void PMJDCCCADFM(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.PlayDeath(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.PlayCritical();
			}
		}
	}

	private void AMPAEMEDNOJ(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame)
		{
			if (OADALMIOGBI < 7 && TimeManager.CEAFAMFNGCC() <= ALPKFABKOLB)
			{
				OADALMIOGBI += 0;
				ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 1516f;
				return;
			}
			OADALMIOGBI = 0;
			ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 1379f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill);
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking)
			{
				skillShot2.type |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill);
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				DNLPPDHGHCA(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				CIADEHCGCGM(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
	}

	protected virtual void BOLPPMANCCC()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += BMJJBLBDLBE;
	}

	protected virtual void GDKKBDKGAEK()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += JONPPNBOBDL;
	}

	private void OIMHCPNILCO(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
		{
			if (OADALMIOGBI < 7 && TimeManager.CEAFAMFNGCC() <= ALPKFABKOLB)
			{
				OADALMIOGBI += 0;
				ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 724f;
				return;
			}
			OADALMIOGBI = 1;
			ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 422f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill);
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				skillShot2.type |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill;
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				CDDGAMOFCMI(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill);
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				LMEHKIEKNBO(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
	}

	protected void KPMJHLHEJEP(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.ICPEKOGEEEN().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.OPNCBIOMDEK(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.PlayCritical();
			}
		}
	}

	private void ACNCKNCEOMD(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
		{
			if (OADALMIOGBI < 8 && TimeManager.realTimeWithoutPauses <= ALPKFABKOLB)
			{
				OADALMIOGBI += 0;
				ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 1682f;
				return;
			}
			OADALMIOGBI = 0;
			ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 473f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking)
			{
				skillShot2.type |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				PHLMNACBOEO(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				LMEHKIEKNBO(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
	}

	protected void OPMMGDPAMAL(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.OFLMKOOONKH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.ICBJNEMFBIP(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.BMIHHHKLCOE();
			}
		}
	}

	private void EHADHODPOEG(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal)
		{
			if (OADALMIOGBI < 0 && TimeManager.realTimeWithoutPauses <= ALPKFABKOLB)
			{
				OADALMIOGBI += 0;
				ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 116f;
				return;
			}
			OADALMIOGBI = 1;
			ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 201f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill);
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking)
			{
				skillShot2.type |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill;
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				JFFNNKGOFEB(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				PMJDCCCADFM(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
	}

	protected virtual void BMLLLOBPGIB()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += HDHPLOGHGJP;
	}

	private void NCJBLPLEKOA(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
		{
			if (OADALMIOGBI < 5 && TimeManager.realTimeWithoutPauses <= ALPKFABKOLB)
			{
				OADALMIOGBI += 0;
				ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 961f;
				return;
			}
			OADALMIOGBI = 0;
			ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 933f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking)
			{
				skillShot2.type |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill);
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				JFFNNKGOFEB(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill);
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				DNLPPDHGHCA(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
	}

	protected virtual void ONBDJLDJDCH()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += ACNCKNCEOMD;
	}

	private void NOJPCHNPCMP(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic)
		{
			if (OADALMIOGBI < 1 && TimeManager.realTimeWithoutPauses <= ALPKFABKOLB)
			{
				OADALMIOGBI += 0;
				ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 1647f;
				return;
			}
			OADALMIOGBI = 0;
			ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 1931f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner);
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				skillShot2.type |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill);
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				LAHOGILALBG(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				LAHOGILALBG(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
	}

	protected void GCGANIEGAEM(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.DBHKNGGFNPC(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.NDCPFCDOOCO();
			}
		}
	}

	protected void NMEMPLJFAAC(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.BCDJJBAFLLG().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.DCDAPPKAMCO(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.NDCPFCDOOCO();
			}
		}
	}

	protected virtual void BAGCDJMLCPF()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += EEOLPBHENDH;
	}

	protected void LAHOGILALBG(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.KHMBHIINOFD().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.BDANMFHHHOB(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.MDKGJKMGOJI();
			}
		}
	}

	private void EPALENKIENF(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal)
		{
			if (OADALMIOGBI < 1 && TimeManager.CEAFAMFNGCC() <= ALPKFABKOLB)
			{
				OADALMIOGBI += 0;
				ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 481f;
				return;
			}
			OADALMIOGBI = 1;
			ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 1789f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill;
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking)
			{
				skillShot2.type |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill);
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				JFFNNKGOFEB(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill);
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				LMEHKIEKNBO(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
	}

	protected void ADPLEDLCBGG(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.FCLNJOLBKGI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.EIBJANKMHAF(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.MDKGJKMGOJI();
			}
		}
	}

	protected virtual void FANDCCNILLD()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += EHADHODPOEG;
	}

	protected void BMIFPDGNLDH(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.KHMBHIINOFD().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.ICBJNEMFBIP(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.PlayCritical();
			}
		}
	}

	protected virtual void FIGOGIMJIIN()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += OIMHCPNILCO;
	}

	protected void PHLMNACBOEO(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.GAFFKDOELMI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.MDACOKBDIAA(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.PlayCritical();
			}
		}
	}

	protected void JFFNNKGOFEB(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.ALODNGEMIMO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.KIFEBDLANNF(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.MDKGJKMGOJI();
			}
		}
	}

	private void HDHPLOGHGJP(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
		{
			if (OADALMIOGBI < 5 && TimeManager.realTimeWithoutPauses <= ALPKFABKOLB)
			{
				OADALMIOGBI++;
				ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 179f;
				return;
			}
			OADALMIOGBI = 1;
			ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 460f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.OneHitKill;
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				skillShot2.type |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill);
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				CIADEHCGCGM(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = ~SkillShot.SkillShotType.HeadShot;
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				PHLMNACBOEO(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
	}

	protected virtual void JJEONLDHCLO()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += EPALENKIENF;
	}

	protected virtual void EEMLMJCHKLM()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += EEOLPBHENDH;
	}

	private void FGACMFHCOCP(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal)
		{
			if (OADALMIOGBI < 4 && TimeManager.CEAFAMFNGCC() <= ALPKFABKOLB)
			{
				OADALMIOGBI++;
				ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 839f;
				return;
			}
			OADALMIOGBI = 1;
			ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 620f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				skillShot2.type |= SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill;
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				OPMMGDPAMAL(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot;
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				OPMMGDPAMAL(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
	}

	protected virtual void FOIKLCECNBL()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += BEHECPMDGNI;
	}

	protected void DNLPPDHGHCA(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.BMNEPICFHNO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.BDANMFHHHOB(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.MDKGJKMGOJI();
			}
		}
	}

	private void BMJJBLBDLBE(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame)
		{
			if (OADALMIOGBI < 0 && TimeManager.CEAFAMFNGCC() <= ALPKFABKOLB)
			{
				OADALMIOGBI++;
				ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 664f;
				return;
			}
			OADALMIOGBI = 0;
			ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 1166f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill;
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				skillShot2.type |= ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered);
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				LMEHKIEKNBO(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill;
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				NMEMPLJFAAC(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
	}

	protected void FCPBGHBDODD(SkillShot IFDBMJEAGND, bool NLJFIIEGHCK, int APLODBKLDEG)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.MCJOOEEIIHI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.DBHKNGGFNPC(APLODBKLDEG, IFDBMJEAGND);
			if (NLJFIIEGHCK)
			{
				skillShotDisplayer.MDKGJKMGOJI();
			}
		}
	}

	private void JONPPNBOBDL(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
		{
			if (OADALMIOGBI < 8 && TimeManager.CEAFAMFNGCC() <= ALPKFABKOLB)
			{
				OADALMIOGBI += 0;
				ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 1147f;
				return;
			}
			OADALMIOGBI = 0;
			ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 367f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking)
			{
				skillShot2.type |= ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill);
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				NMEMPLJFAAC(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill);
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				GCGANIEGAEM(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += EEOLPBHENDH;
	}

	private void EEOLPBHENDH(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame)
		{
			if (OADALMIOGBI < 6 && TimeManager.realTimeWithoutPauses <= ALPKFABKOLB)
			{
				OADALMIOGBI++;
				ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 0.5f;
				return;
			}
			OADALMIOGBI = 0;
			ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 0.5f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = SkillShot.SkillShotType.EnemyPlayerHit;
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				skillShot2.type |= SkillShot.SkillShotType.OnTheMove;
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				PMJDCCCADFM(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = SkillShot.SkillShotType.ArmyPlayerHit;
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				PMJDCCCADFM(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
	}

	private void HEJDBBOGLJC(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal)
		{
			if (OADALMIOGBI < 6 && TimeManager.CEAFAMFNGCC() <= ALPKFABKOLB)
			{
				OADALMIOGBI += 0;
				ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 1156f;
				return;
			}
			OADALMIOGBI = 0;
			ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 1741f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill;
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				skillShot2.type |= ~SkillShot.SkillShotType.TrippleKill;
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				PHLMNACBOEO(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				KPMJHLHEJEP(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 0);
			}
		}
	}

	private void HMBGJJHOADO(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Basic)
		{
			if (OADALMIOGBI < 8 && TimeManager.realTimeWithoutPauses <= ALPKFABKOLB)
			{
				OADALMIOGBI += 0;
				ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 1756f;
				return;
			}
			OADALMIOGBI = 0;
			ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 844f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill;
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking)
			{
				skillShot2.type |= ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill);
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				CIADEHCGCGM(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				LMEHKIEKNBO(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
	}

	protected virtual void FIEKOBKAHKA()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += BEHECPMDGNI;
	}

	private void HDIMFEIBCLN(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver)
		{
			if (OADALMIOGBI < 1 && TimeManager.CEAFAMFNGCC() <= ALPKFABKOLB)
			{
				OADALMIOGBI += 0;
				ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 1419f;
				return;
			}
			OADALMIOGBI = 0;
			ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 1918f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill;
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking)
			{
				skillShot2.type |= ~(SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill);
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				LAHOGILALBG(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = ~(SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill);
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				FCPBGHBDODD(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
	}

	private void DGFPJDPJFNK(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison || KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Flame)
		{
			if (OADALMIOGBI < 0 && TimeManager.CEAFAMFNGCC() <= ALPKFABKOLB)
			{
				OADALMIOGBI++;
				ALPKFABKOLB = TimeManager.realTimeWithoutPauses + 1518f;
				return;
			}
			OADALMIOGBI = 0;
			ALPKFABKOLB = TimeManager.CEAFAMFNGCC() + 1116f;
		}
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		SkillShot skillShot;
		if (playerController != null && GPPBACMGKFF != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.MultiKill;
			SkillShot skillShot2 = skillShot;
			if (GPPBACMGKFF.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				skillShot2.type |= SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill;
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				PMJDCCCADFM(skillShot2, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
		AIObject aIObject = KMJKKNFDFMM.HNFNINFCBEJ as AIObject;
		if (!(aIObject != null) || aIObject.fraction == GPPBACMGKFF.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = SkillShot.SkillShotType.TrippleKill;
		SkillShot iFDBMJEAGND = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(iFDBMJEAGND, player);
			if (player.isCurrentPlayer)
			{
				NMEMPLJFAAC(iFDBMJEAGND, KMJKKNFDFMM.NLJFIIEGHCK, 1);
			}
		}
	}

	protected virtual void IEBHCNFALAB()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += ACNCKNCEOMD;
	}

	protected virtual void FFBBKELEEIF()
	{
		base.Awake();
		GPPBACMGKFF = GetComponent<PlayerController>();
		GPPBACMGKFF.FOCIOKMPCAG.OnDamage += JONPPNBOBDL;
	}
}
