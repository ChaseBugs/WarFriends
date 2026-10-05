using System.Security.Cryptography;
using Google.Protobuf;
using War.Protocol;

namespace War.BattleServer;

// Per-session frozen reply bytes. A mutation acknowledgement is never exposed
// until the complete original snapshot has been authenticated and verified.
internal sealed class MatchReplyTransfer
{
    internal const int MaximumBytes=262144;
    internal const int ChunkBytes=900;
    internal const ulong LifetimeHostTicks=1800;
    private readonly byte[] bytes;
    internal ulong Id { get; }
    internal ulong CreatedHostTick { get; }
    internal uint Size => checked((uint)bytes.Length);
    internal ByteString Digest { get; }
    internal uint ChunkCount => checked((uint)((bytes.Length+ChunkBytes-1)/ChunkBytes));

    internal MatchReplyTransfer(ulong id,ulong hostTick,MatchReply reply)
    {
        if(id==0||reply.Snapshot==null||reply.TransferId!=0)
            throw new InvalidDataException("Invalid match reply transfer source.");
        bytes=reply.ToByteArray();
        if(bytes.Length is <1 or >MaximumBytes)
            throw new InvalidDataException("Match reply transfer exceeds its bounded size.");
        Id=id;CreatedHostTick=hostTick;
        Digest=ByteString.CopyFrom(SHA256.HashData(bytes));
    }

    internal MatchReply Stub(MatchReply original) => new()
    {CommandId=original.CommandId,Code=original.Code,TransferId=Id,
     TransferSize=Size,TransferSha256=Digest};

    internal MatchReplyChunkBatch Page(uint index)
    {
        if(index>=ChunkCount)
            return new MatchReplyChunkBatch {TransferId=Id,Code="invalid-index"};
        int start=checked((int)index*ChunkBytes);
        int length=Math.Min(ChunkBytes,bytes.Length-start);
        return new MatchReplyChunkBatch
        {TransferId=Id,Index=index,ChunkCount=ChunkCount,TotalSize=Size,
         Data=ByteString.CopyFrom(bytes,start,length),Code="chunk"};
    }
}
