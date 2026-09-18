using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine;

/// <summary>
///   <para>Gradient used for animating colors.</para>
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public sealed class Gradient
{
	internal IntPtr m_Ptr;

	/// <summary>
	///   <para>All color keys defined in the gradient.</para>
	/// </summary>
	public extern GradientColorKey[] colorKeys
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>All alpha keys defined in the gradient.</para>
	/// </summary>
	public extern GradientAlphaKey[] alphaKeys
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Create a new Gradient object.</para>
	/// </summary>
	public Gradient()
	{
		Init();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Init();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Cleanup();

	~Gradient()
	{
		Cleanup();
	}

	/// <summary>
	///   <para>Calculate color at a given time.</para>
	/// </summary>
	/// <param name="time">Time of the key (0 - 1).</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Color Evaluate(float time);

	/// <summary>
	///   <para>Setup Gradient with an array of color keys and alpha keys.</para>
	/// </summary>
	/// <param name="colorKeys">Color keys of the gradient (maximum 8 color keys).</param>
	/// <param name="alphaKeys">Alpha keys of the gradient (maximum 8 alpha keys).</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetKeys(GradientColorKey[] colorKeys, GradientAlphaKey[] alphaKeys);
}
