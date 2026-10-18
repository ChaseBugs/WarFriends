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
        public GameObject Canopy;
        public Quaternion CanopyRotation;
        public bool CanopyAttached;
        public float CanopyExpiryAt;
        public Material CanopyLandingMaterial;
        public SelfHostedGunslingerWeaponAttachment GunslingerAttachment { get; set; }
        public SelfHostedInfantrySkinAppearance SkinAppearance { get; set; }
    }

    private sealed class RetiredCanopy
    {
        public ulong EntityKey;
        public GameObject Root;
        public Material LandingMaterial;
        public float ExpiresAt;
    }

    private readonly Dictionary<ulong, Visual> active = new Dictionary<ulong, Visual>();
    private readonly List<RetiredCanopy> retiredCanopies = new List<RetiredCanopy>();
    private readonly Dictionary<string, SoldierBehaviour> behaviours =
        new Dictionary<string, SoldierBehaviour>(StringComparer.Ordinal);
    private EnemyController source;
    private Parachute parachuteSource;
    private SelfHostedBattleClient client;
    private SelfHostedInfantryUpgradeSelection _upgradeSelection;
    private string _localAppearanceOwner;
    private Texture2D _appearanceMatCap;

    /// <summary>Binds the recovered map lighting and local perspective before any infantry is created.</summary>
    public void BindTeamAppearance(string localPlayerId, Texture2D matCap)
    {
        if (_upgradeSelection == null || !_upgradeSelection.HasPlayer(localPlayerId) ||
            _localAppearanceOwner != null || active.Count != 0)
        {
            throw new InvalidOperationException("Bind one admitted appearance perspective before infantry creation.");
        }

        _localAppearanceOwner = localPlayerId;
        _appearanceMatCap = matCap;
    }

    /// <summary>Binds immutable owner equipment before the PvP bridge subscribes to roster updates.</summary>
    public void BindPlayerAppearances(IReadOnlyList<BattlePlayerView> players)
    {
        if (_upgradeSelection != null || active.Count != 0)
        {
            throw new InvalidOperationException("Bind admitted equipment once before infantry creation.");
        }

        _upgradeSelection = new SelfHostedInfantryUpgradeSelection(players);
    }

    public void Configure(EnemyController enemyPrefab, Parachute parachutePrefab,
        LevelBehaviourManager behaviourManager, SelfHostedBattleClient battleClient)
    {
        if (enemyPrefab == null || enemyPrefab.meshChanger == null ||
            behaviourManager == null || behaviourManager.levelBehaviours == null ||
            battleClient == null)
            throw new InvalidOperationException("Recovered infantry visual sources are absent.");

        source = enemyPrefab;
        parachuteSource = parachutePrefab;
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
            if (row.SourceCardId.Length != 0 &&
                row.SourceCardId != "ELITEMINIGUN" &&
                row.SourceCardId != "ELITESWAT" &&
                row.SourceCardId != "ELITESNIPER" &&
                row.SourceCardId != "ELITEPARA" &&
                row.SourceCardId != "BIGROCKET" &&
                row.SourceCardId != "GREATGRENADIER") continue;
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
            var visual = active[entityKey];
            if (visual.Canopy != null && !visual.CanopyAttached &&
                Time.realtimeSinceStartup < visual.CanopyExpiryAt)
            {
                // The original Parachute object outlives its soldier after
                // landing. Its host impact pose and deadline remain valid.
                retiredCanopies.Add(new RetiredCanopy
                {
                    EntityKey = entityKey,
                    Root = visual.Canopy,
                    LandingMaterial = visual.CanopyLandingMaterial,
                    ExpiresAt = visual.CanopyExpiryAt
                });
                visual.Canopy = null;
                visual.CanopyLandingMaterial = null;
            }
            DestroyVisual(visual);
            active.Remove(entityKey);
        }
    }

    public void ApplyEvent(MatchEvent item)
    {
        if (item.Kind != MatchEventKind.ArmyDied ||
            item.SourceCardId != "ELITEPARA" || item.ParachuteEntityKey == 0)
            return;
        if (item.ParachuteLandingTick > item.Tick ||
            item.Tick - item.ParachuteLandingTick >= 90UL ||
            !ValidRotation(item.ParachuteRotation) ||
            !Finite(item.ParachuteLandingX) || !Finite(item.ParachuteLandingY) ||
            !Finite(item.ParachuteLandingZ))
            throw new InvalidOperationException("Invalid authoritative parachute death pose.");
        ulong observedTick = client != null && client.State != null ?
            Math.Max(item.Tick, client.State.ServerTick) : item.Tick;
        ulong expiryTick = item.ParachuteLandingTick + 90UL;
        if (observedTick >= expiryTick) return;
        foreach (var retired in retiredCanopies)
            if (retired.EntityKey == item.ParachuteEntityKey) return;
        Visual visual;
        if (active.TryGetValue(item.ParachuteEntityKey, out visual) &&
            visual.Canopy != null && !visual.CanopyAttached)
            return;
        if (parachuteSource == null || parachuteSource.parashuteRenderer == null ||
            parachuteSource.parashuteRenderer.GetComponent<MeshFilter>() == null)
            throw new InvalidOperationException("Recovered parachute canopy mesh is absent.");
        var canopy = new GameObject("ParachuteCanopy");
        var sourceMap = new Dictionary<Transform, Transform>();
        SelfHostedVisualHierarchy.CopyRoot(parachuteSource.transform, canopy.transform, sourceMap);
        var renderer = canopy.GetComponentInChildren<MeshRenderer>(true);
        var shader = Shader.Find("Legacy Shaders/Transparent/DiffuseNew");
        if (renderer == null || renderer.sharedMaterial == null || shader == null)
        {
            DestroyVisual(canopy);
            throw new InvalidOperationException("Recovered parachute landing material is absent.");
        }
        var material = new Material(renderer.sharedMaterial);
        material.shader = shader;
        renderer.sharedMaterial = material;
        canopy.transform.position = new Vector3(item.ParachuteLandingX,
            item.ParachuteLandingY, item.ParachuteLandingZ);
        canopy.transform.rotation = new Quaternion(item.ParachuteRotation.X,
            item.ParachuteRotation.Y, item.ParachuteRotation.Z,
            item.ParachuteRotation.W);
        retiredCanopies.Add(new RetiredCanopy
        {
            EntityKey = item.ParachuteEntityKey,
            Root = canopy,
            LandingMaterial = material,
            ExpiresAt = Time.realtimeSinceStartup +
                (float)((expiryTick - observedTick) / 30.0)
        });
        if (visual != null && visual.Canopy != null) DestroyCanopy(visual);
    }

    public void ApplySnapshot(MatchSnapshot snapshot)
    {
        if (snapshot == null) throw new ArgumentNullException("snapshot");
        foreach (BattleLandedCanopyState canopy in snapshot.LandedCanopies)
        {
            // Use the same visual and lifetime path as the replayable death event.
            ApplyEvent(new MatchEvent
            {
                Kind = MatchEventKind.ArmyDied,
                SourceCardId = "ELITEPARA",
                Tick = snapshot.ServerTick,
                ParachuteEntityKey = canopy.EntityKey,
                ParachuteLandingTick = canopy.LandingTick,
                ParachuteRotation = canopy.Rotation,
                ParachuteLandingX = canopy.X,
                ParachuteLandingY = canopy.Y,
                ParachuteLandingZ = canopy.Z
            });
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
            !Finite(row.Kevlar) || row.Kevlar < 0 || row.Kevlar > row.MaxKevlar ||
            !ValidParachute(row) ||
            (row.IsColtHolstered && (row.UnitId != "ID_UNIT-GUNSLINGER" || row.SourceCardId.Length != 0)))
        {
            throw new InvalidOperationException("Invalid authoritative infantry visual state.");
        }
    }

    private static bool ValidParachute(BattleArmyEntityState row)
    {
        bool hasLandingPosition = row.ParachuteLandingX != 0 ||
            row.ParachuteLandingY != 0 || row.ParachuteLandingZ != 0;
        if (!row.ParachuteActive && row.ParachuteLandingTick == 0)
            return row.ParachuteRotation == null && !hasLandingPosition;
        if (row.SourceCardId != "ELITEPARA" ||
            !ValidRotation(row.ParachuteRotation)) return false;
        if (row.ParachuteActive)
            return row.ParachuteLandingTick == 0 && !hasLandingPosition;
        return row.ParachuteLandingTick >= row.SpawnTick &&
            row.ParachuteLandingTick <= row.PositionTick &&
            Finite(row.ParachuteLandingX) &&
            Finite(row.ParachuteLandingY) && Finite(row.ParachuteLandingZ);
    }

    private static bool ValidRotation(BattleJointRotation rotation)
    {
        if (rotation == null || !Finite(rotation.X) || !Finite(rotation.Y) ||
            !Finite(rotation.Z) || !Finite(rotation.W)) return false;
        float lengthSquared = rotation.X * rotation.X + rotation.Y * rotation.Y +
            rotation.Z * rotation.Z + rotation.W * rotation.W;
        return Mathf.Abs(lengthSquared - 1f) <= .001f;
    }

    private Visual Create(BattleArmyEntityState row)
    {
        var soldier = behaviours[row.UnitId];
        var styles = row.SourceCardId.Length != 0 ?
            soldier.cardSoldierVisuals : soldier.soldierVisuals;
        if (styles == null || styles.Count == 0)
            throw new InvalidOperationException("Recovered infantry card style is absent.");
        int styleIndex = (int)(row.EntityKey % (ulong)styles.Count);
        var style = styles[styleIndex];
        string rootName = "SelfHostedInfantry_" + row.EntityKey;
        SelfHostedGunslingerWeaponAttachment attachment = null;
        SelfHostedInfantryVisual model;
        if (row.UnitId == "ID_UNIT-GUNSLINGER" && row.SourceCardId.Length == 0)
        {
            model = CreateGunslingerModel(soldier, style, rootName, out attachment);
        }
        else if (_upgradeSelection != null && soldier is SoldierBehaviourAssaulter && row.SourceCardId.Length == 0)
        {
            UpgradeSlots.UnitUpgrades upgrades = _upgradeSelection.Resolve(row, soldier);
            SelfHostedInfantryWeaponAppearance appearance = SelfHostedInfantryWeaponAppearance.ResolveOrdinary(
                (SoldierBehaviourAssaulter)soldier, upgrades);
            model = SelfHostedInfantryVisualFactory.CreateWithAppearance(source, style, appearance, rootName);
        }
        else
        {
            model = SelfHostedInfantryVisualFactory.Create(source, style, rootName);
        }
        SelfHostedInfantrySkinAppearance skin = ApplySkin(model, soldier, row);
        model.Root.SetActive(true);
        return new Visual
        {
            Root = model.Root,
            Motion = new SelfHostedRemoteTransformBuffer(),
            AnimationRoot = model.AnimationRoot,
            GunslingerAttachment = attachment,
            SkinAppearance = skin
        };
    }

    private SelfHostedInfantrySkinAppearance ApplySkin(SelfHostedInfantryVisual model,
        SoldierBehaviour family, BattleArmyEntityState actor)
    {
        if (_localAppearanceOwner == null || actor.SourceCardId.Length != 0)
        {
            return null;
        }

        var skin = new SelfHostedInfantrySkinAppearance(_appearanceMatCap);
        try
        {
            UpgradeSlots.UnitUpgrades upgrades = _upgradeSelection.Resolve(actor, family);
            List<TechnologyVisualDefinition> definitions = family.upgradeSlots.GetVisuals(upgrades);
            if (actor.OwnerPlayerId == _localAppearanceOwner)
            {
                skin.ApplyOwned(source, model, definitions);
            }
            else
            {
                skin.ApplyOpponent(source, model, definitions);
            }

            return skin;
        }
        catch
        {
            // Failed construction must release renderer-owned materials as well as the copied actor.
            skin.Dispose();
            DestroyVisual(model.Root);
            throw;
        }
    }

    private SelfHostedInfantryVisual CreateGunslingerModel(SoldierBehaviour soldier,
        SoldierMeshChanger.SoldierStyle style, string rootName, out SelfHostedGunslingerWeaponAttachment attachment)
    {
        SoldierBehaviourGunslinger family = soldier as SoldierBehaviourGunslinger;
        if (family == null)
        {
            throw new InvalidOperationException("Gunslinger presentation lost its recovered family type.");
        }

        SelfHostedInfantryWeaponAppearance appearance = SelfHostedInfantryWeaponAppearance.ResolveGunslinger(family);
        SelfHostedInfantryVisual model = SelfHostedInfantryVisualFactory.CreateWithAppearance(
            source, style, appearance, rootName);
        try
        {
            attachment = SelfHostedGunslingerWeaponAttachment.Bind(source, appearance, model);
            return model;
        }
        catch
        {
            // A rejected attachment must not leak a partly constructed actor into the next snapshot.
            DestroyVisual(model.Root);
            throw;
        }
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
        UpdateCanopy(visual, row, serverTick);
        ApplyWeaponAttachment(visual, row);
        Sample(visual, visual.SecondsAtReceive);
    }

    private static void ApplyWeaponAttachment(Visual visual, BattleArmyEntityState row)
    {
        if (visual.GunslingerAttachment == null)
        {
            return;
        }

        if (row.IsColtHolstered)
        {
            visual.GunslingerAttachment.Holster();
        }
        else
        {
            visual.GunslingerAttachment.Draw();
        }
    }

    private void UpdateCanopy(Visual visual, BattleArmyEntityState row,
        ulong serverTick)
    {
        if (!row.ParachuteActive && row.ParachuteLandingTick == 0)
        {
            DestroyCanopy(visual);
            return;
        }
        if (parachuteSource == null || parachuteSource.parashuteRenderer == null ||
            parachuteSource.parashuteRenderer.GetComponent<MeshFilter>() == null)
            throw new InvalidOperationException("Recovered parachute canopy mesh is absent.");
        if (visual.Canopy == null)
        {
            visual.Canopy = new GameObject("ParachuteCanopy");
            visual.Canopy.transform.SetParent(visual.Root.transform, false);
            var sourceMap = new Dictionary<Transform, Transform>();
            SelfHostedVisualHierarchy.CopyRoot(parachuteSource.transform,
                visual.Canopy.transform, sourceMap);
            if (visual.Canopy.GetComponentInChildren<MeshRenderer>(true) == null)
                throw new InvalidOperationException("Recovered parachute visual has no renderer.");
        }
        visual.CanopyRotation = new Quaternion(row.ParachuteRotation.X,
            row.ParachuteRotation.Y, row.ParachuteRotation.Z,
            row.ParachuteRotation.W);
        if (row.ParachuteActive)
        {
            visual.Canopy.transform.SetParent(visual.Root.transform, false);
            visual.Canopy.transform.localPosition = Vector3.zero;
            visual.CanopyAttached = true;
            visual.CanopyExpiryAt = 0;
        }
        else
        {
            ulong expiryTick = row.ParachuteLandingTick + 90UL;
            if (serverTick >= expiryTick)
            {
                DestroyCanopy(visual);
                return;
            }
            visual.Canopy.transform.SetParent(null, true);
            visual.Canopy.transform.position = new Vector3(row.ParachuteLandingX,
                row.ParachuteLandingY, row.ParachuteLandingZ);
            if (visual.CanopyLandingMaterial == null)
            {
                var landingShader = Shader.Find(
                    "Legacy Shaders/Transparent/DiffuseNew");
                var canopyRenderer = visual.Canopy.GetComponentInChildren<MeshRenderer>(true);
                if (landingShader == null || canopyRenderer == null ||
                    canopyRenderer.sharedMaterial == null)
                    throw new InvalidOperationException(
                        "Recovered parachute landing material is absent.");
                visual.CanopyLandingMaterial = new Material(
                    canopyRenderer.sharedMaterial);
                visual.CanopyLandingMaterial.shader = landingShader;
                canopyRenderer.sharedMaterial = visual.CanopyLandingMaterial;
            }
            visual.CanopyAttached = false;
            visual.CanopyExpiryAt = Time.realtimeSinceStartup +
                (float)((expiryTick - serverTick) / 30.0);
        }
        visual.Canopy.transform.rotation = visual.CanopyRotation;
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
            if (visual.Canopy != null && visual.CanopyAttached)
                visual.Canopy.transform.rotation = visual.CanopyRotation;
            if (visual.Canopy != null && !visual.CanopyAttached &&
                realtime >= visual.CanopyExpiryAt)
                DestroyCanopy(visual);
            float elapsed = Mathf.Max(0f, realtime - visual.ReceivedAt);
            Sample(visual, visual.SecondsAtReceive + elapsed);
        }
        for (int index = retiredCanopies.Count - 1; index >= 0; index--)
        {
            if (realtime < retiredCanopies[index].ExpiresAt) continue;
            DestroyRetiredCanopy(retiredCanopies[index]);
            retiredCanopies.RemoveAt(index);
        }
    }

    private static void Sample(Visual visual, float seconds)
    {
        if (visual.Clip != null)
            visual.Clip.SampleAnimation(visual.AnimationRoot,
                Mathf.Repeat(seconds, visual.Clip.length));
    }

    private void OnDestroy()
    {
        foreach (var visual in active.Values) DestroyVisual(visual);
        active.Clear();
        foreach (var canopy in retiredCanopies) DestroyRetiredCanopy(canopy);
        retiredCanopies.Clear();
    }

    private static void DestroyRetiredCanopy(RetiredCanopy canopy)
    {
        DestroyVisual(canopy.Root);
        DestroyMaterial(canopy.LandingMaterial);
    }

    private static void DestroyCanopy(Visual visual)
    {
        if (visual.Canopy != null) DestroyVisual(visual.Canopy);
        DestroyMaterial(visual.CanopyLandingMaterial);
        visual.Canopy = null;
        visual.CanopyAttached = false;
        visual.CanopyLandingMaterial = null;
    }

    private static void DestroyVisual(Visual visual)
    {
        DestroyCanopy(visual);
        if (visual.SkinAppearance != null)
        {
            visual.SkinAppearance.Dispose();
        }
        DestroyVisual(visual.Root);
    }

    private static void DestroyMaterial(Material material)
    {
        if (material == null) return;
        if (Application.isPlaying) UnityEngine.Object.Destroy(material);
        else UnityEngine.Object.DestroyImmediate(material);
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
