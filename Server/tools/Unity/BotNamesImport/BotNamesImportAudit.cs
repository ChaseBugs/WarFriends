using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

/// <summary>Exports exact imported string bytes from two small disposable prefab fixtures.</summary>
public static class BotNamesImportAudit
{
    public static void Run()
    {
        string output = Environment.GetEnvironmentVariable("WAR_BOT_NAMES_OUTPUT");
        if (string.IsNullOrEmpty(output))
        {
            throw new InvalidOperationException("Missing output directory.");
        }
        Capture("Plain", output);
        Capture("Quoted", output);
        Debug.Log("BOT_NAMES_IMPORT_CAPTURED");
    }

    private static void Capture(string name, string output)
    {
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/" + name + ".prefab");
        BotNamesImportFixture fixture = prefab.GetComponent<BotNamesImportFixture>();
        string[] names = fixture.CopyNames();
        for (int index = 0; index < names.Length; index++)
        {
            names[index] = Convert.ToBase64String(Encoding.UTF8.GetBytes(names[index]));
        }
        File.WriteAllLines(Path.Combine(output, name + ".txt"), names, new UTF8Encoding(false));
    }
}
