using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public static class ResourceCompatibilityRemapper
{
    private const string SourceMainGuid = "06dd3d5416bf43ea368cc39ff96e6d5a";
    private const string SourceFirstPassGuid = "a6a460bc9cda68a8c89553f1ec5be757";
    private const string CompatibilityMainGuid = "da3348191866a384b95001cc2c6d51b2";
    private const string CompatibilityFirstPassGuid = "ac2116c440a88b441990deaeb6e59e4b";

    private static readonly Regex ScriptReference = new Regex(
        @"m_Script: \{fileID: (?<id>-?\d+), guid: (?<guid>[0-9a-f]{32}), type: 3\}",
        RegexOptions.Compiled);

    private static readonly HashSet<string> TextAssetExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        ".unity", ".prefab", ".asset", ".anim", ".controller", ".overrideController", ".playable", ".mat"
    };

    public static void RemapAllAssets()
    {
        Dictionary<string, HashSet<long>> idsByAssembly = BuildScriptIdSets();
        HashSet<long> oldMain = GetIds(idsByAssembly, "WarFriends.Gameplay");
        HashSet<long> oldFirstPass = GetIds(idsByAssembly, "WarFriends.Gameplay.FirstPass");
        HashSet<long> compatibilityMain = GetIds(idsByAssembly, "WarFriends.ResourceCompatibility");
        HashSet<long> compatibilityFirstPass = GetIds(idsByAssembly, "WarFriends.ResourceCompatibility.FirstPass");

        string assetsRoot = Path.GetFullPath(Application.dataPath);
        string clientRoot = Path.GetFullPath(Path.Combine(assetsRoot, "..", ".."));
        string backupRoot = Path.Combine(clientRoot, "AuxiliaryFiles", "PreCompatibilityRemap");
        List<string> unresolved = new List<string>();
        int changedFiles = 0;
        int changedReferences = 0;

        foreach (string path in Directory.EnumerateFiles(assetsRoot, "*", SearchOption.AllDirectories))
        {
            if (!TextAssetExtensions.Contains(Path.GetExtension(path)))
            {
                continue;
            }

            string text = File.ReadAllText(path);
            int fileChanges = 0;
            string remapped = ScriptReference.Replace(text, match =>
            {
                long fileId;
                if (!long.TryParse(match.Groups["id"].Value, out fileId))
                {
                    return match.Value;
                }

                string sourceGuid = match.Groups["guid"].Value;
                string targetGuid = null;
                if (sourceGuid == SourceMainGuid && !oldMain.Contains(fileId))
                {
                    if (compatibilityMain.Contains(fileId))
                    {
                        targetGuid = CompatibilityMainGuid;
                    }
                    else
                    {
                        unresolved.Add(Relative(assetsRoot, path) + "," + sourceGuid + "," + fileId);
                    }
                }
                else if (sourceGuid == SourceFirstPassGuid && !oldFirstPass.Contains(fileId))
                {
                    if (compatibilityFirstPass.Contains(fileId))
                    {
                        targetGuid = CompatibilityFirstPassGuid;
                    }
                    else
                    {
                        unresolved.Add(Relative(assetsRoot, path) + "," + sourceGuid + "," + fileId);
                    }
                }

                if (targetGuid == null)
                {
                    return match.Value;
                }

                fileChanges++;
                changedReferences++;
                return match.Value.Replace(sourceGuid, targetGuid);
            });

            if (fileChanges == 0)
            {
                continue;
            }

            string relativePath = Relative(assetsRoot, path);
            string backupPath = Path.Combine(backupRoot, relativePath.Replace('/', Path.DirectorySeparatorChar));
            Directory.CreateDirectory(Path.GetDirectoryName(backupPath));
            if (!File.Exists(backupPath))
            {
                File.Copy(path, backupPath);
            }

            File.WriteAllText(path, remapped, new UTF8Encoding(false));
            changedFiles++;
        }

        StringBuilder report = new StringBuilder();
        report.AppendLine("metric,value");
        report.AppendLine("changed_files," + changedFiles);
        report.AppendLine("changed_script_references," + changedReferences);
        report.AppendLine("unresolved_references," + unresolved.Count);
        report.AppendLine();
        report.AppendLine("asset,source_guid,file_id");
        foreach (string value in unresolved.Distinct().OrderBy(value => value, StringComparer.Ordinal))
        {
            report.AppendLine(value);
        }

        string reportPath = Path.Combine(clientRoot, "hybrid-reference-remap.csv");
        File.WriteAllText(reportPath, report.ToString(), new UTF8Encoding(false));
        Debug.Log("Compatibility remap: changedFiles=" + changedFiles +
                  ", changedReferences=" + changedReferences +
                  ", unresolvedReferences=" + unresolved.Count +
                  ", report=" + reportPath);
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        EditorApplication.Exit(unresolved.Count == 0 ? 0 : 1);
    }

    private static Dictionary<string, HashSet<long>> BuildScriptIdSets()
    {
        Dictionary<string, HashSet<long>> result = new Dictionary<string, HashSet<long>>(StringComparer.Ordinal);
        foreach (MonoScript script in MonoImporter.GetAllRuntimeMonoScripts())
        {
            Type type = script.GetClass();
            if (type == null)
            {
                continue;
            }

            string guid;
            long localFileId;
            if (!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(script, out guid, out localFileId))
            {
                continue;
            }

            string assemblyName = type.Assembly.GetName().Name;
            HashSet<long> ids;
            if (!result.TryGetValue(assemblyName, out ids))
            {
                ids = new HashSet<long>();
                result.Add(assemblyName, ids);
            }

            ids.Add(localFileId);
        }

        return result;
    }

    private static HashSet<long> GetIds(Dictionary<string, HashSet<long>> idsByAssembly, string assemblyName)
    {
        HashSet<long> ids;
        if (!idsByAssembly.TryGetValue(assemblyName, out ids))
        {
            throw new InvalidOperationException("Runtime script assembly is not loaded: " + assemblyName);
        }

        return ids;
    }

    private static string Relative(string root, string path)
    {
        return path.Substring(root.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
            .Replace(Path.DirectorySeparatorChar, '/');
    }
}
