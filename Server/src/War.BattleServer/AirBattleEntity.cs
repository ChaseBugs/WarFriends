using System.Numerics;

namespace War.BattleServer;

/// <summary>Match-owned air entity composition.  The match tick owns motion and
/// attack state; callers still provide only server-validated collision data.</summary>
public sealed class AirBattleEntity
{
    public ulong EntityKey { get; }
    public string AttackerPlayerId { get; }
    public ArmyAirMotionState Motion { get; }
    public ArmyAirAttackState Attack { get; }
    public AirEntityHealthState Health { get; }

    public AirBattleEntity(ulong entityKey, string attackerPlayerId,
        ArmyAirMotionState motion, ArmyAirAttackState attack, AirEntityHealthState? health = null)
    {
        if (entityKey == 0 || !Guid.TryParseExact(attackerPlayerId, "N", out _))
            throw new InvalidDataException("Invalid air entity identity.");
        EntityKey = entityKey; AttackerPlayerId = attackerPlayerId;
        Motion = motion ?? throw new ArgumentNullException(nameof(motion));
        Attack = attack ?? throw new ArgumentNullException(nameof(attack));
        Health = health ?? new AirEntityHealthState(1);
    }

    public void AdvanceTick() { Motion.AdvanceTick(); Attack.AdvanceTick(); }

    public bool TryBeginAttack(bool eligible, int windupTicks) =>
        Attack.TryBegin(eligible, windupTicks);

    public bool TryCommitShot() => Attack.CommitShot();

    internal ArmyAirPlayerImpact ResolveImpact(string victimPlayerId, Vector3 target,
        float maxRange, ShotCollision collision, float trustedDamage)
    {
        if (!Attack.ShotDue) throw new InvalidOperationException("Air shot is not due.");
        var intent = new ArmyAirShotIntent(EntityKey, AttackerPlayerId, victimPlayerId,
            target, maxRange, Attack.CurrentShotIsReal);
        return ArmyAirImpactResolver.Resolve(intent, collision, trustedDamage);
    }
}
