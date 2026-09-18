using System;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

public class DestroyableObject : Core_BaseScript, IFraction
{
	public enum DamageType
	{
		Shot,
		Explosion,
		Shiver,
		Basic,
		Poison,
		Flame,
		Heal,
		Immortal,
		Suicide
	}

	public struct DamageInfo
	{
		public DamageType type;

		public float damageAmount;

		public Vector3 force;

		public bool isOneHit;

		public Weapon weapon;

		public IFraction owner;

		public bool isNetwork;

		public byte partIndex;

		public Vector3 hitPosition;

		public bool isCritical;

		public float originalDamage;

		public bool ignoreImmortality;
	}

	[SerializeField]
	private ObscuredFloat mMaxHealth = 1000f;

	private string mHbtext = string.Empty;

	[SerializeField]
	private bool mDestroyableByBonusBox = true;

	protected bool mIsDead;

	public Transform healthBarPosition;

	public bool forceHealthBar;

	public Vector3 offset;

	public bool displayHealthBar;

	public bool playMainHitParticle = true;

	public bool isMetal;

	public float shotCoeficient = 1f;

	public List<string> shotParticleNames;

	protected PhotonView mPhotonView;

	private ObscuredBool mIsImmortal;

	public Healthbar.HealthBarStyle healthBarStyle;

	[SerializeField]
	protected Color mHealthbarColor = Color.green;

	protected Transform mCachedTransform;

	protected Transform mCachedTransformHealthBar;

	public Healthbar healthbar;

	protected Vector3 mLastPosition;

	private Vector3 mDiff;

	private byte mSendDamageIndexInPool;

	private byte mSendDamagePrefabIndex;

	protected Camera mCamera;

	private byte mSendDamagePlayerId = byte.MaxValue;

	private DamageInfo mSendInfo;

	public Sounds3DEnum shotHitSound = Sounds3DEnum.ShieldHit;

	private ObscuredFloat mHealth { get; set; }

	public virtual bool destroyableByBonusBox => mDestroyableByBonusBox;

	public float maxHealth
	{
		get
		{
			return mMaxHealth;
		}
		set
		{
			mMaxHealth = value;
		}
	}

	public virtual DestroyableObject mainDestroyableObject => this;

