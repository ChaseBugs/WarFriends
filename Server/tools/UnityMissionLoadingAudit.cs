using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>Runs original mission event preparation through synchronous battle setup ownership.</summary>
public static class UnityMissionLoadingAudit
{
    private const string BehaviourKey = "AbortMissionVisualProbe";
    private const int ObservationFrames = 6;
    private const int TimeoutSeconds = 10;

    /// <summary>
    /// Requires the real early mission callback to retain and cancel its independently hosted loaders.
    /// </summary>
    public static async Task VerifyAsync(LevelBehaviour level, UpgradeSlots slots)
    {
        LevelManager manager = Resources.FindObjectsOfTypeAll<LevelManager>()
            .Single(value => value.gameObject.scene.IsValid());
        var singleton = typeof(LevelManager).GetField("mInstance", BindingFlags.Static | BindingFlags.NonPublic);
        object previousManager = singleton.GetValue(null);
        List<LevelBehaviour> previousBehaviours = manager.behaviours;
        var root = new GameObject("MissionLoadingOwnershipProbe");
        var mission = root.AddComponent<Mission>();
        var definition = new MissionDefinition
        {
            events = new List<MissionDefinitionEvent>
            {
                new MissionDefinitionEvent { isCardUnit = true, behaviour = BehaviourKey },
            },
        };
        typeof(Mission).GetField("mMissionDefinition", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(mission, definition);
        Require(!Mission.behavioursDictionary.ContainsKey(BehaviourKey), "The temporary mission key already exists.");
        Mission.behavioursDictionary.Add(BehaviourKey, new Tuple<Type, int>(level.GetType(), 0));
        var scope = new BattleResourceLoadScope();
        try
        {
            singleton.SetValue(null, manager);
            manager.behaviours = new List<LevelBehaviour> { level };
            slots.NullCardVisuals(false, true);
            scope.RunSetup(mission.LoadingStarted);
            Require(slots.cardVisuals[0].materialTetxureRed != null &&
                slots.cardVisuals[1].materialTetxureRed == null,
                "The original mission setup did not pause after its first opponent visual.");
            slots.NullCardVisuals(false, true);
            scope.Cancel();
            await WaitFramesAsync();
            Require(scope.PendingCount == 0 &&
                slots.cardVisuals.TrueForAll(visual => visual.materialTetxureRed == null),
                "Early mission setup escaped battle ownership and repopulated cleared opponent visuals.");
            var fresh = new BattleResourceLoadScope();
            fresh.RunSetup(mission.LoadingStarted);
            await WaitFramesAsync();
            Require(fresh.PendingCount == 0 &&
                slots.cardVisuals.TrueForAll(visual => visual.materialTetxureRed != null),
                "Fresh mission setup did not complete its original visual chain.");
            await VerifyFailedSetupAsync(mission, definition, slots);
            Debug.Log("PASS: original mission LoadingStarted owns and cancels its early event visual loaders, " +
                "fresh setup completes and rejected setup restores ownership; no full campaign/co-op gameplay proof.");
        }
        finally
        {
            scope.Cancel();
            mission.StopAllCoroutines();
            root.SetActive(false);
            Mission.behavioursDictionary.Remove(BehaviourKey);
            manager.behaviours = previousBehaviours;
            singleton.SetValue(null, previousManager);
        }
    }

    private static async Task VerifyFailedSetupAsync(Mission mission, MissionDefinition definition, UpgradeSlots slots)
    {
        var invalid = new MissionDefinitionEvent { isCardUnit = true, behaviour = BehaviourKey + "Missing" };
        Require(!Mission.behavioursDictionary.ContainsKey(invalid.behaviour),
            "The failure-control key already exists.");
        definition.events.Add(invalid);
        slots.NullCardVisuals(false, true);
        try
        {
            VerifyGameControllerSetupFailure(mission);
        }
        finally
        {
            definition.events.Remove(invalid);
        }
        slots.NullCardVisuals(false, true);
        await WaitFramesAsync();
        Require(slots.cardVisuals.TrueForAll(visual => visual.materialTetxureRed == null),
            "A loader from rejected mission setup repopulated cleared visuals.");
        mission.StartCoroutine(slots.LoadOpponentVisualsCoroutineCards());
        await WaitFramesAsync();
        Require(slots.cardVisuals.TrueForAll(visual => visual.materialTetxureRed != null),
            "Failed setup leaked its cancelled scope into later unscoped visual loading.");
    }

    private static void VerifyGameControllerSetupFailure(Mission mission)
    {
        GameController game = Singleton<GameController>.instance;
        var controllerField = typeof(GameController).GetField("mMainController",
            BindingFlags.Instance | BindingFlags.NonPublic);
        var scopeField = typeof(GameController).GetField("_battleResourceLoads",
            BindingFlags.Instance | BindingFlags.NonPublic);
        var createdField = typeof(GameController).GetField("mGameCreated",
            BindingFlags.Instance | BindingFlags.NonPublic);
        object previousController = controllerField.GetValue(game);
        object previousCreated = createdField.GetValue(game);
        Require(scopeField.GetValue(game) == null, "The isolated start probe already has a battle load scope.");
        var root = new GameObject("InactiveMissionSetupController");
        root.SetActive(false);
        var controller = root.AddComponent<AbortMissionSetupControllerProbe>();
        controller.LoadingStartedAction = mission.LoadingStarted;
        controllerField.SetValue(game, controller);
        try
        {
            bool rejected = false;
            try
            {
                game.StartGame();
            }
            catch (KeyNotFoundException)
            {
                // The missing source behaviour is the expected failure after the valid event starts loading.
                rejected = true;
            }
            var failed = scopeField.GetValue(game) as BattleResourceLoadScope;
            Require(rejected && failed != null && failed.PendingCount == 0,
                "Real GameController start failed to own and cancel early mission setup before issuing map loading.");
        }
        finally
        {
            var failed = scopeField.GetValue(game) as BattleResourceLoadScope;
            if (failed != null)
            {
                failed.Cancel();
            }
            controllerField.SetValue(game, previousController);
            createdField.SetValue(game, previousCreated);
            scopeField.SetValue(game, null);
        }
    }

    private static async Task WaitFramesAsync()
    {
        int target = Time.frameCount + ObservationFrames;
        DateTime deadline = DateTime.UtcNow.AddSeconds(TimeoutSeconds);
        while (Time.frameCount < target)
        {
            Require(DateTime.UtcNow < deadline, "Mission visual observation timed out.");
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
