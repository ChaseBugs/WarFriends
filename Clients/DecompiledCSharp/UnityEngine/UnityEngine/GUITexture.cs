using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>A texture image used in a 2D GUI.</para>
/// </summary>
public sealed class GUITexture : GUIElement
{
	/// <summary>
	///   <para>The color of the GUI texture.</para>
	/// </summary>
	public Color color
	{
		get
		{
			INTERNAL_get_color(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_color(ref value);
		}
	}

	/// <summary>
	///   <para>The texture used for drawing.</para>
	/// </summary>
	public extern Texture texture
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Pixel inset used for pixel adjustments for size and position.</para>
	/// </summary>
	public Rect pixelInset
	{
		get
		{
			INTERNAL_get_pixelInset(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_pixelInset(ref value);
		}
	}

	/// <summary>
	///   <para>The border defines the number of pixels from the edge that are not affected by scale.</para>
	/// </summary>
	public extern RectOffset border
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
	private extern void INTERNAL_get_color(out Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_color(ref Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_pixelInset(out Rect value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_pixelInset(ref Rect value);
}
