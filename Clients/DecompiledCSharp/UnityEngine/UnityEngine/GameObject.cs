using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using UnityEngine.Internal;
using UnityEngineInternal;

namespace UnityEngine;

/// <summary>
///   <para>Base class for all entities in Unity scenes.</para>
/// </summary>
public sealed class GameObject : Object
{
	/// <summary>
	///   <para>The Transform attached to this GameObject. (null if there is none attached).</para>
	/// </summary>
	public extern Transform transform
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The layer the game object is in. A layer is in the range [0...31].</para>
	/// </summary>
	public extern int layer
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	[Obsolete("GameObject.active is obsolete. Use GameObject.SetActive(), GameObject.activeSelf or GameObject.activeInHierarchy.")]
	public extern bool active
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The local active state of this GameObject. (Read Only)</para>
	/// </summary>
	public extern bool activeSelf
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Is the GameObject active in the scene?</para>
	/// </summary>
	public extern bool activeInHierarchy
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Editor only API that specifies if a game object is static.</para>
	/// </summary>
	public extern bool isStatic
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	internal extern bool isStaticBatchable
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The tag of this game object.</para>
	/// </summary>
	public extern string tag
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	public GameObject gameObject => this;

	/// <summary>
	///   <para>Creates a new game object, named name.</para>
	/// </summary>
	/// <param name="name"></param>
	public GameObject(string name)
	{
		Internal_CreateGameObject(this, name);
	}

	/// <summary>
	///   <para>Creates a new game object.</para>
	/// </summary>
	public GameObject()
	{
		Internal_CreateGameObject(this, null);
	}

	/// <summary>
	///   <para>Creates a game object and attaches the specified components.</para>
	/// </summary>
	/// <param name="name"></param>
	/// <param name="components"></param>
	public GameObject(string name, params Type[] components)
	{
		Internal_CreateGameObject(this, name);
		foreach (Type componentType in components)
		{
			AddComponent(componentType);
		}
	}

	/// <summary>
	///   <para>Creates a game object with a primitive mesh renderer and appropriate collider.</para>
	/// </summary>
	/// <param name="type">The type of primitive object to create.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern GameObject CreatePrimitive(PrimitiveType type);

	/// <summary>
	///   <para>Returns the component of Type type if the game object has one attached, null if it doesn't.</para>
	/// </summary>
	/// <param name="type">The type of Component to retrieve.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
	[WrapperlessIcall]
	public extern Component GetComponent(Type type);

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

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern Component GetComponentByName(string type);

	/// <summary>
	///   <para>Returns the component with name type if the game object has one attached, null if it doesn't.</para>
	/// </summary>
	/// <param name="type">The type of Component to retrieve.</param>
	public Component GetComponent(string type)
	{
		return GetComponentByName(type);
	}

