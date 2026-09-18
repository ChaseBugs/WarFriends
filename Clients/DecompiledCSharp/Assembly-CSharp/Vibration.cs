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

	public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

	public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

	public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", new object[1] { "vibrator" });

	public static void Vibrate()
	{
		Handheld.Vibrate();
	}

	public static void Vibrate(long milliseconds)
	{
		vibrator.Call("vibrate", milliseconds);
	}

	public static void iPhoneVibrate(iPhoneVibrateType type)
	{
	}
}
