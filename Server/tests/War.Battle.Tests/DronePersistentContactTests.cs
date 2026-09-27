using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class DronePersistentContactTests
{
    internal static int Run(string directory,DroneColliderCatalog geometry)
    {
        DroneContactHistoryRestartTests.Run(directory,geometry);
        // A rejected batch must not replace friction history from the preceding
        // successful step; a successful empty pair must deliberately clear it.
        var history=new DroneContactSolver(geometry);
        var control=new DroneContactSolver(geometry);
        var historyPair=new[]{new MaterialContact(new DroneNormalPoint(Vector3.Zero,Vector3.UnitY,-.001f),
            new ContactMaterial(.6f,.6f,0))};
        DroneNormalResult Step(DroneContactSolver solver,MaterialContact[][] pairs)=>solver.Solve(
            Vector3.Zero,Quaternion.Identity,new Vector3(.1f,-.2f,0),Vector3.Zero,pairs,.999f,.025f,.04f,true);
        _=Step(history,new[]{historyPair});_=Step(control,new[]{historyPair});
        try
        {
            _=Step(history,new[]{historyPair,new[]{historyPair[0] with{Material=new ContactMaterial(.6f,.6f,.1f)}}});
            throw new Exception("Unsupported late contact accepted.");
        }
        catch(InvalidDataException){}
        try
        {
            _=history.Solve(Vector3.Zero,Quaternion.Identity,Vector3.Zero,Vector3.Zero,
                new[]{historyPair},.999f,.025f,.04f,true,reuseCorrelationDistance:float.NaN);
            throw new Exception("Invalid friction reuse distance accepted.");
        }
        catch(InvalidDataException){}
        if(Step(history,new[]{historyPair})!=Step(control,new[]{historyPair}))
            throw new Exception("Rejected contact batch changed retained friction authority.");
        _=Step(history,new[]{Array.Empty<MaterialContact>()});
        if(Step(history,new[]{historyPair})!=Step(new DroneContactSolver(geometry),new[]{historyPair}))
            throw new Exception("Absent contact pair retained stale friction authority.");
        var withoutStrong=history.Solve(Vector3.UnitX*.01f,Quaternion.Identity,new Vector3(.1f,-.2f,0),Vector3.Zero,
            new[]{historyPair},.999f,.025f,.04f,true,new[]{true});
        var freshWithoutStrong=new DroneContactSolver(geometry).Solve(Vector3.UnitX*.01f,Quaternion.Identity,
            new Vector3(.1f,-.2f,0),Vector3.Zero,new[]{historyPair},.999f,.025f,.04f,true);
        if(withoutStrong!=freshWithoutStrong)
            throw new Exception("Disabled strong friction reused previous anchors.");
        try
        {
            _=history.Solve(Vector3.Zero,Quaternion.Identity,Vector3.Zero,Vector3.Zero,
                new[]{historyPair},.999f,.025f,.04f,true,Array.Empty<bool>());
            throw new Exception("Unbound strong-friction flags accepted.");
        }
        catch(InvalidDataException){}
        using var document=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-persistent-contact.json")));
        var root=document.RootElement;
        if(root.GetProperty("callbackPolicy").GetString()!="enter-and-stay"||root.GetProperty("rows").GetArrayLength()!=30||
           root.GetProperty("materialPolicy").GetString()!="source-materials"||root.GetProperty("unityVersion").GetString()!="2018.3.0f2")
            throw new Exception("Persistent-contact oracle identity changed.");
        Vector3 Vec(JsonElement v)=>new(v[0].GetSingle(),v[1].GetSingle(),v[2].GetSingle());
        Quaternion Quat(JsonElement q)=>new(q[0].GetSingle(),q[1].GetSingle(),q[2].GetSingle(),q[3].GetSingle());
        float maximumVelocity=0,maximumAngular=0,maximumRoot=0;int steps=0,stays=0;
        float cachedVelocity=0,cachedAngular=0,cachedRoot=0;
        string worstVelocity="",worstAngular="",worstRoot="";int materials=0;
        int stationaryBodies=0,kinematicContacts=0,contactFreeSteps=0,totalFrames=0;
        var pairCoverage=new SortedDictionary<int,(int Steps,float Velocity,float Angular,float Root)>();
        string singlePairWorstVelocity="";
        float shorterVelocity=0,shorterAngular=0,shorterRoot=0;
        int shorterImproved=0,shorterWorse=0,shorterEquivalent=0;
        float reuseOnlyVelocity=0,reuseOnlyAngular=0,reuseOnlyRoot=0;
        int reuseOnlyImproved=0,reuseOnlyWorse=0,reuseOnlyEquivalent=0;
        foreach(var row in root.GetProperty("rows").EnumerateArray())
        {
            var frames=row.GetProperty("frames");
            var cachedSolver=new DroneContactSolver(geometry);
            var shorterSolver=new DroneContactSolver(geometry);
            var reuseOnlySolver=new DroneContactSolver(geometry);
            var pairIds=new Dictionary<(string?,int),int>();
            var callbacks=row.GetProperty("collisionCallbacks").EnumerateArray().ToLookup(c=>c.GetProperty("frame").GetInt32());
            for(int frame=1;frame<frames.GetArrayLength();frame++)
            {
                totalFrames++;
                var group=callbacks[frame];
                var before=frames[frame-1];var after=frames[frame];
                if(!group.Any())
                {
                    contactFreeSteps++;
                    // Contact-free simulation steps clear the shape-pair cache,
                    // even though Unity emits no collision callback for them.
                    _=cachedSolver.Solve(Vec(before.GetProperty("position")),Quat(before.GetProperty("rotation")),
                        Vec(before.GetProperty("velocity")),Vec(before.GetProperty("angularVelocity")),
                        Enumerable.Range(0,pairIds.Count).Select(_=>Array.Empty<MaterialContact>()).ToArray(),.999f,.025f,.04f,true);
                    _=shorterSolver.Solve(Vec(before.GetProperty("position")),Quat(before.GetProperty("rotation")),
                        Vec(before.GetProperty("velocity")),Vec(before.GetProperty("angularVelocity")),
                        Enumerable.Range(0,pairIds.Count).Select(_=>Array.Empty<MaterialContact>()).ToArray(),.999f,.0025f,.04f,true);
                    _=reuseOnlySolver.Solve(Vec(before.GetProperty("position")),Quat(before.GetProperty("rotation")),
                        Vec(before.GetProperty("velocity")),Vec(before.GetProperty("angularVelocity")),
                        Enumerable.Range(0,pairIds.Count).Select(_=>Array.Empty<MaterialContact>()).ToArray(),.999f,.025f,.04f,true,
                        reuseCorrelationDistance:.0025f);
                    continue;
                }
                stays+=group.Count(c=>c.GetProperty("callbackKind").GetString()=="stay");
                var recordedContacts=group.SelectMany(c=>c.GetProperty("contacts").EnumerateArray()).ToArray();
                foreach(var contact in recordedContacts)
                {
                    var body=contact.GetProperty("otherBody");
                    if((body.GetProperty("present").GetBoolean()&&!body.GetProperty("isKinematic").GetBoolean())||
                       Vec(body.GetProperty("velocity"))!=Vector3.Zero||Vec(body.GetProperty("angularVelocity"))!=Vector3.Zero)
                        throw new Exception("Persistent counterpart violates stationary-map solver boundary.");
                    stationaryBodies++;if(body.GetProperty("present").GetBoolean())kinematicContacts++;
                }
                foreach(var contact in recordedContacts)
                foreach(var name in new[]{"bodyMaterial","otherMaterial"})
                {
                    var material=contact.GetProperty(name);
                    if(material.GetProperty("staticFriction").GetSingle()!=.6f||material.GetProperty("dynamicFriction").GetSingle()!=.6f||
                       material.GetProperty("restitution").GetSingle()!=0||material.GetProperty("frictionCombine").GetInt32()!=0||
                       material.GetProperty("restitutionCombine").GetInt32()!=0)
                        throw new Exception("Persistent-contact material differs from solver assumptions.");
                    materials++;
                }
                var pairs=group.SelectMany(c=>c.GetProperty("contacts").EnumerateArray()).GroupBy(c=>
                    (c.GetProperty("bodyCollider").GetString(),c.GetProperty("otherColliderIndex").GetInt32()))
                    .Select(p=>p.Select(c=>new MaterialContact(new DroneNormalPoint(Vec(c.GetProperty("position")),
                        Vec(c.GetProperty("normal")),c.GetProperty("separation").GetSingle()),new ContactMaterial(.6f,.6f,0))).ToArray()).ToArray();
                var result=new DroneContactSolver(geometry).Solve(Vec(before.GetProperty("position")),Quat(before.GetProperty("rotation")),
                    Vec(before.GetProperty("velocity")),Vec(before.GetProperty("angularVelocity")),pairs,.999f,.025f,.04f);
                if(frame==66&&pairs.Length==4&&row.GetProperty("source").GetString()=="Assets/Scenes/Snow_Multiplayer.unity"&&
                   row.GetProperty("fraction").GetInt32()==2&&row.GetProperty("initialRotation")[0].GetSingle()>.1f)
                {
                    float minimum=float.MaxValue,maximum=0;int orders=0;
                    foreach(var order in Permutations(Enumerable.Range(0,pairs.Length).ToArray()))
                    {
                        var alternative=new DroneContactSolver(geometry).Solve(Vec(before.GetProperty("position")),Quat(before.GetProperty("rotation")),
                            Vec(before.GetProperty("velocity")),Vec(before.GetProperty("angularVelocity")),order.Select(i=>pairs[i]).ToArray(),.999f,.025f,.04f);
                        float error=Vector3.Distance(alternative.Velocity,Vec(after.GetProperty("velocity")));
                        minimum=Math.Min(minimum,error);maximum=Math.Max(maximum,error);orders++;
                    }
                    Console.WriteLine("Snow frame66 memoryless pair-order control: orders="+orders+", minimum velocity residual="+minimum+", maximum="+maximum);
                }
                maximumVelocity=Math.Max(maximumVelocity,Vector3.Distance(result.Velocity,Vec(after.GetProperty("velocity"))));
                maximumAngular=Math.Max(maximumAngular,Vector3.Distance(result.AngularVelocity,Vec(after.GetProperty("angularVelocity"))));
                maximumRoot=Math.Max(maximumRoot,Vector3.Distance(result.Pose.Root,Vec(after.GetProperty("position"))));steps++;
                var keyed=group.SelectMany(c=>c.GetProperty("contacts").EnumerateArray()).GroupBy(c=>
                    (c.GetProperty("bodyCollider").GetString(),c.GetProperty("otherColliderIndex").GetInt32())).ToArray();
                foreach(var pair in keyed)if(!pairIds.ContainsKey(pair.Key))pairIds.Add(pair.Key,pairIds.Count);
                var stable=Enumerable.Range(0,pairIds.Count).Select(_=>Array.Empty<MaterialContact>()).ToArray();
                foreach(var pair in keyed)
                    stable[pairIds[pair.Key]]=pair.Select(c=>new MaterialContact(new DroneNormalPoint(Vec(c.GetProperty("position")),
                        Vec(c.GetProperty("normal")),c.GetProperty("separation").GetSingle()),new ContactMaterial(.6f,.6f,0))).ToArray();
                var cached=cachedSolver.Solve(Vec(before.GetProperty("position")),Quat(before.GetProperty("rotation")),
                    Vec(before.GetProperty("velocity")),Vec(before.GetProperty("angularVelocity")),stable,.999f,.025f,.04f,true);
                var shorter=shorterSolver.Solve(Vec(before.GetProperty("position")),Quat(before.GetProperty("rotation")),
                    Vec(before.GetProperty("velocity")),Vec(before.GetProperty("angularVelocity")),stable,.999f,.0025f,.04f,true);
                var reuseOnly=reuseOnlySolver.Solve(Vec(before.GetProperty("position")),Quat(before.GetProperty("rotation")),
                    Vec(before.GetProperty("velocity")),Vec(before.GetProperty("angularVelocity")),stable,.999f,.025f,.04f,true,
                    reuseCorrelationDistance:.0025f);
                reuseOnlyVelocity=Math.Max(reuseOnlyVelocity,Vector3.Distance(reuseOnly.Velocity,Vec(after.GetProperty("velocity"))));
                reuseOnlyAngular=Math.Max(reuseOnlyAngular,Vector3.Distance(reuseOnly.AngularVelocity,Vec(after.GetProperty("angularVelocity"))));
                reuseOnlyRoot=Math.Max(reuseOnlyRoot,Vector3.Distance(reuseOnly.Pose.Root,Vec(after.GetProperty("position"))));
                shorterVelocity=Math.Max(shorterVelocity,Vector3.Distance(shorter.Velocity,Vec(after.GetProperty("velocity"))));
                shorterAngular=Math.Max(shorterAngular,Vector3.Distance(shorter.AngularVelocity,Vec(after.GetProperty("angularVelocity"))));
                shorterRoot=Math.Max(shorterRoot,Vector3.Distance(shorter.Pose.Root,Vec(after.GetProperty("position"))));
                if(frame>=42&&frame<=45&&row.GetProperty("source").GetString()=="Assets/Scenes/Snow_Multiplayer.unity"&&
                   row.GetProperty("fraction").GetInt32()==2&&row.GetProperty("initialRotation")[0].GetSingle()>.1f)
                    foreach(var patch in cachedSolver.FrictionHistory())
                        Console.WriteLine("Snow friction history frame="+frame+", pair="+patch.Pair+", broken="+patch.Cache.Broken+
                            ", anchors="+patch.Cache.Anchors.Count+", bodyNormal="+patch.Cache.BodyNormal+", mapNormal="+patch.Cache.MapNormal+
                            ", coordinates="+string.Join(";",patch.Cache.Anchors.Select(a=>a.BodyLocal+" -> "+a.MapWorld)));
                string identity=row.GetProperty("source").GetString()+"/fraction"+row.GetProperty("fraction")+
                    "/rotation"+Quat(row.GetProperty("initialRotation"))+"/frame"+frame+"/pairs"+keyed.Length+
                    "/contacts"+keyed.Sum(p=>p.Count());
                float ve=Vector3.Distance(cached.Velocity,Vec(after.GetProperty("velocity")));
                float ae=Vector3.Distance(cached.AngularVelocity,Vec(after.GetProperty("angularVelocity")));
                float pe=Vector3.Distance(cached.Pose.Root,Vec(after.GetProperty("position")));
                float shorterError=Vector3.Distance(shorter.Velocity,Vec(after.GetProperty("velocity")));
                if(shorterError<ve-.00002f)shorterImproved++;
                else if(shorterError>ve+.00002f)shorterWorse++;
                else shorterEquivalent++;
                float reuseOnlyError=Vector3.Distance(reuseOnly.Velocity,Vec(after.GetProperty("velocity")));
                if(reuseOnlyError<ve-.00002f)reuseOnlyImproved++;
                else if(reuseOnlyError>ve+.00002f)reuseOnlyWorse++;
                else reuseOnlyEquivalent++;
                if(frame==45&&keyed.Length==1&&keyed[0].Count()==1&&
                   row.GetProperty("source").GetString()=="Assets/Scenes/Snow_Multiplayer.unity"&&
                   row.GetProperty("fraction").GetInt32()==2&&row.GetProperty("initialRotation")[0].GetSingle()>.1f)
                {
                    var contact=pairs.Single().Single();
                    var single=new DroneSingleContactSolver(geometry).Solve(Vec(before.GetProperty("position")),
                        Quat(before.GetProperty("rotation")),Vec(before.GetProperty("velocity")),
                        Vec(before.GetProperty("angularVelocity")),contact);
                    var initial=DroneRigidMotion.AdvanceVelocities(Vec(before.GetProperty("velocity")),Vec(before.GetProperty("angularVelocity")));
                    var observedImpulse=group.Select(c=>Vec(c.GetProperty("impulse"))).Aggregate(Vector3.Zero,(a,b)=>a+b);
                    var measuredChange=Vec(after.GetProperty("velocity"))-initial.Velocity;
                    var normalDirection=contact.Geometry.Normal;
                    if(Math.Abs(Vector3.Dot(measuredChange-observedImpulse,normalDirection))>.00002f)
                        throw new Exception("Isolated persistent contact normal impulse does not conserve measured linear response.");
                    using var restarted=JsonDocument.Parse(File.ReadAllBytes(Path.Combine(directory,"recovered-drone-contact-restart.json")));
                    var restart=restarted.RootElement;
                    var freshContact=restart.GetProperty("collisionCallbacks")[0].GetProperty("contacts")[0];
                    var freshResult=new DroneSingleContactSolver(geometry).Solve(Vec(before.GetProperty("position")),
                        Quat(before.GetProperty("rotation")),Vec(before.GetProperty("velocity")),Vec(before.GetProperty("angularVelocity")),
                        new MaterialContact(new DroneNormalPoint(Vec(freshContact.GetProperty("position")),
                            Vec(freshContact.GetProperty("normal")),freshContact.GetProperty("separation").GetSingle()),new ContactMaterial(.6f,.6f,0)));
                    float freshError=Vector3.Distance(freshResult.Velocity,Vec(restart.GetProperty("freshAfter").GetProperty("velocity")));
                    Console.WriteLine("Snow frame45 restarted Unity body velocity residual="+freshError);
                    if(freshError>.00002f)throw new Exception("Fresh persistent-pose contact does not match restarted Unity body.");
                    Console.WriteLine("Snow frame45 one-contact control: cached velocity residual="+ve+
                        ", fresh="+Vector3.Distance(result.Velocity,Vec(after.GetProperty("velocity")))+
                        ", standalone="+Vector3.Distance(single.Velocity,Vec(after.GetProperty("velocity")))+
                        ", reported normal impulse residual="+Math.Abs(Vector3.Dot(measuredChange-observedImpulse,normalDirection))+
                        ", measured tangential change="+(measuredChange-normalDirection*Vector3.Dot(measuredChange,normalDirection))+
                        ", observed="+observedImpulse+", cached="+cached.Impulse+", fresh="+result.Impulse+
                        ", separation="+contact.Geometry.Separation+", normal="+contact.Geometry.Normal);
                }
                var previousCoverage=pairCoverage.GetValueOrDefault(keyed.Length);
                if(keyed.Length==1&&ve>previousCoverage.Velocity)singlePairWorstVelocity=identity;
                pairCoverage[keyed.Length]=(previousCoverage.Steps+1,Math.Max(previousCoverage.Velocity,ve),
                    Math.Max(previousCoverage.Angular,ae),Math.Max(previousCoverage.Root,pe));
                if(ve>cachedVelocity){cachedVelocity=ve;worstVelocity=identity;}
                if(ae>cachedAngular){cachedAngular=ae;worstAngular=identity;}
                if(pe>cachedRoot){cachedRoot=pe;worstRoot=identity;}
            }
        }
        if(stays==0||steps<30||contactFreeSteps==0||totalFrames!=4500||steps+contactFreeSteps!=totalFrames)
            throw new Exception("Persistent-contact oracle lacks complete fixed-step coverage.");
        Console.WriteLine("Drone memoryless persistent-contact diagnostic: steps="+steps+", stays="+stays+", velocity="+maximumVelocity+
            ", angular="+maximumAngular+", root="+maximumRoot+" (cached anchors absent; no response assertion).");
        Console.WriteLine("Drone growing-anchor cache diagnostic: velocity="+cachedVelocity+", angular="+cachedAngular+", root="+cachedRoot+
            " (experimental pair order and correlation policy).");
        Console.WriteLine("Drone persistent worst cases: velocity="+worstVelocity+"; angular="+worstAngular+"; root="+worstRoot+
            "; validated collider materials="+materials);
        Console.WriteLine("Drone stationary counterparts: contacts="+stationaryBodies+", kinematic="+kinematicContacts);
        Console.WriteLine("Drone contact-history coverage: total="+totalFrames+", contact-free="+contactFreeSteps);
        if(!pairCoverage.ContainsKey(1)||!pairCoverage.Keys.Any(p=>p>1)||pairCoverage.Values.Sum(v=>v.Steps)!=steps)
            throw new Exception("Persistent contact pair-count coverage is incomplete.");
        foreach(var entry in pairCoverage)
            Console.WriteLine("Drone cached pair-count diagnostic: pairs="+entry.Key+", steps="+entry.Value.Steps+
                ", velocity="+entry.Value.Velocity+", angular="+entry.Value.Angular+", root="+entry.Value.Root);
        Console.WriteLine("Drone single-pair worst velocity: "+singlePairWorstVelocity);
        Console.WriteLine("Drone full-dataset .0025 correlation diagnostic: velocity="+shorterVelocity+
            ", angular="+shorterAngular+", root="+shorterRoot+", improved="+shorterImproved+
            ", worse="+shorterWorse+", equivalent="+shorterEquivalent+" (policy unverified).");
        Console.WriteLine("Drone reuse-only .0025 distance diagnostic: velocity="+reuseOnlyVelocity+
            ", angular="+reuseOnlyAngular+", root="+reuseOnlyRoot+", improved="+reuseOnlyImproved+
            ", worse="+reuseOnlyWorse+", equivalent="+reuseOnlyEquivalent+" (distinct distances not source policy).");
        if(shorterImproved+shorterWorse+shorterEquivalent!=steps)
            throw new Exception("Correlation control did not cover every persistent-contact step.");
        return 7;
    }
    private static IEnumerable<int[]> Permutations(int[] values)
    {
        if(values.Length==0){yield return Array.Empty<int>();yield break;}
        foreach(int value in values)
        foreach(var tail in Permutations(values.Where(v=>v!=value).ToArray()))
            yield return new[]{value}.Concat(tail).ToArray();
    }
}
