using UnityEngine;

public class DeviceDisplay : MonoBehaviour
{
	public static int scaleFactor
	{
		get
		{
			return 1;
		}
	}

	public static int width
	{
		get
		{
			return Screen.width;
		}
	}

	public static int height
	{
		get
		{
			return Screen.height;
		}
	}
}
