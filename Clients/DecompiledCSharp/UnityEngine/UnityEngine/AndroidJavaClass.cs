using System;

namespace UnityEngine;

/// <summary>
///   <para>AndroidJavaClass is the Unity representation of a generic instance of java.lang.Class.</para>
/// </summary>
public class AndroidJavaClass : AndroidJavaObject
{
	/// <summary>
	///   <para>Construct an AndroidJavaClass from the class name.</para>
	/// </summary>
	/// <param name="className">Specifies the Java class name (e.g. &lt;tt&gt;java.lang.String&lt;/tt&gt;).</param>
	public AndroidJavaClass(string className)
	{
		_AndroidJavaClass(className);
	}

	internal AndroidJavaClass(IntPtr jclass)
	{
		if (jclass == IntPtr.Zero)
		{
			throw new Exception("JNI: Init'd AndroidJavaClass with null ptr!");
		}
		m_jclass = AndroidJNI.NewGlobalRef(jclass);
		m_jobject = IntPtr.Zero;
	}

	private void _AndroidJavaClass(string className)
	{
		DebugPrint("Creating AndroidJavaClass from " + className);
		using AndroidJavaObject androidJavaObject = AndroidJavaObject.FindClass(className);
		m_jclass = AndroidJNI.NewGlobalRef(androidJavaObject.GetRawObject());
		m_jobject = IntPtr.Zero;
	}
}
