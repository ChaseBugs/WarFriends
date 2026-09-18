using Mono.Xml.Schema;

namespace System.Xml.Schema;

internal struct UriValueType(XmlSchemaUri value)
{
	private XmlSchemaUri value = value;

	public XmlSchemaUri Value => value;

	public override bool Equals(object obj)
	{
		if (obj is UriValueType)
		{
			return (UriValueType)obj == this;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return value.GetHashCode();
	}

	public override string ToString()
	{
		return value.ToString();
	}

	public static bool operator ==(UriValueType v1, UriValueType v2)
	{
		return v1.Value == v2.Value;
	}

	public static bool operator !=(UriValueType v1, UriValueType v2)
	{
		return v1.Value != v2.Value;
	}
}
