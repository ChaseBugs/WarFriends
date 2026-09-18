using System.Text;
using System.Xml.Schema;
using System.Xml.XPath;

namespace System.Xml.Linq;

internal class XNodeNavigator : XPathNavigator
{
	private static readonly XAttribute attr_ns_xml = new XAttribute(XNamespace.Xmlns.GetName("xml"), XNamespace.Xml.NamespaceName);

	private XNode node;

	private XAttribute attr;

	private XmlNameTable name_table;

	public override string BaseURI => node.BaseUri ?? string.Empty;

	public override bool CanEdit => true;

	public override bool HasAttributes => node is XElement xElement && xElement.HasAttributes;

	public override bool HasChildren => node is XContainer xContainer && xContainer.FirstNode != null;

	public override bool IsEmptyElement => node is XElement xElement && xElement.IsEmpty;

	public override string LocalName => NodeType switch
	{
		XPathNodeType.Namespace => (!(attr.Name.Namespace == XNamespace.None)) ? attr.Name.LocalName : string.Empty, 
		XPathNodeType.Attribute => attr.Name.LocalName, 
		XPathNodeType.Element => ((XElement)node).Name.LocalName, 
		XPathNodeType.ProcessingInstruction => ((XProcessingInstruction)node).Target, 
		_ => string.Empty, 
	};

	public override string Name
	{
		get
		{
			XName xName = null;
			switch (NodeType)
			{
			case XPathNodeType.Attribute:
				xName = attr.Name;
				break;
			case XPathNodeType.Element:
				xName = ((XElement)node).Name;
				break;
			default:
				return LocalName;
			}
			if (xName.Namespace == XNamespace.None)
			{
				return xName.LocalName;
			}
			XElement xElement = (node as XElement) ?? node.Parent;
			if (xElement == null)
			{
				return xName.LocalName;
			}
			string prefixOfNamespace = xElement.GetPrefixOfNamespace(xName.Namespace);
			return (prefixOfNamespace.Length <= 0) ? xName.LocalName : (prefixOfNamespace + ":" + xName.LocalName);
		}
	}

	public override string NamespaceURI => NodeType switch
	{
		XPathNodeType.Namespace => attr.Value, 
		XPathNodeType.Attribute => attr.Name.NamespaceName, 
		XPathNodeType.Element => ((XElement)node).Name.NamespaceName, 
		_ => string.Empty, 
	};

	public override XmlNameTable NameTable => name_table;

	public override XPathNodeType NodeType
	{
		get
		{
			if (attr != null)
			{
				return (!attr.IsNamespaceDeclaration) ? XPathNodeType.Attribute : XPathNodeType.Namespace;
			}
			return node.NodeType switch
			{
				XmlNodeType.Element => XPathNodeType.Element, 
				XmlNodeType.Document => XPathNodeType.Root, 
				XmlNodeType.Comment => XPathNodeType.Comment, 
				XmlNodeType.ProcessingInstruction => XPathNodeType.ProcessingInstruction, 
				_ => XPathNodeType.Text, 
			};
		}
	}

	public override string Prefix
	{
		get
		{
			XName xName = null;
			switch (NodeType)
			{
			case XPathNodeType.Attribute:
				xName = attr.Name;
				break;
			case XPathNodeType.Element:
				xName = ((XElement)node).Name;
				break;
			default:
				return LocalName;
			}
			if (xName.Namespace == XNamespace.None)
			{
				return string.Empty;
			}
			XElement xElement = (node as XElement) ?? node.Parent;
			if (xElement == null)
			{
				return string.Empty;
			}
			return xElement.GetPrefixOfNamespace(xName.Namespace);
		}
	}

	public override IXmlSchemaInfo SchemaInfo => null;

	public override object UnderlyingObject => (attr == null) ? ((XObject)node) : ((XObject)attr);

	public override string Value
	{
		get
		{
			if (attr != null)
			{
				return attr.Value;
			}
			switch (NodeType)
			{
			case XPathNodeType.Comment:
				return ((XComment)node).Value;
			case XPathNodeType.ProcessingInstruction:
				return ((XProcessingInstruction)node).Data;
			case XPathNodeType.Text:
				return ((XText)node).Value;
			case XPathNodeType.Root:
			case XPathNodeType.Element:
				return GetInnerText((XContainer)node);
			default:
				return string.Empty;
			}
		}
	}

	public XNodeNavigator(XNode node, XmlNameTable nameTable)
	{
		this.node = node;
		name_table = nameTable;
	}

	public XNodeNavigator(XNodeNavigator other)
	{
		node = other.node;
		attr = other.attr;
		name_table = other.name_table;
	}

