namespace War.BattleServer;

// Drone.OnInstancied/Update: transparency changes, targetability does not.
public sealed class DroneSpecialState
{
    private readonly Func<float> random;
    private readonly float special;
    private float nextInvisibleTime,invisibleLength,lastTime;
    public float SpawnTime { get; }
    public bool Enabled { get; }
    public bool IsImmortal { get; private set; }
    public bool Transparent=>IsImmortal;
    public DroneSpecialState(float spawnTime,bool enabled,float special,Func<float> random)
    {
        ValidateTime(spawnTime);
        // Normal/elite SPECIAL rows are zero; the source special lane is 1.5..3.9.
        if(!float.IsFinite(special)||special<0||special>3.9f||(!enabled&&special!=0))
            throw new InvalidDataException("Invalid source Drone special duration.");
        this.random=random??throw new ArgumentNullException(nameof(random));
        this.special=special;SpawnTime=lastTime=spawnTime;Enabled=enabled;
        nextInvisibleTime=Add(spawnTime,5+5*Next());
    }
    public bool Observe(float unpausedTime,bool gameRunning,bool alive)
    {
        ValidateTime(unpausedTime);
        if(unpausedTime<lastTime)throw new InvalidDataException("Drone special clock regressed.");
        if(Enabled&&gameRunning&&alive)
        {
            if(!IsImmortal&&unpausedTime>nextInvisibleTime)
            {
                float duration=special+Next();_=Add(nextInvisibleTime,duration);
                invisibleLength=duration;IsImmortal=true;lastTime=unpausedTime;return true;
            }
            if(IsImmortal&&unpausedTime>Add(nextInvisibleTime,invisibleLength))
            {
                float next=Add(unpausedTime,10-special+Next());
                nextInvisibleTime=next;IsImmortal=false;lastTime=unpausedTime;return true;
            }
        }
        lastTime=unpausedTime;return false;
    }
    private float Next()
    {
        float value=random();
        if(!float.IsFinite(value)||value<0||value>1)throw new InvalidDataException("Invalid Drone special random sample.");
        return value; // Unity's float Random.Range includes its upper endpoint.
    }
    private static void ValidateTime(float time)
    {if(!float.IsFinite(time)||time<0)throw new InvalidDataException("Invalid Drone unpaused time.");}
    private static float Add(float time,float duration)
    {
        float result=time+duration;
        if(!float.IsFinite(result)||result<time||(duration>0&&result==time))
            throw new InvalidDataException("Drone special deadline overflow or lost precision.");
        return result;
    }
}
