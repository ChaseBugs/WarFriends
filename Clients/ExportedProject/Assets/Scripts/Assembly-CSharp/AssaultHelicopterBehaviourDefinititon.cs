using System;
using CodeStage.AntiCheat.ObscuredTypes;

[Serializable]
public class AssaultHelicopterBehaviourDefinititon : VehicleBehaviourDefinititon
{
	public ObscuredFloat glassHealth = 100f;

	public override void LoadZeros()
	{
		base.LoadZeros();
		speed = 0f;
		glassHealth = 0f;
	}
}
