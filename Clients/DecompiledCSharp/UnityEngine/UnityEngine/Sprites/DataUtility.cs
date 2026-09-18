using System.Runtime.CompilerServices;

namespace UnityEngine.Sprites;

/// <summary>
///   <para>Helper utilities for accessing Sprite data.</para>
/// </summary>
public sealed class DataUtility
{
	/// <summary>
	///   <para>Inner UV's of the Sprite.</para>
	/// </summary>
	/// <param name="sprite"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern Vector4 GetInnerUV(Sprite sprite);

	/// <summary>
	///   <para>Outer UV's of the Sprite.</para>
	/// </summary>
	/// <param name="sprite"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern Vector4 GetOuterUV(Sprite sprite);

	/// <summary>
	///   <para>Return the padding on the sprite.</para>
	/// </summary>
	/// <param name="sprite"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern Vector4 GetPadding(Sprite sprite);

	/// <summary>
	///   <para>Minimum width and height of the Sprite.</para>
	/// </summary>
	/// <param name="sprite"></param>
	public static Vector2 GetMinSize(Sprite sprite)
	{
		Internal_GetMinSize(sprite, out var output);
		return output;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_GetMinSize(Sprite sprite, out Vector2 output);
}
