using UnityEngine;

public class MolotovGrenadeAmmo : GrenadeAmmoContent
{
	public override void LoadAmmoSetup(AmmoSetup setup)
	{
		base.LoadAmmoSetup(setup);
	}

	public override void ExplodeImplementation(Vector3 position)
	{
		GrenadeAmmoSetup grenadeAmmoSetup = base.mSetup as GrenadeAmmoSetup;
		Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
		explosionInfo.position = base.transform.position;
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
		Explosion.ExplosionInfo i = explosionInfo;
		Singleton<SoundsManager3D>.instance.PlayOneShot(base.gameObject, Sounds3DEnum.MolotovImpact);
		Explosion.MissileExplode(i);
		grenade.DestroyPooled(0.3f);
	}

	public override void ExplodeRPCImplementation(Vector3 position)
	{
		base.ExplodeRPCImplementation(position);
		GrenadeAmmoSetup grenadeAmmoSetup = base.mSetup as GrenadeAmmoSetup;
		Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
		explosionInfo.position = base.transform.position;
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
		Explosion.ExplosionInfo i = explosionInfo;
		Singleton<SoundsManager3D>.instance.PlayOneShot(base.gameObject, Sounds3DEnum.MolotovImpact);
		Explosion.MissileExplode(i);
		grenade.DestroyPooled(0.3f);
	}
}
