using System;
using Amazon.Runtime.Internal.Transform;
using ThirdParty.Json.LitJson;

namespace Amazon.MobileAnalytics.Model.Internal.MarshallTransformations;

public class EventUnmarshaller : IUnmarshaller<Event, XmlUnmarshallerContext>, IUnmarshaller<Event, JsonUnmarshallerContext>
{
	private static EventUnmarshaller _instance = new EventUnmarshaller();

	public static EventUnmarshaller Instance => _instance;

	Event IUnmarshaller<Event, XmlUnmarshallerContext>.Unmarshall(XmlUnmarshallerContext context)
	{
		throw new NotImplementedException();
	}

	public Event Unmarshall(JsonUnmarshallerContext context)
	{
		context.Read();
		if (context.CurrentTokenType == JsonToken.Null)
		{
			return null;
		}
		Event obj = new Event();
		int currentDepth = context.CurrentDepth;
		while (context.ReadAtDepth(currentDepth))
		{
			if (context.TestExpression("attributes", currentDepth))
			{
				DictionaryUnmarshaller<string, string, StringUnmarshaller, StringUnmarshaller> dictionaryUnmarshaller = new DictionaryUnmarshaller<string, string, StringUnmarshaller, StringUnmarshaller>(StringUnmarshaller.Instance, StringUnmarshaller.Instance);
				obj.Attributes = dictionaryUnmarshaller.Unmarshall(context);
			}
			else if (context.TestExpression("eventType", currentDepth))
			{
				StringUnmarshaller instance = StringUnmarshaller.Instance;
				obj.EventType = instance.Unmarshall(context);
			}
			else if (context.TestExpression("metrics", currentDepth))
			{
				DictionaryUnmarshaller<string, double, StringUnmarshaller, DoubleUnmarshaller> dictionaryUnmarshaller2 = new DictionaryUnmarshaller<string, double, StringUnmarshaller, DoubleUnmarshaller>(StringUnmarshaller.Instance, DoubleUnmarshaller.Instance);
				obj.Metrics = dictionaryUnmarshaller2.Unmarshall(context);
			}
			else if (context.TestExpression("session", currentDepth))
			{
				SessionUnmarshaller instance2 = SessionUnmarshaller.Instance;
				obj.Session = instance2.Unmarshall(context);
			}
			else if (context.TestExpression("timestamp", currentDepth))
			{
				DateTimeUnmarshaller instance3 = DateTimeUnmarshaller.Instance;
				obj.Timestamp = instance3.Unmarshall(context);
			}
			else if (context.TestExpression("version", currentDepth))
			{
				StringUnmarshaller instance4 = StringUnmarshaller.Instance;
				obj.Version = instance4.Unmarshall(context);
			}
		}
		return obj;
	}
}
