using System;
using System.Collections.Generic;
using UnityEngine;
using War.Protocol;

// Renders ordinary infantry from recovered meshes and clips. No copied object
// runs AI, collision, damage, pooling, or Photon behaviour.
public sealed class SelfHostedInfantryPresenter : MonoBehaviour
{
    private sealed class Visual
    {
        public GameObject Root;
        public SelfHostedRemoteTransformBuffer Motion;
        public GameObject AnimationRoot;
        public AnimationClip Clip;
        public ulong ClipStartTick;
        public float SecondsAtReceive;
        public float ReceivedAt;
    }

    private readonly Dictionary<ulong, Visual> active = new Dictionary<ulong, Visual>();
    private readonly Dictionary<string, SoldierBehaviour> behaviours =
        new Dictionary<string, SoldierBehaviour>(StringComparer.Ordinal);
    private EnemyController source;
    private SelfHostedBattleClient client;

    public void Configure(EnemyController enemyPrefab,
        LevelBehaviourManager behaviourManager, SelfHostedBattleClient battleClient)
    {
        if (enemyPrefab == null || enemyPrefab.meshChanger == null ||
            behaviourManager == null || behaviourManager.levelBehaviours == null ||
            battleClient == null)
            throw new InvalidOperationException("Recovered infantry visual sources are absent.");

        source = enemyPrefab;
        client = battleClient;
        foreach (var entry in behaviourManager.levelBehaviours)
        {
            var soldier = entry.behaviour as SoldierBehaviour;
            if (soldier == null || string.IsNullOrEmpty(soldier.unitDictionaryId) ||
                soldier.soldierVisuals == null || soldier.soldierVisuals.Count == 0)
                continue;
            if (!behaviours.ContainsKey(soldier.unitDictionaryId))
                behaviours.Add(soldier.unitDictionaryId, soldier);
        }
    }

    public void Apply(IReadOnlyList<BattleArmyEntityState> rows)
    {
        if (rows == null) throw new ArgumentNullException("rows");
        var present = new HashSet<ulong>();
        foreach (var row in rows)
        {
            if (string.IsNullOrEmpty(row.InfantryClip)) continue;
            if (row.SourceCardId.Length != 0) continue; // Card infantry needs its own pose ledger.
            if (!behaviours.ContainsKey(row.UnitId))
                throw new InvalidOperationException("The host sent an unknown infantry visual family.");
            Validate(row);
            if (!present.Add(row.EntityKey))
                throw new InvalidOperationException("The infantry page contains a duplicate entity.");

            Visual visual;
            if (!active.TryGetValue(row.EntityKey, out visual))
            {
                visual = Create(row);
                active.Add(row.EntityKey, visual);
            }
            UpdateVisual(visual, row);
        }

        var removed = new List<ulong>();
        foreach (var pair in active)
            if (!present.Contains(pair.Key)) removed.Add(pair.Key);
        foreach (var entityKey in removed)
        {
            DestroyVisual(active[entityKey].Root);
            active.Remove(entityKey);
        }
    }

    private static void Validate(BattleArmyEntityState row)
    {
        var facing = new Vector3(row.InfantryFacingX,
            row.InfantryFacingY, row.InfantryFacingZ);
        if (row.EntityKey == 0 || row.PositionTick < row.SpawnTick ||
            !Finite(row.X) || !Finite(row.Y) || !Finite(row.Z) ||
            !Finite(facing.x) || !Finite(facing.y) || !Finite(facing.z) ||
            Mathf.Abs(facing.sqrMagnitude - 1f) > .001f ||
            !Finite(row.MaxHealth) || row.MaxHealth <= 0 ||
            !Finite(row.Health) || row.Health <= 0 || row.Health > row.MaxHealth ||
            !Finite(row.MaxKevlar) || row.MaxKevlar < 0 ||
            !Finite(row.Kevlar) || row.Kevlar < 0 || row.Kevlar > row.MaxKevlar)
            throw new InvalidOperationException("Invalid authoritative infantry visual state.");
    }

    private Visual Create(BattleArmyEntityState row)
    {
        var soldier = behaviours[row.UnitId];
        int styleIndex = (int)(row.EntityKey % (ulong)soldier.soldierVisuals.Count);
        var style = soldier.soldierVisuals[styleIndex];
        style.LoadModel();
        var sourceSkin = source.meshChanger.skinnedMeshRenderer;
        if (style.modelMeshRenderer == null || style.modelMeshRenderer.sharedMesh == null ||
            sourceSkin == null || sourceSkin.bones == null || sourceSkin.rootBone == null)
            throw new InvalidOperationException("Recovered infantry mesh or skeleton is absent.");

        var root = new GameObject("SelfHostedInfantry_" + row.EntityKey);
        var rig = new GameObject("Rig");
        rig.transform.SetParent(root.transform, false);
        var map = new Dictionary<Transform, Transform>();
        CopyVisualHierarchy(source.transform, rig.transform, true, map);

        var skin = map[sourceSkin.transform].gameObject.AddComponent<SkinnedMeshRenderer>();
        skin.sharedMesh = style.modelMeshRenderer.sharedMesh;
        skin.sharedMaterials = style.modelMeshRenderer.sharedMaterials;
        var bones = new Transform[sourceSkin.bones.Length];
        for (int i = 0; i < bones.Length; i++) bones[i] = map[sourceSkin.bones[i]];
        skin.bones = bones;
        skin.rootBone = map[sourceSkin.rootBone];
        skin.localBounds = sourceSkin.localBounds;
        skin.updateWhenOffscreen = sourceSkin.updateWhenOffscreen;

        var helmet = source.meshChanger.helmet;
        if (helmet != null && style.helmetMesh != null)
        {
            if (helmet.NoRigidBodyObject == null || helmet.RigidBodyObject == null)
                throw new InvalidOperationException("Recovered infantry helmet rig is absent.");
            CopyHelmet(helmet.NoRigidBodyObject.transform, style, map);
            CopyHelmet(helmet.RigidBodyObject.transform, style, map);
        }

        var animation = source.GetComponentInChildren<Animation>(true);
        if (animation == null || !map.ContainsKey(animation.transform))
            throw new InvalidOperationException("Recovered infantry animation rig is absent.");
        return new Visual { Root = root, Motion = new SelfHostedRemoteTransformBuffer(),
            AnimationRoot = map[animation.transform].gameObject };
    }

