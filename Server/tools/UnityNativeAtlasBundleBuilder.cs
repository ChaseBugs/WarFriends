using System;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>Builds only native texture fixtures in an empty disposable Unity project.</summary>
public static class UnityNativeAtlasBundleBuilder
{
    private const string AssetFolder = "Assets/__CompletedAtlasAudit";
    private const int TextureSize = 512;
    /// <summary>The fixture asset address stored in the bundle.</summary>
    public const string TextureName = "AbortAtlasTexture";
    /// <summary>The canonical game-atlas bundle name used by the source loader.</summary>
    public const string BundleName = "gui/abortatlastexture";

    /// <summary>Creates a real Windows texture bundle and manifest without compiling recovered game scripts.</summary>
    public static void Build()
    {
        try
        {
            if (!AssetDatabase.IsValidFolder(AssetFolder))
            {
                AssetDatabase.CreateFolder("Assets", "__CompletedAtlasAudit");
            }
            string assetPath = AssetFolder + "/" + TextureName + ".asset";
            if (AssetDatabase.LoadAssetAtPath<Texture2D>(assetPath) == null)
            {
                var texture = new Texture2D(TextureSize, TextureSize, TextureFormat.RGBA32, false);
                texture.name = TextureName;
                texture.SetPixel(0, 0, Color.cyan);
                texture.Apply();
                AssetDatabase.CreateAsset(texture, assetPath);
            }
            string output = Path.Combine(Path.GetDirectoryName(Application.dataPath), "CompletedAtlasBundle");
            Directory.CreateDirectory(output);
            var definition = new AssetBundleBuild
            {
                assetBundleName = BundleName,
                assetNames = new[] { assetPath },
                addressableNames = new[] { TextureName },
            };
            AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(output, new[] { definition },
                BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows64);
            if (manifest == null)
            {
                throw new InvalidOperationException("The disposable native bundle build failed.");
            }
            Debug.Log("PASS: built real native atlas texture bundle and manifest: " + output);
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }
}
