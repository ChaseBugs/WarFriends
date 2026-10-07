using System;
using UnityEditor;
using UnityEngine;
using War.Protocol;

public static class SelfHostedGroundVehicleRenderAudit
{
    public static void Run()
    {
        GameObject owner=null;
        try
        {
            Transform humvee=Load("Humvee");
            Transform tank=Load("Tank");
            Transform buggy=Load("Buggy");
            Transform transporter=Load("Transporter");
            owner=new GameObject("SelfHostedGroundVehicleRenderAudit");
            var presenter=owner.AddComponent<SelfHostedGroundVehiclePresenter>();
            presenter.Configure(humvee,tank,buggy,transporter);

            var snapshot=new MatchSnapshot{ServerTick=60};
            Add(snapshot,41,"ID_UNIT-HUMVEE",1,0,0);
            Add(snapshot,42,"ID_UNIT-TANK",2,0,0);
            Add(snapshot,43,"ID_UNIT-BUGGY",3,0,0);
            Add(snapshot,44,"ID_UNIT-TRANSPORTER",4,0,0);
            snapshot.Vehicles[1].FacingX=1;
            snapshot.Vehicles[1].FacingZ=0;
            presenter.Apply(snapshot);

            CheckVisual(41,humvee,new Vector3(1,0,0),Vector3.forward);
            CheckVisual(42,tank,new Vector3(2,0,0),Vector3.right);
            CheckVisual(43,buggy,new Vector3(3,0,0),Vector3.forward);
            CheckVisual(44,transporter,new Vector3(4,0,0),Vector3.forward);
            snapshot.ServerTick=66;
            for(int index=0;index<snapshot.Vehicles.Count;index++)
                snapshot.Vehicles[index].X+=4;
            snapshot.Vehicles[1].FacingX=0;
            snapshot.Vehicles[1].FacingZ=1;
            presenter.Apply(snapshot);
            var moving=GameObject.Find("SelfHostedVehicle_42");
            for(int index=0;index<snapshot.Vehicles.Count;index++)
                Require(Mathf.Abs(GameObject.Find("SelfHostedVehicle_"+(ulong)(41+index))
                    .transform.position.x-(index+1))<.0001f,
                    "new vehicle pose waits in the remote visual buffer: "+index);
            presenter.RenderAt(Time.realtimeSinceStartup+.12f,.016f);
            for(int index=0;index<snapshot.Vehicles.Count;index++)
                Require(Mathf.Abs(GameObject.Find("SelfHostedVehicle_"+(ulong)(41+index))
                    .transform.position.x-(index+2.6f))<.1f,
                    "host-tick vehicle position interpolates: "+index);
            Require(Vector3.Dot(moving.transform.forward,Vector3.right)<.999f&&
                Vector3.Dot(moving.transform.forward,Vector3.forward)<.999f,
                "host-tick Tank facing interpolates");
            presenter.RenderAt(Time.realtimeSinceStartup+1.4f,.016f);
            for(int index=0;index<snapshot.Vehicles.Count;index++)
                Require(Mathf.Abs(GameObject.Find("SelfHostedVehicle_"+(ulong)(41+index))
                    .transform.position.x-(index+5))<.01f,
                    "remote vehicle visual settles on the host pose: "+index);
            Require(Vector3.Dot(moving.transform.forward,Vector3.forward)>.999f,
                "Tank facing settles on the host pose");
            presenter.Apply(new MatchSnapshot());
            for(ulong id=41;id<=44;id++)
                Require(GameObject.Find("SelfHostedVehicle_"+id)==null,"snapshot removal "+id);

            Debug.Log("UNITY_GROUND_VEHICLE_RENDER_PASSED families=4 meshIdentity=True scriptFree=True facing=True interpolation=True removal=True");
            EditorApplication.Exit(0);
        }
        catch(Exception exception)
        {
            Debug.LogError(exception);
            EditorApplication.Exit(1);
        }
        finally
        {
            if(owner!=null)UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static Transform Load(string name)
    {
        GameObject prefab=AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/"+name+".prefab");
        Require(prefab!=null,"recovered "+name+" prefab");
        Require(prefab.GetComponentsInChildren<MeshRenderer>(true).Length>0,
            "recovered "+name+" meshes");
        return prefab.transform;
    }

    private static void Add(MatchSnapshot snapshot,ulong id,string unitId,float x,float y,float z)
    {
        snapshot.Vehicles.Add(new BattleVehicleState
        {
            EntityId=id,UnitId=unitId,OwnerPlayerId="11111111111111111111111111111111",
            Generation=1,X=x,Y=y,Z=z,FacingZ=1,Health=10,MaxHealth=10
        });
    }

    private static void CheckVisual(ulong id,Transform source,Vector3 position,Vector3 forward)
    {
        GameObject visual=GameObject.Find("SelfHostedVehicle_"+id);
        Require(visual!=null,"visual "+id);
        Require(visual.transform.position==position,"host position "+id);
        Require(Vector3.Dot(visual.transform.forward,forward)>.999f,"host facing "+id);
        MeshRenderer[] originals=source.GetComponentsInChildren<MeshRenderer>(true);
        MeshRenderer[] copies=visual.GetComponentsInChildren<MeshRenderer>(true);
        Require(copies.Length==originals.Length,"renderer count "+id);
        int visibleRenderers=0;
        for(int index=0;index<copies.Length;index++)
        {
            MeshFilter originalFilter=originals[index].GetComponent<MeshFilter>();
            MeshFilter copiedFilter=copies[index].GetComponent<MeshFilter>();
            Require(originalFilter!=null&&copiedFilter!=null&&
                originalFilter.sharedMesh==copiedFilter.sharedMesh,"mesh identity "+id+"/"+index);
            if(copies[index].enabled&&copies[index].gameObject.activeInHierarchy)
                visibleRenderers++;
        }
        Require(visibleRenderers>0,"visible recovered mesh "+id);
        Require(visual.GetComponentsInChildren<MonoBehaviour>(true).Length==0&&
            visual.GetComponentsInChildren<Collider>(true).Length==0,
            "script-free collision-free visual "+id);
    }

    private static void Require(bool condition,string name)
    {
        if(!condition)throw new InvalidOperationException("Ground-vehicle render audit failed: "+name);
    }
}
