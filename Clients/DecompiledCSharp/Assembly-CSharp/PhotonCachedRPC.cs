using System.Collections.Generic;
using UnityEngine;

public class PhotonCachedRPC : Core_BaseScript
{
	private struct CachedRPC
	{
		public string function;

		public object[] parameters;

		public PhotonTargets target;

		public PhotonView view;

		public PhotonPlayer player;
	}

	private static List<PhotonCachedRPC> mPhotonCachedRpcs = new List<PhotonCachedRPC>();

	private readonly List<CachedRPC> mCachedRpcs = new List<CachedRPC>();

	public static List<PhotonCachedRPC> photonCachedRpcs => mPhotonCachedRpcs;

	public static void SendOfflineRPC(PhotonView view, string function, PhotonTargets target, params object[] parameters)
	{
		if (PhotonConnectionManager.isInRoom)
		{
			view.RPC(function, target, parameters);
			Debug.Log($"Executing RPC {function} {parameters}");
		}
		else
		{
			PhotonCachedRPC photonCachedRPC = view.gameObject.GetComponent<PhotonCachedRPC>() ?? view.gameObject.AddComponent<PhotonCachedRPC>();
			photonCachedRPC.CacheRPC(view, function, target, null, parameters);
		}
	}

	public static void SendOfflineRPC(PhotonView view, string function, PhotonPlayer targetPlayer, params object[] parameters)
	{
		if (PhotonConnectionManager.isInRoom)
		{
			view.RPC(function, targetPlayer, parameters);
			Debug.Log($"Executing RPC {function} {parameters}");
		}
		else
		{
			PhotonCachedRPC photonCachedRPC = view.gameObject.GetComponent<PhotonCachedRPC>() ?? view.gameObject.AddComponent<PhotonCachedRPC>();
			photonCachedRPC.CacheRPC(view, function, PhotonTargets.All, targetPlayer, parameters);
		}
	}

	private void CacheRPC(PhotonView view, string function, PhotonTargets target, PhotonPlayer player, params object[] parameters)
	{
		mCachedRpcs.Add(new CachedRPC
		{
			view = view,
			function = function,
			target = target,
			parameters = parameters
		});
	}

	protected void Update()
	{
		if (!PhotonConnectionManager.isInRoom || mCachedRpcs.Count <= 0)
		{
			return;
		}
		foreach (CachedRPC mCachedRpc in mCachedRpcs)
		{
			Debug.Log($"Executing Oflline RPC {mCachedRpc.function} {mCachedRpc.parameters}");
			if (mCachedRpc.player != null)
			{
				mCachedRpc.view.RPC(mCachedRpc.function, mCachedRpc.player, mCachedRpc.parameters);
			}
			else
			{
				mCachedRpc.view.RPC(mCachedRpc.function, mCachedRpc.target, mCachedRpc.parameters);
			}
		}
		mCachedRpcs.Clear();
	}

	private void OnJoinedNewRoom()
	{
		mCachedRpcs.Clear();
	}

	private void OnEnable()
	{
		mPhotonCachedRpcs.Add(this);
	}
}
