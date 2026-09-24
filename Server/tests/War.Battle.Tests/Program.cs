using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Nodes;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using War.BattleServer;
using War.Backend;
using War.Backend.Legacy;
using War.Client;
using War.Infrastructure;
using War.Protocol;
using War.Protocol.Transport;
using War.Shared;
using War.Persistence;

if(args is ["--client-matchmaking-only"])
{
    int focused=await BackendMatchmakingClientTests.Run();
    Console.WriteLine($"PASS: {focused} focused portable matchmaking assertion");
    return;
}

if(args is ["--flame-only"])
{
    int focused=ArmyFlameBurstTests.Run();
    Console.WriteLine($"PASS: {focused} focused army flamethrower assertions");
    return;
}

if(args is ["--rusher-only"])
{
    var root=new DirectoryInfo(AppContext.BaseDirectory);
    while(root!=null&&!File.Exists(Path.Combine(root.FullName,"content/combat-content-manifest.json")))root=root.Parent;
    if(root==null)throw new Exception("Recovered battle content artifact not found.");
    int focused=await LiveRusherUdpTests.Run(Path.Combine(root.FullName,"content"));
    Console.WriteLine($"PASS: {focused} focused live Rusher UDP assertions");
    return;
}

if(args is ["--unity-rifle-only",var unityExecutable,var unityProject])
{
    var root=new DirectoryInfo(AppContext.BaseDirectory);
    while(root!=null && !File.Exists(Path.Combine(root.FullName,"content/combat-content-manifest.json")))root=root.Parent;
    if(root==null)throw new Exception("Recovered battle content artifact not found.");
    await LiveRifleTests.RunUnity(Path.Combine(root.FullName,"content"),unityExecutable,unityProject);
    return;
}

if(args is ["--unity-smg-only",var smgUnityExecutable,var smgUnityProject])
{
    var root=new DirectoryInfo(AppContext.BaseDirectory);
    while(root!=null && !File.Exists(Path.Combine(root.FullName,"content/smg-content-manifest.json")))root=root.Parent;
    if(root==null)throw new Exception("Recovered SMG content artifact not found.");
    await LiveSmgTests.RunUnity(Path.Combine(root.FullName,"content"),smgUnityExecutable,smgUnityProject);
    return;
}

if(args is ["--smg-only"])
{
    var root=new DirectoryInfo(AppContext.BaseDirectory);
    while(root!=null && !File.Exists(Path.Combine(root.FullName,"content/smg-content-manifest.json")))root=root.Parent;
    if(root==null)throw new Exception("Recovered SMG content artifact not found.");
    int focused=SmgCatalogTests.Run(Path.Combine(root.FullName,"content"));
    focused+=SmgBurstTests.Run(Path.Combine(root.FullName,"content"));
    focused+=LiveSmgTests.Run(Path.Combine(root.FullName,"content"));
    focused+=await LiveSmgTests.RunUdp(Path.Combine(root.FullName,"content"));
    Console.WriteLine($"PASS: {focused} focused SMG source/burst assertions");
    return;
}

if(args is ["--pistol-only"])
{
    var root=new DirectoryInfo(AppContext.BaseDirectory);
    while(root!=null&&!File.Exists(Path.Combine(root.FullName,"content/pistol-content-manifest.json")))root=root.Parent;
    if(root==null)throw new Exception("Recovered pistol content artifact not found.");
    int focused=PistolCatalogTests.Run(Path.Combine(root.FullName,"content"));
    Console.WriteLine($"PASS: {focused} focused pistol assertions");return;
}

if(args is ["--lmg-only"])
{
    var root=new DirectoryInfo(AppContext.BaseDirectory);
    while(root!=null&&!File.Exists(Path.Combine(root.FullName,"content/lmg-content-manifest.json")))root=root.Parent;
    if(root==null)throw new Exception("Recovered LMG content artifact not found.");
    int focused=LmgCatalogTests.Run(Path.Combine(root.FullName,"content"));
    focused+=MinigunCatalogTests.Run(Path.Combine(root.FullName,"content"));
    focused+=await MinigunCatalogTests.RunUdp(Path.Combine(root.FullName,"content"));
    Console.WriteLine($"PASS: {focused} focused LMG assertions");return;
}

if(args is ["--sniper-only"])
{
    var root=new DirectoryInfo(AppContext.BaseDirectory);
    while(root!=null&&!File.Exists(Path.Combine(root.FullName,"content/sniper-content-manifest.json")))root=root.Parent;
    if(root==null)throw new Exception("Recovered sniper content artifact not found.");
    int focused=SniperCatalogTests.Run(Path.Combine(root.FullName,"content"));
    focused+=await SniperCatalogTests.RunUdp(Path.Combine(root.FullName,"content"));
    Console.WriteLine($"PASS: {focused} focused sniper assertions");return;
}

if(args is ["--bazooka-only"])
{
    var root=new DirectoryInfo(AppContext.BaseDirectory);
    while(root!=null&&!File.Exists(Path.Combine(root.FullName,"content/bazooka-content-manifest.json")))root=root.Parent;
    if(root==null)throw new Exception("Recovered bazooka content artifact not found.");
    int focused=BazookaCatalogTests.Run(Path.Combine(root.FullName,"content"));
    focused+=await BazookaCatalogTests.RunUdp(Path.Combine(root.FullName,"content"));
    Console.WriteLine($"PASS: {focused} focused bazooka assertions");return;
}

if(args is ["--grenade-only"])
{
    var root=new DirectoryInfo(AppContext.BaseDirectory);
    while(root!=null&&!File.Exists(Path.Combine(root.FullName,"content/grenade-content-manifest.json")))root=root.Parent;
    if(root==null)throw new Exception("Recovered grenade content artifact not found.");
    int focused=GrenadeCatalogTests.Run(Path.Combine(root.FullName,"content"));
    focused+=await GrenadeCatalogTests.RunUdp(Path.Combine(root.FullName,"content"));
    Console.WriteLine($"PASS: {focused} focused grenade assertions");return;
}

if(args is ["--write-grenade-render-fixture",var grenadeRenderOutput])
{
    var root=new DirectoryInfo(AppContext.BaseDirectory);
    while(root!=null&&!File.Exists(Path.Combine(root.FullName,"content/grenade-content-manifest.json")))root=root.Parent;
    if(root==null)throw new Exception("Recovered grenade content artifact not found.");
    GrenadeCatalogTests.WriteRenderFixture(Path.Combine(root.FullName,"content"),grenadeRenderOutput);return;
}

if(args is ["--write-rifle-template",var outputPath])
{
    var root=new DirectoryInfo(AppContext.BaseDirectory);
    while(root!=null && !File.Exists(Path.Combine(root.FullName,"content/combat-content-manifest.json")))root=root.Parent;
    if(root==null)throw new Exception("Recovered battle content artifact not found.");
    var content=BattleCombatContent.Load(Path.Combine(root.FullName,"content/combat-content-manifest.json"));
    var map=content.Maps.Single(m=>m.Source.Contains("City_Multiplayer",StringComparison.Ordinal));
    var covers=new[]{map.Covers.First(c=>c.Main&&c.Fraction==1),map.Covers.First(c=>c.Main&&c.Fraction==2)};
    var weapon=content.Stats.CreateManifest("Google2u.AssaultRifle_AK47",0);
    string[] ids={new string('a',32),new string('b',32)};
    var template=MatchManifest.Validate(new MatchManifest("m"+new string('0',32),"local-1",
        Path.GetFileNameWithoutExtension(map.Source),map.SourceHash,content.Revision,MatchManifest.RifleCombatMode,10,60,120,
        [new(ids[0],weapon,1,covers[0].SourceIndex,1,new(1000),0),new(ids[1],weapon,2,covers[1].SourceIndex,1,new(1000),0)]));
    content.ValidateAllocation(template);
    Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outputPath))!);
    await File.WriteAllTextAsync(outputPath,JsonSerializer.Serialize(template));
    Console.WriteLine("PASS: wrote source-validated local rifle match template");
    return;
}

if(args is ["--combat-content-only"])
{
    var root=new DirectoryInfo(AppContext.BaseDirectory);
    while(root!=null && !File.Exists(Path.Combine(root.FullName,
        "content/recovered-battle-content.json")))root=root.Parent;
    if(root==null)throw new Exception("Recovered battle content artifact not found.");
    int focused=CombatContentTests.Run(Path.Combine(root.FullName,"content"));
    Console.WriteLine($"PASS: {focused} focused combat content assertions");
    return;
}

int checks = 0;
checks += await BackendAllocationClientTests.Run();
void Check(bool ok, string name) { if (!ok) throw new Exception(name); checks++; }
void Reject(Action f, string name)
{
    try { f(); } catch (Exception e) when (e is InvalidDataException or ArgumentException) { checks++; return; }
    throw new Exception(name);
}
var signingBoundaryKey=Enumerable.Repeat((byte)1,32).ToArray();
var controlBoundaryKey=Enumerable.Repeat((byte)2,32).ToArray();
var frozenControlKey=BattleControlKeyPolicy.ValidateAndCopy(controlBoundaryKey,signingBoundaryKey);
controlBoundaryKey[0]=9;
Check(frozenControlKey[0]==2,"control-plane key is defensively copied");
Reject(()=>BattleControlKeyPolicy.ValidateAndCopy(new byte[31],signingBoundaryKey),"short control-plane key rejected");
Reject(()=>BattleControlKeyPolicy.ValidateAndCopy(new byte[32],new byte[31]),"short UDP signing key rejected at control boundary");
Reject(()=>BattleControlKeyPolicy.ValidateAndCopy(signingBoundaryKey,signingBoundaryKey),"control and UDP signing key reuse rejected");
string a = new string('a', 32), b = new string('b', 32);
string hash = new string('a', 64);
// Synthetic small weapon for boundary tests, NOT recovered catalog content.
var definition = new MatchManifest("test-match", "test-host", "fixture-map", hash, hash,
    MatchManifest.PrototypeMode, 10, 60, 10,
    [new(a, new("fixture-rifle", 2, 3, 0.1, 0.2)), new(b, new("fixture-rifle", 2, 3, 0.1, 0.2))]);
var lifecycleGrant = new MatchConnectionGrant
{
    Host = "127.0.0.1", Port = 1, SessionId = 1, MatchId = "test-match",
    PlayerId = Guid.NewGuid().ToString("N"), ManifestHash = hash,
    SessionKey = ByteString.CopyFrom(new byte[32]), Ticket = new string('t', 10),
    ExpiresUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60
};
using (var lifecycle = new SelfHostedRoomLifecycle(new MatchConnection(lifecycleGrant)))
{
    int transitions = 0;
    lifecycle.PhaseChanged += _ => transitions++;
    lifecycle.Observe(new MatchSnapshot { Phase = BattlePhase.Waiting });
    lifecycle.Observe(new MatchSnapshot { Phase = BattlePhase.Waiting });
    Check(transitions == 1 && lifecycle.Phase == SelfHostedRoomPhase.Loading, "lifecycle suppresses duplicate phase callbacks");
}
var rematch = new RematchRequestState();
Check(rematch.Request("test-match", lifecycleGrant.PlayerId, "r1", false) == "not-terminal", "rematch rejects live match");
Check(rematch.Request("test-match", lifecycleGrant.PlayerId, "r1", true) == "fresh-allocation-required" &&
      rematch.Request("test-match", lifecycleGrant.PlayerId, "r1", true) == "fresh-allocation-required" && rematch.Count == 1,
      "rematch request is idempotent");
var cards = new BattleCardSelectionState();
var cardCatalog = new HashSet<string>(new[] { "card-a", "card-b" }, StringComparer.Ordinal);
Check(cards.Submit(lifecycleGrant.PlayerId, "c1", new[] { "card-a" }, cardCatalog).Single() == "card-a" &&
      cards.Submit(lifecycleGrant.PlayerId, "c1", new[] { "card-a" }, cardCatalog).Single() == "card-a",
      "card selection is idempotent");
Reject(() => cards.Submit(lifecycleGrant.PlayerId, "c1", new[] { "card-b" }, cardCatalog), "card selection retry conflict");
var buddies = new BattleBuddySelectionState(new[]
{
    (lifecycleGrant.PlayerId, (IEnumerable<string>)new[] { "buddy-1", "buddy-2" })
});
Check(buddies.Submit(lifecycleGrant.PlayerId, new[] { "buddy-1" }).Single() == "buddy-1" &&
      buddies.Submit(lifecycleGrant.PlayerId, new[] { "buddy-1" }).Single() == "buddy-1",
      "buddy selection is idempotent");
Reject(() => buddies.Submit(lifecycleGrant.PlayerId, new[] { "buddy-2" }), "buddy selection retry conflict");
Reject(() => buddies.Submit(lifecycleGrant.PlayerId, new[] { "not-owned" }), "buddy selection rejects unowned identity");
var trustedProjection = BattleAllocationProjection.Validate(new BattleAllocationProjection(
    lifecycleGrant.PlayerId, new[] { "card-a" }, new[] { "buddy-1" }, new[] { 0 }, Array.Empty<int>(), Array.Empty<int>()));
Check(trustedProjection.CardIds.Single() == "card-a" && trustedProjection.BuddyCardIds.Single() == "buddy-1",
    "backend allocation projection freezes trusted loadout");
var manifestWithAllocation = definition with { Allocations = new[]
{
    new BattleAllocationProjection(a, new[] { "card-a" }, Array.Empty<string>(), Array.Empty<int>(), Array.Empty<int>(), Array.Empty<int>()),
    new BattleAllocationProjection(b, new[] { "card-a" }, Array.Empty<string>(), Array.Empty<int>(), Array.Empty<int>(), Array.Empty<int>())
} };
var manifestRoundTrip = MatchManifest.Parse(JsonSerializer.SerializeToUtf8Bytes(manifestWithAllocation));
Check(manifestRoundTrip.Allocations != null && manifestRoundTrip.Allocations.Length == 2 &&
      manifestRoundTrip.Allocations[0].CardIds.Single() == "card-a", "allocation manifest round-trip");
BattlePlayerPresentation Presentation(string id,string name) => BattlePlayerPresentation.Validate(new BattlePlayerPresentation(
    id,name,1,100,10,5,1,"1-local","US",false,
    new[]{"CAMO_DEFAULT","HELMET_DEFAULT","HEAD_DEFAULT","BANDS_DEFAULT"},
    new[]{new BattleWeaponPresentation(0,0,"Google2u.AssaultRifle_AK47",0)},
    new[]{new BattleUnitPresentation("Google2u.DBUpgradeSlotsRifleman",0,-1,-1,0)}));
var manifestWithPresentation=manifestWithAllocation with { Presentations=new[]{Presentation(a,"Alpha"),Presentation(b,"Bravo")} };
var presentationRoundTrip=MatchManifest.Parse(JsonSerializer.SerializeToUtf8Bytes(manifestWithPresentation));
Check(presentationRoundTrip.Presentations!=null && presentationRoundTrip.Presentations.Length==2 &&
      presentationRoundTrip.Presentations[1].DisplayName=="Bravo" && presentationRoundTrip.Presentations[0].VisualIds.Count==4,
      "player presentation manifest round-trip");
