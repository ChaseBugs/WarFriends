using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using War.Backend.Legacy;
using War.Infrastructure;

namespace War.Backend.Features.Battle.Settlement;

/// <summary>Explicit offline defaults plus recovered tables, frozen into each allocated battle.</summary>
public sealed record BattleRewardPolicy
{
    public int Version { get; init; } = 1;
    public int WinWarBucks { get; init; } = 800;
    public int LoseWarBucks { get; init; } = 400;
    public int WinMedals { get; init; } = 20;
    public int LoseMedals { get; init; } = 10;
    public int TimeXpPerSecond { get; init; }
    public int StreakSeconds { get; init; }
    public float VipWarBucksMultiplier { get; init; }
    public float VipExperienceMultiplier { get; init; }
    public float VipGoldMultiplier { get; init; }
    public IReadOnlyList<int> StreakRewards { get; init; } = [];
    public IReadOnlyList<JsonElement> RankRows { get; init; } = [];

    public static BattleRewardPolicy Create(LegacyCatalog catalog, IConfiguration configuration)
    {
        int Read(string name, int fallback) => DeploymentValueParser.ReadInt32(
            configuration["Battle:Rewards:" + name], "Battle:Rewards:" + name, fallback);
        var policy = new BattleRewardPolicy
        {
            WinWarBucks = Read(nameof(WinWarBucks), 800), LoseWarBucks = Read(nameof(LoseWarBucks), 400),
            WinMedals = Read(nameof(WinMedals), 20), LoseMedals = Read(nameof(LoseMedals), 10),
            TimeXpPerSecond = Read(nameof(TimeXpPerSecond), 0),
            StreakSeconds = catalog.ConstantInt("WinstreakInterval") ?? throw new InvalidDataException("Missing streak time."),
            VipWarBucksMultiplier = RequiredMultiplier(catalog, "VipWarbucksMultiplier"),
            VipExperienceMultiplier = RequiredMultiplier(catalog, "VipExperienceMultiplier"),
            VipGoldMultiplier = RequiredMultiplier(catalog, "VipGoldMultiplier"),
            StreakRewards = Array.AsReadOnly(Enumerable.Range(1, 10).Select(index =>
                catalog.ConstantInt("WinstreakReward" + index) ?? throw new InvalidDataException("Missing streak reward."))
                .ToArray()),
            RankRows = Array.AsReadOnly(catalog.Sheet("Google2u.Levels").Select(row =>
                JsonSerializer.Deserialize<JsonElement>(row.ToJsonString())).ToArray())
        };
        policy.Validate();
        return policy;
    }

    public static BattleRewardPolicy Parse(string json)
    {
        ValidateFields(json);
        var options = new JsonSerializerOptions { UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow };
        BattleRewardPolicy policy = JsonSerializer.Deserialize<BattleRewardPolicy>(json, options)
            ?? throw new InvalidDataException("Missing frozen reward policy.");
        policy.Validate();
        return policy;
    }

    private static float RequiredMultiplier(LegacyCatalog catalog, string name)
    {
        double value = catalog.Constant(name)
            ?? throw new InvalidDataException("Missing recovered reward multiplier: " + name);
        return (float)value;
    }

    private static void ValidateFields(string json)
    {
        using JsonDocument document = JsonDocument.Parse(json);
        if (document.RootElement.ValueKind != JsonValueKind.Object)
        {
            throw new InvalidDataException("Frozen reward policy must be an object.");
        }

        var remaining = new HashSet<string>(StringComparer.Ordinal)
        {
            nameof(Version), nameof(WinWarBucks), nameof(LoseWarBucks), nameof(WinMedals), nameof(LoseMedals),
            nameof(TimeXpPerSecond), nameof(StreakSeconds), nameof(VipWarBucksMultiplier),
            nameof(VipExperienceMultiplier), nameof(VipGoldMultiplier), nameof(StreakRewards), nameof(RankRows)
        };
        foreach (JsonProperty property in document.RootElement.EnumerateObject())
        {
            if (!remaining.Remove(property.Name))
            {
                throw new InvalidDataException("Unknown or duplicate frozen reward policy field.");
            }
        }
        if (remaining.Count != 0)
        {
            throw new InvalidDataException("Incomplete frozen reward policy.");
        }
    }

    public string ToJson() => JsonSerializer.Serialize(this);

    public string Revision() => Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(ToJson())));

    public BattleRankProgression CreateProgression()
    {
        string catalog = JsonSerializer.Serialize(new { sheets = new[] { new { type = "Google2u.Levels", rows = RankRows } } });
        return new BattleRankProgression(LegacyCatalog.Parse(catalog));
    }

    private void Validate()
    {
        if (Version != 1 || WinWarBucks < 0 || LoseWarBucks < 0 || WinMedals < 0 || LoseMedals < 0 ||
            TimeXpPerSecond is < 0 or > 1_000_000 || StreakSeconds is < 1 or > 86_400 ||
            !float.IsFinite(VipWarBucksMultiplier) || VipWarBucksMultiplier is < 1 or > 4 ||
            !float.IsFinite(VipExperienceMultiplier) || VipExperienceMultiplier is < 1 or > 4 ||
            !float.IsFinite(VipGoldMultiplier) || VipGoldMultiplier is < 1 or > 4 ||
            StreakRewards == null || StreakRewards.Count != 10 || StreakRewards.Any(value => value < 0) || RankRows == null)
        {
            throw new InvalidDataException("Invalid offline battle reward policy.");
        }

        RewardInt32.Scale(WinWarBucks, VipWarBucksMultiplier);
        RewardInt32.Scale(LoseWarBucks, VipWarBucksMultiplier);
        foreach (int reward in StreakRewards)
        {
            RewardInt32.Scale(reward, VipWarBucksMultiplier);
        }
        CreateProgression();
    }
}
