using System.Collections;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
public class TutorialManagerBase : InGameSerializedObjectGeneric<TutorialManagerBase.TutorialData>
{
	[Skip]
	public class TutorialData
	{
		public bool started;

		public bool overtimeShowed;

		public int gold;

		public int wb;
	}

	public List<PoolableObject> bulletsPrefabs;

	public GrenadeAmmoBase grenade;

	private bool mHasEnergyForAll;

	private float mNextSpawnTime;

	protected PlayerBotTutorial mPlayerBotTutorial;

	protected bool mSpawn2;

	private bool mSpawnCheck;

	protected bool mWaitForSpawn;

	protected bool mShowDeployHint = true;

	private float m_NextSpawnTimePause;

	public PoolableObject missile;

	private List<PoolableObject> soldiers;

	public virtual bool autoDeployEnabled => false;

	public bool isTutorialRunning { get; protected set; }

	public virtual void FinishTutorial()
	{
		if (!isTutorialRunning)
		{
			Debug.LogError("Trying to finish Tutorial, which is not currently running ");
		}
		isTutorialRunning = false;
		StopAllCoroutines();
		AIObject.AfterSpawned -= AfterSpawned;
	}

	public virtual void StartTutorial(bool isContinue)
	{
		mSpawnCheck = false;
		isTutorialRunning = true;
		AIObject.AfterSpawned += AfterSpawned;
	}

	protected void SetPlayerDefaultWeapons(bool enableRifle = false, bool enableSniper = false, bool enableGrenade = false)
	{
		List<PlayerInventory.EquippedWeapon> list = new List<PlayerInventory.EquippedWeapon>();
		list.Add(Singleton<BotManager>.instance.AddWeapon(WeaponCategory.AssaultRifle.ToString(), 0));
		list.Add(Singleton<BotManager>.instance.AddWeapon(WeaponCategory.SniperRifle.ToString(), 0));
		list.Add(Singleton<BotManager>.instance.AddWeapon(WeaponCategory.Grenade.ToString(), 0));
		list.Add(Singleton<BotManager>.instance.AddWeapon(WeaponCategory.Pistol.ToString(), 0));
		PlayerController.currentPlayer.playerProperties.weapons = list.ToArray();
		PlayerController.currentPlayer.weaponInventory.startGameWithIndex = ((!enableRifle) ? 3 : 0);
		if (!enableRifle)
		{
			PlayerController.currentPlayer.weaponInventory.currentWeapon = PlayerController.currentPlayer.weaponInventory.usedWeapons[3];
		}
		PlayerController.currentPlayer.weaponInventory.cannotChange = true;
		GuiElementSingle<InventoryGuiElement>.instance.WeaponsChanged();
		foreach (PlayerWeapon usedWeapon in PlayerController.currentPlayer.weaponInventory.usedWeapons)
		{
			usedWeapon.weapon.ammoLeftInClip = 0;
			usedWeapon.weapon.ammoLeft = 0;
			usedWeapon.weapon.friendKill = false;
		}
		PlayerController.currentPlayer.weaponInventory.usedWeapons[3].weapon.ammoLeftInClip = 10;
		if (enableRifle)
		{
			PlayerController.currentPlayer.weaponInventory.cannotChange = false;
			PlayerController.currentPlayer.weaponInventory.usedWeapons[0].weapon.clipSize = 20;
			PlayerController.currentPlayer.weaponInventory.usedWeapons[0].weapon.ammoLeft = 100;
			PlayerController.currentPlayer.weaponInventory.usedWeapons[0].weapon.ammoLeftInClip = 20;
			PlayerController.currentPlayer.weaponInventory.usedWeapons[0].weapon.reloadTime = 1f;
			PlayerController.currentPlayer.weaponInventory.currentWeapon = PlayerController.currentPlayer.weaponInventory.usedWeapons[0];
		}
		if (enableSniper)
		{
			PlayerController.currentPlayer.weaponInventory.usedWeapons[1].weapon.clipSize = 10;
			PlayerController.currentPlayer.weaponInventory.usedWeapons[1].weapon.ammoLeft = 50;
			PlayerController.currentPlayer.weaponInventory.usedWeapons[1].weapon.ammoLeftInClip = 10;
		}
		if (enableGrenade)
		{
			PlayerController.currentPlayer.weaponInventory.usedWeapons[2].weapon.ammoLeft = 15;
			PlayerController.currentPlayer.weaponInventory.usedWeapons[2].weapon.ammoLeftInClip = 15;
		}
		PlayerController.currentPlayer.weaponInventory.usedWeapons[0].weapon.ammoSetup.damageAmount = 50f;
		PlayerController.currentPlayer.weaponInventory.usedWeapons[1].weapon.ammoSetup.damageAmount = 120f;
		GrenadeAmmoSetup grenadeAmmoSetup = PlayerController.currentPlayer.weaponInventory.usedWeapons[2].weapon.ammoSetup as GrenadeAmmoSetup;
		grenadeAmmoSetup.damageAmount = 20f;
		grenadeAmmoSetup.explodeDamageAmount = 180f;
	}