Reject(()=>BattlePlayerPresentation.Validate(new BattlePlayerPresentation(a,"Alpha",1,100,10,5,1,"1-local","US",false,
    new[]{"only-one"},new[]{new BattleWeaponPresentation(0,0,"Google2u.AssaultRifle_AK47",0)},Array.Empty<BattleUnitPresentation>())),
    "player presentation rejects incomplete visuals");
Reject(()=>BattlePlayerPresentation.Validate(new BattlePlayerPresentation(a,"Alpha",1,100,10,5,1,"1-local","US",false,
    new[]{"v0","v1","v2","v3"},new[]{new BattleWeaponPresentation(2,1,"Google2u.AssaultRifle_Famas",0),
        new BattleWeaponPresentation(0,0,"Google2u.AssaultRifle_AK47",0)},Array.Empty<BattleUnitPresentation>())),
    "player presentation rejects noncanonical weapon slot order");
Reject(()=>MatchManifest.Validate(manifestWithAllocation with {Presentations=new[]{Presentation(a,"Alpha"),Presentation(a,"Duplicate")} }),
    "manifest rejects duplicate presentation players");
var durablePresentationPlayer=new LegacyPlayerDocument
{
    Id=a,Name="Alpha",Level=1,ArmyPower=100,Skill=10,MedalsBalance=5,BeginnersLeague=1,LeagueId="1-local",Country="US",
    Serialized=new Dictionary<string,string>
    {
        ["DecalManagerData"]=PlayerState.Write(new DecalManagerData {Slots=Enumerable.Range(0,4).ToDictionary(i=>i,i=>new SavedPlayerVisualSlot{EquippedId="visual-"+i})}),
        ["InventoryData"]=PlayerState.Write(new InventoryData
        {
            Slots=new Dictionary<int,SerializedSlotDetail>
            {
                {0,new SerializedSlotDetail{Name="Google2u.AssaultRifle_AK47",WeaponIndex=0}}
            }
        }),
        ["LevelManagerData"]=PlayerState.Write(new LevelManagerData
        {
            SavedWeapons=new Dictionary<string,SavedWeaponSlots>{{"Google2u.AssaultRifle_AK47",new SavedWeaponSlots{Bought=true,BoughtIndex=2}}},
            SavedArmies=new Dictionary<string,SavedArmySlots>{{"Google2u.DBUpgradeSlotsRifleman",new SavedArmySlots{Bought=true,Equipped=true,BoughtIndex=3,SpecialSlot=-1,EliteSlot=-1,Tier=1}}}
        })
    }
};
var durablePresentation=BattlePlayerPresentationSource.Project(durablePresentationPlayer);
Check(durablePresentation.Weapons.Single().UpgradeIndex==2 && durablePresentation.Units.Single().UpgradeIndex==3 &&
      durablePresentation.VisualIds[3]=="visual-3","durable legacy state projects complete battle presentation");
durablePresentationPlayer.Serialized.Remove("DecalManagerData");
Reject(()=>BattlePlayerPresentationSource.Project(durablePresentationPlayer),"missing durable presentation blob fails closed");
Reject(() => BattleAllocationProjection.Validate(new BattleAllocationProjection(
    lifecycleGrant.PlayerId, new[] { "card-a", "card-a" }, Array.Empty<string>(), Array.Empty<int>(), Array.Empty<int>(), Array.Empty<int>())),
    "backend allocation projection rejects duplicate cards");
var cardMatch = new MatchEngine(definition);
cardMatch.ConfigureBattleAllocations(new[]
{
    new BattleAllocationProjection(a, new[] { "card-a" }, Array.Empty<string>(), Array.Empty<int>(), Array.Empty<int>(), Array.Empty<int>()),
    new BattleAllocationProjection(b, new[] { "card-a" }, Array.Empty<string>(), Array.Empty<int>(), Array.Empty<int>(), Array.Empty<int>())
});
Check(cardMatch.Admit(a) && cardMatch.Admit(b), "card match admission");
var selectCards = new MatchCommand { CommandId = 1, SelectCards = new SelectCardsCommand() };
selectCards.SelectCards.CardIds.Add("card-a");
Check(cardMatch.Command(a, selectCards).Code == "cards-selected", "wire card selection accepted");
var badCards = new MatchCommand { CommandId = 1, SelectCards = new SelectCardsCommand() };
badCards.SelectCards.CardIds.Add("unknown-card");
Check(cardMatch.Command(b, badCards).Code == "invalid-card-selection", "wire card selection rejects unknown");
var emptyCardMatch=new MatchEngine(definition);
emptyCardMatch.ConfigureBattleAllocations(new[]
{
    new BattleAllocationProjection(a,Array.Empty<string>(),Array.Empty<string>(),Array.Empty<int>(),Array.Empty<int>(),Array.Empty<int>()),
    new BattleAllocationProjection(b,Array.Empty<string>(),Array.Empty<string>(),Array.Empty<int>(),Array.Empty<int>(),Array.Empty<int>())
});
Check(emptyCardMatch.Admit(a)&&emptyCardMatch.Admit(b),"empty-card match admission");
Check(emptyCardMatch.Command(a,new MatchCommand{CommandId=1,SelectCards=new SelectCardsCommand()}).Code=="cards-selected" &&
      emptyCardMatch.Snapshot().Players.Single(x=>x.PlayerId==a).CardsSelected,
      "explicit empty card selection retains completion authority");
MatchCommand Ready(ulong id, string digest) => new() { CommandId = id, Ready = new ReadyCommand { ManifestHash = digest } };
checks += PlayerDamageTests.Run(definition);
checks += PlayerAimTests.Run();
checks += BulletFlightTests.Run(definition);
checks += VolleyMatchTests.Run(definition);
checks += BattleEventTests.Run();
checks += ShotgunPlannerTests.Run();
checks += ShotgunOverlapTests.Run();
MatchCommand Fire(ulong id) => new() { CommandId = id, Fire = new FireCommand { TargetX = 1, TargetY = 2, TargetZ = 3 } };
MatchCommand Poll() => new() { Poll = new PollMatch() };
var match = new MatchEngine(definition);
Check(match.Command(a, Fire(1)).Code == "not-admitted", "no pre-admission command");
Check(!match.Admit(new string('c', 32)), "outsider admission");
Check(match.Admit(a) && match.Admit(b), "roster admission");
Check(match.Command(a, Ready(1, hash)).Code == "manifest-mismatch", "wrong content rejected");
Check(match.Command(a, Ready(2, match.ManifestHash)).Code == "ready", "first ready");
Check(match.Command(a, Fire(3)).Code == "not-running", "no early fire");
Check(match.Command(b, Ready(1, match.ManifestHash)).Snapshot.Phase == BattlePhase.Countdown, "two-player ready gate");
match.Advance(59);
Check(match.Command(a, Fire(4)).Code == "not-running", "source two-second start barrier");
match.Advance(60);
var shot = match.Command(a, Fire(5));
Check(shot.Code == "shot-accepted" && shot.Snapshot.Players[0].ClipAmmo == 1, "one shot debit");
match.Advance(61);
Check(match.Command(a, Fire(5)).Equals(shot), "lost reply exact replay");
var altered = Fire(5); altered.Fire.TargetX = 2;
Check(match.Command(a, altered).Code == "command-conflict", "same id different payload");
Check(match.Command(a, Fire(7)).Code == "command-order", "skip command sequence");
Check(match.Command(a, Fire(6)).Code == "cooldown", "server cadence");
match.Advance(63);
var empty = match.Command(a, Fire(7));
Check(empty.Snapshot.Players[0].ClipAmmo == 0 && empty.Snapshot.Players[0].ReloadEndTick == 69, "empty clip auto-reload");
Check(match.Command(a, Fire(8)).Code == "reloading", "no fire during reload");
match.Advance(68);
Check(match.Snapshot().Players[0].ClipAmmo == 0, "reload incomplete");
match.Advance(69);
Check(match.Snapshot().Players[0].ClipAmmo == 2 && match.Snapshot().Players[0].ReserveAmmo == 1, "source min transfer conserving ammo");
var nan = Fire(9); nan.Fire.TargetY = float.NaN;
Check(match.Command(a, nan).Code == "invalid-target" && match.Snapshot().Players[0].ClipAmmo == 2, "NaN target consumes no ammo");
var terminal = match.Command(b, new MatchCommand { CommandId = 2, Forfeit = new ForfeitCommand() });
Check(terminal.Snapshot.WinnerPlayerId == a && terminal.Snapshot.TerminalReason == "forfeit" && !terminal.Snapshot.RewardEligible, "unscored forfeit");
Check((byte)ClientGameEndReason.Killed==1 && (byte)ClientGameEndReason.Win==2 &&
      (byte)ClientGameEndReason.WinByForfeit==3 && (byte)ClientGameEndReason.Forfeit==5 &&
      MatchOutcomeProjection.ForPlayer(terminal.Snapshot,a)==ClientGameEndReason.WinByForfeit &&
      MatchOutcomeProjection.ForPlayer(terminal.Snapshot,b)==ClientGameEndReason.Forfeit,
      "portable SDK projects recovered per-player forfeit reason bytes");
var lethalOutcome=terminal.Snapshot.Clone();lethalOutcome.TerminalReason="player-killed";
lethalOutcome.Players.Single(p=>p.PlayerId==b).Dead=true;
Check(MatchOutcomeProjection.ForPlayer(lethalOutcome,a)==ClientGameEndReason.Win &&
      MatchOutcomeProjection.ForPlayer(lethalOutcome,b)==ClientGameEndReason.Killed,
      "portable SDK projects recovered per-player lethal reason bytes");
lethalOutcome.Players.Single(p=>p.PlayerId==b).Dead=false;
Reject(()=>MatchOutcomeProjection.ForPlayer(lethalOutcome,a),
      "lethal presentation refuses a terminal without a dead losing player");
Check(match.Command(a, Fire(10)).Code == "match-terminal", "no terminal mutation");
Check(match.Command(b, new MatchCommand { CommandId = 2, Forfeit = new ForfeitCommand() }).Equals(terminal), "terminal receipt replay");
Reject(() => match.Advance(68), "backwards clock");
var alternateWeapon=new WeaponManifest("fixture-rifle-two",3,4,.1,.3);
ParticipantManifest WithSlots(ParticipantManifest player)=>player with
{
    WeaponSlots=[new WeaponSlotManifest(0,0,player.Weapon,0),new WeaponSlotManifest(2,1,alternateWeapon,1)]
};
var slottedDefinition=definition with {Players=[WithSlots(definition.Players[0]),WithSlots(definition.Players[1])]};
var slotMatch=new MatchEngine(slottedDefinition);
Check(slotMatch.Admit(a)&&slotMatch.Admit(b),"multi-weapon match admission");
slotMatch.Command(a,Ready(1,slotMatch.ManifestHash));slotMatch.Command(b,Ready(1,slotMatch.ManifestHash));slotMatch.Advance(60);
Check(slotMatch.Command(a,Fire(2)).Code=="shot-accepted","active first slot fires");
var switched=slotMatch.Command(a,new MatchCommand {CommandId=3,SwitchWeapon=new SwitchWeaponCommand {Slot=2}});
Check(switched.Code=="weapon-selected" && switched.Snapshot.Players[0].ActiveWeaponSlot==2 &&
      switched.Snapshot.Players[0].ClipAmmo==3,
      "authoritative switch selects ordered second-slot state");
slotMatch.Advance(63);
Check(slotMatch.Command(a,Fire(4)).Code=="shot-accepted" && slotMatch.Snapshot().Players[0].ClipAmmo==2,
      "second slot owns independent ammunition");
Check(slotMatch.Command(a,new MatchCommand {CommandId=5,Reload=new ReloadCommand()}).Code=="reloading",
      "second-slot reload starts independently");
var firstAgain=slotMatch.Command(a,new MatchCommand {CommandId=6,SwitchWeapon=new SwitchWeaponCommand {Slot=0}});
Check(firstAgain.Snapshot.Players[0].ClipAmmo==1 && firstAgain.Snapshot.Players[0].ReloadEndTick==0,
      "switch restores first-slot ammunition and cooldown state");
slotMatch.Advance(72);
var secondAgain=slotMatch.Command(a,new MatchCommand {CommandId=7,SwitchWeapon=new SwitchWeaponCommand {Slot=2}});
Check(secondAgain.Snapshot.Players[0].ClipAmmo==3 && secondAgain.Snapshot.Players[0].ReserveAmmo==3 &&
      secondAgain.Snapshot.Players[0].ActiveWeaponSlot==2,
      "inactive slot reload completes without changing first slot");
Check(slotMatch.Command(a,new MatchCommand {CommandId=8,SwitchWeapon=new SwitchWeaponCommand {Slot=1}}).Code=="weapon-slot-unavailable",
      "unknown weapon slot rejected");
Reject(()=>new MatchEngine(slottedDefinition with {Players=[slottedDefinition.Players[0] with
    {WeaponSlots=[new WeaponSlotManifest(0,0,definition.Players[0].Weapon,0),new WeaponSlotManifest(0,1,alternateWeapon,1)]},
    slottedDefinition.Players[1]]}),"duplicate weapon slot rejected");
Reject(()=>new MatchEngine(slottedDefinition with {Players=[slottedDefinition.Players[0] with
    {WeaponSlots=[new WeaponSlotManifest(0,1,definition.Players[0].Weapon,0),new WeaponSlotManifest(2,1,alternateWeapon,1)]},
    slottedDefinition.Players[1]]}),"duplicate weapon index rejected");
Reject(()=>new MatchEngine(slottedDefinition with {Players=[slottedDefinition.Players[0] with
    {WeaponSlots=[new WeaponSlotManifest(0,0,alternateWeapon,1)]},slottedDefinition.Players[1]]}),
    "first weapon slot must match legacy authority");
Reject(() => new MatchEngine(definition with { Players = [definition.Players[0], definition.Players[0]] }), "duplicate roster");
Reject(() => new MatchEngine(definition with { DurationSeconds = 0 }), "invalid policy");
Reject(() => new MatchEngine(definition with { Mode = "ranked" }), "no fake ranked combat");
Reject(() => new MatchEngine(definition with { Players = [new(a, definition.Players[0].Weapon with { ReloadSeconds = double.NaN }), definition.Players[1]] }), "invalid weapon config");
var frozen = new MatchEngine(definition);
var original = definition.Players[0];
definition.Players[0] = new(a, new("changed", 999, 999, 1, 1));
Check(frozen.Snapshot().Players[0].ClipAmmo == 2, "detached manifest authority");
definition.Players[0] = original;
var timeout = new MatchEngine(definition);
timeout.Advance(300);
Check(timeout.Snapshot().TerminalReason == "admission-timeout" && !timeout.Admit(a), "half-open admission deadline");
var prestart=new MatchEngine(definition with {IdleSeconds=2});
prestart.Admit(a);prestart.Admit(b);
prestart.Command(a,Ready(1,prestart.ManifestHash));
prestart.Advance(1);
prestart.Command(b,Ready(1,prestart.ManifestHash));
prestart.Advance(60);
Check(prestart.Snapshot() is {Phase:BattlePhase.Aborted,TerminalReason:"prestart-disconnect",
      WinnerPlayerId:"",RewardEligible:false},
      "one idle countdown peer cancels before play without fabricating a win");
