using System.Numerics;
namespace War.BattleServer;

// Initial anchors for one already-correlated patch, in solver contact order.
// Persistent anchors and patch correlation remain separate requirements.
internal static class ContactFrictionAnchors
{
    internal static Vector3[] Select(IReadOnlyList<DroneNormalPoint> contacts,float correlationDistance,float offsetThreshold)
    {
        ArgumentNullException.ThrowIfNull(contacts);
        if(contacts.Count>64||!float.IsFinite(correlationDistance)||correlationDistance<0||correlationDistance>1||
           !float.IsFinite(offsetThreshold)||offsetThreshold<0||offsetThreshold>1)
            throw new InvalidDataException("Invalid friction anchor selection authority.");
        var points=contacts.ToArray();
        foreach(var c in points)
            if(!PlayerHitbox.Finite(c.Point)||!float.IsFinite(c.Separation)||Math.Abs(c.Separation)>100)
                throw new InvalidDataException("Invalid friction contact point.");
        var selected=new List<Vector3>(2);float distance=0;
        foreach(var c in points)
        {
            if(c.Separation>=offsetThreshold)continue;
            if(selected.Count==0){selected.Add(c.Point);continue;}
            float d0=Vector3.DistanceSquared(c.Point,selected[0]);
            if(selected.Count==1)
            {
                if(d0>correlationDistance*correlationDistance){selected.Add(c.Point);distance=d0;}
                continue;
            }
            float d1=Vector3.DistanceSquared(c.Point,selected[1]);
            if(d0>d1){if(d0>distance){selected[1]=c.Point;distance=d0;}}
            else if(d1>distance){selected[0]=c.Point;distance=d1;}
        }
        return selected.ToArray();
    }
}
