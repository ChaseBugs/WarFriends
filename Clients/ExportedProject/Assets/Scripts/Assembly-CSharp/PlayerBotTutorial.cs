using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerBotTutorial : Core_BaseScript
{
	public enum TutorialBotState
	{
		Wait,
		ShootEnemies,
		ShootEnemyPlayer,
		ShootEnemyPlayerAndMoveALot
	}

	private TutorialBotState mBotState;

	private List<DestroyableObject> destroyableObjects = new List<DestroyableObject>(5);

	private EnemyController mDangerEnemy;

	private bool mInDanger;

	private bool mIsShooting;

	private float mLastShotTime;

	private PlayerController mOpponent;

	private PlayerController.PlayerStatex mOpponentState;

	private PlayerController mPlayerController;

	private float mShootingLength = 1f;

	private GameShootableEntity.ShotTarget mShotTarget;

	private float mShotTime;

	private float mNextPosChangeTime;

	private float timeShieldDestroyed = float.MaxValue;

	public PlayerController playerController => mPlayerController;

	private bool hasExplosive => playerController.weaponInventory.currentWeapon.weapon.weaponType == Weapon.WeaponType.Bazooka || playerController.weaponInventory.currentWeapon.weapon.weaponType == Weapon.WeaponType.Grenade;

	private float leaveShieldProb
	{
		get
		{
			if (playerController.currentPlayerPoint == null)
			{
				return 0f;
			}
			if (TimeManager.realTimeWithoutPauses > mNextPosChangeTime)
			{
				return 1f;
			}
			if (playerController.currentPlayerPoint.point.shield.healthRatio < 0.01f)
			{
				if (timeShieldDestroyed > TimeManager.realTimeWithoutPauses)
				{
					timeShieldDestroyed = TimeManager.realTimeWithoutPauses;
					return 0f;
				}
				if (timeShieldDestroyed + 1.5f > TimeManager.realTimeWithoutPauses)
				{
					return 0f;
				}
				if (timeShieldDestroyed + 2.5f > TimeManager.realTimeWithoutPauses)
				{
					return 1f;
				}
			}
			if (mBotState == TutorialBotState.ShootEnemyPlayerAndMoveALot)
			{
				if (mIsShooting)
				{
					return 0f;
				}
				return 0f;
			}
			float num = mNextPosChangeTime - TimeManager.realTimeWithoutPauses;
			return (0.95f - num / 5f) * 0.1f;
		}
	}

	private bool canShoot
	{
		get
		{
			if (hasExplosive)
			{
				return TimeManager.realTimeWithoutPauses > mLastShotTime + 1.2f;
			}
			return true;
		}
	}

	public TutorialBotState botState
	{
		get
		{
			return mBotState;
		}
		set
		{
			mBotState = value;
			SetNextChangePos();
		}
	}

	private void SetNextChangePos()
	{
		if (mBotState == TutorialBotState.ShootEnemyPlayerAndMoveALot)
		{
			mNextPosChangeTime = TimeManager.realTimeWithoutPauses + (float)Random.Range(5, 8);
		}
		else
		{
			mNextPosChangeTime = TimeManager.realTimeWithoutPauses + (float)Random.Range(10, 20);
		}
		timeShieldDestroyed = float.MaxValue;
	}

	protected override void Awake()
	{
		base.Awake();
		mPlayerController = GetComponent<PlayerController>();
	}

	public void Init()
	{
		if (base.enabled)
		{
			if (base.gameObject.activeInHierarchy && playerController.mPhotonView.isMine)
			{
				playerController.weaponInventory.currentWeapon = playerController.weaponInventory.usedWeapons[0];
			}
			mShotTarget = null;
			mOpponent = PlayerController.GetEnemyOf(playerController.fraction);
		}
	}

	private void OnAfterGameStarted()
	{
	}

	protected void Update()
	{
		if (playerController.mPhotonView.isMine && mBotState != TutorialBotState.Wait && Singleton<GameController>.instance.gameIsRunning)
		{
			if (TimeManager.realTimeWithoutPauses > mShotTime && !mIsShooting && canShoot)
			{
				StartShooting();
			}
			if (TimeManager.realTimeWithoutPauses > mShotTime + mShootingLength)
			{
				StopShooting(0f);
			}
			if (mIsShooting && mShotTarget != null && playerController.weaponInventory.currentWeapon.weapon.willShoot && (playerController.playerState != PlayerController.PlayerStatex.Walking || !hasExplosive))
			{
				Vector3 position = Singleton<AimingHelper>.instance.PredictPosition(playerController.weaponInventory.currentWeapon.weapon, mShotTarget.transform.position, mShotTarget.shootableEntity.velocity, 0f) + GetShootRandomOffset();
				playerController.weaponInventory.currentWeapon.ShootForBot(position);
				mLastShotTime = TimeManager.realTimeWithoutPauses;
			}
		}
	}

	private Vector3 GetShootRandomOffset()
	{
		if (playerController.weaponInventory.currentWeapon.weapon.weaponType == Weapon.WeaponType.Bazooka)
		{
			return Vector3.zero;
		}
		Vector3 lhs = base.transform.position - mShotTarget.transform.position;
		Vector3 normalized = Vector3.Cross(lhs, Vector3.up).normalized;
		return normalized * Random.Range(0.1f, 1f) * ((!(Random.value > 0.5f)) ? 1 : (-1)) + new Vector3(0f, Random.Range(-0.3f, 0.3f), 0f);
	}

	private void StopShooting(float minTime = 0f)
	{
		mShotTime = TimeManager.realTimeWithoutPauses + Random.Range(1f, 2f);
		mIsShooting = false;
	}

	private void OnEnable()
	{
		StartCoroutine(UpdateBot());
		StartCoroutine(CheckForDestroyableObjects());
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	protected override void Start()
	{
		base.Start();
	}

	public PlayerWeapon GetRiffle()
	{
		if (mBotState == TutorialBotState.ShootEnemyPlayerAndMoveALot)
		{
			foreach (PlayerWeapon usedWeapon in playerController.weaponInventory.usedWeapons)
			{
				if (usedWeapon is PlayerZoomOnTouchWeapon)
				{
					(usedWeapon as PlayerZoomOnTouchWeapon).SetWaitTime(4.5f);
					if (usedWeapon.weapon.ammoLeft < 5)
					{
						usedWeapon.weapon.ammoLeft = 20;
					}
					return usedWeapon;
				}
			}
		}
		List<PlayerWeapon> list = new List<PlayerWeapon>();
		foreach (PlayerWeapon usedWeapon2 in playerController.weaponInventory.usedWeapons)
		{
			if (usedWeapon2.weapon.weaponType == Weapon.WeaponType.Riffle && usedWeapon2.weapon.ammoLeft > 0 && !(usedWeapon2.weapon is Pistol) && usedWeapon2.weapon.reloadingTimeLeft < 0.5f)
			{
				if (usedWeapon2 is PlayerZoomOnTouchWeapon)
				{
					(usedWeapon2 as PlayerZoomOnTouchWeapon).SetWaitTime(0.8f);
				}
				list.Add(usedWeapon2);
			}
		}
		if (list.Count > 0)
		{
			return list[Random.Range(0, list.Count)];
		}
		return GetPistol();
	}

	private PlayerWeapon GetPistol()
	{
		foreach (PlayerWeapon usedWeapon in playerController.weaponInventory.usedWeapons)
		{
			if (usedWeapon.weapon is Pistol)
			{
				return usedWeapon;
			}
		}
		Debug.LogError("Bot should have pistol equipped");
		return null;
	}

	private IEnumerator UpdateBot()
	{
		yield return new WaitForSeconds(0.3f);
		while (true)
		{
			if (Singleton<GameController>.instance.gameIsRunning && base.enabled && playerController.mPhotonView.isMine && mBotState != TutorialBotState.Wait && playerController.currentPlayerPoint != null && Random.value < leaveShieldProb)
			{
				SetNextChangePos();
				ChangePosition();
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	private MapDefinition.DefendPosition GetNearDefendPoint(MapDefinition.DefendPosition current, bool leftRight)
	{
		if (current == null)
		{
			return null;
		}
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		int num = 0;
		for (num = 0; num < availablePoints.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = availablePoints[num];
			if (defendPosition == current)
			{
				break;
			}
		}
		if (leftRight)
		{
			num--;
			if (num < 0 || availablePoints[num].fraction != playerController.fraction)
			{
				return null;
			}
			return availablePoints[num];
		}
		num++;
		if (num >= availablePoints.Count || availablePoints[num].fraction != playerController.fraction)
		{
			return null;
		}
		return availablePoints[num];
	}

	private MapDefinition.DefendPosition Compare(MapDefinition.DefendPosition a, MapDefinition.DefendPosition b)
	{
		if (a == null && b == null)
		{
			Debug.LogError("Error in bot finding position");
		}
		if (a == null)
		{
			return b;
		}
		if (b == null)
		{
			return a;
		}
		if (a.point.shield.healthRatio > b.point.shield.healthRatio)
		{
			return a;
		}
		return b;
	}

	private void ChangePosition()
	{
		MapDefinition.DefendPosition nearDefendPoint = GetNearDefendPoint(playerController.currentPlayerPoint, leftRight: true);
		MapDefinition.DefendPosition nearDefendPoint2 = GetNearDefendPoint(playerController.currentPlayerPoint, leftRight: false);
		MapDefinition.DefendPosition defendPosition = Compare(nearDefendPoint, nearDefendPoint2);
		if ((double)defendPosition.point.shield.healthRatio < 0.3)
		{
			nearDefendPoint = GetNearDefendPoint(nearDefendPoint, leftRight: true);
			nearDefendPoint2 = GetNearDefendPoint(nearDefendPoint2, leftRight: false);
			MapDefinition.DefendPosition b = Compare(nearDefendPoint, nearDefendPoint2);
			defendPosition = Compare(defendPosition, b);
		}
		if ((double)defendPosition.point.shield.healthRatio < 0.3)
		{
			nearDefendPoint = GetNearDefendPoint(nearDefendPoint, leftRight: true);
			nearDefendPoint2 = GetNearDefendPoint(nearDefendPoint2, leftRight: false);
			MapDefinition.DefendPosition b2 = Compare(nearDefendPoint, nearDefendPoint2);
			defendPosition = Compare(defendPosition, b2);
		}
		defendPosition = Compare(playerController.currentPlayerPoint, defendPosition);
		int index = defendPosition.index;
		int index2 = playerController.currentPlayerPoint.index;
		int num = index2 - index;
		MapDefinition.DefendPosition point = playerController.currentPlayerPoint;
		if (num > 0)
		{
			for (int i = 0; i < Mathf.Abs(num); i++)
			{
				point = playerController.GoLeft(point);
			}
		}
		else
		{
			for (int j = 0; j < Mathf.Abs(num); j++)
			{
				point = playerController.GoRight(point);
			}
		}
	}

	private IEnumerator CheckForDestroyableObjects()
	{
		while (true)
		{
			destroyableObjects.Clear();
			Collider[] overlapingObjects = Physics.OverlapSphere(base.transform.position, 3f, TagsAndLayers.destroyableObjectsMask);
			Collider[] array = overlapingObjects;
			foreach (Collider overlapingObject in array)
			{
				if (!TagsAndLayers.IsDestroyableObject(overlapingObject.gameObject))
				{
					continue;
				}
				DestroyableObject destroyableObject = overlapingObject.gameObject.GetComponent<DestroyableObject>();
				if (destroyableObject == null)
				{
					continue;
				}
				float distance = Vector3.Distance(destroyableObject.transform.position, base.transform.position);
				if (destroyableObject is DestroyableObjectpart)
				{
					DestroyableObjectpart d = destroyableObject as DestroyableObjectpart;
					if (!(d != null) || !(d.ownerDestroyableObject != null) || !destroyableObjects.Contains(d.ownerDestroyableObject))
					{
						destroyableObjects.Add(d.ownerDestroyableObject);
					}
				}
				else
				{
					destroyableObjects.Add(destroyableObject);
				}
			}
			mInDanger = false;
			foreach (DestroyableObject desObj in destroyableObjects)
			{
				if (desObj.owner != null)
				{
					GrenadeAmmoEnemy grenade = desObj.owner as GrenadeAmmoEnemy;
					if (playerController.playerState != PlayerController.PlayerStatex.Walking && grenade != null && Vector3.Distance(desObj.transform.position, base.transform.position) < 2f && Random.value < 0.9f)
					{
						ChangePosition();
					}
					EnemyController enemy = desObj.owner as EnemyController;
					if (enemy != null && enemy.isAlive && enemy.fraction != playerController.fraction)
					{
						mInDanger = true;
						mDangerEnemy = enemy;
						playerController.weaponInventory.currentWeapon = GetRiffle();
						TryShootNow();
					}
				}
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	public void TryShootNow()
	{
		mShotTime = TimeManager.realTimeWithoutPauses;
	}

	private void StartShooting()
	{
		PickTarget();
		mIsShooting = true;
		mShotTime = TimeManager.realTimeWithoutPauses;
		if (mBotState == TutorialBotState.ShootEnemyPlayerAndMoveALot)
		{
			mShootingLength = 5.5f;
		}
		else
		{
			mShootingLength = Random.Range(0.2f, 1.2f);
		}
	}

	private bool CanSeeTarget(Vector3 targetPosition)
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

	private PlayerWeapon PickProperWeapon(GameShootableEntity e)
	{
		DestroyableObject destroyableObject = e.destroyableObject;
		if ((bool)destroyableObject && destroyableObject.shotCoeficient < 0.5f)
		{
			bool flag = false;
			foreach (PlayerWeapon usedWeapon in playerController.weaponInventory.usedWeapons)
			{
				if (usedWeapon.weapon.weaponType == Weapon.WeaponType.Bazooka || usedWeapon.weapon.weaponType == Weapon.WeaponType.Grenade)
				{
					if (usedWeapon.weapon.ammoLeft > 0)
					{
						flag = true;
					}
					if (usedWeapon.weapon.willShoot)
					{
						return usedWeapon;
					}
				}
			}
			if (!flag)
			{
				return GetRiffle();
			}
			return null;
		}
		return GetRiffle();
	}

	private GameShootableEntity PickPriorityTarget()
	{
		List<GameShootableEntity> list = GameShootableEntity.GetOpponents(playerController.fraction);
		list.Sort(delegate(GameShootableEntity a, GameShootableEntity b)
		{
			AIObject aIObject2 = a.owner as AIObject;
			AIObject aIObject3 = b.owner as AIObject;
			if (aIObject3 == null && aIObject2 == null)
			{
				return 0;
			}
			if (aIObject2 == null || aIObject2.behaviour == null)
			{
				return 1;
			}
			if (aIObject3 == null || aIObject3.behaviour == null)
			{
				return -1;
			}
			float num = aIObject2.behaviour.botProperties.dangerCoeficient;
			if (aIObject2.destroyableObj != null)
			{
				num /= aIObject2.destroyableObj.healthRatio;
			}
			float num2 = aIObject3.behaviour.botProperties.dangerCoeficient;
			if (aIObject3.destroyableObj != null)
			{
				num /= aIObject3.destroyableObj.healthRatio;
			}
			return num2.CompareTo(num);
		});
		List<GameShootableEntity> all = GameShootableEntity.GetAll<KillStreakBonusBox>();
		if (all.Count > 0)
		{
			list = all;
		}
		foreach (GameShootableEntity item in list)
		{
			PlayerWeapon playerWeapon = PickProperWeapon(item);
			if (CanSeeTarget(item.GetShotTargets(GameShootableEntity.ShotTargetType.All)[0].transform.position) && playerWeapon != null && AnalyzeSpeed(item))
			{
				AIObject aIObject = item.owner as AIObject;
				playerController.weaponInventory.currentWeapon = playerWeapon;
				return item;
			}
		}
		return null;
	}

	private bool AnalyzeSpeed(GameShootableEntity e)
	{
		if (e.destroyableObject.shotCoeficient < 0.5f)
		{
			return e.velocity.magnitude < 0.3f;
		}
		return true;
	}

	private void PickTarget()
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(playerController.fraction);
		float num = 0.5f;
		GameShootableEntity gameShootableEntity = null;
		gameShootableEntity = ((!(Random.value < num)) ? PickPriorityTarget() : enemyOf.gameShootableEntity);
		if (gameShootableEntity != null)
		{
			GameShootableEntityPlayer gameShootableEntityPlayer = gameShootableEntity as GameShootableEntityPlayer;
			List<GameShootableEntity.ShotTarget> list = ((!(gameShootableEntityPlayer != null)) ? gameShootableEntity.GetShotTargets(GameShootableEntity.ShotTargetType.AllIn) : ((playerController.weaponInventory.currentWeapon.weapon.weaponType != Weapon.WeaponType.Bazooka) ? gameShootableEntityPlayer.GetShotTargets(GameShootableEntity.ShotTargetType.AllIn) : gameShootableEntityPlayer.GetShotTargets(GameShootableEntity.ShotTargetType.Shield)));
			if (list.Count > 0)
			{
				int index = Random.Range(0, list.Count);
				mShotTarget = list[index];
			}
		}
	}
}
