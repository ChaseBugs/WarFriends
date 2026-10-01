namespace War.BattleServer;

// Recovered TurretWeaponBasic.PickTarget for the normal Helicopter prefab:
// decoy first (without PickRandom visibility), Rusher primary, then ordered
// Defender/Shooter/Rusher secondary types, finally the whole opponent registry.
// The caller supplies the source sight and cone test for PickRandom's two passes.
internal static class HelicopterTurretTargetPolicy
{
    internal static DroneTargetCandidate? Select(int fraction,
        IReadOnlyList<DroneTargetCandidate> registry,
        Func<DroneTargetCandidate,bool> visibleInCone,Func<int,int> randomIndex)
    {
        if(fraction is not (1 or 2)||registry==null||registry.Count>1000||
           visibleInCone==null||randomIndex==null)
            throw new InvalidDataException("Invalid Helicopter turret target registry.");
        var ids=new HashSet<string>(StringComparer.Ordinal);
        foreach(var row in registry)
            if(row==null||string.IsNullOrEmpty(row.Id)||row.Id.Length>100||
               row.Id.Any(char.IsControl)||!ids.Add(row.Id)||row.Fraction is not (1 or 2)||
               row.UnitType is <0 or >3||!PlayerHitbox.Finite(row.Position))
                throw new InvalidDataException("Invalid Helicopter turret target identity.");
        var opponents=registry.Where(x=>x.Fraction!=fraction&&x.Alive&&x.Visible).ToArray();
        DroneTargetCandidate? Pick(DroneTargetCandidate[] rows)
        {
            if(rows.Length==0)return null;
            int index=randomIndex(rows.Length);
            if(index<0||index>=rows.Length)
                throw new InvalidDataException("Helicopter turret random index is outside the source list.");
            return rows[index];
        }
        var target=Pick(opponents.Where(x=>x.IsDecoy).ToArray());
        if(target!=null)return target;
        target=Pick(opponents.Where(x=>x.UnitType==3&&visibleInCone(x)).ToArray());
        if(target!=null)return target;
        var secondary=new List<DroneTargetCandidate>();
        foreach(int type in new[]{0,2,3})
            secondary.AddRange(opponents.Where(x=>x.UnitType==type&&visibleInCone(x)));
        target=Pick(secondary.ToArray());
        return target??Pick(opponents.Where(visibleInCone).ToArray());
    }
}
