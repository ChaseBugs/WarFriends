namespace War.BattleServer;

public enum PlayerAnimationState { Idle, Walk, Run, Aim, Fire, Reload, Dead }

/// <summary>Authoritative animation state gate used by hitbox/muzzle sampling.
/// Presentation clips remain Client-owned, but illegal gameplay transitions are
/// rejected server-side.</summary>
public sealed class PlayerAnimationStateMachine
{
    public PlayerAnimationState State { get; private set; } = PlayerAnimationState.Idle;
    public bool TryTransition(PlayerAnimationState next)
    {
        if (State == PlayerAnimationState.Dead) return false;
        if (next == State) return true;
        if (next == PlayerAnimationState.Dead) { State = next; return true; }
        bool legal = State switch
        {
            PlayerAnimationState.Idle => next is PlayerAnimationState.Walk or PlayerAnimationState.Run or PlayerAnimationState.Aim or PlayerAnimationState.Fire or PlayerAnimationState.Reload,
            PlayerAnimationState.Walk => next is PlayerAnimationState.Idle or PlayerAnimationState.Run or PlayerAnimationState.Aim or PlayerAnimationState.Fire,
            PlayerAnimationState.Run => next is PlayerAnimationState.Idle or PlayerAnimationState.Walk,
            PlayerAnimationState.Aim => next is PlayerAnimationState.Idle or PlayerAnimationState.Walk or PlayerAnimationState.Fire or PlayerAnimationState.Reload,
            PlayerAnimationState.Fire => next is PlayerAnimationState.Idle or PlayerAnimationState.Aim or PlayerAnimationState.Reload,
            PlayerAnimationState.Reload => next is PlayerAnimationState.Idle or PlayerAnimationState.Aim,
            _ => false
        };
        if (!legal) return false;
        State = next; return true;
    }
}
