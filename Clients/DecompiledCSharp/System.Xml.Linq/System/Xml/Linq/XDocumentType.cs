namespace System.Xml.Linq;

public class XDocumentType : XNode
{
	private string name;

	private string pubid;

	private string sysid;

	private string intSubset;

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			name = value;
		}
	}

	public string PublicId
	{
		get
		{
			return pubid;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			pubid = value;
		}
	}

	public string SystemId
	{
		get
		{
			return sysid;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			sysid = value;
		}
	}

	public string InternalSubset
	{
		get
		{
			return intSubset;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			intSubset = value;
		}
	}

	public override XmlNodeType NodeType => XmlNodeType.DocumentType;

	public XDocumentType(string name, string publicId, string systemId, string internalSubset)
	{
		this.name = name;
		pubid = publicId;
		sysid = systemId;
		intSubset = internalSubset;
	}

	public XDocumentType(XDocumentType other)
	{
		if (other == null)
		{
			throw new ArgumentNullException("other");
		}
		name = other.name;
		pubid = other.pubid;
		sysid = other.sysid;
		intSubset = other.intSubset;
	}

	public override void WriteTo(XmlWriter w)
	{
		XDocument document = base.Document;
		XElement root = document.Root;
		if (root != null)
		{
			w.WriteDocType(root.Name.LocalName, pubid, sysid, intSubset);
		}
	}
}
