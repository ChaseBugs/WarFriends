using UnityEngine;

public class UnitShield : Core_BaseScript
{
	public DestroyableObject destroyableObject;

	public DestroyableObject shieldDestroyableObject;

	public float shieldStrength = 0.2f;

	public float shieldRechargeRate = 0.33f;

	private PhotonView mPhotonView;

	private float mShieldSyncTimer;

	private int mHitCount;

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
		shieldDestroyableObject.OnDeath += ShieldDestroyableObjectOnOnDeath;
	}

	private void Update()
	{
		if (!mPhotonView.isMine || !shieldDestroyableObject.enabled)
		{
			return;
		}
		mShieldSyncTimer += Time.deltaTime;
		if (shieldDestroyableObject.health < shieldDestroyableObject.maxHealth)
		{
			shieldDestroyableObject.health += Time.deltaTime * shieldDestroyableObject.maxHealth * shieldRechargeRate;
			if (mShieldSyncTimer > 0.2f)
			{
				mShieldSyncTimer -= 0.2f;
				mPhotonView.RPC("SyncShield", PhotonTargets.Others, shieldDestroyableObject.health, mHitCount);
			}
		}
	}

	private void ShieldDestroyableObjectOnOnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		ClearShield();
	}

	private void MainObjectOnDamage(DestroyableObject destroyableObj, DestroyableObject.DamageInfo damageInfo)
	{
		if (!damageInfo.isNetwork)
		{
			if (!destroyableObject.isImmortal)
			{
				destroyableObject.health += Mathf.Max(0f, Mathf.Min(damageInfo.originalDamage, shieldDestroyableObject.health));
			}
			shieldDestroyableObject.DoDamage(new DestroyableObject.DamageInfo
			{
				damageAmount = Mathf.Max(0f, damageInfo.originalDamage),
				isNetwork = false,
				type = damageInfo.type
			});
			if (shieldDestroyableObject.health <= 0f)
			{
				ClearShield();
			}
			mPhotonView.RPC("SyncShield", PhotonTargets.Others, shieldDestroyableObject.health, ++mHitCount);
		}
	}

	public void SetUpShield(int stackIndex = 1)
	{
		shieldDestroyableObject.owner = destroyableObject.owner;
		shieldDestroyableObject.healthBarPosition.transform.parent = destroyableObject.healthBarPosition.parent;
		shieldDestroyableObject.healthBarPosition.transform.localPosition = destroyableObject.healthBarPosition.localPosition;
		shieldDestroyableObject.offset = ((!(destroyableObject.owner is EnemyController)) ? new Vector3(0f, 3.6f * (float)stackIndex, 0f) : new Vector3(0f, 1.7f * (float)stackIndex, 0f));
		destroyableObject.OnDamage -= MainObjectOnDamage;
		destroyableObject.OnDamage += MainObjectOnDamage;
		shieldDestroyableObject.enabled = true;
		shieldDestroyableObject.maxHealth = shieldStrength * destroyableObject.maxHealth;
		destroyableObject.forceHealthBar = true;
		mHitCount = 0;
		shieldDestroyableObject.Refill();
		mPhotonView.RPC("SetUpShieldNetwork", PhotonTargets.Others, shieldDestroyableObject.maxHealth);
	}

	public void ClearShield()
	{
		destroyableObject.OnDamage -= MainObjectOnDamage;
		shieldDestroyableObject.enabled = false;
	}

	public bool IsActive()
	{
		return shieldDestroyableObject.enabled;
	}

	[PunRPC]
	private void SyncShield(float health, int hitCount)
	{
		if (hitCount >= mHitCount)
		{
			shieldDestroyableObject.health = health;
			if (shieldDestroyableObject.health <= 0f)
			{
				destroyableObject.OnDamage -= MainObjectOnDamage;
				shieldDestroyableObject.enabled = false;
			}
			mHitCount = hitCount;
		}
	}

	[PunRPC]
	private void SetUpShieldNetwork(float maxHealth)
	{
		shieldDestroyableObject.owner = destroyableObject.owner;
		shieldDestroyableObject.healthBarPosition.transform.parent = destroyableObject.healthBarPosition.parent;
		shieldDestroyableObject.healthBarPosition.transform.localPosition = destroyableObject.healthBarPosition.localPosition;
		shieldDestroyableObject.offset = ((!(destroyableObject.owner is EnemyController)) ? new Vector3(0f, 3.6f, 0f) : new Vector3(0f, 1.7f, 0f));
		destroyableObject.OnDamage += MainObjectOnDamage;
		shieldDestroyableObject.enabled = true;
		shieldDestroyableObject.maxHealth = maxHealth;
		destroyableObject.forceHealthBar = true;
		mHitCount = 0;
		shieldDestroyableObject.Refill();
	}
}
