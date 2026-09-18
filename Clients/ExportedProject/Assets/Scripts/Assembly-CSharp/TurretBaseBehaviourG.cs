public abstract class TurretBaseBehaviourG<T> : VehicleBehaviour where T : VehicleBehaviourDefinititon
{
	public T baseDefinition;

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
			return baseDefinition;
		}
		set
		{
		}
	}
}
