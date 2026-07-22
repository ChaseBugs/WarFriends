using System.Collections.Generic;

public class PlayerStats
{
	public float damageReceivedArmy;

	public float damageReceivedOtherPlayer;

	public float maxDamage;

	public int shots;

	public int hitsToOpponent;

	public int criticalHits;

	public float finalHP;

	public Dictionary<string, int> equippedWeapons;

	public Dictionary<string, string> equippedUnits;

	public Dictionary<string, int> weaponsKills;

	public Dictionary<string, int> unitsDeployedSpecific;

	public Dictionary<string, int> unitsSpawnedSpecific;

	private Dictionary<int, int> mWeaponKills;

	private Dictionary<int, int> mUnitsClickDeploy;

	private Dictionary<int, int> mUnitsSpawned;

	private int mDeployClicks;

	public Dictionary<int, int> GetWeaponKills()
	{
		return null;
	}

	public Dictionary<int, int> GetUnitsClickDeploy()
	{
		return null;
	}

	public Dictionary<int, int> GetUnitSpawned()
	{
		return null;
	}

	public int GetDeployClicks()
	{
		return 0;
	}

	public void OnGameStarted(KJLIMOPJICE properties)
	{
	}

	public void ShotFired()
	{
	}

	public void WeaponKill(int indexInLevelManager)
	{
	}

	public void DoPlayerDamage(DestroyableObject.LDOKCBNNLCH damage)
	{
	}

	public void SetFinalHP(float health)
	{
	}

	public void DeployUnit(int indexInlevelManager, int count, bool clicked)
	{
	}

	public void CountWeaponKills()
	{
	}

	public void CountUnitsDeploys()
	{
	}

	private void SetMaxDamage(float newDamage)
	{
	}
}
