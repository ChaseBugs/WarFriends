using System.Collections.Generic;

namespace Amazon.MobileAnalytics.Model;

public class PutEventsRequest : AmazonMobileAnalyticsRequest
{
	private string _clientContext;

	private string _clientContextEncoding;

	private List<Event> _events = new List<Event>();

	public string ClientContext
	{
		get
		{
			return _clientContext;
		}
		set
		{
			_clientContext = value;
		}
	}

	public string ClientContextEncoding
	{
		get
		{
			return _clientContextEncoding;
		}
		set
		{
			_clientContextEncoding = value;
		}
	}

	public List<Event> Events
	{
		get
		{
			return _events;
		}
		set
		{
			_events = value;
		}
	}

	internal bool IsSetClientContext()
	{
		return _clientContext != null;
	}

	internal bool IsSetClientContextEncoding()
	{
		return _clientContextEncoding != null;
	}

	internal bool IsSetEvents()
	{
		if (_events != null)
		{
			return _events.Count > 0;
		}
		return false;
	}
}