	public virtual Fractions fraction
	{
		get
		{
			if (owner == null)
			{
				return Fractions.None;
			}
			return owner.fraction;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public virtual IFraction owner { get; set; }

	protected virtual bool playParticles => true;

	public Vector3 velocity => mDiff / Time.deltaTime;

	public virtual float healthRatio
	{
		get
		{
			return Mathf.Clamp01((float)mHealth / maxHealth);
		}
		set
		{
			health = maxHealth * value;
		}
	}

	public virtual float health
	{
		get
		{
			return mHealth;
		}
		set
		{
			mHealth = value;
			mHealth = Mathf.Clamp(mHealth, float.NegativeInfinity, maxHealth);
		}
	}

	public Color healthbarColor
	{
		get
		{
			return mHealthbarColor;
		}
		set
		{
			mHealthbarColor = value;
			if (healthbar != null)
			{
				healthbar.color = mHealthbarColor;
			}
		}
	}

	public bool isDead => mIsDead;

	private bool DebugDamage => DebugSettings.debugEnabled;

	public bool isImmortal
	{
		get
		{
			return mIsImmortal;
		}
		set
		{
			if ((bool)mIsImmortal != value)
			{
				mIsImmortal = value;
				mPhotonView.RPC("SetIsImmortalRPC", PhotonTargets.Others, value);
			}
		}
	}

	public event Action<DestroyableObject, DamageInfo> OnDamage;

	public event Action<DestroyableObject, DamageInfo> OnDeath;

	protected override void Awake()
	{
		base.Awake();
		base.gameObject.layer = TagsAndLayers.destroyableEntitiesLayerNumber;
		mPhotonView = GetComponent<PhotonView>();
		Core_BaseScript[] components = GetComponents<Core_BaseScript>();
		mCachedTransform = base.transform;
		mCamera = Singleton<GameCamera>.instance.camera;
		Core_BaseScript[] array = components;
		foreach (Core_BaseScript core_BaseScript in array)
		{
			if (core_BaseScript is IGameMainEntity && this != core_BaseScript)
			{
				owner = core_BaseScript as IFraction;
				break;
			}
		}
		if (owner != null)
		{
			return;
		}
		Core_BaseScript[] array2 = components;
		foreach (Core_BaseScript core_BaseScript2 in array2)
		{
			if (core_BaseScript2 is IFraction && this != core_BaseScript2)
			{
				owner = core_BaseScript2 as IFraction;
				break;
			}
		}
	}

	protected override void Start()
	{
		base.Start();
		health = maxHealth;
	}

	public void Poison(float damage, Vector3 force, Weapon source, IFraction objectOwner, bool isNetworkCopy)
	{
		if (!isNetworkCopy && !isMetal)
		{
			DoDamage(new DamageInfo
			{
				force = force,
				damageAmount = damage,
				type = DamageType.Poison,
				weapon = source,
				owner = objectOwner
			});
		}
	}

	public void Heal(float healAmount, bool isNetworkCopy)
	{
		if (!isNetworkCopy)
		{
			DoDamage(new DamageInfo
			{
				force = Vector3.zero,
				damageAmount = 0f - healAmount,
				type = DamageType.Basic,
				weapon = null,
				owner = null
			});
		}
	}

	public void HealSoldier(float healAmount, bool isNetworkCopy)
	{
		if (!isNetworkCopy)
		{
			DoDamage(new DamageInfo
			{
				force = Vector3.zero,
				damageAmount = 0f - healAmount,
				type = DamageType.Heal,
				weapon = null,
				owner = null
			});
			if (healthbar != null)
			{
				healthbar.BlinkToWhite();
			}
		}
	}

	public void Shiver(float damage, Vector3 force, Weapon source, IFraction objectOwner, bool isNetworkCopy)
	{
		if (!isNetworkCopy)
		{
			DoDamage(new DamageInfo
			{
				force = force,
				damageAmount = damage,
				type = DamageType.Shiver,
				weapon = source,
				owner = objectOwner
			});
		}
	}

	public void Suicide(float damage, Vector3 force, Weapon source, IFraction objectOwner, bool isNetworkCopy)
	{
		if (!isNetworkCopy)
		{
			DoDamage(new DamageInfo
			{
				force = force,
				damageAmount = damage,
				type = DamageType.Suicide,
				weapon = source,
				owner = objectOwner
			});
		}
	}

	public void Repair(float health, IFraction objectOwner, bool isNetworkCopy)
	{
		if (!isNetworkCopy)
		{
			DoDamage(new DamageInfo
			{
				damageAmount = 0f - health,
				type = DamageType.Shiver,
				weapon = null,
				owner = objectOwner
			});
		}
	}

	public virtual void PlaySound(Sounds3DEnum sound)
	{
		Singleton<SoundsManager3D>.instance.Play(base.gameObject, shotHitSound);
	}

	public virtual void Shoot(float damage, Vector3 hitPos, Vector3 force, Weapon source, IFraction objectOwner, bool isNetworkCopy, bool isCritical)
	{
		if (isNetworkCopy)
		{
			return;
		}
		DoDamage(new DamageInfo
		{
			force = force,
			damageAmount = damage * shotCoeficient,
			type = DamageType.Shot,
			weapon = source,
			owner = objectOwner,
			hitPosition = hitPos,
			isCritical = isCritical
		});
		if (playParticles)
		{
			foreach (string shotParticleName in shotParticleNames)
			{
				Singleton<HitParticleSystem>.instance.PlayParticle(hitPos, force, shotParticleName);
			}
		}
		if (playMainHitParticle)
		{
			Singleton<HitParticleSystem>.instance.PlayParticle(hitPos, force, 2);
		}
		PlaySound(shotHitSound);
	}

	public virtual void Explode(Vector3 force, float damage, Weapon source, IFraction objectOwner, bool isNetworkCopy)
	{
		if (!isNetworkCopy)
		{
			DoDamage(new DamageInfo
			{
				damageAmount = damage,
				force = force,
				type = DamageType.Explosion,
				weapon = source,
				owner = objectOwner
			});
		}
	}

	public virtual void Burn(float damage, Vector3 hitPos, Vector3 force, Weapon source, IFraction objectOwner, bool isNetworkCopy, bool isCritical)
	{
		if (!isNetworkCopy)
		{
			DoDamage(new DamageInfo
			{
				force = force,
				damageAmount = damage * shotCoeficient,
				type = DamageType.Flame,
				weapon = source,
				owner = objectOwner,
				hitPosition = hitPos,
				isCritical = isCritical
			});
		}
	}

	public virtual bool DoDamage(DamageInfo info)
	{
		return DoDamage(info, this);
	}

	public virtual bool DoDamage(DamageInfo info, DestroyableObject obj)
	{
		if (!mIsDead && Singleton<GameController>.instance.gameIsRunning)
		{
			if (info.weapon != null && !info.weapon.friendKill && info.owner.fraction == fraction)
			{
				return false;
			}
			if (info.owner != null && info.owner.fraction == fraction)
			{
				ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FriendDamageCoeficient).FLOATVALUE;
				info.damageAmount *= fLOATVALUE;
			}
			info.originalDamage = info.damageAmount;
			if ((bool)mIsImmortal && !info.ignoreImmortality)
			{
				info.damageAmount = 0f;
				info.type = DamageType.Immortal;
			}
			if ((float)mHealth >= maxHealth && info.damageAmount >= (float)mHealth)
			{
				info.isOneHit = true;
			}
			health -= info.damageAmount;
			float num = health;
			SendDamageEvent(obj, info);
			float num2 = health - num;
			info.damageAmount -= num2;
			if ((float)mHealth <= 0f)
			{
				Death(obj, info);
			}
			SendDamageOverNetwork(info);
			return true;
		}
		return false;
	}

	public virtual void Death(DestroyableObject destroyableObject, DamageInfo info)
	{
		mIsDead = true;
		if (this.OnDeath != null)
		{
			this.OnDeath(destroyableObject, info);
		}
	}

	private void OnEnable()
	{
		if (displayHealthBar)
		{
			healthbar = Singleton<ObjectPoolDatabase>.instance.mainObjectPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.healthbarPrefab) as Healthbar;
			if (healthbar != null)
			{
				healthbar.SetText(mHbtext);
				mCachedTransformHealthBar = healthbar.transform;
				healthbar.InitHealthbar(this, mHealthbarColor);
			}
		}
	}

