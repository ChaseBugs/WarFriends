using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Checks admitted-owner weapon selection through the production infantry presenter.</summary>
public static class UnityInfantryOwnerAppearanceAudit
{
    private const string FirstPlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string SecondPlayerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private static int _checks;

    /// <summary>Exercises opposing normal/Elite owners, immutable admission data and rejected authority.</summary>
    public static void Run()
    {
        GameObject root = null;
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            LevelBehaviourManager manager = scene.GetRootGameObjects()
                .SelectMany(item => item.GetComponentsInChildren<LevelBehaviourManager>(true)).Single();
            SoldierBehaviourAssaulter family = manager.levelBehaviours.Select(item => item.behaviour)
                .OfType<SoldierBehaviourAssaulter>().First();
            ObjectPoolDatabase pool = scene.GetRootGameObjects()
                .SelectMany(item => item.GetComponentsInChildren<ObjectPoolDatabase>(true)).Single();
            var slots = (UpgradeSlotsAssaulter)family.upgradeSlots;
            int eliteLevel = slots.eliteVisualsWeapon.Max(item => item.level);
            BattlePlayerView[] players = CreatePlayers(family.upgradeSlots.GetSheetName(), eliteLevel);
            VerifySelection(players, family);

            root = new GameObject("OwnerAppearanceAudit");
            SelfHostedBattleClient client = root.AddComponent<SelfHostedBattleClient>();
            SelfHostedInfantryPresenter presenter = root.AddComponent<SelfHostedInfantryPresenter>();
            presenter.Configure(pool.enemy, pool.parachute, manager, client);
            presenter.BindPlayerAppearances(players);
            VerifyPresenter(presenter, family, eliteLevel);
            Debug.Log("PASS: " + _checks + " owner-bound infantry appearance checks; no full gameplay proof.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            if (root != null)
            {
                UnityEngine.Object.DestroyImmediate(root);
            }
        }
    }

    private static BattlePlayerView[] CreatePlayers(string sourceId, int eliteLevel)
    {
        var first = new BattlePlayerView { PlayerId = FirstPlayerId, Fraction = 1 };
        first.Units.Add(new BattleUnitView
        {
            SourceId = sourceId, UpgradeIndex = 0, SpecialIndex = -1, EliteIndex = -1
        });
        var second = new BattlePlayerView { PlayerId = SecondPlayerId, Fraction = 2 };
        second.Units.Add(new BattleUnitView
        {
            SourceId = sourceId, UpgradeIndex = eliteLevel, SpecialIndex = 2, EliteIndex = 3
        });
        return new[] { first, second };
    }

    private static void VerifySelection(BattlePlayerView[] players, SoldierBehaviourAssaulter family)
    {
        var selection = new SelfHostedInfantryUpgradeSelection(players);
        BattleArmyEntityState first = CreateActor(FirstPlayerId, 1, 7101);
        BattleArmyEntityState second = CreateActor(SecondPlayerId, 2, 7102);
        UpgradeSlots.UnitUpgrades normal = selection.Resolve(first, family);
        UpgradeSlots.UnitUpgrades elite = selection.Resolve(second, family);
        Require(normal.slotUpgradeindex == 0 && !normal.isElite && !normal.isSpecial,
            "Normal owner must retain absent special and Elite flags.");
        Require(elite.slotUpgradeindex == players[1].Units[0].UpgradeIndex && elite.isElite && elite.isSpecial &&
            elite.slotUpgradeIndexElite == 3 && elite.slotUpgradeIndexSpecial == 2,
            "Elite owner must preserve its own complete recovered upgrade tuple.");
        players[1].Units[0].UpgradeIndex = 0;
        Require(selection.Resolve(second, family).slotUpgradeindex == elite.slotUpgradeindex,
            "A caller mutation must not change the frozen admitted equipment.");
        players[1].Units[0].UpgradeIndex = elite.slotUpgradeindex;
        ExpectRejected(() => selection.Resolve(CreateActor(FirstPlayerId, 2, 7103), family));
        ExpectRejected(() => selection.Resolve(CreateActor("cccccccccccccccccccccccccccccccc", 1, 7103), family));
        first.SourceCardId = "SOLDIER";
        ExpectRejected(() => selection.Resolve(first, family));
        BattlePlayerView missing = players[0].Clone();
        missing.Units.Clear();
        var incomplete = new SelfHostedInfantryUpgradeSelection(new[] { missing, players[1] });
        ExpectRejected(() => incomplete.Resolve(CreateActor(FirstPlayerId, 1, 7101), family));
        BattlePlayerView duplicate = players[0].Clone();
        duplicate.Units.Add(duplicate.Units[0].Clone());
        ExpectRejected(() => new SelfHostedInfantryUpgradeSelection(new[] { duplicate, players[1] }));
        BattlePlayerView malformed = players[0].Clone();
        malformed.Units[0].UpgradeIndex = -1;
        ExpectRejected(() => new SelfHostedInfantryUpgradeSelection(new[] { malformed, players[1] }));
    }

