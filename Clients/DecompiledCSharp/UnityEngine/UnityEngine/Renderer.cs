using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

namespace UnityEngine;

/// <summary>
///   <para>General functionality for all renderers.</para>
/// </summary>
public class Renderer : Component
{
	internal extern Transform staticBatchRootTransform
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	internal extern int staticBatchIndex
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Has this renderer been statically batched with any other renderers?</para>
	/// </summary>
	public extern bool isPartOfStaticBatch
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Matrix that transforms a point from world space into local space (Read Only).</para>
	/// </summary>
	public Matrix4x4 worldToLocalMatrix
	{
		get
		{
			INTERNAL_get_worldToLocalMatrix(out var value);
			return value;
		}
	}

	/// <summary>
	///   <para>Matrix that transforms a point from local space into world space (Read Only).</para>
	/// </summary>
	public Matrix4x4 localToWorldMatrix
	{
		get
		{
			INTERNAL_get_localToWorldMatrix(out var value);
			return value;
		}
	}

	/// <summary>
	///   <para>Makes the rendered 3D object visible if enabled.</para>
	/// </summary>
	public extern bool enabled
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Does this object cast shadows?</para>
	/// </summary>
	public extern ShadowCastingMode shadowCastingMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Property castShadows has been deprecated. Use shadowCastingMode instead.")]
	public extern bool castShadows
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Does this object receive shadows?</para>
	/// </summary>
	public extern bool receiveShadows
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Returns the first instantiated Material assigned to the renderer.</para>
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
	///   <para>The shared material of this object.</para>
	/// </summary>
	public extern Material sharedMaterial
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Returns all the instantiated materials of this object.</para>
	/// </summary>
	public extern Material[] materials
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>All the shared materials of this object.</para>
	/// </summary>
	public extern Material[] sharedMaterials
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The bounding volume of the renderer (Read Only).</para>
	/// </summary>
	public Bounds bounds
	{
		get
		{
			INTERNAL_get_bounds(out var value);
			return value;
		}
	}

	/// <summary>
	///   <para>The index of the baked lightmap applied to this renderer.</para>
	/// </summary>
	public extern int lightmapIndex
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The index of the realtime lightmap applied to this renderer.</para>
	/// </summary>
	public extern int realtimeLightmapIndex
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The UV scale &amp; offset used for a lightmap.</para>
	/// </summary>
	public Vector4 lightmapScaleOffset
	{
		get
		{
			INTERNAL_get_lightmapScaleOffset(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_lightmapScaleOffset(ref value);
		}
	}

	/// <summary>
	///   <para>The UV scale &amp; offset used for a realtime lightmap.</para>
	/// </summary>
	public Vector4 realtimeLightmapScaleOffset
	{
		get
		{
			INTERNAL_get_realtimeLightmapScaleOffset(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_realtimeLightmapScaleOffset(ref value);
		}
	}

	/// <summary>
	///   <para>Is this renderer visible in any camera? (Read Only)</para>
	/// </summary>
	public extern bool isVisible
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Should light probes be used for this Renderer?</para>
	/// </summary>
	public extern bool useLightProbes
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>If set, Renderer will use this Transform's position to find the light or reflection probe.</para>
	/// </summary>
	public extern Transform probeAnchor
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Should reflection probes be used for this Renderer?</para>
	/// </summary>
	public extern ReflectionProbeUsage reflectionProbeUsage
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Name of the Renderer's sorting layer.</para>
	/// </summary>
	public extern string sortingLayerName
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Unique ID of the Renderer's sorting layer.</para>
	/// </summary>
	public extern int sortingLayerID
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Renderer's order within a sorting layer.</para>
	/// </summary>
	public extern int sortingOrder
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern void SetSubsetIndex(int index, int subSetIndexForMaterial);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_worldToLocalMatrix(out Matrix4x4 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_localToWorldMatrix(out Matrix4x4 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_bounds(out Bounds value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_lightmapScaleOffset(out Vector4 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_lightmapScaleOffset(ref Vector4 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_realtimeLightmapScaleOffset(out Vector4 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_realtimeLightmapScaleOffset(ref Vector4 value);

	/// <summary>
	///   <para>Lets you add per-renderer material parameters without duplicating a material.</para>
	/// </summary>
	/// <param name="properties"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetPropertyBlock(MaterialPropertyBlock properties);

	/// <summary>
	///   <para>Get per-renderer material property block.</para>
	/// </summary>
	/// <param name="dest"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void GetPropertyBlock(MaterialPropertyBlock dest);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void GetClosestReflectionProbesInternal(object result);

	public void GetClosestReflectionProbes(List<ReflectionProbeBlendInfo> result)
	{
		GetClosestReflectionProbesInternal(result);
	}
}