    private static void CopyHelmet(Transform sourceHelmet,
        SoldierMeshChanger.SoldierStyle style,
        Dictionary<Transform, Transform> map)
    {
        var filter = map[sourceHelmet].GetComponent<MeshFilter>();
        if (filter == null)
            throw new InvalidOperationException("Recovered infantry helmet mesh is absent.");
        filter.sharedMesh = style.helmetMesh;
        var renderer = map[sourceHelmet].GetComponent<MeshRenderer>();
        if (renderer != null && style.helmetMaterials != null &&
            style.helmetMaterials.Count > 0)
            renderer.sharedMaterials = style.helmetMaterials.ToArray();
    }

    private void UpdateVisual(Visual visual, BattleArmyEntityState row)
    {
        var animation = source.GetComponentInChildren<Animation>(true);
        var clip = animation == null ? null : animation.GetClip(row.InfantryClip);
        if (clip == null || clip.length <= 0)
            throw new InvalidOperationException("The authoritative infantry clip is absent from the recovered rig.");

        var facing = new Vector3(row.InfantryFacingX,
            row.InfantryFacingY, row.InfantryFacingZ);
        var position = new Vector3(row.X, row.Y, row.Z);
        var rotation = Quaternion.LookRotation(facing, Vector3.up);
        visual.Motion.Add(row.PositionTick, position, rotation, Time.realtimeSinceStartup);
        if (visual.Motion.Count == 1)
        {
            visual.Root.transform.position = position;
            visual.Root.transform.rotation = rotation;
        }
        visual.Clip = clip;
        visual.ClipStartTick = row.InfantryClipStartTick;
        ulong serverTick = client.State == null ? row.PositionTick : client.State.ServerTick;
        visual.SecondsAtReceive = serverTick >= visual.ClipStartTick ?
            (float)((serverTick - visual.ClipStartTick) / 30.0) : 0f;
        visual.ReceivedAt = Time.realtimeSinceStartup;
        Sample(visual, visual.SecondsAtReceive);
    }

    private void Update()
    {
        RenderAt(Time.realtimeSinceStartup, Time.deltaTime);
    }

    public void RenderAt(float realtime, float frameSeconds)
    {
        foreach (var visual in active.Values)
        {
            visual.Motion.Render(visual.Root.transform, realtime, frameSeconds);
            float elapsed = Mathf.Max(0f, realtime - visual.ReceivedAt);
            Sample(visual, visual.SecondsAtReceive + elapsed);
        }
    }

    private static void Sample(Visual visual, float seconds)
    {
        if (visual.Clip != null)
            visual.Clip.SampleAnimation(visual.AnimationRoot,
                Mathf.Repeat(seconds, visual.Clip.length));
    }

    private static void CopyVisualHierarchy(Transform sourcePart, Transform copyPart,
        bool root, Dictionary<Transform, Transform> map)
    {
        map.Add(sourcePart, copyPart);
        copyPart.localScale = sourcePart.localScale;
        if (!root)
        {
            copyPart.localPosition = sourcePart.localPosition;
            copyPart.localRotation = sourcePart.localRotation;
            copyPart.gameObject.SetActive(sourcePart.gameObject.activeSelf);
        }
        var filter = sourcePart.GetComponent<MeshFilter>();
        var renderer = sourcePart.GetComponent<MeshRenderer>();
        if (filter != null && renderer != null)
        {
            copyPart.gameObject.AddComponent<MeshFilter>().sharedMesh = filter.sharedMesh;
            var copyRenderer = copyPart.gameObject.AddComponent<MeshRenderer>();
            copyRenderer.sharedMaterials = renderer.sharedMaterials;
            copyRenderer.enabled = renderer.enabled;
        }
        for (int i = 0; i < sourcePart.childCount; i++)
        {
            var child = sourcePart.GetChild(i);
            var copy = new GameObject(child.name);
            copy.transform.SetParent(copyPart, false);
            CopyVisualHierarchy(child, copy.transform, false, map);
        }
    }

    private void OnDestroy()
    {
        foreach (var visual in active.Values) DestroyVisual(visual.Root);
        active.Clear();
    }

    private static void DestroyVisual(GameObject root)
    {
        if (Application.isPlaying) UnityEngine.Object.Destroy(root);
        else UnityEngine.Object.DestroyImmediate(root);
    }

    private static bool Finite(float value)
    {
        return !float.IsNaN(value) && !float.IsInfinity(value);
    }
}
