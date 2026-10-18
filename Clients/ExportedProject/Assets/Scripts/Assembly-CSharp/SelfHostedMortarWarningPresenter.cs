using System;
using UnityEngine;
using War.Client;
using War.Protocol;
using War.Shared;

/// <summary>Owns four recovered warning visuals; only validated server clocks drive their presentation.</summary>
public sealed class SelfHostedMortarWarningPresenter : MonoBehaviour
{
    private const int SourceCapacity = 4;
    private const ulong MaximumCatchUpFrames = 1800;
    private const float FrameSeconds = 1f / 30f;
    private readonly SelfHostedMortarWarningVisual[] _visuals = new SelfHostedMortarWarningVisual[SourceCapacity];
    private readonly MortarIndicatorClock[] _clocks = new MortarIndicatorClock[SourceCapacity];
    private readonly ulong[] _ticks = new ulong[SourceCapacity];
    private SelfHostedBattleClient _client;
    private string _matchId;
    private string _manifestHash;
    private int _observerFraction;
    private bool _isSubscribed;
    private bool _hasScan;
    private ulong _lastScanTick;
    private MatchProjectileBatch _pendingScan;

    /// <summary>Binds a connected scene and preallocates source visuals without enabling recovered gameplay scripts.</summary>
    public void Configure(SelfHostedBattleClient client, Mortar source, Transform worldRoot)
    {
        if (_client != null || client == null || !client.IsConnected || client.State == null ||
            client.PlayerViews == null || source == null)
        {
            throw new InvalidOperationException("One connected source Mortar warning scene is required.");
        }
        foreach (BattlePlayerView player in client.PlayerViews)
        {
            if (player.PlayerId == client.LocalPlayerId)
            {
                _observerFraction = player.Fraction;
            }
        }
        if (_observerFraction != 1 && _observerFraction != 2)
        {
            throw new InvalidOperationException("The warning observer is absent from its admitted roster.");
        }
        for (int slot = 0; slot < SourceCapacity; slot++)
        {
            _visuals[slot] = new SelfHostedMortarWarningVisual(source.indicator, worldRoot, slot);
        }
        _client = client;
        _matchId = client.State.MatchId;
        _manifestHash = client.State.ManifestHash;
        Subscribe();
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        if (_client == null || _isSubscribed || !isActiveAndEnabled)
        {
            return;
        }
        _client.ProjectileScanReceived += ApplyScan;
        _client.StateReceived += ApplyState;
        _client.FullSnapshotRebuild += Clear;
        _client.MatchClosed += Clear;
        _isSubscribed = true;
    }

    private void OnDisable()
    {
        if (_client != null && _isSubscribed)
        {
            _client.ProjectileScanReceived -= ApplyScan;
            _client.StateReceived -= ApplyState;
            _client.FullSnapshotRebuild -= Clear;
            _client.MatchClosed -= Clear;
        }
        _isSubscribed = false;
        Clear();
    }

    /// <summary>Queues complete frozen scans; a newer-than-state sample waits for its authoritative state tick.</summary>
    public void ApplyScan(MatchProjectileBatch batch)
    {
        if (_client == null || !_client.IsConnected || !isActiveAndEnabled)
        {
            return;
        }
        if (batch == null || batch.Code != "projectiles" || batch.HasMore ||
            batch.MatchId != _matchId || batch.ManifestHash != _manifestHash)
        {
            throw new InvalidOperationException("Warning visuals require one complete owned projectile scan.");
        }
        MortarWarningPolicy.Validate(batch.MortarWarnings, batch.SnapshotTick, _observerFraction);
        if (_hasScan && batch.SnapshotTick < _lastScanTick ||
            _pendingScan != null && batch.SnapshotTick < _pendingScan.SnapshotTick)
        {
            return;
        }
        _pendingScan = batch.Clone();
        ApplyState(_client.State);
    }

    private void ApplyState(MatchSnapshot state)
    {
        if (state == null || state.MatchId != _matchId || state.ManifestHash != _manifestHash ||
            state.Phase == BattlePhase.Ended || state.Phase == BattlePhase.Aborted)
        {
            Clear();
            return;
        }
        if (_pendingScan == null || _pendingScan.SnapshotTick > state.ServerTick)
        {
            return;
        }
        if (state.ServerTick - _pendingScan.SnapshotTick > MaximumCatchUpFrames)
        {
            Clear();
            return;
        }
        ApplyPending(state.ServerTick);
    }

    private void ApplyPending(ulong tick)
    {
        var clocks = new MortarIndicatorClock[SourceCapacity];
        var samples = new BattleMortarWarningState[SourceCapacity];
        foreach (BattleMortarWarningState row in _pendingScan.MortarWarnings)
        {
            BattleMortarWarningState sample = MortarWarningReconstruction.AtTick(row, tick);
            if (sample == null)
            {
                continue;
            }
            samples[row.WeaponSlot] = sample;
            clocks[row.WeaponSlot] = MortarIndicatorClock.FromCheckpoint(sample.Clock);
        }
        _lastScanTick = _pendingScan.SnapshotTick;
        _hasScan = true;
        _pendingScan = null;
        for (int slot = 0; slot < SourceCapacity; slot++)
        {
            _clocks[slot] = clocks[slot];
            _ticks[slot] = tick;
            if (clocks[slot] == null)
            {
                _visuals[slot].Hide();
                continue;
            }
            BattleMortarWarningState row = samples[slot];
            _visuals[slot].Root.position = new Vector3(row.X, row.Y, row.Z);
            _visuals[slot].Render(clocks[slot]);
        }
    }

    private void Update()
    {
        if (_client == null || !_client.IsConnected || _client.State == null ||
            _client.State.MatchId != _matchId || _client.State.Phase != BattlePhase.Running ||
            _client.State.PauseHostTick != 0)
        {
            return;
        }
        ulong tick = _client.State.ServerTick;
        for (int slot = 0; slot < SourceCapacity; slot++)
        {
            MortarIndicatorClock clock = _clocks[slot];
            if (clock == null || tick < _ticks[slot])
            {
                continue;
            }
            if (tick - _ticks[slot] > MaximumCatchUpFrames)
            {
                _clocks[slot] = null;
                _visuals[slot].Hide();
                continue;
            }
            while (_ticks[slot] < tick)
            {
                clock.Advance(FrameSeconds);
                _ticks[slot]++;
            }
            _visuals[slot].Render(clock);
        }
    }

    /// <summary>Hides all warnings and discards state owned by the previous recovery boundary.</summary>
    public void Clear()
    {
        _pendingScan = null;
        _hasScan = false;
        for (int slot = 0; slot < SourceCapacity; slot++)
        {
            _clocks[slot] = null;
            if (_visuals[slot] != null)
            {
                _visuals[slot].Hide();
            }
        }
    }

    private void OnDestroy()
    {
        for (int slot = 0; slot < SourceCapacity; slot++)
        {
            if (_visuals[slot] != null)
            {
                _visuals[slot].Dispose();
            }
        }
    }
}
