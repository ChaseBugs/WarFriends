using System;
using System.Collections.Generic;
using Amazon.MobileAnalytics.MobileAnalyticsManager.Internal;
using Amazon.MobileAnalytics.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager;

public class MobileAnalyticsManager : IDisposable
{
	private static object _lock = new object();

	private static IDictionary<string, MobileAnalyticsManager> _instanceDictionary = new Dictionary<string, MobileAnalyticsManager>();

	private Logger _logger = Logger.GetLogger(typeof(MobileAnalyticsManager));

	private static BackgroundRunner _backgroundRunner = new BackgroundRunner();

	internal Amazon.MobileAnalytics.MobileAnalyticsManager.Internal.Session Session { get; set; }

	internal ClientContext ClientContext { get; set; }

	internal IDeliveryClient BackgroundDeliveryClient { get; private set; }

	internal static IDictionary<string, MobileAnalyticsManager> CopyOfInstanceDictionary
	{
		get
		{
			lock (_lock)
			{
				return new Dictionary<string, MobileAnalyticsManager>(_instanceDictionary);
			}
		}
	}

	public event EventHandler<MobileAnalyticsErrorEventArgs> MobileAnalyticsErrorEvent;

	public static MobileAnalyticsManager GetOrCreateInstance(string appID, AWSCredentials credentials, RegionEndpoint regionEndpoint, MobileAnalyticsManagerConfig maConfig)
	{
		if (string.IsNullOrEmpty(appID))
		{
			throw new ArgumentNullException("appID");
		}
		if (credentials == null)
		{
			throw new ArgumentNullException("credentials");
		}
		if (regionEndpoint == null)
		{
			throw new ArgumentNullException("regionEndpoint");
		}
		if (maConfig == null)
		{
			throw new ArgumentNullException("maConfig");
		}
		return GetOrCreateInstanceHelper(appID, credentials, regionEndpoint, maConfig);
	}

	public static MobileAnalyticsManager GetOrCreateInstance(string appID, AWSCredentials credentials, RegionEndpoint regionEndpoint)
	{
		if (string.IsNullOrEmpty(appID))
		{
			throw new ArgumentNullException("appID");
		}
		if (credentials == null)
		{
			throw new ArgumentNullException("credentials");
		}
		if (regionEndpoint == null)
		{
			throw new ArgumentNullException("regionEndpoint");
		}
		MobileAnalyticsManagerConfig maConfig = new MobileAnalyticsManagerConfig();
		return GetOrCreateInstanceHelper(appID, credentials, regionEndpoint, maConfig);
	}

	public static MobileAnalyticsManager GetInstance(string appID)
	{
		if (string.IsNullOrEmpty(appID))
		{
			throw new ArgumentNullException("appID");
		}
		MobileAnalyticsManager value = null;
		lock (_lock)
		{
			if (_instanceDictionary.TryGetValue(appID, out value))
			{
				return value;
			}
			throw new InvalidOperationException("Cannot find MobileAnalyticsManager instance for appID " + appID + ". Please call GetOrCreateInstance() first.");
		}
	}

	private static MobileAnalyticsManager GetOrCreateInstanceHelper(string appID, AWSCredentials credentials, RegionEndpoint regionEndpoint, MobileAnalyticsManagerConfig maConfig)
	{
		MobileAnalyticsManager value = null;
		bool flag = false;
		lock (_lock)
		{
			if (_instanceDictionary.TryGetValue(appID, out value))
			{
				return value;
			}
			value = new MobileAnalyticsManager(appID, credentials, regionEndpoint, maConfig);
			_instanceDictionary[appID] = value;
			flag = true;
		}
		if (flag)
		{
			value.Session.Start();
		}
		_backgroundRunner.StartWork();
		return value;
	}

	private MobileAnalyticsManager(string appID, AWSCredentials credentials, RegionEndpoint regionEndpoint, MobileAnalyticsManagerConfig maConfig)
	{
		ClientContext = new ClientContext(appID);
		BackgroundDeliveryClient = new DeliveryClient(maConfig, ClientContext, credentials, regionEndpoint, this);
		Session = new Amazon.MobileAnalytics.MobileAnalyticsManager.Internal.Session(appID, maConfig);
	}

	public void PauseSession()
	{
		try
		{
			Session.Pause();
		}
		catch (Exception exception)
		{
			_logger.Error(exception, "An exception occurred when pause session.");
			MobileAnalyticsErrorEventArgs eventArgs = new MobileAnalyticsErrorEventArgs(GetType().Name, "An exception occurred when pausing session.", exception, new List<Event>());
			OnRaiseErrorEvent(eventArgs);
		}
	}

	public void ResumeSession()
	{
		try
		{
			Session.Resume();
		}
		catch (Exception exception)
		{
			_logger.Error(exception, "An exception occurred when resume session.");
			MobileAnalyticsErrorEventArgs eventArgs = new MobileAnalyticsErrorEventArgs(GetType().Name, "An exception occurred when resuming session.", exception, new List<Event>());
			OnRaiseErrorEvent(eventArgs);
		}
	}

	public void RecordEvent(CustomEvent customEvent)
	{
		if (customEvent == null)
		{
			throw new ArgumentNullException("customEvent");
		}
		customEvent.Timestamp = AWSSDKUtils.CorrectedUtcNow;
		Event eventObject = customEvent.ConvertToMobileAnalyticsModelEvent(Session);
		BackgroundDeliveryClient.EnqueueEventsForDelivery(eventObject);
	}

	public void AddCustomAttributeToClientContext(string key, string value)
	{
		if (string.IsNullOrEmpty(key))
		{
			throw new ArgumentNullException("key");
		}
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		ClientContext.AddCustomAttributes(key, value);
	}

	internal void OnRaiseErrorEvent(MobileAnalyticsErrorEventArgs eventArgs)
	{
		AWSSDKUtils.InvokeInBackground(this.MobileAnalyticsErrorEvent, eventArgs, this);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			Session.Dispose();
			BackgroundDeliveryClient.Dispose();
		}
	}
}
