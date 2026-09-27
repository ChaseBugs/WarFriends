using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DroneDeathContactTests
{
    internal static int Run(string directory,BattleCombatContent content)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-map-fall.json")));
        int count=0,boundaries=0,boxBoundaries=0,sphereContacts=0,missingSurfaces=0;
        float maximumPointError=0,maximumNormalError=0,maximumSeparationError=0;
        float firstPointError=0,firstNormalError=0,firstSeparationError=0;int firstSphereContacts=0;
        float firstBodyPointError=0;
        float maximumImpulseResidual=0;
        string worstPointCase="",worstSeparationCase="";
        Vector3 Vec(JsonElement value)=>new(value[0].GetSingle(),value[1].GetSingle(),value[2].GetSingle());
        foreach(var row in document.RootElement.GetProperty("rows").EnumerateArray())
        {
            var dynamics=row.GetProperty("bodyDynamics");var mass=DroneMassProperties.Compute(content.DroneColliders);
            var tensor=Vec(dynamics.GetProperty("inertiaTensor"));var inertiaRotation=dynamics.GetProperty("inertiaTensorRotation");
            var rotationMatrix=Matrix4x4.CreateFromQuaternion(new Quaternion(inertiaRotation[0].GetSingle(),
                inertiaRotation[1].GetSingle(),inertiaRotation[2].GetSingle(),inertiaRotation[3].GetSingle()));
            var expectedInertia=Matrix4x4.Transpose(rotationMatrix)*Matrix4x4.CreateScale(tensor)*rotationMatrix;
            if(Vector3.Distance(mass.CenterOfMass,Vec(dynamics.GetProperty("centerOfMass")))>.00001f||
               Math.Abs(mass.Inertia.M11-expectedInertia.M11)>.00001f||
               Math.Abs(mass.Inertia.M22-expectedInertia.M22)>.00001f||
               Math.Abs(mass.Inertia.M33-expectedInertia.M33)>.00001f||
               Math.Abs(mass.Inertia.M12-expectedInertia.M12)>.00001f||
               Math.Abs(mass.Inertia.M13-expectedInertia.M13)>.00001f||
               Math.Abs(mass.Inertia.M23-expectedInertia.M23)>.00001f)
                throw new Exception("Source compound mass properties differ from Unity Rigidbody.");
            count++;
            var map=content.Maps.Single(m=>m.Source==row.GetProperty("source").GetString());
            foreach(var sample in row.GetProperty("frames").EnumerateArray())
            {
                bool actual=map.SphereOverlaps(Vec(sample.GetProperty("sphereCenter")),
                    sample.GetProperty("sphereRadius").GetSingle(),
                    Convert.ToUInt32(sample.GetProperty("sphereMask").GetString(),16));
                var surfaces=map.SphereSurfaceContacts(Vec(sample.GetProperty("sphereCenter")),
                    sample.GetProperty("sphereRadius").GetSingle(),0,
                    Convert.ToUInt32(sample.GetProperty("sphereMask").GetString(),16));
                if((surfaces.Count>0)!=actual||surfaces.Any(c=>!float.IsFinite(c.Separation)||
                    c.Separation>.000001f||Math.Abs(c.Normal.Length()-1)>.0001f))
                    throw new Exception("Sphere surface contacts disagree with map overlap authority.");
                count++;
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
            foreach(var callback in callbacks.EnumerateArray())
            {
                int callbackFrame=callback.GetProperty("frame").GetInt32();
                var prior=row.GetProperty("frames")[callbackFrame-1];
                var surfaces=map.SphereSurfaceContacts(Vec(prior.GetProperty("sphereCenter")),
                    prior.GetProperty("sphereRadius").GetSingle(),.1f,
                    Convert.ToUInt32(prior.GetProperty("sphereMask").GetString(),16));
                foreach(var observedContact in callback.GetProperty("contacts").EnumerateArray()
                    .Where(c=>c.GetProperty("bodyColliderType").GetString()=="SphereCollider"))
                {
                    sphereContacts++;
                    var surface=surfaces.FirstOrDefault(c=>c.ColliderIndex==observedContact.GetProperty("otherColliderIndex").GetInt32());
                    if(surface==null){missingSurfaces++;continue;}
                    float pointError=Vector3.Distance(surface.SurfacePoint,Vec(observedContact.GetProperty("position")));
                    float separationError=Math.Abs(surface.Separation-observedContact.GetProperty("separation").GetSingle());
                    if(pointError>maximumPointError)worstPointCase=map.Source+" fraction "+row.GetProperty("fraction")+
                        " frame "+callbackFrame+" collider "+surface.SourcePath+" host="+surface.SurfacePoint+
                        " Unity="+Vec(observedContact.GetProperty("position"));
                    if(separationError>maximumSeparationError)worstSeparationCase=map.Source+" fraction "+row.GetProperty("fraction")+
                        " frame "+callbackFrame+" collider "+surface.SourcePath+" host="+surface.Separation+
                        " Unity="+observedContact.GetProperty("separation").GetSingle();
                    maximumPointError=Math.Max(maximumPointError,Vector3.Distance(surface.SurfacePoint,
                        Vec(observedContact.GetProperty("position"))));
                    maximumNormalError=Math.Max(maximumNormalError,Vector3.Distance(surface.Normal,
                        Vec(observedContact.GetProperty("normal"))));
                    maximumSeparationError=Math.Max(maximumSeparationError,Math.Abs(surface.Separation-
                        observedContact.GetProperty("separation").GetSingle()));
                    if(callbackFrame==callbacks[0].GetProperty("frame").GetInt32())
                    {
                        firstSphereContacts++;
                        firstPointError=Math.Max(firstPointError,Vector3.Distance(surface.SurfacePoint,
                            Vec(observedContact.GetProperty("position"))));
                        firstNormalError=Math.Max(firstNormalError,Vector3.Distance(surface.Normal,
                            Vec(observedContact.GetProperty("normal"))));
                        firstSeparationError=Math.Max(firstSeparationError,Math.Abs(surface.Separation-
                            observedContact.GetProperty("separation").GetSingle()));
                        float bodyPointError=Vector3.Distance(surface.SurfacePoint+surface.Normal*surface.Separation,
                            Vec(observedContact.GetProperty("position")));
                        firstBodyPointError=Math.Max(firstBodyPointError,bodyPointError);
                        if(Vector3.Distance(surface.Normal,Vec(observedContact.GetProperty("normal")))>.00001f||
                           Math.Abs(surface.Separation-observedContact.GetProperty("separation").GetSingle())>.00001f||
                           bodyPointError>.00001f)
                            throw new Exception("First sphere manifold exceeds independently observed geometry tolerance.");
                        count++;
                    }
                }
            }
            var first=callbacks[0];int frame=first.GetProperty("frame").GetInt32();
            var priorVelocity=Vec(row.GetProperty("frames")[frame-1].GetProperty("velocity"));
            var impulseSum=callbacks.EnumerateArray().Where(c=>c.GetProperty("frame").GetInt32()==frame)
                .Aggregate(Vector3.Zero,(sum,c)=>sum+Vec(c.GetProperty("impulse")));
            var freeStep=DroneRigidMotion.AdvanceVelocities(priorVelocity,Vector3.Zero);
            maximumImpulseResidual=Math.Max(maximumImpulseResidual,Vector3.Distance(freeStep.Velocity+impulseSum,
                Vec(row.GetProperty("frames")[frame].GetProperty("velocity"))));
            var freePosition=Vec(row.GetProperty("frames")[0].GetProperty("position"));
            var freeVelocity=Vector3.Zero;
            var initial=row.GetProperty("frames")[0];
            var initialQuat=initial.GetProperty("rotation");
            var initialRotation=new Quaternion(initialQuat[0].GetSingle(),initialQuat[1].GetSingle(),
                initialQuat[2].GetSingle(),initialQuat[3].GetSingle());
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
                    freePosition,initialRotation,rootMask,childMask,.02f))stagedCandidate=freeFrame+1;
                (freePosition,freeVelocity)=DroneFreeFall.Step(freePosition,freeVelocity);
                if(exactCandidate<0&&(map.BoxOverlaps(freePosition+boxOffset,rootSize,initialRotation,rootMask)||
                    map.SphereOverlaps(freePosition+sphereOffset,childRadius,childMask)))exactCandidate=freeFrame+1;
                // Two default 0.01 contact offsets. Box expansion is a conservative
                // axis margin, not the rounded PhysX contact-distance manifold.
                if(marginCandidate<0&&(map.BoxOverlaps(freePosition+boxOffset,rootSize+new Vector3(.04f),
                    initialRotation,rootMask)||map.SphereOverlaps(freePosition+sphereOffset,childRadius+.02f,childMask)))
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
        Console.WriteLine("Drone sphere manifold diagnostic: contacts="+sphereContacts+" missing="+missingSurfaces+
            " maximum point error="+maximumPointError+" normal error="+maximumNormalError+
            " separation error="+maximumSeparationError+" (diagnostic only, not solver verification).");
        Console.WriteLine("Drone first sphere contact diagnostic: contacts="+firstSphereContacts+
            " maximum point error="+firstPointError+" normal error="+firstNormalError+
            " separation error="+firstSeparationError+" body point error="+firstBodyPointError);
        Console.WriteLine("Drone worst contact point: "+worstPointCase);
        Console.WriteLine("Drone worst contact separation: "+worstSeparationCase);
        Console.WriteLine("Drone reported collision impulse diagnostic: maximum velocity residual="+
            maximumImpulseResidual+" (reported impulses alone do not verify complete contact response).");
        return count;
    }
}
