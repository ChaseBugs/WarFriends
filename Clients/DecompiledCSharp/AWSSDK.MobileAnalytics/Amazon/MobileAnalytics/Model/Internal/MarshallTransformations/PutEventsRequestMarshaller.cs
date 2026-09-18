using System.Globalization;
using System.IO;
using System.Text;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using ThirdParty.Json.LitJson;

namespace Amazon.MobileAnalytics.Model.Internal.MarshallTransformations;

public class PutEventsRequestMarshaller : IMarshaller<IRequest, PutEventsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
{
	public IRequest Marshall(AmazonWebServiceRequest input)
	{
		return Marshall((PutEventsRequest)input);
	}

	public IRequest Marshall(PutEventsRequest publicRequest)
	{
		IRequest request = new DefaultRequest(publicRequest, "Amazon.MobileAnalytics");
		request.Headers["Content-Type"] = "application/x-amz-json-";
		request.HttpMethod = "POST";
		string resourcePath = "/2014-06-05/events";
		request.ResourcePath = resourcePath;
		using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
		{
			JsonWriter jsonWriter = new JsonWriter(stringWriter);
			jsonWriter.WriteObjectStart();
			JsonMarshallerContext jsonMarshallerContext = new JsonMarshallerContext(request, jsonWriter);
			if (publicRequest.IsSetEvents())
			{
				jsonMarshallerContext.Writer.WritePropertyName("events");
				jsonMarshallerContext.Writer.WriteArrayStart();
				foreach (Event @event in publicRequest.Events)
				{
					jsonMarshallerContext.Writer.WriteObjectStart();
					EventMarshaller.Instance.Marshall(@event, jsonMarshallerContext);
					jsonMarshallerContext.Writer.WriteObjectEnd();
				}
				jsonMarshallerContext.Writer.WriteArrayEnd();
			}
			jsonWriter.WriteObjectEnd();
			string s = stringWriter.ToString();
			request.Content = Encoding.UTF8.GetBytes(s);
		}
		if (publicRequest.IsSetClientContext())
		{
			request.Headers["x-amz-Client-Context"] = publicRequest.ClientContext;
		}
		if (publicRequest.IsSetClientContextEncoding())
		{
			request.Headers["x-amz-Client-Context-Encoding"] = publicRequest.ClientContextEncoding;
		}
		return request;
	}
}
