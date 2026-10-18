using Google.Protobuf;
using War.BattleServer;
using War.Protocol;
using War.Protocol.Transport;
using War.Shared;

/// <summary>Checks sampled warning validation and packet sizing independently of active projectile count.</summary>
internal static class MortarWarningWireTests
{
    private const ulong SnapshotTick = 100;
    private static readonly string OwnerId = new('a', 32);

    internal static int Run()
    {
        BattleMortarWarningState valid = Warning(0);
        MortarWarningPolicy.Validate([valid], SnapshotTick, 2);
        var mutations = new Action<BattleMortarWarningState>[]
        {
            row => row.OwnerPlayerId = "invalid",
            row => row.OwnerFraction = 2,
            row => row.ObserverFraction = 1,
            row => row.WeaponSlot = -1,
            row => row.WeaponSlot = 4,
            row => row.EntityKey = 0,
            row => row.ProjectileId = 0,
            row => row.LaunchTick = SnapshotTick + 1,
            row => row.ObservedTick = SnapshotTick - 1,
            row => row.X = float.NaN,
            row => row.StopSeconds = float.PositiveInfinity,
            row => row.StopSeconds = 0,
            row => row.RotationFactor = -1,
            row => row.Scale = 2,
            row => row.Alpha = 1
        };
        foreach (Action<BattleMortarWarningState> mutate in mutations)
        {
            BattleMortarWarningState damaged = valid.Clone();
            mutate(damaged);
            Reject(() => MortarWarningPolicy.Validate([damaged], SnapshotTick, 2));
        }
        Reject(() => MortarWarningPolicy.Validate([valid], SnapshotTick, null));
        Reject(() => MortarWarningPolicy.Validate([valid, valid.Clone()], SnapshotTick, 2));
        var duplicateActor = Warning(1);
        duplicateActor.EntityKey = valid.EntityKey;
        Reject(() => MortarWarningPolicy.Validate([valid, duplicateActor], SnapshotTick, 2));
        Require(BattleMortarWarningState.Parser.ParseFrom(valid.ToByteArray()).Equals(valid),
            "Warning sample lost authority in protobuf serialization.");
        return mutations.Length + 4 + CheckPages();
    }

    private static int CheckPages()
    {
        BattleMortarWarningState[] warnings = Enumerable.Range(0, 4).Select(Warning).ToArray();
        var rows = Enumerable.Range(1, 128).Select(index => new BattleProjectileState
        {
            ProjectileId = (ulong)index, OwnerPlayerId = OwnerId, Kind = "card-rocket",
            ArmyUnitId = "ID_UNIT-MORTAR", X = index, Y = 1, Z = 1
        }).ToArray();
        ulong cursor = 0;
        int received = 0;
        int checks = 0;
        bool hasMore;
        do
        {
            var batch = new MatchProjectileBatch { MatchId = "warning-wire", ManifestHash = new string('a', 64) };
            batch.MortarWarnings.AddRange(warnings.Select(row => row.Clone()));
            var envelope = new Packet { Version = 1, SessionId = 1, Sequence = 1 };
            MatchEndpoint.PageProjectiles(batch, 1, SnapshotTick, rows, cursor, envelope);
            Require(PacketCodec.Encode(envelope, new byte[32]).Length <= PacketCodec.MaximumDatagramBytes &&
                batch.MortarWarnings.SequenceEqual(warnings), "Warning metadata broke page bounds or frozen identity.");
            received += batch.Projectiles.Count;
            cursor = batch.Projectiles[^1].ProjectileId;
            hasMore = batch.HasMore;
            checks++;
        }
        while (hasMore);
        Require(received == rows.Length, "Warnings caused projectile rows to disappear across pages.");
        var empty = new MatchProjectileBatch();
        empty.MortarWarnings.Add(warnings[0].Clone());
        var emptyEnvelope = new Packet { Version = 1, SessionId = 1, Sequence = 1 };
        MatchEndpoint.PageProjectiles(empty, 1, SnapshotTick, [], 0, emptyEnvelope);
        Require(empty.Projectiles.Count == 0 && !empty.HasMore && empty.MortarWarnings.Count == 1,
            "A warning incorrectly required an active projectile.");
        return checks + 2;
    }

    private static BattleMortarWarningState Warning(int slot)
    {
        return new BattleMortarWarningState
        {
            EntityKey = (1UL << 32) | (uint)(slot + 1), OwnerPlayerId = OwnerId,
            OwnerFraction = 1, ObserverFraction = 2, WeaponSlot = slot, ProjectileId = (ulong)slot + 1,
            LaunchTick = 60, ObservedTick = SnapshotTick, X = 1, Y = 1, Z = 1,
            StopSeconds = 2, Scale = 1.2f, Alpha = 0.3f, RotationFactor = 0.5f
        };
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidOperationException)
        {
            return;
        }
        throw new InvalidOperationException("Malformed warning authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
