using System.Net;
using War.Protocol;
using War.Protocol.Transport;
using War.Shared;

namespace War.BattleServer;

// One operator-provisioned match for the first vertical slice. No public match
// creation API. Two bounded sessions; no DB, rewards or production allocation.
public sealed class MatchEndpoint
{
    private readonly MatchEngine match;
    private readonly MatchTokens tokens;
    private readonly string serverId;
    private readonly ulong originTick;
    private readonly Dictionary<ulong, Session> sessions = [];
    private readonly Dictionary<string, ulong> generations = new(StringComparer.Ordinal);
    public string MatchId => match.MatchId;
    public string ManifestHash => match.ManifestHash;
    public MatchSnapshot? TerminalSnapshot => match.Terminal ? match.Snapshot() : null;
    public bool Expired => terminalTick.HasValue && tick - terminalTick.Value > 120 * MatchManifest.TickRate;
    private sealed class Session(string playerId, IPEndPoint endpoint, byte[] key)
    {
        public string PlayerId { get; } = playerId;
        public IPEndPoint Endpoint { get; } = endpoint;
        public byte[] Key { get; } = key;
        public ReplayWindow Replay { get; } = new();
        public ulong Outgoing;
        public ulong BudgetTick;
        public int UsedBudget;
    }
    private ulong tick;
    private ulong? terminalTick;
    public MatchEndpoint(MatchManifest manifest, string signingKey, RecoveredBattleMap? map = null,
        BattleCombatContent? content=null,ulong originTick=0)
    {
        match = new MatchEngine(manifest, map,content);
        serverId = manifest.ServerId;
        tokens = new MatchTokens(signingKey);
        this.originTick=originTick;
    }
    public bool Owns(ulong sessionId) => sessions.ContainsKey(sessionId);
    public IEnumerable<KeyValuePair<ulong,IPEndPoint>> ActiveSessionEndpoints =>
        sessions.Select(pair=>new KeyValuePair<ulong,IPEndPoint>(pair.Key,pair.Value.Endpoint));
    public bool CanReconnect(string playerId) => !Expired && !match.Terminal &&
        generations.ContainsKey(playerId) && sessions.Values.Any(s=>s.PlayerId==playerId);
    public bool CancelBeforeStart() => !Expired && match.CancelBeforeStart();
    public void ConfigureBattleAllocations(IEnumerable<BattleAllocationProjection> allocations) => match.ConfigureBattleAllocations(allocations);
    public bool AbortForHostShutdown() => !Expired && match.AbortForHostShutdown();
    public void Advance(ulong nextTick)
    {
        if(nextTick<originTick)throw new InvalidOperationException("Match tick predates allocation.");
        tick = nextTick-originTick;
        if (Expired) return;
        match.Advance(tick);
        if (match.Terminal) terminalTick ??= tick;
    }
    public byte[]? Handle(Packet packet, byte[] datagram, IPEndPoint endpoint, long unixNow)
    {
        if (Expired) return null;
        if(!ValidClientBody(packet))return null;
        if (packet.BodyCase == Packet.BodyOneofCase.MatchHello && !sessions.ContainsKey(packet.SessionId))
        {
            var claims = tokens.Validate(packet.MatchHello.Ticket, match, serverId, unixNow);
            if (claims == null || claims.SessionId != packet.SessionId) return null;
            byte[] key = tokens.SessionKey(claims);
            if (!PacketCodec.Authenticate(datagram, key)) return null;
            if (generations.TryGetValue(claims.PlayerId, out ulong generation))
            {
                if (claims.ConnectionGeneration <= generation || !match.Resume(claims.PlayerId)) return null;
                ulong old = sessions.Single(s => s.Value.PlayerId == claims.PlayerId).Key;
                sessions.Remove(old); // Revoke old key/endpoint before admitting the replacement.
            }
            else if (sessions.Count >= 2 || !match.Admit(claims.PlayerId)) return null;
            generations[claims.PlayerId] = claims.ConnectionGeneration;
            sessions.Add(packet.SessionId, new Session(claims.PlayerId, endpoint, key));
        }
        if (!sessions.TryGetValue(packet.SessionId, out var session) || !session.Endpoint.Equals(endpoint) || !PacketCodec.Authenticate(datagram, session.Key)) return null;
        // At most four authenticated commands per player/tick, in addition to the
        // host's global bounded receive queue. Excess traffic cannot refill budget.
        if (session.BudgetTick != tick) { session.BudgetTick = tick; session.UsedBudget = 0; }
        if (++session.UsedBudget > 4) return null;
        bool fresh = session.Replay.Accept(packet.Sequence);
        if (!fresh && packet.BodyCase != Packet.BodyOneofCase.MatchHello) return null;
        Packet reply=new() {Version=1,SessionId=packet.SessionId,Sequence=++session.Outgoing,Ack=packet.Sequence};
        switch (packet.BodyCase)
        {
            case Packet.BodyOneofCase.MatchHello:
                reply.MatchReply=match.Reply(0, "admitted");
                break;
            case Packet.BodyOneofCase.MatchCommand:
                reply.MatchReply=match.Command(session.PlayerId, packet.MatchCommand);
                break;
            case Packet.BodyOneofCase.MatchEventPoll:
                reply.MatchEventBatch=match.EventBatch(session.PlayerId,packet.MatchEventPoll.AfterEventId);
                break;
            case Packet.BodyOneofCase.MatchBarrelPoll:
                reply.MatchBarrelBatch=match.BarrelBatch(session.PlayerId);
                break;
            case Packet.BodyOneofCase.MatchArmyPoll:
                reply.MatchArmyBatch=match.ArmyBatch(session.PlayerId);
                break;
            case Packet.BodyOneofCase.MatchArmyEntityPoll:
                reply.MatchArmyEntityBatch=match.ArmyEntityBatch(session.PlayerId,
                    packet.MatchArmyEntityPoll.AfterEntityKey,packet.MatchArmyEntityPoll.ExpectedRevision);
                break;
            default: return null;
        }
        return PacketCodec.Encode(reply,session.Key);
    }
    private static bool ValidClientBody(Packet packet)
    {
        switch(packet.BodyCase)
        {
            case Packet.BodyOneofCase.MatchHello:
                var hello=packet.MatchHello;
                return hello.Ticket.Length is >=10 and <=1024 && hello.MatchId.Length<=64 &&
                    hello.CalculateSize()==new MatchHello {Ticket=hello.Ticket,MatchId=hello.MatchId}.CalculateSize();
            case Packet.BodyOneofCase.MatchCommand:
                var command=packet.MatchCommand;
                if(command.IntentCase==MatchCommand.IntentOneofCase.None || command.CalculateSize()>256)return false;
                var clean=new MatchCommand {CommandId=command.CommandId};
                switch(command.IntentCase)
                {
                    case MatchCommand.IntentOneofCase.Ready:
                        clean.Ready=new ReadyCommand {ManifestHash=command.Ready.ManifestHash};break;
                    case MatchCommand.IntentOneofCase.Fire:
                        clean.Fire=new FireCommand {TargetX=command.Fire.TargetX,TargetY=command.Fire.TargetY,
                            TargetZ=command.Fire.TargetZ};break;
                    case MatchCommand.IntentOneofCase.Reload:clean.Reload=new ReloadCommand();break;
                    case MatchCommand.IntentOneofCase.Forfeit:clean.Forfeit=new ForfeitCommand();break;
                    case MatchCommand.IntentOneofCase.Poll:clean.Poll=new PollMatch();break;
                    case MatchCommand.IntentOneofCase.MoveCover:
                        clean.MoveCover=new MoveCoverCommand {Direction=command.MoveCover.Direction};break;
                    case MatchCommand.IntentOneofCase.SwitchWeapon:
                        clean.SwitchWeapon=new SwitchWeaponCommand {Slot=command.SwitchWeapon.Slot};break;
                    case MatchCommand.IntentOneofCase.MinigunHold:
                        clean.MinigunHold=new MinigunHoldCommand {Pressed=command.MinigunHold.Pressed,
                            TargetX=command.MinigunHold.TargetX,TargetY=command.MinigunHold.TargetY,
                            TargetZ=command.MinigunHold.TargetZ};break;
                    case MatchCommand.IntentOneofCase.SniperAim:
                        clean.SniperAim=new SniperAimCommand {Pressed=command.SniperAim.Pressed,Cancelled=command.SniperAim.Cancelled,
                            TargetX=command.SniperAim.TargetX,TargetY=command.SniperAim.TargetY,TargetZ=command.SniperAim.TargetZ};break;
                    case MatchCommand.IntentOneofCase.BazookaHold:
                        clean.BazookaHold=new BazookaHoldCommand {Pressed=command.BazookaHold.Pressed,
                            TargetX=command.BazookaHold.TargetX,TargetY=command.BazookaHold.TargetY,TargetZ=command.BazookaHold.TargetZ};break;
                    case MatchCommand.IntentOneofCase.GrenadeThrow:
                        clean.GrenadeThrow=new GrenadeThrowCommand {Swipe=command.GrenadeThrow.Swipe,
                            TargetX=command.GrenadeThrow.TargetX,TargetY=command.GrenadeThrow.TargetY,TargetZ=command.GrenadeThrow.TargetZ,
                            SwipeStartX=command.GrenadeThrow.SwipeStartX,SwipeStartY=command.GrenadeThrow.SwipeStartY,SwipeStartZ=command.GrenadeThrow.SwipeStartZ,
                            SwipeEndX=command.GrenadeThrow.SwipeEndX,SwipeEndY=command.GrenadeThrow.SwipeEndY,SwipeEndZ=command.GrenadeThrow.SwipeEndZ,
                            HeldSeconds=command.GrenadeThrow.HeldSeconds};break;
                    case MatchCommand.IntentOneofCase.UseDecoy:
                        clean.UseDecoy=new UseDecoyCommand {RequestId=command.UseDecoy.RequestId};break;
                    case MatchCommand.IntentOneofCase.DeployArmy:
                        clean.DeployArmy=new DeployArmyCommand {OptionIndex=command.DeployArmy.OptionIndex};break;
                    case MatchCommand.IntentOneofCase.VehicleAttack:
                        clean.VehicleAttack=new VehicleAttackCommand
                        { EntityId=command.VehicleAttack.EntityId, TargetPlayerId=command.VehicleAttack.TargetPlayerId,
                          TargetX=command.VehicleAttack.TargetX, TargetY=command.VehicleAttack.TargetY,
                          TargetZ=command.VehicleAttack.TargetZ };break;
                    case MatchCommand.IntentOneofCase.SelectCards:
                        if (command.SelectCards.CardIds.Count > 32 ||
                            command.SelectCards.BuddyCardIds.Count > 32 ||
                            command.SelectCards.NormalUpgradeIndexes.Count > 64 ||
                            command.SelectCards.SpecialUpgradeIndexes.Count > 64 ||
                            command.SelectCards.EliteUpgradeIndexes.Count > 64 ||
                            command.SelectCards.NormalUpgradeIndexes.Any(x => x < 0 || x > 255) ||
                            command.SelectCards.SpecialUpgradeIndexes.Any(x => x < -1 || x > 255) ||
                            command.SelectCards.EliteUpgradeIndexes.Any(x => x < -1 || x > 255)) return false;
                        clean.SelectCards = new SelectCardsCommand();
                        clean.SelectCards.CardIds.Add(command.SelectCards.CardIds);
                        clean.SelectCards.BuddyCardIds.Add(command.SelectCards.BuddyCardIds);
                        clean.SelectCards.NormalUpgradeIndexes.Add(command.SelectCards.NormalUpgradeIndexes);
                        clean.SelectCards.SpecialUpgradeIndexes.Add(command.SelectCards.SpecialUpgradeIndexes);
                        clean.SelectCards.EliteUpgradeIndexes.Add(command.SelectCards.EliteUpgradeIndexes);
                        break;
                    default:return false;
                }
                return command.CalculateSize()==clean.CalculateSize();
            case Packet.BodyOneofCase.MatchEventPoll:
                return packet.MatchEventPoll.CalculateSize()==new MatchEventPoll
                    {AfterEventId=packet.MatchEventPoll.AfterEventId}.CalculateSize();
            case Packet.BodyOneofCase.MatchBarrelPoll:
                return packet.MatchBarrelPoll.CalculateSize()==0;
            case Packet.BodyOneofCase.MatchArmyPoll:
                return packet.MatchArmyPoll.CalculateSize()==0;
            case Packet.BodyOneofCase.MatchArmyEntityPoll:
                return packet.MatchArmyEntityPoll.CalculateSize()==new MatchArmyEntityPoll
                    {AfterEntityKey=packet.MatchArmyEntityPoll.AfterEntityKey,
                     ExpectedRevision=packet.MatchArmyEntityPoll.ExpectedRevision}.CalculateSize();
            default:return false;
        }
    }
}
