using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces;
using Amazon.SecurityToken.Model;
using Amazon.SecurityToken.Model.Internal.MarshallTransformations;

namespace Amazon.SecurityToken;

public class AmazonSecurityTokenServiceClient : AmazonServiceClient, IAmazonSecurityTokenService, IDisposable, ICoreAmazonSTS, IAmazonService
{
	AssumeRoleImmutableCredentials ICoreAmazonSTS.CredentialsFromAssumeRoleAuthentication(string roleArn, string roleSessionName, AssumeRoleAWSCredentialsOptions options)
	{
		try
		{
			AssumeRoleRequest assumeRoleRequest = new AssumeRoleRequest
			{
				RoleArn = roleArn,
				RoleSessionName = roleSessionName
			};
			if (options != null)
			{
				assumeRoleRequest.ExternalId = options.ExternalId;
				assumeRoleRequest.SerialNumber = options.MfaSerialNumber;
				assumeRoleRequest.TokenCode = options.MfaTokenCode;
				assumeRoleRequest.Policy = options.Policy;
				if (options.DurationSeconds.HasValue)
				{
					assumeRoleRequest.DurationSeconds = options.DurationSeconds.Value;
				}
			}
			AssumeRoleResponse assumeRoleResponse = AssumeRole(assumeRoleRequest);
			return new AssumeRoleImmutableCredentials(assumeRoleResponse.Credentials.AccessKeyId, assumeRoleResponse.Credentials.SecretAccessKey, assumeRoleResponse.Credentials.SessionToken, assumeRoleResponse.Credentials.Expiration);
		}
		catch (Exception innerException)
		{
			AmazonClientException ex = new AmazonClientException("Error calling AssumeRole for role " + roleArn, innerException);
			Logger.GetLogger(typeof(AmazonSecurityTokenServiceClient)).Error(ex, ex.Message);
			throw ex;
		}
	}

	public AmazonSecurityTokenServiceClient(AWSCredentials credentials)
		: this(credentials, new AmazonSecurityTokenServiceConfig())
	{
	}

	public AmazonSecurityTokenServiceClient(AWSCredentials credentials, RegionEndpoint region)
		: this(credentials, new AmazonSecurityTokenServiceConfig
		{
			RegionEndpoint = region
		})
	{
	}

	public AmazonSecurityTokenServiceClient(AWSCredentials credentials, AmazonSecurityTokenServiceConfig clientConfig)
		: base(credentials, clientConfig)
	{
	}

	public AmazonSecurityTokenServiceClient(string awsAccessKeyId, string awsSecretAccessKey)
		: this(awsAccessKeyId, awsSecretAccessKey, new AmazonSecurityTokenServiceConfig())
	{
	}

	public AmazonSecurityTokenServiceClient(string awsAccessKeyId, string awsSecretAccessKey, RegionEndpoint region)
		: this(awsAccessKeyId, awsSecretAccessKey, new AmazonSecurityTokenServiceConfig
		{
			RegionEndpoint = region
		})
	{
	}

	public AmazonSecurityTokenServiceClient(string awsAccessKeyId, string awsSecretAccessKey, AmazonSecurityTokenServiceConfig clientConfig)
		: base(awsAccessKeyId, awsSecretAccessKey, clientConfig)
	{
	}

	public AmazonSecurityTokenServiceClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken)
		: this(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, new AmazonSecurityTokenServiceConfig())
	{
	}

	public AmazonSecurityTokenServiceClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, RegionEndpoint region)
		: this(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, new AmazonSecurityTokenServiceConfig
		{
			RegionEndpoint = region
		})
	{
	}

	public AmazonSecurityTokenServiceClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, AmazonSecurityTokenServiceConfig clientConfig)
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

	internal AssumeRoleResponse AssumeRole(AssumeRoleRequest request)
	{
		AssumeRoleRequestMarshaller marshaller = new AssumeRoleRequestMarshaller();
		AssumeRoleResponseUnmarshaller instance = AssumeRoleResponseUnmarshaller.Instance;
		return Invoke<AssumeRoleRequest, AssumeRoleResponse>(request, marshaller, instance);
	}

	public void AssumeRoleAsync(AssumeRoleRequest request, AmazonServiceCallback<AssumeRoleRequest, AssumeRoleResponse> callback, AsyncOptions options = null)
	{
		options = ((options == null) ? new AsyncOptions() : options);
		AssumeRoleRequestMarshaller marshaller = new AssumeRoleRequestMarshaller();
		AssumeRoleResponseUnmarshaller instance = AssumeRoleResponseUnmarshaller.Instance;
		Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
		if (callback != null)
		{
			callbackHelper = delegate(AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao)
			{
				AmazonServiceResult<AssumeRoleRequest, AssumeRoleResponse> responseObject = new AmazonServiceResult<AssumeRoleRequest, AssumeRoleResponse>((AssumeRoleRequest)req, (AssumeRoleResponse)res, ex, ao.State);
				callback(responseObject);
			};
		}
		BeginInvoke(request, marshaller, instance, options, callbackHelper);
	}

	internal AssumeRoleWithSAMLResponse AssumeRoleWithSAML(AssumeRoleWithSAMLRequest request)
	{
		AssumeRoleWithSAMLRequestMarshaller marshaller = new AssumeRoleWithSAMLRequestMarshaller();
		AssumeRoleWithSAMLResponseUnmarshaller instance = AssumeRoleWithSAMLResponseUnmarshaller.Instance;
		return Invoke<AssumeRoleWithSAMLRequest, AssumeRoleWithSAMLResponse>(request, marshaller, instance);
	}

	public void AssumeRoleWithSAMLAsync(AssumeRoleWithSAMLRequest request, AmazonServiceCallback<AssumeRoleWithSAMLRequest, AssumeRoleWithSAMLResponse> callback, AsyncOptions options = null)
	{
		options = ((options == null) ? new AsyncOptions() : options);
		AssumeRoleWithSAMLRequestMarshaller marshaller = new AssumeRoleWithSAMLRequestMarshaller();
		AssumeRoleWithSAMLResponseUnmarshaller instance = AssumeRoleWithSAMLResponseUnmarshaller.Instance;
		Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
		if (callback != null)
		{
			callbackHelper = delegate(AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao)
			{
				AmazonServiceResult<AssumeRoleWithSAMLRequest, AssumeRoleWithSAMLResponse> responseObject = new AmazonServiceResult<AssumeRoleWithSAMLRequest, AssumeRoleWithSAMLResponse>((AssumeRoleWithSAMLRequest)req, (AssumeRoleWithSAMLResponse)res, ex, ao.State);
				callback(responseObject);
			};
		}
		BeginInvoke(request, marshaller, instance, options, callbackHelper);
	}

	internal AssumeRoleWithWebIdentityResponse AssumeRoleWithWebIdentity(AssumeRoleWithWebIdentityRequest request)
	{
		AssumeRoleWithWebIdentityRequestMarshaller marshaller = new AssumeRoleWithWebIdentityRequestMarshaller();
		AssumeRoleWithWebIdentityResponseUnmarshaller instance = AssumeRoleWithWebIdentityResponseUnmarshaller.Instance;
		return Invoke<AssumeRoleWithWebIdentityRequest, AssumeRoleWithWebIdentityResponse>(request, marshaller, instance);
	}

	public void AssumeRoleWithWebIdentityAsync(AssumeRoleWithWebIdentityRequest request, AmazonServiceCallback<AssumeRoleWithWebIdentityRequest, AssumeRoleWithWebIdentityResponse> callback, AsyncOptions options = null)
	{
		options = ((options == null) ? new AsyncOptions() : options);
		AssumeRoleWithWebIdentityRequestMarshaller marshaller = new AssumeRoleWithWebIdentityRequestMarshaller();
		AssumeRoleWithWebIdentityResponseUnmarshaller instance = AssumeRoleWithWebIdentityResponseUnmarshaller.Instance;
		Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
		if (callback != null)
		{
			callbackHelper = delegate(AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao)
			{
				AmazonServiceResult<AssumeRoleWithWebIdentityRequest, AssumeRoleWithWebIdentityResponse> responseObject = new AmazonServiceResult<AssumeRoleWithWebIdentityRequest, AssumeRoleWithWebIdentityResponse>((AssumeRoleWithWebIdentityRequest)req, (AssumeRoleWithWebIdentityResponse)res, ex, ao.State);
				callback(responseObject);
			};
		}
		BeginInvoke(request, marshaller, instance, options, callbackHelper);
	}

	internal DecodeAuthorizationMessageResponse DecodeAuthorizationMessage(DecodeAuthorizationMessageRequest request)
	{
		DecodeAuthorizationMessageRequestMarshaller marshaller = new DecodeAuthorizationMessageRequestMarshaller();
		DecodeAuthorizationMessageResponseUnmarshaller instance = DecodeAuthorizationMessageResponseUnmarshaller.Instance;
		return Invoke<DecodeAuthorizationMessageRequest, DecodeAuthorizationMessageResponse>(request, marshaller, instance);
	}

	public void DecodeAuthorizationMessageAsync(DecodeAuthorizationMessageRequest request, AmazonServiceCallback<DecodeAuthorizationMessageRequest, DecodeAuthorizationMessageResponse> callback, AsyncOptions options = null)
	{
		options = ((options == null) ? new AsyncOptions() : options);
		DecodeAuthorizationMessageRequestMarshaller marshaller = new DecodeAuthorizationMessageRequestMarshaller();
		DecodeAuthorizationMessageResponseUnmarshaller instance = DecodeAuthorizationMessageResponseUnmarshaller.Instance;
		Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
		if (callback != null)
		{
			callbackHelper = delegate(AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao)
			{
				AmazonServiceResult<DecodeAuthorizationMessageRequest, DecodeAuthorizationMessageResponse> responseObject = new AmazonServiceResult<DecodeAuthorizationMessageRequest, DecodeAuthorizationMessageResponse>((DecodeAuthorizationMessageRequest)req, (DecodeAuthorizationMessageResponse)res, ex, ao.State);
				callback(responseObject);
			};
		}
		BeginInvoke(request, marshaller, instance, options, callbackHelper);
	}

	internal GetCallerIdentityResponse GetCallerIdentity(GetCallerIdentityRequest request)
	{
		GetCallerIdentityRequestMarshaller marshaller = new GetCallerIdentityRequestMarshaller();
		GetCallerIdentityResponseUnmarshaller instance = GetCallerIdentityResponseUnmarshaller.Instance;
		return Invoke<GetCallerIdentityRequest, GetCallerIdentityResponse>(request, marshaller, instance);
	}

	public void GetCallerIdentityAsync(GetCallerIdentityRequest request, AmazonServiceCallback<GetCallerIdentityRequest, GetCallerIdentityResponse> callback, AsyncOptions options = null)
	{
		options = ((options == null) ? new AsyncOptions() : options);
		GetCallerIdentityRequestMarshaller marshaller = new GetCallerIdentityRequestMarshaller();
		GetCallerIdentityResponseUnmarshaller instance = GetCallerIdentityResponseUnmarshaller.Instance;
		Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
		if (callback != null)
		{
			callbackHelper = delegate(AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao)
			{
				AmazonServiceResult<GetCallerIdentityRequest, GetCallerIdentityResponse> responseObject = new AmazonServiceResult<GetCallerIdentityRequest, GetCallerIdentityResponse>((GetCallerIdentityRequest)req, (GetCallerIdentityResponse)res, ex, ao.State);
				callback(responseObject);
			};
		}
		BeginInvoke(request, marshaller, instance, options, callbackHelper);
	}

	internal GetFederationTokenResponse GetFederationToken(GetFederationTokenRequest request)
	{
		GetFederationTokenRequestMarshaller marshaller = new GetFederationTokenRequestMarshaller();
		GetFederationTokenResponseUnmarshaller instance = GetFederationTokenResponseUnmarshaller.Instance;
		return Invoke<GetFederationTokenRequest, GetFederationTokenResponse>(request, marshaller, instance);
	}

	public void GetFederationTokenAsync(GetFederationTokenRequest request, AmazonServiceCallback<GetFederationTokenRequest, GetFederationTokenResponse> callback, AsyncOptions options = null)
	{
		options = ((options == null) ? new AsyncOptions() : options);
		GetFederationTokenRequestMarshaller marshaller = new GetFederationTokenRequestMarshaller();
		GetFederationTokenResponseUnmarshaller instance = GetFederationTokenResponseUnmarshaller.Instance;
		Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
		if (callback != null)
		{
			callbackHelper = delegate(AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao)
			{
				AmazonServiceResult<GetFederationTokenRequest, GetFederationTokenResponse> responseObject = new AmazonServiceResult<GetFederationTokenRequest, GetFederationTokenResponse>((GetFederationTokenRequest)req, (GetFederationTokenResponse)res, ex, ao.State);
				callback(responseObject);
			};
		}
		BeginInvoke(request, marshaller, instance, options, callbackHelper);
	}

	internal GetSessionTokenResponse GetSessionToken()
	{
		return GetSessionToken(new GetSessionTokenRequest());
	}

	internal GetSessionTokenResponse GetSessionToken(GetSessionTokenRequest request)
	{
		GetSessionTokenRequestMarshaller marshaller = new GetSessionTokenRequestMarshaller();
		GetSessionTokenResponseUnmarshaller instance = GetSessionTokenResponseUnmarshaller.Instance;
		return Invoke<GetSessionTokenRequest, GetSessionTokenResponse>(request, marshaller, instance);
	}

	public void GetSessionTokenAsync(AmazonServiceCallback<GetSessionTokenRequest, GetSessionTokenResponse> callback, AsyncOptions options = null)
	{
		GetSessionTokenAsync(new GetSessionTokenRequest(), callback, options);
	}

	public void GetSessionTokenAsync(GetSessionTokenRequest request, AmazonServiceCallback<GetSessionTokenRequest, GetSessionTokenResponse> callback, AsyncOptions options = null)
	{
		options = ((options == null) ? new AsyncOptions() : options);
		GetSessionTokenRequestMarshaller marshaller = new GetSessionTokenRequestMarshaller();
		GetSessionTokenResponseUnmarshaller instance = GetSessionTokenResponseUnmarshaller.Instance;
		Action<AmazonWebServiceRequest, AmazonWebServiceResponse, Exception, AsyncOptions> callbackHelper = null;
		if (callback != null)
		{
			callbackHelper = delegate(AmazonWebServiceRequest req, AmazonWebServiceResponse res, Exception ex, AsyncOptions ao)
			{
				AmazonServiceResult<GetSessionTokenRequest, GetSessionTokenResponse> responseObject = new AmazonServiceResult<GetSessionTokenRequest, GetSessionTokenResponse>((GetSessionTokenRequest)req, (GetSessionTokenResponse)res, ex, ao.State);
				callback(responseObject);
			};
		}
		BeginInvoke(request, marshaller, instance, options, callbackHelper);
	}
}
