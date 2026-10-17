namespace War.Persistence;

public sealed partial class BattleRematchConsentStore
{
    private static long NextRevision(long current)
    {
        if (current >= long.MaxValue - 1)
        {
            throw new InvalidDataException("Rematch revision capacity is exhausted.");
        }
        return current + 1;
    }

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
            row.NextMatchId == null || row.NextCompatibilityKey == null ||
            row.Revision is < 1 or long.MaxValue || !hasValidDates)
        {
            throw new InvalidDataException("The durable rematch consent is damaged.");
        }
        bool hasValidStatus = row.Status switch
        {
            Waiting => row.AcceptedPlayers.Length == 1 && row.UpdatedUtc < row.ExpiresUtc,
            Ready => row.AcceptedPlayers.Length == players.Length && row.UpdatedUtc < row.ExpiresUtc,
            Allocated => row.AcceptedPlayers.Length == players.Length && row.UpdatedUtc < row.ExpiresUtc &&
                row.NextMatchId != row.Id && System.Text.RegularExpressions.Regex.IsMatch(
                    row.NextMatchId, @"\Am[0-9a-f]{32}\z") && System.Text.RegularExpressions.Regex.IsMatch(
                    row.NextCompatibilityKey, @"\A[a-zA-Z0-9_.:-]{1,128}\z"),
            Cancelled => row.UpdatedUtc < row.ExpiresUtc,
            Expired => row.AcceptedPlayers.Length >= 1 && row.UpdatedUtc >= row.ExpiresUtc,
            _ => false,
        };
        if (!hasValidStatus || row.Status != Allocated &&
            (row.NextMatchId.Length != 0 || row.NextCompatibilityKey.Length != 0))
        {
            throw new InvalidDataException("The durable rematch consent status is inconsistent.");
        }
    }
}
