using System.Collections.Generic;

namespace System.Xml.Linq;

public sealed class XNamespace
{
	private static readonly XNamespace blank;

	private static readonly XNamespace xml;

	private static readonly XNamespace xmlns;

	private static Dictionary<string, XNamespace> nstable;

	private string uri;

	private Dictionary<string, XName> table;

	public static XNamespace None => blank;

	public static XNamespace Xml => xml;

	public static XNamespace Xmlns => xmlns;

	public string NamespaceName => uri;

	private XNamespace(string namespaceName)
	{
		if (namespaceName == null)
		{
			throw new ArgumentNullException("namespaceName");
		}
		uri = namespaceName;
	}

	static XNamespace()
	{
		nstable = new Dictionary<string, XNamespace>();
		blank = Get(string.Empty);
		xml = Get("http://www.w3.org/XML/1998/namespace");
		xmlns = Get("http://www.w3.org/2000/xmlns/");
	}

	public static XNamespace Get(string uri)
	{
		lock (nstable)
		{
			if (!nstable.TryGetValue(uri, out var value))
			{
				value = new XNamespace(uri);
				nstable[uri] = value;
			}
			return value;
		}
	}

	public XName GetName(string localName)
	{
		if (table == null)
		{
			table = new Dictionary<string, XName>();
		}
		lock (table)
		{
			if (!table.TryGetValue(localName, out var value))
			{
				value = new XName(localName, this);
				table[localName] = value;
			}
			return value;
		}
	}

	public override bool Equals(object other)
	{
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		XNamespace xNamespace = other as XNamespace;
		return xNamespace != null && uri == xNamespace.uri;
	}

	public override int GetHashCode()
	{
		return uri.GetHashCode();
	}

	public override string ToString()
	{
		return uri;
	}

	public static bool operator ==(XNamespace o1, XNamespace o2)
	{
		return o1?.Equals(o2) ?? ((object)o2 == null);
	}

	public static bool operator !=(XNamespace o1, XNamespace o2)
	{
		return !(o1 == o2);
	}

	public static XName operator +(XNamespace ns, string localName)
	{
		return new XName(localName, ns.NamespaceName);
	}

	public static implicit operator XNamespace(string s)
	{
		return (s == null) ? null : Get(s);
	}
}
