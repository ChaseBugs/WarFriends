using System.Collections.Generic;
using UnityEngine;

public class GeneratedObjectManager : Core_BaseScript
{
	public LinkedList<GeneratedGameObject> generatedObjects = new LinkedList<GeneratedGameObject>();

	public string poolName = "ObjectPool";

	public ObjectPool pool;

	protected override void Awake()
	{
		base.Awake();
		pool = ObjectPool.GetPool(poolName);
	}

	public virtual GeneratedGameObject Generate(GeneratedGameObject generatedObject, Vector3 position, Quaternion rotation)
	{
		GeneratedGameObject generatedGameObject = (GeneratedGameObject)pool.Instantiate(generatedObject, position, rotation);
		if (generatedGameObject != null)
		{
			generatedGameObject.nodeInGenerator = generatedObjects.AddLast(generatedGameObject);
			generatedGameObject.generator = this;
			return generatedGameObject;
		}
		return null;
	}

	public virtual GeneratedGameObject ReGenerate(GeneratedGameObject generatedObject, Vector3 position, Quaternion rotation)
	{
		GeneratedGameObject generatedGameObject = pool.ReInstantiate(generatedObject, position, rotation) as GeneratedGameObject;
		if (generatedGameObject != null)
		{
			generatedGameObject.nodeInGenerator = generatedObjects.AddLast(generatedGameObject);
			generatedGameObject.generator = this;
			return generatedGameObject;
		}
		return null;
	}

	public virtual void Delete(GeneratedGameObject generatedGameObject)
	{
		if (generatedGameObject.nodeInGenerator != null)
		{
			generatedObjects.Remove(generatedGameObject.nodeInGenerator);
		}
	}
}
