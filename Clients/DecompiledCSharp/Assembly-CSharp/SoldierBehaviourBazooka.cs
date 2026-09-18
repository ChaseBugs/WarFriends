public class SoldierBehaviourBazooka : SoldierBehaviourGeneric<SoldierBehaviourDefinititonBazooka>
{
	public override void ShootJustStarted()
	{
		base.ShootJustStarted();
	}

	public override void StartEnemyBehaviour()
	{
		base.StartEnemyBehaviour();
	}

	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		MissileSetup missileSetup = (MissileSetup)mWeapons[0].ammoSetup;
		missileSetup.damageAmount = (float)base.mBehaviourDef.damage * 0.1f;
		missileSetup.explodeDamageAmount = base.mBehaviourDef.damage;
		missileSetup.playerBehindShieldRatio = upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.speed = ((!controller.hasSpecial) ? 3f : ((1f + base.soldierBehaviourDefinititon.special) * 3f));
	}

	public override void PickTarget()
	{
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(controller.fraction);
		GameShootableEntity gameShootableEntity = randomEnemy.gameShootableEntity;
		GameShootableEntity.ShotTarget nearestTarget = gameShootableEntity.GetNearestTarget(GameShootableEntity.ShotTargetType.Shield, base.transform.position);
		if (nearestTarget != null)
		{
			targetPosition = nearestTarget.transform.position;
			mShotTarget = nearestTarget;
		}
	}
}
