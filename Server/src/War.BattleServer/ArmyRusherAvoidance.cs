using System.Numerics;

namespace War.BattleServer;

/// <summary>Deterministic radius gate for allied covered Rushers sharing spawn/corridor space.</summary>
internal static class ArmyRusherAvoidance
{
    internal static bool CanAdvance(Vector3 before,Vector3 proposed,
        IEnumerable<Vector3> others,float agentRadius)
    {
        ArgumentNullException.ThrowIfNull(others);
        if(!PlayerHitbox.Finite(before) || !PlayerHitbox.Finite(proposed) ||
           !float.IsFinite(agentRadius) || agentRadius<=0 || agentRadius>1)
            throw new InvalidDataException("Invalid Rusher avoidance input.");
        float diameter=2*agentRadius;
        foreach(var other in others)
        {
            if(!PlayerHitbox.Finite(other))
                throw new InvalidDataException("Invalid opposing Rusher position.");
            var neighbor=new Vector2(other.X,other.Z);
            float prior=Vector2.Distance(new(before.X,before.Z),neighbor);
            float next=Vector2.Distance(new(proposed.X,proposed.Z),neighbor);
            if(next<diameter && !(prior<diameter && next>prior+1e-5f))
                return false;
        }
        return true;
    }
}
