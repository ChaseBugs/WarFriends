using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;

using Google.Protobuf;
using Newtonsoft.Json;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Checks decoded late/replayed Mortar world poses through the production infantry presenter.</summary>
public static class UnityMortarPosePresenterAudit
{
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;
    private const float Tolerance = 0.00001f;
    private const string OwnerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private static int _checks;

    /// <summary>Runs only in a private project without connecting the client to a server or provider.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
        Component[] components = scene.GetRootGameObjects().SelectMany(root =>
            root.GetComponentsInChildren<Component>(true)).ToArray();
        var pool = components.OfType<ObjectPoolDatabase>().Single();
        var manager = components.OfType<LevelBehaviourManager>().Single();
        var family = manager.levelBehaviours.Select(entry => entry.behaviour)
            .OfType<SoldierBehaviourMortar>().Single();
        var owner = new GameObject("MortarPosePresenterAudit");
        try
        {
            var client = owner.AddComponent<SelfHostedBattleClient>();
            var presenter = owner.AddComponent<SelfHostedInfantryPresenter>();
            presenter.Configure(pool.enemy, pool.parachute, manager, client);
            var player = new BattlePlayerView { PlayerId = OwnerId, Fraction = 1 };
            player.Units.Add(new BattleUnitView
            {
                SourceId = family.upgradeSlots.GetSheetName(), UpgradeIndex = 0, SpecialIndex = -1, EliteIndex = -1
            });
            var opponent = player.Clone();
            opponent.PlayerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
            opponent.Fraction = 2;
            presenter.BindPlayerAppearances(new[] { player, opponent });
            presenter.BindTeamAppearance(OwnerId, components.OfType<MatCapTextures>().Single().menuMatCapTexture);
            CheckReplay(presenter, client, family);
            string path = Path.Combine(Directory.GetParent(Application.dataPath).FullName,
                "mortar-pose-presenter-audit.json");
            File.WriteAllText(path, (JsonConvert.SerializeObject(new
            {
                unityVersion = Application.unityVersion, checks = _checks,
                scope = "Decoded production presenter replay/expiry/cleanup; no normal multiplayer or Android proof."
            }, Formatting.Indented) + "\n").Replace("\r\n", "\n"));
            Debug.Log("UNITY_MORTAR_POSE_PRESENTER_PASSED checks=" + _checks);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }
        UnityMortarWeaponAttachmentAudit.Run();
    }

    private static void CheckReplay(SelfHostedInfantryPresenter presenter, SelfHostedBattleClient client,
        SoldierBehaviourMortar family)
    {
        BattleArmyEntityState row = Actor();
        SetTick(client, 120);
        presenter.Apply(new[] { Decode(row) });
        Transform snap = Snap(presenter, family);
        Require(Vector3.Distance(snap.position, Position(row)) < Tolerance && snap.parent == null,
            "A late initial observation detached at the current hand instead of its captured world position.");
        Require(Mathf.Abs(Quaternion.Dot(snap.rotation, Rotation(row))) > 1f - Tolerance &&
            Vector3.Distance(snap.lossyScale, new Vector3(1f, 0.999995f, 1f)) < Tolerance,
            "Presenter lost captured rotation or world scale.");
        GameObject actor = GameObject.Find("SelfHostedInfantry_9001");
        actor.transform.position = new Vector3(-3f, 0f, -4f);
        actor.transform.rotation = Quaternion.Euler(0f, 153f, 0f);
        Require(Vector3.Distance(snap.position, Position(row)) < Tolerance,
            "Later body interpolation moved the captured weapon.");
        presenter.Apply(new BattleArmyEntityState[0]);
        Require(actor == null && snap == null, "Removed roster actor leaked detached world geometry.");

        SetTick(client, 125);
        row.PositionTick = 125;
        row.MortarWeaponPose.ObservedTick = 125;
        presenter.Apply(new[] { Decode(row) });
        snap = Snap(presenter, family);
        Require(Vector3.Distance(snap.position, Position(row)) < Tolerance && snap.parent == null,
            "Reconnect reconstruction lost the original preparation-time pose.");
        SetTick(client, row.MortarWeaponPose.HandReturnTick);
        typeof(SelfHostedInfantryPresenter).GetMethod("Update", PrivateInstance).Invoke(presenter, null);
        Require(snap.parent != null, "An authoritative hand deadline did not restore the production attachment.");
        presenter.Apply(new[] { Decode(row) });
        Require(snap.parent != null, "An old paged observation resurrected an already expired detachment.");
        row.MortarWeaponPose.ScaleX = 2f;
        bool rejected = false;
        try
        {
            presenter.Apply(new[] { Decode(row) });
        }
        catch (InvalidOperationException)
        {
            rejected = true;
        }
        Require(rejected && snap.parent != null, "Malformed pose input changed the existing held visual.");
        presenter.Apply(new BattleArmyEntityState[0]);
        Require(snap == null, "Final roster cleanup retained Mortar geometry.");
    }

    private static Transform Snap(SelfHostedInfantryPresenter presenter, SoldierBehaviourMortar family)
    {
        var active = (IDictionary)typeof(SelfHostedInfantryPresenter).GetField("active", PrivateInstance)
            .GetValue(presenter);
        object visual = active[9001UL];
        var weapons = (SelfHostedInfantryWeaponSet)visual.GetType().GetProperty("Weapons").GetValue(visual, null);
        var prefab = family.GetComponent<EnemyBasicInventory>().weapons[0].weapon;
        return weapons.ResolveSource(0, prefab.GetComponent<FakeRigidBodySwapper>().snapPoint.transform);
    }

    private static void SetTick(SelfHostedBattleClient client, ulong tick)
    {
        typeof(SelfHostedBattleClient).GetProperty("State")
            .SetValue(client, new MatchSnapshot { ServerTick = tick }, null);
    }

    private static BattleArmyEntityState Actor()
    {
        Quaternion rotation = Quaternion.Euler(17f, 41f, 9f);
        return new BattleArmyEntityState
        {
            EntityKey = 9001, UnitId = "ID_UNIT-MORTAR", OwnerPlayerId = OwnerId, OwnerFraction = 1,
            SpawnTick = 60, PositionTick = 120, MaxHealth = 100f, Health = 100f,
            InfantryFacingZ = 1f, InfantryClip = "mortar_hide", InfantryClipStartTick = 100,
            MortarWeaponPose = new BattleMortarWeaponPose
            {
                PreparedTick = 100, HandReturnTick = 134, ObservedTick = 120,
                X = 10f, Y = 0.2f, Z = -6f,
                Rotation = new BattleJointRotation { X = rotation.x, Y = rotation.y, Z = rotation.z, W = rotation.w },
                ScaleX = 1f, ScaleY = 0.999995f, ScaleZ = 1f
            }
        };
    }

    private static BattleArmyEntityState Decode(BattleArmyEntityState row)
    {
        return BattleArmyEntityState.Parser.ParseFrom(row.ToByteArray());
    }

    private static Vector3 Position(BattleArmyEntityState row)
    {
        return new Vector3(row.MortarWeaponPose.X, row.MortarWeaponPose.Y, row.MortarWeaponPose.Z);
    }

    private static Quaternion Rotation(BattleArmyEntityState row)
    {
        BattleJointRotation value = row.MortarWeaponPose.Rotation;
        return new Quaternion(value.X, value.Y, value.Z, value.W);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        _checks++;
    }
}
