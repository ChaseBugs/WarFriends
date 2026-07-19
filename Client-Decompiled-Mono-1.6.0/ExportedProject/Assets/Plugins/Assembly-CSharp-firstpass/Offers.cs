using System.Runtime.InteropServices;
using UnityEngine;

public class Offers
{
	public enum OffersCallbackIdentifier
	{
		PAUSEDRAWING = 0,
		RESTARTDRAWING = 1,
		OFFERSRELEASED = 2,
		OFFERSCLOSED = 3
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
		GOOGLE_PLAY = 0,
		AMAZON = 1,
		SAMSUNG = 2
	}

	public enum OffersCornerToDisplayFrom
	{
		BottomRight = 0,
		BottomLeft = 1,
		TopLeft = 2,
		TopRight = 3
	}

	public enum OffersUIFrameInterval
	{
		VeryLow = 1,
		Low = 2,
		Medium = 3,
		High = 4,
		VeryHigh = 5
	}

	public enum OffersUIUpdateMethod
	{
		DisplayLink = 0,
		Timer = 1
	}

	[DllImport("offersunity")]
	private static extern void _registerForOffersNotification(OffersCallbackIdentifier identifier, string objectName, string methodName);

	[DllImport("offersunity")]
	private static extern void _initialiseOffersSession(string theme, OffersInterfaceOrientationMask orientationMask, OffersAndroidStoreType androidStoreType);

	[DllImport("offersunity")]
	private static extern void _closeOffersSession();

	[DllImport("offersunity")]
	private static extern void _activateOffersUI(OffersCornerToDisplayFrom corner);

	[DllImport("offersunity")]
	private static extern bool _deactivateOffersUI();

	[DllImport("offersunity")]
	private static extern void _setOffersFrameInterval(OffersUIFrameInterval interval);

	[DllImport("offersunity")]
	private static extern void _setOffersUpdateMethod(OffersUIUpdateMethod method);

	public static void registerForOffersNotification(OffersCallbackIdentifier notificationId, string objectName, string methodName)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_registerForOffersNotification(notificationId, objectName, methodName);
		}
	}

	public static void initialiseOffersSession(string theme, OffersInterfaceOrientationMask orientationMask, OffersAndroidStoreType androidStoreType)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_initialiseOffersSession(theme, orientationMask, androidStoreType);
		}
	}

	public static void closeOffersSession()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_closeOffersSession();
		}
	}

	public static void activateOffersUI(OffersCornerToDisplayFrom corner)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_activateOffersUI(corner);
		}
	}

	public static void deactivateOffersUI()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_deactivateOffersUI();
		}
	}

	public static void setOffersFrameInterval(OffersUIFrameInterval interval)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_setOffersFrameInterval(interval);
		}
	}

	public static void setOffersUpdateMethod(OffersUIUpdateMethod method)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_setOffersUpdateMethod(method);
		}
	}
}
