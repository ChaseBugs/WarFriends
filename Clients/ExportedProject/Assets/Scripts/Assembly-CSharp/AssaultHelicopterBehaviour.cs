public class AssaultHelicopterBehaviour : AssaultHelicopterBehaviourG<AssaultHelicopterBehaviourDefinititon>
{
	public AssaultHelicopterBehaviourDefinititon assaultHelicopterBehaviour
	{
		get
		{
			return (AssaultHelicopterBehaviourDefinititon)base.behaviourDefinition;
		}
		set
		{
			base.behaviourDefinition = value;
		}
	}
}
