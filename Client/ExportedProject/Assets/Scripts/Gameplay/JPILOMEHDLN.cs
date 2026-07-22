using UnityEngine;

public static class JPILOMEHDLN
{
	public enum GOEFODHLMBC
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

	public static AndroidJavaClass PFKBDOKBEIK = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

	public static AndroidJavaObject AMPNMGIGBJH = PFKBDOKBEIK.GetStatic<AndroidJavaObject>("currentActivity");

	public static AndroidJavaObject PGEDOPGAPIK = AMPNMGIGBJH.Call<AndroidJavaObject>("getSystemService", new object[1] { "vibrator" });

	public static void JLAAIFMJMEA()
	{
		Handheld.Vibrate();
	}

	public static void JLAAIFMJMEA(long PHAJAKBLGEO)
	{
		PGEDOPGAPIK.Call("vibrate", PHAJAKBLGEO);
	}

	public static void DMHEGPIPEEH(GOEFODHLMBC FJLBLLLEELD)
	{
	}
}
