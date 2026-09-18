using System;
using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Class for generating random data.</para>
/// </summary>
public sealed class Random
{
	/// <summary>
	///   <para>Sets the seed for the random number generator.</para>
	/// </summary>
	public static extern int seed
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Returns a random number between 0.0 [inclusive] and 1.0 [inclusive] (Read Only).</para>
	/// </summary>
	public static extern float value
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Returns a random point inside a sphere with radius 1 (Read Only).</para>
	/// </summary>
	public static Vector3 insideUnitSphere
	{
		get
		{
			INTERNAL_get_insideUnitSphere(out var result);
			return result;
		}
	}

	/// <summary>
	///   <para>Returns a random point inside a circle with radius 1 (Read Only).</para>
	/// </summary>
	public static Vector2 insideUnitCircle
	{
		get
		{
			GetRandomUnitCircle(out var output);
			return output;
		}
	}

	/// <summary>
	///   <para>Returns a random point on the surface of a sphere with radius 1 (Read Only).</para>
	/// </summary>
	public static Vector3 onUnitSphere
	{
		get
		{
			INTERNAL_get_onUnitSphere(out var result);
			return result;
		}
	}

	/// <summary>
	///   <para>Returns a random rotation (Read Only).</para>
	/// </summary>
	public static Quaternion rotation
	{
		get
		{
			INTERNAL_get_rotation(out var result);
			return result;
		}
	}

	/// <summary>
	///   <para>Returns a random rotation with uniform distribution (Read Only).</para>
	/// </summary>
	public static Quaternion rotationUniform
	{
		get
		{
			INTERNAL_get_rotationUniform(out var result);
			return result;
		}
	}

	/// <summary>
	///   <para>Returns a random float number between and min [inclusive] and max [inclusive] (Read Only).</para>
	/// </summary>
	/// <param name="min"></param>
	/// <param name="max"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern float Range(float min, float max);

	/// <summary>
	///   <para>Returns a random integer number between min [inclusive] and max [exclusive] (Read Only).</para>
	/// </summary>
	/// <param name="min"></param>
	/// <param name="max"></param>
	public static int Range(int min, int max)
	{
		return RandomRangeInt(min, max);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern int RandomRangeInt(int min, int max);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_get_insideUnitSphere(out Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void GetRandomUnitCircle(out Vector2 output);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_get_onUnitSphere(out Vector3 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_get_rotation(out Quaternion value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_get_rotationUniform(out Quaternion value);

	[Obsolete("Use Random.Range instead")]
	public static float RandomRange(float min, float max)
	{
		return Range(min, max);
	}

	[Obsolete("Use Random.Range instead")]
	public static int RandomRange(int min, int max)
	{
		return Range(min, max);
	}
}
