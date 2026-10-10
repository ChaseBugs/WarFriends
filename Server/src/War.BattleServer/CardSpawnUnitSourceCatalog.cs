namespace War.BattleServer;

/// <summary>
/// The seven CardSpawnUnit components in the recovered 1.4.0 MainScene.
/// Six use separate CARDS_MIN/CARDS_MAX upgrades; the sniper uses the
/// recovered missing-row fallback. An ordinary army deployment with the
/// same unit ID does not reproduce their combat stats.
/// </summary>
public static class CardSpawnUnitSourceCatalog
{
    public sealed record Row(string SourceCardId, int CardComponentFileId,
        int BehaviourComponentFileId, int UpgradeSlotsComponentFileId,
        int UpgradeSheetComponentFileId, int CardMinimumRowIndex,
        int CardMaximumRowIndex, string UnitId, int Count, float SpawnDelaySeconds)
    {
        // UpgradeSlots.LoadDataForCard uses row zero for both endpoints when
        // its attached sheet has no CARDS_MIN/CARDS_MAX names. This applies
        // to the recovered ELITESNIPER sheet.
        public bool UsesMissingCardRowsFallback => CardMinimumRowIndex == 0 &&
            CardMaximumRowIndex == 0;
    }

    private static readonly IReadOnlyDictionary<string, Row> Rows = Build();

    private static IReadOnlyDictionary<string, Row> Build()
    {
        Row[] recovered =
        [
            new("BIGROCKET", 42057, 42012, 47815, 47816, 117, 118,
                "ID_UNIT-ROCKETSOLDIER", 1, 0),
            new("ELITEMINIGUN", 36004, 41873, 45363, 45364, 57, 58,
                "ID_UNIT-MINIGUNNER", 1, 0),
            new("ELITEPARA", 47393, 38324, 37642, 37643, 123, 124,
                "ID_UNIT-PARATROOPER", 2, 0.5f),
            new("ELITESNIPER", 48860, 43123, 38465, 38464, 0, 0,
                "ID_UNIT-SNIPER", 2, 0),
            new("ELITESWAT", 41884, 38536, 41234, 41235, 102, 103,
                "ID_UNIT-SWAT", 2, 0),
            new("GREATGRENADIER", 40037, 49788, 47098, 47099, 133, 134,
                "ID_UNIT-GRENADIER", 1, 0),
            new("HEAVYDRONE", 42044, 39312, 40715, 40716, 117, 118,
                "ID_UNIT-DRONE", 1, 0)
        ];

        if (recovered.Length != 7 || recovered.Any(row => row.Count is < 1 or > 2 ||
            row.CardComponentFileId <= 0 || row.BehaviourComponentFileId <= 0 ||
            row.UpgradeSlotsComponentFileId <= 0 || row.UpgradeSheetComponentFileId <= 0 ||
            row.CardMinimumRowIndex < 0 ||
            (row.SourceCardId == "ELITESNIPER" ? !row.UsesMissingCardRowsFallback :
                row.CardMinimumRowIndex == 0 || row.CardMaximumRowIndex != row.CardMinimumRowIndex + 1) ||
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

    /// <summary>
    /// A card uses the same scene behaviour and upgrade-slot components as
    /// its ordinary army family. This binding permits the host to reuse that
    /// family's source spawn-point rules without using its normal stat rows.
    /// </summary>
    public static ArmyDeploymentFamily Family(ArmyDeploymentCatalog army,
        string sourceCardId)
    {
        ArgumentNullException.ThrowIfNull(army);
        Row card = Get(sourceCardId);
        ArmyDeploymentFamily[] matches = army.Families.Where(family =>
            family.UnitId == card.UnitId &&
            family.BehaviorFileId == card.BehaviourComponentFileId &&
            family.UpgradeSlotsFileId == card.UpgradeSlotsComponentFileId).ToArray();

        if (matches.Length != 1)
            throw new InvalidDataException("Unit card does not bind one recovered army behaviour.");

        return matches[0];
    }

    public static IReadOnlyList<Row> All => Rows.Values.OrderBy(row => row.SourceCardId,
        StringComparer.Ordinal).ToArray();
}
