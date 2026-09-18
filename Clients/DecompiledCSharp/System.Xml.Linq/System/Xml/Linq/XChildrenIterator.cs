using System.Collections;
using System.Collections.Generic;

namespace System.Xml.Linq;

internal class XChildrenIterator : IEnumerable, IEnumerable<object>
{
	private XContainer source;

	private XNode n;

	public XChildrenIterator(XContainer source)
	{
		this.source = source;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<object> GetEnumerator()
	{
		if (n == null)
		{
			n = source.FirstNode;
			if (n == null)
			{
				yield break;
			}
		}
		do
		{
			yield return n;
			n = n.NextNode;
		}
		while (n != source.LastNode);
	}
}
