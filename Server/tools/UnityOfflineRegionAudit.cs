using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

/// <summary>Checks omitted Photon-region metadata without normal account boot or Photon peer setup.</summary>
public static class UnityOfflineRegionAudit
{
    private const int UnknownPingMilliseconds = 4000;
    private const int MeasuredPingMilliseconds = 100;

    /// <summary>Requires no fabricated route/latency and preserves source ordering for real cached measurements.</summary>
    public static void Verify()
    {
        var previousRegions = PhotonConnectionManager.bestRegions;
        PropertyInfo regionProperty = typeof(PhotonConnectionManager).GetProperty("bestRegion");
        object previousRegion = regionProperty.GetValue(null, null);
        try
        {
            regionProperty.SetValue(null, CloudRegionCode.none, null);
            PhotonConnectionManager.bestRegions = null;
            VerifyMissingMeasurements();
            PhotonConnectionManager.bestRegions = new Dictionary<CloudRegionCode, int>();
            VerifyMissingMeasurements();
            bool isGood;
            Require(PhotonConnectionManager.GetBestRegion(
                new Dictionary<CloudRegionCode, int> { { CloudRegionCode.eu, MeasuredPingMilliseconds } },
                new Dictionary<CloudRegionCode, int>(), out isGood) == CloudRegionCode.none && !isGood,
                "One player's measurements fabricated a mutually measured route.");
            PhotonConnectionManager.bestRegions = new Dictionary<CloudRegionCode, int>
            {
                { CloudRegionCode.au, UnknownPingMilliseconds }, { CloudRegionCode.eu, MeasuredPingMilliseconds }
            };
            Require(PhotonConnectionManager.bestRegionsSorted[0].Value1 == CloudRegionCode.eu &&
                !PhotonConnectionManager.HasMeasuredRegionPingAbove(MeasuredPingMilliseconds) &&
                PhotonConnectionManager.HasMeasuredRegionPingAbove(MeasuredPingMilliseconds - 1),
                "Known cached measurements changed their source ordering or strict high-ping comparison.");
            regionProperty.SetValue(null, CloudRegionCode.eu, null);
            Require(PhotonConnectionManager.pingToBestRegion == MeasuredPingMilliseconds,
                "The measured selected-region latency was discarded.");
            PhotonConnectionManager.bestRegions.Remove(CloudRegionCode.eu);
            Require(PhotonConnectionManager.pingToBestRegion == UnknownPingMilliseconds,
                "A missing selected region became zero latency.");
            VerifyStartup();
            Debug.Log("PASS: omitted/empty regions have no invented route or zero ping, do not force a latency bot, " +
                "and preserve cached measurement ordering; manager startup no longer configures a Photon peer.");
        }
        finally
        {
            PhotonConnectionManager.bestRegions = previousRegions;
            regionProperty.SetValue(null, previousRegion, null);
        }
    }

    private static void VerifyMissingMeasurements()
    {
        bool isGood;
        Require(PhotonConnectionManager.bestRegionsSorted.Count == 0 &&
            PhotonConnectionManager.pingToBestRegion == UnknownPingMilliseconds &&
            !PhotonConnectionManager.HasMeasuredRegionPingAbove(MeasuredPingMilliseconds) &&
            PhotonConnectionManager.GetBestAllowedRegion(new List<CloudRegionCode> { CloudRegionCode.eu }) ==
                CloudRegionCode.none &&
            PhotonConnectionManager.GetBestRegion(PhotonConnectionManager.bestRegions, null, out isGood) ==
                CloudRegionCode.none && !isGood,
            "Absent Photon metadata fabricated latency, routing eligibility or a high-ping bot decision.");
    }

    private static void VerifyStartup()
    {
        PhotonConnectionManager manager = Resources.FindObjectsOfTypeAll<PhotonConnectionManager>()
            .Single(value => value.gameObject.scene.IsValid());
        typeof(PhotonConnectionManager).GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(manager, null);
        manager.CheckIfShouldPing();
        manager.CheckPingsNow();
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
