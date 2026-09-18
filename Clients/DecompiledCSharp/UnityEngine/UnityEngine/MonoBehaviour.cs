using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine;

/// <summary>
///   <para>MonoBehaviour is the base class every script derives from.</para>
/// </summary>
public class MonoBehaviour : Behaviour
{
	/// <summary>
	///   <para>Disabling this lets you skip the GUI layout phase.</para>
	/// </summary>
	public extern bool useGUILayout
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
	public extern MonoBehaviour();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Internal_CancelInvokeAll();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern bool Internal_IsInvokingAll();

	/// <summary>
	///   <para>Invokes the method methodName in time seconds.</para>
	/// </summary>
	/// <param name="methodName"></param>
	/// <param name="time"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void Invoke(string methodName, float time);

	/// <summary>
	///   <para>Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.</para>
	/// </summary>
	/// <param name="methodName"></param>
	/// <param name="time"></param>
	/// <param name="repeatRate"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void InvokeRepeating(string methodName, float time, float repeatRate);

	/// <summary>
	///   <para>Cancels all Invoke calls on this MonoBehaviour.</para>
	/// </summary>
	public void CancelInvoke()
	{
		Internal_CancelInvokeAll();
	}

	/// <summary>
	///   <para>Cancels all Invoke calls with name methodName on this behaviour.</para>
	/// </summary>
	/// <param name="methodName"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void CancelInvoke(string methodName);

	/// <summary>
	///   <para>Is any invoke on methodName pending?</para>
	/// </summary>
	/// <param name="methodName"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool IsInvoking(string methodName);

	/// <summary>
	///   <para>Is any invoke pending on this MonoBehaviour?</para>
	/// </summary>
	public bool IsInvoking()
	{
		return Internal_IsInvokingAll();
	}

	/// <summary>
	///   <para>Starts a coroutine.</para>
	/// </summary>
	/// <param name="routine"></param>
	public Coroutine StartCoroutine(IEnumerator routine)
	{
		return StartCoroutine_Auto(routine);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Coroutine StartCoroutine_Auto(IEnumerator routine);

	/// <summary>
	///   <para>Starts a coroutine named methodName.</para>
	/// </summary>
	/// <param name="methodName"></param>
	/// <param name="value"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value);

	/// <summary>
	///   <para>Starts a coroutine named methodName.</para>
	/// </summary>
	/// <param name="methodName"></param>
	/// <param name="value"></param>
	[ExcludeFromDocs]
	public Coroutine StartCoroutine(string methodName)
	{
		object value = null;
		return StartCoroutine(methodName, value);
	}

	/// <summary>
	///   <para>Stops the first coroutine named methodName, or the coroutine stored in routine running on this behaviour.</para>
	/// </summary>
	/// <param name="methodName">Name of coroutine.</param>
	/// <param name="routine">Name of the function in code.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void StopCoroutine(string methodName);

	/// <summary>
	///   <para>Stops the first coroutine named methodName, or the coroutine stored in routine running on this behaviour.</para>
	/// </summary>
	/// <param name="methodName">Name of coroutine.</param>
	/// <param name="routine">Name of the function in code.</param>
	public void StopCoroutine(IEnumerator routine)
	{
		StopCoroutineViaEnumerator_Auto(routine);
	}

	public void StopCoroutine(Coroutine routine)
	{
		StopCoroutine_Auto(routine);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern void StopCoroutineViaEnumerator_Auto(IEnumerator routine);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern void StopCoroutine_Auto(Coroutine routine);

	/// <summary>
	///   <para>Stops all coroutines running on this behaviour.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void StopAllCoroutines();

	/// <summary>
	///   <para>Logs message to the Unity Console (identical to Debug.Log).</para>
	/// </summary>
	/// <param name="message"></param>
	public static void print(object message)
	{
		Debug.Log(message);
	}
}
