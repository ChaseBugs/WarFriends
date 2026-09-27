using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DroneImpulseTests
{
    internal static int Run(string directory,DroneColliderCatalog geometry)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-impulse.json")));
        Vector3 Vec(JsonElement value)=>new(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
        var response=new DroneImpulseResponse(geometry);int count=0;
        foreach(var row in document.RootElement.GetProperty("rows").EnumerateArray())
        {
            var q=row.GetProperty("rotation");
            var rotation=new Quaternion(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
            var result=response.Apply(Vec(row.GetProperty("root")),rotation,Vector3.Zero,Vector3.Zero,
                Vec(row.GetProperty("impulse")),Vec(row.GetProperty("point")));
            var velocity=(result.Velocity+new Vector3(0,-9.81f,0)*.02f)*.98f;
            var angular=result.AngularVelocity*.999f;
            if(Vector3.Distance(velocity,Vec(row.GetProperty("velocity")))>.00001f||
               Vector3.Distance(angular,Vec(row.GetProperty("angularVelocity")))>.00001f)
                throw new Exception("Drone off-center impulse differs from independent Unity simulation.");
            count++;
            var pose=DroneRigidMotion.Integrate(DroneMassProperties.Compute(geometry),Vec(row.GetProperty("root")),
                rotation,velocity,angular);
            var final=row.GetProperty("finalRotation");
            var expectedRotation=new Quaternion(final[0].GetSingle(),final[1].GetSingle(),final[2].GetSingle(),final[3].GetSingle());
            if(Quaternion.Dot(pose.Rotation,expectedRotation)<0)expectedRotation=Quaternion.Negate(expectedRotation);
            if(Vector3.Distance(pose.Root,Vec(row.GetProperty("finalRoot")))>.00002f||
               Quaternion.Subtract(pose.Rotation,expectedRotation).Length()>.00001f)
                throw new Exception("Drone center-of-mass rigid integration differs from Unity.");
            count++;
        }
        return count;
    }
}
