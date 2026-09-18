using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;

namespace Amazon.MobileAnalytics.Model.Internal.MarshallTransformations;

public class SessionMarshaller : IRequestMarshaller<Session, JsonMarshallerContext>
{
	public static readonly SessionMarshaller Instance = new SessionMarshaller();

	public void Marshall(Session requestObject, JsonMarshallerContext context)
	{
		if (requestObject.IsSetDuration())
		{
			context.Writer.WritePropertyName("duration");
			context.Writer.Write(requestObject.Duration);
		}
		if (requestObject.IsSetId())
		{
			context.Writer.WritePropertyName("id");
			context.Writer.Write(requestObject.Id);
		}
		if (requestObject.IsSetStartTimestamp())
		{
			context.Writer.WritePropertyName("startTimestamp");
			context.Writer.Write(StringUtils.FromDateTime(requestObject.StartTimestamp));
		}
		if (requestObject.IsSetStopTimestamp())
		{
			context.Writer.WritePropertyName("stopTimestamp");
			context.Writer.Write(StringUtils.FromDateTime(requestObject.StopTimestamp));
		}
	}
}
