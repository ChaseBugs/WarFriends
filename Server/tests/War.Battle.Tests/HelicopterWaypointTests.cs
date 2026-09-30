using System.Numerics;
using System.Text.Json;
using System.Security.Cryptography;
using War.BattleServer;

internal static class HelicopterWaypointTests
{
    internal static int Run(string directory,BattleCombatContent content)
    {
        int count=0;
        void Check(bool condition,string name="Helicopter source movement boundary failed")
        {if(!condition)throw new Exception(name);count++;}
        foreach(var map in content.Maps)
        foreach(var spawn in content.ArmySpawnPoints.ForMap(map).Where(p=>p.Collection=="spawnPointsCollectionHelicopters"))
        {
            var route=content.AirWaypoints.ForSpawn(map,spawn.ComponentFileId);
            var state=new HelicopterWaypointState(route,spawn.Position,3f);
            Check(state.TargetIndex==route.JoinIndex&&state.Position==spawn.Position&&!state.StopReached);
        }
        var points=new[]{new DroneWaypoint(1,Vector3.Zero,0),new DroneWaypoint(2,new Vector3(10,0,0),0)};
        var routeControl=new AirWaypointRoute(1,2,0,1,.2f,points);
        var travel=new HelicopterWaypointState(routeControl,Vector3.Zero,3f);
        Check(!travel.Advance(0)&&travel.TargetIndex==1&&travel.Position==Vector3.Zero);
        Check(!travel.Advance(.033f)&&Vector3.Distance(travel.Position,new Vector3(.00066f,0,0))<.000001f&&
            !travel.Breaking);
        var priorPosition=travel.Position;var priorVelocity=travel.Velocity;
        try
        {
            _=travel.Advance(.01f);
            throw new Exception("Regressing Helicopter realtime accepted.");
        }
        catch(InvalidDataException){}
        Check(travel.Position==priorPosition&&travel.Velocity==priorVelocity&&travel.TargetIndex==1);
        var braking=new HelicopterWaypointState(routeControl,new Vector3(5,0,0),3f);
        _=braking.Advance(0);
        Check(!braking.Advance(.033f)&&braking.Breaking&&
            Vector3.Distance(braking.Position,new Vector3(5.001833333f,0,0))<.000002f);
        var stopped=new HelicopterWaypointState(routeControl,new Vector3(9.5f,0,0),3f);
        Check(stopped.Advance(0)&&stopped.StopReached&&!stopped.Advance(.033f));
        try
        {
            _=new HelicopterWaypointState(routeControl with{StopIndex=0},Vector3.Zero,3f);
            throw new Exception("Join point accepted as Helicopter stop.");
        }
        catch(InvalidDataException){count++;}
        var crew=new HelicopterCrewSchedule(90,3);
        Check(crew.DueTick(0)==240&&crew.DueTick(1)==300&&crew.DueTick(2)==360&&
              crew.DueSlots(239).Count==0&&crew.DueSlots(240).SequenceEqual(new[]{0})&&
              crew.DueSlots(359).SequenceEqual(new[]{0,1})&&
              crew.DueSlots(360).SequenceEqual(new[]{0,1,2}),
            "Helicopter source crew drop waits five seconds then two per ordered slot");
        try{_=new HelicopterCrewSchedule(ulong.MaxValue,6);throw new Exception("Overflowing crew timeline accepted.");}
        catch(InvalidDataException){count++;}
        try{_=new HelicopterCrewSchedule(1,7);throw new Exception("Crew beyond prefab points accepted.");}
        catch(InvalidDataException){count++;}
        using(var oracle=JsonDocument.Parse(File.ReadAllText(Path.Combine(directory,"recovered-helicopter-steer.json"))))
        {
            var data=oracle.RootElement;
            Check(data.GetProperty("version").GetInt32()==1&&
                  data.GetProperty("unityVersion").GetString()=="2018.3.0f2"&&
                  data.GetProperty("source").GetString()=="Assets/GameObject/Helicopter.prefab"&&
                  data.GetProperty("prefabSha256").GetString()==
                  Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(Path.GetFullPath(
                      Path.Combine(directory,"..","..","Clients","ExportedProject","Assets","GameObject","Helicopter.prefab"))))),
                "Helicopter steer oracle binds recovered prefab and Unity runtime");
            Check(data.GetProperty("breakDistance").GetSingle()==6f&&
                  data.GetProperty("breakSpeed").GetSingle()==2f&&
                  data.GetProperty("mass").GetSingle()==150f&&
                  data.GetProperty("speed").GetSingle()==3f,
                "Helicopter steer oracle binds source motion constants");
            var rows=data.GetProperty("rows").EnumerateArray().ToArray();
            Check(rows.Length==3&&rows.Select(r=>r.GetProperty("x").GetSingle()).SequenceEqual(new[]{0f,5f,8f}),
                "Helicopter steer oracle covers straight and braking ranges");
            foreach(var row in rows)
            {
                float x=row.GetProperty("x").GetSingle(),dt=row.GetProperty("delta").GetSingle();
                var seek=new HelicopterWaypointState(routeControl with{Waypoints=[
                    new DroneWaypoint(1,new Vector3(x,0,0),0),points[1]]},new Vector3(x,0,0),3f);
                _=seek.Advance(0);
                _=seek.Advance(dt);
                var expected=row.GetProperty("steer").EnumerateArray().Select(c=>c.GetSingle()).ToArray();
                Check(dt>0&&dt<=1f&&seek.Breaking==row.GetProperty("braking").GetBoolean()&&
                      Vector3.Distance(seek.Velocity,new Vector3(expected[0],expected[1],expected[2]))<.0000001f,
                    "Helicopter host steering matches recovered Unity method");
            }
        }
        return count;
    }
}
