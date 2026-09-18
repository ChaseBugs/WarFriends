using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using Amazon.MobileAnalytics.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using ThirdParty.Json.LitJson;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager.Internal;

public class DeliveryClient : IDeliveryClient, IDisposable
{
	private Logger _logger = Logger.GetLogger(typeof(DeliveryClient));

	private object _deliveryLock = new object();

	private bool _deliveryInProgress;

	private readonly IDeliveryPolicyFactory _policyFactory;

	private List<IDeliveryPolicy> _deliveryPolicies;

	private IEventStore _eventStore;

	private AmazonMobileAnalyticsClient _mobileAnalyticsLowLevelClient;

	private ClientContext _clientContext;

	private string _appID;

	private MobileAnalyticsManagerConfig _maConfig;

	private MobileAnalyticsManager _maManager;

	private const int MAX_ALLOWED_SELECTS = 200;

	public DeliveryClient(MobileAnalyticsManagerConfig maConfig, ClientContext clientContext, AWSCredentials credentials, RegionEndpoint regionEndPoint, MobileAnalyticsManager maManager)
		: this(new DeliveryPolicyFactory(maConfig.AllowUseDataNetwork), maConfig, clientContext, credentials, regionEndPoint, maManager)
	{
	}

	public void EnqueueEventsForDelivery(Event eventObject)
	{
		ThreadPool.QueueUserWorkItem(delegate
		{
			EnqueueEventsHelper(eventObject);
		});
	}

	public void AttemptDelivery()
	{
		lock (_deliveryLock)
		{
			if (_deliveryInProgress)
			{
				_logger.InfoFormat("Delivery already in progress, failing new delivery");
				return;
			}
			_deliveryInProgress = true;
		}
		foreach (IDeliveryPolicy deliveryPolicy in _deliveryPolicies)
		{
			if (!deliveryPolicy.IsAllowed())
			{
				_logger.InfoFormat("Policy restriction: {0}", deliveryPolicy.GetType().Name);
				lock (_deliveryLock)
				{
					_deliveryInProgress = false;
					return;
				}
			}
		}
		List<JsonData> events = _eventStore.GetEvents(_appID, 200);
		if (events.Count == 0)
		{
			_logger.InfoFormat("No Events to deliver.");
			lock (_deliveryLock)
			{
				_deliveryInProgress = false;
				return;
			}
		}
		List<string> list = new List<string>();
		List<Event> list2 = new List<Event>();
		long num = 0L;
		foreach (JsonData item2 in events)
		{
			string text = (string)item2["event"];
			num += text.Length;
			if (num < _maConfig.MaxRequestSize)
			{
				try
				{
					Event item = JsonMapper.ToObject<Event>(text);
					list2.Add(item);
				}
				catch (JsonException exception)
				{
					_logger.Error(exception, "Could not load event from event store, discarding.");
				}
				list.Add(item2["id"].ToString());
			}
			else
			{
				SubmitEvents(list, list2);
				list = new List<string>();
				list2 = new List<Event>();
				num = 0L;
			}
		}
		if (num > 0)
		{
			SubmitEvents(list, list2);
		}
	}

