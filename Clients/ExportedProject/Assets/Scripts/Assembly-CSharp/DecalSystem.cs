using UnityEngine;

public class DecalSystem : GeneratedObjectManager
{
	private static DecalSystem _instance;

	public Decal decalPrefab;

	private int numberOfObjectInPool;

	public static DecalSystem Instance
	{
		get
		{
			_instance = _instance ?? ((DecalSystem)Object.FindObjectsOfType(typeof(DecalSystem))[0]);
			return _instance;
		}
	}

	public void OnDestroy()
	{
		_instance = null;
	}

	protected override void Start()
	{
		base.Start();
		numberOfObjectInPool = pool.GetCountInPool(decalPrefab);
	}

	public void PlayDecal(Vector3 position, Vector3 normal, int index)
	{
		if (generatedObjects.Count < numberOfObjectInPool)
		{
			Decal decal = (Decal)Generate(decalPrefab, position + 0.01f * normal, Quaternion.LookRotation(normal));
			return;
		}
		Decal decal2 = (Decal)generatedObjects.First.Value;
		decal2.transform.position = position + 0.01f * normal;
		decal2.transform.rotation = Quaternion.LookRotation(normal);
		decal2.InitDecal();
	}
}
