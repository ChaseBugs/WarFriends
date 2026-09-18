public class HelicopterBehaviour : HelicopterBehaviourG<HelicopterBehaviourDefinititon>
{
	public HelicopterBehaviourDefinititon helicopterBehaviourDefinititon
	{
		get
		{
			return (HelicopterBehaviourDefinititon)base.behaviourDefinition;
		}
		set
		{
			base.behaviourDefinition = value;
		}
	}
}
