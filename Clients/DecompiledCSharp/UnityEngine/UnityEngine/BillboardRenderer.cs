using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Renders a billboard.</para>
/// </summary>
public sealed class BillboardRenderer : Renderer
{
	/// <summary>
	///   <para>The BillboardAsset to render.</para>
	/// </summary>
	public extern BillboardAsset billboard
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Constructor.</para>
	/// </summary>
	public BillboardRenderer()
	{
	}
}
