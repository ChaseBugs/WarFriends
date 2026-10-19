namespace War.BattleServer;

public sealed partial class CoopMissionEngine
{
    /// <summary>Defers objective completion until one synchronous source death callback chain finishes.</summary>
    internal IDisposable BeginDeathCascade(ulong tick)
    {
        if (!Started || Outcome != MissionOutcome.InProgress || tick < StartTick || tick >= DeadlineTick)
        {
            throw new InvalidOperationException("Death cascade is outside the active mission window.");
        }

        objective.BeginDeathCascade();
        return new DeathCascadeScope(this);
    }

    private sealed class DeathCascadeScope : IDisposable
    {
        private CoopMissionEngine? _owner;

        internal DeathCascadeScope(CoopMissionEngine owner)
        {
            _owner = owner;
        }

        public void Dispose()
        {
            if (_owner == null)
            {
                return;
            }

            CoopMissionEngine owner = _owner;
            _owner = null;
            owner.objective.CompleteDeathCascade();
            if (owner.Outcome != MissionOutcome.InProgress)
            {
                owner.spawns.Finish();
            }
        }
    }
}
