using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Rebinds every serialized ResourceCompatibility DLL reference to its editable C# MonoScript.
/// The migration resolves and validates all 402 identities before writing any asset, preserves
/// every serialized field value, and rolls back already-written files if disk verification fails.
/// </summary>
public static class ResourceCompatibilitySourceRemapper
{
    private const string MainDllGuid = "da3348191866a384b95001cc2c6d51b2";
    private const string FirstPassDllGuid = "ac2116c440a88b441990deaeb6e59e4b";
    private const long SourceMonoScriptFileId = 11500000;
    private const int ExpectedMainTypes = 277;
    private const int ExpectedFirstPassTypes = 125;
    private const int ExpectedMainReferences = 1057;
    private const int ExpectedFirstPassReferences = 136;

    private static readonly Regex ScriptReference = new Regex(
        @"\{fileID: (?<id>-?\d+), guid: (?<guid>da3348191866a384b95001cc2c6d51b2|ac2116c440a88b441990deaeb6e59e4b), type: 3\}",
        RegexOptions.Compiled);

    private static readonly HashSet<string> TextAssetExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        ".unity", ".prefab", ".asset", ".anim", ".controller", ".overrideController", ".playable", ".mat"
    };

    private sealed class SourceReference
    {
        public string OldGuid;
        public long OldFileId;
        public string FullName;
        public string SourceAssetPath;
        public string SourceGuid;
        public int Occurrences;
    }

    private sealed class PendingWrite
    {
        public string Path;
        public string RelativePath;
        public string UpdatedText;
        public int Replacements;
    }

    public static void RemapAllAssets()
    {
        string backupRoot = null;
        List<PendingWrite> written = new List<PendingWrite>();
        try
        {
            string assetsRoot = Path.GetFullPath(Application.dataPath);
            string projectRoot = Path.GetFullPath(Path.Combine(assetsRoot, ".."));
            string clientRoot = Path.GetFullPath(Path.Combine(projectRoot, ".."));
            backupRoot = Path.Combine(clientRoot, ".resource-source-remap-backup");

            Dictionary<string, SourceReference> references = new Dictionary<string, SourceReference>(StringComparer.Ordinal);
            LoadManifest(
                Path.Combine(clientRoot, "resource-compatibility-source-map.csv"),
                clientRoot,
                projectRoot,
                MainDllGuid,
                ExpectedMainTypes,
                references);
            LoadManifest(
                Path.Combine(clientRoot, "resource-compatibility-source-map-firstpass.csv"),
                clientRoot,
                projectRoot,
                FirstPassDllGuid,
                ExpectedFirstPassTypes,
                references);

            if (references.Count != ExpectedMainTypes + ExpectedFirstPassTypes)
            {
                throw new InvalidOperationException("Expected 402 unique source mappings, found " + references.Count + ".");
            }

            List<PendingWrite> pendingWrites = new List<PendingWrite>();
            List<string> unresolved = new List<string>();
            int mainReferences = 0;
            int firstPassReferences = 0;

            // Phase one is strictly read-only. Even one unknown (GUID, fileID) pair aborts the
            // migration before any scene, prefab, or ScriptableObject can become partially bound.
            foreach (string path in EnumerateTextAssets(assetsRoot))
            {
                string original = File.ReadAllText(path);
                int replacements = 0;
                string updated = ScriptReference.Replace(original, match =>
                {
                    long oldFileId;
                    if (!long.TryParse(match.Groups["id"].Value, out oldFileId))
                    {
                        unresolved.Add(Relative(assetsRoot, path) + ",invalid-file-id," + match.Value);
                        return match.Value;
                    }

                    string oldGuid = match.Groups["guid"].Value;
                    SourceReference source;
                    if (!references.TryGetValue(Key(oldGuid, oldFileId), out source))
                    {
                        unresolved.Add(Relative(assetsRoot, path) + "," + oldGuid + "," + oldFileId);
                        return match.Value;
                    }

                    source.Occurrences++;
                    replacements++;
                    if (oldGuid == MainDllGuid)
                    {
                        mainReferences++;
                    }
                    else
                    {
                        firstPassReferences++;
                    }
                    return "{fileID: " + SourceMonoScriptFileId + ", guid: " + source.SourceGuid + ", type: 3}";
                });

                if (replacements > 0)
                {
                    pendingWrites.Add(new PendingWrite
                    {
                        Path = path,
                        RelativePath = Relative(assetsRoot, path),
                        UpdatedText = updated,
                        Replacements = replacements
                    });
                }
            }

            if (unresolved.Count > 0)
            {
                throw new InvalidOperationException(
                    "Resource source remap aborted before writes: " + unresolved.Count + " references are unresolved.\n" +
                    string.Join("\n", unresolved.Take(20).ToArray()));
            }
            if (mainReferences != ExpectedMainReferences || firstPassReferences != ExpectedFirstPassReferences)
            {
                throw new InvalidOperationException(
                    "Reference count drift: main=" + mainReferences + "/" + ExpectedMainReferences +
                    ", FirstPass=" + firstPassReferences + "/" + ExpectedFirstPassReferences + ".");
            }

            List<SourceReference> unusedMappings = references.Values.Where(value => value.Occurrences == 0).ToList();
            if (unusedMappings.Count > 0)
            {
                throw new InvalidOperationException(
                    "The asset set no longer uses " + unusedMappings.Count + " mapped source identities; regenerate the manifests first.");
            }

            // Phase two keeps recoverable originals outside Assets. If any write or final disk
            // scan fails, every touched file is restored before Unity is allowed to refresh.
            if (Directory.Exists(backupRoot))
            {
                throw new InvalidOperationException("Stale remap backup exists: " + backupRoot);
            }
            Directory.CreateDirectory(backupRoot);

            foreach (PendingWrite pending in pendingWrites)
            {
                string backupPath = Path.Combine(
                    backupRoot,
                    pending.RelativePath.Replace('/', Path.DirectorySeparatorChar));
                Directory.CreateDirectory(Path.GetDirectoryName(backupPath));
                File.Copy(pending.Path, backupPath, false);
                File.WriteAllText(pending.Path, pending.UpdatedText, new UTF8Encoding(false));
                written.Add(pending);
            }

            List<string> residualDllReferences = EnumerateTextAssets(assetsRoot)
                .Where(path =>
                {
                    string text = File.ReadAllText(path);
                    return text.Contains(MainDllGuid) || text.Contains(FirstPassDllGuid);
                })
                .Select(path => Relative(assetsRoot, path))
                .ToList();
            if (residualDllReferences.Count > 0)
            {
                throw new InvalidOperationException(
                    "DLL GUID verification failed in " + residualDllReferences.Count + " assets: " +
                    string.Join(", ", residualDllReferences.Take(20).ToArray()));
            }

            WriteReport(clientRoot, pendingWrites, references.Values, mainReferences, firstPassReferences);
            Directory.Delete(backupRoot, true);
            backupRoot = null;

            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
            Debug.Log("Resource compatibility source remap completed: files=" + pendingWrites.Count +
                      ", references=" + (mainReferences + firstPassReferences) + ", unresolved=0");
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            try
            {
                if (!string.IsNullOrEmpty(backupRoot) && Directory.Exists(backupRoot))
                {
                    foreach (PendingWrite pending in written)
                    {
                        string backupPath = Path.Combine(
                            backupRoot,
                            pending.RelativePath.Replace('/', Path.DirectorySeparatorChar));
                        if (File.Exists(backupPath))
                        {
                            File.Copy(backupPath, pending.Path, true);
                        }
                    }
                }
            }
            catch (Exception rollbackException)
            {
                Debug.LogError("Resource source remap rollback failed: " + rollbackException);
            }

            Debug.LogException(exception);
            EditorApplication.Exit(1);
        }
    }

    private static void LoadManifest(
        string manifestPath,
        string clientRoot,
        string projectRoot,
        string expectedOldGuid,
        int expectedRows,
        Dictionary<string, SourceReference> result)
    {
        List<string> lines = File.ReadAllLines(manifestPath).Skip(1).Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
        if (lines.Count != expectedRows)
        {
            throw new InvalidOperationException("Manifest row count drift in " + manifestPath + ": " + lines.Count + "/" + expectedRows);
        }

        foreach (string line in lines)
        {
            List<string> fields = ParseCsvLine(line);
            if (fields.Count != 7 || fields[1] != expectedOldGuid || fields[6] != SourceMonoScriptFileId.ToString())
            {
                throw new InvalidOperationException("Malformed source mapping row: " + line);
            }

            long oldFileId;
            if (!long.TryParse(fields[2], out oldFileId))
            {
                throw new InvalidOperationException("Invalid old fileID in source mapping: " + line);
            }

            string repositoryRelativePath = fields[4].Replace('/', Path.DirectorySeparatorChar);
            string absoluteSourcePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(clientRoot), repositoryRelativePath));
            if (!absoluteSourcePath.StartsWith(projectRoot + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Mapped source escaped Unity project: " + fields[4]);
            }
            string sourceAssetPath = "Assets/" + Relative(Path.Combine(projectRoot, "Assets"), absoluteSourcePath);
            MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(sourceAssetPath);
            if (script == null)
            {
                throw new InvalidOperationException("Mapped MonoScript is not importable: " + sourceAssetPath);
            }

            string actualGuid;
            long actualFileId;
            if (!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(script, out actualGuid, out actualFileId) ||
                actualGuid != fields[5] || actualFileId != SourceMonoScriptFileId)
            {
                throw new InvalidOperationException(
                    "Mapped MonoScript identity mismatch for " + fields[3] + ": manifest=" + fields[5] +
                    "/" + SourceMonoScriptFileId + ", Unity=" + actualGuid + "/" + actualFileId);
            }

            Type scriptClass = script.GetClass();
            if (scriptClass == null || !string.Equals(scriptClass.FullName, fields[3], StringComparison.Ordinal))
            {
                throw new InvalidOperationException(
                    "Mapped MonoScript class mismatch for " + fields[3] + " at " + sourceAssetPath);
            }

            SourceReference source = new SourceReference
            {
                OldGuid = expectedOldGuid,
                OldFileId = oldFileId,
                FullName = fields[3],
                SourceAssetPath = sourceAssetPath,
                SourceGuid = actualGuid
            };
            string key = Key(expectedOldGuid, oldFileId);
            if (result.ContainsKey(key))
            {
                throw new InvalidOperationException("Duplicate old script identity in manifests: " + key);
            }
            result.Add(key, source);
        }
    }

    private static IEnumerable<string> EnumerateTextAssets(string assetsRoot)
    {
        return Directory.EnumerateFiles(assetsRoot, "*", SearchOption.AllDirectories)
            .Where(path => TextAssetExtensions.Contains(Path.GetExtension(path)));
    }

    private static void WriteReport(
        string clientRoot,
        IList<PendingWrite> pendingWrites,
        IEnumerable<SourceReference> references,
        int mainReferences,
        int firstPassReferences)
    {
        StringBuilder report = new StringBuilder();
        report.AppendLine("metric,value");
        report.AppendLine("changed_files," + pendingWrites.Count);
        report.AppendLine("main_references," + mainReferences);
        report.AppendLine("firstpass_references," + firstPassReferences);
        report.AppendLine("changed_script_references," + (mainReferences + firstPassReferences));
        report.AppendLine("mapped_source_types," + references.Count());
        report.AppendLine("unresolved_references,0");
        report.AppendLine("residual_dll_references,0");
        report.AppendLine();
        report.AppendLine("old_guid,old_file_id,full_name,source_guid,source_file_id,occurrences,source_asset");
        foreach (SourceReference source in references.OrderBy(value => value.OldGuid, StringComparer.Ordinal)
                     .ThenBy(value => value.OldFileId))
        {
            report.AppendLine(string.Join(",", new[]
            {
                source.OldGuid,
                source.OldFileId.ToString(),
                Csv(source.FullName),
                source.SourceGuid,
                SourceMonoScriptFileId.ToString(),
                source.Occurrences.ToString(),
                Csv(source.SourceAssetPath)
            }));
        }
        File.WriteAllText(
            Path.Combine(clientRoot, "resource-compatibility-reference-remap.csv"),
            report.ToString(),
            new UTF8Encoding(false));
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
            throw new InvalidOperationException("Unterminated quoted CSV row: " + line);
        }
        values.Add(value.ToString());
        return values;
    }

    private static string Key(string guid, long fileId)
    {
        return guid + ":" + fileId;
    }

    private static string Csv(string value)
    {
        return "\"" + value.Replace("\"", "\"\"") + "\"";
    }

    private static string Relative(string root, string path)
    {
        return path.Substring(root.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
            .Replace(Path.DirectorySeparatorChar, '/');
    }
}
