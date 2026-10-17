using System;
using System.Linq;
using System.Reflection;
using Google.Protobuf;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Checks source weapon selection through protobuf decoding and the production infantry presenter.</summary>
public static class UnityCoopInfantryWeaponPresenterAudit
{
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

    /// <summary>Exercises ordinary upgrade indices and the separate card lane without local combat.</summary>
    public static void Run()
    {
        GameObject owner = null;
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Component[] components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            ObjectPoolDatabase pool = components.OfType<ObjectPoolDatabase>().Single();
            LevelBehaviourManager manager = components.OfType<LevelBehaviourManager>().Single();
            SoldierBehaviourAssaulter family = manager.levelBehaviours.Select(entry => entry.behaviour)
                .OfType<SoldierBehaviourAssaulter>().First();
            owner = new GameObject("WeaponPresenterAudit");
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId").SetValue(client, PlayerId, null);
            Publish(client, CreateSnapshot(0));
            SelfHostedCoopInfantryPresenter presenter = owner.AddComponent<SelfHostedCoopInfantryPresenter>();
            presenter.Configure(pool.enemy, manager, client);
            int maximum = ((UpgradeSlotsAssaulter)family.upgradeSlots).visualsWeapon.Max(visual => visual.level) + 1;
            for (int index = 0; index <= maximum; index++)
            {
                MatchSnapshot snapshot = CreateSnapshot(index);
                Publish(client, snapshot);
                VerifyWeapon(snapshot.Coop.EnemySpawns[index], family);
            }

            MatchSnapshot card = CreateSnapshot(maximum + 1);
            BattleCoopEnemySpawn cardEnemy = card.Coop.EnemySpawns[maximum + 1];
            cardEnemy.CardUnit = true;
            cardEnemy.TimedEvent = true;
            cardEnemy.CardProgress = Mathf.Min(1f, cardEnemy.Level / 25f);
            Publish(client, card);
            VerifyWeapon(cardEnemy, family);
            Debug.Log("PASS: " + (maximum + 2) + " decoded source weapon selections through production presenter; " +
                "no gameplay proof.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            if (owner != null)
            {
                UnityEngine.Object.DestroyImmediate(owner);
            }
        }
    }

    private static void VerifyWeapon(BattleCoopEnemySpawn enemy, SoldierBehaviourAssaulter family)
    {
        SelfHostedInfantryWeaponAppearance expected = enemy.CardUnit
            ? SelfHostedInfantryWeaponAppearance.ResolveCard(family)
            : SelfHostedInfantryWeaponAppearance.ResolveOrdinary(
                family, new UpgradeSlots.UnitUpgrades { slotUpgradeindex = enemy.Level });
        GameObject actor = GameObject.Find("SelfHostedCoopInfantry_" + enemy.EntityId);
        MeshFilter model = actor.GetComponentsInChildren<MeshFilter>(true)
            .Single(filter => filter.sharedMesh == expected.Model.GetComponent<MeshFilter>().sharedMesh);
        if (model.transform.localPosition != -expected.Model.pivot.localPosition ||
            model.transform.localScale != expected.Scale ||
            model.GetComponent<MeshRenderer>().sharedMaterial !=
                expected.Model.GetComponent<Renderer>().sharedMaterial ||
            actor.GetComponentsInChildren<MonoBehaviour>(true).Length != 0)
        {
            throw new InvalidOperationException("The production actor did not retain the selected source weapon.");
        }
    }

    private static MatchSnapshot CreateSnapshot(int index)
    {
        MatchSnapshot snapshot = (MatchSnapshot)typeof(UnityCoopWalkingVisualAudit)
            .GetMethod("CreateSnapshot", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, null);
        snapshot.ServerTick += (ulong)index;
        BattleCoopEnemySpawn template = snapshot.Coop.EnemySpawns[0].Clone();
        snapshot.Coop.EnemySpawns.Clear();
        for (int ordinal = 0; ordinal <= index; ordinal++)
        {
            BattleCoopEnemySpawn enemy = template.Clone();
            enemy.EntityId = (ulong)ordinal + 1;
            enemy.Level = ordinal;
            enemy.PoseTick = snapshot.ServerTick;
            enemy.InfantryVisualClip = "";
            enemy.InfantryVisualStartTick = 0;
            enemy.InfantryVisualSampleTick = 0;
            enemy.InfantryAnimation.SampleTick = snapshot.ServerTick;
            snapshot.Coop.EnemySpawns.Add(enemy);
        }
        return snapshot;
    }

    private static void Publish(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        MatchSnapshot decoded = MatchSnapshot.Parser.ParseFrom(snapshot.ToByteArray());
        typeof(SelfHostedBattleClient).GetMethod("Apply", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(client, new object[] { new MatchReply { Code = "state", Snapshot = decoded } });
    }
}
