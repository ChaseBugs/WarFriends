using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Converts serialized MonoBehaviour and ScriptableObject references from the immutable
/// recovered gameplay DLLs to their editable source MonoScripts. The conversion is
/// deliberately two-phase: every referenced DLL type must resolve before the first asset
/// is written, preventing a partial source/DLL transition.
/// </summary>
public static class SourceRuntimeRemapper
{
    private const string MainDllGuid = "06dd3d5416bf43ea368cc39ff96e6d5a";
    private const string FirstPassDllGuid = "a6a460bc9cda68a8c89553f1ec5be757";
    private const long SourceMonoScriptFileId = 11500000;

    private static readonly Regex ScriptReference = new Regex(
        @"\{fileID: (?<id>-?\d+), guid: (?<guid>06dd3d5416bf43ea368cc39ff96e6d5a|a6a460bc9cda68a8c89553f1ec5be757), type: 3\}",
        RegexOptions.Compiled);

    private static readonly HashSet<string> TextAssetExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        ".unity", ".prefab", ".asset", ".anim", ".controller", ".overrideController", ".playable", ".mat"
    };

    private sealed class SourceReference
    {
        public string Guid;
        public string FullName;
        public string AssetPath;
    }

    private sealed class PendingWrite
    {
        public string Path;
        public string Text;
        public int Replacements;
    }

    public static void RemapAllAssets()
    {
        try
        {
            string assetsRoot = Path.GetFullPath(Application.dataPath);
            string clientRoot = Path.GetFullPath(Path.Combine(assetsRoot, "..", ".."));
            Dictionary<long, SourceReference> mainMap = LoadDllMap(
                Path.Combine(clientRoot, "runtime-script-types.csv"),
                "WarFriends.Gameplay",
                "Assets/Scripts/Gameplay");
            Dictionary<long, SourceReference> firstPassMap = LoadDllMap(
                Path.Combine(clientRoot, "runtime-script-types-firstpass.csv"),
                "WarFriends.Gameplay.FirstPass",
                "Assets/Scripts/Gameplay.FirstPass");

            List<PendingWrite> pendingWrites = new List<PendingWrite>();
            List<string> unresolved = new List<string>();
            int totalReferences = 0;

            foreach (string path in Directory.EnumerateFiles(assetsRoot, "*", SearchOption.AllDirectories))
            {
                if (!TextAssetExtensions.Contains(Path.GetExtension(path)))
                {
                    continue;
                }

                string original = File.ReadAllText(path);
                int replacements = 0;
                string updated = ScriptReference.Replace(original, match =>
                {
                    long fileId;
                    if (!long.TryParse(match.Groups["id"].Value, out fileId))
                    {
                        unresolved.Add(Relative(assetsRoot, path) + ",invalid-file-id," + match.Value);
                        return match.Value;
                    }

                    string dllGuid = match.Groups["guid"].Value;
                    Dictionary<long, SourceReference> map = dllGuid == MainDllGuid ? mainMap : firstPassMap;
                    SourceReference source;
                    if (!map.TryGetValue(fileId, out source))
                    {
                        unresolved.Add(Relative(assetsRoot, path) + "," + dllGuid + "," + fileId);
                        return match.Value;
                    }

                    replacements++;
                    totalReferences++;
                    return "{fileID: " + SourceMonoScriptFileId + ", guid: " + source.Guid + ", type: 3}";
                });

                if (replacements > 0)
                {
                    pendingWrites.Add(new PendingWrite { Path = path, Text = updated, Replacements = replacements });
                }
            }

            if (unresolved.Count > 0)
            {
                WriteReport(clientRoot, 0, 0, unresolved);
                throw new InvalidOperationException(
                    "Source runtime remap aborted before writes: " + unresolved.Count + " DLL references were unresolved.");
            }

            foreach (PendingWrite pending in pendingWrites)
            {
                File.WriteAllText(pending.Path, pending.Text, new UTF8Encoding(false));
            }

            WriteReport(clientRoot, pendingWrites.Count, totalReferences, unresolved);
            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
            Debug.Log("Source runtime remap completed: files=" + pendingWrites.Count +
                      ", references=" + totalReferences + ", unresolved=0");
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            EditorApplication.Exit(1);
        }
    }

    private static Dictionary<long, SourceReference> LoadDllMap(
        string csvPath,
        string assemblyName,
        string sourceRoot)
    {
        Dictionary<long, SourceReference> result = new Dictionary<long, SourceReference>();
        foreach (string line in File.ReadAllLines(csvPath).Skip(1))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            List<string> fields = ParseCsvLine(line);
            if (fields.Count < 4)
            {
                throw new System.Exception("Malformed runtime type row: " + line);
            }

            long fileId;
            if (!long.TryParse(fields[0], out fileId))
            {
                throw new System.Exception("Malformed runtime file ID: " + fields[0]);
            }

            // The recovered runtime table contains nested enums and helper classes as well as
            // Unity component types. A nested row such as CardManager/CardFilter has the short
            // name CardFilter, but it lives inside CardManager.cs and must not be mistaken for
            // the unrelated top-level CardFilter.cs MonoScript. Only an exact top-level CLR
            // name can own an independently serialized Unity script reference.
            string expectedTopLevelName = string.IsNullOrEmpty(fields[1])
                ? fields[2]
                : fields[1] + "." + fields[2];
            if (!string.Equals(fields[3], expectedTopLevelName, StringComparison.Ordinal))
            {
                continue;
            }

            // ILSpy emits one source file per top-level recovered type. Its directory is the
            // exact CLR namespace (dots included), while the file name is the CSV type name.
            // Resolve that canonical path instead of indexing MonoScript.GetClass(). Unity
            // 2018 can return the global type for two scripts that share a file name even when
            // one of them belongs to a namespace (for example CustomAuthenticationType), which
            // makes a valid source tree look like it contains a duplicate runtime type.
            string namespacePath = string.IsNullOrEmpty(fields[1]) ? string.Empty : fields[1] + "/";
            string assetPath = sourceRoot + "/" + namespacePath + fields[2] + ".cs";
            MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(assetPath);
            if (script == null)
            {
                // Most rows are ordinary CLR or nested helper types and never have a MonoScript.
                // They are allowed to remain absent here; any serialized reference to one will
                // fail the complete pre-write scan above.
                continue;
            }

            string guid;
            long localFileId;
            if (!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(script, out guid, out localFileId) ||
                localFileId != SourceMonoScriptFileId)
            {
                throw new InvalidOperationException(
                    "Invalid canonical source MonoScript identity: " + assemblyName + " " + fields[3] +
                    " at " + assetPath);
            }

            SourceReference source = new SourceReference
            {
                Guid = guid,
                FullName = fields[3],
                AssetPath = assetPath
            };

            if (result.ContainsKey(fileId))
            {
                throw new System.Exception("Duplicate runtime file ID: " + assemblyName + " " + fileId);
            }

            result.Add(fileId, source);
        }

        return result;
    }

    private static List<string> ParseCsvLine(string line)
    {
        List<string> values = new List<string>();
        StringBuilder value = new StringBuilder();
        bool quoted = false;
        for (int index = 0; index < line.Length; index++)
        {
            char character = line[index];
            if (character == '"')
            {
                if (quoted && index + 1 < line.Length && line[index + 1] == '"')
                {
                    value.Append('"');
                    index++;
                }
                else
                {
                    quoted = !quoted;
                }
            }
            else if (character == ',' && !quoted)
            {
                values.Add(value.ToString());
                value.Length = 0;
            }
            else
            {
                value.Append(character);
            }
        }

        if (quoted)
        {
            throw new System.Exception("Unterminated quoted CSV row: " + line);
        }

        values.Add(value.ToString());
        return values;
    }

    private static void WriteReport(string clientRoot, int changedFiles, int changedReferences, List<string> unresolved)
    {
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

        File.WriteAllText(Path.Combine(clientRoot, "source-reference-remap.csv"), report.ToString(), new UTF8Encoding(false));
    }

    private static string Relative(string root, string path)
    {
        return path.Substring(root.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
            .Replace(Path.DirectorySeparatorChar, '/');
    }
}
