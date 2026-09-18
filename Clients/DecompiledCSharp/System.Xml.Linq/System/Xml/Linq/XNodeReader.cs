namespace System.Xml.Linq;

internal class XNodeReader : XmlReader
{
	private ReadState state;

	private XNode node;

	private XNode start;

	private int attr = -1;

	private bool attr_value;

	private bool end_element;

	private NameTable name_table = new NameTable();

	public override int AttributeCount
	{
		get
		{
			if (state != ReadState.Interactive || end_element)
			{
				return 0;
			}
			int num = 0;
			switch (node.NodeType)
			{
			case XmlNodeType.Document:
			{
				XDeclaration declaration = ((XDocument)node).Declaration;
				return ((declaration.Version != null) ? 1 : 0) + ((declaration.Encoding != null) ? 1 : 0) + ((declaration.Standalone != null) ? 1 : 0);
			}
			case XmlNodeType.DocumentType:
			{
				XDocumentType xDocumentType = (XDocumentType)node;
				return ((xDocumentType.PublicId != null) ? 1 : 0) + ((xDocumentType.SystemId != null) ? 1 : 0) + ((xDocumentType.InternalSubset != null) ? 1 : 0);
			}
			case XmlNodeType.Element:
			{
				XElement xElement = (XElement)node;
				for (XAttribute xAttribute = xElement.FirstAttribute; xAttribute != null; xAttribute = xAttribute.NextAttribute)
				{
					num++;
				}
				return num;
			}
			default:
				return 0;
			}
		}
	}

	public override string BaseURI => node.BaseUri ?? string.Empty;

	public override int Depth
	{
		get
		{
			if (EOF)
			{
				return 0;
			}
			int num = 0;
			for (XNode parent = node.Parent; parent != null; parent = parent.Parent)
			{
				num++;
			}
			if (attr >= 0)
			{
				num++;
			}
			if (attr_value)
			{
				num++;
			}
			return num;
		}
	}

	public override bool EOF => state == ReadState.EndOfFile || state == ReadState.Error;

	public override bool HasAttributes
	{
		get
		{
			if (EOF || end_element || node == null)
			{
				return false;
			}
			if (node is XElement)
			{
				return ((XElement)node).HasAttributes;
			}
			return AttributeCount > 0;
		}
	}

	public override bool HasValue
	{
		get
		{
			if (EOF)
			{
				return false;
			}
			if (attr >= 0)
			{
				return true;
			}
			XmlNodeType nodeType = node.NodeType;
			if (nodeType == XmlNodeType.Element || nodeType == XmlNodeType.Document || nodeType == XmlNodeType.EndElement)
			{
				return false;
			}
			return true;
		}
	}

	public override bool IsEmptyElement => !EOF && attr < 0 && node is XElement && ((XElement)node).IsEmpty;

	public override string LocalName
	{
		get
		{
			object currentName = GetCurrentName();
			if (currentName == null)
			{
				return string.Empty;
			}
			if (currentName is string)
			{
				return (string)currentName;
			}
			return ((XName)currentName).LocalName;
		}
	}

	public override string NamespaceURI
	{
		get
		{
			XName xName = GetCurrentName() as XName;
			if (xName != null)
			{
				return (!(xName.LocalName == "xmlns") || !(xName.Namespace == XNamespace.None)) ? xName.NamespaceName : XNamespace.Xmlns.NamespaceName;
			}
			return string.Empty;
		}
	}

	public override XmlNameTable NameTable => name_table;

	public override XmlNodeType NodeType => (state == ReadState.Interactive) ? (end_element ? XmlNodeType.EndElement : (attr_value ? XmlNodeType.Text : ((attr >= 0) ? XmlNodeType.Attribute : ((node.NodeType != XmlNodeType.Document) ? node.NodeType : XmlNodeType.XmlDeclaration)))) : XmlNodeType.None;

	public override string Prefix
	{
		get
		{
			XName xName = GetCurrentName() as XName;
			if (xName == null || xName.Namespace == XNamespace.None)
			{
				return string.Empty;
			}
			XElement xElement = (node as XElement) ?? node.Parent;
			if (xElement == null)
			{
				return string.Empty;
			}
			return xElement.GetPrefixOfNamespace(xName.Namespace) ?? string.Empty;
		}
	}

