public abstract class CarBehaviourG<T> : VehicleBehaviour where T : VehicleBehaviourDefinititon
{
	public T baseDefinition;

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
