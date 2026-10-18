using System.Numerics;
using War.BattleServer;
using War.Protocol;

/// <summary>Correlates ordinary grenade flights and physical player health loss with recovered blast rules.</summary>
internal static class OrdinaryGrenadierPlayerBlastTests
{
    private const ulong FirstSpawnTick = 61;
    private const ulong MaximumTick = 1800;
    private const float PlayerRadiusRatio = 0.7f;
    private const float ShieldProtectionThreshold = 0.01f;
    private const float DamageScale = 0.25f;
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
                new() { DamageScale = DamageScale });
            int option = host.ArmyBatch(OwnerId).OptionIndexes.First();
            Require(host.Command(OwnerId, new MatchCommand
            {
                CommandId = 3, DeployArmy = new() { OptionIndex = option }
            }).Code == "army-deploying", "Player blast fixture deployment failed.");
            host.Advance(FirstSpawnTick);
            ulong actorKey = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey;
            ArmyCardGrenadierRuntime setup = host.CardGrenadierThrow(actorKey) ??
                throw new InvalidOperationException("Ordinary grenade setup disappeared.");
            checks += ObservePlayerBlast(host, new Fixture(content, map, setup));
        }

        return checks;
    }

    private static int ObservePlayerBlast(MatchEngine host, Fixture fixture)
    {
        var launches = new Dictionary<ulong, ArmyGrenadeDamageStats>();
        var observedExplosions = new List<CardGrenadierExplosion>();
        ulong cursor = 0;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick)
        {
            MatchSnapshot before = host.Snapshot();
            PlayerCollisionModel victimPose = host.ArmyPlayerCollision(OpponentId);
            foreach (BattleProjectileState projectile in before.Projectiles.Where(row =>
                row.Kind == "card-grenadier" && row.OwnerPlayerId == OwnerId))
            {
                launches[projectile.ProjectileId] = host.CardGrenadierLaunchDamage(projectile.ProjectileId) ??
                    throw new InvalidOperationException("The published grenade lost frozen launch damage.");
            }

            host.Advance(before.ServerTick + 1);
            CardGrenadierExplosion[] explosions = host.CardGrenadierExplosions().ToArray();
            observedExplosions.AddRange(explosions);
            MatchEventBatch events = host.EventBatch(OwnerId, cursor);
            if (events.Events.Count > 0)
            {
                cursor = events.Events[^1].EventId;
            }

            MatchSnapshot after = host.Snapshot();
            float loss = Health(before, OpponentId) - Health(after, OpponentId);
            if (loss <= 0)
            {
                continue;
            }

            int checks = Require(explosions.Length == 1 && launches.ContainsKey(explosions[0].ProjectileId),
                "Player health loss must belong to one actual published ordinary grenade explosion.");
            CardGrenadierExplosion explosion = explosions[0];
            checks += Require(!events.Events.Any(item => item.Tick == explosion.Tick &&
                item.Kind == MatchEventKind.BarrelDestroyed),
                "A barrel chain cannot stand in for direct grenade damage.");
            checks += Require(events.Events.Any(item => item.Kind == MatchEventKind.Impact &&
                item.ProjectileId == explosion.ProjectileId && item.Tick == explosion.Tick),
                "Player blast outcome must have a matching physical Impact event.");
            float expected = ExpectedLoss(before, victimPose,
                (explosion.Position, launches[explosion.ProjectileId]), fixture);
            checks += Require(expected > 0 && Math.Abs(loss - expected) < Tolerance,
                "Physical player health loss differs from source radius, falloff, shield and player coefficients.");
            checks += Require(Health(after, OwnerId) == Health(before, OwnerId),
                "An enemy grenade blast changed the distant owner health control.");
            Console.WriteLine($"Ordinary grenade player blast: fuse {fixture.Setup.FuseSeconds}, " +
                $"loss {loss}, expected {expected}, tick {explosion.Tick}.");
            return checks;
        }

        throw new InvalidOperationException("Ordinary grenade never reached direct player damage: " +
            $"{host.Snapshot().TerminalReason}; positions=" +
            string.Join(";", observedExplosions.Take(3).Select(explosion => explosion.Position)));
    }

    private static float ExpectedLoss(MatchSnapshot before, PlayerCollisionModel pose,
        (Vector3 Position, ArmyGrenadeDamageStats Damage) blast, Fixture fixture)
    {
        (Vector3 position, ArmyGrenadeDamageStats damage) = blast;
        PlayerHitbox part = pose.Parts.Where(part => part.OverlapsSphere(position, fixture.Setup.OuterRadius))
            .OrderBy(part => part.BoundsDistanceToPoint(position)).ThenBy(part => part.SourcePath,
                StringComparer.Ordinal).First();
        float distance = part.BoundsDistanceToPoint(position);
        Require(distance <= fixture.Setup.OuterRadius * PlayerRadiusRatio,
            "A player outside the recovered scaled bounds gate cannot receive grenade damage.");
        float raw = damage.Explosion;
        if (distance >= fixture.Setup.InnerRadius * PlayerRadiusRatio)
        {
            BattlePlayerState victim = before.Players.Single(player => player.PlayerId == OpponentId);
            var root = new Vector3(victim.PositionX, victim.PositionY, victim.PositionZ);
            float weight = Math.Clamp(1f - (Vector3.Distance(position, root) - fixture.Setup.InnerRadius) /
                (fixture.Setup.OuterRadius - fixture.Setup.InnerRadius), 0f, 1f);
            raw = damage.Minimum + (damage.Explosion - damage.Minimum) * weight * weight;
        }

        var overlappingOwners = fixture.Map.DynamicSphereOverlaps(position, fixture.Setup.OuterRadius)
            .Select(collider => collider.DynamicOwner).ToHashSet(StringComparer.Ordinal);
        bool hasShield = before.Shields.Any(shield => !shield.Destroyed &&
            shield.Health / shield.MaxHealth > ShieldProtectionThreshold &&
            overlappingOwners.Contains(fixture.Map.Covers[shield.CoverIndex].SourcePath + "/riot_shield"));
        if (hasShield)
        {
            raw *= fixture.Setup.PlayerBehindShieldRatio;
        }

        return raw * fixture.Content.Army.PlayerDamagePolicy("ID_UNIT-GRENADIER").PlayerDamageRatio;
    }

    private static float Health(MatchSnapshot snapshot, string playerId)
    {
        return snapshot.Players.Single(player => player.PlayerId == playerId).Health;
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }

    private sealed record Fixture(BattleCombatContent Content, RecoveredBattleMap Map, ArmyCardGrenadierRuntime Setup);
}
