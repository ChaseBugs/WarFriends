using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace System.Xml.Linq;

[XmlSchemaProvider(null, IsAny = true)]
public class XElement : XContainer, IXmlSerializable
{
	private static IEnumerable<XElement> emptySequence = new List<XElement>();

	private XName name;

	private XAttribute attr_first;

	private XAttribute attr_last;

	private bool explicit_is_empty = true;

	public static IEnumerable<XElement> EmptySequence => emptySequence;

	public XAttribute FirstAttribute
	{
		get
		{
			return attr_first;
		}
		internal set
		{
			attr_first = value;
		}
	}

	public XAttribute LastAttribute
	{
		get
		{
			return attr_last;
		}
		internal set
		{
			attr_last = value;
		}
	}

	public bool HasAttributes => attr_first != null;

	public bool HasElements
	{
		get
		{
			foreach (XNode item in Nodes())
			{
				if (item is XElement)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsEmpty
	{
		get
		{
			return !Nodes().GetEnumerator().MoveNext() && explicit_is_empty;
		}
		internal set
		{
			explicit_is_empty = value;
		}
	}

	public XName Name
	{
		get
		{
			return name;
		}
		set
		{
			if (name == null)
			{
				throw new ArgumentNullException("value");
			}
			name = value;
		}
	}

	public override XmlNodeType NodeType => XmlNodeType.Element;

	public string Value
	{
		get
		{
			StringBuilder stringBuilder = null;
			foreach (XNode item in Nodes())
			{
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder();
				}
				if (item is XText)
				{
					stringBuilder.Append(((XText)item).Value);
				}
				else if (item is XElement)
				{
					stringBuilder.Append(((XElement)item).Value);
				}
			}
			return (stringBuilder != null) ? stringBuilder.ToString() : string.Empty;
		}
		set
		{
			RemoveNodes();
			Add(value);
		}
	}

	public XElement(XName name, object value)
	{
		this.name = name;
		Add(value);
	}

	public XElement(XElement source)
	{
		name = source.name;
		Add(source.Attributes());
		Add(source.Nodes());
	}

	public XElement(XName name)
	{
		this.name = name;
	}

	public XElement(XName name, params object[] contents)
	{
		this.name = name;
		Add(contents);
	}

	public XElement(XStreamingElement source)
	{
		name = source.Name;
		Add(source.Contents);
	}

	void IXmlSerializable.WriteXml(XmlWriter writer)
	{
		Save(writer);
	}

	void IXmlSerializable.ReadXml(XmlReader reader)
	{
		ReadContentFrom(reader, LoadOptions.None);
	}

	XmlSchema IXmlSerializable.GetSchema()
	{
		return null;
	}

	private IEnumerable<XElement> GetAncestorList(XName name, bool getMeIn)
	{
		List<XElement> list = new List<XElement>();
		if (getMeIn)
		{
			list.Add(this);
		}
		for (XElement parent = base.Parent; parent != null; parent = parent.Parent)
		{
			if (name == null || parent.Name == name)
			{
				list.Add(parent);
			}
		}
		return list;
	}

	public XAttribute Attribute(XName name)
	{
		foreach (XAttribute item in Attributes())
		{
			if (item.Name == name)
			{
				return item;
			}
		}
		return null;
	}

	public IEnumerable<XAttribute> Attributes()
	{
		XAttribute a = attr_first;
		while (a != null)
		{
			XAttribute next = a.NextAttribute;
			yield return a;
			a = next;
		}
	}

	public IEnumerable<XAttribute> Attributes(XName name)
	{
		foreach (XAttribute a in Attributes())
		{
			if (a.Name == name)
			{
				yield return a;
			}
		}
	}

	private static void DefineDefaultSettings(XmlReaderSettings settings, LoadOptions options)
	{
		settings.ProhibitDtd = false;
		settings.IgnoreWhitespace = (options & LoadOptions.PreserveWhitespace) == 0;
	}

	private static XmlReaderSettings CreateDefaultSettings(LoadOptions options)
	{
		XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
		DefineDefaultSettings(xmlReaderSettings, options);
		return xmlReaderSettings;
	}

	public static XElement Load(string uri)
	{
		return Load(uri, LoadOptions.None);
	}

	public static XElement Load(string uri, LoadOptions options)
	{
		XmlReaderSettings settings = CreateDefaultSettings(options);
		using XmlReader r = XmlReader.Create(uri, settings);
		return LoadCore(r, options);
	}

	public static XElement Load(TextReader tr)
	{
		return Load(tr, LoadOptions.None);
	}

	public static XElement Load(TextReader tr, LoadOptions options)
	{
		XmlReaderSettings settings = CreateDefaultSettings(options);
		using XmlReader r = XmlReader.Create(tr, settings);
		return LoadCore(r, options);
	}

	public static XElement Load(XmlReader reader)
	{
		return Load(reader, LoadOptions.None);
	}

	public static XElement Load(XmlReader reader, LoadOptions options)
	{
		XmlReaderSettings settings = ((reader.Settings == null) ? new XmlReaderSettings() : reader.Settings.Clone());
		DefineDefaultSettings(settings, options);
		using XmlReader r = XmlReader.Create(reader, settings);
		return LoadCore(r, options);
	}

	internal static XElement LoadCore(XmlReader r, LoadOptions options)
	{
		r.MoveToContent();
		if (r.NodeType != XmlNodeType.Element)
		{
			throw new InvalidOperationException("The XmlReader must be positioned at an element");
		}
		XName xName = XName.Get(r.LocalName, r.NamespaceURI);
		XElement xElement = new XElement(xName);
		xElement.FillLineInfoAndBaseUri(r, options);
		if (r.MoveToFirstAttribute())
		{
			do
			{
				if (r.LocalName == "xmlns" && r.NamespaceURI == XNamespace.Xmlns.NamespaceName)
				{
					xElement.SetAttributeValue(XNamespace.None.GetName("xmlns"), r.Value);
				}
				else
				{
					xElement.SetAttributeValue(XName.Get(r.LocalName, r.NamespaceURI), r.Value);
				}
				xElement.LastAttribute.FillLineInfoAndBaseUri(r, options);
			}
			while (r.MoveToNextAttribute());
			r.MoveToElement();
		}
		if (!r.IsEmptyElement)
		{
			r.Read();
			xElement.ReadContentFrom(r, options);
			r.ReadEndElement();
			xElement.explicit_is_empty = false;
		}
		else
		{
			xElement.explicit_is_empty = true;
			r.Read();
		}
		return xElement;
	}

	public static XElement Parse(string s)
	{
		return Parse(s, LoadOptions.None);
	}

	public static XElement Parse(string s, LoadOptions options)
	{
		return Load(new StringReader(s), options);
	}

	public void RemoveAll()
	{
		RemoveAttributes();
		RemoveNodes();
	}

	public void RemoveAttributes()
	{
		while (attr_first != null)
		{
			attr_last.Remove();
		}
	}

	public void Save(string filename)
	{
		Save(filename, SaveOptions.None);
	}

	public void Save(string filename, SaveOptions options)
	{
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = options != SaveOptions.DisableFormatting;
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
		xmlWriterSettings.Indent = options != SaveOptions.DisableFormatting;
		using XmlWriter w = XmlWriter.Create(tw, xmlWriterSettings);
		Save(w);
	}

	public void Save(XmlWriter w)
	{
		WriteTo(w);
	}

	public IEnumerable<XElement> AncestorsAndSelf()
	{
		return GetAncestorList(null, getMeIn: true);
	}

	public IEnumerable<XElement> AncestorsAndSelf(XName name)
	{
		return GetAncestorList(name, getMeIn: true);
	}

	public IEnumerable<XElement> DescendantsAndSelf()
	{
		List<XElement> list = new List<XElement>();
		list.Add(this);
		list.AddRange(Descendants());
		return list;
	}

	public IEnumerable<XElement> DescendantsAndSelf(XName name)
	{
		List<XElement> list = new List<XElement>();
		if (name == this.name)
		{
			list.Add(this);
		}
		list.AddRange(Descendants(name));
		return list;
	}

	public IEnumerable<XNode> DescendantNodesAndSelf()
	{
		yield return this;
		foreach (XNode item in DescendantNodes())
		{
			yield return item;
		}
	}

	public void SetAttributeValue(XName name, object value)
	{
		XAttribute xAttribute = Attribute(name);
		if (value == null)
		{
			xAttribute?.Remove();
		}
		else if (xAttribute == null)
		{
			SetAttributeObject(new XAttribute(name, value));
		}
		else
		{
			xAttribute.Value = XUtil.ToString(value);
		}
	}

	private void SetAttributeObject(XAttribute a)
	{
		a = (XAttribute)XUtil.GetDetachedObject(a);
		a.SetOwner(this);
		if (attr_first == null)
		{
			attr_first = a;
			attr_last = a;
		}
		else
		{
			attr_last.NextAttribute = a;
			a.PreviousAttribute = attr_last;
			attr_last = a;
		}
	}

	public override void WriteTo(XmlWriter w)
	{
		string prefix = ((name.NamespaceName.Length <= 0) ? string.Empty : w.LookupPrefix(name.Namespace.NamespaceName));
		foreach (XAttribute item in Attributes())
		{
			if (item.IsNamespaceDeclaration && item.Value == name.Namespace.NamespaceName)
			{
				if (item.Name.Namespace == XNamespace.Xmlns)
				{
					prefix = item.Name.LocalName;
				}
				break;
			}
		}
		w.WriteStartElement(prefix, name.LocalName, name.Namespace.NamespaceName);
		foreach (XAttribute item2 in Attributes())
		{
			if (item2.IsNamespaceDeclaration)
			{
				if (item2.Name.Namespace == XNamespace.Xmlns)
				{
					w.WriteAttributeString("xmlns", item2.Name.LocalName, XNamespace.Xmlns.NamespaceName, item2.Value);
				}
				else
				{
					w.WriteAttributeString("xmlns", item2.Value);
				}
			}
			else
			{
				w.WriteAttributeString(item2.Name.LocalName, item2.Name.Namespace.NamespaceName, item2.Value);
			}
		}
		foreach (XNode item3 in Nodes())
		{
			item3.WriteTo(w);
		}
		if (explicit_is_empty)
		{
			w.WriteEndElement();
		}
		else
		{
			w.WriteFullEndElement();
		}
	}

	public XNamespace GetDefaultNamespace()
	{
		for (XElement xElement = this; xElement != null; xElement = xElement.Parent)
		{
			foreach (XAttribute item in xElement.Attributes())
			{
				if (item.IsNamespaceDeclaration && item.Name.Namespace == XNamespace.None)
				{
					return XNamespace.Get(item.Value);
				}
			}
		}
		return XNamespace.None;
	}

	public XNamespace GetNamespaceOfPrefix(string prefix)
	{
		for (XElement xElement = this; xElement != null; xElement = xElement.Parent)
		{
			foreach (XAttribute item in xElement.Attributes())
			{
				if (item.IsNamespaceDeclaration && ((prefix.Length == 0 && item.Name.LocalName == "xmlns") || item.Name.LocalName == prefix))
				{
					return XNamespace.Get(item.Value);
				}
			}
		}
		return XNamespace.None;
	}

	public string GetPrefixOfNamespace(XNamespace ns)
	{
		foreach (string item in GetPrefixOfNamespaceCore(ns))
		{
			if (GetNamespaceOfPrefix(item) == ns)
			{
				return item;
			}
		}
		return null;
	}

	private IEnumerable<string> GetPrefixOfNamespaceCore(XNamespace ns)
	{
		for (XElement el = this; el != null; el = el.Parent)
		{
			foreach (XAttribute a in el.Attributes())
			{
				if (a.IsNamespaceDeclaration && a.Value == ns.NamespaceName)
				{
					yield return (!(a.Name.Namespace == XNamespace.None)) ? a.Name.LocalName : string.Empty;
				}
			}
		}
	}

	public void ReplaceAll(object item)
	{
		RemoveNodes();
		Add(item);
	}

	public void ReplaceAll(params object[] items)
	{
		RemoveNodes();
		Add(items);
	}

	public void ReplaceAttributes(object item)
	{
		RemoveAttributes();
		Add(item);
	}

	public void ReplaceAttributes(params object[] items)
	{
		RemoveAttributes();
		Add(items);
	}

	public void SetElementValue(XName name, object value)
	{
		XElement content = new XElement(name, value);
		RemoveNodes();
		Add(content);
	}

	public void SetValue(object value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (value is XAttribute || value is XDocument || value is XDeclaration || value is XDocumentType)
		{
			throw new ArgumentException($"Node type {value.GetType()} is not allowed as element value");
		}
		RemoveNodes();
		foreach (object item in XUtil.ExpandArray(value))
		{
			Add(item);
		}
	}

	internal override bool OnAddingObject(object o, bool rejectAttribute, XNode refNode, bool addFirst)
	{
		if (o is XDocument || o is XDocumentType || o is XDeclaration || (rejectAttribute && o is XAttribute))
		{
			throw new ArgumentException($"A node of type {o.GetType()} cannot be added as a content");
		}
		if (o is XAttribute xAttribute)
		{
			foreach (XAttribute item in Attributes())
			{
				if (xAttribute.Name == item.Name)
				{
					throw new InvalidOperationException($"Duplicate attribute: {xAttribute.Name}");
				}
			}
			SetAttributeObject(xAttribute);
			return true;
		}
		if (o is string && refNode is XText)
		{
			((XText)refNode).Value += o as string;
			return true;
		}
		return false;
	}

	public static explicit operator bool(XElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return XUtil.ConvertToBoolean(element.Value);
	}

	public static explicit operator bool?(XElement element)
	{
		if (element == null)
		{
			return null;
		}
		return (element.Value != null) ? new bool?(XUtil.ConvertToBoolean(element.Value)) : ((bool?)null);
	}

	public static explicit operator DateTime(XElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return XUtil.ToDateTime(element.Value);
	}

	public static explicit operator DateTime?(XElement element)
	{
		if (element == null)
		{
			return null;
		}
		return (element.Value != null) ? new DateTime?(XUtil.ToDateTime(element.Value)) : ((DateTime?)null);
	}

	public static explicit operator DateTimeOffset(XElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return XmlConvert.ToDateTimeOffset(element.Value);
	}

	public static explicit operator DateTimeOffset?(XElement element)
	{
		if (element == null)
		{
			return null;
		}
		return (element.Value != null) ? new DateTimeOffset?(XmlConvert.ToDateTimeOffset(element.Value)) : ((DateTimeOffset?)null);
	}

	public static explicit operator decimal(XElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return XmlConvert.ToDecimal(element.Value);
	}

	public static explicit operator decimal?(XElement element)
	{
		if (element == null)
		{
			return null;
		}
		return (element.Value != null) ? new decimal?(XmlConvert.ToDecimal(element.Value)) : ((decimal?)null);
	}

	public static explicit operator double(XElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return XmlConvert.ToDouble(element.Value);
	}

	public static explicit operator double?(XElement element)
	{
		if (element == null)
		{
			return null;
		}
		return (element.Value != null) ? new double?(XmlConvert.ToDouble(element.Value)) : ((double?)null);
	}

	public static explicit operator float(XElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return XmlConvert.ToSingle(element.Value);
	}

	public static explicit operator float?(XElement element)
	{
		if (element == null)
		{
			return null;
		}
		return (element.Value != null) ? new float?(XmlConvert.ToSingle(element.Value)) : ((float?)null);
	}

	public static explicit operator Guid(XElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return XmlConvert.ToGuid(element.Value);
	}

	public static explicit operator Guid?(XElement element)
	{
		if (element == null)
		{
			return null;
		}
		return (element.Value != null) ? new Guid?(XmlConvert.ToGuid(element.Value)) : ((Guid?)null);
	}

	public static explicit operator int(XElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return XmlConvert.ToInt32(element.Value);
	}

	public static explicit operator int?(XElement element)
	{
		if (element == null)
		{
			return null;
		}
		return (element.Value != null) ? new int?(XmlConvert.ToInt32(element.Value)) : ((int?)null);
	}

	public static explicit operator long(XElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return XmlConvert.ToInt64(element.Value);
	}

	public static explicit operator long?(XElement element)
	{
		if (element == null)
		{
			return null;
		}
		return (element.Value != null) ? new long?(XmlConvert.ToInt64(element.Value)) : ((long?)null);
	}

	[CLSCompliant(false)]
	public static explicit operator uint(XElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return XmlConvert.ToUInt32(element.Value);
	}

	[CLSCompliant(false)]
	public static explicit operator uint?(XElement element)
	{
		if (element == null)
		{
			return null;
		}
		return (element.Value != null) ? new uint?(XmlConvert.ToUInt32(element.Value)) : ((uint?)null);
	}

	[CLSCompliant(false)]
	public static explicit operator ulong(XElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return XmlConvert.ToUInt64(element.Value);
	}

	[CLSCompliant(false)]
	public static explicit operator ulong?(XElement element)
	{
		if (element == null)
		{
			return null;
		}
		return (element.Value != null) ? new ulong?(XmlConvert.ToUInt64(element.Value)) : ((ulong?)null);
	}

	public static explicit operator TimeSpan(XElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		return XmlConvert.ToTimeSpan(element.Value);
	}

	public static explicit operator TimeSpan?(XElement element)
	{
		if (element == null)
		{
			return null;
		}
		return (element.Value != null) ? new TimeSpan?(XmlConvert.ToTimeSpan(element.Value)) : ((TimeSpan?)null);
	}

	public static explicit operator string(XElement element)
	{
		return element?.Value;
	}
}
