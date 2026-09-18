using System.Collections.Generic;
using System.Text;

namespace System.Xml.Linq;

public class XAttribute : XObject
{
	private static readonly XAttribute[] empty_array = new XAttribute[0];

	private XName name;

	private string value;

	private XAttribute next;

	private XAttribute previous;

	private static readonly char[] escapeChars = new char[7] { '<', '>', '&', '"', '\r', '\n', '\t' };

	public static IEnumerable<XAttribute> EmptySequence => empty_array;

	public bool IsNamespaceDeclaration => name.Namespace == XNamespace.Xmlns || (name.LocalName == "xmlns" && name.Namespace == XNamespace.None);

	public XName Name => name;

	public XAttribute NextAttribute
	{
		get
		{
			return next;
		}
		internal set
		{
			next = value;
		}
	}

	public override XmlNodeType NodeType => XmlNodeType.Attribute;

	public XAttribute PreviousAttribute
	{
		get
		{
			return previous;
		}
		internal set
		{
			previous = value;
		}
	}

	public string Value
	{
		get
		{
			return XUtil.ToString(value);
		}
		set
		{
			this.value = value;
		}
	}

	public XAttribute(XAttribute other)
	{
		if (other == null)
		{
			throw new ArgumentNullException("other");
		}
		name = other.name;
		value = other.value;
	}

