using System;
using UnityEditor;
using UnityEngine;
using War.Protocol;

/// <summary>Exercises real recovered sound/particle dispatch and interrupted callback replay in Play Mode.</summary>
[InitializeOnLoad]
public static class UnityBazookaEffectsPlayAudit
{
    private const string SessionKey = "WarFriends.BazookaEffectsPlayAudit";
    private const int MaximumSeconds = 60;
    private static UnityBazookaEffectFixture _fixture;
    private static SelfHostedProjectilePresenter _presenter;
    private static int _startedFrame;
    private static double _deadline;

    static UnityBazookaEffectsPlayAudit()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            _deadline = EditorApplication.timeSinceStartup + MaximumSeconds;
            EditorApplication.update += Observe;
        }
    }

    /// <summary>Copies only the required recovered services before the domain reload.</summary>
    public static void Run()
    {
        UnityBazookaEffectFixture.PrepareScene();
        SessionState.SetBool(SessionKey, true);
        _deadline = EditorApplication.timeSinceStartup + MaximumSeconds;
        EditorApplication.update -= Observe;
        EditorApplication.update += Observe;
        EditorApplication.isPlaying = true;
    }

    private static void Observe()
    {
        if (EditorApplication.timeSinceStartup > _deadline)
        {
            Finish(new TimeoutException("Recovered bazooka effects did not finish simulation."));
            return;
        }

        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
        {
            return;
        }

        try
        {
            if (_fixture == null)
            {
                _fixture = UnityBazookaEffectFixture.StartServices();
                _presenter = new GameObject("SourceEffectsPresenter").AddComponent<SelfHostedProjectilePresenter>();
                VerifyInterruptedReplay();
                VerifyM202();
                _startedFrame = Time.frameCount;
            }
            else if (Time.frameCount >= _startedFrame + 2)
            {
                Require(_fixture.HasSimulatedParticles(), "Recovered explosion particles must emit on real frames.");
                VerifyReplayScope();
                Finish(null);
            }
        }
        catch (Exception failure)
        {
            Finish(failure);
        }
    }

    private static void VerifyInterruptedReplay()
    {
        MatchEvent impact = Impact(1, "Google2u.Bazooka_RPG7", false);
        _fixture.SuspendParticlePool();
        bool hasFailed = false;
        string failureDetail = string.Empty;
        try
        {
            _presenter.ApplyEvent(impact);
        }
        catch (NullReferenceException failure)
        {
            hasFailed = true;
            failureDetail = failure.ToString();
        }
        finally
        {
            _fixture.ResumeParticlePool();
        }

        Require(hasFailed && _fixture.AudioCursor == 1 && _fixture.ParticleCount == 0,
            "The real source sound must complete before the injected particle-pool failure: " +
            "audio=" + _fixture.AudioCursor + ", particles=" + _fixture.ParticleCount + ", " + failureDetail);
        _presenter.ApplyEvent(impact);
        Require(_fixture.AudioCursor == 1 && _fixture.ParticleCount == 1,
            "Callback replay must resume missing particles without replaying the completed sound.");
        _fixture.VerifyEffect(0, Sounds3DEnum.ExplosionMedium, new Vector3(2, 3, 4));
        _presenter.ApplyEvent(impact);
        Require(_fixture.AudioCursor == 1 && _fixture.ParticleCount == 1,
            "A fully completed impact must not repeat either effect.");
    }

    private static void VerifyM202()
    {
        _presenter.ApplyEvent(Impact(2, "Google2u.Bazooka_M202", false));
        _fixture.VerifyEffect(1, Sounds3DEnum.ExplosionSmall, new Vector3(2, 3, 4));
        MatchEvent fake = Impact(3, "Google2u.Bazooka_M202", true);
        _presenter.ApplyEvent(fake);
        _fixture.VerifyEffect(2, Sounds3DEnum.ExplosionSmall, new Vector3(2, 3, 4));
        _presenter.ApplyEvent(fake);
        Require(_fixture.AudioCursor == 3 && _fixture.ParticleCount == 3,
            "A harmless source M202 missile still has one Small sound and explosion, with no duplicate.");
    }

    private static void VerifyReplayScope()
    {
        _presenter.Apply(new MatchSnapshot { MatchId = "effects-first", ManifestHash = new string('a', 64) });
        _presenter.ResetForFullSnapshot();
        _presenter.ApplyEvent(Impact(1, "Google2u.Bazooka_RPG7", false));
        Require(_fixture.AudioCursor == 3 && _fixture.ParticleCount == 3,
            "The first full snapshot and reconnect must retain completed effect steps.");
        MatchEvent changed = Impact(1, "Google2u.Bazooka_RPG7", false);
        changed.X = 99;
        bool hasRejected = false;
        try
        {
            _presenter.ApplyEvent(changed);
        }
        catch (InvalidOperationException)
        {
            hasRejected = true;
        }

        Require(hasRejected && _fixture.AudioCursor == 3 && _fixture.ParticleCount == 3,
            "An altered replay must not publish another effect.");
        _presenter.Apply(new MatchSnapshot { MatchId = "effects-next", ManifestHash = new string('a', 64) });
        _presenter.ApplyEvent(Impact(1, "Google2u.Bazooka_RPG7", false));
        Require(_fixture.AudioCursor == 0 && _fixture.ParticleCount == 4,
            "A new match may reuse the counter and publish one new effect through the source audio ring.");
        _fixture.VerifyEffect(3, Sounds3DEnum.ExplosionMedium, new Vector3(2, 3, 4));
    }

    private static MatchEvent Impact(ulong id, string sourceId, bool isFake)
    {
        return new MatchEvent
        {
            EventId = id, ProjectileId = id, Kind = MatchEventKind.Impact,
            ActorId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", WeaponSourceId = sourceId,
            Reason = isFake ? "bazooka-fake" : "bazooka", X = 2, Y = 3, Z = 4
        };
    }

    private static void Finish(Exception failure)
    {
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= Observe;
        if (failure != null)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
            return;
        }

        Debug.Log("PASS: recovered Medium/Small/fake sound and particles, interrupted callback replay " +
            "and automatic particle simulation; isolated Play Mode, no rendered or audible output proof.");
        EditorApplication.Exit(0);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
