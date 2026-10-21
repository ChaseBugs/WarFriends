namespace War.BattleServer;

/// <summary>Source completion target choice; this does not execute movement or establish combat eligibility.</summary>
internal abstract record CoopHelicopterExitTarget;

internal sealed record CoopHelicopterEnemyTarget(CoopAssignedEnemyDestination Destination)
    : CoopHelicopterExitTarget;

internal sealed record CoopHelicopterFallbackTarget(CoopSpawnPoint Spawn) : CoopHelicopterExitTarget
{
    // Core_BaseScript.InvokeAfter uses WaitForSeconds, not the realtime coroutine variant.
    internal const float RetryDelayScaledSeconds = 5f;
}
