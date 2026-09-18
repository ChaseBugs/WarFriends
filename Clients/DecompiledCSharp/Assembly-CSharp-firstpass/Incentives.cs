using System.Runtime.InteropServices;
using UnityEngine;

public class Incentives
{
	public enum IncentivesCallbackIdentifier
	{
		INCENTIVE_ACTIVE_DIALOG_PENDING_DISPLAY,
		INCENTIVE_CRITERIAMET_DIALOG_PENDING_DISPLAY,
		INCENTIVE_AWARD_DIALOG_PENDING_DISPLAY,
		INCENTIVE_START_DIALOG_DISPLAYED,
		INCENTIVE_ACTIVE_DIALOG_DISPLAYED,
		INCENTIVE_CRITERIAMET_DIALOG_DISPLAYED,
		INCENTIVE_AWARD_DIALOG_DISPLAYED,
		INCENTIVE_START_DIALOG_WILL_DISMISS,
		INCENTIVE_ACTIVE_DIALOG_WILL_DISMISS,
		INCENTIVE_CRITERIAMET_DIALOG_WILL_DISMISS,
		INCENTIVE_AWARD_DIALOG_WILL_DISMISS,
		INCENTIVE_APPLY_AWARD
	}

	public enum IncentivesInterfaceOrientationMask
	{
		IncentivesInterfaceOrientationMaskPortrait = 2,
		IncentivesInterfaceOrientationMaskLandscapeLeft = 8,
		IncentivesInterfaceOrientationMaskLandscapeRight = 16,
		IncentivesInterfaceOrientationMaskPortraitUpsideDown = 4,
		IncentivesInterfaceOrientationMaskLandscapeAll = 24,
		IncentivesInterfaceOrientationMaskPortraitAll = 6,
		IncentivesInterfaceOrientationMaskAll = 30,
		IncentivesInterfaceOrientationMaskAllButUpsideDown = 26
	}

	[DllImport("offers")]
	private static extern void _registerForIncentivesNotification(IncentivesCallbackIdentifier identifier, string objectName, string methodName);

	[DllImport("offers")]
	private static extern void _initialiseIncentivesSession(IncentivesInterfaceOrientationMask orientationMask);

	[DllImport("offers")]
	private static extern void _closeIncentivesSession();

	[DllImport("offers")]
	private static extern bool _areAnyIncentivesAvailable();

	[DllImport("offers")]
	private static extern void _incentiveCriteriaMet();

	[DllImport("offers")]
	private static extern void _presentIncentiveStartDialog();

	[DllImport("offers")]
	private static extern void _presentIncentiveActiveDialog();

	[DllImport("offers")]
	private static extern void _presentIncentiveCriteriaMetDialog();

	[DllImport("offers")]
	private static extern void _presentIncentiveAwardDialog();

	[DllImport("offers")]
	private static extern void _TEST_presentIncentiveStartDialog();

	[DllImport("offers")]
	private static extern void _TEST_presentIncentiveActiveDialog();

	[DllImport("offers")]
	private static extern void _TEST_presentIncentiveCriteriaMetDialog();

	[DllImport("offers")]
	private static extern void _TEST_presentIncentiveAwardDialog();

	public static void registerForIncentivesNotification(IncentivesCallbackIdentifier notificationId, string objectName, string methodName)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_registerForIncentivesNotification(notificationId, objectName, methodName);
		}
	}

	public static void initialiseIncentivesSession(IncentivesInterfaceOrientationMask orientationMask)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_initialiseIncentivesSession(orientationMask);
		}
	}

	public static void closeIncentivesSession()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_closeIncentivesSession();
		}
	}

	public static bool areAnyIncentivesAvailable()
	{
		bool result = false;
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			result = _areAnyIncentivesAvailable();
		}
		return result;
	}

	public static void incentiveCriteriaMet()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_incentiveCriteriaMet();
		}
	}

	public static void presentIncentiveStartDialog()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_presentIncentiveStartDialog();
		}
	}

	public static void presentIncentiveActiveDialog()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_presentIncentiveActiveDialog();
		}
	}

	public static void presentIncentiveCriteriaMetDialog()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_presentIncentiveCriteriaMetDialog();
		}
	}

	public static void presentIncentiveAwardDialog()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_presentIncentiveAwardDialog();
		}
	}

	public static void TEST_presentIncentiveStartDialog()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_TEST_presentIncentiveStartDialog();
		}
	}

	public static void TEST_presentIncentiveActiveDialog()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_TEST_presentIncentiveActiveDialog();
		}
	}

	public static void TEST_presentIncentiveCriteriaMetDialog()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_TEST_presentIncentiveCriteriaMetDialog();
		}
	}

	public static void TEST_presentIncentiveAwardDialog()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_TEST_presentIncentiveAwardDialog();
		}
	}
}