var idle = new MatchEngine(definition);
idle.Admit(a); idle.Admit(b); idle.Command(a, Ready(1, idle.ManifestHash)); idle.Command(b, Ready(1, idle.ManifestHash));
idle.Advance(299); idle.Command(a, Poll()); idle.Advance(300);
Check(idle.Snapshot().Players[1] is {Reconnecting:true,ReconnectAttempts:1,ReconnectDeadlineHostTick:1200} &&
      idle.Snapshot().ServerTick==300 && idle.Snapshot().PauseHostTick==300,
      "first idle peer starts recovered 30-second grace and pauses simulation");
idle.Advance(1199);
Check(idle.Snapshot().ServerTick==300 && idle.Snapshot().PauseHostTick==1199 &&
      idle.Command(a,Poll()).Code=="state", "reconnect grace advances wall time without simulation");
idle.Advance(1200);
Check(idle.Snapshot().WinnerPlayerId == a && idle.Snapshot().TerminalReason == "opponent-disconnected",
    "unrecovered peer forfeits only after its source grace expires");
Check(MatchOutcomeProjection.ForPlayer(idle.Snapshot(),a)==ClientGameEndReason.WinByForfeit &&
      MatchOutcomeProjection.ForPlayer(idle.Snapshot(),b)==ClientGameEndReason.Forfeit,
      "source reconnect loss projects forfeit outcomes from each peer's perspective");
var both = new MatchEngine(definition);
both.Admit(a); both.Admit(b); both.Command(a, Ready(1, both.ManifestHash)); both.Command(b, Ready(1, both.ManifestHash)); both.Advance(300);
Check(both.Snapshot().Phase == BattlePhase.Aborted && both.Snapshot().WinnerPlayerId == "", "both idle abort");
Check(MatchOutcomeProjection.ForPlayer(both.Snapshot(),a)==ClientGameEndReason.None &&
      MatchOutcomeProjection.ForPlayer(both.Snapshot(),b)==ClientGameEndReason.None,
      "aborted match cannot manufacture a Client victory or loss");
var staged=new MatchEngine(definition with {IdleSeconds=2});
staged.Admit(a);staged.Admit(b);
staged.Command(a,Ready(1,staged.ManifestHash));staged.Command(b,Ready(1,staged.ManifestHash));
staged.Advance(59);staged.Command(a,Poll());staged.Command(b,Poll());staged.Advance(60);
staged.Advance(118);staged.Command(a,Poll());staged.Advance(119);
Check(staged.Snapshot().Players[1] is {ReconnectAttempts:1,ReconnectDeadlineHostTick:1019} &&
      staged.Command(a,new MatchCommand {CommandId=2,Reload=new ReloadCommand()}).Code=="reconnecting" &&
      staged.Resume(b),"first reconnect grace pauses mutations until the peer resumes");
staged.Advance(120);staged.Command(a,Poll());staged.Advance(178);staged.Command(a,Poll());staged.Advance(179);
Check(staged.Snapshot().Players[1] is {ReconnectAttempts:2,ReconnectDeadlineHostTick:779},
      "second disconnect uses recovered 20-second window");
staged.Advance(200);Check(staged.Resume(b),"second reconnect succeeds before deadline");
staged.Advance(201);staged.Command(a,Poll());staged.Advance(259);staged.Command(a,Poll());staged.Advance(260);
Check(staged.Snapshot().Players[1] is {ReconnectAttempts:3,ReconnectDeadlineHostTick:560},
      "third disconnect uses recovered 10-second window");
staged.Advance(300);Check(staged.Resume(b),"third reconnect succeeds before deadline");
staged.Advance(301);staged.Command(a,Poll());staged.Advance(359);staged.Command(a,Poll());staged.Advance(360);
Check(staged.Snapshot() is {Phase:BattlePhase.Ended,WinnerPlayerId:var stagedWinner,
      TerminalReason:"opponent-disconnected"} && stagedWinner==a &&
      staged.Snapshot().Players[1].ReconnectAttempts==4,
      "fourth disconnect forfeits without another grace window");

string signingKey = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
var tokens = new MatchTokens(signingKey);
long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
MatchAdmission Claims(string id, ulong session) => new()
{
    MatchId = definition.MatchId, PlayerId = id, ServerId = definition.ServerId,
    ManifestHash = frozen.ManifestHash, SessionId = session, IssuedUnixSeconds = now, ExpiresUnixSeconds = now + 120
};
var claimsA = Claims(a, 101);
Check(tokens.Validate(tokens.Sign(claimsA), frozen, definition.ServerId, now) != null, "signed match admission");
Check(tokens.Validate(tokens.Sign(claimsA), frozen, definition.ServerId, now + 120) == null, "expired match admission");
Check(tokens.Validate(tokens.Sign(claimsA), frozen, "wrong-host", now) == null, "host binding");
var distant=claimsA.Clone();distant.IssuedUnixSeconds=MatchTokens.MaximumUnixSecond-119;
distant.ExpiresUnixSeconds=MatchTokens.MaximumUnixSecond+1;
Check(tokens.Validate(tokens.Sign(distant),frozen,definition.ServerId,distant.IssuedUnixSeconds)==null,
    "signed match ticket cannot claim an unrepresentable expiry");
var wrong = claimsA.Clone(); wrong.ManifestHash = new string('b', 64);
Check(tokens.Validate(tokens.Sign(wrong), frozen, definition.ServerId, now) == null, "content binding");
var probe = new BattleTickets(signingKey);
Check(tokens.Validate(probe.Sign(new TicketClaims { PlayerId = a, ServerId = definition.ServerId, SessionId = 101, IssuedUnixSeconds = now, ExpiresUnixSeconds = now + 120, Purpose = "connectivity-probe" }), frozen, definition.ServerId, now) == null, "probe cannot join match");
Check(!tokens.SessionKey(claimsA).SequenceEqual(probe.SessionKey(101)), "domain separated keys");

// Adversarial datagrams exercise the same endpoint as NetworkWorker without
// depending on receive timeout timings for negative assertions.
var admission = new MatchEndpoint(definition, signingKey);
var sender = new IPEndPoint(IPAddress.Loopback, 40101);
var stranger = new IPEndPoint(IPAddress.Loopback, 40102);
Packet Hello(MatchAdmission c, ulong sequence) => new()
{
    Version = 1, SessionId = c.SessionId, Sequence = sequence,
    MatchHello = new MatchHello { Ticket = tokens.Sign(c) }
};
var hello = Hello(claimsA, 1);
byte[] helloBytes = PacketCodec.Encode(hello, tokens.SessionKey(claimsA));
var badMac = helloBytes.ToArray(); badMac[^1] ^= 1;
Check(admission.Handle(hello, badMac, sender, now) == null && !admission.Owns(101), "bad MAC cannot reserve participant");
Check(admission.Handle(hello, helloBytes, sender, now) != null, "endpoint admitted");
Check(admission.Handle(hello, helloBytes, stranger, now) == null, "no endpoint hijack");
var duplicateIdentity = Claims(a, 103);
var duplicateHello = Hello(duplicateIdentity, 1);
Check(admission.Handle(duplicateHello, PacketCodec.Encode(duplicateHello, tokens.SessionKey(duplicateIdentity)), sender, now) == null, "one session per participant");
var wrongSession = hello.Clone(); wrongSession.SessionId = 199;
Check(admission.Handle(wrongSession, PacketCodec.Encode(wrongSession, tokens.SessionKey(claimsA)), sender, now) == null, "ticket session mismatch");
var commandPacket = new Packet { Version = 1, SessionId = 101, Sequence = 2, MatchCommand = Ready(1, frozen.ManifestHash) };
var commandBytes = PacketCodec.Encode(commandPacket, tokens.SessionKey(claimsA));
Check(admission.Handle(commandPacket, commandBytes, sender, now) != null, "endpoint command");
Check(admission.Handle(commandPacket, commandBytes, sender, now) == null, "packet replay discarded");
var emptyIntent=new Packet {Version=1,SessionId=101,Sequence=3,
    MatchCommand=new MatchCommand {CommandId=2}};
var serverOnly=new Packet {Version=1,SessionId=101,Sequence=4,
    MatchReply=new MatchReply {Code="forged-server-reply"}};
var paddedBarrelPoll=new MatchBarrelPoll();
paddedBarrelPoll.MergeFrom(new byte[]{8,1});
var paddedPoll=new Packet {Version=1,SessionId=101,Sequence=5,MatchBarrelPoll=paddedBarrelPoll};
var paddedReload=new ReloadCommand();
paddedReload.MergeFrom(new byte[]{8,1});
var paddedCommand=new Packet {Version=1,SessionId=101,Sequence=6,
    MatchCommand=new MatchCommand {CommandId=2,Reload=paddedReload}};
Check(admission.Handle(emptyIntent,PacketCodec.Encode(emptyIntent,tokens.SessionKey(claimsA)),sender,now)==null &&
      admission.Handle(serverOnly,PacketCodec.Encode(serverOnly,tokens.SessionKey(claimsA)),sender,now)==null &&
      admission.Handle(paddedPoll,PacketCodec.Encode(paddedPoll,tokens.SessionKey(claimsA)),sender,now)==null &&
      admission.Handle(paddedCommand,PacketCodec.Encode(paddedCommand,tokens.SessionKey(claimsA)),sender,now)==null,
      "invalid or padded client bodies cannot enter the match replay window");
admission.Advance(1);
for (ulong sequence = 3; sequence < 7; sequence++)
{
    var pollPacket = new Packet { Version = 1, SessionId = 101, Sequence = sequence, MatchCommand = Poll() };
    Check(admission.Handle(pollPacket, PacketCodec.Encode(pollPacket, tokens.SessionKey(claimsA)), sender, now) != null, "bounded packet allowance");
}
var flood = new Packet { Version = 1, SessionId = 101, Sequence = 7, MatchCommand = Poll() };
Check(admission.Handle(flood, PacketCodec.Encode(flood, tokens.SessionKey(claimsA)), sender, now) == null, "per-player tick budget");

var history = new MatchEngine(definition);
// A replacement capability must revoke the old endpoint without resetting commands.
var resumed = Claims(a, 104); resumed.ConnectionGeneration = 1;
var resumedHello = Hello(resumed, 1);
Check(admission.Handle(resumedHello, PacketCodec.Encode(resumedHello, tokens.SessionKey(resumed)), stranger, now) != null, "fresh generation reconnect");
Check(!admission.Owns(101) && admission.Owns(104), "reconnect revokes old session");
Check(admission.Handle(hello, helloBytes, sender, now) == null, "old capability cannot reclaim identity");
var resumedReady = new Packet { Version = 1, SessionId = 104, Sequence = 2, MatchCommand = Ready(1, frozen.ManifestHash) };
var resumedBytes = admission.Handle(resumedReady, PacketCodec.Encode(resumedReady, tokens.SessionKey(resumed)), stranger, now);
Check(resumedBytes != null && PacketCodec.Authenticate(resumedBytes, tokens.SessionKey(resumed)) && PacketCodec.ReadUntrusted(resumedBytes)?.MatchReply.Code == "ready", "reconnect preserves exact command receipt");
var pauseDefinition=definition with {IdleSeconds=2,MatchId="pause-match"};
var pausing=new MatchEndpoint(pauseDefinition,signingKey);
string pauseHash=new MatchEngine(pauseDefinition).ManifestHash;
MatchAdmission PauseClaims(string id,ulong session,ulong generation=0)=>new()
{
    MatchId=pauseDefinition.MatchId,PlayerId=id,ServerId=pauseDefinition.ServerId,
    ManifestHash=pauseHash,SessionId=session,ConnectionGeneration=generation,
    IssuedUnixSeconds=now,ExpiresUnixSeconds=now+120
};
var pauseA=PauseClaims(a,201UL);var pauseB=PauseClaims(b,202UL);
foreach(var (claim,peer) in new[]{(pauseA,sender),(pauseB,stranger)})
{
    var join=Hello(claim,1);join.MatchHello.MatchId=pauseDefinition.MatchId;
    Check(pausing.Handle(join,PacketCodec.Encode(join,tokens.SessionKey(claim)),peer,now)!=null,
        "pause fixture peer admitted through signed match hello");
    var ready=new Packet {Version=1,SessionId=claim.SessionId,Sequence=2,
        MatchCommand=Ready(1,pauseHash)};
    Check(pausing.Handle(ready,PacketCodec.Encode(ready,tokens.SessionKey(claim)),peer,now)!=null,
        "pause fixture ready command admitted");
}
pausing.Advance(59);
foreach(var (claim,peer) in new[]{(pauseA,sender),(pauseB,stranger)})
{
    var keepAlive=new Packet {Version=1,SessionId=claim.SessionId,Sequence=3,MatchCommand=Poll()};
    pausing.Handle(keepAlive,PacketCodec.Encode(keepAlive,tokens.SessionKey(claim)),peer,now);
}
pausing.Advance(60);pausing.Advance(118);
var activePoll=new Packet {Version=1,SessionId=pauseA.SessionId,Sequence=4,MatchCommand=Poll()};
pausing.Handle(activePoll,PacketCodec.Encode(activePoll,tokens.SessionKey(pauseA)),sender,now);
pausing.Advance(119);pausing.Advance(130);
var pauseView=new Packet {Version=1,SessionId=pauseA.SessionId,Sequence=5,MatchCommand=Poll()};
var pauseBytes=pausing.Handle(pauseView,PacketCodec.Encode(pauseView,tokens.SessionKey(pauseA)),sender,now);
Check(PacketCodec.ReadUntrusted(pauseBytes!)?.MatchReply.Snapshot is
      {ServerTick:119,PauseHostTick:130,Players:{Count:2}} pausedSnapshot &&
      pausedSnapshot.Players[1].Reconnecting,
      "authenticated UDP poll sees frozen simulation and opponent reconnect deadline");
var pauseReplacement=PauseClaims(b,203UL,1);
var resumeHello=Hello(pauseReplacement,1);resumeHello.MatchHello.MatchId=pauseDefinition.MatchId;
var resumedPause=pausing.Handle(resumeHello,PacketCodec.Encode(resumeHello,tokens.SessionKey(pauseReplacement)),stranger,now);
pausing.Advance(131);
Check(PacketCodec.ReadUntrusted(resumedPause!)?.MatchReply.Snapshot.Players[1].Reconnecting==false &&
      !pausing.Owns(pauseB.SessionId) && pausing.Owns(pauseReplacement.SessionId),
      "higher-generation UDP hello resumes a paused match and revokes the old key");
