using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IGameController : Core_BaseScript
{
	private List<Card> mCardsForGame = new List<Card>();

	public abstract float time { get; set; }

	public abstract bool dropCreates { get; }

	public abstract bool gameIsRunning { get; set; }

	public abstract bool canShowPause { get; }

	public abstract bool canDeployUnits { get; }

	public abstract string quitText { get; }

	public virtual bool ableToQuit { get; set; }

	public abstract bool pauseCountDown { get; }

	public virtual CardManager.CardFilter cardsFilter => CardManager.CardFilter.All;

	public virtual SpawningType spawningType => SpawningType.Classic;

	public virtual List<UnitUpgradeDefinition> myUpgrades => PlayerController.currentPlayer.playerProperties.upgrades;

	public virtual List<UnitUpgradeDefinition> opponentUpgrades => Singleton<GameController>.instance.opponent.playerProperties.upgrades;

	public virtual PlayerInventory.EquippedWeapon[] equippedWeapons => PlayerInventory.instance.equippedWeapons;

	public virtual int playerLevel => LevelManager.instance.currentLevel.displayNumber;

	public virtual string[] equppedVisuals => CamosManager.instance.equppedIndices;

	public virtual List<Card> cardsForGame
	{
		get
		{
			return mCardsForGame;
		}
		set
		{
			mCardsForGame = value;
		}
	}

	public abstract IEnumerator StartGame();

	public abstract void FinishGame();

	public abstract void LoadingStarted();

	public abstract void StopGame(bool switchScreen = true);

	public abstract void FreeLevel();

	public abstract IEnumerator AquireLevelName();

	public abstract void Quit();

	public abstract void Forfeit();

	public abstract void PauseGame(bool focusLost);

	public abstract void ResumeGame();

	public abstract void UnPauseGame();

	public abstract void FinishChoosingCards();

	public abstract void Rematch();

	public abstract void GetTimeProgressText(StringBuilder text);

	public virtual List<UnitUpgradeDefinition> GetUnitsUpgrades()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<UnitUpgradeDefinition> list = new List<UnitUpgradeDefinition>();
		foreach (LevelBehaviour item in behaviours)
		{
			UpgradeSlots.UnitUpgrades upgradeIndex = item.upgradeSlots.LoadData(item);
			list.Add(new UnitUpgradeDefinition(item.upgradeSlots.canUseInBattle, upgradeIndex, item.upgradeSlots.isNew, item.upgradeSlots.actualTier));
		}
		return list;
	}

	public virtual float GetPlayerHP(PlayerController playerController)
	{
		return Singleton<GameVariables>.instance.balancetable.Rows[playerController.playerProperties.level].PLAYERHP;
	}

	public virtual float GetShieldHP(PlayerController playerController)
	{
		return Singleton<GameVariables>.instance.balancetable.Rows[playerController.playerProperties.level].SHIELDHP;
	}

	public virtual UpgradeSlots.UnitUpgrades PickUpgradesForUnit(bool isPreview, AIObject aiObject)
	{
		UpgradeSlots.UnitUpgrades unitUpgrades = new UpgradeSlots.UnitUpgrades(1f);
		LevelBehaviour behaviour = aiObject.behaviour;
		Fractions fraction = aiObject.fraction;
		Perk perk = new Perk();
		if (isPreview && Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
		{
			UpgradeSlots.UnitUpgrades previewUpgrades = UnitUpgradeDefinition.GetPreviewUpgrades(behaviour, 1f);
			unitUpgrades = behaviour.upgradeSlots.LoadData(behaviour, previewUpgrades);
		}
		else if (behaviour != null)
		{
			if (aiObject.spawnedByCard)
			{
				behaviour.upgradeSlots.LoadDataForCard(behaviour, aiObject.cardProgress);
				Debug.Log($"Loading for card: hp: {behaviour.behaviourDefinition.health}, progress:{aiObject.cardProgress}, obj {aiObject.gameObject.name} ");
			}
			else
			{
				string key = behaviour.GetType().ToString();
				Dictionary<string, UnitUpgradeDefinition> upgradesDictionary = GetUpgradesDictionary(fraction);
				if (upgradesDictionary.TryGetValue(key, out var value))
				{
					unitUpgrades = value.unitUpgrades;
				}
				perk = CheckForPerks(behaviour, fraction);
				behaviour.upgradeSlots.LoadData(behaviour, unitUpgrades, perk);
			}
		}
		aiObject.perk = perk;
		return unitUpgrades;
	}

	public Perk CheckForPerks(LevelBehaviour affectedBehavior, Fractions fraction)
	{
		Perk perk = new Perk();
		if (Singleton<GameController>.instance.opponent != null)
		{
			List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
			PlayerController friend = PlayerController.GetFriend(fraction);
			if (friend != null)
			{
				List<UnitUpgradeDefinition> upgrades = friend.playerProperties.upgrades;
				for (int i = 0; i < upgrades.Count; i++)
				{
					UnitUpgradeDefinition def = upgrades[i];
					LevelBehaviour levelBehaviour = behaviours[i];
					perk = levelBehaviour.MultipleCurrentPerkForUnit(affectedBehavior, def, perk, PerkType.Buff);
				}
			}
			PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
			if (enemyOf != null)
			{
				List<UnitUpgradeDefinition> upgrades2 = enemyOf.playerProperties.upgrades;
				for (int j = 0; j < upgrades2.Count; j++)
				{
					UnitUpgradeDefinition def2 = upgrades2[j];
					LevelBehaviour levelBehaviour2 = behaviours[j];
					perk = levelBehaviour2.MultipleCurrentPerkForUnit(affectedBehavior, def2, perk, PerkType.Debuff);
				}
			}
		}
		return perk;
	}

	protected virtual Dictionary<string, UnitUpgradeDefinition> GetUpgradesDictionary(Fractions fraction)
	{
		return PlayerController.GetPlayer(fraction).playerProperties.upgradesDictionary;
	}

	public virtual void ShowResultsScreen()
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<EndScreen>.instance);
	}
}
