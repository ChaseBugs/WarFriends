using UnityEngine;

public static class Vibration
{
	public enum iPhoneVibrateType
	{
		VibrateLight,
		VibrateMedium,
		VibrateHeavy,
		PrepareLight,
		PrepareMedium,
		PrepareHeavy,
		VibrateSuccess,
		VibrateError
	}

#if UNITY_ANDROID && !UNITY_EDITOR
	public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

	public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

	public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", new object[1] { "vibrator" });
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

	public static void Vibrate()
	{
		Handheld.Vibrate();
	}

	public static void Vibrate(long milliseconds)
	{
        if (vibrator != null) vibrator.Call("vibrate", milliseconds);
	}

	public static void iPhoneVibrate(iPhoneVibrateType type)
	{
	}
}
