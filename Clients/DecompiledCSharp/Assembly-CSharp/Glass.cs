using UnityEngine;

public class Glass : Core_BaseScript
{
	public DestroyableObject destroyableObject;

	public Mesh glassMesh;

	public Mesh brokenGlassMesh;

	protected override void Awake()
	{
		base.Awake();
		destroyableObject.OnDeath += DestroyableObjectOnOnDeath;
	}

	private void DestroyableObjectOnOnDeath(DestroyableObject destroyableObject, DestroyableObject.DamageInfo damageInfo)
	{
		GetComponent<MeshFilter>().mesh = brokenGlassMesh;
		GetComponent<Collider>().enabled = false;
	}

	public void Enable()
	{
		GetComponent<MeshFilter>().mesh = glassMesh;
		GetComponent<Collider>().enabled = true;
	}
}
