using UnityEngine;

public class SkillShotControllerPlayer : Core_BaseScript
{
	private PlayerController mGameEntity;

	public Transform mPosition;

	private PhotonView mPhotonView;

	private int mFlameDamageIgnoreCounter = 6;

	private float mFlameDamageIgnoreTimer;

	protected override void Awake()
	{
		base.Awake();
		mGameEntity = GetComponent<PlayerController>();
		mGameEntity.destroyableParts.OnDamage += PlayerOnDamage;
	}

	private void PlayerOnDamage(DestroyableObject destroyableObject, DestroyableObject.DamageInfo info)
	{
		if (info.type == DestroyableObject.DamageType.Poison || info.type == DestroyableObject.DamageType.Immortal)
		{
			return;
		}
		if (info.type == DestroyableObject.DamageType.Flame)
		{
			if (mFlameDamageIgnoreCounter < 6 && TimeManager.realTimeWithoutPauses <= mFlameDamageIgnoreTimer)
			{
				mFlameDamageIgnoreCounter++;
				mFlameDamageIgnoreTimer = TimeManager.realTimeWithoutPauses + 0.5f;
				return;
			}
			mFlameDamageIgnoreCounter = 0;
			mFlameDamageIgnoreTimer = TimeManager.realTimeWithoutPauses + 0.5f;
		}
		PlayerController playerController = info.owner as PlayerController;
		SkillShot skillShot;
		if (playerController != null && mGameEntity != playerController)
		{
			skillShot = new SkillShot();
			skillShot.type = SkillShot.SkillShotType.EnemyPlayerHit;
			SkillShot skillShot2 = skillShot;
			if (mGameEntity.playerState == PlayerController.PlayerStatex.Walking)
			{
				skillShot2.type |= SkillShot.SkillShotType.OnTheMove;
			}
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot2, playerController);
			if (playerController.isCurrentPlayer)
			{
				PlaySkillshot(skillShot2, info.isCritical, 0);
			}
		}
		AIObject aIObject = info.owner as AIObject;
		if (!(aIObject != null) || aIObject.fraction == mGameEntity.fraction)
		{
			return;
		}
		skillShot = new SkillShot();
		skillShot.type = SkillShot.SkillShotType.ArmyPlayerHit;
		SkillShot skillShot3 = skillShot;
		PlayerController player = PlayerController.GetPlayer(aIObject.fraction);
		if (player != null)
		{
			Singleton<SkillShotManager>.instance.AddSkillshot(skillShot3, player);
			if (player.isCurrentPlayer)
			{
				PlaySkillshot(skillShot3, info.isCritical, 0);
			}
		}
	}

	protected void PlaySkillshot(SkillShot skillShot, bool isCritical, int power)
	{
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.mainObjectPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.skillShotDisplayer);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(mPosition.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.PlayDeath(power, skillShot);
			if (isCritical)
			{
				skillShotDisplayer.PlayCritical();
			}
		}
	}
}
