using UnityEngine;

public class SkillShotControllerBonusBox : SkillShotController
{
	public AudioClip stolenSound;

	protected override void GameEntityOnKilled(IGameMainEntity gameMainEntity, DestroyableObject.DamageInfo info)
	{
	}

	public void Play(Fractions fraction)
	{
		PlayStolen(fraction != PlayerController.currentPlayer.fraction);
		mPhotonView.RPC("RecieveStolen", PhotonTargets.Others, (byte)fraction);
	}

	[PunRPC]
	protected void RecieveStolen(byte fraction)
	{
		PlayStolen((Fractions)fraction != PlayerController.currentPlayer.fraction);
	}

	protected void PlayStolen(bool wasStolen)
	{
		if (wasStolen)
		{
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, stolenSound);
		}
		if (!wasStolen)
		{
			StatsManager.instance.matchStats.cratesStolen++;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.mainObjectPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.skillShotDisplayer);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(skillshotPosition.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.PlayBoxStolen(wasStolen);
		}
	}
}
