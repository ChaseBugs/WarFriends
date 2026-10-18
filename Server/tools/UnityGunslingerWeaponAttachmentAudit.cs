using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using Google.Protobuf;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Compares source-selected Gunslinger models and copied attachments with original swapper methods.</summary>
public static class UnityGunslingerWeaponAttachmentAudit
{
    private const float Tolerance = 0.00001f;
    private static readonly List<object> Cases = new List<object>();

    /// <summary>Runs source selection and transform checks without starting gameplay or Photon.</summary>
    public static void Run()
    {
        try
        {
            Require(typeof(UnityGunslingerReferenceSwapper).GetMethod("Swap").DeclaringType ==
                typeof(FakeRigidBodySwapper) &&
                typeof(UnityGunslingerReferenceSwapper).GetMethod("SnapTo").DeclaringType ==
                    typeof(FakeRigidBodySwapper),
                "Reference attachment functions must remain inherited from the recovered source.");
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            var roots = scene.GetRootGameObjects();
            LevelBehaviourManager manager = roots.SelectMany(root =>
                root.GetComponentsInChildren<LevelBehaviourManager>(true)).Single();
            ObjectPoolDatabase pool = roots.SelectMany(root =>
                root.GetComponentsInChildren<ObjectPoolDatabase>(true)).Single();
            SoldierBehaviourGunslinger family = manager.levelBehaviours.Select(entry => entry.behaviour)
                .OfType<SoldierBehaviourGunslinger>().Single();
            UpgradeSlotsGunslicer slots = (UpgradeSlotsGunslicer)family.upgradeSlots;
            int normal = CheckLane(pool.enemy, family, slots.visualsWeapon, false);
            int elite = CheckLane(pool.enemy, family, slots.eliteVisualsWeapon, true);
            int presenterChecks = CheckPresenter(pool, manager, family);
            string output = Environment.GetEnvironmentVariable("WAR_GUNSLINGER_WEAPON_AUDIT_OUTPUT");
            if (string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("Set WAR_GUNSLINGER_WEAPON_AUDIT_OUTPUT.");
            }

            File.WriteAllText(output, JsonConvert.SerializeObject(new
            {
                version = 1, unity = Application.unityVersion,
                normalCases = normal, eliteCases = elite, presenterChecks,
                sourceHashes = SourceHashes(), cases = Cases
            }, Formatting.Indented));
            Debug.Log("GUNSLINGER_WEAPON_ATTACHMENT_PASSED normal=" + normal + " elite=" + elite +
                " presenter=" + presenterChecks);
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static int CheckLane(EnemyController source, SoldierBehaviourGunslinger family,
        List<TechnologyVisualDefinition> definitions, bool isElite)
    {
        MethodInfo selector = typeof(SoldierBehaviour).GetMethod("GetWeaponLevels",
            BindingFlags.Instance | BindingFlags.NonPublic);
        int maximum = definitions.Max(definition => definition.level) + 1;
        for (int level = 0; level <= maximum; level++)
        {
            var upgrades = new UpgradeSlots.UnitUpgrades { slotUpgradeindex = level, isElite = isElite };
            int expected = ((int[])selector.Invoke(family, new object[] { upgrades }))[0];
            SelfHostedInfantryWeaponAppearance appearance = SelfHostedInfantryWeaponAppearance.ResolveOrdinary(
                family, upgrades);
            Require(appearance.ModelNumber == expected &&
                SelfHostedInfantryWeaponAppearance.ResolveGunslinger(family).ModelNumber == expected,
                "The Gunslinger model differs from GetWeaponLevels or the verified constant-lane resolver.");
            CheckAttachment(source, family, appearance, new LaneCase(level, isElite));
        }

        return maximum + 1;
    }

    private static void CheckAttachment(EnemyController source, SoldierBehaviourGunslinger family,
        SelfHostedInfantryWeaponAppearance appearance, LaneCase lane)
    {
        List<SoldierMeshChanger.SoldierStyle> styles = lane.IsElite && family.eliteSoldierVisuals.Count > 0
            ? family.eliteSoldierVisuals : family.soldierVisuals;
        SelfHostedInfantryVisual actual = SelfHostedInfantryVisualFactory.CreateWithAppearance(
            source, styles[0], appearance, "ActualGunslinger");
        SelfHostedInfantryVisual reference = null;
        try
        {
            reference = SelfHostedInfantryVisualFactory.CreateWithAppearance(
                source, styles[0], appearance, "ReferenceGunslinger");
            SelfHostedGunslingerWeaponAttachment attachment = SelfHostedGunslingerWeaponAttachment.Bind(
                source, appearance, actual);
            Transform sourceModel = appearance.WeaponPrefab.GetComponent<EnemyLeveledWeapon>().weaponRenderer.transform;
            var pair = new ModelPair(Copy(sourceModel, appearance, actual), Copy(sourceModel, appearance, reference));
            FakeRigidBodySwapper expected = CreateReferenceSwapper(appearance, reference);
            Transform holster = SelfHostedVisualHierarchy.ResolveCopy(source.transform,
                source.GetComponentInChildren<SoldierParts>(true).coltSnap, reference.Root.transform.Find("Rig"));
            actual.Root.SetActive(true);
            reference.Root.SetActive(true);
            attachment.Draw();
            expected.Swap(false);
            Vector3 hand = CheckModel(pair, actual, appearance);
            attachment.Holster();
            expected.SnapTo(holster);
            Vector3 stored = CheckModel(pair, actual, appearance);
            Require(attachment.IsHolstered && Vector3.Distance(hand, stored) > Tolerance,
                "Holstering did not move the source model to a distinct socket.");
            attachment.Draw();
            expected.Swap(false);
            Require(!attachment.IsHolstered && Vector3.Distance(CheckModel(pair, actual, appearance), hand) < Tolerance,
                "Drawing did not restore the original hand pose.");
            Cases.Add(new { lane.Level, lane.IsElite, appearance.ModelNumber, appearance.ResourcePath,
                modelPrefab = AssetDatabase.GetAssetPath(appearance.Model.gameObject),
                modelPrefabSha256 = Hash(AssetDatabase.GetAssetPath(appearance.Model.gameObject)),
                mesh = AssetDatabase.GetAssetPath(appearance.Model.GetComponent<MeshFilter>().sharedMesh),
                meshSha256 = Hash(AssetDatabase.GetAssetPath(appearance.Model.GetComponent<MeshFilter>().sharedMesh)),
                material = AssetDatabase.GetAssetPath(appearance.Model.GetComponent<Renderer>().sharedMaterial),
                materialSha256 = Hash(AssetDatabase.GetAssetPath(
                    appearance.Model.GetComponent<Renderer>().sharedMaterial)),
                hand = new[] { hand.x, hand.y, hand.z }, holster = new[] { stored.x, stored.y, stored.z } });
        }
        finally
        {
            if (reference != null)
            {
                UnityEngine.Object.DestroyImmediate(reference.Root);
            }
            UnityEngine.Object.DestroyImmediate(actual.Root);
        }
    }

    private static FakeRigidBodySwapper CreateReferenceSwapper(SelfHostedInfantryWeaponAppearance appearance,
        SelfHostedInfantryVisual visual)
    {
        FakeRigidBodySwapper original = appearance.WeaponPrefab.GetComponent<FakeRigidBodySwapper>();
        visual.WeaponRoot.gameObject.SetActive(false);
        FakeRigidBodySwapper reference = visual.WeaponRoot.gameObject.AddComponent<UnityGunslingerReferenceSwapper>();
        reference.NoRigidBodyObject = Copy(original.NoRigidBodyObject.transform, appearance, visual).gameObject;
        reference.RigidBodyObject = Copy(original.RigidBodyObject.transform, appearance, visual).gameObject;
        reference.snapPoint = Copy(original.snapPoint.transform, appearance, visual).gameObject;
        reference.noRigidBody = new FakeRigidBodySwapper.MeshFliterAndRenderer
        {
            meshFilter = reference.NoRigidBodyObject.GetComponent<MeshFilter>(),
            meshRenderer = reference.NoRigidBodyObject.GetComponent<Renderer>()
        };
        reference.rigidBody = new FakeRigidBodySwapper.MeshFliterAndRenderer
        {
            meshFilter = reference.RigidBodyObject.GetComponent<MeshFilter>(),
            meshRenderer = reference.RigidBodyObject.GetComponent<Renderer>()
        };
        reference.Init();
        visual.WeaponRoot.gameObject.SetActive(true);
        return reference;
    }

    private static Transform Copy(Transform target, SelfHostedInfantryWeaponAppearance appearance,
        SelfHostedInfantryVisual visual)
    {
        return SelfHostedVisualHierarchy.ResolveCopy(appearance.WeaponPrefab.transform, target, visual.WeaponRoot);
    }

    private static Vector3 CheckModel(ModelPair pair, SelfHostedInfantryVisual actual,
        SelfHostedInfantryWeaponAppearance appearance)
    {
        Transform expected = pair.Reference;
        Transform current = pair.Actual;
        Require(Vector3.Distance(current.position, expected.position) < Tolerance &&
            Mathf.Abs(Quaternion.Dot(current.rotation, expected.rotation)) > 1f - Tolerance &&
            Vector3.Distance(current.lossyScale, expected.lossyScale) < Tolerance,
            "The script-free model differs from the source swapper attachment pose.");
        Require(current.GetComponent<MeshFilter>().sharedMesh ==
            appearance.Model.GetComponent<MeshFilter>().sharedMesh &&
            current.GetComponent<MeshRenderer>().sharedMaterial ==
                appearance.Model.GetComponent<Renderer>().sharedMaterial &&
            current.GetComponent<MeshRenderer>().enabled && current.gameObject.activeInHierarchy &&
            actual.Root.GetComponentsInChildren<MonoBehaviour>(true).Length == 0,
            "Attachment changed model identity, material or script-free isolation.");
        return current.position;
    }

    private static int CheckPresenter(ObjectPoolDatabase pool, LevelBehaviourManager manager,
        SoldierBehaviourGunslinger family)
    {
        GameObject owner = new GameObject("GunslingerPresenterAudit");
        try
        {
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            SelfHostedInfantryPresenter presenter = owner.AddComponent<SelfHostedInfantryPresenter>();
            presenter.Configure(pool.enemy, pool.parachute, manager, client);
            SelfHostedInfantryWeaponAppearance appearance =
                SelfHostedInfantryWeaponAppearance.ResolveGunslinger(family);
            var row = new BattleArmyEntityState
            {
                EntityKey = 9001, UnitId = "ID_UNIT-GUNSLINGER", SpawnTick = 60, PositionTick = 60,
                MaxHealth = 100, Health = 100, InfantryClip = "colt_idle01",
                InfantryClipStartTick = 60, InfantryFacingZ = 1
            };
            presenter.Apply(new[] { BattleArmyEntityState.Parser.ParseFrom(row.ToByteArray()) });
            GameObject actor = GameObject.Find("SelfHostedInfantry_9001");
            MeshFilter selected = actor.GetComponentsInChildren<MeshFilter>(true).Single(filter =>
                filter.sharedMesh == appearance.Model.GetComponent<MeshFilter>().sharedMesh);
            Vector3 hand = selected.transform.position;
            Require(selected.GetComponent<MeshRenderer>().enabled && selected.gameObject.activeInHierarchy &&
                actor.GetComponentsInChildren<MonoBehaviour>(true).Length == 0,
                "The production presenter did not create an active script-free source weapon.");
            Capture(actor, "gunslinger-hand.png");
            row.IsColtHolstered = true;
            presenter.Apply(new[] { BattleArmyEntityState.Parser.ParseFrom(row.ToByteArray()) });
            Require(Vector3.Distance(hand, selected.transform.position) > Tolerance,
                "A decoded holster flag did not move the actual selected presenter model.");
            Capture(actor, "gunslinger-holstered.png");
            row.IsColtHolstered = false;
            presenter.Apply(new[] { BattleArmyEntityState.Parser.ParseFrom(row.ToByteArray()) });
            Require(Vector3.Distance(hand, selected.transform.position) < Tolerance,
                "A decoded hand flag did not restore the source weapon pose.");
            presenter.Apply(new BattleArmyEntityState[0]);
            Require(actor == null, "The production presenter leaked a removed Gunslinger.");
            return 4;
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static void Capture(GameObject actor, string name)
    {
        GameObject cameraRoot = new GameObject("GunslingerAuditCamera");
        GameObject lightRoot = new GameObject("GunslingerAuditLight");
        RenderTexture target = new RenderTexture(960, 720, 24);
        Texture2D image = new Texture2D(960, 720, TextureFormat.RGB24, false);
        RenderTexture previous = RenderTexture.active;
        try
        {
            Light light = lightRoot.AddComponent<Light>();
            light.type = LightType.Directional;
            lightRoot.transform.rotation = Quaternion.Euler(40, -25, 0);
            Camera camera = cameraRoot.AddComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = new Color(0.12f, 0.14f, 0.17f);
            Bounds bounds = actor.GetComponentInChildren<SkinnedMeshRenderer>(true).bounds;
            foreach (MeshRenderer renderer in actor.GetComponentsInChildren<MeshRenderer>())
            {
                MeshFilter filter = renderer.GetComponent<MeshFilter>();
                if (renderer.enabled && filter != null && filter.sharedMesh != null)
                {
                    bounds.Encapsulate(renderer.bounds);
                }
            }

            camera.orthographic = true;
            camera.orthographicSize = Mathf.Max(bounds.extents.y, bounds.extents.x) * 1.35f;
            camera.nearClipPlane = 0.01f;
            camera.transform.position = bounds.center + new Vector3(2.8f, 1.8f, 4f).normalized *
                Mathf.Max(1f, bounds.size.magnitude * 3f);
            camera.transform.LookAt(bounds.center);
            camera.targetTexture = target;
            camera.Render();
            RenderTexture.active = target;
            image.ReadPixels(new Rect(0, 0, 960, 720), 0, 0);
            image.Apply();
            string folder = Path.GetDirectoryName(
                Environment.GetEnvironmentVariable("WAR_GUNSLINGER_WEAPON_AUDIT_OUTPUT"));
            File.WriteAllBytes(Path.Combine(folder, name), image.EncodeToPNG());
        }
        finally
        {
            RenderTexture.active = previous;
            UnityEngine.Object.DestroyImmediate(image);
            UnityEngine.Object.DestroyImmediate(target);
            UnityEngine.Object.DestroyImmediate(cameraRoot);
            UnityEngine.Object.DestroyImmediate(lightRoot);
        }
    }

    private static Dictionary<string, string> SourceHashes()
    {
        string[] paths =
        {
            "Assets/Scripts/Assembly-CSharp/SelfHostedGunslingerWeaponAttachment.cs",
            "Assets/Scripts/Assembly-CSharp/SelfHostedInfantryWeaponAppearance.cs",
            "Assets/Scripts/Assembly-CSharp/SelfHostedVisualHierarchy.cs",
            "Assets/Scripts/Assembly-CSharp/SelfHostedInfantryVisualFactory.cs",
            "Assets/Scripts/Assembly-CSharp/SelfHostedInfantryVisual.cs",
            "Assets/Scripts/Assembly-CSharp/SelfHostedInfantryPresenter.cs",
            "Assets/Scripts/Assembly-CSharp/SelfHostedInfantryUpgradeSelection.cs",
            "Assets/Scripts/Assembly-CSharp/SelfHostedInfantrySkinAppearance.cs",
            "Assets/Scripts/Assembly-CSharp/SelfHostedInfantryShieldAppearance.cs",
            "Assets/Scripts/Assembly-CSharp/SelfHostedRiflePoseRenderer.cs",
            "Assets/Plugins/WarFriends.Networking/War.Shared.dll",
            "Assets/Plugins/WarFriends.Networking/War.Client.dll",
            "Assets/Scripts/Assembly-CSharp/FakeRigidBodySwapper.cs",
            "Assets/Scripts/Assembly-CSharp/SoldierBehaviour.cs",
            "Assets/Scripts/Assembly-CSharp/UpgradeSlotsBaseSoldier.cs",
            "Assets/Scripts/Assembly-CSharp/UpgradeSlotsGunslicer.cs",
            "Assets/Scripts/Assembly-CSharp/SoldierParts.cs",
            "Assets/Scripts/Assembly-CSharp/SpawningManager.cs",
            "Assets/Plugins/Assembly-CSharp-firstpass/SkinnedMeshTools.cs",
            "Assets/GameObject/enemy.prefab",
            "Assets/GameObject/AssaultRifleEnemy.prefab",
            "Assets/Scenes/MainScene.unity",
            "Assets/Editor/UnityGunslingerWeaponAttachmentAudit.cs",
            "Assets/UnityGunslingerReferenceSwapper.cs"
        };
        return paths.ToDictionary(path => path, Hash);
    }

    private static string Hash(string path)
    {
        using (SHA256 hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed class ModelPair
    {
        internal readonly Transform Actual;
        internal readonly Transform Reference;

        internal ModelPair(Transform actual, Transform reference)
        {
            Actual = actual;
            Reference = reference;
        }
    }

    private sealed class LaneCase
    {
        internal readonly int Level;
        internal readonly bool IsElite;

        internal LaneCase(int level, bool isElite)
        {
            Level = level;
            IsElite = isElite;
        }
    }
}
