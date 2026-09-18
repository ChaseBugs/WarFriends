using System;
using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>The network view is the binding material of multiplayer games.</para>
/// </summary>
public sealed class NetworkView : Behaviour
{
	/// <summary>
	///   <para>The component the network view is observing.</para>
	/// </summary>
	public extern Component observed
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The type of NetworkStateSynchronization set for this network view.</para>
	/// </summary>
	public extern NetworkStateSynchronization stateSynchronization
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The ViewID of this network view.</para>
	/// </summary>
	public NetworkViewID viewID
	{
		get
		{
			Internal_GetViewID(out var result);
			return result;
		}
		set
		{
			Internal_SetViewID(value);
		}
	}

	/// <summary>
	///   <para>The network group number of this network view.</para>
	/// </summary>
	public extern int group
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Is the network view controlled by this object?</para>
	/// </summary>
	public bool isMine => viewID.isMine;

	/// <summary>
	///   <para>The NetworkPlayer who owns this network view.</para>
	/// </summary>
	public NetworkPlayer owner => viewID.owner;

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_RPC(NetworkView view, string name, RPCMode mode, object[] args);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_RPC_Target(NetworkView view, string name, NetworkPlayer target, object[] args);

	/// <summary>
	///   <para>Call a RPC function on all connected peers.</para>
	/// </summary>
	/// <param name="name"></param>
	/// <param name="mode"></param>
	/// <param name="args"></param>
	[Obsolete("NetworkView RPC functions are deprecated. Refer to the new Multiplayer Networking system.")]
	public void RPC(string name, RPCMode mode, params object[] args)
	{
		Internal_RPC(this, name, mode, args);
	}

	/// <summary>
	///   <para>Call a RPC function on a specific player.</para>
	/// </summary>
	/// <param name="name"></param>
	/// <param name="target"></param>
	/// <param name="args"></param>
	[Obsolete("NetworkView RPC functions are deprecated. Refer to the new Multiplayer Networking system.")]
	public void RPC(string name, NetworkPlayer target, params object[] args)
	{
		Internal_RPC_Target(this, name, target, args);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Internal_GetViewID(out NetworkViewID viewID);

	private void Internal_SetViewID(NetworkViewID viewID)
	{
		INTERNAL_CALL_Internal_SetViewID(this, ref viewID);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_Internal_SetViewID(NetworkView self, ref NetworkViewID viewID);

	/// <summary>
	///   <para>Set the scope of the network view in relation to a specific network player.</para>
	/// </summary>
	/// <param name="player"></param>
	/// <param name="relevancy"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool SetScope(NetworkPlayer player, bool relevancy);

	/// <summary>
	///   <para>Find a network view based on a NetworkViewID.</para>
	/// </summary>
	/// <param name="viewID"></param>
	public static NetworkView Find(NetworkViewID viewID)
	{
		return INTERNAL_CALL_Find(ref viewID);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern NetworkView INTERNAL_CALL_Find(ref NetworkViewID viewID);
}