	public override ReadState ReadState => state;

	public override string Value
	{
		get
		{
			if (ReadState != ReadState.Interactive)
			{
				return string.Empty;
			}
			XAttribute currentAttribute = GetCurrentAttribute();
			if (currentAttribute != null)
			{
				return currentAttribute.Value;
			}
			switch (node.NodeType)
			{
			case XmlNodeType.Document:
			{
				XDeclaration declaration = ((XDocument)node).Declaration;
				if (attr >= 0)
				{
					return LocalName switch
					{
						"version" => declaration.Version, 
						"encoding" => declaration.Encoding, 
						_ => declaration.Standalone, 
					};
				}
				string text = declaration.ToString();
				return text.Substring(6, text.Length - 6 - 2);
			}
			case XmlNodeType.DocumentType:
			{
				XDocumentType xDocumentType = (XDocumentType)node;
				return LocalName switch
				{
					"PUBLIC" => xDocumentType.PublicId, 
					"SYSTEM" => xDocumentType.SystemId, 
					_ => xDocumentType.InternalSubset, 
				};
			}
			case XmlNodeType.ProcessingInstruction:
				return ((XProcessingInstruction)node).Data;
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
				return ((XText)node).Value;
			case XmlNodeType.Comment:
				return ((XComment)node).Value;
			default:
				return string.Empty;
			}
		}
	}

	public XNodeReader(XNode node)
	{
		this.node = node;
		start = node;
	}

	private XAttribute GetCurrentAttribute()
	{
		return GetXAttribute(attr);
	}

	private XAttribute GetXAttribute(int idx)
	{
		if (EOF)
		{
			return null;
		}
		if (!(node is XElement xElement))
		{
			return null;
		}
		int num = 0;
		foreach (XAttribute item in xElement.Attributes())
		{
			if (num++ == idx)
			{
				return item;
			}
		}
		return null;
	}

	private object GetCurrentName()
	{
		if (EOF || attr_value)
		{
			return null;
		}
		return GetName(attr);
	}

	private object GetName(int attr)
	{
		if (attr >= 0)
		{
			switch (node.NodeType)
			{
			case XmlNodeType.Element:
			{
				XAttribute xAttribute = GetXAttribute(attr);
				return xAttribute.Name;
			}
			case XmlNodeType.DocumentType:
				if (attr == 0)
				{
					return (((XDocumentType)node).PublicId == null) ? "SYSTEM" : "PUBLIC";
				}
				return "SYSTEM";
			case XmlNodeType.Document:
			{
				XDeclaration declaration = ((XDocument)node).Declaration;
				return attr switch
				{
					0 => (declaration.Version != null) ? "version" : ((declaration.Encoding == null) ? "standalone" : "encoding"), 
					1 => (declaration.Version == null) ? "standalone" : ((declaration.Encoding == null) ? "standalone" : "encoding"), 
					_ => "standalone", 
				};
			}
			}
		}
		else
		{
			switch (node.NodeType)
			{
			case XmlNodeType.Document:
				return "xml";
			case XmlNodeType.Element:
				return ((XElement)node).Name;
			case XmlNodeType.ProcessingInstruction:
				return ((XProcessingInstruction)node).Target;
			case XmlNodeType.DocumentType:
				return ((XDocumentType)node).Name;
			}
		}
		return null;
	}

	public override void Close()
	{
		state = ReadState.Closed;
	}

	public override string LookupNamespace(string prefix)
	{
		if (EOF)
		{
			return null;
		}
		XElement xElement = (node as XElement) ?? node.Parent;
		if (xElement == null)
		{
			return null;
		}
		XNamespace namespaceOfPrefix = xElement.GetNamespaceOfPrefix(prefix);
		return (!(namespaceOfPrefix != XNamespace.None)) ? null : namespaceOfPrefix.NamespaceName;
	}

	public override bool MoveToElement()
	{
		if (attr >= 0)
		{
			attr_value = false;
			attr = -1;
			return true;
		}
		return false;
	}

	public override bool MoveToFirstAttribute()
	{
		if (AttributeCount > 0)
		{
			attr = 0;
			attr_value = false;
			return true;
		}
		return false;
	}

