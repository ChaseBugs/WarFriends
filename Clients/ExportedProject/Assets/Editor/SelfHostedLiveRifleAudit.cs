using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;
using War.Protocol;

// Runs against a separate disposable Unity project and a live .NET UDP Worker.
public static class SelfHostedLiveRifleAudit
{
    private static Task audit;
    private static double deadline;
    public static void Run()
    {
        string path=Environment.GetEnvironmentVariable("WAR_RIFLE_LIVE_GRANTS_FILE");
        if(string.IsNullOrEmpty(path))throw new InvalidOperationException("Set WAR_RIFLE_LIVE_GRANTS_FILE.");
        string[] lines=File.ReadAllLines(path);
        if(lines.Length!=2)throw new InvalidOperationException("Expected two signed grants.");
        var first=JsonParser.Default.Parse<MatchConnectionGrant>(lines[0]);
        var second=JsonParser.Default.Parse<MatchConnectionGrant>(lines[1]);
        deadline=EditorApplication.timeSinceStartup+65;
        audit=Check(first,second);
        EditorApplication.update+=Update;
    }
    private static async Task Check(MatchConnectionGrant local,MatchConnectionGrant peer)
    {
        GameObject owner=null,left=null,right=null;
        try
        {
            var scene=EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            var original=scene.GetRootGameObjects().SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
            bool wasActive=original.gameObject.activeSelf;
            original.gameObject.SetActive(false);
            left=UnityEngine.Object.Instantiate(original.gameObject);right=UnityEngine.Object.Instantiate(original.gameObject);
            left.name="SelfHostedLeft";right.name="SelfHostedRight";
            foreach(var clone in new[] {left,right})
            {
                foreach(var behaviour in clone.GetComponentsInChildren<MonoBehaviour>(true))behaviour.enabled=false;
                clone.SetActive(true);
            }
            original.gameObject.SetActive(wasActive);
            owner=new GameObject("SelfHostedLiveRifleAudit");
            var adapter=owner.AddComponent<SelfHostedBattleClient>();
            var leftPlayer=left.GetComponent<PlayerController>();var rightPlayer=right.GetComponent<PlayerController>();
            var leftAnimator=left.GetComponentInChildren<SoldierAnimationController>(true);
            var rightAnimator=right.GetComponentInChildren<SoldierAnimationController>(true);
            using(var ct=new CancellationTokenSource(TimeSpan.FromSeconds(45)))
            using(var other=new MatchConnection(peer))
            {
                await adapter.Connect(local);
                await other.ConnectAsync(ct.Token);
                leftPlayer.playerProperties=new PlayerProperties {playerID=local.PlayerId};
                rightPlayer.playerProperties=new PlayerProperties {playerID=peer.PlayerId};
                foreach(var pair in new[] {new {Player=leftPlayer,Grant=local},new {Player=rightPlayer,Grant=peer}})
                {
                    var inventory=pair.Player.ResolveSelfHostedInventory();
                    if(inventory==null || inventory.allWeapons==null || inventory.allWeapons.Count==0)
                        throw new InvalidOperationException("Recovered player has no weapon inventory.");
                    if(inventory.usedWeapons==null)inventory.usedWeapons=new System.Collections.Generic.List<PlayerWeapon>();
                    inventory.usedWeapons.Clear();
                    var view=pair.Grant.PlayerViews.Single(v=>v.PlayerId==pair.Grant.PlayerId);
                    foreach(var weaponView in view.Weapons)
                        if(weaponView.WeaponIndex<0 || weaponView.WeaponIndex>=inventory.allWeapons.Count ||
                           inventory.allWeapons[weaponView.WeaponIndex]==null)
                            throw new InvalidOperationException("Recovered weapon index is unavailable.");
                        else
                        {
                            inventory.allWeapons[weaponView.WeaponIndex].playerController=pair.Player;
                            inventory.usedWeapons.Add(inventory.allWeapons[weaponView.WeaponIndex]);
                        }
                }
                adapter.ActivateDeathMatchScene(leftPlayer,rightPlayer);
                if(leftPlayer.enabled || rightPlayer.enabled || leftAnimator.enabled || rightAnimator.enabled)
                    throw new InvalidOperationException("Production bridge retained a legacy scene writer.");
                await adapter.Ready();await other.ReadyAsync(ct.Token);
                while(adapter.State.Phase!=BattlePhase.Running)
                {
                    await Task.Delay(100,ct.Token);await adapter.Refresh();
                }
                if(left.transform.position==right.transform.position || !left.activeInHierarchy || !right.activeInHierarchy ||
                    left.GetComponentsInChildren<Renderer>(true).Length==0 || right.GetComponentsInChildren<Renderer>(true).Length==0)
                    throw new InvalidOperationException("Two rendered rigs were not placed at distinct server covers.");
                await adapter.SwitchWeapon(2);
                var switchedState=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                if(switchedState.ActiveWeaponSlot!=2 || leftPlayer.weaponInventory.weaponIndex!=1 ||
                   leftPlayer.weaponInventory.currentWeapon!=leftPlayer.weaponInventory.usedWeapons[1])
                    throw new InvalidOperationException("Authoritative weapon switch did not select the recovered FAMAS rig.");
                int frames=0;
                adapter.StateReceived+=snapshot=>
                {
                    if(snapshot.Players.Any(p=>p.RiflePose==null))throw new InvalidOperationException("Missing live rifle pose.");
                    if(Vector3.Distance(left.transform.position,Position(snapshot,local.PlayerId))>.0001f ||
                        Vector3.Distance(right.transform.position,Position(snapshot,peer.PlayerId))>.0001f)
                        throw new InvalidOperationException("Rendered rig identity/cover mismatch.");
                    frames++;
                };
                ulong? firstTick=null;
                for(int attempt=0;attempt<24;attempt++)
                {
                    Vector3 localHead=Head(leftPlayer),remoteHead=Head(rightPlayer);
                    var response=await other.FireAsync(localHead.x,localHead.y,localHead.z,ct.Token);
                    if(!firstTick.HasValue)firstTick=response.Snapshot.Players.First(p=>p.PlayerId==peer.PlayerId).ShotsFired;
                    await Task.Delay(240,ct.Token);
                    await adapter.Fire(remoteHead);
                    if(adapter.State.Players.Any(p=>p.Health<1000))break;
                }
                if(!adapter.State.Players.Any(p=>p.Health<1000) ||
                    !adapter.State.Players.Any(p=>p.ConfirmedPlayerHits>0) || frames<2)
                    throw new InvalidOperationException("Live rendered rifle combat did not deliver damage and pose updates.");
                var leftState=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                var rightState=adapter.State.Players.Single(p=>p.PlayerId==peer.PlayerId);
                if(Math.Abs(leftPlayer.destroyableParts.health-leftState.Health)>.001f ||
                    Math.Abs(rightPlayer.destroyableParts.health-rightState.Health)>.001f)
                    throw new InvalidOperationException("Production bridge did not project authoritative health.");
                if(leftPlayer.weaponInventory==null || leftPlayer.weaponInventory.currentWeapon==null ||
                    leftPlayer.weaponInventory.currentWeapon.weapon.ammoLeftInClip!=leftState.ClipAmmo ||
                    leftPlayer.weaponInventory.currentWeapon.weapon.ammoLeft!=leftState.ReserveAmmo)
                    throw new InvalidOperationException("Production bridge did not project authoritative ammunition: actual="+
                        (leftPlayer.weaponInventory==null?"inventory-null":leftPlayer.weaponInventory.currentWeapon.weapon.ammoLeftInClip+"/"+
                        leftPlayer.weaponInventory.currentWeapon.weapon.ammoLeft)+" expected="+leftState.ClipAmmo+"/"+leftState.ReserveAmmo);
                adapter.enabled=false;
                bool failOnce=true;var handledEvents=new System.Collections.Generic.List<ulong>();
                adapter.CombatEventReceived+=item=>
                {
                    if(failOnce){failOnce=false;throw new InvalidOperationException("Injected presentation failure.");}
                    if(handledEvents.Count>0 && item.EventId!=handledEvents[handledEvents.Count-1]+1)
                        throw new InvalidOperationException("Unity event callback skipped an ID.");
                    handledEvents.Add(item.EventId);
                };
                bool retried=false;
                try{await adapter.DispatchEvents();}catch(InvalidOperationException e)
                {retried=e.Message=="Injected presentation failure.";}
                if(!retried || adapter.ProcessedEventId!=0)
                    throw new InvalidOperationException("Failed presentation handler acknowledged an event.");
                for(int page=0;page<32;page++)if(await adapter.DispatchEvents()==0)break;
                if(handledEvents.Count==0 || handledEvents[0]!=1 ||
                    adapter.ProcessedEventId!=handledEvents[handledEvents.Count-1])
                    throw new InvalidOperationException("Unity adapter did not replay and deliver host-owned events.");
                ulong beforeMoveEvents=adapter.ProcessedEventId;
                adapter.enabled=true;
                var origin=left.transform.position;
                await adapter.MoveCover(1);
                if(!adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId).Moving)
                    throw new InvalidOperationException("Source cover move was not admitted.");
                bool observedRun=false,observedWalkingShot=false;
                while(adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId).Moving)
                {
                    if(!observedWalkingShot)await adapter.Fire(Head(rightPlayer));
                    await Task.Delay(100,ct.Token);await adapter.Refresh();
                    var current=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                    if(current.Moving && Vector3.Distance(origin,left.transform.position)>.01f)
                    {
                        if(current.RiflePose.Layers.Count!=1 || current.RiflePose.Layers[0].Clip!=RiflePoseClip.QbzRun)
                            throw new InvalidOperationException("Switched FAMAS rig did not receive its source run pose.");
                        observedRun=true;
                        if(current.RiflePose.UpperBodyLayer!=null && current.RiflePose.UpperBodyLayer.Weight>0)
                            observedWalkingShot=true;
                    }
                }
                // Editor batch mode does not run MonoBehaviour.Update; dispatch
                // explicitly while retaining the same production callback path.
                await adapter.DispatchEvents();
                if(!observedRun || !observedWalkingShot || Vector3.Distance(origin,left.transform.position)<.1f ||
                    adapter.ProcessedEventId<=beforeMoveEvents)
                    throw new InvalidOperationException("Live moving rig did not deliver its walking shot event.");
                Debug.Log("UNITY_LIVE_RIFLE_PASSED renderedRigs=2 movingRun=True walkingShot=True frames="+frames+" health="+
                    string.Join(",",adapter.State.Players.Select(p=>p.Health.ToString("F2"))));
            }
        }
        finally
        {
            if(owner!=null)UnityEngine.Object.DestroyImmediate(owner);
            if(left!=null)UnityEngine.Object.DestroyImmediate(left);
            if(right!=null)UnityEngine.Object.DestroyImmediate(right);
            // This audit runs only in the disposable compile project. Scene
            // restoration from this async continuation recursively enters the
            // Unity 2018 PlayerLoop and can crash the editor before Run exits.
        }
    }
    private static Vector3 Position(MatchSnapshot snapshot,string id)
    {var p=snapshot.Players.Single(x=>x.PlayerId==id);return new Vector3(p.PositionX,p.PositionY,p.PositionZ);}
    private static Vector3 Head(PlayerController p)
    {
        var part=p.GetComponentsInChildren<DestroyableObjectpart>(true).Select(x=>x.GetComponent<Collider>()).OfType<SphereCollider>().Single();
        return part.transform.TransformPoint(part.center);
    }
    private static void Update()
    {
        if(!audit.IsCompleted&&EditorApplication.timeSinceStartup<deadline)return;
        EditorApplication.update-=Update;
        if(audit.IsCompleted&&!audit.IsFaulted&&!audit.IsCanceled)EditorApplication.Exit(0);
        else {Debug.LogError(audit.Exception==null?"Live rifle audit timed out":audit.Exception.ToString());EditorApplication.Exit(1);}
    }
}
