using System;

[Serializable]
public class CarTransporterBehaviourDefinititon : VehicleBehaviourDefinititon
{
	public float repairBotHP;

	public override void LoadZeros()
	{
		base.LoadZeros();
		repairBotHP = 0f;
	}

	public override void ScaleDamageAndHP(float damageFactor, float hpFactor)
	{
		repairBotHP *= hpFactor;
		base.ScaleDamageAndHP(damageFactor, hpFactor);
	}
}
