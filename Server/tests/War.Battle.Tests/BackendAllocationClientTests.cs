using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;
using War.Shared;

internal static class BackendAllocationClientTests
{
    private sealed class Handler(Func<HttpRequestMessage,HttpResponseMessage> send) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken cancellationToken)
            =>Task.FromResult(send(request));
    }

    public static async Task<int> Run()
    {
        int checks=0;
        byte[] key=Enumerable.Range(1,32).Select(x=>(byte)x).ToArray();
        string[] ids={new string('a',32),new string('b',32)};
        BattleAllocationProjection Row(string id)=>new(id,["ID_CARD-TEST"],[],[0],[-1],[-1]);
        var endpoint=new Uri("https://backend.invalid/internal/battle/allocations/read");
        var handler=new Handler(request=>
        {
            byte[] body=request.Content!.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            string time=request.Headers.GetValues("X-War-Control-Time").Single();
            string mac=request.Headers.GetValues("X-War-Control-Mac").Single();
            byte[] prefix=Encoding.UTF8.GetBytes("war/allocation/read/v1/"+time+"\n");
            byte[] signed=new byte[prefix.Length+body.Length];prefix.CopyTo(signed,0);body.CopyTo(signed,prefix.Length);
            if(!CryptographicOperations.FixedTimeEquals(Convert.FromHexString(mac),HMACSHA256.HashData(key,signed)))
                throw new Exception("allocation request HMAC");
            using var json=JsonDocument.Parse(body);
            if(json.RootElement.GetProperty("serverId").GetString()!="test-host" ||
               !json.RootElement.GetProperty("playerIds").EnumerateArray().Select(x=>x.GetString()).SequenceEqual(ids))
                throw new Exception("allocation request identity");
            checks+=2;
            return new HttpResponseMessage(HttpStatusCode.OK)
                {Content=new ByteArrayContent(JsonSerializer.SerializeToUtf8Bytes(ids.Select(Row).ToArray()))};
        });
        var client=new BackendAllocationClient(new HttpClient(handler),key,"test-host");
        var values=await client.ReadAsync(endpoint,ids,CancellationToken.None);
        if(values.Length!=2 || !values.Select(x=>x.PlayerId).SequenceEqual(ids))throw new Exception("allocation response order");
        checks++;

        var reversed=new BackendAllocationClient(new HttpClient(new Handler(_=>new HttpResponseMessage(HttpStatusCode.OK)
            {Content=new ByteArrayContent(JsonSerializer.SerializeToUtf8Bytes(ids.Reverse().Select(Row).ToArray()))})),key,"test-host");
        try {await reversed.ReadAsync(endpoint,ids,CancellationToken.None);throw new Exception("reordered allocation accepted");}
        catch(InvalidDataException){checks++;}

        var missing=new BackendAllocationClient(new HttpClient(new Handler(_=>new HttpResponseMessage(HttpStatusCode.OK)
            {Content=new ByteArrayContent(JsonSerializer.SerializeToUtf8Bytes(new[]{Row(ids[0])}))})),key,"test-host");
        try {await missing.ReadAsync(endpoint,ids,CancellationToken.None);throw new Exception("incomplete allocation accepted");}
        catch(InvalidDataException){checks++;}
        return checks;
    }
}
