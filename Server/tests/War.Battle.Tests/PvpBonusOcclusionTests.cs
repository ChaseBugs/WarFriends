using System.Numerics;
using War.BattleServer;
using War.Protocol;

/// <summary>Replays a live RPG miss against source City geometry before changing cover.</summary>
internal static class PvpBonusOcclusionTests
{
    private const string WeaponId = "Google2u.Bazooka_RPG7";
    private const float ObservedBoxX = -0.86121786f;
    private const float ObservedBoxZ = -1.5879494f;
    private const ulong GroundedTick = 220;
    private const ulong FirstImpactDeadline = 600;
    private const ulong SecondImpactAllowance = 300;
    private const ulong RunningTick = 60;
    private const float SurfaceProbeOffset = 0.1f;
    private const float SurfaceMatchTolerance = 0.001f;

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleCombatContent.Load(
            Path.Combine(directory, "combat-content-manifest.json"),
            bazookaManifestPath: Path.Combine(directory, "bazooka-content-manifest.json"));
        MatchManifest template = MatchManifest.Read(Path.Combine(directory, "local-rifle-match-template.json"));
        RecoveredBattleMap map = content.Maps.Single(row => row.SourceHash == template.MapRevision);
        PvpBonusSpawnArea area = content.PvpBonusSpawnAreas.ForMap(map).First(row =>
            ObservedBoxX >= row.BoundsMin.X && ObservedBoxX <= row.BoundsMax.X &&
            ObservedBoxZ >= row.BoundsMin.Z && ObservedBoxZ <= row.BoundsMax.Z);
        Vector3 unitPosition = new(
            (ObservedBoxX - area.BoundsMin.X) / (area.BoundsMax.X - area.BoundsMin.X),
            1f,
            (ObservedBoxZ - area.BoundsMin.Z) / (area.BoundsMax.Z - area.BoundsMin.Z));
        MatchManifest manifest = CreateManifest(template, content);
        var match = new MatchEngine(manifest, map, content, combatRandom: () => 1f,
            bonusAreaChoice: _ => area.Order, bonusPositionDraw: () => unitPosition);
        Start(match, manifest);
        string ownerId = manifest.Players[0].PlayerId;
        IssueBox(match, ownerId);
        AdvanceTo(match, GroundedTick);
        PvpBonusBoxSnapshot box = match.BonusPlanner.ActiveBoxesSnapshot().Single();
        Require(box.Phase == PvpBonusBoxPhase.Grounded, "The observed crate must settle before the controlled shot.");
        Require(Hold(match, ownerId, box.Position, 2).Code == "bazooka-targeting", "The source RPG hold is accepted.");
        AdvanceTo(match, FirstImpactDeadline);
        MatchEvent impact = match.EventBatch(ownerId, 0).Events.Single(row =>
            row.Kind == MatchEventKind.Impact && row.Reason == "bazooka");
        Require(match.BonusPlanner.BoxSnapshot(box.BoxId).Phase == PvpBonusBoxPhase.Grounded,
            "The observed blocked RPG must not collect the crate through map geometry.");
        Require(Vector3.Distance(new Vector3(impact.X, impact.Y, impact.Z), box.Position) >
            content.Bazookas!.Binding(WeaponId).HurtRadius,
            "The observed missile impact must remain outside the crate's explosion radius.");
        Vector3 impactPosition = new(impact.X, impact.Y, impact.Z);
        Vector3 direction = Vector3.Normalize(box.Position - impactPosition);
        MapHit? barrier = map.Raycast(impactPosition - direction * SurfaceProbeOffset, direction,
            SurfaceProbeOffset * 2f, content.Bazookas.EnemiesBulletMask, dynamicEnabled: _ => false);
        Require(barrier != null && Vector3.Distance(barrier.Position, impactPosition) < SurfaceMatchTolerance,
            "The blocked impact must bind an actual source-static map surface.");

        MatchReply movement = match.Command(ownerId, new MatchCommand
        {
            CommandId = 3,
            MoveCover = new MoveCoverCommand { Direction = 1 }
        });
        Require(movement.Code == "moving", "The shooter can change to the next source cover.");
        ulong arrivalTick = movement.Snapshot.Players[0].MoveEndTick;
        AdvanceTo(match, arrivalTick);
        Require(Hold(match, ownerId, box.Position, 4).Code == "bazooka-targeting",
            "The repositioned shooter retains a real RPG round and can aim again.");
        AdvanceTo(match, arrivalTick + SecondImpactAllowance);
        Require(match.BonusPlanner.BoxSnapshot(box.BoxId).Phase == PvpBonusBoxPhase.Collected,
            "Changing cover must give the RPG a real path to the observed crate.");
        Console.WriteLine("PASS: 8 deterministic City RPG occlusion and cover-change checks; " + barrier!.SourcePath);
        return 8;
    }

    private static MatchManifest CreateManifest(MatchManifest template, BattleCombatContent content)
    {
        return template with
        {
            MatchId = "bonus-rpg-occlusion",
            Mode = MatchManifest.BazookaCombatMode,
            CatalogRevision = content.BazookaRevision!,
            SceneMasterPlayerId = template.Players[0].PlayerId,
            PvpBonusMode = MatchManifest.OrdinaryPvpBonusMode,
            PvpGoldBonusesAtAdmission = 0,
            Players = template.Players.Select(player => player with
            {
                PlayerLevel = 8,
                Weapon = content.Bazookas!.CreateManifest(WeaponId, 0),
                WeaponUpgrade = 0
            }).ToArray()
        };
    }

    private static void Start(MatchEngine match, MatchManifest manifest)
    {
        foreach (ParticipantManifest player in manifest.Players)
        {
            match.Admit(player.PlayerId);
            match.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 1,
                Ready = new ReadyCommand { ManifestHash = match.ManifestHash }
            });
        }

        AdvanceTo(match, RunningTick);
    }

    private static void IssueBox(MatchEngine match, string ownerId)
    {
        const int KevlarSourceIndex = 6;
        const int RequiredSkillShots = 3;
        const int QualifyingVehicleKill = 0x1210;
        match.BonusPlanner.EnqueueConfirmedBonus(Guid.NewGuid().ToString("N"), ownerId, KevlarSourceIndex);
        for (int index = 0; index < RequiredSkillShots; index++)
        {
            match.BonusProgress.RecordConfirmedSkillShot(
                ownerId, Guid.NewGuid().ToString("N"), QualifyingVehicleKill, 1f);
        }
    }

    private static MatchReply Hold(MatchEngine match, string ownerId, Vector3 target, ulong commandId)
    {
        return match.Command(ownerId, new MatchCommand
        {
            CommandId = commandId,
            BazookaHold = new BazookaHoldCommand
            {
                Pressed = true, TargetX = target.X, TargetY = target.Y, TargetZ = target.Z
            }
        });
    }

    private static void AdvanceTo(MatchEngine match, ulong targetTick)
    {
        for (ulong tick = match.Snapshot().ServerTick + 1; tick <= targetTick; tick++)
        {
            match.Advance(tick);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
