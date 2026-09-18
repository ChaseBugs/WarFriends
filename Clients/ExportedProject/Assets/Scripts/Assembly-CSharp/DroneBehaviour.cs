public class DroneBehaviour : DroneBehaviourG<DroneBehaviourDefinititon>
{
	public DroneBehaviourDefinititon droneBehaviourDefinition
	{
		get
		{
			return (DroneBehaviourDefinititon)base.behaviourDefinition;
		}
		set
		{
			base.behaviourDefinition = value;
		}
	}
}
