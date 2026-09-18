using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>The line renderer is used to draw free-floating lines in 3D space.</para>
/// </summary>
public sealed class LineRenderer : Renderer
{
	/// <summary>
	///   <para>If enabled, the lines are defined in world space.</para>
	/// </summary>
	public extern bool useWorldSpace
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Set the line width at the start and at the end.</para>
	/// </summary>
	/// <param name="start"></param>
	/// <param name="end"></param>
	public void SetWidth(float start, float end)
	{
		INTERNAL_CALL_SetWidth(this, start, end);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_SetWidth(LineRenderer self, float start, float end);

	/// <summary>
	///   <para>Set the line color at the start and at the end.</para>
	/// </summary>
	/// <param name="start"></param>
	/// <param name="end"></param>
	public void SetColors(Color start, Color end)
	{
		INTERNAL_CALL_SetColors(this, ref start, ref end);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_SetColors(LineRenderer self, ref Color start, ref Color end);

	/// <summary>
	///   <para>Set the number of line segments.</para>
	/// </summary>
	/// <param name="count"></param>
	public void SetVertexCount(int count)
	{
		INTERNAL_CALL_SetVertexCount(this, count);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_SetVertexCount(LineRenderer self, int count);

	/// <summary>
	///   <para>Set the position of the vertex in the line.</para>
	/// </summary>
	/// <param name="index"></param>
	/// <param name="position"></param>
	public void SetPosition(int index, Vector3 position)
	{
		INTERNAL_CALL_SetPosition(this, index, ref position);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_SetPosition(LineRenderer self, int index, ref Vector3 position);
}
