using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.Infrastructure;

internal static class BattleMatchControlClientTests
{
    private sealed class Handler(Func<HttpRequestMessage,HttpResponseMessage> send):HttpMessageHandler
    {protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken ct)=>Task.FromResult(send(request));}
    public static async Task<int> Run()
    {
        int checks=0;byte[] key=Enumerable.Repeat((byte)7,32).ToArray();
        string matchId="allocator-match",hash=new string('a',64);
        string[] players={Guid.NewGuid().ToString("N"),Guid.NewGuid().ToString("N")};
        byte[] manifest=Encoding.UTF8.GetBytes("{\"matchId\":\"allocator-match\"}");
        object Grant(string player,ulong session,long expiry=2000)=>new {host="127.0.0.1",port=30000,ticket=new string('t',10),
            sessionKey=Convert.ToBase64String(new byte[32]),sessionId=session,matchId,playerId=player,manifestHash=hash,expiresUnixSeconds=expiry};
        HttpResponseMessage Response(IEnumerable<string> order)=>new(HttpStatusCode.Created)
        {Content=new StringContent(JsonSerializer.Serialize(new {code="registered",matchId,manifestHash=hash,
            grants=order.Select((p,i)=>Grant(p,(ulong)i+1)).ToArray()}),Encoding.UTF8,"application/json")};
        var handler=new Handler(request=>
        {
            byte[] body=request.Content!.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            string time=request.Headers.GetValues("X-War-Control-Time").Single();
            byte[] prefix=Encoding.UTF8.GetBytes("war/match/control/v1/"+time+"\n");
            byte[] signed=new byte[prefix.Length+body.Length];prefix.CopyTo(signed,0);body.CopyTo(signed,prefix.Length);
            string expected=Convert.ToHexString(HMACSHA256.HashData(key,signed));
            if(request.Headers.GetValues("X-War-Control-Mac").Single()!=expected)throw new Exception("control HMAC");
            if(!body.AsSpan().SequenceEqual(manifest))throw new Exception("manifest bytes changed");
            checks+=2;return Response(players);
        });
        var client=new BattleMatchControlClient(new HttpClient(handler),key);
        var result=await client.RegisterAsync(new Uri("http://127.0.0.1:30001/internal/matches"),manifest,matchId,players,CancellationToken.None);
        if(result.Code!="registered" || !result.Grants.Select(x=>x.PlayerId).SequenceEqual(players))throw new Exception("valid registration response");
        checks++;
        var reversed=new BattleMatchControlClient(new HttpClient(new Handler(_=>Response(players.Reverse()))),key);
        try {await reversed.RegisterAsync(new Uri("http://127.0.0.1:30001/internal/matches"),manifest,matchId,players,CancellationToken.None);throw new Exception("reordered grants accepted");}
        catch(InvalidDataException){checks++;}
        string requestId=Guid.NewGuid().ToString("N");
        var reconnect=new BattleMatchControlClient(new HttpClient(new Handler(request=>
        {
            byte[] body=request.Content!.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            using var document=JsonDocument.Parse(body);
            var root=document.RootElement;
            if(root.GetProperty("matchId").GetString()!=matchId ||
               root.GetProperty("playerId").GetString()!=players[0] ||
               root.GetProperty("requestId").GetString()!=requestId)
                throw new Exception("Reconnect request identity changed.");
            string time=request.Headers.GetValues("X-War-Control-Time").Single();
            byte[] prefix=Encoding.UTF8.GetBytes("war/match/control/v1/"+time+"\n");
            byte[] signed=new byte[prefix.Length+body.Length];
            prefix.CopyTo(signed,0);
            body.CopyTo(signed,prefix.Length);
            string expected=Convert.ToHexString(HMACSHA256.HashData(key,signed));
            if(request.Headers.GetValues("X-War-Control-Mac").Single()!=expected)
                throw new Exception("Reconnect request was not signed over its exact body.");
            checks+=2;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {Content=new StringContent(JsonSerializer.Serialize(new
                {code="reconnect-issued",grant=Grant(players[0],42,DateTimeOffset.UtcNow.ToUnixTimeSeconds()+120)}),Encoding.UTF8,"application/json")};
        })),key);
        var restored=await reconnect.ReconnectAsync(
            new Uri("http://127.0.0.1:30001/internal/matches/reconnect"),
            matchId,players[0],requestId,CancellationToken.None);
        if(restored.PlayerId!=players[0] || restored.SessionId!=42)
            throw new Exception("Trusted reconnect grant was not returned.");
        checks++;
        try
        {
            await reconnect.ReconnectAsync(new Uri("http://127.0.0.1:30001/internal/matches/reconnect"),
                matchId,players[1],"BAD",CancellationToken.None);
            throw new Exception("Malformed reconnect request reached the Worker.");
        }
        catch(InvalidDataException){checks++;}
        var mismatched=new BattleMatchControlClient(new HttpClient(new Handler(_=>new HttpResponseMessage(HttpStatusCode.OK)
        {Content=new StringContent(JsonSerializer.Serialize(new
            {code="reconnect-issued",grant=Grant(players[1],43,DateTimeOffset.UtcNow.ToUnixTimeSeconds()+120)}),Encoding.UTF8,"application/json")})),key);
        try
        {
            await mismatched.ReconnectAsync(new Uri("http://127.0.0.1:30001/internal/matches/reconnect"),
                matchId,players[0],requestId,CancellationToken.None);
            throw new Exception("Another player's reconnect grant was accepted.");
        }
        catch(InvalidDataException){checks++;}
        return checks;
    }
}
