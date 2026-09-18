using System;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

namespace UnityEngine;

/// <summary>
///   <para>Script interface for.</para>
/// </summary>
public sealed class Light : Behaviour
{
	/// <summary>
	///   <para>The type of the light.</para>
	/// </summary>
	public extern LightType type
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The color of the light.</para>
	/// </summary>
	public Color color
	{
		get
		{
			INTERNAL_get_color(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_color(ref value);
		}
	}

	/// <summary>
	///   <para>The Intensity of a light is multiplied with the Light color.</para>
	/// </summary>
	public extern float intensity
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The multiplier that defines the strength of the bounce lighting.</para>
	/// </summary>
	public extern float bounceIntensity
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>How this light casts shadows</para>
	/// </summary>
	public extern LightShadows shadows
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Strength of light's shadows.</para>
	/// </summary>
	public extern float shadowStrength
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Shadow mapping constant bias.</para>
	/// </summary>
	public extern float shadowBias
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Shadow mapping normal-based bias.</para>
	/// </summary>
	public extern float shadowNormalBias
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	[Obsolete("Shadow softness is removed in Unity 5.0+")]
	public extern float shadowSoftness
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	[Obsolete("Shadow softness is removed in Unity 5.0+")]
	public extern float shadowSoftnessFade
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The range of the light.</para>
	/// </summary>
	public extern float range
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The angle of the light's spotlight cone in degrees.</para>
	/// </summary>
	public extern float spotAngle
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The size of a directional light's cookie.</para>
	/// </summary>
	public extern float cookieSize
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The cookie texture projected by the light.</para>
	/// </summary>
	public extern Texture cookie
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The to use for this light.</para>
	/// </summary>
	public extern Flare flare
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>How to render the light.</para>
	/// </summary>
	public extern LightRenderMode renderMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Has the light already been lightmapped.</para>
	/// </summary>
	public extern bool alreadyLightmapped
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>This is used to light certain objects in the scene selectively.</para>
	/// </summary>
	public extern int cullingMask
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Number of command buffers set up on this light (Read Only).</para>
	/// </summary>
	public extern int commandBufferCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	public static extern int pixelLightCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	[Obsolete("light.shadowConstantBias was removed, use light.shadowBias", true)]
	public float shadowConstantBias
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	[Obsolete("light.shadowObjectSizeBias was removed, use light.shadowBias", true)]
	public float shadowObjectSizeBias
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	[Obsolete("light.attenuate was removed; all lights always attenuate now", true)]
	public bool attenuate
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_color(out Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_color(ref Color value);

	/// <summary>
	///   <para>Add a command buffer to be executed at a specified place.</para>
	/// </summary>
	/// <param name="evt">When to execute the command buffer during rendering.</param>
	/// <param name="buffer">The buffer to execute.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void AddCommandBuffer(LightEvent evt, CommandBuffer buffer);

	/// <summary>
	///   <para>Remove command buffer from execution at a specified place.</para>
	/// </summary>
	/// <param name="evt">When to execute the command buffer during rendering.</param>
	/// <param name="buffer">The buffer to execute.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void RemoveCommandBuffer(LightEvent evt, CommandBuffer buffer);

	/// <summary>
	///   <para>Remove command buffers from execution at a specified place.</para>
	/// </summary>
	/// <param name="evt">When to execute the command buffer during rendering.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void RemoveCommandBuffers(LightEvent evt);

	/// <summary>
	///   <para>Remove all command buffers set on this light.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void RemoveAllCommandBuffers();

	/// <summary>
	///   <para>Get command buffers to be executed at a specified place.</para>
	/// </summary>
	/// <param name="evt">When to execute the command buffer during rendering.</param>
	/// <returns>
	///   <para>Array of command buffers.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern CommandBuffer[] GetCommandBuffers(LightEvent evt);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern Light[] GetLights(LightType type, int layer);
}
