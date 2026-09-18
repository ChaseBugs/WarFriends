using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Text file assets.</para>
/// </summary>
public class TextAsset : Object
{
	/// <summary>
	///   <para>The text contents of the .txt file as a string. (Read Only)</para>
	/// </summary>
	public extern string text
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The raw bytes of the text asset. (Read Only)</para>
	/// </summary>
	public extern byte[] bytes
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	public override string ToString()
	{
		return text;
	}
}
