using System;
using System.Collections.Generic;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Samples supported host walking frames on script-free source infantry rigs.</summary>
public sealed class SelfHostedCoopInfantryPresenter : MonoBehaviour
{
    private const string WalkingClip = "run_0";
    private const double HostTicksPerSecond = 30d;
    private readonly Dictionary<ulong, Actor> _actors = new Dictionary<ulong, Actor>();
    private SelfHostedBattleClient _client;
    private EnemyController _source;
    private SoldierBehaviourAssaulter _family;
    private AnimationClip _walkingClip;
    private Animation _sourceAnimation;
    private string _matchId;
    private string _manifestHash;

    private void OnEnable()
    {
        SubscribeAndReplay();
    }

    private void OnDisable()
    {
        if (_client != null)
        {
            _client.CoopEnemiesReceived -= Apply;
            _client.MatchClosed -= Clear;
        }

        Clear();
    }

    private void OnDestroy()
    {
        Clear();
    }

    /// <summary>Binds one source scene and its admitted match without enabling recovered unit controllers.</summary>
    public void Configure(EnemyController source, LevelBehaviourManager manager, SelfHostedBattleClient client)
    {
        if (_client != null || source == null || manager == null || manager.levelBehaviours == null ||
            client == null || client.State == null ||
            client.State.Coop == null || string.IsNullOrEmpty(client.State.MatchId) ||
            string.IsNullOrEmpty(client.State.ManifestHash))
        {
            throw new InvalidOperationException("A source infantry scene and one co-op match are required.");
        }

        SoldierBehaviourAssaulter family = FindAssaulter(manager);
        Animation animation = source.GetComponentInChildren<Animation>(true);
        if (animation != null)
        {
            SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
        }
        AnimationClip clip = animation == null ? null : animation.GetClip(WalkingClip);
        if (family == null || clip == null || clip.length <= 0f)
        {
            throw new InvalidOperationException("The recovered Assaulter family and walking clip are required.");
        }

        _source = source;
        _family = family;
        _walkingClip = clip;
        _sourceAnimation = animation;
        _matchId = client.State.MatchId;
        _manifestHash = client.State.ManifestHash;
        _client = client;
        if (isActiveAndEnabled)
        {
            SubscribeAndReplay();
        }
    }

    /// <summary>Shows only supported confirmed samples; absence never substitutes a guessed idle/fire pose.</summary>
    public void Apply(IReadOnlyList<CoopEnemyViewState> rows)
    {
        if (rows == null)
        {
            throw new ArgumentNullException(nameof(rows));
        }
        if (_client == null || _client.State == null || _client.State.MatchId != _matchId ||
            _client.State.ManifestHash != _manifestHash)
        {
            Clear();
            return;
        }

        var present = new HashSet<ulong>();
        foreach (CoopEnemyViewState row in rows)
        {
            present.Add(row.EntityId);
            ApplyEnemy(row);
        }

        var removed = new List<ulong>();
        foreach (ulong entityId in _actors.Keys)
        {
            if (!present.Contains(entityId))
            {
                removed.Add(entityId);
            }
        }
        foreach (ulong entityId in removed)
        {
            Remove(entityId);
        }
    }

    private void ApplyEnemy(CoopEnemyViewState row)
    {
        Actor actor;
        _actors.TryGetValue(row.EntityId, out actor);
        if (row.IsDead)
        {
            Remove(row.EntityId);
            return;
        }
        if (row.InfantryVisualClip.Length == 0 && row.InfantryAnimation == null)
        {
            if (actor != null)
            {
                actor.Visual.Root.SetActive(false);
            }

            return;
        }
        if (row.Behaviour != "Assaulter" || row.Rotation == null)
        {
            throw new InvalidOperationException("The infantry presenter received an unsupported visual state.");
        }

        if (actor == null)
        {
            actor = CreateActor(row);
            _actors.Add(row.EntityId, actor);
        }
        if (actor.Level != row.Level || actor.IsCardUnit != row.IsCardUnit)
        {
            throw new InvalidOperationException("A source enemy identity cannot change appearance lanes in place.");
        }

        SampleActor(actor, row);
    }

