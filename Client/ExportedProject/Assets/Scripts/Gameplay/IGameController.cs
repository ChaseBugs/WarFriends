using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

public abstract class IGameController : Core_BaseScript
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool _003CBLFMFOBGJOL_003Ek__BackingField;

	private List<Card> IMKGAJHJLLM = new List<Card>();

	public abstract float time { get; set; }

	public abstract bool dropCreates { get; }

	public abstract bool gameIsRunning { get; set; }

	public abstract bool canShowPause { get; }

	public abstract bool canDeployUnits { get; }

	public abstract string quitText { get; }

	public virtual bool ableToQuit
	{
		[CompilerGenerated]
		get
		{
			return _003CBLFMFOBGJOL_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CBLFMFOBGJOL_003Ek__BackingField = value;
		}
	}

	public abstract bool pauseCountDown { get; }

	public virtual CardManager.CardFilter cardsFilter => CardManager.CardFilter.All;

	public virtual BNKNNCBAPIH spawningType => BNKNNCBAPIH.Classic;

	public virtual List<UnitUpgradeDefinition> myUpgrades => PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.KBBDGCLPOCJ;

	public virtual List<UnitUpgradeDefinition> opponentUpgrades => Singleton<GameController>.instance.opponent.EHHHBEMKGOE.KBBDGCLPOCJ;

	public virtual PlayerInventory.JIMOKIIJHNA[] equippedWeapons => PlayerInventory.instance.equippedWeapons;

	public virtual int playerLevel => LevelManager.instance.currentLevel.displayNumber;

	public virtual string[] equppedVisuals => CamosManager.instance.equppedIndices;

	public virtual List<Card> cardsForGame
	{
		get
		{
			return IMKGAJHJLLM;
		}
		set
		{
			IMKGAJHJLLM = value;
		}
	}

	public abstract IEnumerator StartGame();

	public abstract void FinishGame();

	public abstract void LoadingStarted();

	public abstract void StopGame(bool KANLHOCIMID = true);

	public abstract void FreeLevel();

	public abstract IEnumerator AquireLevelName();

	public abstract void Quit();

	public abstract void Forfeit();

	public abstract void PauseGame(bool IEFGEFFDHOK);

	public abstract void ResumeGame();

	public abstract void UnPauseGame();

	public abstract void FinishChoosingCards();

	public abstract void Rematch();

	public abstract void GetTimeProgressText(StringBuilder HOLNKOFHDNK);

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

	public virtual float GetPlayerHP(PlayerController NPHCOBMHFND)
	{
		return Singleton<GameVariables>.instance.balancetable.Rows[NPHCOBMHFND.EHHHBEMKGOE.BCCDDJMPBLL].PLAYERHP;
	}

	public virtual float GetShieldHP(PlayerController NPHCOBMHFND)
	{
		return Singleton<GameVariables>.instance.balancetable.Rows[NPHCOBMHFND.EHHHBEMKGOE.BCCDDJMPBLL].SHIELDHP;
	}

	public virtual int GetUnitPower(LevelBehaviour IIHPBNNDMBM)
	{
		UpgradeSlots upgradeSlots = IIHPBNNDMBM.upgradeSlots;
		if (upgradeSlots != null && upgradeSlots.armyUpgradesRow != null)
		{
			return upgradeSlots.totalPower;
		}
		return 0;
	}

	public virtual UpgradeSlots.UnitUpgrades PickUpgradesForUnit(bool KPIGIEPMLLC, AIObject KLHPCPKJGOC)
	{
		UpgradeSlots.UnitUpgrades unitUpgrades = new UpgradeSlots.UnitUpgrades(1f);
		LevelBehaviour aCLDFHJKBLI = KLHPCPKJGOC.ACLDFHJKBLI;
		GHPGNELIDBM fraction = KLHPCPKJGOC.fraction;
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		if (KPIGIEPMLLC && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			UpgradeSlots.UnitUpgrades previewUpgrades = UnitUpgradeDefinition.GetPreviewUpgrades(aCLDFHJKBLI);
			unitUpgrades = aCLDFHJKBLI.upgradeSlots.LoadData(aCLDFHJKBLI, previewUpgrades);
		}
		else if (aCLDFHJKBLI != null)
		{
			if (KLHPCPKJGOC.spawnedByCard)
			{
				aCLDFHJKBLI.upgradeSlots.LoadDataForCard(aCLDFHJKBLI, KLHPCPKJGOC.cardProgress);
			}
			else
			{
				string key = aCLDFHJKBLI.GetType().ToString();
				Dictionary<string, UnitUpgradeDefinition> dictionary = PAGGMONGACL(fraction);
				if (dictionary.TryGetValue(key, out var value))
				{
					unitUpgrades = value.unitUpgrades;
				}
				fCLADBGKCIA = CheckForPerks(aCLDFHJKBLI, fraction);
				aCLDFHJKBLI.upgradeSlots.LoadData(aCLDFHJKBLI, unitUpgrades, fCLADBGKCIA);
			}
		}
		KLHPCPKJGOC.IGKDFJKEELP = fCLADBGKCIA;
		return unitUpgrades;
	}

	public FCLADBGKCIA CheckForPerks(LevelBehaviour EIECJNNCDJP, GHPGNELIDBM CIOPAKLHFIL)
	{
		FCLADBGKCIA fCLADBGKCIA = new FCLADBGKCIA();
		if (Singleton<GameController>.instance.opponent != null)
		{
			List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
			PlayerController friend = PlayerController.GetFriend(CIOPAKLHFIL);
			if (friend != null)
			{
				List<UnitUpgradeDefinition> list = friend.EHHHBEMKGOE.KBBDGCLPOCJ;
				for (int i = 0; i < list.Count; i++)
				{
					UnitUpgradeDefinition def = list[i];
					LevelBehaviour levelBehaviour = behaviours[i];
					fCLADBGKCIA = levelBehaviour.MultipleCurrentPerkForUnit(EIECJNNCDJP, def, fCLADBGKCIA, PDNPBLFEPJG.Buff);
				}
			}
			PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
			if (enemyOf != null)
			{
				List<UnitUpgradeDefinition> list2 = enemyOf.EHHHBEMKGOE.KBBDGCLPOCJ;
				for (int j = 0; j < list2.Count; j++)
				{
					UnitUpgradeDefinition def2 = list2[j];
					LevelBehaviour levelBehaviour2 = behaviours[j];
					fCLADBGKCIA = levelBehaviour2.MultipleCurrentPerkForUnit(EIECJNNCDJP, def2, fCLADBGKCIA, PDNPBLFEPJG.Debuff);
				}
			}
		}
		return fCLADBGKCIA;
	}

	protected virtual Dictionary<string, UnitUpgradeDefinition> PAGGMONGACL(GHPGNELIDBM CIOPAKLHFIL)
	{
		return PlayerController.GetPlayer(CIOPAKLHFIL).EHHHBEMKGOE.HDDPODGBNIC;
	}

	public virtual void ShowResultsScreen()
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<EndScreen>.instance);
	}
}