	public override bool MoveToNextAttribute()
	{
		int attributeCount = AttributeCount;
		if (attr + 1 < attributeCount)
		{
			attr++;
			attr_value = false;
			return true;
		}
		return false;
	}

	public override bool MoveToAttribute(string name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		int attributeCount = AttributeCount;
		bool flag = false;
		for (int i = 0; i < attributeCount; i++)
		{
			object name2 = GetName(i);
			if (name2 != null)
			{
				if (name2 as string == name)
				{
					flag = true;
				}
				XName xName = (XName)name2;
				if (name.EndsWith(xName.LocalName, StringComparison.Ordinal) && name == GetPrefixedName((XName)name2))
				{
					flag = true;
				}
				if (flag)
				{
					attr = i;
					attr_value = false;
					return true;
				}
			}
		}
		return false;
	}

	private string GetPrefixedName(XName name)
	{
		XElement xElement = (node as XElement) ?? node.Parent;
		if (xElement == null || name.Namespace == XNamespace.None || xElement.GetPrefixOfNamespace(name.Namespace) == string.Empty)
		{
			return name.LocalName;
		}
		return xElement.GetPrefixOfNamespace(name.Namespace) + ":" + name.LocalName;
	}

	public override bool MoveToAttribute(string local, string ns)
	{
		if (local == null)
		{
			throw new ArgumentNullException("local");
		}
		if (ns == null)
		{
			throw new ArgumentNullException("ns");
		}
		int attributeCount = AttributeCount;
		bool flag = false;
		for (int i = 0; i < attributeCount; i++)
		{
			object name = GetName(i);
			if (name != null)
			{
				if (name as string == local && ns.Length == 0)
				{
					flag = true;
				}
				XName xName = (XName)name;
				if (local == xName.LocalName && ns == xName.NamespaceName)
				{
					flag = true;
				}
				if (flag)
				{
					attr = i;
					attr_value = false;
					return true;
				}
			}
		}
		return false;
	}

	public override string GetAttribute(int i)
	{
		int num = attr;
		bool flag = attr_value;
		try
		{
			MoveToElement();
			MoveToAttribute(i);
			return Value;
		}
		finally
		{
			attr = num;
			attr_value = flag;
		}
	}

	public override string GetAttribute(string name)
	{
		int num = attr;
		bool flag = attr_value;
		try
		{
			MoveToElement();
			return (!MoveToAttribute(name)) ? null : Value;
		}
		finally
		{
			attr = num;
			attr_value = flag;
		}
	}

	public override string GetAttribute(string local, string ns)
	{
		int num = attr;
		bool flag = attr_value;
		try
		{
			MoveToElement();
			return (!MoveToAttribute(local, ns)) ? null : Value;
		}
		finally
		{
			attr = num;
			attr_value = flag;
		}
	}

	public override bool Read()
	{
		attr = -1;
		attr_value = false;
		switch (state)
		{
		case ReadState.Initial:
			state = ReadState.Interactive;
			if (node is XDocument xDocument)
			{
				if (xDocument.Declaration != null)
				{
					return true;
				}
				break;
			}
			return true;
		default:
			return false;
		case ReadState.Interactive:
			break;
		}
		if (node is XDocument)
		{
			XDocument xDocument2 = node as XDocument;
			node = xDocument2.FirstNode;
			if (node == null)
			{
				state = ReadState.EndOfFile;
				return false;
			}
			node = xDocument2.FirstNode;
			return true;
		}
		if (node is XElement xElement && !end_element)
		{
			if (xElement.FirstNode != null)
			{
				node = xElement.FirstNode;
				return true;
			}
			if (!xElement.IsEmpty)
			{
				end_element = true;
				return true;
			}
		}
		end_element = false;
		if (node.NextNode != null && node != start)
		{
			node = node.NextNode;
			return true;
		}
		if (node.Parent == null || node == start)
		{
			state = ReadState.EndOfFile;
			return false;
		}
		node = node.Parent;
		end_element = true;
		return true;
	}

	public override bool ReadAttributeValue()
	{
		if (attr < 0 || attr_value)
		{
			return false;
		}
		attr_value = true;
		return true;
	}

	public override void ResolveEntity()
	{
		throw new NotSupportedException();
	}
}
