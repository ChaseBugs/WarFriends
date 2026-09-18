using System;
using System.Runtime.CompilerServices;
using UnityEngineInternal;

namespace UnityEngine;

/// <summary>
///   <para>AssetBundles let you stream additional assets via the WWW class and instantiate them at runtime. AssetBundles are created via BuildPipeline.BuildAssetBundle.</para>
/// </summary>
public sealed class AssetBundle : Object
{
	/// <summary>
	///   <para>Main asset that was supplied when building the asset bundle (Read Only).</para>
	/// </summary>
	public extern Object mainAsset
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Asynchronously create an AssetBundle from a memory region.</para>
	/// </summary>
	/// <param name="binary"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern AssetBundleCreateRequest CreateFromMemory(byte[] binary);

	/// <summary>
	///   <para>Synchronously create an AssetBundle from a memory region.</para>
	/// </summary>
	/// <param name="binary">Array of bytes with the AssetBundle data.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern AssetBundle CreateFromMemoryImmediate(byte[] binary);

	/// <summary>
	///   <para>Loads an asset bundle from a disk.</para>
	/// </summary>
	/// <param name="path">Path of the file on disk
	///
	/// See Also: WWW.assetBundle, WWW.LoadFromCacheOrDownload.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern AssetBundle CreateFromFile(string path);

	/// <summary>
	///   <para>Check if an AssetBundle contains a specific object.</para>
	/// </summary>
	/// <param name="name"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool Contains(string name);

	[Obsolete("Method Load has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAsset instead and check the documentation for details.", true)]
	public Object Load(string name)
	{
		return null;
	}

