using UnityEngine;

public static class UIHelper
{
	private static float mIPhoneXSafeArea = 170f;

	private static float mIPhoneXSafeAreaBottom = 42f;

	private static bool? mIsIphone;

	private static bool isIphoneX
	{
		get
		{
			return false;
		}
	}

	public static float safeAreaSize
	{
		get
		{
			return (!isIphoneX) ? 0f : mIPhoneXSafeArea;
		}
	}

	public static float safeAreaSizeBottom
	{
		get
		{
			return (!isIphoneX) ? 0f : mIPhoneXSafeAreaBottom;
		}
	}

	public static int sizeMod
	{
		get
		{
			return isIphoneX ? 150 : 0;
		}
	}

	public static float activeWidthFull
	{
		get
		{
			return UIRoot.list[0].activeWidth;
		}
	}

	public static float activeWidthSafe
	{
		get
		{
			float num = (float)Screen.height / activeHeight;
			return UIRoot.list[0].activeWidth - 2f * safeAreaSize * UIRoot.list[0].pixelSizeAdjustment * num;
		}
	}

	public static float activeHeight
	{
		get
		{
			if (UIRoot.list.Count > 0)
			{
				int num = UIRoot.list[0].activeHeight;
				return num;
			}
			return Screen.height;
		}
	}

	public static float activeHeightSafe
	{
		get
		{
			float num = (float)Screen.height / activeHeight;
			return (float)UIRoot.list[0].activeHeight - safeAreaSizeBottom * UIRoot.list[0].pixelSizeAdjustment * num;
		}
	}

	public static float density
	{
		get
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("android.util.DisplayMetrics");
			androidJavaObject.Call<AndroidJavaObject>("getWindowManager", new object[0]).Call<AndroidJavaObject>("getDefaultDisplay", new object[0]).Call("getMetrics", androidJavaObject2);
			return androidJavaObject2.Get<float>("density");
		}
	}
}
