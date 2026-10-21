using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Configuration;
using War.Backend.Features.Battle.Settlement;
using War.Backend.Legacy;

namespace War.Battle.Tests.Legacy.Progression;

internal static class BattleRewardPolicyTests
{
    internal static void Run(string contentDirectory)
    {
        LegacyCatalog catalog = LegacyCatalog.Load(Path.Combine(contentDirectory, "recovered-battle-content.json"));
        var settings = new Dictionary<string, string?> { ["Battle:Rewards:WinWarBucks"] = "900" };
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(settings).Build();
        BattleRewardPolicy policy = BattleRewardPolicy.Create(catalog, configuration);
        BattleRewardPolicy restored = BattleRewardPolicy.Parse(policy.ToJson());
        Require(restored.WinWarBucks == 900 && restored.LoseWarBucks == 400,
            "Operator reward overrides and documented defaults must survive allocation freezing.");
        Require(restored.Revision() == policy.Revision(), "Frozen policy must retain its content identity.");

        var complete = JsonNode.Parse(policy.ToJson())!.AsObject();
        foreach (string field in complete.Select(property => property.Key).ToArray())
        {
            var missing = (JsonObject)complete.DeepClone();
            missing.Remove(field);
            ExpectInvalid(() => BattleRewardPolicy.Parse(missing.ToJsonString()));
        }
        ExpectInvalid(() => BattleRewardPolicy.Parse(policy.ToJson().Insert(1, "\"Version\":1,")));
        var damaged = (JsonObject)complete.DeepClone();
        damaged["Unknown"] = 1;
        ExpectInvalid(() => BattleRewardPolicy.Parse(damaged.ToJsonString()));
        damaged.Remove("Unknown");
        damaged["WinWarBucks"] = -1;
        ExpectInvalid(() => BattleRewardPolicy.Parse(damaged.ToJsonString()));
        damaged["WinWarBucks"] = int.MaxValue;
        ExpectInvalid(() => BattleRewardPolicy.Parse(damaged.ToJsonString()));
    }

    private static void ExpectInvalid(Action action)
    {
        try
        {
            action();
        }
        catch (Exception error) when (error is InvalidDataException or JsonException or OverflowException)
        {
            return;
        }
        throw new Exception("Damaged reward policy was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
