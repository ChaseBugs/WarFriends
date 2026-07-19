using UnityEngine;

public class OSPlatformEnabler : MonoBehaviour
{
	public enum OSType
	{
		Android = 0,
		IOS = 1
	}

	public OSType OsType;

	private void Awake()
	{
		if (OsType != OSType.Android)
		{
			base.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
	}
}
