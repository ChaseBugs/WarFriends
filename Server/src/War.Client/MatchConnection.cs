using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using War.Protocol;
using War.Protocol.Transport;

namespace War.Client
{
    /// <summary>Portable Unity-compatible match transport. One in-flight mutation;
    /// its identity survives a timeout until RetryPendingAsync resolves it.</summary>
    public sealed class MatchConnection : IDisposable
    {
        private readonly Socket socket;
        private readonly MatchConnectionGrant grant;
        private readonly byte[] key;
        private readonly SemaphoreSlim gate = new SemaphoreSlim(1, 1);
        private readonly ReplayWindow replay = new ReplayWindow();
        private ulong sequence;
        private ulong commandId;
        private MatchCommand pending;
        private bool admitted;
        private volatile bool disposed;
        public IReadOnlyList<BattlePlayerView> PlayerViews { get; private set; }

        public MatchConnection(MatchConnectionGrant connection)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            grant = connection.Clone();
            PlayerViews = connection.PlayerViews.Count==0 ? new List<BattlePlayerView>().AsReadOnly() : BattlePlayerViewProjection.Validate(connection);
            IPAddress address;
            if (!IPAddress.TryParse(grant.Host, out address) || grant.Port == 0 || grant.Port > 65535 ||
                grant.SessionId == 0 || grant.SessionKey.Length != 32 || grant.Ticket.Length < 10 || grant.Ticket.Length > 1024 ||
                grant.MatchId.Length < 1 || grant.MatchId.Length > 64 || !Guid.TryParseExact(grant.PlayerId, "N", out _) ||
                !System.Text.RegularExpressions.Regex.IsMatch(grant.ManifestHash, @"\A[0-9a-f]{64}\z") ||
                grant.ExpiresUnixSeconds <= DateTimeOffset.UtcNow.ToUnixTimeSeconds() ||
                grant.ExpiresUnixSeconds > 253402300679L)
                throw new ArgumentException("Invalid match grant. An IP endpoint and unexpired participant capability are required.");
            key = grant.SessionKey.ToByteArray();
            socket = new Socket(address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            socket.Connect(new IPEndPoint(address, (int)grant.Port));
        }

