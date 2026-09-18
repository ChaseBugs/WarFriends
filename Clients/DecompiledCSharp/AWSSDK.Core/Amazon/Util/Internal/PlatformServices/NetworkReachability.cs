using System;
using Amazon.Util.Storage.Internal;
using UnityEngine;

namespace Amazon.Util.Internal.PlatformServices;

public class NetworkReachability : INetworkReachability
{
	internal EventHandler<NetworkStatusEventArgs> mNetworkReachabilityChanged;

	internal static readonly object reachabilityChangedLock = new object();

	public NetworkStatus NetworkStatus => NetworkInfo.Reachability switch
	{
		UnityEngine.NetworkReachability.ReachableViaCarrierDataNetwork => NetworkStatus.ReachableViaCarrierDataNetwork, 
		UnityEngine.NetworkReachability.ReachableViaLocalAreaNetwork => NetworkStatus.ReachableViaWiFiNetwork, 
		_ => NetworkStatus.NotReachable, 
	};

	public event EventHandler<NetworkStatusEventArgs> NetworkReachabilityChanged
	{
		add
		{
			lock (reachabilityChangedLock)
			{
				mNetworkReachabilityChanged = (EventHandler<NetworkStatusEventArgs>)Delegate.Combine(mNetworkReachabilityChanged, value);
			}
		}
		remove
		{
			lock (reachabilityChangedLock)
			{
				mNetworkReachabilityChanged = (EventHandler<NetworkStatusEventArgs>)Delegate.Remove(mNetworkReachabilityChanged, value);
			}
		}
	}

	internal void OnNetworkReachabilityChanged(NetworkStatus status)
	{
		mNetworkReachabilityChanged?.Invoke(null, new NetworkStatusEventArgs(status));
	}
}
