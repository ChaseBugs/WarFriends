using UnityEngine.AI;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class Shield : DestroyableObject
{
	public enum LockResult
	{
		None,
		Success,
		Failure
	}

	private readonly Color32 mChargingColor = new Color32(14, 192, 254, byte.MaxValue);

	public AudioSource audioSource;

	[SerializeField]
	private Material goldMaterial;

	public HudObjectIndicator hudIndicator;

	public LockResult lockResult;

	private bool mAutoRepair = true;

	private bool mCanRegenerate;

	private Collider mCollider;

	private float mDestroyTime;

	private bool mIsDestroyed;

	private int mLastSync;

	private int mModelNumber;

	public List<float> modelsLimits;

	private PlayerController mPlayer;

	private float mRepairTime = 10f;

	private float mWantedHealth;

	[SerializeField]
	private Material normalMaterial;

	public List<GameObject> shiedModels;

	public AudioClip shieldDestroyedSound;

	public Transform shotPosition;

	public bool tryGetLock;

	public CardIconIndicator cardIconIndicator { get; private set; }

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

	public override Fractions fraction { get; set; }

	public float refreshTime
	{
		get
		{
			return mRepairTime;
		}
		set
		{
			mRepairTime = value;
			mPhotonView.RPC("SetShieldRefresTimeRPC", PhotonTargets.Others, refreshTime);
		}
	}

	public PlayerController player
	{
		get
		{
			return mPlayer;
		}
		set
		{
			mPlayer = value;
			if (mPhotonView != null)
			{
				if (value != null)
				{
					mPhotonView.RPC("SetPlayer", PhotonTargets.Others, value.playerNetworkId);
				}
				else
				{
					mPhotonView.RPC("SetPlayer", PhotonTargets.Others, -1);
				}
			}
		}
	}

	public bool autoRepair
	{
		get
		{
			return mAutoRepair && (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RepairShields).FLOATVALUE > 0f;
		}
		set
		{
			mAutoRepair = value;
			mPhotonView.RPC("SetAutoRepairRPC", PhotonTargets.Others, value);
		}
	}

	public bool canRegenerate
	{
		get
		{
			return mCanRegenerate;
		}
		set
		{
			mCanRegenerate = value;
			mPhotonView.RPC("SetCanRegenerateRPC", PhotonTargets.Others, value);
		}
	}

	[PunRPC]
	private void SetCanRegenerateRPC(bool value)
	{
		mCanRegenerate = value;
	}

	[PunRPC]
	private void SetAutoRepairRPC(bool value)
	{
		mAutoRepair = value;
	}

	[PunRPC]
	private void SetPlayer(int playerID)
	{
		if (playerID >= 0 && PlayerController.players.ContainsKey(playerID))
		{
			mPlayer = PlayerController.players[playerID];
			Debug.Log("Rpc: Set player: for " + base.transform.parent.name + ":" + player.name);
		}
		else
		{
			Debug.Log("Rpc: Set player null: for " + base.transform.parent.name);
			mPlayer = null;
		}
	}

	[PunRPC]
	private void SetShieldRefresTimeRPC(float seconds)
	{
		mRepairTime = seconds;
	}

	protected override void Awake()
	{
		base.Awake();
		isMetal = true;
		base.gameObject.layer = TagsAndLayers.destroyableEntitiesShieldLayerNumber;
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		Singleton<GameController>.instance.BeforeGameStarted += OnBeforeGameStarted;
		mRepairTime = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ShieldRepairTime).FLOATVALUE;
		if (NavMesh.SamplePosition(base.transform.position, out var hit, 10f, 1))
		{
			Vector3 position = base.transform.position;
			position.y = hit.position.y;
			base.transform.position = position;
		}
		cardIconIndicator = base.gameObject.AddComponent<CardIconIndicator>();
		cardIconIndicator.hudObjectIndicator = hudIndicator;
		mPhotonView.RebuildCache();
		SwitchModel(0);
		mCollider = GetComponent<Collider>();
	}

	private void OnBeforeGameStarted()
	{
	}

	private void OnGameStarted()
	{
		if (PhotonNetwork.isMasterClient && !mIsDestroyed)
		{
			PlayerController playerController = PlayerController.GetPlayer(fraction);
			if (playerController != null)
			{
				float shieldHP = Singleton<GameController>.instance.mainController.GetShieldHP(playerController);
				base.maxHealth = shieldHP;
				Refill();
			}
		}
		StopAllCoroutines();
		SwitchModel(0);
		healthBarPosition.localPosition = ((fraction != PlayerController.currentPlayer.fraction) ? new Vector3(0.32f, -0.06f, 0.5f) : new Vector3(0.24f, -0.06f, 0.5f));
	}

	private void OnDestroy()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= OnGameStarted;
		}
	}

	private void OnEnable()
	{
		healthbar = Singleton<ObjectPoolDatabase>.instance.mainObjectPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.verticalHealthBar) as Healthbar;
		if (healthbar != null)
		{
			healthbar.destroyableObject = this;
			healthbar.color = mHealthbarColor;
			mCachedTransformHealthBar = healthbar.transform;
			displayHealthBar = true;
		}
	}

	private void OnDisable()
	{
		if (displayHealthBar && healthbar != null)
		{
			healthbar.DestroyPooled();
		}
		healthbar = null;
	}

	protected void Update()
	{
		if (mIsDestroyed)
		{
			health = 0f;
			forceHealthBar = true;
			float num = (TimeManager.realTimeWithoutPauses - mDestroyTime) / mRepairTime;
			if (autoRepair)
			{
				if (num >= 1f && mPhotonView.isMine && Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					Repair();
				}
				if (healthbar != null)
				{
					healthbar.healthRatio = num;
					healthbar.color = Color.white;
				}
			}
			else if (healthbar != null)
			{
				healthbar.healthRatio = -1f;
			}
			if (mCachedTransformHealthBar != null)
			{
				Vector3 point = mCamera.WorldToNormalizedViewportPoint(healthBarPosition.position);
				mCachedTransformHealthBar.position = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point);
				float num2 = Vector3.Distance(healthBarPosition.position, mCamera.transform.position);
				float num3 = Mathf.Clamp(5f / num2, 0.75f, 1.2f);
				Vector3 localScale = new Vector3(num3, num3, num3);
				mCachedTransformHealthBar.localScale = localScale;
			}
		}
		else if (mCachedTransformHealthBar != null && healthbar != null)
		{
			healthbar.color = mChargingColor;
			forceHealthBar = false;
			healthbar.healthRatio = healthRatio;
			Vector3 point2 = mCamera.WorldToNormalizedViewportPoint(healthBarPosition.position);
			mCachedTransformHealthBar.position = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point2);
			float num4 = Vector3.Distance(healthBarPosition.position, mCamera.transform.position);
			float num5 = Mathf.Clamp(5f / num4, 0.75f, 1.2f);
			Vector3 localScale2 = new Vector3(num5, num5, num5);
			mCachedTransformHealthBar.localScale = localScale2;
		}
		float num6 = ((!mIsDestroyed) ? healthRatio : 0f);
		while (num6 > modelsLimits[mModelNumber] && mModelNumber > 0)
		{
			SwitchModel(mModelNumber - 1);
		}
		while (num6 <= modelsLimits[mModelNumber + 1] && mModelNumber < shiedModels.Count - 1)
		{
			SwitchModel(mModelNumber + 1);
		}
		CheckIfShieldIsDestroyed();
		if (!mIsDestroyed && healthRatio < 1f && mPhotonView.isMine)
		{
			if (mCanRegenerate && player != null && mAutoRepair)
			{
				health += Time.deltaTime * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ShieldRespawnRatePerSec).FLOATVALUE * base.maxHealth;
			}
			if (mLastSync != (int)TimeManager.realTimeWithoutPauses)
			{
				mLastSync = (int)TimeManager.realTimeWithoutPauses;
				Sync();
			}
		}
	}

	private void CheckIfShieldIsDestroyed()
	{
		if (!mIsDestroyed)
		{
			if (healthRatio <= 0f)
			{
				mIsDestroyed = true;
				mDestroyTime = TimeManager.realTimeWithoutPauses;
				Singleton<HitParticleSystem>.instance.PlayParticle(base.transform.position + 0.5f * Vector3.up, base.transform.up, "shieldDestroy");
				Singleton<SoundsManager3D>.instance.Play(audioSource, shieldDestroyedSound);
				Vibration.iPhoneVibrate(Vibration.iPhoneVibrateType.VibrateHeavy);
			}
		}
		else if (healthRatio > 0.01f)
		{
			mIsDestroyed = false;
		}
		mCollider.enabled = !mIsDestroyed;
	}

	protected override void LateUpdate()
	{
	}

	private void SwitchModel(int modelNumber)
	{
		mModelNumber = modelNumber;
		MeshFilter component = GetComponent<MeshFilter>();
		MeshFilter component2 = shiedModels[mModelNumber].GetComponent<MeshFilter>();
		component.sharedMesh = component2.sharedMesh;
		GetComponent<Renderer>().enabled = true;
	}

	private void Repair()
	{
		if (autoRepair)
		{
			Refill();
		}
	}

	public override void Refill()
	{
		base.Refill();
		mIsDestroyed = false;
	}

	[PunRPC]
	protected override void RefillRPC(float health, float maxHealth)
	{
		base.RefillRPC(health, maxHealth);
		mIsDestroyed = false;
	}

	public override bool DoDamage(DamageInfo info)
	{
		float num = 1f;
		PlayerController playerController = info.owner as PlayerController;
		if (playerController != null && info.weapon != null && info.weapon.playerWeapon != null)
		{
			num = info.weapon.playerWeapon.weaponLevelSetup.damageToShield;
			if (Singleton<GameController>.instance.isTutorial && info.type == DamageType.Shot)
			{
				num *= 0.5f;
			}
		}
		else if (info.type == DamageType.Shot)
		{
			num = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.UnitToShieldCoef).FLOATVALUE;
		}
		info.damageAmount *= num;
		return base.DoDamage(info);
	}

	public void GetLock()
	{
		if ((Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot) && PhotonNetwork.room.playerCount == 2)
		{
			lockResult = LockResult.None;
			tryGetLock = true;
			mPhotonView.RPC("GetLockRPC", PhotonTargets.Others);
		}
		else
		{
			lockResult = LockResult.Success;
			tryGetLock = false;
		}
	}

	[PunRPC]
	private void GetLockRPC()
	{
		LockResult lockResult = LockResult.Success;
		if (player != null || (tryGetLock && PhotonNetwork.isMasterClient))
		{
			lockResult = LockResult.Failure;
		}
		mPhotonView.RPC("GetLockResultRPC", PhotonTargets.Others, (byte)lockResult);
	}

	[PunRPC]
	private void GetLockResultRPC(byte res)
	{
		lockResult = (LockResult)res;
		tryGetLock = false;
	}

	public void DestroyShield()
	{
		health = -10f;
		CheckIfShieldIsDestroyed();
		Sync();
	}

	public void Resync()
	{
		Sync();
	}

	public override void Sync()
	{
		if (!(mPhotonView == null))
		{
			mPhotonView.RPC("SyncShieldRPC", PhotonTargets.Others, health, base.maxHealth, mIsDead);
		}
	}

	[PunRPC]
	protected void SyncShieldRPC(float health, float maxHealth, bool isDead)
	{
		this.health = health;
		base.maxHealth = maxHealth;
		mIsDead = isDead;
		CheckIfShieldIsDestroyed();
	}

	public void Init()
	{
		PlayerController playerController = PlayerController.GetPlayer(fraction);
		bool flag = playerController != null && playerController.playerProperties.goldShields;
		GetComponent<Renderer>().sharedMaterial = ((!flag) ? normalMaterial : goldMaterial);
	}
}
