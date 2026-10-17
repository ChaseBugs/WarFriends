using System;
using System.Linq;
using System.Text.RegularExpressions;
using War.Client;
using War.Protocol;

/// <summary>Validates rematch replies against the original completed two-player ownership scope.</summary>
internal static class SelfHostedRematchAuthority
{
    private const int ParticipantCount = 2;
    private const long MaximumUnixMilliseconds = 253402300799999L;

    internal static void RequireSource(MatchSnapshot source, string playerId)
    {
        if (source == null || source.Phase != BattlePhase.Ended || !IsMatchId(source.MatchId) ||
            source.Players.Count != ParticipantCount ||
            !source.Players.Any(player => player.PlayerId == playerId) ||
            source.Players.Select(player => player.PlayerId).Distinct(StringComparer.Ordinal)
                .Count() != ParticipantCount)
        {
            throw new InvalidOperationException("Rematch requires the original completed two-player snapshot.");
        }
        foreach (var player in source.Players)
        {
            if (!Guid.TryParseExact(player.PlayerId, "N", out _) ||
                player.PlayerId != player.PlayerId.ToLowerInvariant())
            {
                throw new InvalidOperationException("Rematch source participant identity is invalid.");
            }
        }
    }

    internal static void RequireConsent(MatchRematchConsent consent, string sourceMatchId, string[] players)
    {
        bool isEmpty = consent.Status == "not-requested";
        bool isAllocated = consent.Status == "allocated";
        bool hasKnownStatus = isEmpty || isAllocated || consent.Status == "waiting" || consent.Status == "ready" ||
            consent.Status == "cancelled" || consent.Status == "expired";
        if (consent.MatchId != sourceMatchId || !hasKnownStatus ||
            consent.AcceptedPlayerIds.Count > ParticipantCount ||
            consent.AcceptedPlayerIds.Distinct(StringComparer.Ordinal).Count() != consent.AcceptedPlayerIds.Count ||
            consent.AcceptedPlayerIds.Any(player => !players.Contains(player, StringComparer.Ordinal)) ||
            (isEmpty ? consent.Revision != 0 || consent.ExpiresUnixMilliseconds != 0 ||
                consent.AcceptedPlayerIds.Count != 0 : consent.Revision <= 0 || consent.Revision == long.MaxValue ||
                consent.ExpiresUnixMilliseconds <= 0 || consent.ExpiresUnixMilliseconds > MaximumUnixMilliseconds) ||
            (isAllocated ? !IsMatchId(consent.NextMatchId) || consent.NextMatchId == sourceMatchId :
                consent.NextMatchId.Length != 0) ||
            ((consent.Status == "ready" || isAllocated) && consent.AcceptedPlayerIds.Count != ParticipantCount) ||
            (consent.Status == "waiting" && consent.AcceptedPlayerIds.Count != 1))
        {
            throw new InvalidOperationException("Rematch consent differs from the original ownership scope.");
        }
    }

    internal static void RequireAllocation(MatchQueueReply reply, string sourceMatchId, string[] players)
    {
        if (reply.Code != "paired" || !IsMatchId(reply.MatchId) || reply.MatchId == sourceMatchId ||
            !reply.PlayerIds.OrderBy(player => player, StringComparer.Ordinal)
                .SequenceEqual(players.OrderBy(player => player, StringComparer.Ordinal)))
        {
            throw new InvalidOperationException(
                "The Backend did not allocate a fresh match for the source participants.");
        }
    }

    internal static void RequireGrant(MatchConnectionGrant grant, MatchQueueReply allocation, string playerId)
    {
        MatchConnection.ValidateGrantEnvelope(grant);
        var views = BattlePlayerViewProjection.Validate(grant);
        if (grant.MatchId != allocation.MatchId || grant.PlayerId != playerId || grant.SessionId == 0 ||
            grant.SessionKey.Length != 32 || grant.ExpiresUnixSeconds <= DateTimeOffset.UtcNow.ToUnixTimeSeconds() ||
            !views.Select(player => player.PlayerId).SequenceEqual(allocation.PlayerIds, StringComparer.Ordinal))
        {
            throw new InvalidOperationException("Rematch grant differs from the allocated local-player scope.");
        }
    }

    private static bool IsMatchId(string identity)
    {
        return identity != null && Regex.IsMatch(identity, @"\Am[0-9a-f]{32}\z");
    }
}
