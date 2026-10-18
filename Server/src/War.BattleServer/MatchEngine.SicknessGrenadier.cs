using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    /// <summary>Reads the current grenade setup, separate from immutable card provenance.</summary>
    internal ArmyGrenadeDamageStats? CardGrenadierDamage(ulong entityKey)
    {
        return _cardGrenadierDamage.GetValueOrDefault(entityKey);
    }

    /// <summary>Reads frozen launch damage so later weapon changes cannot rewrite an airborne grenade.</summary>
    internal ArmyGrenadeDamageStats? CardGrenadierLaunchDamage(ulong projectileId)
    {
        return grenadierLaunches.GetValueOrDefault(projectileId)?.Damage;
    }

    /// <summary>Host-only grenade binding; full Sickness activation and vitality binding remain separate.</summary>
    internal bool ApplySicknessToCardGrenadierGrenade(ulong entityKey, SicknessSpawnWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);
        if (phase != BattlePhase.Running ||
            !activeArmyEntities.TryGetValue(entityKey, out var entity) ||
            entity.SourceCardId != "GREATGRENADIER" ||
            !_cardGrenadierDamage.TryGetValue(entityKey, out var damage))
        {
            return false;
        }

        // This source unit is an EnemyController. Its spawn Walk/Parachute and
        // subsequent Corner states all pass canBeFreezed; mechanical types do not enter here.
        var target = new SicknessSpawnTarget(entity.OwnerFraction, true, true);
        if (!window.ShouldAffect(target))
        {
            return false;
        }

        _cardGrenadierDamage[entityKey] = window.ApplyGrenadeDamage(target, damage);
        return true;
    }
}
