using System.Collections.Generic;
using System.IO;

namespace System.Xml.Linq;

public class XStreamingElement
{
	private XName name;

	private List<object> contents;

	public XName Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}

	internal IEnumerable<object> Contents => contents;

	public XStreamingElement(XName name)
	{
		Name = name;
	}

	public XStreamingElement(XName name, object content)
		: this(name)
	{
		Add(content);
	}

	public XStreamingElement(XName name, params object[] content)
		: this(name)
	{
		Add(content);
	}

	public void Add(object content)
	{
		if (contents == null)
		{
			contents = new List<object>();
		}
		contents.Add(content);
	}

	public void Add(params object[] content)
	{
		if (contents == null)
		{
			contents = new List<object>();
		}
		contents.Add(content);
	}

	public void Save(string fileName)
	{
		using TextWriter textWriter = File.CreateText(fileName);
		Save(textWriter);
	}

	public void Save(TextWriter textWriter)
	{
		Save(textWriter, SaveOptions.None);
	}

	public void Save(XmlWriter writer)
	{
		WriteTo(writer);
	}

	public void Save(string fileName, SaveOptions options)
	{
		using TextWriter textWriter = File.CreateText(fileName);
		Save(textWriter, options);
	}

	public void Save(TextWriter textWriter, SaveOptions options)
	{
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.OmitXmlDeclaration = true;
		xmlWriterSettings.Indent = options != SaveOptions.DisableFormatting;
		using XmlWriter writer = XmlWriter.Create(textWriter, xmlWriterSettings);
		Save(writer);
	}

	public override string ToString()
	{
		return ToString(SaveOptions.None);
	}

	public string ToString(SaveOptions options)
	{
		StringWriter stringWriter = new StringWriter();
		Save(stringWriter, options);
		return stringWriter.ToString();
	}

	public void WriteTo(XmlWriter writer)
	{
		writer.WriteStartElement(name.LocalName, name.Namespace.NamespaceName);
		WriteContents(contents, writer);
		writer.WriteEndElement();
	}

	private void WriteContents(IEnumerable<object> items, XmlWriter w)
	{
		foreach (object item in XUtil.ExpandArray(items))
		{
			if (item != null)
			{
				if (item is XNode)
				{
					((XNode)item).WriteTo(w);
				}
				else if (item is object[])
				{
					WriteContents((object[])item, w);
				}
				else if (item is XAttribute)
				{
					WriteAttribute((XAttribute)item, w);
				}
				else
				{
					new XText(item.ToString()).WriteTo(w);
				}
			}
		}
	}

	private void WriteAttribute(XAttribute a, XmlWriter w)
	{
		if (a.IsNamespaceDeclaration)
		{
			if (a.Name.Namespace == XNamespace.Xmlns)
			{
				w.WriteAttributeString("xmlns", a.Name.LocalName, XNamespace.Xmlns.NamespaceName, a.Value);
			}
			else
			{
				w.WriteAttributeString("xmlns", a.Value);
			}
		}
		else
		{
			w.WriteAttributeString(a.Name.LocalName, a.Name.Namespace.NamespaceName, a.Value);
		}
	}
}
