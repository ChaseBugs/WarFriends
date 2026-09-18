using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngineInternal;

namespace UnityEngine;

/// <summary>
///   <para>Base class for all objects Unity can reference.</para>
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public class Object
{
	private int m_InstanceID;

	private IntPtr m_CachedPtr;

	/// <summary>
	///   <para>The name of the object.</para>
	/// </summary>
	public extern string name
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Should the object be hidden, saved with the scene or modifiable by the user?</para>
	/// </summary>
	public extern HideFlags hideFlags
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
	private static extern Object Internal_CloneSingle(Object data);

	private static Object Internal_InstantiateSingle(Object data, Vector3 pos, Quaternion rot)
	{
		return INTERNAL_CALL_Internal_InstantiateSingle(data, ref pos, ref rot);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern Object INTERNAL_CALL_Internal_InstantiateSingle(Object data, ref Vector3 pos, ref Quaternion rot);

	/// <summary>
	///   <para>Removes a gameobject, component or asset.</para>
	/// </summary>
	/// <param name="obj">The object to destroy.</param>
	/// <param name="t">The optional amount of time to delay before destroying the object.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void Destroy(Object obj, [DefaultValue("0.0F")] float t);

	/// <summary>
	///   <para>Removes a gameobject, component or asset.</para>
	/// </summary>
	/// <param name="obj">The object to destroy.</param>
	/// <param name="t">The optional amount of time to delay before destroying the object.</param>
	[ExcludeFromDocs]
	public static void Destroy(Object obj)
	{
		float t = 0f;
		Destroy(obj, t);
	}

	/// <summary>
	///   <para>Destroys the object obj immediately. You are strongly recommended to use Destroy instead.</para>
	/// </summary>
	/// <param name="obj">Object to be destroyed.</param>
	/// <param name="allowDestroyingAssets">Set to true to allow assets to be destoyed.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void DestroyImmediate(Object obj, [DefaultValue("false")] bool allowDestroyingAssets);

	/// <summary>
	///   <para>Destroys the object obj immediately. You are strongly recommended to use Destroy instead.</para>
	/// </summary>
	/// <param name="obj">Object to be destroyed.</param>
	/// <param name="allowDestroyingAssets">Set to true to allow assets to be destoyed.</param>
	[ExcludeFromDocs]
	public static void DestroyImmediate(Object obj)
	{
		bool allowDestroyingAssets = false;
		DestroyImmediate(obj, allowDestroyingAssets);
	}

	/// <summary>
	///   <para>Returns a list of all active loaded objects of Type type.</para>
	/// </summary>
	/// <param name="type">The type of object to find.</param>
	/// <returns>
	///   <para>The array of objects found matching the type specified.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[TypeInferenceRule(TypeInferenceRules.ArrayOfTypeReferencedByFirstArgument)]
	[WrapperlessIcall]
	public static extern Object[] FindObjectsOfType(Type type);

	/// <summary>
	///   <para>Makes the object target not be destroyed automatically when loading a new scene.</para>
	/// </summary>
	/// <param name="target"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void DontDestroyOnLoad(Object target);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void DestroyObject(Object obj, [DefaultValue("0.0F")] float t);

	[ExcludeFromDocs]
	public static void DestroyObject(Object obj)
	{
		float t = 0f;
		DestroyObject(obj, t);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	[Obsolete("use Object.FindObjectsOfType instead.")]
	public static extern Object[] FindSceneObjectsOfType(Type type);

	/// <summary>
	///   <para>Returns a list of all active and inactive loaded objects of Type type, including assets.</para>
	/// </summary>
	/// <param name="type">The type of object or asset to find.</param>
	/// <returns>
	///   <para>The array of objects and assets found matching the type specified.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	[Obsolete("use Resources.FindObjectsOfTypeAll instead.")]
	public static extern Object[] FindObjectsOfTypeIncludingAssets(Type type);

	/// <summary>
	///   <para>Returns a list of all active and inactive loaded objects of Type type.</para>
	/// </summary>
	/// <param name="type">The type of object to find.</param>
	/// <returns>
	///   <para>The array of objects found matching the type specified.</para>
	/// </returns>
	[Obsolete("Please use Resources.FindObjectsOfTypeAll instead")]
	public static Object[] FindObjectsOfTypeAll(Type type)
	{
		return Resources.FindObjectsOfTypeAll(type);
	}

	/// <summary>
	///   <para>Returns the name of the game object.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public override extern string ToString();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal static extern bool DoesObjectWithInstanceIDExist(int instanceID);

	public override bool Equals(object o)
	{
		return CompareBaseObjects(this, o as Object);
	}

	public override int GetHashCode()
	{
		return GetInstanceID();
	}

	private static bool CompareBaseObjects(Object lhs, Object rhs)
	{
		bool flag = (object)lhs == null;
		bool flag2 = (object)rhs == null;
		if (flag2 && flag)
		{
			return true;
		}
		if (flag2)
		{
			return !IsNativeObjectAlive(lhs);
		}
		if (flag)
		{
			return !IsNativeObjectAlive(rhs);
		}
		return lhs.m_InstanceID == rhs.m_InstanceID;
	}

	private static bool IsNativeObjectAlive(Object o)
	{
		return o.GetCachedPtr() != IntPtr.Zero;
	}

	/// <summary>
	///   <para>Returns the instance id of the object.</para>
	/// </summary>
	public int GetInstanceID()
	{
		return m_InstanceID;
	}

	private IntPtr GetCachedPtr()
	{
		return m_CachedPtr;
	}

	/// <summary>
	///   <para>Clones the object original and returns the clone.</para>
	/// </summary>
	/// <param name="original">An existing object that you want to make a copy of.</param>
	/// <param name="position">Position for the new object.</param>
	/// <param name="rotation">Orientation of the new object.</param>
	[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
	public static Object Instantiate(Object original, Vector3 position, Quaternion rotation)
	{
		CheckNullArgument(original, "The thing you want to instantiate is null.");
		return Internal_InstantiateSingle(original, position, rotation);
	}

	/// <summary>
	///   <para>Clones the object original and returns the clone.</para>
	/// </summary>
	/// <param name="original">An existing object that you want to make a copy of.</param>
	/// <param name="position">Position for the new object.</param>
	/// <param name="rotation">Orientation of the new object.</param>
	[TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
	public static Object Instantiate(Object original)
	{
		CheckNullArgument(original, "The thing you want to instantiate is null.");
		return Internal_CloneSingle(original);
	}

	public static T Instantiate<T>(T original) where T : Object
	{
		CheckNullArgument(original, "The thing you want to instantiate is null.");
		return (T)Internal_CloneSingle(original);
	}

	private static void CheckNullArgument(object arg, string message)
	{
		if (arg == null)
		{
			throw new ArgumentException(message);
		}
	}

	public static T[] FindObjectsOfType<T>() where T : Object
	{
		return Resources.ConvertObjects<T>(FindObjectsOfType(typeof(T)));
	}

	/// <summary>
	///   <para>Returns the first active loaded object of Type type.</para>
	/// </summary>
	/// <param name="type"></param>
	[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
	public static Object FindObjectOfType(Type type)
	{
		Object[] array = FindObjectsOfType(type);
		if (array.Length > 0)
		{
			return array[0];
		}
		return null;
	}

	public static T FindObjectOfType<T>() where T : Object
	{
		return (T)FindObjectOfType(typeof(T));
	}

	public static implicit operator bool(Object exists)
	{
		return !CompareBaseObjects(exists, null);
	}

	public static bool operator ==(Object x, Object y)
	{
		return CompareBaseObjects(x, y);
	}

	public static bool operator !=(Object x, Object y)
	{
		return !CompareBaseObjects(x, y);
	}
}
