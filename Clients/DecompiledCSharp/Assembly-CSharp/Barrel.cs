using UnityEngine;

public class Barrel : PoolableObject
{
	public ParticleSystem damageParticles;

	private PhotonView mPhotonView;

	protected override void Awake()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		mPhotonView = GetComponent<PhotonView>();
		component.OnDamage += OnOnDamage;
		component.OnDeath += OnDeath;
		base.Awake();
		damageParticles.gameObject.SetActive(value: false);
		if (mPhotonView.isMine)
		{
			float num = (float)PlayerController.currentPlayer.playerProperties.level / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 50f + num * 6f;
			component.Refill();
		}
	}

	private void OnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		DestroyPooled(0.2f);
		Singleton<HitParticleSystem>.instance.PlayParticles(base.transform.position, Vector3.up, "metalExplosion", "grenadeExplosion");
		Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
		explosionInfo.position = base.transform.position;
		explosionInfo.explodeDamage = 180f;
		explosionInfo.damageAmount = 15f;
		explosionInfo.owner = null;
		explosionInfo.isNetworkCopy = !mPhotonView.isMine;
		explosionInfo.type = Explosion.ExplosionType.Barel;
		Explosion.ExplosionInfo i = explosionInfo;
		Explosion.Explode(i);
	}

	private void OnOnDamage(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		damageParticles.gameObject.SetActive(value: true);
		damageParticles.Play();
	}
}