var otherDefinition = definition with { MatchId = "second-match" };
var router = new MatchRouter([definition, otherDefinition], definition.ServerId, signingKey);
Check(router.Handle(hello, helloBytes, sender, now) == null, "multi-match requires routing identity");
var routedHello = hello.Clone(); routedHello.MatchHello.MatchId = definition.MatchId;
Check(router.Handle(routedHello, PacketCodec.Encode(routedHello, tokens.SessionKey(claimsA)), sender, now) != null, "first routed match admitted");
var otherClaims = Claims(b, 105); otherClaims.MatchId = otherDefinition.MatchId; otherClaims.ManifestHash = new MatchEngine(otherDefinition).ManifestHash;
var otherHello = Hello(otherClaims, 1); otherHello.MatchHello.MatchId = otherDefinition.MatchId;
Check(router.Handle(otherHello, PacketCodec.Encode(otherHello, tokens.SessionKey(otherClaims)), stranger, now) != null, "second match isolated admission");
var misrouted = routedHello.Clone(); misrouted.MatchHello.MatchId = otherDefinition.MatchId;
Check(router.Handle(misrouted, PacketCodec.Encode(misrouted, tokens.SessionKey(claimsA)), sender, now) == null, "session cannot cross matches");
Reject(() => new MatchRouter([definition, definition], definition.ServerId, signingKey), "duplicate match allocation");
Reject(() => new MatchRouter(Enumerable.Range(0, 33).Select(i => definition with { MatchId = "m" + i }), definition.ServerId, signingKey), "bounded match allocation");
var liveRouter = new MatchRouter([], definition.ServerId, signingKey);
liveRouter.Advance(5000);
var timeBoundaryRouter=new MatchRouter([],definition.ServerId,signingKey);
Reject(()=>timeBoundaryRouter.Register(definition,MatchTokens.MaximumUnixSecond-119),
    "allocation refuses a grant whose expiry exceeds DateTimeOffset support");
Check(timeBoundaryRouter.Count==0 &&
      timeBoundaryRouter.Register(definition,MatchTokens.MaximumUnixSecond-120) is
          {Code:"registered",Grants.Count:2} lastDateGrant &&
      lastDateGrant.Grants.All(g=>g.ExpiresUnixSeconds==MatchTokens.MaximumUnixSecond),
      "last supported allocation second issues exactly bounded grants");
var firstRegistration=liveRouter.Register(definition,now);
var retriedRegistration=liveRouter.Register(definition,now);
string reconnectRequestId=new string('1',32);
Check(liveRouter.Reconnect(definition.MatchId,a,reconnectRequestId,now).Code=="reconnect-unavailable" &&
      liveRouter.Reconnect("missing-match",a,new string('2',32),now).Code=="unknown-match",
      "reconnect issuer requires an admitted known match");
Check(firstRegistration is {Code:"registered",ManifestHash:var registeredHash} &&
      registeredHash==frozen.ManifestHash && liveRouter.Count==1 &&
      retriedRegistration.Code=="existing-match" &&
      firstRegistration.Grants?.Count==2 && retriedRegistration.Grants?.Count==2 &&
      firstRegistration.Grants[0].Ticket==retriedRegistration.Grants[0].Ticket &&
      firstRegistration.Grants[1].Ticket==retriedRegistration.Grants[1].Ticket &&
      firstRegistration.Grants[0].SessionId!=firstRegistration.Grants[1].SessionId &&
      tokens.Validate(firstRegistration.Grants[0].Ticket,frozen,definition.ServerId,now)?.PlayerId==a &&
      tokens.Validate(firstRegistration.Grants[1].Ticket,frozen,definition.ServerId,now)?.PlayerId==b &&
      liveRouter.Register(definition with {AdmissionSeconds=definition.AdmissionSeconds+1},now).Code=="duplicate-match" &&
      liveRouter.Register(definition with { ServerId="another-host", MatchId="other-match" }).Code=="wrong-host",
      "runtime registration returns retry-stable player grants bound to one immutable host match");
Check(liveRouter.Register(definition,now+120).Code=="admission-expired" &&
      liveRouter.Register(definition,now+119).Code=="existing-match",
      "registration retry never returns an expired admission ticket");
var lateHello = hello.Clone(); lateHello.MatchHello.MatchId=definition.MatchId;
var lateBytes=liveRouter.Handle(lateHello,PacketCodec.Encode(lateHello,tokens.SessionKey(claimsA)),sender,now);
Check(lateBytes!=null && PacketCodec.ReadUntrusted(lateBytes)?.MatchReply.Snapshot.Phase==BattlePhase.Waiting,
      "late registration starts its own admission clock instead of inheriting worker uptime");
Reject(()=>liveRouter.Reconnect(definition.MatchId,a,new string('4',32),MatchTokens.MaximumUnixSecond-119),
    "reconnect refuses an out-of-range expiry before rotating the session");
var replacement=liveRouter.Reconnect(definition.MatchId,a,reconnectRequestId,now);
var replacementRetry=liveRouter.Reconnect(definition.MatchId,a,reconnectRequestId,now);
Check(replacement is {Code:"reconnect-issued",Grants.Count:1} &&
      replacement.Grants[0].SessionId!=firstRegistration.Grants![0].SessionId &&
      replacementRetry.Code=="reconnect-existing" &&
      replacementRetry.Grants![0].Ticket==replacement.Grants[0].Ticket &&
      tokens.Validate(replacement.Grants[0].Ticket,frozen,definition.ServerId,now) is
          {ConnectionGeneration:1,PlayerId:var resumedId} && resumedId==a &&
      liveRouter.Reconnect(definition.MatchId,b,reconnectRequestId,now).Code=="reconnect-conflict" &&
      liveRouter.Reconnect(definition.MatchId,"unknown-player",new string('3',32),now).Code=="unknown-player",
      "trusted reconnect replays one grant per request ID and rejects conflicting outsiders");
Check(liveRouter.Reconnect(definition.MatchId,a,reconnectRequestId,now+120).Code=="reconnect-expired" &&
      liveRouter.Reconnect(definition.MatchId,a,reconnectRequestId,now+119).Code=="reconnect-existing",
      "reconnect retry never returns an expired rotated ticket");
liveRouter.Advance(5000+(ulong)definition.AdmissionSeconds*MatchManifest.TickRate+1);
Check(liveRouter.Count==1,"terminal match remains available for bounded replay");
Check(liveRouter.Register(definition,now).Code=="match-terminal",
    "terminal match cannot replay admission grants even before expiry");
liveRouter.Advance(5000+(ulong)definition.AdmissionSeconds*MatchManifest.TickRate+
    121*MatchManifest.TickRate+1);
Check(liveRouter.Count==0 && liveRouter.Handle(lateHello,
    PacketCodec.Encode(lateHello,tokens.SessionKey(claimsA)),sender,now)==null,
    "expired terminal match and its session route leave the bounded registry");
var capacityRouter=new MatchRouter([],definition.ServerId,signingKey);
var capacityGrants=new List<MatchConnectionGrant[]>();
for(int i=0;i<32;i++)
{
    var allocation=capacityRouter.Register(definition with {MatchId="allocated-"+i},now);
    Check(allocation.Code=="registered" && allocation.Grants?.Count==2,
        "runtime registry accepts one slot inside its bound");
    capacityGrants.Add(allocation.Grants!.ToArray());
}
Check(capacityRouter.Register(definition with {MatchId="allocated-overflow"}).Code=="match-capacity" &&
      capacityRouter.Count==32,"runtime allocation cannot exceed the 32-match host bound");
Packet CapacityRequest(MatchConnectionGrant grant,IPEndPoint peer,ulong sequence,MatchCommand? command=null)
{
    var packet=new Packet {Version=1,SessionId=grant.SessionId,Sequence=sequence};
    if(command==null)packet.MatchHello=new MatchHello {Ticket=grant.Ticket,MatchId=grant.MatchId};
    else packet.MatchCommand=command;
    byte[]? response=capacityRouter.Handle(packet,
        PacketCodec.Encode(packet,grant.SessionKey.ToByteArray()),peer,now);
    Check(response!=null && PacketCodec.Authenticate(response!,grant.SessionKey.ToByteArray()),
        "capacity match returns an authenticated packet");
    return PacketCodec.ReadUntrusted(response!)!;
}
var capacityPeers=Enumerable.Range(0,32).Select(i=>new[] {
    new IPEndPoint(IPAddress.Loopback,42000+i*2),
    new IPEndPoint(IPAddress.Loopback,42001+i*2)}).ToArray();
for(int i=0;i<32;i++)
    for(int j=0;j<2;j++)
    {
        var grant=capacityGrants[i][j];var peer=capacityPeers[i][j];
        Check(CapacityRequest(grant,peer,1).MatchReply.Code=="admitted",
            "each capacity slot admits its own signed participant");
        Check(CapacityRequest(grant,peer,2,Ready(1,grant.ManifestHash))
              .MatchReply.Code=="ready",
            "each capacity slot accepts its own manifest-bound ready command");
    }
capacityRouter.Advance(60);
for(int i=0;i<32;i++)
    Check(CapacityRequest(capacityGrants[i][0],capacityPeers[i][0],3,Poll())
          .MatchReply.Snapshot.Phase==BattlePhase.Running,
        "all 32 capacity matches advance into running independently");
Check(CapacityRequest(capacityGrants[0][1],capacityPeers[0][1],3,
          new MatchCommand {CommandId=2,Forfeit=new ForfeitCommand()})
      .MatchReply.Snapshot is {Phase:BattlePhase.Ended,WinnerPlayerId:var capacityWinner} &&
      capacityWinner==a && capacityRouter.UnpublishedTerminals().Count()==1,
    "one full-capacity match terminates without ending another");
capacityRouter.Advance(61);
for(int i=1;i<32;i++)
    Check(CapacityRequest(capacityGrants[i][0],capacityPeers[i][0],4,Poll())
          .MatchReply.Snapshot is {Phase:BattlePhase.Running,ServerTick:61},
        "unrelated capacity matches keep their own running clocks");
var cancellable=new MatchRouter([],definition.ServerId,signingKey);
Check(cancellable.Register(definition,now).Code=="registered" &&
      cancellable.CancelBeforeStart(definition.MatchId).Code=="cancelled-before-start" &&
      cancellable.CancelBeforeStart(definition.MatchId).Code=="already-cancelled" &&
      cancellable.UnpublishedTerminals().Single() is
          {Phase:BattlePhase.Aborted,TerminalReason:"cancelled-before-start",RewardEligible:false,WinnerPlayerId:""},
      "trusted prestart cancellation is idempotent and publishes unscored terminal evidence");
Check(cancellable.Handle(lateHello,PacketCodec.Encode(lateHello,tokens.SessionKey(claimsA)),sender,now)==null &&
      cancellable.CancelBeforeStart("missing-match").Code=="unknown-match",
      "cancelled allocation rejects late player admission and unknown cancellations");
var sameTickCancel=new MatchEngine(definition);
ulong beforeCancelRevision=sameTickCancel.Snapshot().StateRevision;
Check(sameTickCancel.CancelBeforeStart() &&
      sameTickCancel.Snapshot().StateRevision>beforeCancelRevision &&
      sameTickCancel.Snapshot().ServerTick==0,
      "same-tick cancellation advances the terminal snapshot revision");
var startedForCancel=new MatchEngine(definition);
startedForCancel.Admit(a);startedForCancel.Admit(b);
startedForCancel.Command(a,Ready(1,startedForCancel.ManifestHash));
startedForCancel.Command(b,Ready(1,startedForCancel.ManifestHash));
startedForCancel.Advance(61);
Check(startedForCancel.Snapshot().Phase==BattlePhase.Running &&
      !startedForCancel.CancelBeforeStart() && startedForCancel.Snapshot().Phase==BattlePhase.Running,
      "allocator cancellation cannot rewrite a running battle result");
ulong beforeShutdownRevision=startedForCancel.Snapshot().StateRevision;
Check(startedForCancel.AbortForHostShutdown() && !startedForCancel.AbortForHostShutdown() &&
      startedForCancel.Snapshot() is
          {Phase:BattlePhase.Aborted,TerminalReason:"host-shutdown",RewardEligible:false,WinnerPlayerId:""} &&
      startedForCancel.Snapshot().StateRevision>beforeShutdownRevision,
      "controlled host shutdown produces one unscored running-match result");
var shutdownRouter=new MatchRouter([],definition.ServerId,signingKey);
shutdownRouter.Register(definition,now);
Check(shutdownRouter.AbortForHostShutdown()==1 && shutdownRouter.AbortForHostShutdown()==0 &&
      shutdownRouter.UnpublishedTerminals().Single().TerminalReason=="host-shutdown",
      "host shutdown aborts every active allocation exactly once for outbox publication");
history.Admit(a);
Check(history.Command(a,new MatchCommand {CommandId=1}).Code=="invalid-command" &&
      history.Snapshot().Players[0].LastCommandId==0,
      "empty match command cannot consume the reliable mutation cursor");
for (ulong id = 1; id <= 70; id++) history.Command(a, new MatchCommand { CommandId = id, Reload = new ReloadCommand() });
Check(history.Command(a, new MatchCommand { CommandId = 1, Reload = new ReloadCommand() }).Code == "command-order", "evicted command cannot execute again");
var timer = new MatchEngine(definition with { DurationSeconds = 5, IdleSeconds = 120 });
timer.Admit(a); timer.Admit(b); timer.Command(a, Ready(1, timer.ManifestHash)); timer.Command(b, Ready(1, timer.ManifestHash));
timer.Advance(210);
Check(timer.Snapshot().TerminalReason == "duration-limit" && !timer.Snapshot().RewardEligible, "duration expires without fake outcome");
byte[] frozenTerminal=timer.Snapshot().ToByteArray();
timer.Advance(300);
Check(timer.Command(a,new MatchCommand {CommandId=2,Reload=new ReloadCommand()}).Code=="match-terminal" &&
      timer.Snapshot().ToByteArray().AsSpan().SequenceEqual(frozenTerminal) &&
      timer.Command(b,new MatchCommand {CommandId=2,Forfeit=new ForfeitCommand()}).Code=="match-terminal" &&
      timer.Command(a,Ready(1,timer.ManifestHash)).Code=="ready" &&
      timer.Snapshot().ToByteArray().AsSpan().SequenceEqual(frozenTerminal),
      "terminal evidence stays byte-stable after later ticks, rejected commands, and receipt replay");
