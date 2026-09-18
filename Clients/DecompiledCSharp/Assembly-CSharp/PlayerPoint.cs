using System.Collections.Generic;
using UnityEngine;

public class PlayerPoint : Core_BaseScript
{
	public ElectricTrap electricTrap;

	public List<Transform> attackPositions;

	public List<TurretPosition> turretPositions;

	private Shield mShield;

	public List<EnemyPointRusher> rusherPoints;

	public Shield shield => mShield ?? (mShield = GetComponentInChildren<Shield>());

	private new void Awake()
	{
		foreach (EnemyPointRusher rusherPoint in rusherPoints)
		{
			rusherPoint.playerPoint = this;
		}
	}
}
