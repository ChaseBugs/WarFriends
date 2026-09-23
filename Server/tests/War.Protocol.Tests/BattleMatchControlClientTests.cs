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
        object Grant(string player,ulong session)=>new {host="127.0.0.1",port=30000,ticket=new string('t',10),
            sessionKey=Convert.ToBase64String(new byte[32]),sessionId=session,matchId,playerId=player,manifestHash=hash,expiresUnixSeconds=2000};
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
        return checks;
    }
}
