public class SoldierBehaviourBazooka : SoldierBehaviourGeneric<SoldierBehaviourDefinititonBazooka>
{
	public virtual void IAEKGFEGPCH()
	{
		base.ShootJustStarted();
	}

	protected virtual void EFPGIJHLHBB()
	{
		base.KMINNAEBJAB();
		MissileSetup missileSetup = (MissileSetup)EEMHAHAINNM[0].ammoSetup;
		missileSetup.EPDELOGPNAC = (float)base.KKOCPACHJII.damage * 1312f;
		missileSetup.ABFGHBDEBAN = base.KKOCPACHJII.damage;
		missileSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.JPNAINOGAMM = ((!LMNPOINIJBD.hasSpecial) ? 1224f : ((1743f + base.soldierBehaviourDefinititon.special) * 612f));
	}

	protected override void KMINNAEBJAB()
	{
		base.KMINNAEBJAB();
		MissileSetup missileSetup = (MissileSetup)EEMHAHAINNM[0].ammoSetup;
		missileSetup.EPDELOGPNAC = (float)base.KKOCPACHJII.damage * 0.1f;
		missileSetup.ABFGHBDEBAN = base.KKOCPACHJII.damage;
		missileSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.JPNAINOGAMM = ((!LMNPOINIJBD.hasSpecial) ? 3f : ((1f + base.soldierBehaviourDefinititon.special) * 3f));
	}

	public virtual void BIEHFMDOCIG()
	{
		PlayerController playerController = PlayerController.BGEKNDDACNP(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = playerController.IJPPJNNDFIB();
		GameShootableEntity.ShotTarget nearestTarget = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Out, base.transform.position);
		if (nearestTarget != null)
		{
			OEDJOFINBMI = nearestTarget.transform.position;
			GLNJNLEHCDC = nearestTarget;
		}
	}

	public virtual void JDEAFMHPCFG()
	{
		PlayerController playerController = PlayerController.BAEIKGKJOIN(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = playerController.IJPPJNNDFIB();
		GameShootableEntity.ShotTarget nearestTarget = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Head, base.transform.position);
		if (nearestTarget != null)
		{
			OEDJOFINBMI = nearestTarget.transform.position;
			GLNJNLEHCDC = nearestTarget;
		}
	}

	public virtual void MMECIFFNDLB()
	{
		base.ShootJustStarted();
	}

	public virtual void DKDKCIKDGMI()
	{
		base.StartEnemyBehaviour();
	}

	public virtual void KOKHDDEHBFD()
	{
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = randomEnemy.IJPPJNNDFIB();
		GameShootableEntity.ShotTarget shotTarget = gameShootableEntity.KLFLBCHDNBI(GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Out, base.transform.position);
		if (shotTarget != null)
		{
			OEDJOFINBMI = shotTarget.transform.position;
			GLNJNLEHCDC = shotTarget;
		}
	}

	public virtual void BBPHEIPNPPF()
	{
		base.StartEnemyBehaviour();
	}

	protected virtual void ECLKNHLFENC()
	{
		base.KMINNAEBJAB();
		MissileSetup missileSetup = (MissileSetup)EEMHAHAINNM[0].ammoSetup;
		missileSetup.EPDELOGPNAC = (float)base.KKOCPACHJII.damage * 734f;
		missileSetup.ABFGHBDEBAN = base.KKOCPACHJII.damage;
		missileSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.JPNAINOGAMM = ((!LMNPOINIJBD.hasSpecial) ? 1237f : ((835f + base.soldierBehaviourDefinititon.special) * 1982f));
	}

	public virtual void MCOFIEDFGFH()
	{
		base.StartEnemyBehaviour();
	}

