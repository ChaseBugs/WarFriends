using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace War.Shared
{

/// <summary>Backend-owned data required to construct the recovered non-Photon player view.</summary>
public sealed class BattlePlayerPresentation
{
    public string PlayerId { get; set; }
    public string DisplayName { get; set; }
    public int Level { get; set; }
    public int ArmyPower { get; set; }
    public int Skill { get; set; }
    public int LeagueMedals { get; set; }
    public int BeginnersLeague { get; set; }
    public string LeagueId { get; set; }
    public string Country { get; set; }
    public bool IsVip { get; set; }
    public IReadOnlyList<string> VisualIds { get; set; }
    public IReadOnlyList<BattleWeaponPresentation> Weapons { get; set; }
    public IReadOnlyList<BattleUnitPresentation> Units { get; set; }

    public BattlePlayerPresentation(string playerId, string displayName, int level, int armyPower, int skill,
        int leagueMedals, int beginnersLeague, string leagueId, string country, bool isVip,
        IReadOnlyList<string> visualIds, IReadOnlyList<BattleWeaponPresentation> weapons,
        IReadOnlyList<BattleUnitPresentation> units)
    {
        PlayerId=playerId; DisplayName=displayName; Level=level; ArmyPower=armyPower; Skill=skill;
        LeagueMedals=leagueMedals; BeginnersLeague=beginnersLeague; LeagueId=leagueId; Country=country;
        IsVip=isVip; VisualIds=visualIds; Weapons=weapons; Units=units;
    }

    public static BattlePlayerPresentation Validate(BattlePlayerPresentation value)
    {
        if(value==null || !Guid.TryParseExact(value.PlayerId,"N",out _) || value.PlayerId!=value.PlayerId.ToLowerInvariant())
            throw new InvalidDataException("Invalid battle presentation player identity.");
        Text(value.DisplayName,1,64,"display name");
        Text(value.Country,0,16,"country");
        Text(value.LeagueId,0,64,"league");
        if(value.LeagueId.Length!=0)
        {
            string tier=value.LeagueId.Split('-')[0];
            int parsed;
            if(!int.TryParse(tier,System.Globalization.NumberStyles.None,System.Globalization.CultureInfo.InvariantCulture,out parsed) || parsed<0 || parsed>16)
                throw new InvalidDataException("Invalid battle presentation league identity.");
        }
        if(value.Level<0 || value.Level>42 || value.ArmyPower<0 || value.Skill<0 || value.LeagueMedals<0 || value.BeginnersLeague<0)
            throw new InvalidDataException("Invalid battle presentation progression.");
        if(value.VisualIds==null || value.VisualIds.Count!=4)
            throw new InvalidDataException("Battle presentation requires the four recovered visual slots.");
        foreach(string id in value.VisualIds) Text(id,1,128,"visual identity");
        if(value.Weapons==null || value.Weapons.Count<1 || value.Weapons.Count>8 ||
           value.Weapons.Select(x=>x.Slot).Distinct().Count()!=value.Weapons.Count ||
           !value.Weapons.Select(x=>x.Slot).SequenceEqual(value.Weapons.Select(x=>x.Slot).OrderBy(x=>x)))
            throw new InvalidDataException("Invalid equipped weapon presentation.");
        foreach(var weapon in value.Weapons) BattleWeaponPresentation.Validate(weapon);
        if(value.Units==null || value.Units.Count>24 || value.Units.Select(x=>x.SourceId).Distinct(StringComparer.Ordinal).Count()!=value.Units.Count)
            throw new InvalidDataException("Invalid equipped unit presentation.");
        foreach(var unit in value.Units) BattleUnitPresentation.Validate(unit);
        return new BattlePlayerPresentation(value.PlayerId,value.DisplayName,value.Level,value.ArmyPower,value.Skill,
            value.LeagueMedals,value.BeginnersLeague,value.LeagueId,value.Country,value.IsVip,
            Array.AsReadOnly(value.VisualIds.ToArray()),Array.AsReadOnly(value.Weapons.Select(BattleWeaponPresentation.Validate).ToArray()),
            Array.AsReadOnly(value.Units.Select(BattleUnitPresentation.Validate).ToArray()));
    }

    internal static void Text(string value,int min,int max,string label)
    {
        if(value==null || value.Length<min || value.Length>max || value.Any(char.IsControl))
            throw new InvalidDataException("Invalid battle presentation "+label+".");
    }
}

public sealed class BattleWeaponPresentation
{
    public int Slot { get; set; }
    public int WeaponIndex { get; set; }
    public string SourceId { get; set; }
    public int UpgradeIndex { get; set; }
    public BattleWeaponPresentation(int slot,int weaponIndex,string sourceId,int upgradeIndex)
    { Slot=slot; WeaponIndex=weaponIndex; SourceId=sourceId; UpgradeIndex=upgradeIndex; }
    public static BattleWeaponPresentation Validate(BattleWeaponPresentation value)
    {
        if(value==null || value.Slot<0 || value.Slot>32 || value.WeaponIndex<0 || value.WeaponIndex>255 || value.UpgradeIndex<0 || value.UpgradeIndex>255)
            throw new InvalidDataException("Invalid equipped weapon indexes.");
        BattlePlayerPresentation.Text(value.SourceId,1,128,"weapon identity");
        return new BattleWeaponPresentation(value.Slot,value.WeaponIndex,value.SourceId,value.UpgradeIndex);
    }
}

public sealed class BattleUnitPresentation
{
    public string SourceId { get; set; }
    public int UpgradeIndex { get; set; }
    public int SpecialIndex { get; set; }
    public int EliteIndex { get; set; }
    public int Tier { get; set; }
    public BattleUnitPresentation(string sourceId,int upgradeIndex,int specialIndex,int eliteIndex,int tier)
    { SourceId=sourceId; UpgradeIndex=upgradeIndex; SpecialIndex=specialIndex; EliteIndex=eliteIndex; Tier=tier; }
    public static BattleUnitPresentation Validate(BattleUnitPresentation value)
    {
        if(value==null || value.UpgradeIndex<0 || value.UpgradeIndex>255 || value.SpecialIndex< -1 || value.SpecialIndex>255 ||
            value.EliteIndex< -1 || value.EliteIndex>255 || value.Tier<0 || value.Tier>16)
            throw new InvalidDataException("Invalid equipped unit indexes.");
        BattlePlayerPresentation.Text(value.SourceId,1,128,"unit identity");
        return new BattleUnitPresentation(value.SourceId,value.UpgradeIndex,value.SpecialIndex,value.EliteIndex,value.Tier);
    }
}
}

