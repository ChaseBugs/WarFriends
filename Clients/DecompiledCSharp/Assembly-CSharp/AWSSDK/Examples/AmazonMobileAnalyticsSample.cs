using Amazon;
using Amazon.CognitoIdentity;
using Amazon.MobileAnalytics.MobileAnalyticsManager;
using UnityEngine;

namespace AWSSDK.Examples;

public class AmazonMobileAnalyticsSample : MonoBehaviour
{
	public string IdentityPoolId = "YourIdentityPoolId";

	public string appId = "YourAppId";

	public string CognitoIdentityRegion = RegionEndpoint.USEast1.SystemName;

	public string AnalyticsRegion = RegionEndpoint.USEast1.SystemName;

	private MobileAnalyticsManager analyticsManager;

	private CognitoAWSCredentials _credentials;

	private RegionEndpoint _CognitoIdentityRegion => RegionEndpoint.GetBySystemName(CognitoIdentityRegion);

	private RegionEndpoint _AnalyticsRegion => RegionEndpoint.GetBySystemName(AnalyticsRegion);

	private void Start()
	{
		UnityInitializer.AttachToGameObject(base.gameObject);
		_credentials = new CognitoAWSCredentials(IdentityPoolId, _CognitoIdentityRegion);
		analyticsManager = MobileAnalyticsManager.GetOrCreateInstance(appId, _credentials, _AnalyticsRegion);
	}

	private void OnGUI()
	{
		GUILayout.BeginArea(new Rect(0f, 0f, (float)Screen.width * 0.5f, Screen.height));
		GUILayout.Label("Amazon Mobile Analytics Operations");
		if (GUILayout.Button("Record Custom Event", GUILayout.MinHeight((float)Screen.height * 0.2f), GUILayout.Width((float)Screen.width * 0.4f)))
		{
			CustomEvent customEvent = new CustomEvent("level_complete");
			customEvent.AddAttribute("LevelName", "Level1");
			customEvent.AddAttribute("CharacterClass", "Warrior");
			customEvent.AddAttribute("Successful", "True");
			customEvent.AddMetric("Score", 12345.0);
			customEvent.AddMetric("TimeInLevel", 64.0);
			analyticsManager.RecordEvent(customEvent);
		}
		if (GUILayout.Button("Record Monetization Event", GUILayout.MinHeight((float)Screen.height * 0.2f), GUILayout.Width((float)Screen.width * 0.4f)))
		{
			MonetizationEvent monetizationEvent = new MonetizationEvent();
			monetizationEvent.Quantity = 3.0;
			monetizationEvent.ItemPrice = 1.99;
			monetizationEvent.ProductId = "ProductId123";
			monetizationEvent.ItemPriceFormatted = "$1.99";
			monetizationEvent.Store = "Apple";
			monetizationEvent.TransactionId = "TransactionId123";
			monetizationEvent.Currency = "USD";
			analyticsManager.RecordEvent(monetizationEvent);
		}
		GUILayout.EndArea();
	}

	private void OnApplicationFocus(bool focus)
	{
		if (analyticsManager != null)
		{
			if (focus)
			{
				analyticsManager.ResumeSession();
			}
			else
			{
				analyticsManager.PauseSession();
			}
		}
	}
}
