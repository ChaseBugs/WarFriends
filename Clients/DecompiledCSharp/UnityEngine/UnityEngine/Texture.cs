using System;
using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Base class for texture handling. Contains functionality that is common to both Texture2D and RenderTexture classes.</para>
/// </summary>
public class Texture : Object
{
	public static extern int masterTextureLimit
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	public static extern AnisotropicFiltering anisotropicFiltering
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Width of the texture in pixels. (Read Only)</para>
	/// </summary>
	public virtual int width
	{
		get
		{
			return Internal_GetWidth(this);
		}
		set
		{
			throw new Exception("not implemented");
		}
	}

	/// <summary>
	///   <para>Height of the texture in pixels. (Read Only)</para>
	/// </summary>
	public virtual int height
	{
		get
		{
			return Internal_GetHeight(this);
		}
		set
		{
			throw new Exception("not implemented");
		}
	}

	/// <summary>
	///   <para>Filtering mode of the texture.</para>
	/// </summary>
	public extern FilterMode filterMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Anisotropic filtering level of the texture.</para>
	/// </summary>
	public extern int anisoLevel
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Wrap mode (Repeat or Clamp) of the texture.</para>
	/// </summary>
	public extern TextureWrapMode wrapMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Mip map bias of the texture.</para>
	/// </summary>
	public extern float mipMapBias
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	public Vector2 texelSize
	{
		get
		{
			INTERNAL_get_texelSize(out var value);
			return value;
		}
	}

	/// <summary>
	///   <para>Sets Anisotropic limits.</para>
	/// </summary>
	/// <param name="forcedMin"></param>
	/// <param name="globalMax"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void SetGlobalAnisotropicFilteringLimits(int forcedMin, int globalMax);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern int Internal_GetWidth(Texture mono);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern int Internal_GetHeight(Texture mono);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_texelSize(out Vector2 value);

	/// <summary>
	///   <para>Retrieve native ('hardware') pointer to a texture.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern IntPtr GetNativeTexturePtr();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[Obsolete("Use GetNativeTexturePtr instead.")]
	[WrapperlessIcall]
	public extern int GetNativeTextureID();
}
