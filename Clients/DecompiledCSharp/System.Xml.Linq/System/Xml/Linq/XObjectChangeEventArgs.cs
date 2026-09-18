namespace System.Xml.Linq;

public class XObjectChangeEventArgs : EventArgs
{
	public static readonly XObjectChangeEventArgs Add = new XObjectChangeEventArgs(XObjectChange.Add);

	public static readonly XObjectChangeEventArgs Name = new XObjectChangeEventArgs(XObjectChange.Name);

	public static readonly XObjectChangeEventArgs Remove = new XObjectChangeEventArgs(XObjectChange.Remove);

	public static readonly XObjectChangeEventArgs Value = new XObjectChangeEventArgs(XObjectChange.Value);

	private XObjectChange type;

	public XObjectChange ObjectChange => type;

	public XObjectChangeEventArgs(XObjectChange change)
	{
		type = change;
	}
}
