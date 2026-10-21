using Google.Protobuf;
using War.BattleServer;
using War.Protocol;
using War.Shared;

namespace War.Battle.Tests.Http;

/// <summary>Retains real engine terminal semantics and pads a canonical protobuf compatibility field.</summary>
internal static class TerminalPayloadFixture
{
    private const int CompatibilityFieldNumber = 50000;

    internal static byte[] Create(string matchId, int targetBytes)
    {
        string revision = new('a', 64);
        var weapon = new WeaponManifest("envelope-fixture", 2, 3, 0.1, 0.2);
        var manifest = new MatchManifest(matchId, "local-1", "fixture-map", revision, revision,
            MatchManifest.PrototypeMode, 10, 60, 10,
            new[] { "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb" }
                .Select(id => new ParticipantManifest(id, weapon)).ToArray());
        byte[] terminal = AtomicTerminalAcceptanceTests.FinishBattle(manifest);
        int tagBytes = CodedOutputStream.ComputeTagSize(CompatibilityFieldNumber);
        int paddingBytes = targetBytes - terminal.Length - tagBytes;
        while (terminal.Length + tagBytes + CodedOutputStream.ComputeLengthSize(paddingBytes) +
            paddingBytes > targetBytes)
        {
            paddingBytes--;
        }

        using var memory = new MemoryStream();
        memory.Write(terminal);
        using (var output = new CodedOutputStream(memory, leaveOpen: true))
        {
            output.WriteTag(CompatibilityFieldNumber, WireFormat.WireType.LengthDelimited);
            output.WriteBytes(ByteString.CopyFrom(Enumerable.Repeat((byte)0xfb, paddingBytes).ToArray()));
            output.Flush();
        }
        byte[] payload = memory.ToArray();
        if (payload.Length != targetBytes)
        {
            throw new InvalidOperationException("The canonical terminal boundary fixture has the wrong size.");
        }
        _ = BattleTerminalEvidenceValidator.ValidatePayload(payload, matchId, TerminalResultDigest.Compute(payload));
        return payload;
    }
}
