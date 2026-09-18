namespace Mono.Xml.Xsl;

internal struct Attribute(string prefix, string namespaceUri, string localName, string value)
{
	public string Prefix = prefix;

	public string Namespace = namespaceUri;

	public string LocalName = localName;

	public string Value = value;
}
