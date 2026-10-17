using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

/// <summary>Checks recovered RPC cache lifetime and its self-hosted transport boundary.</summary>
public static class UnityCachedRpcAudit
{
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;
    private const int RemoteActorId = 2;
    private const int SourceMapIndex = 0;

    /// <summary>Keeps one registry entry across re-enabling, and removes destroyed receivers.</summary>
    public static void VerifyRegistry()
    {
        int previousCount = PhotonCachedRPC.photonCachedRpcs.Count;
        var owner = new GameObject("CachedRpcRegistryFixture");
        try
        {
            var cache = owner.AddComponent<PhotonCachedRPC>();
            owner.SetActive(false);
            owner.SetActive(true);
            cache.enabled = false;
            cache.enabled = true;
            Require(PhotonCachedRPC.photonCachedRpcs.Count == previousCount + 1,
                "Re-enabling an RPC cache duplicated its new-room receiver.");
            owner.SetActive(false);
            Require(PhotonCachedRPC.photonCachedRpcs.Contains(cache),
                "Inactive RPC caches must still receive the recovered new-room cache reset.");
            QueuePriorMapRequest(cache, null);
            typeof(PhotonConnectionManager).GetMethod("InvalidateCachedRoomRequests",
                BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null);
            Require(GetQueue(cache).Count == 0, "New-room invalidation skipped an inactive cache.");
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }

        Require(PhotonCachedRPC.photonCachedRpcs.Count == previousCount,
            "A destroyed RPC cache remained in the new-room receiver registry.");
    }

    /// <summary>Rejects direct legacy sends and discards a pre-existing queue under a retained owner.</summary>
    public static void VerifyOwnedBoundary()
    {
        Require(PhotonConnectionManager.IsSelfHostedActive, "The fixture needs the retained session owner.");
        var owner = new GameObject("InactiveOwnedRpcCacheFixture");
        owner.SetActive(false);
        try
        {
            var view = owner.AddComponent<PhotonView>();
            var cache = owner.AddComponent<PhotonCachedRPC>();
            RequireRefusal(() => PhotonCachedRPC.SendOfflineRPC(view, "SetMapRPC",
                PhotonTargets.AllBufferedViaServer, SourceMapIndex));
            var remotePlayer = new PhotonPlayer(false, RemoteActorId, "FixtureRemote");
            RequireRefusal(() => PhotonCachedRPC.SendOfflineRPC(view, "SetMapRPC", remotePlayer, SourceMapIndex));

            // Model an entry queued before admission; do not send it through the now-owned public transport.
            QueuePriorMapRequest(cache, view);
            IList queued = GetQueue(cache);
            Require(queued.Count == 1, "The prior-session cache entry was not prepared.");
            typeof(PhotonCachedRPC).GetMethod("Update", PrivateInstance).Invoke(cache, null);
            Require(queued.Count == 0, "A prior Photon command survived self-hosted ownership.");
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }

        Debug.Log("PASS: RPC cache receivers survive disable without duplicates, destroyed receivers retire, " +
            "and retained self-hosted ownership rejects direct Photon sends and discards old queued RPCs.");
    }

    private static void QueuePriorMapRequest(PhotonCachedRPC cache, PhotonView view)
    {
        typeof(PhotonCachedRPC).GetMethod("CacheRPC", PrivateInstance).Invoke(cache,
            new object[]
            {
                view, "SetMapRPC", PhotonTargets.AllBufferedViaServer, null, new object[] { SourceMapIndex }
            });
    }

    private static IList GetQueue(PhotonCachedRPC cache)
    {
        return (IList)typeof(PhotonCachedRPC).GetField("mCachedRpcs", PrivateInstance).GetValue(cache);
    }

    private static void RequireRefusal(Action send)
    {
        try
        {
            send();
        }
        catch (InvalidOperationException failure)
        {
            Require(failure.Message == "Cached Photon RPCs cannot mutate a self-hosted battle.",
                "The cached transport failed for an unrelated reason.");
            return;
        }

        throw new InvalidOperationException("A legacy cached RPC was accepted by a self-hosted session.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
