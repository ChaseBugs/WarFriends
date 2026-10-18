using System;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;
using War.Shared;

/// <summary>Checks source card skins through the production presenter without ordinary equipped units.</summary>
public static class UnityCardInfantryAppearanceAudit
{
    private const string FirstPlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string SecondPlayerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private const int FirstFraction = 1;
    private const int SecondFraction = 2;
    private static int _checks;
    private static EnemyController _source;
    private static Texture2D _matCap;
    private static string _localPlayerId;

    /// <summary>Exercises all six supported infantry card identities from both player perspectives.</summary>
    public static void Run()
    {
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Component[] components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            LevelBehaviourManager manager = components.OfType<LevelBehaviourManager>().Single();
            ObjectPoolDatabase pool = components.OfType<ObjectPoolDatabase>().Single();
            Texture2D matCap = components.OfType<MatCapTextures>().Single().menuMatCapTexture;
            _source = pool.enemy;
            _matCap = matCap;
            foreach (string localPlayerId in new[] { FirstPlayerId, SecondPlayerId })
            {
                _localPlayerId = localPlayerId;
                VerifyPerspective(manager, pool);
            }

            Debug.Log("PASS: " + _checks + " card infantry appearance checks across twenty-four source actors.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void VerifyPerspective(LevelBehaviourManager manager, ObjectPoolDatabase pool)
    {
        GameObject owner = new GameObject("CardSkinAudit");
        try
        {
            BattlePlayerView[] players = CreatePlayers();
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            SelfHostedInfantryPresenter presenter = owner.AddComponent<SelfHostedInfantryPresenter>();
            presenter.Configure(pool.enemy, pool.parachute, manager, client);
            presenter.BindPlayerAppearances(players);
            presenter.BindTeamAppearance(_localPlayerId, _matCap);
            var selection = new SelfHostedInfantryUpgradeSelection(players);
            foreach (KeyValuePair<string, string> card in CardClips())
            {
                SoldierBehaviour family = manager.levelBehaviours.Select(entry => entry.behaviour)
                    .OfType<SoldierBehaviour>().First(item =>
                        CardUnitSourceIdentity.Matches(card.Key, item.unitDictionaryId));
                VerifyCard(presenter, selection, family, card);
            }

        }
        finally
        {
            if (owner != null)
            {
                UnityEngine.Object.DestroyImmediate(owner);
            }
        }
    }

    private static BattlePlayerView[] CreatePlayers()
    {
        // A card spawn is allowed even when neither player has its ordinary unit equipped.
        return new[]
        {
            new BattlePlayerView { PlayerId = FirstPlayerId, Fraction = FirstFraction },
            new BattlePlayerView { PlayerId = SecondPlayerId, Fraction = SecondFraction }
        };
    }

    private static IEnumerable<KeyValuePair<string, string>> CardClips()
    {
        return new[]
        {
            new KeyValuePair<string, string>("BIGROCKET", "bazooka_idle"),
            new KeyValuePair<string, string>("ELITEMINIGUN", "minigun_idle"),
            new KeyValuePair<string, string>("ELITEPARA", "idle_1"),
            new KeyValuePair<string, string>("ELITESNIPER", "sniper_idle"),
            new KeyValuePair<string, string>("ELITESWAT", "shield_idle"),
            new KeyValuePair<string, string>("GREATGRENADIER", "idle_1")
        };
    }

    private static void VerifyCard(SelfHostedInfantryPresenter presenter,
        SelfHostedInfantryUpgradeSelection selection, SoldierBehaviour family, KeyValuePair<string, string> card)
    {
        var materials = new List<Material>();
        foreach (int fraction in new[] { FirstFraction, SecondFraction })
        {
            BattleArmyEntityState actor = CreateActor(family.unitDictionaryId, card, fraction);
            List<TechnologyVisualDefinition> definitions = selection.ResolveVisuals(actor, family);
            Require(definitions.SequenceEqual(family.upgradeSlots.cardVisuals) &&
                !ReferenceEquals(definitions, family.upgradeSlots.cardVisuals),
                "Card selection must copy the exact source card lane without requiring ordinary equipment.");
            presenter.Apply(new[] { BattleArmyEntityState.Parser.ParseFrom(actor.ToByteArray()) });
            GameObject copy = GameObject.Find("SelfHostedInfantry_" + actor.EntityKey);
            SkinnedMeshRenderer body = copy.GetComponentInChildren<SkinnedMeshRenderer>(true);
            string path = IsLocalFraction(fraction) ? definitions[0].materialTextrePathBlue :
                definitions[0].materialTextrePathRed;
            Require(body.sharedMaterial.mainTexture == Resources.Load<Texture2D>(path),
                "Card body must use the fixed card lane and the admitted owner's team texture.");
            VerifyDetails(copy, definitions, fraction);
            Require(copy.GetComponentsInChildren<MonoBehaviour>(true).Length == 0,
                "Card skin presentation must not activate recovered gameplay components.");
            materials.Add(body.sharedMaterial);
        }

        presenter.Apply(new BattleArmyEntityState[0]);
        Require(materials.All(material => material == null), "Card actor removal must release cloned materials.");
        VerifyRejections(selection, family, card);
    }

    private static void VerifyDetails(GameObject actor, List<TechnologyVisualDefinition> definitions, int fraction)
    {
        FakeRigidBodySwapper helmet = _source.meshChanger.helmet;
        foreach (GameObject form in new[] { helmet.NoRigidBodyObject, helmet.RigidBodyObject })
        {
            string path = AnimationUtility.CalculateTransformPath(form.transform, _source.transform);
            Renderer renderer = actor.transform.Find("Rig/" + path).GetComponent<Renderer>();
            string texturePath = IsLocalFraction(fraction) ? definitions[1].materialTextrePathBlue :
                definitions[1].materialTextrePathRed;
            Require(renderer.sharedMaterial.mainTexture == Resources.Load<Texture2D>(texturePath) &&
                renderer.sharedMaterial.GetTexture("_MatCap") == _matCap,
                "Both card helmet forms must use their fixed source team texture and scene MatCap.");
        }

        VerifyAttachments(actor, _source.meshChanger.bodyAttachemnts, definitions[0], fraction);
        VerifyAttachments(actor, _source.meshChanger.helmetAttachments, definitions[1], fraction);
    }

    private static void VerifyAttachments(GameObject actor, ModelAttachments slots,
        TechnologyVisualDefinition definition, int fraction)
    {
        foreach (UpgradeSlots.VisualSlotMesh selection in definition.visualSlotMeshes)
        {
            MeshRenderer prefab = !IsLocalFraction(fraction) && selection.partRed != null ?
                selection.partRed : selection.part;
            ModelAttachments.ModelAttachment slot = slots.modelAttachments.FirstOrDefault(item =>
                item.id == selection.visualSlotId);
            if (prefab == null || slot == null)
            {
                continue;
            }

            string path = AnimationUtility.CalculateTransformPath(slot.parent, _source.transform);
            Transform parent = actor.transform.Find("Rig/" + path);
            Transform copy = parent.Cast<Transform>().Last(child => child.name == prefab.name);
            Require(copy.localPosition == Vector3.zero && copy.localRotation == Quaternion.identity &&
                copy.localScale == Vector3.one && copy.GetComponent<MeshFilter>().sharedMesh ==
                    prefab.GetComponent<MeshFilter>().sharedMesh &&
                copy.GetComponent<MeshRenderer>().sharedMaterials.SequenceEqual(prefab.sharedMaterials),
                "Card attachment meshes, materials and socket poses must agree with the fixed source lane.");
        }
    }

    private static void VerifyRejections(SelfHostedInfantryUpgradeSelection selection,
        SoldierBehaviour family, KeyValuePair<string, string> card)
    {
        BattleArmyEntityState actor = CreateActor(family.unitDictionaryId, card, FirstFraction);
        actor.OwnerFraction = SecondFraction;
        ExpectRejected(() => selection.ResolveVisuals(actor, family));
        actor.OwnerFraction = FirstFraction;
        actor.SourceCardId = "UNKNOWN";
        ExpectRejected(() => selection.ResolveVisuals(actor, family));
        actor.SourceCardId = card.Key == "BIGROCKET" ? "ELITEMINIGUN" : "BIGROCKET";
        ExpectRejected(() => selection.ResolveVisuals(actor, family));
        actor.SourceCardId = "";
        ExpectRejected(() => selection.ResolveVisuals(actor, family));
    }

    private static BattleArmyEntityState CreateActor(string unitId, KeyValuePair<string, string> card, int fraction)
    {
        return new BattleArmyEntityState
        {
            EntityKey = (ulong)fraction, OwnerPlayerId = fraction == FirstFraction ? FirstPlayerId : SecondPlayerId,
            OwnerFraction = fraction, UnitId = unitId, SourceCardId = card.Key,
            SpawnTick = 60, PositionTick = 60, MaxHealth = 100, Health = 100,
            InfantryClip = card.Value, InfantryClipStartTick = 60, InfantryFacingZ = 1, OptionIndex = -1
        };
    }

    private static bool IsLocalFraction(int fraction)
    {
        return _localPlayerId == (fraction == FirstFraction ? FirstPlayerId : SecondPlayerId);
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

        throw new Exception("Invalid card appearance authority was accepted.");
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
