using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Google.Protobuf;
using War.Protocol;

namespace War.BattleServer;

/// <summary>Crash-readable local spool for unscored terminal evidence.</summary>
public sealed class TerminalOutbox
{
    private static readonly byte[] Magic="WFR1"u8.ToArray();
    private static readonly TimeSpan AcknowledgementRetention=TimeSpan.FromDays(30);
    private readonly string directory;
    private readonly object gate=new();
    public sealed record Evidence(MatchSnapshot Snapshot,string Digest);
    public TerminalOutbox(string path):this(path,null){}
    internal TerminalOutbox(string path,IReadOnlySet<string>? recoverableActiveIds)
    {
        directory=Path.GetFullPath(path);
        Directory.CreateDirectory(directory);
        var temporaries=Directory.EnumerateFiles(directory,"*.tmp").Take(10001).ToArray();
        if(temporaries.Length>10000)throw new InvalidDataException("Terminal outbox temporary capacity exceeded.");
        foreach(var temporary in temporaries)
        {
            string name=Path.GetFileName(temporary);
            if(!Regex.IsMatch(name,@"\A[a-zA-Z0-9_-]{1,64}\.[0-9a-f]{32}\.tmp\z"))
                throw new InvalidDataException("Invalid terminal outbox temporary filename.");
            MatchSnapshot snapshot;
            try {snapshot=ReadFile(temporary);}
            catch(InvalidDataException) when(recoverableActiveIds?.Contains(name.Split('.')[0])==true)
            {
                // A validated active allocation can recover as unscored host-crash
                // evidence. Keep the interrupted bytes for operator inspection.
                File.Move(temporary,temporary+".partial");
                continue;
            }
            byte[] bytes=File.ReadAllBytes(temporary);
            string pending=Path.Combine(directory,snapshot.MatchId+".wfr");
            string acknowledged=Path.Combine(directory,snapshot.MatchId+".ack");
            if(File.Exists(pending) || File.Exists(acknowledged))
            {
                string existing=File.Exists(acknowledged)?acknowledged:pending;
                if(!File.ReadAllBytes(existing).AsSpan().SequenceEqual(bytes))
                    throw new InvalidDataException("Conflicting uncommitted terminal evidence.");
                File.Delete(temporary);
            }
            else File.Move(temporary,pending);
        }
        var files=Directory.EnumerateFiles(directory)
            .Where(f=>Path.GetExtension(f) is ".wfr" or ".ack").Take(10001).ToArray();
        if(files.Length>10000)throw new InvalidDataException("Terminal outbox capacity exceeded.");
        foreach(var file in files)
        {
            if(!Regex.IsMatch(Path.GetFileName(file),@"\A[a-zA-Z0-9_-]{1,64}\.(wfr|ack)\z"))
                throw new InvalidDataException("Invalid terminal outbox filename.");
            ReadFile(file);
        }
        if(files.Select(Path.GetFileNameWithoutExtension).Distinct(StringComparer.Ordinal).Count()!=files.Length)
            throw new InvalidDataException("Duplicate pending and acknowledged terminal identity.");
    }
    public IReadOnlyList<MatchSnapshot> Pending()
        =>PendingPage(10000).Select(e=>e.Snapshot).ToArray();
    public bool HasIdentity(string matchId)
    {
        if(!Regex.IsMatch(matchId,@"\A[a-zA-Z0-9_-]{1,64}\z"))
            throw new ArgumentException("Invalid terminal identity.",nameof(matchId));
        lock(gate)return ReadIdentity(matchId)!=null;
    }
    public bool Contains(string matchId,string manifestHash,IReadOnlyList<string> playerIds)
    {
        if(!Regex.IsMatch(matchId,@"\A[a-zA-Z0-9_-]{1,64}\z"))
            throw new ArgumentException("Invalid terminal identity.",nameof(matchId));
        lock(gate)
        {
            var snapshot=ReadIdentity(matchId);
            if(snapshot==null)return false;
            if(snapshot.ManifestHash!=manifestHash || playerIds.Count!=2 ||
               snapshot.Players[0].PlayerId!=playerIds[0] ||
               snapshot.Players[1].PlayerId!=playerIds[1])
                throw new InvalidDataException("Terminal result conflicts with active allocation proof.");
            return true;
        }
    }
    private MatchSnapshot? ReadIdentity(string matchId)
    {
        string pending=Path.Combine(directory,matchId+".wfr");
        string acknowledged=Path.Combine(directory,matchId+".ack");
        if(File.Exists(pending) && File.Exists(acknowledged))
            throw new InvalidDataException("Duplicate terminal authority.");
        string? existing=File.Exists(pending)?pending:File.Exists(acknowledged)?acknowledged:null;
        return existing==null?null:ReadFile(existing);
    }
    public IReadOnlyList<Evidence> PendingPage(int count=16)
    {
        if(count<1 || (count>16 && count!=10000))throw new ArgumentOutOfRangeException(nameof(count));
        lock(gate)
            return Directory.EnumerateFiles(directory,"*.wfr").Order(StringComparer.Ordinal)
                .Take(count).Select(f=>new Evidence(ReadFile(f),Digest(File.ReadAllBytes(f)))).ToArray();
    }
    public string Acknowledge(string matchId,string digest)
    {
        if(!Regex.IsMatch(matchId,@"\A[a-zA-Z0-9_-]{1,64}\z") ||
           !Regex.IsMatch(digest,@"\A[0-9a-f]{64}\z"))
            throw new ArgumentException("Invalid terminal acknowledgement identity.");
        lock(gate)
        {
            string pending=Path.Combine(directory,matchId+".wfr");
            string acknowledged=Path.Combine(directory,matchId+".ack");
            if(File.Exists(acknowledged))
            {
                if(File.Exists(pending))throw new InvalidDataException("Duplicate terminal authority.");
                ReadFile(acknowledged);
                return Digest(File.ReadAllBytes(acknowledged))==digest?"already-acknowledged":"digest-mismatch";
            }
            if(!File.Exists(pending))return "missing";
            ReadFile(pending);
            if(Digest(File.ReadAllBytes(pending))!=digest)return "digest-mismatch";
            File.SetLastWriteTimeUtc(pending,DateTime.UtcNow);
            File.Move(pending,acknowledged);
            return "acknowledged";
        }
    }
    public async Task<int> ForwardPendingAsync(BackendResultForwarder forwarder, Uri endpoint,
        int count = 16, CancellationToken cancellationToken = default)
    {
        if (forwarder == null) throw new ArgumentNullException(nameof(forwarder));
        if (count < 1 || count > 16) throw new ArgumentOutOfRangeException(nameof(count));
        var page = PendingPage(count);
        int acknowledged = 0;
        foreach (var evidence in page)
        {
            cancellationToken.ThrowIfCancellationRequested();
            string code = await forwarder.AcceptAsync(endpoint, evidence.Snapshot.MatchId, evidence.Digest,
                evidence.Snapshot.ToByteArray(), cancellationToken);
            if (code is "accepted" or "already-accepted")
            {
                string result = Acknowledge(evidence.Snapshot.MatchId, evidence.Digest);
                if (result is "acknowledged" or "already-acknowledged") acknowledged++;
            }
        }
        return acknowledged;
    }
    public int PruneAcknowledged(DateTimeOffset now)
    {
        if(now< DateTimeOffset.UnixEpoch || now> DateTimeOffset.MaxValue-AcknowledgementRetention)
            throw new ArgumentOutOfRangeException(nameof(now));
        lock(gate)
        {
            var files=Directory.EnumerateFiles(directory,"*.ack").Take(10001).ToArray();
            if(files.Length>10000)throw new InvalidDataException("Terminal acknowledgement capacity exceeded.");
            var expired=new List<string>();
            foreach(var file in files)
            {
                ReadFile(file);
                var written=new DateTimeOffset(File.GetLastWriteTimeUtc(file),TimeSpan.Zero);
                if(written>now)throw new InvalidDataException("Terminal acknowledgement timestamp is in the future.");
                if(written+AcknowledgementRetention<=now)expired.Add(file);
            }
            foreach(var file in expired)File.Delete(file);
            return expired.Count;
        }
    }
    private static string Digest(byte[] record)
        =>Convert.ToHexString(record.AsSpan(record.Length-32,32)).ToLowerInvariant();
    public static MatchSnapshot ValidatePayload(byte[] payload,string matchId,string digest)
    {
        if(payload is not {Length:>0 and <=65536} ||
           !Regex.IsMatch(matchId??"",@"\A[a-zA-Z0-9_-]{1,64}\z") ||
           !Regex.IsMatch(digest??"",@"\A[0-9a-f]{64}\z"))
            throw new InvalidDataException("Invalid terminal result envelope.");
        if(War.Shared.TerminalResultDigest.Compute(payload)!=digest)
            throw new InvalidDataException("Terminal result digest mismatch.");
        MatchSnapshot snapshot;
        try {snapshot=MatchSnapshot.Parser.ParseFrom(payload);}
        catch(InvalidProtocolBufferException e){throw new InvalidDataException("Invalid terminal result protobuf.",e);}
        if(!snapshot.ToByteArray().AsSpan().SequenceEqual(payload) || snapshot.MatchId!=matchId)
            throw new InvalidDataException("Terminal result identity or canonical bytes differ.");
        Validate(snapshot);
        return snapshot;
    }
    public bool Publish(MatchSnapshot snapshot)
    {
        lock(gate)return PublishLocked(snapshot);
    }
    private bool PublishLocked(MatchSnapshot snapshot)
    {
        Validate(snapshot);
        byte[] payload=snapshot.ToByteArray();
        if(payload.Length>65536)throw new InvalidDataException("Terminal evidence too large.");
        byte[] record=new byte[Magic.Length+4+payload.Length+32];
        Magic.CopyTo(record,0);
        System.Buffers.Binary.BinaryPrimitives.WriteInt32LittleEndian(record.AsSpan(4,4),payload.Length);
        payload.CopyTo(record,8);
        SHA256.HashData(record.AsSpan(0,8+payload.Length),record.AsSpan(8+payload.Length,32));
        string target=Path.Combine(directory,snapshot.MatchId+".wfr");
        string acknowledged=Path.Combine(directory,snapshot.MatchId+".ack");
        if(File.Exists(acknowledged))
        {
            if(!File.ReadAllBytes(acknowledged).AsSpan().SequenceEqual(record))
                throw new InvalidDataException("Conflicting acknowledged terminal evidence.");
            return false;
        }
        if(File.Exists(target))
        {
            if(!File.ReadAllBytes(target).AsSpan().SequenceEqual(record))
                throw new InvalidDataException("Conflicting terminal evidence for match ID.");
            return false;
        }
        if(Directory.EnumerateFiles(directory).Count(f=>Path.GetExtension(f) is ".wfr" or ".ack")>=10000)
            throw new InvalidDataException("Terminal outbox capacity exceeded.");
        string temp=Path.Combine(directory,snapshot.MatchId+"."+Guid.NewGuid().ToString("N")+".tmp");
        try
        {
            using(var stream=new FileStream(temp,FileMode.CreateNew,FileAccess.Write,FileShare.None,
                4096,FileOptions.WriteThrough))
            {stream.Write(record);stream.Flush(true);}
            File.Move(temp,target);
            return true;
        }
        catch(IOException) when(File.Exists(target))
        {
            if(!File.ReadAllBytes(target).AsSpan().SequenceEqual(record))
                throw new InvalidDataException("Conflicting terminal evidence for match ID.");
            return false;
        }
        finally {if(File.Exists(temp))File.Delete(temp);}
    }
    private static MatchSnapshot ReadFile(string path)
    {
        byte[] record=File.ReadAllBytes(path);
        if(record.Length<40 || !record.AsSpan(0,4).SequenceEqual(Magic))
            throw new InvalidDataException("Invalid terminal evidence header.");
        int length=System.Buffers.Binary.BinaryPrimitives.ReadInt32LittleEndian(record.AsSpan(4,4));
        if(length<1 || length>65536 || record.Length!=8+length+32 ||
            !CryptographicOperations.FixedTimeEquals(
                SHA256.HashData(record.AsSpan(0,8+length)),record.AsSpan(8+length,32)))
            throw new InvalidDataException("Invalid terminal evidence length or checksum.");
        MatchSnapshot snapshot;
        try {snapshot=MatchSnapshot.Parser.ParseFrom(record,8,length);}
        catch(InvalidProtocolBufferException e){throw new InvalidDataException("Invalid terminal evidence payload.",e);}
        if(!snapshot.ToByteArray().AsSpan().SequenceEqual(record.AsSpan(8,length)))
            throw new InvalidDataException("Noncanonical terminal evidence payload.");
        Validate(snapshot);
        string stem=Path.GetExtension(path)==".tmp"
            ?Path.GetFileName(path).Split('.')[0]
            :Path.GetFileNameWithoutExtension(path);
        if(stem!=snapshot.MatchId)
            throw new InvalidDataException("Terminal evidence filename does not match its identity.");
        return snapshot;
    }
    private static void Validate(MatchSnapshot snapshot)
    {
        foreach(var player in snapshot.Players)
            BattleStatisticsValidator.Validate(new BattleStatistics(
                player.ConfirmedPlayerHits,player.ConfirmedPlayerKills,
                player.ConfirmedArmySpawns,player.ConfirmedArmyLosses));
        bool completedReason=snapshot.TerminalReason is "forfeit" or "opponent-disconnected" or "player-killed";
        bool abortedReason=snapshot.TerminalReason is "cancelled-before-start" or "host-shutdown" or "host-crash" or
            "admission-timeout" or "prestart-disconnect" or "both-disconnected" or "duration-limit" or
            "simultaneous-barrel-death" or "invalid-shield-authority" or "invalid-combat-authority" or
            "invalid-projectile-authority" or "invalid-barrel-authority" or "invalid-army-authority" or
            "army-event-backpressure" or "overtime-event-backpressure";
        if(!Regex.IsMatch(snapshot.MatchId,@"\A[a-zA-Z0-9_-]{1,64}\z") ||
           !Regex.IsMatch(snapshot.ManifestHash,@"\A[0-9a-f]{64}\z") ||
           snapshot.Phase is not (BattlePhase.Ended or BattlePhase.Aborted) ||
           snapshot.RewardEligible || snapshot.TerminalReason.Length is <1 or >64 ||
           snapshot.ServerTick>10000000 || snapshot.EndTick!=snapshot.ServerTick ||
           snapshot.StartTick>10000000 ||
           (snapshot.StartTick!=0 && snapshot.EndTick>=snapshot.StartTick
               ? snapshot.PerformanceStartTick<snapshot.StartTick ||
                 snapshot.PerformanceStartTick>snapshot.EndTick ||
                 snapshot.PerformanceDurationTicks!=snapshot.EndTick-snapshot.PerformanceStartTick
               : snapshot.PerformanceStartTick!=0 || snapshot.PerformanceDurationTicks!=0) ||
           (snapshot.Phase==BattlePhase.Ended && (!completedReason || snapshot.WinnerPlayerId.Length==0)) ||
           (snapshot.Phase==BattlePhase.Aborted && (!abortedReason || snapshot.WinnerPlayerId.Length!=0)) ||
           snapshot.Players.Count!=2 || snapshot.Players[0].PlayerId==snapshot.Players[1].PlayerId ||
           snapshot.Players.Any(p=>p.ConfirmedArmyLosses>p.ConfirmedArmySpawns ||
               p.ConfirmedPlayerHits>p.ConfirmedEnemyHits ||
               p.ConfirmedCardsPlayed>4096 ||
               p.ConfirmedEnemyHits>1_000_000) ||
           snapshot.Players.Any(p=>!Guid.TryParseExact(p.PlayerId,"N",out _)) ||
           snapshot.PauseHostTick!=0 || snapshot.Players.Any(p=>!ValidTerminalPlayer(p,snapshot.ServerTick)) ||
           !ValidTerminalShields(snapshot.Shields) ||
           (snapshot.Phase==BattlePhase.Aborted && snapshot.WinnerPlayerId.Length!=0) ||
           (snapshot.WinnerPlayerId.Length!=0 && snapshot.Players.All(p=>p.PlayerId!=snapshot.WinnerPlayerId)) ||
           (snapshot.Phase==BattlePhase.Ended && snapshot.TerminalReason=="player-killed" &&
               (snapshot.Players.Single(p=>p.PlayerId==snapshot.WinnerPlayerId).Dead ||
                !snapshot.Players.Single(p=>p.PlayerId!=snapshot.WinnerPlayerId).Dead)) ||
           (snapshot.Phase==BattlePhase.Ended && snapshot.TerminalReason is ("forfeit" or "opponent-disconnected") &&
               snapshot.Players.Any(p=>p.Dead)))
            throw new InvalidDataException("Invalid unscored terminal evidence.");
        ulong hits=0,kills=0,spawns=0,losses=0;
        foreach(var player in snapshot.Players)
        {
            hits+=player.ConfirmedPlayerHits;kills+=player.ConfirmedPlayerKills;
            spawns+=player.ConfirmedArmySpawns;losses+=player.ConfirmedArmyLosses;
        }
        if(snapshot.Players.Aggregate(0UL,(sum,player)=>sum+player.ConfirmedCardsPlayed)!=snapshot.CardActivations)
            throw new InvalidDataException("Terminal card ownership does not conserve activations.");
        if(snapshot.CardUsage.Count>WarCardEffectCatalog.All.Count*2)
            throw new InvalidDataException("Terminal card usage exceeds its source catalog.");
        var usageByOwner=snapshot.Players.ToDictionary(p=>p.PlayerId,_=>0UL,StringComparer.Ordinal);
        string previousOwner="",previousCard="",previousSource="";
        ulong usageTotal=0;
        foreach(var usage in snapshot.CardUsage)
        {
            bool validSource;
            try {validSource=WarCardSourceIdentityCatalog.Resolve(usage.CardId,usage.SourceCardId)==usage.SourceCardId;}
            catch(InvalidDataException){validSource=false;}
            if(!usageByOwner.ContainsKey(usage.OwnerPlayerId) || !validSource ||
               !WarCardEffectCatalog.TryGet(usage.CardId,out _) || usage.Count is <1 or >4096 ||
               (previousOwner.Length!=0 && (string.CompareOrdinal(usage.OwnerPlayerId,previousOwner)<0 ||
                   (usage.OwnerPlayerId==previousOwner &&
                    (string.CompareOrdinal(usage.CardId,previousCard)<0 ||
                     (usage.CardId==previousCard &&
                      string.CompareOrdinal(usage.SourceCardId,previousSource)<=0))))))
                throw new InvalidDataException("Invalid terminal card usage row.");
            usageByOwner[usage.OwnerPlayerId]+=usage.Count;
            usageTotal+=usage.Count;
            previousOwner=usage.OwnerPlayerId;previousCard=usage.CardId;previousSource=usage.SourceCardId;
        }
        if(usageTotal!=snapshot.CardActivations ||
           snapshot.Players.Any(p=>usageByOwner[p.PlayerId]!=p.ConfirmedCardsPlayed))
            throw new InvalidDataException("Terminal card usage does not conserve player credits.");
        if(hits>uint.MaxValue || kills>uint.MaxValue || spawns>uint.MaxValue || losses>uint.MaxValue ||
           snapshot.CardActivations>int.MaxValue || snapshot.ObjectiveCredits>int.MaxValue)
            throw new InvalidDataException("Terminal performance counters exceed their durable contract.");
        CompleteBattleEvidenceValidator.Validate(new CompleteBattleEvidence(snapshot.MatchId,snapshot.ManifestHash,
            new BattleStatistics((uint)hits,(uint)kills,(uint)spawns,(uint)losses),
            snapshot.PerformanceDurationTicks,snapshot.RibbonIds.ToArray(),
            (int)snapshot.CardActivations,(int)snapshot.ObjectiveCredits));
    }

