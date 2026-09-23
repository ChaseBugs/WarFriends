using War.BattleServer;
using System.Numerics;
using System.Text.Json;

internal static class RifleCoverTests
{
    internal static int RunUnityQueue(string path)
    {
        using var doc=JsonDocument.Parse(File.ReadAllBytes(path));
        int count=0;
        foreach (var frame in doc.RootElement.GetProperty("frames").EnumerateArray())
        {
            double time=frame.GetProperty("seconds").GetDouble();
            var blend=QueuedCrossFade.Sample(time,.5);
            var incoming=frame.GetProperty("states").EnumerateArray().Single(s=>s.GetProperty("name").GetString()=="idle - Queued Clone");
            if (Math.Abs(blend.IncomingWeight-incoming.GetProperty("weight").GetSingle())>.0002 ||
                Math.Abs(blend.IncomingSeconds-incoming.GetProperty("time").GetSingle())>.0002)
                throw new Exception("Unity queued idle clock/weight mismatch.");
            count+=2;
            double x=(1-blend.IncomingWeight)*Math.Min(time/.5,1)+blend.IncomingWeight*10;
            if (Math.Abs(x-frame.GetProperty("x").GetSingle())>.002) throw new Exception("Unity queued linear blend mismatch.");
            count++;
        }
        return count;
    }
    internal static int Run(PlayerPoseCatalog poses)
    {
        int count=0;
        void Check(bool ok,string name) { if (!ok) throw new Exception(name); count++; }
        var timeline=new RifleCoverTimeline(poses);
        foreach(var family in new[] {(7,"_shotgun"),(9,"_qbz"),(13,"_qbz2"),(15,"_shotgun")})
        {
            var variant=new RifleCoverTimeline(poses,family.Item1);
            Check(variant.Shot(true)!.To.Name=="player_look_right"+family.Item2,"source animation family right cover mapping");
            var leftVariant=new RifleCoverTimeline(poses,family.Item1);
            Check(leftVariant.Shot(false)!.To.Name=="player_look_left"+family.Item2,"source animation family left cover mapping");
            variant.Advance(.2);
            Check(variant.Selection.Name=="player_fire_right"+family.Item2,"source animation family firing transition");
        }
        try {_=new RifleCoverTimeline(poses,8);throw new Exception("Unsupported weapon family accepted.");}
        catch(InvalidDataException){count++;}
        Check(timeline.Selection.Name=="idle" && timeline.Selection.Loop,"initial rifle idle");
        var transition=timeline.Shot(true)!;
        Check(transition.To.Name=="player_look_right3" && transition.To.Speed==4 && transition.FadeSeconds==.02f,"right side mapping and crossfade");
        timeline.Advance(.05);
        double before=timeline.Selection.Seconds;
        Check(timeline.Shot(true)==null && timeline.Selection.Seconds==before,"repeat uncover extends deadline without restarting clip");
        timeline.Advance(.2);
        Check(timeline.Phase==RifleCoverPhase.Firing && timeline.Selection.Seconds>0,"queued firing preserves leftover frame time");
        Check(timeline.Shot(true)!.FadeSeconds==0 && timeline.Selection.Seconds==0,"repeated fire restarts clip");
        double deadline=.2+.4f;
        Check(timeline.Advance(deadline)==null && timeline.Phase==RifleCoverPhase.Firing,"strict hide deadline");
        Check(timeline.Advance(deadline+.001)!.To.Name=="player_right_coverBack3" && timeline.Selection.Seconds==0,"hide begins on observed expiry frame");
        timeline.Advance(deadline+.101);
        Check(timeline.Layers.Count==2 && timeline.Layers[1].Weight==0,"idle queue starts with zero weight before fade window");
        double normalized=timeline.Selection.Seconds/poses.Duration("player_right_coverBack3");
        Check(Math.Abs(timeline.HidingWait-poses.Duration("player_look_right3")/4*normalized)<.000001,"hiding first-shot wait uses uncover speed");
        var reverse=timeline.Shot(true)!;
        Check(reverse.FadeSeconds==0 && Math.Abs(reverse.To.Seconds/poses.Duration(reverse.To.Name)-(1-normalized))<.000001,"reverse hide into uncover at complementary normalized time");
        Check(timeline.Shot(false)!.FadeSeconds==.02f && timeline.Selection.Name=="player_look_left3" && timeline.Selection.Seconds==0,"side switch starts new uncover");
        timeline.Advance(2);
        Check(timeline.Phase==RifleCoverPhase.Hiding,"late update starts queued hiding");
        timeline.Advance(3);
        Check(timeline.Phase==RifleCoverPhase.Idle && timeline.Selection.Seconds<poses.Duration("idle"),"hide completes to looping idle");
        try { timeline.Advance(2); throw new Exception("backwards cover clock accepted"); } catch (InvalidDataException) { count++; }
        try { timeline.Advance(double.NaN); throw new Exception("NaN cover clock accepted"); } catch (InvalidDataException) { count++; }
        var shot=new RifleFirstShot(); var target=new Vector3(1,2,3);
        var initial=shot.Trigger(0,target,false,true,false,false,false,false,0,.5,0);
        Check(!initial.Immediate && initial.Scheduled,"idle first shot schedules uncover");
        Check(shot.Advance(.125,false)==null,"strict first-shot deadline");
        Check(shot.Advance(.126,true)==null && shot.Waiting,"clicked state defers pending shot");
        Check(shot.Advance(.127,false)==target && !shot.Waiting,"deferred shot retains original aim position");
        Check(shot.Advance(.128,false)==null,"first shot emitted once");
        var switched=shot.Trigger(.2,target,true,false,false,true,false,false,0,.5,0);
        Check(switched.Immediate && switched.Scheduled,"source side switch can fire now and schedule another attempt");
        shot.SelectionChanged(); Check(shot.Advance(1,false)==null,"weapon selection cancels delayed shot");
        shot.StopShooting();
        var walk=shot.Trigger(1,target,true,false,false,false,true,true,0,.5,0);
        Check(walk.Scheduled && !walk.Immediate,"walking after stop schedules first shot");
        Check(shot.Advance(1+.05f,false)==null && shot.Advance(1.051,false)==target,"walking wait is source fifty milliseconds");
        var pendingMove=new RifleFirstShot();
        Check(pendingMove.Trigger(0,target,false,true,false,false,false,false,0,.5,0).Scheduled,
            "source cover shot scheduled before clicked movement");
        pendingMove.StopShooting();
        Check(pendingMove.Waiting && pendingMove.Advance(.126,false)==target,
            "clicked/reset shooting state retains pending first-shot target");
        return count;
    }
}
