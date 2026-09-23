using System.Buffers.Binary;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;
using War.Protocol;

namespace War.BattleServer;

/// <summary>Crash marker for a runtime allocation; it is not a gameplay checkpoint.</summary>
public sealed class ActiveMatchJournal
{
    private static readonly byte[] Magic="WFA1"u8.ToArray();
    private readonly string directory;
    private sealed record Allocation(string MatchId,string ManifestHash,string[] PlayerIds);

    public ActiveMatchJournal(string path)
    {
        directory=Path.GetFullPath(path);
        Directory.CreateDirectory(directory);
        foreach(var temp in Directory.EnumerateFiles(directory,"*.tmp"))
        {
            // A grant is never returned before the final rename. Preserve a bad
            // temporary for operator inspection; a complete one needs no replay.
            Read(temp);
            File.Delete(temp);
        }
        var files=Directory.EnumerateFiles(directory,"*.active").Take(33).ToArray();
        if(files.Length>32)throw new InvalidDataException("Active match journal capacity exceeded.");
        foreach(var file in files)Read(file);
    }

    internal IReadOnlySet<string> ActiveMatchIds()=>Directory.EnumerateFiles(directory,"*.active")
        .Take(33).Select(file=>Read(file).MatchId).ToHashSet(StringComparer.Ordinal);

    public void Begin(MatchManifest manifest,string manifestHash)
    {
        MatchManifest.Validate(manifest);
        if(manifestHash!=manifest.Digest())
            throw new InvalidDataException("Active allocation manifest digest mismatch.");
        var allocation=new Allocation(manifest.MatchId,manifestHash,
            manifest.Players.Select(p=>p.PlayerId).ToArray());
        Validate(allocation);
        string target=Path.Combine(directory,allocation.MatchId+".active");
        byte[] record=Encode(allocation);
        if(File.Exists(target))
        {
            if(!File.ReadAllBytes(target).AsSpan().SequenceEqual(record))
                throw new InvalidDataException("Conflicting active match allocation.");
            return;
        }
        if(Directory.EnumerateFiles(directory,"*.active").Take(33).Count()>=32)
            throw new InvalidDataException("Active match journal capacity exceeded.");
        string temp=Path.Combine(directory,allocation.MatchId+"."+Guid.NewGuid().ToString("N")+".tmp");
        try
        {
            using(var stream=new FileStream(temp,FileMode.CreateNew,FileAccess.Write,FileShare.None,
                4096,FileOptions.WriteThrough))
            {stream.Write(record);stream.Flush(true);}
            File.Move(temp,target);
        }
        finally {if(File.Exists(temp))File.Delete(temp);}
    }

    public int Recover(TerminalOutbox outbox,Func<string,bool>? currentlyAllocated=null)
    {
        var rows=Directory.EnumerateFiles(directory,"*.active").Order(StringComparer.Ordinal)
            .Select(file=>(File:file,Allocation:Read(file))).ToArray();
        if(rows.Length>32 || rows.Any(row=>currentlyAllocated?.Invoke(row.Allocation.MatchId)==true))
            throw new InvalidDataException("Recovered runtime allocation conflicts with current host roster.");
        bool[] existing=rows.Select(row=>outbox.Contains(row.Allocation.MatchId,
            row.Allocation.ManifestHash,row.Allocation.PlayerIds)).ToArray();
        int recovered=0;
        for(int i=0;i<rows.Length;i++)
        {
            var (file,allocation)=rows[i];
            if(!existing[i])
            {
                var snapshot=new MatchSnapshot {MatchId=allocation.MatchId,
                    ManifestHash=allocation.ManifestHash,Phase=BattlePhase.Aborted,
                    TerminalReason="host-crash",RewardEligible=false};
                snapshot.Players.AddRange(allocation.PlayerIds.Select(id=>new BattlePlayerState {PlayerId=id}));
                outbox.Publish(snapshot);
                recovered++;
            }
            File.Delete(file);
        }
        return recovered;
    }

    public void Complete(string matchId)
    {
        if(!ValidId(matchId))throw new ArgumentException("Invalid match identity.",nameof(matchId));
        string path=Path.Combine(directory,matchId+".active");
        if(File.Exists(path))File.Delete(path);
    }

    private static bool ValidId(string? value)
        =>value!=null && Regex.IsMatch(value,@"\A[a-zA-Z0-9_-]{1,64}\z");
    private static void Validate(Allocation allocation)
    {
        if(!ValidId(allocation.MatchId) || allocation.ManifestHash==null ||
           !Regex.IsMatch(allocation.ManifestHash,@"\A[0-9a-f]{64}\z") ||
           allocation.PlayerIds is not {Length:2} ||
           allocation.PlayerIds.Any(id=>!Guid.TryParseExact(id,"N",out _) || id!=id.ToLowerInvariant()) ||
           allocation.PlayerIds[0]==allocation.PlayerIds[1])
            throw new InvalidDataException("Invalid active match journal record.");
    }
    private static byte[] Encode(Allocation allocation)
    {
        byte[] payload=JsonSerializer.SerializeToUtf8Bytes(allocation);
        if(payload.Length is <1 or >1024)throw new InvalidDataException("Active match journal record too large.");
        byte[] record=new byte[8+payload.Length+32];
        Magic.CopyTo(record,0);
        BinaryPrimitives.WriteInt32LittleEndian(record.AsSpan(4,4),payload.Length);
        payload.CopyTo(record,8);
        SHA256.HashData(record.AsSpan(0,8+payload.Length),record.AsSpan(8+payload.Length,32));
        return record;
    }
    private static Allocation Read(string path)
    {
        string name=Path.GetFileName(path);
        string stem=Path.GetExtension(path)==".tmp"?name.Split('.')[0]:Path.GetFileNameWithoutExtension(path);
        if(!ValidId(stem) || !Regex.IsMatch(name,
            @"\A[a-zA-Z0-9_-]{1,64}(\.[0-9a-f]{32}\.tmp|\.active)\z"))
            throw new InvalidDataException("Invalid active match journal filename.");
        byte[] record=File.ReadAllBytes(path);
        if(record.Length<41 || !record.AsSpan(0,4).SequenceEqual(Magic))
            throw new InvalidDataException("Invalid active match journal header.");
        int length=BinaryPrimitives.ReadInt32LittleEndian(record.AsSpan(4,4));
        if(length is <1 or >1024 || record.Length!=8+length+32 ||
           !CryptographicOperations.FixedTimeEquals(SHA256.HashData(record.AsSpan(0,8+length)),
               record.AsSpan(8+length,32)))
            throw new InvalidDataException("Invalid active match journal checksum.");
        Allocation allocation;
        try {allocation=JsonSerializer.Deserialize<Allocation>(record.AsSpan(8,length))!;}
        catch(JsonException e){throw new InvalidDataException("Invalid active match journal payload.",e);}
        if(allocation==null)throw new InvalidDataException("Empty active match journal payload.");
        Validate(allocation);
        if(allocation.MatchId!=stem)throw new InvalidDataException("Active match journal identity mismatch.");
        return allocation;
    }
}
