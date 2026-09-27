using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DroneDeathContactTests
{
    internal static int Run(string directory,BattleCombatContent content)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-map-fall.json")));
        int count=0,boundaries=0,boxBoundaries=0;
        Vector3 Vec(JsonElement value)=>new(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
        foreach(var row in document.RootElement.GetProperty("rows").EnumerateArray())
        {
            var map=content.Maps.Single(m=>m.Source==row.GetProperty("source").GetString());
            foreach(var sample in row.GetProperty("frames").EnumerateArray())
            {
                bool actual=map.SphereOverlaps(Vec(sample.GetProperty("sphereCenter")),
                    sample.GetProperty("sphereRadius").GetSingle(),
                    Convert.ToUInt32(sample.GetProperty("sphereMask").GetString(),16));
                if(actual!=sample.GetProperty("sphereMapOverlap").GetBoolean())
                {
                    // Resting contacts can lie within binary32 geometry/cooking
                    // error of the exact boundary. Bound, report, never call exact.
                    var center=Vec(sample.GetProperty("sphereCenter"));
                    float radius=sample.GetProperty("sphereRadius").GetSingle();
                    uint mask=Convert.ToUInt32(sample.GetProperty("sphereMask").GetString(),16);
                    if(!map.SphereOverlaps(center,radius+.00001f,mask)||
                        map.SphereOverlaps(center,radius-.00001f,mask))
                        throw new Exception("Drone sphere overlap differs beyond 0.00001 boundary: "+map.Source+
                            " fraction "+row.GetProperty("fraction")+" frame "+sample.GetProperty("frame"));
                    boundaries++;
                }
                count++;
                var rotationSample=sample.GetProperty("rotation");
                var rotation=new Quaternion(rotationSample[0].GetSingle(),rotationSample[1].GetSingle(),
                    rotationSample[2].GetSingle(),rotationSample[3].GetSingle());
                var boxCenter=Vec(sample.GetProperty("boxCenter"));var boxSize=Vec(sample.GetProperty("boxSize"));
                uint boxMask=Convert.ToUInt32(sample.GetProperty("boxMask").GetString(),16);
                if(map.BoxOverlaps(boxCenter,boxSize,rotation,boxMask)!=sample.GetProperty("boxMapOverlap").GetBoolean())
                {
                    var margin=new Vector3(.00002f);
                    if(!map.BoxOverlaps(boxCenter,boxSize+margin,rotation,boxMask)||
                        map.BoxOverlaps(boxCenter,boxSize-margin,rotation,boxMask))
                        throw new Exception("Drone box overlap differs beyond 0.00001 boundary: "+map.Source+
                            " fraction "+row.GetProperty("fraction")+" frame "+sample.GetProperty("frame"));
                    boxBoundaries++;
                }
                count++;
            }
            var callbacks=row.GetProperty("collisionCallbacks");
            if(callbacks.GetArrayLength()==0)throw new Exception("Missing Drone collision callback oracle.");
            var first=callbacks[0];int frame=first.GetProperty("frame").GetInt32();
            var freePosition=Vec(row.GetProperty("frames")[0].GetProperty("position"));
            var freeVelocity=Vector3.Zero;
            var initial=row.GetProperty("frames")[0];
            var boxOffset=Vec(initial.GetProperty("boxCenter"))-freePosition;
            var sphereOffset=Vec(initial.GetProperty("sphereCenter"))-freePosition;
            uint rootMask=Convert.ToUInt32(initial.GetProperty("boxMask").GetString(),16);
            uint childMask=Convert.ToUInt32(initial.GetProperty("sphereMask").GetString(),16);
            var rootSize=Vec(initial.GetProperty("boxSize"));
            float childRadius=initial.GetProperty("sphereRadius").GetSingle();
            int exactCandidate=-1,marginCandidate=-1;
            int stagedCandidate=-1;
            for(int freeFrame=0;freeFrame<frame;freeFrame++)
            {
                var observed=row.GetProperty("frames")[freeFrame];
                if(Vector3.Distance(freePosition,Vec(observed.GetProperty("position")))>.0001f||
                   Vector3.Distance(freeVelocity,Vec(observed.GetProperty("velocity")))>.00001f)
                    throw new Exception("Drone pre-contact free fall differs in "+map.Source+
                        " fraction "+row.GetProperty("fraction")+" frame "+freeFrame);
                count++;
                if(stagedCandidate<0&&DroneMapContactCandidate.Query(map,content.DroneColliders,
                    freePosition,Quaternion.Identity,rootMask,childMask,.02f))stagedCandidate=freeFrame+1;
                (freePosition,freeVelocity)=DroneFreeFall.Step(freePosition,freeVelocity);
                if(exactCandidate<0&&(map.BoxOverlaps(freePosition+boxOffset,rootSize,Quaternion.Identity,rootMask)||
                    map.SphereOverlaps(freePosition+sphereOffset,childRadius,childMask)))exactCandidate=freeFrame+1;
                // Two default 0.01 contact offsets. Box expansion is a conservative
                // axis margin, not the rounded PhysX contact-distance manifold.
                if(marginCandidate<0&&(map.BoxOverlaps(freePosition+boxOffset,rootSize+new Vector3(.04f),
                    Quaternion.Identity,rootMask)||map.SphereOverlaps(freePosition+sphereOffset,childRadius+.02f,childMask)))
                    marginCandidate=freeFrame+1;
            }
            Console.WriteLine("Drone first-contact diagnostic: "+map.Source+" fraction "+row.GetProperty("fraction")+
                " callback="+frame+" exact="+exactCandidate+" conservative-margin="+marginCandidate);
            if(stagedCandidate!=frame)
                throw new Exception("Start-of-step Drone candidate disagrees with sampled first callback in "+map.Source);
            count++;
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
        Console.WriteLine("Drone sphere overlap oracle: "+boundaries+" boundary differences within 0.00001 world units.");
        Console.WriteLine("Drone box overlap oracle: "+boxBoundaries+" boundary differences within 0.00001 world units.");
        return count;
    }
}
