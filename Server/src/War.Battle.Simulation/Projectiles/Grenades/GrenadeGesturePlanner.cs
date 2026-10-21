using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

// The recovered player weapons use two different inputs: a swipe for thrown
// grenades and a world target for the M320. Both produce a host-owned launch
// tick after the source animation windup.
internal sealed record GrenadeGesturePlan(
    Vector3 Target, bool Right, string WindupClip, ulong LaunchTick);

internal static class GrenadeGesturePlanner
{
    internal static GrenadeGesturePlan Plan(
        GrenadeBinding binding, GrenadePoseCatalog poses,
        Vector3 playerPosition, Quaternion coverRotation,
        GrenadeThrowCommand command, ulong currentTick)
    {
        ArgumentNullException.ThrowIfNull(binding);
        ArgumentNullException.ThrowIfNull(poses);
        ArgumentNullException.ThrowIfNull(command);
        if (!PlayerHitbox.Finite(playerPosition))
            throw new InvalidDataException("Invalid grenade player position.");

        Vector3 target;
        bool right;
        string clip;
        double windupSeconds;

        if (binding.Swipe)
        {
            if (!command.Swipe || !CanonicalZero(command.TargetX) ||
                !CanonicalZero(command.TargetY) ||
                !CanonicalZero(command.TargetZ))
                throw new InvalidDataException(
                    "Swipe grenade requires canonical input.");

            GrenadeThrowPlan swipe = GrenadeThrowPlanner.Plan(
                binding, playerPosition, coverRotation,
                new Vector3(command.SwipeStartX, command.SwipeStartY,
                    command.SwipeStartZ),
                new Vector3(command.SwipeEndX, command.SwipeEndY,
                    command.SwipeEndZ), command.HeldSeconds);
            target = swipe.Target;
            right = swipe.Right;
            clip = right ? "throw_grenade_left" : "throw_grenade_right";
            windupSeconds = binding.FirstShotWaitSeconds;
        }
        else
        {
            if (command.Swipe || !CanonicalZero(command.SwipeStartX) ||
                !CanonicalZero(command.SwipeStartY) ||
                !CanonicalZero(command.SwipeStartZ) ||
                !CanonicalZero(command.SwipeEndX) ||
                !CanonicalZero(command.SwipeEndY) ||
                !CanonicalZero(command.SwipeEndZ) ||
                !CanonicalZero(command.HeldSeconds))
                throw new InvalidDataException(
                    "Launcher requires canonical target input.");

            target = new Vector3(command.TargetX, command.TargetY,
                command.TargetZ);
            Vector3 direction = target - playerPosition;
            Vector3 planarDirection = new(direction.X, 0, direction.Z);
            if (!PlayerHitbox.Finite(target) ||
                direction.LengthSquared() < 1e-10f ||
                planarDirection.LengthSquared() < 1e-10f)
                throw new InvalidDataException("Invalid launcher target.");

            Vector3 forward = Vector3.Transform(Vector3.UnitZ,
                coverRotation);
            right = Vector3.Dot(Vector3.UnitY,
                Vector3.Cross(forward, planarDirection)) > 0;
            clip = right ? "player_look_left_grenadelauncher" :
                "player_look_right_grenadelauncher";
            windupSeconds = poses.Duration(clip) * 0.25;
        }

        ulong windupTicks = Math.Max(1,
            (ulong)Math.Ceiling(windupSeconds * MatchManifest.TickRate));
        return new GrenadeGesturePlan(target, right, clip,
            checked(currentTick + windupTicks));
    }

    private static bool CanonicalZero(float value) =>
        BitConverter.SingleToInt32Bits(value) == 0;
}
