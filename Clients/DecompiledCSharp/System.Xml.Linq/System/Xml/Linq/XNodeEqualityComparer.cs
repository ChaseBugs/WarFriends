using System.Collections;
using System.Collections.Generic;

namespace System.Xml.Linq;

public sealed class XNodeEqualityComparer : IEqualityComparer, IEqualityComparer<XNode>
{
	bool IEqualityComparer.Equals(object n1, object n2)
	{
		return Equals((XNode)n1, (XNode)n2);
	}

	int IEqualityComparer.GetHashCode(object node)
	{
		return GetHashCode((XNode)node);
	}

	public bool Equals(XNode n1, XNode n2)
	{
		if (n1 == null)
		{
			return n2 == null;
		}
		if (n2 == null)
		{
			return false;
		}
		if (n1.NodeType != n2.NodeType)
		{
			return false;
		}
		switch (n1.NodeType)
		{
		case XmlNodeType.Document:
		{
			XDocument xDocument = (XDocument)n1;
			XDocument xDocument2 = (XDocument)n2;
			if (!Equals(xDocument.Declaration, xDocument2.Declaration))
			{
				return false;
			}
			IEnumerator<XNode> enumerator5 = xDocument2.Nodes().GetEnumerator();
			foreach (XNode item in xDocument.Nodes())
			{
				if (!enumerator5.MoveNext())
				{
					return false;
				}
				if (!Equals(item, enumerator5.Current))
				{
					return false;
				}
			}
			return !enumerator5.MoveNext();
		}
		case XmlNodeType.Element:
		{
			XElement xElement = (XElement)n1;
			XElement xElement2 = (XElement)n2;
			if (xElement.Name != xElement2.Name)
			{
				return false;
			}
			IEnumerator<XAttribute> enumerator = xElement2.Attributes().GetEnumerator();
			foreach (XAttribute item2 in xElement.Attributes())
			{
				if (!enumerator.MoveNext())
				{
					return false;
				}
				if (!Equals(item2, enumerator.Current))
				{
					return false;
				}
			}
			if (enumerator.MoveNext())
			{
				return false;
			}
			IEnumerator<XNode> enumerator3 = xElement2.Nodes().GetEnumerator();
			foreach (XNode item3 in xElement.Nodes())
			{
				if (!enumerator3.MoveNext())
				{
					return false;
				}
				if (!Equals(item3, enumerator3.Current))
				{
					return false;
				}
			}
			return !enumerator3.MoveNext();
		}
		case XmlNodeType.Comment:
		{
			XComment xComment = (XComment)n1;
			XComment xComment2 = (XComment)n2;
			return xComment.Value == xComment2.Value;
		}
		case XmlNodeType.ProcessingInstruction:
		{
			XProcessingInstruction xProcessingInstruction = (XProcessingInstruction)n1;
			XProcessingInstruction xProcessingInstruction2 = (XProcessingInstruction)n2;
			return xProcessingInstruction.Target == xProcessingInstruction2.Target && xProcessingInstruction.Data == xProcessingInstruction2.Data;
		}
		case XmlNodeType.DocumentType:
		{
			XDocumentType xDocumentType = (XDocumentType)n1;
			XDocumentType xDocumentType2 = (XDocumentType)n2;
			return xDocumentType.Name == xDocumentType2.Name && xDocumentType.PublicId == xDocumentType2.PublicId && xDocumentType.SystemId == xDocumentType2.SystemId && xDocumentType.InternalSubset == xDocumentType2.InternalSubset;
		}
		case XmlNodeType.Text:
			return ((XText)n1).Value == ((XText)n2).Value;
		default:
			throw new Exception("INTERNAL ERROR: should not happen");
		}
	}

	private bool Equals(XAttribute a1, XAttribute a2)
	{
		if (a1 == null)
		{
			return a2 == null;
		}
		if (a2 == null)
		{
			return false;
		}
		return a1.Name == a2.Name && a1.Value == a2.Value;
	}

	private bool Equals(XDeclaration d1, XDeclaration d2)
	{
		if (d1 == null)
		{
			return d2 == null;
		}
		if (d2 == null)
		{
			return false;
		}
		return d1.Version == d2.Version && d1.Encoding == d2.Encoding && d1.Standalone == d2.Standalone;
	}

	private int GetHashCode(XDeclaration d)
	{
		if (d == null)
		{
			return 0;
		}
		return (d.Version.GetHashCode() << 7) ^ (d.Encoding.GetHashCode() << 6) ^ d.Standalone.GetHashCode();
	}

	public int GetHashCode(XNode node)
	{
		if (node == null)
		{
			return 0;
		}
		int num = (int)node.NodeType << 6;
		switch (node.NodeType)
		{
		case XmlNodeType.Document:
		{
			XDocument xDocument = (XDocument)node;
			num ^= GetHashCode(xDocument.Declaration);
			foreach (XNode item in xDocument.Nodes())
			{
				num ^= item.GetHashCode() << 5;
			}
			break;
		}
		case XmlNodeType.Element:
		{
			XElement xElement = (XElement)node;
			num ^= xElement.Name.GetHashCode() << 3;
			foreach (XAttribute item2 in xElement.Attributes())
			{
				num ^= item2.GetHashCode() << 7;
			}
			foreach (XNode item3 in xElement.Nodes())
			{
				num ^= item3.GetHashCode() << 6;
			}
			break;
		}
		case XmlNodeType.Comment:
			num ^= ((XComment)node).Value.GetHashCode();
			break;
		case XmlNodeType.ProcessingInstruction:
		{
			XProcessingInstruction xProcessingInstruction = (XProcessingInstruction)node;
			num ^= (xProcessingInstruction.Target.GetHashCode() << 6) + xProcessingInstruction.Data.GetHashCode();
			break;
		}
		case XmlNodeType.DocumentType:
		{
			XDocumentType xDocumentType = (XDocumentType)node;
			num = num ^ (xDocumentType.Name.GetHashCode() << 7) ^ (xDocumentType.PublicId.GetHashCode() << 6) ^ (xDocumentType.SystemId.GetHashCode() << 5) ^ (xDocumentType.InternalSubset.GetHashCode() << 4);
			break;
		}
		case XmlNodeType.Text:
			num ^= ((XText)node).GetHashCode();
			break;
		}
		return num;
	}
}