        public Task<MatchReply> ConnectAsync(CancellationToken ct) => Run(null, true, false, ct);
        public Task<MatchReply> ReadyAsync(CancellationToken ct) => Run(new MatchCommand { Ready = new ReadyCommand { ManifestHash = grant.ManifestHash } }, false, false, ct);
        public Task<MatchReply> FireAsync(float x, float y, float z, CancellationToken ct) => Run(new MatchCommand { Fire = new FireCommand { TargetX = x, TargetY = y, TargetZ = z } }, false, false, ct);
        public Task<MatchReply> MinigunHoldAsync(bool pressed,float x,float y,float z,CancellationToken ct) => Run(new MatchCommand {MinigunHold=new MinigunHoldCommand {Pressed=pressed,TargetX=x,TargetY=y,TargetZ=z}},false,false,ct);
        public Task<MatchReply> SniperAimAsync(bool pressed,bool cancelled,float x,float y,float z,CancellationToken ct) => Run(new MatchCommand {SniperAim=new SniperAimCommand {Pressed=pressed,Cancelled=cancelled,TargetX=x,TargetY=y,TargetZ=z}},false,false,ct);
        public Task<MatchReply> BazookaHoldAsync(bool pressed,float x,float y,float z,CancellationToken ct) => Run(new MatchCommand {BazookaHold=new BazookaHoldCommand {Pressed=pressed,TargetX=x,TargetY=y,TargetZ=z}},false,false,ct);
        public Task<MatchReply> GrenadeLauncherThrowAsync(float x,float y,float z,CancellationToken ct) => Run(new MatchCommand {GrenadeThrow=new GrenadeThrowCommand {TargetX=x,TargetY=y,TargetZ=z}},false,false,ct);
        public Task<MatchReply> GrenadeSwipeThrowAsync(float startX,float startY,float startZ,float endX,float endY,float endZ,float heldSeconds,CancellationToken ct) => Run(new MatchCommand {GrenadeThrow=new GrenadeThrowCommand {Swipe=true,SwipeStartX=startX,SwipeStartY=startY,SwipeStartZ=startZ,SwipeEndX=endX,SwipeEndY=endY,SwipeEndZ=endZ,HeldSeconds=heldSeconds}},false,false,ct);
        public Task<MatchReply> ReloadAsync(CancellationToken ct) => Run(new MatchCommand { Reload = new ReloadCommand() }, false, false, ct);
        public Task<MatchReply> SwitchWeaponAsync(int slot,CancellationToken ct) => Run(new MatchCommand { SwitchWeapon = new SwitchWeaponCommand { Slot=slot } }, false, false, ct);
        public Task<MatchReply> ForfeitAsync(CancellationToken ct) => Run(new MatchCommand { Forfeit = new ForfeitCommand() }, false, false, ct);
        public Task<MatchReply> PollAsync(CancellationToken ct) => Run(new MatchCommand { Poll = new PollMatch() }, false, false, ct);
        public Task<MatchReply> SelectCardsAsync(IEnumerable<string> cardIds,IEnumerable<int> normal,
            IEnumerable<int> special,IEnumerable<int> elite,IEnumerable<string> buddyCardIds,CancellationToken ct)
        {
            var command=new SelectCardsCommand();
            command.CardIds.Add(cardIds??throw new ArgumentNullException(nameof(cardIds)));
            command.NormalUpgradeIndexes.Add(normal??throw new ArgumentNullException(nameof(normal)));
            command.SpecialUpgradeIndexes.Add(special??throw new ArgumentNullException(nameof(special)));
            command.EliteUpgradeIndexes.Add(elite??throw new ArgumentNullException(nameof(elite)));
            command.BuddyCardIds.Add(buddyCardIds??throw new ArgumentNullException(nameof(buddyCardIds)));
            return Run(new MatchCommand{SelectCards=command},false,false,ct);
        }
        public Task<MatchReply> MoveCoverAsync(int direction, CancellationToken ct) => Run(new MatchCommand { MoveCover = new MoveCoverCommand { Direction = direction } }, false, false, ct);
        public Task<MatchReply> DeployArmyAsync(int optionIndex, CancellationToken ct) => Run(new MatchCommand { DeployArmy = new DeployArmyCommand { OptionIndex = optionIndex } }, false, false, ct);
        public Task<MatchReply> RetryPendingAsync(CancellationToken ct) => Run(null, false, true, ct);

        // The caller advances this cursor only after consuming the returned
        // events. A new connection may resume from the same processed cursor.
        public async Task<MatchEventBatch> PollEventsAsync(ulong afterEventId, CancellationToken ct)
        {
            await gate.WaitAsync(ct).ConfigureAwait(false);
            try
            {
                if(disposed)throw new ObjectDisposedException(nameof(MatchConnection));
                if(!admitted)throw new InvalidOperationException("Connect before polling match events.");
                return await Task.Run(()=>ExchangeEvents(afterEventId,ct),ct).ConfigureAwait(false);
            }
            finally {gate.Release();}
        }

        public async Task<int> PollAndConsumeEventsAsync(MatchEventConsumer consumer, CancellationToken ct)
        {
            if (consumer == null) throw new ArgumentNullException(nameof(consumer));
            var batch = await PollEventsAsync(consumer.LastEventId, ct).ConfigureAwait(false);
            return consumer.Consume(batch);
        }

        public async Task<MatchBarrelBatch> PollBarrelsAsync(CancellationToken ct)
        {
            await gate.WaitAsync(ct).ConfigureAwait(false);
            try
            {
                if(disposed)throw new ObjectDisposedException(nameof(MatchConnection));
                if(!admitted)throw new InvalidOperationException("Connect before polling barrels.");
                return await Task.Run(()=>ExchangeBarrels(ct),ct).ConfigureAwait(false);
            }
            finally {gate.Release();}
        }

        public async Task<MatchArmyBatch> PollArmyAsync(CancellationToken ct)
        {
            await gate.WaitAsync(ct).ConfigureAwait(false);
            try
            {
                if(disposed)throw new ObjectDisposedException(nameof(MatchConnection));
                if(!admitted)throw new InvalidOperationException("Connect before polling army offers.");
                return await Task.Run(()=>ExchangeArmy(ct),ct).ConfigureAwait(false);
            }
            finally {gate.Release();}
        }

