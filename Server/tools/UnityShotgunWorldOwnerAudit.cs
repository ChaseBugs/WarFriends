// Copy into a disposable recovered Unity project's Assets/Editor and run
// WarShotgunWorldOwnerAudit.Run. It reads scenes without saving them.
using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class WarShotgunWorldOwnerAudit
{
    public static void Run()
    {
        string[] maps={"Aztec_Multiplayer","City_Multiplayer","Desert_Multiplayer",
            "Park_Multiplayer","Snow_Multiplayer"};
        int shields=0,barrels=0,other=0;
        try
        {
            foreach(string name in maps)
            {
                var scene=EditorSceneManager.OpenScene("Assets/Scenes/"+name+".unity");
                foreach(var target in scene.GetRootGameObjects().SelectMany(root=>
                    root.GetComponentsInChildren<DestroyableObject>(true)))
                {
                    var collider=target.GetComponent<Collider>();
                    if(collider==null||!collider.enabled||!target.gameObject.activeInHierarchy)continue;
                    var sameObject=target.GetComponents<Core_BaseScript>()
                        .Where(component=>component!=target&&component is IFraction).ToArray();
                    if(target is Shield shield)
                    {
                        if(target.gameObject.layer!=24||!ReferenceEquals(shield.owner,shield)||
                           sameObject.Length!=0||!(collider is BoxCollider))
                            throw new InvalidOperationException("Unrecognized source shield owner: "+name);
                        shields++;
                    }
                    else if(target.GetComponent<Barrel>()!=null)
                    {
                        if(sameObject.Length!=0||target.GetType()!=typeof(DestroyableObject))
                            throw new InvalidOperationException("Source barrel gained a faction owner: "+name);
                        barrels++;
                    }
                    else
                    {
                        var part=target as DestroyableObjectpart;
                        if(part!=null)
                        {
                            var main=part.GetComponentInParent<DestroyableObjectMultipleParts>();
                            if(main==null||main.GetComponents<Core_BaseScript>()
                                .Any(component=>component!=main&&component is IFraction))
                                throw new InvalidOperationException("Source world part gained a faction owner: "+name);
                        }
                        if(sameObject.Length!=0)
                            throw new InvalidOperationException("Source world object gained a faction owner: "+name);
                        other++;
                    }
                }
            }
            if(shields!=40||barrels!=29||other!=17)
                throw new InvalidOperationException("World destroyable inventory changed: "+
                    shields+"/"+barrels+"/"+other);
            Debug.Log("UNITY_SHOTGUN_WORLD_OWNER_PASSED shields="+shields+
                " barrels="+barrels+" other="+other);
            EditorApplication.Exit(0);
        }
        catch(Exception error){Debug.LogError(error);EditorApplication.Exit(1);}
    }
}
