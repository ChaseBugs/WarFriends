using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>Runs the actual pending game-atlas loader on its own host through abort invalidation.</summary>
public static class UnityAbortAtlasLoadingAudit
{
    private const int ObservationFrames = 4;
    private const int TimeoutSeconds = 10;

    /// <summary>Requires a cancelled loader to exit before reading its unavailable bundle provider again.</summary>
    public static async Task VerifyAsync()
    {
        var root = new GameObject("AbortAtlasLoaderProbe");
        root.SetActive(false);
        var atlas = root.AddComponent<AbortAtlasPreparerProbe>();
        AssetBundleManager bundles = Resources.FindObjectsOfTypeAll<AssetBundleManager>()
            .Single(value => value.gameObject.scene.IsValid());
        var provider = typeof(Singleton<AssetBundleManager>).GetField("_instance",
            BindingFlags.Static | BindingFlags.NonPublic);
        var references = typeof(AssetBundleManager).GetField("mAssetBundleReferencesDic",
            BindingFlags.Instance | BindingFlags.NonPublic);
        object previousProvider = provider.GetValue(null);
        object previousReferences = references.GetValue(bundles);
        UIAtlas originalAtlas = Resources.FindObjectsOfTypeAll<UIAtlas>()
            .First(value => !string.IsNullOrEmpty(value.pngPath));
        atlas.nGuiSpriteSheets = new List<AtlasPreparer.TextureDatasNgui>
        {
            new AtlasPreparer.TextureDatasNgui
            {
                atlas = originalAtlas,
                mode = AtlasPreparer.AtlasMode.Game,
                resourceMode = AtlasPreparer.ResourceMode.AssetBundle,
            },
        };
        atlas.toolkitSrites = new List<AtlasPreparer.TextureDatas2DToolkit>();
        var atlasProvider = typeof(Singleton<AtlasPreparer>).GetField("_instance",
            BindingFlags.Static | BindingFlags.NonPublic);
        object previousAtlasProvider = atlasProvider.GetValue(null);
        try
        {
            provider.SetValue(null, bundles);
            atlasProvider.SetValue(null, atlas);
            root.SetActive(true);
            for (int cycle = 0; cycle < 2; cycle++)
            {
                references.SetValue(bundles, new Dictionary<string, AssetBundleReference>());
                bool finished = false;
                atlas.StartCoroutine(ObserveCompletion(atlas.LoadGameCoroutine(), () => finished = true));
                await WaitFramesAsync();
                Require(!finished, "The source game loader did not retain its missing-bundle wait.");
                Singleton<GameController>.instance.StopAllCoroutines();
                var cancel = typeof(AtlasPreparer).GetMethod("CancelGameLoadingForAbort");
                Require(cancel != null, "The explicit game-atlas abort invalidation entry is missing.");
                cancel.Invoke(atlas, null);
                references.SetValue(bundles, null);
                await WaitFramesAsync();
                Require(finished, "The old game-atlas loader survived abort invalidation on its independent host.");
            }
            Debug.Log("PASS: original pending game-atlas loaders exit on abort across two scopes without " +
                "rereading unavailable bundle state; no completed-bundle or full resource/menu proof.");
        }
        finally
        {
            atlas.StopAllCoroutines();
            root.SetActive(false);
            references.SetValue(bundles, previousReferences);
            provider.SetValue(null, previousProvider);
            atlasProvider.SetValue(null, previousAtlasProvider);
        }
    }

    private static IEnumerator ObserveCompletion(IEnumerator loading, Action completed)
    {
        yield return loading;
        completed();
    }

    private static async Task WaitFramesAsync()
    {
        int targetFrame = Time.frameCount + ObservationFrames;
        DateTime deadline = DateTime.UtcNow.AddSeconds(TimeoutSeconds);
        while (Time.frameCount < targetFrame)
        {
            Require(DateTime.UtcNow < deadline, "The native frame observation timed out.");
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