	private void OnDisable()
	{
		if (displayHealthBar && healthbar != null)
		{
			healthbar.DestroyPooled();
		}
		healthbar = null;
		mHbtext = string.Empty;
	}

	protected void NetworkDamage(DamageInfo info, bool isDead)
	{
		health -= info.damageAmount;
		if (mIsDead)
		{
			return;
		}
		if (info.type == DamageType.Shot)
		{
			if (playParticles)
			{
				foreach (string shotParticleName in shotParticleNames)
				{
					Singleton<HitParticleSystem>.instance.PlayParticle(info.hitPosition, Vector3.up, shotParticleName);
				}
			}
			if (playMainHitParticle)
			{
				Singleton<HitParticleSystem>.instance.PlayParticle(info.hitPosition, Vector3.up, 2);
			}
			PlaySound(shotHitSound);
		}
		if (info.type == DamageType.Heal && healthbar != null)
		{
			healthbar.BlinkToWhite();
		}
		if (health <= 0f)
		{
			Death(this, info);
			if (!isDead)
			{
				Debug.LogError($"NetworkDamage damage Error new HP is {health} and {owner} should NOT be DEAD, damage: {info.damageAmount}, damage owner {info.owner}");
			}
		}
		else if (isDead)
		{
			Death(this, info);
			if (health > 0f)
			{
				Debug.LogError($"NetworkDamage damage Error new HP is {health} and {owner} should BE DEAD, damage: {info.damageAmount}, damage owner {info.owner}");
			}
		}
		SendDamageEvent(this, info);
	}

