using System.Numerics;
using War.BattleServer;

internal static class HelicopterWaypointTests
{
    internal static int Run(BattleCombatContent content)
    {
        int count=0;
        void Check(bool condition){if(!condition)throw new Exception("Helicopter source movement boundary failed.");count++;}
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
        return count;
    }
}
