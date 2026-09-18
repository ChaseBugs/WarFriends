public abstract class VehicleBehaviour : LevelBehaviour
{
	public abstract VehicleBehaviourDefinititon baseVehicleDefinititon { get; set; }

	public override BehaviourDefinititon baseBehaviourDefinititon => baseVehicleDefinititon;
}
