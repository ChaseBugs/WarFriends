using System.Numerics;

namespace War.BattleServer;

internal sealed record RifleTriggerResult(bool Immediate,bool Scheduled);

// PlayerClickWeapon.Sh / delayed-shot Update branch. Weapon cadence, ammunition,
// angle eligibility and button/autofire gates are checked by the calling host.
internal sealed class RifleFirstShot
{
    private bool stopped=true, shootRight, waiting;
    private Vector3 target;
    private double deadline, clock;
    public bool Waiting => waiting;
    public void StopShooting() => stopped=true;
    public void SelectionChanged() => waiting=false;

    public RifleTriggerResult Trigger(double now,Vector3 position,bool right,bool idle,bool hiding,bool shooting,
        bool running,bool walking,double hidingWait,double uncoverLength,float firstShotWait)
    {
        Time(now);
        if (!PlayerHitbox.Finite(position) || !double.IsFinite(hidingWait) || hidingWait is < 0 or > 60 ||
            !double.IsFinite(uncoverLength) || uncoverLength is <= 0 or > 60 ||
            !float.IsFinite(firstShotWait) || firstShotWait is < 0 or > 60)
            throw new InvalidDataException("Invalid first-shot state.");
        clock=now;
        if (waiting) return new(false,false);
        bool schedule=false, immediate=false;
        double wait=firstShotWait;
        if (hiding || idle || (walking && stopped))
        {
            schedule=true; stopped=false;
            wait=hiding ? hidingWait : uncoverLength*.25;
            if (walking) wait=.05f;
        }
        else if (shooting || running) immediate=true;
        if (right!=shootRight)
        {
            shootRight=right; schedule=true; wait=uncoverLength*.25;
        }
        if (schedule) { target=position; deadline=now+wait; waiting=true; }
        // The source can fire immediately AND schedule on a side change. The
        // future weapon Fire call still rechecks its own cadence/ammo eligibility.
        return new(immediate,schedule);
    }
    public Vector3? Advance(double now,bool clicked)
    {
        Time(now); clock=now;
        if (clicked) { stopped=true; return null; }
        if (!waiting || now<=deadline) return null;
        waiting=false;
        return target;
    }
    private void Time(double now) { if (!double.IsFinite(now)||now<clock||now>86400) throw new InvalidDataException("Invalid first-shot clock."); }
}