string outboxPath=Path.Combine(Path.GetTempPath(),"war-terminal-test-"+Guid.NewGuid().ToString("N"));
try
{
    var outbox=new TerminalOutbox(outboxPath);
    var impossibleArmy=timer.Snapshot().Clone();
    impossibleArmy.Players[0].ConfirmedArmyLosses=1;
    Reject(()=>outbox.Publish(impossibleArmy),
        "terminal result cannot claim an army loss without a host-confirmed spawn");
    var impossibleHits=timer.Snapshot().Clone();
    impossibleHits.Players[0].ConfirmedEnemyHits=1;
    Reject(()=>outbox.Publish(impossibleHits),
        "terminal result cannot claim an enemy hit without a host-created projectile");
    impossibleHits.Players[0].ShotsFired=1;
    impossibleHits.Players[0].ConfirmedPlayerHits=2;
    Reject(()=>outbox.Publish(impossibleHits),
        "terminal result cannot claim more player hits than confirmed enemy hits");
    var impossibleClock=timer.Snapshot().Clone();impossibleClock.EndTick++;
    Reject(()=>outbox.Publish(impossibleClock),
        "terminal evidence must freeze the simulation tick at its end tick");
    var impossiblePlayer=timer.Snapshot().Clone();impossiblePlayer.Players[0].PositionX=float.NaN;
    Reject(()=>outbox.Publish(impossiblePlayer),
        "durable terminal evidence rejects nonfinite player positions");
    impossiblePlayer=timer.Snapshot().Clone();impossiblePlayer.Players[0].ClipAmmo=-1;
    Reject(()=>outbox.Publish(impossiblePlayer),
        "durable terminal evidence rejects impossible ammunition");
    impossiblePlayer=timer.Snapshot().Clone();impossiblePlayer.Players[0].ReconnectDeadlineHostTick=1;
    Reject(()=>outbox.Publish(impossiblePlayer),
        "durable terminal evidence cannot retain an active reconnect deadline");
    var impossibleShield=timer.Snapshot().Clone();
    impossibleShield.Shields.Add(new BattleShieldState {CoverIndex=0,OwnerFraction=1,Health=0,MaxHealth=10,Destroyed=true});
    Reject(()=>outbox.Publish(impossibleShield),
        "durable terminal evidence rejects incomplete shield sets");
    var validPose=RiflePoseProjection.Create(timer.Snapshot().ServerTick,
        [new RifleClipLayer(new("idle",0,1,true),1)],Quaternion.Identity,Quaternion.Identity,null);
    Check(RiflePoseProjection.ValidWire(validPose,timer.Snapshot().ServerTick),
        "host-created idle pose satisfies terminal pose validation");
    var impossiblePose=timer.Snapshot().Clone();impossiblePose.Players[0].RiflePose=validPose.Clone();
    impossiblePose.Players[0].RiflePose.SampledTick++;
    Reject(()=>outbox.Publish(impossiblePose),
        "terminal pose sample cannot postdate the result tick");
    impossiblePose.Players[0].RiflePose=validPose.Clone();
    impossiblePose.Players[0].RiflePose.Layers[0].Clip=(RiflePoseClip)99;
    Reject(()=>outbox.Publish(impossiblePose),
        "terminal pose cannot carry an unknown animation clip");
    impossiblePose.Players[0].RiflePose=validPose.Clone();
    impossiblePose.Players[0].RiflePose.RootRotation.W=float.NaN;
    Reject(()=>outbox.Publish(impossiblePose),
        "terminal pose cannot carry a nonfinite root rotation");
    var impossibleReason=timer.Snapshot().Clone();impossibleReason.TerminalReason="forfeit";
    Reject(()=>outbox.Publish(impossibleReason),
        "aborted terminal evidence cannot carry a completed-match reason");
    var falseLethal=terminal.Snapshot.Clone();falseLethal.TerminalReason="player-killed";
    Reject(()=>outbox.Publish(falseLethal),
        "durable lethal evidence needs the losing player dead");
    falseLethal.Players.Single(p=>p.PlayerId==b).Dead=true;
    falseLethal.Players.Single(p=>p.PlayerId==a).Dead=true;
    Reject(()=>outbox.Publish(falseLethal),
        "durable lethal evidence cannot declare a dead winner");
    var falseForfeit=terminal.Snapshot.Clone();
    falseForfeit.Players.Single(p=>p.PlayerId==b).Dead=true;
    Reject(()=>outbox.Publish(falseForfeit),
        "durable forfeit evidence cannot hide a lethal player death");
    Check(!outbox.HasIdentity(timer.MatchId),"rejected army statistics leave no durable terminal identity");
    Check(outbox.Publish(timer.Snapshot()) && !outbox.Publish(timer.Snapshot()),
        "terminal evidence publishes once under its match identity");
    Check(outbox.HasIdentity(timer.MatchId),"terminal result reserves its match identity");
    string pendingFile=Path.Combine(outboxPath,timer.MatchId+".wfr");
    string interruptedFile=Path.Combine(outboxPath,timer.MatchId+"."+Guid.NewGuid().ToString("N")+".tmp");
    File.Move(pendingFile,interruptedFile);
    var reopened=new TerminalOutbox(outboxPath);
    Check(File.Exists(pendingFile) && !File.Exists(interruptedFile),
        "startup recovers a complete flushed result interrupted before rename");
    Check(reopened.Pending() is [{TerminalReason:"duration-limit",RewardEligible:false}],
        "terminal evidence survives outbox restart with its unscored result");
    var page=reopened.PendingPage();
    Check(page.Count==1 && page[0].Digest.Length==64 && page[0].Snapshot.MatchId==timer.MatchId,
        "bounded result page binds snapshot and acknowledgement digest");
    var forged=timer.Snapshot().Clone();forged.TerminalReason="forged-result";
    Reject(()=>reopened.Publish(forged),
        "conflicting terminal evidence cannot replace the first record");
    Check(reopened.Acknowledge(timer.MatchId,new string('0',64))=="digest-mismatch" &&
          reopened.PendingPage().Count==1,"wrong result digest cannot clear pending evidence");
    Check(reopened.Acknowledge(timer.MatchId,page[0].Digest)=="acknowledged" &&
          reopened.Acknowledge(timer.MatchId,page[0].Digest)=="already-acknowledged" &&
          reopened.PendingPage().Count==0 && !reopened.Publish(timer.Snapshot()),
          "result acknowledgement is durable, idempotent, and blocks republishing");
    Check(new TerminalOutbox(outboxPath).PendingPage().Count==0,
        "acknowledged result stays closed after outbox restart");
    string resultFile=Path.Combine(outboxPath,timer.MatchId+".ack");
    byte[] intact=File.ReadAllBytes(resultFile);
    byte[] corrupted=(byte[])intact.Clone();corrupted[^1]^=1;File.WriteAllBytes(resultFile,corrupted);
    Reject(()=>new TerminalOutbox(outboxPath),"corrupt terminal evidence fails startup");
    File.WriteAllBytes(resultFile,intact);
    int payloadLength=System.Buffers.Binary.BinaryPrimitives.ReadInt32LittleEndian(intact.AsSpan(4,4));
    byte[] duplicateField=new byte[intact.Length+2];
    intact.AsSpan(0,8+payloadLength).CopyTo(duplicateField);
    duplicateField[8+payloadLength]=0x50; // Duplicate/default reward_eligible=false.
    duplicateField[9+payloadLength]=0;
    System.Buffers.Binary.BinaryPrimitives.WriteInt32LittleEndian(duplicateField.AsSpan(4,4),payloadLength+2);
    SHA256.HashData(duplicateField.AsSpan(0,10+payloadLength),duplicateField.AsSpan(10+payloadLength,32));
    File.WriteAllBytes(resultFile,duplicateField);
    Reject(()=>new TerminalOutbox(outboxPath),
        "checksummed but noncanonical terminal protobuf cannot change restart interpretation");
    File.WriteAllBytes(resultFile,intact);
    var invalidReplay=MatchSnapshot.Parser.ParseFrom(intact,8,payloadLength);
    invalidReplay.Players[0].PositionX=float.NaN;
    byte[] invalidPayload=invalidReplay.ToByteArray();
    byte[] invalidRecord=new byte[8+invalidPayload.Length+32];
    intact.AsSpan(0,4).CopyTo(invalidRecord);
    System.Buffers.Binary.BinaryPrimitives.WriteInt32LittleEndian(invalidRecord.AsSpan(4,4),invalidPayload.Length);
    invalidPayload.CopyTo(invalidRecord,8);
    SHA256.HashData(invalidRecord.AsSpan(0,8+invalidPayload.Length),invalidRecord.AsSpan(8+invalidPayload.Length,32));
    File.WriteAllBytes(resultFile,invalidRecord);
    Reject(()=>new TerminalOutbox(outboxPath),
        "checksummed terminal spool replay rejects nonfinite player authority");
    File.WriteAllBytes(resultFile,intact);
    var retainedPending=timer.Snapshot().Clone();retainedPending.MatchId="retained-pending";
    Check(reopened.Publish(retainedPending),"second terminal result enters the pending spool");
    var retentionNow=DateTimeOffset.UtcNow;
    File.SetLastWriteTimeUtc(resultFile,retentionNow.UtcDateTime.AddDays(-29));
    Check(reopened.PruneAcknowledged(retentionNow)==0 && File.Exists(resultFile),
        "recent acknowledged evidence remains idempotent within retention");
    File.SetLastWriteTimeUtc(resultFile,retentionNow.UtcDateTime.AddDays(-31));
    Check(reopened.PruneAcknowledged(retentionNow)==1 && !File.Exists(resultFile) &&
          reopened.Acknowledge(timer.MatchId,page[0].Digest)=="missing" &&
          reopened.PendingPage().Single().Snapshot.MatchId==retainedPending.MatchId,
        "expired acknowledged tombstone is removed without reviving pending evidence");
}
finally {Directory.Delete(outboxPath,true);}
string crashRoot=Path.Combine(Path.GetTempPath(),"war-crash-journal-"+Guid.NewGuid().ToString("N"));
try
{
    var crashOutbox=new TerminalOutbox(Path.Combine(crashRoot,"outbox"));
    var journal=new ActiveMatchJournal(Path.Combine(crashRoot,"active"));
    journal.Begin(definition,frozen.ManifestHash);
    journal.Begin(definition,frozen.ManifestHash);
    var restarted=new ActiveMatchJournal(Path.Combine(crashRoot,"active"));
    Check(restarted.Recover(crashOutbox)==1 && restarted.Recover(crashOutbox)==0 &&
          new TerminalOutbox(Path.Combine(crashRoot,"outbox")).Pending().Single() is
              {Phase:BattlePhase.Aborted,TerminalReason:"host-crash",RewardEligible:false,WinnerPlayerId:""},
          "abandoned runtime allocation becomes one durable unscored crash result on restart");
    var completed=definition with {MatchId="completed-before-crash"};
    journal.Begin(completed,new MatchEngine(completed).ManifestHash);
    var completedSnapshot=timer.Snapshot().Clone();
    completedSnapshot.MatchId=completed.MatchId;
    completedSnapshot.ManifestHash=new MatchEngine(completed).ManifestHash;
    crashOutbox.Publish(completedSnapshot);
    Check(restarted.Recover(crashOutbox)==0 && crashOutbox.Pending().Count==2,
        "restart keeps an existing terminal result rather than forging a crash result");
    var conflict=definition with {MatchId="conflicting-before-crash"};
    journal.Begin(conflict,new MatchEngine(conflict).ManifestHash);
    var conflictingSnapshot=completedSnapshot.Clone();
    conflictingSnapshot.MatchId=conflict.MatchId;
    crashOutbox.Publish(conflictingSnapshot);
    Reject(()=>restarted.Recover(crashOutbox),
        "restart rejects a terminal record whose manifest disagrees with the active allocation");
    var colliding=definition with {MatchId="new-startup-collision"};
    journal.Begin(colliding,new MatchEngine(colliding).ManifestHash);
    Reject(()=>restarted.Recover(crashOutbox,id=>id==colliding.MatchId),
        "startup refuses to reuse an abandoned runtime match identity");
}
finally {Directory.Delete(crashRoot,true);}
string partialRoot=Path.Combine(Path.GetTempPath(),"war-partial-terminal-"+Guid.NewGuid().ToString("N"));
try
{
    string spool=Path.Combine(partialRoot,"outbox");
    var active=new ActiveMatchJournal(Path.Combine(spool,"active"));
    active.Begin(definition,new MatchEngine(definition).ManifestHash);
    string partial=Path.Combine(spool,definition.MatchId+"."+Guid.NewGuid().ToString("N")+".tmp");
    byte[] interrupted="WFR1"u8.ToArray();File.WriteAllBytes(partial,interrupted);
    Reject(()=>new TerminalOutbox(spool),"incomplete terminal bytes without allocation proof fail startup");
    var recovering=new TerminalOutbox(spool,active.ActiveMatchIds());
    Check(File.Exists(partial+".partial") && !File.Exists(partial) &&
          File.ReadAllBytes(partial+".partial").SequenceEqual(interrupted) &&
          active.Recover(recovering)==1 &&
          recovering.Pending().Single().TerminalReason=="host-crash" &&
          new TerminalOutbox(spool).Pending().Single().TerminalReason=="host-crash",
          "journal-proven incomplete result is preserved and recovers as durable unscored crash evidence");
    string unproven=Path.Combine(spool,"unproven."+Guid.NewGuid().ToString("N")+".tmp");
    File.WriteAllBytes(unproven,interrupted);
    Reject(()=>new TerminalOutbox(spool,active.ActiveMatchIds()),
        "unproven incomplete terminal evidence still blocks startup");
}
finally {Directory.Delete(partialRoot,true);}
var limited = new MatchEngine(definition);
limited.Admit(a); limited.Admit(b); limited.Command(a, Ready(1, limited.ManifestHash)); limited.Command(b, Ready(1, limited.ManifestHash));
limited.Advance(60); limited.Command(a, Fire(2)); limited.Advance(63); limited.Command(a, Fire(3)); limited.Advance(69);
limited.Command(a, Fire(4)); limited.Advance(72); limited.Command(a, Fire(5)); limited.Advance(78);
Check(limited.Snapshot().Players[0].ClipAmmo == 1 && limited.Snapshot().Players[0].ReserveAmmo == 0, "partial final reload");
limited.Command(a, Fire(6)); limited.Advance(81);
Check(limited.Command(a, Fire(7)).Code == "no-ammo", "finite ammunition exhausted");
Check(limited.Command(a, new MatchCommand { CommandId = 8, Reload = new ReloadCommand() }).Code == "reload-unavailable", "empty reserve cannot refill");