	private string GetInnerText(XContainer node)
	{
		StringBuilder sb = null;
		foreach (XNode item in node.Nodes())
		{
			GetInnerText(item, ref sb);
		}
		return (sb == null) ? string.Empty : sb.ToString();
	}

	private void GetInnerText(XNode n, ref StringBuilder sb)
	{
		switch (n.NodeType)
		{
		case XmlNodeType.Element:
		{
			foreach (XNode item in ((XElement)n).Nodes())
			{
				GetInnerText(item, ref sb);
			}
			break;
		}
		case XmlNodeType.Text:
		case XmlNodeType.CDATA:
			if (sb == null)
			{
				sb = new StringBuilder();
			}
			sb.Append(((XText)n).Value);
			break;
		case XmlNodeType.Attribute:
			break;
		}
	}

	public override XPathNavigator Clone()
	{
		return new XNodeNavigator(this);
	}

	public override bool IsSamePosition(XPathNavigator other)
	{
		if (!(other is XNodeNavigator xNodeNavigator) || xNodeNavigator.node.Owner != node.Owner)
		{
			return false;
		}
		return node == xNodeNavigator.node && attr == xNodeNavigator.attr;
	}

	public override bool MoveTo(XPathNavigator other)
	{
		if (!(other is XNodeNavigator xNodeNavigator) || xNodeNavigator.node.Owner != node.Owner)
		{
			return false;
		}
		node = xNodeNavigator.node;
		attr = xNodeNavigator.attr;
		return true;
	}

	public override bool MoveToFirstAttribute()
	{
		if (!(node is XElement { HasAttributes: not false } xElement))
		{
			return false;
		}
		foreach (XAttribute item in xElement.Attributes())
		{
			if (!item.IsNamespaceDeclaration)
			{
				attr = item;
				return true;
			}
		}
		return false;
	}

	public override bool MoveToFirstChild()
	{
		if (!(node is XContainer xContainer))
		{
			return false;
		}
		node = xContainer.FirstNode;
		attr = null;
		return true;
	}

	public override bool MoveToFirstNamespace(XPathNamespaceScope scope)
	{
		for (XElement xElement = node as XElement; xElement != null; xElement = xElement.Parent)
		{
			foreach (XAttribute item in xElement.Attributes())
			{
				if (item.IsNamespaceDeclaration)
				{
					attr = item;
					return true;
				}
			}
			if (scope == XPathNamespaceScope.Local)
			{
				return false;
			}
		}
		if (scope != XPathNamespaceScope.All)
		{
			return false;
		}
		attr = attr_ns_xml;
		return true;
	}

	public override bool MoveToId(string id)
	{
		throw new NotSupportedException("This XPathNavigator does not support IDs");
	}

	public override bool MoveToNext()
	{
		if (node.NextNode == null)
		{
			return false;
		}
		node = node.NextNode;
		attr = null;
		return true;
	}

	public override bool MoveToNextAttribute()
	{
		if (attr == null)
		{
			return false;
		}
		if (attr.NextAttribute == null)
		{
			return false;
		}
		for (XAttribute nextAttribute = attr.NextAttribute; nextAttribute != null; nextAttribute = nextAttribute.NextAttribute)
		{
			if (!nextAttribute.IsNamespaceDeclaration)
			{
				attr = nextAttribute;
				return true;
			}
		}
		return false;
	}

	public override bool MoveToNextNamespace(XPathNamespaceScope scope)
	{
		if (attr == null)
		{
			return false;
		}
		for (XAttribute nextAttribute = attr.NextAttribute; nextAttribute != null; nextAttribute = nextAttribute.NextAttribute)
		{
			if (nextAttribute.IsNamespaceDeclaration)
			{
				attr = nextAttribute;
				return true;
			}
		}
		if (scope == XPathNamespaceScope.Local)
		{
			return false;
		}
		for (XElement parent = attr.Parent.Parent; parent != null; parent = parent.Parent)
		{
			foreach (XAttribute item in parent.Attributes())
			{
				if (item.IsNamespaceDeclaration)
				{
					attr = item;
					return true;
				}
			}
		}
		if (scope != XPathNamespaceScope.All)
		{
			return false;
		}
		attr = attr_ns_xml;
		return true;
	}

	public override bool MoveToParent()
	{
		if (attr != null)
		{
			attr = null;
			return true;
		}
		if (node.Parent == null)
		{
			return false;
		}
		node = node.Parent;
		return true;
	}

	public override bool MoveToPrevious()
	{
		if (node.PreviousNode == null)
		{
			return false;
		}
		node = node.PreviousNode;
		attr = null;
		return true;
	}

	public override void MoveToRoot()
	{
		node = node.Owner;
		attr = null;
	}
}
