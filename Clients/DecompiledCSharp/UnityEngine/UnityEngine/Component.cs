using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using UnityEngine.Internal;
using UnityEngineInternal;

namespace UnityEngine;

/// <summary>
///   <para>Base class for everything attached to GameObjects.</para>
/// </summary>
public class Component : Object
{
	/// <summary>
	///   <para>The Transform attached to this GameObject (null if there is none attached).</para>
	/// </summary>
	public extern Transform transform
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The game object this component is attached to. A component is always attached to a game object.</para>
	/// </summary>
	public extern GameObject gameObject
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The tag of this game object.</para>
	/// </summary>
	public string tag
	{
		get
		{
			return gameObject.tag;
		}
		set
		{
			gameObject.tag = value;
		}
	}

	/// <summary>
	///   <para>Returns the component of Type type if the game object has one attached, null if it doesn't.</para>
	/// </summary>
	/// <param name="type">The type of Component to retrieve.</param>
	[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
	public Component GetComponent(Type type)
	{
		return gameObject.GetComponent(type);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern void GetComponentFastPath(Type type, IntPtr oneFurtherThanResultValue);

	[SecuritySafeCritical]
	public unsafe T GetComponent<T>()
	{
		CastHelper<T> castHelper = default(CastHelper<T>);
		GetComponentFastPath(typeof(T), new IntPtr(&castHelper.onePointerFurtherThanT));
		return castHelper.t;
	}

	/// <summary>
	///   <para>Returns the component with name type if the game object has one attached, null if it doesn't.</para>
	/// </summary>
	/// <param name="type"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Component GetComponent(string type);

	/// <summary>
	///   <para>Returns the component of Type type in the GameObject or any of its children using depth first search.</para>
	/// </summary>
	/// <param name="t">The type of Component to retrieve.</param>
	[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
	public Component GetComponentInChildren(Type t)
	{
		return gameObject.GetComponentInChildren(t);
	}

	public T GetComponentInChildren<T>()
	{
		return (T)(object)GetComponentInChildren(typeof(T));
	}

	/// <summary>
	///   <para>Returns all components of Type type in the GameObject or any of its children.</para>
	/// </summary>
	/// <param name="t">The type of Component to retrieve.</param>
	/// <param name="includeInactive">Should Components on inactive GameObjects be included in the found set?</param>
	[ExcludeFromDocs]
	public Component[] GetComponentsInChildren(Type t)
	{
		bool includeInactive = false;
		return GetComponentsInChildren(t, includeInactive);
	}

	/// <summary>
	///   <para>Returns all components of Type type in the GameObject or any of its children.</para>
	/// </summary>
	/// <param name="t">The type of Component to retrieve.</param>
	/// <param name="includeInactive">Should Components on inactive GameObjects be included in the found set?</param>
	public Component[] GetComponentsInChildren(Type t, [DefaultValue("false")] bool includeInactive)
	{
		return gameObject.GetComponentsInChildren(t, includeInactive);
	}

	public T[] GetComponentsInChildren<T>(bool includeInactive)
	{
		return gameObject.GetComponentsInChildren<T>(includeInactive);
	}

	public void GetComponentsInChildren<T>(bool includeInactive, List<T> result)
	{
		gameObject.GetComponentsInChildren(includeInactive, result);
	}

	public T[] GetComponentsInChildren<T>()
	{
		return GetComponentsInChildren<T>(includeInactive: false);
	}

	public void GetComponentsInChildren<T>(List<T> results)
	{
		GetComponentsInChildren(includeInactive: false, results);
	}

	/// <summary>
	///   <para>Returns the component of Type type in the GameObject or any of its parents.</para>
	/// </summary>
	/// <param name="t">The type of Component to retrieve.</param>
	[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
	public Component GetComponentInParent(Type t)
	{
		return gameObject.GetComponentInParent(t);
	}

	public T GetComponentInParent<T>()
	{
		return (T)(object)GetComponentInParent(typeof(T));
	}

	[ExcludeFromDocs]
	public Component[] GetComponentsInParent(Type t)
	{
		bool includeInactive = false;
		return GetComponentsInParent(t, includeInactive);
	}

	/// <summary>
	///   <para>Returns all components of Type type in the GameObject or any of its parents.</para>
	/// </summary>
	/// <param name="t">The type of Component to retrieve.</param>
	/// <param name="includeInactive">Should inactive Components be included in the found set?</param>
	public Component[] GetComponentsInParent(Type t, [DefaultValue("false")] bool includeInactive)
	{
		return gameObject.GetComponentsInParent(t, includeInactive);
	}

	public T[] GetComponentsInParent<T>(bool includeInactive)
	{
		return gameObject.GetComponentsInParent<T>(includeInactive);
	}

	public void GetComponentsInParent<T>(bool includeInactive, List<T> results)
	{
		gameObject.GetComponentsInParent(includeInactive, results);
	}

	public T[] GetComponentsInParent<T>()
	{
		return GetComponentsInParent<T>(includeInactive: false);
	}

	/// <summary>
	///   <para>Returns all components of Type type in the GameObject.</para>
	/// </summary>
	/// <param name="type">The type of Component to retrieve.</param>
	public Component[] GetComponents(Type type)
	{
		return gameObject.GetComponents(type);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void GetComponentsForListInternal(Type searchType, object resultList);

	public void GetComponents(Type type, List<Component> results)
	{
		GetComponentsForListInternal(type, results);
	}

	public void GetComponents<T>(List<T> results)
	{
		GetComponentsForListInternal(typeof(T), results);
	}

	public T[] GetComponents<T>()
	{
		return gameObject.GetComponents<T>();
	}

	/// <summary>
	///   <para>Is this game object tagged with tag ?</para>
	/// </summary>
	/// <param name="tag">The tag to compare.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool CompareTag(string tag);

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.</para>
	/// </summary>
	/// <param name="methodName">Name of method to call.</param>
	/// <param name="value">Optional parameter value for the method.</param>
	/// <param name="options">Should an error be raised if the method does not exist on the target object?</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SendMessageUpwards(string methodName, [DefaultValue("null")] object value, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.</para>
	/// </summary>
	/// <param name="methodName">Name of method to call.</param>
	/// <param name="value">Optional parameter value for the method.</param>
	/// <param name="options">Should an error be raised if the method does not exist on the target object?</param>
	[ExcludeFromDocs]
	public void SendMessageUpwards(string methodName, object value)
	{
		SendMessageOptions options = SendMessageOptions.RequireReceiver;
		SendMessageUpwards(methodName, value, options);
	}

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.</para>
	/// </summary>
	/// <param name="methodName">Name of method to call.</param>
	/// <param name="value">Optional parameter value for the method.</param>
	/// <param name="options">Should an error be raised if the method does not exist on the target object?</param>
	[ExcludeFromDocs]
	public void SendMessageUpwards(string methodName)
	{
		SendMessageOptions options = SendMessageOptions.RequireReceiver;
		object value = null;
		SendMessageUpwards(methodName, value, options);
	}

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.</para>
	/// </summary>
	/// <param name="methodName">Name of method to call.</param>
	/// <param name="value">Optional parameter value for the method.</param>
	/// <param name="options">Should an error be raised if the method does not exist on the target object?</param>
	public void SendMessageUpwards(string methodName, SendMessageOptions options)
	{
		SendMessageUpwards(methodName, null, options);
	}

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object.</para>
	/// </summary>
	/// <param name="methodName">Name of the method to call.</param>
	/// <param name="value">Optional parameter for the method.</param>
	/// <param name="options">Should an error be raised if the target object doesn't implement the method for the message?</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SendMessage(string methodName, [DefaultValue("null")] object value, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object.</para>
	/// </summary>
	/// <param name="methodName">Name of the method to call.</param>
	/// <param name="value">Optional parameter for the method.</param>
	/// <param name="options">Should an error be raised if the target object doesn't implement the method for the message?</param>
	[ExcludeFromDocs]
	public void SendMessage(string methodName, object value)
	{
		SendMessageOptions options = SendMessageOptions.RequireReceiver;
		SendMessage(methodName, value, options);
	}

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object.</para>
	/// </summary>
	/// <param name="methodName">Name of the method to call.</param>
	/// <param name="value">Optional parameter for the method.</param>
	/// <param name="options">Should an error be raised if the target object doesn't implement the method for the message?</param>
	[ExcludeFromDocs]
	public void SendMessage(string methodName)
	{
		SendMessageOptions options = SendMessageOptions.RequireReceiver;
		object value = null;
		SendMessage(methodName, value, options);
	}

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object.</para>
	/// </summary>
	/// <param name="methodName">Name of the method to call.</param>
	/// <param name="value">Optional parameter for the method.</param>
	/// <param name="options">Should an error be raised if the target object doesn't implement the method for the message?</param>
	public void SendMessage(string methodName, SendMessageOptions options)
	{
		SendMessage(methodName, null, options);
	}

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object or any of its children.</para>
	/// </summary>
	/// <param name="methodName">Name of the method to call.</param>
	/// <param name="parameter">Optional parameter to pass to the method (can be any value).</param>
	/// <param name="options">Should an error be raised if the method does not exist for a given target object?</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void BroadcastMessage(string methodName, [DefaultValue("null")] object parameter, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object or any of its children.</para>
	/// </summary>
	/// <param name="methodName">Name of the method to call.</param>
	/// <param name="parameter">Optional parameter to pass to the method (can be any value).</param>
	/// <param name="options">Should an error be raised if the method does not exist for a given target object?</param>
	[ExcludeFromDocs]
	public void BroadcastMessage(string methodName, object parameter)
	{
		SendMessageOptions options = SendMessageOptions.RequireReceiver;
		BroadcastMessage(methodName, parameter, options);
	}

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object or any of its children.</para>
	/// </summary>
	/// <param name="methodName">Name of the method to call.</param>
	/// <param name="parameter">Optional parameter to pass to the method (can be any value).</param>
	/// <param name="options">Should an error be raised if the method does not exist for a given target object?</param>
	[ExcludeFromDocs]
	public void BroadcastMessage(string methodName)
	{
		SendMessageOptions options = SendMessageOptions.RequireReceiver;
		object parameter = null;
		BroadcastMessage(methodName, parameter, options);
	}

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object or any of its children.</para>
	/// </summary>
	/// <param name="methodName">Name of the method to call.</param>
	/// <param name="parameter">Optional parameter to pass to the method (can be any value).</param>
	/// <param name="options">Should an error be raised if the method does not exist for a given target object?</param>
	public void BroadcastMessage(string methodName, SendMessageOptions options)
	{
		BroadcastMessage(methodName, null, options);
	}
}
