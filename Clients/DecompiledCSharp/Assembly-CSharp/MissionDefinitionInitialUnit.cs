using System;
using UnityEngine;

[Serializable]
public class MissionDefinitionInitialUnit
{
	public enum MissionDefinitionInitialUnitBehaviour
	{
		Turret,
		HeavyTurret,
		RocketTurret
	}

	public MissionDefinitionInitialUnitBehaviour behaviour;

	public int level;

	public Vector3 position;
}
