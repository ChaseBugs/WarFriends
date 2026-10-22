using System;
using System.Collections;
using System.Diagnostics;
using System.Net;
using ExitGames.Client.Photon;
using UnityEngine;

public class PhotonPingManager
{
	public bool UseNative;

	public static int Attempts = 5;

	public static bool IgnoreInitialAttempt = true;

	public static int MaxMilliseconsPerPing = 800;

	private int PingsRunning;

	public Region BestRegion
	{
		get
		{
			Region result = null;
			int num = int.MaxValue;
			foreach (Region availableRegion in PhotonNetwork.networkingPeer.AvailableRegions)
			{
				UnityEngine.Debug.Log("BestRegion checks region: " + availableRegion);
				if (availableRegion.Ping != 0 && availableRegion.Ping < num)
				{
					num = availableRegion.Ping;
					result = availableRegion;
				}
			}
			return result;
		}
	}

	public bool Done => PingsRunning == 0;

    public IEnumerator PingSocket(Region region)
    {
        // No DNS lookup or socket probe: endpoint selection belongs to the self-hosted Backend.
        yield break;
    }

    public static string ResolveHost(string hostName)
    {
        return string.Empty;
    }
}
