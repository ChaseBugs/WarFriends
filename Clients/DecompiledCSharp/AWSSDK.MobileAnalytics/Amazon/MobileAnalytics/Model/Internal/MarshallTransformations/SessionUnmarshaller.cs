using System;
using Amazon.Runtime.Internal.Transform;
using ThirdParty.Json.LitJson;

namespace Amazon.MobileAnalytics.Model.Internal.MarshallTransformations;

public class SessionUnmarshaller : IUnmarshaller<Session, XmlUnmarshallerContext>, IUnmarshaller<Session, JsonUnmarshallerContext>
{
	private static SessionUnmarshaller _instance = new SessionUnmarshaller();

	public static SessionUnmarshaller Instance => _instance;

	Session IUnmarshaller<Session, XmlUnmarshallerContext>.Unmarshall(XmlUnmarshallerContext context)
	{
		throw new NotImplementedException();
	}

	public Session Unmarshall(JsonUnmarshallerContext context)
	{
		context.Read();
		if (context.CurrentTokenType == JsonToken.Null)
		{
			return null;
		}
		Session session = new Session();
		int currentDepth = context.CurrentDepth;
		while (context.ReadAtDepth(currentDepth))
		{
			if (context.TestExpression("duration", currentDepth))
			{
				LongUnmarshaller instance = LongUnmarshaller.Instance;
				session.Duration = instance.Unmarshall(context);
			}
			else if (context.TestExpression("id", currentDepth))
			{
				StringUnmarshaller instance2 = StringUnmarshaller.Instance;
				session.Id = instance2.Unmarshall(context);
			}
			else if (context.TestExpression("startTimestamp", currentDepth))
			{
				DateTimeUnmarshaller instance3 = DateTimeUnmarshaller.Instance;
				session.StartTimestamp = instance3.Unmarshall(context);
			}
			else if (context.TestExpression("stopTimestamp", currentDepth))
			{
				DateTimeUnmarshaller instance4 = DateTimeUnmarshaller.Instance;
				session.StopTimestamp = instance4.Unmarshall(context);
			}
		}
		return session;
	}
}
