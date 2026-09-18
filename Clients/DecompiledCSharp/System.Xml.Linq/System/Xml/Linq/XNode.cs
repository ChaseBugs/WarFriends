using System.Collections.Generic;
using System.IO;

namespace System.Xml.Linq;

public abstract class XNode : XObject
{
	private static XNodeEqualityComparer eq_comparer = new XNodeEqualityComparer();

	private static XNodeDocumentOrderComparer order_comparer = new XNodeDocumentOrderComparer();

	private XNode previous;

	private XNode next;

	public static XNodeDocumentOrderComparer DocumentOrderComparer => order_comparer;

	public static XNodeEqualityComparer EqualityComparer => eq_comparer;

	public XNode PreviousNode
	{
		get
		{
			return previous;
		}
		internal set
		{
			previous = value;
		}
	}

	public XNode NextNode
	{
		get
		{
			return next;
		}
		internal set
		{
			next = value;
		}
	}

	internal XNode()
	{
	}

	public static int CompareDocumentOrder(XNode n1, XNode n2)
	{
		return order_comparer.Compare(n1, n2);
	}

	public static bool DeepEquals(XNode n1, XNode n2)
	{
		return eq_comparer.Equals(n1, n2);
	}

	public string ToString(SaveOptions options)
	{
		StringWriter stringWriter = new StringWriter();
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.ConformanceLevel = ConformanceLevel.Auto;
		xmlWriterSettings.Indent = options != SaveOptions.DisableFormatting;
		XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings);
		WriteTo(xmlWriter);
		xmlWriter.Close();
		return stringWriter.ToString();
	}

	public void AddAfterSelf(object content)
	{
		if (base.Parent == null)
		{
			throw new InvalidOperationException();
		}
		XNode xNode = this;
		XNode xNode2 = next;
		foreach (object item in XUtil.ExpandArray(content))
		{
			if (!base.Owner.OnAddingObject(item, rejectAttribute: true, xNode, addFirst: false))
			{
				XNode child = XUtil.ToNode(item);
				child = (XNode)XUtil.GetDetachedObject(child);
				child.SetOwner(base.Parent);
				child.previous = xNode;
				xNode.next = child;
				child.next = xNode2;
				if (xNode2 != null)
				{
					xNode2.previous = child;
				}
				else
				{
					base.Parent.LastNode = child;
				}
				xNode = child;
			}
		}
	}

	public void AddAfterSelf(params object[] content)
	{
		if (base.Parent == null)
		{
			throw new InvalidOperationException();
		}
		AddAfterSelf((object)content);
	}

	public void AddBeforeSelf(object content)
	{
		if (base.Parent == null)
		{
			throw new InvalidOperationException();
		}
		foreach (object item in XUtil.ExpandArray(content))
		{
			if (!base.Owner.OnAddingObject(item, rejectAttribute: true, previous, addFirst: true))
			{
				XNode child = XUtil.ToNode(item);
				child = (XNode)XUtil.GetDetachedObject(child);
				child.SetOwner(base.Parent);
				child.previous = previous;
				child.next = this;
				if (previous != null)
				{
					previous.next = child;
				}
				previous = child;
				if (base.Parent.FirstNode == this)
				{
					base.Parent.FirstNode = child;
				}
			}
		}
	}

	public void AddBeforeSelf(params object[] content)
	{
		if (base.Parent == null)
		{
			throw new InvalidOperationException();
		}
		AddBeforeSelf((object)content);
	}

	public static XNode ReadFrom(XmlReader r)
	{
		return ReadFrom(r, LoadOptions.None);
	}

	internal static XNode ReadFrom(XmlReader r, LoadOptions options)
	{
		switch (r.NodeType)
		{
		case XmlNodeType.Element:
			return XElement.LoadCore(r, options);
		case XmlNodeType.Text:
		case XmlNodeType.Whitespace:
		case XmlNodeType.SignificantWhitespace:
		{
			XText xText = new XText(r.Value);
			xText.FillLineInfoAndBaseUri(r, options);
			r.Read();
			return xText;
		}
		case XmlNodeType.CDATA:
		{
			XCData xCData = new XCData(r.Value);
			xCData.FillLineInfoAndBaseUri(r, options);
			r.Read();
			return xCData;
		}
		case XmlNodeType.ProcessingInstruction:
		{
			XProcessingInstruction xProcessingInstruction = new XProcessingInstruction(r.Name, r.Value);
			xProcessingInstruction.FillLineInfoAndBaseUri(r, options);
			r.Read();
			return xProcessingInstruction;
		}
		case XmlNodeType.Comment:
		{
			XComment xComment = new XComment(r.Value);
			xComment.FillLineInfoAndBaseUri(r, options);
			r.Read();
			return xComment;
		}
		case XmlNodeType.DocumentType:
		{
			XDocumentType xDocumentType = new XDocumentType(r.Name, r.GetAttribute("PUBLIC"), r.GetAttribute("SYSTEM"), r.Value);
			xDocumentType.FillLineInfoAndBaseUri(r, options);
			r.Read();
			return xDocumentType;
		}
		default:
			throw new InvalidOperationException($"Node type {r.NodeType} is not supported");
		}
	}

	public void Remove()
	{
		if (base.Parent == null)
		{
			throw new InvalidOperationException("Parent is missing");
		}
		if (base.Parent.FirstNode == this)
		{
			base.Parent.FirstNode = next;
		}
		if (base.Parent.LastNode == this)
		{
			base.Parent.LastNode = previous;
		}
		if (previous != null)
		{
			previous.next = next;
		}
		if (next != null)
		{
			next.previous = previous;
		}
		previous = null;
		next = null;
		SetOwner(null);
	}

	public override string ToString()
	{
		return ToString(SaveOptions.None);
	}

	public abstract void WriteTo(XmlWriter w);

	public IEnumerable<XElement> Ancestors()
	{
		for (XElement el = base.Parent; el != null; el = el.Parent)
		{
			yield return el;
		}
	}

	public IEnumerable<XElement> Ancestors(XName name)
	{
		foreach (XElement el in Ancestors())
		{
			if (el.Name == name)
			{
				yield return el;
			}
		}
	}

	public XmlReader CreateReader()
	{
		return new XNodeReader(this);
	}

	public IEnumerable<XElement> ElementsAfterSelf()
	{
		foreach (XNode n in NodesAfterSelf())
		{
			if (n is XElement)
			{
				yield return (XElement)n;
			}
		}
	}

	public IEnumerable<XElement> ElementsAfterSelf(XName name)
	{
		foreach (XElement el in ElementsAfterSelf())
		{
			if (el.Name == name)
			{
				yield return el;
			}
		}
	}

	public IEnumerable<XElement> ElementsBeforeSelf()
	{
		foreach (XNode n in NodesBeforeSelf())
		{
			if (n is XElement)
			{
				yield return (XElement)n;
			}
		}
	}

	public IEnumerable<XElement> ElementsBeforeSelf(XName name)
	{
		foreach (XElement el in ElementsBeforeSelf())
		{
			if (el.Name == name)
			{
				yield return el;
			}
		}
	}

	public bool IsAfter(XNode other)
	{
		return DocumentOrderComparer.Compare(this, other) > 0;
	}

	public bool IsBefore(XNode other)
	{
		return DocumentOrderComparer.Compare(this, other) < 0;
	}

	public IEnumerable<XNode> NodesAfterSelf()
	{
		if (base.Parent != null)
		{
			for (XNode n = NextNode; n != null; n = n.NextNode)
			{
				yield return n;
			}
		}
	}

	public IEnumerable<XNode> NodesBeforeSelf()
	{
		for (XNode n = base.Parent.FirstNode; n != this; n = n.NextNode)
		{
			yield return n;
		}
	}

	public void ReplaceWith(object item)
	{
		AddAfterSelf(item);
		Remove();
	}

	public void ReplaceWith(params object[] items)
	{
		AddAfterSelf(items);
		Remove();
	}
}
