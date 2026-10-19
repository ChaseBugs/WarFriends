namespace War.Persistence;

public sealed partial class BattleMatchQueueStore
{
    /// <summary>Reads a validated pair only while no cancellation has been requested.</summary>
    public async Task<BattlePairingResult?> ReadStartablePairAsync(
        string playerId, CancellationToken cancellationToken)
    {
        if (!ValidId(playerId))
        {
            throw new InvalidDataException("Invalid battle participant identity.");
        }

        BattlePairDocument? pair = await PairFor(playerId, cancellationToken);
        if (pair == null)
        {
            return null;
        }

        BattlePairingResult checkedPair = Result("paired", pair);
        return pair.Cancellation == null ? checkedPair : null;
    }
}
