using System;
using System.Net;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.MobileAnalytics.Model.Internal.MarshallTransformations;

public class PutEventsResponseUnmarshaller : JsonResponseUnmarshaller
{
	private static PutEventsResponseUnmarshaller _instance = new PutEventsResponseUnmarshaller();

	public static PutEventsResponseUnmarshaller Instance => _instance;

	public override AmazonWebServiceResponse Unmarshall(JsonUnmarshallerContext context)
	{
		return new PutEventsResponse();
	}

	public override AmazonServiceException UnmarshallException(JsonUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
	{
		ErrorResponse errorResponse = JsonErrorResponseUnmarshaller.GetInstance().Unmarshall(context);
		if (errorResponse.Code != null && errorResponse.Code.Equals("BadRequestException"))
		{
			return new BadRequestException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
		}
		return new AmazonMobileAnalyticsException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
	}

	internal static PutEventsResponseUnmarshaller GetInstance()
	{
		return _instance;
	}
}