	protected void FreezeEnemies()
	{
		Singleton<GameController>.instance.gameControllerTutorial.paused = true;
		soldiers = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		foreach (PoolableObject soldier in soldiers)
		{
			EnemyController enemyController = (EnemyController)soldier;
			enemyController.Freeze(freeze: true);
		}
		if (mPlayerBotTutorial != null)
		{
			mPlayerBotTutorial.botState = PlayerBotTutorial.TutorialBotState.Wait;
		}
		else
		{
			PlayerController playerOld = PlayerController.GetPlayerOld(Fractions.Enemies);
			PlayerBot playerBot = playerOld.playerBot;
			playerBot.enabled = false;
		}
		foreach (PoolableObject bulletsPrefab in bulletsPrefabs)
		{
			List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.ammoPool.GetObjectsMadeOfPrefab(bulletsPrefab);
			foreach (PoolableObject item in objectsMadeOfPrefab)
			{
				if (item.isInstantiated)
				{
					TweenPosition component = item.GetComponent<TweenPosition>();
					component.enabled = false;
				}
			}
		}
		List<PoolableObject> objectsMadeOfPrefab2 = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(this.missile);
		foreach (PoolableObject item2 in objectsMadeOfPrefab2)
		{
			if (item2.isInstantiated)
			{
				Missile missile = (Missile)item2;
				missile.Pause();
			}
		}
		List<PoolableObject> objectsMadeOfPrefab3 = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(grenade);
		foreach (PoolableObject item3 in objectsMadeOfPrefab3)
		{
			if (item3.isInstantiated)
			{
				GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)item3;
				grenadeAmmoBase.Pause();
			}
		}
		PlayerController.currentPlayer.movingFreeze = true;
		Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
	}

	protected void StartTapAnimationOnSoldiersToDeploy()
	{
		int num = 0;
		int index = 0;
		for (int i = 0; i < DeathMatchUnitsGuiElement.instance.guiCards.Count; i++)
		{
			DeathMatchGuiCard deathMatchGuiCard = DeathMatchUnitsGuiElement.instance.guiCards[i];
			if (deathMatchGuiCard.armyUnitDefinition.power > num && deathMatchGuiCard.hasEnoughPower)
			{
				num = deathMatchGuiCard.armyUnitDefinition.power;
				index = i;
			}
		}
		Vector3 worldPoint = DeathMatchUnitsGuiElement.instance.guiCards[index].transform.position + new Vector3(0.05f, 0.05f, 0f);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(worldPoint);
	}

	protected void StartTapAnimationOnSoldiersToDeploy(LevelBehaviour.UnitType type)
	{
		int index = 0;
		for (int i = 0; i < DeathMatchUnitsGuiElement.instance.guiCards.Count; i++)
		{
			DeathMatchGuiCard deathMatchGuiCard = DeathMatchUnitsGuiElement.instance.guiCards[i];
			if (deathMatchGuiCard.armyUnitDefinition != null && deathMatchGuiCard.armyUnitDefinition.armyUnit.behaviour.unitType == type && deathMatchGuiCard.hasEnoughPower)
			{
				index = i;
				break;
			}
		}
		Vector3 worldPoint = DeathMatchUnitsGuiElement.instance.guiCards[index].transform.position + new Vector3(0.05f, 0.05f, 0f);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(worldPoint);
	}

	protected void UnfreezeEnemies()
	{
		Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = autoDeployEnabled;
		Singleton<GameController>.instance.gameControllerTutorial.paused = false;
		foreach (PoolableObject soldier in soldiers)
		{
			EnemyController enemyController = (EnemyController)soldier;
			enemyController.Freeze(freeze: false);
		}
		if (mPlayerBotTutorial != null)
		{
			mPlayerBotTutorial.botState = PlayerBotTutorial.TutorialBotState.ShootEnemyPlayer;
		}
		else
		{
			PlayerController playerOld = PlayerController.GetPlayerOld(Fractions.Enemies);
			PlayerBot playerBot = playerOld.playerBot;
			playerBot.enabled = true;
		}
		foreach (PoolableObject bulletsPrefab in bulletsPrefabs)
		{
			List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.ammoPool.GetObjectsMadeOfPrefab(bulletsPrefab);
			foreach (PoolableObject item in objectsMadeOfPrefab)
			{
				if (item.isInstantiated)
				{
					TweenPosition component = item.GetComponent<TweenPosition>();
					component.enabled = true;
				}
			}
		}
		List<PoolableObject> objectsMadeOfPrefab2 = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(this.missile);
		foreach (PoolableObject item2 in objectsMadeOfPrefab2)
		{
			if (item2.isInstantiated)
			{
				Missile missile = (Missile)item2;
				missile.Resume();
			}
		}
		List<PoolableObject> objectsMadeOfPrefab3 = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(grenade);
		foreach (PoolableObject item3 in objectsMadeOfPrefab3)
		{
			if (item3.isInstantiated)
			{
				GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)item3;
				grenadeAmmoBase.Resume();
			}
		}
		PlayerController.currentPlayer.movingFreeze = false;
	}

	protected virtual void AfterSpawned(AIObject aiObject)
	{
		if (isTutorialRunning && aiObject.fraction == Fractions.Allies && mSpawnCheck)
		{
			mWaitForSpawn = false;
			if (Time.time > mNextSpawnTime || mNextSpawnTime == float.PositiveInfinity)
			{
				mNextSpawnTime = Time.time + 17f;
			}
			DeathMatchUnitsGuiElement.instance.ShowKillHelp(show: false);
		}
	}

	protected IEnumerator SpawnCheckWithPause(float time)
	{
		mWaitForSpawn = true;
		float t = TimeManager.realTimeWithoutPauses + time;
		while (TimeManager.realTimeWithoutPauses < t)
		{
			yield return new WaitForSeconds(0.2f);
		}
		m_NextSpawnTimePause = Time.time;
		if (mWaitForSpawn)
		{
			PlayerController.currentPlayer.updateWeapons = false;
			PlayerController.currentPlayer.canSendCards = false;
			TimeManager.FreezeGame();
			Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("{0}98 FORGOT SPAWN", Singleton<GameController>.instance.gameControllerTutorial.tutorialStageId.Replace("Stage", string.Empty)));
			GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_FORGOT_SPAWN_UP", "ID_TUTORIAL_FORGOT_SPAWN_DOWN", 0f);
			StartTapAnimationOnSoldiersToDeploy(LevelBehaviour.UnitType.Defender);
			while (mWaitForSpawn)
			{
				yield return null;
			}
			GuiElementSingle<TutorialDialog>.instance.HideDialog();
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			TimeManager.UnFreezeGame(0f);
			PlayerController.currentPlayer.updateWeapons = true;
			PlayerController.currentPlayer.canSendCards = true;
		}
	}

	protected IEnumerator SpawnCheck(float time = 13f)
	{
		mSpawnCheck = true;
		mNextSpawnTime = Time.time + time;
		while (true)
		{
			if (Time.time >= mNextSpawnTime && Singleton<SpawningManagerDeathMatch>.instance.progress <= 0f)
			{
				Debug.Log("SHOW SPAWN HELP" + Time.time);
				mNextSpawnTime = float.PositiveInfinity;
				mHasEnergyForAll = Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll;
				if (mHasEnergyForAll)
				{
					if (mShowDeployHint)
					{
						DeathMatchUnitsGuiElement.instance.ShowHintText(show: true, flashEnergy: false);
					}
				}
				else
				{
					DeathMatchUnitsGuiElement.instance.ShowKillHelp(show: true);
				}
			}
			if (mNextSpawnTime == float.PositiveInfinity && Singleton<SpawningManagerDeathMatch>.instance.progress <= 0f)
			{
				if (Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && !mHasEnergyForAll)
				{
					mHasEnergyForAll = true;
					if (mShowDeployHint)
					{
						DeathMatchUnitsGuiElement.instance.ShowHintText(show: true, flashEnergy: false);
					}
				}
				if (!Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && mHasEnergyForAll)
				{
					mHasEnergyForAll = false;
					DeathMatchUnitsGuiElement.instance.ShowKillHelp(show: true);
				}
			}
			yield return new WaitForSeconds(1f);
		}
	}
}