	protected void SendDamageEvent(DestroyableObject obj, DamageInfo info)
	{
		if (this.OnDamage != null)
		{
			this.OnDamage(obj, info);
		}
	}

	public void RefillOffline()
	{
		health = maxHealth;
		mIsImmortal = false;
		mIsDead = false;
	}

	public void Disable()
	{
		mIsDead = true;
	}

	public virtual void Refill()
	{
		RefillOffline();
		if (!(mPhotonView == null))
		{
			mPhotonView.RPC("RefillRPC", PhotonTargets.Others, health, maxHealth);
		}
	}

	public void RefillTo(float health)
	{
		this.health = health;
		mIsImmortal = false;
		mIsDead = false;
		if (!(mPhotonView == null))
		{
			mPhotonView.RPC("RefillRPC", PhotonTargets.Others, this.health, maxHealth);
		}
	}

	public void RefillTo(float health, float maxHealth)
	{
		this.maxHealth = maxHealth;
		this.health = health;
		mIsImmortal = false;
		mIsDead = false;
		if (!(mPhotonView == null))
		{
			mPhotonView.RPC("RefillRPC", PhotonTargets.Others, this.health, maxHealth);
		}
	}

	[PunRPC]
	protected virtual void RefillRPC(float health, float maxHealth)
	{
		mIsDead = false;
		mIsImmortal = false;
		this.maxHealth = maxHealth;
		this.health = health;
	}

	[PunRPC]
	protected void SetIsImmortalRPC(bool value)
	{
		mIsImmortal = value;
	}

