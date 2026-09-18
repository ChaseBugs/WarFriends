using System;
using UnityEngine;

public class AssetBundleLoadManifestOperation : AssetBundleLoadAssetOperationFull
{
	public AssetBundleLoadManifestOperation(string bundleName, string assetName, Type type)
		: base(bundleName, assetName, type)
	{
	}

	public override bool Update()
	{
		base.Update();
		if (m_Request != null && m_Request.isDone)
		{
			Debug.Log("AssetBundleManifestObjectt loaded");
			Singleton<AssetBundleManager>.instance.AssetBundleManifestObject = GetAsset<AssetBundleManifest>();
			return false;
		}
		return true;
	}
}
