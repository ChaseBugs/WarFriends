using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using War.Shared;

namespace War.BattleServer;

// Operator/allocator input, NEVER a client command. Live modes remain unscored
// until full gameplay and durable outcome authority exist.
public sealed record WeaponManifest(string SourceId, int ClipSize, int ReserveAmmo, double CadenceSeconds, double ReloadSeconds);
public sealed record WeaponSlotManifest(int Slot,int WeaponIndex,WeaponManifest Weapon,int WeaponUpgrade);
public sealed record ArmyHealthFactors(float PerkCoefficient,float UpgradeScale);
public sealed record ParticipantManifest(string PlayerId, WeaponManifest Weapon, int Fraction = 0, int StartCover = -1, float MovementSpeed = 0, PlayerCombatManifest? Combat = null,
    [property:JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)] int? WeaponUpgrade=null,
    [property:JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)] int? ShieldLevel=null,
    [property:JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)] int? PlayerLevel=null)
{
    // Trusted allocator projection of equipped units; never supplied by a UDP command.
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public string[]? EquippedArmyUnitIds { get; init; }
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public string[]? NewArmyUnitIds { get; init; }
    // Same order as EquippedArmyUnitIds; trusted allocator normal-upgrade indexes.
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public int[]? ArmyNormalUpgradeIndexes { get; init; }
    // -1 means the lane is not bought. Both optional lane arrays are a single projection.
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public int[]? ArmySpecialUpgradeIndexes { get; init; }
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public int[]? ArmyEliteUpgradeIndexes { get; init; }
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public ArmyHealthFactors[]? ArmyHealthFactors { get; init; }
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public float[]? ArmyDamageScales { get; init; }
    // Trusted perk.speedCoef for each equipped family, after Backend entitlement resolution.
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public float[]? ArmySpeedCoefficients { get; init; }
    // Trusted perk.accuracyCoef applied after source upgrade rows compose.
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public float[]? ArmyAccuracyCoefficients { get; init; }
    // Source-ordered durable equipped slots. Weapon remains the first active
    // slot for compatibility with older signed manifests.
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public WeaponSlotManifest[]? WeaponSlots { get; init; }
}
public sealed record MatchManifest(string MatchId, string ServerId, string MapId, string MapRevision,
    string CatalogRevision, string Mode, int AdmissionSeconds, int DurationSeconds,
    int IdleSeconds, ParticipantManifest[] Players)
{
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public string? SceneMasterPlayerId { get; init; }
    // Optional Backend-owned selection projection, consumed before admission.
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public BattleAllocationProjection[]? Allocations { get; init; }
    // Backend-owned recovered profile/loadout view; used by Client presentation, never combat authority.
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public BattlePlayerPresentation[]? Presentations { get; init; }
    public const int TickRate = 30;
    public const string PrototypeMode = "unscored-weapon-prototype";
    public const string RifleCombatMode = "unscored-rifle-combat";
    public const string ShotgunCombatMode = "unscored-shotgun-combat";
    public const string SmgCombatMode = "unscored-smg-combat";
    public const string MixedCombatMode = "unscored-mixed-combat";
    public const string PistolCombatMode = "unscored-pistol-combat";
    public const string LmgCombatMode = "unscored-lmg-combat";
    public const string MinigunCombatMode = "unscored-minigun-combat";
    public const string SniperCombatMode = "unscored-sniper-combat";
    public const string BazookaCombatMode = "unscored-bazooka-combat";
    public const string GrenadeCombatMode = "unscored-grenade-combat";
    private static readonly JsonSerializerOptions Json = new() { UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow };

    public static MatchManifest Read(string path)
    {
        using var stream = File.OpenRead(path);
        if (stream.Length is < 2 or > 65536) throw new InvalidDataException("Match manifest must be 2..65536 bytes.");
        return Validate(JsonSerializer.Deserialize<MatchManifest>(stream, Json) ?? throw new InvalidDataException("Null manifest."));
    }

    public static MatchManifest Parse(ReadOnlySpan<byte> bytes)
    {
        if(bytes.Length is <2 or >65536)throw new InvalidDataException("Match manifest must be 2..65536 bytes.");
        try
        {
            return Validate(JsonSerializer.Deserialize<MatchManifest>(bytes,Json) ??
                throw new InvalidDataException("Null match manifest."));
        }
        catch(JsonException e){throw new InvalidDataException("Malformed match manifest.",e);}
    }

    public static MatchManifest Validate(MatchManifest m)
    {
        static bool Id(string? x) => x != null && Regex.IsMatch(x, @"\A[a-zA-Z0-9_-]{1,64}\z");
        static bool WeaponId(string? x) => Id(x) || (x != null && Regex.IsMatch(x, @"\AGoogle2u\.[A-Za-z0-9_]{1,55}\z"));
        static bool Hash(string? x) => x != null && Regex.IsMatch(x, @"\A[0-9a-f]{64}\z");
        if (!Id(m.MatchId) || !Id(m.ServerId) || !Id(m.MapId) || !Hash(m.MapRevision) || !Hash(m.CatalogRevision) ||
            !IsSupportedMode(m.Mode) || m.AdmissionSeconds is < 5 or > 120 || m.DurationSeconds is < 5 or > 1800 ||
            m.IdleSeconds is < 2 or > 120 || m.Players == null || m.Players.Length != 2)
            throw new InvalidDataException("Invalid/unsupported match manifest.");
        var ids = new HashSet<string>(StringComparer.Ordinal);
        foreach (var p in m.Players)
        {
            if (p == null || !Guid.TryParseExact(p.PlayerId, "N", out _) || p.PlayerId != p.PlayerId.ToLowerInvariant() || !ids.Add(p.PlayerId))
                throw new InvalidDataException("Exactly two distinct canonical player IDs are required.");
            var w = p.Weapon;
            if (p.WeaponUpgrade is < 0 or > 255) throw new InvalidDataException("Invalid recovered weapon upgrade index.");
            if(p.ShieldLevel is <0 or >43)throw new InvalidDataException("Invalid recovered zero-based shield rank.");
            if(p.PlayerLevel is <0 or >42)throw new InvalidDataException("Invalid recovered zero-based player level.");
            if(p.EquippedArmyUnitIds is { } units &&
               (units.Length is < 1 or > 24 || units.Any(x=>x==null ||
                   !Regex.IsMatch(x,@"\AID_UNIT-[A-Z0-9-]{1,50}\z")) ||
                units.Distinct(StringComparer.Ordinal).Count()!=units.Length))
                throw new InvalidDataException("Invalid trusted equipped army set.");
            if(p.NewArmyUnitIds is { } newUnits &&
               (p.EquippedArmyUnitIds==null || newUnits.Length>p.EquippedArmyUnitIds.Length ||
                newUnits.Any(x=>x==null || !p.EquippedArmyUnitIds.Contains(x,StringComparer.Ordinal)) ||
                newUnits.Distinct(StringComparer.Ordinal).Count()!=newUnits.Length))
                throw new InvalidDataException("New army identities must be a trusted equipped subset.");
            if(p.ArmyNormalUpgradeIndexes is { } armyStages &&
               (p.EquippedArmyUnitIds==null || armyStages.Length!=p.EquippedArmyUnitIds.Length ||
                armyStages.Any(x=>x<0 || x>255)))
                throw new InvalidDataException("Army upgrade stages must align with the trusted equipped set.");
            if((p.ArmySpecialUpgradeIndexes!=null || p.ArmyEliteUpgradeIndexes!=null) &&
               (p.ArmyNormalUpgradeIndexes==null || p.ArmySpecialUpgradeIndexes==null ||
                p.ArmyEliteUpgradeIndexes==null ||
                p.ArmySpecialUpgradeIndexes.Length!=p.ArmyNormalUpgradeIndexes.Length ||
                p.ArmyEliteUpgradeIndexes.Length!=p.ArmyNormalUpgradeIndexes.Length ||
                p.ArmySpecialUpgradeIndexes.Any(x=>x< -1 || x>255) ||
                p.ArmyEliteUpgradeIndexes.Any(x=>x< -1 || x>255)))
                throw new InvalidDataException("Army special/elite lanes must align with normal stages.");
            if(p.ArmyHealthFactors is { } healthFactors &&
               (p.ArmyNormalUpgradeIndexes==null || healthFactors.Length!=p.ArmyNormalUpgradeIndexes.Length ||
                healthFactors.Any(x=>x==null || !float.IsFinite(x.PerkCoefficient) ||
                    x.PerkCoefficient<=0 || x.PerkCoefficient>100 ||
                    !float.IsFinite(x.UpgradeScale) || x.UpgradeScale<=0 || x.UpgradeScale>100)))
                throw new InvalidDataException("Army health factors must align with trusted upgrade stages.");
            if(p.ArmyDamageScales is { } damageScales &&
               (p.ArmyNormalUpgradeIndexes==null || damageScales.Length!=p.ArmyNormalUpgradeIndexes.Length ||
                damageScales.Any(x=>!float.IsFinite(x) || x<=0 || x>100)))
                throw new InvalidDataException("Army damage scales must align with trusted upgrade stages.");
            if(p.ArmySpeedCoefficients is { } speedCoefficients &&
               (p.ArmyNormalUpgradeIndexes==null || speedCoefficients.Length!=p.ArmyNormalUpgradeIndexes.Length ||
                speedCoefficients.Any(x=>!float.IsFinite(x) || x<=0 || x>100)))
                throw new InvalidDataException("Army perk speed coefficients must align with trusted upgrade stages.");
            if(p.ArmyAccuracyCoefficients is { } accuracyCoefficients &&
               (p.ArmyNormalUpgradeIndexes==null || accuracyCoefficients.Length!=p.ArmyNormalUpgradeIndexes.Length ||
                accuracyCoefficients.Any(x=>!float.IsFinite(x) || x<=0 || x>10)))
                throw new InvalidDataException("Army perk accuracy coefficients must align with trusted upgrade stages.");
            if (p.Combat != null)
            {
                PlayerDamage.Validate(p.Combat);
                if (p.Fraction is not (1 or 2)) throw new InvalidDataException("Combat requires a source fraction.");
            }
            if (p.Fraction is < 0 or > 2 || p.StartCover is < -1 or > 7 || !float.IsFinite(p.MovementSpeed) || p.MovementSpeed is < 0 or > 20)
                throw new InvalidDataException("Invalid movement manifest.");
            if (w == null || !WeaponId(w.SourceId) || w.ClipSize is < 1 or > 1000 || w.ReserveAmmo < 0 ||
                !double.IsFinite(w.CadenceSeconds) || w.CadenceSeconds is < 0.01 or > 60 ||
                !double.IsFinite(w.ReloadSeconds) || w.ReloadSeconds is < 0.01 or > 120)
                throw new InvalidDataException("Invalid basic reloadable weapon definition.");
            if(p.WeaponSlots is { } weaponSlots)
            {
                if(weaponSlots.Length is <1 or >8 || weaponSlots.Any(x=>x==null || x.Slot is <0 or >32 ||
                    x.WeaponIndex is <0 or >255 || x.WeaponUpgrade is <0 or >255 || x.Weapon==null) ||
                   weaponSlots.Select(x=>x.Slot).Distinct().Count()!=weaponSlots.Length ||
                   weaponSlots.Select(x=>x.WeaponIndex).Distinct().Count()!=weaponSlots.Length ||
                   !weaponSlots.Select(x=>x.Slot).SequenceEqual(weaponSlots.Select(x=>x.Slot).OrderBy(x=>x)))
                    throw new InvalidDataException("Invalid equipped weapon slot authority.");
                foreach(var slot in weaponSlots)
                    if(!WeaponId(slot.Weapon.SourceId) || slot.Weapon.ClipSize is <1 or >1000 || slot.Weapon.ReserveAmmo<0 ||
                       !double.IsFinite(slot.Weapon.CadenceSeconds) || slot.Weapon.CadenceSeconds is <0.01 or >60 ||
                       !double.IsFinite(slot.Weapon.ReloadSeconds) || slot.Weapon.ReloadSeconds is <0.01 or >120)
                        throw new InvalidDataException("Invalid equipped weapon slot definition.");
                var first=weaponSlots[0];
                if(first.Weapon!=p.Weapon ||
                   (p.WeaponUpgrade.HasValue && first.WeaponUpgrade!=p.WeaponUpgrade.Value))
                    throw new InvalidDataException("First equipped weapon slot must match legacy combat authority.");
            }
        }
        if (m.Players.Any(p => p.Combat != null) &&
            (m.Players.Any(p => p.Combat == null) || m.Players[0].Fraction == m.Players[1].Fraction))
            throw new InvalidDataException("A combat duel requires two defined opposing players.");
        if(m.Players.Any(p=>p.ShieldLevel.HasValue) &&
            (m.Mode==PrototypeMode || m.Players.Any(p=>!p.ShieldLevel.HasValue || p.Combat==null)))
            throw new InvalidDataException("Shield authority requires both live participants and ranks.");
        if(m.Players.Any(p=>p.EquippedArmyUnitIds!=null) &&
           (m.Mode==PrototypeMode || m.Players.Any(p=>p.EquippedArmyUnitIds==null || p.Combat==null)))
            throw new InvalidDataException("Army authority requires both live combat participants and equipped sets.");
        if(m.Players.Any(p=>p.ArmyNormalUpgradeIndexes!=null) &&
           m.Players.Any(p=>p.ArmyNormalUpgradeIndexes==null))
            throw new InvalidDataException("Army upgrade projection requires both live participants.");
        if(m.Players.Any(p=>p.ArmySpecialUpgradeIndexes!=null || p.ArmyEliteUpgradeIndexes!=null) &&
           m.Players.Any(p=>p.ArmySpecialUpgradeIndexes==null || p.ArmyEliteUpgradeIndexes==null))
            throw new InvalidDataException("Army special/elite projection requires both live participants.");
        if(m.Players.Any(p=>p.ArmyHealthFactors!=null) && m.Players.Any(p=>p.ArmyHealthFactors==null))
            throw new InvalidDataException("Army health factors require both live participants.");
        if(m.Players.Any(p=>p.ArmyDamageScales!=null) && m.Players.Any(p=>p.ArmyDamageScales==null))
            throw new InvalidDataException("Army damage scales require both live participants.");
        if(m.Players.Any(p=>p.ArmySpeedCoefficients!=null) && m.Players.Any(p=>p.ArmySpeedCoefficients==null))
            throw new InvalidDataException("Army perk speed coefficients require both live participants.");
        if(m.Players.Any(p=>p.ArmyAccuracyCoefficients!=null) && m.Players.Any(p=>p.ArmyAccuracyCoefficients==null))
            throw new InvalidDataException("Army perk accuracy coefficients require both live participants.");
        if(m.SceneMasterPlayerId!=null || m.Players.Any(p=>p.PlayerLevel.HasValue))
        {
            if(m.Mode==PrototypeMode || m.SceneMasterPlayerId==null ||
               !ids.Contains(m.SceneMasterPlayerId) || m.Players.Any(p=>!p.PlayerLevel.HasValue || p.Combat==null))
                throw new InvalidDataException("Scene-master barrel authority requires both signed levels and a live roster owner.");
        }
        if (m.Allocations is { } allocations)
        {
            if (allocations.Length != m.Players.Length || allocations.Select(x => x.PlayerId).Distinct(StringComparer.Ordinal).Count() != allocations.Length)
                throw new InvalidDataException("Allocation projection must contain each participant exactly once.");
            foreach (var allocation in allocations) BattleAllocationProjection.Validate(allocation);
            if (allocations.Any(x => !ids.Contains(x.PlayerId))) throw new InvalidDataException("Allocation player is not in the manifest.");
        }
        if(m.Presentations is { } presentations)
        {
            if(presentations.Length!=m.Players.Length || presentations.Select(x=>x.PlayerId).Distinct(StringComparer.Ordinal).Count()!=presentations.Length)
                throw new InvalidDataException("Presentation projection must contain each participant exactly once.");
            foreach(var presentation in presentations)BattlePlayerPresentation.Validate(presentation);
            if(presentations.Any(x=>!ids.Contains(x.PlayerId)))throw new InvalidDataException("Presentation player is not in the manifest.");
            foreach(var participant in m.Players.Where(x=>x.WeaponSlots!=null))
            {
                var view=presentations.Single(x=>x.PlayerId==participant.PlayerId);
                foreach(var slot in participant.WeaponSlots!)
                {
                    var equipped=view.Weapons.SingleOrDefault(x=>x.Slot==slot.Slot);
                    if(equipped==null || equipped.WeaponIndex!=slot.WeaponIndex || equipped.SourceId!=slot.Weapon.SourceId ||
                       equipped.UpgradeIndex!=slot.WeaponUpgrade)
                        throw new InvalidDataException("Combat weapon slot differs from durable presentation authority.");
                }
            }
        }
        // Detach both mutable arrays before hashing or retaining allocator authority.
        return m with { Players = m.Players.Select(p=>p with
            {EquippedArmyUnitIds=p.EquippedArmyUnitIds?.ToArray(),
             NewArmyUnitIds=p.NewArmyUnitIds?.ToArray(),
             ArmyNormalUpgradeIndexes=p.ArmyNormalUpgradeIndexes?.ToArray(),
             ArmySpecialUpgradeIndexes=p.ArmySpecialUpgradeIndexes?.ToArray(),
             ArmyEliteUpgradeIndexes=p.ArmyEliteUpgradeIndexes?.ToArray(),
             ArmyHealthFactors=p.ArmyHealthFactors?.ToArray(),
             ArmyDamageScales=p.ArmyDamageScales?.ToArray(),
             ArmySpeedCoefficients=p.ArmySpeedCoefficients?.ToArray(),
             ArmyAccuracyCoefficients=p.ArmyAccuracyCoefficients?.ToArray(),
             WeaponSlots=p.WeaponSlots?.Select(x=>x with {}).ToArray()}).ToArray(),
             Presentations=m.Presentations?.Select(BattlePlayerPresentation.Validate).ToArray() };
    }

    private static bool IsSupportedMode(string? mode)
    {
        try { _ = BattleModeCapabilityPolicy.Resolve(mode ?? ""); return true; }
        catch (InvalidDataException) { return false; }
    }

    public string Digest() => Convert.ToHexStringLower(SHA256.HashData(JsonSerializer.SerializeToUtf8Bytes(this, Json)));
}
