using War.BattleServer;
internal static class DroneAttackClockTests
{
    internal static int Run()
    {
        int count=0;void Check(bool ok,string name){if(!ok)throw new Exception(name);count++;}
        void Reject(Action action){try{action();}catch(InvalidDataException){count++;return;}throw new Exception("Invalid Drone attack clock accepted.");}
        var clock=new DroneAttackClock(2,3,5);
        Check(!clock.BeginAttempt(4,true)&&clock.Deadline==4,"strict initial spawn-plus-two deadline");
        Check(clock.BeginAttempt(4.1f,true),"first source target/batch attempt after deadline");
        Reject(()=>clock.BeginAttempt(4.1f,true));
        clock.CompleteAttempt(.5f);
        Check(clock.Deadline==8,"interval adds to prior deadline rather than current time");
        Check(!clock.BeginAttempt(8,true)&&clock.BeginAttempt(100,true),"late observation executes only one source attempt");
        clock.CompleteAttempt(1);
        Check(clock.Deadline==13,"late attempt does not fast-forward missed intervals");
        Check(clock.BeginAttempt(100,true),"next observation may still be overdue");clock.CompleteAttempt(0);
        Check(clock.Deadline==16,"source float range accepts both endpoints");
        Reject(()=>clock.CompleteAttempt(0));Reject(()=>clock.BeginAttempt(99,true));
        var disabled=new DroneAttackClock(0,0,0);
        Check(!disabled.BeginAttempt(3,false)&&disabled.BeginAttempt(4,true),"dead/remote gate retains deadline without advancing");
        Reject(()=>disabled.CompleteAttempt(float.NaN));
        Check(disabled.Deadline==2,"failed interval completion leaves prior deadline");
        disabled.CompleteAttempt(0);
        Check(disabled.BeginAttempt(4,true),"zero interval stays due on a later source observation");disabled.CompleteAttempt(1);
        Reject(()=>new DroneAttackClock(float.MaxValue,0,0));Reject(()=>new DroneAttackClock(0,5,3));
        return count;
    }
}
