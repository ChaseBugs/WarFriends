using System;

namespace War.Client
{
    /// <summary>
    /// The Worker no longer retains the requested combat events. Callers must
    /// rebuild presentation from an authoritative snapshot before moving their
    /// event cursor forward; replay alone cannot fill this gap.
    /// </summary>
    public sealed class MatchEventCursorExpiredException : InvalidOperationException
    {
        public ulong LatestEventId { get; }

        public MatchEventCursorExpiredException(ulong latestEventId)
            : base("The battle event cursor expired; a full snapshot is required.")
        {
            LatestEventId = latestEventId;
        }
    }
}
