using System;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine;

/// <summary>
///   <para>Render textures are textures that can be rendered to.</para>
/// </summary>
public sealed class RenderTexture : Texture
{
	/// <summary>
	///   <para>The width of the render texture in pixels.</para>
	/// </summary>
	public override int width
	{
		get
		{
			return Internal_GetWidth(this);
		}
		set
		{
			Internal_SetWidth(this, value);
		}
	}

	/// <summary>
	///   <para>The height of the render texture in pixels.</para>
	/// </summary>
	public override int height
	{
		get
		{
			return Internal_GetHeight(this);
		}
		set
		{
			Internal_SetHeight(this, value);
		}
	}

	/// <summary>
	///   <para>The precision of the render texture's depth buffer in bits (0, 16, 24 are supported).</para>
	/// </summary>
	public extern int depth
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	public extern bool isPowerOfTwo
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Does this render texture use sRGB read / write (Read Only).</para>
	/// </summary>
	public extern bool sRGB
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The color format of the render texture.</para>
	/// </summary>
	public extern RenderTextureFormat format
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Use mipmaps on a render texture?</para>
	/// </summary>
	public extern bool useMipMap
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Should mipmap levels be generated automatically?</para>
	/// </summary>
	public extern bool generateMips
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>If enabled, this Render Texture will be used as a Cubemap.</para>
	/// </summary>
	public extern bool isCubemap
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>If enabled, this Render Texture will be used as a Texture3D.</para>
	/// </summary>
	public extern bool isVolume
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Volume extent of a 3D render texture.</para>
	/// </summary>
	public extern int volumeDepth
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The antialiasing level for the RenderTexture.</para>
	/// </summary>
	public extern int antiAliasing
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Enable random access write into this render texture on Shader Model 5.0 level shaders.</para>
	/// </summary>
	public extern bool enableRandomWrite
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Color buffer of the render texture (Read Only).</para>
	/// </summary>
	public RenderBuffer colorBuffer
	{
		get
		{
			GetColorBuffer(out var res);
			return res;
		}
	}

	/// <summary>
	///   <para>Depth/stencil buffer of the render texture (Read Only).</para>
	/// </summary>
	public RenderBuffer depthBuffer
	{
		get
		{
			GetDepthBuffer(out var res);
			return res;
		}
	}

	/// <summary>
	///   <para>Currently active render texture.</para>
	/// </summary>
	public static extern RenderTexture active
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	[Obsolete("Use SystemInfo.supportsRenderTextures instead.")]
	public static extern bool enabled
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Creates a new RenderTexture object.</para>
	/// </summary>
	/// <param name="width">Texture width in pixels.</param>
	/// <param name="height">Texture height in pixels.</param>
	/// <param name="depth">Number of bits in depth buffer (0, 16 or 24). Note that only 24 bit depth has stencil buffer.</param>
	/// <param name="format">Texture color format.</param>
	/// <param name="readWrite">How or if color space conversions should be done on texture read/write.</param>
	public RenderTexture(int width, int height, int depth, RenderTextureFormat format, RenderTextureReadWrite readWrite)
	{
		Internal_CreateRenderTexture(this);
		this.width = width;
		this.height = height;
		this.depth = depth;
		this.format = format;
		bool flag = readWrite == RenderTextureReadWrite.sRGB;
		if (readWrite == RenderTextureReadWrite.Default)
		{
			flag = QualitySettings.activeColorSpace == ColorSpace.Linear;
		}
		Internal_SetSRGBReadWrite(this, flag);
	}

	/// <summary>
	///   <para>Creates a new RenderTexture object.</para>
	/// </summary>
	/// <param name="width">Texture width in pixels.</param>
	/// <param name="height">Texture height in pixels.</param>
	/// <param name="depth">Number of bits in depth buffer (0, 16 or 24). Note that only 24 bit depth has stencil buffer.</param>
	/// <param name="format">Texture color format.</param>
	/// <param name="readWrite">How or if color space conversions should be done on texture read/write.</param>
	public RenderTexture(int width, int height, int depth, RenderTextureFormat format)
	{
		Internal_CreateRenderTexture(this);
		this.width = width;
		this.height = height;
		this.depth = depth;
		this.format = format;
		Internal_SetSRGBReadWrite(this, QualitySettings.activeColorSpace == ColorSpace.Linear);
	}