        public async Task<MatchArmyEntityBatch> PollArmyEntitiesAsync(ulong afterEntityKey,
            ulong expectedRevision,CancellationToken ct)
        {
            await gate.WaitAsync(ct).ConfigureAwait(false);
            try
            {
                if(disposed)throw new ObjectDisposedException(nameof(MatchConnection));
                if(!admitted)throw new InvalidOperationException("Connect before polling army entities.");
                return await Task.Run(()=>ExchangeArmyEntities(afterEntityKey,expectedRevision,ct),ct)
                    .ConfigureAwait(false);
            }
            finally {gate.Release();}
        }

        public async Task<IReadOnlyList<BattleArmyEntityState>> FetchArmyEntitiesAsync(CancellationToken ct)
        {
            for(int attempt=0;attempt<3;attempt++)
            {
                var rows=new List<BattleArmyEntityState>();ulong cursor=0,revision=0;
                while(true)
                {
                    var batch=await PollArmyEntitiesAsync(cursor,revision,ct).ConfigureAwait(false);
                    if(batch.Code=="revision-changed")break;
                    if(batch.Code=="army-disabled")return rows.AsReadOnly();
                    if(batch.Code!="entities")throw new InvalidOperationException("Army entity cursor rejected: "+batch.Code);
                    if(revision==0)revision=batch.Revision;
                    rows.AddRange(batch.Entities.Select(x=>x.Clone()));
                    if(rows.Count>10000)throw new InvalidOperationException("Army entity projection exceeded its bound.");
                    if(!batch.HasMore)
                    {
                        if(rows.Count!=batch.ActiveCount)throw new InvalidOperationException("Incomplete army entity projection.");
                        return rows.AsReadOnly();
                    }
                    cursor=batch.Entities[batch.Entities.Count-1].EntityKey;
                }
            }
            throw new InvalidOperationException("Army entities changed during three reconnect scans.");
        }

        private MatchArmyEntityBatch ExchangeArmyEntities(ulong after,ulong expectedRevision,CancellationToken ct)
        {
            var watch=Stopwatch.StartNew();long nextSend=0;
            ulong firstSequence=checked(sequence+1);
            byte[] buffer=new byte[PacketCodec.MaximumDatagramBytes+1];
            while(watch.ElapsedMilliseconds<3000)
            {
                ct.ThrowIfCancellationRequested();
                if(disposed)throw new ObjectDisposedException(nameof(MatchConnection));
                if(watch.ElapsedMilliseconds>=nextSend)
                {
                    var request=new Packet {Version=1,SessionId=grant.SessionId,
                        Sequence=checked(++sequence),MatchArmyEntityPoll=new MatchArmyEntityPoll
                        {AfterEntityKey=after,ExpectedRevision=expectedRevision}};
                    socket.Send(PacketCodec.Encode(request,key));
                    nextSend=watch.ElapsedMilliseconds+150;
                }
                if(!socket.Poll(10000,SelectMode.SelectRead))continue;
                int size;
                try {size=socket.Receive(buffer);}
                catch(SocketException e) when(e.SocketErrorCode==SocketError.MessageSize || e.SocketErrorCode==SocketError.ConnectionReset){continue;}
                if(size>PacketCodec.MaximumDatagramBytes)continue;
                byte[] bytes=new byte[size];Array.Copy(buffer,bytes,size);
                if(!PacketCodec.Authenticate(bytes,key))continue;
                Packet response=PacketCodec.ReadUntrusted(bytes);
                if(response==null || response.SessionId!=grant.SessionId || response.Ack<firstSequence ||
                    response.Ack>sequence || response.MatchArmyEntityBatch==null || !replay.Accept(response.Sequence))continue;
                var batch=response.MatchArmyEntityBatch;
                if(batch.MatchId!=grant.MatchId || batch.ManifestHash!=grant.ManifestHash ||
                   batch.ActiveCount>10000 || batch.ServerTick>10000000 ||
                   batch.Code!="entities" && batch.Code!="army-disabled" &&
                   batch.Code!="revision-changed" && batch.Code!="invalid-cursor" ||
                   batch.Entities.Count>4 || batch.Code!="entities" && (batch.Entities.Count!=0 || batch.HasMore) ||
                   batch.Code=="entities" && expectedRevision!=0 && batch.Revision!=expectedRevision ||
                   batch.HasMore && batch.Entities.Count!=4)
                    throw new InvalidOperationException("Battle host returned invalid army entity authority.");
                ulong prior=after;
                foreach(var entity in batch.Entities)
                {
                    if(entity.EntityKey<=prior || entity.OwnerFraction<1 || entity.OwnerFraction>2 ||
                       entity.LocalEntityId<=0 || entity.EntityKey!=
                           (((ulong)entity.OwnerFraction<<32)|(uint)entity.LocalEntityId) ||
                       !Guid.TryParseExact(entity.OwnerPlayerId,"N",out _) ||
                       entity.OwnerPlayerId!=entity.OwnerPlayerId.ToLowerInvariant() ||
                       entity.OptionIndex<0 || entity.OptionIndex>=48 ||
                       !System.Text.RegularExpressions.Regex.IsMatch(entity.UnitId,@"\AID_UNIT-[A-Z0-9-]{1,50}\z") ||
                       entity.SpawnComponentFileId<=0 || entity.ReservationFileId<0 ||
                       !FiniteCoordinate(entity.X) || !FiniteCoordinate(entity.Y) || !FiniteCoordinate(entity.Z) ||
                       (entity.MaxHealth==0 ? entity.Health!=0 :
                           float.IsNaN(entity.MaxHealth) || float.IsInfinity(entity.MaxHealth) ||
                           entity.MaxHealth<=0 || entity.MaxHealth>10000000 ||
                           float.IsNaN(entity.Health) || float.IsInfinity(entity.Health) ||
                           entity.Health<=0 || entity.Health>entity.MaxHealth) ||
                       (entity.MaxKevlar==0 ? entity.Kevlar!=0 :
                           float.IsNaN(entity.MaxKevlar) || float.IsInfinity(entity.MaxKevlar) ||
                           entity.MaxKevlar<=0 || entity.MaxKevlar>10000000 ||
                           float.IsNaN(entity.Kevlar) || float.IsInfinity(entity.Kevlar) ||
                           entity.Kevlar<0 || entity.Kevlar>entity.MaxKevlar) ||
                       entity.SpawnTick>batch.ServerTick ||
                       entity.PositionTick<entity.SpawnTick ||
                       entity.PositionTick>batch.ServerTick)
                        throw new InvalidOperationException("Battle host returned invalid army entity row.");
                    prior=entity.EntityKey;
                }
                return batch.Clone();
            }
            throw new TimeoutException("Battle host did not acknowledge army entities. Retry the read.");
        }