    private Actor CreateActor(CoopEnemyViewState row)
    {
        List<SoldierMeshChanger.SoldierStyle> styles = row.IsCardUnit
            ? _family.cardSoldierVisuals : _family.soldierVisuals;
        if (styles == null || styles.Count == 0)
        {
            throw new InvalidOperationException("The selected source infantry appearance lane is absent.");
        }

        // The recovered SetSoldierStyle makes this cosmetic choice locally, once per created unit.
        int index = UnityEngine.Random.Range(0, styles.Count);
        SelfHostedInfantryVisual visual = SelfHostedInfantryVisualFactory.Create(_source, styles[index],
            "SelfHostedCoopInfantry_" + row.EntityId);
        try
        {
            var sampler = new SelfHostedInfantryAnimationSampler(visual.AnimationRoot, _sourceAnimation);
            return new Actor(visual, row.Level, row.IsCardUnit, sampler);
        }
        catch
        {
            DestroyRoot(visual.Root);
            throw;
        }
    }

    private void SampleActor(Actor actor, CoopEnemyViewState row)
    {
        SelfHostedInfantryVisual visual = actor.Visual;
        BattleJointRotation rotation = row.Rotation;
        visual.Root.transform.position = new Vector3(row.X, row.Y, row.Z);
        visual.Root.transform.rotation = new Quaternion(rotation.X, rotation.Y, rotation.Z, rotation.W);
        actor.Sampler.Sample(CreateAnimationStates(row));
        visual.Root.SetActive(true);
    }

    private IReadOnlyList<SelfHostedInfantryAnimationState> CreateAnimationStates(CoopEnemyViewState row)
    {
        var states = new List<SelfHostedInfantryAnimationState>();
        if (row.InfantryAnimation != null)
        {
            foreach (InfantryAnimationClipView clip in row.InfantryAnimation.Clips)
            {
                states.Add(new SelfHostedInfantryAnimationState(clip.ClipName, clip.TimeSeconds,
                    clip.Weight, ToUnityWrap(clip.Wrap)));
            }
            return states;
        }

        // Keep older walking-only hosts compatible until every source animation is projected by the host.
        float seconds = (float)((row.InfantryVisualSampleTick - row.InfantryVisualStartTick) / HostTicksPerSecond);
        states.Add(new SelfHostedInfantryAnimationState(WalkingClip, Mathf.Repeat(seconds, _walkingClip.length),
            1f, WrapMode.ClampForever));
        return states;
    }

    private static WrapMode ToUnityWrap(BattleInfantryAnimationWrap wrap)
    {
        switch (wrap)
        {
            case BattleInfantryAnimationWrap.Clamp:
                return WrapMode.Clamp;
            case BattleInfantryAnimationWrap.ClampForever:
                return WrapMode.ClampForever;
            case BattleInfantryAnimationWrap.Loop:
                return WrapMode.Loop;
            default:
                throw new InvalidOperationException("The SDK published an unsupported source wrapping mode.");
        }
    }

    private void SubscribeAndReplay()
    {
        if (_client == null)
        {
            return;
        }

        _client.CoopEnemiesReceived -= Apply;
        _client.CoopEnemiesReceived += Apply;
        _client.MatchClosed -= Clear;
        _client.MatchClosed += Clear;
        Apply(_client.CoopEnemies);
    }

    private void Clear()
    {
        foreach (Actor actor in _actors.Values)
        {
            DestroyRoot(actor.Visual.Root);
        }

        _actors.Clear();
    }

    private void Remove(ulong entityId)
    {
        Actor actor;
        if (_actors.TryGetValue(entityId, out actor))
        {
            DestroyRoot(actor.Visual.Root);
            _actors.Remove(entityId);
        }
    }

    private static void DestroyRoot(GameObject root)
    {
        if (root == null)
        {
            return;
        }
        if (Application.isPlaying)
        {
            UnityEngine.Object.Destroy(root);
        }
        else
        {
            UnityEngine.Object.DestroyImmediate(root);
        }
    }

    private static SoldierBehaviourAssaulter FindAssaulter(LevelBehaviourManager manager)
    {
        foreach (LevelBehaviourManager.BehaviourEntry entry in manager.levelBehaviours)
        {
            SoldierBehaviourAssaulter family = entry.behaviour as SoldierBehaviourAssaulter;
            if (family != null)
            {
                return family;
            }
        }

        return null;
    }

    private sealed class Actor
    {
        internal SelfHostedInfantryVisual Visual { get; private set; }
        internal int Level { get; private set; }
        internal bool IsCardUnit { get; private set; }
        internal SelfHostedInfantryAnimationSampler Sampler { get; private set; }

        internal Actor(SelfHostedInfantryVisual visual, int level, bool isCardUnit,
            SelfHostedInfantryAnimationSampler sampler)
        {
            Visual = visual;
            Level = level;
            IsCardUnit = isCardUnit;
            Sampler = sampler;
        }
    }
}
