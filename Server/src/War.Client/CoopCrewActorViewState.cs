using War.Protocol;

namespace War.Client
{
    /// <summary>Contains immutable crew identity and health, without a collision or landing pose.</summary>
    public sealed class CoopCrewActorViewState
    {
        /// <summary>Gets the host's match-wide actor identity.</summary>
        public ulong EntityId { get; }

        /// <summary>Gets the original ordered source seat.</summary>
        public uint Slot { get; }

        /// <summary>Gets the recovered seat component identity.</summary>
        public int PointComponentFileId { get; }

        /// <summary>Gets the source-scaled maximum health.</summary>
        public float MaxHealth { get; }

        /// <summary>Gets current host health.</summary>
        public float Health { get; }

        /// <summary>Gets the confirmed creation tick.</summary>
        public ulong SpawnTick { get; }

        /// <summary>Gets the confirmed death tick, or zero while alive.</summary>
        public ulong DeathTick { get; }

        /// <summary>Gets whether the actor still belongs to its source seat.</summary>
        public bool IsAttached { get; }

        internal CoopCrewActorViewState(BattleCoopCrewActor source)
        {
            EntityId = source.EntityId;
            Slot = source.Slot;
            PointComponentFileId = source.PointComponentFileId;
            MaxHealth = source.MaxHealth;
            Health = source.Health;
            SpawnTick = source.SpawnTick;
            DeathTick = source.DeathTick;
            IsAttached = source.IsAttached;
        }
    }
}
