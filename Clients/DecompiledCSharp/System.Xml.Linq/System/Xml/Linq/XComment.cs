namespace System.Xml.Linq;

public class XComment : XNode
{
	private string value;

	public override XmlNodeType NodeType => XmlNodeType.Comment;

	public string Value
	{
		get
		{
			return value;
		}
		set
		{
			this.value = value;
		}
	}

	public XComment(string value)
	{
		this.value = value;
	}

	public XComment(XComment other)
	{
		value = other.value;
	}

	public override void WriteTo(XmlWriter w)
	{
		w.WriteComment(value);
	}
}
