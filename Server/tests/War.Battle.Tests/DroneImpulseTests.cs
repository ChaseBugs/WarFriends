using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DroneImpulseTests
{
    internal static int Run(string directory,DroneColliderCatalog geometry)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-impulse.json")));
        if(document.RootElement.GetProperty("unityVersion").GetString()!="2018.3.0f2"||
           document.RootElement.GetProperty("scenario").GetString()!="source-body-impulse-at-world-point"||
           document.RootElement.GetProperty("fixedTimestep").GetSingle()!=.02f||
           document.RootElement.GetProperty("rows").GetArrayLength()!=6)
            throw new Exception("Drone impulse oracle identity or coverage changed.");
        Vector3 Vec(JsonElement value)=>new(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
        var response=new DroneImpulseResponse(geometry);int count=0;
        foreach(var row in document.RootElement.GetProperty("rows").EnumerateArray())
        {
            if(row.GetProperty("frames").GetArrayLength()!=50)
                throw new Exception("Truncated Drone impulse trajectory oracle.");
            var q=row.GetProperty("rotation");
            var rotation=new Quaternion(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
            var result=response.Apply(Vec(row.GetProperty("root")),rotation,Vector3.Zero,Vector3.Zero,
                Vec(row.GetProperty("impulse")),Vec(row.GetProperty("point")));
            var (velocity,angular)=DroneRigidMotion.AdvanceVelocities(result.Velocity,result.AngularVelocity);
            if(Vector3.Distance(velocity,Vec(row.GetProperty("velocity")))>.00001f||
               Vector3.Distance(angular,Vec(row.GetProperty("angularVelocity")))>.00001f)
                throw new Exception("Drone off-center impulse differs from independent Unity simulation.");
            count++;
            int frameIndex=0;
            var stepVelocity=velocity;var stepAngular=angular;
            var stepPose=DroneRigidMotion.Integrate(DroneMassProperties.Compute(geometry),Vec(row.GetProperty("root")),
                rotation,stepVelocity,stepAngular);
            foreach(var sample in row.GetProperty("frames").EnumerateArray())
            {
                if(frameIndex>0)
                {
                    (stepVelocity,stepAngular)=DroneRigidMotion.AdvanceVelocities(stepVelocity,stepAngular);
                    stepPose=DroneRigidMotion.Integrate(DroneMassProperties.Compute(geometry),stepPose.Root,stepPose.Rotation,stepVelocity,stepAngular);
                }
                var s=sample.GetProperty("rotation");
                var observed=new Quaternion(s[0].GetSingle(),s[1].GetSingle(),s[2].GetSingle(),s[3].GetSingle());
                if(Quaternion.Dot(stepPose.Rotation,observed)<0)observed=Quaternion.Negate(observed);
                if(sample.GetProperty("frame").GetInt32()!=frameIndex+1||
                   Vector3.Distance(stepPose.Root,Vec(sample.GetProperty("root")))>.0002f||
                   Vector3.Distance(stepVelocity,Vec(sample.GetProperty("velocity")))>.00002f||
                   Vector3.Distance(stepAngular,Vec(sample.GetProperty("angularVelocity")))>.00002f||
                   Quaternion.Subtract(stepPose.Rotation,observed).Length()>.00001f)
                    throw new Exception("Drone multi-step impulse trajectory differs from Unity frame "+(frameIndex+1));
                frameIndex++;count++;
            }
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
