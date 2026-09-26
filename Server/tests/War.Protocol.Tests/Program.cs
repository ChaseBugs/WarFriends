using System.Security.Cryptography;
using Google.Protobuf;
using War.Infrastructure;
using War.Protocol;
using War.Protocol.Transport;

int checks = 0;
checks += await BattleMatchControlClientTests.Run();
void Check(bool condition, string name) { if (!condition) throw new Exception(name); checks++; }
Check(new MatchQueueRequest().CalculateSize()==0,"canonical matchmaking request is empty");
var queueWire=new MatchQueueReply{Code="paired",MatchId="m"+new string('a',32)};queueWire.PlayerIds.Add(Guid.NewGuid().ToString("N"));queueWire.PlayerIds.Add(Guid.NewGuid().ToString("N"));
Check(MatchQueueReply.Parser.ParseFrom(queueWire.ToByteArray()).Equals(queueWire),"matchmaking reply protobuf round trip");
var grenadeWire=new MatchCommand{CommandId=17,GrenadeThrow=new GrenadeThrowCommand{Swipe=true,
    SwipeStartX=1,SwipeStartY=2,SwipeStartZ=3,SwipeEndX=4,SwipeEndY=5,SwipeEndZ=6,HeldSeconds=.25f}};
Check(MatchCommand.Parser.ParseFrom(grenadeWire.ToByteArray()).Equals(grenadeWire)&&
      grenadeWire.IntentCase==MatchCommand.IntentOneofCase.GrenadeThrow,
    "typed grenade swipe intent protobuf round trip");
var decoyRequest=Guid.NewGuid().ToString("N");
var decoyWire=new MatchCommand{CommandId=18,UseDecoy=new UseDecoyCommand{RequestId=decoyRequest}};
var decoySnapshot=new MatchSnapshot();decoySnapshot.Decoys.Add(new BattleDecoyState
{EntityId=1,RequestId=decoyRequest,OwnerPlayerId=Guid.NewGuid().ToString("N"),OwnerFraction=1,
 ObstacleComponentFileId=123,X=1,Y=2,Z=3,FacingZ=1,Health=100,MaxHealth=100});
Check(MatchCommand.Parser.ParseFrom(decoyWire.ToByteArray()).Equals(decoyWire)&&
      decoyWire.IntentCase==MatchCommand.IntentOneofCase.UseDecoy&&
      MatchSnapshot.Parser.ParseFrom(decoySnapshot.ToByteArray()).Equals(decoySnapshot),
    "typed Decoy activation and authoritative state protobuf round trip");
var mineRequest=Guid.NewGuid().ToString("N");
var mineWire=new MatchCommand{CommandId=19,UseLandMine=new UseLandMineCommand{RequestId=mineRequest}};
var mineSnapshot=new MatchSnapshot();mineSnapshot.LandMines.Add(new BattleLandMineState
{EntityId=1,RequestId=mineRequest,OwnerPlayerId=Guid.NewGuid().ToString("N"),OwnerFraction=1,
 HidingComponentFileId=456,X=1,Y=2,Z=3,Damage=57.625f});
Check(MatchCommand.Parser.ParseFrom(mineWire.ToByteArray()).Equals(mineWire)&&
      mineWire.IntentCase==MatchCommand.IntentOneofCase.UseLandMine&&
      MatchSnapshot.Parser.ParseFrom(mineSnapshot.ToByteArray()).Equals(mineSnapshot),
    "typed Land Mine activation and authoritative state protobuf round trip");
var turretRequest=Guid.NewGuid().ToString("N");
var turretWire=new MatchCommand{CommandId=20,UseHeavyTurret=new UseHeavyTurretCommand{RequestId=turretRequest}};
var turretSnapshot=new MatchSnapshot();turretSnapshot.HeavyTurrets.Add(new BattleHeavyTurretState
{EntityId=1,RequestId=turretRequest,OwnerPlayerId=Guid.NewGuid().ToString("N"),OwnerFraction=1,
 SlotComponentFileId=789,X=1,Y=2,Z=3,Health=100,MaxHealth=100,Damage=20,BatchMinimum=3,BatchMaximum=6,
 ShootMinimum=2,ShootMaximum=4,RealShotProbability=.75f});
Check(MatchCommand.Parser.ParseFrom(turretWire.ToByteArray()).Equals(turretWire)&&
      turretWire.IntentCase==MatchCommand.IntentOneofCase.UseHeavyTurret&&
      MatchSnapshot.Parser.ParseFrom(turretSnapshot.ToByteArray()).Equals(turretSnapshot),
    "typed Heavy Turret activation and authoritative state protobuf round trip");
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
byte[] canonical=packet.ToByteArray();
byte[] repeatedVersion=canonical.Concat(new byte[]{8,1}).ToArray();
byte[] duplicateWire=repeatedVersion.Concat(HMACSHA256.HashData(key,repeatedVersion)).ToArray();
Check(PacketCodec.Authenticate(duplicateWire,key) && PacketCodec.ReadUntrusted(duplicateWire)==null,
    "noncanonical duplicate protobuf envelope is rejected despite a valid MAC");
byte[] unknownEnvelope=canonical.Concat(new byte[]{0x98,0x06,0x01}).ToArray();
byte[] unknownWire=unknownEnvelope.Concat(HMACSHA256.HashData(key,unknownEnvelope)).ToArray();
Check(PacketCodec.Authenticate(unknownWire,key) && PacketCodec.ReadUntrusted(unknownWire)==null,
    "authenticated unknown envelope field cannot reach session or replay state");
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
