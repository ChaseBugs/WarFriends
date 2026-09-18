using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine;

/// <summary>
///   <para>Specialized values for the given states used by GUIStyle objects.</para>
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public sealed class GUIStyleState
{
	[NonSerialized]
	internal IntPtr m_Ptr;

	private readonly GUIStyle m_SourceStyle;

	[NonSerialized]
	private Texture2D m_Background;

	/// <summary>
	///   <para>The background image used by GUI elements in this given state.</para>
	/// </summary>
	public Texture2D background
	{
		get
		{
			return GetBackgroundInternal();
		}
		set
		{
			SetBackgroundInternal(value);
			m_Background = value;
		}
	}

	/// <summary>
	///   <para>The text color used by GUI elements in this state.</para>
	/// </summary>
	public Color textColor
	{
		get
		{
			INTERNAL_get_textColor(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_textColor(ref value);
		}
	}

	public GUIStyleState()
	{
		Init();
	}

	internal GUIStyleState(GUIStyle sourceStyle, IntPtr source)
	{
		m_SourceStyle = sourceStyle;
		m_Ptr = source;
		m_Background = GetBackgroundInternal();
	}

	~GUIStyleState()
	{
		if (m_SourceStyle == null)
		{
			Cleanup();
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Init();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Cleanup();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void SetBackgroundInternal(Texture2D value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern Texture2D GetBackgroundInternal();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_textColor(out Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_textColor(ref Color value);
}