	protected void SendDamageOverNetwork(DamageInfo info)
	{
		mSendInfo = info;
		mSendDamageIndexInPool = 0;
		mSendDamagePrefabIndex = 0;
		mSendDamagePlayerId = byte.MaxValue;
		PlayerController playerController = info.owner as PlayerController;
		if (playerController != null)
		{
			mSendDamagePlayerId = (byte)playerController.playerNetworkId;
		}
		else
		{
			PoolableObject poolableObject = info.owner as PoolableObject;
			if (poolableObject != null && poolableObject.pool != null)
			{
				mSendDamageIndexInPool = (byte)poolableObject.indexInObjectPool;
				mSendDamagePrefabIndex = (byte)poolableObject.pool.prefabToIndexDic[poolableObject.prefab];
			}
		}
		if (mPhotonView == null)
		{
			return;
		}
		if (health > 0f)
		{
			if (mSendInfo.type == DamageType.Shot)
			{
				Vector3 vector = mCachedTransform.InverseTransformPoint(mSendInfo.hitPosition);
				if (mSendDamagePlayerId == byte.MaxValue)
				{
					mPhotonView.RPC("DamageEventShoot", PhotonTargets.Others, info.damageAmount, (byte)mSendInfo.type, mSendDamagePrefabIndex, mSendDamageIndexInPool, mSendInfo.partIndex, vector);
					return;
				}
				mPhotonView.RPC("DamageEventPlayerShoot", PhotonTargets.Others, info.damageAmount, (byte)mSendInfo.type, mSendDamagePlayerId, mSendInfo.partIndex, vector);
				if (DebugDamage)
				{
					Debug.Log($"DamageEventPlayerShoot damage: {info.damageAmount} to {owner} new HP {health}");
				}
			}
			else if (mSendDamagePlayerId == byte.MaxValue)
			{
				mPhotonView.RPC("DamageEvent", PhotonTargets.Others, info.damageAmount, (byte)mSendInfo.type, mSendDamagePrefabIndex, mSendDamageIndexInPool);
			}
			else
			{
				mPhotonView.RPC("DamageEventPlayer", PhotonTargets.Others, info.damageAmount, (byte)mSendInfo.type, mSendDamagePlayerId);
				if (DebugDamage)
				{
					Debug.Log($"DamageEventPlayer damage: {info.damageAmount} to {owner} new HP {health}");
				}
			}
		}
		else if (mSendInfo.type == DamageType.Shot)
		{
			Vector3 vector2 = mCachedTransform.InverseTransformPoint(mSendInfo.hitPosition);
			if (mSendDamagePlayerId == byte.MaxValue)
			{
				mPhotonView.RPC("DeathEventShoot", PhotonTargets.Others, info.damageAmount, (byte)mSendInfo.type, mSendDamagePrefabIndex, mSendDamageIndexInPool, mSendInfo.partIndex, vector2, mSendInfo.force);
				return;
			}
			mPhotonView.RPC("DeathEventPlayerShoot", PhotonTargets.Others, info.damageAmount, (byte)mSendInfo.type, mSendDamagePlayerId, mSendInfo.partIndex, vector2, mSendInfo.force);
			if (DebugDamage)
			{
				Debug.Log($"DeathEventPlayerShoot damage: {info.damageAmount} to {owner} new HP {health}");
			}
		}
		else if (mSendDamagePlayerId == byte.MaxValue)
		{
			mPhotonView.RPC("DeathEvent", PhotonTargets.Others, info.damageAmount, (byte)mSendInfo.type, mSendDamagePrefabIndex, mSendDamageIndexInPool, mSendInfo.force);
		}
		else
		{
			mPhotonView.RPC("DeathEventPlayer", PhotonTargets.Others, info.damageAmount, (byte)mSendInfo.type, mSendDamagePlayerId, mSendInfo.force);
			if (DebugDamage)
			{
				Debug.Log($"DeathEventPlayer damage: {info.damageAmount} to {owner} new HP {health}");
			}
		}
	}

	[PunRPC]
	protected virtual void DamageEvent(float health, byte type, byte prefabIndex, byte indexInPool)
	{
		DamageEvent(health, type, prefabIndex, indexInPool, 0, Vector3.zero, Vector3.zero, dead: false);
	}

	[PunRPC]
	protected virtual void DamageEventShoot(float health, byte type, byte prefabIndex, byte indexInPool, byte partIndex, Vector3 pos)
	{
		DamageEvent(health, type, prefabIndex, indexInPool, partIndex, pos, Vector3.zero, dead: false);
	}

	[PunRPC]
	protected virtual void DeathEvent(float health, byte type, byte prefabIndex, byte indexInPool, Vector3 force)
	{
		DamageEvent(health, type, prefabIndex, indexInPool, 0, Vector3.zero, force, dead: true);
	}

	[PunRPC]
	protected virtual void DeathEventShoot(float health, byte type, byte prefabIndex, byte indexInPool, byte partIndex, Vector3 pos, Vector3 force)
	{
		DamageEvent(health, type, prefabIndex, indexInPool, partIndex, pos, force, dead: true);
	}

	protected void DamageEvent(float damageAmount, byte type, byte prefabIndex, byte indexInPool, byte partIndex, Vector3 pos, Vector3 force, bool dead)
	{
		IFraction fraction = null;
		if (prefabIndex > 0 || indexInPool > 0)
		{
			PoolableObject poolableObject = ObjectPoolDatabase.networkPool.pooledObjects[prefabIndex][indexInPool];
			fraction = poolableObject as IFraction;
		}
		NetworkDamage(new DamageInfo
		{
			damageAmount = damageAmount,
			isNetwork = true,
			type = (DamageType)type,
			owner = fraction,
			partIndex = partIndex,
			hitPosition = mCachedTransform.TransformPoint(pos),
			force = force
		}, dead);
	}

