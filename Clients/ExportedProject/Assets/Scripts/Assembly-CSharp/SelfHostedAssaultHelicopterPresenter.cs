using System;
using System.Collections.Generic;
using UnityEngine;
using War.Protocol;

// A visual copy of the recovered prefab. The Worker owns movement, collision,
// glass health and damage; this component only presents roster state.
public sealed class SelfHostedAssaultHelicopterPresenter : MonoBehaviour
{
    private sealed class GlassVisual
    {
        public MeshFilter Filter;
        public Mesh IntactMesh;
        public Mesh BrokenMesh;
    }

    private sealed class Visual
    {
        public GameObject Root;
        public GlassVisual[] Glass;
        public SelfHostedRemoteTransformBuffer Transform;
    }

    private readonly Dictionary<ulong,Visual> active = new Dictionary<ulong,Visual>();
    private AssaultHelicopter source;

    public void Configure(AssaultHelicopter prefab)
    {
        source = prefab;
    }

    public void Apply(IReadOnlyList<BattleArmyEntityState> rows)
    {
        if (rows == null) throw new ArgumentNullException("rows");
        var present = new HashSet<ulong>();
        foreach (var row in rows)
        {
            if (row.UnitId != "ID_UNIT-ASSAULTHELI") continue;
            if (row.AssaultRotation == null ||
                !ValidRotation(row.AssaultRotation) ||
                !ValidGlassHealth(row))
                throw new InvalidOperationException("Authoritative Assault Helicopter state is invalid.");

            present.Add(row.EntityKey);
            Visual visual;
            if (!active.TryGetValue(row.EntityKey, out visual))
            {
                visual = Create(row.EntityKey);
                active.Add(row.EntityKey, visual);
            }
            var hostPosition = new Vector3(row.X, row.Y, row.Z);
            var hostRotation = new Quaternion(row.AssaultRotation.X,
                row.AssaultRotation.Y, row.AssaultRotation.Z, row.AssaultRotation.W);
            visual.Transform.Add(row.PositionTick, hostPosition, hostRotation,
                Time.realtimeSinceStartup);
            if (visual.Transform.Count == 1)
            {
                visual.Root.transform.position = hostPosition;
                visual.Root.transform.rotation = hostRotation;
            }
            bool broken = row.AssaultGlassHealth == 0f;
            foreach (var glass in visual.Glass)
                glass.Filter.sharedMesh = broken ? glass.BrokenMesh : glass.IntactMesh;
        }

        var removed = new List<ulong>();
        foreach (var entry in active)
            if (!present.Contains(entry.Key)) removed.Add(entry.Key);
        foreach (ulong entityKey in removed)
        {
            DestroyVisual(active[entityKey].Root);
            active.Remove(entityKey);
        }
    }

    private void Update()
    {
        RenderAt(Time.realtimeSinceStartup, Time.deltaTime);
    }

    // The recovered AssaultHelicopter updates PhotonTransform only on a
    // remote kinematic copy. Rendering never changes Worker collision or health.
    public void RenderAt(float realtime, float frameSeconds)
    {
        foreach (var visual in active.Values)
            visual.Transform.Render(visual.Root.transform, realtime, frameSeconds);
    }

    private Visual Create(ulong entityKey)
    {
        if (source == null || source.glass == null || source.glass.Count != 3)
            throw new InvalidOperationException("Recovered Assault Helicopter glass sources are absent.");
        var root = new GameObject("SelfHostedAssaultHelicopter_" + entityKey);
        var copiedTransforms = new Dictionary<Transform,Transform>();
        Copy(source.transform, root.transform, true, copiedTransforms);

        var glassVisuals = new GlassVisual[source.glass.Count];
        for (int index = 0; index < source.glass.Count; index++)
        {
            Glass glass = source.glass[index];
            if (glass == null || glass.glassMesh == null || glass.brokenGlassMesh == null ||
                !copiedTransforms.ContainsKey(glass.transform))
                throw new InvalidOperationException("Recovered Assault Helicopter glass mesh is absent.");
            MeshFilter filter = copiedTransforms[glass.transform].GetComponent<MeshFilter>();
            if (filter == null)
                throw new InvalidOperationException("Copied Assault Helicopter glass filter is absent.");
            filter.sharedMesh = glass.glassMesh;
            glassVisuals[index] = new GlassVisual
            {
                Filter = filter,
                IntactMesh = glass.glassMesh,
                BrokenMesh = glass.brokenGlassMesh
            };
        }
        return new Visual
        {
            Root = root,
            Glass = glassVisuals,
            Transform = new SelfHostedRemoteTransformBuffer()
        };
    }

    private static bool ValidGlassHealth(BattleArmyEntityState row)
    {
        return !float.IsNaN(row.AssaultGlassMaxHealth) &&
               !float.IsInfinity(row.AssaultGlassMaxHealth) &&
               row.AssaultGlassMaxHealth > 0f &&
               row.AssaultGlassMaxHealth <= 10000000f &&
               !float.IsNaN(row.AssaultGlassHealth) &&
               !float.IsInfinity(row.AssaultGlassHealth) &&
               row.AssaultGlassHealth >= 0f &&
               row.AssaultGlassHealth <= row.AssaultGlassMaxHealth;
    }

    private static bool ValidRotation(BattleJointRotation rotation)
    {
        float length = rotation.X * rotation.X + rotation.Y * rotation.Y +
            rotation.Z * rotation.Z + rotation.W * rotation.W;
        return !float.IsNaN(length) && !float.IsInfinity(length) &&
               Mathf.Abs(length - 1f) <= .001f;
    }

    private static void Copy(Transform from, Transform to, bool root,
        Dictionary<Transform,Transform> copiedTransforms)
    {
        copiedTransforms.Add(from, to);
        to.localScale = from.localScale;
        if (!root)
        {
            to.localPosition = from.localPosition;
            to.localRotation = from.localRotation;
            to.gameObject.SetActive(from.gameObject.activeSelf);
        }
        var filter = from.GetComponent<MeshFilter>();
        var renderer = from.GetComponent<MeshRenderer>();
        if (filter != null && renderer != null)
        {
            to.gameObject.AddComponent<MeshFilter>().sharedMesh = filter.sharedMesh;
            var copy = to.gameObject.AddComponent<MeshRenderer>();
            copy.sharedMaterials = renderer.sharedMaterials;
            copy.enabled = renderer.enabled;
            copy.shadowCastingMode = renderer.shadowCastingMode;
            copy.receiveShadows = renderer.receiveShadows;
        }
        for (int index = 0; index < from.childCount; index++)
        {
            Transform child = from.GetChild(index);
            var copy = new GameObject(child.name);
            copy.transform.SetParent(to, false);
            Copy(child, copy.transform, false, copiedTransforms);
        }
    }

    private void OnDestroy()
    {
        foreach (var visual in active.Values) DestroyVisual(visual.Root);
        active.Clear();
    }

    private static void DestroyVisual(GameObject value)
    {
        if (Application.isPlaying) UnityEngine.Object.Destroy(value);
        else UnityEngine.Object.DestroyImmediate(value);
    }
}
