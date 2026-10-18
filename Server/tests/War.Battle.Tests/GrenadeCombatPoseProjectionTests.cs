using System.Numerics;
using War.BattleServer;
using War.Protocol;

/// <summary>Checks every exported grenade pose frame through the position-only common combat view.</summary>
internal static class GrenadeCombatPoseProjectionTests
{
    private const int SampleRate = 30;
    private const float PositionTolerance = 0.00001f;
    private static readonly Vector3 FirstRoot = new(2, 1, -3);
    private static readonly Vector3 SecondRoot = new(-4, 2, 5);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"),
            grenadeManifestPath: Path.Combine(directory, "grenade-content-manifest.json"));
        GrenadePoseCatalog poses = content.Grenades!.Poses;
        int checks = 0;
        foreach (string clip in poses.ClipNames)
        {
            int frameCount = (int)Math.Ceiling(poses.Duration(clip) * SampleRate) + 1;
            for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
            {
                double seconds = Math.Min((frameIndex + 0.125) / SampleRate, poses.Duration(clip));
                checks += CheckFrame(content, clip, seconds);
            }
        }
        checks += CheckRuntimeFrame(content);
        return checks;
    }

    private static int CheckRuntimeFrame(BattleCombatContent content)
    {
        const string Launcher = "Google2u.GrenadeLauncher_M320";
        var map = content.Maps.Single(candidate =>
            candidate.Source.Contains("City_Multiplayer", StringComparison.Ordinal));
        CoverNode[] covers = [map.Covers.First(cover => cover.Main && cover.Fraction == 1),
            map.Covers.First(cover => cover.Main && cover.Fraction == 2)];
        string owner = new('c', 32);
        var weapon = content.Grenades!.CreateManifest(Launcher, 0);
        var definition = new MatchManifest("grenade-common-view", "local-1",
            Path.GetFileNameWithoutExtension(map.Source),
            map.SourceHash, content.GrenadeRevision!, MatchManifest.GrenadeCombatMode, 10, 60, 120,
            [new(owner, weapon, 1, covers[0].SourceIndex, 1, new(1000), 0),
                new(new string('d', 32), weapon, 2, covers[1].SourceIndex, 1, new(1000), 0)]);
        var simulation = new GrenadeMatchSimulation(definition, map, content.Grenades);
        simulation.ConfigureShotTargets(content.GrenadeShotTargets!);
        PlayerAimPose initial = simulation.CombatPose(owner, content.PlayerShotTargets);
        Require(ReferenceEquals(initial, simulation.CombatPose(owner, content.PlayerShotTargets)),
            "Repeated collision reads rebuilt an unchanged grenade pose.");

        Vector3 target = covers[1].Position;
        var command = new GrenadeThrowCommand { TargetX = target.X, TargetY = target.Y, TargetZ = target.Z };
        GrenadeGesturePlan gesture = GrenadeGesturePlanner.Plan(content.Grenades.Binding(Launcher),
            content.Grenades.Poses, covers[0].Position, covers[0].Rotation, command, 0);
        ScheduledGrenadeLaunch launch = simulation.Begin(owner, command, 0)!;
        for (ulong tick = 0; tick <= launch.LaunchTick; tick++)
        {
            simulation.Advance(tick);
        }
        PlayerAimPose release = simulation.CombatPose(owner, content.PlayerShotTargets);
        Require(!ReferenceEquals(initial, release), "A throw reused the cached idle grenade pose.");
        double seconds = launch.LaunchTick / (double)MatchManifest.TickRate;
        IReadOnlyList<Vector3> expected = content.GrenadeShotTargets!.Place(gesture.WindupClip, seconds, false,
            covers[0].Position, covers[0].Rotation);
        IReadOnlyList<Vector3> legacyTargets = simulation.PlayerShotTargets(owner);
        for (int index = 0; index < expected.Count; index++)
        {
            int identity = content.PlayerShotTargets.Gameplay[index].TransformFileId;
            Require(release.BodyTargetPosition(identity) == expected[index] && legacyTargets[index] == expected[index],
                "Launch-tick targets advanced to the next clip before the collision and muzzle pose.");
        }
        simulation.Advance(launch.LaunchTick + 1);
        Require(!ReferenceEquals(release, simulation.CombatPose(owner, content.PlayerShotTargets)),
            "The next animation frame retained a stale common combat view.");
        PlayerAimPose rifle = content.Poses.SampleBlended("idle", 0, true, "idle", 0, true, 0);
        foreach (PlayerShotTarget identity in content.PlayerShotTargets.Gameplay)
        {
            Require(rifle.BodyTargetPosition(identity.TransformFileId) ==
                rifle.BodyTarget(identity.TransformFileId).Position,
                "The position query changed the existing rifle target path.");
        }
        return 3 + expected.Count + content.PlayerShotTargets.Gameplay.Count;
    }

    private static int CheckFrame(BattleCombatContent content, string clip, double seconds)
    {
        Quaternion firstRotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0.7f);
        GrenadePoseFrame source = content.Grenades!.Poses.Sample(clip, seconds, false);
        var frame = new GrenadePoseFrame(source.Seconds, source.Collision.Place(FirstRoot, firstRotation),
            source.Left.Place(FirstRoot, firstRotation), source.Right.ToDictionary(pair => pair.Key,
                pair => pair.Value.Place(FirstRoot, firstRotation), StringComparer.Ordinal));
        IReadOnlyList<Vector3> targets = content.GrenadeShotTargets!.Place(clip, seconds, false,
            FirstRoot, firstRotation);
        PlayerAimPose view = GrenadeCombatPoseProjection.Create(frame, targets, content.PlayerShotTargets);
        Require(view.Collision.Parts.SequenceEqual(frame.Collision.Parts),
            "The common combat view changed exported grenade collision parts.");
        Require(view.MovingTarget == null, "The common view invented an uncaptured moving target.");
        int checks = 2;
        for (int index = 0; index < targets.Count; index++)
        {
            int identity = content.PlayerShotTargets.Gameplay[index].TransformFileId;
            Require(view.BodyTargetPosition(identity) == targets[index], "A grenade target identity changed position.");
            Reject(() => view.BodyTarget(identity));
            checks += 2;
        }
        foreach (var muzzle in frame.Right)
        {
            Require(view.Muzzle(muzzle.Key) == muzzle.Value, "A grenade muzzle changed during common-view projection.");
            checks++;
        }

        checks += CheckRelocation(content, view, clip, seconds);
        Reject(() => view.BodyTargetPosition(-1));
        Reject(() => view.WeaponRoot(frame.Right.Keys.First()));
        return checks + 2;
    }

    private static int CheckRelocation(BattleCombatContent content, PlayerAimPose view, string clip, double seconds)
    {
        Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, -1.2f);
        PlayerAimPose relocated = view.Place(SecondRoot, rotation);
        IReadOnlyList<Vector3> expected = content.GrenadeShotTargets!.Place(clip, seconds, false, SecondRoot, rotation);
        for (int index = 0; index < expected.Count; index++)
        {
            int identity = content.PlayerShotTargets.Gameplay[index].TransformFileId;
            Require(Vector3.Distance(relocated.BodyTargetPosition(identity), expected[index]) < PositionTolerance,
                "Rigid placement left grenade target positions at their previous world coordinates.");
        }
        return expected.Count;
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidOperationException("The position-only pose exposed unsupported transform authority.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
