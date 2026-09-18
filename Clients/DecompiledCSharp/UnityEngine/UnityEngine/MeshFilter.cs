using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>A class to access the Mesh of the.</para>
/// </summary>
public sealed class MeshFilter : Component
{
	/// <summary>
	///   <para>Returns the instantiated Mesh assigned to the mesh filter.</para>
	/// </summary>
	public extern Mesh mesh
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Returns the shared mesh of the mesh filter.</para>
	/// </summary>
	public extern Mesh sharedMesh
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}
}
