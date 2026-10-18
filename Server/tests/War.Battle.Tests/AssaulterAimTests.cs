using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Checks both source lead stages, persistent weapon speed and an actual moving-player capture.</summary>
internal static class AssaulterAimTests
{
    private const float Tolerance = 0.0001f;
    private const int RandomScale = 1_000_000;
    private const ulong MaximumArrivalTick = 1800;
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = CheckWeaponState(content.CoopAssaulterWeapon);
        checks += CheckHostCapture(content);
        return checks;
    }

    private static int CheckWeaponState(CoopAssaulterWeaponCatalog source)
    {
        var weapon = new AssaulterWeaponAimState(source);
        var target = new Vector3(10f, 0f, 0f);
        AssaulterAimPrediction selected = weapon.SelectMovingPlayer(Vector3.Zero, target, Vector3.UnitX);
        int checks = Require(Near(selected.TargetPosition, new Vector3(12.2f, 0f, 0f)),
            "Initial moving selection lost distance/5 plus both 0.1-second pads.");

        AssaulterAimPrediction entityShot = weapon.StartEntityShot(Vector3.Zero, target, Vector3.UnitX);
        checks += Require(entityShot.Inputs.BulletSpeed == 15f && weapon.RealBulletSpeed == 15f &&
            Near(entityShot.TargetPosition, new Vector3(11.066667f, 0f, 0f)),
            "Entity shot-start did not set triple real speed before its 0.1+0.3-second prediction.");
        checks += Require(weapon.FakeBulletSpeed == 7.5f,
            "BulletSetup.speedMultiplayer incorrectly changed cosmetic bullet speed.");

        AssaulterAimPrediction next = weapon.SelectMovingPlayer(Vector3.Zero, target, Vector3.UnitX);
        checks += Require(next.Inputs.BulletSpeed == 15f &&
            Near(next.TargetPosition, new Vector3(10.866667f, 0f, 0f)),
            "The previous entity-shot multiplier was reset before the next target-selection stage.");
        AssaulterAimPrediction playerShot = weapon.StartPlayerShot(Vector3.UnitX,
            next.TargetPosition, Vector3.UnitX * 2f);
        checks += Require(playerShot.Inputs.BulletSpeed == 5f && weapon.RealBulletSpeed == 5f &&
            Near(playerShot.TargetPosition, new Vector3(15.613333f, 0f, 0f)),
            "Player callback did not use its current muzzle/velocity, latched prepared aim and reset real speed.");
        checks += Require(Near(selected.TargetPosition, new Vector3(12.2f, 0f, 0f)) &&
            selected.Inputs.BulletSpeed == 5f, "A later speed change rewrote an earlier captured prediction.");
        checks += CheckRejectedCallback(weapon);
        checks += Require(new AssaulterWeaponAimState(source).RealBulletSpeed == 5f && source.RealBulletSpeed == 5f,
            "One actor's mutable speed damaged the shared source binding or another actor.");
        return checks;
    }

    private static int CheckRejectedCallback(AssaulterWeaponAimState weapon)
    {
        try
        {
            weapon.StartEntityShot(Vector3.Zero, Vector3.UnitX, new Vector3(float.NaN));
        }
        catch (InvalidDataException)
        {
            return Require(weapon.RealBulletSpeed == 5f,
                "A rejected callback changed weapon speed before validating its prediction.");
        }

        throw new InvalidOperationException("Malformed callback velocity entered weapon authority.");
    }

    private static int CheckHostCapture(BattleCombatContent content)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        bool shouldChooseBody = false;
        int Draw(int maximum) => shouldChooseBody && maximum == RandomScale ? RandomScale - 1 : 0;
        MatchEngine host = GrenadierPrimaryDamageTests.CreateRealShotHost(content, map, Draw);
        int option = host.ArmyBatch(OpponentId).OptionIndexes.First();
        Require(host.Command(OpponentId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The moving-aim fixture failed its real normal deployment.");
        host.Advance(61);
        ulong actor = host.ArmyEntityBatch(OpponentId, 0, 0).Entities.Single().EntityKey;
        while (!host.Terminal && host.AssaulterCorner(actor) == null &&
            host.Snapshot().ServerTick < MaximumArrivalTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        Require(!host.Terminal && host.AssaulterCorner(actor) != null, "The source actor did not reach its Corner.");
        shouldChooseBody = true;
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, MoveCover = new() { Direction = 1 }
        }).Code == "moving", "The moving-aim fixture failed its real player movement command.");
        host.Advance(host.Snapshot().ServerTick + 1);
        host.Advance(host.Snapshot().ServerTick + 1);
        return CheckCapturedPrediction(host, actor, content);
    }

    private static int CheckCapturedPrediction(MatchEngine host, ulong actor, BattleCombatContent content)
    {
        AssaulterPreparedAim captured = host.CaptureAssaulterAim(actor) ??
            throw new InvalidOperationException("The moving source player produced no prepared aim.");
        AssaulterAimPrediction prediction = captured.MovingPrediction ??
            throw new InvalidOperationException("The fixed player movement did not select a Moving transform.");
        int checks = Require(captured.ActorEntityKey == actor &&
            captured.AcquisitionTick == host.Snapshot().ServerTick &&
            captured.Target.IsPlayer && captured.Target.ShotTargetType == 16,
            "The capture lost its actor, source target type or acquisition tick.");
        checks += Require(prediction.Inputs.Velocity.LengthSquared() > 0f &&
            prediction.Inputs.Velocity == host.MovingPlayerVelocity(OwnerId),
            "Moving prediction did not use actual host-observed player motion.");
        float seconds = Vector3.Distance(prediction.Inputs.Muzzle, captured.Target.TransformPosition) / 5f + 0.2f;
        checks += Require(Near(captured.TargetPosition,
            captured.Target.TransformPosition + seconds * prediction.Inputs.Velocity),
            "The actual host capture lost the current muzzle and two source selection pads.");
        checks += CheckMuzzle(host, actor, prediction.Inputs.Muzzle, content);
        Vector3 latched = captured.TargetPosition;
        host.Advance(host.Snapshot().ServerTick + 1);
        checks += Require(captured.TargetPosition == latched,
            "Subsequent player animation rewrote the captured prediction.");
        checks += Require(host.ConfirmArmyDeath(actor, false) && host.AssaulterAimWeapon(actor) == null,
            "Host-confirmed death retained mutable Assaulter weapon aim authority.");
        return checks;
    }

    private static int CheckMuzzle(MatchEngine host, ulong actor, Vector3 muzzle, BattleCombatContent content)
    {
        BattleArmyEntityState entity = host.ArmyEntityBatch(OpponentId, 0, 0).Entities.Single(row =>
            row.EntityKey == actor);
        MatchEngine.ArmyInfantryPoseSnapshot pose = host.InfantryPose(actor) ??
            throw new InvalidOperationException("The actual source actor lost its current rig pose.");
        float yaw = MathF.Atan2(pose.Facing.X, pose.Facing.Z);
        float seconds = (host.Snapshot().ServerTick - pose.StartTick) / (float)MatchManifest.TickRate;
        CoopMuzzlePose expected = content.CoopEnemyMuzzles.Place(pose.Clip, new Vector3(entity.X, entity.Y, entity.Z),
            Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw), seconds);
        return Require(Near(muzzle, expected.Position),
            "Acquisition used a root/rest/future firing point instead of the current sampled source muzzle.");
    }

    private static bool Near(Vector3 actual, Vector3 expected)
    {
        return Vector3.Distance(actual, expected) < Tolerance;
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
