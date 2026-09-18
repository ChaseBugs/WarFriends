using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

namespace UnityEngine;

/// <summary>
///   <para>The Render Settings contain values for a range of visual elements in your scene, like fog and ambient light.</para>
/// </summary>
public sealed class RenderSettings : Object
{
	/// <summary>
	///   <para>Is fog enabled?</para>
	/// </summary>
	public static extern bool fog
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Fog mode to use.</para>
	/// </summary>
	public static extern FogMode fogMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The color of the fog.</para>
	/// </summary>
	public static Color fogColor
	{
		get
		{
			INTERNAL_get_fogColor(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_fogColor(ref value);
		}
	}

	/// <summary>
	///   <para>The density of the exponential fog.</para>
	/// </summary>
	public static extern float fogDensity
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The starting distance of linear fog.</para>
	/// </summary>
	public static extern float fogStartDistance
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The ending distance of linear fog.</para>
	/// </summary>
	public static extern float fogEndDistance
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Ambient lighting mode.</para>
	/// </summary>
	public static extern AmbientMode ambientMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Ambient lighting coming from above.</para>
	/// </summary>
	public static Color ambientSkyColor
	{
		get
		{
			INTERNAL_get_ambientSkyColor(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_ambientSkyColor(ref value);
		}
	}

	/// <summary>
	///   <para>Ambient lighting coming from the sides.</para>
	/// </summary>
	public static Color ambientEquatorColor
	{
		get
		{
			INTERNAL_get_ambientEquatorColor(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_ambientEquatorColor(ref value);
		}
	}

	/// <summary>
	///   <para>Ambient lighting coming from below.</para>
	/// </summary>
	public static Color ambientGroundColor
	{
		get
		{
			INTERNAL_get_ambientGroundColor(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_ambientGroundColor(ref value);
		}
	}

	/// <summary>
	///   <para>Flat ambient lighting color.</para>
	/// </summary>
	public static Color ambientLight
	{
		get
		{
			INTERNAL_get_ambientLight(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_ambientLight(ref value);
		}
	}

	/// <summary>
	///   <para>How much the light from the Ambient Source affects the scene.</para>
	/// </summary>
	public static extern float ambientIntensity
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Custom or skybox ambient lighting data.</para>
	/// </summary>
	public static SphericalHarmonicsL2 ambientProbe
	{
		get
		{
			INTERNAL_get_ambientProbe(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_ambientProbe(ref value);
		}
	}

	/// <summary>
	///   <para>How much the skybox / custom cubemap reflection affects the scene.</para>
	/// </summary>
	public static extern float reflectionIntensity
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The number of times a reflection includes other reflections.</para>
	/// </summary>
	public static extern int reflectionBounces
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Size of the Light halos.</para>
	/// </summary>
	public static extern float haloStrength
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The intensity of all flares in the scene.</para>
	/// </summary>
	public static extern float flareStrength
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The fade speed of all flares in the scene.</para>
	/// </summary>
	public static extern float flareFadeSpeed
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The global skybox to use.</para>
	/// </summary>
	public static extern Material skybox
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Default reflection mode.</para>
	/// </summary>
	public static extern DefaultReflectionMode defaultReflectionMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Cubemap resolution for default reflection.</para>
	/// </summary>
	public static extern int defaultReflectionResolution
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Custom specular reflection cubemap.</para>
	/// </summary>
	public static extern Cubemap customReflection
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
	private static extern void INTERNAL_get_fogColor(out Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_set_fogColor(ref Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_get_ambientSkyColor(out Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_set_ambientSkyColor(ref Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_get_ambientEquatorColor(out Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_set_ambientEquatorColor(ref Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_get_ambientGroundColor(out Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_set_ambientGroundColor(ref Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_get_ambientLight(out Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_set_ambientLight(ref Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_get_ambientProbe(out SphericalHarmonicsL2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_set_ambientProbe(ref SphericalHarmonicsL2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal static extern void Reset();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal static extern Object GetRenderSettings();
}