        private static bool FiniteCoordinate(float x)=>!float.IsNaN(x) && !float.IsInfinity(x) && Math.Abs(x)<=10000;

        private MatchArmyBatch ExchangeArmy(CancellationToken ct)
        {
            var watch=Stopwatch.StartNew();long nextSend=0;
            ulong firstSequence=checked(sequence+1);
            byte[] buffer=new byte[PacketCodec.MaximumDatagramBytes+1];
            while(watch.ElapsedMilliseconds<3000)
            {
                ct.ThrowIfCancellationRequested();
                if(disposed)throw new ObjectDisposedException(nameof(MatchConnection));
                if(watch.ElapsedMilliseconds>=nextSend)
                {
                    var request=new Packet {Version=1,SessionId=grant.SessionId,
                        Sequence=checked(++sequence),MatchArmyPoll=new MatchArmyPoll()};
                    socket.Send(PacketCodec.Encode(request,key));
                    nextSend=watch.ElapsedMilliseconds+150;
                }
                if(!socket.Poll(10000,SelectMode.SelectRead))continue;
                int size;
                try {size=socket.Receive(buffer);}
                catch(SocketException e) when(e.SocketErrorCode==SocketError.MessageSize || e.SocketErrorCode==SocketError.ConnectionReset){continue;}
                if(size>PacketCodec.MaximumDatagramBytes)continue;
                byte[] bytes=new byte[size];Array.Copy(buffer,bytes,size);
                if(!PacketCodec.Authenticate(bytes,key))continue;
                Packet response=PacketCodec.ReadUntrusted(bytes);
                if(response==null || response.SessionId!=grant.SessionId || response.Ack<firstSequence ||
                    response.Ack>sequence || response.MatchArmyBatch==null || !replay.Accept(response.Sequence))continue;
                var batch=response.MatchArmyBatch;
                if(batch.MatchId!=grant.MatchId || batch.ManifestHash!=grant.ManifestHash ||
                   batch.Code!="army-offers" && batch.Code!="army-unavailable" &&
                   batch.Code!="army-not-running" && batch.Code!="army-disabled" ||
                   batch.OptionIndexes.Count!=(batch.Code=="army-offers"?3:0) ||
                   batch.OptionIndexes.Any(index=>index<0 || index>=48) ||
                   batch.Energy<0 || batch.Energy>16 || batch.ActiveCount<0 || batch.ActiveCount>10000 ||
                   batch.PendingCount<0 || batch.PendingCount>100 || batch.NextDeployTick>10001000)
                    throw new InvalidOperationException("Battle host returned invalid army authority.");
                return batch.Clone();
            }
            throw new TimeoutException("Battle host did not acknowledge army offers. Retry the read.");
        }

