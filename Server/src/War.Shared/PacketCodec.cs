using System;
using System.Security.Cryptography;
using Google.Protobuf;

namespace War.Protocol.Transport
{
    public static class PacketCodec
    {
        public const int MaximumDatagramBytes = 1200;
        public const int MacBytes = 32;
        public static byte[] Encode(Packet packet, byte[] key)
        {
            if (key.Length != 32) throw new ArgumentException("Session key must be 32 bytes.");
            byte[] payload = packet.ToByteArray();
            if (payload.Length + MacBytes > MaximumDatagramBytes) throw new ArgumentException("Datagram exceeds MTU budget.");
            byte[] result = new byte[payload.Length + MacBytes];
            Array.Copy(payload, result, payload.Length);
            using (var hmac = new HMACSHA256(key)) Array.Copy(hmac.ComputeHash(payload), 0, result, payload.Length, MacBytes);
            return result;
        }
        // The result is untrusted until Authenticate succeeds.
        public static Packet ReadUntrusted(byte[] bytes)
        {
            if (bytes.Length <= MacBytes || bytes.Length > MaximumDatagramBytes) return null;
            try
            {
                Packet packet = Packet.Parser.ParseFrom(bytes, 0, bytes.Length - MacBytes);
                if (packet.Version != 1 || packet.SessionId == 0 || packet.Sequence == 0 ||
                    packet.BodyCase == Packet.BodyOneofCase.None) return null;
                // Protobuf retains unknown fields. Comparing a rebuilt envelope
                // excludes them before any session or replay state is touched.
                var clean = new Packet { Version = packet.Version, SessionId = packet.SessionId,
                    Sequence = packet.Sequence, Ack = packet.Ack, AckBits = packet.AckBits };
                switch (packet.BodyCase)
                {
                    case Packet.BodyOneofCase.Hello: clean.Hello = packet.Hello; break;
                    case Packet.BodyOneofCase.Welcome: clean.Welcome = packet.Welcome; break;
                    case Packet.BodyOneofCase.Ping: clean.Ping = packet.Ping; break;
                    case Packet.BodyOneofCase.Pong: clean.Pong = packet.Pong; break;
                    case Packet.BodyOneofCase.Disconnect: clean.Disconnect = packet.Disconnect; break;
                    case Packet.BodyOneofCase.MatchHello: clean.MatchHello = packet.MatchHello; break;
                    case Packet.BodyOneofCase.MatchCommand: clean.MatchCommand = packet.MatchCommand; break;
                    case Packet.BodyOneofCase.MatchReply: clean.MatchReply = packet.MatchReply; break;
                    case Packet.BodyOneofCase.MatchEventPoll: clean.MatchEventPoll = packet.MatchEventPoll; break;
                    case Packet.BodyOneofCase.MatchEventBatch: clean.MatchEventBatch = packet.MatchEventBatch; break;
                    case Packet.BodyOneofCase.MatchBarrelPoll: clean.MatchBarrelPoll = packet.MatchBarrelPoll; break;
                    case Packet.BodyOneofCase.MatchBarrelBatch: clean.MatchBarrelBatch = packet.MatchBarrelBatch; break;
                    case Packet.BodyOneofCase.MatchArmyPoll: clean.MatchArmyPoll = packet.MatchArmyPoll; break;
                    case Packet.BodyOneofCase.MatchArmyBatch: clean.MatchArmyBatch = packet.MatchArmyBatch; break;
                    case Packet.BodyOneofCase.MatchArmyEntityPoll: clean.MatchArmyEntityPoll = packet.MatchArmyEntityPoll; break;
                    case Packet.BodyOneofCase.MatchArmyEntityBatch: clean.MatchArmyEntityBatch = packet.MatchArmyEntityBatch; break;
                    default: return null;
                }
                return clean.ToByteArray().AsSpan().SequenceEqual(bytes.AsSpan(0, bytes.Length - MacBytes))
                    ? packet : null;
            }
            catch (InvalidProtocolBufferException) { return null; }
        }
        public static bool Authenticate(byte[] bytes, byte[] key)
        {
            if (key.Length != 32 || bytes.Length <= MacBytes || bytes.Length > MaximumDatagramBytes) return false;
            byte[] digest;
            using (var hmac = new HMACSHA256(key)) digest = hmac.ComputeHash(bytes, 0, bytes.Length - MacBytes);
            int difference = 0;
            for (int i = 0; i < MacBytes; i++) difference |= digest[i] ^ bytes[bytes.Length - MacBytes + i];
            return difference == 0;
        }
    }
    public sealed class ReplayWindow
    {
        public ulong Highest { get; private set; }
        private ulong seen;
        public bool Accept(ulong sequence)
        {
            if (sequence == 0) return false;
            if (sequence > Highest)
            {
                ulong gap = sequence - Highest;
                seen = gap >= 64 ? 1 : (seen << (int)gap) | 1;
                Highest = sequence;
                return true;
            }
            ulong behind = Highest - sequence;
            if (behind >= 64 || (seen & (1UL << (int)behind)) != 0) return false;
            seen |= 1UL << (int)behind;
            return true;
        }
    }
}
