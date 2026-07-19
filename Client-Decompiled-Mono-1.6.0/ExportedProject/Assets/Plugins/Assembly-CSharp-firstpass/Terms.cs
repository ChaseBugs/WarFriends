using System.Runtime.InteropServices;
using UnityEngine;

public class Terms
{
	public enum AgeVerificationCallbackIdentifier
	{
		CRITERIA_MET = 0,
		CRITERIA_NOT_MET = 1,
		PENDING_DIALOG_DISPLAY = 2,
		COUNTRY_IS_REAL_NAME_SENSITIVE = 3,
		GAPP_DIALOG_PENDING_DISPLAY = 4
	}

	public enum ComplianceLevel
	{
		FULLY_COMPLIANT = 0,
		AGE_SENSETIVE = 1,
		AGE_GATED = 2,
		FULLY_COMPLIANT_CHILD_SAFE_CONTENT = 3,
		FULLY_COMPLIANT_ADULT_CONTENT = 4
	}

	[DllImport("termsunity")]
	private static extern void _registerForTermsNotification(AgeVerificationCallbackIdentifier identifier, string objectName, string methodName);

	[DllImport("termsunity")]
	private static extern void _initialiseTermsSession(bool preCOPPA, bool useCustomSkin, ComplianceLevel complianceLevel, bool isChinaOnly, string resourcePackageName);

	[DllImport("termsunity")]
	private static extern void _closeTermsSession();

	[DllImport("termsunity")]
	private static extern void _showTermsUI();

	[DllImport("termsunity")]
	private static extern void _showGAPPAdvisory();

	[DllImport("termsunity")]
	private static extern bool _isGAPPAdvisoryRequired();

	[DllImport("termsunity")]
	private static extern string _termsUrlForUserAgreement();

	[DllImport("termsunity")]
	private static extern string _termsUrlForPrivacyPolicy();

	[DllImport("termsunity")]
	private static extern string _termsTextForUserAgreementButton();

	[DllImport("termsunity")]
	private static extern string _termsTextForPrivacyPolicyButton();

	[DllImport("termsunity")]
	private static extern string _termsTextForRealNameSensitiveDialog();

	public static void registerForTermsNotification(AgeVerificationCallbackIdentifier notificationId, string objectName, string methodName)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_registerForTermsNotification(notificationId, objectName, methodName);
		}
	}

	public static void initialiseTermsSession(bool preCOPPA, bool useCustomSkin, ComplianceLevel complianceLevel)
	{
		initialiseTermsSession(preCOPPA, useCustomSkin, complianceLevel, false, null);
	}

	public static void initialiseTermsSession(bool preCOPPA, bool useCustomSkin, ComplianceLevel complianceLevel, bool isChinaOnly)
	{
		initialiseTermsSession(preCOPPA, useCustomSkin, complianceLevel, isChinaOnly, null);
	}

	public static void initialiseTermsSession(bool preCOPPA, bool useCustomSkin, ComplianceLevel complianceLevel, bool isChinaOnly, string resourcePackageName)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_initialiseTermsSession(preCOPPA, useCustomSkin, complianceLevel, isChinaOnly, resourcePackageName);
		}
	}

	public static void closeTermsSession()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_closeTermsSession();
		}
	}

	public static void showTermsUI()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_showTermsUI();
		}
	}

	public static void showGAPPAdvisory()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			_showGAPPAdvisory();
		}
	}

	public static bool isGAPPAdvisoryRequired()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			return _isGAPPAdvisoryRequired();
		}
		return false;
	}

	public static string urlForUserAgreement()
	{
		string result = null;
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			result = _termsUrlForUserAgreement();
		}
		return result;
	}

	public static string urlForPrivacyPolicy()
	{
		string result = null;
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			result = _termsUrlForPrivacyPolicy();
		}
		return result;
	}

	public static string textForUserAgreementButton()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			return _termsTextForUserAgreementButton();
		}
		return null;
	}

	public static string textForPrivacyPolicyButton()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			return _termsTextForPrivacyPolicyButton();
		}
		return null;
	}

	public static string textForRealNameSensitiveDialog()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
		{
			return _termsTextForRealNameSensitiveDialog();
		}
		return null;
	}
}
