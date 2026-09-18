using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using Amazon.MobileAnalytics.Model.Internal.MarshallTransformations;
using Amazon.Runtime.Internal.Transform;
using ThirdParty.Json.LitJson;

namespace Amazon.MobileAnalytics.Model;

public class Event
{
	private class DummyResponse : IWebResponseData
	{
		long IWebResponseData.ContentLength => 0L;

		string IWebResponseData.ContentType => "";

		HttpStatusCode IWebResponseData.StatusCode => HttpStatusCode.OK;

		bool IWebResponseData.IsSuccessStatusCode => false;

		IHttpResponseBody IWebResponseData.ResponseBody => null;

		bool IWebResponseData.IsHeaderPresent(string headerName)
		{
			return false;
		}

		string IWebResponseData.GetHeaderValue(string headerName)
		{
			return null;
		}

		string[] IWebResponseData.GetHeaderNames()
		{
			return new string[0];
		}
	}

	private Dictionary<string, string> _attributes = new Dictionary<string, string>();

	private string _eventType;

	private Dictionary<string, double> _metrics = new Dictionary<string, double>();

	private Session _session;

	private DateTime? _timestamp;

	private string _version;

	public Dictionary<string, string> Attributes
	{
		get
		{
			return _attributes;
		}
		set
		{
			_attributes = value;
		}
	}

	public string EventType
	{
		get
		{
			return _eventType;
		}
		set
		{
			_eventType = value;
		}
	}

	public Dictionary<string, double> Metrics
	{
		get
		{
			return _metrics;
		}
		set
		{
			_metrics = value;
		}
	}

	public Session Session
	{
		get
		{
			return _session;
		}
		set
		{
			_session = value;
		}
	}

	public DateTime Timestamp
	{
		get
		{
			return _timestamp.GetValueOrDefault();
		}
		set
		{
			_timestamp = value;
		}
	}

	public string Version
	{
		get
		{
			return _version;
		}
		set
		{
			_version = value;
		}
	}

	public string MarshallToJson()
	{
		using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		JsonWriter jsonWriter = new JsonWriter(stringWriter);
		jsonWriter.WriteObjectStart();
		EventMarshaller.Instance.Marshall(this, new JsonMarshallerContext(null, jsonWriter));
		jsonWriter.WriteObjectEnd();
		return stringWriter.ToString();
	}

	public static Event UnmarshallFromJson(string eventValue)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using StreamWriter streamWriter = new StreamWriter(memoryStream);
		streamWriter.Write(eventValue);
		streamWriter.Flush();
		memoryStream.Position = 0L;
		return EventUnmarshaller.Instance.Unmarshall(new JsonUnmarshallerContext(memoryStream, maintainResponseBody: false, new DummyResponse()));
	}

	internal bool IsSetAttributes()
	{
		if (_attributes != null)
		{
			return _attributes.Count > 0;
		}
		return false;
	}

	internal bool IsSetEventType()
	{
		return _eventType != null;
	}

	internal bool IsSetMetrics()
	{
		if (_metrics != null)
		{
			return _metrics.Count > 0;
		}
		return false;
	}

	internal bool IsSetSession()
	{
		return _session != null;
	}

	internal bool IsSetTimestamp()
	{
		return _timestamp.HasValue;
	}

	internal bool IsSetVersion()
	{
		return _version != null;
	}
}
