using System;

[Serializable]
public class HelicopterBehaviourDefinititon : VehicleBehaviourDefinititon
{
	public int crew;

	public override void LoadZeros()
	{
		base.LoadZeros();
		crew = 0;
	}
}