	public virtual void KAIOJEOHIEF()
	{
		PlayerController playerController = PlayerController.BGEKNDDACNP(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = playerController.IJPPJNNDFIB();
		GameShootableEntity.ShotTarget shotTarget = gameShootableEntity.KLFLBCHDNBI(GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield, base.transform.position);
		if (shotTarget != null)
		{
			OEDJOFINBMI = shotTarget.transform.position;
			GLNJNLEHCDC = shotTarget;
		}
	}

	public virtual void BOFCCNAAJFK()
	{
		PlayerController playerController = PlayerController.BAEIKGKJOIN(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = playerController.IJPPJNNDFIB();
		GameShootableEntity.ShotTarget nearestTarget = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.None, base.transform.position);
		if (nearestTarget != null)
		{
			OEDJOFINBMI = nearestTarget.transform.position;
			GLNJNLEHCDC = nearestTarget;
		}
	}

	public override void StartEnemyBehaviour()
	{
		base.StartEnemyBehaviour();
	}

	public virtual void DEGMOEBAHFE()
	{
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = randomEnemy.gameShootableEntity;
		GameShootableEntity.ShotTarget shotTarget = gameShootableEntity.KLFLBCHDNBI(GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out, base.transform.position);
		if (shotTarget != null)
		{
			OEDJOFINBMI = shotTarget.transform.position;
			GLNJNLEHCDC = shotTarget;
		}
	}

	public virtual void IBAMEEMHJGC()
	{
		base.StartEnemyBehaviour();
	}

	public virtual void GALIGAEPEGA()
	{
		base.StartEnemyBehaviour();
	}

	public virtual void DMKPKAAKLNB()
	{
		base.ShootJustStarted();
	}

	protected virtual void JGKEECKDGME()
	{
		base.KMINNAEBJAB();
		MissileSetup missileSetup = (MissileSetup)EEMHAHAINNM[0].ammoSetup;
		missileSetup.EPDELOGPNAC = (float)base.KKOCPACHJII.damage * 226f;
		missileSetup.ABFGHBDEBAN = base.KKOCPACHJII.damage;
		missileSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.JPNAINOGAMM = ((!LMNPOINIJBD.hasSpecial) ? 209f : ((883f + base.soldierBehaviourDefinititon.special) * 1976f));
	}

	public virtual void BDIOIOLMOPE()
	{
		base.StartEnemyBehaviour();
	}

	public virtual void MNFAMPCEFFH()
	{
		base.StartEnemyBehaviour();
	}

	public virtual void PBOPLOCAJCK()
	{
		base.ShootJustStarted();
	}

	public virtual void CLFFMHNNINE()
	{
		base.ShootJustStarted();
	}

	public virtual void HEAAEGEJLNM()
	{
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = randomEnemy.gameShootableEntity;
		GameShootableEntity.ShotTarget nearestTarget = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.None, base.transform.position);
		if (nearestTarget != null)
		{
			OEDJOFINBMI = nearestTarget.transform.position;
			GLNJNLEHCDC = nearestTarget;
		}
	}

	public virtual void PCHIKBBJCCE()
	{
		base.StartEnemyBehaviour();
	}

	protected virtual void ABHLPNFCEFN()
	{
		base.KMINNAEBJAB();
		MissileSetup missileSetup = (MissileSetup)EEMHAHAINNM[0].ammoSetup;
		missileSetup.EPDELOGPNAC = (float)base.KKOCPACHJII.damage * 958f;
		missileSetup.ABFGHBDEBAN = base.KKOCPACHJII.damage;
		missileSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.JPNAINOGAMM = ((!LMNPOINIJBD.hasSpecial) ? 1151f : ((1063f + base.soldierBehaviourDefinititon.special) * 1131f));
	}

	protected virtual void HDGGFDICAMP()
	{
		base.KMINNAEBJAB();
		MissileSetup missileSetup = (MissileSetup)EEMHAHAINNM[0].ammoSetup;
		missileSetup.EPDELOGPNAC = (float)base.KKOCPACHJII.damage * 1078f;
		missileSetup.ABFGHBDEBAN = base.KKOCPACHJII.damage;
		missileSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.JPNAINOGAMM = ((!LMNPOINIJBD.hasSpecial) ? 1286f : ((1658f + base.soldierBehaviourDefinititon.special) * 137f));
	}

	protected virtual void JDDOENAKGCA()
	{
		base.KMINNAEBJAB();
		MissileSetup missileSetup = (MissileSetup)EEMHAHAINNM[1].ammoSetup;
		missileSetup.EPDELOGPNAC = (float)base.KKOCPACHJII.damage * 806f;
		missileSetup.ABFGHBDEBAN = base.KKOCPACHJII.damage;
		missileSetup.MAOPCAMOEEK = upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.JPNAINOGAMM = ((!LMNPOINIJBD.hasSpecial) ? 711f : ((924f + base.soldierBehaviourDefinititon.special) * 1539f));
	}

	public override void ShootJustStarted()
	{
		base.ShootJustStarted();
	}

	public override void PickTarget()
	{
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = randomEnemy.gameShootableEntity;
		GameShootableEntity.ShotTarget nearestTarget = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Shield, base.transform.position);
		if (nearestTarget != null)
		{
			OEDJOFINBMI = nearestTarget.transform.position;
			GLNJNLEHCDC = nearestTarget;
		}
	}
}
