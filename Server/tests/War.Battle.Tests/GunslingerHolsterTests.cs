using System.Security.Cryptography;
using System.Text.Json;

using Google.Protobuf;

using War.BattleServer;
using War.Client;
using War.Protocol;

/// <summary>Checks native coroutine ticks, authoritative attachment state and its protobuf/SDK boundary.</summary>
internal static class GunslingerHolsterTests
{
    private const string UnitId = "ID_UNIT-GUNSLINGER";
    private const string NativeRevision = "4da42424b0f539a4f42c11cc37df83cde1fc1d62d645bd638bbad1e42b0154c9";
    private const ulong MaximumTick = 2400;
    private static readonly string OwnerId = new('b', 32);

    internal static int Run(string directory)
    {
        int checks = CheckNativeClock(directory);
        checks += CheckSdkBoundary();
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        checks += CheckLifecycle(content);
        checks += CheckCancelledTimer(content);
        return checks;
    }

    private static int CheckNativeClock(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "gunslinger-holster-unity-reference.json"));
        int checks = Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == NativeRevision,
            "Native Gunslinger holster evidence revision changed.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        foreach (JsonElement row in document.RootElement.GetProperty("observations").EnumerateArray())
        {
            checks += Require(GunslingerFiringClock.HolsterTick(row.GetProperty("scheduledTick").GetUInt64()) ==
                row.GetProperty("callbackTick").GetUInt64(),
                "The one-second holster coroutine differs from its native callback tick.");
        }

        return checks;
    }

    private static int CheckSdkBoundary()
    {
        var valid = new BattleArmyEntityState { UnitId = UnitId, IsColtHolstered = true };
        BattleArmyEntityState decoded = BattleArmyEntityState.Parser.ParseFrom(valid.ToByteArray());
        int checks = Require(decoded.IsColtHolstered && MatchConnection.IsValidColtAttachment(decoded),
            "The normal Gunslinger holster field did not survive protobuf and SDK validation.");
        decoded.UnitId = "ID_UNIT-ASSAULT";
        checks += Require(!MatchConnection.IsValidColtAttachment(decoded),
            "The SDK accepted a Gunslinger-only attachment flag on another unit.");
        decoded.UnitId = UnitId;
        decoded.SourceCardId = "unreviewed-card";
        checks += Require(!MatchConnection.IsValidColtAttachment(decoded),
            "A normal Gunslinger attachment flag widened the card-unit allowlist.");
        decoded.IsColtHolstered = false;
        checks += Require(MatchConnection.IsValidColtAttachment(decoded),
            "The default omitted protobuf field broke another attachment path.");
        return checks;
    }

    private static int CheckLifecycle(BattleCombatContent content)
    {
        var (host, actor) = Deploy(content);
        int checks = Require(Entity(host, actor).IsColtHolstered,
            "A newly walking Gunslinger did not retain StartEnemyBehaviour's SnapColt(true).");
        AdvanceUntil(host, () => host.GunslingerState(actor) != null);
        checks += Require(!Entity(host, actor).IsColtHolstered,
            "Source Gunslinger entry did not move its weapon back to the hand.");
        AdvanceUntil(host, () => host.GunslingerState(actor)?.ShotsRemaining == 0 &&
            host.GunslingerAttempt(actor)?.CompletedTick.HasValue == true);
        GunslingerShotAttempt attempt = host.GunslingerAttempt(actor) ??
            throw new InvalidOperationException("The holster fixture lost its completed source burst.");
        ulong due = GunslingerFiringClock.HolsterTick(attempt.PollTick);
        AdvanceUntil(host, () => host.Snapshot().ServerTick >= due - 1);
        checks += Require(!Entity(host, actor).IsColtHolstered,
            "Gunslinger holstered before its one-second coroutine callback.");
        host.Advance(due);
        checks += Require(Entity(host, actor).IsColtHolstered,
            "Gunslinger did not holster on its verified source callback tick.");
        float speed = host.GunslingerAimWeapon(actor)?.RealBulletSpeed ??
            throw new InvalidOperationException("Attachment state lost current weapon speed.");
        AdvanceUntil(host, () => host.GunslingerState(actor) == null);
        checks += Require(Entity(host, actor).IsColtHolstered && Entity(host, actor).InfantryClip == "colt_run",
            "An exhausted moving Gunslinger silently unsnapped its holstered weapon.");
        AdvanceUntil(host, () => host.GunslingerState(actor) != null);
        checks += Require(!Entity(host, actor).IsColtHolstered &&
            host.GunslingerAimWeapon(actor)?.RealBulletSpeed == speed,
            "A new point did not restore hand attachment or changed weapon speed through presentation state.");
        return checks;
    }

    private static int CheckCancelledTimer(BattleCombatContent content)
    {
        var (host, actor) = Deploy(content);
        AdvanceUntil(host, () => host.GunslingerState(actor)?.ShotsRemaining == 0 &&
            host.GunslingerAttempt(actor)?.CompletedTick.HasValue == true);
        GunslingerShotAttempt attempt = host.GunslingerAttempt(actor) ??
            throw new InvalidOperationException("The death fixture lost its final shot.");
        ulong due = GunslingerFiringClock.HolsterTick(attempt.PollTick);
        int checks = Require(host.ConfirmArmyDeath(actor, false), "The holster fixture failed source death cleanup.");
        AdvanceUntil(host, () => host.Snapshot().ServerTick > due);
        checks += Require(host.ArmyEntityBatch(OwnerId, 0, 0).Entities.All(row => row.EntityKey != actor),
            "A cancelled holster callback recreated a removed entity or left a live timer without an owner.");
        return checks;
    }

    private static (MatchEngine Host, ulong Actor) Deploy(BattleCombatContent content)
    {
        MatchEngine host = OrdinaryArmyTestHost.Create(content, UnitId);
        int option = host.ArmyBatch(OwnerId).OptionIndexes.First(index => content.Army.Option(index).Count == 1);
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The attachment fixture failed real ordinary deployment.");
        host.Advance(61);
        return (host, host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey);
    }

    private static BattleArmyEntityState Entity(MatchEngine host, ulong actor)
    {
        return host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(row => row.EntityKey == actor);
    }

    private static void AdvanceUntil(MatchEngine host, Func<bool> completed)
    {
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && !completed())
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        Require(!host.Terminal && completed(),
            "Gunslinger attachment fixture stopped: " + host.Snapshot().TerminalReason);
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
