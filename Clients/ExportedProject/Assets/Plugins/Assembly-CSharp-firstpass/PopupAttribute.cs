using UnityEngine;

public class PopupAttribute : PropertyAttribute
{
	public readonly string[] elements;

	public PopupAttribute(string[] elements)
	{
		this.elements = elements;
	}
}
