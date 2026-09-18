using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourMortar : SoldierBehaviourGeneric<SoldierBehaviourDefinititonMortar>
{
	protected override void ApplyWeaponsSetup()
	{
		base.ApplyWeaponsSetup();
		MissileSetup missileSetup = (MissileSetup)mWeapons[0].ammoSetup;
		missileSetup.speed = 20f;
		missileSetup.stopTime = 1f / base.soldierBehaviourDefinititon.shotSpeed;
		missileSetup.damageAmount = (float)base.mBehaviourDef.damage * 0.1f;
		missileSetup.explodeDamageAmount = base.mBehaviourDef.damage;
		missileSetup.playerBehindShieldRatio = upgradeSlots.playerBehindShieldDamageRatio;
	}

	private void PickPlayer(float shieldProb = 0.5f)
	{
		if (!(shieldProb < 0f))
		{
			PlayerController randomEnemy = PlayerController.GetRandomEnemy(controller.fraction);
			GameShootableEntity gameShootableEntity = randomEnemy.gameShootableEntity;
			if (randomEnemy.playerState == PlayerController.PlayerStatex.Walking)
			{
				shieldProb *= 0.5f;
			}
			List<GameShootableEntity.ShotTarget> shotTargets = gameShootableEntity.GetShotTargets(GameShootableEntity.ShotTargetType.Shield);
			if (shotTargets.Count > 0)
			{
				int index = Random.Range(0, shotTargets.Count);
				mShotTarget = shotTargets[index];
				targetPosition = mShotTarget.transform.position;
			}
		}
	}

	public override void PickTarget()
	{
		PickPlayer(upgradeSlots.shieldHitProbability);
		targetPosition -= Vector3.up * 0.4f;
	}

	public override void StandShoot()
	{
		controller.SwitchState(EnemyController.EnemyAIState.Mortar);
	}
}
