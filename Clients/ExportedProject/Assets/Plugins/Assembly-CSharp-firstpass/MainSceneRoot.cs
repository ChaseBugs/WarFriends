using UnityEngine;

public class MainSceneRoot : Singleton<MainSceneRoot>
{
	public Transform mTransform;

	protected override void Awake()
	{
		base.Awake();
		Object.DontDestroyOnLoad(this);
		mTransform = base.transform;
	}
}
