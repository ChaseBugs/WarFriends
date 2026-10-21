using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using War.BattleServer;
using War.Protocol;
using War.Protocol.Transport;

namespace War.Battle.Tests.Transport;

/// <summary>Checks deployment rejection and real authenticated datagrams at the supported UDP boundary.</summary>
internal static class PacketMtuTests
{
    private const int ReceiveTimeoutMilliseconds = 5_000;
    private const int TransferEnvelopeReserveBytes = 128;

    internal static int Run() => CheckConfiguration() + CheckBoundaryPackets() + CheckReplyChunks();

    private static int CheckConfiguration()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
        Require(BattleRuntimeConfigValidator.FromConfiguration(configuration).MtuBytes ==
            PacketCodec.MaximumDatagramBytes, "Default MTU differs from the codec budget.");
        configuration["Battle:MtuBytes"] = "1200";
        BattleRuntimeConfig frozen = BattleRuntimeConfigValidator.FromConfiguration(configuration);
        int checks = 2;
        foreach (string value in new[] { "576", "1199", "1201", "1400", "0", "2147483647", "1200.5", "large" })
        {
            configuration["Battle:MtuBytes"] = value;
            Reject(() => BattleRuntimeConfigValidator.FromConfiguration(configuration));
            checks++;
        }

        Require(frozen.MtuBytes == PacketCodec.MaximumDatagramBytes,
            "Configuration mutation changed the resolved MTU snapshot.");
        foreach (int value in new[] { 576, 1199, 1201, 1400 })
        {
            Reject(() => BattleRuntimeConfigValidator.Validate(new BattleRuntimeConfig(30000, 32, 30, value)));
            Require(!PacketMtuPolicy.Accept(100, value), "Ingress accepted an unsupported MTU policy.");
            checks += 2;
        }

        return checks;
    }

    private static int CheckBoundaryPackets()
    {
        byte[] key = RandomNumberGenerator.GetBytes(PacketCodec.MacBytes);
        using var receiver = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
        using var sender = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
        receiver.Client.ReceiveTimeout = ReceiveTimeoutMilliseconds;
        var destination = (IPEndPoint)receiver.Client.LocalEndPoint!;
        foreach (int size in new[] { PacketCodec.MaximumDatagramBytes - 1, PacketCodec.MaximumDatagramBytes })
        {
            Packet packet = ReplyOfSize(size);
            byte[] encoded = PacketCodec.Encode(packet, key);
            sender.Send(encoded, encoded.Length, destination);
            IPEndPoint peer = new(IPAddress.Any, 0);
            byte[] received = receiver.Receive(ref peer);
            Require(received.Length == size && PacketMtuPolicy.Accept(received.Length, 1200) &&
                PacketCodec.Authenticate(received, key) && PacketCodec.ReadUntrusted(received)?.Equals(packet) == true,
                "Supported full-width reply failed its real UDP/authentication round trip.");
        }

        Packet oversized = ReplyOfSize(PacketCodec.MaximumDatagramBytes + 1);
        try
        {
            PacketCodec.Encode(oversized, key);
        }
        catch (ArgumentException)
        {
            byte[] raw = new byte[PacketCodec.MaximumDatagramBytes + 1];
            Require(!PacketMtuPolicy.Accept(raw.Length, 1200) && PacketCodec.ReadUntrusted(raw) == null,
                "Oversized receive crossed the fixed protocol boundary.");
            return 3;
        }

        throw new InvalidOperationException("Outbound codec encoded a reply above the configured UDP budget.");
    }

    private static int CheckReplyChunks()
    {
        var source = new MatchReply
        {
            CommandId = ulong.MaxValue,
            Code = "accepted",
            Snapshot = new MatchSnapshot
            {
                TerminalReason = new string('x', MatchReplyTransfer.MaximumBytes - TransferEnvelopeReserveBytes)
            }
        };
        var transfer = new MatchReplyTransfer(ulong.MaxValue, 1, source);
        Require(transfer.ChunkCount > byte.MaxValue, "Transfer fixture did not exercise full-width page metadata.");
        byte[] key = RandomNumberGenerator.GetBytes(PacketCodec.MacBytes);
        int checks = 1;
        for (uint index = 0; index < transfer.ChunkCount; index++)
        {
            Packet packet = FullWidthEnvelope();
            packet.MatchReplyChunkBatch = transfer.Page(index);
            byte[] encoded = PacketCodec.Encode(packet, key);
            Require(PacketMtuPolicy.Accept(encoded.Length, 1200) && PacketCodec.Authenticate(encoded, key) &&
                PacketCodec.ReadUntrusted(encoded)?.MatchReplyChunkBatch.Equals(packet.MatchReplyChunkBatch) == true,
                "Reply page with full-width envelope and transfer ID exceeded the supported UDP budget.");
            checks++;
        }

        return checks;
    }

    private static Packet ReplyOfSize(int size)
    {
        Packet packet = FullWidthEnvelope();
        packet.MatchReply = new MatchReply { CommandId = ulong.MaxValue };
        for (int padding = 0; padding < size; padding++)
        {
            packet.MatchReply.Code = new string('x', padding);
            if (packet.CalculateSize() + PacketCodec.MacBytes == size)
            {
                return packet;
            }
        }

        throw new InvalidOperationException("Unable to construct the reviewed packet-size fixture.");
    }

    private static Packet FullWidthEnvelope() => new()
    {
        Version = 1,
        SessionId = ulong.MaxValue,
        Sequence = ulong.MaxValue,
        Ack = ulong.MaxValue,
        AckBits = uint.MaxValue
    };

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidOperationException("Unsupported MTU configuration was accepted before startup.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
