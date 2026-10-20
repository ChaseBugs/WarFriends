using System.Numerics;
using War.BattleServer;

/// <summary>Verifies source hidden-state flags, float deadlines and secondary card progression.</summary>
internal static class TransportCrewPointEntryTests
{
    internal static int Run(string directory, BattleCombatContent content)
    {
        const float ControllerTime = 1.25f;
        var shot = new ArmyBaseShotStats(1, 1, 1, 2, 4);
        var obstacle = new TransportCrewPointEntry(Context(CoopInfantryPointState.ObstacleHiding, ControllerTime),
            shot, new TransportCrewPointEntry.RandomDraws(1, 19, 1));
        Require(obstacle.IsAgentStopped && obstacle.IsCrawling && !obstacle.IsHidingBehindCorner &&
            obstacle.AnimationClip == "stand_up_crawl" && obstacle.NextShootTime == 5.25f &&
            obstacle.NextEnemyChangeTime == 20.25f && obstacle.NextRepositionTime == 5.25f &&
            obstacle.CornerTweenPosition == null && obstacle.CornerTweenDuration == null,
            "Obstacle entry changed source flags, clip or scaled deadlines.");
        var corner = new TransportCrewPointEntry(Context(CoopInfantryPointState.CornerHiding, ControllerTime),
            shot, new TransportCrewPointEntry.RandomDraws(0, 10, null));
        Require(corner.IsAgentStopped && !corner.IsCrawling && corner.IsHidingBehindCorner &&
            corner.AnimationClip == "idle_1" && corner.NextShootTime == 3.25f &&
            corner.NextEnemyChangeTime == 11.25f && corner.NextRepositionTime == null &&
            corner.CornerTweenPosition == new Vector3(1, 7, 3) &&
            corner.CornerTweenLookDirection == -Vector3.UnitZ && corner.CornerTweenDuration == 0.5f,
            "Corner entry changed source tween targets, preserved height or deadlines.");

        int assertions = 2 + VerifyInvalidEntries(shot);
        MissionCatalog missions = MissionCatalog.Load(Path.Combine(directory, "recovered-mission-catalog.json"));
        CoopCardRowCatalog cards = CoopCardRowCatalog.Load(Path.Combine(directory, "recovered-coop-card-rows.json"),
            missions, content.Army, content.Stats.Revision);
        var combat = new CoopEnemyCombatCatalog(missions, content.Army, cards);
        for (int index = 0; index < 71; index++)
        {
            // Source Helicopter has STARTINGLEVEL 30 and 71 normal Tier rows; maximum level is 101.
            float progress = (float)(index + 30) / 101;
            Require(content.Army.NormalLevelProgress("ID_UNIT-HELICOPTER", index) == progress,
                "Secondary actor progress used an upgrade index or last index as its maximum level.");
            Require(combat.TransportCrewShot(index) == cards.Shot("ID_UNIT-ASSAULT", progress),
                "Helicopter crew shot timing did not use source card interpolation.");
            assertions += 2;
        }
        return assertions;
    }

    private static int VerifyInvalidEntries(ArmyBaseShotStats shot)
    {
        var valid = new TransportCrewPointEntry.RandomDraws(0.5f, 15, 0.5f);
        var context = Context(CoopInfantryPointState.ObstacleHiding, 1);
        Action[] invalid =
        {
            () => new TransportCrewPointEntry(context with { ControllerTime = float.NaN }, shot, valid),
            () => new TransportCrewPointEntry(context with { ControllerTime = float.MaxValue }, shot, valid),
            () => new TransportCrewPointEntry(context, shot, valid with { PointChangeSeconds = 20 }),
            () => new TransportCrewPointEntry(context, shot, valid with { ShotFraction = -0.1f }),
            () => new TransportCrewPointEntry(context, shot, valid with { RepositionFraction = null }),
            () => new TransportCrewPointEntry(context, shot with { MaxShootTime = float.NaN }, valid),
            () => new TransportCrewPointEntry(Context(CoopInfantryPointState.CornerHiding, 1), shot, valid),
        };
        foreach (Action action in invalid)
        {
            try
            {
                action();
                throw new Exception("Invalid hidden-state authority was accepted.");
            }
            catch (InvalidDataException)
            {
                // Construction fails before the runtime publishes an entry state.
            }
        }
        return invalid.Length;
    }

    internal static TransportCrewPointEntry.EntryContext Context(CoopInfantryPointState state, float controllerTime)
    {
        const int PointFileId = 1;
        string pointType = state == CoopInfantryPointState.ObstacleHiding ? "EnemyPointObstacle" : "EnemyPointCorner";
        var point = new CoopEnemyPoint(0, PointFileId, pointType, 2, 3,
            new Vector3(1, 2, 3), Quaternion.Identity, new Vector3(1, 2, 3), null, null)
        {
            CornerDirection = state == CoopInfantryPointState.CornerHiding ? Vector3.UnitZ : null,
        };
        var arrival = new CoopMatchRuntime.TransportCrewPointArrival(1, new Vector3(1, 7, 3), PointFileId, state);
        return new TransportCrewPointEntry.EntryContext(arrival, point, controllerTime);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
