using System.Numerics;

namespace War.BattleServer;

/// <summary>Recovered EnemyController.GetNextPoint authority for Warper edge hops.</summary>
public static class ArmyWarperDestinationPolicy
{
    public static Vector3 Select(ArmyWarperRelocation policy,ArmyWarperField field,bool side,
        Func<float> random,Func<Vector3,float,Vector3?> sample)
    {
        ArgumentNullException.ThrowIfNull(policy);ArgumentNullException.ThrowIfNull(field);
        ArgumentNullException.ThrowIfNull(random);ArgumentNullException.ThrowIfNull(sample);
        float xRange=field.Maximum.X-field.Minimum.X-2*policy.EdgeInsetX;
        if(!float.IsFinite(xRange)||xRange<=0)
            throw new InvalidDataException("Warper field is too narrow for its recovered inset.");
        float x=field.Minimum.X+policy.EdgeInsetX+xRange*Next(random);
        float shrink=policy.EdgeShrinkZMin+
            (policy.EdgeShrinkZMax-policy.EdgeShrinkZMin)*Next(random);
        float z=side?field.Minimum.Z+shrink/2:field.Maximum.Z-shrink/2;
        var requested=new Vector3(x,field.Minimum.Y,z);
        var sampled=sample(requested,policy.SampleRadius)??
            throw new InvalidDataException("Warper edge destination has no source-radius NavMesh sample.");
        if(!PlayerHitbox.Finite(sampled)||Vector3.Distance(requested,sampled)>policy.SampleRadius+.001f)
            throw new InvalidDataException("Warper NavMesh sample is outside its recovered radius.");
        return sampled;
    }

    private static float Next(Func<float> random)
    {
        float value=random();
        if(!float.IsFinite(value)||value<0||value>=1)
            throw new InvalidDataException("Warper random source returned an invalid value.");
        return value;
    }
}
