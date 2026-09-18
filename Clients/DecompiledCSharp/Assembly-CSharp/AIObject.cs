using System;
using System.Collections.Generic;
using UnityEngine;

public class AIObject : MainGameEntity, IFraction, IGameMainEntity
{
	public LevelBehaviour preparedBehaviour;

	public LevelBehaviour behaviour;

	public UpgradeSlots.UnitUpgrades unitUpgrades;

	public Perk perk = new Perk();

	public Fractions mFraction = Fractions.Enemies;

	public bool isPrewiev;

	protected int mPower;

	protected bool mSpawnEnabled = true;

	private AimTarget[] mAimTargets;

	public float spawnTime { get; protected set; }

	public bool spawnedByCard { get; private set; }

	public int spawnedCardLevel { get; private set; }

	public string cardId { get; private set; }

	public float cardProgress { get; private set; }

	public bool hasSpecial => unitUpgrades.isSpecial;

	public override int power
	{
		get
		{
			return mPower;
		}
		set
		{
			if (photonView != null && Singleton<PhotonConnectionManager>.instance.isMasterClient)
			{
				mPower = value;
				photonView.RPC("SetPower", PhotonTargets.Others, (byte)value);
			}
		}
	}

	public virtual DestroyableObject destroyableObj => null;

	public override Fractions fraction
	{
		get
		{
			return mFraction;
		}
		set
		{
			if (mFraction != value)
			{
				mFraction = value;
			}
		}
	}

	public override IFraction owner
	{
		get
		{
			return this;
		}
		set
		{
		}
	}

	public static event Action<AIObject, DestroyableObject.DamageInfo> AIObjectKilled;

	public override event Action<IGameMainEntity, DestroyableObject.DamageInfo> Killed;

	public static event Action<AIObject> AfterSpawned;

	protected override void Awake()
	{
		base.Awake();
		mAimTargets = GetComponentsInChildren<AimTarget>();
	}

