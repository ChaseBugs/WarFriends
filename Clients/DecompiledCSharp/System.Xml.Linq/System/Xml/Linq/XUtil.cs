using System.Collections;
using System.Globalization;

namespace System.Xml.Linq;

internal static class XUtil
{
	public const string XmlnsNamespace = "http://www.w3.org/2000/xmlns/";

	public static bool ConvertToBoolean(string s)
	{
		return XmlConvert.ToBoolean(s.ToLower(CultureInfo.InvariantCulture));
	}

	public static DateTime ToDateTime(string s)
	{
		try
		{
			return XmlConvert.ToDateTime(s, XmlDateTimeSerializationMode.RoundtripKind);
		}
		catch
		{
			return DateTime.Parse(s);
		}
	}

	public static string ToString(object o)
	{
		if (o == null)
		{
			throw new InvalidOperationException("Attempt to get string from null");
		}
		switch (Type.GetTypeCode(o.GetType()))
		{
		case TypeCode.String:
			return (string)o;
		case TypeCode.DateTime:
			return XmlConvert.ToString((DateTime)o, XmlDateTimeSerializationMode.RoundtripKind);
		case TypeCode.Double:
			return ((double)o).ToString("r");
		case TypeCode.Single:
			return ((float)o).ToString("r");
		case TypeCode.Boolean:
			return o.ToString().ToLower();
		default:
			if (o is TimeSpan)
			{
				return XmlConvert.ToString((TimeSpan)o);
			}
			if (o is DateTimeOffset)
			{
				return XmlConvert.ToString((DateTimeOffset)o);
			}
			return o.ToString();
		}
	}

	public static bool ToBoolean(object o)
	{
		throw new NotImplementedException();
	}

	public static bool? ToNullableBoolean(object o)
	{
		throw new NotImplementedException();
	}

	public static IEnumerable ExpandArray(object o)
	{
		if (o is XNode n)
		{
			yield return n;
			yield break;
		}
		if (o is string)
		{
			yield return o;
			yield break;
		}
		if (o is IEnumerable)
		{
			foreach (object obj in (IEnumerable)o)
			{
				foreach (object item in ExpandArray(obj))
				{
					yield return item;
				}
			}
			yield break;
		}
		yield return o;
	}

	public static XNode ToNode(object o)
	{
		if (o is XAttribute)
		{
			throw new ArgumentException("Attribute node is not allowed as argument");
		}
		if (o is XNode result)
		{
			return result;
		}
		if (o is string)
		{
			return new XText((string)o);
		}
		return new XText(ToString(o));
	}

	public static object GetDetachedObject(XObject child)
	{
		return (child.Owner == null) ? child : Clone(child);
	}

	public static object Clone(object o)
	{
		if (o is string)
		{
			return (string)o;
		}
		if (o is XAttribute)
		{
			return new XAttribute((XAttribute)o);
		}
		if (o is XElement)
		{
			return new XElement((XElement)o);
		}
		if (o is XCData)
		{
			return new XCData((XCData)o);
		}
		if (o is XComment)
		{
			return new XComment((XComment)o);
		}
		if (o is XProcessingInstruction)
		{
			return new XProcessingInstruction((XProcessingInstruction)o);
		}
		if (o is XDeclaration)
		{
			return new XDeclaration((XDeclaration)o);
		}
		if (o is XDocumentType)
		{
			return new XDocumentType((XDocumentType)o);
		}
		if (o is XText)
		{
			return new XText((XText)o);
		}
		throw new ArgumentException();
	}
}
