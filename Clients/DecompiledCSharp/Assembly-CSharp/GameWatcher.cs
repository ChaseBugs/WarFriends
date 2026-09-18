using UnityEngine;

public class GameWatcher : MonoBehaviour
{
	private void Awake()
	{
		Object.DontDestroyOnLoad(this);
	}

	public void OnApplicationFocus()
	{
		bool autorotateToLandscapeRight = (Screen.autorotateToLandscapeLeft = AndroidRotationLockUtil.AllowAutorotation());
		Screen.autorotateToLandscapeRight = autorotateToLandscapeRight;
	}
}
