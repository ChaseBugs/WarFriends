using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.SecurityToken.Model.Internal.MarshallTransformations;

public class GetCallerIdentityRequestMarshaller : IMarshaller<IRequest, GetCallerIdentityRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
{
	public IRequest Marshall(AmazonWebServiceRequest input)
	{
		return Marshall((GetCallerIdentityRequest)input);
	}

	public IRequest Marshall(GetCallerIdentityRequest publicRequest)
	{
		return new DefaultRequest(publicRequest, "Amazon.SecurityToken")
		{
			Parameters = 
			{
				{ "Action", "GetCallerIdentity" },
				{ "Version", "2011-06-15" }
			}
		};
	}
}
