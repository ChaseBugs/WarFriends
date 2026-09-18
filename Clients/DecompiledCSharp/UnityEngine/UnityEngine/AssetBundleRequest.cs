using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine;

/// <summary>
///   <para>Asynchronous load request from an AssetBundle.</para>
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public sealed class AssetBundleRequest : AsyncOperation
{
	/// <summary>
	///   <para>Asset object being loaded (Read Only).</para>
	/// </summary>
	public extern Object asset
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Asset objects with sub assets being loaded. (Read Only)</para>
	/// </summary>
	public extern Object[] allAssets
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}
}
