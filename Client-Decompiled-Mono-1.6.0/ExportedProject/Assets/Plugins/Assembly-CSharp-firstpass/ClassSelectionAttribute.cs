using System;
using UnityEngine;

public class ClassSelectionAttribute : PropertyAttribute
{
	public readonly Type t;

	public ClassSelectionAttribute(Type t)
	{
		this.t = t;
	}
}
