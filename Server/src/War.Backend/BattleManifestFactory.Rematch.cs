using System.Text.Json;
using System.Text.Json.Nodes;
using War.BattleServer;

namespace War.Backend;

public sealed partial class BattleManifestFactory
{
    /// <summary>Refreshes durable equipment while preserving the accepted source battle's map and slots.</summary>
    public async Task<byte[]> CreateRematchAsync(byte[] acceptedManifest, string acceptedManifestHash,
        string nextMatchId, CancellationToken cancellationToken)
    {
        return (await PrepareRematchAsync(acceptedManifest, acceptedManifestHash,
            nextMatchId, cancellationToken)).Manifest;
    }

    /// <summary>Preserves the source scene and carries fresh durable revisions into rematch reservation.</summary>
    public async Task<PreparedBattleManifest> PrepareRematchAsync(byte[] acceptedManifest, string acceptedManifestHash,
        string nextMatchId, CancellationToken cancellationToken)
    {
        MatchManifest previous = MatchManifest.Parse(acceptedManifest);
        if (previous.Digest() != acceptedManifestHash || previous.MatchId == nextMatchId)
        {
            throw new InvalidDataException("Rematch source must match accepted evidence and use a fresh identity.");
        }
        var source = JsonNode.Parse(acceptedManifest)?.AsObject()
            ?? throw new InvalidDataException("Rematch source is absent.");
        RequireRefreshableSource(source, previous);
        source.Remove("Allocations");
        source.Remove("Presentations");
        var rematch = new BattleManifestFactory(JsonSerializer.SerializeToUtf8Bytes(source),
            allocations, presentations, weapons);
        string[] players = previous.Players.Select(player => player.PlayerId).ToArray();
        PreparedBattleManifest bound = await rematch.CreatePreparedAsync(nextMatchId, players, cancellationToken);
        var refreshed = JsonNode.Parse(bound.Manifest)?.AsObject()
            ?? throw new InvalidDataException("Rematch projection is absent.");
        PreserveSceneMaster(refreshed, previous);
        RefreshExistingRankFields(refreshed);
        byte[] result = JsonSerializer.SerializeToUtf8Bytes(refreshed);
        ValidateRefreshedArmyAllocations(MatchManifest.Parse(result));
        return new PreparedBattleManifest(result, bound.AccountRevisions);
    }

    private void ValidateRefreshedArmyAllocations(MatchManifest manifest)
    {
        if (weapons is not IBattleArmyManifestCatalog)
        {
            return;
        }

        foreach (ParticipantManifest player in manifest.Players)
        {
            var allocation = manifest.Allocations?.SingleOrDefault(row => row.PlayerId == player.PlayerId)
                ?? throw new InvalidDataException("Refreshed rematch army allocation is absent.");
            if (!allocation.NormalUpgradeIndexes.SequenceEqual(player.ArmyNormalUpgradeIndexes ?? []) ||
                !allocation.SpecialUpgradeIndexes.SequenceEqual(player.ArmySpecialUpgradeIndexes ?? []) ||
                !allocation.EliteUpgradeIndexes.SequenceEqual(player.ArmyEliteUpgradeIndexes ?? []))
            {
                throw new InvalidDataException("Rematch army allocation differs from current durable unit lanes.");
            }
        }
    }

    private void RequireRefreshableSource(JsonObject source, MatchManifest previous)
    {
        weapons.ValidateTemplate(source);
        if (previous.ServerId != template["ServerId"]?.GetValue<string>() ||
            previous.PvpGoldBonusesAtAdmission.HasValue)
        {
            throw new InvalidDataException("Rematch requires current host policy and a fresh bonus admission ledger.");
        }
        foreach (JsonNode? node in source["Players"]!.AsArray())
        {
            var player = node?.AsObject() ?? throw new InvalidDataException("Rematch participant is absent.");
            bool hasArmyAuthority = player.Any(field => field.Value != null &&
                (field.Key.StartsWith("Army", StringComparison.Ordinal) ||
                    field.Key is "EquippedArmyUnitIds" or "NewArmyUnitIds"));
            if (player["ShieldLevel"] != null)
            {
                throw new InvalidDataException("Rematch shield authority requires a fresh projection builder.");
            }

            if (hasArmyAuthority)
            {
                if (weapons is not IBattleArmyManifestCatalog armyCatalog)
                {
                    throw new InvalidDataException("The rematch catalog cannot refresh army authority.");
                }

                // Bind reconstructs these lanes from current state; source values never survive as authority.
                armyCatalog.RequireRefreshableArmyAuthority(player);
            }
        }
    }

    private static void PreserveSceneMaster(JsonObject root, MatchManifest previous)
    {
        if (previous.SceneMasterPlayerId != null)
        {
            // Ordinary Create chooses slot zero; rematch retains the source room's actual scene master.
            root["SceneMasterPlayerId"] = previous.SceneMasterPlayerId;
        }
    }

    private static void RefreshExistingRankFields(JsonObject root)
    {
        JsonArray players = root["Players"]!.AsArray();
        JsonArray views = root["Presentations"]!.AsArray();
        for (int index = 0; index < players.Count; index++)
        {
            var player = players[index]!.AsObject();
            if (player["PlayerLevel"] != null)
            {
                player["PlayerLevel"] = views[index]!["Level"]!.GetValue<int>();
            }
        }
    }
}