	[Obsolete("Method Load has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAsset instead and check the documentation for details.", true)]
	public T Load<T>(string name) where T : Object
	{
		return (T)null;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
	[Obsolete("Method Load has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAsset instead and check the documentation for details.", true)]
	[WrapperlessIcall]
	public extern Object Load(string name, Type type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	[Obsolete("Method LoadAsync has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAssetAsync instead and check the documentation for details.", true)]
	public extern AssetBundleRequest LoadAsync(string name, Type type);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[Obsolete("Method LoadAll has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAllAssets instead and check the documentation for details.", true)]
	[WrapperlessIcall]
	public extern Object[] LoadAll(Type type);

	[Obsolete("Method LoadAll has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAllAssets instead and check the documentation for details.", true)]
	public Object[] LoadAll()
	{
		return null;
	}

	[Obsolete("Method LoadAll has been deprecated. Script updater cannot update it as the loading behaviour has changed. Please use LoadAllAssets instead and check the documentation for details.", true)]
	public T[] LoadAll<T>() where T : Object
	{
		return null;
	}

	/// <summary>
	///   <para>Loads asset with name of type T from the bundle.</para>
	/// </summary>
	/// <param name="name"></param>
	public Object LoadAsset(string name)
	{
		return LoadAsset(name, typeof(Object));
	}

	public T LoadAsset<T>(string name) where T : Object
	{
		return (T)LoadAsset(name, typeof(T));
	}

	/// <summary>
	///   <para>Loads asset with name of a given type from the bundle.</para>
	/// </summary>
	/// <param name="name"></param>
	/// <param name="type"></param>
	[TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
	public Object LoadAsset(string name, Type type)
	{
		if (name == null)
		{
			throw new NullReferenceException("The input asset name cannot be null.");
		}
		if (name.Length == 0)
		{
			throw new ArgumentException("The input asset name cannot be empty.");
		}
		if (type == null)
		{
			throw new NullReferenceException("The input type cannot be null.");
		}
		return LoadAsset_Internal(name, type);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	[TypeInferenceRule(TypeInferenceRules.TypeReferencedBySecondArgument)]
	private extern Object LoadAsset_Internal(string name, Type type);

	/// <summary>
	///   <para>Asynchronously loads asset with name of a given T from the bundle.</para>
	/// </summary>
	/// <param name="name"></param>
	public AssetBundleRequest LoadAssetAsync(string name)
	{
		return LoadAssetAsync(name, typeof(Object));
	}

	public AssetBundleRequest LoadAssetAsync<T>(string name)
	{
		return LoadAssetAsync(name, typeof(T));
	}

	/// <summary>
	///   <para>Asynchronously loads asset with name of a given type from the bundle.</para>
	/// </summary>
	/// <param name="name"></param>
	/// <param name="type"></param>
	public AssetBundleRequest LoadAssetAsync(string name, Type type)
	{
		if (name == null)
		{
			throw new NullReferenceException("The input asset name cannot be null.");
		}
		if (name.Length == 0)
		{
			throw new ArgumentException("The input asset name cannot be empty.");
		}
		if (type == null)
		{
			throw new NullReferenceException("The input type cannot be null.");
		}
		return LoadAssetAsync_Internal(name, type);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern AssetBundleRequest LoadAssetAsync_Internal(string name, Type type);

	/// <summary>
	///   <para>Loads asset and sub assets with name from the bundle.</para>
	/// </summary>
	/// <param name="name"></param>
	public Object[] LoadAssetWithSubAssets(string name)
	{
		return LoadAssetWithSubAssets(name, typeof(Object));
	}

	public T[] LoadAssetWithSubAssets<T>(string name) where T : Object
	{
		return Resources.ConvertObjects<T>(LoadAssetWithSubAssets(name, typeof(T)));
	}

	/// <summary>
	///   <para>Loads asset and sub assets with name of a given type from the bundle.</para>
	/// </summary>
	/// <param name="name"></param>
	/// <param name="type"></param>
	public Object[] LoadAssetWithSubAssets(string name, Type type)
	{
		if (name == null)
		{
			throw new NullReferenceException("The input asset name cannot be null.");
		}
		if (name.Length == 0)
		{
			throw new ArgumentException("The input asset name cannot be empty.");
		}
		if (type == null)
		{
			throw new NullReferenceException("The input type cannot be null.");
		}
		return LoadAssetWithSubAssets_Internal(name, type);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal extern Object[] LoadAssetWithSubAssets_Internal(string name, Type type);

	/// <summary>
	///   <para>Loads asset with sub assets with name of type T from the bundle asynchronously.</para>
	/// </summary>
	/// <param name="name"></param>
	public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name)
	{
		return LoadAssetWithSubAssetsAsync(name, typeof(Object));
	}

	public AssetBundleRequest LoadAssetWithSubAssetsAsync<T>(string name)
	{
		return LoadAssetWithSubAssetsAsync(name, typeof(T));
	}

	/// <summary>
	///   <para>Loads asset with sub assets with name of a given type from the bundle asynchronously.</para>
	/// </summary>
	/// <param name="name"></param>
	/// <param name="type"></param>
	public AssetBundleRequest LoadAssetWithSubAssetsAsync(string name, Type type)
	{
		if (name == null)
		{
			throw new NullReferenceException("The input asset name cannot be null.");
		}
		if (name.Length == 0)
		{
			throw new ArgumentException("The input asset name cannot be empty.");
		}
		if (type == null)
		{
			throw new NullReferenceException("The input type cannot be null.");
		}
		return LoadAssetWithSubAssetsAsync_Internal(name, type);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern AssetBundleRequest LoadAssetWithSubAssetsAsync_Internal(string name, Type type);

	/// <summary>
	///   <para>Loads all assets contained in the asset bundle that inherit from type T.</para>
	/// </summary>
	public Object[] LoadAllAssets()
	{
		return LoadAllAssets(typeof(Object));
	}

	public T[] LoadAllAssets<T>() where T : Object
	{
		return Resources.ConvertObjects<T>(LoadAllAssets(typeof(T)));
	}

	/// <summary>
	///   <para>Loads all assets contained in the asset bundle that inherit from type.</para>
	/// </summary>
	/// <param name="type"></param>
	public Object[] LoadAllAssets(Type type)
	{
		if (type == null)
		{
			throw new NullReferenceException("The input type cannot be null.");
		}
		return LoadAssetWithSubAssets_Internal(string.Empty, type);
	}

	/// <summary>
	///   <para>Loads all assets contained in the asset bundle asynchronously.</para>
	/// </summary>
	public AssetBundleRequest LoadAllAssetsAsync()
	{
		return LoadAllAssetsAsync(typeof(Object));
	}

	public AssetBundleRequest LoadAllAssetsAsync<T>()
	{
		return LoadAllAssetsAsync(typeof(T));
	}

	/// <summary>
	///   <para>Loads all assets contained in the asset bundle that inherit from type asynchronously.</para>
	/// </summary>
	/// <param name="type"></param>
	public AssetBundleRequest LoadAllAssetsAsync(Type type)
	{
		if (type == null)
		{
			throw new NullReferenceException("The input type cannot be null.");
		}
		return LoadAssetWithSubAssetsAsync_Internal(string.Empty, type);
	}

	/// <summary>
	///   <para>Unloads all assets in the bundle.</para>
	/// </summary>
	/// <param name="unloadAllLoadedObjects"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void Unload(bool unloadAllLoadedObjects);

	[Obsolete("This method is deprecated. Use GetAllAssetNames() instead.")]
	public string[] AllAssetNames()
	{
		return GetAllAssetNames();
	}

	/// <summary>
	///   <para>Return all asset names in the AssetBundle.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern string[] GetAllAssetNames();

	/// <summary>
	///   <para>Return all the scene asset paths (paths to *.unity assets) in the AssetBundle.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern string[] GetAllScenePaths();
}
