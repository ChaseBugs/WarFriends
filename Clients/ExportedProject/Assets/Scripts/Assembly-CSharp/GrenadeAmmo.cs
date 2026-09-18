using UnityEngine;

public class GrenadeAmmo : GrenadeAmmoContent
{
	public override void ExplodeImplementation(Vector3 position)
	{
		base.ExplodeImplementation(position);
		Explosion.ExplosionInfo i = CreateExplosionInfo(position);
		Explosion.MissileExplode(i);
		grenade.DestroyPooled(0.15f);
	}

	private Explosion.ExplosionInfo CreateExplosionInfo(Vector3 position)
	{
		GrenadeAmmoSetup grenadeAmmoSetup = base.mSetup as GrenadeAmmoSetup;
		bool flag = base.weapon is Grenade && ((Grenade)base.weapon).grenadeTpe == GrenadeAmmoBase.GrenadeAmmoType.Molotov;
		Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
		explosionInfo.position = position;
		explosionInfo.explodeDamage = grenadeAmmoSetup.explodeDamageAmount;
		explosionInfo.damageAmount = grenadeAmmoSetup.damageAmount;
		explosionInfo.owner = base.mOwner;
		explosionInfo.weapon = base.weapon;
		explosionInfo.deadRadius = grenadeAmmoSetup.deadRadius;
		explosionInfo.hurtRadius = grenadeAmmoSetup.hurtRadius;
		explosionInfo.exposionCoef = grenadeAmmoSetup.exposionCoef;
		explosionInfo.additionalUpForce = grenadeAmmoSetup.additionalUpForce;
		explosionInfo.isNetworkCopy = base.isNetworkCopy;
		explosionInfo.playerBehindShieldRatio = grenadeAmmoSetup.playerBehindShieldRatio;
		explosionInfo.playerRadiusCoef = 0.7f;
		explosionInfo.type = ((!flag) ? Explosion.ExplosionType.Medium : Explosion.ExplosionType.Molotov);
		return explosionInfo;
	}

	public override void ExplodeRPCImplementation(Vector3 position)
	{
		base.ExplodeRPCImplementation(position);
		Explosion.ExplosionInfo i = CreateExplosionInfo(position);
		Explosion.MissileExplode(i);
		grenade.DestroyPooled(0.1f);
	}
}