        private MatchBarrelBatch ExchangeBarrels(CancellationToken ct)
        {
            var watch=Stopwatch.StartNew();long nextSend=0;
            ulong firstSequence=checked(sequence+1);
            byte[] buffer=new byte[PacketCodec.MaximumDatagramBytes+1];
            while(watch.ElapsedMilliseconds<3000)
            {
                ct.ThrowIfCancellationRequested();
                if(disposed)throw new ObjectDisposedException(nameof(MatchConnection));
                if(watch.ElapsedMilliseconds>=nextSend)
                {
                    var request=new Packet {Version=1,SessionId=grant.SessionId,
                        Sequence=checked(++sequence),MatchBarrelPoll=new MatchBarrelPoll()};
                    socket.Send(PacketCodec.Encode(request,key));
                    nextSend=watch.ElapsedMilliseconds+150;
                }
                if(!socket.Poll(10000,SelectMode.SelectRead))continue;
                int size;
                try {size=socket.Receive(buffer);}
                catch(SocketException e) when(e.SocketErrorCode==SocketError.MessageSize || e.SocketErrorCode==SocketError.ConnectionReset){continue;}
                if(size>PacketCodec.MaximumDatagramBytes)continue;
                byte[] bytes=new byte[size];Array.Copy(buffer,bytes,size);
                if(!PacketCodec.Authenticate(bytes,key))continue;
                Packet response=PacketCodec.ReadUntrusted(bytes);
                if(response==null || response.SessionId!=grant.SessionId || response.Ack<firstSequence ||
                    response.Ack>sequence || response.MatchBarrelBatch==null || !replay.Accept(response.Sequence))continue;
                var batch=response.MatchBarrelBatch;
                if(batch.MatchId!=grant.MatchId || batch.ManifestHash!=grant.ManifestHash ||
                    batch.SourceCount>10 || batch.Changed.Count>batch.SourceCount ||
                    (batch.SourceCount==0)!=(batch.MaxHealth==0) ||
                    (batch.SourceCount>0 && (float.IsNaN(batch.MaxHealth) || float.IsInfinity(batch.MaxHealth) ||
                        batch.MaxHealth<50 || batch.MaxHealth>56)) ||
                    batch.Changed.Select(x=>x.ColliderIndex).Distinct().Count()!=batch.Changed.Count ||
                    batch.Changed.Select(x=>x.GameObjectFileId).Distinct().Count()!=batch.Changed.Count ||
                    batch.Changed.Any(x=>x.ColliderIndex<0 || x.GameObjectFileId<=0 || x.Revision==0 ||
                        float.IsNaN(x.Health) || float.IsInfinity(x.Health) ||
                        x.Health>batch.MaxHealth || x.Destroyed!=(x.Health<=0)))
                    throw new InvalidOperationException("Battle host returned invalid barrel authority.");
                return batch.Clone();
            }
            throw new TimeoutException("Battle host did not acknowledge barrel state. Retry the read.");
        }

