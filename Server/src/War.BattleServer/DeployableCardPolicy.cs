using System.Numerics;

namespace War.BattleServer;

public readonly record struct DeployablePlacement(int SlotId,Vector3 Position);

/// <summary>Authoritative placement limits extracted from HeavyTurret and Landmine cards.</summary>
public static class DeployableCardPolicy
{
    public static IReadOnlyList<DeployablePlacement> SelectLandmineTargets(
        string cardId,int ownerFraction,IReadOnlyList<DeployablePlacement> opposingHidingSlots,
        Func<int,int> choose)
    {
        if(cardId!="LandMine"||ownerFraction<0||opposingHidingSlots==null||choose==null)
            throw new InvalidDataException("Invalid landmine placement request.");
        var candidates=opposingHidingSlots.Where(x=>x.SlotId>0&&PlayerHitbox.Finite(x.Position)).ToList();
        int count=Math.Min(3,candidates.Count);var selected=new List<DeployablePlacement>(count);
        while(selected.Count<count)
        {
            int index=choose(candidates.Count);
            if(index<0||index>=candidates.Count)throw new InvalidDataException("Invalid deployable selection.");
            selected.Add(candidates[index]);candidates.RemoveAt(index);
        }
        return selected.AsReadOnly();
    }

    public static bool CanSpawnHeavyTurret(string cardId,Vector3 position,int ownerFraction)
        =>cardId=="HeavyTurret"&&ownerFraction>=0&&PlayerHitbox.Finite(position);
}
