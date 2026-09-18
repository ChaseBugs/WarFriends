using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine;

/// <summary>
///   <para>Asynchronous operation coroutine.</para>
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public class AsyncOperation : YieldInstruction
{
	internal IntPtr m_Ptr;

	/// <summary>
	///   <para>Has the operation finished? (Read Only)</para>
	/// </summary>
	public extern bool isDone
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>What's the operation's progress. (Read Only)</para>
	/// </summary>
	public extern float progress
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Priority lets you tweak in which order async operation calls will be performed.</para>
	/// </summary>
	public extern int priority
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Allow scenes to be activated as soon as it is ready.</para>
	/// </summary>
	public extern bool allowSceneActivation
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
	private extern void InternalDestroy();

	~AsyncOperation()
	{
		InternalDestroy();
	}
}
