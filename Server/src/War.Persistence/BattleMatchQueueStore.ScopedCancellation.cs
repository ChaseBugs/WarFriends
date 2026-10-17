using System.Text.RegularExpressions;

using MongoDB.Driver;

namespace War.Persistence;

public sealed partial class BattleMatchQueueStore
{
    private const int ReservedMatchPlayerCount = 2;

    /// <summary>Captures only the specified reservation, never a replacement pair or ticket.</summary>
    public async Task<BattlePairingResult> CancelReservedMatchAsync(
        BattleReservedMatchCancellation request, CancellationToken cancellationToken)
    {
        string playerId = request.PlayerId;
        string expectedMatchId = request.MatchId;
        DateTimeOffset now = request.ApplicationTime;
        string[] expectedPlayers = request.ExpectedPlayers?.ToArray()
            ?? throw new InvalidDataException("Expected cancellation roster is missing.");
        Validate(playerId, "cancel", now);
        if (!Regex.IsMatch(expectedMatchId ?? "", @"\Am[0-9a-f]{32}\z") ||
            expectedPlayers.Length != ReservedMatchPlayerCount ||
            expectedPlayers.Distinct(StringComparer.Ordinal).Count() != ReservedMatchPlayerCount ||
            !expectedPlayers.Contains(playerId, StringComparer.Ordinal) || expectedPlayers.Any(identity =>
                !Guid.TryParseExact(identity, "N", out _) || identity != identity.ToLowerInvariant()))
        {
            throw new InvalidDataException("A canonical cancellation match identity is required.");
        }
        using var session = await client.StartSessionAsync(cancellationToken: cancellationToken);
        return await session.WithTransactionAsync(async (transaction, token) =>
        {
            var pair = await pairs.Find(transaction, row => row.MatchId == expectedMatchId).FirstOrDefaultAsync(token);
            if (pair == null)
            {
                return new BattlePairingResult("not-assigned", null, null);
            }
            var validated = ValidatePairDocument(pair);
            var roster = validated.Players ?? throw new InvalidDataException("Reserved roster is missing.");
            if (!roster.SequenceEqual(expectedPlayers, StringComparer.Ordinal))
            {
                throw new InvalidDataException("Reserved cancellation roster differs from the current pair.");
            }
            if (pair.AttemptIds.Length != 0)
            {
                throw new InvalidDataException("An attempt credential owns this match's cancellation authority.");
            }
            await RecordPairCancellationAsync(pair, playerId, "", new AttemptTransaction(transaction, now, token));
            return Result("already-paired", pair);
        }, QueueTransaction, cancellationToken);
    }
}
