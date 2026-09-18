using System;
using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Stores lightmaps of the scene.</para>
/// </summary>
public sealed class LightmapSettings : Object
{
	/// <summary>
	///   <para>Lightmap array.</para>
	/// </summary>
	public static extern LightmapData[] lightmaps
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	[Obsolete("Use lightmapsMode property")]
	public static extern LightmapsModeLegacy lightmapsModeLegacy
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Non-directional, Directional or Directional Specular lightmaps rendering mode.</para>
	/// </summary>
	public static extern LightmapsMode lightmapsMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Color space of the lightmap.</para>
	/// </summary>
	[Obsolete("bakedColorSpace is no longer valid. Use QualitySettings.desiredColorSpace.", false)]
	public static ColorSpace bakedColorSpace
	{
		get
		{
			return QualitySettings.desiredColorSpace;
		}
		set
		{
		}
	}

	/// <summary>
	///   <para>Holds all data needed by the light probes.</para>
	/// </summary>
	public static extern LightProbes lightProbes
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
	internal static extern void Reset();
}
