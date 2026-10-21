using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    // Explosion.MissileExplode checks shield coverage before it changes any
    // shield or barrel. The same saved overlap set owns the subsequent damage.
    private bool ApplyPvpBonusGrenadeMapExplosion(
        PvpBonusGrenadeExplosionQuote explosion, GrenadeStage stage, Player owner)
    {
        if (map == null) return false;
        Func<int, bool>? barrelEnabled = barrels == null ? null :
            index => barrels.ColliderEnabled(index);
        Func<int, int, int>? barrelLayer = barrels == null ? null :
            (index, sourceLayer) => barrels.RuntimeLayer(index, sourceLayer);
        var overlaps = map.DynamicSphereOverlaps(explosion.Position,
            stage.HurtRadius, uint.MaxValue, barrelEnabled, barrelLayer);
        var shieldRows = shields?.Snapshot();
        bool shieldNearPlayer = overlaps.Any(collider =>
        {
            if (shields?.IsLiveShield(collider.DynamicOwner) != true)
                return false;
            var cover = map.Covers.FirstOrDefault(value =>
                value.SourcePath + "/riot_shield" == collider.DynamicOwner);
            var row = shieldRows?.FirstOrDefault(value =>
                value.CoverIndex == cover?.SourceIndex);
            if (row == null || row.MaxHealth <= 0)
                throw new InvalidDataException("Bonus grenade shield lost host authority.");
            return row.Health / row.MaxHealth > 0.01f;
        });

        foreach (var collider in overlaps)
        {
            if (shields?.IsLiveShield(collider.DynamicOwner) == true)
            {
                // The Manager grenade has friendKill=0. The recovered
                // DestroyableObject base rejects same-faction weapon damage.
                var shieldCover = map.Covers.FirstOrDefault(value =>
                    value.SourcePath + "/riot_shield" == collider.DynamicOwner);
                if (shieldCover == null || shieldRows?.Any(value =>
                        value.CoverIndex == shieldCover.SourceIndex) != true)
                    throw new InvalidDataException("Bonus grenade shield lost host authority.");
                if (shieldCover.Fraction == owner.Definition.Fraction) continue;

                var hit = GrenadeExplosion.ResolveDynamic(explosion.Position,
                    collider, stage);
                var changed = shields.ApplyBonusGrenadeExplosion(collider.DynamicOwner,
                    owner.Definition.Fraction, hit.RawDamage, tick);
                if (changed == null) continue;
                stateRevision++;
                EmitShield(changed.Destroyed ? MatchEventKind.ShieldDestroyed :
                    MatchEventKind.ShieldDamaged, explosion.OwnerId,
                    changed, explosion.ProjectileId);
            }
            else if (barrels?.Contains(collider.ColliderIndex) == true)
            {
                var hit = GrenadeExplosion.ResolveDynamic(explosion.Position,
                    collider, stage);
                ApplyBarrelDamage(explosion.OwnerId, explosion.ProjectileId,
                    collider.ColliderIndex, hit.RawDamage,
                    hit.Kind == CombatDamageType.Explosion ?
                        BarrelChainCause.Explosion : BarrelChainCause.Shiver);
                if (Terminal) return shieldNearPlayer;
            }
        }

        return shieldNearPlayer;
    }
}
