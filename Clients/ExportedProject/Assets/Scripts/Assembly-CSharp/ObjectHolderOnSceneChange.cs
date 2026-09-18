using UnityEngine;

public class ObjectHolderOnSceneChange : MonoBehaviour
{
	public static ObjectHolderOnSceneChange instance;

	public FuseboxxService fuseboxxService { get; private set; }

	private void Awake()
	{
		if (instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
		fuseboxxService = new FuseboxxService(GetComponentInChildren<FuseSDK>());
	}

	public void OnDestroy()
	{
		instance = null;
	}
}
