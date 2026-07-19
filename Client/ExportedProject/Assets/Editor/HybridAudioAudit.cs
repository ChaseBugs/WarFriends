using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public static class HybridAudioAudit
{
    public static void Run()
    {
        string[] paths = AssetDatabase.GetAllAssetPaths()
            .Where(path => path.StartsWith("Assets/", StringComparison.Ordinal) &&
                (path.EndsWith(".wav", StringComparison.OrdinalIgnoreCase) ||
                 path.EndsWith(".ogg", StringComparison.OrdinalIgnoreCase) ||
                 path.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase)))
            .OrderBy(path => path, StringComparer.Ordinal)
            .ToArray();

        var report = new StringBuilder();
        report.AppendLine("asset,status,samples,channels,frequency,length_seconds,load_state");
        int failures = 0;
        foreach (string path in paths)
        {
            AudioClip clip = AssetDatabase.LoadAssetAtPath<AudioClip>(path);
            bool valid = clip != null && clip.samples > 0 && clip.channels > 0 && clip.frequency > 0;
            if (!valid)
            {
                failures++;
            }

            report.AppendLine(string.Join(",", new[]
            {
                Csv(path), valid ? "ok" : "failed",
                clip == null ? "0" : clip.samples.ToString(),
                clip == null ? "0" : clip.channels.ToString(),
                clip == null ? "0" : clip.frequency.ToString(),
                clip == null ? "0" : clip.length.ToString("F3", System.Globalization.CultureInfo.InvariantCulture),
                clip == null ? "missing" : clip.loadState.ToString()
            }));
        }

        string outputPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "hybrid-audio-audit.csv"));
        File.WriteAllText(outputPath, report.ToString());
        Debug.Log("HybridAudioAudit clips=" + paths.Length + " failures=" + failures + " report=" + outputPath);
        EditorApplication.Exit(failures == 0 ? 0 : 1);
    }

    private static string Csv(string value)
    {
        return "\"" + value.Replace("\"", "\"\"") + "\"";
    }
}