        private MatchEventBatch ExchangeEvents(ulong afterEventId,CancellationToken ct)
        {
            var watch=Stopwatch.StartNew();long nextSend=0;
            ulong firstSequence=checked(sequence+1);
            byte[] buffer=new byte[PacketCodec.MaximumDatagramBytes+1];
            while(watch.ElapsedMilliseconds<3000)
            {
                ct.ThrowIfCancellationRequested();
                if(disposed)throw new ObjectDisposedException(nameof(MatchConnection));
                if(watch.ElapsedMilliseconds>=nextSend)
                {
                    var request=new Packet {Version=1,SessionId=grant.SessionId,Sequence=checked(++sequence),
                        MatchEventPoll=new MatchEventPoll {AfterEventId=afterEventId}};
                    socket.Send(PacketCodec.Encode(request,key));
                    nextSend=watch.ElapsedMilliseconds+150;
                }
                if(!socket.Poll(10000,SelectMode.SelectRead))continue;
                int size;
                try {size=socket.Receive(buffer);}
                catch(SocketException e) when(e.SocketErrorCode==SocketError.MessageSize || e.SocketErrorCode==SocketError.ConnectionReset){continue;}
                if(size>PacketCodec.MaximumDatagramBytes)continue;
                byte[] bytes=new byte[size];Array.Copy(buffer,bytes,size);
                if(!PacketCodec.Authenticate(bytes,key))continue;
                Packet response=PacketCodec.ReadUntrusted(bytes);
                if(response==null || response.SessionId!=grant.SessionId || response.Ack<firstSequence || response.Ack>sequence ||
                    response.MatchEventBatch==null || !replay.Accept(response.Sequence))continue;
                var batch=response.MatchEventBatch;
                if(batch.MatchId!=grant.MatchId || batch.ManifestHash!=grant.ManifestHash || batch.Events.Count>4 ||
                    batch.LatestEventId<afterEventId && batch.Code=="events")
                    throw new InvalidOperationException("Battle host returned an incompatible event batch.");
                if(batch.Code!="events")throw new InvalidOperationException("Battle event cursor rejected: "+batch.Code);
                ulong expected=afterEventId;
                foreach(var row in batch.Events)
                    if(row.EventId!=checked(++expected) || row.EventId>batch.LatestEventId ||
                       row.Kind==MatchEventKind.Unspecified ||
                       (row.Kind==MatchEventKind.ArmySpawned || row.Kind==MatchEventKind.ArmyDied) &&
                       (row.ArmyEntityId<=0 || row.ArmyOptionIndex<0 || row.ArmyOptionIndex>=48 ||
                        row.ArmySpawnComponentFileId<=0 || row.ArmyReservationFileId<0 ||
                        (row.Kind==MatchEventKind.ArmySpawned ?
                            !Guid.TryParseExact(row.ActorId,"N",out _) || row.ArmyEnergyRecipientId!="" :
                            !Guid.TryParseExact(row.TargetId,"N",out _) ||
                            !Guid.TryParseExact(row.ArmyEnergyRecipientId,"N",out _) ||
                            row.Reason!="suicide" && row.Reason!="combat") ||
                        !System.Text.RegularExpressions.Regex.IsMatch(row.ArmyUnitId,@"\AID_UNIT-[A-Z0-9-]{1,50}\z") ||
                        !FiniteCoordinate(row.X) || !FiniteCoordinate(row.Y) || !FiniteCoordinate(row.Z)))
                        throw new InvalidOperationException("Battle host returned unordered events.");
                foreach(var row in batch.Events)
                {
                    bool entityLifecycle = row.Kind==MatchEventKind.AirSpawned || row.Kind==MatchEventKind.AirDespawned ||
                        row.Kind==MatchEventKind.DeployableSpawned || row.Kind==MatchEventKind.DeployableDespawned;
                    if(entityLifecycle && (row.ProjectileId==0 || !Guid.TryParseExact(row.ActorId,"N",out _)))
                        throw new InvalidOperationException("Battle host returned invalid entity lifecycle metadata.");
                    bool cardLifecycle = row.Kind==MatchEventKind.CardEffectApplied || row.Kind==MatchEventKind.CardEffectExpired;
                    if(cardLifecycle && (!Guid.TryParseExact(row.ActorId,"N",out _) || string.IsNullOrWhiteSpace(row.Reason)))
                        throw new InvalidOperationException("Battle host returned invalid card lifecycle metadata.");
                    if(row.Kind==MatchEventKind.ObjectiveProgress &&
                       (!Guid.TryParseExact(row.ActorId,"N",out _) || row.ProjectileId==0 || string.IsNullOrWhiteSpace(row.Reason)))
                        throw new InvalidOperationException("Battle host returned invalid objective metadata.");
                    if(row.Kind==MatchEventKind.ArenaSettled &&
                       (!Guid.TryParseExact(row.ActorId,"N",out _) ||
                        (!row.Reason.EndsWith(":won",StringComparison.Ordinal) && !row.Reason.EndsWith(":lost",StringComparison.Ordinal))))
                        throw new InvalidOperationException("Battle host returned invalid Arena settlement metadata.");
                    if((row.Kind==MatchEventKind.VehicleSpawned || row.Kind==MatchEventKind.VehicleDestroyed) &&
                       (!Guid.TryParseExact(row.ActorId,"N",out _) || !uint.TryParse(row.Reason,out var generation) || generation==0 ||
                        row.ProjectileId==0 || string.IsNullOrWhiteSpace(row.TargetId)))
                        throw new InvalidOperationException("Battle host returned invalid vehicle lifecycle metadata.");
                }
                return batch.Clone();
            }
            throw new TimeoutException("Battle host did not acknowledge the event cursor. Retry the same cursor.");
        }

