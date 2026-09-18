using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnityEngine.Experimental.Director;

/// <summary>
///   <para>Playables are customizable runtime objects that can be connected together in a tree to create complex behaviours.</para>
/// </summary>
public class Playable : IDisposable
{
	internal IntPtr m_Ptr;

	internal int m_UniqueId;

	/// <summary>
	///   <para>Current local time for this Playable.</para>
	/// </summary>
	public extern double time
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Current Experimental.Director.PlayState of this playable. This indicates whether the Playable is currently playing or paused.</para>
	/// </summary>
	public extern PlayState state
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The count of inputs on the Playable. This count includes slots that aren't connected to anything. This is equivalent to, but much faster than calling GetInputs().Length.</para>
	/// </summary>
	public extern int inputCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The count of inputs on the Playable. This count includes slots that aren't connected to anything. This is equivalent to, but much faster than calling GetOutputs().Length.</para>
	/// </summary>
	public extern int outputCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	public Playable()
	{
		m_Ptr = IntPtr.Zero;
		m_UniqueId = GenerateUniqueId();
		InstantiateEnginePlayable();
	}

	internal Playable(bool callCPPConstructor)
	{
		m_Ptr = IntPtr.Zero;
		m_UniqueId = GenerateUniqueId();
		if (callCPPConstructor)
		{
			InstantiateEnginePlayable();
		}
	}

