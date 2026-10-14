namespace War.BattleServer;

/// <summary>
/// Host-owned score progress multipliers for the two recovered War Cards.
/// This state is ready for the live card route; it does not spend a card.
/// </summary>
public sealed class PvpScoreMultiplierState
{
    public const string StreakBoost = "STREAKBOOST";
    public const string CrateBlocker = "CRATEBLOCKER";
    public const float DurationSeconds = 60f;

    private sealed class CardTimer
    {
        public string OwnerId { get; }
        public string TargetId { get; }
        public string CardId { get; }
        public float RemainingSeconds { get; set; }

        public CardTimer(string ownerId, string targetId, string cardId)
        {
            OwnerId = ownerId;
            TargetId = targetId;
            CardId = cardId;
            RemainingSeconds = DurationSeconds;
        }
    }

    private readonly string firstPlayerId;
    private readonly string secondPlayerId;
    private readonly Dictionary<string, CardTimer> activeCards = new(StringComparer.Ordinal);
    private readonly Dictionary<string, float> multipliers = new(StringComparer.Ordinal);

    public PvpScoreMultiplierState(string firstPlayerId, string secondPlayerId)
    {
        if (string.IsNullOrWhiteSpace(firstPlayerId) ||
            string.IsNullOrWhiteSpace(secondPlayerId) || firstPlayerId == secondPlayerId)
            throw new ArgumentException("A PvP multiplier needs two distinct players.");
        this.firstPlayerId = firstPlayerId;
        this.secondPlayerId = secondPlayerId;
        multipliers.Add(firstPlayerId, 1f);
        multipliers.Add(secondPlayerId, 1f);
    }

    public float ForPlayer(string playerId) => multipliers.TryGetValue(playerId, out float value)
        ? value : throw new InvalidDataException("Multiplier target is outside the match.");

    public void UseCard(string ownerId, string cardId)
    {
        if (!multipliers.ContainsKey(ownerId))
            throw new InvalidDataException("Card owner is outside the match.");
        if (cardId is not (StreakBoost or CrateBlocker))
            throw new InvalidDataException("Card has no reviewed score multiplier.");

        string targetId = cardId == StreakBoost ? ownerId : OpponentOf(ownerId);
        if (activeCards.ContainsKey(cardId + ":" + ownerId))
            throw new InvalidOperationException("This card is already active for its owner.");

        activeCards.Add(cardId + ":" + ownerId, new CardTimer(ownerId, targetId, cardId));
        // The Client assigns the ScoreManager property. It does not multiply
        // existing card effects, so the last use overwrites the target value.
        multipliers[targetId] = cardId == StreakBoost ? 1.25f : 0f;
    }

    public void Advance(float scaledDeltaSeconds)
    {
        if (!float.IsFinite(scaledDeltaSeconds) || scaledDeltaSeconds < 0f)
            throw new ArgumentOutOfRangeException(nameof(scaledDeltaSeconds));

        foreach (var pair in activeCards.ToArray())
        {
            CardTimer timer = pair.Value;
            // Each recovered Card.Update checks remaining time before reducing
            // it; a card that crosses zero expires on the following update.
            if (timer.RemainingSeconds > 0f)
            {
                timer.RemainingSeconds -= scaledDeltaSeconds;
                continue;
            }

            activeCards.Remove(pair.Key);
            // The source resets to one even if another card overwrote the
            // property in the meantime. Preserve that callback ordering.
            multipliers[timer.TargetId] = 1f;
        }
    }

    internal PvpScoreMultiplierState PrepareAdvanceCopy(float scaledDeltaSeconds)
    {
        var candidate = new PvpScoreMultiplierState(firstPlayerId, secondPlayerId);
        foreach (var pair in multipliers)
            candidate.multipliers[pair.Key] = pair.Value;
        foreach (var pair in activeCards)
        {
            var timer = pair.Value;
            candidate.activeCards.Add(pair.Key, new CardTimer(timer.OwnerId,
                timer.TargetId, timer.CardId)
            {
                RemainingSeconds = timer.RemainingSeconds
            });
        }
        candidate.Advance(scaledDeltaSeconds);
        return candidate;
    }

    private string OpponentOf(string playerId) => playerId == firstPlayerId
        ? secondPlayerId : firstPlayerId;
}
