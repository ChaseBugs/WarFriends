using UnityEngine;

public class GrenadeAmmoEnemy : GrenadeAmmo
{
	private DestroyableObject mDestroyableObject;

	private HudObjectIndicator mHudIndicator;

	private bool mCanThrowAway;

	private bool mGroundHitted;

	public bool CanThrowAway
	{
		get
		{
			return mCanThrowAway;
		}
		set
		{
			if (value != mCanThrowAway)
			{
				mCanThrowAway = value;
				mHudIndicator.Show(mCanThrowAway);
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mDestroyableObject = GetComponent<DestroyableObject>();
		mDestroyableObject.OnDeath += DestroyableObjectOnOnDeath;
		mDestroyableObject.isMetal = true;
		mHudIndicator = GetComponent<HudObjectIndicator>();
	}

	public override void GroundHitted()
	{
		base.GroundHitted();
		mGroundHitted = true;
	}

	private void DestroyableObjectOnOnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		if (base.enabled && grenade != null && grenade.photonView.isMine)
		{
			grenade.Explode();
		}
	}

	public override void ExplodeImplementation(Vector3 position)
	{
		CanThrowAway = false;
		mDestroyableObject.Disable();
		base.ExplodeImplementation(position);
	}

	public override void ExplodeRPCImplementation(Vector3 position)
	{
		CanThrowAway = false;
		mDestroyableObject.Disable();
		base.ExplodeRPCImplementation(position);
	}

	public override void Init()
	{
		mDestroyableObject.RefillOffline();
		CanThrowAway = false;
		StopAllCoroutines();
		mGroundHitted = false;
	}

	protected void Update()
	{
		if (base.mOwner != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(base.mOwner.fraction);
			CanThrowAway = Vector3.Distance(base.transform.position, enemyOf.transform.position) < 2f && enemyOf == PlayerController.currentPlayer && mGroundHitted && base.mSetup.explodeAfterTime > 0.1f && !grenade.exploded;
		}
	}
}
