using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Asset type that defines the surface properties of a Collider2D.</para>
/// </summary>
public sealed class PhysicsMaterial2D : Object
{
	/// <summary>
	///   <para>The degree of elasticity during collisions.</para>
	/// </summary>
	public extern float bounciness
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Coefficient of friction.</para>
	/// </summary>
	public extern float friction
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	public PhysicsMaterial2D()
	{
		Internal_Create(this, null);
	}

	public PhysicsMaterial2D(string name)
	{
		Internal_Create(this, name);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_Create([Writable] PhysicsMaterial2D mat, string name);
}
