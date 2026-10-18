using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Compares script-free shields with recovered SoldierParts.AttachShield and ChangeShieldMat.</summary>
public static class UnityInfantryShieldAppearanceAudit
{
    private const float Tolerance = 0.0001f;
    private static int _checks;
    private static EnemyController _source;
    private static SoldierBehaviour _family;

    /// <summary>Checks ordinary/card inventories with unit and nonuniform shield socket scales.</summary>
    public static void Run()
    {
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Component[] components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            _source = components.OfType<ObjectPoolDatabase>().Single().enemy;
            _family = components.OfType<LevelBehaviourManager>().Single().levelBehaviours
                .Select(entry => entry.behaviour).OfType<SoldierBehaviour>()
                .Single(family => family.unitDictionaryId == "ID_UNIT-SWAT");
            foreach (Vector3 scale in new[] { Vector3.one, new Vector3(1.25f, 0.8f, 1.1f) })
            {
                VerifySelection(Selection.Ordinary, scale);
                VerifySelection(Selection.Card, scale);
            }

            VerifyProduction(components.OfType<LevelBehaviourManager>().Single(),
                components.OfType<ObjectPoolDatabase>().Single(),
                components.OfType<MatCapTextures>().Single().menuMatCapTexture);

            Debug.Log("PASS: " + _checks + " shield checks; four source-method attachments and four presenter actors.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void VerifySelection(Selection selection, Vector3 socketScale)
    {
        SoldierMeshChanger.SoldierStyle style = selection == Selection.Card ?
            _family.cardSoldierVisuals[0] : _family.soldierVisuals[0];
        SelfHostedInfantryVisual actual = SelfHostedInfantryVisualFactory.Create(_source, style, "ShieldActual");
        SelfHostedInfantryVisual expected = SelfHostedInfantryVisualFactory.Create(_source, style, "ShieldReference");
        Material bodyMaterial = new Material(actual.Body.sharedMaterial);
        try
        {
            actual.Body.sharedMaterial = bodyMaterial;
            SoldierParts sourceParts = _source.GetComponentInChildren<SoldierParts>(true);
            Transform actualSocket = actual.ResolveSource(sourceParts.shieldSnapPointNotScaled);
            Transform expectedSocket = expected.ResolveSource(sourceParts.shieldSnapPointNotScaled);
            actualSocket.localScale = socketScale;
            expectedSocket.localScale = socketScale;
            actual.Root.SetActive(true);
            expected.Root.SetActive(true);
            SoldierParts referenceParts = expected.Root.AddComponent<SoldierParts>();
            referenceParts.shieldSnapPointNotScaled = expectedSocket;
            EnemyBasicInventory inventory = _family.GetComponent<EnemyBasicInventory>();
            GameObject prefab = selection == Selection.Card ? inventory.cardShield : inventory.shield;
            Require(prefab != null, "The selected recovered SWAT inventory must contain a shield.");
            referenceParts.AttachShield(prefab);
            if (selection == Selection.Card)
            {
                referenceParts.ChangeShieldMat(bodyMaterial);
            }

            GameObject copy = selection == Selection.Card ?
                SelfHostedInfantryShieldAppearance.AttachCard(_family, _source, actual) :
                SelfHostedInfantryShieldAppearance.AttachOrdinary(_family, _source, actual);
            FakeRigidBodySwapper reference = expected.Root.GetComponentsInChildren<FakeRigidBodySwapper>(true).Single();
            Compare(copy, reference.gameObject);
            Require(copy.transform.parent == actualSocket &&
                actual.Root.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
                actual.Root.GetComponentsInChildren<Collider>(true).Length == 0 &&
                actual.Root.GetComponentsInChildren<Rigidbody>(true).Length == 0,
                "The shield must use the copied source socket without gameplay or physics components.");
            VerifyMaterialOwnership(copy, prefab, bodyMaterial, selection);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(actual.Root);
            UnityEngine.Object.DestroyImmediate(expected.Root);
            UnityEngine.Object.DestroyImmediate(bodyMaterial);
        }
    }

    private static void Compare(GameObject actual, GameObject expected)
    {
        Transform[] copies = actual.GetComponentsInChildren<Transform>(true);
        Transform[] references = expected.GetComponentsInChildren<Transform>(true);
        Require(copies.Length == references.Length, "Every source shield transform must be copied.");
        for (int index = 0; index < copies.Length; index++)
        {
            Transform copy = copies[index];
            Transform reference = references[index];
            Require(Vector3.Distance(copy.position, reference.position) < Tolerance &&
                Mathf.Abs(Quaternion.Dot(copy.rotation, reference.rotation)) > 1f - Tolerance &&
                Vector3.Distance(copy.lossyScale, reference.lossyScale) < Tolerance &&
                copy.gameObject.activeSelf == reference.gameObject.activeSelf &&
                copy.gameObject.layer == reference.gameObject.layer,
                "Shield world pose, scale, visibility and layers must match the recovered attachment method.");
            MeshFilter mesh = reference.GetComponent<MeshFilter>();
            if (mesh != null)
            {
                Require(copy.GetComponent<MeshFilter>().sharedMesh == mesh.sharedMesh &&
                    copy.GetComponent<MeshRenderer>().sharedMaterials.SequenceEqual(
                        reference.GetComponent<MeshRenderer>().sharedMaterials),
                    "Shield mesh and material identity must match the recovered reference.");
            }
        }
    }

    private static void VerifyMaterialOwnership(GameObject copy, GameObject prefab,
        Material bodyMaterial, Selection selection)
    {
        FakeRigidBodySwapper original = prefab.GetComponent<FakeRigidBodySwapper>();
        foreach (GameObject form in new[] { original.NoRigidBodyObject, original.RigidBodyObject })
        {
            string path = AnimationUtility.CalculateTransformPath(form.transform, prefab.transform);
            Material expected = selection == Selection.Card ? bodyMaterial :
                form.GetComponent<MeshRenderer>().sharedMaterial;
            Require(copy.transform.Find(path).GetComponent<MeshRenderer>().sharedMaterial == expected,
                "Card shields share the copied body material; ordinary shields retain source materials.");
        }
    }

    private static void VerifyProduction(LevelBehaviourManager manager, ObjectPoolDatabase pool, Texture2D matCap)
    {
        GameObject owner = new GameObject("ShieldPresenterAudit");
        try
        {
            BattlePlayerView[] players = CreatePlayers();
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            SelfHostedInfantryPresenter presenter = owner.AddComponent<SelfHostedInfantryPresenter>();
            presenter.Configure(pool.enemy, pool.parachute, manager, client);
            presenter.BindPlayerAppearances(players);
            presenter.BindTeamAppearance(players[0].PlayerId, matCap);
            foreach (BattlePlayerView player in players)
            {
                VerifyProductionActor(presenter, player, Selection.Ordinary);
                VerifyProductionActor(presenter, player, Selection.Card);
            }
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static BattlePlayerView[] CreatePlayers()
    {
        var players = new[]
        {
            new BattlePlayerView { PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", Fraction = 1 },
            new BattlePlayerView { PlayerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", Fraction = 2 }
        };
        foreach (BattlePlayerView player in players)
        {
            player.Units.Add(new BattleUnitView
            {
                SourceId = _family.upgradeSlots.GetSheetName(), UpgradeIndex = 0, SpecialIndex = -1, EliteIndex = -1
            });
        }

        return players;
    }

    private static void VerifyProductionActor(SelfHostedInfantryPresenter presenter,
        BattlePlayerView player, Selection selection)
    {
        var row = new BattleArmyEntityState
        {
            EntityKey = (ulong)player.Fraction, OwnerPlayerId = player.PlayerId, OwnerFraction = player.Fraction,
            UnitId = _family.unitDictionaryId, SourceCardId = selection == Selection.Card ? "ELITESWAT" : "",
            SpawnTick = 60, PositionTick = 60, MaxHealth = 100, Health = 100,
            InfantryClip = "shield_idle", InfantryClipStartTick = 60, InfantryFacingZ = 1,
            OptionIndex = selection == Selection.Card ? -1 : 0
        };
        presenter.Apply(new[] { row });
        GameObject actor = GameObject.Find("SelfHostedInfantry_" + row.EntityKey);
        EnemyBasicInventory inventory = _family.GetComponent<EnemyBasicInventory>();
        GameObject prefab = selection == Selection.Card ? inventory.cardShield : inventory.shield;
        SoldierParts parts = _source.GetComponentInChildren<SoldierParts>(true);
        string socketPath = AnimationUtility.CalculateTransformPath(parts.shieldSnapPointNotScaled, _source.transform);
        Transform socket = actor.transform.Find("Rig/" + socketPath);
        GameObject shield = socket.Cast<Transform>().Single(item => item.name == prefab.name).gameObject;
        Material material = actor.GetComponentInChildren<SkinnedMeshRenderer>(true).sharedMaterial;
        VerifyMaterialOwnership(shield, prefab, material, selection);
        Require(actor.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
            actor.GetComponentsInChildren<Collider>(true).Length == 0,
            "Production shields must not activate local gameplay or collision writers.");
        presenter.Apply(new BattleArmyEntityState[0]);
        Require(actor == null && shield == null && material == null,
            "Roster removal must release the actor, shield and shared body material together.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }

        _checks++;
    }

    private enum Selection
    {
        Ordinary,
        Card
    }
}
