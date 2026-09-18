using System.IO;

namespace System.Xml.Linq;

public class XDocument : XContainer
{
	private XDeclaration xmldecl;

	public XDeclaration Declaration
	{
		get
		{
			return xmldecl;
		}
		set
		{
			xmldecl = value;
		}
	}

	public XDocumentType DocumentType
	{
		get
		{
			foreach (XNode item in Nodes())
			{
				if (item is XDocumentType)
				{
					return (XDocumentType)item;
				}
			}
			return null;
		}
	}

	public override XmlNodeType NodeType => XmlNodeType.Document;

	public XElement Root
	{
		get
		{
			foreach (XNode item in Nodes())
			{
				if (item is XElement)
				{
					return (XElement)item;
				}
			}
			return null;
		}
	}

	public XDocument()
	{
	}

	public XDocument(params object[] content)
	{
		Add(content);
	}

	public XDocument(XDeclaration xmldecl, params object[] content)
	{
		Declaration = xmldecl;
		Add(content);
	}

	public XDocument(XDocument other)
	{
		foreach (XNode item in other.Nodes())
		{
			Add(XUtil.Clone(item));
		}
	}

	public static XDocument Load(string uri)
	{
		return Load(uri, LoadOptions.None);
	}

	public static XDocument Load(string uri, LoadOptions options)
	{
		XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
		xmlReaderSettings.IgnoreWhitespace = (options & LoadOptions.PreserveWhitespace) == 0;
		using XmlReader reader = XmlReader.Create(uri, xmlReaderSettings);
		return LoadCore(reader, options);
	}

	public static XDocument Load(Stream stream)
	{
		return Load(new StreamReader(stream), LoadOptions.None);
	}

	public static XDocument Load(Stream stream, LoadOptions options)
	{
		return Load(new StreamReader(stream), options);
	}

	public static XDocument Load(TextReader reader)
	{
		return Load(reader, LoadOptions.None);
	}

	public static XDocument Load(TextReader reader, LoadOptions options)
	{
		XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
		xmlReaderSettings.IgnoreWhitespace = (options & LoadOptions.PreserveWhitespace) == 0;
		using XmlReader reader2 = XmlReader.Create(reader, xmlReaderSettings);
		return LoadCore(reader2, options);
	}

	public static XDocument Load(XmlReader reader)
	{
		return Load(reader, LoadOptions.None);
	}

	public static XDocument Load(XmlReader reader, LoadOptions options)
	{
		XmlReaderSettings xmlReaderSettings = ((reader.Settings == null) ? new XmlReaderSettings() : reader.Settings.Clone());
		xmlReaderSettings.IgnoreWhitespace = (options & LoadOptions.PreserveWhitespace) == 0;
		using XmlReader reader2 = XmlReader.Create(reader, xmlReaderSettings);
		return LoadCore(reader2, options);
	}

	private static XDocument LoadCore(XmlReader reader, LoadOptions options)
	{
		XDocument xDocument = new XDocument();
		xDocument.ReadContent(reader, options);
		return xDocument;
	}

	private void ReadContent(XmlReader reader, LoadOptions options)
	{
		if (reader.ReadState == ReadState.Initial)
		{
			reader.Read();
		}
		if (reader.NodeType == XmlNodeType.XmlDeclaration)
		{
			Declaration = new XDeclaration(reader.GetAttribute("version"), reader.GetAttribute("encoding"), reader.GetAttribute("standalone"));
			reader.Read();
		}
		ReadContentFrom(reader, options);
		if (Root == null)
		{
			throw new InvalidOperationException("The document element is missing.");
		}
	}

	private static void ValidateWhitespace(string s)
	{
		for (int i = 0; i < s.Length; i++)
		{
			switch (s[i])
			{
			case '\t':
			case '\n':
			case '\r':
			case ' ':
				continue;
			}
			throw new ArgumentException("Non-whitespace text appears directly in the document.");
		}
	}

	public static XDocument Parse(string s)
	{
		return Parse(s, LoadOptions.None);
	}

	public static XDocument Parse(string s, LoadOptions options)
	{
		return Load(new StringReader(s), options);
	}

	public void Save(string filename)
	{
		Save(filename, SaveOptions.None);
	}

	public void Save(string filename, SaveOptions options)
	{
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		if ((options & SaveOptions.DisableFormatting) == 0)
		{
			xmlWriterSettings.Indent = true;
		}
		using XmlWriter w = XmlWriter.Create(filename, xmlWriterSettings);
		Save(w);
	}

	public void Save(TextWriter tw)
	{
		Save(tw, SaveOptions.None);
	}

	public void Save(TextWriter tw, SaveOptions options)
	{
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		if ((options & SaveOptions.DisableFormatting) == 0)
		{
			xmlWriterSettings.Indent = true;
		}
		using XmlWriter w = XmlWriter.Create(tw, xmlWriterSettings);
		Save(w);
	}

	public void Save(XmlWriter w)
	{
		WriteTo(w);
	}

	public override void WriteTo(XmlWriter w)
	{
		if (xmldecl != null)
		{
			if (xmldecl.Standalone != null)
			{
				w.WriteStartDocument(xmldecl.Standalone == "yes");
			}
			else
			{
				w.WriteStartDocument();
			}
		}
		foreach (XNode item in Nodes())
		{
			item.WriteTo(w);
		}
	}

	internal override bool OnAddingObject(object obj, bool rejectAttribute, XNode refNode, bool addFirst)
	{
		VerifyAddedNode(obj, addFirst);
		return false;
	}

	private void VerifyAddedNode(object node, bool addFirst)
	{
		if (node == null)
		{
			throw new InvalidOperationException("Only a node is allowed here");
		}
		if (node is string)
		{
			ValidateWhitespace((string)node);
		}
		if (node is XText)
		{
			ValidateWhitespace(((XText)node).Value);
		}
		else if (node is XDocumentType)
		{
			if (DocumentType != null)
			{
				throw new InvalidOperationException("There already is another document type declaration");
			}
			if (Root != null && !addFirst)
			{
				throw new InvalidOperationException("A document type cannot be added after the document element");
			}
		}
		else if (node is XElement)
		{
			if (Root != null)
			{
				throw new InvalidOperationException("There already is another document element");
			}
			if (DocumentType != null && addFirst)
			{
				throw new InvalidOperationException("An element cannot be added before the document type declaration");
			}
		}
	}
}
