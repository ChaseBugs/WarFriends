using UnityEngine;
using WarFriends.Legacy;

public class MainSceneRoot : Singleton<MainSceneRoot>
{
	public Transform mTransform;

	protected override void Awake()
	{
		base.Awake();
		SingletonSupport.DontDestroyOnLoadIfPlaying((Object)this);
		mTransform = base.transform;
	}
}
