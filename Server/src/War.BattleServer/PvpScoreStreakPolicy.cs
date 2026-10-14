using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Reviewed source parameters, never supplied by a battle packet.</summary>
public sealed class PvpScoreStreakPolicy
{
    private const string ReviewedSha256 =
        "7ff8de88e288ab40f188d25e22b8460de6555adaf3c76353a522e06b2775042b";

    public float MultiplayerRatio { get; } = 0.75f;
    public float ProgressLossPerSecond { get; } = 1.1f;
    public float BonusThreshold { get; } = 100f;
    public int MaximumBonusesPerUpdate { get; } = 1;
    public int MatchmakingEasyBotTillLevel { get; } = 4;

    private PvpScoreStreakPolicy() { }

    public float RatioForMatch(bool dropsCrates)
    {
        // ScoreManager.Restart overwrites the serialized 0.075 with the
        // Constants row, then disables progress gain when dropCreates is false.
        return dropsCrates ? MultiplayerRatio : 0f;
    }

    public bool DropsCratesForOnlineView(int localLevelIndex, int? opponentLevelIndex)
    {
        if (localLevelIndex is < 0 or > 42)
            throw new ArgumentOutOfRangeException(nameof(localLevelIndex));
        if (opponentLevelIndex is < 0 or > 42)
            throw new ArgumentOutOfRangeException(nameof(opponentLevelIndex));
        // LevelManager.isNoob uses the local display number (index + 1).
        // GameControllerOnline compares the opponent's raw zero-based index.
        return opponentLevelIndex.HasValue &&
            localLevelIndex + 1 > MatchmakingEasyBotTillLevel &&
            opponentLevelIndex.Value > MatchmakingEasyBotTillLevel;
    }

    public static PvpScoreStreakPolicy Load(string path, string sceneSha256, string contentSha256)
    {
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedSha256)
            throw new InvalidDataException("PvP score-streak policy differs from reviewed source.");
        using var document = JsonDocument.Parse(bytes);
        var root = document.RootElement;
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("sceneSha256").GetString() != sceneSha256 ||
            root.GetProperty("battleContentSha256").GetString() != contentSha256 ||
            root.GetProperty("multiplayerRatio").GetSingle() != 0.75f ||
            root.GetProperty("progressLossPerSecond").GetSingle() != 1.1f ||
            root.GetProperty("bonusThreshold").GetInt32() != 100 ||
            root.GetProperty("maximumBonusesPerUpdate").GetInt32() != 1 ||
            root.GetProperty("matchmakingEasyBotTillLevel").GetInt32() != 4)
            throw new InvalidDataException("PvP score-streak policy uses different source provenance.");
        return new PvpScoreStreakPolicy();
    }
}
