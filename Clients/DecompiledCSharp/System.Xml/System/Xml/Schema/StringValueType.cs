namespace System.Xml.Schema;

internal struct StringValueType(string value)
{
	private string value = value;

	public string Value => value;

	public override bool Equals(object obj)
	{
		if (obj is StringValueType)
		{
			return (StringValueType)obj == this;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return value.GetHashCode();
	}

	public static bool operator ==(StringValueType v1, StringValueType v2)
	{
		return v1.Value == v2.Value;
	}

	public static bool operator !=(StringValueType v1, StringValueType v2)
	{
		return v1.Value != v2.Value;
	}
}
