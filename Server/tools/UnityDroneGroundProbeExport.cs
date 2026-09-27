using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

// Downward probes are collision evidence, not a Rigidbody contact solver.
public static class UnityDroneGroundProbeExport
{
    public static void Run()
    {
        string input=Environment.GetEnvironmentVariable("WAR_DRONE_ROUTES_INPUT");
        string output=Environment.GetEnvironmentVariable("WAR_DRONE_GROUND_OUTPUT");
        if(string.IsNullOrEmpty(input)||string.IsNullOrEmpty(output))
            throw new InvalidOperationException("Set Drone route input and ground output.");
        var previous=EditorSceneManager.GetSceneManagerSetup();var maps=new List<object>();
        try
        {
            foreach(var map in JObject.Parse(File.ReadAllText(input))["maps"])
            {
                string source=(string)map["source"];
                using(var sha=SHA256.Create())
                    if(BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(source))).Replace("-","").ToLowerInvariant()!=
                        (string)map["sha256"])throw new InvalidOperationException("Scene provenance mismatch: "+source);
                EditorSceneManager.OpenScene(source);
                Physics.SyncTransforms();var points=new List<object>();
                foreach(var point in map["routes"].Where(r=>(string)r["collection"]=="spawnPointsCollectionDrones")
                    .SelectMany(r=>r["waypoints"]).GroupBy(p=>(long)p["componentFileId"]).Select(g=>g.First()))
                {
                    var p=point["worldPosition"];var origin=new Vector3((float)p[0],(float)p[1],(float)p[2]);
                    var hits=Physics.RaycastAll(origin,Vector3.down,100,~0,QueryTriggerInteraction.Ignore)
                        .OrderBy(h=>h.distance).ThenBy(h=>Hierarchy(h.collider.transform),StringComparer.Ordinal)
                        .Select(h=>new{path=Hierarchy(h.collider.transform),layer=h.collider.gameObject.layer,
                            type=h.collider.GetType().Name,distance=h.distance,
                            position=new[]{h.point.x,h.point.y,h.point.z},
                            alliesCollide=!Physics.GetIgnoreLayerCollision(26,h.collider.gameObject.layer),
                            enemiesCollide=!Physics.GetIgnoreLayerCollision(27,h.collider.gameObject.layer)}).ToArray();
                    points.Add(new{waypointFileId=(long)point["componentFileId"],
                        origin=new[]{origin.x,origin.y,origin.z},hits});
                }
                maps.Add(new{source,sourceSha256=(string)map["sha256"],points});
            }
            File.WriteAllText(output,JsonConvert.SerializeObject(new{version=1,
                unityVersion=Application.unityVersion,scenario="drone-waypoint-downward-ray-probes",maps},Formatting.Indented)+"\n");
            Debug.Log("WAR_DRONE_GROUND_EXPORT_PASS");
        }
        finally
        {
            if(previous.Any(s=>s.isLoaded)&&previous.Any(s=>s.isActive))
                EditorSceneManager.RestoreSceneManagerSetup(previous);
            else EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
        }
    }
    private static string Hierarchy(Transform transform)
    {string path=transform.name;while(transform.parent!=null){transform=transform.parent;path=transform.name+"/"+path;}return path;}
}
