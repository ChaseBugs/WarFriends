using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

/// <summary>Checks exact battle ownership through the original level and card-visual loading chain.</summary>
public static class UnityBattleVisualLoadingAudit
{
    private const string RequestedKey = "WarFriends.BattleVisualLoadingAudit";
    private const string ResourceName = "__AbortVisualTexture";
    private const int ObservationFrames = 6;
    private const int TimeoutSeconds = 10;

    /// <summary>Creates a local texture fixture and enters the existing isolated Play Mode audit.</summary>
    public static void RunAsync()
    {
        PrepareFixture();
        UnityAbortNoticeAudit.RunAsync();
    }

    /// <summary>Also checks real native bundle completion when WAR_NATIVE_ATLAS_BUNDLE is configured.</summary>
    public static void RunWithNativeBundleAsync()
    {
        PrepareFixture();
        UnityCompletedAtlasAudit.RunAsync();
    }

    private static void PrepareFixture()
    {
        string path = "Assets/Resources/" + ResourceName + ".asset";
        if (AssetDatabase.LoadAssetAtPath<Texture2D>(path) == null)
        {
            var texture = new Texture2D(1, 1);
            AssetDatabase.CreateAsset(texture, path);
        }
        SessionState.SetBool(RequestedKey, true);
    }

    /// <summary>Requires old battle visuals to stay cleared while same-host unscoped previews continue.</summary>
    public static async Task VerifyIfRequestedAsync()
    {
        if (!SessionState.GetBool(RequestedKey, false))
        {
            return;
        }
        SessionState.SetBool(RequestedKey, false);
        var root = new GameObject("BattleVisualLoadingProbe");
        root.SetActive(false);
        var slots = root.AddComponent<AbortUpgradeSlotsProbe>();
        var level = root.AddComponent<AbortVisualLevelProbe>();
        level.upgradeSlots = slots;
        slots.unitSounds = new List<Sounds3DEnum>();
        slots.cardVisuals = new List<TechnologyVisualDefinition> { CreateVisual(), CreateVisual() };
        root.SetActive(true);
        var scope = new BattleResourceLoadScope();
        try
        {
            scope.Start(level, level.PrepareVisualsForCardCoroutine(true, false));
            level.StartCoroutine(slots.LoadOpponentVisualsCoroutineCards());
            Require(slots.cardVisuals[0].materialTetxureBlue != null &&
                slots.cardVisuals[1].materialTetxureBlue == null,
                "The real source chain did not pause between the two card visual definitions.");
            slots.NullCardVisuals(true, false);
            scope.Cancel();
            await WaitFramesAsync();
            Require(scope.PendingCount == 0 &&
                slots.cardVisuals.TrueForAll(visual => visual.materialTetxureBlue == null),
                "A separately hosted old battle loader repopulated cleared card visuals.");
            Require(slots.cardVisuals.TrueForAll(visual => visual.materialTetxureRed != null),
                "Battle cancellation stopped the unrelated preview lane on the same coroutine host.");
            var fresh = new BattleResourceLoadScope();
            fresh.Start(level, level.PrepareVisualsForCardCoroutine(true, false));
            await WaitFramesAsync();
            Require(fresh.PendingCount == 0 &&
                slots.cardVisuals.TrueForAll(visual => visual.materialTetxureBlue != null),
                "A fresh battle scope did not load its original card visuals normally.");
            await UnityMissionLoadingAudit.VerifyAsync(level, slots);
            await UnityResourceScopeFailureAudit.VerifyAsync(level, slots);
            await UnityResourceExecutionFailureAudit.VerifyAsync(level, slots);
            Debug.Log("PASS: original level/card visual chain cancels across hosts without repopulating cleared " +
                "visuals; unrelated same-host preview and a fresh battle scope finish normally.");
        }
        finally
        {
            scope.Cancel();
            slots.StopAllCoroutines();
            level.StopAllCoroutines();
            root.SetActive(false);
        }
    }

    private static TechnologyVisualDefinition CreateVisual()
    {
        return new TechnologyVisualDefinition
        {
            materialTextrePathBlue = ResourceName,
            materialTextrePathRed = ResourceName,
        };
    }

    private static async Task WaitFramesAsync()
    {
        int target = Time.frameCount + ObservationFrames;
        DateTime deadline = DateTime.UtcNow.AddSeconds(TimeoutSeconds);
        while (Time.frameCount < target)
        {
            Require(DateTime.UtcNow < deadline, "Visual loading frame observation timed out.");
            await Task.Yield();
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
