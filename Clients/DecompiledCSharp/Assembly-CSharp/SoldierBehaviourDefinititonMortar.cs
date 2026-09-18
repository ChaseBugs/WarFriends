using System;
using UnityEngine;

[Serializable]
public class SoldierBehaviourDefinititonMortar : SoldierBehaviourDefinititon
{
	public float mortarBuildTime;

	public override void LoadZeros()
	{
		base.LoadZeros();
		mortarBuildTime = 0f;
	}

	public override BehaviourDefinititon Interpolate(BehaviourDefinititon d1, BehaviourDefinititon d2, float ratio)
	{
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = (SoldierBehaviourDefinititonMortar)d1;
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar2 = (SoldierBehaviourDefinititonMortar)d2;
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar3 = (SoldierBehaviourDefinititonMortar)base.Interpolate(d1, d2, ratio);
		soldierBehaviourDefinititonMortar3.mortarBuildTime = Mathf.Lerp(soldierBehaviourDefinititonMortar.mortarBuildTime, soldierBehaviourDefinititonMortar2.mortarBuildTime, ratio);
		return soldierBehaviourDefinititonMortar3;
	}
}