        private async Task<MatchReply> Run(MatchCommand command, bool hello, bool retry, CancellationToken ct)
        {
            await gate.WaitAsync(ct).ConfigureAwait(false);
            try
            {
                if (disposed) throw new ObjectDisposedException(nameof(MatchConnection));
                if (hello && admitted) throw new InvalidOperationException("This session is already admitted. Reconnect with a fresh grant and connection.");
                if (!hello && !admitted) throw new InvalidOperationException("Connect before sending match commands.");
                bool poll = command != null && command.IntentCase == MatchCommand.IntentOneofCase.Poll;
                if (retry)
                {
                    if (pending == null) throw new InvalidOperationException("No unresolved command.");
                    command = pending.Clone();
                }
                else if (!hello && !poll)
                {
                    if (pending != null) throw new InvalidOperationException("Retry the unresolved command before another mutation.");
                    command.CommandId = checked(commandId + 1);
                    pending = command.Clone();
                }
                // Poll/Receive is run off Unity's main thread. No orphaned async
                // receive tasks can consume a later request's reply after timeout.
                MatchReply reply = await Task.Run(() => Exchange(command, hello, ct), ct).ConfigureAwait(false);
                if (hello)
                {
                    if (reply.Code != "admitted") throw new InvalidOperationException("Admission rejected: " + reply.Code);
                    admitted = true;
                    foreach (var player in reply.Snapshot.Players)
                        if (player.PlayerId == grant.PlayerId) commandId = player.LastCommandId;
                }
                else if (!poll)
                {
                    if (reply.Code == "command-conflict" || reply.Code == "command-order" || reply.Code == "invalid-command" || reply.Code == "not-admitted")
                        throw new InvalidOperationException("Match command stream rejected: " + reply.Code);
                    commandId = command.CommandId;
                    pending = null;
                }
                return reply;
            }
            finally { gate.Release(); }
        }

