using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using War.Protocol;

/// <summary>Observes real UDP callback retry, source effect dispatch and automatic particle simulation.</summary>
public sealed class UnityLiveBazookaEffectObservation
{
    private const string M202Source = "Google2u.Bazooka_M202";
    private const int ExpectedImpacts = 5;
    private readonly UnityBazookaEffectFixture _fixture;
    private readonly SelfHostedBattleClient _client;
    private readonly Dictionary<ulong, MatchEvent> _completed = new Dictionary<ulong, MatchEvent>();
    private readonly List<ParticleObservation> _particles = new List<ParticleObservation>();
    private MatchEvent _interrupted;
    private int _previousAudioCursor;
    private int _previousParticleCount;
    private int _nextAudioCursor;
    private bool _hasRecovered;
    private string _failure;

    /// <summary>Inserts failure before the bridge and observes errors from the normal adapter Update.</summary>
    public UnityLiveBazookaEffectObservation(UnityBazookaEffectFixture fixture, SelfHostedBattleClient client)
    {
        _fixture = fixture;
        _client = client;
        _nextAudioCursor = fixture.AudioCursor;
        client.CombatEventReceived += BeforeBridge;
        client.ConnectionError += ObserveConnectionError;
    }

    /// <summary>Binds after the bridge so every observed effect has passed through production presentation.</summary>
    public void BindCompletedHandler()
    {
        _client.CombatEventReceived += AfterBridge;
    }

    /// <summary>Observes emitted particles without manually simulating or polling the adapter.</summary>
    public bool HasFinished()
    {
        ThrowIfFailed();

        return _completed.Count == ExpectedImpacts && _hasRecovered &&
            _client.ProcessedEventId >= _interrupted.EventId && _particles.All(row => row.HasEmitted);
    }

    /// <summary>Surfaces callback failures and observes particles between network deliveries.</summary>
    public void ThrowIfFailed()
    {
        if (_failure != null)
        {
            throw new InvalidOperationException(_failure);
        }

        foreach (ParticleObservation observation in _particles)
        {
            if (!observation.HasEmitted && observation.System != null && Time.frameCount > observation.Frame)
            {
                observation.HasEmitted = observation.System.GetComponentsInChildren<ParticleSystem>(true)
                    .Sum(system => system.particleCount) > 0;
            }
        }
    }

    private void BeforeBridge(MatchEvent impact)
    {
        if (!IsBazookaImpact(impact) || _interrupted != null)
        {
            return;
        }

        _interrupted = impact.Clone();
        _previousAudioCursor = _fixture.AudioCursor;
        _previousParticleCount = _fixture.ParticleCount;
        _fixture.SuspendParticlePool();
    }

    private void ObserveConnectionError(string message)
    {
        if (_interrupted == null || _hasRecovered)
        {
            _failure = "Unexpected production adapter error: " + message;
            return;
        }

        bool hasPendingCursor = _client.ProcessedEventId < _interrupted.EventId;
        bool hasOneSound = _fixture.AudioCursor == _fixture.NextAudioCursor(_previousAudioCursor);
        bool hasNoParticle = _fixture.ParticleCount == _previousParticleCount;
        _fixture.ResumeParticlePool();
        _hasRecovered = true;
        if (!hasPendingCursor || !hasOneSound || !hasNoParticle)
        {
            _failure = "The failed UDP callback must retain its cursor after one sound and no particle: " + message;
        }

        Debug.Log("LIVE_BAZOOKA_RETRY: pending event=" + _interrupted.EventId +
            ", acknowledged=" + _client.ProcessedEventId + ", one sound=" + hasOneSound);
    }

    private void AfterBridge(MatchEvent impact)
    {
        if (!IsBazookaImpact(impact))
        {
            return;
        }

        if (_completed.ContainsKey(impact.ProjectileId))
        {
            throw new InvalidOperationException("The adapter repeated an acknowledged impact callback.");
        }

        if (impact.ProjectileId == _interrupted.ProjectileId && !_interrupted.Equals(impact))
        {
            throw new InvalidOperationException("The UDP retry changed its original authoritative impact bytes.");
        }

        _nextAudioCursor = _fixture.NextAudioCursor(_nextAudioCursor);
        if (_fixture.AudioCursor != _nextAudioCursor)
        {
            throw new InvalidOperationException("Each live impact must dispatch exactly one source sound.");
        }

        Sounds3DEnum sound = impact.WeaponSourceId == M202Source ?
            Sounds3DEnum.ExplosionSmall : Sounds3DEnum.ExplosionMedium;
        ParticleSystem particles = _fixture.CaptureLatestEffect(sound, new Vector3(impact.X, impact.Y, impact.Z));
        _particles.Add(new ParticleObservation(particles, Time.frameCount));
        _completed.Add(impact.ProjectileId, impact.Clone());
    }

    private static bool IsBazookaImpact(MatchEvent impact)
    {
        return impact.Kind == MatchEventKind.Impact &&
            (impact.Reason == "bazooka" || impact.Reason == "bazooka-fake");
    }

    private sealed class ParticleObservation
    {
        internal ParticleSystem System { get; private set; }

        internal int Frame { get; private set; }

        internal bool HasEmitted { get; set; }

        internal ParticleObservation(ParticleSystem system, int frame)
        {
            System = system;
            Frame = frame;
        }
    }
}
