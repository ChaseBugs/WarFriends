using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Renders a Sprite for 2D graphics.</para>
/// </summary>
public sealed class SpriteRenderer : Renderer
{
	/// <summary>
	///   <para>The Sprite to render.</para>
	/// </summary>
	public Sprite sprite
	{
		get
		{
			return GetSprite_INTERNAL();
		}
		set
		{
			SetSprite_INTERNAL(value);
		}
	}

	/// <summary>
	///   <para>Rendering color for the Sprite graphic.</para>
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

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern Sprite GetSprite_INTERNAL();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void SetSprite_INTERNAL(Sprite sprite);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_color(out Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_color(ref Color value);
}
