using System.Text.Json.Serialization;

namespace War.BattleServer;

public sealed record ParticipantManifest(
    string PlayerId,
    WeaponManifest Weapon,
    int Fraction = 0,
    int StartCover = -1,
    float MovementSpeed = 0,
    PlayerCombatManifest? Combat = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] int? WeaponUpgrade = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] int? ShieldLevel = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] int? PlayerLevel = null)
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
    // Trusted BehaviourDefinititon.ScaleByPerk shotSpeedCoef, never packet authority.
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public float[]? ArmyShotSpeedCoefficients { get; init; }
    // Source-ordered durable equipped slots. Weapon remains the first active
    // slot for compatibility with older signed manifests.
    [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingNull)]
    public WeaponSlotManifest[]? WeaponSlots { get; init; }
}
