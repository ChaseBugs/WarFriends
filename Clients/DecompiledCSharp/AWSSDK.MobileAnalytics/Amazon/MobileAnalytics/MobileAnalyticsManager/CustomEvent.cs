using System;
using System.Collections.Generic;
using Amazon.MobileAnalytics.MobileAnalyticsManager.Internal;
using Amazon.MobileAnalytics.Model;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager;

public class CustomEvent : IEvent
{
	private static Dictionary<string, Dictionary<string, string>> _eventTypeGlobalAttributes = new Dictionary<string, Dictionary<string, string>>();

	private static Dictionary<string, Dictionary<string, double>> _eventTypeGlobalMetrics = new Dictionary<string, Dictionary<string, double>>();

	private static Dictionary<string, string> _globalAttributes = new Dictionary<string, string>();

	private static Dictionary<string, double> _globalMetrics = new Dictionary<string, double>();

	private Dictionary<string, string> _attributes = new Dictionary<string, string>();

	private Dictionary<string, double> _metrics = new Dictionary<string, double>();

	private static object _globalLock = new object();

	private object _lock = new object();

	private const int MAX_KEY_SIZE = 50;

	private const int MAX_ATTRIB_VALUE_SIZE = 255;

	internal string EventType { get; set; }

	internal string SessionId { get; set; }

	internal long Duration { get; set; }

	internal DateTime StartTimestamp { get; set; }

	internal DateTime? StopTimestamp { get; set; }

	internal DateTime Timestamp { get; set; }

	public IDictionary<string, string> AllAttributes
	{
		get
		{
			lock (_lock)
			{
				return CopyDict(_attributes);
			}
		}
	}

	public IDictionary<string, double> AllMetrics
	{
		get
		{
			lock (_lock)
			{
				return CopyDict(_metrics);
			}
		}
	}

	public CustomEvent(string eventType)
	{
		if (eventType == null)
		{
			throw new ArgumentNullException("eventType");
		}
		EventType = eventType;
	}

	internal virtual Event ConvertToMobileAnalyticsModelEvent(Amazon.MobileAnalytics.MobileAnalyticsManager.Internal.Session session)
	{
		Event obj = new Event();
		StartTimestamp = session.StartTime;
		SessionId = session.SessionId;
		obj.EventType = EventType;
		obj.Session = new Amazon.MobileAnalytics.Model.Session();
		obj.Session.Id = session.SessionId;
		obj.Session.StartTimestamp = session.StartTime;
		if (session.StopTime.HasValue)
		{
			obj.Session.StopTimestamp = session.StopTime.Value;
		}
		if (EventType == "_session.stop")
		{
			obj.Session.StopTimestamp = StopTimestamp.Value;
			obj.Session.Duration = Duration;
		}
		lock (_globalLock)
		{
			AddDict(_globalAttributes, obj.Attributes);
			if (_eventTypeGlobalAttributes.ContainsKey(EventType))
			{
				AddDict(_eventTypeGlobalAttributes[EventType], obj.Attributes);
			}
			AddDict(_globalMetrics, obj.Metrics);
			if (_eventTypeGlobalMetrics.ContainsKey(EventType))
			{
				AddDict(_eventTypeGlobalMetrics[EventType], obj.Metrics);
			}
		}
		lock (_lock)
		{
			AddDict(_attributes, obj.Attributes);
			AddDict(_metrics, obj.Metrics);
		}
		obj.Timestamp = Timestamp;
		obj.Version = "v2.0";
		return obj;
	}

	public void AddAttribute(string attributeName, string attributeValue)
	{
		if (string.IsNullOrEmpty(attributeName))
		{
			throw new ArgumentNullException("attributeName");
		}
		if (attributeValue == null)
		{
			throw new ArgumentNullException("attributeValue");
		}
		if (attributeName.Length > 50)
		{
			throw new ArgumentException("Length of attributeName " + attributeName + " is more than " + 50);
		}
		if (attributeValue.Length > 255)
		{
			throw new ArgumentException("Length of attributeValue is more than " + 255);
		}
		lock (_lock)
		{
			_attributes[attributeName] = attributeValue;
		}
	}

	public bool HasAttribute(string attributeName)
	{
		if (string.IsNullOrEmpty(attributeName))
		{
			throw new ArgumentNullException("attributeName");
		}
		bool flag = false;
		lock (_lock)
		{
			return _attributes.ContainsKey("attributeName");
		}
	}

	public string GetAttribute(string attributeName)
	{
		if (string.IsNullOrEmpty(attributeName))
		{
			throw new ArgumentNullException("attributeName");
		}
		string result = null;
		lock (_lock)
		{
			if (attributeName.Contains(attributeName))
			{
				result = _attributes[attributeName];
			}
		}
		return result;
	}

