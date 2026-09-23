using System.Numerics;
using War.BattleServer;

internal static class ShotgunPlannerTests
{
    internal static int Run()
    {
        int checks=0;
        void Check(bool ok,string label){if(!ok)throw new Exception(label);checks++;}
        void Reject(Action action){try{action();}catch(InvalidDataException){checks++;return;}throw new Exception("Invalid shotgun input accepted.");}
        var rule=new ShotgunRule(50,3,10,22.62f,101.8f,false,false);
        var from=Vector3.Zero;var aim=new Vector3(0,0,5);
        var targets=new[]
        {
            new ShotgunCollider("one-head","one",new(0,0,4.5f),true),
            new ShotgunCollider("one-body","one",new(0,0,5.5f),true),
            new ShotgunCollider("one-third","one",new(0,0,6),true),
            new ShotgunCollider("ally-head","ally",new(0,0,4),false),
            new ShotgunCollider("aim-center","other",aim,true),
            new ShotgunCollider("outside-cone","far",new(5,0,5),true)
        };
        var planned=ShotgunShotPlanner.Plan(rule,from,aim,targets);
        Check(planned.RealPellets.Count==3 && planned.RealPellets[0].Main &&
            planned.RealPellets[1].EntityId=="one-head" && planned.RealPellets[2].EntityId=="one-body",
            "main plus at most two real extras for one enemy object");
        Check(planned.FakePellets==2,"fake pellets fill four-minus-extra presentation count");
        Check(Math.Abs(planned.RealPellets[0].BaseDamage-(22.62f+(101.8f-22.62f)*.5f))<.0001f,
            "source distance damage interpolates min/max before impact");
        var only=ShotgunShotPlanner.Plan(rule with {OnlyMain=true},from,aim,targets);
        Check(only.RealPellets.Count==1 && only.FakePellets==4,"main-only shot has no extra damage pellets");
        var seven=Enumerable.Range(0,10).Select(i=>new ShotgunCollider("part"+i,"enemy"+i,new(0,0,4+i*.1f),true)).ToArray();
        var capped=ShotgunShotPlanner.Plan(rule,from,aim,seven);
        Check(capped.RealPellets.Count==8 && capped.FakePellets==0,
            "source stops after seventh successful extra pellet");
        var angled=new[] {new ShotgunCollider("angle","enemy",new(.5f,0,1),true)};
        Check(ShotgunShotPlanner.Plan(rule,from,new(0,0,1),angled).RealPellets.Count==1,
            "distance-weighted cone rejects a far-angle candidate");
        var highAim=new Vector3(0,10,5);
        var flatTarget=new[] {new ShotgunCollider("flat","enemy",new(0,0,4.5f),true)};
        var flattened=ShotgunShotPlanner.Plan(rule with {FlatY=true},from,highAim,flatTarget);
        var threeDimensional=ShotgunShotPlanner.Plan(rule,from,highAim,flatTarget);
        Check(flattened.RealPellets.Count==1 && !flattened.RealPellets[0].Main &&
            threeDimensional.RealPellets.Count==1 && threeDimensional.RealPellets[0].Main,
            "flatY changes only the cone axis, including the main pellet's steep aim");
        Reject(()=>ShotgunShotPlanner.Plan(rule with {Radius=0},from,aim,targets));
        Reject(()=>ShotgunShotPlanner.Plan(rule,from,from,targets));
        Reject(()=>ShotgunShotPlanner.Plan(rule,from,aim,[targets[0],targets[0]]));
        Reject(()=>ShotgunShotPlanner.Plan(rule,from,aim,[targets[0] with {Center=new(float.NaN,0,0)}]));
        return checks;
    }
}
