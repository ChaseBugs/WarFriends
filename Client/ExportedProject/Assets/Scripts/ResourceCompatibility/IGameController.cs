using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public abstract class IGameController : Core_BaseScript
{
	[CompilerGenerated]
	private bool _003CDJMMCLLEAFI_003Ek__BackingField;

	private List<Card> AEMCMIAIKNA;

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
			return false;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public abstract bool pauseCountDown { get; }

	public virtual CardManager.CardFilter cardsFilter => default(CardManager.CardFilter);

	public virtual IBMHKHLJJNA spawningType => default(IBMHKHLJJNA);

	public virtual List<UnitUpgradeDefinition> myUpgrades => null;

	public virtual List<UnitUpgradeDefinition> opponentUpgrades => null;

	public virtual PlayerInventory.EquippedWeapon[] equippedWeapons => null;

	public virtual int playerLevel => 0;

	public virtual int playerPrestigeLevel => 0;

	public virtual string[] equppedVisuals => null;

	public virtual bool isEqualMatch => false;

	public virtual bool isIgnoringMax2UnitsPerCategory => false;

	public virtual bool isUsingAugmentations => false;

	public virtual bool isUsingWeaponAugmentations => false;

	public virtual bool isSuperChargedUnitsEnabled => false;

	public virtual List<Card> cardsForGame
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public abstract IEnumerator StartGame();

	public abstract void FinishGame();

	public abstract void LoadingStarted();

	public abstract void StopGame(bool FKIOECHJOOO = true);

	public abstract void FreeLevel();

	public abstract IEnumerator AquireLevelName();

	public abstract void Quit();

	public abstract void Forfeit();

	public abstract void PauseGame(bool PHDBMIIGJKC);

	public abstract void ResumeGame();

	public abstract void UnPauseGame();

	public abstract void FinishChoosingCards();

	public abstract void Rematch();

	public abstract void GetTimeProgressText(StringBuilder BALEOFOKIOC);

	public virtual List<UnitUpgradeDefinition> GetUnitsUpgrades()
	{
		return null;
	}

	public virtual float GetPlayerHP(PlayerController EGJCNDAINGF)
	{
		return 0f;
	}

	public virtual float GetShieldHP(PlayerController EGJCNDAINGF)
	{
		return 0f;
	}

	public virtual int GetUnitPower(LevelBehaviour HDNJKKKHFNG)
	{
		return 0;
	}

	public virtual UpgradeSlots.UnitUpgrades PickUpgradesForUnit(bool CJPHFLKKIPD, AIObject FKJGHEFHPKE)
	{
		return default(UpgradeSlots.UnitUpgrades);
	}

	public FEPKHDHDKII CheckForPerks(LevelBehaviour JBIEACBBOOI, HPHFGNJPDKN LBHJBBKENEO)
	{
		return null;
	}

	protected virtual Dictionary<string, UnitUpgradeDefinition> IMBPKPDEKEP(HPHFGNJPDKN LBHJBBKENEO)
	{
		return null;
	}

	public virtual void ShowResultsScreen()
	{
	}

	public virtual void ShowGameOverScreen()
	{
	}

	public virtual bool DidGameOverScreenClose()
	{
		return false;
	}
}
