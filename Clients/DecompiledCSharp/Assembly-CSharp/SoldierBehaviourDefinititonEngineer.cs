using System;
using UnityEngine;

[Serializable]
public class SoldierBehaviourDefinititonEngineer : SoldierBehaviourDefinititon
{
	public int turretUpgradeLevel;

	public override void LoadZeros()
	{
		base.LoadZeros();
		turretUpgradeLevel = 0;
	}

	public override BehaviourDefinititon Interpolate(BehaviourDefinititon d1, BehaviourDefinititon d2, float ratio)
	{
		SoldierBehaviourDefinititonEngineer soldierBehaviourDefinititonEngineer = (SoldierBehaviourDefinititonEngineer)d1;
		SoldierBehaviourDefinititonEngineer soldierBehaviourDefinititonEngineer2 = (SoldierBehaviourDefinititonEngineer)d2;
		SoldierBehaviourDefinititonEngineer soldierBehaviourDefinititonEngineer3 = (SoldierBehaviourDefinititonEngineer)base.Interpolate(d1, d2, ratio);
		soldierBehaviourDefinititonEngineer3.turretUpgradeLevel = (int)Mathf.Lerp(soldierBehaviourDefinititonEngineer.turretUpgradeLevel, soldierBehaviourDefinititonEngineer2.turretUpgradeLevel, ratio);
		return soldierBehaviourDefinititonEngineer3;
	}
}
