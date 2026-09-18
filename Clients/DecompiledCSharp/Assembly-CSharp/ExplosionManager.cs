using UnityEngine;

public class ExplosionManager : Singleton<ExplosionManager>
{
	private float hurtRadius = 1.8f;

	private float deadRadius = 1.1f;

	private Vector3 explosionCoef = new Vector3(5f, 8f, 5f);

	private float additionalUpForce = 6f;

	private PhotonView mPhotonView;

	protected override void Awake()
	{
		mPhotonView = GetComponent<PhotonView>();
	}

	public void MissileExplode(Vector3 position, float damage, IFraction owner, Weapon weapon, Explosion.ExplosionType explosionType)
	{
		MissileExplode(position, damage, 0.1f * damage, deadRadius, hurtRadius, explosionCoef, additionalUpForce, owner, weapon, 0.5f, explosionType);
	}

	public void MissileExplode(Vector3 position, float explodeDamage, float damageAmount, float deadRadius, float hurtRadius, Vector3 exposionCoef, float additionalUpForce, IFraction owner, Weapon weapon, float playerBehindShieldRatio, Explosion.ExplosionType explosionType)
	{
		Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
		explosionInfo.position = position;
		explosionInfo.explodeDamage = explodeDamage;
		explosionInfo.damageAmount = damageAmount;
		explosionInfo.owner = owner;
		explosionInfo.weapon = weapon;
		explosionInfo.deadRadius = deadRadius;
		explosionInfo.hurtRadius = hurtRadius;
		explosionInfo.exposionCoef = exposionCoef;
		explosionInfo.additionalUpForce = additionalUpForce;
		explosionInfo.isNetworkCopy = false;
		explosionInfo.playerBehindShieldRatio = playerBehindShieldRatio;
		explosionInfo.type = explosionType;
		Explosion.ExplosionInfo i = explosionInfo;
		Explosion.MissileExplode(i);
		mPhotonView.RPC("MissileExplodeRPC", PhotonTargets.Others, position, explodeDamage, damageAmount, deadRadius, hurtRadius, exposionCoef, additionalUpForce, playerBehindShieldRatio, (int)explosionType);
	}

	[PunRPC]
	protected void MissileExplodeRPC(Vector3 position, float explodeDamage, float damageAmount, float deadRadius, float hurtRadius, Vector3 exposionCoef, float additionalUpForce, float playerBehindShieldRatio, int explosionType)
	{
		Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
		explosionInfo.position = position;
		explosionInfo.explodeDamage = explodeDamage;
		explosionInfo.damageAmount = damageAmount;
		explosionInfo.owner = null;
		explosionInfo.weapon = null;
		explosionInfo.deadRadius = deadRadius;
		explosionInfo.hurtRadius = hurtRadius;
		explosionInfo.exposionCoef = exposionCoef;
		explosionInfo.additionalUpForce = additionalUpForce;
		explosionInfo.isNetworkCopy = true;
		explosionInfo.playerBehindShieldRatio = playerBehindShieldRatio;
		explosionInfo.type = (Explosion.ExplosionType)explosionType;
		Explosion.ExplosionInfo i = explosionInfo;
		Explosion.MissileExplode(i);
	}
}
