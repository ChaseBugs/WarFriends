using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;

public static class HybridBuild
{
    public static void BuildAndroid()
    {
        string clientRoot = Path.GetFullPath(Path.Combine(UnityEngine.Application.dataPath, "..", ".."));
        string buildDirectory = Path.Combine(clientRoot, "Builds");
        string outputPath = Path.Combine(buildDirectory, "WarFriends-Hybrid-4.9.5-resources-1.6.0-runtime.apk");
        string reportPath = Path.Combine(clientRoot, "hybrid-android-build.txt");
        Directory.CreateDirectory(buildDirectory);

        string[] scenes = EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToArray();

        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.chillingo.warfriends.android.gplay");
        PlayerSettings.bundleVersion = "4.9.5-hybrid";
        PlayerSettings.Android.bundleVersionCode = 495160;
        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel19;
        PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevelAuto;
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARMv7;
        PlayerSettings.Android.useAPKExpansionFiles = true;
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.Mono2x);
        EditorUserBuildSettings.buildAppBundle = false;
        EditorPrefs.SetInt("AndroidGradleMaxHeapSize", 8192);

        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = outputPath,
            target = BuildTarget.Android,
            targetGroup = BuildTargetGroup.Android,
            options = BuildOptions.Development | BuildOptions.AllowDebugging
        };

        BuildReport report = BuildPipeline.BuildPlayer(options);
        BuildSummary summary = report.summary;
        string generatedExpansionPath = Path.Combine(
            buildDirectory,
            Path.GetFileNameWithoutExtension(outputPath) + ".main.obb");
        string standardExpansionPath = Path.Combine(
            buildDirectory,
            "main." + PlayerSettings.Android.bundleVersionCode + "." +
            PlayerSettings.GetApplicationIdentifier(BuildTargetGroup.Android) + ".obb");
        if (summary.result == BuildResult.Succeeded && File.Exists(generatedExpansionPath))
        {
            if (File.Exists(standardExpansionPath))
            {
                File.Delete(standardExpansionPath);
            }
            File.Move(generatedExpansionPath, standardExpansionPath);
        }
        string[] expansionFiles = Directory.GetFiles(buildDirectory, "*.obb");
        string text =
            "result=" + summary.result + Environment.NewLine +
            "platform=" + summary.platform + Environment.NewLine +
            "output_path=" + outputPath + Environment.NewLine +
            "output_exists=" + File.Exists(outputPath) + Environment.NewLine +
            "expansion_file_count=" + expansionFiles.Length + Environment.NewLine +
            "expansion_files=" + string.Join(";", expansionFiles) + Environment.NewLine +
            "total_size_bytes=" + summary.totalSize + Environment.NewLine +
            "total_time=" + summary.totalTime + Environment.NewLine +
            "warning_count=" + summary.totalWarnings + Environment.NewLine +
            "error_count=" + summary.totalErrors + Environment.NewLine +
            "scene_count=" + scenes.Length + Environment.NewLine;
        File.WriteAllText(reportPath, text);

        if (summary.result != BuildResult.Succeeded)
        {
            throw new InvalidOperationException("Hybrid Android build failed. See " + reportPath);
        }
    }
}
