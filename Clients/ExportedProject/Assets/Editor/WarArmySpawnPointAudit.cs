// Read-only scene proof for Server/content/recovered-army-spawn-points.json.
using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class WarArmySpawnPointAudit
{
    public static void Run()
    {
        string path=Environment.GetEnvironmentVariable("WAR_ARMY_SPAWNS");
        if(string.IsNullOrEmpty(path))throw new InvalidOperationException("Set WAR_ARMY_SPAWNS.");
        var artifact=JObject.Parse(File.ReadAllText(path));
        int checkedPoints=0;
        var previous=EditorSceneManager.GetSceneManagerSetup();
        try
        {
            foreach(var map in (JArray)artifact["maps"])
            {
                string source=(string)map["source"];
                var scene=EditorSceneManager.OpenScene(source);
                var definition=scene.GetRootGameObjects().SelectMany(x=>x.GetComponentsInChildren<MapDefinition>(true)).Single();
                foreach(var row in (JArray)map["points"])
                {
                    string category=(string)row["collection"];
                    var field=typeof(MapDefinition).GetField(category);
                    if(field==null)throw new InvalidOperationException("Unknown collection field "+category);
                    var collection=(SpawnPointsCollection)field.GetValue(definition);
                    int order=(int)row["order"];
                    var point=collection.spawnPoints[order];
                    string guid;long fileId;
                    bool resolved=AssetDatabase.TryGetGUIDAndLocalFileIdentifier(point,out guid,out fileId);
                    // Unity 2018 returns localId zero for opened scene components;
                    // YAML file IDs are independently bound by the source digest.
                    if((resolved && fileId>0 && fileId!=(long)row["componentFileId"]) ||
                        point.GetType().Name!=(string)row["componentType"] ||
                        (int)point.fraction!=(int)row["fraction"])
                        throw new InvalidOperationException("Spawn identity/faction differs: "+source+"/"+category+"/"+order+
                            " localId="+fileId+" expected="+row["componentFileId"]+
                            " type="+point.GetType().Name+" expectedType="+row["componentType"]+
                            " fraction="+(int)point.fraction+" expectedFraction="+row["fraction"]);
                    var expected=(JArray)row["worldPosition"];
                    var actual=point.transform.position;
                    if(Math.Abs(actual.x-(float)expected[0])>0.001f ||
                       Math.Abs(actual.y-(float)expected[1])>0.001f ||
                       Math.Abs(actual.z-(float)expected[2])>0.001f)
                        throw new InvalidOperationException("Spawn world position differs: "+source+"/"+category+"/"+order);
                    checkedPoints++;
                }
            }
            Debug.Log("WAR_ARMY_SPAWNS PASS: "+checkedPoints+" source scene points");
        }
        finally {if(previous.Length>0 && previous.Any(x=>x.isActive))EditorSceneManager.RestoreSceneManagerSetup(previous);}
    }
}
