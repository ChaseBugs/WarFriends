using System;
using System.Net;
using System.Text.RegularExpressions;

using War.Protocol;

namespace War.Client
{
    public sealed partial class MatchConnection
    {
        private const int SessionKeyBytes = 32;
        private const int MinimumTicketCharacters = 10;
        private const int MaximumTicketCharacters = 1024;
        private const int MaximumIdentityCharacters = 64;
        private const uint MaximumPort = 65535;
        private const long LatestGrantExpirySeconds = 253402300679L;

        /// <summary>Checks the transport envelope without creating or connecting a UDP socket.</summary>
        public static void ValidateGrantEnvelope(MatchConnectionGrant candidate)
        {
            if (candidate == null)
            {
                throw new ArgumentNullException(nameof(candidate));
            }
            War.Shared.BattleMapIdentity.ValidateOptional(candidate.MapId, candidate.MapRevision);
            IPAddress address;
            if (!IPAddress.TryParse(candidate.Host, out address) || candidate.Port == 0 ||
                candidate.Port > MaximumPort ||
                candidate.SessionId == 0 || candidate.SessionKey.Length != SessionKeyBytes ||
                candidate.Ticket.Length < MinimumTicketCharacters ||
                candidate.Ticket.Length > MaximumTicketCharacters ||
                candidate.MatchId.Length < 1 || candidate.MatchId.Length > MaximumIdentityCharacters ||
                !War.Shared.CanonicalGuid.IsCanonical(candidate.PlayerId) ||
                !Regex.IsMatch(candidate.ManifestHash, @"\A[0-9a-f]{64}\z") ||
                candidate.ExpiresUnixSeconds <= DateTimeOffset.UtcNow.ToUnixTimeSeconds() ||
                candidate.ExpiresUnixSeconds > LatestGrantExpirySeconds)
            {
                throw new ArgumentException(
                    "Invalid match grant. An IP endpoint and unexpired capability are required.");
            }
        }
    }
}
