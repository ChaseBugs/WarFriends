using System;
using System.Collections.Generic;
using War.Protocol;

namespace War.Shared
{
    /// <summary>Validates a bounded, frozen observer projection independently of live projectile membership.</summary>
    public static class MortarWarningPolicy
    {
        private const int SourceCapacity = 4;
        private const ulong MaximumTick = 10_000_000;
        private const float MaximumCoordinate = 100_000f;
        private const float MaximumStopSeconds = 1800f;
        private const float MinimumScale = 0.65f;
        private const float MaximumScale = 1.5f;
        private const float MaximumAlpha = 0.35f;
        private const float SampleTolerance = 0.00001f;
        private const float SourceShrinkLeadSeconds = 0.3f;

        /// <summary>Rejects mixed observers, unordered slots, duplicate launches and malformed sampled values.</summary>
        public static void Validate(IReadOnlyList<BattleMortarWarningState> rows, ulong snapshotTick, int? observerFraction)
        {
            if (rows == null || rows.Count > SourceCapacity || snapshotTick > MaximumTick ||
                rows.Count > 0 && observerFraction != 1 && observerFraction != 2)
            {
                throw new InvalidOperationException("Invalid Mortar warning scan authority.");
            }
            int previousSlot = -1;
            var actors = new HashSet<ulong>();
            var projectiles = new HashSet<ulong>();
            foreach (BattleMortarWarningState row in rows)
            {
                Guid owner;
                if (row == null || !Guid.TryParseExact(row.OwnerPlayerId, "N", out owner) ||
                    row.OwnerPlayerId != owner.ToString("N") || row.OwnerFraction < 1 || row.OwnerFraction > 2 ||
                    row.ObserverFraction != observerFraction || row.OwnerFraction == row.ObserverFraction ||
                    row.WeaponSlot <= previousSlot || row.WeaponSlot >= SourceCapacity ||
                    row.EntityKey >> 32 != (ulong)row.OwnerFraction || (uint)row.EntityKey == 0 ||
                    !actors.Add(row.EntityKey) || row.ProjectileId == 0 || !projectiles.Add(row.ProjectileId) ||
                    row.LaunchTick == 0 || row.LaunchTick > row.ObservedTick || row.ObservedTick != snapshotTick ||
                    !Bounded(row.X, -MaximumCoordinate, MaximumCoordinate) ||
                    !Bounded(row.Y, -MaximumCoordinate, MaximumCoordinate) ||
                    !Bounded(row.Z, -MaximumCoordinate, MaximumCoordinate) ||
                    !Bounded(row.StopSeconds, float.Epsilon, MaximumStopSeconds) ||
                    !Bounded(row.RotationFactor, 0f, 1f) ||
                    !Bounded(row.Scale, MinimumScale - SampleTolerance, MaximumScale + SampleTolerance) ||
                    !Bounded(row.Alpha, -SampleTolerance, MaximumAlpha + SampleTolerance))
                {
                    throw new InvalidOperationException("Malformed or observer-incompatible Mortar warning.");
                }
                previousSlot = row.WeaponSlot;
                MortarIndicatorClock clock = MortarIndicatorClock.FromCheckpoint(row.Clock);
                float duration = StoredSingle(row.StopSeconds - SourceShrinkLeadSeconds);
                float expectedSpeed = duration > 0f ? StoredSingle(1f / duration) : 0f;
                if (!clock.IsVisible || !row.Clock.HasBegun || row.Clock.ShrinkSpeed != expectedSpeed ||
                    clock.RotationFactor != row.RotationFactor || clock.Scale != row.Scale || clock.Alpha != row.Alpha)
                {
                    throw new InvalidOperationException("Warning sample disagrees with its source clock checkpoint.");
                }
            }
        }

        private static bool Bounded(float value, float minimum, float maximum)
        {
            return !float.IsNaN(value) && !float.IsInfinity(value) && value >= minimum && value <= maximum;
        }

        private static float StoredSingle(float value)
        {
            // Mono can retain extra precision between subtraction and division. Source
            // NGUI stores duration/rate in float fields; preserve those binary32 boundaries.
            return BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
        }
    }
}