    private static void VerifyPresenter(SelfHostedInfantryPresenter presenter,
        SoldierBehaviourAssaulter family, int eliteLevel)
    {
        BattleArmyEntityState[] actors =
        {
            CreateActor(FirstPlayerId, 1, 7101), CreateActor(SecondPlayerId, 2, 7102)
        };
        presenter.Apply(actors);
        for (int index = 0; index < actors.Length; index++)
        {
            var upgrades = new UpgradeSlots.UnitUpgrades(1f)
            {
                slotUpgradeindex = index == 0 ? 0 : eliteLevel, isElite = index != 0
            };
            SelfHostedInfantryWeaponAppearance expected =
                SelfHostedInfantryWeaponAppearance.ResolveOrdinary(family, upgrades);
            // Source lanes may select the same mesh; tuple checks above distinguish ownership without invented art.
            Debug.Log("Owner " + actors[index].OwnerFraction + " source model " + expected.ModelNumber);
            GameObject actor = GameObject.Find("SelfHostedInfantry_" + actors[index].EntityKey);
            Mesh mesh = expected.Model.GetComponent<MeshFilter>().sharedMesh;
            Require(actor != null && actor.GetComponentsInChildren<MeshFilter>(true)
                .Any(filter => filter.sharedMesh == mesh) &&
                actor.GetComponentsInChildren<MonoBehaviour>(true).Length == 0,
                "Production actor must display its owner's selected source weapon without gameplay components.");
        }

        presenter.Apply(new BattleArmyEntityState[0]);
        Require(GameObject.Find("SelfHostedInfantry_7101") == null &&
            GameObject.Find("SelfHostedInfantry_7102") == null, "Removed owner actors must be destroyed.");
        ExpectRejected(() => presenter.Apply(new[] { CreateActor(FirstPlayerId, 2, 7103) }));
        Require(GameObject.Find("SelfHostedInfantry_7103") == null,
            "Rejected owner authority must not leave a partly created actor.");
    }

    private static BattleArmyEntityState CreateActor(string ownerId, int fraction, ulong key)
    {
        return new BattleArmyEntityState
        {
            EntityKey = key, OwnerPlayerId = ownerId, OwnerFraction = fraction, UnitId = "ID_UNIT-ASSAULT",
            SpawnTick = 60, PositionTick = 60, MaxHealth = 100, Health = 100,
            InfantryClip = "idle_1", InfantryClipStartTick = 60, InfantryFacingZ = 1
        };
    }

    private static void ExpectRejected(Action action)
    {
        try
        {
            action();
        }
        catch (ArgumentException)
        {
            _checks++;
            return;
        }
        catch (InvalidOperationException)
        {
            _checks++;
            return;
        }
        catch (Exception failure)
        {
            // Recovered AWS and Mono both export this name, so avoid an ambiguous compile-time type reference.
            if (failure.GetType().FullName != "System.IO.InvalidDataException")
            {
                throw;
            }

            _checks++;
            return;
        }

        throw new Exception("Invalid appearance authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }

        _checks++;
    }
}
