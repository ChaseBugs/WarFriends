// Copy this read-only Editor script into an isolated WarFriends Unity project,
// then invoke WarBarrelOverlapAudit.Run in batch mode. It never saves a scene.
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class WarBarrelOverlapAudit
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_BARREL_OVERLAP_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_BARREL_OVERLAP_OUTPUT.");
        var previous=EditorSceneManager.GetSceneManagerSetup();
        try
        {
            var maps=Directory.GetFiles("Assets/Scenes","*_Multiplayer.unity")
                .OrderBy(path=>path,StringComparer.Ordinal).Select(path=>
                {
                    var scene=EditorSceneManager.OpenScene(path);
                    var barrels=scene.GetRootGameObjects()
                        .SelectMany(root=>root.GetComponentsInChildren<Barrel>(true))
                        .Where(barrel=>barrel.gameObject.activeInHierarchy)
                        .OrderBy(barrel=>barrel.name,StringComparer.Ordinal)
                        .ThenBy(barrel=>barrel.transform.position.x)
                        .ThenBy(barrel=>barrel.transform.position.z).ToArray();
                    foreach(var barrel in barrels)
                        barrel.gameObject.layer=TagsAndLayers.destroyableEntitiesLayerNumber;
                    Physics.SyncTransforms();
                    var probes=barrels.Select(barrel=>new {
                        name=barrel.name,position=Vec(barrel.transform.position),
                        radii=new[]{1.1f,1.8f}.Select(radius=>new {
                            radius,
                            hits=Physics.OverlapSphere(barrel.transform.position,radius,
                                TagsAndLayers.destroyableObjectsMask)
                                .Where(collider=>collider.gameObject.activeInHierarchy && collider.enabled &&
                                    TagsAndLayers.IsDestroyableObject(collider.gameObject) &&
                                    collider.GetComponent<DestroyableObject>()!=null)
                                .Select(collider=>new {
                                    name=collider.name,position=Vec(collider.transform.position),
                                    kind=collider.GetComponent<DestroyableObject>().GetType().Name,
                                    layer=collider.gameObject.layer
                                }).ToArray()
                        }).ToArray()
                    }).ToArray();
                    string digest;
                    using(var sha=SHA256.Create())
                        digest=BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path)))
                            .Replace("-","").ToLowerInvariant();
                    return new {source=path.Replace('\\','/'),sha256=digest,probes};
                }).ToArray();
            File.WriteAllText(output,JsonConvert.SerializeObject(new {client="1.4.0",maps},Formatting.Indented));
            Debug.Log("Barrel overlap audit wrote "+output);
        }
        finally { if(previous.Length>0)EditorSceneManager.RestoreSceneManagerSetup(previous); }
    }
    private static float[] Vec(Vector3 v)=>new[]{v.x,v.y,v.z};
}
