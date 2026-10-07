using System;
using War.Protocol;

namespace War.Client
{
    /// <summary>
    /// An unresolved local mutation kept across a replacement UDP session.
    /// Only MatchConnection can create it, and its command bytes are copied.
    /// </summary>
    public sealed class MatchPendingCommand
    {
        internal string MatchId { get; }
        internal string ManifestHash { get; }
        internal string PlayerId { get; }
        internal MatchCommand Command { get; }
        public ulong CommandId { get { return Command.CommandId; } }

        internal MatchPendingCommand(string matchId, string manifestHash,
            string playerId, MatchCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            MatchId = matchId;
            ManifestHash = manifestHash;
            PlayerId = playerId;
            Command = command.Clone();
        }
    }
}