	private void SubmitEvents(List<string> rowIds, List<Event> eventList)
	{
		PutEventsRequest putEventsRequest = new PutEventsRequest();
		putEventsRequest.Events = eventList;
		putEventsRequest.ClientContext = Convert.ToBase64String(Encoding.UTF8.GetBytes(_clientContext.ToJsonString()));
		putEventsRequest.ClientContextEncoding = "base64";
		_logger.DebugFormat("Client Context is : {0}", _clientContext.ToJsonString());
		PutEventsResponse putEventsResponse = null;
		try
		{
			putEventsResponse = _mobileAnalyticsLowLevelClient.PutEvents(putEventsRequest);
		}
		catch (AmazonMobileAnalyticsException ex)
		{
			_logger.Error(ex, "An AmazonMobileAnalyticsException occurred while sending Amazon Mobile Analytics request: error code is {0} ; error type is {1} ; request id is {2} ; status code is {3} ; error message is {4}", ex.ErrorCode, ex.ErrorType, ex.RequestId, ex.StatusCode, ex.Message);
			if (ex.StatusCode == HttpStatusCode.BadRequest && (ex.ErrorCode.Equals("ValidationException", StringComparison.CurrentCultureIgnoreCase) || ex.ErrorCode.Equals("SerializationException", StringComparison.CurrentCultureIgnoreCase) || ex.ErrorCode.Equals("BadRequestException", StringComparison.CurrentCultureIgnoreCase)))
			{
				MobileAnalyticsErrorEventArgs eventArgs = new MobileAnalyticsErrorEventArgs(GetType().Name, "Amazon Mobile Analytics Service returned an error.", ex, eventList);
				_maManager.OnRaiseErrorEvent(eventArgs);
				_logger.InfoFormat("The error code is not retriable. Delete {0} events from local storage.", rowIds.Count);
				_eventStore.DeleteEvent(rowIds);
			}
			else
			{
				MobileAnalyticsErrorEventArgs eventArgs2 = new MobileAnalyticsErrorEventArgs(GetType().Name, "Amazon Mobile Analytics Service returned an error.", ex, new List<Event>());
				_maManager.OnRaiseErrorEvent(eventArgs2);
			}
		}
		catch (AmazonServiceException ex2)
		{
			_logger.Error(ex2, "An AmazonServiceException occurred while sending Amazon Mobile Analytics request:  error code is {0} ; error type is {1} ; request id is {2} ; status code is {3} ; error message is {4} ", ex2.ErrorCode, ex2.ErrorType, ex2.RequestId, ex2.StatusCode, ex2.Message);
			MobileAnalyticsErrorEventArgs eventArgs3 = new MobileAnalyticsErrorEventArgs(GetType().Name, "Amazon Web Service returned an error.", ex2, new List<Event>());
			_maManager.OnRaiseErrorEvent(eventArgs3);
		}
		catch (Exception exception)
		{
			_logger.Error(exception, "An exception occurred while sending Amazon Mobile Analytics request.");
			MobileAnalyticsErrorEventArgs eventArgs4 = new MobileAnalyticsErrorEventArgs(GetType().Name, "An exception occurred when sending request to Amazon Mobile Analytics.", exception, new List<Event>());
			_maManager.OnRaiseErrorEvent(eventArgs4);
		}
		finally
		{
			if (putEventsResponse != null && putEventsResponse.HttpStatusCode == HttpStatusCode.Accepted)
			{
				_logger.InfoFormat("Mobile Analytics client successfully delivered {0} events to service. Delete those events from local storage.", rowIds.Count);
				_eventStore.DeleteEvent(rowIds);
			}
			lock (_deliveryLock)
			{
				_deliveryInProgress = false;
			}
		}
	}

	private void EnqueueEventsHelper(Event eventObject)
	{
		string text = null;
		try
		{
			text = JsonMapper.ToJson(eventObject);
		}
		catch (Exception exception)
		{
			_logger.Error(exception, "An exception occurred when converting low level client event to json string.");
			List<Event> list = new List<Event>();
			list.Add(eventObject);
			MobileAnalyticsErrorEventArgs eventArgs = new MobileAnalyticsErrorEventArgs(GetType().Name, "An exception occurred when converting low level client event to json string.", exception, list);
			_maManager.OnRaiseErrorEvent(eventArgs);
		}
		if (text != null)
		{
			try
			{
				_eventStore.PutEvent(text, _appID);
			}
			catch (Exception exception2)
			{
				_logger.Error(exception2, "Event {0} was not stored.", eventObject.EventType);
				MobileAnalyticsErrorEventArgs eventArgs2 = new MobileAnalyticsErrorEventArgs(GetType().Name, "An exception occurred when storing event into event store.", exception2, new List<Event>());
				_maManager.OnRaiseErrorEvent(eventArgs2);
			}
			_logger.DebugFormat("Event {0} is queued for delivery", eventObject.EventType);
		}
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
			_eventStore.Dispose();
			_mobileAnalyticsLowLevelClient.Dispose();
		}
	}

	public DeliveryClient(IDeliveryPolicyFactory policyFactory, MobileAnalyticsManagerConfig maConfig, ClientContext clientContext, AWSCredentials credentials, RegionEndpoint regionEndPoint, MobileAnalyticsManager maManager)
	{
		_policyFactory = policyFactory;
		_mobileAnalyticsLowLevelClient = new AmazonMobileAnalyticsClient(credentials, regionEndPoint);
		_clientContext = clientContext;
		_appID = clientContext.AppID;
		_maConfig = maConfig;
		_maManager = maManager;
		_eventStore = new SQLiteEventStore(maConfig);
		_deliveryPolicies = new List<IDeliveryPolicy>();
		_deliveryPolicies.Add(_policyFactory.NewConnectivityPolicy());
	}
}
