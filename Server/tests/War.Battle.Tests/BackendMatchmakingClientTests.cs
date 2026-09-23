using System.Net;
using Google.Protobuf;
using War.Client;
using War.Protocol;

internal static class BackendMatchmakingClientTests
{
    private sealed class Handler(Func<HttpRequestMessage,HttpResponseMessage> send):HttpMessageHandler
    {protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken ct)=>Task.FromResult(send(request));}
    public static async Task<int> Run()
    {
        int checks=0,calls=0;string match="m"+new string('a',32);
        string one=Guid.NewGuid().ToString("N"),two=Guid.NewGuid().ToString("N");
        HttpResponseMessage Proto(IMessage value)=>new(HttpStatusCode.OK)
            {Content=new ByteArrayContent(value.ToByteArray()){Headers={ContentType=new("application/x-protobuf")}}};
        var handler=new Handler(request=>
        {
            if(request.Headers.Authorization?.Scheme!="Bearer" || request.Headers.Authorization.Parameter!="token")throw new Exception("matchmaking auth");
            calls++;
            if(calls==1)return Proto(new MatchQueueReply{Code="waiting"});
            if(calls==2){var paired=new MatchQueueReply{Code="paired",MatchId=match};paired.PlayerIds.Add(one);paired.PlayerIds.Add(two);return Proto(paired);}
            if(calls==3 && request.RequestUri!.AbsolutePath.EndsWith("/v1/battle/grant",StringComparison.Ordinal))
            {
                var grant=new MatchConnectionGrant{Host="127.0.0.1",Port=30000,Ticket=new string('t',10),SessionKey=ByteString.CopyFrom(new byte[32]),
                    SessionId=1,MatchId=match,PlayerId=one,ManifestHash=new string('b',64),ExpiresUnixSeconds=2000};
                grant.PlayerViews.Add(View(one,"One",1));grant.PlayerViews.Add(View(two,"Two",2));return Proto(grant);
            }
            throw new Exception("unexpected matchmaking request");
        });
        using var backend=new BackendClient(new Uri("http://127.0.0.1:8080/"),handler,true);
        var grant=await backend.FindMatchAsync("token",TimeSpan.FromSeconds(5),CancellationToken.None);
        if(grant.MatchId!=match || grant.PlayerId!=one || calls!=3)throw new Exception("matchmaking grant flow");
        checks++;
        var malformed=grant.Clone();malformed.PlayerViews[0].VisualIds.Clear();
        try {BattlePlayerViewProjection.Validate(malformed);throw new Exception("malformed battle view accepted");}
        catch(InvalidDataException){checks++;}
        return checks;
    }
    private static BattlePlayerView View(string id,string name,int fraction)
    {
        var view=new BattlePlayerView{PlayerId=id,DisplayName=name,Level=1,ArmyPower=1,LeagueId="1-local",Country="US",Fraction=fraction,DefendPosition=1};
        view.VisualIds.Add(new[]{"v0","v1","v2","v3"});
        view.Weapons.Add(new BattleWeaponView{Slot=0,WeaponIndex=0,SourceId="Google2u.AssaultRifle_AK47",UpgradeIndex=0});
        return view;
    }
}
