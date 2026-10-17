using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

/// <summary>Verifies late abort and fresh-scope publication using a real locally built Unity bundle.</summary>
public static class UnityCompletedAtlasAudit
{
    private const string RequestedKey = "WarFriends.CompletedAtlasAudit";
    private const string OutputKey = RequestedKey + ".Output";
    private const int TimeoutSeconds = 15;
    /// <summary>The native texture address used by the original loader.</summary>
    public const string TextureName = UnityNativeAtlasBundleBuilder.TextureName;
    /// <summary>The canonical bundle identity derived from the atlas texture path.</summary>
    public const string BundleName = UnityNativeAtlasBundleBuilder.BundleName;

    /// <summary>Reads the separately built fixture and enters the original modal audit.</summary>
    public static void RunAsync()
    {
        string output = Environment.GetEnvironmentVariable("WAR_NATIVE_ATLAS_BUNDLE");
        Require(!string.IsNullOrEmpty(output) && File.Exists(Path.Combine(output, BundleName)),
            "Build the empty-project native fixture and set WAR_NATIVE_ATLAS_BUNDLE to its output directory.");
        SessionState.SetString(OutputKey, output);
        SessionState.SetBool(RequestedKey, true);
        UnityAbortNoticeAudit.RunAsync();
    }

    /// <summary>Runs only when explicitly requested by this bundle-building entry point.</summary>
    public static async Task VerifyIfRequestedAsync()
    {
        if (!SessionState.GetBool(RequestedKey, false))
        {
            return;
        }
        SessionState.SetBool(RequestedKey, false);
        using (var fixture = new UnityCompletedAtlasFixture(SessionState.GetString(OutputKey, string.Empty)))
        {
            await VerifyPublicationAsync(fixture, PublicationMode.CancelBeforeCompletion);
            await VerifyPublicationAsync(fixture, PublicationMode.PublishNormally);
            fixture.ReleaseExternalLease();
            Debug.Log("PASS: real in-flight bundle completion skips cancelled texture publication, releases " +
                "exactly one shared lease, then publishes in a fresh scope and fully unloads after the last owner.");
        }
    }

    private static async Task VerifyPublicationAsync(UnityCompletedAtlasFixture fixture, PublicationMode mode)
    {
        bool finished = false;
        fixture.Loader.StartCoroutine(ObserveCompletion(fixture.Loader.LoadGameCoroutine(), () => finished = true));
        AssetBundleLoadAssetOperationFull operation = fixture.CurrentOperation;
        fixture.PumpOperations();
        var request = (AssetBundleRequest)typeof(AssetBundleLoadAssetOperationFull)
            .GetField("m_Request", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(operation);
        Require(request != null && !request.isDone && fixture.ReferenceCount == 2,
            "The source loader did not acquire its own lease and issue a still-pending native asset request.");
        if (mode == PublicationMode.CancelBeforeCompletion)
        {
            fixture.Loader.CancelGameLoadingForAbort();
        }
        DateTime deadline = DateTime.UtcNow.AddSeconds(TimeoutSeconds);
        while (!finished)
        {
            Require(DateTime.UtcNow < deadline, "The real native atlas request did not drain.");
            fixture.PumpOperations();
            await Task.Yield();
        }
        Require(request.isDone && operation.GetAsset<Texture2D>() != null && fixture.ReferenceCount == 1,
            "Completed source loading did not return the real texture or conserve the external bundle lease.");
        if (mode == PublicationMode.CancelBeforeCompletion)
        {
            Require(fixture.Target.mainTexture == fixture.OriginalTexture && fixture.Atlas.pixelSize == 2f,
                "Cancelled native completion overwrote the restored atlas texture or pixel size.");
        }
        else
        {
            Require(fixture.Target.mainTexture == operation.GetAsset<Texture2D>() && fixture.Atlas.pixelSize == 1f,
                "A fresh game-load scope did not publish the completed native texture normally.");
        }
    }

    private static IEnumerator ObserveCompletion(IEnumerator loading, Action completed)
    {
        yield return loading;
        completed();
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private enum PublicationMode
    {
        CancelBeforeCompletion,
        PublishNormally,
    }

}
