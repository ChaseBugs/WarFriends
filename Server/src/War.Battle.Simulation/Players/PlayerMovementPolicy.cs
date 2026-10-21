using System.Numerics;

namespace War.BattleServer;

public static class PlayerMovementPolicy
{
    public static Vector3 ValidateStep(Vector3 previous, Vector3 next, PlayerAnimationState state, float maxSpeed)
    {
        if (!PlayerHitbox.Finite(previous) || !PlayerHitbox.Finite(next) ||
            !float.IsFinite(maxSpeed) || maxSpeed <= 0 || maxSpeed > 20 ||
            !Enum.IsDefined(state)) throw new InvalidDataException("Invalid player movement.");
        float multiplier = state switch
        {
            PlayerAnimationState.Run => 1.5f,
            PlayerAnimationState.Walk => 1f,
            PlayerAnimationState.Aim => .5f,
            PlayerAnimationState.Idle or PlayerAnimationState.Reload or PlayerAnimationState.Fire => .25f,
            _ => 0f
        };
        if (state == PlayerAnimationState.Dead) throw new InvalidDataException("Dead players cannot move.");
        float distance = Vector3.Distance(previous, next);
        if (!float.IsFinite(distance) || distance > maxSpeed * multiplier / MatchManifest.TickRate + .001f)
            throw new InvalidDataException("Player movement exceeds authoritative tick speed.");
        return next;
    }
}