	protected bool CanSeeTarget(Vector3 targetPosition)
	{
		Vector3 vector = base.transform.position + Vector3.up * 0.5f;
		Vector3 normalized = (targetPosition - vector).normalized;
		vector += 0.5f * normalized;
		Ray ray = new Ray(vector, normalized);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, Mathf.Clamp(Vector3.Distance(vector, targetPosition) - 0.5f, 0.1f, float.MaxValue), (1 << TagsAndLayers.staticlayerNum) | TagsAndLayers.destroyableObjectsMask | TagsAndLayers.t4mObj);
		if (flag)
		{
		}
		return !flag;
	}

	public bool CanSeeTarget(Vector3 start, Vector3 targetPosition)
	{
		Vector3 vector = start;
		Vector3 normalized = (targetPosition - vector).normalized;
		vector += 0.18f * normalized;
		Ray ray = new Ray(vector, normalized);
		float maxDistance = Mathf.Clamp(Vector3.Distance(vector, targetPosition) - 0.5f, 0.1f, float.MaxValue);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, maxDistance, (1 << TagsAndLayers.staticlayerNum) | TagsAndLayers.destroyableObjectsMask | TagsAndLayers.t4mObj);
		if (flag)
		{
		}
		return !flag;
	}

	public static bool CanSeeTargetStatic(Vector3 start, Vector3 targetPosition, float offset = 0.25f)
	{
		Vector3 vector = start;
		Vector3 normalized = (targetPosition - vector).normalized;
		vector += offset * normalized;
		Ray ray = new Ray(vector, normalized);
		float maxDistance = Mathf.Clamp(Vector3.Distance(vector, targetPosition) - 0.5f, 0.1f, float.MaxValue);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, maxDistance, (1 << TagsAndLayers.staticlayerNum) | TagsAndLayers.destroyableObjectsMask | TagsAndLayers.t4mObj);
		if (flag)
		{
		}
		return !flag;
	}

	public virtual void PrepareInstancies()
	{
	}

	public override void SafeStart()
	{
		base.SafeStart();
		if (behaviour != null)
		{
			behaviour.Init(this);
		}
	}

	public virtual void Spawn()
	{
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		if (isPrewiev)
		{
			PickUpgrades();
			return;
		}
		if (behaviour != null)
		{
			behaviour.botProperties.dangerCoeficient = preparedBehaviour.dangerCoef;
		}
		if (photonView != null && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			PickUpgrades();
		}
		if (photonView == null || Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			Spawn();
		}
	}

	public void PickUpgrades()
	{
		unitUpgrades = Singleton<GameController>.instance.mainController.PickUpgradesForUnit(isPrewiev, this);
		if (!isPrewiev)
		{
			SyncUpgrades();
		}
		UpgradesLoaded();
	}

	protected void SyncUpgrades()
	{
		photonView.RPC("SyncUpgradesRPC", PhotonTargets.Others, (byte)fraction, unitUpgrades);
	}

	[PunRPC]
	protected void SyncUpgradesRPC(byte fr, UpgradeSlots.UnitUpgrades upgrades)
	{
		fraction = (Fractions)fr;
		if (!spawnedByCard)
		{
			unitUpgrades = upgrades;
			if (behaviour != null)
			{
				perk = Singleton<GameController>.instance.mainController.CheckForPerks(behaviour, fraction);
				behaviour.upgradeSlots.LoadData(behaviour, unitUpgrades, perk);
			}
		}
		else
		{
			unitUpgrades = upgrades;
			preparedBehaviour.upgradeSlots.LoadDataForCard(behaviour, cardProgress);
			perk = new Perk();
		}
		behaviour.behaviourDefinition.ScaleDamageAndHP(unitUpgrades.scaleDamage, unitUpgrades.scaleHp);
		UpgradesLoaded();
	}

	public virtual void StartEnemyBehaviour()
	{
		AfterSpawn();
		if (photonView != null && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			photonView.RPC("StartEnemyBehaviourNetwork", PhotonTargets.Others, (byte)fraction);
		}
	}

	[PunRPC]
	protected void StartEnemyBehaviourNetwork(byte newFraction)
	{
		fraction = (Fractions)newFraction;
		AfterSpawn();
	}

	protected virtual void AfterSpawn()
	{
		if (AIObject.AfterSpawned != null)
		{
			AIObject.AfterSpawned(this);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		isPrewiev = false;
		spawnedByCard = false;
	}

	[PunRPC]
	protected void SetPower(byte power)
	{
		mPower = power;
	}

	protected virtual void OnKilled(DestroyableObject.DamageInfo arg3)
	{
		if (isAlive)
		{
			if (Killed != null)
			{
				Killed(this, arg3);
			}
			if (AIObject.AIObjectKilled != null)
			{
				AIObject.AIObjectKilled(this, arg3);
			}
			isAlive = false;
		}
	}

	public virtual void UpdatePreview(bool inGame)
	{
		PickUpgrades();
		if (destroyableObj.healthbar != null)
		{
			destroyableObj.healthbar.Disable();
		}
	}

	public void SpawnByCard(float progress, string cardId)
	{
		unitUpgrades = new UpgradeSlots.UnitUpgrades(1f);
		cardProgress = progress;
		this.cardId = cardId;
		spawnedByCard = true;
		photonView.RPC("SpawnByCardRPC", PhotonTargets.Others, progress, cardId);
	}

	[PunRPC]
	protected void SpawnByCardRPC(float progress, string cardId)
	{
		unitUpgrades = new UpgradeSlots.UnitUpgrades(1f);
		cardProgress = progress;
		this.cardId = cardId;
		spawnedByCard = true;
		Debug.Log($"Spawned by card:  progress:{cardProgress}, obj: {base.gameObject.name},uu: {unitUpgrades} ");
	}

	public virtual void UpgradesLoaded()
	{
		spawnTime = Time.realtimeSinceStartup;
		if (destroyableObj != null)
		{
			destroyableObj.forceHealthBar = false;
			destroyableObj.healthbarColor = ((PlayerController.currentPlayer.fraction == fraction) ? Color.green : Color.red);
			if (fraction != Fractions.None)
			{
				if (PlayerController.currentPlayer.fraction != fraction && DebugSettings.instance.data.forceOpponentHB)
				{
					destroyableObj.forceHealthBar = true;
				}
				if (PlayerController.currentPlayer.fraction == fraction && DebugSettings.instance.data.forceMyHB)
				{
					destroyableObj.forceHealthBar = true;
				}
			}
			int actualLevelForIndex = behaviour.upgradeSlots.GetActualLevelForIndex(unitUpgrades.slotUpgradeindex);
			spawnedCardLevel = (int)(cardProgress * (float)LevelManager.instance.maxDisplayLevel);
			string text = ((actualLevelForIndex <= 0 || Singleton<GameController>.instance.isTutorial) ? string.Empty : actualLevelForIndex.ToString());
			if (spawnedByCard)
			{
				text = ((spawnedCardLevel <= 0 || Singleton<GameController>.instance.isTutorial) ? string.Empty : spawnedCardLevel.ToString());
			}
			if (Singleton<GameController>.instance.isWarArena)
			{
				text = string.Empty;
			}
			destroyableObj.SetText(text);
			destroyableObj.SetBuffs(perk);
		}
		AimTarget[] array = mAimTargets;
		foreach (AimTarget aimTarget in array)
		{
			aimTarget.gameObject.SetActive(PlayerController.currentPlayer.fraction != fraction);
		}
		SetupCollisionLayers(fraction);
	}

	public virtual void ReSync()
	{
		if (isAlive && base.isInstantiated)
		{
			photonView.RPC("ReSyncRPC", PhotonTargets.Others, (byte)fraction, base.transform.position, base.transform.rotation, unitUpgrades, spawnedByCard, cardProgress, cardId);
			behaviour.ReSync();
		}
		else
		{
			photonView.RPC("ReSyncDisabledRPC", PhotonTargets.Others);
		}
	}

	[PunRPC]
	public virtual void ReSyncRPC(byte fr, Vector3 positon, Quaternion rotation, UpgradeSlots.UnitUpgrades upgrades, bool spawnedByCard, float progress, string cardId)
	{
		if (!base.isInstantiated || !isAlive)
		{
			if (base.isInstantiated && !isAlive)
			{
				DestroyPooled();
			}
			if (spawnedByCard)
			{
				SpawnByCardRPC(progress, cardId);
			}
			base.pool.ReInstantiate(this, positon, rotation);
			SyncUpgradesRPC(fr, upgrades);
		}
	}

	[PunRPC]
	public virtual void ReSyncDisabledRPC()
	{
		if (base.isInstantiated)
		{
			DestroyPooled();
		}
	}

	public virtual void EnableSpawn()
	{
		mSpawnEnabled = true;
	}

	public virtual void DisableSpawn()
	{
		mSpawnEnabled = false;
	}

	protected virtual void SetupCollisionLayers(Fractions fraction)
	{
		if (destroyableObj != null)
		{
			destroyableObj.ChangeLayer(fraction, isFlying: false);
		}
	}

	public virtual void GetAudioSources(List<AudioSource> list)
	{
	}
}
