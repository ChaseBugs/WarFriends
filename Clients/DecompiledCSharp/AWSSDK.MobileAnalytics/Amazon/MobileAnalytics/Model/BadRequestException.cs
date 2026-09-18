using System;
using System.Net;
using System.Runtime.Serialization;
using Amazon.Runtime;

namespace Amazon.MobileAnalytics.Model;

[Serializable]
public class BadRequestException : AmazonMobileAnalyticsException
{
	public BadRequestException(string message)
		: base(message)
	{
	}

	public BadRequestException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public BadRequestException(Exception innerException)
		: base(innerException)
	{
	}

	public BadRequestException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
		: base(message, innerException, errorType, errorCode, requestId, statusCode)
	{
	}

	public BadRequestException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
		: base(message, errorType, errorCode, requestId, statusCode)
	{
	}

	protected BadRequestException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
