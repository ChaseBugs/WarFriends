using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>BillboardAsset describes how a billboard is rendered.</para>
/// </summary>
public sealed class BillboardAsset : Object
{
	/// <summary>
	///   <para>Width of the billboard.</para>
	/// </summary>
	public extern float width
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Height of the billboard.</para>
	/// </summary>
	public extern float height
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Height of the billboard that is below ground.</para>
	/// </summary>
	public extern float bottom
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Number of pre-baked images that can be switched when the billboard is viewed from different angles.</para>
	/// </summary>
	public extern int imageCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Number of vertices in the billboard mesh. The mesh is not necessarily a quad. It can be a more complex shape which fits the actual image more precisely.</para>
	/// </summary>
	public extern int vertexCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Number of indices in the billboard mesh. The mesh is not necessarily a quad. It can be a more complex shape which fits the actual image more precisely.</para>
	/// </summary>
	public extern int indexCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The material used for rendering.</para>
	/// </summary>
	public extern Material material
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Constructs a new BillboardAsset.</para>
	/// </summary>
	public BillboardAsset()
	{
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern void MakeRenderMesh(Mesh mesh, float widthScale, float heightScale, float rotation);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern void MakeMaterialProperties(MaterialPropertyBlock properties, Camera camera);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern void MakePreviewMesh(Mesh mesh);
}
