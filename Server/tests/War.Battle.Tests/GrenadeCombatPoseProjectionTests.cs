using System.Numerics;
using System.Text.Json;
using War.BattleServer;
using War.Protocol;

/// <summary>Checks position-only compatibility and complete observed grenade poses against Unity samples.</summary>
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
        checks += CheckObservedRig(content, directory);
        return checks;
    }

    private static int CheckObservedRig(BattleCombatContent content, string directory)
    {
        using JsonDocument document = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory, "recovered-grenade-rig.json")));
        JsonElement source = document.RootElement;
        string[] weapons = source.GetProperty("weapons").EnumerateArray()
            .Select(row => row.GetProperty("sourceId").GetString()!).ToArray();
        Quaternion rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY, 0.7f);
        int checks = 0;
        foreach (JsonElement clip in source.GetProperty("clips").EnumerateArray())
        {
            string name = clip.GetProperty("name").GetString()!;
            int index = 0;
            foreach (JsonElement observed in clip.GetProperty("frames").EnumerateArray())
            {
                double duration = content.Grenades!.Poses.Duration(name);
                double start = index++ / (double)SampleRate;
                bool isLastFrame = index == clip.GetProperty("frames").GetArrayLength();
                double seconds = isLastFrame ? duration : start + Math.Min(0.125 / SampleRate, (duration - start) / 2);
                GrenadePoseFrame frame = content.Grenades!.Poses.Sample(name, seconds, false);
                PlayerCollisionModel collision = frame.Collision.Place(FirstRoot, rotation);
                PlayerAimPoseDetails details = content.GrenadeShotTargets!.PoseDetails(name, seconds, false, collision);
                var view = new PlayerAimPose(collision, new Dictionary<string, RifleMuzzlePose>(), details);
                Vector3 root = ReadPosition(observed.GetProperty("root"));
                JsonElement rootRotation = observed.GetProperty("root").GetProperty("rotation");
                var orientation = Quaternion.Normalize(new Quaternion(rootRotation[0].GetSingle(),
                    rootRotation[1].GetSingle(), rootRotation[2].GetSingle(), rootRotation[3].GetSingle()));
                Quaternion delta = Quaternion.Normalize(rotation * Quaternion.Inverse(orientation));
                for (int weaponIndex = 0; weaponIndex < weapons.Length; weaponIndex++)
                {
                    Vector3 expected = FirstRoot + Vector3.Transform(
                        ReadPosition(observed.GetProperty("weapons")[weaponIndex]) - root, delta);
                    Require(Vector3.Distance(view.WeaponRoot(weapons[weaponIndex]).Position, expected) <
                        PositionTolerance,
                        $"Weapon root differs: {name} frame {index} {weapons[weaponIndex]}: " +
                        $"{view.WeaponRoot(weapons[weaponIndex]).Position} vs {expected} at {seconds}.");
                    CheckRotation(view.WeaponRoot(weapons[weaponIndex]).Rotation,
                        observed.GetProperty("weapons")[weaponIndex], delta);
                    checks += 2;
                }

                IReadOnlyList<Vector3> targets = content.GrenadeShotTargets.Place(
                    name, seconds, false, FirstRoot, rotation);
                for (int targetIndex = 0; targetIndex < targets.Count; targetIndex++)
                {
                    PlayerShotTarget identity = content.PlayerShotTargets.Gameplay[targetIndex];
                    Require(Vector3.Distance(view.BodyTarget(identity.TransformFileId).Position,
                        targets[targetIndex]) < PositionTolerance,
                        $"Target differs: {name} frame {index} target {targetIndex}: " +
                        $"{view.BodyTarget(identity.TransformFileId).Position} vs {targets[targetIndex]}.");
                    CheckRotation(view.BodyTarget(identity.TransformFileId).Rotation,
                        observed.GetProperty("targets")[targetIndex], delta);
                    checks += 2;
                }

                Require(view.MovingTarget != null, "Observed type-16 target is missing from the common pose.");
                checks++;
            }
        }

        return checks;
    }

    private static Vector3 ReadPosition(JsonElement transform)
    {
        JsonElement position = transform.GetProperty("position");
        return new Vector3(position[0].GetSingle(), position[1].GetSingle(), position[2].GetSingle());
    }

    private static void CheckRotation(Quaternion actual, JsonElement transform, Quaternion delta)
    {
        JsonElement rotation = transform.GetProperty("rotation");
        var source = Quaternion.Normalize(new Quaternion(rotation[0].GetSingle(), rotation[1].GetSingle(),
            rotation[2].GetSingle(), rotation[3].GetSingle()));
        Quaternion expected = Quaternion.Normalize(delta * source);
        Require(Math.Abs(Quaternion.Dot(actual, expected)) > 0.99999f,
            "A placed grenade transform differs from the observed Unity rotation.");
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
        Require(release.MovingTarget != null && PlayerHitbox.Finite(release.WeaponRoot(Launcher).Position),
            "Runtime grenade projection omitted observed target or weapon-root authority.");
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
        return 4 + expected.Count + content.PlayerShotTargets.Gameplay.Count;
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
