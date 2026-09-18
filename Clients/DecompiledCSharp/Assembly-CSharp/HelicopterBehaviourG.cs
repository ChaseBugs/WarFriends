public abstract class HelicopterBehaviourG<T> : VehicleBehaviour where T : VehicleBehaviourDefinititon
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
