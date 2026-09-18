using System.Collections.Generic;

public class CarBuggyBehaviour : CarBuggyBehaviourG<CarBuggyBehaviourDefinititon>
{
	public CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon
	{
		get
		{
			return (CarBuggyBehaviourDefinititon)base.behaviourDefinition;
		}
		set
		{
			base.behaviourDefinition = value;
		}
	}

	public override bool CanBeSpawned(Fractions f, int numberOfEnemies)
	{
		List<SpawnPoint> spawnPoints = Singleton<MapManager>.instance.currentMapDef.spawnPointsCollectionCars.spawnPoints;
		foreach (SpawnPoint item in spawnPoints)
		{
			SpawnPointCar spawnPointCar = (SpawnPointCar)item;
			if (item.fraction == f && spawnPointCar.usedByEntity == null)
			{
				return true;
			}
		}
		return false;
	}
}
