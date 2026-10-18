using System.Numerics;
using War.BattleServer;
using War.Protocol;

/// <summary>Checks real ordinary grenade contact, fuse and shield damage without injecting explosions.</summary>
internal static class OrdinaryGrenadierExplosionTests
{
    private const ulong FirstSpawnTick = 61;
    private const ulong MaximumTick = 1800;
    // A trusted fixture scale exposes uncapped shield arithmetic without changing any production policy.
    private const float ReducedDamageScale = 0.25f;
    private const float Tolerance = 0.002f;
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(BattleCombatContent content)
    {
        int checks = 0;
        foreach (var selection in new (int Normal, int Special, int Elite)[]
        {
            (0, -1, -1), (39, 101, -1), (39, 126, 127)
        })
        {
            RecoveredBattleMap map = content.Maps.Single(candidate =>
                candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
            MatchEngine host = OrdinaryGrenadierSpawnTests.CreateHost(content, map, selection,
                new() { DamageScale = ReducedDamageScale });
            int option = host.ArmyBatch(OwnerId).OptionIndexes.First();
            Require(host.Command(OwnerId, new MatchCommand
            {
                CommandId = 3, DeployArmy = new() { OptionIndex = option }
            }).Code == "army-deploying", "Ordinary explosion deployment failed.");
            host.Advance(FirstSpawnTick);
            BattleArmyEntityState actor = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single();
            Require(actor.SourceCardId.Length == 0, "The explosion fixture must use an ordinary actor.");
            ArmyCardGrenadierRuntime setup = host.CardGrenadierThrow(actor.EntityKey) ??
                throw new InvalidOperationException("An ordinary spawn lost its grenade setup.");
            checks += ObserveExplosion(host, (content, map, setup));
            if (selection.Normal == 0)
            {
                checks += Require(host.Snapshot().Shields.Any(shield => shield.OwnerFraction == 2 &&
                    shield.Health > 0 && shield.Health < shield.MaxHealth),
                    "The basic grenade case must prove uncapped damage, not only shield destruction.");
            }
        }

        return checks;
    }

    private static int ObserveExplosion(MatchEngine host,
        (BattleCombatContent Content, RecoveredBattleMap Map, ArmyCardGrenadierRuntime Setup) fixture)
    {
        var launches = new Dictionary<ulong, ArmyGrenadeDamageStats>();
        var contacts = new Dictionary<ulong, ulong>();
        var explosions = new List<CardGrenadierExplosion>();
        ulong cursor = 0;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick)
        {
            MatchSnapshot before = host.Snapshot();
            foreach (BattleProjectileState projectile in before.Projectiles.Where(row =>
                row.Kind == "card-grenadier" && row.OwnerPlayerId == OwnerId))
            {
                launches[projectile.ProjectileId] = host.CardGrenadierLaunchDamage(projectile.ProjectileId) ??
                    throw new InvalidOperationException("A published ordinary grenade lost frozen launch damage.");
                if (host.GrenadierFirstContactTick(projectile.ProjectileId) is { } contact)
                {
                    contacts[projectile.ProjectileId] = contact;
                }
            }

            host.Advance(before.ServerTick + 1);
            explosions.AddRange(host.CardGrenadierExplosions());
            MatchEventBatch batch = host.EventBatch(OwnerId, cursor);
            if (batch.Events.Count > 0)
            {
                cursor = batch.Events[^1].EventId;
            }

            foreach (MatchEvent hit in batch.Events.Where(item =>
                item.Kind is MatchEventKind.ShieldDamaged or MatchEventKind.ShieldDestroyed &&
                item.TargetId == OpponentId && launches.ContainsKey(item.ProjectileId)))
            {
                CardGrenadierExplosion explosion = explosions.Single(item => item.ProjectileId == hit.ProjectileId);
                ulong fuseTicks = (ulong)MathF.Ceiling(fixture.Setup.FuseSeconds * MatchManifest.TickRate);
                int checks = Require(contacts.TryGetValue(hit.ProjectileId, out ulong contactTick) &&
                    explosion.Tick == contactTick + fuseTicks,
                    "Ordinary grenade explosion must follow its first contact and composed source fuse.");
                checks += CheckShield(before, (hit, explosion, launches[hit.ProjectileId]), fixture);
                Console.WriteLine($"Ordinary grenade: fuse {fixture.Setup.FuseSeconds}, " +
                    $"contact {contactTick}, explosion {explosion.Tick}, shield health {hit.Health}.");
                return checks;
            }
        }

        throw new InvalidOperationException("Ordinary grenade never damaged a shield: " +
            $"{host.Snapshot().TerminalReason}; " +
            $"explosions={explosions.Count}; positions=" +
            string.Join(";", explosions.Take(3).Select(item => item.Position)));
    }

    private static int CheckShield(MatchSnapshot before,
        (MatchEvent Hit, CardGrenadierExplosion Explosion, ArmyGrenadeDamageStats Damage) observed,
        (BattleCombatContent Content, RecoveredBattleMap Map, ArmyCardGrenadierRuntime Setup) fixture)
    {
        (MatchEvent hit, CardGrenadierExplosion explosion, ArmyGrenadeDamageStats damage) = observed;
        string owner = fixture.Map.Covers[hit.ShieldCoverIndex].SourcePath + "/riot_shield";
        MapDynamicCollider collider = fixture.Map.DynamicSphereOverlaps(explosion.Position, fixture.Setup.OuterRadius)
            .Where(row => row.DynamicOwner == owner)
            .OrderBy(row => Vector3.Distance(explosion.Position,
                Vector3.Clamp(explosion.Position, row.BoundsMin, row.BoundsMax)))
            .ThenBy(row => row.ColliderIndex).First();
        float closest = Vector3.Distance(explosion.Position,
            Vector3.Clamp(explosion.Position, collider.BoundsMin, collider.BoundsMax));
        float raw = damage.Explosion;
        if (closest >= fixture.Setup.InnerRadius)
        {
            float distance = Vector3.Distance(explosion.Position, collider.TransformPosition);
            float weight = Math.Clamp(1f - (distance - fixture.Setup.InnerRadius) /
                (fixture.Setup.OuterRadius - fixture.Setup.InnerRadius), 0f, 1f);
            raw = damage.Minimum + (damage.Explosion - damage.Minimum) * weight * weight;
        }

        float previousHealth = before.Shields.Single(shield => shield.CoverIndex == hit.ShieldCoverIndex).Health;
        float expected = Math.Min(previousHealth,
            raw * fixture.Content.Shields.ExplosionCoefficient * fixture.Content.Shields.UnitToShieldCoefficient);
        int checks = Require(expected > 0 && Math.Abs(previousHealth - hit.Health - expected) < Tolerance,
            "Actual ordinary grenade shield loss differs from source falloff and shield coefficients.");
        checks += Require(hit.Tick == explosion.Tick,
            "Shield damage must belong to the exact physical explosion tick.");
        return checks;
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }
}
