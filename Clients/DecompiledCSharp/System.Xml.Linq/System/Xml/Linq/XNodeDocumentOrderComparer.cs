using System.Collections;
using System.Collections.Generic;

namespace System.Xml.Linq;

public sealed class XNodeDocumentOrderComparer : IComparer, IComparer<XNode>
{
	private enum CompareResult
	{
		Same,
		Random,
		Parent,
		Child,
		Ancestor,
		Descendant,
		Preceding,
		Following
	}

	int IComparer.Compare(object n1, object n2)
	{
		return Compare((XNode)n1, (XNode)n2);
	}

	public int Compare(XNode n1, XNode n2)
	{
		switch (CompareCore(n1, n2))
		{
		case CompareResult.Same:
			return 0;
		case CompareResult.Random:
			return (DateTime.Now.Ticks % 2 == 1) ? 1 : (-1);
		case CompareResult.Parent:
		case CompareResult.Ancestor:
		case CompareResult.Preceding:
			return 1;
		default:
			return -1;
		}
	}

	private CompareResult CompareCore(XNode n1, XNode n2)
	{
		if (n1 == n2)
		{
			return CompareResult.Same;
		}
		if (n1.Owner == null)
		{
			if (n2.Owner == null)
			{
				return CompareResult.Random;
			}
			CompareResult compareResult = CompareCore(n1, n2.Owner);
			switch (compareResult)
			{
			case CompareResult.Same:
				return CompareResult.Child;
			case CompareResult.Child:
			case CompareResult.Descendant:
				return CompareResult.Descendant;
			case CompareResult.Parent:
			case CompareResult.Ancestor:
				throw new Exception("INTERNAL ERROR: should not happen");
			default:
				return compareResult;
			}
		}
		if (n2.Owner == null)
		{
			CompareResult compareResult2 = CompareCore(n2, n1);
			switch (compareResult2)
			{
			case CompareResult.Parent:
				return CompareResult.Child;
			case CompareResult.Child:
				return CompareResult.Parent;
			case CompareResult.Ancestor:
				return CompareResult.Descendant;
			case CompareResult.Descendant:
				return CompareResult.Ancestor;
			case CompareResult.Following:
				return CompareResult.Preceding;
			case CompareResult.Preceding:
				return CompareResult.Following;
			case CompareResult.Same:
			case CompareResult.Random:
				return compareResult2;
			}
		}
		CompareResult compareResult3 = CompareCore(n1.Owner, n2.Owner);
		switch (compareResult3)
		{
		case CompareResult.Same:
			return CompareSibling(n1, n2, CompareResult.Same);
		case CompareResult.Child:
			return CompareSibling(n1, n2.Owner, CompareResult.Child);
		case CompareResult.Parent:
			return CompareSibling(n1.Owner, n2, CompareResult.Parent);
		case CompareResult.Descendant:
		{
			XNode xNode2 = n2;
			while (xNode2.Owner != n1.Owner)
			{
				xNode2 = xNode2.Owner;
			}
			return CompareSibling(n1, xNode2, CompareResult.Descendant);
		}
		case CompareResult.Ancestor:
		{
			XNode xNode = n1;
			while (xNode.Owner != n2.Owner)
			{
				xNode = xNode.Owner;
			}
			return CompareSibling(xNode, n2, CompareResult.Ancestor);
		}
		default:
			return compareResult3;
		}
	}

	private CompareResult CompareSibling(XNode n1, XNode n2, CompareResult forSameValue)
	{
		if (n1 == n2)
		{
			return forSameValue;
		}
		for (XNode nextNode = n1.NextNode; nextNode != null; nextNode = nextNode.NextNode)
		{
			if (nextNode == n2)
			{
				return CompareResult.Following;
			}
		}
		return CompareResult.Preceding;
	}
}
