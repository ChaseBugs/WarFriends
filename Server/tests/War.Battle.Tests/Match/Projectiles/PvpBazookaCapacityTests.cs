using System.Numerics;
using System.Reflection;
using War.Battle.Tests.Match.Tracing;
using War.BattleServer;
using static War.Battle.Tests.Match.Projectiles.PvpBazookaFixture;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpBazookaCapacityTests
{
    internal static int Run()
    {
        using MatchEngineTrace rpg = Started("rpg-resource-count");
        Launch(rpg);
        Require(rpg.Engine.PendingProjectileCount == rpg.Engine.Snapshot().Projectiles.Count,
            "C30: the shared projectile budget omitted an active RPG missile.");
        using MatchEngineTrace m202 = Started("m202-resource-reservation", M202);
        ulong launch = Launch(m202);
        Require(m202.Engine.PendingProjectileCount == 4,
            "C30: the M202 budget omitted its primary active missile.");
        AdvanceThrough(m202, launch + 12);
        Require(m202.Engine.PendingProjectileCount == m202.Engine.Snapshot().Projectiles.Count &&
            m202.Engine.PendingProjectileCount > 0,
            "C30: delayed launch consumption lost still-active missile reservations.");
        CheckAdmissionAtSharedLimit();
        return 3;
    }

    private static void CheckAdmissionAtSharedLimit()
    {
        using MatchEngineTrace trace = Started("shared-budget-refuses-new-bazooka");
        Vector3 origin = trace.Engine.CombatPose(First).Collision.RootPosition;
        Vector3 far = origin + Vector3.Normalize(Target(trace) - origin) * 40 + Vector3.UnitY * 20;
        Require(Hold(trace, First, 2, far).Code == "bazooka-targeting", "The capacity fixture lost its first aim.");
        ulong launch = AdvanceToFirstShot(trace);
        FieldInfo field = typeof(MatchEngine).GetField("_playerBullets",
            BindingFlags.Instance | BindingFlags.NonPublic)!;
        var occupants = (PvpPlayerBulletSystem)field.GetValue(trace.Engine)!;
        // Controlled host flights occupy the other slots. No network caller can install this factory state.
        for (int index = 0; index < MatchEngine.MaximumProjectiles - 1; index++)
        {
            ulong id = 900_000 + (ulong)index;
            var flight = new BulletFlight(id, First, new(0.01f, 0, true), Vector3.Zero, Vector3.UnitZ, launch,
                (_, _, _) => null);
            occupants.AddReal(id, new(flight, new(1, CombatDamageType.Shot), "Google2u.AssaultRifle_AK47"));
        }
        int initialClip = trace.Engine.Snapshot().Players[1].ClipAmmo;
        Vector3 target = trace.Engine.CombatPose(First).Collision.Parts[1].Center;
        Require(Hold(trace, Second, 2, target).Code == "bazooka-targeting", "The second capacity hold was refused.");
        AdvanceThrough(trace, launch + 40);
        Require(trace.Engine.PendingProjectileCount == MatchEngine.MaximumProjectiles &&
            trace.Engine.Snapshot().Players[1].ShotsFired == 0 &&
            trace.Engine.Snapshot().Players[1].ClipAmmo == initialClip,
            "C30: a full shared budget admitted another missile or spent its ammunition.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
