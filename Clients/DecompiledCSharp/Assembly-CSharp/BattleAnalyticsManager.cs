using System.Collections.Generic;
using UnityEngine;

public class BattleAnalyticsManager : Core_BaseScript
{
	public class PlayerStats
	{
		public float damageReceivedArmy;

		public float damageReceivedOtherPlayer;

		public float maxDamage;

		public int shots;

		public int hitsToOpponent;

		public int criticalHits;

		public float finalHP;

		public Dictionary<string, int> equippedWeapons = new Dictionary<string, int>();

		public Dictionary<string, int> equippedUnits = new Dictionary<string, int>();
	}

	public class BattleData
	{
		public PlayerStats playerOpponent;

		public PlayerStats playerCurrent;

		public GameController.GameEndReason gameEndReason;

		public float matchTime;

		public BattleData()
		{
			playerCurrent = new PlayerStats();
			playerOpponent = new PlayerStats();
		}
	}

	public BattleData battleData = new BattleData();

	private static BattleAnalyticsManager mInstance;

	public static BattleAnalyticsManager instance
	{
		get
		{
			mInstance = mInstance ?? ((BattleAnalyticsManager)Object.FindObjectsOfType(typeof(BattleAnalyticsManager))[0]);
			return mInstance;
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		Weapon.OnShotFired += WeaponOnOnShotFired;
	}

	private void WeaponOnOnShotFired(Weapon weapon, Vector3 target)
	{
		PlayerController playerController = weapon.owner as PlayerController;
		if (playerController != null)
		{
			PlayerStats stats = GetStats(playerController);
			stats.shots++;
		}
	}

	private void OnGameStarted()
	{
		battleData = new BattleData();
	}

	private PlayerStats GetStats(PlayerController player)
	{
		return (!player.isCurrentPlayer) ? battleData.playerCurrent : battleData.playerOpponent;
	}

	public void DoPlayerDamage(PlayerController player, DestroyableObject.DamageInfo dmg)
	{
		if (player == null)
		{
			return;
		}
		PlayerStats stats = GetStats(player);
		if (dmg.isCritical)
		{
			stats.criticalHits++;
		}
		if (dmg.owner is AIObject)
		{
			stats.damageReceivedArmy += dmg.damageAmount;
		}
		else if (dmg.owner is PlayerController)
		{
			stats.damageReceivedOtherPlayer += dmg.damageAmount;
			PlayerStats stats2 = GetStats((PlayerController)dmg.owner);
			stats2.hitsToOpponent++;
			if (stats2.maxDamage < dmg.damageAmount)
			{
				stats2.maxDamage = dmg.damageAmount;
			}
		}
	}

	public void FinishGame()
	{
		battleData.matchTime = Singleton<MatchManager>.instance.matchTime;
		battleData.gameEndReason = Singleton<GameController>.instance.gameEndReason;
		PlayerStats stats = GetStats(PlayerController.currentPlayer);
		stats.equippedWeapons = PlayerController.currentPlayer.playerProperties.GetWeaponsForStats();
		stats.equippedUnits = PlayerController.currentPlayer.playerProperties.GetArmyForStats();
		stats.finalHP = PlayerController.currentPlayer.destroyableParts.health;
		if (Singleton<GameController>.instance.opponent != null)
		{
			PlayerStats stats2 = GetStats(Singleton<GameController>.instance.opponent);
			stats2.equippedWeapons = Singleton<GameController>.instance.opponent.playerProperties.GetWeaponsForStats();
			stats2.equippedUnits = Singleton<GameController>.instance.opponent.playerProperties.GetArmyForStats();
			stats2.finalHP = Singleton<GameController>.instance.opponent.destroyableParts.health;
		}
	}
}