        private MatchReply Exchange(MatchCommand command, bool hello, CancellationToken ct)
        {
            var watch = Stopwatch.StartNew();
            long nextSend = 0;
            ulong firstSequence = checked(sequence + 1);
            byte[] buffer = new byte[PacketCodec.MaximumDatagramBytes + 1];
            while (watch.ElapsedMilliseconds < 3000)
            {
                ct.ThrowIfCancellationRequested();
                if (disposed) throw new ObjectDisposedException(nameof(MatchConnection));
                if (watch.ElapsedMilliseconds >= nextSend)
                {
                    var packet = new Packet { Version = 1, SessionId = grant.SessionId, Sequence = checked(++sequence) };
                    if (hello) packet.MatchHello = new MatchHello { Ticket = grant.Ticket, MatchId = grant.MatchId };
                    else packet.MatchCommand = command;
                    socket.Send(PacketCodec.Encode(packet, key));
                    nextSend = watch.ElapsedMilliseconds + 150;
                }
                if (!socket.Poll(10000, SelectMode.SelectRead)) continue;
                int size;
                try { size = socket.Receive(buffer); }
                catch (SocketException e) when (e.SocketErrorCode == SocketError.MessageSize || e.SocketErrorCode == SocketError.ConnectionReset) { continue; }
                if (size > PacketCodec.MaximumDatagramBytes) continue;
                byte[] bytes = new byte[size]; Array.Copy(buffer, bytes, size);
                if (!PacketCodec.Authenticate(bytes, key)) continue;
                Packet response = PacketCodec.ReadUntrusted(bytes);
                if (response == null || response.SessionId != grant.SessionId || response.Ack < firstSequence || response.Ack > sequence ||
                    response.MatchReply == null || response.MatchReply.CommandId != (hello ? 0 : command.CommandId) || !replay.Accept(response.Sequence)) continue;
                var snapshot = response.MatchReply.Snapshot;
                if (snapshot == null || snapshot.MatchId != grant.MatchId || snapshot.ManifestHash != grant.ManifestHash || snapshot.Players.Count != 2)
                    throw new InvalidOperationException("Battle host returned an incompatible snapshot.");
                ulong priorVehicle = 0;
                foreach (var vehicle in snapshot.Vehicles)
                {
                    if (vehicle.EntityId == 0 || vehicle.EntityId <= priorVehicle || vehicle.Generation == 0 ||
                        !Guid.TryParseExact(vehicle.OwnerPlayerId, "N", out _) ||
                        vehicle.OwnerPlayerId != vehicle.OwnerPlayerId.ToLowerInvariant() ||
                        string.IsNullOrWhiteSpace(vehicle.UnitId) || vehicle.UnitId.Length > 64 ||
                        !FiniteCoordinate(vehicle.X) || !FiniteCoordinate(vehicle.Y) || !FiniteCoordinate(vehicle.Z) ||
                        vehicle.AttackPhase < 0 || vehicle.AttackPhase > 3 || vehicle.CooldownTicks < 0 || vehicle.CooldownTicks > 10_000_000 ||
                        float.IsNaN(vehicle.MaxHealth) || float.IsInfinity(vehicle.MaxHealth) || vehicle.MaxHealth < 0 || vehicle.MaxHealth > 10_000_000 ||
                        float.IsNaN(vehicle.Health) || float.IsInfinity(vehicle.Health) || vehicle.Health < 0 || vehicle.Health > vehicle.MaxHealth)
                        throw new InvalidOperationException("Battle host returned an invalid vehicle snapshot row.");
                    var partIds = new System.Collections.Generic.HashSet<string>(StringComparer.Ordinal);
                    foreach (var part in vehicle.Parts)
                        if (string.IsNullOrWhiteSpace(part.PartId) || part.PartId.Length > 64 || !partIds.Add(part.PartId) ||
                            float.IsNaN(part.MaxHealth) || float.IsInfinity(part.MaxHealth) || part.MaxHealth <= 0 ||
                            part.MaxHealth > 10_000_000 || float.IsNaN(part.Health) || float.IsInfinity(part.Health) ||
                            part.Health < 0 || part.Health > part.MaxHealth ||
                            (!string.IsNullOrEmpty(part.PassengerPlayerId) && !Guid.TryParseExact(part.PassengerPlayerId, "N", out _)))
                            throw new InvalidOperationException("Battle host returned an invalid vehicle part row.");
                    priorVehicle = vehicle.EntityId;
                }
                ulong priorDeployable = 0;
                foreach (var deployable in snapshot.Deployables)
                {
                    if (deployable.EntityId <= 0 || (ulong)deployable.EntityId <= priorDeployable ||
                        !Guid.TryParseExact(deployable.OwnerPlayerId, "N", out _) ||
                        deployable.OwnerPlayerId != deployable.OwnerPlayerId.ToLowerInvariant() ||
                        deployable.CardId != "LandMine" && deployable.CardId != "HeavyTurret" ||
                        !FiniteCoordinate(deployable.X) || !FiniteCoordinate(deployable.Y) || !FiniteCoordinate(deployable.Z) ||
                        deployable.State < 0 || deployable.State > 2 || deployable.RemainingTicks < 0 || deployable.RemainingTicks > 1_800 ||
                        deployable.Charges < 0 || deployable.Charges > 32 || deployable.CooldownTicks < 0 || deployable.CooldownTicks > 10_000_000)
                        throw new InvalidOperationException("Battle host returned an invalid deployable snapshot row.");
                    priorDeployable = (ulong)deployable.EntityId;
                }
                return response.MatchReply.Clone();
            }
            throw new TimeoutException("Battle host did not acknowledge the request. Retry pending mutations with their existing identity.");
        }

        public void Dispose() { disposed = true; socket.Dispose(); }
    }
}
