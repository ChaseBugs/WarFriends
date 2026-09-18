using System.Collections.Generic;

namespace System.Xml.Linq;

public static class Extensions
{
	public static IEnumerable<XElement> Ancestors<T>(this IEnumerable<T> source) where T : XNode
	{
		foreach (T item2 in source)
		{
			T item = item2;
			for (XElement n = item.Parent; n != null; n = n.Parent)
			{
				yield return n;
			}
		}
	}

	public static IEnumerable<XElement> Ancestors<T>(this IEnumerable<T> source, XName name) where T : XNode
	{
		foreach (T item2 in source)
		{
			T item = item2;
			for (XElement n = item.Parent; n != null; n = n.Parent)
			{
				if (n.Name == name)
				{
					yield return n;
				}
			}
		}
	}

	public static IEnumerable<XElement> AncestorsAndSelf(this IEnumerable<XElement> source)
	{
		foreach (XElement item in source)
		{
			for (XElement n = item; n != null; n = n.Parent)
			{
				yield return n;
			}
		}
	}

	public static IEnumerable<XElement> AncestorsAndSelf(this IEnumerable<XElement> source, XName name)
	{
		foreach (XElement item in source)
		{
			for (XElement n = item; n != null; n = n.Parent)
			{
				if (n.Name == name)
				{
					yield return n;
				}
			}
		}
	}

	public static IEnumerable<XAttribute> Attributes(this IEnumerable<XElement> source)
	{
		foreach (XElement item in source)
		{
			foreach (XAttribute item2 in item.Attributes())
			{
				yield return item2;
			}
		}
	}

	public static IEnumerable<XAttribute> Attributes(this IEnumerable<XElement> source, XName name)
	{
		foreach (XElement item in source)
		{
			foreach (XAttribute item2 in item.Attributes(name))
			{
				yield return item2;
			}
		}
	}

	public static IEnumerable<XNode> DescendantNodes<T>(this IEnumerable<T> source) where T : XContainer
	{
		foreach (T item in source)
		{
			foreach (XNode item2 in item.DescendantNodes())
			{
				yield return item2;
			}
		}
	}

	public static IEnumerable<XNode> DescendantNodesAndSelf(this IEnumerable<XElement> source)
	{
		foreach (XElement item in source)
		{
			foreach (XNode item2 in item.DescendantNodesAndSelf())
			{
				yield return item2;
			}
		}
	}

	public static IEnumerable<XElement> Descendants<T>(this IEnumerable<T> source) where T : XContainer
	{
		foreach (T item in source)
		{
			foreach (XElement item2 in item.Descendants())
			{
				yield return item2;
			}
		}
	}

	public static IEnumerable<XElement> Descendants<T>(this IEnumerable<T> source, XName name) where T : XContainer
	{
		foreach (T item in source)
		{
			foreach (XElement item2 in item.Descendants(name))
			{
				yield return item2;
			}
		}
	}

	public static IEnumerable<XElement> DescendantsAndSelf(this IEnumerable<XElement> source)
	{
		foreach (XElement item in source)
		{
			foreach (XElement item2 in item.DescendantsAndSelf())
			{
				yield return item2;
			}
		}
	}

	public static IEnumerable<XElement> DescendantsAndSelf(this IEnumerable<XElement> source, XName name)
	{
		foreach (XElement item in source)
		{
			foreach (XElement item2 in item.DescendantsAndSelf(name))
			{
				yield return item2;
			}
		}
	}

	public static IEnumerable<XElement> Elements<T>(this IEnumerable<T> source) where T : XContainer
	{
		foreach (T item in source)
		{
			foreach (XElement item2 in item.Elements())
			{
				yield return item2;
			}
		}
	}

	public static IEnumerable<XElement> Elements<T>(this IEnumerable<T> source, XName name) where T : XContainer
	{
		foreach (T item in source)
		{
			foreach (XElement item2 in item.Elements(name))
			{
				yield return item2;
			}
		}
	}

	public static IEnumerable<T> InDocumentOrder<T>(this IEnumerable<T> source) where T : XNode
	{
		List<XNode> list = new List<XNode>();
		foreach (T n in source)
		{
			list.Add(n);
		}
		list.Sort(XNode.DocumentOrderComparer);
		foreach (T item in list)
		{
			yield return item;
		}
	}

	public static IEnumerable<XNode> Nodes<T>(this IEnumerable<T> source) where T : XContainer
	{
		foreach (T item in source)
		{
			foreach (XNode item2 in item.Nodes())
			{
				yield return item2;
			}
		}
	}

	public static void Remove(this IEnumerable<XAttribute> source)
	{
		foreach (XAttribute item in source)
		{
			item.Remove();
		}
	}

	public static void Remove<T>(this IEnumerable<T> source) where T : XNode
	{
		foreach (T item in source)
		{
			T current = item;
			current.Remove();
		}
	}
}
