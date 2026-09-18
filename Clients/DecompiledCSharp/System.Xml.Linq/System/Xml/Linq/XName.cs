using System.Runtime.Serialization;

namespace System.Xml.Linq;

[Serializable]
public sealed class XName : ISerializable, IEquatable<XName>
{
	private string local;

	private XNamespace ns;

	public string LocalName => local;

	public XNamespace Namespace => ns;

	public string NamespaceName => ns.NamespaceName;

	private XName(SerializationInfo info, StreamingContext context)
	{
		string expandedName = info.GetString("name");
		ExpandName(expandedName, out var text, out var uri);
		local = text;
		ns = XNamespace.Get(uri);
	}

	internal XName(string local, XNamespace ns)
	{
		this.local = XmlConvert.VerifyNCName(local);
		this.ns = ns;
	}

	bool IEquatable<XName>.Equals(XName other)
	{
		return this == other;
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("name", ToString());
	}

	private static Exception ErrorInvalidExpandedName()
	{
		return new ArgumentException("Invalid expanded name.");
	}

	public override bool Equals(object obj)
	{
		XName xName = obj as XName;
		return xName != null && this == xName;
	}

	public static XName Get(string expandedName)
	{
		ExpandName(expandedName, out var localName, out var namespaceName);
		return Get(localName, namespaceName);
	}

	private static void ExpandName(string expandedName, out string local, out string ns)
	{
		if (expandedName == null)
		{
			throw new ArgumentNullException("expandedName");
		}
		ns = null;
		local = null;
		if (expandedName.Length == 0)
		{
			throw ErrorInvalidExpandedName();
		}
		if (expandedName[0] == '{')
		{
			for (int i = 1; i < expandedName.Length; i++)
			{
				if (expandedName[i] == '}')
				{
					ns = expandedName.Substring(1, i - 1);
				}
			}
			if (string.IsNullOrEmpty(ns))
			{
				throw ErrorInvalidExpandedName();
			}
			if (expandedName.Length == ns.Length + 2)
			{
				throw ErrorInvalidExpandedName();
			}
			local = expandedName.Substring(ns.Length + 2);
		}
		else
		{
			local = expandedName;
			ns = string.Empty;
		}
	}

	public static XName Get(string localName, string namespaceName)
	{
		return XNamespace.Get(namespaceName).GetName(localName);
	}

	public override int GetHashCode()
	{
		return local.GetHashCode() ^ ns.GetHashCode();
	}

	public override string ToString()
	{
		if (ns == XNamespace.None)
		{
			return local;
		}
		return "{" + ns.NamespaceName + "}" + local;
	}

	public static bool operator ==(XName n1, XName n2)
	{
		if ((object)n1 == null)
		{
			return (object)n2 == null;
		}
		if ((object)n2 == null)
		{
			return false;
		}
		return object.ReferenceEquals(n1, n2) || (n1.local == n2.local && n1.ns == n2.ns);
	}

	public static implicit operator XName(string s)
	{
		return (s != null) ? Get(s) : null;
	}

	public static bool operator !=(XName n1, XName n2)
	{
		return !(n1 == n2);
	}
}
