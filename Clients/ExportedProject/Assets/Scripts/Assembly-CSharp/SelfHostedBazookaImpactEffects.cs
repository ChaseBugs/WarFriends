using System;
using System.Collections.Generic;
using UnityEngine;
using War.Protocol;
using War.Shared;

/// <summary>
/// Resumes interrupted source explosion dispatch without repeating a completed sound or particle step.
/// </summary>
public sealed class SelfHostedBazookaImpactEffects
{
    private const int MaximumImpacts = 512;
    private const int SourceParticleIndex = 3;
    private const float SourceParticleHeight = 0.2f;
    private const float MaximumCoordinate = 10000f;
    private readonly Dictionary<ulong, Progress> _impacts = new Dictionary<ulong, Progress>();

    /// <summary>Uses the original Medium/Small source effect rules and no overlap or damage path.</summary>
    public void Apply(MatchEvent impact)
    {
        Validate(impact);
        Progress progress = GetProgress(impact);
        Vector3 position = new Vector3(impact.X, impact.Y, impact.Z);
        if (!progress.HasPlayedSound)
        {
            Sounds3DEnum sound = SelfHostedBazookaVisual.ExplosionTypeFor(impact.WeaponSourceId) ==
                Explosion.ExplosionType.Small ? Sounds3DEnum.ExplosionSmall : Sounds3DEnum.ExplosionMedium;
            // Explosion.PlayEffects dispatches sound before particles, including harmless M202 missiles.
            Singleton<SoundsManager3D>.instance.Play(position, sound);
            progress.HasPlayedSound = true;
        }

        if (!progress.HasPlayedParticles)
        {
            ParticleSystem particles = Singleton<HitParticleSystem>.instance.PlayParticle(
                position + Vector3.up * SourceParticleHeight, Vector3.up, SourceParticleIndex);
            if (particles == null)
            {
                throw new InvalidOperationException("The recovered explosion particle did not start.");
            }

            progress.HasPlayedParticles = true;
        }
    }

    /// <summary>
    /// Only a new match scope discards replay history; reconnects preserve successful dispatch steps.
    /// </summary>
    public void Clear()
    {
        _impacts.Clear();
    }

    private Progress GetProgress(MatchEvent impact)
    {
        Progress progress;
        if (_impacts.TryGetValue(impact.ProjectileId, out progress))
        {
            if (!progress.Original.Equals(impact))
            {
                throw new InvalidOperationException("A repeated explosion changed its authoritative impact record.");
            }

            return progress;
        }

        // A source failure must not discard the successful preceding step when its callback retries.
        if (_impacts.Count >= MaximumImpacts)
        {
            throw new InvalidOperationException(
                "Explosion replay history exceeded the host's retained event bound.");
        }

        progress = new Progress(impact.Clone());
        _impacts.Add(impact.ProjectileId, progress);
        return progress;
    }

    private static void Validate(MatchEvent impact)
    {
        if (impact == null || impact.EventId == 0 || impact.Kind != MatchEventKind.Impact ||
            (impact.Reason != "bazooka" && impact.Reason != "bazooka-fake") ||
            !BazookaSourceIdentity.ValidEvent(impact) ||
            !IsFinite(impact.X) || !IsFinite(impact.Y) || !IsFinite(impact.Z))
        {
            throw new InvalidOperationException("Invalid source bazooka explosion event.");
        }
    }

    private static bool IsFinite(float coordinate)
    {
        return !float.IsNaN(coordinate) && !float.IsInfinity(coordinate) &&
            Mathf.Abs(coordinate) <= MaximumCoordinate;
    }

    private sealed class Progress
    {
        internal MatchEvent Original { get; private set; }

        internal bool HasPlayedSound { get; set; }

        internal bool HasPlayedParticles { get; set; }

        internal Progress(MatchEvent original)
        {
            Original = original;
        }
    }
}
