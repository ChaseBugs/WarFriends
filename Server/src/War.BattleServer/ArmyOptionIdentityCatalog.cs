namespace War.BattleServer;

public sealed record ArmyOptionIdentity(int Index,string UnitId,int SpawnCount);

/// <summary>Runtime options extracted from MainScene and ArmyUpgrades.SPAWNS.</summary>
public static class ArmyOptionIdentityCatalog
{
    private static readonly IReadOnlyDictionary<int,ArmyOptionIdentity> Options = Build();
    private static IReadOnlyDictionary<int,ArmyOptionIdentity> Build()
    {
        var families=new (string UnitId,string Options)[]
        {
            ("ID_UNIT-ASSAULT","0:2,1:4"),("ID_UNIT-HELICOPTER","2:1"),
            ("ID_UNIT-HUMVEE","3:1"),("ID_UNIT-SNIPER","4:1,5:2,6:4"),
            ("ID_UNIT-ROCKETSOLDIER","7:1,8:2"),("ID_UNIT-DRONE","9:1,10:2"),
            ("ID_UNIT-SHOTGUNNER","11:1,12:2"),("ID_UNIT-GRENADIER","13:1,14:2"),
            ("ID_UNIT-PARATROOPER","15:1,16:2"),("ID_UNIT-SWAT","17:1,18:2"),
            ("ID_UNIT-TANK","19:1"),("ID_UNIT-MINIGUNNER","20:1,21:2"),
            ("ID_UNIT-ENGINEER","22:1,23:2"),("ID_UNIT-MACHINEGUNNER","24:1,25:2,26:3"),
            ("ID_UNIT-SCIFI","27:1,28:2"),("ID_UNIT-BUGGY","29:1"),
            ("ID_UNIT-ASSAULTHELI","30:1,31:2"),("ID_UNIT-TRANSPORTER","32:1"),
            ("ID_UNIT-FLAMETHROWER","33:1,34:2"),("ID_UNIT-COMMANDO","35:1,36:2"),
            ("ID_UNIT-GUNSLINGER","37:1,38:2,39:3"),("ID_UNIT-MORTAR","40:1,41:2,42:3"),
            ("ID_UNIT-WARPER","43:1,44:2,45:3"),("ID_UNIT-MECH","46:1,47:2")
        };
        var rows=new Dictionary<int,ArmyOptionIdentity>();
        foreach(var family in families)
            foreach(var encoded in family.Options.Split(','))
            {
                var parts=encoded.Split(':');
                int index=int.Parse(parts[0],System.Globalization.CultureInfo.InvariantCulture);
                int count=int.Parse(parts[1],System.Globalization.CultureInfo.InvariantCulture);
                if(!rows.TryAdd(index,new ArmyOptionIdentity(index,family.UnitId,count)))
                    throw new InvalidDataException("Duplicate recovered army option.");
            }
        if(rows.Count!=48 || Enumerable.Range(0,48).Any(index=>!rows.ContainsKey(index)))
            throw new InvalidDataException("Recovered army option map is incomplete.");
        return rows;
    }
    public static ArmyOptionIdentity Get(int index)
        =>Options.TryGetValue(index,out var row) ? row : throw new InvalidDataException("Unknown recovered army option.");
    public static IReadOnlyList<ArmyOptionIdentity> All=>Options.Values.OrderBy(row=>row.Index).ToArray();
}
