using System;
using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>The Caching class lets you manage cached AssetBundles, downloaded using WWW.LoadFromCacheOrDownload.</para>
/// </summary>
public sealed class Caching
{
	[Obsolete("this API is not for public use.")]
	public static extern CacheIndex[] index
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The number of currently unused bytes in the cache.</para>
	/// </summary>
	public static extern long spaceFree
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The total number of bytes that can potentially be allocated for caching.</para>
	/// </summary>
	public static extern long maximumAvailableDiskSpace
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Used disk space in bytes.</para>
	/// </summary>
	public static extern long spaceOccupied
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	[Obsolete("Please use Caching.spaceFree instead")]
	public static extern int spaceAvailable
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	[Obsolete("Please use Caching.spaceOccupied instead")]
	public static extern int spaceUsed
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The number of seconds that an AssetBundle may remain unused in the cache before it is automatically deleted.</para>
	/// </summary>
	public static extern int expirationDelay
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Is Caching enabled?</para>
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
	///   <para>Is caching ready?</para>
	/// </summary>
	public static extern bool ready
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>(This is a WebPlayer-only function).</para>
	/// </summary>
	/// <param name="string">Signature The authentification signature provided by Unity.</param>
	/// <param name="int">Size The number of bytes allocated to this cache.</param>
	/// <param name="name"></param>
	/// <param name="domain"></param>
	/// <param name="size"></param>
	/// <param name="signature"></param>
	/// <param name="expiration"></param>
	public static bool Authorize(string name, string domain, long size, string signature)
	{
		return Authorize(name, domain, size, -1, signature);
	}

	/// <summary>
	///   <para>(This is a WebPlayer-only function).</para>
	/// </summary>
	/// <param name="string">Signature The authentification signature provided by Unity.</param>
	/// <param name="int">Size The number of bytes allocated to this cache.</param>
	/// <param name="name"></param>
	/// <param name="domain"></param>
	/// <param name="size"></param>
	/// <param name="signature"></param>
	/// <param name="expiration"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool Authorize(string name, string domain, long size, int expiration, string signature);

	/// <summary>
	///   <para>TODO.</para>
	/// </summary>
	/// <param name="name"></param>
	/// <param name="domain"></param>
	/// <param name="size"></param>
	/// <param name="signature"></param>
	/// <param name="expiration"></param>
	[Obsolete("Size is now specified as a long")]
	public static bool Authorize(string name, string domain, int size, int expiration, string signature)
	{
		return Authorize(name, domain, (long)size, expiration, signature);
	}

	/// <summary>
	///   <para>TODO.</para>
	/// </summary>
	/// <param name="name"></param>
	/// <param name="domain"></param>
	/// <param name="size"></param>
	/// <param name="signature"></param>
	/// <param name="expiration"></param>
	[Obsolete("Size is now specified as a long")]
	public static bool Authorize(string name, string domain, int size, string signature)
	{
		return Authorize(name, domain, (long)size, signature);
	}

	/// <summary>
	///   <para>Delete all AssetBundle and Procedural Material content that has been cached by the current application.</para>
	/// </summary>
	/// <returns>
	///   <para>True when cache cleaning succeeded, false if cache was in use.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool CleanCache();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[Obsolete("this API is not for public use.")]
	[WrapperlessIcall]
	public static extern bool CleanNamedCache(string name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[Obsolete("This function is obsolete and has no effect.")]
	[WrapperlessIcall]
	public static extern bool DeleteFromCache(string url);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[Obsolete("This function is obsolete and will always return -1. Use IsVersionCached instead.")]
	[WrapperlessIcall]
	public static extern int GetVersionFromCache(string url);

	/// <summary>
	///   <para>Checks if an AssetBundle is cached.</para>
	/// </summary>
	/// <param name="string">Url The filename of the AssetBundle. Domain and path information are stripped from this string automatically.</param>
	/// <param name="int">Version The version number of the AssetBundle to check for. Negative values are not allowed.</param>
	/// <param name="url"></param>
	/// <param name="version"></param>
	/// <returns>
	///   <para>True if an AssetBundle matching the url and version parameters has previously been loaded using WWW.LoadFromCacheOrDownload() and is currently stored in the cache. Returns false if the AssetBundle is not in cache, either because it has been flushed from the cache or was never loaded using the Caching API.</para>
	/// </returns>
	public static bool IsVersionCached(string url, int version)
	{
		Hash128 hash = new Hash128(0u, 0u, 0u, (uint)version);
		return IsVersionCached(url, hash);
	}

	public static bool IsVersionCached(string url, Hash128 hash)
	{
		return INTERNAL_CALL_IsVersionCached(url, ref hash);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern bool INTERNAL_CALL_IsVersionCached(string url, ref Hash128 hash);

	/// <summary>
	///   <para>Bumps the timestamp of a cached file to be the current time.</para>
	/// </summary>
	/// <param name="url"></param>
	/// <param name="version"></param>
	public static bool MarkAsUsed(string url, int version)
	{
		Hash128 hash = new Hash128(0u, 0u, 0u, (uint)version);
		return MarkAsUsed(url, hash);
	}

	public static bool MarkAsUsed(string url, Hash128 hash)
	{
		return INTERNAL_CALL_MarkAsUsed(url, ref hash);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern bool INTERNAL_CALL_MarkAsUsed(string url, ref Hash128 hash);
}
