public class Decal : GeneratedGameObject
{
	public override void OnInstancied()
	{
		base.OnInstancied();
		InitDecal();
	}

	public void InitDecal()
	{
		StopAllCoroutines();
		InvokeAfter(Destroy, 5f);
	}
}
