using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>The Skinned Mesh filter.</para>
/// </summary>
public class SkinnedMeshRenderer : Renderer
{
	/// <summary>
	///   <para>The bones used to skin the mesh.</para>
	/// </summary>
	public extern Transform[] bones
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	public extern Transform rootBone
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The maximum number of bones affecting a single vertex.</para>
	/// </summary>
	public extern SkinQuality quality
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The mesh used for skinning.</para>
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

	/// <summary>
	///   <para>If enabled, the Skinned Mesh will be updated when offscreen. If disabled, this also disables updating animations.</para>
	/// </summary>
	public extern bool updateWhenOffscreen
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>AABB of this Skinned Mesh in its local space.</para>
	/// </summary>
	public Bounds localBounds
	{
		get
		{
			INTERNAL_get_localBounds(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_localBounds(ref value);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_localBounds(out Bounds value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_localBounds(ref Bounds value);

	/// <summary>
	///   <para>Creates a snapshot of SkinnedMeshRenderer and stores it in mesh.</para>
	/// </summary>
	/// <param name="mesh">A static mesh that will receive the snapshot of the skinned mesh.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void BakeMesh(Mesh mesh);

	/// <summary>
	///   <para>Returns weight of BlendShape on this renderer.</para>
	/// </summary>
	/// <param name="index"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern float GetBlendShapeWeight(int index);

	/// <summary>
	///   <para>Sets weight of BlendShape on this renderer.</para>
	/// </summary>
	/// <param name="index"></param>
	/// <param name="value"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetBlendShapeWeight(int index, float value);
}
