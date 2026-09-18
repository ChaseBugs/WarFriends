using System.Collections;
using System.Collections.Generic;

namespace System.Xml.Linq;

public abstract class XContainer : XNode
{
	private XNode first;

	private XNode last;

	public XNode FirstNode
	{
		get
		{
			return first;
		}
		internal set
		{
			first = value;
		}
	}

	public XNode LastNode
	{
		get
		{
			return last;
		}
		internal set
		{
			last = value;
		}
	}

	internal XContainer()
	{
	}

	private void CheckChildType(object o, bool addFirst)
	{
		if (o == null || o is string || o is XNode)
		{
			return;
		}
		if (o is IEnumerable)
		{
			foreach (object item in (IEnumerable)o)
			{
				CheckChildType(item, addFirst);
			}
			return;
		}
		throw new ArgumentException("Invalid child type: " + o.GetType());
	}

	public void Add(object content)
	{
		if (content == null)
		{
			return;
		}
		foreach (object item in XUtil.ExpandArray(content))
		{
			if (!OnAddingObject(item, rejectAttribute: false, last, addFirst: false))
			{
				AddNode(XUtil.ToNode(item));
			}
		}
	}

	private void AddNode(XNode n)
	{
		CheckChildType(n, addFirst: false);
		n = (XNode)XUtil.GetDetachedObject(n);
		n.SetOwner(this);
		if (first == null)
		{
			last = (first = n);
			return;
		}
		last.NextNode = n;
		n.PreviousNode = last;
		last = n;
	}

	public void Add(params object[] content)
	{
		if (content == null)
		{
			return;
		}
		foreach (object item in XUtil.ExpandArray(content))
		{
			Add(item);
		}
	}

	public void AddFirst(object content)
	{
		if (first == null)
		{
			Add(content);
		}
		else
		{
			first.AddBeforeSelf(XUtil.ExpandArray(content));
		}
	}

	public void AddFirst(params object[] content)
	{
		if (content == null)
		{
			return;
		}
		if (first == null)
		{
			Add(content);
			return;
		}
		foreach (object item in XUtil.ExpandArray(content))
		{
			if (!OnAddingObject(item, rejectAttribute: false, first.PreviousNode, addFirst: true))
			{
				first.AddBeforeSelf(item);
			}
		}
	}

	internal virtual bool OnAddingObject(object o, bool rejectAttribute, XNode refNode, bool addFirst)
	{
		return false;
	}

	public XmlWriter CreateWriter()
	{
		return new XNodeWriter(this);
	}

	public IEnumerable<XNode> Nodes()
	{
		XNode n = FirstNode;
		while (n != null)
		{
			XNode next = n.NextNode;
			yield return n;
			n = next;
		}
	}

	public IEnumerable<XNode> DescendantNodes()
	{
		foreach (XNode n in Nodes())
		{
			yield return n;
			if (!(n is XContainer c))
			{
				continue;
			}
			foreach (XNode item in c.DescendantNodes())
			{
				yield return item;
			}
		}
	}

	public IEnumerable<XElement> Descendants()
	{
		foreach (XNode n in DescendantNodes())
		{
			if (n is XElement el)
			{
				yield return el;
			}
		}
	}

	public IEnumerable<XElement> Descendants(XName name)
	{
		foreach (XElement el in Descendants())
		{
			if (el.Name == name)
			{
				yield return el;
			}
		}
	}

	public IEnumerable<XElement> Elements()
	{
		foreach (XNode n in Nodes())
		{
			if (n is XElement el)
			{
				yield return el;
			}
		}
	}

	public IEnumerable<XElement> Elements(XName name)
	{
		foreach (XElement el in Elements())
		{
			if (el.Name == name)
			{
				yield return el;
			}
		}
	}

	public XElement Element(XName name)
	{
		foreach (XElement item in Elements())
		{
			if (item.Name == name)
			{
				return item;
			}
		}
		return null;
	}

	internal void ReadContentFrom(XmlReader reader, LoadOptions options)
	{
		while (!reader.EOF && reader.NodeType != XmlNodeType.EndElement)
		{
			Add(XNode.ReadFrom(reader, options));
		}
	}

	public void RemoveNodes()
	{
		foreach (XNode item in Nodes())
		{
			item.Remove();
		}
	}

	public void ReplaceNodes(object content)
	{
		XNode firstNode = FirstNode;
		XNode lastNode = LastNode;
		Add(content);
		if (firstNode != null)
		{
			XNode xNode = firstNode;
			while (xNode != lastNode)
			{
				XNode nextNode = xNode.NextNode;
				xNode.Remove();
				xNode = nextNode;
			}
			lastNode.Remove();
		}
	}

	public void ReplaceNodes(params object[] content)
	{
		ReplaceNodes((object)content);
	}
}
