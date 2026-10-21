using System.Text.Json;
using System.Text.Json.Nodes;

using War.BattleServer;
using War.Shared;

namespace War.Backend;

/// <summary>Binds source PvP scales and bilateral elite perks into presentation-ordered combat lanes.</summary>
internal static class BattleArmyCombatProjection
{
    private const float NormalPvpScale = 1f;
    private static readonly string[] CombatFields =
    ["ArmyHealthFactors", "ArmyDamageScales", "ArmySpeedCoefficients", "ArmyAccuracyCoefficients",
        "ArmyShotSpeedCoefficients"];

    internal static void Bind(BattleCombatContent content, JsonArray players,
        IReadOnlyList<BattlePlayerPresentation> views)
    {
        JsonObject[] fields = BuildPair(content, players, views);
        for (int index = 0; index < fields.Length; index++)
        {
            JsonObject player = players[index]!.AsObject();
            foreach (var field in fields[index])
            {
                player[field.Key] = field.Value?.DeepClone();
            }
        }
    }

    internal static void PrepareRefresh(BattleCombatContent content, JsonObject source, MatchManifest previous)
    {
        JsonArray players = source["Players"]!.AsArray();
        bool hasCombat = players.Any(player => CombatFields.Any(field => player![field] != null));
        if (!hasCombat)
        {
            return;
        }
        BattlePlayerPresentation[] views = previous.Presentations ??
            throw new InvalidDataException("Army combat refresh requires accepted player presentation.");
        JsonObject[] expected = BuildPair(content, players, views);
        for (int index = 0; index < players.Count; index++)
        {
            foreach (string field in CombatFields)
            {
                if (!JsonNode.DeepEquals(players[index]![field], expected[index][field]))
                {
                    throw new InvalidDataException("Accepted army combat factors differ from source projection.");
                }
            }
        }
        // Only a fully validated old projection is removed; fresh account snapshots rebuild every lane afterward.
        foreach (JsonNode? player in players)
        {
            foreach (string field in CombatFields)
            {
                player!.AsObject().Remove(field);
            }
        }
    }

    private static JsonObject[] BuildPair(BattleCombatContent content, JsonArray players,
        IReadOnlyList<BattlePlayerPresentation> views)
    {
        if (players.Count != 2 || views.Count != 2)
        {
            throw new InvalidDataException("Army combat projection requires two participants.");
        }
        var ordered = new BattlePlayerPresentation[players.Count];
        for (int index = 0; index < ordered.Length; index++)
        {
            if (players[index] is not JsonObject player || player["PlayerId"] is not JsonValue identityNode ||
                !identityNode.TryGetValue(out string? identity))
            {
                throw new InvalidDataException("Army combat participant identity is missing.");
            }
            BattlePlayerPresentation[] matches = views.Where(view => view.PlayerId == identity).ToArray();
            if (matches.Length != 1)
            {
                throw new InvalidDataException("Army combat presentation does not bind exactly one participant.");
            }
            ordered[index] = BattlePlayerPresentation.Validate(matches[0]);
        }
        return
        [
            BuildFields(content.Army, ordered[0], ordered[1]),
            BuildFields(content.Army, ordered[1], ordered[0])
        ];
    }

    private static JsonObject BuildFields(ArmyDeploymentCatalog army, BattlePlayerPresentation owner,
        BattlePlayerPresentation opponent)
    {
        if (owner.Units.Count == 0)
        {
            return new JsonObject();
        }
        var factors = BattleArmyPerkCatalog.Recovered.Calculate(army, owner, opponent);
        var health = new List<ArmyHealthFactors>();
        var damage = new List<float>();
        var speed = new List<float>();
        var accuracy = new List<float>();
        var shotSpeed = new List<float>();
        foreach (BattleUnitPresentation unit in owner.Units)
        {
            ArmyDeploymentFamily family = army.Families.Single(row => row.SheetRow == unit.SourceId);
            BattleArmyPerkCatalog.Factors perk = factors[family.UnitId];
            var healthFactors = new ArmyHealthFactors(perk.Health, NormalPvpScale);
            ValidateComposedStats(army, unit, family.UnitId, healthFactors);
            health.Add(healthFactors);
            // PlayerProperties and IGameController build normal PvP UnitUpgrades with scaleHp/scaleDamage one.
            damage.Add(NormalPvpScale);
            speed.Add(perk.Speed);
            accuracy.Add(perk.Accuracy);
            shotSpeed.Add(perk.ShotSpeed);
        }
        return new JsonObject
        {
            ["ArmyHealthFactors"] = JsonSerializer.SerializeToNode(health),
            ["ArmyDamageScales"] = JsonSerializer.SerializeToNode(damage),
            ["ArmySpeedCoefficients"] = JsonSerializer.SerializeToNode(speed),
            ["ArmyAccuracyCoefficients"] = JsonSerializer.SerializeToNode(accuracy),
            ["ArmyShotSpeedCoefficients"] = JsonSerializer.SerializeToNode(shotSpeed)
        };
    }

    private static void ValidateComposedStats(ArmyDeploymentCatalog army, BattleUnitPresentation unit,
        string unitId, ArmyHealthFactors factors)
    {
        int? special = unit.SpecialIndex >= 0 ? unit.SpecialIndex : null;
        int? elite = unit.EliteIndex >= 0 ? unit.EliteIndex : null;
        _ = army.EffectiveHealth(unitId, unit.UpgradeIndex, special, elite, factors);
        _ = army.EffectiveDamage(unitId, unit.UpgradeIndex, special, elite, NormalPvpScale);
    }
}
