using System.Text.Json;
using System.Text.Json.Nodes;
using War.Backend.Features.Battle.Settlement;
using War.Backend.Legacy;

namespace War.Battle.Tests.Legacy.Progression;

internal static class BattleRankProgressionTests
{
    internal static void Run(string contentDirectory)
    {
        LegacyCatalog catalog = LegacyCatalog.Load(Path.Combine(contentDirectory, "recovered-battle-content.json"));
        var progression = new BattleRankProgression(catalog);
        BattleRankAdvance unchanged = progression.Apply(new(0, 49_999, 49_999), 0);
        Require(unchanged.Rank == new BattleRankSnapshot(0, 49_999, 49_999) && unchanged.GoldReward == 0,
            "Zero earned XP must not consume a rank or grant its reward.");

        BattleRankAdvance crossed = progression.Apply(new(0, 49_999, 49_999), 50_001);
        Require(crossed.Rank == new BattleRankSnapshot(2, 0, 100_000),
            "Exact thresholds must carry XP through both recovered 50,000-point ranks.");
        Require(crossed.LevelsGained == 2 && crossed.GoldReward == 10 && crossed.WarBucksReward == 0 &&
            crossed.RankPowerIncrease == 11, "Each completed source row contributes exactly one reward and power delta.");

        BattleRankAdvance capped = progression.Apply(new(42, 117_091_961, 500_000_000), 2);
        Require(capped.Rank.Level == 42 && capped.Rank.LevelExperience == 117_091_963 &&
            capped.Rank.Experience == 500_000_002 && capped.GoldReward == 0 && capped.LevelsGained == 0,
            "Final rank retains XP without repeated threshold rewards.");

        ExpectInvalid(() => progression.Apply(new(0, 50_000, 50_000), 1));
        ExpectInvalid(() => progression.Apply(new(43, 0, 0), 1));
        ExpectInvalid(() => progression.Apply(new(0, 0, 0), -1));
        ExpectInvalid(() => progression.Apply(new(42, int.MaxValue, 0), 1));
        ExpectInvalid(() => progression.Apply(new(0, 0, long.MaxValue), 1));
        CheckDamagedRows(catalog);
    }

    private static void CheckDamagedRows(LegacyCatalog catalog)
    {
        var rows = new JsonArray(catalog.Sheet("Google2u.Levels")
            .Select(row => JsonNode.Parse(row.ToJsonString())).ToArray());
        CheckMutation(rows, changed => changed.RemoveAt(0));
        CheckMutation(rows, changed => changed[1]!["LEVEL"] = 1);
        CheckMutation(rows, changed => changed[0]!["EXPERIENCE"] = 0);
        CheckMutation(rows, changed => changed[0]!["EXPERIENCE"] = 1.5);
        CheckMutation(rows, changed => changed[0]!["REWARDGOLD"] = -1);
        CheckMutation(rows, changed => changed[0]!["REWARDGOLD"] = int.MaxValue);
        CheckMutation(rows, changed => changed[1]!["ARMYPOWER"] = 0);
    }

    private static void CheckMutation(JsonArray rows, Action<JsonArray> mutate)
    {
        var changed = (JsonArray)rows.DeepClone();
        mutate(changed);
        string json = JsonSerializer.Serialize(new { sheets = new[] { new { type = "Google2u.Levels", rows = changed } } });
        ExpectInvalid(() => new BattleRankProgression(LegacyCatalog.Parse(json)));
    }

    private static void ExpectInvalid(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new Exception("Invalid battle rank authority was accepted.");
    }

    private static void Require(bool valid, string message)
    {
        if (!valid)
        {
            throw new Exception(message);
        }
    }
}
