using System;
using System.Net;
using System.Runtime.Serialization;
using Amazon.Runtime;

namespace Amazon.MobileAnalytics;

[Serializable]
public class AmazonMobileAnalyticsException : AmazonServiceException
{
	public AmazonMobileAnalyticsException(string message)
		: base(message)
	{
	}

	public AmazonMobileAnalyticsException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public AmazonMobileAnalyticsException(Exception innerException)
		: base(innerException.Message, innerException)
	{
	}

	public AmazonMobileAnalyticsException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
		: base(message, errorType, errorCode, requestId, statusCode)
	{
	}

	public AmazonMobileAnalyticsException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
		: base(message, innerException, errorType, errorCode, requestId, statusCode)
	{
	}

	protected AmazonMobileAnalyticsException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
