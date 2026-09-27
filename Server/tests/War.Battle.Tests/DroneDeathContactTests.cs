using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DroneDeathContactTests
{
    internal static int Run(string directory)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-map-fall.json")));
        int count=0;
        Vector3 Vec(JsonElement value)=>new(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
        foreach(var row in document.RootElement.GetProperty("rows").EnumerateArray())
        {
            var callbacks=row.GetProperty("collisionCallbacks");
            if(callbacks.GetArrayLength()==0)throw new Exception("Missing Drone collision callback oracle.");
            var first=callbacks[0];int frame=first.GetProperty("frame").GetInt32();
            var root=Vec(first.GetProperty("rootPosition"));
            if(frame<1||frame>150||Vector3.Distance(root,Vec(row.GetProperty("frames")[frame].GetProperty("position")))>.0001f)
                throw new Exception("Drone callback root does not match physics publication.");
            var death=new DroneDeathState(0,400);
            var explosion=death.ObserveCollision(frame*.02f,root);
            if(explosion==null||explosion.Position!=root||explosion.Damage!=200||
               Math.Abs(death.DestructionDeadline!.Value-(frame*.02f+.2f))>.000001f)
                throw new Exception("Drone first contact failed to bind root explosion authority.");
            count++;
            foreach(var later in callbacks.EnumerateArray().Skip(1))
            {
                if(death.ObserveCollision(later.GetProperty("frame").GetInt32()*.02f,
                    Vec(later.GetProperty("rootPosition")))!=null)
                    throw new Exception("Later source contact repeated Drone death blast.");
                count++;
            }
        }
        return count;
    }
}
