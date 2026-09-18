using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Renders meshes inserted by the MeshFilter or TextMesh.</para>
/// </summary>
public sealed class MeshRenderer : Renderer
{
	/// <summary>
	///   <para>Vertex attributes in this mesh will override or add attributes of the primary mesh in the MeshRenderer.</para>
	/// </summary>
	public extern Mesh additionalVertexStreams
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}
}