    private static bool ValidTerminalPlayer(BattlePlayerState p,ulong serverTick)
    {
        if(p.Ready && !p.Admitted || p.Reconnecting || p.ReconnectDeadlineHostTick!=0 ||
            p.ClipAmmo<0 || p.ReserveAmmo<0 || p.CoverIndex is <-1 or >1000 ||
           !float.IsFinite(p.PositionX) || !float.IsFinite(p.PositionY) || !float.IsFinite(p.PositionZ) ||
           p.LastCommandId>100000 || p.ConfirmedPlayerKills>p.ConfirmedPlayerHits ||
           p.RiflePose!=null && !RiflePoseProjection.ValidWire(p.RiflePose,serverTick) ||
           p.LastGeometryHit.Length!=0 && !Regex.IsMatch(p.LastGeometryHit,@"\A[0-9a-f]{64}\z"))
             return false;
        if(!p.CombatEnabled)
            return p.Health==0 && p.MaxHealth==0 && !p.Dead && p.DamageRevision==0;
        return float.IsFinite(p.Health) && float.IsFinite(p.MaxHealth) &&
            p.MaxHealth is >0 and <=100000000 && p.Health<=p.MaxHealth &&
            p.Dead==(p.Health<=0);
    }

    private static bool ValidTerminalShields(Google.Protobuf.Collections.RepeatedField<BattleShieldState> shields)
    {
        if(shields.Count==0)return true;
        if(shields.Count!=8 || shields.Select(s=>s.CoverIndex).Distinct().Count()!=8 ||
           shields.Count(s=>s.OwnerFraction==1)!=4 || shields.Count(s=>s.OwnerFraction==2)!=4)
            return false;
        return shields.All(s=>s.CoverIndex is >=0 and <=1000 &&
            float.IsFinite(s.Health) && float.IsFinite(s.MaxHealth) &&
            s.MaxHealth is >0 and <=10000000 && s.Health>=0 && s.Health<=s.MaxHealth &&
            s.Destroyed==(s.Health==0));
    }
}
