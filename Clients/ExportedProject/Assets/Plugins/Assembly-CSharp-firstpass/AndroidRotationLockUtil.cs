using UnityEngine;

public class AndroidRotationLockUtil
{
	private static AndroidJavaClass unity;

	public static bool AllowAutorotation()
	{
		bool flag = false;
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unityutils.RotationLockUtil"))
		{
		int num = androidJavaClass.CallStatic<int>("GetAutorotateSetting", new object[1] { GetUnityActivity() });
		return num != 0;
		}
}

	private static AndroidJavaObject GetUnityActivity()
	{
		if (unity == null)
		{
			unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		}
		return unity.GetStatic<AndroidJavaObject>("currentActivity");
	}
}
