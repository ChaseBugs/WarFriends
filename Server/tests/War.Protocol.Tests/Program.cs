using System.Security.Cryptography;
using War.Infrastructure;
using War.Protocol;
using War.Protocol.Transport;

int checks = 0;
void Check(bool condition, string name) { if (!condition) throw new Exception(name); checks++; }
byte[] secret = RandomNumberGenerator.GetBytes(32);
var tickets = new BattleTickets(Convert.ToBase64String(secret));
var claims = new TicketClaims { PlayerId = Guid.NewGuid().ToString("N"), ServerId = "test-1", SessionId = 11, IssuedUnixSeconds = 1000, ExpiresUnixSeconds = 1120, Purpose = "connectivity-probe" };
string ticket = tickets.Sign(claims);
Check(tickets.Validate(ticket, "test-1", 1000) != null, "valid admission");
Check(tickets.Validate(ticket, "test-1", 1120) == null, "half-open expiry");
Check(tickets.Validate(ticket, "wrong-server", 1001) == null, "audience");
Check(tickets.Validate(ticket, "test-1", 999) == null, "future ticket");
Check(tickets.Validate(ticket + "x", "test-1", 1001) == null, "tampered ticket");
claims.ExpiresUnixSeconds = 1121;
Check(tickets.Validate(tickets.Sign(claims), "test-1", 1001) == null, "excess lifetime");
Check(tickets.Validate("not.a.ticket", "test-1", 1001) == null, "malformed ticket");
byte[] key = tickets.SessionKey(11);
var packet = new Packet { Version = 1, SessionId = 11, Sequence = 1, Ping = new Ping { ClientTime = 42 } };
byte[] encoded = PacketCodec.Encode(packet, key);
Check(PacketCodec.Authenticate(encoded, key), "packet auth");
Check(PacketCodec.ReadUntrusted(encoded)?.Ping.ClientTime == 42, "protobuf round trip");
Check(!PacketCodec.Authenticate(encoded, tickets.SessionKey(12)), "session isolation");
encoded[0] ^= 1;
Check(!PacketCodec.Authenticate(encoded, key), "payload modification");
encoded[0] ^= 1; encoded[^1] ^= 1;
Check(!PacketCodec.Authenticate(encoded, key), "MAC modification");
Check(PacketCodec.ReadUntrusted(new byte[1201]) == null, "MTU cap");
var window = new ReplayWindow();
Check(!window.Accept(0), "zero sequence");
Check(window.Accept(1) && window.Accept(3) && window.Accept(2), "limited reordering");
Check(!window.Accept(2) && !window.Accept(1), "duplicates");
Check(window.Accept(100) && !window.Accept(3) && window.Accept(99), "old window eviction");
var random = new Random(17);
for (int i = 0; i < 1000; i++)
{
    byte[] bytes = new byte[random.Next(0, 1400)]; random.NextBytes(bytes);
    _ = PacketCodec.ReadUntrusted(bytes);
    Check(!PacketCodec.Authenticate(bytes, key), "random packet authentication");
}
Console.WriteLine($"PASS: {checks} protocol/admission/replay checks");
