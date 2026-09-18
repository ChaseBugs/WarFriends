using System;

[Serializable]
public class SoldierBehaviourDefinititonMinigunner : SoldierBehaviourDefinititon
{
	public float shieldRechargeRate;

	public override void LoadZeros()
	{
		base.LoadZeros();
		shieldRechargeRate = 0f;
	}
}