	public void AddMetric(string metricName, double metricValue)
	{
		if (string.IsNullOrEmpty(metricName))
		{
			throw new ArgumentNullException("metricName");
		}
		if (metricName.Length > 50)
		{
			throw new ArgumentException("length of the metricName " + metricName + " is more than " + 50);
		}
		lock (_lock)
		{
			_metrics[metricName] = metricValue;
		}
	}

	public bool HasMetric(string metricName)
	{
		if (string.IsNullOrEmpty(metricName))
		{
			throw new ArgumentNullException("metricName");
		}
		bool flag = false;
		lock (_lock)
		{
			return _metrics.ContainsKey(metricName);
		}
	}

	public double? GetMetric(string metricName)
	{
		if (string.IsNullOrEmpty(metricName))
		{
			throw new ArgumentNullException("metricName");
		}
		double? result = null;
		lock (_lock)
		{
			if (_metrics.ContainsKey(metricName))
			{
				result = _metrics[metricName];
				return result;
			}
		}
		return result;
	}

	public void AddGlobalAttribute(string attributeName, string attributeValue)
	{
		if (string.IsNullOrEmpty(attributeName))
		{
			throw new ArgumentNullException("attributeName");
		}
		if (attributeValue == null)
		{
			throw new ArgumentNullException("attributeValue");
		}
		if (attributeName.Length > 50)
		{
			throw new ArgumentException("Length of attributeName " + attributeName + " is more than " + 50);
		}
		if (attributeValue.Length > 255)
		{
			throw new ArgumentException("Length of attributeValue is more than " + 255);
		}
		lock (_globalLock)
		{
			_globalAttributes[attributeName] = attributeValue;
		}
	}

	public void AddGlobalAttribute(string eventType, string attributeName, string attributeValue)
	{
		if (string.IsNullOrEmpty(eventType))
		{
			throw new ArgumentNullException("eventType");
		}
		if (string.IsNullOrEmpty(attributeName))
		{
			throw new ArgumentNullException("attributeName");
		}
		if (attributeValue == null)
		{
			throw new ArgumentNullException("attributeValue");
		}
		if (attributeName.Length > 50)
		{
			throw new ArgumentException("Length of attributeName " + attributeName + " is more than " + 50);
		}
		if (attributeValue.Length > 255)
		{
			throw new ArgumentException("Length of attributeValue is more than " + 255);
		}
		lock (_globalLock)
		{
			if (!_eventTypeGlobalAttributes.ContainsKey(eventType))
			{
				_eventTypeGlobalAttributes.Add(eventType, new Dictionary<string, string>());
				_eventTypeGlobalAttributes[eventType].Add(attributeName, attributeValue);
			}
			else if (_eventTypeGlobalAttributes.ContainsKey(eventType) && !_eventTypeGlobalAttributes[eventType].ContainsKey(attributeName))
			{
				_eventTypeGlobalAttributes[eventType].Add(attributeName, attributeValue);
			}
		}
	}

	public void RemoveGlobalAttribute(string attributeName)
	{
		if (string.IsNullOrEmpty(attributeName))
		{
			throw new ArgumentNullException("attributeName");
		}
		lock (_globalLock)
		{
			if (_globalAttributes.ContainsKey(attributeName))
			{
				_globalAttributes.Remove(attributeName);
			}
		}
	}

	public void RemoveGlobalAttribute(string eventType, string attributeName)
	{
		if (string.IsNullOrEmpty(eventType))
		{
			throw new ArgumentNullException("eventType");
		}
		if (string.IsNullOrEmpty(attributeName))
		{
			throw new ArgumentNullException("attributeName");
		}
		lock (_globalLock)
		{
			if (_eventTypeGlobalAttributes.ContainsKey(eventType) && _eventTypeGlobalAttributes[eventType].ContainsKey(attributeName))
			{
				_eventTypeGlobalAttributes[eventType].Remove(attributeName);
			}
		}
	}

	public string GetGlobalAttribute(string attributeName)
	{
		if (string.IsNullOrEmpty(attributeName))
		{
			throw new ArgumentNullException("attributeName");
		}
		string result = null;
		lock (_globalLock)
		{
			if (_globalAttributes.ContainsKey(attributeName))
			{
				result = _globalAttributes[attributeName];
			}
		}
		return result;
	}

