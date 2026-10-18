using System;

using War.Protocol;

namespace War.Shared
{
    /// <summary>Validates the host's ordinary Mortar world-pose observation before Unity can apply it.</summary>
    public static class MortarWeaponPosePolicy
    {
        private const ulong HandReturnTicks = 34;
        private const ulong MaximumTick = 10000000;
        private const float MaximumCoordinate = 10000f;
        private const float UnitTolerance = 0.001f;

        /// <summary>Checks identity, captured animation phase, observation lifetime and source transform bounds.</summary>
        public static bool IsValid(BattleArmyEntityState actor, ulong observedTick)
        {
            if (actor == null)
            {
                return false;
            }
            BattleMortarWeaponPose pose = actor.MortarWeaponPose;
            // Absence is the held state, including terminal actors whose last clip can still be hide.
            if (pose == null)
            {
                return true;
            }
            return actor.UnitId == "ID_UNIT-MORTAR" && actor.SourceCardId.Length == 0 &&
                actor.InfantryClip == "mortar_hide" && actor.InfantryClipStartTick == pose.PreparedTick &&
                pose.PreparedTick >= actor.SpawnTick && pose.PreparedTick <= MaximumTick - HandReturnTicks &&
                pose.HandReturnTick == pose.PreparedTick + HandReturnTicks && pose.ObservedTick == observedTick &&
                pose.PreparedTick <= observedTick && observedTick < pose.HandReturnTick &&
                Coordinate(pose.X) && Coordinate(pose.Y) && Coordinate(pose.Z) &&
                UnitScale(pose.ScaleX) && UnitScale(pose.ScaleY) && UnitScale(pose.ScaleZ) &&
                UnitRotation(pose.Rotation);
        }

        private static bool UnitRotation(BattleJointRotation rotation)
        {
            if (rotation == null || !Finite(rotation.X) || !Finite(rotation.Y) ||
                !Finite(rotation.Z) || !Finite(rotation.W))
            {
                return false;
            }
            float length = rotation.X * rotation.X + rotation.Y * rotation.Y +
                rotation.Z * rotation.Z + rotation.W * rotation.W;
            return Math.Abs(length - 1f) <= UnitTolerance;
        }

        private static bool UnitScale(float value)
        {
            return Finite(value) && Math.Abs(value - 1f) <= UnitTolerance;
        }

        private static bool Coordinate(float value)
        {
            return Finite(value) && Math.Abs(value) <= MaximumCoordinate;
        }

        private static bool Finite(float value)
        {
            return !float.IsNaN(value) && !float.IsInfinity(value);
        }
    }
}
