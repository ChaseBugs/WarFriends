using System.Collections;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerBot : Core_BaseScript
{
	private class OpponentState
	{
		public PlayerController.PlayerStatex mOpponentState;

		public float aimingAtMeForTime;

		public float aimingTime;

		public bool willAttack;

		public bool willHide;

		public float doOpponentActionAfter;
	}

	private readonly List<DestroyableObject> destroyableObjects = new List<DestroyableObject>(5);

	public PlayerBotDiffcultiesRow botConfig;

	public int maxUnits;

	public bool canUseCards;

	private bool mCanSpawn = true;

	private EnemyController mDangerEnemy;

	private float mDestroyedShieldTime;

	private bool mExplosiveTimingSecondShot;

	private bool mInDanger;

	private bool mIsShooting;

	private bool mIsUnder;

	private float mLastChangePosTime;

	private float mLastGeneratedTime;

	private float mSendNextUnitAfter;

	private float mLastShotTime;

	private float mNoViableCardCooldown;

	private List<PlayerController> mOpponents;

	private List<OpponentState> mOpponentStates;

	private int mOpponentPowerOnField;

	private PlayerController mPlayerController;

	private float mShootingLength = 1f;

	private GameShootableEntity.ShotTarget mShotTarget;

	private float mShotTime;

	private float mTimeUnder;

	private float mUnderPressureCoeficient;

	private float mWeaponChangeTime;

	private GameShootableEntity mBonusBox;

	private float mNewChangeIntervalOvertime;

	private bool mHasBonusBox;

	private float mBonusShotTime;

	private List<SpawningManagerDeathMatch.ArmyUnitDefinition> mEnemies;

	public PlayerController playerController => mPlayerController;

	public bool canSpawn
	{
		get
		{
			return mCanSpawn;
		}
		set
		{
			if (value && !mCanSpawn)
			{
				mLastGeneratedTime = Time.time - 4f;
			}
			mCanSpawn = value;
		}
	}

	public bool explosivePistol { get; set; }

	public bool explosiveTiming => playerController.weaponInventory.usedWeapons.Count > 2 && playerController.weaponInventory.usedWeapons[2].haveNextNoReload;

	private bool hasExplosive => playerController.weaponInventory.currentWeapon.weapon.weaponType == Weapon.WeaponType.Bazooka || playerController.weaponInventory.currentWeapon.weapon.weaponType == Weapon.WeaponType.Grenade || playerController.weaponInventory.currentWeapon.weapon.weaponType == Weapon.WeaponType.GrenadeLauncher;

	private float leaveShieldProb
	{
		get
		{
			if (playerController.currentPlayerPoint == null)
			{
				return 0f;
			}
			if (Singleton<GameController>.instance.isTutorialStage3 || Singleton<GameController>.instance.isTutorialStage2)
			{
				if (Singleton<MatchManager>.instance.isOverTime)
				{
					return 0.06f;
				}
				if (playerController.currentPlayerPoint.point.shield.healthRatio < 0.01f)
				{
					if (mDestroyedShieldTime > 0f)
					{
						float num = TimeManager.realTimeWithoutPauses - mDestroyedShieldTime;
						return (num - 0.8f) * 0.5f;
					}
					mDestroyedShieldTime = TimeManager.realTimeWithoutPauses;
				}
				else
				{
					mDestroyedShieldTime = 0f;
				}
				float num2 = TimeManager.realTimeWithoutPauses - mLastChangePosTime;
				if (num2 < 8f)
				{
					return 0.1f;
				}
				return (num2 - 8f) * 0.2f;
			}
			if (Singleton<MatchManager>.instance.isOverTime)
			{
				float num3 = TimeManager.realTimeWithoutPauses - mLastChangePosTime;
				if (num3 < mNewChangeIntervalOvertime)
				{
					return 0.06f;
				}
				return (num3 - mNewChangeIntervalOvertime) * 0.2f;
			}
			if (playerController.currentPlayerPoint.point.shield.healthRatio < 0.15f)
			{
				return 1f;
			}
			float num4 = 0.85f - playerController.currentPlayerPoint.point.shield.healthRatio;
			return num4 * 0.1f;
		}
	}

	private int mBotPowerOnField
	{
		get
		{
			int num = (int)(2f * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE);
			return num - (int)Singleton<SpawningManagerDeathMatch>.instance.powerLeftEnemy - (int)Singleton<SpawningManagerDeathMatch>.instance.powerLeft - mOpponentPowerOnField;
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

	protected override void Awake()
	{
		base.Awake();
		mPlayerController = GetComponent<PlayerController>();
		Singleton<GameController>.instance.AfterGameStarted += OnAfterGameStarted;
	}

	protected override void Start()
	{
		base.Start();
	}

	private Vector3 GetShotPosition()
	{
		Vector3 vector = Singleton<AimingHelper>.instance.PredictPosition(playerController.weaponInventory.currentWeapon.weapon, mShotTarget.transform.position, mShotTarget.shootableEntity.velocity, 0f);
		if (playerController.weaponInventory.currentWeapon.weapon.weaponType == Weapon.WeaponType.Grenade && vector.y - base.transform.position.y > 1.5f)
		{
			Vector3 vector2 = (vector - base.transform.position).normalized.ReplaceY(0f);
			return base.transform.position + vector2 * 30f;
		}
		return vector;
	}

	protected void Update()
	{
		if (!playerController.mPhotonView.isMine || !Singleton<GameController>.instance.gameIsRunning)
		{
			return;
		}
		if (TimeManager.realTimeWithoutPauses > mShotTime && !mIsShooting && canShoot)
		{
			StartShooting(null);
		}
		if (TimeManager.realTimeWithoutPauses > mShotTime + mShootingLength)
		{
			StopShooting(0f);
		}
		if (mIsShooting && mShotTarget != null && playerController.weaponInventory.currentWeapon.weapon.willShoot)
		{
			MainGameEntity mainGameEntity = mShotTarget.shootableEntity.mainGameEntity;
			if (mainGameEntity != null && !mainGameEntity.isAlive)
			{
				StopShooting(0f);
			}
			else if (playerController.playerState != PlayerController.PlayerStatex.Walking || !hasExplosive)
			{
				Vector3 shotPosition = GetShotPosition();
				playerController.weaponInventory.currentWeapon.ShootForBot(shotPosition + GetShootRandomOffset(shotPosition, mShotTarget));
				mLastShotTime = TimeManager.realTimeWithoutPauses;
			}
		}
		if (mIsShooting && playerController.weaponInventory.currentWeapon.weapon.isReloading)
		{
			StopShooting(0f);
		}
		OffenseDefenseBehaviour();
	}

	private void OffenseDefenseBehaviour()
	{
		for (int i = 0; i < mOpponents.Count; i++)
		{
			PlayerController playerController = mOpponents[i];
			OpponentState opponentState = mOpponentStates[i];
			if (opponentState.mOpponentState != playerController.playerState)
			{
				opponentState.mOpponentState = playerController.playerState;
				if (playerController.playerState == PlayerController.PlayerStatex.Walking && !mInDanger)
				{
					TryShootNow();
				}
			}
			Vector3 aimingDir = playerController.soldierAnimator.aimingDir;
			Vector3 to = base.transform.position - playerController.transform.position;
			float num = Vector3.Angle(aimingDir, to);
			if (aimingDir != Vector3.zero)
			{
				if (opponentState.aimingTime == 0f)
				{
					opponentState.willAttack = Random.value < botConfig.OPPONENTOFFENSE;
					if (opponentState.willAttack)
					{
						opponentState.doOpponentActionAfter = botConfig.OPPONENTOFFENCEREACTIONTIME;
						Debug.Log("opponentState.willAttack = true");
					}
				}
				opponentState.aimingTime += Time.deltaTime;
				if (num < 15f && playerController.weaponInventory.currentWeapon.weapon.weaponType == Weapon.WeaponType.SniperRiffle)
				{
					if (opponentState.aimingAtMeForTime == 0f && !opponentState.willAttack)
					{
						opponentState.willHide = Random.value < botConfig.OPPONENTSNIPERDEFFENSE;
						opponentState.doOpponentActionAfter = botConfig.OPPONENTSNIPERDEFENSEREACTIONTIME;
						Debug.Log("opponentState.willHide = true");
					}
					opponentState.aimingAtMeForTime += Time.deltaTime;
				}
				else
				{
					opponentState.aimingAtMeForTime = 0f;
				}
			}
			else
			{
				opponentState.aimingTime = 0f;
			}
			if (opponentState.aimingTime > opponentState.doOpponentActionAfter && opponentState.willAttack)
			{
				opponentState.aimingTime = 0f;
				opponentState.willAttack = false;
				Debug.Log("opponent attack = true");
				GameShootableEntity component = playerController.GetComponent<GameShootableEntity>();
				StartShooting(component, GameShootableEntity.ShotTargetType.Head);
			}
			if (opponentState.aimingAtMeForTime > opponentState.doOpponentActionAfter && opponentState.willHide)
			{
				opponentState.aimingAtMeForTime = 0f;
				opponentState.willHide = false;
				Shield shield = this.playerController.currentPlayerPoint.point.shield;
				if (shield.healthRatio <= 0f)
				{
					ChangePosition();
				}
				if (mIsShooting)
				{
					Debug.Log("opponent defense stop shooting");
					StopShooting(0.1f);
				}
				else
				{
					Debug.Log("opponent defense shooting delayed");
					mShotTime += 1f;
				}
			}
		}
	}

	private void OnEnable()
	{
		StopAllCoroutines();
		StartCoroutine(UpdateBot());
		StartCoroutine(CheckForDestroyableObjects());
		StartCoroutine(CheckForBonussBoxes());
		Weapon.OnShotFired += WeaponOnOnShotFired;
		playerController.destroyableParts.OnDamage += DestroyablePartsOnOnDamage;
	}

	private IEnumerator CheckForBonussBoxes()
	{
		while (true)
		{
			List<GameShootableEntity> targetsBoxes = GameShootableEntity.GetAll<KillStreakBonusBox>();
			List<GameShootableEntity> res = new List<GameShootableEntity>();
			bool hasMine = false;
			foreach (GameShootableEntity gameShootableEntity in targetsBoxes)
			{
				KillStreakBonusBox box = (KillStreakBonusBox)gameShootableEntity.owner;
				if (box.onGround)
				{
					res.Add(gameShootableEntity);
					if (box.owner.fraction == playerController.fraction)
					{
						hasMine = true;
					}
				}
			}
			if (res.Count > 0)
			{
				if (!mHasBonusBox)
				{
					mHasBonusBox = true;
					float time = Random.Range(botConfig.PICKBONUSPROBABILITYMINTIME, botConfig.PICKBONUSPROBABILITYMAXTIME);
					time = ((!hasMine) ? time : (time * botConfig.PICKMYBONUSCOEF));
					mBonusShotTime = Time.realtimeSinceStartup + time;
				}
				else if (Time.realtimeSinceStartup > mBonusShotTime)
				{
					mBonusShotTime = Time.realtimeSinceStartup + Random.Range(botConfig.PICKBONUSPROBABILITYMINTIME, botConfig.PICKBONUSPROBABILITYMAXTIME) * 0.5f;
					mBonusBox = res[Random.Range(0, res.Count)];
					TryShootNow();
				}
			}
			else
			{
				mBonusBox = null;
				mHasBonusBox = false;
			}
			yield return new WaitForSeconds(0.1f);
		}
	}

	private void OnDisable()
	{
		Weapon.OnShotFired -= WeaponOnOnShotFired;
		playerController.destroyableParts.OnDamage -= DestroyablePartsOnOnDamage;
		StopAllCoroutines();
	}

	private void OnAfterGameStarted()
	{
		if (!base.enabled)
		{
			return;
		}
		if (base.gameObject.activeInHierarchy && playerController.mPhotonView.isMine)
		{
			playerController.weaponInventory.currentWeapon = playerController.weaponInventory.usedWeapons[0];
		}
		mLastChangePosTime = TimeManager.realTimeWithoutPauses + 2f;
		explosivePistol = false;
		mShotTarget = null;
		mCanSpawn = true;
		mLastGeneratedTime = Time.time;
		mShotTime = TimeManager.realTimeWithoutPauses + 2f;
		mSendNextUnitAfter = 3f;
		mExplosiveTimingSecondShot = false;
		mHasBonusBox = false;
		mBonusShotTime = 0f;
		mOpponents = PlayerController.GetEnemiesOf(playerController.fraction);
		mOpponentStates = new List<OpponentState>();
		mEnemies = null;
		foreach (PlayerController mOpponent in mOpponents)
		{
			mOpponentStates.Add(new OpponentState());
		}
	}

	private void WeaponOnOnShotFired(Weapon weapon, Vector3 position)
	{
		if (weapon.owner.fraction != playerController.fraction)
		{
			List<GameShootableEntity.ShotTarget> shotTargets = playerController.gameShootableEntity.GetShotTargets(GameShootableEntity.ShotTargetType.Body);
			foreach (GameShootableEntity.ShotTarget item in shotTargets)
			{
				if (!((item.transform.position - position).sqrMagnitude < 0.05f) || mInDanger)
				{
					continue;
				}
				if (!(weapon is AutomaticRifle))
				{
					break;
				}
				float num = weapon.ComputeFlyTimeToTarget(position);
				if (Random.value > botConfig.IGNORESHOTPROBABILITY)
				{
					if (mIsShooting)
					{
						StopShooting(num);
					}
					else if (mShotTime < TimeManager.realTimeWithoutPauses + num)
					{
						mShotTime = TimeManager.realTimeWithoutPauses + num + 0.1f;
					}
				}
				break;
			}
		}
		if (weapon.owner.fraction == playerController.fraction || !(weapon is Bazooka))
		{
			return;
		}
		List<GameShootableEntity.ShotTarget> shotTargets2 = playerController.gameShootableEntity.GetShotTargets(GameShootableEntity.ShotTargetType.Shield);
		foreach (GameShootableEntity.ShotTarget item2 in shotTargets2)
		{
			if (!((item2.transform.position - position).sqrMagnitude < 0.3f) || mInDanger)
			{
				continue;
			}
			if (!(Random.value > botConfig.IGNORESHOTPROBABILITY))
			{
				break;
			}
			float b = weapon.ComputeFlyTimeToTarget(position) - 0.2f;
			float num2 = 0.3f;
			float seconds = Random.Range(num2, Mathf.Max(num2, b));
			InvokeAfterRealTime(delegate
			{
				if (playerController.playerState == PlayerController.PlayerStatex.HidingBehindShield)
				{
					ChangePosition();
				}
			}, seconds);
			break;
		}
	}

	private void DestroyablePartsOnOnDamage(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		if (damageInfo.owner != null)
		{
			EnemyController enemyController = damageInfo.owner as EnemyController;
			if (enemyController != null)
			{
				GameShootableEntity component = enemyController.GetComponent<GameShootableEntity>();
				StartShooting(component);
			}
		}
	}

	private void StopShooting(float minTime = 0f)
	{
		float num = Random.Range(botConfig.SHOOTFREQUENCYMIN, botConfig.SHOOTFREQUENCYMAX) / ((!mInDanger) ? 1f : botConfig.INDANGERCOEFICIENT);
		num -= mUnderPressureCoeficient * num * 0.6f;
		num = Mathf.Clamp(num, 0f, float.MaxValue);
		num = Mathf.Max(minTime, num);
		mShotTime = TimeManager.realTimeWithoutPauses + num;
		mIsShooting = false;
	}

	private Vector3 GetShootRandomOffset(Vector3 pos, GameShootableEntity.ShotTarget shotTarget)
	{
		if (shotTarget.shootableEntity.owner is KillStreakBonusBox)
		{
			return Vector3.zero;
		}
		bool flag = GeometryTools.AngleSigned(playerController.transform.forward, pos - playerController.transform.position, Vector3.up) > 0f;
		if (Random.value > botConfig.SHOOTACCURACY && !mInDanger)
		{
			Weapon.WeaponType weaponType = playerController.weaponInventory.currentWeapon.weapon.weaponType;
			if (weaponType == Weapon.WeaponType.Grenade)
			{
				return new Vector3(Random.Range(0.5f, 1f), Random.value * 0.2f, Random.Range(0.5f, 1f)) * 1.5f * (1f - mUnderPressureCoeficient);
			}
			Vector3 lhs = base.transform.position - mShotTarget.transform.position;
			Vector3 normalized = Vector3.Cross(lhs, Vector3.up).normalized;
			return (normalized * Random.Range(0.5f, 1f) * ((!flag) ? 1 : (-1)) + new Vector3(0f, Random.Range(-0.3f, 0.3f), 0f)) * (1f - mUnderPressureCoeficient);
		}
		return Vector3.zero;
	}

	private bool WillShoot(PlayerWeapon w)
	{
		return !w.weapon.outOfAmmo && !w.weapon.isReloading;
	}

	private PlayerWeapon GetRiffle(bool preferPrimary = false)
	{
		List<PlayerWeapon> list = new List<PlayerWeapon>();
		PlayerWeapon primary = GetPrimary();
		PlayerWeapon secondary = GetSecondary();
		PlayerWeapon pistol = GetPistol();
		bool flag = WillShoot(primary);
		if (flag)
		{
			list.Add(primary);
		}
		bool flag2 = WillShoot(secondary);
		if (flag2)
		{
			list.Add(secondary);
		}
		bool flag3 = WillShoot(pistol);
		if (!flag && !flag2 && !flag3)
		{
			Debug.LogWarning("Bot cant choose proper rifle, either out of ammo or reloading");
		}
		if (list.Count > 0)
		{
			return list[(!preferPrimary) ? Random.Range(0, list.Count) : 0];
		}
		return GetPistol();
	}

	private PlayerWeapon GetSecondary()
	{
		PlayerWeapon playerWeapon = playerController.weaponInventory.usedWeapons[1];
		PlayerZoomOnTouchWeapon playerZoomOnTouchWeapon = playerWeapon as PlayerZoomOnTouchWeapon;
		if ((bool)playerZoomOnTouchWeapon)
		{
			playerZoomOnTouchWeapon.SetWaitTime((!mInDanger && !(mBonusBox != null)) ? botConfig.SNIPERLOOKTIME : (botConfig.SNIPERLOOKTIME * 0.5f));
		}
		return playerWeapon;
	}

	private PlayerWeapon GetPrimary()
	{
		return playerController.weaponInventory.usedWeapons[0];
	}

	private PlayerWeapon GetPistol()
	{
		return playerController.weaponInventory.usedWeapons[3];
	}

	private PlayerWeapon GetExplosive()
	{
		return playerController.weaponInventory.usedWeapons[2];
	}

	private int GetUnitsCount()
	{
		List<GameShootableEntity> entities = GameShootableEntity.GetEntities(playerController.fraction);
		int num = 0;
		foreach (GameShootableEntity item in entities)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null && aIObject.power > 0)
			{
				num++;
			}
		}
		return num;
	}

	private IEnumerator UpdateBot()
	{
		yield return new WaitForSeconds(0.3f);
		while (true)
		{
			if (Singleton<GameController>.instance.gameIsRunning && base.enabled && playerController.mPhotonView.isMine)
			{
				if (playerController.currentPlayerPoint != null && Random.value < leaveShieldProb)
				{
					ChangePosition();
				}
				if (DebugSettings.botSpawns)
				{
					if (playerController.isCurrentPlayer)
					{
						if (Singleton<GameController>.instance.mainController.canDeployUnits)
						{
							if (Singleton<SpawningManagerDeathMatch>.instance.progress <= 0f)
							{
								if (!mIsUnder)
								{
									mTimeUnder = TimeManager.realTimeWithoutPauses;
									mIsUnder = true;
								}
								else if (TimeManager.realTimeWithoutPauses > mTimeUnder + 2f && (int)Singleton<SpawningManagerDeathMatch>.instance.powerLeft > 0)
								{
									Singleton<SpawningManagerDeathMatch>.instance.SendRandomUnit();
									mTimeUnder = TimeManager.realTimeWithoutPauses;
								}
							}
							else
							{
								mIsUnder = false;
							}
						}
					}
					else
					{
						int unitsCount = int.MinValue;
						if (maxUnits > 0)
						{
							unitsCount = GetUnitsCount();
						}
						if (Time.time > mLastGeneratedTime + mSendNextUnitAfter && mCanSpawn)
						{
							mEnemies = mEnemies ?? Singleton<SpawningManagerDeathMatch>.instance.GetThreeRandomUnits(playerController.fraction);
							List<SpawningManagerDeathMatch.ArmyUnitDefinition> possible = new List<SpawningManagerDeathMatch.ArmyUnitDefinition>();
							foreach (SpawningManagerDeathMatch.ArmyUnitDefinition currentArmyUnitDefinition in mEnemies)
							{
								if (currentArmyUnitDefinition.power <= (int)Singleton<SpawningManagerDeathMatch>.instance.powerLeftEnemy && unitsCount + currentArmyUnitDefinition.numberOfEnemies <= maxUnits)
								{
									possible.Add(currentArmyUnitDefinition);
								}
							}
							if (possible.Count > 0)
							{
								int r = Random.Range(0, possible.Count);
								Singleton<SpawningManagerDeathMatch>.instance.SendBotUnit(possible[r], playerController.fraction);
								float coolDown = (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SendUnitsCoolDown).FLOATVALUE + possible[r].coolDown;
								mLastGeneratedTime = Time.time;
								mSendNextUnitAfter = coolDown + Random.Range(botConfig.SENDUNITMINTIME, botConfig.SENDUNITMAXTIME);
								mEnemies = null;
							}
							else
							{
								mLastGeneratedTime += 1f;
							}
						}
					}
				}
				if (canUseCards)
				{
					if (!playerController.isCurrentPlayer)
					{
						Singleton<CardManagerDeathmatchOffline>.instance.UseCard();
					}
					if (playerController.isCurrentPlayer && CardManager.instance.Progress <= 0f && Random.value < 0.1f)
					{
						CardManager.instance.UseCard(CardManager.instance.CurrentCard);
					}
				}
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

	private MapDefinition.DefendPosition GetMostLeftDefendPoint()
	{
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		int num = 0;
		for (num = 0; num < availablePoints.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = availablePoints[num];
			if (defendPosition.fraction == playerController.fraction)
			{
				break;
			}
		}
		return availablePoints[num];
	}

	private MapDefinition.DefendPosition GetMostRightDefendPoint()
	{
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		int index = 0;
		for (int i = 0; i < availablePoints.Count; i++)
		{
			MapDefinition.DefendPosition defendPosition = availablePoints[i];
			if (defendPosition.fraction == playerController.fraction)
			{
				index = i;
			}
		}
		return availablePoints[index];
	}

	private MapDefinition.DefendPosition Compare(MapDefinition.DefendPosition a, MapDefinition.DefendPosition b)
	{
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
		mLastChangePosTime = TimeManager.realTimeWithoutPauses;
		mNewChangeIntervalOvertime = Random.Range(botConfig.OVERTIMESHIELDMINTIME, botConfig.OVERTIMESHIELDMAXTIME);
		MapDefinition.DefendPosition nearDefendPoint = GetNearDefendPoint(playerController.currentPlayerPoint, leftRight: true);
		MapDefinition.DefendPosition nearDefendPoint2 = GetNearDefendPoint(playerController.currentPlayerPoint, leftRight: false);
		MapDefinition.DefendPosition defendPosition = Compare(nearDefendPoint, nearDefendPoint2);
		int num = 0;
		int index = playerController.currentPlayerPoint.index;
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
		if (defendPosition.point.shield.healthRatio > 0f)
		{
			int index2 = defendPosition.index;
			num = index - index2;
		}
		else
		{
			MapDefinition.DefendPosition mostLeftDefendPoint = GetMostLeftDefendPoint();
			MapDefinition.DefendPosition mostRightDefendPoint = GetMostRightDefendPoint();
			int num2 = Random.Range(mostLeftDefendPoint.index, mostRightDefendPoint.index);
			num = index - num2;
		}
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
						TryShootNow();
					}
				}
			}
			yield return new WaitForSeconds(0.3f);
		}
	}

	private void TryShootNow()
	{
		mShotTime = TimeManager.realTimeWithoutPauses;
	}

	private void StartShooting(GameShootableEntity shotTarget, GameShootableEntity.ShotTargetType? shotTargetType = null)
	{
		PickTarget(shotTarget, shotTargetType);
		if (explosiveTiming && playerController.weaponInventory.currentWeapon.haveNextNoReload)
		{
			mExplosiveTimingSecondShot = true;
		}
		else if (mExplosiveTimingSecondShot && playerController.weaponInventory.currentWeapon == GetExplosive())
		{
			mExplosiveTimingSecondShot = false;
		}
		mIsShooting = true;
		mShotTime = TimeManager.realTimeWithoutPauses;
		mShootingLength = Random.Range(botConfig.SHOOTINGLENGTHMIN, botConfig.SHOOTINGLENGTHMAX) * ((!mInDanger) ? 1f : botConfig.INDANGERCOEFICIENT);
		mShootingLength += mShootingLength * mUnderPressureCoeficient;
	}

	private bool CanSeeTarget(GameShootableEntity target)
	{
		Vector3 position = target.GetShotTargets(GameShootableEntity.ShotTargetType.AllIn)[0].transform.position;
		Vector3 vector = base.transform.position + Vector3.up * 0.5f;
		Vector3 normalized = (position - vector).normalized;
		vector += 0.5f * normalized;
		Ray ray = new Ray(vector, normalized);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, Mathf.Clamp(Vector3.Distance(vector, position) - 0.5f, 0.1f, float.MaxValue), (1 << TagsAndLayers.staticlayerNum) | TagsAndLayers.destroyableObjectsMask | TagsAndLayers.t4mObj);
		if (flag)
		{
			flag = !hitInfo.collider.gameObject.IsChildOf(target.gameObject);
		}
		return !flag;
	}

	private PlayerWeapon PickProperWeapon(GameShootableEntity e)
	{
		if (playerController.weaponInventory.usedWeapons.Count != 4)
		{
			Debug.LogError("bad number of weapons for bot: " + playerController.weaponInventory.usedWeapons.Count);
		}
		foreach (PlayerWeapon usedWeapon in playerController.weaponInventory.usedWeapons)
		{
			float reloadProgress = usedWeapon.weapon.reloadProgress;
		}
		bool flag = e.owner is KillStreakBonusBox;
		if (flag)
		{
			return GetRiffle(preferPrimary: true);
		}
		if (explosivePistol)
		{
			return GetPistol();
		}
		if (!flag && (explosiveTiming || mExplosiveTimingSecondShot))
		{
			PlayerWeapon explosive = GetExplosive();
			if (explosive.weapon.ammoLeft >= 2 || mExplosiveTimingSecondShot)
			{
				return explosive;
			}
		}
		AIObject aIObject = e.owner as AIObject;
		DestroyableObject destroyableObject = e.destroyableObject;
		if ((bool)destroyableObject && aIObject != null && aIObject.behaviour.botProperties.useExplosive)
		{
			if (playerController.weaponInventory.usedWeapons.Count == 4)
			{
				PlayerWeapon playerWeapon = playerController.weaponInventory.usedWeapons[2];
				if (playerWeapon.weapon.willShoot && playerWeapon.weapon.ammoLeft > 0)
				{
					return playerWeapon;
				}
			}
			if (Random.value < 0.2f)
			{
				return GetRiffle();
			}
			return null;
		}
		if (Random.value < botConfig.SWITCHGRENADEBAZOOKAPROBABILITY && !mInDanger && playerController.weaponInventory.usedWeapons.Count == 4)
		{
			PlayerWeapon playerWeapon2 = playerController.weaponInventory.usedWeapons[2];
			if (playerWeapon2.weapon.willShoot && playerWeapon2.weapon.ammoLeft > 0)
			{
				return playerWeapon2;
			}
		}
		return GetRiffle();
	}

	private GameShootableEntity PickPriorityTarget()
	{
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(playerController.fraction);
		opponents.Sort(delegate(GameShootableEntity a, GameShootableEntity b)
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
			float num2 = aIObject2.behaviour.botProperties.dangerCoeficient;
			if (aIObject2.destroyableObj != null)
			{
				num2 /= aIObject2.destroyableObj.healthRatio;
			}
			float num3 = aIObject3.behaviour.botProperties.dangerCoeficient;
			if (aIObject3.destroyableObj != null)
			{
				num3 /= aIObject3.destroyableObj.healthRatio;
			}
			return num3.CompareTo(num2);
		});
		mOpponentPowerOnField = 0;
		foreach (GameShootableEntity item in opponents)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null)
			{
				mOpponentPowerOnField += aIObject.power;
			}
		}
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE;
		if (!playerController.isCurrentPlayer && (double)mOpponentPowerOnField > (double)(float)fLOATVALUE * 0.8)
		{
			int num = mBotPowerOnField + (int)Singleton<SpawningManagerDeathMatch>.instance.powerLeftEnemy;
			mUnderPressureCoeficient = Mathf.Clamp01(((float)fLOATVALUE - (float)num) / (float)fLOATVALUE);
		}
		else
		{
			mUnderPressureCoeficient = 0f;
		}
		foreach (GameShootableEntity item2 in opponents)
		{
			PlayerWeapon playerWeapon = PickProperWeapon(item2);
			if (CanSeeTarget(item2) && playerWeapon != null && AnalyzeSpeed(item2))
			{
				playerController.weaponInventory.currentWeapon = playerWeapon;
				return item2;
			}
		}
		return null;
	}

	private bool AnalyzeSpeed(GameShootableEntity e)
	{
		AIObject aIObject = e.owner as AIObject;
		if (aIObject != null && aIObject.behaviour.botProperties.useExplosive)
		{
			return e.velocity.magnitude < 0.3f;
		}
		return true;
	}

	private void PickTarget(GameShootableEntity e, GameShootableEntity.ShotTargetType? targetType = null)
	{
		if (mInDanger)
		{
			List<GameShootableEntity.ShotTarget> shotTargets = mDangerEnemy.GetComponent<GameShootableEntity>().GetShotTargets(GameShootableEntity.ShotTargetType.Head);
			mShotTarget = shotTargets[Random.Range(0, shotTargets.Count)];
			PlayerWeapon playerWeapon = PickProperWeapon(mDangerEnemy.GetComponent<GameShootableEntity>());
			if (playerWeapon != null)
			{
				this.playerController.weaponInventory.currentWeapon = playerWeapon;
			}
			return;
		}
		List<PlayerController> enemiesOf = PlayerController.GetEnemiesOf(this.playerController.fraction);
		float value = Random.value;
		float num = 0f;
		GameShootableEntity gameShootableEntity = null;
		for (int i = 0; i < enemiesOf.Count; i++)
		{
			PlayerController playerController = enemiesOf[i];
			float num2 = Mathf.Clamp01(Mathf.Pow(playerController.destroyableParts.healthRatio, 0.25f) + 0.1f);
			if (playerController.currentPlayerPoint != null && !(playerController.currentPlayerPoint.point == null))
			{
				float num3 = ((playerController.playerState != PlayerController.PlayerStatex.Walking) ? botConfig.PICKOPPONENTSHOTPROBABILITY : botConfig.PICKWALKINGOPPONENTSHOTPROBABILITY);
				num3 *= 1f - mUnderPressureCoeficient;
				num3 /= num2;
				if (playerController.currentPlayerPoint != null && playerController.currentPlayerPoint.point.shield.healthRatio <= 0f)
				{
					num3 = botConfig.PICKOPPONENTSHOTPROBABILITYNOSHIELD * (1f - mUnderPressureCoeficient * 0.2f);
				}
				num3 *= 1f / (float)enemiesOf.Count;
				if (value > num && value < num + num3)
				{
					gameShootableEntity = playerController.gameShootableEntity;
					break;
				}
				num += num3;
			}
		}
		if (gameShootableEntity == null)
		{
			gameShootableEntity = PickPriorityTarget();
		}
		if (mBonusBox != null)
		{
			gameShootableEntity = mBonusBox;
			PlayerWeapon playerWeapon2 = PickProperWeapon(gameShootableEntity);
			if (playerWeapon2 != null)
			{
				this.playerController.weaponInventory.currentWeapon = playerWeapon2;
			}
		}
		if (e != null)
		{
			gameShootableEntity = e;
		}
		if (!(gameShootableEntity != null))
		{
			return;
		}
		GameShootableEntityPlayer gameShootableEntityPlayer = gameShootableEntity as GameShootableEntityPlayer;
		List<GameShootableEntity.ShotTarget> list;
		if (gameShootableEntityPlayer != null)
		{
			PlayerController playerController2 = (PlayerController)gameShootableEntityPlayer.owner;
			bool flag = playerController2.currentPlayerPoint != null && playerController2.currentPlayerPoint.point.shield.healthRatio <= 0.01f && playerController2.playerState == PlayerController.PlayerStatex.HidingBehindShield;
			list = ((!Singleton<MatchManager>.instance.isOverTime && !flag) ? ((this.playerController.weaponInventory.currentWeapon.weapon.weaponType != Weapon.WeaponType.Bazooka) ? gameShootableEntityPlayer.GetShotTargets(GameShootableEntity.ShotTargetType.AllIn) : gameShootableEntityPlayer.GetShotTargets(GameShootableEntity.ShotTargetType.Shield)) : gameShootableEntityPlayer.GetShotTargets(GameShootableEntity.ShotTargetType.Head | GameShootableEntity.ShotTargetType.Moving));
		}
		else
		{
			list = gameShootableEntity.GetShotTargets(GameShootableEntity.ShotTargetType.AllIn);
		}
		if (list.Count <= 0)
		{
			return;
		}
		int index = Random.Range(0, list.Count);
		mShotTarget = list[index];
		if (targetType.HasValue)
		{
			foreach (GameShootableEntity.ShotTarget item in list)
			{
				if (item.type == targetType.GetValueOrDefault() && targetType.HasValue)
				{
					mShotTarget = item;
					break;
				}
			}
			return;
		}
		if (!(Random.value < botConfig.HEADSHOTPROBABILITY))
		{
			return;
		}
		foreach (GameShootableEntity.ShotTarget item2 in list)
		{
			if (item2.type == GameShootableEntity.ShotTargetType.Head)
			{
				mShotTarget = item2;
				break;
			}
		}
	}
}
