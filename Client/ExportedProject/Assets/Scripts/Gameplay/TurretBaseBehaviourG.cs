using UnityEngine.Serialization;

public abstract class TurretBaseBehaviourG<T> : VehicleBehaviour where T : VehicleBehaviourDefinititon
{
	[FormerlySerializedAs("PNDGJKHJEOD")]
	public T OLCJKFMGKAJ;

	public T turretBehaviour
	{
		get
		{
			return (T)base.behaviourDefinition;
		}
		set
		{
			base.behaviourDefinition = value;
		}
	}

	public override VehicleBehaviourDefinititon baseVehicleDefinititon
	{
		get
		{
			return OLCJKFMGKAJ;
		}
		set
		{
		}
	}
}
