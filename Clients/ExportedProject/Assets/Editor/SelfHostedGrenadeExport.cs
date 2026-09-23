using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class SelfHostedGrenadeExport
{
    public static void Run()
    {
        string output=Environment.GetEnvironmentVariable("WAR_GRENADE_OUTPUT");
        if(string.IsNullOrEmpty(output))throw new InvalidOperationException("Set WAR_GRENADE_OUTPUT.");
        const string source="Assets/Scenes/MainScene.unity",layerSource="Assets/GameObject/GlobalStorage.prefab";
        var scene=EditorSceneManager.OpenScene(source);var roots=scene.GetRootGameObjects();
        var layers=AssetDatabase.LoadAssetAtPath<GameObject>(layerSource).GetComponentsInChildren<TagsAndLayers>(true).Single();
        var player=roots.SelectMany(g=>g.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
        var inventory=player.GetComponentsInChildren<WeaponInventory>(true).Single();
        var levels=roots.SelectMany(g=>g.GetComponentsInChildren<LevelManager>(true)).Single();
        var rows=new List<object>();
        foreach(var setup in levels.GetComponentsInChildren<GrenadeLevelsSetup>(true))
        {
            var sourceComponent=setup.GetComponents<MonoBehaviour>().Single(c=>c!=null&&c.GetType().Namespace=="Google2u");
            string id=sourceComponent.GetType().FullName;
            if(id!="Google2u.GrenadeLauncher_M320"&&!id.StartsWith("Google2u.Grenade_",StringComparison.Ordinal))continue;
            int index=setup.indexInWeaponInventory;var controller=inventory.allWeapons[index];
            var weapon=controller==null?null:controller.GetComponent<Weapon>() as Grenade;
            var ammo=weapon==null?null:weapon.ammoSetup as GrenadeAmmoBaseSetup;
            var definition=setup.baseDefinition;
            var projectile=weapon==null?null:weapon.bulletPrefab as GrenadeAmmoBase;
            if(controller==null||weapon==null||ammo==null||definition==null||weapon.spawnPoint==null||projectile==null)
                throw new InvalidOperationException("Incomplete grenade binding "+id);
            var swipe=controller as PlayerSwipeWeapon;var click=controller as PlayerClickWeapon;
            if((id=="Google2u.GrenadeLauncher_M320")!=(click!=null)||id!="Google2u.GrenadeLauncher_M320"&&swipe==null)
                throw new InvalidOperationException("Unexpected grenade controller "+id);
            string prefab=AssetDatabase.GetAssetPath(weapon.bulletPrefab),guid;long fileId;
            if(!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(weapon.bulletPrefab,out guid,out fileId))
                throw new InvalidOperationException("Missing grenade projectile identity.");
            var explosive=ammo as GrenadeAmmoSetup;var flash=ammo as FlashGrenadeAmmoSetup;
            var poison=ammo as PoisonGrenadeAmmoSetup;var smoke=ammo as SmokeGrenadeAmmoSetup;
            rows.Add(new{id=id,inventoryIndex=index,setupPath=PathOf(setup.transform),playerWeaponType=controller.GetType().FullName,
                weaponType=weapon.GetType().FullName,weaponPath=PathOf(weapon.transform),muzzlePath=PathOf(weapon.spawnPoint),shootOffset=V(weapon.shootOffset),
                firstShotWaitTime=controller.firstShotWaitTime,animationFamily=(int)weapon.weaponType,reloadable=weapon.reloadableWeapon,
                infiniteAmmo=weapon.infiniteAmmo,friendKill=weapon.friendKill,shotType=(int)weapon.shotType,ignoreLayersMask=weapon.ignoreLayersMask,
                grenadeType=(int)weapon.grenadeTpe,damageToPlayerRatio=setup.damageToPlayerRatio,
                damageToPlayerRatioOvertime=setup.damageToPlayerRatioOvertime,damageToPlayerBehindShieldRatio=setup.damageToPlayerBehindShieldRatio,
                baseDeadRadius=definition.deadRadius,baseHurtRadius=definition.hurtradius,baseThrowDistance=definition.throwDistance,
                baseExplodeAfterTime=definition.explodeAfterTIme,ammoSetupType=ammo.GetType().FullName,
                angle=ammo.angle,throwDistance=ammo.throwDistance,explodeAfterTime=ammo.explodeAfterTime,
                damageAmount=(float)ammo.damageAmount,criticalProbability=(float)ammo.criticalProbability,criticalMultiplier=(float)ammo.criticalAmount,
                explosive=explosive==null?null:new{hurtRadius=explosive.hurtRadius,deadRadius=explosive.deadRadius,
                    explosionCoef=V(explosive.exposionCoef),additionalUpForce=explosive.additionalUpForce,explodeDamageAmount=(float)explosive.explodeDamageAmount},
                flash=flash==null?null:new{radius=flash.radius,lastTime=flash.lastTime},
                poison=poison==null?null:new{radius=poison.radius,lastTime=poison.lastTime},
                smoke=smoke==null?null:new{radius=smoke.radius,lastTime=smoke.lastTime,
                    smokeColorFull=C(smoke.smokeColorFull),smokeColorFake=C(smoke.smokeColorFake)},
                swipe=swipe==null?null:new{swipe.maxDistance,swipe.maxDistanceShot,swipe.maxThrowTime,swipe.minDistance,
                    swipe.minDistanceShot,swipe.minThrowTime,swipe.throwfactor,swipe.distanceTreshold,
                    spawnPointLeftPath=PathOf(swipe.spawnPointLeft),spawnPointRightPath=PathOf(swipe.spawnPointRight)},
                click=click==null?null:new{click.autofire,click.scopeNum,click.showScope},
                projectileContent=new{frag=projectile.fragGrenade.GetType().FullName,
                    flash=projectile.flashGrenade.GetType().FullName,smoke=projectile.smokeGrenade.GetType().FullName,
                    poison=projectile.posionGrenade.GetType().FullName,molotov=projectile.molotovGrenade.GetType().FullName},
                bulletType=weapon.bulletPrefab.GetType().FullName,bulletSource=prefab,bulletGuid=guid,bulletFileId=fileId,bulletSha256=Hash(prefab)});
        }
        rows=rows.OrderBy(x=>JsonConvert.SerializeObject(x),StringComparer.Ordinal).ToList();
        if(rows.Count!=8)throw new InvalidOperationException("Unexpected grenade count "+rows.Count);
        File.WriteAllText(output,JsonConvert.SerializeObject(new{client="1.4.0",source=source,sha256=Hash(source),
            playerPath=PathOf(player.transform),alliesBulletMask=(int)layers.alliesBulletMask,enemiesBulletMask=(int)layers.enemiesBulletMask,
            destroyableMask=(int)TagsAndLayers.destroyableObjectsMask,layerSource=layerSource,layerSha256=Hash(layerSource),
            weaponCount=rows.Count,weapons=rows},Formatting.Indented));
        Debug.Log("GRENADE_EXPORT_PASSED weapons="+rows.Count);EditorApplication.Exit(0);
    }
    private static string Hash(string path){using(var sha=SHA256.Create())return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-","").ToLowerInvariant();}
    private static string PathOf(Transform t){if(t==null)throw new InvalidOperationException("Missing grenade transform.");return t.parent==null?t.name:PathOf(t.parent)+"/"+t.name;}
    private static float[] V(Vector3 v){return new[]{v.x,v.y,v.z};}
    private static float[] C(Color v){return new[]{v.r,v.g,v.b,v.a};}
}
