using UnityEngine;

public class OSPlatformEnabler : MonoBehaviour
{
	public enum OSType
	{
		Android,
		IOS
	}

	public OSType OsType;

	private void Awake()
	{
		if (OsType != OSType.Android)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
	}
}
