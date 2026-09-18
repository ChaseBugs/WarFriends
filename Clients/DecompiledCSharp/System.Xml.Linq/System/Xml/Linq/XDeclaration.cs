namespace System.Xml.Linq;

public class XDeclaration
{
	private string encoding;

	private string standalone;

	private string version;

	public string Encoding
	{
		get
		{
			return encoding;
		}
		set
		{
			encoding = value;
		}
	}

	public string Standalone
	{
		get
		{
			return standalone;
		}
		set
		{
			standalone = value;
		}
	}

	public string Version
	{
		get
		{
			return version;
		}
		set
		{
			version = value;
		}
	}

	public XDeclaration(string version, string encoding, string standalone)
	{
		this.version = version;
		this.encoding = encoding;
		this.standalone = standalone;
	}

	public XDeclaration(XDeclaration other)
	{
		if (other == null)
		{
			throw new ArgumentNullException("other");
		}
		version = other.version;
		encoding = other.encoding;
		standalone = other.standalone;
	}

	public override string ToString()
	{
		return "<?xml" + ((version == null) ? null : " version=\"") + ((version == null) ? null : version) + ((version == null) ? null : "\"") + ((encoding == null) ? null : " encoding=\"") + ((encoding == null) ? null : encoding) + ((encoding == null) ? null : "\"") + ((standalone == null) ? null : " standalone=\"") + ((standalone == null) ? null : standalone) + ((standalone == null) ? null : "\"") + "?>";
	}
}
