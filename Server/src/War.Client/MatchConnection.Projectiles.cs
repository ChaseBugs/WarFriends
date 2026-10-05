using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using War.Protocol;
using War.Protocol.Transport;

namespace War.Client
{
    public sealed partial class MatchConnection
    {
        public async Task<MatchProjectileBatch> PollProjectilesAsync(ulong scanId,
            ulong afterProjectileId,CancellationToken ct)
        {
            await gate.WaitAsync(ct).ConfigureAwait(false);
            try
            {
                if(disposed)throw new ObjectDisposedException(nameof(MatchConnection));
                if(!admitted)throw new InvalidOperationException("Connect before polling projectiles.");
                if(scanId==0)
                    throw new ArgumentException("Projectile scans need a nonzero request identity.");
                return await Task.Run(()=>ExchangeProjectiles(scanId,afterProjectileId,ct),ct)
                    .ConfigureAwait(false);
            }
            finally {gate.Release();}
        }

        public async Task<MatchProjectileBatch> FetchProjectilesAsync(CancellationToken ct)
        {
            for(int attempt=0;attempt<3;attempt++)
            {
                MatchProjectileBatch result=null;
                ulong scanId=BitConverter.ToUInt64(Guid.NewGuid().ToByteArray(),0),cursor=0;
                if(scanId==0)scanId=1;
                var rows=new List<BattleProjectileState>();
                while(true)
                {
                    var page=await PollProjectilesAsync(scanId,cursor,ct).ConfigureAwait(false);
                    if(page.Code=="scan-expired")break;
                    if(page.Code!="projectiles")
                        throw new InvalidOperationException("Projectile scan cursor rejected: "+page.Code);
                    if(result==null)
                    {
                        result=page.Clone();result.Projectiles.Clear();result.HasMore=false;
                    }
                    else if(page.ScanId!=scanId||page.SnapshotTick!=result.SnapshotTick||
                            page.ActiveCount!=result.ActiveCount)
                        throw new InvalidOperationException("Projectile scan authority changed between pages.");
                    rows.AddRange(page.Projectiles.Select(x=>x.Clone()));
                    if(rows.Count>128)throw new InvalidOperationException("Projectile scan exceeded host cap.");
                    if(!page.HasMore)
                    {
                        if(rows.Count!=result.ActiveCount)
                            throw new InvalidOperationException("Incomplete projectile scan.");
                        result.Projectiles.AddRange(rows);
                        return result;
                    }
                    cursor=page.Projectiles[page.Projectiles.Count-1].ProjectileId;
                }
            }
            throw new InvalidOperationException("Projectile scan expired during three attempts.");
        }

        private MatchProjectileBatch ExchangeProjectiles(ulong scanId,ulong after,CancellationToken ct)
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
                        Sequence=checked(++sequence),MatchProjectilePoll=new MatchProjectilePoll
                        {ScanId=scanId,AfterProjectileId=after}};
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
                if(response==null||response.SessionId!=grant.SessionId||response.Ack<firstSequence||
                   response.Ack>sequence||response.MatchProjectileBatch==null||
                   !replay.Accept(response.Sequence))continue;
                var batch=response.MatchProjectileBatch;
                if(batch.MatchId!=grant.MatchId||batch.ManifestHash!=grant.ManifestHash||
                   batch.Code!="projectiles"&&batch.Code!="scan-expired"&&batch.Code!="invalid-cursor"||
                   batch.ActiveCount>128||batch.SnapshotTick>10000000||
                   batch.Projectiles.Count>128||
                   batch.Code=="projectiles"&&
                       (batch.ScanId==0||scanId!=0&&batch.ScanId!=scanId||
                        batch.Projectiles.Count>batch.ActiveCount||
                        batch.HasMore&&batch.Projectiles.Count==0)||
                   batch.Code!="projectiles"&&
                       (batch.ScanId!=0||batch.ActiveCount!=0||batch.HasMore||batch.Projectiles.Count!=0))
                    throw new InvalidOperationException("Battle host returned invalid projectile scan authority.");
                ulong prior=after;
                foreach(var row in batch.Projectiles)
                {
                    if(row.ProjectileId<=prior||!Guid.TryParseExact(row.OwnerPlayerId,"N",out _)||
                       row.OwnerPlayerId!=row.OwnerPlayerId.ToLowerInvariant()||
                       row.Kind!="grenade"&&row.Kind!="grenade-molotov"&&
                       row.Kind!="heavy-turret-bullet"&&row.Kind!="helicopter-bullet"&&
                       row.Kind!="helicopter-fake-bullet"&&row.Kind!="drone-bullet"&&
                       row.Kind!="drone-fake-bullet"||
                       !FiniteCoordinate(row.X)||!FiniteCoordinate(row.Y)||!FiniteCoordinate(row.Z)||
                       !FiniteCoordinate(row.VelocityX)||!FiniteCoordinate(row.VelocityY)||
                       !FiniteCoordinate(row.VelocityZ))
                        throw new InvalidOperationException("Battle host returned invalid projectile row.");
                    prior=row.ProjectileId;
                }
                return batch.Clone();
            }
            throw new TimeoutException("Battle host did not acknowledge projectile scan. Retry the read.");
        }
    }
}
