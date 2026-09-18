using System.Collections.Generic;

public class GeneratedGameObject : PoolableObject
{
	public LinkedListNode<GeneratedGameObject> nodeInGenerator;

	public GeneratedObjectManager generator;

	public virtual void Destroy()
	{
		DestroyPooled();
		if (generator != null)
		{
			generator.Delete(this);
		}
	}
}
