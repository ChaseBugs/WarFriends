using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBuddy : Card
{
	public override CardManager.CardType rarity => CardManager.CardType.Buddy;

	public override int newFromMission => 1;

	public CardManager.BuddyCardData buddyCardData { get; set; }

	public override string cardName => (buddyCardData != null && !string.IsNullOrEmpty(buddyCardData.buddyName)) ? buddyCardData.buddyName : string.Empty;

	public override string description => Localization.LocalizeFormat("ID_CARD_DESC_BUDDY", Localization.Localize(GameVariables.unitType[buddyCardData.unityType].Value1).ToUpper(), buddyCardData.buddyName);

	public string createDescription => Localization.LocalizeFormat("ID_CARD_DESC_BUDDYCREATE", buddyCardData.buddyName);

	public override int amount => (buddyCardData != null) ? buddyCardData.amount : 0;

	public override string unitTypeSpriteName => GameVariables.unitType[buddyCardData.unityType].Value2;

	private static SoldierBehaviourBuddy behaviour => (SoldierBehaviourBuddy)Singleton<LevelBehaviourManager>.instance.behavioursDic[typeof(SoldierBehaviourBuddy).Name];

	public override void RemoveCard()
	{
		if (buddyCardData != null)
		{
			buddyCardData.amount = 0;
		}
	}

	public void Init(string cardId, CardManager.BuddyCardData data)
	{
		if (data.amount == 0)
		{
			data.amount = 1;
		}
		base.iconTexture = null;
		id = cardId;
		buddyCardData = data;
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		cardManager.CardWasUsed(this, fraction);
		if (PhotonNetwork.isMasterClient)
		{
			SpawnUnit(fraction);
		}
	}

	private void SpawnUnit(Fractions fraction)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(fraction);
		float progress = (float)playerOld.playerProperties.level / (float)LevelManager.instance.maxDisplayLevel;
		AIObject aIObject = SpawningManager.instance.SpawnCardBehaviour(behaviour, playerOld.fraction, progress, Vector3.one * 9999f, spawnEnabled: false, id);
		EnemyController enemyController = (EnemyController)aIObject;
		SoldierBehaviourBuddy soldierBehaviourBuddy = (SoldierBehaviourBuddy)enemyController.soldierBehaviour;
		soldierBehaviourBuddy.ChangeCamo(buddyCardData.equippedVisuals);
		soldierBehaviourBuddy.Init(buddyCardData, progress);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		base.UseCardOnline(cardManager, fraction);
		if (base.isOnlineMaster)
		{
			SpawnUnit(fraction);
		}
	}

	public override IEnumerator InitCard(bool isOpponentCard)
	{
		WeaponLevelsSetup prim = LevelManager.instance.weaponLevelsSetups[buddyCardData.primaryWeapon];
		WeaponLevelsSetup sec = ((buddyCardData.secondaryWeapon <= 0) ? null : LevelManager.instance.weaponLevelsSetups[buddyCardData.secondaryWeapon]);
		Debug.Log(string.Format("CardBuddy Init: Prim: {0} Sec: {1} Type: {2} IsOpponent {3}", prim.name, (!(sec != null)) ? "null" : sec.name, buddyCardData.unityType, isOpponentCard));
		EnemyLeveledWeapon leveledWeapon = prim.unitWeaponPrefab.GetComponent<EnemyLeveledWeapon>();
		if (leveledWeapon != null)
		{
			yield return StartCoroutine(leveledWeapon.PrepareAsync(prim.unitWeaponLevel));
		}
		if (sec != null)
		{
			leveledWeapon = sec.unitWeaponPrefab.GetComponent<EnemyLeveledWeapon>();
			if (leveledWeapon != null)
			{
				yield return StartCoroutine(leveledWeapon.PrepareAsync(sec.unitWeaponLevel));
			}
		}
	}

	public override void ShowInMenu()
	{
		base.ShowInMenu();
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((buddyCardData == null) ? null : buddyCardData.equippedVisuals);
		DatabasePlayer player = databasePlayer;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= InstanceOnOnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += InstanceOnOnPlayerTextureCreated;
		int num = Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(player, useBackground: false, PlayerTexturePool.RenderType.Card);
		if (DebugSettings.debugEnabled)
		{
			Debug.Log($"CARD BUDDY - SHOW IN MENU - Player: {id} actual reference count: {num}");
		}
	}

	public void DestroyCard()
	{
		int num = Singleton<PlayerTexturePool>.instance.FreePlayerTexture(id, useBackground: false);
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((buddyCardData == null) ? null : buddyCardData.equippedVisuals);
		DatabasePlayer player = databasePlayer;
		while (num > 0)
		{
			num = Singleton<PlayerTexturePool>.instance.FreePlayerTexture(player, useBackground: false);
		}
		base.iconTexture = null;
		id = "DESTROYED REFERENCE";
		if (DebugSettings.debugEnabled)
		{
			Debug.Log($"CARD BUDDY - DESTROY CARD - Player: {id}");
		}
	}

	public override void HideInMenu()
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((buddyCardData == null) ? null : buddyCardData.equippedVisuals);
		DatabasePlayer player = databasePlayer;
		int num = Singleton<PlayerTexturePool>.instance.FreePlayerTexture(player, useBackground: false);
		if (DebugSettings.debugEnabled)
		{
			Debug.Log($"CARD BUDDY - HIDE IN MENU - Player: {id} actual reference count: {num}");
		}
		if (num <= 0)
		{
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= InstanceOnOnPlayerTextureCreated;
			base.iconTexture = null;
		}
		base.HideInMenu();
	}

	private void InstanceOnOnPlayerTextureCreated(string s, Texture2D texture2D, bool useBackground)
	{
		if (s == id)
		{
			base.iconTexture = texture2D;
		}
	}

	public static CardManager.BuddyCardData CreateDataForCurrentPlayer()
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = slot.Value.equippedID
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		int num = 0;
		int num2 = -1;
		WeaponLevelsSetup weaponLevelsSetup = PlayerInventory.instance.inventorySlots[0].weaponLevelsSetup;
		WeaponLevelsSetup weaponLevelsSetup2 = PlayerInventory.instance.inventorySlots[1].weaponLevelsSetup;
		WeaponLevelsSetup weaponLevelsSetup3 = PlayerInventory.instance.inventorySlots[2].weaponLevelsSetup;
		WeaponLevelsSetup weaponLevelsSetup4 = PlayerInventory.instance.inventorySlots[3].weaponLevelsSetup;
		int num3 = Random.Range(0, 4);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.weaponCategory == WeaponCategory.RocketLauncher || weaponLevelsSetup3.weaponCategory == WeaponCategory.GrenadeLauncher)
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.weaponCategory != WeaponCategory.SniperRifle) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.weaponCategory != WeaponCategory.Shotgun) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 0) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.unitWeaponPrefab == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.unitWeaponPrefab == null))
		{
			Debug.LogError(string.Format("Cant generate buddy card for weapons: {0}, {1} and type {2}", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "null" : weaponLevelsSetup6.name, unitType));
			return CreateDataForCurrentPlayer();
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 1;
		buddyCardData.buddyName = GameLoginManager.currentPlayer.name;
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = LevelManager.instance.armyPower;
		buddyCardData.level = LevelManager.instance.currentLevel.index;
		return buddyCardData;
	}

	public static CardManager.BuddyCardData CreateRandomByddyCard(int maxLevel, int armyPower)
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = BotManager.GetRandomUnlocked(playerVisualCategories[slot.Key], maxLevel)
			});
		}
		int num = 0;
		int num2 = -1;
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.Primary, maxLevel)];
		WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.Special, maxLevel)];
		WeaponLevelsSetup weaponLevelsSetup3 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.Explosive, maxLevel)];
		WeaponLevelsSetup weaponLevelsSetup4 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.Pistol, maxLevel)];
		int num3 = Random.Range(0, 4);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.weaponCategory == WeaponCategory.RocketLauncher || weaponLevelsSetup3.weaponCategory == WeaponCategory.GrenadeLauncher)
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.weaponCategory != WeaponCategory.SniperRifle || !(weaponLevelsSetup2.unitWeaponPrefab != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.weaponCategory != WeaponCategory.Shotgun || !(weaponLevelsSetup2.unitWeaponPrefab != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 0) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.unitWeaponPrefab == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.unitWeaponPrefab == null))
		{
			Debug.LogError(string.Format("Cant generate buddy card for weapons: {0}, {1} and type {2}", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "null" : weaponLevelsSetup6.name, unitType));
			return CreateRandomByddyCard(maxLevel, armyPower);
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 1;
		buddyCardData.buddyName = "Warfriend" + Random.Range(100000, 999999);
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = armyPower;
		buddyCardData.level = maxLevel;
		return buddyCardData;
	}
}
