using UnityEngine;

public class GrenadeAmmoContent : Core_BaseScript
{
	public GrenadeAmmoBase grenade;

	protected GrenadeAmmoBaseSetup mSetup => grenade.mSetup;

	protected IFraction mOwner => grenade.mOwner;

	protected Weapon weapon => grenade.weapon;

	protected bool isNetworkCopy => grenade.isNetworkCopy;

	public virtual void ExplodeImplementation(Vector3 position)
	{
	}

	public virtual void ExplodeRPCImplementation(Vector3 position)
	{
	}

	public virtual void GroundHitted()
	{
	}

	public virtual void LoadAmmoSetup(AmmoSetup setup)
	{
	}

	public virtual void Init()
	{
	}
}
