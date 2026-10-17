using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

/// <summary>Supplies real native bundles to inactive source services without account or network startup.</summary>
public sealed class UnityCompletedAtlasFixture : IDisposable
{
    private const BindingFlags InstanceFields = BindingFlags.Instance | BindingFlags.NonPublic;
    private const BindingFlags StaticFields = BindingFlags.Static | BindingFlags.NonPublic;
    private readonly AssetBundleManager _manager;
    private readonly AssetBundle _manifestBundle;
    private readonly AssetBundle _textureBundle;
    private readonly Dictionary<string, LoadedAssetBundle> _loaded;
    private readonly List<AssetBundleLoadOperation> _operations;
    private readonly object _previousManager;
    private readonly object _previousAtlas;
    private readonly object _previousManifest;
    private readonly object _previousReferences;
    private readonly GameObject _root;

    /// <summary>Loads fixture files and retains one explicit external bundle lease for conservation checks.</summary>
    public UnityCompletedAtlasFixture(string output)
    {
        _manager = Resources.FindObjectsOfTypeAll<AssetBundleManager>()
            .Single(value => value.gameObject.scene.IsValid());
        _loaded = (Dictionary<string, LoadedAssetBundle>)ReadManager("m_LoadedAssetBundles");
        _operations = (List<AssetBundleLoadOperation>)ReadManager("mInProgressOperations");
        Require(_loaded.Count == 0 && _operations.Count == 0, "The isolated native provider is not empty.");
        _manifestBundle = AssetBundle.LoadFromFile(Path.Combine(output, Path.GetFileName(output)));
        _textureBundle = AssetBundle.LoadFromFile(Path.Combine(output, UnityCompletedAtlasAudit.BundleName));
        Require(_manifestBundle != null && _textureBundle != null, "The real native bundle files did not load.");
        _previousManager = typeof(Singleton<AssetBundleManager>).GetField("_instance", StaticFields).GetValue(null);
        _previousAtlas = typeof(Singleton<AtlasPreparer>).GetField("_instance", StaticFields).GetValue(null);
        _previousManifest = ReadManager("m_AssetBundleManifest");
        _previousReferences = ReadManager("mAssetBundleReferencesDic");
        BindBundleProvider();
        _root = new GameObject("CompletedAtlasSourceLoader");
        _root.SetActive(false);
        Loader = _root.AddComponent<AbortAtlasPreparerProbe>();
        Atlas = _root.AddComponent<UIAtlas>();
        Atlas.pngPath = UnityCompletedAtlasAudit.TextureName;
        Target = new Material(Shader.Find("Unlit/Texture"));
        OriginalTexture = new Texture2D(1, 1);
        Target.mainTexture = OriginalTexture;
        Atlas.spriteMaterial = Target;
        Atlas.pixelSize = 2f;
        Loader.nGuiSpriteSheets = new List<AtlasPreparer.TextureDatasNgui>
        {
            new AtlasPreparer.TextureDatasNgui { atlas = Atlas, mode = AtlasPreparer.AtlasMode.Game,
                resourceMode = AtlasPreparer.ResourceMode.AssetBundle },
        };
        Loader.toolkitSrites = new List<AtlasPreparer.TextureDatas2DToolkit>();
        typeof(Singleton<AtlasPreparer>).GetField("_instance", StaticFields).SetValue(null, Loader);
        _root.SetActive(true);
    }

    /// <summary>The original atlas loading methods on a startup-isolated host.</summary>
    public AtlasPreparer Loader { get; private set; }

    /// <summary>The controlled atlas receiving original loader publication.</summary>
    public UIAtlas Atlas { get; private set; }

    /// <summary>The material whose texture assignment is checked.</summary>
    public Material Target { get; private set; }

    /// <summary>The restored-menu sentinel texture retained during cancellation.</summary>
    public Texture2D OriginalTexture { get; private set; }

    /// <summary>The current source-owned bundle reference counter.</summary>
    public int ReferenceCount { get { return _loaded[UnityCompletedAtlasAudit.BundleName].m_ReferencedCount; } }

    /// <summary>The actual source operation queued for native loading.</summary>
    public AssetBundleLoadAssetOperationFull CurrentOperation
    {
        get { return _operations.OfType<AssetBundleLoadAssetOperationFull>().Single(); }
    }

    /// <summary>Uses the original manager's Update pump while its unrelated Awake remains inactive.</summary>
    public void PumpOperations()
    {
        typeof(AssetBundleManager).GetMethod("Update", InstanceFields).Invoke(_manager, null);
    }

    /// <summary>Requires original unload to remove the final lease and invalidate the actual native bundle.</summary>
    public void ReleaseExternalLease()
    {
        Require(ReferenceCount == 1, "The external bundle owner lost or gained a lease.");
        AssetBundleManager.UnloadAssetBundle(UnityCompletedAtlasAudit.BundleName);
        Require(!_loaded.ContainsKey(UnityCompletedAtlasAudit.BundleName) && _textureBundle == null,
            "The last source unload did not remove the dictionary row and unload the native bundle.");
    }

    /// <summary>Restores source bindings and releases only fixture-owned native assets.</summary>
    public void Dispose()
    {
        Loader.StopAllCoroutines();
        _root.SetActive(false);
        _operations.Clear();
        _loaded.Remove(UnityCompletedAtlasAudit.BundleName);
        SetManager("m_AssetBundleManifest", _previousManifest);
        SetManager("mAssetBundleReferencesDic", _previousReferences);
        typeof(Singleton<AssetBundleManager>).GetField("_instance", StaticFields).SetValue(null, _previousManager);
        typeof(Singleton<AtlasPreparer>).GetField("_instance", StaticFields).SetValue(null, _previousAtlas);
        if (_textureBundle != null)
        {
            _textureBundle.Unload(true);
        }
        _manifestBundle.Unload(true);
        UnityEngine.Object.Destroy(Target);
        UnityEngine.Object.Destroy(OriginalTexture);
    }

    private void BindBundleProvider()
    {
        AssetBundleManifest manifest = _manifestBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        Require(manifest != null, "The native manifest is missing from its bundle.");
        SetManager("m_AssetBundleManifest", manifest);
        SetManager("mAssetBundleReferencesDic", new Dictionary<string, AssetBundleReference>
        {
            { UnityCompletedAtlasAudit.BundleName, new AssetBundleReference
                { name = UnityCompletedAtlasAudit.BundleName, cached = true } },
        });
        _loaded.Add(UnityCompletedAtlasAudit.BundleName, new LoadedAssetBundle(_textureBundle));
        typeof(Singleton<AssetBundleManager>).GetField("_instance", StaticFields).SetValue(null, _manager);
    }

    private object ReadManager(string name)
    {
        return typeof(AssetBundleManager).GetField(name, InstanceFields).GetValue(_manager);
    }

    private void SetManager(string name, object value)
    {
        typeof(AssetBundleManager).GetField(name, InstanceFields).SetValue(_manager, value);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
