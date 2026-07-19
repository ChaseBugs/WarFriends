using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public static class RuntimeScriptMap
{
    public static void EnablePluginAssembliesInEditor()
    {
        string[] dllGuids = AssetDatabase.FindAssets("t:DefaultAsset", new[] { "Assets/Plugins" });
        int changed = 0;

        foreach (string dllGuid in dllGuids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(dllGuid);
            if (!assetPath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            PluginImporter importer = AssetImporter.GetAtPath(assetPath) as PluginImporter;
            if (importer == null || importer.GetCompatibleWithEditor())
            {
                continue;
            }

            importer.SetCompatibleWithEditor(true);
            importer.SaveAndReimport();
            changed++;
        }

        Debug.Log("Enabled Editor compatibility for " + changed + " plugin assemblies.");
        EditorApplication.Exit(0);
    }

    public static void Export()
    {
        StringBuilder report = new StringBuilder();
        report.AppendLine("asset_path,assembly,type_name,guid,local_file_id");

        MonoScript[] scripts = MonoImporter.GetAllRuntimeMonoScripts();
        foreach (MonoScript script in scripts.OrderBy(value => AssetDatabase.GetAssetPath(value)).ThenBy(value => value.name))
        {
            Type type = script.GetClass();
            string assetPath = AssetDatabase.GetAssetPath(script);
            string guid;
            long localFileId;
            AssetDatabase.TryGetGUIDAndLocalFileIdentifier(script, out guid, out localFileId);

            report.AppendLine(string.Join(",", new[]
            {
                Csv(assetPath),
                Csv(type == null ? string.Empty : type.Assembly.GetName().Name),
                Csv(type == null ? script.name : type.FullName),
                guid,
                localFileId.ToString()
            }));
        }

        string reportPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "active-runtime-script-map.csv"));
        File.WriteAllText(reportPath, report.ToString());
        Debug.Log("Runtime script map: " + reportPath + " (" + scripts.Length + " scripts)");
        EditorApplication.Exit(0);
    }

    private static string Csv(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        return "\"" + value.Replace("\"", "\"\"") + "\"";
    }
}