// Actual NetworkWorker socket/tick integration; no Backend or Mongo process.
using var portProbe = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
int port = ((IPEndPoint)portProbe.Client.LocalEndPoint!).Port;
portProbe.Close();
string manifestFile = Path.Combine(Path.GetTempPath(), "war-battle-" + Guid.NewGuid().ToString("N") + ".json");
string workerOutboxPath=Path.Combine(Path.GetTempPath(),"war-worker-outbox-"+Guid.NewGuid().ToString("N"));
await File.WriteAllTextAsync(manifestFile, JsonSerializer.Serialize(definition));
using var logs = LoggerFactory.Create(builder => builder.SetMinimumLevel(LogLevel.Warning));
var config = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
{
    ["Battle:SigningKey"] = signingKey, ["Battle:ServerId"] = definition.ServerId,
    ["Battle:Port"] = port.ToString(), ["Battle:BindAddress"] = "127.0.0.1", ["Battle:MatchManifestPath"] = manifestFile,
    ["Battle:ResultOutboxPath"] = workerOutboxPath
}).Build();
IConfiguration OutboxConfig(string path)=>new ConfigurationBuilder().AddConfiguration(config)
    .AddInMemoryCollection(new Dictionary<string,string?>{{"Battle:ResultOutboxPath",path}}).Build();
using var worker = new NetworkWorker(config, logs.CreateLogger<NetworkWorker>());
Check(!worker.IsReady,"unstarted battle worker is not ready");
try
{
    await worker.StartAsync(CancellationToken.None);
    for(int attempt=0;attempt<100 && !worker.IsReady;attempt++)await Task.Delay(10);
    Check(worker.IsReady,"battle worker becomes ready only after UDP bind");
    using var peerA = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
    using var peerB = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
    var endpoint = new IPEndPoint(IPAddress.Loopback, port);
    var seq = new Dictionary<ulong, ulong>();
    async Task<MatchReply> Exchange(UdpClient peer, MatchAdmission claims, MatchCommand? command)
    {
        var packet = new Packet { Version = 1, SessionId = claims.SessionId, Sequence = seq.GetValueOrDefault(claims.SessionId) + 1 };
        seq[claims.SessionId] = packet.Sequence;
        if (command == null) packet.MatchHello = new MatchHello { Ticket = tokens.Sign(claims) };
        else packet.MatchCommand = command;
        var key = tokens.SessionKey(claims);
        var bytes = PacketCodec.Encode(packet, key);
        await peer.SendAsync(bytes, endpoint);
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        var received = await peer.ReceiveAsync(deadline.Token);
        var reply = PacketCodec.ReadUntrusted(received.Buffer);
        Check(received.RemoteEndPoint.Equals(endpoint) && PacketCodec.Authenticate(received.Buffer, key) && reply?.SessionId == claims.SessionId && reply.Ack == packet.Sequence && reply.MatchReply != null, "authenticated UDP reply");
        return reply!.MatchReply!;
    }
    var claimsB = Claims(b, 102);
    Check((await Exchange(peerA, claimsA, null)).Code == "admitted", "UDP admit A");
    Check((await Exchange(peerB, claimsB, null)).Code == "admitted", "UDP admit B");
    Check((await Exchange(peerA, claimsA, Ready(1, frozen.ManifestHash))).Code == "ready", "UDP ready A");
    Check((await Exchange(peerB, claimsB, Ready(1, frozen.ManifestHash))).Snapshot.Phase == BattlePhase.Countdown, "UDP start barrier");
    var limit = DateTime.UtcNow.AddSeconds(4);
    MatchReply state;
    do
    {
        await Task.Delay(100);
        state = await Exchange(peerA, claimsA, Poll());
    } while (state.Snapshot.Phase != BattlePhase.Running && DateTime.UtcNow < limit);
    Check(state.Snapshot.Phase == BattlePhase.Running, "live fixed-tick running");
    var liveShot = await Exchange(peerA, claimsA, Fire(2));
    Check(liveShot.Code == "shot-accepted", "UDP fire command");
    Check((await Exchange(peerA, claimsA, Fire(2))).Equals(liveShot), "UDP reliable command retry");
    var final = await Exchange(peerB, claimsB, new MatchCommand { CommandId = 2, Forfeit = new ForfeitCommand() });
    Check(final.Snapshot.Phase == BattlePhase.Ended && final.Snapshot.WinnerPlayerId == a && !final.Snapshot.RewardEligible, "UDP terminal state");
}
finally
{
    await worker.StopAsync(CancellationToken.None);
    Check(!worker.IsReady,"stopped battle worker withdraws readiness");
    File.Delete(manifestFile);
}
string multiOutboxPath=Path.Combine(Path.GetTempPath(),"war-multi-udp-"+Guid.NewGuid().ToString("N"));
var multiConfig=new ConfigurationBuilder().AddConfiguration(config)
    .AddInMemoryCollection(new Dictionary<string,string?>{
        ["Battle:MatchManifestPath"]="",["Battle:ResultOutboxPath"]=multiOutboxPath}).Build();
using(var multiWorker=new NetworkWorker(multiConfig,logs.CreateLogger<NetworkWorker>()))
{
    var multiPeers=new List<UdpClient>();
    var multiGrants=new MatchConnectionGrant[32][];
    var multiSequences=new Dictionary<ulong,ulong>();
    async Task<MatchReply> MultiExchange(MatchConnectionGrant grant,UdpClient peer,MatchCommand? command)
    {
        ulong sequence=multiSequences.GetValueOrDefault(grant.SessionId)+1;
        multiSequences[grant.SessionId]=sequence;
        var packet=new Packet {Version=1,SessionId=grant.SessionId,Sequence=sequence};
        if(command==null)packet.MatchHello=new MatchHello {Ticket=grant.Ticket,MatchId=grant.MatchId};
        else packet.MatchCommand=command;
        byte[] key=grant.SessionKey.ToByteArray();
        await peer.SendAsync(PacketCodec.Encode(packet,key),new IPEndPoint(IPAddress.Loopback,port));
        using var deadline=new CancellationTokenSource(TimeSpan.FromSeconds(3));
        while(true)
        {
            var received=await peer.ReceiveAsync(deadline.Token);
            var response=PacketCodec.ReadUntrusted(received.Buffer);
            if(response?.SessionId==grant.SessionId && response.Ack<sequence)continue;
            Check(PacketCodec.Authenticate(received.Buffer,key) && response?.SessionId==grant.SessionId &&
                  response.Ack==sequence && response.MatchReply?.Snapshot.MatchId==grant.MatchId,
                "parallel match UDP reply retains its authenticated session and match");
            return response!.MatchReply!;
        }
    }
    async Task<MatchReply> MultiPollWithRetry(int index)
    {
        for(int attempt=0;attempt<3;attempt++)
        {
            try {return await MultiExchange(multiGrants[index][0],multiPeers[index*2],Poll());}
            catch(OperationCanceledException) when(attempt<2) { }
        }
        return await MultiExchange(multiGrants[index][0],multiPeers[index*2],Poll());
    }
    try
    {
        await multiWorker.StartAsync(CancellationToken.None);
        for(int attempt=0;attempt<100 && !multiWorker.IsReady;attempt++)await Task.Delay(10);
        Check(multiWorker.IsReady,"multi-match UDP worker binds before allocation");
        for(int i=0;i<multiGrants.Length;i++)
        {
            var allocation=await multiWorker.RegisterMatch(definition with
                {MatchId="udp-parallel-"+i,AdmissionSeconds=120,IdleSeconds=120,DurationSeconds=30},
                CancellationToken.None);
            Check(allocation is {Code:"registered",Grants.Count:2},
                "multi-match Worker allocates one signed roster");
            multiGrants[i]=allocation.Grants!.ToArray();
            multiPeers.Add(new UdpClient(new IPEndPoint(IPAddress.Loopback,0)));
            multiPeers.Add(new UdpClient(new IPEndPoint(IPAddress.Loopback,0)));
        }
        for(int i=0;i<multiGrants.Length;i++)
            for(int j=0;j<2;j++)
                Check((await MultiExchange(multiGrants[i][j],multiPeers[i*2+j],null)).Code=="admitted",
                    "multiple live UDP matches admit their own peers");
        for(int i=0;i<multiGrants.Length;i++)
            for(int j=0;j<2;j++)
                Check((await MultiExchange(multiGrants[i][j],multiPeers[i*2+j],
                    Ready(1,multiGrants[i][j].ManifestHash))).Code=="ready",
                    "multiple live UDP matches accept independent ready commands");
        await Task.Delay(2200);
        for(int i=0;i<multiGrants.Length;i++)
            Check((await MultiExchange(multiGrants[i][0],multiPeers[i*2],Poll()))
                  .Snapshot.Phase==BattlePhase.Running,
                "all parallel live UDP matches reach running");
        ulong[] firstBurstTicks=new ulong[multiGrants.Length];
        ulong[] lastBurstTicks=new ulong[multiGrants.Length];
        for(int round=0;round<8;round++)
        {
            var burst=await Task.WhenAll(Enumerable.Range(0,multiGrants.Length)
                .Select(i=>MultiExchange(multiGrants[i][0],multiPeers[i*2],Poll())));
            for(int i=0;i<burst.Length;i++)
            {
                ulong observed=burst[i].Snapshot.ServerTick;
                Check(burst[i].Snapshot.Phase==BattlePhase.Running &&
                      (round==0 || observed>=lastBurstTicks[i]),
                    "full-capacity UDP poll burst keeps each match running and monotonic");
                if(round==0)firstBurstTicks[i]=observed;
                lastBurstTicks[i]=observed;
            }
            await Task.Delay(100);
        }
        Check(Enumerable.Range(0,multiGrants.Length).All(i=>
              lastBurstTicks[i]>=firstBurstTicks[i]+10),
            "all full-capacity matches advance during repeated concurrent UDP bursts");
        var soakClock=System.Diagnostics.Stopwatch.StartNew();
        ulong[] soakStartTicks=(ulong[])lastBurstTicks.Clone();
        var pollMillis=new List<double>();
        int soakRounds=0;
        while(soakClock.Elapsed<TimeSpan.FromSeconds(8))
        {
            var roundClock=System.Diagnostics.Stopwatch.StartNew();
            var replies=await Task.WhenAll(Enumerable.Range(0,multiGrants.Length)
                .Select(MultiPollWithRetry));
            roundClock.Stop();
            pollMillis.Add(roundClock.Elapsed.TotalMilliseconds);
            for(int i=0;i<replies.Length;i++)
            {
                Check(replies[i].Snapshot.Phase==BattlePhase.Running &&
                      replies[i].Snapshot.ServerTick>=lastBurstTicks[i],
                    "sustained full-capacity UDP poll preserves live monotonic match state");
                lastBurstTicks[i]=replies[i].Snapshot.ServerTick;
            }
            soakRounds++;
            await Task.Delay(100);
        }
        double soakSeconds=soakClock.Elapsed.TotalSeconds;
        pollMillis.Sort();
        double p95=pollMillis[(int)Math.Ceiling(pollMillis.Count*.95)-1];
        Check(soakRounds>=30 && Enumerable.Range(0,multiGrants.Length).All(i=>
              lastBurstTicks[i]-soakStartTicks[i]>=soakSeconds*20),
            "all 32 matches sustain at least 20 server ticks per second under periodic UDP polling");
        Check(p95<1000,"full-capacity loopback poll-round p95 stays below one second");
        Console.WriteLine($"Full-capacity UDP: {soakRounds} x 32 poll rounds over {soakSeconds:F2}s, " +
            $"round p95 {p95:F1}ms, max {pollMillis[^1]:F1}ms");
        for(int i=0;i<multiGrants.Length;i++)
        {
            var grant=multiGrants[i][0];
            byte[] key=grant.SessionKey.ToByteArray();
            var forged=new Packet {Version=1,SessionId=grant.SessionId,Sequence=100000,
                MatchCommand=Poll()};
            byte[] payload=forged.ToByteArray().Concat(new byte[]{0x98,0x06,0x01}).ToArray();
            byte[] malformed=payload.Concat(HMACSHA256.HashData(key,payload)).ToArray();
            Check(PacketCodec.Authenticate(malformed,key) && PacketCodec.ReadUntrusted(malformed)==null,
                "full-capacity malformed burst uses valid MAC but unknown outer protobuf field");
            for(int repeat=0;repeat<8;repeat++)
                await multiPeers[i*2].SendAsync(malformed,new IPEndPoint(IPAddress.Loopback,port));
        }
        var afterMalformed=await Task.WhenAll(Enumerable.Range(0,multiGrants.Length)
            .Select(i=>MultiExchange(multiGrants[i][0],multiPeers[i*2],Poll())));
        Check(afterMalformed.All(reply=>reply.Snapshot.Phase==BattlePhase.Running &&
              reply.Snapshot.Players.All(player=>player.LastCommandId==1)),
            "malformed full-capacity traffic cannot consume replay or match command state");
        using(var floodingPeer=new UdpClient(new IPEndPoint(IPAddress.Loopback,0)))
        {
            var grant=multiGrants[0][0];
            byte[] key=grant.SessionKey.ToByteArray();
            var forged=new Packet {Version=1,SessionId=grant.SessionId,Sequence=100001,
                MatchCommand=Poll()};
            byte[] payload=forged.ToByteArray().Concat(new byte[]{0x98,0x06,0x01}).ToArray();
            byte[] floodDatagram=payload.Concat(HMACSHA256.HashData(key,payload)).ToArray();
            var floodTask=Task.Run(async()=>
            {
                for(int n=0;n<4096;n++)
                {
                    await floodingPeer.SendAsync(floodDatagram,new IPEndPoint(IPAddress.Loopback,port));
                    if((n&15)==15)await Task.Delay(1);
                }
            });
            await Task.Delay(10);
            var survivors=await Task.WhenAll(Enumerable.Range(0,multiGrants.Length)
                .Select(MultiPollWithRetry));
            await floodTask;
            Check(survivors.All(reply=>reply.Snapshot.Phase==BattlePhase.Running &&
                  reply.Snapshot.Players.All(player=>player.LastCommandId==1)),
                "one malformed UDP sender cannot starve 32 admitted peers or mutate commands");
        }
        var floodPeers=Enumerable.Range(0,64)
            .Select(_=>new UdpClient(new IPEndPoint(IPAddress.Loopback,0))).ToArray();
        try
        {
            var grant=multiGrants[0][0];
            byte[] key=grant.SessionKey.ToByteArray();
            var forged=new Packet {Version=1,SessionId=grant.SessionId,Sequence=100002,
                MatchCommand=Poll()};
            byte[] payload=forged.ToByteArray().Concat(new byte[]{0x98,0x06,0x01}).ToArray();
            byte[] malformedDatagram=payload.Concat(HMACSHA256.HashData(key,payload)).ToArray();
            var senders=floodPeers.Select(peer=>Task.Run(async()=>
            {
                for(int n=0;n<64;n++)
                {
                    await peer.SendAsync(malformedDatagram,new IPEndPoint(IPAddress.Loopback,port));
                    if((n&7)==7)await Task.Delay(1);
                }
            })).ToArray();
            await Task.Delay(10);
            var survivors=await Task.WhenAll(Enumerable.Range(0,multiGrants.Length)
                .Select(MultiPollWithRetry));
            await Task.WhenAll(senders);
            Check(survivors.All(reply=>reply.Snapshot.Phase==BattlePhase.Running &&
                  reply.Snapshot.Players.All(player=>player.LastCommandId==1)),
                "64 malformed UDP senders cannot fill the Worker queue or mutate 32 matches");
        }
        finally {foreach(var peer in floodPeers)peer.Dispose();}
        var unknownPeers=Enumerable.Range(0,64)
            .Select(_=>new UdpClient(new IPEndPoint(IPAddress.Loopback,0))).ToArray();
        try
        {
            byte[] unknownKey=Enumerable.Repeat((byte)0x5a,32).ToArray();
            var sends=unknownPeers.Select((peer,index)=>Task.Run(async()=>
            {
                var packet=new Packet {Version=1,SessionId=0x9000000000000000UL+(ulong)index,
                    Sequence=1,MatchCommand=Poll()};
                byte[] datagram=PacketCodec.Encode(packet,unknownKey);
                for(int n=0;n<64;n++)
                {
                    await peer.SendAsync(datagram,new IPEndPoint(IPAddress.Loopback,port));
                    if((n&7)==7)await Task.Delay(1);
                }
            })).ToArray();
            await Task.Delay(10);
            var survivors=await Task.WhenAll(Enumerable.Range(0,multiGrants.Length)
                .Select(MultiPollWithRetry));
            await Task.WhenAll(sends);
            Check(survivors.All(reply=>reply.Snapshot.Phase==BattlePhase.Running &&
                  reply.Snapshot.Players.All(player=>player.LastCommandId==1)),
                "64 valid-envelope unknown-session senders cannot crowd out 32 admitted matches");
        }
        finally {foreach(var peer in unknownPeers)peer.Dispose();}
        var stolenKeyPeers=Enumerable.Range(0,64)
            .Select(_=>new UdpClient(new IPEndPoint(IPAddress.Loopback,0))).ToArray();
        try
        {
            var grant=multiGrants[0][0];
            byte[] datagram=PacketCodec.Encode(new Packet {Version=1,
                SessionId=grant.SessionId,Sequence=100005,MatchCommand=Poll()},
                grant.SessionKey.ToByteArray());
            var sends=stolenKeyPeers.Select(peer=>Task.Run(async()=>
            {
                for(int n=0;n<64;n++)
                {
                    await peer.SendAsync(datagram,new IPEndPoint(IPAddress.Loopback,port));
                    if((n&7)==7)await Task.Delay(1);
                }
            })).ToArray();
            await Task.Delay(10);
            var survivors=await Task.WhenAll(Enumerable.Range(0,multiGrants.Length)
                .Select(MultiPollWithRetry));
            await Task.WhenAll(sends);
            Check(survivors.All(reply=>reply.Snapshot.Phase==BattlePhase.Running &&
                  reply.Snapshot.Players.All(player=>player.LastCommandId==1)),
                "64 wrong-endpoint senders with a valid match key cannot crowd out 32 matches");
        }
        finally {foreach(var peer in stolenKeyPeers)peer.Dispose();}
        {
            var noisyGrant=multiGrants[0][0];
            byte[] datagram=PacketCodec.Encode(new Packet {Version=1,
                SessionId=noisyGrant.SessionId,Sequence=100006,MatchCommand=Poll()},
                noisyGrant.SessionKey.ToByteArray());
            var floodTask=Task.Run(async()=>
            {
                for(int n=0;n<4096;n++)
                {
                    await multiPeers[0].SendAsync(datagram,new IPEndPoint(IPAddress.Loopback,port));
                    if((n&15)==15)await Task.Delay(1);
                }
            });
            await Task.Delay(10);
            var survivorTasks=Enumerable.Range(1,multiGrants.Length-1)
                .Select(MultiPollWithRetry).ToList();
            survivorTasks.Add(MultiExchange(multiGrants[0][1],multiPeers[1],Poll()));
            var survivors=await Task.WhenAll(survivorTasks);
            await floodTask;
            Check(survivors.All(reply=>reply.Snapshot.Phase==BattlePhase.Running &&
                  reply.Snapshot.Players.All(player=>player.LastCommandId==1)),
                "an admitted endpoint flood cannot starve its opponent or 31 other matches");
        }
        await Task.Delay(100);
        var metrics=multiWorker.Metrics;
        Check(metrics.Ready && metrics.Received>metrics.Handled &&
              metrics.Handled>0 && metrics.MalformedDrops>0 && metrics.UnownedDrops>0 &&
              metrics.Pending is >=0 and <=512 && metrics.TickBacklogs>=0,
            "Worker exposes bounded live UDP ingress, drop, queue and tick metrics");
        Check((await MultiExchange(multiGrants[0][1],multiPeers[1],
            new MatchCommand {CommandId=2,Forfeit=new ForfeitCommand()})).Snapshot is
                {Phase:BattlePhase.Ended,WinnerPlayerId:var multiWinner} && multiWinner==a,
            "one parallel UDP match ends for its own roster");
        for(int i=1;i<multiGrants.Length;i++)
            Check((await MultiExchange(multiGrants[i][0],multiPeers[i*2],Poll()))
                  .Snapshot.Phase==BattlePhase.Running,
                "unrelated live UDP matches remain running after one terminal result");
    }
    finally
    {
        foreach(var peer in multiPeers)peer.Dispose();
        await multiWorker.StopAsync(CancellationToken.None);
        if(Directory.Exists(multiOutboxPath))Directory.Delete(multiOutboxPath,true);
    }
}
await File.WriteAllTextAsync(manifestFile,JsonSerializer.Serialize(definition));
string shutdownOutboxPath=Path.Combine(Path.GetTempPath(),"war-shutdown-outbox-"+Guid.NewGuid().ToString("N"));
using(var shutdownWorker=new NetworkWorker(OutboxConfig(shutdownOutboxPath),logs.CreateLogger<NetworkWorker>()))
{
    await shutdownWorker.StartAsync(CancellationToken.None);
    for(int attempt=0;attempt<100 && !shutdownWorker.IsReady;attempt++)await Task.Delay(10);
    Check(shutdownWorker.IsReady,"shutdown test worker reached UDP-bound readiness");
    Check((await shutdownWorker.RegisterMatch(definition,CancellationToken.None)).Code=="existing-match",
        "shutdown test worker reached its single-writer control loop");
    await shutdownWorker.StopAsync(CancellationToken.None);
    Check((await shutdownWorker.RegisterMatch(definition,CancellationToken.None)
            .WaitAsync(TimeSpan.FromSeconds(1))).Code=="control-unavailable" &&
          (await shutdownWorker.RegisterReconnect(definition.MatchId,a,Guid.NewGuid().ToString("N"),CancellationToken.None)
            .WaitAsync(TimeSpan.FromSeconds(1))).Code=="control-unavailable" &&
          (await shutdownWorker.CancelMatchBeforeStart(definition.MatchId,CancellationToken.None)
            .WaitAsync(TimeSpan.FromSeconds(1))).Code=="control-unavailable",
        "stopped Worker rejects all control operations promptly");
}
Check(new TerminalOutbox(shutdownOutboxPath).Pending().Single() is
    {Phase:BattlePhase.Aborted,TerminalReason:"host-shutdown",RewardEligible:false,WinnerPlayerId:""},
    "controlled worker stop persists unscored active-allocation evidence before exit");
