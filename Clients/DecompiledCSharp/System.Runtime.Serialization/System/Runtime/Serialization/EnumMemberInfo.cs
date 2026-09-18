namespace System.Runtime.Serialization;

internal struct EnumMemberInfo(string name, object value)
{
	public readonly string XmlName = name;

	public readonly object Value = value;
}
