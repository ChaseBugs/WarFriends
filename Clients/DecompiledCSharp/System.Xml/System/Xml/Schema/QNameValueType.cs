namespace System.Xml.Schema;

internal struct QNameValueType(XmlQualifiedName value)
{
	private XmlQualifiedName value = value;

	public XmlQualifiedName Value => value;

	public override bool Equals(object obj)
	{
		if (obj is QNameValueType)
		{
			return (QNameValueType)obj == this;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return value.GetHashCode();
	}

	public static bool operator ==(QNameValueType v1, QNameValueType v2)
	{
		return v1.Value == v2.Value;
	}

	public static bool operator !=(QNameValueType v1, QNameValueType v2)
	{
		return v1.Value != v2.Value;
	}
}
