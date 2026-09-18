namespace System.Xml.Linq;

internal class XNodeWriter : XmlWriter
{
	private XContainer root;

	private bool is_closed;

	private XContainer current;

	private XAttribute attribute;

	private XmlNodeType state;

	public override WriteState WriteState
	{
		get
		{
			if (is_closed)
			{
				return WriteState.Closed;
			}
			if (attribute != null)
			{
				return WriteState.Attribute;
			}
			return state switch
			{
				XmlNodeType.None => WriteState.Start, 
				XmlNodeType.XmlDeclaration => WriteState.Prolog, 
				XmlNodeType.DocumentType => WriteState.Element, 
				_ => WriteState.Content, 
			};
		}
	}

	public XNodeWriter(XContainer fragment)
	{
		root = fragment;
		state = XmlNodeType.None;
		current = fragment;
	}

	private void CheckState()
	{
		if (is_closed)
		{
			throw new InvalidOperationException();
		}
	}

	private void WritePossiblyTopLevelNode(XNode n, bool possiblyAttribute)
	{
		CheckState();
		if (!possiblyAttribute && attribute != null)
		{
			throw new InvalidOperationException($"Current state is not acceptable for {n.NodeType}.");
		}
		if (state != XmlNodeType.Element)
		{
			root.Add(n);
		}
		else if (attribute != null)
		{
			attribute.Value += XUtil.ToString(n);
		}
		else
		{
			current.Add(n);
		}
		if (state == XmlNodeType.None)
		{
			state = XmlNodeType.XmlDeclaration;
		}
	}

	private void FillXmlns(XElement el, string prefix, XNamespace xns)
	{
		if (!(xns == XNamespace.Xmlns) && xns == XNamespace.None)
		{
			if (el.GetPrefixOfNamespace(xns) != prefix)
			{
				el.SetAttributeValue((!(prefix == string.Empty)) ? XNamespace.Xmlns.GetName(prefix) : XNamespace.None.GetName("xmlns"), xns.NamespaceName);
			}
			else if (el.GetDefaultNamespace() != XNamespace.None)
			{
				el.SetAttributeValue(XNamespace.None.GetName("xmlns"), xns.NamespaceName);
			}
		}
	}

	public override void Close()
	{
		CheckState();
		is_closed = true;
	}

	public override void Flush()
	{
	}

	public override string LookupPrefix(string ns)
	{
		CheckState();
		if (current == null)
		{
			throw new InvalidOperationException();
		}
		return ((current as XElement) ?? current.Parent)?.GetPrefixOfNamespace(XNamespace.Get(ns));
	}

	public override void WriteStartDocument()
	{
		WriteStartDocument(null);
	}

	public override void WriteStartDocument(bool standalone)
	{
		WriteStartDocument((!standalone) ? "no" : "yes");
	}

	private void WriteStartDocument(string sddecl)
	{
		CheckState();
		if (state != XmlNodeType.None)
		{
			throw new InvalidOperationException("Current state is not acceptable for xmldecl.");
		}
		if (!(current is XDocument xDocument))
		{
			throw new InvalidOperationException("Only document node can accept xml declaration");
		}
		xDocument.Declaration = new XDeclaration("1.0", null, sddecl);
		state = XmlNodeType.XmlDeclaration;
	}

	public override void WriteEndDocument()
	{
		CheckState();
		is_closed = true;
	}

	public override void WriteDocType(string name, string publicId, string systemId, string internalSubset)
	{
		CheckState();
		XmlNodeType xmlNodeType = state;
		if (xmlNodeType == XmlNodeType.None || xmlNodeType == XmlNodeType.XmlDeclaration)
		{
			if (!(current is XDocument xDocument))
			{
				throw new InvalidOperationException("Only document node can accept doctype declaration");
			}
			xDocument.Add(new XDocumentType(name, publicId, systemId, internalSubset));
			state = XmlNodeType.DocumentType;
			return;
		}
		throw new InvalidOperationException("Current state is not acceptable for doctype.");
	}

