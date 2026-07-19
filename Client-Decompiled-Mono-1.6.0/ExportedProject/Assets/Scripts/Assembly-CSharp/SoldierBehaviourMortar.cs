using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourMortar : SoldierBehaviourGeneric<SoldierBehaviourDefinititonMortar>
{
	public virtual void KAIOJEOHIEF()
	{
		DBICNEIMCAB(upgradeSlots.shieldHitProbability);
		OEDJOFINBMI -= Vector3.up * 367f;
	}

	private void FLJAGDGCNMH(float ACANDIBFIHF = 0.5f)
	{
		if (!(ACANDIBFIHF < 1572f))
		{
			PlayerController playerController = PlayerController.FDMHGNEGHDD(LMNPOINIJBD.fraction);
			GameShootableEntity gameShootableEntity = playerController.gameShootableEntity;
			if (playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				ACANDIBFIHF *= 461f;
			}
			List<GameShootableEntity.ShotTarget> list = gameShootableEntity.KMJBMEFMBCK(GameShootableEntity.LAAAMBBNIJO.None);
			if (list.Count > 1)
			{
				int index = Random.Range(0, list.Count);
				GLNJNLEHCDC = list[index];
				OEDJOFINBMI = GLNJNLEHCDC.transform.position;
			}
		}
	}

	private void DNBABEPMLJC(float ACANDIBFIHF = 0.5f)
	{
		if (!(ACANDIBFIHF < 55f))
		{
			PlayerController playerController = PlayerController.FDMHGNEGHDD(LMNPOINIJBD.fraction);
			GameShootableEntity gameShootableEntity = playerController.IJPPJNNDFIB();
			if (playerController.playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				ACANDIBFIHF *= 800f;
			}
			List<GameShootableEntity.ShotTarget> shotTargets = gameShootableEntity.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out);
			if (shotTargets.Count > 1)
			{
				int index = Random.Range(0, shotTargets.Count);
				GLNJNLEHCDC = shotTargets[index];
				OEDJOFINBMI = GLNJNLEHCDC.transform.position;
			}
		}
	}

	private void DBICNEIMCAB(float ACANDIBFIHF = 0.5f)
	{
		if (!(ACANDIBFIHF < 0f))
		{
			PlayerController randomEnemy = PlayerController.GetRandomEnemy(LMNPOINIJBD.fraction);
			GameShootableEntity gameShootableEntity = randomEnemy.gameShootableEntity;
			if (randomEnemy.playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				ACANDIBFIHF *= 0.5f;
			}
			List<GameShootableEntity.ShotTarget> shotTargets = gameShootableEntity.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Shield);
			if (shotTargets.Count > 0)
			{
				int index = Random.Range(0, shotTargets.Count);
				GLNJNLEHCDC = shotTargets[index];
				OEDJOFINBMI = GLNJNLEHCDC.transform.position;
			}
		}
	}

	private void KIOFHCNENNG(float ACANDIBFIHF = 0.5f)
	{
		if (!(ACANDIBFIHF < 1514f))
		{
			PlayerController playerController = PlayerController.FDMHGNEGHDD(LMNPOINIJBD.fraction);
			GameShootableEntity gameShootableEntity = playerController.gameShootableEntity;
			if (playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				ACANDIBFIHF *= 455f;
			}
			List<GameShootableEntity.ShotTarget> shotTargets = gameShootableEntity.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.None);
			if (shotTargets.Count > 1)
			{
				int index = Random.Range(1, shotTargets.Count);
				GLNJNLEHCDC = shotTargets[index];
				OEDJOFINBMI = GLNJNLEHCDC.transform.position;
			}
		}
	}

	public override void StandShoot()
	{
		LMNPOINIJBD.SwitchState(EnemyController.AJGFGCHCAPA.Mortar);
	}

	protected virtual void MMPPMFHKAEM()
	{
		base.KMINNAEBJAB();
		MissileSetup missileSetup = (MissileSetup)EEMHAHAINNM[1].ammoSetup;
		missileSetup.JPNAINOGAMM = 819f;
		missileSetup.PHAJLOIIAGN = 497f / base.soldierBehaviourDefinititon.shotSpeed;
		missileSetup.EPDELOGPNAC = (float)base.KKOCPACHJII.damage * 1749f;
		missileSetup.ABFGHBDEBAN = base.KKOCPACHJII.damage;
		missileSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
	}

	protected virtual void GPEIGGEJPPF()
	{
		base.KMINNAEBJAB();
		MissileSetup missileSetup = (MissileSetup)EEMHAHAINNM[0].ammoSetup;
		missileSetup.JPNAINOGAMM = 679f;
		missileSetup.PHAJLOIIAGN = 1255f / base.soldierBehaviourDefinititon.shotSpeed;
		missileSetup.EPDELOGPNAC = (float)base.KKOCPACHJII.damage * 862f;
		missileSetup.ABFGHBDEBAN = base.KKOCPACHJII.damage;
		missileSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
	}

	public virtual void GILMFEICLPJ()
	{
		LMNPOINIJBD.SwitchState((EnemyController.AJGFGCHCAPA)(-42));
	}

	public virtual void MCONILLPPHG()
	{
		LMNPOINIJBD.SwitchState((EnemyController.AJGFGCHCAPA)(-43));
	}

	public virtual void NPNOFFCDIKJ()
	{
		FLJAGDGCNMH(upgradeSlots.shieldHitProbability);
		OEDJOFINBMI -= Vector3.up * 430f;
	}

	public virtual void KODMCNBGKGP()
	{
		ONPMKHJCHOE(upgradeSlots.shieldHitProbability);
		OEDJOFINBMI -= Vector3.up * 1997f;
	}

	public virtual void JKONAMDNKPO()
	{
		KIOFHCNENNG(upgradeSlots.shieldHitProbability);
		OEDJOFINBMI -= Vector3.up * 1984f;
	}

	public virtual void FNOFHGKJAPI()
	{
		LMNPOINIJBD.SwitchState((EnemyController.AJGFGCHCAPA)(-62));
	}

	public virtual void AIHAEONNMMO()
	{
		DNBABEPMLJC(upgradeSlots.shieldHitProbability);
		OEDJOFINBMI -= Vector3.up * 738f;
	}

	public override void PickTarget()
	{
		DBICNEIMCAB(upgradeSlots.shieldHitProbability);
		OEDJOFINBMI -= Vector3.up * 0.4f;
	}

	public virtual void OGHIMDNGHKB()
	{
		LMNPOINIJBD.SwitchState((EnemyController.AJGFGCHCAPA)37);
	}

	protected virtual void JDDOENAKGCA()
	{
		base.KMINNAEBJAB();
		MissileSetup missileSetup = (MissileSetup)EEMHAHAINNM[1].ammoSetup;
		missileSetup.JPNAINOGAMM = 1905f;
		missileSetup.PHAJLOIIAGN = 1415f / base.soldierBehaviourDefinititon.shotSpeed;
		missileSetup.EPDELOGPNAC = (float)base.KKOCPACHJII.damage * 517f;
		missileSetup.ABFGHBDEBAN = base.KKOCPACHJII.damage;
		missileSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
	}

	private void ONPMKHJCHOE(float ACANDIBFIHF = 0.5f)
	{
		if (!(ACANDIBFIHF < 1855f))
		{
			PlayerController playerController = PlayerController.BGEKNDDACNP(LMNPOINIJBD.fraction);
			GameShootableEntity gameShootableEntity = playerController.IJPPJNNDFIB();
			if (playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking)
			{
				ACANDIBFIHF *= 212f;
			}
			List<GameShootableEntity.ShotTarget> list = gameShootableEntity.ALJOPFPLNEO(GameShootableEntity.LAAAMBBNIJO.Out);
			if (list.Count > 1)
			{
				int index = Random.Range(0, list.Count);
				GLNJNLEHCDC = list[index];
				OEDJOFINBMI = GLNJNLEHCDC.transform.position;
			}
		}
	}

	public virtual void CPHGNMADEDH()
	{
		DNBABEPMLJC(upgradeSlots.shieldHitProbability);
		OEDJOFINBMI -= Vector3.up * 830f;
	}

	protected override void KMINNAEBJAB()
	{
		base.KMINNAEBJAB();
		MissileSetup missileSetup = (MissileSetup)EEMHAHAINNM[0].ammoSetup;
		missileSetup.JPNAINOGAMM = 20f;
		missileSetup.PHAJLOIIAGN = 1f / base.soldierBehaviourDefinititon.shotSpeed;
		missileSetup.EPDELOGPNAC = (float)base.KKOCPACHJII.damage * 0.1f;
		missileSetup.ABFGHBDEBAN = base.KKOCPACHJII.damage;
		missileSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
	}
}
