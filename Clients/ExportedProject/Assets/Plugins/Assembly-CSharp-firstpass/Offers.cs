using System.Runtime.InteropServices;
using UnityEngine;

public class Offers
{
	public enum OffersCallbackIdentifier
	{
		PAUSEDRAWING,
		RESTARTDRAWING,
		OFFERSRELEASED,
		OFFERSCLOSED
	}

	public enum OffersInterfaceOrientationMask
	{
		OffersInterfaceOrientationMaskPortrait = 2,
		OffersInterfaceOrientationMaskLandscapeLeft = 8,
		OffersInterfaceOrientationMaskLandscapeRight = 16,
		OffersInterfaceOrientationMaskPortraitUpsideDown = 4,
		OffersInterfaceOrientationMaskLandscapeAll = 24,
		OffersInterfaceOrientationMaskPortraitAll = 6,
		OffersInterfaceOrientationMaskAll = 30,
		OffersInterfaceOrientationMaskAllButUpsideDown = 26
	}

	public enum OffersAndroidStoreType
	{
		GOOGLE_PLAY,
		AMAZON,
		SAMSUNG
	}

	public enum OffersCornerToDisplayFrom
	{
		BottomRight,
		BottomLeft,
		TopLeft,
		TopRight
	}

	public enum OffersUIFrameInterval
	{
		VeryLow = 1,
		Low,
		Medium,
		High,
		VeryHigh
	}

	public enum OffersUIUpdateMethod
	{
		DisplayLink,
		Timer
	}
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("offersunity")]
	private static extern void _registerForOffersNotification(OffersCallbackIdentifier identifier, string objectName, string methodName);
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("offersunity")]
	private static extern void _initialiseOffersSession(string theme, OffersInterfaceOrientationMask orientationMask, OffersAndroidStoreType androidStoreType);
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("offersunity")]
	private static extern void _closeOffersSession();
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("offersunity")]
	private static extern void _activateOffersUI(OffersCornerToDisplayFrom corner);
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("offersunity")]
	private static extern bool _deactivateOffersUI();
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("offersunity")]
	private static extern void _setOffersFrameInterval(OffersUIFrameInterval interval);
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("offersunity")]
	private static extern void _setOffersUpdateMethod(OffersUIUpdateMethod method);
#endif

	public static void registerForOffersNotification(OffersCallbackIdentifier notificationId, string objectName, string methodName)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			_registerForOffersNotification(notificationId, objectName, methodName);
#endif
		}
	}

	public static void initialiseOffersSession(string theme, OffersInterfaceOrientationMask orientationMask, OffersAndroidStoreType androidStoreType)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			_initialiseOffersSession(theme, orientationMask, androidStoreType);
#endif
		}
	}

	public static void closeOffersSession()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			_closeOffersSession();
#endif
		}
	}

	public static void activateOffersUI(OffersCornerToDisplayFrom corner)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			_activateOffersUI(corner);
#endif
		}
	}

	public static void deactivateOffersUI()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			_deactivateOffersUI();
#endif
		}
	}

	public static void setOffersFrameInterval(OffersUIFrameInterval interval)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			_setOffersFrameInterval(interval);
#endif
		}
	}

	public static void setOffersUpdateMethod(OffersUIUpdateMethod method)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			_setOffersUpdateMethod(method);
#endif
		}
	}
}