	public XAttribute(XName name, object value)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		this.name = name;
		SetValue(value);
	}

	public void Remove()
	{
		if (base.Parent != null)
		{
			if (next != null)
			{
				next.previous = previous;
			}
			if (previous != null)
			{
				previous.next = next;
			}
			if (base.Parent.FirstAttribute == this)
			{
				base.Parent.FirstAttribute = next;
			}
			if (base.Parent.LastAttribute == this)
			{
				base.Parent.LastAttribute = previous;
			}
			SetOwner(null);
		}
		next = null;
		previous = null;
	}

	public void SetValue(object value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		this.value = XUtil.ToString(value);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(name.ToString());
		stringBuilder.Append("=\"");
		int num = 0;
		while (true)
		{
			int num2 = value.IndexOfAny(escapeChars, num);
			if (num2 < 0)
			{
				break;
			}
			stringBuilder.Append(value, num, num2 - num);
			switch (value[num2])
			{
			case '&':
				stringBuilder.Append("&amp;");
				break;
			case '<':
				stringBuilder.Append("&lt;");
				break;
			case '>':
				stringBuilder.Append("&gt;");
				break;
			case '"':
				stringBuilder.Append("&quot;");
				break;
			case '\r':
				stringBuilder.Append("&#xD;");
				break;
			case '\n':
				stringBuilder.Append("&#xA;");
				break;
			case '\t':
				stringBuilder.Append("&#x9;");
				break;
			}
			num = num2 + 1;
		}
		if (num > 0)
		{
			stringBuilder.Append(value, num, value.Length - num);
		}
		else
		{
			stringBuilder.Append(value);
		}
		stringBuilder.Append("\"");
		return stringBuilder.ToString();
	}

	public static explicit operator bool(XAttribute attribute)
	{
		if (attribute == null)
		{
			throw new ArgumentNullException("attribute");
		}
		return XUtil.ConvertToBoolean(attribute.value);
	}

	public static explicit operator bool?(XAttribute attribute)
	{
		if (attribute == null)
		{
			return null;
		}
		return (attribute.value != null) ? new bool?(XUtil.ConvertToBoolean(attribute.value)) : ((bool?)null);
	}

	public static explicit operator DateTime(XAttribute attribute)
	{
		if (attribute == null)
		{
			throw new ArgumentNullException("attribute");
		}
		return XUtil.ToDateTime(attribute.value);
	}

	public static explicit operator DateTime?(XAttribute attribute)
	{
		if (attribute == null)
		{
			return null;
		}
		return (attribute.value != null) ? new DateTime?(XUtil.ToDateTime(attribute.value)) : ((DateTime?)null);
	}

	public static explicit operator DateTimeOffset(XAttribute attribute)
	{
		if (attribute == null)
		{
			throw new ArgumentNullException("attribute");
		}
		return XmlConvert.ToDateTimeOffset(attribute.value);
	}

	public static explicit operator DateTimeOffset?(XAttribute attribute)
	{
		if (attribute == null)
		{
			return null;
		}
		return (attribute.value != null) ? new DateTimeOffset?(XmlConvert.ToDateTimeOffset(attribute.value)) : ((DateTimeOffset?)null);
	}

	public static explicit operator decimal(XAttribute attribute)
	{
		if (attribute == null)
		{
			throw new ArgumentNullException("attribute");
		}
		return XmlConvert.ToDecimal(attribute.value);
	}

	public static explicit operator decimal?(XAttribute attribute)
	{
		if (attribute == null)
		{
			return null;
		}
		return (attribute.value != null) ? new decimal?(XmlConvert.ToDecimal(attribute.value)) : ((decimal?)null);
	}

	public static explicit operator double(XAttribute attribute)
	{
		if (attribute == null)
		{
			throw new ArgumentNullException("attribute");
		}
		return XmlConvert.ToDouble(attribute.value);
	}

	public static explicit operator double?(XAttribute attribute)
	{
		if (attribute == null)
		{
			return null;
		}
		return (attribute.value != null) ? new double?(XmlConvert.ToDouble(attribute.value)) : ((double?)null);
	}

	public static explicit operator float(XAttribute attribute)
	{
		if (attribute == null)
		{
			throw new ArgumentNullException("attribute");
		}
		return XmlConvert.ToSingle(attribute.value);
	}

	public static explicit operator float?(XAttribute attribute)
	{
		if (attribute == null)
		{
			return null;
		}
		return (attribute.value != null) ? new float?(XmlConvert.ToSingle(attribute.value)) : ((float?)null);
	}

	public static explicit operator Guid(XAttribute attribute)
	{
		if (attribute == null)
		{
			throw new ArgumentNullException("attribute");
		}
		return XmlConvert.ToGuid(attribute.value);
	}

	public static explicit operator Guid?(XAttribute attribute)
	{
		if (attribute == null)
		{
			return null;
		}
		return (attribute.value != null) ? new Guid?(XmlConvert.ToGuid(attribute.value)) : ((Guid?)null);
	}

	public static explicit operator int(XAttribute attribute)
	{
		if (attribute == null)
		{
			throw new ArgumentNullException("attribute");
		}
		return XmlConvert.ToInt32(attribute.value);
	}

	public static explicit operator int?(XAttribute attribute)
	{
		if (attribute == null)
		{
			return null;
		}
		return (attribute.value != null) ? new int?(XmlConvert.ToInt32(attribute.value)) : ((int?)null);
	}

	public static explicit operator long(XAttribute attribute)
	{
		if (attribute == null)
		{
			throw new ArgumentNullException("attribute");
		}
		return XmlConvert.ToInt64(attribute.value);
	}

	public static explicit operator long?(XAttribute attribute)
	{
		if (attribute == null)
		{
			return null;
		}
		return (attribute.value != null) ? new long?(XmlConvert.ToInt64(attribute.value)) : ((long?)null);
	}

	[CLSCompliant(false)]
	public static explicit operator uint(XAttribute attribute)
	{
		if (attribute == null)
		{
			throw new ArgumentNullException("attribute");
		}
		return XmlConvert.ToUInt32(attribute.value);
	}

	[CLSCompliant(false)]
	public static explicit operator uint?(XAttribute attribute)
	{
		if (attribute == null)
		{
			return null;
		}
		return (attribute.value != null) ? new uint?(XmlConvert.ToUInt32(attribute.value)) : ((uint?)null);
	}

	[CLSCompliant(false)]
	public static explicit operator ulong(XAttribute attribute)
	{
		if (attribute == null)
		{
			throw new ArgumentNullException("attribute");
		}
		return XmlConvert.ToUInt64(attribute.value);
	}

	[CLSCompliant(false)]
	public static explicit operator ulong?(XAttribute attribute)
	{
		if (attribute == null)
		{
			return null;
		}
		return (attribute.value != null) ? new ulong?(XmlConvert.ToUInt64(attribute.value)) : ((ulong?)null);
	}

	public static explicit operator TimeSpan(XAttribute attribute)
	{
		if (attribute == null)
		{
			throw new ArgumentNullException("attribute");
		}
		return XmlConvert.ToTimeSpan(attribute.value);
	}

	public static explicit operator TimeSpan?(XAttribute attribute)
	{
		if (attribute == null)
		{
			return null;
		}
		return (attribute.value != null) ? new TimeSpan?(XmlConvert.ToTimeSpan(attribute.value)) : ((TimeSpan?)null);
	}

	public static explicit operator string(XAttribute attribute)
	{
		return attribute?.value;
	}
}
