using System;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine;

/// <summary>
///   <para>Class for texture handling.</para>
/// </summary>
public sealed class Texture2D : Texture
{
	/// <summary>
	///   <para>How many mipmap levels are in this texture (Read Only).</para>
	/// </summary>
	public extern int mipmapCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The format of the pixel data in the texture (Read Only).</para>
	/// </summary>
	public extern TextureFormat format
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Get a small texture with all white pixels.</para>
	/// </summary>
	public static extern Texture2D whiteTexture
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Get a small texture with all black pixels.</para>
	/// </summary>
	public static extern Texture2D blackTexture
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Create a new empty texture.</para>
	/// </summary>
	/// <param name="width"></param>
	/// <param name="height"></param>
	public Texture2D(int width, int height)
	{
		Internal_Create(this, width, height, TextureFormat.ARGB32, mipmap: true, linear: false, IntPtr.Zero);
	}

	/// <summary>
	///   <para>Create a new empty texture.</para>
	/// </summary>
	/// <param name="width"></param>
	/// <param name="height"></param>
	/// <param name="format"></param>
	/// <param name="mipmap"></param>
	public Texture2D(int width, int height, TextureFormat format, bool mipmap)
	{
		Internal_Create(this, width, height, format, mipmap, linear: false, IntPtr.Zero);
	}

	/// <summary>
	///   <para>See Also: SetPixel, SetPixels, Apply functions.</para>
	/// </summary>
	/// <param name="width"></param>
	/// <param name="height"></param>
	/// <param name="format"></param>
	/// <param name="mipmap"></param>
	/// <param name="linear"></param>
	public Texture2D(int width, int height, TextureFormat format, bool mipmap, bool linear)
	{
		Internal_Create(this, width, height, format, mipmap, linear, IntPtr.Zero);
	}

	internal Texture2D(int width, int height, TextureFormat format, bool mipmap, bool linear, IntPtr nativeTex)
	{
		Internal_Create(this, width, height, format, mipmap, linear, nativeTex);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_Create([Writable] Texture2D mono, int width, int height, TextureFormat format, bool mipmap, bool linear, IntPtr nativeTex);

	/// <summary>
	///   <para>Creates Unity Texture out of externally created native texture object.</para>
	/// </summary>
	/// <param name="nativeTex">Native 2D texture object.</param>
	/// <param name="width">Width of texture in pixels.</param>
	/// <param name="height">Height of texture in pixels.</param>
	/// <param name="format">Format of underlying texture object.</param>
	/// <param name="mipmap">Does the texture have mipmaps?</param>
	/// <param name="linear">Is texture using linear color space?</param>
	public static Texture2D CreateExternalTexture(int width, int height, TextureFormat format, bool mipmap, bool linear, IntPtr nativeTex)
	{
		return new Texture2D(width, height, format, mipmap, linear, nativeTex);
	}

	/// <summary>
	///   <para>Updates Unity texture to use different native texture object.</para>
	/// </summary>
	/// <param name="nativeTex">Native 2D texture object.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void UpdateExternalTexture(IntPtr nativeTex);

	/// <summary>
	///   <para>Sets pixel color at coordinates (x,y).</para>
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="color"></param>
	public void SetPixel(int x, int y, Color color)
	{
		INTERNAL_CALL_SetPixel(this, x, y, ref color);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_SetPixel(Texture2D self, int x, int y, ref Color color);

	/// <summary>
	///   <para>Returns pixel color at coordinates (x, y).</para>
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Color GetPixel(int x, int y);

	/// <summary>
	///   <para>Returns filtered pixel color at normalized coordinates (u, v).</para>
	/// </summary>
	/// <param name="u"></param>
	/// <param name="v"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Color GetPixelBilinear(float u, float v);

	[ExcludeFromDocs]
	public void SetPixels(Color[] colors)
	{
		int miplevel = 0;
		SetPixels(colors, miplevel);
	}

	/// <summary>
	///   <para>Set a block of pixel colors.</para>
	/// </summary>
	/// <param name="colors"></param>
	/// <param name="miplevel"></param>
	public void SetPixels(Color[] colors, [DefaultValue("0")] int miplevel)
	{
		int num = width >> miplevel;
		if (num < 1)
		{
			num = 1;
		}
		int num2 = height >> miplevel;
		if (num2 < 1)
		{
			num2 = 1;
		}
		SetPixels(0, 0, num, num2, colors, miplevel);
	}

	/// <summary>
	///   <para>Set a block of pixel colors.</para>
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="blockWidth"></param>
	/// <param name="blockHeight"></param>
	/// <param name="colors"></param>
	/// <param name="miplevel"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors, [DefaultValue("0")] int miplevel);

	[ExcludeFromDocs]
	public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors)
	{
		int miplevel = 0;
		SetPixels(x, y, blockWidth, blockHeight, colors, miplevel);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void SetAllPixels32(Color32[] colors, int miplevel);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void SetBlockOfPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors, int miplevel);

	[ExcludeFromDocs]
	public void SetPixels32(Color32[] colors)
	{
		int miplevel = 0;
		SetPixels32(colors, miplevel);
	}

	/// <summary>
	///   <para>Set a block of pixel colors.</para>
	/// </summary>
	/// <param name="colors"></param>
	/// <param name="miplevel"></param>
	public void SetPixels32(Color32[] colors, [DefaultValue("0")] int miplevel)
	{
		SetAllPixels32(colors, miplevel);
	}

	[ExcludeFromDocs]
	public void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors)
	{
		int miplevel = 0;
		SetPixels32(x, y, blockWidth, blockHeight, colors, miplevel);
	}

