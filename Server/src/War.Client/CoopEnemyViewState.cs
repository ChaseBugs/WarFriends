using War.Protocol;

namespace War.Client
{
    /// <summary>Contains only the validated common fields needed to identify and place a co-op enemy visual.</summary>
    public sealed class CoopEnemyViewState
    {
        private readonly BattleJointRotation _rotation;

        /// <summary>Gets the host-owned entity identity.</summary>
        public ulong EntityId { get; }

        /// <summary>Gets the recovered behaviour identity without substituting an asset type.</summary>
        public string Behaviour { get; }

        /// <summary>Gets the source upgrade level.</summary>
        public int Level { get; }

        /// <summary>Gets the source scene spawn component identity.</summary>
        public int SpawnComponentFileId { get; }

        /// <summary>Gets the confirmed creation tick.</summary>
        public ulong SpawnTick { get; }

        /// <summary>Gets the confirmed body death tick, or zero while the body remains alive.</summary>
        public ulong DeathTick { get; }

        /// <summary>Gets whether source card interpolation owns the unit's appearance/upgrade lane.</summary>
        public bool IsCardUnit { get; }

        /// <summary>Gets the source card interpolation fraction.</summary>
        public float CardProgress { get; }

        /// <summary>Gets the host-confirmed maximum body health.</summary>
        public float MaxHealth { get; }

        /// <summary>Gets the host-confirmed body health.</summary>
        public float Health { get; }

        /// <summary>Gets whether the host has confirmed body death.</summary>
        public bool IsDead => Health == 0f;

        /// <summary>Gets the current host position's X coordinate.</summary>
        public float X { get; }

        /// <summary>Gets the current host position's Y coordinate.</summary>
        public float Y { get; }

        /// <summary>Gets the current host position's Z coordinate.</summary>
        public float Z { get; }

        /// <summary>Gets the tick owning the current pose.</summary>
        public ulong PoseTick { get; }

        /// <summary>Gets a copy of the optional host rotation; absence does not imply simulated facing.</summary>
        public BattleJointRotation Rotation => _rotation == null ? null : _rotation.Clone();

        internal CoopEnemyViewState(BattleCoopEnemySpawn source)
        {
            EntityId = source.EntityId;
            Behaviour = source.Behaviour;
            Level = source.Level;
            SpawnComponentFileId = source.SpawnComponentFileId;
            SpawnTick = source.SpawnTick;
            DeathTick = source.DeathTick;
            IsCardUnit = source.CardUnit;
            CardProgress = source.CardProgress;
            MaxHealth = source.MaxHealth;
            Health = source.Health;
            X = source.CurrentX;
            Y = source.CurrentY;
            Z = source.CurrentZ;
            PoseTick = source.PoseTick;
            _rotation = source.CurrentRotation == null ? null : source.CurrentRotation.Clone();
        }
    }
}
