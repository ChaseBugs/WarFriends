using System.Collections.Generic;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;

namespace Amazon.MobileAnalytics.Model.Internal.MarshallTransformations;

public class EventMarshaller : IRequestMarshaller<Event, JsonMarshallerContext>
{
	public static readonly EventMarshaller Instance = new EventMarshaller();

	public void Marshall(Event requestObject, JsonMarshallerContext context)
	{
		if (requestObject.IsSetAttributes())
		{
			context.Writer.WritePropertyName("attributes");
			context.Writer.WriteObjectStart();
			foreach (KeyValuePair<string, string> attribute in requestObject.Attributes)
			{
				context.Writer.WritePropertyName(attribute.Key);
				string value = attribute.Value;
				context.Writer.Write(value);
			}
			context.Writer.WriteObjectEnd();
		}
		if (requestObject.IsSetEventType())
		{
			context.Writer.WritePropertyName("eventType");
			context.Writer.Write(requestObject.EventType);
		}
		if (requestObject.IsSetMetrics())
		{
			context.Writer.WritePropertyName("metrics");
			context.Writer.WriteObjectStart();
			foreach (KeyValuePair<string, double> metric in requestObject.Metrics)
			{
				context.Writer.WritePropertyName(metric.Key);
				double value2 = metric.Value;
				context.Writer.Write(value2);
			}
			context.Writer.WriteObjectEnd();
		}
		if (requestObject.IsSetSession())
		{
			context.Writer.WritePropertyName("session");
			context.Writer.WriteObjectStart();
			SessionMarshaller.Instance.Marshall(requestObject.Session, context);
			context.Writer.WriteObjectEnd();
		}
		if (requestObject.IsSetTimestamp())
		{
			context.Writer.WritePropertyName("timestamp");
			context.Writer.Write(StringUtils.FromDateTime(requestObject.Timestamp));
		}
		if (requestObject.IsSetVersion())
		{
			context.Writer.WritePropertyName("version");
			context.Writer.Write(requestObject.Version);
		}
	}
}
