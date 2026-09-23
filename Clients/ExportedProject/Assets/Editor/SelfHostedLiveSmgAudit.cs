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

public static class SelfHostedLiveSmgAudit
{
    private static Task audit; private static double deadline;
    public static void Run()
    {
        string path=Environment.GetEnvironmentVariable("WAR_SMG_LIVE_GRANTS_FILE");
        if(string.IsNullOrEmpty(path))throw new InvalidOperationException("Set WAR_SMG_LIVE_GRANTS_FILE.");
        string[] lines=File.ReadAllLines(path);if(lines.Length!=2)throw new InvalidOperationException("Expected two grants.");
        deadline=EditorApplication.timeSinceStartup+65;
        audit=Check(JsonParser.Default.Parse<MatchConnectionGrant>(lines[0]),JsonParser.Default.Parse<MatchConnectionGrant>(lines[1]));
        EditorApplication.update+=Update;
    }
    private static async Task Check(MatchConnectionGrant local,MatchConnectionGrant peer)
    {
        GameObject owner=null,left=null,right=null;
        try
        {
            var scene=EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            var original=scene.GetRootGameObjects().SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
            bool active=original.gameObject.activeSelf;original.gameObject.SetActive(false);
            left=UnityEngine.Object.Instantiate(original.gameObject);right=UnityEngine.Object.Instantiate(original.gameObject);
            left.name="SelfHostedSmgLeft";right.name="SelfHostedSmgRight";
            foreach(var clone in new[]{left,right}){foreach(var b in clone.GetComponentsInChildren<MonoBehaviour>(true))b.enabled=false;clone.SetActive(true);}
            original.gameObject.SetActive(active);owner=new GameObject("SelfHostedLiveSmgAudit");
            var adapter=owner.AddComponent<SelfHostedBattleClient>();var lp=left.GetComponent<PlayerController>();var rp=right.GetComponent<PlayerController>();
            using(var ct=new CancellationTokenSource(TimeSpan.FromSeconds(45)))using(var other=new MatchConnection(peer))
            {
                await adapter.Connect(local);await other.ConnectAsync(ct.Token);
                lp.playerProperties=new PlayerProperties{playerID=local.PlayerId};rp.playerProperties=new PlayerProperties{playerID=peer.PlayerId};
                foreach(var pair in new[]{new{Player=lp,Grant=local},new{Player=rp,Grant=peer}})
                {
                    var inventory=pair.Player.ResolveSelfHostedInventory();inventory.usedWeapons.Clear();
                    var view=pair.Grant.PlayerViews.Single(v=>v.PlayerId==pair.Grant.PlayerId);
                    foreach(var weapon in view.Weapons)
                    {
                        var recovered=inventory.allWeapons[weapon.WeaponIndex];recovered.playerController=pair.Player;inventory.usedWeapons.Add(recovered);
                    }
                }
                adapter.ActivateDeathMatchScene(lp,rp);await adapter.Ready();await other.ReadyAsync(ct.Token);
                while(adapter.State.Phase!=BattlePhase.Running){await Task.Delay(80,ct.Token);await adapter.Refresh();}
                await adapter.SwitchWeapon(1);
                if(adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId).ActiveWeaponSlot!=1||
                   lp.weaponInventory.weaponIndex!=1||lp.weaponInventory.currentWeapon!=lp.weaponInventory.usedWeapons[1])
                    throw new InvalidOperationException("Cross-class rifle-to-CPW selection was not applied.");
                bool pistolPose=false;ulong initialShots=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId).ShotsFired;
                await adapter.Fire(Head(rp));
                for(int i=0;i<30;i++)
                {
                    await Task.Delay(50,ct.Token);await adapter.Refresh();
                    var state=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                    if(state.RiflePose.Layers.Any(x=>(int)x.Clip>=31&&(int)x.Clip<=36))pistolPose=true;
                    if(state.ShotsFired>=initialShots+3)break;
                }
                var burst=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                if(!pistolPose||burst.ShotsFired!=initialShots+3||
                   lp.weaponInventory.currentWeapon.weapon.ammoLeftInClip!=burst.ClipAmmo)
                    throw new InvalidOperationException("Recovered CPW pose/burst/ammunition was not rendered from authority.");
                await adapter.SwitchWeapon(2);var selected=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                if(selected.ActiveWeaponSlot!=2||lp.weaponInventory.weaponIndex!=2||
                   lp.weaponInventory.currentWeapon!=lp.weaponInventory.usedWeapons[2])
                    throw new InvalidOperationException("Authoritative P90 selection was not applied to the recovered inventory.");
                Vector3 origin=left.transform.position;await adapter.MoveCover(1);bool qbz2Run=false;
                while(adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId).Moving)
                {
                    await Task.Delay(70,ct.Token);await adapter.Refresh();
                    var state=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                    if(state.RiflePose.Layers.Any(x=>x.Clip==RiflePoseClip.Qbz2Run))qbz2Run=true;
                }
                if(!qbz2Run||Vector3.Distance(origin,left.transform.position)<.1f)
                    throw new InvalidOperationException("Recovered P90 run pose was not rendered during authoritative movement.");
                await adapter.SwitchWeapon(3);var pistol=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                if(pistol.ActiveWeaponSlot!=3||lp.weaponInventory.weaponIndex!=3||pistol.ReserveAmmo!=int.MaxValue)
                    throw new InvalidOperationException("Authoritative pistol selection/infinite reserve was not applied.");
                ulong beforePistol=pistol.ShotsFired;int beforeClip=pistol.ClipAmmo;await adapter.Fire(Head(rp));
                for(int i=0;i<30&&adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId).ShotsFired==beforePistol;i++)
                {await Task.Delay(50,ct.Token);await adapter.Refresh();}
                pistol=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                if(pistol.ShotsFired!=beforePistol+1||pistol.ClipAmmo!=beforeClip-1||pistol.ReserveAmmo!=int.MaxValue||
                   lp.weaponInventory.currentWeapon.weapon.ammoLeftInClip!=pistol.ClipAmmo)
                    throw new InvalidOperationException("Recovered pistol shot was not projected from host authority.");
                await adapter.SwitchWeapon(4);var lmg=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                if(lmg.ActiveWeaponSlot!=4||lp.weaponInventory.weaponIndex!=4)
                    throw new InvalidOperationException("Authoritative LMG selection was not applied.");
                ulong beforeLmg=lmg.ShotsFired;int lmgClip=lmg.ClipAmmo;bool lmgPose=false;await adapter.Fire(Head(rp));
                for(int i=0;i<40;i++)
                {
                    await Task.Delay(50,ct.Token);await adapter.Refresh();lmg=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                    if(lmg.RiflePose.Layers.Any(x=>(int)x.Clip>=20&&(int)x.Clip<=25))lmgPose=true;
                    if(lmg.ShotsFired>=beforeLmg+2)break;
                }
                if(!lmgPose||lmg.ShotsFired!=beforeLmg+2||lmg.ClipAmmo!=lmgClip-2||
                   lp.weaponInventory.currentWeapon.weapon.ammoLeftInClip!=lmg.ClipAmmo)
                    throw new InvalidOperationException("Recovered LMG two-round burst was not projected from host authority.");
                await adapter.SwitchWeapon(5);var minigun=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                var minigunController=lp.weaponInventory.currentWeapon as PlayerMinigunWeapon;
                if(minigun.ActiveWeaponSlot!=5||lp.weaponInventory.weaponIndex!=5||minigunController==null)
                    throw new InvalidOperationException("Authoritative minigun selection was not applied.");
                ulong beforeMinigun=minigun.ShotsFired;int minigunAmmo=minigun.ClipAmmo;bool minigunPose=false;
                await adapter.MinigunHold(true,Head(rp));
                for(int i=0;i<50;i++)
                {
                    await Task.Delay(50,ct.Token);await adapter.Refresh();minigun=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                    if(minigun.RiflePose.Layers.Any(x=>(int)x.Clip>=38&&(int)x.Clip<=45))minigunPose=true;
                    if(minigun.ShotsFired>=beforeMinigun+2)break;
                }
                if(!minigunPose||!minigun.MinigunHeld||minigun.ShotsFired<beforeMinigun+2||
                   minigun.ClipAmmo!=minigunAmmo-(int)(minigun.ShotsFired-beforeMinigun)||
                   minigunController.motor==null||!minigunController.motor.selfHostedMotorRequested)
                    throw new InvalidOperationException("Recovered minigun hold/pose/motor/ammunition was not projected from host authority: pose="+
                        minigunPose+" held="+minigun.MinigunHeld+" shots="+minigun.ShotsFired+"/"+beforeMinigun+
                        " ammo="+minigun.ClipAmmo+"/"+minigunAmmo+" motor="+(minigunController.motor!=null)+
                        " motorRequested="+(minigunController.motor!=null&&minigunController.motor.selfHostedMotorRequested));
                ulong stoppedAt=minigun.ShotsFired;await adapter.MinigunHold(false,Vector3.zero);
                for(int i=0;i<8;i++){await Task.Delay(50,ct.Token);await adapter.Refresh();}
                minigun=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                if(minigun.MinigunHeld||minigun.ShotsFired!=stoppedAt)
                    throw new InvalidOperationException("Recovered minigun release did not stop host fire.");
                await adapter.SwitchWeapon(6);var sniper=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                var sniperController=lp.weaponInventory.currentWeapon as PlayerZoomOnTouchWeapon;
                if(sniper.ActiveWeaponSlot!=6||lp.weaponInventory.weaponIndex!=6||sniperController==null)
                    throw new InvalidOperationException("Authoritative sniper selection was not applied.");
                ulong beforeSniper=sniper.ShotsFired;int sniperClip=sniper.ClipAmmo;bool sniperPose=false,scopeVisible=false;
                await adapter.SniperAim(true,false,Head(rp));
                for(int i=0;i<25;i++)
                {
                    await Task.Delay(40,ct.Token);await adapter.Refresh();sniper=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                    if(sniper.RiflePose.Layers.Any(x=>(int)x.Clip>=46&&(int)x.Clip<=53))sniperPose=true;
                    if(sniper.SniperScopeVisible){scopeVisible=true;break;}
                }
                if(!sniperPose||!sniper.SniperAiming||!scopeVisible)
                    throw new InvalidOperationException("Recovered sniper pose/scope gate was not projected from host authority.");
                await adapter.SniperAim(false,false,Vector3.zero);
                for(int i=0;i<12&&adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId).ShotsFired==beforeSniper;i++)
                {await Task.Delay(50,ct.Token);await adapter.Refresh();}
                sniper=adapter.State.Players.Single(p=>p.PlayerId==local.PlayerId);
                if(sniper.SniperAiming||sniper.SniperScopeVisible||sniper.ShotsFired!=beforeSniper+1||sniper.ClipAmmo!=sniperClip-1||
                   lp.weaponInventory.currentWeapon.weapon.ammoLeftInClip!=sniper.ClipAmmo)
                    throw new InvalidOperationException("Recovered sniper release/ammunition was not projected from host authority.");
                Debug.Log("UNITY_LIVE_SMG_PASSED crossClass=True cpwBurst=3 pistolPose=True p90Run=True pistolShot=True lmgBurst=2 minigunHold=True sniperRelease=True ammo="+sniper.ClipAmmo);
            }
        }
        finally
        {
            if(owner!=null)UnityEngine.Object.DestroyImmediate(owner);
            if(left!=null)UnityEngine.Object.DestroyImmediate(left);
            if(right!=null)UnityEngine.Object.DestroyImmediate(right);
        }
    }
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
        else{Debug.LogError(audit.Exception==null?"Live SMG audit timed out":audit.Exception.ToString());EditorApplication.Exit(1);}
    }
}
