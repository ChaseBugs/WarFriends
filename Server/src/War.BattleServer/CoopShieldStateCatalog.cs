using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopShieldStart(
    float HealthRatio, float MaxHealthRatio, bool Regenerate, bool AutoRepair);

public sealed record CoopMissionShields(
    int MissionIndex, IReadOnlyList<CoopShieldStart> Player,
    IReadOnlyList<CoopShieldStart> Bot);

/// <summary>
/// Mission.OnAfterGameStarted applies these overrides to the ordered shields
/// of each fraction. Missing rows leave the normal full-health shield intact.
/// </summary>
public sealed class CoopShieldStateCatalog
{
    private const string ReviewedSha256 =
        "02ed9bc14a3fd96ff799da9299c84f46f00cf59e5717bbc9187039fab2e7dd63";
    private readonly IReadOnlyList<CoopMissionShields> missions;

    private CoopShieldStateCatalog(CoopMissionShields[] rows)
    {
        missions = new ReadOnlyCollection<CoopMissionShields>(rows);
    }

    public CoopMissionShields ForMission(int missionIndex)
    {
        if (missionIndex < 0 || missionIndex >= missions.Count)
            throw new ArgumentOutOfRangeException(nameof(missionIndex));
        return missions[missionIndex];
    }

    public static CoopShieldStateCatalog Load(string path, MissionCatalog catalog)
    {
        ArgumentNullException.ThrowIfNull(catalog);
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedSha256)
            throw new InvalidDataException("Mission shield states differ from reviewed MainScene.");

        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("sourceSha256").GetString() != catalog.SourceSha256)
            throw new InvalidDataException("Mission shield states use a different source.");
        JsonElement sourceRows = root.GetProperty("missions");
        if (sourceRows.GetArrayLength() != catalog.Missions.Count)
            throw new InvalidDataException("Incomplete mission shield states.");

        var rows = new CoopMissionShields[sourceRows.GetArrayLength()];
        for (int index = 0; index < rows.Length; index++)
        {
            JsonElement source = sourceRows[index];
            if (source.GetProperty("missionIndex").GetInt32() != index)
                throw new InvalidDataException("Mission shield states are out of order.");
            rows[index] = new CoopMissionShields(index,
                ReadStates(source.GetProperty("player")),
                ReadStates(source.GetProperty("bot")));
        }
        return new CoopShieldStateCatalog(rows);
    }

    private static IReadOnlyList<CoopShieldStart> ReadStates(JsonElement source)
    {
        if (source.ValueKind != JsonValueKind.Array || source.GetArrayLength() > 4)
            throw new InvalidDataException("Invalid mission shield state count.");
        var states = new CoopShieldStart[source.GetArrayLength()];
        for (int index = 0; index < states.Length; index++)
        {
            JsonElement row = source[index];
            float health = row.GetProperty("healthRatio").GetSingle();
            float maximum = row.GetProperty("maxHealthRatio").GetSingle();
            if (!float.IsFinite(health) || health is < 0 or > 10 ||
                !float.IsFinite(maximum) || maximum is < 0 or > 10)
                throw new InvalidDataException("Invalid mission shield health ratio.");
            states[index] = new CoopShieldStart(health, maximum,
                row.GetProperty("regenerate").GetBoolean(),
                row.GetProperty("autoRepair").GetBoolean());
        }
        return new ReadOnlyCollection<CoopShieldStart>(states);
    }
}
