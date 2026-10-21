using War.Protocol.Transport;

namespace War.BattleServer;

/// <summary>Applies the fixed authenticated datagram budget shared by codec, host and portable SDK.</summary>
public static class PacketMtuPolicy
{
    /// <summary>Rejects unsupported budgets as well as oversized or MAC-only datagrams.</summary>
    public static bool Accept(int byteCount, int mtu) =>
        mtu == PacketCodec.MaximumDatagramBytes && byteCount > PacketCodec.MacBytes && byteCount <= mtu;
}
