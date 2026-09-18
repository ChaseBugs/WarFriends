using System;

[Serializable]
public class SoldierBehaviourDefinititonCommando : SoldierBehaviourDefinititon
{
	public override void LoadZeros()
	{
		base.LoadZeros();
	}

	public override BehaviourDefinititon Interpolate(BehaviourDefinititon d1, BehaviourDefinititon d2, float ratio)
	{
		SoldierBehaviourDefinititonFlamethrower soldierBehaviourDefinititonFlamethrower = (SoldierBehaviourDefinititonFlamethrower)d1;
		SoldierBehaviourDefinititonFlamethrower soldierBehaviourDefinititonFlamethrower2 = (SoldierBehaviourDefinititonFlamethrower)d2;
		return (SoldierBehaviourDefinititonCommando)base.Interpolate(d1, d2, ratio);
	}
}
