using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine;

/// <summary>
///   <para>Class for handling cube maps, Use this to create or modify existing.</para>
/// </summary>
public sealed class Cubemap : Texture
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
	///   <para>Create a new empty cubemap texture.</para>
	/// </summary>
	/// <param name="size">Width/height of a cube face in pixels.</param>
	/// <param name="format">Pixel data format to be used for the Cubemap.</param>
	/// <param name="mipmap">Should mipmaps be created?</param>
	public Cubemap(int size, TextureFormat format, bool mipmap)
	{
		Internal_Create(this, size, format, mipmap);
	}

	/// <summary>
	///   <para>Sets pixel color at coordinates (face, x, y).</para>
	/// </summary>
	/// <param name="face"></param>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="color"></param>
	public void SetPixel(CubemapFace face, int x, int y, Color color)
	{
		INTERNAL_CALL_SetPixel(this, face, x, y, ref color);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_SetPixel(Cubemap self, CubemapFace face, int x, int y, ref Color color);

	/// <summary>
	///   <para>Returns pixel color at coordinates (face, x, y).</para>
	/// </summary>
	/// <param name="face"></param>
	/// <param name="x"></param>
	/// <param name="y"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Color GetPixel(CubemapFace face, int x, int y);

	/// <summary>
	///   <para>Returns pixel colors of a cubemap face.</para>
	/// </summary>
	/// <param name="face">The face from which pixel data is taken.</param>
	/// <param name="miplevel">Mipmap level for the chosen face.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Color[] GetPixels(CubemapFace face, [DefaultValue("0")] int miplevel);

	[ExcludeFromDocs]
	public Color[] GetPixels(CubemapFace face)
	{
		int miplevel = 0;
		return GetPixels(face, miplevel);
	}

	/// <summary>
	///   <para>Sets pixel colors of a cubemap face.</para>
	/// </summary>
	/// <param name="colors">Pixel data for the Cubemap face.</param>
	/// <param name="face">The face to which the new data should be applied.</param>
	/// <param name="miplevel">The mipmap level for the face.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetPixels(Color[] colors, CubemapFace face, [DefaultValue("0")] int miplevel);

	[ExcludeFromDocs]
	public void SetPixels(Color[] colors, CubemapFace face)
	{
		int miplevel = 0;
		SetPixels(colors, face, miplevel);
	}

	/// <summary>
	///   <para>Actually apply all previous SetPixel and SetPixels changes.</para>
	/// </summary>
	/// <param name="updateMipmaps">Should all mipmap levels be updated?</param>
	/// <param name="makeNoLongerReadable">Should the Cubemap texture data be readable/modifiable after changes are applied?</param>
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

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_Create([Writable] Cubemap mono, int size, TextureFormat format, bool mipmap);

	/// <summary>
	///   <para>Performs smoothing of near edge regions.</para>
	/// </summary>
	/// <param name="smoothRegionWidthInPixels">Pixel distance at edges over which to apply smoothing.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SmoothEdges([DefaultValue("1")] int smoothRegionWidthInPixels);

	[ExcludeFromDocs]
	public void SmoothEdges()
	{
		int smoothRegionWidthInPixels = 1;
		SmoothEdges(smoothRegionWidthInPixels);
	}
}
