using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
using Google.Protobuf;
using War.Protocol;
using War.Protocol.Transport;

namespace War.Client
{
    public sealed partial class MatchConnection
    {
        private const int MaximumReplyTransferBytes=262144;
        private const int ReplyChunkBytes=900;

        private MatchReply ResolveReplyTransfer(MatchReply stub,CancellationToken ct)
        {
            if(stub.Snapshot!=null||stub.TransferSize<1||stub.TransferSize>MaximumReplyTransferBytes||
               stub.TransferSha256.Length!=32)
                throw new InvalidOperationException("Battle host returned an invalid reply transfer stub.");
            int count=checked(((int)stub.TransferSize+ReplyChunkBytes-1)/ReplyChunkBytes);
            byte[] assembled=new byte[stub.TransferSize];
            for(uint index=0;index<count;index++)
            {
                var page=ExchangeReplyChunk(stub.TransferId,index,checked((uint)count),
                    stub.TransferSize,ct);
                int offset=checked((int)index*ReplyChunkBytes);
                int expected=Math.Min(ReplyChunkBytes,assembled.Length-offset);
                if(page.Data.Length!=expected)
                    throw new InvalidOperationException("Battle host returned an incomplete reply chunk.");
                page.Data.CopyTo(assembled,offset);
            }
            return VerifyReplyTransfer(stub,assembled);
        }

        internal static MatchReply VerifyReplyTransfer(MatchReply stub,byte[] assembled)
        {
            if(stub==null||assembled==null||stub.TransferId==0||
               stub.TransferSize!=assembled.Length||stub.TransferSha256.Length!=32)
                throw new InvalidOperationException("Battle host reply transfer length is invalid.");
            byte[] digest;
            using(var sha=SHA256.Create())digest=sha.ComputeHash(assembled);
            var expectedDigest=stub.TransferSha256.ToByteArray();
            int difference=0;
            for(int i=0;i<digest.Length;i++)difference|=digest[i]^expectedDigest[i];
            if(difference!=0)throw new InvalidOperationException("Battle host reply transfer digest changed.");
            MatchReply complete;
            try {complete=MatchReply.Parser.ParseFrom(assembled);}
            catch(Google.Protobuf.InvalidProtocolBufferException e)
            {throw new InvalidOperationException("Battle host reply transfer is malformed.",e);}
            if(complete.ToByteArray().Length!=assembled.Length||complete.TransferId!=0||
               complete.Snapshot==null||complete.CommandId!=stub.CommandId||complete.Code!=stub.Code)
                throw new InvalidOperationException("Battle host reply transfer changed acknowledgement authority.");
            return complete;
        }

        private MatchReplyChunkBatch ExchangeReplyChunk(ulong transferId,uint index,uint count,
            uint totalSize,CancellationToken ct)
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
                        Sequence=checked(++sequence),MatchReplyChunkPoll=new MatchReplyChunkPoll
                        {TransferId=transferId,Index=index}};
                    socket.Send(PacketCodec.Encode(request,key));
                    nextSend=watch.ElapsedMilliseconds+150;
                }
                if(!socket.Poll(10000,SelectMode.SelectRead))continue;
                int size;
                try {size=socket.Receive(buffer);}
                catch(SocketException e) when(e.SocketErrorCode==SocketError.MessageSize||
                    e.SocketErrorCode==SocketError.ConnectionReset){continue;}
                if(size>PacketCodec.MaximumDatagramBytes)continue;
                byte[] bytes=new byte[size];Array.Copy(buffer,bytes,size);
                if(!PacketCodec.Authenticate(bytes,key))continue;
                Packet response=PacketCodec.ReadUntrusted(bytes);
                if(response==null||response.SessionId!=grant.SessionId||
                   response.Ack<firstSequence||response.Ack>sequence||
                   response.MatchReplyChunkBatch==null||!replay.Accept(response.Sequence))continue;
                var page=response.MatchReplyChunkBatch;
                if(page.TransferId!=transferId)
                    throw new InvalidOperationException("Battle host reply chunk identity changed.");
                if(page.Code=="expired")
                    throw new TimeoutException("Battle host reply transfer expired. Retry the pending command.");
                if(page.Code!="chunk"||page.Index!=index||page.ChunkCount!=count||
                   page.TotalSize!=totalSize||page.Data.Length>ReplyChunkBytes)
                    throw new InvalidOperationException("Battle host returned invalid reply chunk authority.");
                return page.Clone();
            }
            throw new TimeoutException("Battle host did not acknowledge reply chunk. Retry the pending command.");
        }
    }
}
