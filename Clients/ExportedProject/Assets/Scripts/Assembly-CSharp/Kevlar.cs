using UnityEngine;

public class Kevlar : Core_BaseScript
{
	public DestroyableObject destroyableObject;

	public DestroyableObject kevlarDestroyableObject;

	private PhotonView photonView;

	private bool selfHostedActive;

	public float kevlarStrength = 0.2f;

	public void ApplySelfHostedState(float health, float maximum)
	{
		if (float.IsNaN(health) || float.IsInfinity(health) ||
			float.IsNaN(maximum) || float.IsInfinity(maximum) ||
			maximum < 0f || health < 0f || health > maximum)
			throw new System.InvalidOperationException("Invalid authoritative Kevlar state.");
		if (health == 0f)
		{
			if (selfHostedActive)
				kevlarDestroyableObject.enabled = false;
			selfHostedActive = false;
			return;
		}
		if (!selfHostedActive)
		{
			kevlarDestroyableObject.owner = destroyableObject.owner;
			kevlarDestroyableObject.healthBarPosition.transform.parent =
				destroyableObject.healthBarPosition.parent;
			kevlarDestroyableObject.healthBarPosition.transform.localPosition =
				destroyableObject.healthBarPosition.localPosition;
			kevlarDestroyableObject.offset = new Vector3(0f, 3.6f, 0f);
			destroyableObject.forceHealthBar = true;
			selfHostedActive = true;
		}
		kevlarDestroyableObject.maxHealth = maximum;
		kevlarDestroyableObject.health = health;
		kevlarDestroyableObject.enabled = true;
	}

	protected override void Awake()
	{
		base.Awake();
		photonView = GetComponent<PhotonView>();
		kevlarDestroyableObject.OnDeath += KevlarDestroyableObjectOnOnDeath;
	}

	private void KevlarDestroyableObjectOnOnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		ClearKevlar();
	}

	private void MainObjectOnDamage(DestroyableObject destroyableObj, DestroyableObject.DamageInfo damageInfo)
	{
		if (!damageInfo.isNetwork)
		{
			if (!destroyableObject.isImmortal)
			{
				destroyableObject.health += Mathf.Max(0f, Mathf.Min(damageInfo.originalDamage, kevlarDestroyableObject.health));
			}
			kevlarDestroyableObject.DoDamage(new DestroyableObject.DamageInfo
			{
				damageAmount = Mathf.Max(0f, damageInfo.originalDamage),
				isNetwork = false,
				type = damageInfo.type
			});
			if (kevlarDestroyableObject.health <= 0f)
			{
				ClearKevlar();
			}
			damageInfo.originalDamage = 0f;
			photonView.RPC("SyncKevlar", PhotonTargets.Others, kevlarDestroyableObject.health, kevlarDestroyableObject.maxHealth);
		}
	}

	public void SetUpKevlar(int stackIndex = 1)
	{
		kevlarDestroyableObject.owner = destroyableObject.owner;
		kevlarDestroyableObject.healthBarPosition.transform.parent = destroyableObject.healthBarPosition.parent;
		kevlarDestroyableObject.healthBarPosition.transform.localPosition = destroyableObject.healthBarPosition.localPosition;
		kevlarDestroyableObject.offset = ((!(destroyableObject.owner is EnemyController)) ? new Vector3(0f, 3.6f * (float)stackIndex, 0f) : new Vector3(0f, 1.7f * (float)stackIndex, 0f));
		destroyableObject.OnDamage -= MainObjectOnDamage;
		destroyableObject.OnDamage += MainObjectOnDamage;
		kevlarDestroyableObject.enabled = true;
		kevlarDestroyableObject.maxHealth = kevlarStrength * destroyableObject.maxHealth;
		destroyableObject.forceHealthBar = true;
		kevlarDestroyableObject.Refill();
		photonView.RPC("SetUpKevlarNetwork", PhotonTargets.Others, kevlarDestroyableObject.maxHealth, stackIndex);
	}

	public void ClearKevlar()
	{
		destroyableObject.OnDamage -= MainObjectOnDamage;
		kevlarDestroyableObject.enabled = false;
	}

	[PunRPC]
	private void SyncKevlar(float health, float maxHealth)
	{
		kevlarDestroyableObject.maxHealth = maxHealth;
		kevlarDestroyableObject.health = health;
		if (kevlarDestroyableObject.health <= 0f)
		{
			destroyableObject.OnDamage -= MainObjectOnDamage;
			kevlarDestroyableObject.enabled = false;
		}
	}

	[PunRPC]
	private void SetUpKevlarNetwork(float maxHealth, int stackIndex)
	{
		kevlarDestroyableObject.owner = destroyableObject.owner;
		kevlarDestroyableObject.healthBarPosition.transform.parent = destroyableObject.healthBarPosition.parent;
		kevlarDestroyableObject.healthBarPosition.transform.localPosition = destroyableObject.healthBarPosition.localPosition;
		kevlarDestroyableObject.offset = ((!(destroyableObject.owner is EnemyController)) ? new Vector3(0f, 3.6f * (float)stackIndex, 0f) : new Vector3(0f, 1.7f * (float)stackIndex, 0f));
		destroyableObject.OnDamage += MainObjectOnDamage;
		kevlarDestroyableObject.enabled = true;
		kevlarDestroyableObject.maxHealth = maxHealth;
		destroyableObject.forceHealthBar = true;
		kevlarDestroyableObject.Refill();
	}
}
