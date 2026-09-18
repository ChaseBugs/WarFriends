using System;
using UnityEngine;

[RequireComponent(typeof(DestroyableObject))]
public class KillStreakBonusBox : PoolableObject, IFraction, IGameMainEntity
{
	private DestroyableObject mDestroyableObject;

	public KillStreakBonus bonusToActivate;

	public Transform killStreakPosition;

	private Transform mTransform;

	private bool mOnGround;

	public Material blueMat;

	public Material redMat;

	public int boxID;

	public AudioClip destroySound;

	public AudioClip stolenSound;

	public AudioClip crateFallSound;

	private SkillShotControllerBonusBox mSkillShotController;

	public Fractions fraction
	{
		get
		{
			return Fractions.None;
		}
		set
		{
		}
	}

	public IFraction owner { get; set; }

	public int power { get; set; }

	public bool isAlive { get; set; }

	public bool onGround
	{
		get
		{
			return mOnGround;
		}
		set
		{
			mOnGround = value;
		}
	}

	public event Action<IGameMainEntity, DestroyableObject.DamageInfo> Killed;

	public event Action<IGameMainEntity, Fractions, Fractions> FractionChanged;

	protected override void Awake()
	{
		base.Awake();
		mDestroyableObject = GetComponent<DestroyableObject>();
		mSkillShotController = GetComponent<SkillShotControllerBonusBox>();
		mDestroyableObject.OnDeath += OnDeath;
		mTransform = base.transform;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		mDestroyableObject.maxHealth = 1f;
		mDestroyableObject.RefillOffline();
		onGround = false;
	}

	protected void Update()
	{
		killStreakPosition.position = mTransform.position + Vector3.up * 0.7f;
	}

	private void OnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		AudioSource audioSource = Singleton<SoundsManager3D>.instance.Play(mTransform.position, destroySound);
		if (!damageInfo.isNetwork)
		{
			if (damageInfo.owner != null)
			{
				PlayerController playerOld = PlayerController.GetPlayerOld(damageInfo.owner.fraction);
				Singleton<KillStreakManager>.instance.ActivateBonus(this, playerOld);
			}
			else
			{
				PlayerController playerOld2 = PlayerController.GetPlayerOld(owner.fraction);
				Singleton<KillStreakManager>.instance.ActivateBonus(this, playerOld2);
			}
		}
		isAlive = false;
		if (this.Killed != null)
		{
			this.Killed(this, damageInfo);
		}
		Singleton<HitParticleSystem>.instance.PlayParticle(base.transform.position, Vector3.up, "groundBoxHit");
		DestroyPooled(0.1f);
	}

	public void ActivateBonus(PlayerController player, bool res)
	{
		if (!res)
		{
			return;
		}
		if (owner.fraction != player.fraction && Singleton<KillStreakManager>.instance.CanBoobyTrap(owner.fraction))
		{
			bonusToActivate = Singleton<KillStreakManager>.instance.boobyTrapBonus;
			Singleton<KillStreakManager>.instance.BoobyTrapSet(allowed: false, owner.fraction);
		}
		if (owner.fraction != player.fraction)
		{
			mSkillShotController.Play(player.fraction);
		}
		bonusToActivate.ActivateBonus(base.gameObject, player);
		if (player.isCurrentPlayer)
		{
			Vector3 vector = HealthBarManager.instance.guiCamera.transform.position + new Vector3(0f, 0f, HealthBarManager.instance.guiCamera.nearClipPlane + 3f);
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(base.transform.position);
			point = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point);
			point.z = vector.z;
			BonusTakeDisplayer bonusTakeDisplayer = Singleton<SkillShotManager>.instance.objectPool.Instantiate(Singleton<KillStreakManager>.instance.bonusTakeDisplayerPrefab, point + Vector3.up * 10f, Quaternion.identity) as BonusTakeDisplayer;
			if (bonusTakeDisplayer != null)
			{
				bonusTakeDisplayer.Play(bonusToActivate);
			}
			if (player.isCurrentPlayer)
			{
				Singleton<KillStreakManager>.instance.numberOfDestroyedBoxesInLastGame++;
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!onGround && TagsAndLayers.IsDestroyableObject(collision.collider.gameObject))
		{
			DestroyableObject component = collision.collider.gameObject.GetComponent<DestroyableObject>();
			if (component != null && component.destroyableByBonusBox)
			{
				component.DoDamage(new DestroyableObject.DamageInfo
				{
					damageAmount = float.MaxValue,
					force = Vector3.zero,
					isNetwork = false,
					owner = null,
					type = DestroyableObject.DamageType.Basic,
					ignoreImmortality = true
				});
			}
		}
		if (TagsAndLayers.IsStatic(collision.collider.gameObject))
		{
			isAlive = true;
			ContactPoint contactPoint = collision.contacts[0];
			Singleton<HitParticleSystem>.instance.PlayParticle(contactPoint.point, contactPoint.normal, "groundBoxHit");
			onGround = true;
			Singleton<SoundsManager3D>.instance.Play(mTransform.position, crateFallSound);
		}
	}
}