	[PunRPC]
	protected virtual void DamageEventPlayer(float health, byte type, byte playerIndex)
	{
		DamageEventPlayer(health, type, playerIndex, 0, Vector3.zero, Vector3.zero, dead: false);
	}

	[PunRPC]
	protected virtual void DamageEventPlayerShoot(float health, byte type, byte playerIndex, byte partIndex, Vector3 position)
	{
		DamageEventPlayer(health, type, playerIndex, partIndex, position, Vector3.zero, dead: false);
	}

	[PunRPC]
	protected virtual void DeathEventPlayer(float health, byte type, byte playerIndex, Vector3 force)
	{
		DamageEventPlayer(health, type, playerIndex, 0, Vector3.zero, force, dead: true);
	}

	[PunRPC]
	protected virtual void DeathEventPlayerShoot(float health, byte type, byte playerIndex, byte partIndex, Vector3 position, Vector3 force)
	{
		DamageEventPlayer(health, type, playerIndex, partIndex, position, force, dead: true);
	}

	protected virtual void DamageEventPlayer(float damageAmount, byte type, byte playerIndex, byte partIndex, Vector3 position, Vector3 force, bool dead)
	{
		if (!PlayerController.players.ContainsKey(playerIndex))
		{
			Debug.LogError("There is no player with id:" + playerIndex);
		}
		DamageInfo info = new DamageInfo
		{
			damageAmount = damageAmount,
			isNetwork = true,
			type = (DamageType)type,
			owner = PlayerController.players[playerIndex],
			partIndex = partIndex,
			hitPosition = mCachedTransform.TransformPoint(position),
			force = force
		};
		NetworkDamage(info, dead);
		if (DebugDamage)
		{
			Debug.Log($"DamageEventPlayer damage: {info.damageAmount} to {owner} new HP {health}");
		}
	}

	protected virtual void LateUpdate()
	{
		if (displayHealthBar && healthbar != null)
		{
			healthbar.healthRatio = healthRatio;
			Vector3 point = mCamera.WorldToNormalizedViewportPoint(healthBarPosition.position);
			mCachedTransformHealthBar.position = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point);
			float num = Vector3.Distance(healthBarPosition.position, mCamera.transform.position);
			float num2 = Mathf.Clamp(5f / num, 0.75f, 1.2f);
			Vector3 localScale = new Vector3(num2, num2, num2);
			mCachedTransformHealthBar.localScale = localScale;
			mCachedTransformHealthBar.position += offset * num2;
		}
		mDiff = mCachedTransform.position - mLastPosition;
		mLastPosition = mCachedTransform.position;
	}

	public virtual void Sync()
	{
		if (!(mPhotonView == null))
		{
			mPhotonView.RPC("SyncNetwork", PhotonTargets.Others, health, maxHealth, mIsDead);
		}
	}

	[PunRPC]
	protected void SyncNetwork(float health, float maxHealth, bool isDead)
	{
		this.health = health;
		this.maxHealth = maxHealth;
		mIsDead = isDead;
	}

	public virtual void ChangeLayer(Fractions fraction, bool isFlying)
	{
		int fractionBulletLayer = Singleton<TagsAndLayers>.instance.GetFractionBulletLayer(fraction, isFlying);
		base.gameObject.layer = fractionBulletLayer;
	}

	public void SetText(string text)
	{
		mHbtext = text;
		if (healthbar != null)
		{
			healthbar.SetText(mHbtext);
		}
	}

	public void SetBuffs(Perk perk)
	{
		if (healthbar != null)
		{
			healthbar.SetBuffs(perk);
		}
	}
}
