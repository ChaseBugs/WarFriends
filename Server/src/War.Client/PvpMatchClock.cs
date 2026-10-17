using System;
using System.IO;
using War.Protocol;

namespace War.Client
{
    /// <summary>Projects the host clock without inferring overtime or outcomes from local elapsed time.</summary>
    public readonly struct PvpMatchClock
    {
        private const ulong TicksPerSecond = 30;
        private const ulong MaximumDurationTicks = 1800 * TicksPerSecond;
        private const ulong PrestartDelayTicks = 2 * TicksPerSecond;

        /// <summary>Gets remaining simulation seconds; a paused host tick leaves this value unchanged.</summary>
        public float RemainingSeconds { get; }

        /// <summary>Gets confirmed overtime without deriving it from the displayed countdown.</summary>
        public bool IsOvertime { get; }

        private PvpMatchClock(ulong remainingTicks, bool isOvertime)
        {
            RemainingSeconds = (float)remainingTicks / TicksPerSecond;
            IsOvertime = isOvertime;
        }

        /// <summary>Validates the complete phase/clock tuple before exposing recovered PvP HUD values.</summary>
        public static PvpMatchClock FromSnapshot(MatchSnapshot snapshot)
        {
            if (snapshot == null)
            {
                throw new ArgumentNullException(nameof(snapshot));
            }

            if (snapshot.Coop != null || snapshot.Arena != null)
            {
                throw new InvalidDataException("The DeathMatch clock cannot project another mode's lifecycle.");
            }

            switch (snapshot.Phase)
            {
                case BattlePhase.Waiting:
                    Require(snapshot.StartTick == 0 && snapshot.EndTick == 0 && !snapshot.Overtime);
                    return new PvpMatchClock(0, false);
                case BattlePhase.Countdown:
                    Require(snapshot.StartTick > snapshot.ServerTick && !snapshot.Overtime);
                    Require(snapshot.StartTick - snapshot.ServerTick <= PrestartDelayTicks);
                    return ScheduledClock(snapshot, snapshot.StartTick);
                case BattlePhase.Running:
                    Require(snapshot.StartTick > 0 && snapshot.StartTick <= snapshot.ServerTick);
                    if (snapshot.Overtime)
                    {
                        Require(snapshot.EndTick == 0);
                        return new PvpMatchClock(0, true);
                    }

                    return ScheduledClock(snapshot, snapshot.ServerTick);
                case BattlePhase.Ended:
                    Require(snapshot.StartTick > 0 && snapshot.StartTick <= snapshot.ServerTick);
                    return TerminalClock(snapshot);
                case BattlePhase.Aborted:
                    // Cancellation can preserve the scheduled start while the match is still counting down.
                    if (snapshot.StartTick > snapshot.ServerTick)
                    {
                        Require(snapshot.StartTick - snapshot.ServerTick <= PrestartDelayTicks);
                    }

                    return TerminalClock(snapshot);
                default:
                    throw new InvalidDataException("Unknown DeathMatch clock phase.");
            }
        }

        private static PvpMatchClock TerminalClock(MatchSnapshot snapshot)
        {
            Require(snapshot.EndTick == snapshot.ServerTick);
            Require(!snapshot.Overtime || snapshot.StartTick > 0 && snapshot.StartTick <= snapshot.ServerTick);
            return new PvpMatchClock(0, snapshot.Overtime);
        }

        private static PvpMatchClock ScheduledClock(MatchSnapshot snapshot, ulong currentTick)
        {
            Require(snapshot.EndTick > snapshot.StartTick && snapshot.EndTick >= currentTick);
            ulong durationTicks = snapshot.EndTick - snapshot.StartTick;
            Require(durationTicks <= MaximumDurationTicks);
            return new PvpMatchClock(snapshot.EndTick - currentTick, false);
        }

        private static void Require(bool condition)
        {
            if (!condition)
            {
                throw new InvalidDataException("Inconsistent authoritative DeathMatch clock.");
            }
        }
    }
}
