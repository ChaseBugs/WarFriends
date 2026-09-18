using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Wind Zones add realism to the trees you create by making them wave their branches and leaves as if blown by the wind.</para>
/// </summary>
public sealed class WindZone : Component
{
	/// <summary>
	///   <para>Defines the type of wind zone to be used (Spherical or Directional).</para>
	/// </summary>
	public extern WindZoneMode mode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Radius of the Spherical Wind Zone (only active if the WindZoneMode is set to Spherical).</para>
	/// </summary>
	public extern float radius
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The primary wind force.</para>
	/// </summary>
	public extern float windMain
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The turbulence wind force.</para>
	/// </summary>
	public extern float windTurbulence
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Defines ow much the wind changes over time.</para>
	/// </summary>
	public extern float windPulseMagnitude
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Defines the frequency of the wind changes.</para>
	/// </summary>
	public extern float windPulseFrequency
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The constructor.</para>
	/// </summary>
	public WindZone()
	{
	}
}