	/// <summary>
	///   <para>Returns the component of Type type in the GameObject or any of its children using depth first search.</para>
	/// </summary>
	/// <param name="type">The type of Component to retrieve.</param>
	[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
	public Component GetComponentInChildren(Type type)
	{
		if (activeInHierarchy)
		{
			Component component = GetComponent(type);
			if (component != null)
			{
				return component;
			}
		}
		Transform transform = this.transform;
		if (transform != null)
		{
			foreach (Transform item in transform)
			{
				Component componentInChildren = item.gameObject.GetComponentInChildren(type);
				if (componentInChildren != null)
				{
					return componentInChildren;
				}
			}
		}
		return null;
	}

	public T GetComponentInChildren<T>()
	{
		return (T)(object)GetComponentInChildren(typeof(T));
	}

	/// <summary>
	///   <para>Finds component in the parent.</para>
	/// </summary>
	/// <param name="type">Type of component to find.</param>
	[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
	public Component GetComponentInParent(Type type)
	{
		if (activeInHierarchy)
		{
			Component component = GetComponent(type);
			if (component != null)
			{
				return component;
			}
		}
		Transform parent = transform.parent;
		if (parent != null)
		{
			while (parent != null)
			{
				if (parent.gameObject.activeInHierarchy)
				{
					Component component2 = parent.gameObject.GetComponent(type);
					if (component2 != null)
					{
						return component2;
					}
				}
				parent = parent.parent;
			}
		}
		return null;
	}

	public T GetComponentInParent<T>()
	{
		return (T)(object)GetComponentInParent(typeof(T));
	}

	/// <summary>
	///   <para>Returns all components of Type type in the GameObject.</para>
	/// </summary>
	/// <param name="type">The type of Component to retrieve.</param>
	public Component[] GetComponents(Type type)
	{
		return (Component[])GetComponentsInternal(type, useSearchTypeAsArrayReturnType: false, recursive: false, includeInactive: true, reverse: false, null);
	}

	public T[] GetComponents<T>()
	{
		return (T[])GetComponentsInternal(typeof(T), useSearchTypeAsArrayReturnType: true, recursive: false, includeInactive: true, reverse: false, null);
	}

	public void GetComponents(Type type, List<Component> results)
	{
		GetComponentsInternal(type, useSearchTypeAsArrayReturnType: false, recursive: false, includeInactive: true, reverse: false, results);
	}

	public void GetComponents<T>(List<T> results)
	{
		GetComponentsInternal(typeof(T), useSearchTypeAsArrayReturnType: false, recursive: false, includeInactive: true, reverse: false, results);
	}

	/// <summary>
	///   <para>Returns all components of Type type in the GameObject or any of its children.</para>
	/// </summary>
	/// <param name="type">The type of Component to retrieve.</param>
	/// <param name="includeInactive">Should Components on inactive GameObjects be included in the found set?</param>
	[ExcludeFromDocs]
	public Component[] GetComponentsInChildren(Type type)
	{
		bool includeInactive = false;
		return GetComponentsInChildren(type, includeInactive);
	}

	/// <summary>
	///   <para>Returns all components of Type type in the GameObject or any of its children.</para>
	/// </summary>
	/// <param name="type">The type of Component to retrieve.</param>
	/// <param name="includeInactive">Should Components on inactive GameObjects be included in the found set?</param>
	public Component[] GetComponentsInChildren(Type type, [DefaultValue("false")] bool includeInactive)
	{
		return (Component[])GetComponentsInternal(type, useSearchTypeAsArrayReturnType: false, recursive: true, includeInactive, reverse: false, null);
	}

	public T[] GetComponentsInChildren<T>(bool includeInactive)
	{
		return (T[])GetComponentsInternal(typeof(T), useSearchTypeAsArrayReturnType: true, recursive: true, includeInactive, reverse: false, null);
	}

	public void GetComponentsInChildren<T>(bool includeInactive, List<T> results)
	{
		GetComponentsInternal(typeof(T), useSearchTypeAsArrayReturnType: true, recursive: true, includeInactive, reverse: false, results);
	}

	public T[] GetComponentsInChildren<T>()
	{
		return GetComponentsInChildren<T>(includeInactive: false);
	}

	public void GetComponentsInChildren<T>(List<T> results)
	{
		GetComponentsInChildren(includeInactive: false, results);
	}

	[ExcludeFromDocs]
	public Component[] GetComponentsInParent(Type type)
	{
		bool includeInactive = false;
		return GetComponentsInParent(type, includeInactive);
	}

	/// <summary>
	///   <para>Returns all components of Type type in the GameObject or any of its parents.</para>
	/// </summary>
	/// <param name="type">The type of Component to retrieve.</param>
	/// <param name="includeInactive">Should inactive Components be included in the found set?</param>
	public Component[] GetComponentsInParent(Type type, [DefaultValue("false")] bool includeInactive)
	{
		return (Component[])GetComponentsInternal(type, useSearchTypeAsArrayReturnType: false, recursive: true, includeInactive, reverse: true, null);
	}

	public void GetComponentsInParent<T>(bool includeInactive, List<T> results)
	{
		GetComponentsInternal(typeof(T), useSearchTypeAsArrayReturnType: true, recursive: true, includeInactive, reverse: true, results);
	}

	public T[] GetComponentsInParent<T>(bool includeInactive)
	{
		return (T[])GetComponentsInternal(typeof(T), useSearchTypeAsArrayReturnType: true, recursive: true, includeInactive, reverse: true, null);
	}

	public T[] GetComponentsInParent<T>()
	{
		return GetComponentsInParent<T>(includeInactive: false);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern Array GetComponentsInternal(Type type, bool useSearchTypeAsArrayReturnType, bool recursive, bool includeInactive, bool reverse, object resultList);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern Component AddComponentInternal(string className);

	/// <summary>
	///   <para>Activates/Deactivates the GameObject.</para>
	/// </summary>
	/// <param name="value">Activate or deactivation the  object.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetActive(bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	[Obsolete("gameObject.SetActiveRecursively() is obsolete. Use GameObject.SetActive(), which is now inherited by children.")]
	public extern void SetActiveRecursively(bool state);

	/// <summary>
	///   <para>Is this game object tagged with tag ?</para>
	/// </summary>
	/// <param name="tag">The tag to compare.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool CompareTag(string tag);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern GameObject FindGameObjectWithTag(string tag);

	/// <summary>
	///   <para>Returns one active GameObject tagged tag. Returns null if no GameObject was found.</para>
	/// </summary>
	/// <param name="tag">The tag to search for.</param>
	public static GameObject FindWithTag(string tag)
	{
		return FindGameObjectWithTag(tag);
	}

	/// <summary>
	///   <para>Returns a list of active GameObjects tagged tag. Returns empty array if no GameObject was found.</para>
	/// </summary>
	/// <param name="tag">The name of the tag to search GameObjects for.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern GameObject[] FindGameObjectsWithTag(string tag);

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.</para>
	/// </summary>
	/// <param name="methodName">The name of the method to call.</param>
	/// <param name="value">An optional parameter value to pass to the called method.</param>
	/// <param name="options">Should an error be raised if the method doesn't exist on the target object?</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SendMessageUpwards(string methodName, [DefaultValue("null")] object value, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.</para>
	/// </summary>
	/// <param name="methodName">The name of the method to call.</param>
	/// <param name="value">An optional parameter value to pass to the called method.</param>
	/// <param name="options">Should an error be raised if the method doesn't exist on the target object?</param>
	[ExcludeFromDocs]
	public void SendMessageUpwards(string methodName, object value)
	{
		SendMessageOptions options = SendMessageOptions.RequireReceiver;
		SendMessageUpwards(methodName, value, options);
	}

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object and on every ancestor of the behaviour.</para>
	/// </summary>
	/// <param name="methodName">The name of the method to call.</param>
	/// <param name="value">An optional parameter value to pass to the called method.</param>
	/// <param name="options">Should an error be raised if the method doesn't exist on the target object?</param>
	[ExcludeFromDocs]
	public void SendMessageUpwards(string methodName)
	{
		SendMessageOptions options = SendMessageOptions.RequireReceiver;
		object value = null;
		SendMessageUpwards(methodName, value, options);
	}

	/// <summary>
	///   <para></para>
	/// </summary>
	/// <param name="methodName"></param>
	/// <param name="options"></param>
	public void SendMessageUpwards(string methodName, SendMessageOptions options)
	{
		SendMessageUpwards(methodName, null, options);
	}

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object.</para>
	/// </summary>
	/// <param name="methodName">The name of the method to call.</param>
	/// <param name="value">An optional parameter value to pass to the called method.</param>
	/// <param name="options">Should an error be raised if the method doesn't exist on the target object?</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SendMessage(string methodName, [DefaultValue("null")] object value, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object.</para>
	/// </summary>
	/// <param name="methodName">The name of the method to call.</param>
	/// <param name="value">An optional parameter value to pass to the called method.</param>
	/// <param name="options">Should an error be raised if the method doesn't exist on the target object?</param>
	[ExcludeFromDocs]
	public void SendMessage(string methodName, object value)
	{
		SendMessageOptions options = SendMessageOptions.RequireReceiver;
		SendMessage(methodName, value, options);
	}

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object.</para>
	/// </summary>
	/// <param name="methodName">The name of the method to call.</param>
	/// <param name="value">An optional parameter value to pass to the called method.</param>
	/// <param name="options">Should an error be raised if the method doesn't exist on the target object?</param>
	[ExcludeFromDocs]
	public void SendMessage(string methodName)
	{
		SendMessageOptions options = SendMessageOptions.RequireReceiver;
		object value = null;
		SendMessage(methodName, value, options);
	}

	/// <summary>
	///   <para></para>
	/// </summary>
	/// <param name="methodName"></param>
	/// <param name="options"></param>
	public void SendMessage(string methodName, SendMessageOptions options)
	{
		SendMessage(methodName, null, options);
	}

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object or any of its children.</para>
	/// </summary>
	/// <param name="methodName"></param>
	/// <param name="parameter"></param>
	/// <param name="options"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void BroadcastMessage(string methodName, [DefaultValue("null")] object parameter, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options);

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object or any of its children.</para>
	/// </summary>
	/// <param name="methodName"></param>
	/// <param name="parameter"></param>
	/// <param name="options"></param>
	[ExcludeFromDocs]
	public void BroadcastMessage(string methodName, object parameter)
	{
		SendMessageOptions options = SendMessageOptions.RequireReceiver;
		BroadcastMessage(methodName, parameter, options);
	}

	/// <summary>
	///   <para>Calls the method named methodName on every MonoBehaviour in this game object or any of its children.</para>
	/// </summary>
	/// <param name="methodName"></param>
	/// <param name="parameter"></param>
	/// <param name="options"></param>
	[ExcludeFromDocs]
	public void BroadcastMessage(string methodName)
	{
		SendMessageOptions options = SendMessageOptions.RequireReceiver;
		object parameter = null;
		BroadcastMessage(methodName, parameter, options);
	}

	/// <summary>
	///   <para></para>
	/// </summary>
	/// <param name="methodName"></param>
	/// <param name="options"></param>
	public void BroadcastMessage(string methodName, SendMessageOptions options)
	{
		BroadcastMessage(methodName, null, options);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern Component Internal_AddComponentWithType(Type componentType);

	/// <summary>
	///   <para>Adds a component class of type componentType to the game object. C# Users can use a generic version.</para>
	/// </summary>
	/// <param name="componentType"></param>
	[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
	public Component AddComponent(Type componentType)
	{
		return Internal_AddComponentWithType(componentType);
	}

	public T AddComponent<T>() where T : Component
	{
		return AddComponent(typeof(T)) as T;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_CreateGameObject([Writable] GameObject mono, string name);

	/// <summary>
	///   <para>Finds a game object by name and returns it.</para>
	/// </summary>
	/// <param name="name"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern GameObject Find(string name);
}
