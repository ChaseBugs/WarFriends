namespace System.Xml.Linq;

public class XProcessingInstruction : XNode
{
	private string name;

	private string data;

	public string Data
	{
		get
		{
			return data;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			data = value;
		}
	}

	public override XmlNodeType NodeType => XmlNodeType.ProcessingInstruction;

	public string Target
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

	public XProcessingInstruction(string name, string data)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		this.name = name;
		this.data = data;
	}

	public XProcessingInstruction(XProcessingInstruction other)
	{
		if (other == null)
		{
			throw new ArgumentNullException("other");
		}
		name = other.name;
		data = other.data;
	}

	public override void WriteTo(XmlWriter w)
	{
		w.WriteProcessingInstruction(name, data);
	}
}
