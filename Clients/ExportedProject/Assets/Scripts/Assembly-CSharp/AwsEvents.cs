using System.Collections;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.MobileAnalytics.MobileAnalyticsManager;
using UnityEngine;

public class AwsEvents
{
	private MobileAnalyticsManager analyticsManager;

	public AwsEvents(GameObject parenGameobject)
	{
		UnityInitializer.AttachToGameObject(parenGameobject);
		CognitoAWSCredentials credentials = new CognitoAWSCredentials("us-east-1:a951d2ae-0491-424d-8240-ae25baedf92a", RegionEndpoint.USEast1);
		analyticsManager = MobileAnalyticsManager.GetOrCreateInstance("81cb29735bbd4830b860f8d13ebeb48b", credentials, RegionEndpoint.USEast1);
	}

	public void RegisterEvent(string eventName, string parameterName, string parameterValue, Hashtable table)
	{
		CustomEvent customEvent = new CustomEvent(eventName);
		if (double.TryParse(parameterValue, out var result))
		{
			customEvent.AddMetric(parameterName, result);
		}
		else
		{
			customEvent.AddAttribute(parameterName, parameterValue);
		}
		if (table != null)
		{
			foreach (DictionaryEntry item in table)
			{
				if (item.Value is int)
				{
					customEvent.AddMetric(item.Key.ToString(), (int)item.Value);
				}
				else if (item.Value is long)
				{
					customEvent.AddMetric(item.Key.ToString(), (long)item.Value);
				}
				else if (item.Value is float)
				{
					customEvent.AddMetric(item.Key.ToString(), (float)item.Value);
				}
				else if (item.Value is double)
				{
					customEvent.AddMetric(item.Key.ToString(), (double)item.Value);
				}
				else
				{
					customEvent.AddAttribute(item.Key.ToString(), item.Value.ToString());
				}
			}
		}
		customEvent.AddAttribute("Player_id", GameLoginManager.instance.playerId);
		customEvent.AddAttribute("DB_enviroment", Singleton<BeanstalkServerManager>.instance.environmentName);
		analyticsManager.RecordEvent(customEvent);
	}

	public void RegisterInApp(string produktId, double price, string formatedPrice, string transactionId, string currencyCode)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 1.0;
		monetizationEvent.ItemPrice = price;
		monetizationEvent.ProductId = produktId;
		monetizationEvent.ItemPriceFormatted = formatedPrice;
		monetizationEvent.Store = "Google";
		monetizationEvent.TransactionId = transactionId;
		monetizationEvent.Currency = currencyCode;
		analyticsManager.RecordEvent(monetizationEvent);
	}

	public void ChangeFocuse(bool focuse)
	{
		if (focuse)
		{
			analyticsManager.ResumeSession();
		}
		else
		{
			analyticsManager.PauseSession();
		}
	}
}
