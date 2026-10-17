using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>Checks original initial-turret dispatch with real prepared visual types and resource paths.</summary>
public static class UnityInitialTurretLoadingAudit
{
    private const int ObservationFrames = 6;
    private const int TimeoutSeconds = 10;

    /// <summary>
    /// Requires delayed initial-unit preparation to cancel and reload without changing source definitions.
    /// </summary>
    public static async Task VerifyAsync(Mission mission, MissionDefinition definition)
    {
        List<MissionDefinitionInitialUnit> previous = definition.initialUnits;
        using (var fixture = new UnityInitialTurretFixture())
        {
            var cancelled = new BattleResourceLoadScope();
            var fresh = new BattleResourceLoadScope();
            try
            {
                definition.initialUnits = new List<MissionDefinitionInitialUnit>
                {
                    Initial(MissionDefinitionInitialUnit.MissionDefinitionInitialUnitBehaviour.Turret),
                };
                fixture.ClearVisuals();
                fresh.RunSetup(mission.LoadInitialUnitVisuals);
                Require(fresh.PendingCount == 0,
                    "The source base-turret selector unexpectedly started special visuals.");
                fixture.RequireCleared();
                definition.initialUnits.Add(Initial(MissionDefinitionInitialUnit
                    .MissionDefinitionInitialUnitBehaviour.RocketTurret));
                definition.initialUnits.Add(Initial(MissionDefinitionInitialUnit
                    .MissionDefinitionInitialUnitBehaviour.HeavyTurret));
                bool dispatched = false;
                cancelled.Start(mission, PrepareAfterFrame(mission, () => dispatched = true));
                await WaitAsync(() => dispatched);
                Require(cancelled.PendingCount > 0, "Delayed turret preparation escaped its battle scope.");
                cancelled.Cancel();
                fixture.ClearVisuals();
                await WaitFramesAsync();
                Require(cancelled.PendingCount == 0, "Initial turret cancellation left managed work pending.");
                fixture.RequireCleared();
                fresh.RunSetup(mission.LoadInitialUnitVisuals);
                await WaitAsync(() => fresh.PendingCount == 0);
                fixture.RequireLoaded();
                Debug.Log("PASS: original initial heavy/rocket turret dispatch cancels after a delayed continuation " +
                    "and fresh source visual loaders complete; no active turret combat or rendering proof.");
            }
            finally
            {
                cancelled.Cancel();
                fresh.Cancel();
                definition.initialUnits = previous;
            }
        }
    }

    private static MissionDefinitionInitialUnit Initial(
        MissionDefinitionInitialUnit.MissionDefinitionInitialUnitBehaviour behaviour)
    {
        return new MissionDefinitionInitialUnit { behaviour = behaviour };
    }

    private static IEnumerator PrepareAfterFrame(Mission mission, Action dispatched)
    {
        yield return null;
        mission.LoadInitialUnitVisuals();
        dispatched();
    }

    private static async Task WaitFramesAsync()
    {
        int target = Time.frameCount + ObservationFrames;
        await WaitAsync(() => Time.frameCount >= target);
    }

    private static async Task WaitAsync(Func<bool> completed)
    {
        DateTime deadline = DateTime.UtcNow.AddSeconds(TimeoutSeconds);
        while (!completed())
        {
            Require(DateTime.UtcNow < deadline, "Initial turret loading observation timed out.");
            await Task.Yield();
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
