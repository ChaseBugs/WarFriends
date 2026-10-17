using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Google.Protobuf;
using War.Protocol;

/// <summary>Collects live host-to-presenter evidence without altering combat or rendering decisions.</summary>
public sealed class UnityLiveBazookaObservation
{
    private const string M202 = "Google2u.Bazooka_M202";
    private const string Rpg = "Google2u.Bazooka_RPG7";
    private const int M202Missiles = 4;
    private const int M202FakeMissiles = 2;
    private const int PeerRpgMissiles = 1;
    private const int ExpectedMissiles = M202Missiles + PeerRpgMissiles;
    private const float PositionTolerance = 0.001f;
    private static readonly Vector3 SmallModelScale = new Vector3(0.5f, 0.5f, 0.7f);
    private readonly string _localPlayerId;
    private readonly string _peerPlayerId;
    private readonly Dictionary<ulong, BattleProjectileState> _flights =
        new Dictionary<ulong, BattleProjectileState>();
    private readonly Dictionary<ulong, MatchEvent> _impacts = new Dictionary<ulong, MatchEvent>();
    private readonly HashSet<ulong> _moved = new HashSet<ulong>();
    private bool _hasPreservedSwitchedFlight;

    /// <summary>Binds each received source family to the independently admitted sender.</summary>
    public UnityLiveBazookaObservation(string localPlayerId, string peerPlayerId)
    {
        _localPlayerId = localPlayerId;
        _peerPlayerId = peerPlayerId;
    }

    /// <summary>Waits for every source M202 sub-shot before changing the active slot.</summary>
    public bool HasM202Volley
    {
        get { return _flights.Values.Count(row => row.WeaponSourceId == M202) == M202Missiles; }
    }

    /// <summary>Counts the independently received reliable impact identities.</summary>
    public int ImpactCount { get { return _impacts.Count; } }

    /// <summary>Runs after the production bridge has applied this same snapshot.</summary>
    public void ObserveSnapshot(MatchSnapshot snapshot)
    {
        foreach (BattleProjectileState row in snapshot.Projectiles)
        {
            if (row.Kind != "bazooka" && row.Kind != "bazooka-fake")
            {
                continue;
            }

            GameObject root = Find(row.ProjectileId);
            Require(root != null, "A live host missile must reach the production Unity presenter.");
            Require(root.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
                root.GetComponentsInChildren<Collider>(true).Length == 0,
                "The live flight must remain presentation-only.");
            Vector3 position = new Vector3(row.X, row.Y, row.Z);
            Require(Vector3.Distance(root.transform.position, position) < PositionTolerance,
                "The presented missile position must come from this host frame.");
            BattleProjectileState previous;
            if (_flights.TryGetValue(row.ProjectileId, out previous) &&
                Vector3.Distance(new Vector3(previous.X, previous.Y, previous.Z), position) > PositionTolerance)
            {
                _moved.Add(row.ProjectileId);
            }

            _flights[row.ProjectileId] = row.Clone();
        }
    }

    /// <summary>Runs after reliable production impact presentation has stopped the model.</summary>
    public void ObserveEvent(MatchEvent item)
    {
        if (item.Kind != MatchEventKind.Impact || (item.Reason != "bazooka" && item.Reason != "bazooka-fake"))
        {
            return;
        }

        GameObject root = Find(item.ProjectileId);
        Require(root != null && !root.transform.Find("missilePrototype").gameObject.activeSelf,
            "The live reliable impact must stop its model and retain the source tail.");
        Require(Vector3.Distance(root.transform.position, new Vector3(item.X, item.Y, item.Z)) < PositionTolerance,
            "The live tail must finish at the confirmed host impact.");
        _impacts.Add(item.ProjectileId, item.Clone());
    }

    /// <summary>Checks a live M202 mesh after the owner has selected the source RPG slot.</summary>
    public void VerifySwitchedFlight()
    {
        foreach (BattleProjectileState row in _flights.Values)
        {
            GameObject root = Find(row.ProjectileId);
            if (row.WeaponSourceId != M202 || root == null)
            {
                continue;
            }

            Transform model = root.transform.Find("missilePrototype");
            if (model.gameObject.activeSelf)
            {
                Require(model.localScale == SmallModelScale,
                    "An existing M202 missile must retain its Small model after the RPG switch.");
                _hasPreservedSwitchedFlight = true;
                return;
            }
        }

        throw new InvalidOperationException("No M202 flight survived long enough to test slot independence.");
    }

    /// <summary>Checks matching impact bytes received by independently authenticated participants.</summary>
    public void VerifyPeer(IReadOnlyDictionary<ulong, MatchEvent> peerImpacts)
    {
        Require(_flights.Count == ExpectedMissiles && _impacts.Count == ExpectedMissiles &&
            _moved.Count == ExpectedMissiles && _hasPreservedSwitchedFlight,
            "All five missiles must move through live snapshots and reach reliable impact presentation.");
        Require(_flights.Values.Count(row => row.WeaponSourceId == M202) == M202Missiles &&
            _flights.Values.Count(row => row.WeaponSourceId == Rpg) == PeerRpgMissiles &&
            _flights.Values.Count(row => row.Kind == "bazooka-fake") == M202FakeMissiles,
            "The source M202 real/fake volley and peer RPG must preserve their identities.");
        foreach (KeyValuePair<ulong, MatchEvent> entry in _impacts)
        {
            BattleProjectileState flight = _flights[entry.Key];
            string expectedOwner = flight.WeaponSourceId == M202 ? _localPlayerId : _peerPlayerId;
            Require(flight.OwnerPlayerId == expectedOwner && entry.Value.ActorId == expectedOwner &&
                entry.Value.WeaponSourceId == flight.WeaponSourceId && entry.Value.Reason == flight.Kind,
                "Each real/fake flight and impact must preserve its authenticated sender and source.");
            MatchEvent peer;
            Require(peerImpacts.TryGetValue(entry.Key, out peer) &&
                peer.ToByteArray().SequenceEqual(entry.Value.ToByteArray()),
                "Both UDP participants must receive identical host impact records.");
        }
    }

    private static GameObject Find(ulong projectileId)
    {
        return GameObject.Find("SelfHostedProjectile_" + projectileId);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
