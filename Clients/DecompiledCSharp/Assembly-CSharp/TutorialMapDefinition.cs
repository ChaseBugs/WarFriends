using System.Collections.Generic;
using UnityEngine;

public class TutorialMapDefinition : MonoBehaviour
{
	public EnemyPointsCollection enemyPointsCollection;

	public Transform grenadePoint;

	public Transform spawnForGrenadeSoldiers;

	public List<EnemyPoint> rocketLauncherEnemyPoint;

	public List<EnemyPoint> firstUnitTargets;

	public Transform spawnForMachinegunner;

	public EnemyPoint machinegunnerPoint;
}
