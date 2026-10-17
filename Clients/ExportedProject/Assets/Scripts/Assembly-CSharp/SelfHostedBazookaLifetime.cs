using System;
using System.Collections.Generic;
using UnityEngine;
using War.Protocol;
using War.Shared;

/// <summary>Owns cosmetic missile tails and prevents older reads from restoring a completed flight.</summary>
public sealed class SelfHostedBazookaLifetime
{
    private const int MaximumTrackedProjectiles = 512;
    private const float LocalTailSeconds = 1.3f;
    private const float RemoteTailSeconds = 0.2f;
    private readonly Dictionary<ulong, Flight> _active = new Dictionary<ulong, Flight>();
    private readonly Dictionary<ulong, Flight> _tails = new Dictionary<ulong, Flight>();
    private readonly Dictionary<ulong, string> _impacts = new Dictionary<ulong, string>();
    private readonly HashSet<ulong> _finished = new HashSet<ulong>();
    private readonly List<ulong> _expired = new List<ulong>();
    private string _matchId;
    private string _manifestHash;

    /// <summary>Changes identity without losing the old visual handles needed by the presenter's cleanup.</summary>
    public bool SelectScope(string matchId, string manifestHash)
    {
        if (_matchId == null)
        {
            // An impact can precede the first full snapshot; both were checked by the same SDK connection.
            _matchId = matchId;
            _manifestHash = manifestHash;
            return false;
        }

        if (_matchId == matchId && _manifestHash == manifestHash)
        {
            return false;
        }

        _matchId = matchId;
        _manifestHash = manifestHash;
        _finished.Clear();
        _impacts.Clear();
        return true;
    }

    /// <summary>Registers a script-free flight with its immutable source and owner role.</summary>
    public void Register(ulong projectileId, GameObject root, string sourceId, bool isLocal)
    {
        if (projectileId == 0 || root == null || !BazookaSourceIdentity.ValidProjectile(sourceId, false) ||
            IsFinished(projectileId) || _active.ContainsKey(projectileId) ||
            _active.Count + _tails.Count >= MaximumTrackedProjectiles)
        {
            throw new InvalidOperationException("Invalid or repeated bazooka visual registration.");
        }

        _active.Add(projectileId, new Flight(root, sourceId, isLocal));
    }

    /// <summary>Finished identities survive tail expiry and same-match reconnects.</summary>
    public bool IsFinished(ulong projectileId)
    {
        return _finished.Contains(projectileId);
    }

    /// <summary>Distinguishes these roots from the presenter's other projectile families.</summary>
    public bool OwnsVisual(ulong projectileId)
    {
        return _active.ContainsKey(projectileId) || _tails.ContainsKey(projectileId);
    }

    /// <summary>Retires an authoritative full-snapshot omission without fabricating an explosion.</summary>
    public bool RetireMissing(ulong projectileId, float scaledTime)
    {
        ValidateTime(scaledTime);
        Flight flight;
        if (!_active.TryGetValue(projectileId, out flight))
        {
            return false;
        }

        RequireFinishedCapacity(projectileId);
        StopFlight(flight, scaledTime);
        _active.Remove(projectileId);
        _tails.Add(projectileId, flight);
        _finished.Add(projectileId);
        return true;
    }

    /// <summary>Returns true once per host impact, including impacts whose snapshot was never received.</summary>
    public bool Impact(MatchEvent impact, float scaledTime)
    {
        ValidateTime(scaledTime);
        if (impact == null || impact.Kind != MatchEventKind.Impact ||
            (impact.Reason != "bazooka" && impact.Reason != "bazooka-fake") ||
            !BazookaSourceIdentity.ValidEvent(impact) ||
            !FiniteCoordinate(impact.X) || !FiniteCoordinate(impact.Y) || !FiniteCoordinate(impact.Z))
        {
            throw new InvalidOperationException("Invalid bazooka retirement event.");
        }

        string previousSource;
        if (_impacts.TryGetValue(impact.ProjectileId, out previousSource))
        {
            if (previousSource != impact.WeaponSourceId)
            {
                throw new InvalidOperationException("A repeated impact changed its launch source.");
            }

            return false;
        }

        RequireFinishedCapacity(impact.ProjectileId);
        Flight flight;
        bool hasActive = _active.TryGetValue(impact.ProjectileId, out flight);
        if (hasActive || _tails.TryGetValue(impact.ProjectileId, out flight))
        {
            if (flight.SourceId != impact.WeaponSourceId)
            {
                throw new InvalidOperationException("An impact changed the flying missile's source.");
            }

            if (flight.Root != null)
            {
                flight.Root.transform.position = new Vector3(impact.X, impact.Y, impact.Z);
                StopFlight(flight, scaledTime);
            }

            _active.Remove(impact.ProjectileId);
            _tails[impact.ProjectileId] = flight;
        }

        _finished.Add(impact.ProjectileId);
        _impacts.Add(impact.ProjectileId, impact.WeaponSourceId);
        return true;
    }

    /// <summary>Uses scaled Unity time, matching PoolableObject's WaitForSeconds cleanup.</summary>
    public void Advance(float scaledTime)
    {
        ValidateTime(scaledTime);
        _expired.Clear();
        foreach (KeyValuePair<ulong, Flight> entry in _tails)
        {
            if (entry.Value.Root == null || scaledTime >= entry.Value.ExpiresAt)
            {
                DestroyRoot(entry.Value.Root);
                _expired.Add(entry.Key);
            }
        }

        foreach (ulong projectileId in _expired)
        {
            _tails.Remove(projectileId);
        }
    }

    /// <summary>Reconnect cleanup removes objects while retaining completed IDs in the same scope.</summary>
    public void ClearVisuals()
    {
        foreach (Flight flight in _active.Values)
        {
            DestroyRoot(flight.Root);
        }

        foreach (Flight flight in _tails.Values)
        {
            DestroyRoot(flight.Root);
        }

        _active.Clear();
        _tails.Clear();
        _expired.Clear();
    }

    private void RequireFinishedCapacity(ulong projectileId)
    {
        // The host retains at most 512 events, including every player missile's Shot.
        // Do not evict a completed ID and permit a delayed scan to restore its mesh.
        if (!_finished.Contains(projectileId) && _finished.Count >= MaximumTrackedProjectiles)
        {
            throw new InvalidOperationException("Bazooka completion history exceeded the host event bound.");
        }
    }

    private static void StopFlight(Flight flight, float scaledTime)
    {
        if (flight.Root != null)
        {
            SelfHostedBazookaVisual.StopFlight(flight.Root);
        }

        flight.ExpiresAt = scaledTime + (flight.IsLocal ? LocalTailSeconds : RemoteTailSeconds);
    }

    private static void ValidateTime(float scaledTime)
    {
        if (float.IsNaN(scaledTime) || float.IsInfinity(scaledTime) || scaledTime < 0f)
        {
            throw new ArgumentException("Invalid scaled projectile lifetime clock.");
        }
    }

    private static bool FiniteCoordinate(float coordinate)
    {
        return !float.IsNaN(coordinate) && !float.IsInfinity(coordinate) && Mathf.Abs(coordinate) <= 10000f;
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

    private sealed class Flight
    {
        internal GameObject Root { get; private set; }
        internal string SourceId { get; private set; }
        internal bool IsLocal { get; private set; }
        internal float ExpiresAt { get; set; }

        internal Flight(GameObject root, string sourceId, bool isLocal)
        {
            Root = root;
            SourceId = sourceId;
            IsLocal = isLocal;
        }
    }
}
