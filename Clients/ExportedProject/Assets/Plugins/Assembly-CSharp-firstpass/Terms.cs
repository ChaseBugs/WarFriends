using System.Runtime.InteropServices;
using UnityEngine;

public class Terms
{
	private static string sCriteriaMetObjectName;

	private static string sCriteriaMetMethodName;

	public enum AgeVerificationCallbackIdentifier
	{
		CRITERIA_MET,
		CRITERIA_NOT_MET,
		PENDING_DIALOG_DISPLAY,
		COUNTRY_IS_REAL_NAME_SENSITIVE,
		GAPP_DIALOG_PENDING_DISPLAY
	}

	public enum ComplianceLevel
	{
		FULLY_COMPLIANT,
		AGE_SENSETIVE,
		AGE_GATED,
		FULLY_COMPLIANT_CHILD_SAFE_CONTENT,
		FULLY_COMPLIANT_ADULT_CONTENT
	}
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("termsunity")]
	private static extern void _registerForTermsNotification(AgeVerificationCallbackIdentifier identifier, string objectName, string methodName);
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("termsunity")]
	private static extern void _initialiseTermsSession(bool preCOPPA, bool useCustomSkin, ComplianceLevel complianceLevel, bool isChinaOnly, string resourcePackageName);
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("termsunity")]
	private static extern void _closeTermsSession();
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("termsunity")]
	private static extern void _showTermsUI();
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("termsunity")]
	private static extern void _showGAPPAdvisory();
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("termsunity")]
	private static extern bool _isGAPPAdvisoryRequired();
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("termsunity")]
	private static extern string _termsUrlForEULA();
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("termsunity")]
	private static extern string _termsUrlForTOS();
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("termsunity")]
	private static extern string _termsUrlForPrivacyPolicy();
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("termsunity")]
	private static extern string _termsTextForEULAButton();
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("termsunity")]
	private static extern string _termsTextForTOSButton();
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("termsunity")]
	private static extern string _termsTextForPrivacyPolicyButton();
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

	[DllImport("termsunity")]
	private static extern string _termsTextForRealNameSensitiveDialog();
#endif

	public static void registerForTermsNotification(AgeVerificationCallbackIdentifier notificationId, string objectName, string methodName)
	{
		if (notificationId == AgeVerificationCallbackIdentifier.CRITERIA_MET)
		{
			sCriteriaMetObjectName = objectName;
			sCriteriaMetMethodName = methodName;
		}
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			_registerForTermsNotification(notificationId, objectName, methodName);
#endif
		}
	}

	public static void initialiseTermsSession(bool preCOPPA, bool useCustomSkin, ComplianceLevel complianceLevel)
	{
		initialiseTermsSession(preCOPPA, useCustomSkin, complianceLevel, isChinaOnly: false, null);
	}

	public static void initialiseTermsSession(bool preCOPPA, bool useCustomSkin, ComplianceLevel complianceLevel, bool isChinaOnly)
	{
		initialiseTermsSession(preCOPPA, useCustomSkin, complianceLevel, isChinaOnly, null);
	}

	public static void initialiseTermsSession(bool preCOPPA, bool useCustomSkin, ComplianceLevel complianceLevel, bool isChinaOnly, string resourcePackageName)
	{
		bool nativeSessionStarted = false;
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			_initialiseTermsSession(preCOPPA, useCustomSkin, complianceLevel, isChinaOnly, resourcePackageName);
			nativeSessionStarted = true;
#endif
		}
		if (!nativeSessionStarted && !string.IsNullOrEmpty(sCriteriaMetObjectName))
		{
			GameObject obj = GameObject.Find(sCriteriaMetObjectName);
			if (obj != null)
			{
				obj.SendMessage(sCriteriaMetMethodName, string.Empty, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public static void closeTermsSession()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			_closeTermsSession();
#endif
		}
	}

	public static void showTermsUI()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			_showTermsUI();
#endif
		}
	}

	public static void showGAPPAdvisory()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			_showGAPPAdvisory();
#endif
		}
	}

	public static bool isGAPPAdvisoryRequired()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			return _isGAPPAdvisoryRequired();
#endif
		}
		return false;
	}

	public static string urlForEULA()
	{
		string result = null;
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			result = _termsUrlForEULA();
#endif
		}
		return result;
	}

	public static string urlForTOS()
	{
		string result = null;
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			result = _termsUrlForTOS();
#endif
		}
		return result;
	}

	public static string urlForPrivacyPolicy()
	{
		string result = null;
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			result = _termsUrlForPrivacyPolicy();
#endif
		}
		return result;
	}

	public static string textForEULAButton()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			return _termsTextForEULAButton();
#endif
		}
		return null;
	}

	public static string textForTOSButton()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			return _termsTextForTOSButton();
#endif
		}
		return null;
	}

	public static string textForPrivacyPolicyButton()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			return _termsTextForPrivacyPolicyButton();
#endif
		}
		return null;
	}

	public static string textForRealNameSensitiveDialog()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
			return _termsTextForRealNameSensitiveDialog();
#endif
		}
		return null;
	}
}