string drainOutboxPath=Path.Combine(Path.GetTempPath(),"war-control-drain-"+Guid.NewGuid().ToString("N"));
using(var drainWorker=new NetworkWorker(OutboxConfig(drainOutboxPath),logs.CreateLogger<NetworkWorker>()))
{
    await drainWorker.StartAsync(CancellationToken.None);
    for(int attempt=0;attempt<100 && !drainWorker.IsReady;attempt++)await Task.Delay(10);
    Check(drainWorker.IsReady,"control-drain Worker reached UDP-bound readiness");
    var queued=Enumerable.Range(0,12).Select(i=>drainWorker.RegisterMatch(
        definition with {MatchId="drain-"+i},CancellationToken.None)).ToArray();
    await drainWorker.StopAsync(CancellationToken.None);
    var outcomes=await Task.WhenAll(queued).WaitAsync(TimeSpan.FromSeconds(2));
    Check(outcomes.All(result=>result.Code is "registered" or "control-unavailable"),
        "shutdown resolves every queued match allocation without stranding callers");
}
Directory.Delete(drainOutboxPath,true);
Reject(()=>new NetworkWorker(OutboxConfig(shutdownOutboxPath),logs.CreateLogger<NetworkWorker>()),
    "startup refuses a configured match ID already closed in the outbox");
File.Delete(manifestFile);
// Portable production SDK through a lossy UDP proxy. The server applies the shot
// before its response is deliberately dropped; SDK retry must not fire twice.
await File.WriteAllTextAsync(manifestFile, JsonSerializer.Serialize(definition));
string sdkOutboxPath=Path.Combine(Path.GetTempPath(),"war-sdk-outbox-"+Guid.NewGuid().ToString("N"));
using var sdkWorker = new NetworkWorker(OutboxConfig(sdkOutboxPath), logs.CreateLogger<NetworkWorker>());
using var proxy = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
using var proxyStop = new CancellationTokenSource();
var sdkServer = new IPEndPoint(IPAddress.Loopback, port);
int proxyPort = ((IPEndPoint)proxy.Client.LocalEndPoint!).Port;
bool dropped = false;
int reorderPoll=0;
byte[]? delayedPollReply=null;
Task relay = Task.Run(async () =>
{
    IPEndPoint? client = null;
    try
    {
        while (!proxyStop.IsCancellationRequested)
        {
            var datagram = await proxy.ReceiveAsync(proxyStop.Token);
            if (datagram.RemoteEndPoint.Equals(sdkServer))
            {
                var packet = PacketCodec.ReadUntrusted(datagram.Buffer);
                if (!dropped && packet?.MatchReply?.Code == "shot-accepted") { dropped = true; continue; }
                if(reorderPoll==1 && packet?.MatchReply?.Code=="state")
                {delayedPollReply=datagram.Buffer;reorderPoll=2;continue;}
                if(reorderPoll==2 && packet?.MatchReply?.Code=="state" && delayedPollReply!=null)
                {
                    if(client!=null)
                    {
                        await proxy.SendAsync(datagram.Buffer,client,proxyStop.Token);
                        await proxy.SendAsync(delayedPollReply,client,proxyStop.Token);
                    }
                    delayedPollReply=null;reorderPoll=3;continue;
                }
                if (client != null) await proxy.SendAsync(datagram.Buffer, client, proxyStop.Token);
            }
            else { client = datagram.RemoteEndPoint; await proxy.SendAsync(datagram.Buffer, sdkServer, proxyStop.Token); }
        }
    }
    catch (OperationCanceledException) when (proxyStop.IsCancellationRequested) { }
});
MatchConnectionGrant Grant(MatchAdmission c, int endpointPort) => new()
{
    Host = "127.0.0.1", Port = (uint)endpointPort, Ticket = tokens.Sign(c), SessionKey = ByteString.CopyFrom(tokens.SessionKey(c)),
    SessionId = c.SessionId, MatchId = c.MatchId, PlayerId = c.PlayerId, ManifestHash = c.ManifestHash, ExpiresUnixSeconds = c.ExpiresUnixSeconds
};
var overlongSdkGrant=Grant(claimsA,proxyPort);
overlongSdkGrant.ExpiresUnixSeconds=MatchTokens.MaximumUnixSecond+1;
Reject(()=>new MatchConnection(overlongSdkGrant),
    "portable SDK refuses an unrepresentable admission expiry");
try
{
    await sdkWorker.StartAsync(CancellationToken.None);
    using var sdkA = new MatchConnection(Grant(claimsA, proxyPort));
    using var sdkB = new MatchConnection(Grant(Claims(b, 102), port));
    Check((await sdkA.ConnectAsync(CancellationToken.None)).Code == "admitted", "portable SDK admission A");
    Check((await sdkB.ConnectAsync(CancellationToken.None)).Code == "admitted", "portable SDK admission B");
    await sdkA.ReadyAsync(CancellationToken.None); await sdkB.ReadyAsync(CancellationToken.None);
    var deadline = DateTime.UtcNow.AddSeconds(4);
    while ((await sdkA.PollAsync(CancellationToken.None)).Snapshot.Phase != BattlePhase.Running && DateTime.UtcNow < deadline) await Task.Delay(100);
    var sdkShot = await sdkA.FireAsync(1, 2, 3, CancellationToken.None);
    Check(dropped && sdkShot.Code == "shot-accepted" && sdkShot.Snapshot.Players[0].ShotsFired == 1, "SDK recovered dropped shot response exactly once");
    reorderPoll=1;
    var reorderedPollReply=await sdkA.PollAsync(CancellationToken.None);
    Check(reorderedPollReply.Snapshot.Players[0].ShotsFired == 1,
        "SDK accepts the later poll reply without repeating the shot");
    Check(reorderPoll==3,
        "loss proxy delivered the newer poll reply before its delayed predecessor");
    Check((await sdkA.PollAsync(CancellationToken.None)).Snapshot.Players[0].ShotsFired == 1,
        "SDK ignores a reordered stale poll response on the next request");
    Check((await sdkB.ForfeitAsync(CancellationToken.None)).Snapshot.WinnerPlayerId == a, "SDK terminal projection");
}
finally
{
    proxyStop.Cancel(); await relay;
    await sdkWorker.StopAsync(CancellationToken.None);
    File.Delete(manifestFile);
}
var contentRoot = new DirectoryInfo(AppContext.BaseDirectory);
while (contentRoot != null && !File.Exists(Path.Combine(contentRoot.FullName, "content/recovered-battle-content.json"))) contentRoot = contentRoot.Parent;
if (contentRoot == null) throw new Exception("Recovered battle content artifact not found.");
string contentFile = Path.Combine(contentRoot.FullName, "content/recovered-battle-content.json");
string combatManifestFile=Path.Combine(contentRoot.FullName,"content/combat-content-manifest.json");
var allocatorRifles=BattleRifleManifestCatalog.Load(combatManifestFile);
var workerRifles=BattleCombatContent.Load(combatManifestFile);
var allocatorTemplate=(JsonObject)JsonNode.Parse(await File.ReadAllTextAsync(Path.Combine(contentRoot.FullName,"content/local-rifle-match-template.json")))!;
allocatorRifles.ValidateTemplate(allocatorTemplate);
var allocatorParticipant=allocatorTemplate["Players"]![0]!.AsObject();
var famasView=BattlePlayerPresentation.Validate(new BattlePlayerPresentation(a,"Alpha",1,100,10,5,1,"1-local","US",false,
    new[]{"CAMO_DEFAULT","HELMET_DEFAULT","HEAD_DEFAULT","BANDS_DEFAULT"},
    new[]{new BattleWeaponPresentation(0,1,"Google2u.AssaultRifle_Famas",55)},
    new[]{new BattleUnitPresentation("Google2u.DBUpgradeSlotsRifleman",0,-1,-1,0)}));
