using System.Numerics;
namespace War.BattleServer;

public sealed record DroneBatchShot(Vector3 Target,bool IsFake,int Index,int BatchSize,bool EndsBatch);

// BatchedWeapon setup/Update. Actual gun, ammo and collision remain host transitions.
public sealed class DroneBatchState
{
    private uint mask;
    private int size,index;
    private Vector3 target;
    private readonly Func<float> random;
    public bool Shooting { get; private set; }
    public DroneBatchState(Func<float> random){this.random=random??throw new ArgumentNullException(nameof(random));}
    public void Replace(Vector3 target,int batchSize,float realProbability)
    {
        if(!Finite(target)||batchSize is <0 or >32||!float.IsFinite(realProbability)||realProbability<0||realProbability>1)
            throw new InvalidDataException("Invalid Drone batch authority.");
        uint next=0;
        for(int i=0;i<batchSize;i++)if(Next()<realProbability)next|=1u<<i;
        this.target=target;size=batchSize;mask=next;index=0;Shooting=true;
    }
    public DroneBatchShot? Advance(Vector3 origin,bool willShoot,float fakeDispersion=1)
    {
        if(!Finite(origin)||!float.IsFinite(fakeDispersion)||fakeDispersion<0||fakeDispersion>100)
            throw new InvalidDataException("Invalid Drone fake-shot authority.");
        if(!Shooting||!willShoot)return null;
        bool fake=(mask&(1u<<index))==0;Vector3 position=target;
        if(fake)
        {
            Vector3 axis=Vector3.Cross(origin-target,Vector3.UnitY);float length=axis.Length();
            if(!float.IsFinite(length))throw new InvalidDataException("Drone fake-shot direction overflow.");
            axis=length>1e-5f?axis/length:Vector3.Zero;
            axis*=(.3f+.2f*Next())*fakeDispersion;
            if(Next()<.5f)axis=-axis;
            position+=axis+new Vector3(0,.3f,0)*fakeDispersion;
        }
        if(!Finite(position))throw new InvalidDataException("Drone fake-shot target overflow.");
        bool ends=index+1>=size;var shot=new DroneBatchShot(position,fake,index,size,ends);
        if(ends){index=0;Shooting=false;}else index++;
        return shot;
    }
    public void Reset(){Shooting=false;}
    private float Next()
    {float value=random();if(!float.IsFinite(value)||value<0||value>1)throw new InvalidDataException("Invalid Drone batch sample.");return value;}
    private static bool Finite(Vector3 v)=>float.IsFinite(v.X)&&float.IsFinite(v.Y)&&float.IsFinite(v.Z);
}