	public string GetGlobalAttribute(string eventType, string attributeName)
	{
		if (string.IsNullOrEmpty(eventType))
		{
			throw new ArgumentNullException(eventType);
		}
		if (string.IsNullOrEmpty(attributeName))
		{
			throw new ArgumentNullException(attributeName);
		}
		string result = null;
		lock (_globalLock)
		{
			if (_eventTypeGlobalAttributes.ContainsKey(eventType) && _eventTypeGlobalAttributes[eventType].ContainsKey(attributeName))
			{
				result = _eventTypeGlobalAttributes[eventType][attributeName];
			}
		}
		return result;
	}

	public void AddGlobalMetric(string metricName, double metricValue)
	{
		if (string.IsNullOrEmpty(metricName))
		{
			throw new ArgumentNullException("metricName");
		}
		if (metricName.Length > 50)
		{
			throw new ArgumentException("Length of the metricName " + metricName + " is more than " + 50);
		}
		lock (_globalLock)
		{
			_globalMetrics[metricName] = metricValue;
		}
	}

	public void AddGlobalMetric(string eventType, string metricName, double metricValue)
	{
		if (string.IsNullOrEmpty(eventType))
		{
			throw new ArgumentNullException("eventType");
		}
		if (string.IsNullOrEmpty(metricName))
		{
			throw new ArgumentNullException("metricName");
		}
		if (metricName.Length > 50)
		{
			throw new ArgumentException("Length of the metricName " + metricName + " is more than " + 50);
		}
		lock (_globalLock)
		{
			if (!_eventTypeGlobalMetrics.ContainsKey(eventType))
			{
				_eventTypeGlobalMetrics.Add(eventType, new Dictionary<string, double>());
				_eventTypeGlobalMetrics[eventType][metricName] = metricValue;
			}
			else if (_eventTypeGlobalMetrics.ContainsKey(eventType))
			{
				_eventTypeGlobalMetrics[eventType][metricName] = metricValue;
			}
		}
	}

	public void RemoveGlobalMetric(string metricName)
	{
		if (string.IsNullOrEmpty(metricName))
		{
			throw new ArgumentNullException("metricName");
		}
		lock (_globalLock)
		{
			if (_globalMetrics.ContainsKey(metricName))
			{
				_globalMetrics.Remove(metricName);
			}
		}
	}

	public void RemoveGlobalMetric(string eventType, string metricName)
	{
		if (string.IsNullOrEmpty(eventType))
		{
			throw new ArgumentNullException("eventType");
		}
		if (string.IsNullOrEmpty(metricName))
		{
			throw new ArgumentNullException("metricName");
		}
		lock (_globalLock)
		{
			if (_eventTypeGlobalMetrics.ContainsKey(eventType) && _eventTypeGlobalMetrics[eventType].ContainsKey(metricName))
			{
				_eventTypeGlobalMetrics[eventType].Remove(metricName);
			}
		}
	}

	public double? GetGlobalMetric(string metricName)
	{
		if (string.IsNullOrEmpty(metricName))
		{
			throw new ArgumentNullException("metricName");
		}
		double? result = null;
		lock (_globalLock)
		{
			if (_globalMetrics.ContainsKey(metricName))
			{
				result = _globalMetrics[metricName];
				return result;
			}
		}
		return result;
	}

	public double? GetGlobalMetric(string eventType, string metricName)
	{
		if (string.IsNullOrEmpty(eventType))
		{
			throw new ArgumentNullException(eventType);
		}
		if (string.IsNullOrEmpty(metricName))
		{
			throw new ArgumentNullException(metricName);
		}
		double? result = null;
		lock (_globalLock)
		{
			if (_eventTypeGlobalMetrics.ContainsKey(eventType) && _eventTypeGlobalMetrics[eventType].ContainsKey(metricName))
			{
				result = _eventTypeGlobalMetrics[eventType][metricName];
				return result;
			}
		}
		return result;
	}

	private static void AddDict<T, S>(Dictionary<T, S> srcDict, Dictionary<T, S> dstDict)
	{
		if (srcDict == null)
		{
			throw new ArgumentNullException("srcDict");
		}
		if (dstDict == null)
		{
			throw new ArgumentNullException("dstDict");
		}
		foreach (KeyValuePair<T, S> item in srcDict)
		{
			dstDict[item.Key] = item.Value;
		}
	}

	private static Dictionary<T, S> CopyDict<T, S>(Dictionary<T, S> srcDict)
	{
		if (srcDict == null)
		{
			throw new ArgumentNullException("srcDict");
		}
		Dictionary<T, S> dictionary = new Dictionary<T, S>();
		foreach (KeyValuePair<T, S> item in srcDict)
		{
			dictionary.Add(item.Key, item.Value);
		}
		return dictionary;
	}
}
