using System;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine;

/// <summary>
///   <para>Script interface for.</para>
/// </summary>
public sealed class QualitySettings : Object
{
	/// <summary>
	///   <para>The indexed list of available Quality Settings.</para>
	/// </summary>
	public static extern string[] names
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	[Obsolete("Use GetQualityLevel and SetQualityLevel")]
	public static extern QualityLevel currentLevel
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The maximum number of pixel lights that should affect any object.</para>
	/// </summary>
	public static extern int pixelLightCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Directional light shadow projection.</para>
	/// </summary>
	public static extern ShadowProjection shadowProjection
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Number of cascades to use for directional light shadows.</para>
	/// </summary>
	public static extern int shadowCascades
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Shadow drawing distance.</para>
	/// </summary>
	public static extern float shadowDistance
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Offset shadow frustum near plane.</para>
	/// </summary>
	public static extern float shadowNearPlaneOffset
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The normalized cascade distribution for a 2 cascade setup. The value defines the position of the cascade with respect to Zero.</para>
	/// </summary>
	public static extern float shadowCascade2Split
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The normalized cascade start position for a 4 cascade setup. Each member of the vector defines the normalized position of the coresponding cascade with respect to Zero.</para>
	/// </summary>
	public static Vector3 shadowCascade4Split
	{
		get
		{
			INTERNAL_get_shadowCascade4Split(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_shadowCascade4Split(ref value);
		}
	}

	/// <summary>
	///   <para>A texture size limit applied to all textures.</para>
	/// </summary>
	public static extern int masterTextureLimit
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Global anisotropic filtering mode.</para>
	/// </summary>
	public static extern AnisotropicFiltering anisotropicFiltering
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Global multiplier for the LOD's switching distance.</para>
	/// </summary>
	public static extern float lodBias
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>A maximum LOD level. All LOD groups.</para>
	/// </summary>
	public static extern int maximumLODLevel
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Budget for how many ray casts can be performed per frame for approximate collision testing.</para>
	/// </summary>
	public static extern int particleRaycastBudget
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Use a two-pass shader for the vegetation in the terrain engine.</para>
	/// </summary>
	public static extern bool softVegetation
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Enables realtime reflection probes.</para>
	/// </summary>
	public static extern bool realtimeReflectionProbes
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>If enabled, billboards will face towards camera position rather than camera orientation.</para>
	/// </summary>
	public static extern bool billboardsFaceCameraPosition
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Maximum number of frames queued up by graphics driver.</para>
	/// </summary>
	public static extern int maxQueuedFrames
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The VSync Count.</para>
	/// </summary>
	public static extern int vSyncCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Set The AA Filtering option.</para>
	/// </summary>
	public static extern int antiAliasing
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Desired color space.</para>
	/// </summary>
	public static extern ColorSpace desiredColorSpace
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Active color space.</para>
	/// </summary>
	public static extern ColorSpace activeColorSpace
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Blend weights.</para>
	/// </summary>
	public static extern BlendWeights blendWeights
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Returns the current graphics quality level.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int GetQualityLevel();

	/// <summary>
	///   <para>Sets a new graphics quality level.</para>
	/// </summary>
	/// <param name="index">Quality index to set.</param>
	/// <param name="applyExpensiveChanges">Should expensive changes be applied (Anti-aliasing etc).</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void SetQualityLevel(int index, [DefaultValue("true")] bool applyExpensiveChanges);

	[ExcludeFromDocs]
	public static void SetQualityLevel(int index)
	{
		bool applyExpensiveChanges = true;
		SetQualityLevel(index, applyExpensiveChanges);
	}

	/// <summary>
	///   <para>Increase the current quality level.</para>
	/// </summary>
	/// <param name="applyExpensiveChanges">Should expensive changes be applied (Anti-aliasing etc).</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void IncreaseLevel([DefaultValue("false")] bool applyExpensiveChanges);

	[ExcludeFromDocs]
	public static void IncreaseLevel()
	{
		bool applyExpensiveChanges = false;
		IncreaseLevel(applyExpensiveChanges);
	}

	/// <summary>
	///   <para>Decrease the current quality level.</para>
	/// </summary>
	/// <param name="applyExpensiveChanges">Should expensive changes be applied (Anti-aliasing etc).</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void DecreaseLevel([DefaultValue("false")] bool applyExpensiveChanges);

	[ExcludeFromDocs]
	public static void DecreaseLevel()
	{
		bool applyExpensiveChanges = false;
		DecreaseLevel(applyExpensiveChanges);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_get_shadowCascade4Split(out Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_set_shadowCascade4Split(ref Vector3 value);
}