	public override void WriteStartElement(string prefix, string name, string ns)
	{
		CheckState();
		XNamespace xNamespace = XNamespace.Get(ns ?? string.Empty);
		XElement xElement = new XElement(xNamespace.GetName(name));
		if (current == null)
		{
			root.Add(xElement);
			state = XmlNodeType.Element;
		}
		else
		{
			current.Add(xElement);
			state = XmlNodeType.Element;
		}
		FillXmlns(xElement, prefix ?? string.Empty, xNamespace);
		current = xElement;
	}

	public override void WriteEndElement()
	{
		WriteEndElementInternal(forceFull: false);
	}

	public override void WriteFullEndElement()
	{
		WriteEndElementInternal(forceFull: true);
	}

	private void WriteEndElementInternal(bool forceFull)
	{
		CheckState();
		if (current == null)
		{
			throw new InvalidOperationException("Current state is not acceptable for endElement.");
		}
		XElement xElement = current as XElement;
		if (forceFull)
		{
			xElement.IsEmpty = false;
		}
		current = current.Parent;
	}

	public override void WriteStartAttribute(string prefix, string name, string ns)
	{
		CheckState();
		if (attribute != null)
		{
			throw new InvalidOperationException("There is an open attribute.");
		}
		if (!(current is XElement xElement))
		{
			throw new InvalidOperationException("Current state is not acceptable for startAttribute.");
		}
		if (prefix == null)
		{
			prefix = string.Empty;
		}
		if (prefix.Length == 0 && name == "xmlns" && ns == XNamespace.Xmlns.NamespaceName)
		{
			ns = string.Empty;
		}
		XNamespace xNamespace = XNamespace.Get(ns);
		xElement.SetAttributeValue(xNamespace.GetName(name), string.Empty);
		attribute = xElement.LastAttribute;
		FillXmlns(xElement, prefix, xNamespace);
	}

	public override void WriteEndAttribute()
	{
		CheckState();
		if (attribute == null)
		{
			throw new InvalidOperationException("Current state is not acceptable for startAttribute.");
		}
		attribute = null;
	}

	public override void WriteCData(string data)
	{
		CheckState();
		if (current == null)
		{
			throw new InvalidOperationException("Current state is not acceptable for CDATAsection.");
		}
		current.Add(new XCData(data));
	}

	public override void WriteComment(string comment)
	{
		WritePossiblyTopLevelNode(new XComment(comment), possiblyAttribute: false);
	}

	public override void WriteProcessingInstruction(string name, string value)
	{
		WritePossiblyTopLevelNode(new XProcessingInstruction(name, value), possiblyAttribute: false);
	}

	public override void WriteEntityRef(string name)
	{
		throw new NotSupportedException();
	}

	public override void WriteCharEntity(char c)
	{
		throw new NotSupportedException();
	}

	public override void WriteWhitespace(string ws)
	{
		WritePossiblyTopLevelNode(new XText(ws), possiblyAttribute: true);
	}

	public override void WriteString(string data)
	{
		CheckState();
		if (current == null)
		{
			throw new InvalidOperationException("Current state is not acceptable for Text.");
		}
		if (attribute != null)
		{
			attribute.Value += data;
		}
		else
		{
			current.Add(data);
		}
	}

	public override void WriteName(string name)
	{
		WriteString(name);
	}

	public override void WriteNmToken(string nmtoken)
	{
		WriteString(nmtoken);
	}

	public override void WriteQualifiedName(string name, string ns)
	{
		string text = LookupPrefix(ns);
		if (text == null)
		{
			throw new ArgumentException($"Invalid namespace {ns}");
		}
		if (text != string.Empty)
		{
			WriteString(name);
		}
		else
		{
			WriteString(text + ":" + name);
		}
	}

	public override void WriteChars(char[] chars, int start, int len)
	{
		WriteString(new string(chars, start, len));
	}

	public override void WriteRaw(string data)
	{
		WriteString(data);
	}

	public override void WriteRaw(char[] chars, int start, int len)
	{
		WriteChars(chars, start, len);
	}

	public override void WriteBase64(byte[] data, int start, int len)
	{
		WriteString(Convert.ToBase64String(data, start, len));
	}

	public override void WriteBinHex(byte[] data, int start, int len)
	{
		throw new NotImplementedException();
	}

	public override void WriteSurrogateCharEntity(char c1, char c2)
	{
		throw new NotImplementedException();
	}
}
