using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Applies forces within an area.</para>
/// </summary>
public sealed class AreaEffector2D : Effector2D
{
	/// <summary>
	///   <para>The angle of the force to be applied.</para>
	/// </summary>
	public extern float forceAngle
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Should the forceAngle use global space?</para>
	/// </summary>
	public extern bool useGlobalAngle
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The magnitude of the force to be applied.</para>
	/// </summary>
	public extern float forceMagnitude
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The variation of the magnitude of the force to be applied.</para>
	/// </summary>
	public extern float forceVariation
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The linear drag to apply to rigid-bodies.</para>
	/// </summary>
	public extern float drag
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The angular drag to apply to rigid-bodies.</para>
	/// </summary>
	public extern float angularDrag
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The target for where the effector applies any force.</para>
	/// </summary>
	public extern EffectorSelection2D forceTarget
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}
}
