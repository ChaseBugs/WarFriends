using System.Numerics;

namespace War.BattleServer;

public sealed class SnapshotInterpolationBuffer
{
    private readonly int capacity;
    private readonly Queue<(ulong Tick,Vector3 Position)> snapshots=[];
    public SnapshotInterpolationBuffer(int capacity=32){if(capacity is <2 or >256)throw new InvalidDataException("Invalid snapshot capacity.");this.capacity=capacity;}
    public void Add(ulong tick,Vector3 position)
    {
        if(!PlayerHitbox.Finite(position))throw new InvalidDataException("Invalid snapshot position.");
        if(snapshots.Count>0)SnapshotTickPolicy.Validate(snapshots.Last().Tick,tick);
        snapshots.Enqueue((tick,position));while(snapshots.Count>capacity)snapshots.Dequeue();
    }
    public Vector3 Sample(ulong tick)
    {
        if(snapshots.Count==0)throw new InvalidOperationException("No snapshots available.");
        var rows=snapshots.ToArray();if(tick<=rows[0].Tick)return rows[0].Position;if(tick>=rows[^1].Tick)return rows[^1].Position;
        for(int i=1;i<rows.Length;i++)if(tick<=rows[i].Tick){var a=rows[i-1];var b=rows[i];float t=(float)(tick-a.Tick)/(b.Tick-a.Tick);return Vector3.Lerp(a.Position,b.Position,t);}
        return rows[^1].Position;
    }
}
