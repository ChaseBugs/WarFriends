using System.Security.Cryptography;
using Google.Protobuf;
using War.BattleServer;
using War.Client;
using War.Protocol;
using War.Protocol.Transport;

internal static class MatchReplyTransferTests
{
    internal static int Run()
    {
        int checks=0;
        void Check(bool okay,string name)
        {if(!okay)throw new Exception(name);checks++;}
        var source=new MatchReply{CommandId=7,Code="shot-accepted",
            Snapshot=new MatchSnapshot{MatchId="large-reply",ManifestHash=new string('a',64)}};
        source.Snapshot.Players.Add(new BattlePlayerState{PlayerId=new string('a',32)});
        source.Snapshot.Players.Add(new BattlePlayerState{PlayerId=new string('b',32)});
        for(int i=0;i<128;i++)
            source.Snapshot.RibbonIds.Add("R"+i.ToString("D3")+new string('x',55));
        var transfer=new MatchReplyTransfer(71,100,source);
        var stub=transfer.Stub(source);
        Check(transfer.Size>PacketCodec.MaximumDatagramBytes&&transfer.ChunkCount>1&&
              stub.Snapshot==null&&stub.TransferId==71&&stub.TransferSize==transfer.Size&&
              stub.TransferSha256.Length==32,
              "oversized immutable reply becomes a digest-bound compact acknowledgement");
        byte[] key=RandomNumberGenerator.GetBytes(32);
        var parts=new List<byte>();
        for(uint i=0;i<transfer.ChunkCount;i++)
        {
            var page=transfer.Page(i);
            var packet=new Packet{Version=1,SessionId=9401,Sequence=i+1,Ack=i+1,
                MatchReplyChunkBatch=page};
            byte[] encoded=PacketCodec.Encode(packet,key);
            Check(encoded.Length<=PacketCodec.MaximumDatagramBytes&&
                  PacketCodec.Authenticate(encoded,key)&&page.TransferId==71&&
                  page.Index==i&&page.ChunkCount==transfer.ChunkCount&&
                  page.TotalSize==transfer.Size&&page.Code=="chunk",
                  "authenticated reply chunk fits its UDP datagram");
            parts.AddRange(page.Data);
        }
        var restored=MatchConnection.VerifyReplyTransfer(stub,parts.ToArray());
        Check(restored.ToByteArray().SequenceEqual(source.ToByteArray())&&
              restored.Snapshot.RibbonIds.Count==128,
              "portable SDK verifies and reconstructs the exact original reply");
        var forged=parts.ToArray();forged[forged.Length-1]^=1;
        bool rejected=false;
        try {MatchConnection.VerifyReplyTransfer(stub,forged);}
        catch(InvalidOperationException){rejected=true;}
        Check(rejected,"digest mismatch cannot publish forged reply state");
        var wrongCommand=stub.Clone();wrongCommand.CommandId++;
        rejected=false;
        try {MatchConnection.VerifyReplyTransfer(wrongCommand,parts.ToArray());}
        catch(InvalidOperationException){rejected=true;}
        Check(rejected,"reassembled reply cannot change the acknowledged command identity");
        var beyondCap=source.Clone();beyondCap.Snapshot.TerminalReason=new string('z',
            MatchReplyTransfer.MaximumBytes);
        rejected=false;
        try {new MatchReplyTransfer(72,100,beyondCap);}
        catch(InvalidDataException){rejected=true;}
        Check(rejected,"transfer cache rejects oversized state before allocation");
        Check(transfer.Page(transfer.ChunkCount).Code=="invalid-index",
              "out-of-range chunk cursor returns a bounded rejection");
        return checks;
    }
}
