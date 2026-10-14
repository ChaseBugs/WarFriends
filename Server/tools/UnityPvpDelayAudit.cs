using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class UnityPvpDelayAudit
{
    static UnityPvpDelayAudit()
    {
        EditorApplication.playModeStateChanged += state => {
            if (state == PlayModeStateChange.EnteredPlayMode &&
                !string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("WAR_PVP_DELAY_OUTPUT")))
                new GameObject("Original delay probe").AddComponent<SourceDelayRunner>();
        };
    }
    public static void Run() { EditorApplication.isPlaying = true; }
}
