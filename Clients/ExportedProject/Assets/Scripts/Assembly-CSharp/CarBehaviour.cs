using System.Collections.Generic;

public class CarBehaviour : CarBehaviourG<CarBehaviourDefinititon>
{
	public CarBehaviourDefinititon carBehaviourDefinititon
	{
		get
		{
			return (CarBehaviourDefinititon)base.behaviourDefinition;
		}
		set
		{
			base.behaviourDefinition = value;
		}
	}

	public override bool CanBeSpawned(Fractions f, int numberOfEnemies)
	{
		if (Singleton<MapManager>.instance.currentMapDef != null && Singleton<MapManager>.instance.currentMapDef.spawnPointsCollectionCars != null)
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
		}
		return false;
	}
}
