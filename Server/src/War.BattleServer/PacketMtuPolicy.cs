namespace War.BattleServer;
using War.Protocol.Transport;

public static class PacketMtuPolicy
{
    public static bool Accept(int byteCount,int mtu)
        =>mtu is >=576 and <=1400&&byteCount>PacketCodec.MacBytes&&byteCount<=mtu;
}
