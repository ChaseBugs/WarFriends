using System.Numerics;

namespace War.BattleServer;

/// <summary>Canonical event construction for newly authoritative server entities.
/// Callers cannot publish arbitrary RPC-shaped payloads.</summary>
public static class BattleEventFactory
{
    public static ClientBattleEvent Spawn(ulong sequence, ulong entityId, Vector3 position, string kind)
        => Create(sequence, entityId, position, "spawn:" + kind);
    public static ClientBattleEvent Despawn(ulong sequence, ulong entityId, Vector3 position, string kind)
        => Create(sequence, entityId, position, "despawn:" + kind);
    public static ClientBattleEvent Objective(ulong sequence, ulong entityId, Vector3 position, BattleObjectiveKind kind)
        => Create(sequence, entityId, position, "objective:" + kind);
    public static ClientBattleEvent Effect(ulong sequence, ulong entityId, Vector3 position, WarCardEffectKind kind)
        => Create(sequence, entityId, position, "effect:" + kind);

    private static ClientBattleEvent Create(ulong sequence, ulong entityId, Vector3 position, string kind)
    {
        var result = new ClientBattleEvent(sequence, kind, entityId, position);
        ClientBattleEventValidator.Validate(result);
        return result;
    }
}
