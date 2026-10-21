using System.Net;
using War.BattleServer;
using War.Client;
using War.Protocol;
using War.Protocol.Transport;

/// <summary>Checks authenticated session-local pose capability negotiation before gameplay authority changes.</summary>
internal static class PoseCapabilityTests
{
    private const long Now = 100;
    private const ulong SessionId = 3001;
    private const int SigningKeyBytes = 32;

    internal static void Run(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        string signingKey = Convert.ToBase64String(Enumerable.Repeat((byte)1, SigningKeyBytes).ToArray());
        var runtime = new CoopMatchRuntime(sources.Manifest, sources.Missions, sources.Spawns,
            sources.Routes, sources.Combat, chooseBehaviour: _ => 0, playerWeaponContent: sources.Content);
        var endpoint = new MatchEndpoint(sources.Manifest, signingKey, runtime, 0);
        var tokens = new MatchTokens(signingKey);
        var claims = new MatchAdmission
        {
            MatchId = runtime.MatchId, ManifestHash = runtime.ManifestHash, ServerId = sources.Manifest.ServerId,
            PlayerId = sources.Manifest.Players[0].PlayerId, SessionId = SessionId,
            IssuedUnixSeconds = Now, ExpiresUnixSeconds = Now + MatchTokens.GrantLifetimeSeconds
        };
        var sender = new IPEndPoint(IPAddress.Loopback, 40199);
        byte[] key = tokens.SessionKey(claims);
        var packet = new Packet
        {
            Version = 1, SessionId = SessionId, Sequence = 1,
            MatchHello = new MatchHello
            {
                Ticket = tokens.Sign(claims), MatchId = runtime.MatchId,
                ObservedPoseCatalogRevision = new string('a', 64)
            }
        };
        Require(endpoint.Handle(packet, PacketCodec.Encode(packet, key), sender, Now) == null &&
            !endpoint.Owns(SessionId), "Unknown renderer content must not admit a session.");
        string revision = ObservedInfantryPoseCatalogData.BuiltIn.Revision;
        packet.MatchHello.ObservedPoseCatalogRevision = revision;
        RequireReply(endpoint, packet, key, sender);
        packet.Sequence = 2;
        packet.MatchHello.ObservedPoseCatalogRevision = "";
        Require(endpoint.Handle(packet, PacketCodec.Encode(packet, key), sender, Now) == null,
            "A repeated hello must not downgrade an authenticated session.");
        packet.MatchHello.ObservedPoseCatalogRevision = revision;
        RequireReply(endpoint, packet, key, sender);
        packet.Sequence = 3;
        packet.MatchCommand = new MatchCommand
        {
            CommandId = 1, Ready = new ReadyCommand { ManifestHash = runtime.ManifestHash }
        };
        RequireReply(endpoint, packet, key, sender);
        Require(runtime.Command(claims.PlayerId, packet.MatchCommand).ObservedPoseCatalogRevision.Length == 0,
            "A connection capability must not contaminate the runtime's retained command receipt.");
        Console.WriteLine("PASS: authenticated pose negotiation rejects unknown content and in-session downgrade");
    }

    private static void RequireReply(MatchEndpoint endpoint, Packet packet, byte[] key, IPEndPoint sender)
    {
        byte[] response = endpoint.Handle(packet, PacketCodec.Encode(packet, key), sender, Now) ??
            throw new Exception("A valid negotiated request was rejected.");
        Packet reply = PacketCodec.ReadUntrusted(response) ?? throw new Exception("A negotiated reply was malformed.");
        Require(PacketCodec.Authenticate(response, key) && reply.MatchReply.ObservedPoseCatalogRevision ==
            ObservedInfantryPoseCatalogData.BuiltIn.Revision,
            "The authenticated admission reply must preserve its session-local negotiated revision.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
