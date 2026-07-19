public abstract class TurretBaseBehaviourG<T> : VehicleBehaviour where T : VehicleBehaviourDefinititon
{
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
