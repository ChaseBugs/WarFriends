using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class SelfHostedAirRouteExport
{
    public static void Run()
    {
        try
        {
            var output=Environment.GetEnvironmentVariable("WAR_AIR_ROUTE_OUTPUT");
            if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_AIR_ROUTE_OUTPUT.");
            var maps=new List<object>();int count=0;
            foreach(var name in new[]{"Aztec","City","Desert","Park","Snow"})
            {
                string source="Assets/Scenes/"+name+"_Multiplayer.unity";
                var scene=EditorSceneManager.OpenScene(source,OpenSceneMode.Single);
                var map=scene.GetRootGameObjects().SelectMany(x=>x.GetComponentsInChildren<MapDefinition>(true)).Single();
                var routes=new List<object>();
                foreach(var category in new[]{"spawnPointsCollectionDrones","spawnPointsCollectionAssaultHelis","spawnPointsCollectionHelicopters"})
                {
                    var collection=(SpawnPointsCollection)new SerializedObject(map).FindProperty(category).objectReferenceValue;
                    foreach(var spawn in collection.spawnPoints)
                    {
                        var join=(WayPoint)new SerializedObject(spawn).FindProperty(category=="spawnPointsCollectionHelicopters"?"wayPointToJoin":"pointToJoin").objectReferenceValue;
                        var path=join.path;
                        routes.Add(new{spawnComponentFileId=Id(spawn),pathComponentFileId=Id(path),joinWaypointFileId=Id(join),
                            joinIndex=path.wayPoints.IndexOf(join),radius=path.Radius,
                            waypoints=path.wayPoints.Select((p,i)=>new{componentFileId=Id(p),transformFileId=Id(p.transform),index=i,stayTime=p.stayTime,
                                worldPosition=new[]{p.transform.position.x,p.transform.position.y,p.transform.position.z}}).ToArray()});
                        count++;
                    }
                }
                maps.Add(new{source=source,routes=routes});
            }
            File.WriteAllText(output,JsonConvert.SerializeObject(new{maps=maps},Formatting.Indented)+"\n");
            Debug.Log("AIR_ROUTE_EXPORT_PASSED routes="+count);EditorApplication.Exit(0);
        }
        catch(Exception e){Debug.LogError(e);EditorApplication.Exit(1);}
    }
    private static long Id(UnityEngine.Object obj)
    {
        string guid;long id;if(AssetDatabase.TryGetGUIDAndLocalFileIdentifier(obj,out guid,out id))return id;
        var serialized=new SerializedObject(obj);
        typeof(SerializedObject).GetProperty("inspectorMode",System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Instance)
            .SetValue(serialized,InspectorMode.Debug,null);
        var local=serialized.FindProperty("m_LocalIdentfierInFile");
        if(local==null||local.longValue<=0)throw new InvalidOperationException("Scene object ID absent: "+obj.name);
        return local.longValue;
    }
}