	/// <summary>
	///   <para>Creates a new RenderTexture object.</para>
	/// </summary>
	/// <param name="width">Texture width in pixels.</param>
	/// <param name="height">Texture height in pixels.</param>
	/// <param name="depth">Number of bits in depth buffer (0, 16 or 24). Note that only 24 bit depth has stencil buffer.</param>
	/// <param name="format">Texture color format.</param>
	/// <param name="readWrite">How or if color space conversions should be done on texture read/write.</param>
	public RenderTexture(int width, int height, int depth)
	{
		Internal_CreateRenderTexture(this);
		this.width = width;
		this.height = height;
		this.depth = depth;
		format = RenderTextureFormat.Default;
		Internal_SetSRGBReadWrite(this, QualitySettings.activeColorSpace == ColorSpace.Linear);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_CreateRenderTexture([Writable] RenderTexture rt);

	/// <summary>
	///   <para>Allocate a temporary render texture.</para>
	/// </summary>
	/// <param name="width">Width in pixels.</param>
	/// <param name="height">Height in pixels.</param>
	/// <param name="depthBuffer">Depth buffer bits (0, 16 or 24). Note that only 24 bit depth has stencil buffer.</param>
	/// <param name="format">Render texture format.</param>
	/// <param name="readWrite">sRGB handling mode.</param>
	/// <param name="antiAliasing">Anti-aliasing (1,2,4,8).</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern RenderTexture GetTemporary(int width, int height, [DefaultValue("0")] int depthBuffer, [DefaultValue("RenderTextureFormat.Default")] RenderTextureFormat format, [DefaultValue("RenderTextureReadWrite.Default")] RenderTextureReadWrite readWrite, [DefaultValue("1")] int antiAliasing);

	[ExcludeFromDocs]
	public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite)
	{
		int num = 1;
		return GetTemporary(width, height, depthBuffer, format, readWrite, num);
	}

	[ExcludeFromDocs]
	public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format)
	{
		int num = 1;
		RenderTextureReadWrite readWrite = RenderTextureReadWrite.Default;
		return GetTemporary(width, height, depthBuffer, format, readWrite, num);
	}

	[ExcludeFromDocs]
	public static RenderTexture GetTemporary(int width, int height, int depthBuffer)
	{
		int num = 1;
		RenderTextureReadWrite readWrite = RenderTextureReadWrite.Default;
		RenderTextureFormat renderTextureFormat = RenderTextureFormat.Default;
		return GetTemporary(width, height, depthBuffer, renderTextureFormat, readWrite, num);
	}

	[ExcludeFromDocs]
	public static RenderTexture GetTemporary(int width, int height)
	{
		int num = 1;
		RenderTextureReadWrite readWrite = RenderTextureReadWrite.Default;
		RenderTextureFormat renderTextureFormat = RenderTextureFormat.Default;
		int num2 = 0;
		return GetTemporary(width, height, num2, renderTextureFormat, readWrite, num);
	}

	/// <summary>
	///   <para>Release a temporary texture allocated with GetTemporary.</para>
	/// </summary>
	/// <param name="temp"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void ReleaseTemporary(RenderTexture temp);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern int Internal_GetWidth(RenderTexture mono);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_SetWidth(RenderTexture mono, int width);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern int Internal_GetHeight(RenderTexture mono);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_SetHeight(RenderTexture mono, int width);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_SetSRGBReadWrite(RenderTexture mono, bool sRGB);

	/// <summary>
	///   <para>Actually creates the RenderTexture.</para>
	/// </summary>
	public bool Create()
	{
		return INTERNAL_CALL_Create(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern bool INTERNAL_CALL_Create(RenderTexture self);

	/// <summary>
	///   <para>Releases the RenderTexture.</para>
	/// </summary>
	public void Release()
	{
		INTERNAL_CALL_Release(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_Release(RenderTexture self);

	/// <summary>
	///   <para>Is the render texture actually created?</para>
	/// </summary>
	public bool IsCreated()
	{
		return INTERNAL_CALL_IsCreated(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern bool INTERNAL_CALL_IsCreated(RenderTexture self);

	/// <summary>
	///   <para>Discards the contents of the RenderTexture.</para>
	/// </summary>
	/// <param name="discardColor">Should the colour buffer be discarded?</param>
	/// <param name="discardDepth">Should the depth buffer be discarded?</param>
	public void DiscardContents()
	{
		INTERNAL_CALL_DiscardContents(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_DiscardContents(RenderTexture self);

	/// <summary>
	///   <para>Discards the contents of the RenderTexture.</para>
	/// </summary>
	/// <param name="discardColor">Should the colour buffer be discarded?</param>
	/// <param name="discardDepth">Should the depth buffer be discarded?</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void DiscardContents(bool discardColor, bool discardDepth);

	/// <summary>
	///   <para>Indicate that there's a RenderTexture restore operation expected.</para>
	/// </summary>
	public void MarkRestoreExpected()
	{
		INTERNAL_CALL_MarkRestoreExpected(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_MarkRestoreExpected(RenderTexture self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void GetColorBuffer(out RenderBuffer res);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void GetDepthBuffer(out RenderBuffer res);

	/// <summary>
	///   <para>Assigns this RenderTexture as a global shader property named propertyName.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetGlobalShaderProperty(string propertyName);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_GetTexelOffset(RenderTexture tex, out Vector2 output);

	public Vector2 GetTexelOffset()
	{
		Internal_GetTexelOffset(this, out var output);
		return output;
	}

	/// <summary>
	///   <para>Does a RenderTexture have stencil buffer?</para>
	/// </summary>
	/// <param name="rt">Render texture, or null for main screen.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool SupportsStencil(RenderTexture rt);

	[Obsolete("SetBorderColor is no longer supported.", true)]
	public void SetBorderColor(Color color)
	{
	}
}
