namespace War.Persistence;

public sealed partial class BattleRematchConsentStore
{
    private static void ValidateTime(DateTimeOffset now)
    {
        if (now < DateTimeOffset.UnixEpoch || now > DateTimeOffset.MaxValue.AddSeconds(-ConsentDurationSeconds))
        {
            throw new InvalidDataException("Rematch application time cannot represent its deadline.");
        }
    }

    private static void Validate(BattleRematchConsentDocument row, BattleResultDocument result,
        string[] players, DateTimeOffset now)
    {
        bool hasValidDates = row.CreatedUtc.Kind == DateTimeKind.Utc &&
            row.UpdatedUtc.Kind == DateTimeKind.Utc && row.ExpiresUtc.Kind == DateTimeKind.Utc &&
            row.CreatedUtc >= result.AcceptedUtc && row.CreatedUtc <= row.UpdatedUtc &&
            row.UpdatedUtc <= now.UtcDateTime &&
            row.ExpiresUtc.Ticks - row.CreatedUtc.Ticks == TimeSpan.FromSeconds(ConsentDurationSeconds).Ticks;
        if (row.Id != result.MatchId || row.ResultDigest != result.Digest ||
            row.Players == null || !row.Players.SequenceEqual(players) || row.AcceptedPlayers == null ||
            row.AcceptedPlayers.Length > players.Length ||
            !row.AcceptedPlayers.SequenceEqual(row.AcceptedPlayers.Distinct(StringComparer.Ordinal)
                .OrderBy(player => player, StringComparer.Ordinal)) ||
            row.AcceptedPlayers.Any(player => !players.Contains(player, StringComparer.Ordinal)) ||
            row.Revision is < 1 or long.MaxValue || !hasValidDates)
        {
            throw new InvalidDataException("The durable rematch consent is damaged.");
        }
        bool hasValidStatus = row.Status switch
        {
            Waiting => row.AcceptedPlayers.Length == 1 && row.UpdatedUtc < row.ExpiresUtc,
            Ready => row.AcceptedPlayers.Length == players.Length && row.UpdatedUtc < row.ExpiresUtc,
            Cancelled => row.UpdatedUtc < row.ExpiresUtc,
            Expired => row.AcceptedPlayers.Length >= 1 && row.UpdatedUtc >= row.ExpiresUtc,
            _ => false,
        };
        if (!hasValidStatus)
        {
            throw new InvalidDataException("The durable rematch consent status is inconsistent.");
        }
    }
}