	private void Dispose(bool disposing)
	{
		ReleaseEnginePlayable();
		m_Ptr = IntPtr.Zero;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern int GetUniqueIDInternal();

	public static bool Connect(Playable source, Playable target)
	{
		return Connect(source, target, -1, -1);
	}

	/// <summary>
	///   <para>Connects two Playables together.</para>
	/// </summary>
	/// <param name="source">Playable to be used as input.</param>
	/// <param name="target">Playable on which the input will be connected.</param>
	/// <param name="sourceOutputPort">Optional index of the output on the source Playable.</param>
	/// <param name="targetInputPort">Optional index of the input on the target Playable.</param>
	/// <returns>
	///   <para>Returns false if the operation could not be completed.</para>
	/// </returns>
	public static bool Connect(Playable source, Playable target, int sourceOutputPort, int targetInputPort)
	{
		if (!CheckPlayableValidity(source, "source") && !CheckPlayableValidity(target, "target"))
		{
			return false;
		}
		if (source != null && !source.CheckInputBounds(sourceOutputPort, acceptAny: true))
		{
			return false;
		}
		if (!target.CheckInputBounds(targetInputPort, acceptAny: true))
		{
			return false;
		}
		return ConnectInternal(source, target, sourceOutputPort, targetInputPort);
	}

	/// <summary>
	///   <para>Disconnects an input from a Playable.</para>
	/// </summary>
	/// <param name="right">Playable from which the input will be disconnected.</param>
	/// <param name="inputPort">Index of the input to disconnect.</param>
	/// <param name="target"></param>
	public static void Disconnect(Playable target, int inputPort)
	{
		if (CheckPlayableValidity(target, "target") && target.CheckInputBounds(inputPort))
		{
			DisconnectInternal(target, inputPort);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void ReleaseEnginePlayable();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void InstantiateEnginePlayable();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern int GenerateUniqueId();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern bool SetInputWeightInternal(int inputIndex, float weight);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern float GetInputWeightInternal(int inputIndex);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal static extern bool ConnectInternal(Playable source, Playable target, int sourceOutputPort, int targetInputPort);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal static extern void DisconnectInternal(Playable target, int inputPort);

	/// <summary>
	///   <para>Returns the Playable connected at the specified index.</para>
	/// </summary>
	/// <param name="inputPort">Index of the input.</param>
	/// <returns>
	///   <para>Playable connected at the index specified, or null if the index is valid but is not connected to anything. This happens if there was once a Playable connected at the index, but was disconnected via Playable::Disconnect.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Playable GetInput(int inputPort);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Playable[] GetInputs();

	/// <summary>
	///   <para>Safely disconnects all connected inputs and resizes the input array to 0.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void ClearInputs();

	/// <summary>
	///   <para>Returns the Playable connected at the specified output index.</para>
	/// </summary>
	/// <param name="outputPort">Index of the output.</param>
	/// <returns>
	///   <para>Playable connected at the output index specified, or null if the index is valid but is not connected to anything. This happens if there was once a Playable connected at the index, but was disconnected via Playable::Disconnect.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Playable GetOutput(int outputPort);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Playable[] GetOutputs();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void GetInputsInternal(object list);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void GetOutputsInternal(object list);

	~Playable()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	///   <para>Implements IDisposable. Call this method to release the resources allocated by the Playable.</para>
	/// </summary>
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public override bool Equals(object p)
	{
		return CompareIntPtr(this, p as Playable);
	}

	public override int GetHashCode()
	{
		return m_UniqueId;
	}

	internal static bool CompareIntPtr(Playable lhs, Playable rhs)
	{
		bool flag = (object)lhs == null || !IsNativePlayableAlive(lhs);
		bool flag2 = (object)rhs == null || !IsNativePlayableAlive(rhs);
		if (flag2 && flag)
		{
			return true;
		}
		if (flag2)
		{
			return !IsNativePlayableAlive(lhs);
		}
		if (flag)
		{
			return !IsNativePlayableAlive(rhs);
		}
		return lhs.GetUniqueIDInternal() == rhs.GetUniqueIDInternal();
	}

	internal static bool IsNativePlayableAlive(Playable p)
	{
		return p.m_Ptr != IntPtr.Zero;
	}

	internal static bool CheckPlayableValidity(Playable playable, string name)
	{
		if (playable == null)
		{
			throw new NullReferenceException("Playable " + name + "is null");
		}
		return true;
	}

	internal bool CheckInputBounds(int inputIndex)
	{
		return CheckInputBounds(inputIndex, acceptAny: false);
	}

	internal bool CheckInputBounds(int inputIndex, bool acceptAny)
	{
		if (inputIndex == -1 && acceptAny)
		{
			return true;
		}
		if (inputIndex < 0)
		{
			throw new IndexOutOfRangeException("Index must be greater than 0");
		}
		Playable[] inputs = GetInputs();
		if (inputs.Length <= inputIndex)
		{
			throw new IndexOutOfRangeException("inputIndex " + inputIndex + " is greater than the number of available inputs (" + inputs.Length + ").");
		}
		return true;
	}

	/// <summary>
	///   <para>Get the weight of the Playable at a specified index.</para>
	/// </summary>
	/// <param name="inputIndex">Index of the Playable.</param>
	/// <returns>
	///   <para>Weight of the input Playable. Returns -1 if there is no input connected at this input index.</para>
	/// </returns>
	public float GetInputWeight(int inputIndex)
	{
		if (CheckInputBounds(inputIndex))
		{
			return GetInputWeightInternal(inputIndex);
		}
		return -1f;
	}

	/// <summary>
	///   <para>Set the weight of an input.</para>
	/// </summary>
	/// <param name="inputIndex">Index of the input.</param>
	/// <param name="weight">Weight of the input.</param>
	/// <returns>
	///   <para>Returns false if there is no input Playable connected at that index.</para>
	/// </returns>
	public bool SetInputWeight(int inputIndex, float weight)
	{
		if (CheckInputBounds(inputIndex))
		{
			return SetInputWeightInternal(inputIndex, weight);
		}
		return false;
	}

	public void GetInputs(List<Playable> inputList)
	{
		inputList.Clear();
		GetInputsInternal(inputList);
	}

	public void GetOutputs(List<Playable> outputList)
	{
		outputList.Clear();
		GetOutputsInternal(outputList);
	}

	/// <summary>
	///   <para>Prepares the Experimental.Director.Playable tree for the next frame. PrepareFrame is called before the tree is evaluated.</para>
	/// </summary>
	/// <param name="info">Data for the current frame.</param>
	public virtual void PrepareFrame(FrameData info)
	{
	}

	/// <summary>
	///   <para>Evaluates the Playable with a delta time.</para>
	/// </summary>
	/// <param name="info">The Experimental.Director.FrameData for the current frame.</param>
	/// <param name="playerData">Custom data passed down the tree, specified in DirectorPlayer.Play.</param>
	public virtual void ProcessFrame(FrameData info, object playerData)
	{
	}

	/// <summary>
	///   <para>Callback called when the current time has changed</para>
	/// </summary>
	/// <param name="localTime">New local time</param>
	public virtual void OnSetTime(float localTime)
	{
	}

	/// <summary>
	///   <para>Callback called when the PlayState has changed</para>
	/// </summary>
	/// <param name="newState">New PlayState</param>
	public virtual void OnSetPlayState(PlayState newState)
	{
	}

	public static bool operator ==(Playable x, Playable y)
	{
		return CompareIntPtr(x, y);
	}

	public static bool operator !=(Playable x, Playable y)
	{
		return !CompareIntPtr(x, y);
	}

	public static implicit operator bool(Playable exists)
	{
		return !CompareIntPtr(exists, null);
	}
}
