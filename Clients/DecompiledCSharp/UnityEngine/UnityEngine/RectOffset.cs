using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine;

/// <summary>
///   <para>Offsets for rectangles, borders, etc.</para>
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public sealed class RectOffset
{
	[NonSerialized]
	internal IntPtr m_Ptr;

	private readonly GUIStyle m_SourceStyle;

	/// <summary>
	///   <para>Left edge size.</para>
	/// </summary>
	public extern int left
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Right edge size.</para>
	/// </summary>
	public extern int right
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Top edge size.</para>
	/// </summary>
	public extern int top
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Bottom edge size.</para>
	/// </summary>
	public extern int bottom
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Shortcut for left + right. (Read Only)</para>
	/// </summary>
	public extern int horizontal
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Shortcut for top + bottom. (Read Only)</para>
	/// </summary>
	public extern int vertical
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Creates a new rectangle with offsets.</para>
	/// </summary>
	/// <param name="left"></param>
	/// <param name="right"></param>
	/// <param name="top"></param>
	/// <param name="bottom"></param>
	public RectOffset()
	{
		Init();
	}

	internal RectOffset(GUIStyle sourceStyle, IntPtr source)
	{
		m_SourceStyle = sourceStyle;
		m_Ptr = source;
	}

	/// <summary>
	///   <para>Creates a new rectangle with offsets.</para>
	/// </summary>
	/// <param name="left"></param>
	/// <param name="right"></param>
	/// <param name="top"></param>
	/// <param name="bottom"></param>
	public RectOffset(int left, int right, int top, int bottom)
	{
		Init();
		this.left = left;
		this.right = right;
		this.top = top;
		this.bottom = bottom;
	}

	~RectOffset()
	{
		if (m_SourceStyle == null)
		{
			Cleanup();
		}
	}

	public override string ToString()
	{
		return UnityString.Format("RectOffset (l:{0} r:{1} t:{2} b:{3})", left, right, top, bottom);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Init();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Cleanup();

	/// <summary>
	///   <para>Add the border offsets to a rect.</para>
	/// </summary>
	/// <param name="rect"></param>
	public Rect Add(Rect rect)
	{
		return INTERNAL_CALL_Add(this, ref rect);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern Rect INTERNAL_CALL_Add(RectOffset self, ref Rect rect);

	/// <summary>
	///   <para>Remove the border offsets from a rect.</para>
	/// </summary>
	/// <param name="rect"></param>
	public Rect Remove(Rect rect)
	{
		return INTERNAL_CALL_Remove(this, ref rect);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern Rect INTERNAL_CALL_Remove(RectOffset self, ref Rect rect);
}
