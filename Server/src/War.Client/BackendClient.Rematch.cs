using System.Threading;
using System.Threading.Tasks;
using War.Protocol;

namespace War.Client
{
    public sealed partial class BackendClient
    {
        /// <summary>Cancels this source's allocated match without touching a later search or match.</summary>
        public Task<MatchQueueReply> CancelAllocatedRematchAsync(
            string sourceMatchId, string token, CancellationToken cancellationToken)
        {
            return Send("v1/battle/rematch/cancel-allocation", new MatchGrantRequest { MatchId = sourceMatchId },
                token, MatchQueueReply.Parser, cancellationToken);
        }

        /// <summary>Allocates a mutually accepted rematch; fetch its separate fresh grant before connecting.</summary>
        public Task<MatchQueueReply> AllocateRematchAsync(
            string sourceMatchId, string token, CancellationToken cancellationToken)
        {
            return Send("v1/battle/rematch/allocate", new MatchGrantRequest { MatchId = sourceMatchId },
                token, MatchQueueReply.Parser, cancellationToken);
        }

        /// <summary>Reads the original participants' intent without consenting or extending the deadline.</summary>
        public Task<MatchRematchConsent> ReadRematchConsentAsync(
            string matchId, string token, CancellationToken cancellationToken)
        {
            return Send("v1/battle/rematch/read", new MatchGrantRequest { MatchId = matchId },
                token, MatchRematchConsent.Parser, cancellationToken);
        }

        /// <summary>Consents to the same opponent; ready intent is not a playable battle grant.</summary>
        public Task<MatchRematchConsent> AcceptRematchAsync(
            string matchId, string token, CancellationToken cancellationToken)
        {
            return Send("v1/battle/rematch/accept", new MatchGrantRequest { MatchId = matchId },
                token, MatchRematchConsent.Parser, cancellationToken);
        }

        /// <summary>Withdraws consent without modifying the completed battle's result.</summary>
        public Task<MatchRematchConsent> CancelRematchAsync(
            string matchId, string token, CancellationToken cancellationToken)
        {
            return Send("v1/battle/rematch/cancel", new MatchGrantRequest { MatchId = matchId },
                token, MatchRematchConsent.Parser, cancellationToken);
        }
    }
}
