namespace War.BattleServer;

/// <summary>
/// The seven CardSpawnUnit components in the recovered 1.4.0 MainScene.
/// These cards use separate CARDS_MIN/CARDS_MAX upgrades. An ordinary army
/// deployment with the same unit ID does not reproduce their combat stats.
/// </summary>
public static class CardSpawnUnitSourceCatalog
{
    public sealed record Row(string SourceCardId, int CardComponentFileId,
        int BehaviourComponentFileId, int UpgradeSlotsComponentFileId,
        string UnitId, int Count, float SpawnDelaySeconds);

    private static readonly IReadOnlyDictionary<string, Row> Rows = Build();

    private static IReadOnlyDictionary<string, Row> Build()
    {
        Row[] recovered =
        [
            new("BIGROCKET", 42057, 42012, 47815, "ID_UNIT-ROCKETSOLDIER", 1, 0),
            new("ELITEMINIGUN", 36004, 41873, 45363, "ID_UNIT-MINIGUNNER", 1, 0),
            new("ELITEPARA", 47393, 38324, 37642, "ID_UNIT-PARATROOPER", 2, 0.5f),
            new("ELITESNIPER", 48860, 43123, 38465, "ID_UNIT-SNIPER", 2, 0),
            new("ELITESWAT", 41884, 38536, 41234, "ID_UNIT-SWAT", 2, 0),
            new("GREATGRENADIER", 40037, 49788, 47098, "ID_UNIT-GRENADIER", 1, 0),
            new("HEAVYDRONE", 42044, 39312, 40715, "ID_UNIT-DRONE", 1, 0)
        ];

        if (recovered.Length != 7 || recovered.Any(row => row.Count is < 1 or > 2 ||
            row.CardComponentFileId <= 0 || row.BehaviourComponentFileId <= 0 ||
            row.UpgradeSlotsComponentFileId <= 0 ||
            !float.IsFinite(row.SpawnDelaySeconds) || row.SpawnDelaySeconds < 0 ||
            row.SpawnDelaySeconds > 1 ||
            WarCardSourceIdentityCatalog.Resolve("CardSpawnUnit", row.SourceCardId) != row.SourceCardId ||
            !ArmyOptionIdentityCatalog.All.Any(option => option.UnitId == row.UnitId)))
            throw new InvalidDataException("Recovered unit-card catalog is incomplete.");

        var byId = recovered.ToDictionary(row => row.SourceCardId, StringComparer.Ordinal);
        if (byId.Count != recovered.Length)
            throw new InvalidDataException("Recovered unit-card identities repeat.");
        return byId;
    }

    public static Row Get(string sourceCardId) =>
        Rows.TryGetValue(sourceCardId, out var row) ? row :
        throw new InvalidDataException("Unknown recovered unit-card identity.");

    public static IReadOnlyList<Row> All => Rows.Values.OrderBy(row => row.SourceCardId,
        StringComparer.Ordinal).ToArray();
}
