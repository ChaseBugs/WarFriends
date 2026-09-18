using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Controls the from script.</para>
/// </summary>
public sealed class Profiler
{
	public static extern bool supported
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Sets profiler output file in built players.</para>
	/// </summary>
	public static extern string logFile
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Sets profiler output file in built players.</para>
	/// </summary>
	public static extern bool enableBinaryLog
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Enables the Profiler.</para>
	/// </summary>
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
	///   <para>Resize the profiler sample buffers to allow the desired amount of samples per thread.</para>
	/// </summary>
	public static extern int maxNumberOfSamplesPerFrame
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Heap size used by the program.</para>
	/// </summary>
	/// <returns>
	///   <para>Size of the used heap in bytes, (or 0 if the profiler is disabled).</para>
	/// </returns>
	public static extern uint usedHeapSize
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Displays the recorded profiledata in the profiler.</para>
	/// </summary>
	/// <param name="file"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[Conditional("ENABLE_PROFILER")]
	[WrapperlessIcall]
	public static extern void AddFramesFromFile(string file);

	/// <summary>
	///   <para>Begin profiling a piece of code with a custom label.</para>
	/// </summary>
	/// <param name="name"></param>
	/// <param name="targetObject"></param>
	[Conditional("ENABLE_PROFILER")]
	public static void BeginSample(string name)
	{
		BeginSampleOnly(name);
	}

	/// <summary>
	///   <para>Begin profiling a piece of code with a custom label.</para>
	/// </summary>
	/// <param name="name"></param>
	/// <param name="targetObject"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	[Conditional("ENABLE_PROFILER")]
	public static extern void BeginSample(string name, Object targetObject);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void BeginSampleOnly(string name);

	/// <summary>
	///   <para>End profiling a piece of code with a custom label.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[Conditional("ENABLE_PROFILER")]
	[WrapperlessIcall]
	public static extern void EndSample();

	/// <summary>
	///   <para>Returns the runtime memory usage of the resource.</para>
	/// </summary>
	/// <param name="o"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int GetRuntimeMemorySize(Object o);

	/// <summary>
	///   <para>Returns the size of the mono heap.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern uint GetMonoHeapSize();

	/// <summary>
	///   <para>Returns the used size from mono.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern uint GetMonoUsedSize();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern uint GetTotalAllocatedMemory();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern uint GetTotalUnusedReservedMemory();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern uint GetTotalReservedMemory();
}