	/// <summary>
	///   <para>Set a block of pixel colors.</para>
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="blockWidth"></param>
	/// <param name="blockHeight"></param>
	/// <param name="colors"></param>
	/// <param name="miplevel"></param>
	public void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors, [DefaultValue("0")] int miplevel)
	{
		SetBlockOfPixels32(x, y, blockWidth, blockHeight, colors, miplevel);
	}

	/// <summary>
	///   <para>Loads PNG/JPG image byte array into a texture.</para>
	/// </summary>
	/// <param name="data">The byte array containing the image data to load.</param>
	/// <returns>
	///   <para>Returns true if the data can be loaded, false otherwise.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool LoadImage(byte[] data);

	/// <summary>
	///   <para>Fills texture pixels with raw preformatted data.</para>
	/// </summary>
	/// <param name="data">Byte array to initialize texture pixels with.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void LoadRawTextureData(byte[] data);

	/// <summary>
	///   <para>Get raw data from a texture.</para>
	/// </summary>
	/// <returns>
	///   <para>Raw texture data as a byte array.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern byte[] GetRawTextureData();

	[ExcludeFromDocs]
	public Color[] GetPixels()
	{
		int miplevel = 0;
		return GetPixels(miplevel);
	}

	/// <summary>
	///   <para>Get a block of pixel colors.</para>
	/// </summary>
	/// <param name="miplevel"></param>
	public Color[] GetPixels([DefaultValue("0")] int miplevel)
	{
		int num = width >> miplevel;
		if (num < 1)
		{
			num = 1;
		}
		int num2 = height >> miplevel;
		if (num2 < 1)
		{
			num2 = 1;
		}
		return GetPixels(0, 0, num, num2, miplevel);
	}

	/// <summary>
	///   <para>Get a block of pixel colors.</para>
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="blockWidth"></param>
	/// <param name="blockHeight"></param>
	/// <param name="miplevel"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Color[] GetPixels(int x, int y, int blockWidth, int blockHeight, [DefaultValue("0")] int miplevel);

	[ExcludeFromDocs]
	public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight)
	{
		int miplevel = 0;
		return GetPixels(x, y, blockWidth, blockHeight, miplevel);
	}

	/// <summary>
	///   <para>Get a block of pixel colors in Color32 format.</para>
	/// </summary>
	/// <param name="miplevel"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Color32[] GetPixels32([DefaultValue("0")] int miplevel);

	[ExcludeFromDocs]
	public Color32[] GetPixels32()
	{
		int miplevel = 0;
		return GetPixels32(miplevel);
	}

	/// <summary>
	///   <para>Actually apply all previous SetPixel and SetPixels changes.</para>
	/// </summary>
	/// <param name="updateMipmaps"></param>
	/// <param name="makeNoLongerReadable"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void Apply([DefaultValue("true")] bool updateMipmaps, [DefaultValue("false")] bool makeNoLongerReadable);

	[ExcludeFromDocs]
	public void Apply(bool updateMipmaps)
	{
		bool makeNoLongerReadable = false;
		Apply(updateMipmaps, makeNoLongerReadable);
	}

	[ExcludeFromDocs]
	public void Apply()
	{
		bool makeNoLongerReadable = false;
		bool updateMipmaps = true;
		Apply(updateMipmaps, makeNoLongerReadable);
	}

	/// <summary>
	///   <para>Resizes the texture.</para>
	/// </summary>
	/// <param name="width"></param>
	/// <param name="height"></param>
	/// <param name="format"></param>
	/// <param name="hasMipMap"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool Resize(int width, int height, TextureFormat format, bool hasMipMap);

	/// <summary>
	///   <para>Resizes the texture.</para>
	/// </summary>
	/// <param name="width"></param>
	/// <param name="height"></param>
	public bool Resize(int width, int height)
	{
		return Internal_ResizeWH(width, height);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern bool Internal_ResizeWH(int width, int height);

	/// <summary>
	///   <para>Compress texture into DXT format.</para>
	/// </summary>
	/// <param name="highQuality"></param>
	public void Compress(bool highQuality)
	{
		INTERNAL_CALL_Compress(this, highQuality);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_Compress(Texture2D self, bool highQuality);

	/// <summary>
	///   <para>Packs multiple Textures into a texture atlas.</para>
	/// </summary>
	/// <param name="textures">Array of textures to pack into the atlas.</param>
	/// <param name="padding">Padding in pixels between the packed textures.</param>
	/// <param name="maximumAtlasSize">Maximum size of the resulting texture.</param>
	/// <param name="makeNoLongerReadable">Should the texture be marked as no longer readable?</param>
	/// <returns>
	///   <para>An array of rectangles containing the UV coordinates in the atlas for each input texture, or null if packing fails.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Rect[] PackTextures(Texture2D[] textures, int padding, [DefaultValue("2048")] int maximumAtlasSize, [DefaultValue("false")] bool makeNoLongerReadable);

	[ExcludeFromDocs]
	public Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize)
	{
		bool makeNoLongerReadable = false;
		return PackTextures(textures, padding, maximumAtlasSize, makeNoLongerReadable);
	}

	[ExcludeFromDocs]
	public Rect[] PackTextures(Texture2D[] textures, int padding)
	{
		bool makeNoLongerReadable = false;
		int maximumAtlasSize = 2048;
		return PackTextures(textures, padding, maximumAtlasSize, makeNoLongerReadable);
	}

	/// <summary>
	///   <para>Read pixels from screen into the saved texture data.</para>
	/// </summary>
	/// <param name="source">Rectangular region of the view to read from. Pixels are read from current render target.</param>
	/// <param name="destX">Horizontal pixel position in the texture to place the pixels that are read.</param>
	/// <param name="destY">Vertical pixel position in the texture to place the pixels that are read.</param>
	/// <param name="recalculateMipMaps">Should the texture's mipmaps be recalculated after reading?</param>
	public void ReadPixels(Rect source, int destX, int destY, [DefaultValue("true")] bool recalculateMipMaps)
	{
		INTERNAL_CALL_ReadPixels(this, ref source, destX, destY, recalculateMipMaps);
	}

	[ExcludeFromDocs]
	public void ReadPixels(Rect source, int destX, int destY)
	{
		bool recalculateMipMaps = true;
		INTERNAL_CALL_ReadPixels(this, ref source, destX, destY, recalculateMipMaps);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_ReadPixels(Texture2D self, ref Rect source, int destX, int destY, bool recalculateMipMaps);

	/// <summary>
	///   <para>Encodes this texture into PNG format.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern byte[] EncodeToPNG();

	/// <summary>
	///   <para>Encodes this texture into JPG format.</para>
	/// </summary>
	/// <param name="quality">JPG quality to encode with, 1..100 (default 75).</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern byte[] EncodeToJPG(int quality);

	/// <summary>
	///   <para>Encodes this texture into JPG format.</para>
	/// </summary>
	/// <param name="quality">JPG quality to encode with, 1..100 (default 75).</param>
	public byte[] EncodeToJPG()
	{
		return EncodeToJPG(75);
	}
}
