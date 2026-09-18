using System.Collections.Generic;

public class CarTransporterBehaviour : CarTransporterBehaviourG<CarTransporterBehaviourDefinititon>
{
	public CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon
	{
		get
		{
			return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
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
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.fraction == f && spawnPointVehicle.usedByEntity == null)
			{
				return true;
			}
		}
		return false;
	}
}
