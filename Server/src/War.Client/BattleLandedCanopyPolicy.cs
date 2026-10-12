using System;
using War.Protocol;

namespace War.Client
{
    internal static class BattleLandedCanopyPolicy
    {
        internal static void Validate(MatchSnapshot snapshot)
        {
            if (snapshot.LandedCanopies.Count > 10000)
                throw new InvalidOperationException("Too many landed canopies in a battle snapshot.");

            ulong priorEntityKey = 0;
            foreach (BattleLandedCanopyState canopy in snapshot.LandedCanopies)
            {
                if (canopy.EntityKey <= priorEntityKey ||
                    canopy.LandingTick > snapshot.ServerTick ||
                    snapshot.ServerTick - canopy.LandingTick >= 90 ||
                    !Finite(canopy.X) || !Finite(canopy.Y) || !Finite(canopy.Z) ||
                    !ValidRotation(canopy.Rotation))
                    throw new InvalidOperationException("Invalid landed canopy in a battle snapshot.");
                priorEntityKey = canopy.EntityKey;
            }
        }

        private static bool ValidRotation(BattleJointRotation rotation)
        {
            if (rotation == null || !Finite(rotation.X) || !Finite(rotation.Y) ||
                !Finite(rotation.Z) || !Finite(rotation.W)) return false;
            float magnitudeSquared = rotation.X * rotation.X +
                rotation.Y * rotation.Y + rotation.Z * rotation.Z +
                rotation.W * rotation.W;
            return Math.Abs(magnitudeSquared - 1f) <= .001f;
        }

        private static bool Finite(float value)
        {
            return !float.IsNaN(value) && !float.IsInfinity(value);
        }
    }
}
