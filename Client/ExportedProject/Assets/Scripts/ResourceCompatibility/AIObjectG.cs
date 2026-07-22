using System;

public class AIObjectG<T> : AIObject where T : LevelBehaviour
{
	public bool isInField => false;

	public T currentBeh => null;

	public override void OnInstancied()
	{
	}

	public override Type GetBehaviourType()
	{
		return null;
	}
}
