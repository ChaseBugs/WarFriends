using System.Collections.Generic;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager;

public interface IEvent
{
	IDictionary<string, string> AllAttributes { get; }

	IDictionary<string, double> AllMetrics { get; }

	void AddAttribute(string attributeName, string attributeValue);

	bool HasAttribute(string attributeName);

	string GetAttribute(string attributeName);

	void AddMetric(string metricName, double metricValue);

	bool HasMetric(string metricName);

	double? GetMetric(string metricName);

	void AddGlobalAttribute(string attributeName, string attributeValue);

	void AddGlobalAttribute(string eventType, string attributeName, string attributeValue);

	void RemoveGlobalAttribute(string attributeName);

	void RemoveGlobalAttribute(string eventType, string attributeName);

	string GetGlobalAttribute(string attributeName);

	string GetGlobalAttribute(string eventType, string attributeName);

	void AddGlobalMetric(string metricName, double metricValue);

	void AddGlobalMetric(string eventType, string metricName, double metricValue);

	void RemoveGlobalMetric(string metricName);

	void RemoveGlobalMetric(string eventType, string metricName);

	double? GetGlobalMetric(string metricName);

	double? GetGlobalMetric(string eventType, string metricName);
}
