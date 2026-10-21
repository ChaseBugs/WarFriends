namespace War.BattleServer;

// Drone.OnInstancied/Update: target selection and batch setup precede interval draw.
public sealed class DroneAttackClock
{
    private readonly float minimum,maximum;
    private float deadline,lastTime;
    private bool pending;
    public float Deadline=>deadline;
    public DroneAttackClock(float spawnTime,float minimum,float maximum)
    {
        if(!ValidTime(spawnTime)||!float.IsFinite(minimum)||!float.IsFinite(maximum)||minimum<0||
            maximum<minimum||maximum>60)throw new InvalidDataException("Invalid Drone attack clock authority.");
        this.minimum=minimum;this.maximum=maximum;lastTime=spawnTime;deadline=Add(spawnTime,2);
    }
    public bool BeginAttempt(float time,bool ownerAlive)
    {
        if(!ValidTime(time)||time<lastTime||pending)throw new InvalidDataException("Invalid Drone attack observation.");
        lastTime=time;
        if(!ownerAlive||time<=deadline)return false;
        pending=true;return true;
    }
    // Call after PickTarget/StartShooting, including a no-target/no-shot attempt.
    // Do not draw the interval before batch masks/target assertions consume randomness.
    public void CompleteAttempt(float randomSample)
    {
        if(!pending||!float.IsFinite(randomSample)||randomSample<0||randomSample>1)
            throw new InvalidDataException("Invalid Drone attack completion.");
        float interval=minimum+(maximum-minimum)*randomSample;
        float next=Add(deadline,interval);
        deadline=next;pending=false;
    }
    private static bool ValidTime(float time)=>float.IsFinite(time)&&time>=0;
    private static float Add(float time,float duration)
    {
        float result=time+duration;
        if(!float.IsFinite(result)||result<time||(duration>0&&result==time))
            throw new InvalidDataException("Drone attack deadline overflow or lost precision.");
        return result;
    }
}
