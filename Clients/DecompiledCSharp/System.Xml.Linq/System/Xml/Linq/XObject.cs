using System.Collections.Generic;

namespace System.Xml.Linq;

public abstract class XObject : IXmlLineInfo
{
	private XContainer owner;

	private List<object> annotations;

	private string baseuri;

	private int line;

	private int column;

	int IXmlLineInfo.LineNumber => LineNumber;

	int IXmlLineInfo.LinePosition => LinePosition;

	public string BaseUri
	{
		get
		{
			return baseuri;
		}
		internal set
		{
			baseuri = value;
		}
	}

	public XDocument Document
	{
		get
		{
			if (this is XDocument)
			{
				return (XDocument)this;
			}
			for (XContainer xContainer = owner; xContainer != null; xContainer = xContainer.owner)
			{
				if (xContainer is XDocument)
				{
					return (XDocument)xContainer;
				}
			}
			return null;
		}
	}

	public abstract XmlNodeType NodeType { get; }

	public XElement Parent => owner as XElement;

	internal XContainer Owner => owner;

	internal int LineNumber
	{
		get
		{
			return line;
		}
		set
		{
			line = value;
		}
	}

	internal int LinePosition
	{
		get
		{
			return column;
		}
		set
		{
			column = value;
		}
	}

	public event EventHandler<XObjectChangeEventArgs> Changing;

	public event EventHandler<XObjectChangeEventArgs> Changed;

	internal XObject()
	{
	}

	bool IXmlLineInfo.HasLineInfo()
	{
		return line > 0;
	}

	internal void SetOwner(XContainer node)
	{
		owner = node;
	}

	public void AddAnnotation(object annotation)
	{
		if (annotation == null)
		{
			throw new ArgumentNullException("annotation");
		}
		if (annotations == null)
		{
			annotations = new List<object>();
		}
		annotations.Add(annotation);
	}

	public T Annotation<T>() where T : class
	{
		return (T)Annotation(typeof(T));
	}

	public object Annotation(Type type)
	{
		if (annotations != null)
		{
			foreach (object annotation in annotations)
			{
				if (annotation.GetType() == type)
				{
					return annotation;
				}
			}
		}
		return null;
	}

	public IEnumerable<T> Annotations<T>() where T : class
	{
		foreach (T item in Annotations(typeof(T)))
		{
			yield return item;
		}
	}

	public IEnumerable<object> Annotations(Type type)
	{
		if (annotations == null)
		{
			yield break;
		}
		foreach (object o in annotations)
		{
			if (o.GetType() == type)
			{
				yield return o;
			}
		}
	}

	public void RemoveAnnotations<T>() where T : class
	{
		RemoveAnnotations(typeof(T));
	}

	public void RemoveAnnotations(Type type)
	{
		if (annotations == null)
		{
			return;
		}
		for (int i = 0; i < annotations.Count; i++)
		{
			if (annotations[i].GetType() == type)
			{
				annotations.RemoveAt(i);
			}
		}
	}

	internal void FillLineInfoAndBaseUri(XmlReader r, LoadOptions options)
	{
		if ((options & LoadOptions.SetLineInfo) != LoadOptions.None && r is IXmlLineInfo xmlLineInfo && xmlLineInfo.HasLineInfo())
		{
			LineNumber = xmlLineInfo.LineNumber;
			LinePosition = xmlLineInfo.LinePosition;
		}
		if ((options & LoadOptions.SetBaseUri) != LoadOptions.None)
		{
			BaseUri = r.BaseURI;
		}
	}
}
