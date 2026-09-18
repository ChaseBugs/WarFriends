using System;
using Amazon.MobileAnalytics.Model;
using Amazon.MobileAnalytics.Model.Internal.MarshallTransformations;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Auth;

namespace Amazon.MobileAnalytics;

public class AmazonMobileAnalyticsClient : AmazonServiceClient, IAmazonMobileAnalytics, IAmazonService, IDisposable
{
	public AmazonMobileAnalyticsClient(AWSCredentials credentials)
		: this(credentials, new AmazonMobileAnalyticsConfig())
	{
	}

	public AmazonMobileAnalyticsClient(AWSCredentials credentials, RegionEndpoint region)
		: this(credentials, new AmazonMobileAnalyticsConfig
		{
			RegionEndpoint = region
		})
	{
	}

	public AmazonMobileAnalyticsClient(AWSCredentials credentials, AmazonMobileAnalyticsConfig clientConfig)
		: base(credentials, clientConfig)
	{
	}

	public AmazonMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey)
		: this(awsAccessKeyId, awsSecretAccessKey, new AmazonMobileAnalyticsConfig())
	{
	}

	public AmazonMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey, RegionEndpoint region)
		: this(awsAccessKeyId, awsSecretAccessKey, new AmazonMobileAnalyticsConfig
		{
			RegionEndpoint = region
		})
	{
	}

	public AmazonMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey, AmazonMobileAnalyticsConfig clientConfig)
		: base(awsAccessKeyId, awsSecretAccessKey, clientConfig)
	{
	}

	public AmazonMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken)
		: this(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, new AmazonMobileAnalyticsConfig())
	{
	}

	public AmazonMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, RegionEndpoint region)
		: this(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, new AmazonMobileAnalyticsConfig
		{
			RegionEndpoint = region
		})
	{
	}

	public AmazonMobileAnalyticsClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, AmazonMobileAnalyticsConfig clientConfig)
		: base(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, clientConfig)
	{
	}

	protected override AbstractAWSSigner CreateSigner()
	{
		return new AWS4Signer();
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	internal PutEventsResponse PutEvents(PutEventsRequest request)
	{
		PutEventsRequestMarshaller marshaller = new PutEventsRequestMarshaller();
		PutEventsResponseUnmarshaller instance = PutEventsResponseUnmarshaller.Instance;
		return Invoke<PutEventsRequest, PutEventsResponse>(request, marshaller, instance);
	}

	public void PutEventsAsync(PutEventsRequest request, AmazonServiceCallback<PutEventsRequest, PutEventsResponse> callback, AsyncOptions options = null)
	{
		options = ((options == null) ? new AsyncOptions() : options);
		PutEventsRequestMarshaller marshaller = new PutEventsRequestMarshaller();
		PutEventsResponseUnmarshaller instance = PutEventsResponseUnmarshaller.Instance;
		Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
		if (callback != null)
		{
			callbackHelper = delegate(AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao)
			{
				AmazonServiceResult<PutEventsRequest, PutEventsResponse> responseObject = new AmazonServiceResult<PutEventsRequest, PutEventsResponse>((PutEventsRequest)req, (PutEventsResponse)res, ex, ao.State);
				callback(responseObject);
			};
		}
		BeginInvoke(request, marshaller, instance, options, callbackHelper);
	}
}
