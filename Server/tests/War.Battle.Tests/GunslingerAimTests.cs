using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Checks Colt lead stages, persistent speed, base-batch draws and normal deployment ownership.</summary>
internal static class GunslingerAimTests
{
    private const string UnitId = "ID_UNIT-GUNSLINGER";
    private const float Tolerance = 0.0001f;
    private static readonly string OwnerId = new('a', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = CheckPredictionStages();
        checks += CheckBaseBatchDraws();
        checks += CheckInvalidAuthority();
        checks += CheckHostOwnership(content);
        return checks;
    }

    private static int CheckPredictionStages()
    {
        var weapon = new GunslingerWeaponAimState(5f);
        GunslingerAimPrediction selection = weapon.SelectMovingPlayer(Vector3.Zero,
            new Vector3(10f, 0f, 0f), Vector3.UnitX);
        int checks = Require(Near(selection.TargetPosition.X, 12.2f),
            "Colt selection lost distance/speed and the two source 0.1-second terms.");

        // The target moves after acquisition. The callback receives that new raw
        // transform, rather than feeding selection.TargetPosition into another lead.
        GunslingerAimPrediction player = weapon.StartPlayerShot(Vector3.UnitX,
            new Vector3(20f, 0f, 0f), Vector3.UnitX * 2f);
        checks += Require(player.Inputs.BulletSpeed == 2.5f && weapon.RealBulletSpeed == 2.5f &&
            Near(player.TargetPosition.X, 35.4f),
            "Colt callback lost current target/muzzle, half player speed or zero extra callback lead.");
        GunslingerAimPrediction next = weapon.SelectMovingPlayer(Vector3.Zero,
            new Vector3(10f, 0f, 0f), Vector3.UnitX);
        checks += Require(next.Inputs.BulletSpeed == 2.5f && Near(next.TargetPosition.X, 14.2f),
            "Moving acquisition reset the previous player callback speed multiplier.");
        GunslingerAimPrediction entity = weapon.StartEntityShot(Vector3.Zero,
            new Vector3(10f, 0f, 0f), Vector3.UnitX);
        checks += Require(entity.Inputs.BulletSpeed == 5f && Near(entity.TargetPosition.X, 12.1f),
            "An entity callback used Assaulter triple speed or its 0.3-second extra lead.");
        checks += Require(selection.Inputs.BulletSpeed == 5f && Near(selection.TargetPosition.X, 12.2f),
            "A later callback mutated the captured acquisition inputs.");
        return checks;
    }

    private static int CheckBaseBatchDraws()
    {
        var source = new ArmyBaseShotStats(0.5f, 3, 5, 1f, 2f);
        int rolls = 0;
        CoopInfantryShotBatch batch = GunslingerShotBatchPolicy.Create(source, width =>
        {
            Require(width == 2, "Gunslinger changed the original exclusive batch range.");
            return 1;
        }, () => ++rolls == 1 ? 0.75f : 0.25f);
        int checks = Require(batch.Count == 1 && batch.RealShotMask == 0 && rolls == 4,
            "Gunslinger skipped base real/fake draws or used a later real bit for its single shot.");
        rolls = 0;
        batch = GunslingerShotBatchPolicy.Create(source, _ => 0, () => ++rolls == 1 ? 0.25f : 0.75f);
        checks += Require(batch.Count == 1 && batch.RealShotMask == 1 && rolls == 3,
            "The forced one-shot batch did not preserve bit zero after all base draws.");
        rolls = 0;
        batch = GunslingerShotBatchPolicy.Create(new(0.5f, 16, 17, 1f, 2f), _ => 0, () =>
        {
            rolls++;
            return 0.25f;
        });
        checks += Require(batch.Count == 1 && batch.RealShotMask == 1 && rolls == 14,
            "Gunslinger did not consume the base fourteen-round clamp before forcing one round.");
        return checks;
    }

    private static int CheckInvalidAuthority()
    {
        var weapon = new GunslingerWeaponAimState(5f);
        int checks = Reject(() => new GunslingerWeaponAimState(float.NaN));
        checks += Reject(() => new GunslingerWeaponAimState(0f));
        checks += Reject(() => weapon.StartPlayerShot(Vector3.Zero, Vector3.UnitX, new Vector3(float.NaN)));
        checks += Require(weapon.RealBulletSpeed == 5f,
            "Rejected Colt callback changed the actor's speed before validation.");
        checks += Reject(() => GunslingerShotBatchPolicy.Create(new(0.5f, 3, 5, 1f, 2f),
            _ => 0, () => float.PositiveInfinity));
        return checks;
    }

    private static int CheckHostOwnership(BattleCombatContent content)
    {
        MatchEngine host = OrdinaryArmyTestHost.Create(content, UnitId);
        int option = host.ArmyBatch(OwnerId).OptionIndexes.First(index => content.Army.Option(index).Count == 2);
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The Colt aim fixture failed actual normal deployment.");
        host.Advance(61);
        ulong actor = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.First().EntityKey;
        GunslingerWeaponAimState weapon = host.GunslingerAimWeapon(actor) ??
            throw new InvalidOperationException("Normal Gunslinger lost its match-owned weapon state.");
        int checks = Require(weapon.RealBulletSpeed == content.Army.EffectiveInfantryBulletSpeed(UnitId, 1f),
            "Normal Colt speed did not use the source ArmyUpgrades row.");
        GunslingerPreparedAim aim = host.CaptureGunslingerAim(actor) ??
            throw new InvalidOperationException("Normal Gunslinger could not capture its source player target.");
        checks += Require(aim.ActorEntityKey == actor && aim.AcquisitionTick == 61 && aim.Target.IsPlayer,
            "Gunslinger acquisition lost actor, tick or current player fallback.");
        checks += CheckSiblingState(content, host, actor, weapon);
        checks += Require(host.ConfirmArmyDeath(actor, false) && host.GunslingerAimWeapon(actor) == null,
            "Authoritative death retained mutable Colt weapon state.");
        checks += Reject(() => content.Army.EffectiveInfantryBulletSpeed(UnitId, float.NaN));
        checks += Reject(() => content.Army.EffectiveInfantryBulletSpeed("ID_UNIT-TANK", 1f));
        return checks;
    }

    private static int CheckSiblingState(BattleCombatContent content, MatchEngine host, ulong actor,
        GunslingerWeaponAimState weapon)
    {
        const ulong MaximumSpawnTick = 180;
        while (!host.Terminal && host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Count < 2 &&
            host.Snapshot().ServerTick < MaximumSpawnTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        Require(!host.Terminal && host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Count == 2,
            "The source deployment did not deliver its second scheduled Gunslinger.");
        ulong sibling = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.First(row => row.EntityKey != actor).EntityKey;
        weapon.StartPlayerShot(Vector3.Zero, Vector3.UnitX, Vector3.Zero);
        int checks = Require(host.GunslingerAimWeapon(sibling)?.RealBulletSpeed ==
            content.Army.EffectiveInfantryBulletSpeed(UnitId, 1f),
            "One Gunslinger callback changed another actor's speed state.");
        checks += Require(content.Army.EffectiveInfantryBulletSpeed(UnitId, 2f) ==
            content.Army.EffectiveInfantryBulletSpeed(UnitId, 1f) * 2f,
            "The source infantry speed ignored its trusted perk coefficient.");
        return checks;
    }

    private static bool Near(float actual, float expected)
    {
        return MathF.Abs(actual - expected) < Tolerance;
    }

    private static int Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return 1;
        }

        throw new InvalidOperationException("Invalid Colt prediction or batch authority was accepted.");
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
