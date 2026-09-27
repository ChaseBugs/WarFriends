using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEngine;

public static class UnityPhysicsSettingsExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_PHYSICS_SETTINGS_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_PHYSICS_SETTINGS_OUTPUT.");
        var masks=new uint[32];
        for(int layer=0;layer<32;layer++)
            for(int other=0;other<32;other++)
                if(!Physics.GetIgnoreLayerCollision(layer,other))masks[layer]|=1u<<other;
        for(int layer=0;layer<32;layer++)
            for(int other=0;other<32;other++)
                if(((masks[layer]>>other)&1)!=((masks[other]>>layer)&1))
                    throw new InvalidOperationException("Runtime layer collision matrix is asymmetric.");
        var settings=new[]{"ProjectSettings/DynamicsManager.asset","ProjectSettings/TimeManager.asset",
            "ProjectSettings/TagManager.asset"}.Select(path=>new{source=path,sha256=Hash(path)}).ToArray();
        File.WriteAllText(output,JsonConvert.SerializeObject(new{version=1,unityVersion=Application.unityVersion,
            settingsEvidence=settings,fixedTimestep=Time.fixedDeltaTime,
            gravity=new[]{Physics.gravity.x,Physics.gravity.y,Physics.gravity.z},
            queriesHitTriggers=Physics.queriesHitTriggers,
            layers=Enumerable.Range(0,32).Select(layer=>new{index=layer,name=LayerMask.LayerToName(layer),
                collisionMask=masks[layer].ToString("x8")}).ToArray()},Formatting.Indented)+"\n");
        Debug.Log("WAR_PHYSICS_SETTINGS_EXPORT_PASS");
    }
    private static string Hash(string path)
    {
        using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path)))
            .Replace("-","").ToLowerInvariant();
    }
}
