using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Compares copied Mortar attachment operations with the actual recovered swapper implementation.</summary>
public static class UnityMortarWeaponAttachmentAudit
{
    private const int NormalLevels = 26;
    private const float Tolerance = 0.00001f;
    private static int _checks;

    /// <summary>Verifies every normal upgrade selection without activating gameplay or provider components.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
        var components = scene.GetRootGameObjects().SelectMany(root =>
            root.GetComponentsInChildren<Component>(true)).ToArray();
        EnemyController source = components.OfType<ObjectPoolDatabase>().Single().enemy;
        SoldierBehaviourMortar family = components.OfType<LevelBehaviourManager>().Single().levelBehaviours
            .Select(entry => entry.behaviour).OfType<SoldierBehaviourMortar>().Single();
        for (int level = 0; level < NormalLevels; level++)
        {
            CheckLevel(source, family, level);
        }
        CheckDestroyedOwner(source, family);
        UnityOfflineLauncherAudit.Run();
        string output = Path.Combine(Directory.GetParent(Application.dataPath).FullName,
            "mortar-weapon-attachment-audit.json");
        File.WriteAllText(output, (JsonConvert.SerializeObject(new
        {
            unityVersion = Application.unityVersion,
            scope = "Source SetParent/Swap transform comparison; no host attachment snapshot or normal gameplay proof.",
            normalLevels = NormalLevels,
            checks = _checks
        }, Formatting.Indented) + "\n").Replace("\r\n", "\n"));
        Debug.Log("UNITY_MORTAR_WEAPON_ATTACHMENT_PASSED checks=" + _checks);
        UnityOrdinaryInfantryWeaponsAudit.Run();
    }

    private static void CheckLevel(EnemyController source, SoldierBehaviourMortar family, int level)
    {
        var upgrades = new UpgradeSlots.UnitUpgrades(1f) { slotUpgradeindex = level };
        SelfHostedInfantryVisual actual = SelfHostedInfantryVisualFactory.Create(
            source, family.soldierVisuals[0], "ActualMortar");
        SelfHostedInfantryVisual reference = SelfHostedInfantryVisualFactory.Create(
            source, family.soldierVisuals[0], "ReferenceMortar");
        var world = new GameObject("ReferenceWorld");
        SelfHostedMortarWeaponAttachment attachment = null;
        Transform referenceSnap = null;
        Transform actualSnap = null;
        try
        {
            var actualWeapons = SelfHostedInfantryWeaponSet.CreateOrdinary(family, source, actual, upgrades);
            var referenceWeapons = SelfHostedInfantryWeaponSet.CreateOrdinary(family, source, reference, upgrades);
            Weapon prefab = family.GetComponent<EnemyBasicInventory>().weapons[0].weapon;
            attachment = SelfHostedMortarWeaponAttachment.Bind(prefab, actualWeapons, actual.Root);
            var original = prefab.GetComponent<FakeRigidBodySwapper>();
            actualSnap = actualWeapons.ResolveSource(0, original.snapPoint.transform);
            referenceSnap = referenceWeapons.ResolveSource(0, original.snapPoint.transform);
            FakeRigidBodySwapper swapper = CreateReference(original, referenceWeapons);
            Require(actualSnap.parent == actualWeapons.ResolveSource(0, original.NoRigidBodyObject.transform),
                "The retained identity map lost the snap point after held-state reparenting.");
            Require(swapper.GetType().GetMethod("SetParent").DeclaringType == typeof(FakeRigidBodySwapper) &&
                swapper.GetType().GetMethod("Swap").DeclaringType == typeof(FakeRigidBodySwapper),
                "Reference attachment operations must remain inherited from the recovered source.");
            actual.Root.SetActive(true);
            reference.Root.SetActive(true);
            SetActorPose(actual, reference, new Vector3(3f, -0.25f, 7f), Quaternion.Euler(0f, 37f, 0f));
            attachment.RestoreHand();
            swapper.Swap(false);
            Compare(actualSnap, referenceSnap);
            attachment.Detach();
            swapper.SetParent(world.transform);
            Vector3 detached = actualSnap.position;
            Compare(actualSnap, referenceSnap);
            SetActorPose(actual, reference, new Vector3(-2f, 1f, 4f), Quaternion.Euler(0f, 123f, 0f));
            attachment.Detach();
            Require(attachment.IsDetached && Vector3.Distance(actualSnap.position, detached) < Tolerance,
                "Repeated detach or later actor movement changed the retained world pose.");
            Compare(actualSnap, referenceSnap);
            attachment.RestoreHand();
            swapper.Swap(false);
            Require(!attachment.IsDetached && Vector3.Distance(actualSnap.position, detached) > Tolerance,
                "Restoring the hand did not rejoin the moved source socket.");
            Compare(actualSnap, referenceSnap);
            attachment.Detach();
            attachment.Dispose();
            attachment.Dispose();
            Require(actualSnap.IsChildOf(actual.Root.transform),
                "Disposal left a detached mesh outside the actor's lifetime root.");
            Require(actual.Root.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
                actual.Root.GetComponentsInChildren<Collider>(true).Length == 0,
                "Attachment introduced recovered gameplay or collision components.");
            UnityEngine.Object.DestroyImmediate(actual.Root);
            Require(actualSnap == null, "Actor removal left disposed detached geometry in the scene.");
        }
        finally
        {
            if (attachment != null) attachment.Dispose();
            UnityEngine.Object.DestroyImmediate(actual.Root);
            UnityEngine.Object.DestroyImmediate(reference.Root);
            if (referenceSnap != null) UnityEngine.Object.DestroyImmediate(referenceSnap.gameObject);
            if (actualSnap != null) UnityEngine.Object.DestroyImmediate(actualSnap.gameObject);
            UnityEngine.Object.DestroyImmediate(world);
        }
    }

    private static void CheckDestroyedOwner(EnemyController source, SoldierBehaviourMortar family)
    {
        SelfHostedInfantryVisual actor = SelfHostedInfantryVisualFactory.Create(
            source, family.soldierVisuals[0], "DestroyedMortarOwner");
        SelfHostedMortarWeaponAttachment attachment = null;
        Transform snap = null;
        try
        {
            var upgrades = new UpgradeSlots.UnitUpgrades(1f) { slotUpgradeindex = 0 };
            var weapons = SelfHostedInfantryWeaponSet.CreateOrdinary(family, source, actor, upgrades);
            Weapon prefab = family.GetComponent<EnemyBasicInventory>().weapons[0].weapon;
            attachment = SelfHostedMortarWeaponAttachment.Bind(prefab, weapons, actor.Root);
            snap = weapons.ResolveSource(0, prefab.GetComponent<FakeRigidBodySwapper>().snapPoint.transform);
            actor.Root.SetActive(true);
            attachment.Detach();
            UnityEngine.Object.DestroyImmediate(actor.Root);
            attachment.Dispose();
            attachment.Dispose();
            Require(snap == null, "Disposal after owner destruction leaked the detached Mortar model.");
        }
        finally
        {
            if (attachment != null) attachment.Dispose();
            if (actor.Root != null) UnityEngine.Object.DestroyImmediate(actor.Root);
            if (snap != null) UnityEngine.Object.DestroyImmediate(snap.gameObject);
        }
    }

    private static FakeRigidBodySwapper CreateReference(FakeRigidBodySwapper source,
        SelfHostedInfantryWeaponSet weapons)
    {
        GameObject root = weapons.Roots[0];
        root.SetActive(false);
        var swapper = root.AddComponent<UnityGunslingerReferenceSwapper>();
        swapper.snapPoint = weapons.ResolveSource(0, source.snapPoint.transform).gameObject;
        swapper.NoRigidBodyObject = weapons.ResolveSource(0, source.NoRigidBodyObject.transform).gameObject;
        swapper.RigidBodyObject = weapons.ResolveSource(0, source.RigidBodyObject.transform).gameObject;
        swapper.noRigidBody = new FakeRigidBodySwapper.MeshFliterAndRenderer();
        swapper.rigidBody = new FakeRigidBodySwapper.MeshFliterAndRenderer();
        swapper.Init();
        root.SetActive(true);
        return swapper;
    }

    private static void SetActorPose(SelfHostedInfantryVisual actual, SelfHostedInfantryVisual reference,
        Vector3 position, Quaternion rotation)
    {
        actual.Root.transform.position = position;
        actual.Root.transform.rotation = rotation;
        reference.Root.transform.position = position;
        reference.Root.transform.rotation = rotation;
    }

    private static void Compare(Transform actual, Transform reference)
    {
        Require(Vector3.Distance(actual.position, reference.position) < Tolerance &&
            Mathf.Abs(Quaternion.Dot(actual.rotation, reference.rotation)) > 1f - Tolerance &&
            Vector3.Distance(actual.lossyScale, reference.lossyScale) < Tolerance,
            "Copied Mortar attachment differs from the recovered source swapper.");
        MeshFilter[] actualMeshes = actual.GetComponentsInChildren<MeshFilter>(true);
        MeshFilter[] referenceMeshes = reference.GetComponentsInChildren<MeshFilter>(true);
        Require(actualMeshes.Length > 0 && actualMeshes.Length == referenceMeshes.Length,
            "Mortar attachment lost its source-selected meshes.");
        for (int index = 0; index < actualMeshes.Length; index++)
        {
            Require(actualMeshes[index].sharedMesh == referenceMeshes[index].sharedMesh &&
                Vector3.Distance(actualMeshes[index].transform.position,
                    referenceMeshes[index].transform.position) < Tolerance,
                "Mortar model selection or world placement changed during attachment.");
            MeshRenderer actualRenderer = actualMeshes[index].GetComponent<MeshRenderer>();
            MeshRenderer referenceRenderer = referenceMeshes[index].GetComponent<MeshRenderer>();
            Require(actualRenderer != null && referenceRenderer != null &&
                actualRenderer.sharedMaterials.SequenceEqual(referenceRenderer.sharedMaterials) &&
                actualRenderer.enabled == referenceRenderer.enabled &&
                actualRenderer.gameObject.activeInHierarchy == referenceRenderer.gameObject.activeInHierarchy,
                "Mortar attachment changed the source material or visible renderer state.");
        }
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
