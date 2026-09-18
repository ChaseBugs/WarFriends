using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>A base class for all 2D effectors.</para>
/// </summary>
public class Effector2D : Behaviour
{
	/// <summary>
	///   <para>Should the collider-mask be used or the global collision matrix?</para>
	/// </summary>
	public extern bool useColliderMask
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The mask used to select specific layers allowed to interact with the effector.</para>
	/// </summary>
	public extern int colliderMask
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	internal extern bool requiresCollider
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	internal extern bool designedForTrigger
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	internal extern bool designedForNonTrigger
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}
}