allocatorRifles.Bind(allocatorParticipant,famasView);
var allocatedWeapon=JsonSerializer.Deserialize<WeaponManifest>(allocatorParticipant["Weapon"]!.ToJsonString())!;
Check(allocatedWeapon==workerRifles.Stats.CreateManifest("Google2u.AssaultRifle_Famas",55) &&
      allocatorParticipant["WeaponUpgrade"]!.GetValue<int>()==55,
      "backend allocator and Worker derive the same durable equipped rifle stage");
Reject(()=>allocatorRifles.Bind(allocatorParticipant,BattlePlayerPresentation.Validate(new BattlePlayerPresentation(a,"Alpha",1,100,10,5,1,"1-local","US",false,
    new[]{"CAMO_DEFAULT","HELMET_DEFAULT","HEAD_DEFAULT","BANDS_DEFAULT"},
    new[]{new BattleWeaponPresentation(0,1,"Google2u.Shotgun_SPAS",0)},Array.Empty<BattleUnitPresentation>()))),
    "rifle allocator rejects unsupported equipped weapon");
var wrongRevision=(JsonObject)allocatorTemplate.DeepClone();wrongRevision["CatalogRevision"]=new string('0',64);
Reject(()=>allocatorRifles.ValidateTemplate(wrongRevision),"rifle allocator rejects template package mismatch");
checks += ShieldLifecycleTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += ShotgunCatalogTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += SmgCatalogTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += SmgBurstTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += LiveSmgTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += await LiveSmgTests.RunUdp(Path.Combine(contentRoot.FullName,"content"));
checks += PistolCatalogTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += LmgCatalogTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += MinigunCatalogTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += await MinigunCatalogTests.RunUdp(Path.Combine(contentRoot.FullName,"content"));
checks += SniperCatalogTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += await SniperCatalogTests.RunUdp(Path.Combine(contentRoot.FullName,"content"));
checks += BazookaCatalogTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += await BazookaCatalogTests.RunUdp(Path.Combine(contentRoot.FullName,"content"));
checks += GrenadeCatalogTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += await GrenadeCatalogTests.RunUdp(Path.Combine(contentRoot.FullName,"content"));
checks += ArmyFlameBurstTests.Run();
checks += CombatContentTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += BarrelOverlapReferenceTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += BarrelChainTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += PlayerExplosionOverlapReferenceTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += LiveShotgunTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += await LiveShotgunTests.RunUdp(Path.Combine(contentRoot.FullName,"content"));
checks += await LiveShotgunTests.RunOvertimeUdp(Path.Combine(contentRoot.FullName,"content"));
checks += await LiveBarrelUdpTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += await LiveRusherUdpTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += LiveRifleTests.Run(Path.Combine(contentRoot.FullName,"content"));
checks += await LiveRifleTests.RunUdp(Path.Combine(contentRoot.FullName,"content"));
checks += RifleStatTests.Run(contentFile);
checks += PlayerAimTests.RunUnityReference(Path.Combine(contentRoot.FullName,"content/recovered-aim-reference.json"));
checks += RifleCoverTests.RunUnityQueue(Path.Combine(contentRoot.FullName,"content/unity-animation-queue-reference.json"));
checks += RigBlendTests.Run(Path.Combine(contentRoot.FullName,"content/recovered-rig-blend-reference.json"));
checks += WalkingShotTests.Run(Path.Combine(contentRoot.FullName,"content/recovered-walking-shot-reference.json"));
var maps = RecoveredBattleMap.Load(contentFile);
Check(maps.Count == 5 && maps.Sum(m => m.PathCount) == 60, "complete recovered map/path identity set");
var aztec = maps.Single(m => m.Source.EndsWith("Aztec_Multiplayer.unity", StringComparison.Ordinal));
checks += PlayerCollisionTests.Run(Path.Combine(contentRoot.FullName, "content/recovered-player-collision.json"), aztec);
checks += PlayerPoseTests.Run(Path.Combine(contentRoot.FullName, "content/recovered-player-poses.json"),
    PlayerCollisionModel.Load(Path.Combine(contentRoot.FullName, "content/recovered-player-collision.json"))[0].SourceHash);
var mappedDefinition = definition with
{
    MapId = "Aztec_Multiplayer", MapRevision = aztec.SourceHash,
    Players = [new(a, original.Weapon, 2, 5, 1), new(b, original.Weapon, 1, 1, 1)]
};
var mapped = new MatchEngine(mappedDefinition, aztec);
mapped.Admit(a); mapped.Admit(b); mapped.Command(a, Ready(1, mapped.ManifestHash)); mapped.Command(b, Ready(1, mapped.ManifestHash)); mapped.Advance(60);
Check(mapped.Snapshot().Players[0].CoverIndex == 5, "manifest binds actual source start cover");
var move = mapped.Command(a, new MatchCommand { CommandId = 2, MoveCover = new MoveCoverCommand { Direction = 1 } });
Check(move.Code == "moving" && move.Snapshot.Players[0].Moving, "source adjacent cover command");
Check(mapped.Command(a, Fire(3)).Code == "moving", "no shot while moving");
mapped.Advance(60);
Check(mapped.Snapshot().Players[0].PositionX == aztec.Covers[5].Position.X, "deferred movement has no unsigned clock underflow");
mapped.Advance(move.Snapshot.Players[0].MoveEndTick);
Check(mapped.Snapshot().Players[0].CoverIndex == 6 && !mapped.Snapshot().Players[0].Moving, "server finishes recovered path");
Check(mapped.Command(a, new MatchCommand { CommandId = 4, MoveCover = new MoveCoverCommand { Direction = 2 } }).Code == "cover-unavailable", "invalid cover direction");
Reject(() => new MatchEngine(mappedDefinition with { MapRevision = hash }, aztec), "map revision binding");
Reject(() => new MatchEngine(mappedDefinition with { Players = [new(a, original.Weapon, 1, 5, 1), mappedDefinition.Players[1]] }, aztec), "cannot use opponent cover");
Check(mapped.Command(a, Fire(5)).Code == "shot-accepted", "mapped geometry fire query");
Check(PacketCodec.Encode(new Packet { Version = 1, SessionId = 101, Sequence = 1, MatchReply = mapped.Reply(5, "shot-accepted") }, tokens.SessionKey(claimsA)).Length <= 1200, "mapped snapshot remains inside MTU");
using (var content = JsonDocument.Parse(await File.ReadAllTextAsync(contentFile)))
{
    Vector3 ReadVector(JsonElement value) => new(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
    Check(maps.Sum(m=>m.DynamicColliders.Count)==87 &&
          maps.Sum(m=>m.DynamicColliders.Count(c=>c.DynamicOwner.EndsWith("/riot_shield",StringComparison.Ordinal)))==40 &&
          maps.Sum(m=>m.DynamicColliders.Count(c=>c.DynamicOwner.Split('/').Last().StartsWith("barrel",StringComparison.OrdinalIgnoreCase)))==29,
          "all five source maps retain 87 dynamic colliders, including 40 shields and 29 barrels");
    foreach (var map in maps)
    {
        foreach (var node in map.Covers)
        {
            foreach (int direction in new[] { -1, 1 })
            {
                int adjacent = map.Adjacent(node.SourceIndex, direction, node.Fraction);
                if (adjacent >= 0)
                {
                    var route = map.Path(node.SourceIndex, adjacent);
                    Check(route.Length >= 2 && map.Covers[adjacent].Fraction == node.Fraction, "source cover adjacency/path");
                    route[0] = new Vector3(999,999,999);
                    Check(map.Path(node.SourceIndex, adjacent)[0] != route[0], "navigation cannot mutate authority");
                }
            }
        }
        var sourceMap = content.RootElement.GetProperty("maps").EnumerateArray().Single(m => m.GetProperty("source").GetString() == map.Source);
        var dynamicColliders=map.DynamicColliders;
        var sourceColliders=sourceMap.GetProperty("colliders");
        Check(dynamicColliders.Count>0 && dynamicColliders.Select(c=>c.ColliderIndex).Distinct().Count()==dynamicColliders.Count,
            "active dynamic colliders have unique map-scoped source indexes");
        foreach(var collider in dynamicColliders)
        {
            var row=sourceColliders[collider.ColliderIndex];
            Check(row.GetProperty("path").GetString()==collider.SourcePath &&
                row.GetProperty("dynamicOwner").GetString()==collider.DynamicOwner &&
                row.GetProperty("layer").GetInt32()==collider.Layer &&
                Vector3.Distance(collider.TransformPosition,new Vector3(
                    row.GetProperty("matrix")[12].GetSingle(),row.GetProperty("matrix")[13].GetSingle(),
                    row.GetProperty("matrix")[14].GetSingle()))<.00001f &&
                row.GetProperty("enabled").GetBoolean() && row.GetProperty("active").GetBoolean() &&
                !row.GetProperty("trigger").GetBoolean(),"dynamic collider identity binds to its exact source row");
            Check(float.IsFinite(collider.TransformPosition.X) &&
                collider.BoundsMin.X<=collider.BoundsMax.X && collider.BoundsMin.Y<=collider.BoundsMax.Y &&
                collider.BoundsMin.Z<=collider.BoundsMax.Z,
                "source dynamic collider retains finite world transform and bounds");
            var center=(collider.BoundsMin+collider.BoundsMax)/2;
            var candidates=map.DynamicSphereCandidates(center,.01f,1u<<collider.Layer);
            Check(candidates.Any(c=>c.Collider.ColliderIndex==collider.ColliderIndex && c.BoundsDistance==0),
                "sphere broadphase includes the exact source collider when centered on its bounds");
            Check(!map.DynamicSphereCandidates(center,.01f,1u<<collider.Layer,
                index=>index!=collider.ColliderIndex).Any(c=>c.Collider.ColliderIndex==collider.ColliderIndex),
                "sphere broadphase suppresses only the selected source collider index");
        }
        Reject(()=>map.DynamicSphereCandidates(Vector3.Zero,float.NaN),"nonfinite explosion radius accepted");
        if(map.Source.Contains("Aztec_Multiplayer",StringComparison.Ordinal))
            Check(dynamicColliders.Where(c=>c.DynamicOwner.EndsWith("/barrelAztec",StringComparison.Ordinal))
                  .Select(c=>c.ColliderIndex).Distinct().Count()==3,
                  "three Aztec barrels sharing one hierarchy path retain distinct collider identities");
        foreach (var ray in sourceMap.GetProperty("validationRays").EnumerateArray())
        {
            var hit = map.Raycast(ReadVector(ray.GetProperty("origin")), ReadVector(ray.GetProperty("direction")), ray.GetProperty("distance").GetSingle());
            bool expectedHit = ray.GetProperty("hit").GetBoolean();
            Check((hit != null) == expectedHit && (!expectedHit || Math.Abs(hit!.Distance - ray.GetProperty("hitDistance").GetSingle()) < 0.002f), "Unity physics parity: " + map.Source + " expected " + ray.GetProperty("hitDistance") + " actual " + hit?.Distance);
            if(hit!=null)Check(hit.ColliderIndex>=0 && hit.ColliderIndex<sourceColliders.GetArrayLength() &&
                sourceColliders[hit.ColliderIndex].GetProperty("path").GetString()==hit.SourcePath,
                "ray hit identifies one exact serialized collider");
            if(hit?.DynamicOwner!=null)
            {
                var without=map.Raycast(ReadVector(ray.GetProperty("origin")),ReadVector(ray.GetProperty("direction")),
                    ray.GetProperty("distance").GetSingle(),colliderEnabled:i=>i!=hit.ColliderIndex);
                Check(without?.ColliderIndex!=hit.ColliderIndex,
                    "one dynamic collider can be disabled without hiding another instance with its path");
            }
        }
    }
}
Console.WriteLine($"PASS: {checks} battle engine, admission, portable SDK, map geometry and real two-peer UDP assertions");

if(args.Length==3 && args[0]=="--unity-rifle")
    await LiveRifleTests.RunUnity(Path.Combine(contentRoot.FullName,"content"),args[1],args[2]);

if (args.Length == 3 && args[0] == "--unity")
{
    var unityDefinition = definition with { AdmissionSeconds = 120 };
    await File.WriteAllTextAsync(manifestFile, JsonSerializer.Serialize(unityDefinition));
    string grantsFile = Path.Combine(Path.GetTempPath(), "war-grants-" + Guid.NewGuid().ToString("N") + ".jsonl");
    string unityLog = Path.GetFullPath("Server/.local/unity-battle-sdk.log");
    Directory.CreateDirectory(Path.GetDirectoryName(unityLog)!);
    MatchConnectionGrant UnityGrant(string id, ulong session)
    {
        var claims = Claims(id, session);
        claims.ManifestHash = new MatchEngine(unityDefinition).ManifestHash;
        claims.IssuedUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        claims.ExpiresUnixSeconds = claims.IssuedUnixSeconds + 120;
        return Grant(claims, port);
    }
    await File.WriteAllLinesAsync(grantsFile, [JsonFormatter.Default.Format(UnityGrant(a, 201)), JsonFormatter.Default.Format(UnityGrant(b, 202))]);
    string unityOutboxPath=Path.Combine(Path.GetTempPath(),"war-unity-outbox-"+Guid.NewGuid().ToString("N"));
    using var unityWorker = new NetworkWorker(OutboxConfig(unityOutboxPath), logs.CreateLogger<NetworkWorker>());
    System.Diagnostics.Process? editor = null;
    try
    {
        await unityWorker.StartAsync(CancellationToken.None);
        var start = new System.Diagnostics.ProcessStartInfo(args[1])
        {
            UseShellExecute = false, CreateNoWindow = true, WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
        };
        foreach (var argument in new[] { "-batchmode", "-nographics", "-projectPath", args[2], "-executeMethod", "SelfHostedBattleAudit.Run", "-logFile", unityLog }) start.ArgumentList.Add(argument);
        start.Environment["WAR_BATTLE_GRANTS_FILE"] = grantsFile;
        editor = System.Diagnostics.Process.Start(start) ?? throw new Exception("Unity did not start.");
        using var unityTimeout = new CancellationTokenSource(TimeSpan.FromSeconds(110));
        await editor.WaitForExitAsync(unityTimeout.Token);
        Check(editor.ExitCode == 0 && (await File.ReadAllTextAsync(unityLog)).Contains("UNITY_BATTLE_SDK_PASSED"), "actual Unity Mono SDK audit");
        Console.WriteLine("PASS: actual Unity Mono battle SDK; log " + unityLog);
    }
    finally
    {
        if (editor != null) { if (!editor.HasExited) editor.Kill(true); editor.Dispose(); }
        await unityWorker.StopAsync(CancellationToken.None);
        File.Delete(grantsFile); File.Delete(manifestFile);
        Directory.Delete(unityOutboxPath,true);
    }
}
Directory.Delete(workerOutboxPath,true);
Directory.Delete(sdkOutboxPath,true);
